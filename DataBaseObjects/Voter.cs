using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseObjects
{
    public class Voter
    {
        public int VoterID { get; set; }

        public Voter(
            int VoterID)
        {
            this.VoterID = VoterID;
            // fill in with rest of DataTable Columns
        }

        public Voter()
        {
        }

        public override string ToString() // allows Voter Object to be easily converted to String Properly
        {
            return $"Voter ID: {VoterID}"; // Ditto

            // may need to edit this based on our specific needs
        }
    }
}
