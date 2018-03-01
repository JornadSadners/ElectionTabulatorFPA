using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataBaseObjects
{
    public class ElectionDBClass
    {
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
    }
}
