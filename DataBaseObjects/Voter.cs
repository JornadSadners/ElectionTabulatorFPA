using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseObjects
{
    [Serializable]
    public class Voter
    {
        public int VoterID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool HasVoted { get; set; }

        public Voter(
            int VoterID,
            string Fname,
            string Lname,
            bool HasVoted)
            
        {
            this.VoterID = VoterID;
            this.Fname = Fname;
            this.Lname = Lname;
            this.HasVoted = HasVoted;
        }

        public Voter()
        {
        }

        public override string ToString() // allows Voter Object to be easily converted to String Properly
        {
            return $"Voter ID: {VoterID} First Name: {Fname} Last Name: {Lname} Has Voted?: {HasVoted}";

            // may need to edit this based on our specific needs
        }
    }
}
