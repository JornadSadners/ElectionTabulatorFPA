using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseObjects
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PartyName { get; set; }
        public string Seat { get; set; }
        public int VoteCount { get; set; }
        
            public Candidate(
            int CandidateID,
            string Fname,
            string Lname,
            string PartyName,
            string Seat,
            int VoteCount)

        {
            this.CandidateID = CandidateID;
            this.Fname = Fname;
            this.Lname = Lname;
            this.PartyName = PartyName;
            this.Seat = Seat;
        }

        public Candidate()
        {
        }

        public override string ToString() // allows Voter Object to be easily converted to String Properly
        {
            return $"Candidate ID: {CandidateID} First Name: {Fname} Last Name: {Lname} Party Name: {PartyName} Seat: {Seat} Vote Count: {VoteCount}";

            // may need to edit this based on our specific needs
        }
    }
}
