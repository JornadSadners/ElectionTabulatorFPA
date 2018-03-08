using BaseLayerObjects;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace ElectionTabulatorFPA
{
    //modified from: https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/tutorial-server-broadcast-with-signalr
    public class VoteTicker
    {
        // public List<Candidate> Candidates;

        private readonly static Lazy<VoteTicker> _instance = new Lazy<VoteTicker>(() => new VoteTicker(GlobalHost.ConnectionManager.GetHubContext<ResultsHub>().Clients));
        private readonly ConcurrentDictionary<int, Candidate> _candidates = new ConcurrentDictionary<int, Candidate>();
        private readonly object _updateCandidatesLock = new object();
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
        private readonly Random _updateOrNotRandom = new Random();
        //private readonly Timer _timer;
        private volatile bool _updatingCandidates = false;

        //NewVoteNotifier voteNotifier;
        private VoteTicker(IHubConnectionContext<dynamic> clients)
        {

            Clients = clients;
            //  _timer = new Timer(UpdateCandidates, null, _updateInterval, _updateInterval);
        }

        public static VoteTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }
        private void BroadcastResult(Candidate candidate)
        {
            Clients.All.updateResult(candidate);
        }
        public IEnumerable<Candidate> GetAllCandidates()
        {
            GetResultsFromDB();
            return _candidates.Values;
        }
        private void UpdateCandidates(object state)
        {
            lock (_updateCandidatesLock)
            {
                if (!_updatingCandidates)
                {
                    _updatingCandidates = true;
                    //GetResultsFromDB();
                    foreach (var candidate in _candidates.Values)
                    {
                        //BroadcastResult(candidate);
                    }

                    _updatingCandidates = false;
                }
            }
        }

        public void GetResultsFromDB()
        {

            _candidates.Clear();
            var candidates = new List<Candidate>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["B231InstructorMachine"].ConnectionString))
            {
                string query = "SELECT CandidateID, FName, LName, PartyName, Seat, VoteCount FROM [dbo].[Candidates] order by VoteCount desc";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Notification = null;
                        DataTable dt = new DataTable();
                        SqlDependency dependency = new SqlDependency(command);
                        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                        // voteNotifier = new NewVoteNotifier(connection, query);
                        //voteNotifier.NewVote += NewVoteReceived;
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        //SqlDependency.Start(connection.ConnectionString);
                        var reader = command.ExecuteReader();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                candidates.Add(new Candidate
                                {
                                    CandidateID = Int32.Parse(dt.Rows[i]["CandidateID"].ToString()),
                                    FName = dt.Rows[i]["FName"].ToString(),
                                    LName = dt.Rows[i]["LName"].ToString(),
                                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                                    Seat = dt.Rows[i]["Seat"].ToString(),
                                    VoteCount = Convert.ToInt32(dt.Rows[i]["VoteCount"])
                                });
                            }
                            candidates.ForEach(candidate => _candidates.TryAdd(candidate.CandidateID, candidate));

                        }
                        //connection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            //return candidates;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            // SqlDependency dependency = sender as SqlDependency;
            // if (dependency != null) dependency.OnChange -= dependency_OnChange;

            if (e.Type == SqlNotificationType.Change)
            {
                //Console.WriteLine($"{e.Type}");
                GetResultsFromDB();
                foreach (var candidate in _candidates.Values)
                {
                    BroadcastResult(candidate);
                }
            }
        }
        //private void BroadcastVotes(Candidate candidate)
        //{
        //    Clients.All.updateResults(candidate);
        //}

    }
}
