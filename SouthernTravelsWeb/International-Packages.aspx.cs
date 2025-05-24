using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class International_Packages : System.Web.UI.Page
    {

        string pOfferIDs = "";

        public string fldOfferIDs
        {
            get
            {
                if (Request.QueryString["ofr"] != null && Request.QueryString["ofr"].ToString().Trim() != string.Empty)
                {
                    pOfferIDs = Request.QueryString["ofr"].ToString().Trim();
                }
                else
                {
                    pOfferIDs = "1";
                }
                return pOfferIDs;
            }
            set { pOfferIDs = value; }
        }
        public string fldOffers
        {
            get
            {
                if (fldOfferIDs == "1")
                {
                    return "";
                }
                else
                {
                    return "_Offer" + fldOfferIDs;
                }
            }
        }
        #region "Events"
        protected void Page_Load(object sender, EventArgs e)
        {
           UCSearchTours1.fldTourType = 17;
        }
        #endregion
        #region "Methods"
      
        #endregion
    }
}