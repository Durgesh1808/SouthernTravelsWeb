using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcHotelInIndia : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        private string bgColor = "#b8d558";
        private bool HideBaner, bgBottomimg, leftBotimg, rightBotimg, rightTopimg, leftTopimg, centerImg;
        #endregion
        #region "Property(s)"
        public string BgColor
        {
            get
            {
                return bgColor;
            }
            set
            {
                bgColor = value;
            }
        }

        public bool fldHideBanner
        {
            get
            {
                return HideBaner;
            }
            set
            {
                HideBaner = value;
            }
        }

        public bool BgBottomimg
        {
            get
            {
                return bgBottomimg;
            }
            set
            {
                bgBottomimg = value;
            }
        }

        public bool LeftBotimg
        {
            get
            {
                return leftBotimg;
            }
            set
            {
                leftBotimg = value;
            }
        }

        public bool RightBotimg
        {
            get
            {
                return rightBotimg;
            }
            set
            {
                rightBotimg = value;
            }
        }

        public bool RightTopimg
        {
            get
            {
                return rightTopimg;
            }
            set
            {
                rightTopimg = value;
            }
        }

        public bool LeftTopimg
        {
            get
            {
                return leftTopimg;
            }
            set
            {
                leftTopimg = value;
            }
        }

        public bool CenterImg
        {
            get
            {
                return centerImg;
            }
            set
            {
                centerImg = value;
            }
        }
        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCheckIn.Attributes.Add("readonly", "readonly");
            txtCheckOut.Attributes.Add("readonly", "readonly");
            // Set User Control display property
            if (!IsPostBack)
            {
                GetCity("IN");
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //HiddenField bookHit = Page.FindControl("bookHit") as HiddenField;//(HiddenField)this..FindControl("bookHit");
            //bookHit.Value = "false";
            string CheckInDate = txtCheckIn.Text.Trim();
            string CheckOutDate = txtCheckOut.Text.Trim();
            //if (!Page.IsValid)
            //{
            //    return;
            //}
            DateTime dt = GetDateFormate(CheckInDate);
            if (dt < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
            {
                lblErr.Text = "Check-in date should be higher than todays date.";
                return;
            }
            else
            {
                lblErr.Text = "";
            }
            DateTime dt2 = GetDateFormate(CheckOutDate);
            if (dt2 < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
            {
                lblErr1.Text = "Check-Out date should be higher than todays date.";
                return;
            }
            else
            {
                lblErr1.Text = "";
            }

            if (dt > dt2)
            {
                lblErr1.Text = "Check Out date cannot be more than Check In date."; return;
            }
            else
            {
                lblErr1.Text = "";
            }
            System.TimeSpan diffResult = dt2.Subtract(dt);
            if (Convert.ToInt32(diffResult.Days) > 30)
            {
                lblErr1.Text = "Sorry You Cannot Do  Booking For More Than 30 Days."; return;
            }
            else
            {
                lblErr1.Text = "";
            }
            Session["strCity"] = ddlCity.SelectedItem.ToString().Trim();
            Session["rbtnCity"] = "1";
            //if (rbtnCity.SelectedValue == "Other City")
            //{
            //    Session["strCity"] = ddlCity.SelectedItem.ToString().Trim();
            //    Session["rbtnCity"] = "1";
            //}
            //else
            //{
            //    Session["strCity"] = rbtnCity.SelectedValue.Trim();
            //    Session["rbtnCity"] = "0";
            //}
            //if (CheckInDate.ToString().Contains('-'))
            //{
            //    CheckInDate = CheckInDate.ToString().Replace('-', '/');
            //}
            //if (CheckOutDate.ToString().Contains('-'))
            //{
            //    CheckOutDate = CheckOutDate.ToString().Replace('-', '/');
            //}
            string[] CheckInDate1 = CheckInDate.ToString().Split('/');
            Session["CheckInDay"] = CheckInDate1[0];
            Session["CheckInMonth"] = CheckInDate1[1];
            Session["CheckInYear"] = CheckInDate1[2];
            Session["checkInDate"] = CheckInDate1[1] + "/" + CheckInDate1[0] + "/" + CheckInDate1[2];
            string[] CheckOutDate1 = CheckOutDate.ToString().Split('/');
            Session["CheckOutDay"] = CheckOutDate1[0];
            Session["CheckOutMonth"] = CheckOutDate1[1];
            Session["CheckOutYear"] = CheckOutDate1[2];
            Session["checkInDate"] = CheckOutDate1[1] + "/" + CheckOutDate1[0] + "/" + CheckOutDate1[2];
            int strTotalAudlt = 0;
            int strTotalChild = 0;
            Session["strRooms"] = ddlRoom.SelectedItem.ToString();
            if (ddlRoom.SelectedItem.ToString() == "1")
            {
                Session["strAdult1"] = ddlAdult1.SelectedItem.ToString();
                strTotalAudlt = strTotalAudlt + Convert.ToInt16(ddlAdult1.SelectedItem.ToString());
                //  strQuery += "&strChildrenRoom1=" + ddlChild1.SelectedItem.ToString();
            }
            else if (ddlRoom.SelectedItem.ToString() == "2")
            {
                Session["strAdult1"] = ddlAdult1.SelectedItem.ToString();
                Session["strAdult2"] = ddlAdult2.SelectedItem.ToString();
                strTotalAudlt = strTotalAudlt + Convert.ToInt16(ddlAdult1.SelectedItem.ToString()) +
                    Convert.ToInt16(ddlAdult2.SelectedItem.ToString());
            }
            else if (ddlRoom.SelectedItem.ToString() == "3")
            {
                Session["strAdult1"] = ddlAdult1.SelectedItem.ToString();
                Session["strAdult2"] = ddlAdult2.SelectedItem.ToString();
                Session["strAdult3"] = ddlAdult3.SelectedItem.ToString();
                strTotalAudlt = strTotalAudlt + Convert.ToInt16(ddlAdult1.SelectedItem.ToString()) +
                    Convert.ToInt16(ddlAdult2.SelectedItem.ToString()) + Convert.ToInt16(ddlAdult3.SelectedItem.ToString());
            }
            else if (ddlRoom.SelectedItem.ToString() == "4")
            {
                Session["strAdult1"] = ddlAdult1.SelectedItem.ToString();
                Session["strAdult2"] = ddlAdult2.SelectedItem.ToString();
                Session["strAdult3"] = ddlAdult3.SelectedItem.ToString();
                Session["strAdult4"] = ddlAdult4.SelectedItem.ToString();
                strTotalAudlt = strTotalAudlt + Convert.ToInt16(ddlAdult1.SelectedItem.ToString()) +
                    Convert.ToInt16(ddlAdult2.SelectedItem.ToString()) + Convert.ToInt16(ddlAdult3.SelectedItem.ToString()) +
                    Convert.ToInt16(ddlAdult4.SelectedItem.ToString());
            }
            strTotalChild = strTotalChild + Convert.ToInt16(ddlChild1.SelectedItem.ToString()) +
                Convert.ToInt16(ddlChild2.SelectedItem.ToString()) + Convert.ToInt16(ddlChild3.SelectedItem.ToString()) +
                Convert.ToInt16(ddlChild4.SelectedItem.ToString());
            Session["strChildrenRoom1"] = ddlChild1.SelectedItem.ToString();
            Session["strChildrenRoom2"] = ddlChild2.SelectedItem.ToString();
            Session["strChildrenRoom3"] = ddlChild3.SelectedItem.ToString();
            Session["strChildrenRoom4"] = ddlChild4.SelectedItem.ToString();
            if (ddlChild1Age1.SelectedItem.ToString() != "?")
                Session["strAgeChild1Room1"] = ddlChild1Age1.SelectedValue.ToString();
            if (ddlChild1Age2.SelectedItem.ToString() != "?")
                Session["strAgeChild2Room1"] = ddlChild1Age2.SelectedValue.ToString();
            if (ddlChild1Age3.SelectedItem.ToString() != "?")
                Session["strAgeChild3Room1"] = ddlChild1Age3.SelectedValue.ToString();
            if (ddlChild2Age1.SelectedItem.ToString() != "?")
                Session["strAgeChild1Room2"] = ddlChild2Age1.SelectedValue.ToString();
            if (ddlChild2Age2.SelectedItem.ToString() != "?")
                Session["strAgeChild2Room2"] = ddlChild2Age2.SelectedValue.ToString();
            if (ddlChild2Age3.SelectedItem.ToString() != "?")
                Session["strAgeChild3Room2"] = ddlChild2Age3.SelectedValue.ToString();
            if (ddlChild3Age1.SelectedItem.ToString() != "?")
                Session["strAgeChild1Room3"] = ddlChild3Age1.SelectedValue.ToString();
            if (ddlChild3Age2.SelectedItem.ToString() != "?")
                Session["strAgeChild2Room3"] = ddlChild3Age2.SelectedValue.ToString();
            if (ddlChild3Age3.SelectedItem.ToString() != "?")
                Session["strAgeChild3Room3"] = ddlChild3Age3.SelectedValue.ToString();
            if (ddlChild4Age1.SelectedItem.ToString() != "?")
                Session["strAgeChild1Room4"] = ddlChild4Age1.SelectedValue.ToString();
            if (ddlChild4Age2.SelectedItem.ToString() != "?")
                Session["strAgeChild2Room4"] = ddlChild4Age2.SelectedValue.ToString();
            if (ddlChild4Age3.SelectedItem.ToString() != "?")
                Session["strAgeChild3Room4"] = ddlChild4Age3.SelectedValue.ToString();
            Session["strTotalAudlt"] = strTotalAudlt.ToString();
            Session["strTotalChild"] = strTotalChild.ToString();
            //Session["strQueryStr"] = "~/SearchResult.aspx" + strQuery;
            // Session["strQueryStr1"] = "SearchResult.aspx" + strQuery;
            Cache.Remove("dtHotelResults" + Session.SessionID);
            Cache.Remove("dtRates" + Session.SessionID);
            Cache.Remove("dtRateDays" + Session.SessionID);
            //Session["EndUserId"] = "EndUser";        
            Response.Redirect("hotelsearch.aspx", true);
        }
        #endregion
        #region "Method(s)"
        private DateTime GetDateFormate(string Date)
        {
            string[] CheckInDate1 = Date.ToString().Split('/');// txtCheckIn.Text.Split('/');
                                                               //string CheckInYear = Convert.ToInt16(CheckInDate1[2].ToString()).ToString("00");
                                                               //string CheckInMonth = Convert.ToInt16(CheckInDate1[1].ToString()).ToString("00");
                                                               //string CheckInDate = Convert.ToInt16(CheckInDate1[0].ToString()).ToString("00");
                                                               //DateTime dt1 = Convert.ToDateTime(CheckInMonth + "/" + CheckInDate + "/" + CheckInYear);
            DateTime dt1 = new DateTime(Convert.ToInt32(CheckInDate1[2]), Convert.ToInt32(CheckInDate1[1]),
                       Convert.ToInt32(CheckInDate1[0]));
            return dt1;
        }

        public DataTable GetCity(string pCountryCode)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@countrycode", SqlDbType.VarChar, 10)
            {
                Value = pCountryCode
            };

            return DataLib.GetDataTableWithParamSP(DataLib.getConnectionString(), StoredProcedures.sp_GetCityDetail, param);
        }
        #endregion
    }
}