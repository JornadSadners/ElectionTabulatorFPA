using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data

public static class ElectionDBClass
{	
    private static string ConString = ""; // Connection String Code Should be Inserted into this Variable

    private static SqlConnection con;

    public static void TestConnection()
    {

    }

    private static void OpenDB()
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

    private static void CloseDB()
    {
        if (con != null)
        { }


    }
}
