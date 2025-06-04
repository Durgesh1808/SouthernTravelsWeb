using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class ThankYou : System.Web.UI.Page
    {
        protected string ThankYouMsg; protected string TransactionResponse;
        protected void Page_Load(object sender, EventArgs e)
        {
            ThankYouMsg = "Our destination expert will reach you soon.";

            if (!IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["PrevPage"]).ToLower() == "AgentRegistrationEnq".ToLower())
                {
                    DivAgent.Visible = true; divother.Visible = false;
                }
                else
                { DivAgent.Visible = false; divother.Visible = true; }
            }
        }
    }
}