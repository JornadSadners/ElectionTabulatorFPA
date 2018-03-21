using DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectionTabulatorFPA
{
    public partial class VerifyInformation : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Voter voter = new Voter();
            if (txtFirstName.Text != string.Empty)
            {
                voter.Fname = txtFirstName.Text;
            }
            if (txtLastName.Text != string.Empty)
            {
                voter.Lname = txtLastName.Text;
            }

            ///////////////
            //////////////////////
            ///////////////
            Response.Redirect("Ballot.aspx");
        }
    }
}