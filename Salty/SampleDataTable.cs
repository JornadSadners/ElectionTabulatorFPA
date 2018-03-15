using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salty
{
    class SampleDataTable
    {
        public static  DataTable myTable;
        /// <summary>
        /// Below would be rough example of the saltedHash datatable would look like
        /// SQL table would have three values: id = int, salt= varbinary, hash =varbinary
        /// </summary>
        public static void GenerateDataTable()
        {
           
        
            // Create a new DataTable.
            myTable = new DataTable("Table");

            DataColumn id = new DataColumn("SaltedHashID"); //or userid
            id.DataType = System.Type.GetType("System.Int32");
            myTable.Columns.Add(id);

            DataColumn Salt = new DataColumn("Salt");
            Salt.DataType = System.Type.GetType("System.Byte[]");
            myTable.Columns.Add(Salt);

            DataColumn Hash = new DataColumn("Hash");
            Hash.DataType = System.Type.GetType("System.Byte[]");
            myTable.Columns.Add(Hash);
        }
    }
}
