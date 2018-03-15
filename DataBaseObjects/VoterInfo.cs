﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseObjects
{
    [Serializable]
    public class VoterInfo
    {
        public int VoterID { get; set; } 
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }

        public VoterInfo(int voterID, byte[] salt, byte[] hash)
        {
            this.VoterID = voterID;
            this.Salt = salt;
            this.Hash = hash;
        }

        public VoterInfo()
        {

        }

        public override string ToString() // allows VoterInfo Object to be easily converted to String Properly
        {
            return $"Voter ID: {VoterID} Salt: {Salt} Hash: {Hash}";

            // may need to edit this based on our specific needs
        }
    }
}
