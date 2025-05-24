using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class company_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetSection();
        }
        public void SetSection()
        {
            if (Request.QueryString["Check"] != null && Request.QueryString["Check"] == "About")
            {
                tab_company.Attributes.Add("class", "tab-pane fade in active");
                aCompany.Attributes.Add("class", "active");
            }
            if (Request.QueryString["Check"] != null && Request.QueryString["Check"] == "csr")
            {
                tab_csr.Attributes.Add("class", "tab-pane fade in active");
                aCSR.Attributes.Add("class", "active");
            }
            if (Request.QueryString["Check"] != null && Request.QueryString["Check"] == "Award")
            {
                tab_awards.Attributes.Add("class", "tab-pane fade in active");
                aAward.Attributes.Add("class", "active");
            }
            if (Request.QueryString["Check"] != null && Request.QueryString["Check"] == "Test")
            {
                tab_Offices.Attributes.Add("class", "tab-pane fade in active");
                aTest.Attributes.Add("class", "active");
            }


        }
    }
}