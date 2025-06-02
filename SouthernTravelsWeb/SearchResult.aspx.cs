using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class SearchResult : System.Web.UI.Page
    {
        #region "Member Variable(s)"

        public int pvTourType;
        public int pvTourID;
        public string pvprefixText = "";
        public int pvMinDay;
        public int pvMaxDay;
        public int pvTravelMonth;
        public bool pvIncludeCityOutput;
        public int pvZoneID;
        public bool pvIsLTC = false;
        public string pvRedirectPage = "";
        public int pvPageSize;

        #endregion

        #region "Property"
        public string fldRedirectUrl
        {
            get { return pvRedirectPage; }
            set { pvRedirectPage = value; }
        }




        #endregion

        #region "Page Events"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        #endregion
    }
}