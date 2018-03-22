using DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectionTabulatorFPA
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ViewState["Mayor"] != null)
            {
                string[] tokens = ((string)ViewState["Mayor"]).Split(new char[] { ',' });
                Candidate candidate = new Candidate();
                candidate.LName = tokens[0];
                candidate.FName = tokens[1];
                ElectionDBClass.AddVoteToCandidate(candidate);
            }
            if (ViewState["CityCouncil"] != null)
            {
                string[] tokens = ((string)ViewState["CityCouncil"]).Split(new char[] { ',' });
                Candidate candidate = new Candidate();
                candidate.LName = tokens[0];
                candidate.FName = tokens[1];
                ElectionDBClass.AddVoteToCandidate(candidate);
            }
            if (ViewState["Superintendent"] != null)
            {
                string[] tokens = ((string)ViewState["Superintendent"]).Split(new char[] { ',' });
                Candidate candidate = new Candidate();
                candidate.LName = tokens[0];
                candidate.FName = tokens[1];
                ElectionDBClass.AddVoteToCandidate(candidate);
            }
        }
        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = ((RadioButton)sender);
            if (radio.GroupName == "Mayor")
            {
                ViewState["Mayor"] = radio.Text;
            }
            if (radio.GroupName == "CityCouncil")
            {
                ViewState["CityCouncil"] = radio.Text;
            }
            if (radio.GroupName == "Superintendent")
            {
                ViewState["Superintendent"] = radio.Text;
            }
        }
    }
}