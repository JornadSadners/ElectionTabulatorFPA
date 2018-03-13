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

        public static DataTable ResultsTable() // should create the DataTable within the code based on the selected Table
        {
            DataTable dtResults = new DataTable();
            string sql = ""; // Insert Command for the Database here, something like "SELECT * From ElectionTable"
            SqlDataAdapter da;
            OpenDB();
            da = new SqlDataAdapter(sql, con);
            da.FillSchema(dtResults, SchemaType.Source);
            da.Fill(dtResults);
            CloseDB();
            return dtResults;
        }

        public static void VerifyVoter(Voter V) // method to verify voter information
        {
            
        }

        public static Voter RetrieveVoterObject(int VoterID) // should retrieve a Voter Object based on the input of a VoterID, Voter has an override for .ToString()
        {
            SqlDataReader DR;
            Voter V = new Voter();
            string sql = "SELECT * From Voters where VoterID = " + VoterID.ToString(); // !!! placeholder may need to be changed 
            OpenDB();

            SqlCommand cmd = new SqlCommand(sql, con);
            DR = cmd.ExecuteReader();
            if (DR.Read())
            {
                V.VoterID = (int)DR["VoterID"];
                // fill in with the rest of the datatable voter properties, name, address etc.

                DR.Close();
                CloseDB();

                return V;
            }

            else
            {
                CloseDB();

                throw new Exception($"VoterID {VoterID} Not Found");
            }
        }
    }
}
