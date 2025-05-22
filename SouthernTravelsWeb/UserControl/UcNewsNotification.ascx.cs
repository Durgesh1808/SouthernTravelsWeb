using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcNewsNotification : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        private string pvlandingUrl = "";
        private string NewsType = "";

        #endregion
        #region "Property(s)"
        public string fllandingUrl
        {
            get
            {
                return pvlandingUrl;
            }
            set
            {
                pvlandingUrl = value;
            }
        }
        public string fldNewsType
        {
            get
            {
                return NewsType;
            }
            set
            {
                NewsType = value;
            }
        }


        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindNewsNotification();
            }
            catch { }


        }
        #endregion
        #region "Method(s)"
        private void BindNewsNotification()
        {
            ClsCommon objCommon = new ClsCommon();
            int NewsID = 0;
            string strNewsType = NewsType;
            int IsActive = 1;
            string LandingURL = "";
            // string EventDate=txtEventDate.Text.Trim();
            DateTime? lFromDate = null;
            DateTime? lToDate = null;
            int TourId = 0;
            int TourType = 0;
            DataTable dtNewsNotification = objCommon.GetNewsNotificationList(NewsID, strNewsType, IsActive, lFromDate, lToDate, TourId, LandingURL, TourType);
            repNews.DataSource = dtNewsNotification;
            repNews.DataBind();

        }
        #endregion
    }
}