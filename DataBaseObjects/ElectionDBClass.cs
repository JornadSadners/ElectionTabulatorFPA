using System;
using System.Data;
using System.Data.SqlClient;


namespace DataBaseObjects
{
    public class ElectionDBClass
    {
    	
        private static string ConString = ""; // Connection String Code Should be Inserted into this Variable

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

        public static DataTable VotersTable() // should create the DataTable within the code based on the selected Table
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

        public static DataTable VoterInfoTable()
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

        public static void VerifyVoter(Voter VUser, Voter VData) // method to verify voter information
        {

            // VUser is the Voter Object retrieved from the Users input from the program
            // VData is the Voter Object retrieved from the Database

            string VUserString = VUser.ToString();
            string VDataString = VData.ToString();

            if (VUserString == VDataString)
            {
                // strings match and the voter is correct
            }

            else
            {
                // strings don't match, verification failed
            }
             
        }

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
    }
}
