using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectionTabulatorFPA
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonVote_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerifyInformation.aspx");
        }

        protected void ButtonResults_Click(object sender, EventArgs e)
        {
            Response.Redirect("Results.aspx");
        }
    }
}