using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
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

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcModifySearch : System.Web.UI.UserControl
    {

        #region Member Variable(s)
        private bool _datePanel = true;
        private string pvTourName = "", pvJDate = "";
        ArrayList DateHdr = new ArrayList();
        #endregion

        #region Property(s)
        public bool DatePanel
        {
            get
            {
                return _datePanel;
            }
            set
            {
                _datePanel = value;
            }
        }
        public string fldTourName
        {
            get
            {
                return pvTourName;
            }
            set
            {
                pvTourName = value;
            }
        }
        public string fldJDate
        {
            get
            {
                return pvJDate;
            }
            set
            {
                pvJDate = value;
            }
        }
        #endregion
        #region Event(s)
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
            if (Request.QueryString["jdate"] != null && Convert.ToString(Request.QueryString["jdate"]) != "")
            {
                string[] lJDate = Request.QueryString["jdate"].ToString().Split('/');
                hdFromDate.Value = new DateTime(Convert.ToInt32(lJDate[2]), Convert.ToInt32(lJDate[0]), Convert.ToInt32(lJDate[1])).ToString();
                hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                ddlMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            }
            else
            {
                hdFromDate.Value = DateTime.Now.ToString();
                hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                ddlMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                ddlYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                Session["FromDate"] = null;
            }
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckIntlEBKTourIDs(Convert.ToString(Request.QueryString["TourID"]));
            if (!IsPostBack)
            {
                if (fldJDate != "")
                {
                    //lblJDate.Text = " <span class=\"tName\">| </span>" + fldJDate;
                }
                CheckIntlEBKTourIDs(Convert.ToString(Request.QueryString["TourID"]));
                fillddlJdate(Convert.ToInt32(Request.QueryString["TourID"]));
                BindYear();
                
                GetLastJourneyDateAll();
                if (Request.QueryString["jdate"] != null)
                {

                    string[] lJDate = Request.QueryString["jdate"].ToString().Split('/');
                    hdFromDate.Value = new DateTime(Convert.ToInt32(lJDate[2]), Convert.ToInt32(lJDate[0]), Convert.ToInt32(lJDate[1])).ToString();
                    hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                    ddlMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                }
                else
                {
                    ddlMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                    Session["FromDate"] = null;

                }
                if (Convert.ToDateTime(lblCurrentDate.Value).Month == Convert.ToDateTime(hdFromDate.Value).Month
                    && Convert.ToDateTime(lblCurrentDate.Value).Year == Convert.ToDateTime(hdFromDate.Value).Year)
                {
                    btnLeft.Visible = false;
                }

            }

            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            
            if (Request.QueryString.Count == 1)
            {
                Panel1.Visible = true;
            }

            if (Request.QueryString["IsEdit"] != null || Request.QueryString["IsBookMore"] != null || Request.QueryString["ltc"] != null)
            {
                Session["Panel2Step"] = null;
                Panel1.Visible = true;
            }

        }
        #endregion
        #region Calender
        public void BindCalendar(DateTime FromDate, DateTime ToDate)
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


                ClsCommon lclsEndObj = null;
                DataTable dtTourDate = new DataTable();
                try
                {
                    string pHours = ConfigurationManager.AppSettings["CustomerFixedTourHours"].ToString();
                    pHours = "-" + pHours;
                    lclsEndObj = new ClsCommon();
                    dtTourDate = lclsEndObj.fnGetFixedTourJourneyDate(Convert.ToInt32(Request.QueryString["TourID"]), FromDate.Month, FromDate.Year, Convert.ToInt32(pHours));
                    lblMonth.Text = FromDate.ToString("MMMMM") + " " + FromDate.ToString("yyyy");


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

                            if (item.Cells[i].Text != "" && item.Cells[i].Text != "&nbsp;")
                            {
                                HiddenField hdJDate = new HiddenField();
                                hdJDate.ID = "hdJDate" + item.Cells[i].Text;
                                item.Cells[i].Controls.Add(hdJDate);
                                hdJDate.Value = Convert.ToDateTime(item.Cells[i].Text + lblStartDate.Value).ToString("MM/dd/yyyy");

                                HiddenField hdVacantSeat = new HiddenField();
                                hdVacantSeat.ID = "hdVacantSeat" + item.Cells[i].Text;
                                item.Cells[i].Controls.Add(hdVacantSeat);
                                hdVacantSeat.Value = "";
                            }
                        }
                    }

                    foreach (GridViewRow item in gvRoomDetails.Rows)
                    {

                        for (int i = 0; i < DateHdr.Count; i++)
                        {

                            if (item.Cells[i].Text != "" && item.Cells[i].Text != "&nbsp;")
                            {
                                bool lFlag = false;

                                HiddenField hdJDate = (HiddenField)item.Cells[i].FindControl("hdJDate" + item.Cells[i].Text);
                                HiddenField hdVacantSeat = (HiddenField)item.Cells[i].FindControl("hdVacantSeat" + item.Cells[i].Text);
                                DateTime pDate = Convert.ToDateTime(hdJDate.Value);
                                for (int lTourDate = dtTourDate.Rows.Count - 1; lTourDate > -1; lTourDate--)
                                {
                                    DateTime JDate = Convert.ToDateTime(dtTourDate.Rows[lTourDate]["sjourneydate"].ToString());
                                    decimal lFare = Convert.ToDecimal(dtTourDate.Rows[lTourDate]["MinCost"].ToString());

                                    if (pDate.ToString("MM/dd/yyyy") == JDate.ToString("MM/dd/yyyy"))
                                    {
                                        if (pDate.ToString("yyyy").Trim() == JDate.ToString("yyyy").Trim())
                                        {
                                            if (pDate.ToString("MMM").Trim() == JDate.ToString("MMM").Trim())
                                            {
                                                if (pDate.ToString("dd").Trim() == JDate.ToString("dd").Trim())
                                                {
                                                    if (Convert.ToInt32(dtTourDate.Rows[lTourDate]["ac"]) > 0 || Convert.ToInt32(dtTourDate.Rows[lTourDate]["nonac"]) > 0)
                                                    {
                                                        Panel ltrC = new Panel();

                                                        try
                                                        {
                                                            if (Request.QueryString["jdate"] != null)
                                                            {
                                                                if (Convert.ToDateTime(Request.QueryString["jdate"]).ToString("MM//dd/yyyy").Trim() == JDate.ToString("MM//dd/yyyy").Trim())
                                                                {
                                                                    item.Cells[i].CssClass = "td_seatavail active";
                                                                }
                                                                else
                                                                {
                                                                    item.Cells[i].CssClass = "td_seatavail";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                item.Cells[i].CssClass = "td_seatavail";
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            item.Cells[i].CssClass = "td_seatavail";
                                                        }
                                                        ltrC = new Panel();
                                                        ltrC.ID = "ltrC" + item.Cells[i].Text;

                                                        item.Cells[i].Controls.Add(ltrC);

                                                        Label lblVcSeats = new Label();
                                                        lblVcSeats.ID = "lblVcSeats" + item.Cells[i].Text;
                                                        lblVcSeats.Text = "<span class=\"date\">" + item.Cells[i].Text + "</span>";
                                                        //item.Cells[i].Controls.Add(lblVcSeats);

                                                        LinkButton lbAc = new LinkButton();
                                                        lbAc.ID = "lbAc" + item.Cells[i].Text;
                                                        lbAc.CommandName = "lbAc";
                                                        lbAc.ToolTip = "Select Date";
                                                        lbAc.Click += new EventHandler(lbAc_Click);
                                                        ltrC.Controls.Add(lbAc);
                                                        lbAc.Attributes.Add("onclick", "javascript:PopupHide();");

                                                        Literal lTest = new Literal();
                                                        if (Convert.ToDateTime(DateTime.Now).ToString("MM//dd/yyyy").Trim() == JDate.ToString("MM//dd/yyyy").Trim())
                                                        {
                                                            lTest.Text = "<span class=\"date todaydate\">" + item.Cells[i].Text + "</span>";
                                                        }
                                                        else
                                                        {
                                                            lTest.Text = "<span class=\"date\">" + item.Cells[i].Text + "</span>";
                                                        }
                                                        lbAc.Controls.Add(lTest);
                                                        int lTotal = Convert.ToInt32(dtTourDate.Rows[lTourDate]["ac"]) + Convert.ToInt32(dtTourDate.Rows[lTourDate]["nonac"]);
                                                        Label lTest1 = new Label();
                                                        if (ViewState["UcTourID"] == "Y")
                                                            lTest1.Text = "<span class=\"seats\">Book</br> Now</span>";//<i class=\"fa fa-rupee\"></i>&nbsp;" + lFare.ToString() + "</span>";
                                                        else
                                                            lTest1.Text = "<span class=\"seats\">" + lTotal.ToString() + "</br> Vacant</span>";//<i class=\"fa fa-rupee\"></i>&nbsp;" + lFare.ToString() + "</span>";
                                                        lbAc.Controls.Add(lTest1);
                                                        //lbAc.CssClass = "selected";
                                                        lFlag = true;
                                                    }

                                                    hdVacantSeat.Value = "Ac:" + dtTourDate.Rows[lTourDate]["ac"].ToString() + "?" + "NoAc" + dtTourDate.Rows[lTourDate]["nonac"].ToString();

                                                }

                                            }
                                        }
                                    }

                                }
                                if (!lFlag)
                                {
                                    item.Cells[i].CssClass = "disabled";
                                    Label lblVcSeats = new Label();
                                    lblVcSeats.ID = "lblVcSeats" + item.Cells[i].Text;
                                    lblVcSeats.Text = "<span class=\"date\">" + item.Cells[i].Text + "</span>";
                                    item.Cells[i].Controls.Add(lblVcSeats);

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
        private void BindYear()
        {
            ddlYear.Items.Clear();
            DateTime startYear = DateTime.Now;
            while (startYear.Year < DateTime.Now.AddYears(2).Year)
            {
                ListItem li = new ListItem();
                li.Value = startYear.Year.ToString();
                li.Text = startYear.Year.ToString();
                ddlYear.Items.Add(li);
                startYear = startYear.AddYears(1);
            }
        }
        protected void lbAc_Click(object sender, EventArgs e)
        {
            LinkButton lbButton = (LinkButton)sender;
            string lblID = lbButton.ID.Substring(4).ToString().Trim();
            GridViewRow gRow = (GridViewRow)lbButton.NamingContainer;
            //Label lblDate = (Label)gRow.FindControl("lblVcSeats" + lblID);
            HiddenField hdJDate = (HiddenField)gRow.FindControl("hdJDate" + lblID);
            HiddenField hdVacantSeat = (HiddenField)gRow.FindControl("hdVacantSeat" + lblID);
            hdFromDate.Value = Convert.ToDateTime(hdFromDate.Value).ToString("dd") + " " + ddlMonth.SelectedValue + " " + ddlYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            Session["FromDate"] = hdFromDate.Value;

            string[] lDate = Convert.ToDateTime(hdJDate.Value).ToString("MM/dd/yyyy").Split('/');
            string lJDate = lDate[0].ToString() + "/" + lDate[1].ToString() + "/" + lDate[2].ToString();

            if (Request.QueryString["IsEdit"] != null)
            {
                Session["Panel2Step"] = null;
                string lQryStr = "";
                if (Request.QueryString["A"] != null)
                {
                    lQryStr = "&A=" + Convert.ToString(Request.QueryString["A"]);
                }
                if (Request.QueryString["A"] != null)
                {
                    lQryStr = lQryStr + "&C=" + Convert.ToString(Request.QueryString["C"]);
                }
                Response.Redirect("~/TourBooking.aspx?TourID=" + Convert.ToString(Request.QueryString["TourID"]) + "&jdate=" + lJDate + "&orderid=" + Convert.ToString(Request.QueryString["orderid"]) +
                         "&Rowid=" + Convert.ToString(Request.QueryString["Rowid"]) + "&IsEdit=IsEdit" + lQryStr.Trim() + "#BookSelect");
             
            }
            else if (Request.QueryString["IsBookMore"] != null)
            {
                Session["Panel2Step"] = null;
                Response.Redirect("TourBooking.aspx?orderid=" + Convert.ToString(Request.QueryString["orderid"]) + "&jdate=" + lJDate +
                    "&TourId=" + Convert.ToString(Request.QueryString["TourID"]) + "&A=" + Convert.ToString(Request.QueryString["A"]) + "&C=" +
                    Convert.ToString(Request.QueryString["C"]) +
                    "&TourName=" + Convert.ToString(Request.QueryString["TourName"]) + "&IsBookMore=BookMore" + "#BookSelect");
                
            }
            else if (Request.QueryString["ltc"] != null)
            {
                Response.Redirect("~/TourBooking.aspx?TourID=" + Convert.ToString(Request.QueryString["TourID"]) + "&jdate=" + lJDate + "&ltc=true" + "#BookSelect");
            }
            else
            {
                Response.Redirect("~/TourBooking.aspx?TourID=" + Convert.ToString(Request.QueryString["TourID"]) + "&jdate=" + lJDate + "#BookSelect");
             
            }
        }
   
        protected void gvRoomDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < 7; i++)
                {

                }
            }

        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdFromDate.Value = "01" + " " + ddlMonth.SelectedValue + " " + ddlYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            lblCurrentDate.Value = hdFromDate.Value;
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));

            if (Convert.ToDateTime(lblCurrentDate.Value).Month == Convert.ToDateTime(hdFromDate.Value).Month
                    && Convert.ToDateTime(lblCurrentDate.Value).Year == Convert.ToDateTime(hdFromDate.Value).Year)
            {
                btnLeft.Visible = true;
            }
        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdFromDate.Value = "01" + " " + ddlMonth.SelectedValue + " " + ddlYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            lblCurrentDate.Value = hdFromDate.Value;
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            if (Convert.ToDateTime(lblCurrentDate.Value).Month == Convert.ToDateTime(hdFromDate.Value).Month
                   && Convert.ToDateTime(lblCurrentDate.Value).Year == Convert.ToDateTime(hdFromDate.Value).Year)
            {
                btnLeft.Visible = true;
            }
        }
        protected void ddlJDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJDate.SelectedIndex == 0)
                return;
            string[] jDate = ddlJDate.SelectedItem.Text.Split('(');
            

            hdFromDate.Value = jDate[0].ToString();
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            Session["FromDate"] = hdFromDate.Value;

            string[] lDate = Convert.ToDateTime(hdFromDate.Value).ToString("MM/dd/yyyy").Split('/');
            string lJDate = lDate[0].ToString() + "/" + lDate[1].ToString() + "/" + lDate[2].ToString();

            if (Request.QueryString["IsEdit"] != null)
            {
                Session["Panel2Step"] = null;
                string lQryStr = "";
                if (Request.QueryString["A"] != null)
                {
                    lQryStr = "&A=" + Convert.ToString(Request.QueryString["A"]);

                }
                if (Request.QueryString["A"] != null)
                {
                    lQryStr = lQryStr + "&C=" + Convert.ToString(Request.QueryString["C"]);

                }
                Response.Redirect("~/TourBooking.aspx?TourID=" + Convert.ToString(Request.QueryString["TourID"]) + "&jdate=" + lJDate + "&orderid=" + Convert.ToString(Request.QueryString["orderid"]) +
                         "&Rowid=" + Convert.ToString(Request.QueryString["Rowid"]) + "&IsEdit=IsEdit" + lQryStr.Trim() + "#BookSelect");

            }
            else if (Request.QueryString["IsBookMore"] != null)
            {
                Session["Panel2Step"] = null;
                Response.Redirect("TourBooking.aspx?orderid=" + Convert.ToString(Request.QueryString["orderid"]) + "&jdate=" + lJDate +
                    "&TourId=" + Convert.ToString(Request.QueryString["TourID"]) + "&A=" + Convert.ToString(Request.QueryString["A"]) + "&C=" +
                    Convert.ToString(Request.QueryString["C"]) +
                    "&TourName=" + Convert.ToString(Request.QueryString["TourName"]) + "&IsBookMore=BookMore" + "#BookSelect");

            }
            else if (Request.QueryString["ltc"] != null)
            {
                Response.Redirect("~/TourBooking.aspx?TourID=" + Convert.ToString(Request.QueryString["TourID"]) + "&jdate=" + lJDate + "&ltc=true" + "#BookSelect", true);
            }
            else
            {
                Response.Redirect("~/TourBooking.aspx?TourID=" + Convert.ToString(Request.QueryString["TourID"]) + "&jdate=" + lJDate + "#BookSelect", true);

            }
        }
        private void fillddlJdate(int TourNo)
        {
            DropDownList ctrl;
            string ctrlName = "ddlJDate";
            ctrl = (DropDownList)this.FindControl(ctrlName);
            ctrl.Items.Clear();
            ctrl.Items.Insert(0, new ListItem("Tour Departure date", "0"));
            string hr = ConfigurationManager.AppSettings["CustomerFixedTourHours"].ToString();
            hr = "-" + hr;
            DataTable dtdates = null;
            DataSet lds = null;
            ClsCommon clsObj = null;
            try
            {
                clsObj = new ClsCommon();
                lds = clsObj.fnGetjdates_vacantseats(TourNo, Convert.ToInt32(hr));
                if (lds != null ? lds.Tables.Count > 0 : false)
                {
                    dtdates = lds.Tables[0];
                }
                if (dtdates != null && dtdates.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtdates.Rows.Count - 1; i++)
                    {
                        if ((dtdates.Rows[i]["sJourneyDate"] != DBNull.Value) &&
                            (dtdates.Rows[i]["ac"] != DBNull.Value) &&
                            (dtdates.Rows[i]["nonac"] != DBNull.Value))
                        {
                            DateTime TestDate = Convert.ToDateTime(dtdates.Rows[i]["sJourneyDate"]);
                            int lAcTotalSeat = 0;
                            int lNonAcTotalSeat = 0;

                            lAcTotalSeat = Convert.ToInt32(dtdates.Rows[i]["ac"]);
                            lNonAcTotalSeat = Convert.ToInt32(dtdates.Rows[i]["nonac"]);
                            int lTotalSeat = lAcTotalSeat + lNonAcTotalSeat;
                            if (ViewState["UcTourID"] == "Y")
                            {
                                ctrl.Items.Insert(1, new ListItem(TestDate.ToString("dd-MMM-yyyy"), TestDate.ToString("MM/dd/yyyy")));
                            }
                            else
                            {
                                ctrl.Items.Insert(1, new ListItem(TestDate.ToString("dd-MMM-yyyy") + " (" + lTotalSeat.ToString() + " Vacant)", TestDate.ToString("MM/dd/yyyy")));
                            }
                        }
                    }
                }
                else
                {
                }
                if (Request.QueryString["jdate"] != null)
                {
                    string[] lJDate = Convert.ToString(Request.QueryString["jdate"]).Split('/');
                    ddlJDate.SelectedValue = (new DateTime(Convert.ToInt32(lJDate[2]), Convert.ToInt32(lJDate[0]),
                        Convert.ToInt32(lJDate[1]))).ToString("MM/dd/yyyy").Trim();
                }
            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
                if (dtdates != null)
                {
                    dtdates.Dispose();
                    dtdates = null;
                }
                if (lds != null)
                {
                    lds.Dispose();
                    lds = null;
                }
            }
        }
        private void BindMonth(DropDownList ddlMonth)
        {
            int pMonth = DateTime.Now.Month;
            pMonth = 12 - pMonth;
            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add("Month");
            DateTime lCurMonth = DateTime.Now;
            int lCtr = 0;
            for (int lMonth = 0; lMonth < 12; lMonth++)
            {
                DataRow dr = dtMonth.NewRow();
                dr["Month"] = lCurMonth.AddMonths(lCtr).ToString("MMM").Trim();
                dtMonth.Rows.Add(dr);
                lCtr++;
            }
            ddlMonth.DataSource = dtMonth;
            ddlMonth.DataTextField = "Month";
            ddlMonth.DataValueField = "Month";
            ddlMonth.DataBind();
        }
        private void BindYear(DropDownList ddlYear)
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
            ddlYear.DataSource = dtYear;
            ddlYear.DataTextField = "Year";
            ddlYear.DataValueField = "Year";
            ddlYear.DataBind();
        }
        #endregion
        protected void btnLeft_Click(object sender, ImageClickEventArgs e)
        {

            btnLeft.Visible = true;
            btnRight.Visible = true;
            lblCurrentDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(-1).ToString();
            DateTime lDate = Convert.ToDateTime(lblCurrentDate.Value);
            hdFromDate.Value = lDate.Month.ToString() + " " + "01" + " " + lDate.Year.ToString();
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(-1).ToString();

            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));

            if (lDate.Month <= DateTime.Now.Month && lDate.Year <= DateTime.Now.Year)
            {
                btnLeft.Visible = false;

            }
            ddlMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
            ddlYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
        }
        protected void btnRight_Click(object sender, ImageClickEventArgs e)
        {
            btnRight.Visible = true;
            btnLeft.Visible = true;
            lblCurrentDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();

            DateTime lDate = Convert.ToDateTime(lblCurrentDate.Value);

            hdFromDate.Value = lDate.Month.ToString() + " " + "01" + " " + lDate.Year.ToString();
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();

            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));

            if (Convert.ToDateTime(hdLastDateCal.Value).Month == Convert.ToDateTime(hdFromDate.Value).Month
                   && Convert.ToDateTime(hdLastDateCal.Value).Year == Convert.ToDateTime(hdFromDate.Value).Year)
            {
                btnRight.Visible = false;

            }
            ddlMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
            ddlYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
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
                String strCn = DataLib.getConnectionString();

                lConn = new SqlConnection(strCn);// For  Live

                lCommand = new SqlCommand(StoredProcedures.GetLastJourneyDateAll_SP, lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@I_TourType", Convert.ToInt32(TOURTYPE.FIXED_TOUR));
                lCommand.Parameters.AddWithValue("@I_TourID", Convert.ToInt32(Request.QueryString["TourID"]));

                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }
                lCommand.ExecuteNonQuery();

                lDataAdp = new SqlDataAdapter(lCommand);
                lDataAdp.Fill(ldsDetail);


                if (ldsDetail != null && ldsDetail.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ldsDetail.Tables[0].Rows[0]["StartDate"]) != "")
                    {
                        lblCurrentDate.Value = Convert.ToDateTime(ldsDetail.Tables[0].Rows[0]["StartDate"]).ToString("MM/dd/yyyy");
                        hdFromDate.Value = Convert.ToDateTime(ldsDetail.Tables[0].Rows[0]["StartDate"]).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        hdLastDateCal.Value = hdToDate.Value;
                        lblCurrentDate.Value = hdFromDate.Value;
                    }
                    if (Convert.ToString(ldsDetail.Tables[0].Rows[0]["EndDate"]) != "")
                    {
                        hdLastDateCal.Value = Convert.ToDateTime(ldsDetail.Tables[0].Rows[0]["EndDate"]).ToString("MM/dd/yyyy");
                        hdToDate.Value = Convert.ToDateTime(ldsDetail.Tables[0].Rows[0]["EndDate"]).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        hdLastDateCal.Value = hdToDate.Value;
                        lblCurrentDate.Value = hdToDate.Value;
                    }


                }
                else
                {
                    hdFromDate.Value = DateTime.Now.ToString();
                    hdToDate.Value = DateTime.Now.AddDays(1).ToString();

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

        private void CheckIntlEBKTourIDs(string strTourid)
        {
            string Ids = ConfigurationManager.AppSettings["IntlEBKTourIDs"];
            string[] Arr = Ids.Split(',');
            foreach (string str in Arr)
            {
                if (str == strTourid)
                {
                    ViewState["UcTourID"] = "Y"; ; break;
                }
            }
        }
    }
}