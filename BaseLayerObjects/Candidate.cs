﻿using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BaseLayerObjects
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PartyName { get; set; }
        public string Seat { get; set; }
        public int VoteCount { get; set; }
        public Candidate()
        {

        }
        public Candidate(int candidateID, string fname, string lname, string partyname, string seat)
        {
            this.CandidateID = candidateID;
            this.FName = fname;
            this.LName = lname;
            this.PartyName = partyname;
            this.Seat = seat;
            this.VoteCount = 0;
        }
    }
}
