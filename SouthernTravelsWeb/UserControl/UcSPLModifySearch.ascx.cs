using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcSPLModifySearch : System.Web.UI.UserControl
    {

        #region Member Variable(s)
        private string _loginUserID = "";
        private string pvTourName = "", pvJDate = "";
        ArrayList DateHdr = new ArrayList();
        int pvTourType;
        int pvTourID;
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

        public int fldTourType
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

        #region Event(s)
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
          

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string[] ltourName = fldTourName.ToString().Split('(');
                hdTourName.Value = ltourName[0].Trim().Replace(" ", "-");
                
                if (fldJDate != "")
                {
                    lblJDate.Text = " <span class=\"tName\">| </span>" + fldJDate;
                }

                BindYear();

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
                GetLastJourneyDateAll();
                if (Request.QueryString["jdate"] != null)
                {
                    string[] lJDate = Request.QueryString["jdate"].ToString().Split('/');
                    hdFromDate.Value = new DateTime(Convert.ToInt32(lJDate[2]), Convert.ToInt32(lJDate[0]), Convert.ToInt32(lJDate[1])).ToString();
                    hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                }
                else
                {

                    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                    lblCurrentDate.Value = hdFromDate.Value;
                    Session["SPLFromDate"] = null;
                }
                if (Convert.ToDateTime(lblCurrentDate.Value).Month == Convert.ToDateTime(hdFromDate.Value).Month
                     && Convert.ToDateTime(lblCurrentDate.Value).Year == Convert.ToDateTime(hdFromDate.Value).Year)
                {
                    btnLeft.Visible = false;
                }

            }

            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            if (Request.QueryString.Count > 2 && Request.QueryString["utm_source"] == null)
            {
                Panel1.Visible = false;
            }
            if (Request.QueryString.Count == 1)
            {
                Panel1.Visible = true;
            }
            if (Request.QueryString["IsEdit"] != null)
            {
                Panel1.Visible = true;
            }

        }

        protected void imgLeft_click(object sender, ImageClickEventArgs e)
        {

        }
        protected void imgRight_click(object sender, ImageClickEventArgs e)
        {
        }


        #endregion

        #region Method(s)

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
                    dtTourDate = lclsEndObj.fnGetSpecialTourJourneyDate(fldTourID, FromDate.Month, FromDate.Year, Convert.ToInt32(pHours));
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
                                DateTime pDate = Convert.ToDateTime(hdJDate.Value);
                                string lCellValue = "";
                                if (dtTourDate != null && dtTourDate.Rows.Count > 0)
                                {
                                    for (int lTourDate = 0; lTourDate < dtTourDate.Rows.Count; lTourDate++)
                                    {
                                        DateTime JDate = Convert.ToDateTime(dtTourDate.Rows[lTourDate]["JourneyDate"].ToString());
                                        Decimal MinAmount = Convert.ToDecimal(dtTourDate.Rows[lTourDate]["MinFare"].ToString());

                                        if (pDate.ToString("MM/dd/yyyy") == JDate.ToString("MM/dd/yyyy"))
                                        {
                                            if (pDate.ToString("yyyy").Trim() == JDate.ToString("yyyy").Trim())
                                            {
                                                if (pDate.ToString("MMM").Trim() == JDate.ToString("MMM").Trim())
                                                {
                                                    if (pDate.ToString("dd").Trim() == JDate.ToString("dd").Trim())
                                                    {
                                                        //item.Cells[i].CssClass = "hL";
                                                        lCellValue = item.Cells[i].Text;
                                                        try
                                                        {
                                                            if (Page.RouteData.Values["jdate"] != null)
                                                            {
                                                                if (Convert.ToDateTime(Page.RouteData.Values["jdate"]).ToString("MM//dd/yyyy").Trim() == JDate.ToString("MM//dd/yyyy").Trim())
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
                                                            item.Cells[i].CssClass = "";
                                                            item.Cells[i].CssClass = "td_seatavail";
                                                        }
                                                        Panel ltrC = new Panel();
                                                        ltrC.ID = "ltrC" + item.Cells[i].Text;

                                                        item.Cells[i].Controls.Add(ltrC);

                                                        Label lblDate = new Label();
                                                        lblDate.ID = "lblDate" + lCellValue;
                                                        lblDate.Text = item.Cells[i].Text;

                                                        LinkButton lbDate = new LinkButton();
                                                        lbDate.ID = "lbDate" + lCellValue;
                                                        lbDate.CommandName = "lbDate";
                                                        lbDate.ToolTip = "Select Date";
                                                        lbDate.Click += new EventHandler(lbDate_Click);
                                                        ltrC.Controls.Add(lbDate);

                                                        Literal lTest = new Literal();
                                                        if (Convert.ToDateTime(DateTime.Now).ToString("MM//dd/yyyy").Trim() == JDate.ToString("MM//dd/yyyy").Trim())
                                                        {
                                                            lTest.Text = "<span class=\"date todaydate\">" + lCellValue + "</span>" + "<span style=''>" +
                                                                /*<i class='fa fa-rupee'></i>&nbsp;" + Convert.ToString(MinAmount) + */ "Book</span>";
                                                        }
                                                        else
                                                        {
                                                            lTest.Text = "<span class='date'>" + lCellValue + "</span>" + "<span style=''>" +
                                                                /*<i class='fa fa-rupee'></i>&nbsp;" + Convert.ToString(MinAmount) + */ "Book</span>";
                                                        }

                                                        lbDate.Controls.Add(lTest);
                                                        Label lTest1 = new Label();
                                                        lbDate.Controls.Add(lTest1);
                                                       
                                                        lFlag = true;
                                                        lblDate.CssClass = "date";

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (!lFlag)
                                {
                                    Label lblDate = new Label();
                                    lblDate.ID = "lblDate" + item.Cells[i].Text;
                                    lblDate.Text = item.Cells[i].Text;
                                    item.Cells[i].Controls.Add(lblDate);
                                    lblDate.CssClass = "date";
                                    item.Cells[i].CssClass = "disabled todaydate";
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
            HiddenField hdJDate = (HiddenField)gRow.FindControl("hdJDate" + lblID);
            hdFromDate.Value = Convert.ToDateTime(hdFromDate.Value).ToString("dd") + " " + ddlSPLMonth.SelectedValue + " " + ddlSPLYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            Session["SPLFromDate"] = hdFromDate.Value;
            string[] lDate = Convert.ToDateTime(hdJDate.Value).ToString("MM/dd/yyyy").Split('/');
            string lJDate = Convert.ToDateTime(hdJDate.Value).ToString("MM/dd/yyyy").ToString();// lDate[1].ToString() + "/" + lDate[0].ToString() + "/" + lDate[2].ToString();

            Response.Redirect("~/BookSpecialTour.aspx?TourID=" + Convert.ToString(Page.RouteData.Values["tourId"]) + "&jdate=" + lJDate + "#BookSelect");

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

        protected void ddlSPLMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdFromDate.Value = "01" + " " + ddlSPLMonth.SelectedValue + " " + ddlSPLYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            lblCurrentDate.Value = hdFromDate.Value;
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            if (Convert.ToDateTime(lblCurrentDate.Value).Month == Convert.ToDateTime(hdFromDate.Value).Month
                   && Convert.ToDateTime(lblCurrentDate.Value).Year == Convert.ToDateTime(hdFromDate.Value).Year)
            {
                btnLeft.Visible = true;
            }
        }
        protected void ddlSPLYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdFromDate.Value = "01" + " " + ddlSPLMonth.SelectedValue + " " + ddlSPLYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            lblCurrentDate.Value = hdFromDate.Value;
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            if (Convert.ToDateTime(lblCurrentDate.Value).Month == Convert.ToDateTime(hdFromDate.Value).Month
                   && Convert.ToDateTime(lblCurrentDate.Value).Year == Convert.ToDateTime(hdFromDate.Value).Year)
            {
                btnLeft.Visible = true;
            }
        }
        private void BindMonth(DropDownList ddlSPLMonth)
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
        #endregion

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
            ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
            ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
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
            ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
            ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
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

                lCommand = new SqlCommand(StoredProcedures.GetLastJourneyDateAll_SP, lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@I_TourType", Convert.ToInt32(TOURTYPE.SPECIAL_TOUR));
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
    }
}