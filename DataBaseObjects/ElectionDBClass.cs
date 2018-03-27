using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DataBaseObjects
{
    public class ElectionDBClass
    {

        private static string ConString = ConfigurationManager.ConnectionStrings["FPA"].ConnectionString;

        private static SqlConnection con;

        public static string TestConnection() // tests the connection and returns a message
        {
            try
            {
                OpenDB();
                CloseDB();
                return "Test Succeeded";
            }

            catch(Exception ex)
            {
                return "Test Failed, Error Code: " + ex.ToString();
            }
        }

        private static void OpenDB() // opens the DataBase
        {
            if (con == null)
            {
                con = new SqlConnection(ConString);
            }

            if (con.State != System.Data.ConnectionState.Open)
            {
               con.Open();
            }
        }

        private static void CloseDB() // closes the DataBase
        {
            if (con != null)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public static DataTable VotersTable()
        {
            DataTable VotersTable = new DataTable();
            string sql = "SELECT * From Voters";
            SqlDataAdapter da;
            OpenDB();
            da = new SqlDataAdapter(sql, con);
            da.FillSchema(VotersTable, SchemaType.Source);
            da.Fill(VotersTable);
            CloseDB();
            return VotersTable;
        }

        public static DataTable VoterInfoTable() // unsure if neccassary
        {
            DataTable VoterInfoTable = new DataTable();
            string sql = "SELECT * From VoterInfo";
            SqlDataAdapter da;
            OpenDB();
            da = new SqlDataAdapter(sql, con);
            da.FillSchema(VoterInfoTable, SchemaType.Source);
            da.Fill(VoterInfoTable);
            CloseDB();
            return VoterInfoTable;
        }

        public static DataTable CandidateTable()
        {
            DataTable CandidateTable = new DataTable();
            string sql = "SELECT * From VoterInfo";
            SqlDataAdapter da;
            OpenDB();
            da = new SqlDataAdapter(sql, con);
            da.FillSchema(CandidateTable, SchemaType.Source);
            da.Fill(CandidateTable);
            CloseDB();
            return CandidateTable;
        }

        //public static void VerifyVoter(VoterInfo VUser, VoterInfo VData) // method to verify voter information
        //{

        //    // VUser is the Voter Object retrieved from the Users input from the program
        //    // VData is the Voter Object retrieved from the Database

        //    string VUserString = VUser.ToString();
        //    string VDataString = VData.ToString();

        //    if (VUserString == VDataString)
        //    {
        //        // strings match and the voter is correct
        //    }

        //    else
        //    {
        //        // strings don't match, verification failed
        //    }
             
        //    

            
        //}

        public static Voter RetrieveVoterObject(int VoterID) // should retrieve a Voter Object based on the input of a VoterID, Voter has an override for .ToString()
        {
            SqlDataReader DR;
            Voter VData = new Voter();
            string sql = "SELECT * From Voters where VoterID = " + VoterID.ToString();
            OpenDB();

            SqlCommand cmd = new SqlCommand(sql, con);
            DR = cmd.ExecuteReader();
            if (DR.Read())
            {
                VData.VoterID = (int)DR["VoterID"];
                VData.Fname = (string)DR["Fname"];
                VData.Lname = (string)DR["Lname"];
                VData.HasVoted = (bool)DR["HasVoted"]; // watch this one, might need to specify a 0 or 1 instead of true or false

                DR.Close();
                CloseDB();

                return VData;
            }

            else
            {
                CloseDB();

                throw new Exception($"VoterID {VoterID} Not Found");
            }
        }

        public static Candidate RetrieveCandidateObject(int CandidateID) // should retrieve a Candidate Object based on the input of a CandidateID, Candidate has an override for .ToString()
        {
            SqlDataReader DR;
            Candidate CData = new Candidate();
            string sql = "SELECT * From Candidates where VoterID = " + CandidateID.ToString();
            OpenDB();

            SqlCommand cmd = new SqlCommand(sql, con);
            DR = cmd.ExecuteReader();
            if (DR.Read())
            {
                CData.CandidateID = (int)DR["CandidateID"];
                CData.FName = (string)DR["Fname"];
                CData.LName = (string)DR["Lname"];
                CData.PartyName = (string)DR["PartyName"];
                CData.Seat = (string)DR["Seat"];
                CData.VoteCount = (int)DR["VoteCount"];

                DR.Close();
                CloseDB();

                return CData;
            }

            else
            {
                CloseDB();

                throw new Exception($"VoterID {CandidateID} Not Found");
            }
        }

        public static VoterInfo RetrieveVoterInfoObject(int VoterID) // should retrieve a Candidate Object based on the input of a CandidateID, Candidate has an override for .ToString()
        {
            SqlDataReader DR;
            VoterInfo VIData = new VoterInfo();
            string sql = "SELECT * From VoterInfo where VoterID = " + VoterID.ToString();
            OpenDB();

            SqlCommand cmd = new SqlCommand(sql, con);
            DR = cmd.ExecuteReader();
            if (DR.Read())
            {
                VIData.VoterID = (int)DR["VoterID"];
                VIData.Salt = (byte[])DR["Salt"];
                VIData.Hash = (byte[])DR["Hash"];

                DR.Close();
                CloseDB();

                return VIData;
            }

            else
            {
                CloseDB();

                throw new Exception($"VoterID {VoterID} Not Found");
            }
        }

        public static void AddNewVoterInfo(int VoterID, byte[] Salt, byte[] Hash)
        {
            string sql = "INSERT INTO VoterInfo (VoterID, Salt, Hash) values (@VoterID, @Salt, @Hash)";

            SqlTransaction transaction = con.BeginTransaction("AddNewVoterInfo");
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Transaction = transaction;
            
            try
            {
                OpenDB();
                cmd.Parameters.Add(new SqlParameter("@VoterID", VoterID));
                cmd.Parameters.Add(new SqlParameter("@Salt", Salt));
                cmd.Parameters.Add(new SqlParameter("@Hash", Hash));

                cmd.ExecuteNonQuery();
                transaction.Commit(); // !!! trying Transaction functionality, should be working but untested
                CloseDB();
            }

            catch
            {
                try
                {
                    transaction.Rollback();
                    throw new Exception ("AddNewVoterInfo Failed, Transaction Rollback was a Success");
                }
                catch
                {
                    throw new Exception("AddNewVoterInfo Failed, Transaction Rollback Failed");
                }
            }
        }


       // https://stackoverflow.com/questions/19639474/how-to-increment-an-integer-in-sql-c-sharp?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        public static void AddVoteToCandidate(Candidate candidate)
        {
            string sql = $"UPDATE Candidates SET VoteCount = (ISNULL(VoteCount, 0) + 1 ) WHERE  LName = '{candidate.LName}'";
            OpenDB();
            SqlTransaction transaction = con.BeginTransaction("AddVoteToCandidate");
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Transaction = transaction;
            try
            {

                //cmd.Parameters.Add(new SqlParameter("@FName", candidate.FName));
                //cmd.Parameters.Add(new SqlParameter("@LName", candidate.LName));
                int check = cmd.ExecuteNonQuery();
                transaction.Commit();
                if (cmd.ExecuteNonQuery() == 0)
                {
                    transaction.Rollback();                             // !!! updated with transaction functionality do not commit to master until tested to be working correctly
                    throw new Exception("No Candidates Updated");       // https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqltransaction(v=vs.110).aspx information on transactions
                }
                else if (cmd.ExecuteNonQuery() > 1)
                {
                    transaction.Rollback();
                    throw new Exception("More then one Candidate Added");
                }
                CloseDB();
           }

            catch (Exception EX)
            {
                CloseDB();
                transaction.Rollback();
                throw EX;
               
            }
        }

    }
}
