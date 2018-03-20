using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DataBaseObjects;

namespace ElectionTabulatorFPA
{
    public class ResultsHub : Hub
    {
        private readonly VoteTicker _voteTicker;
        public ResultsHub() : this(VoteTicker.Instance) { }
        public ResultsHub(VoteTicker voteTicker)
        {
            _voteTicker = voteTicker;
        }
        [HubMethodName("getAllCandidates")]
        public IEnumerable<Candidate> GetAllCandidates()
        {
            return _voteTicker.GetAllCandidates();
        }
    
    }
}