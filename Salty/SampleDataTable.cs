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
        public static void GenerateDataTable(int id)
        {
            // Create a new DataTable.
 
            DataTable myTable = DataBaseObjects.ElectionDBClass.VoterInfoTable();

            foreach (var r in myTable.Rows)
            {
                DataRow r2 = (DataRow)r;

                r2[0] 
            }
       
        }
    }
}
