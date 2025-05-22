using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcMatchingTour : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"

        int pvTourType;
        int pvTourID;
        string pvprefixText = "";
        int pvMinDay;
        int pvMaxDay;
        int pvTravelMonth;
        bool pvIncludeCityOutput;
        int pvZoneID;
        bool pvIsLTC = false;
        public string pvRedirectPage = "";
        protected string connectionString;
        #endregion
        #region "Property(s)"
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

        public bool fldIsLTC
        {
            get { return pvIsLTC; }
            set { pvIsLTC = value; }
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

        public string fldPrefixText
        {
            get
            {
                return pvprefixText;
            }
            set
            {
                pvprefixText = value;
            }
        }

        public int fldMinDay
        {
            get
            {
                return pvMinDay;
            }
            set
            {
                pvMinDay = value;
            }
        }

        public int fldMaxDay
        {
            get
            {
                return pvMaxDay;
            }
            set
            {
                pvMaxDay = value;
            }
        }

        public int fldTravelMonth
        {
            get
            {
                return pvTravelMonth;
            }
            set
            {
                pvTravelMonth = value;
            }
        }

        public bool fldIncludeCityOutput
        {
            get
            {
                return pvIncludeCityOutput;
            }
            set
            {
                pvIncludeCityOutput = value;
            }
        }


        public int fldZoneID
        {
            get
            {
                return pvZoneID;
            }
            set
            {
                pvZoneID = value;
            }
        }

        public string fldRedirectPage
        {
            get
            {
                return pvRedirectPage;
            }
            set
            {
                pvRedirectPage = value;
            }
        }

        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.AppSettings["southernconn"];

            if (!IsPostBack)
            {
                //ShowMatchingTour();
                ShowMatchingTour_New();
            }
        }
        protected void repMatchingTour_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltr = (Literal)e.Item.FindControl("ltrNoDaysNight");
                //Literal ltrTourTypeText = (Literal)e.Item.FindControl("ltrTourTypeText");
                Literal litCost = (Literal)e.Item.FindControl("litCost");
                Literal ltrTourName = (Literal)e.Item.FindControl("ltrTourName");
                CultureInfo CInfo = new CultureInfo("hi-IN");
                HiddenField hdHolidayType = (HiddenField)e.Item.FindControl("hdHolidayType");
                HiddenField hdTourType = (HiddenField)e.Item.FindControl("hdTourType");
                DataRowView row = (DataRowView)e.Item.DataItem;
                string TourName = Convert.ToString(row["TourName"]);
                int TourId = Convert.ToInt32(row["TourId"]);
                bool IsLtc = false;  //Has to set the value 
                HtmlAnchor anch = (HtmlAnchor)e.Item.FindControl("anchorTag");
                string lTourCost = "<p>Package Starting @ <i class='fa fa-rupee'></i> " + Convert.ToDecimal(row["MinCost"]).ToString("N", CInfo).Split('.')[0] + " /- </p>";
                if (Convert.ToDecimal(row["MinCost"]) == 0)
                {
                    lTourCost = "<p>Package On Request</p>";
                }
                litCost.Text = lTourCost;// Convert.ToDecimal(row["MinCost"]).ToString("N", CInfo).Split('.')[0] + " /-";
                string[] lTourCode = TourName.Split(':');
                ltrTourName.Text = "<p>Tour Code  : " + lTourCode[0] + "</p><h3>" + lTourCode[1] + "</h3>";

                if (ConvertStringToInt(Convert.ToString(row["NoOfDays"])) > 0)
                {
                    ltr.Text = ltr.Text + Convert.ToString(row["NoOfDays"]) + " D ";
                }
                if (ConvertStringToInt(Convert.ToString(row["NoOfNights"])) > 0)
                {
                    ltr.Text = ltr.Text + " / " + Convert.ToString(row["NoOfNights"]) + " N ";
                }

                if (Convert.ToInt32(hdTourType.Value) == Convert.ToInt32(TOURTYPE.FIXED_TOUR))
                {
                    if (IsLtc == true)
                    {
                        fldRedirectPage = "../Fixed-Departure-LTC-Itinerary-" + TourName.Trim().Replace(" ", "-").Replace(":", "") + "_" + Convert.ToString(TourId);
                        anch.HRef = fldRedirectPage;
                        //ltrTourTypeText.Text = "Fixed Departure";
                    }
                    else
                    {
                        //  lbtnTour.NavigateUrl = "../Fixed-Departure-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                        fldRedirectPage = "../Fixed-Departure-Itinerary-" + TourName.Trim().Replace(" ", "-").Replace(":", "") + "_" + Convert.ToString(TourId);
                        anch.HRef = fldRedirectPage;
                        //ltrTourTypeText.Text = "Fixed Departure";
                    }
                    //if (hdTourID.Value.Trim() == "45")
                    //{
                    //    lblTourName.ToolTip += " (Starts From 06-Sep-2014)";
                    //}
                    //if (hdTourID.Value.Trim() == "130")
                    //{
                    //    lblTourName.ToolTip += " (25-Sep-2014 To 05-Oct-2014)";
                    //}
                }
                else if (Convert.ToInt32(hdTourType.Value) == Convert.ToInt32(TOURTYPE.SPECIAL_TOUR))
                {
                    //lbtnTour.NavigateUrl = "../Holiday-Packages-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                    fldRedirectPage = "../Holiday-Packages-Itinerary-" + TourName.Replace(" ", "-").Replace(":", "") + "_" + Convert.ToString(TourId);
                    anch.HRef = fldRedirectPage;
                    //ltrTourTypeText.Text = "Holiday Packages";
                }
                else if (Convert.ToInt32(hdTourType.Value) == Convert.ToInt32(TOURTYPE.INTERNATIONAL_TOUR))
                {
                    //lbtnTour.NavigateUrl = "../Holiday-Packages-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                    if (hdHolidayType.Value == "Fixed Tours")
                    {
                        //fldRedirectPage = "../InternationalTours-" + TourName.Replace(" ", "-").Replace(":", "") + "_" + Convert.ToString(TourId);
                        fldRedirectPage = "../IntItenaryDetails.aspx?TourId=" + TourId.ToString() + "&ofr=2";
                        anch.HRef = fldRedirectPage;
                    }
                    else
                    {
                        //fldRedirectPage = "../InternationalTours-" + TourName.Replace(" ", "-").Replace(":", "") + "_" + Convert.ToString(TourId);
                        fldRedirectPage = "../IntItenaryDetails.aspx?TourId=" + TourId.ToString() + "&ofr=1";
                        anch.HRef = fldRedirectPage;
                    }
                    //ltrTourTypeText.Text = "International Tour";
                }
            }
        }
        protected void dgShowItinerary_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
           
        }
        #endregion
        #region "Method(s)"

        private void ShowMatchingTour_New()
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            DataSet ldsetail = new DataSet();
            SqlDataAdapter lDataAdp = null;
            DataTable dt = new DataTable();
            try
            {
                lConn = new SqlConnection(connectionString);// For  Live

                lCommand = new SqlCommand(StoredProcedures.GetSimilarPKGEndUser_SP, lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@I_TourType", fldTourType);
                lCommand.Parameters.AddWithValue("@I_TourID", fldTourID);

                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }
                lCommand.ExecuteNonQuery();

                lDataAdp = new SqlDataAdapter(lCommand);
                lDataAdp.Fill(ldsetail);

                if (ldsetail != null && ldsetail.Tables.Count > 0)
                {
                    dt = ldsetail.Tables[0];
                    if (dt.Rows.Count > 1)
                    {
                        dt.DefaultView.RowFilter = "TourId<>'" + Convert.ToString(fldTourID) + "'"; // +Convert.ToString(Enums.PackageType.LNFPRO);   // lnfPro 3
                        divMsg.Visible = false;
                        if (dt != null && dt.DefaultView.Count > 0)
                        {
                            repMatchingTour.DataSource = dt.DefaultView;
                            repMatchingTour.DataBind();
                        }
                        else
                        {
                            divMsg.Visible = true;
                            ltrMsg.Text = "Recommended tours by our travel experts.";
                        }
                    }
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
                if (ldsetail != null)
                {
                    ldsetail.Dispose();
                    ldsetail = null;
                }
                if (lDataAdp != null)
                {
                    lDataAdp.Dispose();
                    lDataAdp = null;
                }
            }
        }
        private void ShowMatchingTour()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            List<TourItenerary_SPResult> lGetResult = null;
            ClsCommon objOther = new ClsCommon();

            try
            {
                lGetResult = new List<TourItenerary_SPResult>();

                lGetResult = objOther.fnGetTourItenerary(fldTourID, fldTourType).ToList();
                fldPrefixText = lGetResult[0].TourName.ToString();
            }
            catch
            {
            }
            finally
            {
                if (lGetResult != null)
                {
                    lGetResult = null;
                }
            }
            fldPrefixText = fldPrefixText.ToLower().Replace("volvo", "").Replace("a.c", "").
                /*Replace("ac", "").*/Replace("best", "").Replace("of", "").Replace("days", "").Replace("day", "").
                Replace("nights", "").Replace("night", "").Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").
                Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("food", "").Replace("city", "").Replace("temple", "").
                Replace("tours", "").Replace("tour", "").Replace("package", "").Replace("exciting", "").Replace("majestic", "").Replace("splendours", "").Trim();

            if (fldPrefixText.LastIndexOf('%') == -1)
            {
                fldPrefixText = fldPrefixText.TrimEnd('-').Replace('-', '%');
            }
            else
            {
                fldPrefixText = fldPrefixText.Trim().Replace('-', '%');
            }
            if (fldTourType == 3)
            {
                if (Request.QueryString["ofr"] == "1")
                {
                    //fldTourID = 0;
                }
                try
                {
                    DataTable dtResult = GetTourZone(fldTourType, fldTourID).Tables[0];
                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        fldZoneID = Convert.ToInt32(dtResult.Rows[0]["ZoneID"]);
                    }
                }
                catch
                {
                    fldZoneID = 0;
                }
                fldPrefixText = "";
            }
            try
            {
                DataTable dtResult = GetTourZone(fldTourType, fldTourID).Tables[0];
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    fldZoneID = Convert.ToInt32(dtResult.Rows[0]["ZoneID"]);
                    fldPrefixText = "";
                }
            }
            catch
            {
                fldZoneID = 0;
            }
            ds = new ClsCommon().GetTourList(fldPrefixText.Trim(), fldMinDay, fldMaxDay, fldTravelMonth, fldTourType,
                fldIncludeCityOutput, fldTourID, fldZoneID);

            try
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count > 1)
                {
                    dt.DefaultView.RowFilter = "TourId<>'" + Convert.ToString(fldTourID) + "'"; // +Convert.ToString(Enums.PackageType.LNFPRO);   // lnfPro 3
                    divMsg.Visible = false;
                    if (dt != null && dt.DefaultView.Count > 0)
                    {
                        repMatchingTour.DataSource = dt.DefaultView;
                        repMatchingTour.DataBind();
                    }
                    else
                    {
                        divMsg.Visible = true;
                        ltrMsg.Text = "Recommended tours by our travel experts.";
                    }
                }
                else
                {
                    DataTable dtTourZone = new DataTable();
                    dtTourZone = ds.Tables[1];
                    fldZoneID = Convert.ToInt32(dtTourZone.Rows[0]["ZoneID"]);
                    fldPrefixText = "";

                    ds = new DataSet();
                    dt = new DataTable();
                    //fldTourID = 0;
                    ds = new ClsCommon().GetTourList(fldPrefixText.Trim(), fldMinDay, fldMaxDay, fldTravelMonth, fldTourType,
                fldIncludeCityOutput, fldTourID, fldZoneID);

                    dt = ds.Tables[0];

                    dt.DefaultView.RowFilter = "TourId<>'" + Convert.ToString(fldTourID) + "'";

                    divMsg.Visible = true;
                    ltrMsg.Text = "Recommended tours by our travel experts.";

                    if (dt != null && dt.DefaultView.Count > 0)
                    {
                        repMatchingTour.DataSource = dt.DefaultView;
                        repMatchingTour.DataBind();
                    }

                }
                if (fldTourType == 3)
                {
                    divMsg.Visible = false;

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (dt != null)
                {
                    dt = null;
                }
                if (ds != null)
                {
                    ds = null;
                }
            }
        }
        public DataSet GetTourZone(int pTourType, int pTourID)
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            DataSet ldsetail = new DataSet();
            SqlDataAdapter lDataAdp = null;

            try
            {
                lConn = new SqlConnection(connectionString);// For  Live

                lCommand = new SqlCommand(StoredProcedures.GetTourZone_SP, lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@I_TourType", pTourType);
                lCommand.Parameters.AddWithValue("@I_TourID", pTourID);

                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }
                lCommand.ExecuteNonQuery();

                lDataAdp = new SqlDataAdapter(lCommand);
                lDataAdp.Fill(ldsetail);

                if (ldsetail != null && ldsetail.Tables.Count > 0)
                {
                    return ldsetail.Copy();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
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
                if (ldsetail != null)
                {
                    ldsetail.Dispose();
                    ldsetail = null;
                }
                if (lDataAdp != null)
                {
                    lDataAdp.Dispose();
                    lDataAdp = null;
                }
            }

        }
        public int ConvertStringToInt(string IntString)
        {
            Int32 decval = 0;
            if (string.IsNullOrEmpty(IntString))
            {
                decval = 0;
            }
            else
            {
                try
                {
                    decval = Convert.ToInt32(IntString);
                }
                catch (Exception ex)
                {
                    decval = 0;
                }

            }
            return decval;
        }
        #endregion
    }
}