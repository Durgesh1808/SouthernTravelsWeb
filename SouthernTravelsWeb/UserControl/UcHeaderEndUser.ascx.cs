using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcHeaderEndUser : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        Current_Section pvMainSection;
        string pvHeaderImgURL, pvHeaderCSSClass; bool pvHeaderNotification = false;
        TOURTYPE pvTourType;
        int pvTourID;
        private string pvlandingUrl = "";
        private string Notification = "";

        #endregion
        #region "Property(s)"
        public Current_Section fldMainSection
        {
            get
            {
                return pvMainSection;
            }
            set
            {
                pvMainSection = value;
            }
        }
        public string fldHeaderImgURL
        {
            get
            {
                return pvHeaderImgURL;
            }
            set
            {
                pvHeaderImgURL = value;
            }
        }
        public string fldHeaderCSSClass
        {
            get
            {
                return pvHeaderCSSClass;
            }
            set
            {
                pvHeaderCSSClass = value;
            }
        }
        public bool fldHeaderNotification
        {
            get
            {
                return pvHeaderNotification;
            }
            set
            {
                pvHeaderNotification = value;
            }
        }
        public TOURTYPE fldTourType
        {
            get
            {
                return pvTourType;
            }
            set
            {
                pvTourType = value;
            }
        }

        public int fldTourID
        {
            get
            {
                return pvTourID;
            }
            set
            {
                pvTourID = value;
            }
        }
        #endregion

        #region "Event(s)"

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.Uri currentUrl = System.Web.HttpContext.Current.Request.Url;
                bool lIsModified = false;
                string NewUrl = currentUrl.AbsoluteUri.ToString();
                
                if (lIsModified)
                {
                    currentUrl = new Uri(NewUrl);
                    System.UriBuilder secureUrlBuilder = new UriBuilder(currentUrl);
                    secureUrlBuilder.Scheme = Uri.UriSchemeHttp;
                    secureUrlBuilder.Port = -1;
                    System.Web.HttpContext.Current.Response.Redirect(secureUrlBuilder.Uri.ToString(), false);
                }
            }
            catch { }

            if (!IsPostBack)
            {
                SetMainSection();
                SetNotificatioSection();

            }
        }

        #endregion

        #region "Method(s)"
        private void SetMainSection()
        {
            MainMHM.Attributes.Add("class", "");
            //MainMAL.Attributes.Add("class", "");
            //MainMCL.Attributes.Add("class", "");
            MainMCU.Attributes.Add("class", "");
            //MainMEB.Attributes.Add("class", "");
            MainMINTC.Attributes.Add("class", "");
            MainMFD.Attributes.Add("class", "");
            MainMHP.Attributes.Add("class", "");
            MainMINT.Attributes.Add("class", "");
            MainMHTL.Attributes.Add("class", "");
            MainMCR.Attributes.Add("class", "");
            //MainMFLIGHT.Attributes.Add("class", "");
            MainMLLTC.Attributes.Add("class", "");
            MainMHTLI.Attributes.Add("class", "");

            switch (fldMainSection)
            {
                case Current_Section.HOME:
                    MainMHM.Attributes.Add("class", "active");
                    break;
                case Current_Section.AGENT_LOGIN:
                    //MainMAL.Attributes.Add("class", "active");
                    break;
                case Current_Section.CUST_Login:
                    // MainMCL.Attributes.Add("class", "active");
                    // aMyAccount.Attributes.Add("class", "active");
                    break;
                case Current_Section.CONTACT_US:
                    MainMCU.Attributes.Add("class", "active");
                    break;
                //case Current_Section.E_BROCHURE:
                //    MainMEB.Attributes.Add("class", "active");
                //    break;


                case Current_Section.FIXED_DEPARTURE:
                    MainMFD.Attributes.Add("class", "active");
                    break;
                case Current_Section.HOLIDAY_PACKAGE_CAR:
                    MainMHP.Attributes.Add("class", "active");
                    break;
                case Current_Section.HOLIDAY_PACKAGE_INTERNATIONAL_FIXED:
                    MainMINT.Attributes.Add("class", "active");
                    break;
                case Current_Section.HOLIDAY_PACKAGE_INTERNATIONAL_CUSTOMIZED:
                    MainMINTC.Attributes.Add("class", "active");
                    break;
                case Current_Section.HOLIDAY_PACKAGE_CRUISE:
                    MainMHP.Attributes.Add("class", "active");
                    break;
                case Current_Section.CAR_COACH_RENTAL:
                    MainMCR.Attributes.Add("class", "active");
                    break;
                case Current_Section.HOTEL_DELHI:
                    MainMHTL.Attributes.Add("class", "active");
                    break;
                case Current_Section.HOTEL_IN_INDIA:
                    MainMHTLI.Attributes.Add("class", "active");
                    break;
                case Current_Section.DOMESTIC_FLIGHT:
                    //MainMFLIGHT.Attributes.Add("class", "active");
                    break;
                case Current_Section.LTC_LFC_TOUR:
                    MainMLLTC.Attributes.Add("class", "active");
                    break;

            }
        }

        public void SetNotificatioSection()
        {
            ClsCommon objCommon = new ClsCommon();
            int NewsID = 0;
            string strNewsType = Notification;
            int IsActive = 1;
            if (Request.Url.PathAndQuery.Split('?').Length > 1)
            {
                string qryString = Request.Url.PathAndQuery.Split('?')[1];
                string[] qryStringValues = qryString.Split('&');
                for (int i = 0; i < qryStringValues.Length; i++)
                {
                    if (qryStringValues[i].ToLower().Contains("tourid"))
                    {
                        fldTourID = Convert.ToInt32(qryStringValues[i].ToString().Split('=')[1]);
                    }

                }
            }
            string urlPath = Request.Url.AbsolutePath;
            FileInfo fileInfo = new FileInfo(urlPath);
            string LandingURL = fileInfo.Name;

            // string EventDate=txtEventDate.Text.Trim();
            DateTime? lFromDate = null;
            DateTime? lToDate = null;
            DataTable dtNewsNotification = objCommon.GetNewsNotificationList(NewsID, strNewsType, IsActive, lFromDate, lToDate, fldTourID, LandingURL, Convert.ToInt32(fldTourType));
            if (dtNewsNotification != null && dtNewsNotification.Rows.Count > 0)
            {
                //  litNotification.Visible=true;
                StringBuilder NotificationStr = new StringBuilder();
                NotificationStr.Append("<div class=\"topnote\"><div class=\"container\"><div class=\"row\"><div class=\"col-md-12 text-center\"><p>");
                NotificationStr.Append(Convert.ToString(dtNewsNotification.Rows[0]["ShortDescription"]));
                if (!string.IsNullOrEmpty(Convert.ToString(dtNewsNotification.Rows[0]["KnowMoreURL"])))
                {
                    NotificationStr.Append("<a href=#KnowMoreURL# class=\"topbtn\">Book Now</a>");
                    NotificationStr.Replace("#KnowMoreURL#", Convert.ToString(dtNewsNotification.Rows[0]["KnowMoreURL"]));

                }
                NotificationStr.Append("</p></div></div></div><div class=\"topclose\"><a href=#>X</a></div></div>");
                litNotification.Text = NotificationStr.ToString();


            }

        }
        #endregion
        protected void btnSubmit_click(object sender, EventArgs e)
        {
            string prefixText = "";
            prefixText = txtSearch.Text.Trim();
            Response.Redirect("SearchResult.aspx?prefixText=" + prefixText);

        }
    }
}