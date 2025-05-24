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
using System.Xml.Linq;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcSpecialTourSearch : System.Web.UI.UserControl
    {
        #region Member Variable(s)
        private string _loginUserID = "";
        private string _tourStartFrom = "";
        ArrayList DateHdr = new ArrayList();
        protected string connectionString;

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
            //if (Session["SPLFromDate"] == null)
            //{
            //    hdFromDate.Value = DateTime.Now.ToString();
            //    hdToDate.Value = DateTime.Now.AddDays(1).ToString();
            //    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
            //    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            //}
            //else
            //{
            //    hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
            //    hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
            //    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
            //    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
            //}
            if (Request.QueryString["jdate"] != null)
            {
                string[] lJDate = Request.QueryString["jdate"].ToString().Split('/');
                hdFromDate.Value = new DateTime(Convert.ToInt32(lJDate[2]), Convert.ToInt32(lJDate[0]), Convert.ToInt32(lJDate[1])).ToString();
                //hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
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
            //this.lstSPLTours.BorderColor = System.Drawing.Color.Transparent;
            //this.lstSPLTours.BorderStyle = BorderStyle.None;
            //this.lstSPLTours.BorderWidth = new Unit(0);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.AppSettings["southernconn"];
            btnSPLBook.Attributes.Add("onclick", "javascript:return fnQuickSPLSearchVal();");
            //btnRight.Attributes.Add("onclick", "javascript:return fnQuickSPLSearchVal();");
            txtSPLJourneyDate.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            {
                //txtSPLTour.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13){ __doPostBack('" + btnSPLBook.UniqueID + "','')}");
                // txtSPLJourneyDate.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13){ __doPostBack('" + btnSPLBook.UniqueID + "','')}");
                Panel1.Style.Add("display", "none");

                BindYear();
                //BindMonth(ddlSPLMonth);
                GetTourStartFromSearch();
                string pURL = Request.Url.ToString().ToLower();

                if (Request.QueryString["TourID"] != null && (pURL.Contains("BookSpecialTour.aspx".ToLower()) || pURL.Contains("SpecialTouritinerary.aspx".ToLower())))
                {
                    BindTours(Convert.ToInt32(Request.QueryString["TourID"]));
                }
                else
                {
                    txtSPLJourneyDate.Text = "";
                    //txtSPLTour.Text = "";
                }
                //if (Session["SPLFromDate"] == null)
                //{
                //    hdFromDate.Value = DateTime.Now.ToString();
                //    hdToDate.Value = DateTime.Now.AddDays(1).ToString();
                //    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                //    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                //}
                //else
                //{
                //    hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
                //    hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddDays(1).ToString();
                //    ddlSPLMonth.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("MMM");
                //    ddlSPLYear.SelectedValue = Convert.ToDateTime(hdFromDate.Value).ToString("yyyy");
                //}
                if (Request.QueryString["jdate"] != null)
                {
                    string[] lJDate = Request.QueryString["jdate"].ToString().Split('/');
                    hdFromDate.Value = new DateTime(Convert.ToInt32(lJDate[2]), Convert.ToInt32(lJDate[0]), Convert.ToInt32(lJDate[1])).ToString();
                    //hdFromDate.Value = Convert.ToDateTime(Session["SPLFromDate"]).ToString();
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
                //GetLastJourneyDateAll();
            }

            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            //lstSPLTours.BorderWidth = 0;
            //btnLeft.Visible = true;
            //btnRight.Visible = true;
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
            //System.Threading.Thread.Sleep(1500000);
            GetBindTours();
        }
        protected void btnSPLBook_Click(object sender, EventArgs e)
        {
            string[] pJDate = txtSPLJourneyDate.Text.Trim().Split('/');
            string lJDate = pJDate[1].ToString().Trim() + "/" + pJDate[0].ToString().Trim() + "/" + pJDate[2].ToString().Trim();
            string pURL = Request.Url.ToString();

            //Response.Redirect("~/BookSpecialTour.aspx?TourID=" + fldTourID.Value + "&jdate=" + lJDate);

            if (pURL.Contains("BookSpecialTour.aspx"))
            {
                Response.Redirect("~/BookSpecialTour.aspx?TourID=" + fldTourID.Value + "&jdate=" + lJDate);
                //Response.Redirect("~/Holiday-Packages-Booking_JDate-" + txtSPLTour.Text.Trim().Replace(" ", "-") + "_" + Convert.ToString(fldTourID.Value) + "_" + lJDate.Trim().Replace("/", "-"));
            }
            else if (pURL.Contains("SpecialTouritinerary.aspx"))
            {
                Response.Redirect("~/BookSpecialTour.aspx?TourID=" + fldTourID.Value + "&jdate=" + lJDate);
            }
            else
            {
                //Response.Redirect("~/SpecialTouritinerary.aspx?TourID=" + fldTourID.Value + "&jdate=" + lJDate);
                Response.Redirect("~/Holiday-Packages-Itinerary_JDate-" + ddlSPLTour.SelectedItem.Text.Trim().Replace(" ", "-") + "_" + Convert.ToString(fldTourID.Value) + "_" + lJDate.Trim().Replace("/", "-"));
            }


        }
        #endregion

        #region Method(s)
        private void BindTours(int pTourID)
        {
            DataTable dtTour = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                   using (SqlCommand cmd = new SqlCommand(StoredProcedures.sp_GetTourStartFrom, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters for your stored procedure
                        cmd.Parameters.AddWithValue("@TourID", pTourID);
                        cmd.Parameters.AddWithValue("@TourType", Convert.ToInt32(TOURTYPE.SPECIAL_TOUR));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtTour);
                        }
                    }
                }

                if (dtTour != null && dtTour.Rows.Count > 0)
                {
                    // Assuming your stored procedure returns columns: TourStartFrom, TourName
                    ddlSPLTourStartFrom.SelectedValue = dtTour.Rows[0]["TourStartFrom"].ToString();

                    // Call GetBindTours method as in your original code
                    GetBindTours();

                    ddlSPLTour.SelectedValue = dtTour.Rows[0]["TourName"].ToString();
                    fldTourID.Value = pTourID.ToString();

                    if (Request.QueryString["jdate"] != null)
                    {
                        txtSPLJourneyDate.Text = Convert.ToDateTime(Request.QueryString["jdate"]).ToString("dd/MM/yyyy");
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
            catch (Exception ex)
            {
                // Handle/log exception as needed
            }
        }
        private void GetTourStartFromSearch_ADONET()
        {
            DataTable dtStartFrom = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Use stored procedure or raw query as needed
                    using (SqlCommand cmd = new SqlCommand("sp_GetTourStartFromByType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Pass the tour type parameter (assuming int)
                        cmd.Parameters.AddWithValue("@TourType", Convert.ToInt32(TOURTYPE.SPECIAL_TOUR));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtStartFrom);
                        }
                    }
                }

                if (dtStartFrom != null && dtStartFrom.Rows.Count > 0)
                {
                    ddlSPLTourStartFrom.DataSource = dtStartFrom;
                    ddlSPLTourStartFrom.DataValueField = "CityID";    // Column from your DB
                    ddlSPLTourStartFrom.DataTextField = "CityName";   // Column from your DB
                    ddlSPLTourStartFrom.DataBind();
                    ddlSPLTourStartFrom.Items.Insert(0, new ListItem("Tour starting from", "0"));
                }
            }
            catch (Exception ex)
            {
                // Log or handle exception
            }
        }

        private void GetTourStartFromSearch()
        {
            DataTable dtStartFrom = new DataTable();
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourStartFromSearch_SP, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TourType", Convert.ToInt32(TOURTYPE.SPECIAL_TOUR));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtStartFrom);
                        }
                    }
                }

                ddlSPLTourStartFrom.DataSource = dtStartFrom;
                ddlSPLTourStartFrom.DataValueField = "CityID";    // Ensure column names match your DB results
                ddlSPLTourStartFrom.DataTextField = "CityName";
                ddlSPLTourStartFrom.DataBind();
                ddlSPLTourStartFrom.Items.Insert(0, new ListItem("Tour starting from", "0"));
            }
            catch (Exception ex)
            {
                // Handle error properly (logging etc.)
            }
        }

        /// <summary>
        /// Use Xml For Fill Tours Info
        /// </summary>
        private void GetBindTours_XML()
        {
            DataTable dtTours = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.sp_GetToursByTypeAndStartFrom, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Assuming your stored procedure accepts these parameters
                        cmd.Parameters.AddWithValue("@TourType", Convert.ToInt32(TOURTYPE.SPECIAL_TOUR));
                        cmd.Parameters.AddWithValue("@StartsFromID", Convert.ToInt32(ddlSPLTourStartFrom.SelectedValue));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtTours);
                        }
                    }
                }

                if (dtTours != null && dtTours.Rows.Count > 0)
                {
                    ddlSPLTour.DataSource = dtTours;
                    ddlSPLTour.DataValueField = "TourNo";      
                    ddlSPLTour.DataTextField = "TourName";
                    ddlSPLTour.DataBind();
                    ddlSPLTour.Items.Insert(0, new ListItem("I want to go to", "0"));
                }

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
                // Handle exception (log etc.)
            }
        }

        private void GetBindTours()
        {
            DataTable dtTours = new DataTable();
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourS_Search_SP, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StartFrom", ddlSPLTourStartFrom.SelectedValue);
                        cmd.Parameters.AddWithValue("@SomeParam", ""); // Replace with actual parameter name or remove if not needed
                        cmd.Parameters.AddWithValue("@TourType", Convert.ToInt32(TOURTYPE.SPECIAL_TOUR));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtTours);
                        }
                    }
                }

                ddlSPLTour.DataSource = dtTours;
                ddlSPLTour.DataValueField = "TourNo";  // Make sure these column names match your result set
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
                // Log or handle the error properly
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
                int lTotalDays = DateTime.DaysInMonth(FromDate.Year, FromDate.Month);
                DateTime lNext = new DateTime(FromDate.Year, FromDate.Month, lTotalDays);
                DateTime lPrev = new DateTime(FromDate.Year, FromDate.Month, 1);
                lblStartDate.Value = FromDate.ToString("MMMM") + " " + FromDate.Year.ToString();

                // Weekday headers
                DateHdr.Add("Sun");
                DateHdr.Add("Mon");
                DateHdr.Add("Tue");
                DateHdr.Add("Wed");
                DateHdr.Add("Thu");
                DateHdr.Add("Fri");
                DateHdr.Add("Sat");

                DataTable dt = new DataTable();
                foreach (string day in DateHdr)
                    dt.Columns.Add(day);

                DataTable dtTourDate = new DataTable();

                try
                {
                    // ADO.NET code starts here
                    string pHours = "0";
                    pHours = "-" + pHours;

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetSpecialTourJourneyDate_SP, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TourID", Convert.ToInt32(fldTourID.Value));
                            cmd.Parameters.AddWithValue("@Month", FromDate.Month);
                            cmd.Parameters.AddWithValue("@Year", FromDate.Year);
                            cmd.Parameters.AddWithValue("@Hours", Convert.ToInt32(pHours));

                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dtTourDate);
                            }
                        }
                    }
                    // ADO.NET code ends here

                    lbl.Text = "(" + FromDate.ToString("MMM") + " " + FromDate.ToString("yyyy") + ")<br>Seat Availability in";

                    ArrayList ArrDays = new ArrayList();

                    int pRow = 5;
                    if ((lPrev.DayOfWeek.ToString() == "Friday" && (lTotalDays == 30 || lTotalDays == 31)) ||
                        (lPrev.DayOfWeek.ToString() == "Saturday" && (lTotalDays == 30 || lTotalDays == 31)))
                    {
                        pRow = 6;
                    }

                    for (int Row = 0; Row < pRow; Row++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int Week = 0; Week < dt.Columns.Count; Week++)
                        {
                            string[] DateArr = lPrev.ToString("D").Split(',');
                            string lDay = DateArr[0].Substring(0, 3);
                            string lMon = DateArr[1].Substring(0, 4);
                            string lDate = DateArr[1].Substring(DateArr[1].Length - 2, 2);
                            string lYear = DateArr[2].Substring(DateArr[2].Length - 2, 2);
                            string lShortDate = lDate.Trim() + " " + lMon.Trim() + " " + lYear.Trim();

                            if (lMon.Trim() == FromDate.ToString("MMM"))
                            {
                                if (dt.Columns[Week].ColumnName.ToUpper() == lDay.ToUpper().Trim())
                                {
                                    dr[Week] = lDate.Trim();
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
                                item.Cells[i].Style.Add("text-align", "center");
                                item.Cells[i].Style.Add("vertical-align", "middle");
                            }
                            catch { }

                            if (item.Cells[i].Text != "" && item.Cells[i].Text != "&nbsp;")
                            {
                                HiddenField hdJDate = new HiddenField();
                                hdJDate.ID = "hdJDate" + item.Cells[i].Text;
                                item.Cells[i].Controls.Add(hdJDate);
                                hdJDate.Value = Convert.ToDateTime(item.Cells[i].Text + " " + lblStartDate.Value).ToString("MM/dd/yyyy");

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

                                    if (pDate.Date == JDate.Date)
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
                                        item.Cells[i].Attributes.Add("onmouseout", "this.style.color='#848f98';this.style.backgroundColor='#f3f3f3'");
                                        item.Cells[i].BackColor = System.Drawing.Color.FromName("#f3f3f3");
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exception here
                }
                finally
                {
                    if (dtTourDate != null)
                    {
                        dtTourDate.Dispose();
                        dtTourDate = null;
                    }
                }
            }
            catch
            {
                // Handle outer exceptions here
            }
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

                    /*e.Row.Cells[i].ForeColor = System.Drawing.Color.FromName("#FFF");
                    e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("#FFC99A");
                    //e.Row.Cells[i].Style.Add("font-weight", "bold");
                    e.Row.Cells[i].Style.Add("text-align", "center");
                    e.Row.Cells[i].Style.Add("vertical-align", "middle");
                    e.Row.Cells[i].Width = Unit.Pixel(50);
                    e.Row.Cells[i].Height = Unit.Pixel(25);
                    e.Row.Cells[i].BorderWidth = Unit.Pixel(1);
                    e.Row.Cells[i].BorderColor = System.Drawing.Color.White;*/
                }
            }
            //if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.EmptyDataRow)
            //{
            //    for (int i = 0; i < 7; i++)
            //    {
            //        e.Row.Cells[i].BorderColor = System.Drawing.Color.Gray;
            //        e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
            //        e.Row.Cells[i].BorderWidth = Unit.Pixel(1);

            //    }
            //}
        }

        protected void ddlSPLMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdFromDate.Value = "01" + " " + ddlSPLMonth.SelectedValue + " " + ddlSPLYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            //BalloonPopupExtender2.DisplayOnFocus = true;
        }
        protected void ddlSPLYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindMonth(ddlSPLMonth);
            hdFromDate.Value = "01" + " " + ddlSPLMonth.SelectedValue + " " + ddlSPLYear.SelectedValue;
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();
            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));
            //BalloonPopupExtender2.DisplayOnFocus = true;
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
            //tblCal.Visible = true;
            btnLeft.Visible = true;
            lblCurrentDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();

            DateTime lDate = Convert.ToDateTime(lblCurrentDate.Value);

            hdFromDate.Value = lDate.Month.ToString() + " " + "01" + " " + lDate.Year.ToString();
            hdToDate.Value = Convert.ToDateTime(hdFromDate.Value).AddMonths(1).ToString();

            BindCalendar(Convert.ToDateTime(hdFromDate.Value), Convert.ToDateTime(hdToDate.Value));

            //if (Convert.ToDateTime(hdLastDateCal.Value).Month == Convert.ToDateTime(hdFromDate.Value).Month
            //       && Convert.ToDateTime(hdLastDateCal.Value).Year == Convert.ToDateTime(hdFromDate.Value).Year)
            //{
            //    btnRight.Visible = false;

            //}
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

                lConn = new SqlConnection(connectionString);// For  Live

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
                    if (Convert.ToString(ldsDetail.Tables[0].Rows[0]["JourneyDate"]) != "")
                        hdLastDateCal.Value = Convert.ToDateTime(ldsDetail.Tables[0].Rows[0]["JourneyDate"]).ToString("MM/dd/yyyy");
                }
                else
                {
                    //btnRight.Visible = false;
                    //btnLeft.Visible = false;
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