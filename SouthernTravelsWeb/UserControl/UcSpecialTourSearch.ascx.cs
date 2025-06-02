using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcSpecialTourSearch : System.Web.UI.UserControl
    {

        #region Member Variable(s)
        private string _loginUserID = "";
        private string _tourStartFrom = "";
        ArrayList DateHdr = new ArrayList();
        #endregion

        #region Property(s)
        public string UserID
        {
            get
            {
                return _loginUserID;
            }
            set
            {
                _loginUserID = value;
            }
        }
        public string fldTourStartFrom
        {
            get
            {
                _tourStartFrom = ddlSPLTourStartFrom.SelectedValue;
                return _tourStartFrom;
            }
            set
            {
                _tourStartFrom = value;
            }
        }

        #endregion

        #region Event(s)
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
           
            if (Page.RouteData.Values["jdate"] != null)
            {
                string[] lJDate = Page.RouteData.Values["jdate"].ToString().Split('/');
                hdFromDate.Value = new DateTime(Convert.ToInt32(lJDate[2]), Convert.ToInt32(lJDate[0]), Convert.ToInt32(lJDate[1])).ToString();
                hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            }
            else
            {
                hdFromDate.Value = DateTime.Now.ToString();
                hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                Session["SPLFromDate"] = null;
            }
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));


        }
        void Page_PreRender(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            btnSPLBook.Attributes.Add("onclick", "javascript:return fnQuickSPLSearchVal();");
            txtSPLJourneyDate.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            { Panel1.Style.Add("display", "none");

                BindYear();
           
                GetTourStartFromSearch();
                string pURL = Request.Url.ToString().ToLower();

                if (Page.RouteData.Values["tourId"] != null && (pURL.Contains("BookSpecialTour.aspx".ToLower()) || pURL.Contains("SpecialTouritinerary.aspx".ToLower())))
                {
                    BindTours(Convert.ToInt32(Page.RouteData.Values["tourId"]));
                }
                else
                {
                    txtSPLJourneyDate.Text = "";
                }
               
                if (Page.RouteData.Values["jdate"] != null)
                {
                    string[] lJDate = Page.RouteData.Values["jdate"].ToString().Split('/');
                    hdFromDate.Value = new DateTime(Convert.ToInt32(lJDate[2]), Convert.ToInt32(lJDate[0]), Convert.ToInt32(lJDate[1])).ToString();
                    hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                    lblCurrentDate.Value = hdFromDate.Value;
                }
                else
                {
                    hdFromDate.Value = DateTime.Now.ToString();
                    hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                    lblCurrentDate.Value = hdFromDate.Value;
                    Session["SPLFromDate"] = null;
                }
                if (Convert.ToDateTime(lblCurrentDate.Value).Month == DateTime.Now.Month
                               && Convert.ToDateTime(lblCurrentDate.Value).Year == DateTime.Now.Year)
                {
                    btnLeft.Visible = false;
                }
            }

            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
           
        }
        protected void txtSPLTour_TextChanged(object sender, EventArgs e)
        {
            if (Session["SPLFromDate"] == null)
            {
                hdFromDate.Value = DateTime.Now.ToString();
                hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            }
            else
            {
                hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
                hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            }
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
        }
        protected void lstSPLTours_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["SPLFromDate"] == null)
            {
                hdFromDate.Value = DateTime.Now.ToString();
                hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            }
            else
            {
                hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
                hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            }
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
        }
        protected void ddlSPLTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["SPLFromDate"] == null)
            {
                hdFromDate.Value = DateTime.Now.ToString();
                hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            }
            else
            {
                hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
                hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            }
            fldTourID.Value = ddlSPLTour.SelectedValue;
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
        }
        protected void ddlSPLTourStartFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBindTours();
        }
        protected void btnSPLBook_Click(object sender, EventArgs e)
        {
            string[] pJDate = txtSPLJourneyDate.Text.Trim().Split('/');
            string lJDate = pJDate[1].ToString().Trim() + "/" + pJDate[0].ToString().Trim() + "/" + pJDate[2].ToString().Trim();
            string pURL = Request.Url.ToString();


            if (pURL.Contains("BookSpecialTour.aspx"))
            {
                Response.Redirect("~/BookSpecialTour.aspx?TourID=" + fldTourID.Value + "&jdate=" + lJDate);
            }
            else if (pURL.Contains("SpecialTouritinerary.aspx"))
            {
                Response.Redirect("~/BookSpecialTour.aspx?TourID=" + fldTourID.Value + "&jdate=" + lJDate);
            }
            else
            {
                Response.Redirect("~/Holiday-Packages-Itinerary_JDate-" + ddlSPLTour.SelectedItem.Text.Trim().Replace(" ", "-") + "_" + Convert.ToString(fldTourID.Value) + "_" + lJDate.Trim().Replace("/", "-"));
            }


        }
        #endregion

        #region Method(s)
        private void BindTours(int pTourID)
        {
            List<GetTourStratFrom_SPResult> lGetTour = null;
            clsAdo objOther = new clsAdo();
            try
            {
                lGetTour = new List<GetTourStratFrom_SPResult>();

                lGetTour = objOther.fnGetTourStratFrom(Convert.ToInt32(pTourID), Convert.ToInt32(TOURTYPE.SPECIAL_TOUR)).ToList();
                if (lGetTour != null && lGetTour.Count > 0)
                {
                    ddlSPLTourStartFrom.SelectedValue = Convert.ToString(lGetTour[0].TourStartFrom);
                    GetBindTours();
                    ddlSPLTour.SelectedValue = lGetTour[0].TourName;
                    fldTourID.Value = pTourID.ToString();
                    if (Page.RouteData.Values["jdate"] != null)
                    {
                        txtSPLJourneyDate.Text = Convert.ToDateTime(Page.RouteData.Values["jdate"]).ToString("dd/MM/yyyy");
                    }
                    if (Session["SPLFromDate"] == null)
                    {
                        hdFromDate.Value = DateTime.Now.ToString();
                        hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                        ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                        ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                    }
                    else
                    {
                        hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
                        hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                        ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                        ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                    }
                    BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
                }
            }
            catch
            {
            }
            finally
            {
                if (lGetTour != null)
                {
                    lGetTour = null;
                }

                if (objOther != null)
                {
                    objOther = null;
                }
            }
        }
        private void GetTourStartFromSearch_XML()
        {
            List<GetTourStartFromSearch_SPResult> lResultSet = new List<GetTourStartFromSearch_SPResult>();
            GetTourStartFromSearch_SPResult lResult = null;
            XDocument XDocTourList = XDocument.Load(Server.MapPath("Common/ToursStartsFrom.xml"));
            try
            {
                var varTourStartFrom = from TourStartFrom in XDocTourList.Descendants("StartsFrom")
                                       where Convert.ToInt32(TourStartFrom.Element("TourType").Value) == Convert.ToInt32(TOURTYPE.SPECIAL_TOUR)
                                       orderby TourStartFrom.Element("CityName").Value
                                       select new
                                       {
                                           CityID = TourStartFrom.Element("CityID").Value.Trim(),
                                           CityName = TourStartFrom.Element("CityName").Value.Trim()
                                       };
                foreach (var TourStartFrom in varTourStartFrom)
                {
                    lResult = new GetTourStartFromSearch_SPResult();
                    lResult.CityID = Convert.ToInt32(TourStartFrom.CityID);
                    lResult.CityName = TourStartFrom.CityName;
                    lResultSet.Add(lResult);
                }

                ddlSPLTourStartFrom.DataSource = lResultSet;
                ddlSPLTourStartFrom.DataValueField = "CityID";
                ddlSPLTourStartFrom.DataTextField = "CityName";
                ddlSPLTourStartFrom.DataBind();
                ddlSPLTourStartFrom.Items.Insert(0, new ListItem("Tour starting from", "0"));
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lResultSet != null)
                {
                    lResultSet = null;
                }
                if (lResult != null)
                {
                    lResult = null;
                }
                if (XDocTourList != null)
                {
                    XDocTourList = null;
                }
            }
        }
        private void GetTourStartFromSearch()
        {
            List<GetTourStartFromSearch_SPResult> lResultSet = null;
           
            clsAdo lclsEndObj = null;
            try
            {
                lclsEndObj = new clsAdo();
                lResultSet = new List<GetTourStartFromSearch_SPResult>();
                lResultSet = lclsEndObj.fnGetTourStartFromSearch(Convert.ToInt32(TOURTYPE.SPECIAL_TOUR));
                ddlSPLTourStartFrom.DataSource = lResultSet;
                ddlSPLTourStartFrom.DataValueField = "CityID";
                ddlSPLTourStartFrom.DataTextField = "CityName";
                ddlSPLTourStartFrom.DataBind();
                ddlSPLTourStartFrom.Items.Insert(0, new ListItem("Tour starting from", "0"));
            }
            catch (Exception ex)
            {

            }
            finally
            {
               
                if (lResultSet != null)
                {
                    lResultSet = null;
                }
            }
        }
        /// <summary>
        /// Use Xml For Fill Tours Info
        /// </summary>
        private void GetBindTours_XML()
        {
            List<GetTourS_Search_SPResult> lResultSet = new List<GetTourS_Search_SPResult>(); ;
            GetTourS_Search_SPResult lResult = null;
            XDocument XDocTourList = XDocument.Load(Server.MapPath("Common/QuickSearchTours.xml"));
            try
            {
                var varTourList = from TourList in XDocTourList.Descendants("TourList")
                                  where Convert.ToInt32(TourList.Element("TourType").Value) == Convert.ToInt32(Convert.ToInt32(TOURTYPE.SPECIAL_TOUR))
                                  && Convert.ToInt32(TourList.Element("StartsFromID").Value.Trim()) == Convert.ToInt32(ddlSPLTourStartFrom.SelectedValue)
                                  orderby TourList.Element("TourName").Value
                                  select new
                                  {
                                      TourNo = TourList.Element("TourNo").Value.Trim(),
                                      TourName = TourList.Element("TourName").Value.Trim(),
                                      Tour_Short_key = TourList.Element("Tour_Short_key").Value,
                                      StartsFromID = TourList.Element("StartsFromID").Value.Trim(),
                                      TourType = TourList.Element("TourType").Value.Trim()
                                  };
                foreach (var Tour in varTourList)
                {
                    lResult = new GetTourS_Search_SPResult();
                    lResult.TourNo = Convert.ToInt16(Tour.TourNo);
                    lResult.Tour_Short_key = Tour.Tour_Short_key;
                    lResult.TourName = Tour.TourName;
                    lResultSet.Add(lResult);
                }
                if (lResultSet != null && lResultSet.Count > 0)
                {
                    //lstSPLTours.DataSource = lResultSet;
                    //lstSPLTours.DataValueField = "TourNo";
                    //lstSPLTours.DataTextField = "TourName";
                    //lstSPLTours.DataBind();

                    ddlSPLTour.DataSource = lResultSet;
                    ddlSPLTour.DataValueField = "TourNo";
                    ddlSPLTour.DataTextField = "TourName";
                    ddlSPLTour.DataBind();
                    ddlSPLTour.Items.Insert(0, new ListItem("I want to go to", "0"));
                }

                fldTourID.Value = "0";
                //txtSPLTour.Text = "";
                txtSPLJourneyDate.Text = "";

                if (Session["SPLFromDate"] == null)
                {
                    hdFromDate.Value = DateTime.Now.ToString();
                    hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                }
                else
                {
                    hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
                    hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                }
                BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lResult != null)
                {
                    lResult = null;
                }
                if (XDocTourList != null)
                {
                    XDocTourList = null;
                }
                if (lResultSet != null)
                {
                    lResultSet = null;
                }
            }
        }
        private void GetBindTours()
        {
            List<GetTourS_Search_SPResult> lResultSet = null;
            clsAdo lclsEndObj = null;
            try
            {
                lclsEndObj = new clsAdo();
                lResultSet = new List<GetTourS_Search_SPResult>();
                lResultSet = lclsEndObj.fnGetTourS_Search(ddlSPLTourStartFrom.SelectedValue, "", Convert.ToInt32(TOURTYPE.SPECIAL_TOUR));
               
                ddlSPLTour.DataSource = lResultSet;
                ddlSPLTour.DataValueField = "TourNo";
                ddlSPLTour.DataTextField = "TourName";
                ddlSPLTour.DataBind();
                ddlSPLTour.Items.Insert(0, new ListItem("I want to go to", "0"));
                fldTourID.Value = "0";
             
                txtSPLJourneyDate.Text = "";
                if (Session["SPLFromDate"] == null)
                {
                    hdFromDate.Value = DateTime.Now.ToString();
                    hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                }
                else
                {
                    hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
                    hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                }
                BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lclsEndObj != null)
                {
                    lclsEndObj = null;
                }
                if (lResultSet != null)
                {
                    lResultSet = null;
                }
            }
        }
        private void BindYear()
        {
            ddlSPLYear.Items.Clear();
            DateTime startYear = DateTime.Now;
            while (startYear.Year < DateTime.Now.AddYears(2).Year)
            {
                ListItem li = new ListItem();
                li.Value = startYear.Year.ToString();
                li.Text = startYear.Year.ToString();
                ddlSPLYear.Items.Add(li);
                startYear = startYear.AddYears(1);
            }
        }

        #region Calender
        private void BindCalendar(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DateHdr = new ArrayList();
                int lTotalDays = Convert.ToInt32(DateTime.DaysInMonth(FromDate.Year, FromDate.Month));
                DateTime lNext = new DateTime(Convert.ToInt32(FromDate.Year.ToString()), Convert.ToInt32(FromDate.Month), lTotalDays);
                DateTime lPrev = new DateTime(Convert.ToInt32(FromDate.Year.ToString()), Convert.ToInt32(FromDate.Month), 01);
                lblStartDate.Value = FromDate.ToString("MMMM") + " " + FromDate.Year.ToString();

                DateHdr.Add("Sun");
                DateHdr.Add("Mon");
                DateHdr.Add("Tue");
                DateHdr.Add("Wed");
                DateHdr.Add("Thu");
                DateHdr.Add("Fri");
                DateHdr.Add("Sat");

                DataTable dt = new DataTable();

                dt.Columns.Add("Sun");
                dt.Columns.Add("Mon");
                dt.Columns.Add("Tue");
                dt.Columns.Add("Wed");
                dt.Columns.Add("Thu");
                dt.Columns.Add("Fri");
                dt.Columns.Add("Sat");


                clsAdo lclsEndObj = null;
                DataTable dtTourDate = new DataTable();
                try
                {
                    string pHours = "0";
                    pHours = "-" + pHours;
                    lclsEndObj = new clsAdo();
                    dtTourDate = lclsEndObj.fnGetSpecialTourJourneyDate(Convert.ToInt32(fldTourID.Value), FromDate.Month, FromDate.Year, Convert.ToInt32(pHours));
                    lbl.Text = "(" + FromDate.ToString("MMM") + " " + FromDate.ToString("yyyy") + ")<br>Seat Availability in";

                    ArrayList ArrDays = new ArrayList();

                    int pRow = 5;
                    if ((lPrev.DayOfWeek.ToString() == "Friday" && lTotalDays == 30)
                         || (lPrev.DayOfWeek.ToString() == "Friday" && lTotalDays == 31)
                         || (lPrev.DayOfWeek.ToString() == "Saturday" && lTotalDays == 30)
                         || (lPrev.DayOfWeek.ToString() == "Saturday" && lTotalDays == 31))
                    {
                        pRow = 6;
                    }

                    for (int Row = 0; Row < pRow; Row++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int Week = 0; Week < dt.Columns.Count; Week++)
                        {
                            string[] DateArr = lPrev.ToString("D").ToString().Split(',');
                            string lDay = DateArr[0].Substring(0, 3);
                            string lMon = DateArr[1].Substring(0, 4);
                            string lDate = DateArr[1].Substring(DateArr[1].Length - 2, 2);
                            string lYear = DateArr[2].Substring(DateArr[2].Length - 2, 2);
                            string lShortDate = lDate.Trim() + " " + lMon.Trim() + " " + lYear.Trim();
                            if (lMon.Trim() == FromDate.ToString("MMM"))
                            {
                                if (dt.Columns[Week].ToString().ToUpper() == lDay.ToString().ToUpper().Trim())
                                {
                                    dr[Week] = lDate.ToString().Trim();
                                    ArrDays.Add(lPrev.AddDays(1).ToString());
                                    lPrev = lPrev.AddDays(1);
                                }
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                    gvRoomDetails.DataSource = dt;
                    gvRoomDetails.DataBind();
                    int lCurentMonth = DateTime.Now.Month;
                    int lCurentDay = DateTime.Now.Day;
                    foreach (GridViewRow item in gvRoomDetails.Rows)
                    {

                        for (int i = 0; i < DateHdr.Count; i++)
                        {
                            try
                            {
                                item.Cells[i].Width = Unit.Pixel(25);
                                item.Cells[i].Height = Unit.Pixel(30);
                                item.Cells[i].BorderWidth = Unit.Pixel(1);
                                item.Cells[i].BorderColor = System.Drawing.Color.White;
                                item.Cells[i].BackColor = System.Drawing.Color.FromName("#f3f3f3");
                                item.Cells[i].ForeColor = System.Drawing.Color.FromName("#848F98");

                                //item.Cells[i].Style.Add("font-weight", "bold");
                                item.Cells[i].Style.Add("text-align", "center");
                                item.Cells[i].Style.Add("vertical-align", "middle");
                                //item.Cells[i].ForeColor = System.Drawing.Color.Black;

                            }
                            catch { }
                            if (item.Cells[i].Text != "" && item.Cells[i].Text != "&nbsp;")
                            {
                                HiddenField hdJDate = new HiddenField();
                                hdJDate.ID = "hdJDate" + item.Cells[i].Text;
                                item.Cells[i].Controls.Add(hdJDate);
                                hdJDate.Value = Convert.ToDateTime(item.Cells[i].Text + lblStartDate.Value).ToString("MM/dd/yyyy");

                                Label lblDate = new Label();
                                lblDate.ID = "lblDate" + item.Cells[i].Text;
                                lblDate.Text = item.Cells[i].Text;
                                item.Cells[i].Controls.Add(lblDate);
                                item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
                                item.Cells[i].VerticalAlign = VerticalAlign.Top;


                            }
                        }
                    }

                    foreach (GridViewRow item in gvRoomDetails.Rows)
                    {
                        item.Style.Add("font-size", "12px");
                        for (int i = 0; i < DateHdr.Count; i++)
                        {
                            if (item.Cells[i].Text != "" && item.Cells[i].Text != "&nbsp;")
                            {

                                Label lblDate = (Label)item.Cells[i].FindControl("lblDate" + item.Cells[i].Text);
                                HiddenField hdJDate = (HiddenField)item.Cells[i].FindControl("hdJDate" + item.Cells[i].Text);
                                DateTime pDate = Convert.ToDateTime(hdJDate.Value);
                                for (int lTourDate = 0; lTourDate < dtTourDate.Rows.Count; lTourDate++)
                                {
                                    DateTime JDate = Convert.ToDateTime(dtTourDate.Rows[lTourDate]["JourneyDate"].ToString());
                                    if (pDate.ToString("MM/dd/yyyy") == JDate.ToString("MM/dd/yyyy"))
                                    {
                                        if (pDate.ToString("yyyy").Trim() == JDate.ToString("yyyy").Trim())
                                        {
                                            if (pDate.ToString("MMM").Trim() == JDate.ToString("MMM").Trim())
                                            {
                                                if (pDate.ToString("dd").Trim() == JDate.ToString("dd").Trim())
                                                {


                                                    item.Cells[i].ForeColor = System.Drawing.Color.FromName("#848f98");
                                                    item.Cells[i].Style.Add("font-size", "12px");
                                                    item.Cells[i].Style.Add("decoration", "none");
                                                    LinkButton lbDate = new LinkButton();
                                                    lbDate.ID = "lbDate" + item.Cells[i].Text;
                                                    lbDate.CommandName = "lbDate";
                                                    lbDate.ToolTip = "Select Date";
                                                    lbDate.CssClass = "";

                                                    lbDate.Click += new EventHandler(lbDate_Click);
                                                    item.Cells[i].Controls.Add(lbDate);

                                                    lbDate.Attributes.Add("onclick", "javascript:PopupHide();");
                                                    lbDate.Text = item.Cells[i].Text;
                                                    lbDate.Attributes.Add("onmouseover", "this.style.color='#f3f3f3';");
                                                    lbDate.Attributes.Add("onmouseout", "this.style.color='#848f98'");
                                                    lbDate.Style.Add("color", "#848f98");
                                                    lbDate.Text = "<br/>Book";


                                                    item.Cells[i].Attributes.Add("onmouseover", "this.style.color='White';this.style.decoration='none';this.style.backgroundColor='#F9B32F'");
                                                    // This will change back the ground color
                                                    item.Cells[i].Attributes.Add("onmouseout", "this.style.color='#848f98';this.style.backgroundColor='#f3f3f3'");
                                                    item.Cells[i].BackColor = System.Drawing.Color.FromName("#f3f3f3");
                                                }


                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (lclsEndObj != null)
                    {
                        lclsEndObj = null;
                    }
                    if (dtTourDate != null)
                    {
                        dtTourDate.Dispose();
                        dtTourDate = null;
                    }
                }

            }
            catch { }
        }

        protected void lbDate_Click(object sender, EventArgs e)
        {
            LinkButton lbButton = (LinkButton)sender;
            string lblID = lbButton.ID.Substring(6).ToString().Trim();
            GridViewRow gRow = (GridViewRow)lbButton.NamingContainer;
            Label lblDate = (Label)gRow.FindControl("lblDate" + lblID);
            HiddenField hdJDate = (HiddenField)gRow.FindControl("hdJDate" + lblID);
            hdFromDate.Value = Convert.ToDateTime(hdFromDate.Value).ToString("dd") + " " + ddlSPLMonth.SelectedValue + " " + ddlSPLYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            Session["SPLFromDate"] = hdFromDate.Value;
            string[] lDate = Convert.ToDateTime(hdJDate.Value).ToString("MM/dd/yyyy").Split('/');
            txtSPLJourneyDate.Text = lDate[1].ToString() + "/" + lDate[0].ToString() + "/" + lDate[2].ToString();

            string[] pJDate = txtSPLJourneyDate.Text.Trim().Split('/');
            string lJDate = pJDate[1].ToString().Trim() + "/" + pJDate[0].ToString().Trim() + "/" + pJDate[2].ToString().Trim();
            string pURL = Request.Url.ToString();
            if (pURL.Contains("SpecialTouritinerary.aspx"))
            {
                Response.Redirect("~/Holiday-Packages-Itinerary_JDate-" + ddlSPLTour.SelectedItem.Text.Trim().Replace(" ", "-") + "_" + Convert.ToString(fldTourID.Value) + "_" + lJDate.Trim().Replace("/", "-"));
            }
            else if (pURL.Contains("BookSpecialTour.aspx"))
            {
                Response.Redirect("~/BookSpecialTour.aspx?TourID=" + fldTourID.Value + "&jdate=" + lJDate);
            }
        }

        protected void gvRoomDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < 7; i++)
                {
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.FromName("#fff");
                    e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("#D1BE96");
                    e.Row.Cells[i].Style.Add("font-weight", "normal");
                    e.Row.Cells[i].Style.Add("text-align", "center");
                    e.Row.Cells[i].Style.Add("vertical-align", "middle");
                    e.Row.Cells[i].Width = Unit.Pixel(50);
                    e.Row.Cells[i].Height = Unit.Pixel(25);
                    e.Row.Cells[i].BorderWidth = Unit.Pixel(1);
                    e.Row.Cells[i].BorderColor = System.Drawing.Color.White;

                }
            }
          
        }

        protected void ddlSPLMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdFromDate.Value = "01" + " " + ddlSPLMonth.SelectedValue + " " + ddlSPLYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));

        }
        protected void ddlSPLYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindMonth(ddlSPLMonth);
            hdFromDate.Value = "01" + " " + ddlSPLMonth.SelectedValue + " " + ddlSPLYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));

        }
        private void BindMonth(DropDownList ddlSPLMonth)
        {
            ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
            ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            int pMonth = Convert.ToInt32(Convert.ToDateTime(hdFromDate.Value).ToString("MM"));// DateTime.Now.Month;
            DateTime lCurMonth = Convert.ToDateTime(hdFromDate.Value);// DateTime.Now;
            if (DateTime.Now.Year != Convert.ToInt32(Convert.ToDateTime(hdFromDate.Value).ToString("yyyy")))
            {
                pMonth = 1;
                lCurMonth = Convert.ToDateTime("01-Jan-" + Convert.ToDateTime(hdFromDate.Value).ToString("yyyy"));
            }
            pMonth = 12 - pMonth;
            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add("Month");

            int lCtr = 0;
            for (int lMonth = 0; lMonth <= pMonth; lMonth++)
            {
                DataRow dr = dtMonth.NewRow();
                dr["Month"] = lCurMonth.AddMonths(lCtr).ToString("MMM").Trim();
                dtMonth.Rows.Add(dr);
                lCtr++;
            }
            ddlSPLMonth.DataSource = dtMonth;
            ddlSPLMonth.DataTextField = "Month";
            ddlSPLMonth.DataValueField = "Month";
            ddlSPLMonth.DataBind();
        }

        private void BindYear(DropDownList ddlSPLYear)
        {
            DataTable dtYear = new DataTable();
            dtYear.Columns.Add("Year");
            DateTime lCurYear = DateTime.Now;
            int lCtr = 0;
            for (int lYear = 0; lYear < 2; lYear++)
            {
                DataRow dr = dtYear.NewRow();
                dr["Year"] = lCurYear.AddYears(lCtr).ToString("yyyy").Trim();
                dtYear.Rows.Add(dr);
                lCtr++;
            }
            ddlSPLYear.DataSource = dtYear;
            ddlSPLYear.DataTextField = "Year";
            ddlSPLYear.DataValueField = "Year";
            ddlSPLYear.DataBind();
        }
        protected void btnLeft_Click(object sender, EventArgs e)
        {

            btnLeft.Visible = true;
            btnRight.Visible = true;
            lblCurrentDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(-1).ToString();
            DateTime lDate = Convert.ToDateTime(lblCurrentDate.Value);
            hdFromDate.Value = lDate.Month.ToString() + " " + "01" + " " + lDate.Year.ToString();
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(-1).ToString();

            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));

            if (lDate.Month == DateTime.Now.Month && lDate.Year == DateTime.Now.Year)
            {
                btnLeft.Visible = false;

            }
        }
        protected void btnRight_Click(object sender, EventArgs e)
        {
            btnRight.Visible = true;
       
            btnLeft.Visible = true;
            lblCurrentDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();

            DateTime lDate = Convert.ToDateTime(lblCurrentDate.Value);

            hdFromDate.Value = lDate.Month.ToString() + " " + "01" + " " + lDate.Year.ToString();
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();

            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));

         
        }
        public void GetLastJourneyDateAll()
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            SqlParameter lParamStDate = null;
            SqlParameter lParamEndDate = null;

            DataSet ldsDetail = new DataSet();
            SqlDataAdapter lDataAdp = null;

            try
            {
                String strCn = System.Configuration.ConfigurationManager.AppSettings["southernconn"];

                lConn = new SqlConnection(strCn);// For  Live

                lCommand = new SqlCommand("GetLastJourneyDateAll_SP", lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@I_TourType", Convert.ToInt32(TOURTYPE.SPECIAL_TOUR));
                lCommand.Parameters.AddWithValue("@I_TourID", Convert.ToInt32(Page.RouteData.Values["tourId"]));

                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }
                lCommand.ExecuteNonQuery();

                lDataAdp = new SqlDataAdapter(lCommand);
                lDataAdp.Fill(ldsDetail);


                if (ldsDetail != null && ldsDetail.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ldsDetail.Tables[0].Rows[0]["JourneyDate"]) != "")
                        hdLastDateCal.Value = Convert.ToDateTime(ldsDetail.Tables[0].Rows[0]["JourneyDate"]).ToString("MM/dd/yyyy");
                }
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lConn != null)
                {
                    if (lConn.State != ConnectionState.Closed)
                    {
                        lConn.Close();
                    }
                    lConn.Dispose();
                    lConn = null;
                }
                if (lCommand != null)
                {
                    lCommand.Dispose();
                    lCommand = null;
                }
                if (ldsDetail != null)
                {
                    ldsDetail.Dispose();
                    ldsDetail = null;
                }
                if (lDataAdp != null)
                {
                    lDataAdp.Dispose();
                    lDataAdp = null;
                }
                if (lParamStDate != null)
                {
                    lParamStDate = null;
                }

                if (lParamEndDate != null)
                {
                    lParamEndDate = null;
                }
            }

        }
        #endregion

        #endregion
        protected void ImageButton1_Click(object sender, EventArgs e)
        {

        }
        protected void testbutton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmsg", "alert('Hello button');", true);
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}