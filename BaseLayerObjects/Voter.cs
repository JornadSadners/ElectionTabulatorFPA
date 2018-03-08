using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BaseLayerObjects
{
    public class Voter
    {
       public static Voter GetVoter(string VoterID)
        {
            ElectionDBClass
        }


        public string VoterID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        // others?

        public Voter(string Fname, string Lname)
        {
            this.Fname = Fname;
            this.Lname = Lname;
        }
    }
}
