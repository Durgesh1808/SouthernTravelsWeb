using ASPEMAILLib;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
namespace SouthernTravelsWeb.BLL
{


    public enum BASE_PAYMENT_TYPE
    {
        [Description("Cash")]
        CASH = 1,
        [Description("Net Banking")]
        TECH_PROCESS = 5,
        [Description("HDFC")]
        HDFC = 6,
        [Description("AMEX")]
        AMEX = 7,
        [Description("ATOM")]
        ATOM = 63
    }
    public struct RequestStatus
    {
        public bool Status;

        public int ErrNo;

        public string ErrDesc;
    }
    public enum pbException
    {
        [Description("Success")]
        SUCCESS = 1,
        [Description("Data not found.")]
        ERR_DATANOT_FOUND = 1001,
        [Description("Data Not Save.")]
        ERR_DATANOT_SAVE = 1002,
        [Description("Record Already Exist.")]
        ERR_RECORD_EXIST = 1003,
        [Description("Sorry For your inconvience.The Error has been Logged and will be rectified soon.")]
        ERR_CATCH_BLOCK = 1004,
        [Description("Sorry For your inconvience for saving data.")]
        ERR_SAVE_CATCH_BLOCK = 1005,
        [Description("Geocode value is not available.")]
        ERR_GEOCODE_NOT_FOUND = 1006,
        [Description("Season with same name already exist.")]
        ERR_SEASON_EXIST = 1007,
        [Description("Date range already exist.")]
        ERR_SEASON_DATE_EXIST = 1008,
        [Description("Week days already exists within same date range in some other season.")]
        ERR_WEEK_DAYS_ALREADY_EXIST = 1009,
        [Description("Sorry For your inconvience for Delete data.")]
        ERR_DELETE_CATCH_BLOCK = 1010,
        [Description("Approval levelName already exist.")]
        ERR_APP_LEVEL_EXS = 1011,
        [Description("Priority level already registered.")]
        ERR_PR_LEVEL_EXS = 1012,
        [Description("Date collapsing with previous date range.")]
        ERR_DATE_COLLAPSE = 1013
    }
    public enum Booking_Source // *** CHANGED
    {
        MBK = 1,
        ENQ = 2
    }
    public enum GE_Section // *** CHANGED
    {
        ITINERARY = 1,
        COSTING = 2,
        BILLING = 3,
        BOOKING = 4
    }
    public enum pvTour_Mail // *** CHANGED
    {
        [Description("Fixed Tour")]
        EBK = 1,
        [Description("Special Tour")]
        SPL = 2,
        [Description("CAB Bookings")]
        CAB = 3,
        [Description("HAC Booking")]
        HAC = 4,
        [Description("Flight Bookings")]
        FRN = 5,
        [Description("Train Bookings")]
        TRN = 6,
        [Description("Group Booking")]
        GRP = 7,
        [Description("Total")]
        TOT = 8
    }
    public enum pvTour // *** CHANGED
    {
        [Description("Fixed Tour")]
        EBK = 1,
        [Description("Special Tour")]
        SPL = 2,
        [Description("Cab Tour")]
        CAB = 3,
        [Description("Hotel Southern Accommodation")]
        HAC = 4,
        [Description("Continued Southern Hotel")]
        CONTHAC = 17,
        [Description("Flight")]
        FRN = 5,
        [Description("Continued Flight")]
        CONTFRN = 18,
        [Description("Train")]
        TRN = 6,
        [Description("Continued Train")]
        CONTTRN = 19,
        [Description("Accommodation")]
        ACCOM = 7,
        [Description("Continued Accommodation")]
        CONTACC = 8,
        [Description("Transport")]
        TRANS = 9,
        [Description("Continued Transport")]
        CONTTRANS = 10,
        [Description("En-route")]
        ENRT = 11,
        [Description("Tour Escort")]
        GUID = 12,
        [Description("Other Service")]
        OTHS = 13,
        [Description("Tour Continued")]
        CONT = 14,
        [Description("Cancel Tour")]
        CANL = 15,
        [Description("Split Tour")]
        SPLIT = 16,
        [Description("Day Free")]
        DAYFREE = 20
    }
    /// <summary>
    /// Tour Type enum
    /// </summary>
    public enum TOURTYPE
    {
        [Description("AL")]
        ALL_TOUR = -1,
        [Description("FT")]
        FIXED_TOUR = 1,
        [Description("ST")]
        SPECIAL_TOUR = 2,
        [Description("INT")]
        INTERNATIONAL_TOUR = 3,
        [Description("GRP")]
        GROUP_TOUR = 4,
        [Description("ADH")]
        ADHOC_TOUR = 5,
        [Description("CAB")]
        CAB_TOUR = 6,
        [Description("LTCFT")]
        LTC_FIXED_TOUR = 7,
        [Description("FTBKNG")]
        FIXED_TOUR_BOOKING = 8,
        [Description("LFTBKNG")]
        LTC_FIXED_TOUR_BOOKING = 9,
        [Description("STBKNG")]
        SPECIAL_TOUR_BOOKING = 10,
        [Description("SPAX")]
        SPECIAL_PAX_TOUR = 11,
        [Description("SPBKNG")]
        SPECIAL_PAX_TOUR_BOOKING = 12,
        [Description("HACB")]
        HAC_TOUR_BOOKING = 13,
        [Description("BAL")]
        TKT_BAL_CLEAR = 14,
        [Description("AAFD")]
        AGENT_ADD_FUND = 15,
        [Description("FRN")]
        Flight_Booking = 16,
        [Description("TRN")]
        Rail_Booking = 17,
        [Description("MBK")]
        MBK_Booking = 19,
    }
    /// <summary>
    /// Current End User Section
    /// </summary>
    public enum Current_Section
    {
        FIXED_DEPARTURE = 1,
        HOLIDAY_PACKAGE_CAR = 2,
        HOLIDAY_PACKAGE_INTERNATIONAL = 3,
        HOLIDAY_PACKAGE_CRUISE = 4,
        HOTEL_DELHI = 5,
        HOTEL_IN_INDIA = 6,
        CAR_COACH_RENTAL = 7,
        DOMESTIC_FLIGHT = 8,
        LTC_LFC_TOUR = 9,
        ENQUIRY = 10,
        CONTACT_US = 11,
        HOME = 12,
        AGENT_LOGIN = 13,
        CUST_Login = 14,
        E_BROCHURE = 16,
        HOLIDAY_PACKAGE_INTERNATIONAL_CUSTOMIZED = 17,
        HOLIDAY_PACKAGE_INTERNATIONAL_FIXED = 18,
        CRUISE_PACKAGES = 19
    }
    public enum ItineraryTourType
    {
        [Description("FIXED DEPARTURE")]
        EBK = 1,
        [Description("HOLIDAY PACKAGE")]
        SPL = 2,
        [Description("CAR COACH RENTAL")]
        CAB = 3,
        [Description("Accommodation")]
        Accommodation = 4,
        [Description("Transport")]
        Transport = 5,
        [Description("Tour Continue")]
        TourContinue = 6,
    }
    public enum NextStep
    {
        [Description("REF")]
        REFUND = 1,
        [Description("RES")]
        REISSUE = 2
    }
    public enum Section
    {
        SEC_EndUser = 1,
        SEC_Branch = 2,
        SEC_Agent = 3,
        SEC_Kerala = 4,
        SEC_ControlPanel = 5
    }
    public enum VehicleType
    {
        Bus = 1,
        Car = 3,
        Tempo_Traveller = 3
    }
    public enum HotelFareType
    {
        [Description("For GRP And SPL")]
        FIT = 1,
        [Description("For Fixed")]
        GIT = 2
    }
    public enum EntityStatus
    {
        [Description("")]
        ALL,
        [Description("A")]
        ACTIVE,
        [Description("I")]
        INACTIVE,
        [Description("R")]
        REJECTED,
        [Description("D")]
        DELETED
    }
    public enum Approval_Status
    {
        [Description("")]
        ALL,
        [Description("A")]
        APPROVED,
        [Description("P")]
        PENDING,
        [Description("R")]
        REJECTED,
        [Description("D")]
        DELETED
    }
    public enum Approval_Section
    {
        [Description("REQST")]
        REQUEST = 1,
        [Description("APRVL")]
        APPROVAL = 2,
        [Description("REPRT")]
        REPORT = 3,
        [Description("REPFL")]
        REPORT_FILTER = 4
    }
    public enum Request_Section
    {
        [Description("ORCAN")]
        OVER_RIDE_CANCEL_BEFORE_DOJ = 1,
        [Description("CANADOJ")]
        CANCEL_AFTER_DOJ = 2,
        [Description("EBKZEROADV")]
        ZERO_ADVANCE_EBK = 3,
        [Description("REUSECAN")]
        REUSE_CAN = 4,
        [Description("CANREISSUE")]
        OVER_RIDE_CANCEL_REISSUE = 5,
        [Description("CANCELREISSUE")]
        CANCEL_REISSUE = 18,
    }

    public class DataListResponse<T>
    {
        public List<T> ResultList;

        public RequestStatus Status;
    }
    /// <summary>
    /// Summary description for ClsCommon
    /// </summary>
    public class ClsCommon
    {
      
        #region Public Member Variable(s)
        /// <summary>
        /// Web config's connection string name.
        /// </summary>
        private static string connectionString;

        #endregion
        #region Propertie(s)
        /// <summary>
        /// Get Connection String
        /// </summary>
       
        public ClsCommon()
        {
            connectionString =DataLib.getConnectionString();
        }
        #endregion
        public static DataTable Fixed_ToursAtAGlance(string pDay, string pMonth, string pYear, string pBranchCode)
        {
            DataTable ldtToursAtAGlance = new DataTable();
            string connStr = DataLib.getConnectionString(); // From config
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.Fixed_DatewiseTours_Vacantseats, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters to match the stored procedure
                        cmd.Parameters.AddWithValue("@I_Day", pDay);
                        cmd.Parameters.AddWithValue("@I_Month", pMonth);
                        cmd.Parameters.AddWithValue("@I_Year", pYear);
                        cmd.Parameters.AddWithValue("@I_Branch", pBranchCode);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ldtToursAtAGlance);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Optionally log the exception
                    return null;
                }
            }
            return ldtToursAtAGlance.Rows.Count > 0 ? ldtToursAtAGlance.Copy() : null;
        }


        public static void ShowAlert(System.Web.UI.Page currentPage, string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            currentPage.ClientScript.RegisterStartupScript(typeof(ClsCommon), "showalert", sb.ToString(), true);
        }
        public static void ShowAlert(string Msg)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                Msg = Msg.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(),
                 "err_msg", "alert('" + Msg + "');", true);
            }
        }
        public DataTable GetNewsNotificationList(int pNewsID, string pNewsType, int pIsActive, DateTime? pStartDate, DateTime? pEndDate,
                int pTourID, string pLandingUrl, int pTourType)
        {
            DataTable resultTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetNewsNotificationList_sp, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                cmd.Parameters.AddWithValue("@NewsID", pNewsID);
                cmd.Parameters.AddWithValue("@NewsType", pNewsType ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", pIsActive);
                cmd.Parameters.AddWithValue("@LandingURL", pLandingUrl ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@StartDate", pStartDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EndDate", pEndDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TourID", pTourID);
                cmd.Parameters.AddWithValue("@TourType", pTourType);

                try
                {
                    adapter.Fill(resultTable);
                    return resultTable.Rows.Count > 0 ? resultTable.Copy() : null;
                }
                catch (Exception ex)
                {
                    // Optionally log error: ex.Message
                    return null;
                }
            }
        }

        /// <summary>
        /// Convert Date Formate from MM/dd/yyyy to dd/MM/yyyy
        /// </summary>
        /// <param name="date1"></param>
        /// <returns> Date Formate of dd/MM/yyyy  </returns>
        public static string mmddyy2ddmmyy(string pDate)
        {
            if (pDate != null || pDate != "")
            {
                string[] DateArr3 = new string[3];
                char[] splitter1 = { '/' };
                DateArr3 = pDate.Split(splitter1);
                if (DateArr3.Length > 2)
                    return DateArr3[1] + "/" + DateArr3[0] + "/" + DateArr3[2].Substring(0, 4);
                else
                    return "";
            }
            else
                return "";
        }

        public static string ddmmyy2mmddyy(string pDate)
        {
            pDate = pDate.Replace("-", "/");
            if (pDate != null || pDate != "")
            {
                string[] DateArr3 = new string[3];
                char[] splitter1 = { '/' };
                DateArr3 = pDate.Split(splitter1);
                if (DateArr3.Length > 2)
                    return DateArr3[1] + "/" + DateArr3[0] + "/" + DateArr3[2].Substring(0, 4);
                else
                    return "";
            }
            else
                return "";
        }

        public List<GetTourList_By_Start_RegionResult> GetTourListByStartRegion(TOURTYPE tourType, string region)
        {
            List<GetTourList_By_Start_RegionResult> list = new List<GetTourList_By_Start_RegionResult>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourList_By_Start_Region, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 1) Input parameters
                    cmd.Parameters.Add("@I_TourType", SqlDbType.Int).Value = (int)tourType;
                    cmd.Parameters.Add("@I_Region", SqlDbType.VarChar, 100).Value = region.Trim();

                    // 2) Output parameter (mandatory)
                    var outParam = new SqlParameter("@O_ReturnValue", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParam);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new GetTourList_By_Start_RegionResult
                            {
                                TourID = reader.GetInt32(reader.GetOrdinal("RowID")),
                                TourNo = reader.GetInt32(reader.GetOrdinal("TourNo")),
                                TourName = reader.GetString(reader.GetOrdinal("TourName")),
                                Tour_Short_Key = reader.GetString(reader.GetOrdinal("Tour_Short_Key")), // adjust if you want another
                                EndLocation = reader.GetString(reader.GetOrdinal("FullTourName")),
                                DurationDays = reader.GetInt32(reader.GetOrdinal("TourSequence")),   // as example
                                MinCost = reader.GetDecimal(reader.GetOrdinal("MinCost")),
                                TourType = reader.GetString(reader.GetOrdinal("TourGoingOn")),
                                TourGoingOn = reader.GetString(reader.GetOrdinal("TourGoingOn")),
                                DepartureWeekDays = reader.GetString(reader.GetOrdinal("DepartureWeekDays")),
                                ImageUrl = null,    // SP doesn’t return ImageUrl; set if you extend SP
                                Description = reader.GetString(reader.GetOrdinal("Remarks")),
                                IsFeatured = false    // SP doesn’t return this; omit or extend
                            });
                        }
                    }
                }
            }

            return list;
        }


        public static DataSet GetTourListAll(int lPageIndex, int lPageSize, int lSort, string prefixText, int pMinDay, int pMaxDay, int pTravelMonth,
        int pTourType, bool pIncludeCityOutput, int pTourID, int pZoneID, int pNoOfDays, int pPriceMin, int pPriceMax, int pOfferID)
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            DataSet ldsetail = new DataSet();
            SqlDataAdapter lDataAdp = null;

            try
            {
                lConn = new SqlConnection(connectionString);// For  Live

                lCommand = new SqlCommand(StoredProcedures.GetTourListSearchWithPagging_SP, lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@I_SearchString", prefixText);
                lCommand.Parameters.AddWithValue("@I_MinDays", pMinDay);
                lCommand.Parameters.AddWithValue("@I_MaxDays", pMaxDay);
                lCommand.Parameters.AddWithValue("@I_TravelMonth", pTravelMonth);
                lCommand.Parameters.AddWithValue("@I_TourID", pTourID);
                lCommand.Parameters.AddWithValue("@I_TourType", pTourType);
                lCommand.Parameters.AddWithValue("@I_IncludeCity", pIncludeCityOutput == true ? 1 : 0);
                lCommand.Parameters.AddWithValue("@I_ZoneID", pZoneID);
                lCommand.Parameters.AddWithValue("@I_PageIndex", lPageIndex);
                lCommand.Parameters.AddWithValue("@I_PageSize", lPageSize);
                lCommand.Parameters.AddWithValue("@I_SortBy", lSort);
                lCommand.Parameters.AddWithValue("@I_NoOfDays", pNoOfDays);
                lCommand.Parameters.AddWithValue("@I_PriceMin", pPriceMin);
                lCommand.Parameters.AddWithValue("@I_PriceMax", pPriceMax);
                lCommand.Parameters.AddWithValue("@I_OfferID", pOfferID);
                lCommand.Parameters.Add("@I_PageCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

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


        public static string GetTourList_New(int lPageIndex, int lPageSize, int lSort, string prefixText, int pMinDay, int pMaxDay, int pTravelMonth,
        int pTourType, bool pIncludeCityOutput, int pTourID, int pZoneID, int pNoOfDays, int pPriceMin, int pPriceMax, int pOfferID)
        {
            System.Globalization.CultureInfo CInfo = new System.Globalization.CultureInfo("hi-IN");
            DataSet ResProduct = GetTourListAll(lPageIndex, lPageSize, lSort, prefixText, pMinDay, pMaxDay, pTravelMonth,
             pTourType, pIncludeCityOutput, pTourID, pZoneID, pNoOfDays, pPriceMin, pPriceMax, pOfferID);

            StringBuilder sb = new StringBuilder();
            try
            {
                if (ResProduct == null || ResProduct.Tables[0].Rows.Count == 0)
                {
                    if (lPageIndex == 1)
                    {
                        sb.Append("<div class=\"col-md-12\"><p style=\"background-color: #ddd; border: solid 1px #eee; padding: 4px 15px; \">No Results found</p></div>");
                    }
                }
                if (ResProduct.Tables[0].Rows.Count > 0)
                {

                    for (int lctr = 0; lctr < ResProduct.Tables[0].Rows.Count; lctr++)
                    {
                        string lTourType = ResProduct.Tables[0].Rows[lctr]["HolidayType"].ToString(), URL = "";
                        if (ResProduct.Tables[0].Rows[lctr]["TourType"].ToString() == "1")
                        {
                            URL = "Fixed-Departure-Itinerary-" + ResProduct.Tables[0].Rows[lctr]["TourName"].ToString().Trim().Replace(" ", "-") + "_" +
                                ResProduct.Tables[0].Rows[lctr]["TourID"].ToString().Trim();
                        }
                        else if (ResProduct.Tables[0].Rows[lctr]["TourType"].ToString() == "2")
                        {
                            URL = "Holiday-Packages-Itinerary-" + ResProduct.Tables[0].Rows[lctr]["TourName"].ToString().Trim().Replace(" ", "-") + "_" +
                                ResProduct.Tables[0].Rows[lctr]["TourID"].ToString().Trim();
                        }
                        else if (ResProduct.Tables[0].Rows[lctr]["TourType"].ToString() == "3")
                        {
                            if (ResProduct.Tables[0].Rows[lctr]["HolidayType"].ToString() == "Fixed Tours")
                            {  URL = "IntItenaryDetails.aspx?TourId=" + ResProduct.Tables[0].Rows[lctr]["TourID"].ToString() + "&ofr=2";

                            }
                            else
                            { URL = "IntItenaryDetails.aspx?TourId=" + ResProduct.Tables[0].Rows[lctr]["TourID"].ToString() + "&ofr=1";
                            }
                        }
                        sb.Append("<div class=\"col-md-4\"><div class=\"intlbox\"><a href=" + URL + ">");

                        sb.Append("<div class=\"imgsection\"><span class=\"customtag2\">");
                        sb.Append(lTourType + "<img loading=\'lazy\' src=\"/Assets/images/custom-arrow.png\"></span><img loading='lazy' width='371px' height='385px' src=/Assets/images/EntityImage/" + ResProduct.Tables[0].Rows[lctr]["MainImg"].ToString() + "></div>");



                        string lTourInfo = "<p>Tour Code : " + ResProduct.Tables[0].Rows[lctr]["TourCode"].ToString() + "</p><h3>";
                        string lTourName = ResProduct.Tables[0].Rows[lctr]["TourName"].ToString();
                        string lTourDuration = ResProduct.Tables[0].Rows[lctr]["NoofDays"].ToString() + " D ";
                        lTourDuration += ResProduct.Tables[0].Rows[lctr]["NoofNights"].ToString() == "0" ? "</h3>" : " / " + ResProduct.Tables[0].Rows[lctr]["NoofNights"].ToString() + " N</h3>";

                        int lSeparator = 20;

                        

                        string lFinalTourName = Convert.ToString(lTourName).Length > lSeparator ?
                          Convert.ToString(lTourName).Substring(0,
                          (Convert.ToString(lTourName).Substring(0, lSeparator).LastIndexOf(" ") > 0 ?
                          Convert.ToString(lTourName).Substring(0, lSeparator).LastIndexOf(" ") :
                          Convert.ToString(lTourName).Substring(0, lSeparator).LastIndexOf("-"))) : Convert.ToString(lTourName);

                        if (lTourName.Length > lSeparator)
                        {
                            lFinalTourName += "<br>" + lTourName.Replace(lFinalTourName, "");
                        }

                        lFinalTourName = System.Threading.Thread.CurrentThread
                          .CurrentCulture.TextInfo.ToTitleCase(lFinalTourName.ToLower());

                        sb.Append("<div class=\"textsection\">" + lTourInfo + lFinalTourName + " " + lTourDuration);
                        if (Convert.ToInt32(ResProduct.Tables[0].Rows[lctr]["MinCost"]) == 0)
                        {
                            sb.Append("<p>Package On Request</p></div></a></div></div>");
                        }
                        else
                        {
                            sb.Append("<p>Package Starting @ <i class=\"fa fa-rupee\"></i> " +
                                Convert.ToDecimal(ResProduct.Tables[0].Rows[lctr]["MinCost"]).ToString("N", CInfo).Split('.')[0] + " /-</p></div></a></div></div>");
                        }

                        sb.Append("<div style='display:none'>" + lPageIndex.ToString() + "</div>");

                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("<div class=\"col-md-12\"><p style=\"background-color: #ddd; border: solid 1px #eee; padding: 4px 15px; \">" + ex.Message + "</p></div>");

            }
            return sb.ToString();
        }


        public static int ConvertStringint(object strInt)
        {
            int intval = 0;
            if (string.IsNullOrEmpty(Convert.ToString(strInt)) || strInt == "&nbsp;")
            {
                intval = 0;
            }
            else
            {
                try
                {
                    intval = Convert.ToInt32(strInt);
                }
                catch (Exception ex)
                {
                    intval = 0;
                }
            }
            return intval;
        }


        public DataSet GetTourList(string prefixText, int pMinDay, int pMaxDay, int pTravelMonth,
            int pTourType, bool pIncludeCityOutput, int pTourID, int pZoneID)
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            DataSet ldsetail = new DataSet();
            SqlDataAdapter lDataAdp = null;

            try
            {
                lConn = new SqlConnection(connectionString);// For  Live

                lCommand = new SqlCommand(StoredProcedures.GetTourListSearch_SP, lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@I_SearchString", prefixText);
                lCommand.Parameters.AddWithValue("@I_MinDays", pMinDay);
                lCommand.Parameters.AddWithValue("@I_MaxDays", pMaxDay);
                lCommand.Parameters.AddWithValue("@I_TravelMonth", pTravelMonth);
                lCommand.Parameters.AddWithValue("@I_TourID", pTourID);
                lCommand.Parameters.AddWithValue("@I_TourType", pTourType);
                lCommand.Parameters.AddWithValue("@I_IncludeCity", pIncludeCityOutput == true ? 1 : 0);
                lCommand.Parameters.AddWithValue("@I_ZoneID", pZoneID);

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

        public List<TourItenerary_SPResult> fnGetTourItenerary(int lTourID, int lTourType)
        {
            List<TourItenerary_SPResult> lResult = new List<TourItenerary_SPResult>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.TourItenerary_SP, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@I_TourID", lTourID);
                    cmd.Parameters.AddWithValue("@I_TourType", lTourType);

                    SqlParameter outputParam = new SqlParameter("@O_ReturnValue", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TourItenerary_SPResult result = new TourItenerary_SPResult
                                {
                                    Tour_Short_key = reader["Tour_Short_key"] as string,
                                    ISAccomodation = reader["ISAccomodation"] as char?,
                                    TourName = reader["TourName"] as string,
                                    Departuretime = reader["Departuretime"] as string,
                                    ReturnTime = reader["ReturnTime"] as string,
                                    CostIncludes = reader["CostIncludes"] as string,
                                    CostExcludes = reader["CostExcludes"] as string,
                                    Duration = reader["Duration"] as string,
                                    TourPolicy = reader["TourPolicy"] as string,
                                    Notes = reader["Notes"] as string,
                                    OccasionalItinerary = reader["OccasionalItinerary"] as string,
                                    NoOfDays = reader["NoOfDays"] as int?,
                                    NoOfNights = reader["NoOfNights"] as int?,
                                    DepartureWeekDays = reader["DepartureWeekDays"] as string,
                                    ReturnWweekDays = reader["ReturnWweekDays"] as string,
                                    TourGoingOn = reader["TourGoingOn"] as string,
                                    ImagePath = reader["ImagePath"] as string,
                                    CoachDetails = reader["CoachDetails"] as string,
                                    ZoneName = reader["ZoneName"] as string,
                                    State = reader["State"] as string,
                                    Fair = reader["Fair"] != DBNull.Value ? Convert.ToDecimal(reader["Fair"]) : 0,
                                    TourCost = reader["TourCost"] as string,
                                    HolidayType = reader["HolidayType"] as string,
                                    OfferZone = reader["OfferZone"] as string,
                                    Remarks = reader["Remarks"] as string,
                                    PageBanner = reader["PageBanner"] as string,
                                    ImageDescription = reader["ImageDescription"] as string,
                                    IsQuery = reader["IsQuery"] != DBNull.Value ? Convert.ToBoolean(reader["IsQuery"]) : false
                                };

                                lResult.Add(result);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle as needed
                        return new List<TourItenerary_SPResult>(); // Return empty list on error
                    }
                }
            }

            return lResult;
        }


        public int fninsert_SmsSend_tbl(decimal? pCustID, string pMblNo, string pUserID, string pMsg, string pUserName, string pBranchCode, string TransactionType,
                string TicketNo, string OrderId)
        {
            int status = 1;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.insert_SmsSend_tbl, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@pCustID", (object)pCustID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@pMblNo", (object)pMblNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@pUserID", (object)pUserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@pMsg", (object)pMsg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@pUserName", (object)pUserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@pBranchCode", (object)pBranchCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TransactionType", (object)TransactionType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TicketNo", (object)TicketNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OrderId", (object)OrderId ?? DBNull.Value);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery(); // You assume no result, just status
                        status = 0; // success
                    }
                    catch (Exception ex)
                    {
                        // Log exception (optional)
                        status = 1; // failure
                    }
                }
            }

            return status;
        }

        public DataSet fnGetIntMenu(string pOfferID)
        {
            DataSet dsResult = new DataSet();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetIntMenu_sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OfferID", (object)pOfferID ?? DBNull.Value);

                    try
                    {
                        conn.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dsResult); // Automatically fills all result sets (multiple tables)
                    }
                    catch (Exception ex)
                    {
                        dsResult = null;
                    }
                }
            }

            return dsResult;
        }

         public static void sendmail(
            string pTO, string pBCC, string pCC,
            string pFrom, string pSubject, string pBody,
            string pFromName = null)
        {
            try
            {
                // Ensure TLS 1.2 or higher for secure connections
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                // Read config
                bool useAuthMail = ConfigurationSettings.AppSettings["AuthMail"]?.ToUpper() == "TRUE";
                string smtpHost = ConfigurationSettings.AppSettings["SmtpHost"];
                string smtpPortStr = ConfigurationSettings.AppSettings["SmtpPort"];
                int smtpPort = 25;
                if (!string.IsNullOrEmpty(smtpPortStr) && int.TryParse(smtpPortStr, out int port))
                    smtpPort = port;

                // If TO email ends with @temp.com, redirect TO to BCC address
                if (!string.IsNullOrEmpty(pTO) && pTO.ToLower().EndsWith("@temp.com"))
                {
                    pTO = pBCC;
                }

                using (var mail = new System.Net.Mail.MailMessage())
                {
                    // From Address
                    var fromAddress = !string.IsNullOrEmpty(pFromName)
                        ? new System.Net.Mail.MailAddress(pFrom, pFromName)
                        : new System.Net.Mail.MailAddress(pFrom);

                    mail.From = fromAddress;

                    // Add TO recipients
                    if (!string.IsNullOrEmpty(pTO))
                    {
                        foreach (var toAddr in pTO.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries))
                            mail.To.Add(toAddr.Trim());
                    }

                    // Add BCC recipients
                    if (!string.IsNullOrEmpty(pBCC))
                    {
                        foreach (var bccAddr in pBCC.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries))
                            mail.Bcc.Add(bccAddr.Trim());
                    }

                    // Add CC recipients
                    if (!string.IsNullOrEmpty(pCC))
                    {
                        foreach (var ccAddr in pCC.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries))
                            mail.CC.Add(ccAddr.Trim());
                    }

                    mail.Subject = pSubject;
                    mail.Body = pBody;
                    mail.IsBodyHtml = true;

                    using (var smtpClient = new System.Net.Mail.SmtpClient(smtpHost, smtpPort))
                    {
                        if (useAuthMail)
                        {
                            // Use authentication settings from config based on 'from' email
                            string smtpUser = ConfigurationSettings.AppSettings[$"{pFrom.ToLower()}_username"];
                            string smtpPass = ConfigurationSettings.AppSettings[$"{pFrom.ToLower()}_password"];

                            if (!string.IsNullOrEmpty(smtpUser) && !string.IsNullOrEmpty(smtpPass))
                            {
                                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);
                                smtpClient.EnableSsl = true;
                            }
                        }
                        else
                        {
                            // No authentication, or use default credentials
                            smtpClient.UseDefaultCredentials = true;
                            smtpClient.EnableSsl = false;
                        }

                        smtpClient.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                // Ideally log this exception somewhere
                // For now, silent catch like your original, but consider logging!
            }
        }


        /// <summary>
        /// Mail With Attachment
        /// </summary>
        /// <param name="pTO"></param>
        /// <param name="pBCC"></param>
        /// <param name="pCC"></param>
        /// <param name="pFrom"></param>
        /// <param name="pSubject"></param>
        /// <param name="pBody"></param>
        /// <param name="pFromName"></param>
        /// <param name="pFileName"></param>
        public static void sendmail(string pTO, string pBCC, string pCC, string pFrom, string pSubject, string pBody, string pFromName, string pFileName)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                if (pTO.ToLower().EndsWith("@temp.com"))
                {
                    pTO = pBCC;
                }

                if (ConfigurationManager.AppSettings["PersistMailORSmtpHost"]?.ToUpper() == "TRUE")
                {
                    MailSend(pTO, pBCC, pCC, pFrom, pSubject, pBody, pFromName);
                }
                else if (ConfigurationManager.AppSettings["AuthMail"]?.ToUpper() == "TRUE")
                {
                    AuthMail(pTO, pBCC, pCC, pFrom, pSubject, pBody, pFromName, pFileName);
                }
                else
                {
                    SendSmtpMail(pTO, pBCC, pCC, pFrom, pSubject, pBody, pFromName, pFileName);
                }
            }
            catch (Exception ex)
            {
                // Optional: log exception
            }
        }
        public static void MailSend(string pTO, string pBCC, string pCC, string pFrom, string pSubject, string pBody, string pFromName)
        {
            SendSmtpMail(pTO, pBCC, pCC, pFrom, pSubject, pBody, pFromName, null);
        }
        public static void AuthMail(string pTO, string pBCC, string pCC, string pFrom, string pSubject, string pBody, string pFromName, string pFileName = null)
        {
            try
            {
                string smtpHost = ConfigurationManager.AppSettings["AuthMailSmtpIP"];
                int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["AuthMailSmtpPort"] ?? "587");
                string smtpUser = ConfigurationManager.AppSettings[pFrom.ToLower() + "_UserName"];
                string smtpPass = ConfigurationManager.AppSettings[pFrom.ToLower() + "_Password"];

                SendSmtpMail(pTO, pBCC, pCC, smtpUser, pSubject, pBody, pFromName, pFileName, smtpHost, smtpPort, smtpUser, smtpPass, true);
            }
            catch (Exception ex)
            {
                // Optional: log exception
            }
        }

        private static void SendSmtpMail(
    string pTO, string pBCC, string pCC, string pFrom, string pSubject, string pBody, string pFromName,
    string pFileName = null,
    string smtpHost = null,
    int smtpPort = 25,
    string smtpUser = null,
    string smtpPass = null,
    bool enableSsl = false)
        {
            using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
            {
                mail.From = new MailAddress(pFrom, pFromName);

                foreach (var addr in pTO.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                    mail.To.Add(addr.Trim());

                if (!string.IsNullOrWhiteSpace(pCC))
                    foreach (var addr in pCC.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                        mail.CC.Add(addr.Trim());

                if (!string.IsNullOrWhiteSpace(pBCC))
                    foreach (var addr in pBCC.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                        mail.Bcc.Add(addr.Trim());

                mail.Subject = pSubject;
                mail.Body = pBody;
                mail.IsBodyHtml = true;

                if (!string.IsNullOrWhiteSpace(pFileName) && File.Exists(pFileName))
                {
                    mail.Attachments.Add(new Attachment(pFileName));
                }

                smtpHost = smtpHost ?? ConfigurationManager.AppSettings["SmtpHost"];
                smtpPort = smtpPort == 0 ? Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"] ?? "25") : smtpPort;

                using (SmtpClient smtp = new SmtpClient(smtpHost, smtpPort))
                {
                    smtp.EnableSsl = enableSsl;

                    if (!string.IsNullOrWhiteSpace(smtpUser))
                        smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
                    else
                        smtp.UseDefaultCredentials = true;

                    smtp.Send(mail);
                }
            }
        }


        public DataTable fnGetMetaTagForTours(int? TourTypeId, int? TourId, int? CountryId, int? ZoneId)
        {
            DataTable dtMetaTags = new DataTable();


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetMetTagForTours_sp, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TourTypeId", TourTypeId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TourId", TourId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountryId", CountryId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ZoneId", ZoneId ?? (object)DBNull.Value);

                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtMetaTags);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log exception or handle as needed
                        return null;
                    }
                }
            }

            return dtMetaTags;
        }

        public List<GetTourPlaceInfo_SPResult> fnGetTourPlaceInfo(int pTourID, int pTourType)
        {
            List<GetTourPlaceInfo_SPResult> result = new List<GetTourPlaceInfo_SPResult>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourPlaceInfo_SP, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@I_TourID", pTourID);
                    cmd.Parameters.AddWithValue("@I_TourTypeID", pTourType);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new GetTourPlaceInfo_SPResult
                                {
                                    RowID = Convert.ToInt32(reader["RowID"]),
                                    TourTypeID = reader["TourTypeID"] as int?,
                                    TourID = reader["TourID"] as int?,
                                    CityID = reader["CityID"] as int?,
                                    PlaceID = reader["PlaceID"] as int?,
                                    CityName = reader["CityName"]?.ToString(),
                                    PlaceName = reader["PlaceName"]?.ToString(),
                                    ShortDescription = reader["ShortDescription"]?.ToString(),
                                    LongDescription = reader["LongDescription"]?.ToString(),
                                    ImagePath = reader["ImagePath"]?.ToString(),
                                    GeoCode = reader["GeoCode"].ToString(), // NOT NULL
                                    TourStartCity = reader["TourStartCity"].ToString(), // NOT NULL
                                    TourStartFrom = reader["TourStartFrom"]?.ToString(),
                                    TourStartFromID = reader["TourStartFromID"] as int?,
                                    StateName = reader["StateName"]?.ToString()
                                });
                            }

                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            return result;
        }

        public DataTable fnGetFixedTourJourneyDate(int? lTourNo, int? lMonth, int? lYear, int? lHours)
        {
            DataTable pdtTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetFixedTourJourneyDate_SP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@I_TourNo", lTourNo.HasValue ? (object)lTourNo.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@I_Month", lMonth.HasValue ? (object)lMonth.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@I_Year", lYear.HasValue ? (object)lYear.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@I_Hours", lHours.HasValue ? (object)lHours.Value : DBNull.Value);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(pdtTable);
                        }
                    }
                }

                return pdtTable;
            }
            catch (Exception ex)
            {
                // Log the error if necessary
                return null;
            }
            finally
            {
                if (pdtTable != null)
                {
                    pdtTable.Dispose();
                }
            }
        }
        public DataSet fnGetjdates_vacantseats(int? lTourNo, int? lTourDate)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.jdates_vacantseats, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@tourno", lTourNo.HasValue ? (object)lTourNo.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@jdate", lTourDate.HasValue ? (object)lTourDate.Value : DBNull.Value);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void LogAndSendError(string error)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.LogError_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Error", SqlDbType.NVarChar).Value = error;

                        cmd.ExecuteNonQuery();
                    }

                    // Send error email
                    string to = ConfigurationManager.AppSettings["errormail"];
                    ClsCommon.sendmail(to, "", "", "tickets1@southerntravels.com",
                        "Error Has Been Caught in Application_Error event", error, "");
                }
                catch (Exception ex)
                {
                }
            }
        }
        public List<GST_GetCityListByStateIdAndSearchedCityTextResult> GST_GetCityListByStateIdAndSearchedCityText(string search, int? StateId)
        {
            List<GST_GetCityListByStateIdAndSearchedCityTextResult> resultList = new List<GST_GetCityListByStateIdAndSearchedCityTextResult>();


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GST_GetCityListByStateIdAndSearchedCityText, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@search", SqlDbType.NVarChar).Value = (object)search ?? DBNull.Value;
                        cmd.Parameters.Add("@StateId", SqlDbType.Int).Value = (object)StateId ?? DBNull.Value;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var city = new GST_GetCityListByStateIdAndSearchedCityTextResult
                                {
                                    CityID = reader["CityID"] != DBNull.Value ? reader["CityID"].ToString() : null,
                                    CityName = reader["CityName"] != DBNull.Value ? reader["CityName"].ToString() : string.Empty
                                };

                                resultList.Add(city);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return resultList;
        }
      

        public DataListResponse<GetCountryWiseStateName_SPResult> fnGetCountryWiseStateName(int iCountryID)
        {
            var dataListResponse = new DataListResponse<GetCountryWiseStateName_SPResult>();
            var resultList = new List<GetCountryWiseStateName_SPResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetCountryWiseStateName_SP, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CountryID", iCountryID);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var state = new GetCountryWiseStateName_SPResult
                            {
                                StateID = reader.GetInt32(reader.GetOrdinal("StateID")),
                                CountryID = reader.GetInt32(reader.GetOrdinal("CountryID")),
                                RegionID = reader.GetInt32(reader.GetOrdinal("RegionID")),
                                StateName = reader.GetString(reader.GetOrdinal("StateName")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                IsOffice = reader.GetBoolean(reader.GetOrdinal("IsOffice")),
                                CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn")),
                                CreatedBy = reader.GetInt32(reader.GetOrdinal("CreatedBy")),
                                LastUpdatedOn = reader.IsDBNull(reader.GetOrdinal("LastUpdatedOn"))
                                    ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LastUpdatedOn")),
                                LastUpdatedBy = reader.IsDBNull(reader.GetOrdinal("LastUpdatedBy"))
                                    ? (int?)null : reader.GetInt32(reader.GetOrdinal("LastUpdatedBy"))
                            };

                            resultList.Add(state);
                        }
                    }
                }

                dataListResponse.ResultList = resultList;
                if (resultList != null && resultList.Count > 0)
                {
                    dataListResponse.Status = fnGetRequestStatus(true, pbException.SUCCESS);
                }
                else
                {
                    dataListResponse.Status = fnGetRequestStatus(true, pbException.ERR_DATANOT_FOUND);
                }
            }
            catch (Exception)
            {
                dataListResponse.Status = fnGetRequestStatus(false, pbException.ERR_CATCH_BLOCK);
            }

            return dataListResponse;
        }
        public static RequestStatus fnGetRequestStatus(bool pStatus, pbException pException)
        {
            RequestStatus result = default(RequestStatus);
            result.Status = pStatus;
            result.ErrNo = Convert.ToInt32(pException);
            result.ErrDesc = fnGetEnumDescription(pException);
            return result;
        }

        internal static string fnGetEnumDescription(Enum pValue)
        {
            FieldInfo field = pValue.GetType().GetField(pValue.ToString());
            DescriptionAttribute[] array = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
            return (array.Length > 0) ? array[0].Description : pValue.ToString();
        }

        public int fnSaveAgentLogInInfo(int? pAgentID, string pIPAddress)
        {
            int status = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.SaveAgentLogInInfo_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parameters
                        cmd.Parameters.Add("@AgentID", SqlDbType.Int).Value = (object)pAgentID ?? DBNull.Value;
                        cmd.Parameters.Add("@IpAddress", SqlDbType.VarChar, 50).Value = pIPAddress;

                        // Open and execute
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        // If needed, you can return result here
                        status = 1; // success
                    }
                }
                catch (Exception ex)
                {
                    status = -1; // failure
                                 // Optionally log the error
                }
            }

            return status;
        }
        static string _Password = "SouthernTravels";
        static byte[] _Salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        /// <summary>
        /// Decrypt Cipher Text using Symmetric Algorithm. 
        /// </summary>
        /// <returns></returns>
        public static string Decrypt(string decryptedValue)
        {
            try
            {

                // VSR: UnEscape String (URL Decode) whenever received decrypted data from URL
                //decryptedValue = System.Uri.UnescapeDataString(cipherText);

                byte[] cipherBytes = Convert.FromBase64String(decryptedValue);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(_Password, _Salt);
                byte[] decryptedData = Decryption(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        ///  Decrypt a string using Symmetric Algorithm 
        /// </summary>
        /// <param name="cipherData">The original string</param>
        /// <param name="Key">Set the value of secret key for Symmetric Algorithm </param>
        /// <param name="IV">set initialization  vector for Symmetric Algorithm</param>
        /// <returns>Decrypted String </returns>
        private static byte[] Decryption(byte[] cipherData, byte[] Key, byte[] IV)
        {

            try
            {
                MemoryStream ms = new MemoryStream();
                Rijndael alg = Rijndael.Create();
                alg.Key = Key;
                alg.IV = IV;
                CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();
                byte[] decryptedData = ms.ToArray();
                return decryptedData;
            }
            catch
            {
                return null;
            }

        }
        public static DataTable Agent_ForgotPassword(string pAgentEmail, string pAgentResetPassword)
        {
            DataTable dtAgentForgotPassword = null;
            string connString = DataLib.getConnectionString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.Agent_ForgotPassword, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.Add(new SqlParameter("@I_Emailid", SqlDbType.VarChar, 150) { Value = pAgentEmail });
                    cmd.Parameters.Add(new SqlParameter("@I_Password", SqlDbType.VarChar, 50) { Value = pAgentResetPassword });

                    conn.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {   
                        dtAgentForgotPassword = new DataTable();
                        adapter.Fill(dtAgentForgotPassword);
                    }
                }

                // Return a copy if needed
                return dtAgentForgotPassword != null ? dtAgentForgotPassword.Copy() : null;
            }
            catch (Exception ex)
            {
                // Optionally log the exception here
                return null;
            }
            finally
            {
                if (dtAgentForgotPassword != null)
                {
                    dtAgentForgotPassword.Dispose();
                    dtAgentForgotPassword = null;
                }
            }
        }
        public DataTable ValidateAgent(string pUserID)
        {
            DataTable dtValidateAgent = new DataTable();
            string connString = DataLib.getConnectionString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.ValidateAgent_sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input parameter
                    cmd.Parameters.Add(new SqlParameter("@I_UserID", SqlDbType.VarChar, 20)
                    {
                        Value = pUserID
                    });

                    // Output parameter
                    SqlParameter returnValueParam = new SqlParameter("@O_ReturnValue", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(returnValueParam);

                    // Execute
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtValidateAgent);
                    }

                    // You can optionally capture and use the output parameter value:
                    int status = returnValueParam.Value != DBNull.Value ? (int)returnValueParam.Value : 0;

                    if (dtValidateAgent.Rows.Count > 0)
                        return dtValidateAgent.Copy();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                // Optionally log ex
                return null;
            }
            finally
            {
                if (dtValidateAgent != null)
                {
                    dtValidateAgent.Dispose();
                    dtValidateAgent = null;
                }
            }
        }
        public static DataTable CheckUpdateCustomerEmailMobile(int pCustID, string pEmailorMobile, char pType)
        {
            DataTable ldtCustomer = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.Check_UpdateCustomerEmailMobile, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@rowid", pCustID);
                        cmd.Parameters.AddWithValue("@type", pType);

                        // Email or mobile based on type
                        if (pType == 'E')
                        {
                            cmd.Parameters.AddWithValue("@email", pEmailorMobile);
                            cmd.Parameters.AddWithValue("@mobile", "");
                        }
                        else if (pType == 'M')
                        {
                            cmd.Parameters.AddWithValue("@email", "");
                            cmd.Parameters.AddWithValue("@mobile", pEmailorMobile);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@email", "");
                            cmd.Parameters.AddWithValue("@mobile", "");
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ldtCustomer);
                        }

                        return ldtCustomer.Copy();
                    }
                }
                catch (Exception ex)
                {
                    // Optional: Log the exception
                    return null;
                }
                finally
                {
                    if (ldtCustomer != null)
                    {
                        ldtCustomer.Dispose();
                    }
                }
            }
        }


        public int fnInsertPaymentDetail(
string pOrderID, string pItemCode, char pPaidStatus, decimal pAmount, string pCurrencyCode,
string pIPAdd, string pBankName, string pEMIMonth, string pSectionName,
bool lIsHDFC, bool lIsPayU, string lPayMode)
        {
            int returnValue = 0;

            string connStr = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.InsertPaymentDetail_Sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                cmd.Parameters.AddWithValue("@OrderId", pOrderID);
                cmd.Parameters.AddWithValue("@ItemCode", pItemCode);
                cmd.Parameters.AddWithValue("@Amount", pAmount);
                cmd.Parameters.AddWithValue("@IsPaid", pPaidStatus);
                cmd.Parameters.AddWithValue("@Currency", pCurrencyCode);
                cmd.Parameters.AddWithValue("@IP", pIPAdd ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EMIMonth", pEMIMonth ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@BankName", pBankName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SectionName", pSectionName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsHDFC", lIsHDFC);
                cmd.Parameters.AddWithValue("@IsPayU", lIsPayU);
                cmd.Parameters.AddWithValue("@PayMode", lPayMode ?? (object)DBNull.Value);

                // Output parameter
                SqlParameter outputParam = new SqlParameter("@TourRowId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(outputParam.Value);
                }
                catch (Exception)
                {
                    returnValue = 0;
                }
            }

            return returnValue;
        }



        public static int Add_Fixed_PickupPlace(int pTourID)
        {
            clsAdo clsObj = new clsAdo();
            DataSet dsDefault = null;

            try
            {
                dsDefault = clsObj.fnFixed_Default_PickupAddress(pTourID);

                if (dsDefault != null && dsDefault.Tables.Count > 0 && dsDefault.Tables[0].Rows.Count > 0)
                {
                    string arrtime = "06:00:00 AM";
                    string dept = Convert.ToString(dsDefault.Tables[0].Rows[0]["departuretime"]);

                    if (!string.IsNullOrEmpty(dept) && dept.Length > 2)
                    {
                        DateTime dt = DateTime.Parse(dept).AddMinutes(-30);
                        arrtime = dt.ToString("hh:mm:ss tt"); 
                    }

                    int Val = clsObj.fnInsertUpdatedispup(
                        Convert.ToInt32(dsDefault.Tables[0].Rows[0]["Rowid"]),
                        pTourID,
                        Convert.ToString(dsDefault.Tables[0].Rows[0]["branchname"]).Replace("'", "''"),
                        arrtime,
                        arrtime,
                        'Y',
                        Convert.ToString(dsDefault.Tables[0].Rows[0]["branchcode"]),
                        Convert.ToString(dsDefault.Tables[0].Rows[0]["address"]).Replace("'", "''")
                    );

                    return Val;
                }
                else
                {
                    return 2; // no rows found
                }
            }
            finally
            {
                if (dsDefault != null)
                {
                    dsDefault.Dispose();
                    dsDefault = null;
                }
            }
        }

        public static int NoofAvailableSeats(int pBusSeatCapacity, int pBusSerialNo)
        {
            int availableSeats = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.Get_VacantSeats, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@seaterCapacity", SqlDbType.Int) { Value = pBusSeatCapacity });
                    cmd.Parameters.Add(new SqlParameter("@SerialNo", SqlDbType.Int) { Value = pBusSerialNo });

                    // Output parameter
                    SqlParameter outputParam = new SqlParameter("@availableseats", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    if (outputParam.Value != DBNull.Value)
                    {
                        availableSeats = Convert.ToInt32(outputParam.Value);
                    }
                }
            }
            catch (Exception)
            {
                // Optionally log error here
                availableSeats = 0;  // Same behavior as original on error
            }
            return availableSeats;
        }
        public static bool Block_Seats(string pSeats, int pTourSerial, string pBlockedString)
        {
            int val = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.BlockUnBlockSeats_sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@TSerial", SqlDbType.VarChar, 15) { Value = pTourSerial.ToString() });
                    cmd.Parameters.Add(new SqlParameter("@Seat", SqlDbType.VarChar, -1) { Value = pSeats }); // VarChar(MAX) = -1
                    cmd.Parameters.Add(new SqlParameter("@BlockedString", SqlDbType.VarChar, 150) { Value = pBlockedString });
                    cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit) { Value = true });

                    // Output parameter for return value
                    SqlParameter outputParam = new SqlParameter("@ReturnValue", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    if (outputParam.Value != DBNull.Value)
                    {
                        val = Convert.ToInt32(outputParam.Value);
                    }
                }
            }
            catch (Exception)
            {
                val = -1;
            }

            return val > 0;
        }
        public static void UnBlock_Seats(string pSeats, int pTourSerial)
        {
            try
            {
                int status = new clsAdo().fnBlockUnBlockSeats_sp(pTourSerial.ToString(), pSeats, "NULL", false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int Insert_OnlineToursBooking(
    string pOrderID, int pTourID, DateTime pDOJ, DateTime pDOB, char pBusEnvType,
    int pAdults, int pChilds, int pTwin, int pTriple, int pChildNoBed, int pSingle, string pTourName, decimal pAmount,
    decimal pTaxPercent, decimal pTax, decimal pTotalAmount, string pSeatNos, string pBusSerial, string pTourSerial,
    int pPickupPointID, decimal pAdultFare, decimal pChildFare, decimal pTwinFare, decimal pTripleFare, decimal pChildNoBedFare,
    decimal pSingleFare, decimal pCCFee, decimal pCCAmount, int pDormitory, decimal pDormitoryFare, char pIsLtc, string pOnlineDiscont, decimal pMinPay,
    int NoAWFood, int NoCWFood, decimal AdWFoodfare, decimal CWFoodfare, string Utm_Source, string Utm_Medium, string Utm_Term, string Utm_Content, string Utm_Campaign,
    decimal ServiceChargesTotal, decimal ServiceChargesTax, decimal ServiceChargesTaxVal, decimal AdultServiceCharges, decimal ChildServiceCharges)
        {
            int result = -1;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.insertbook_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters - match SQL types carefully
                cmd.Parameters.Add("@orderid", SqlDbType.NVarChar, 100).Value = pOrderID ?? (object)DBNull.Value;
                cmd.Parameters.Add("@tourno", SqlDbType.Int).Value = pTourID;
                cmd.Parameters.Add("@doj", SqlDbType.SmallDateTime).Value = pDOJ;
                cmd.Parameters.Add("@dob", SqlDbType.SmallDateTime).Value = pDOB;
                cmd.Parameters.Add("@env", SqlDbType.Char, 1).Value = pBusEnvType;
                cmd.Parameters.Add("@adults", SqlDbType.SmallInt).Value = pAdults;
                cmd.Parameters.Add("@child", SqlDbType.SmallInt).Value = pChilds;
                cmd.Parameters.Add("@adultstwin", SqlDbType.SmallInt).Value = pTwin;
                cmd.Parameters.Add("@adultstriple", SqlDbType.SmallInt).Value = pTriple;
                cmd.Parameters.Add("@childbed", SqlDbType.SmallInt).Value = pChildNoBed;
                cmd.Parameters.Add("@singleadults", SqlDbType.SmallInt).Value = pSingle;
                cmd.Parameters.Add("@TourName", SqlDbType.VarChar, 50).Value = pTourName ?? (object)DBNull.Value;
                cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = pAmount;
                cmd.Parameters.Add("@tax", SqlDbType.Decimal).Value = pTaxPercent;
                cmd.Parameters.Add("@taxamt", SqlDbType.Decimal).Value = pTax;
                cmd.Parameters.Add("@tot", SqlDbType.Decimal).Value = pTotalAmount;
                cmd.Parameters.Add("@tempstr", SqlDbType.VarChar, 500).Value = pSeatNos ?? (object)DBNull.Value;
                cmd.Parameters.Add("@BusserialNo", SqlDbType.VarChar, 100).Value = pBusSerial ?? (object)DBNull.Value;
                cmd.Parameters.Add("@TourSerial", SqlDbType.VarChar, 100).Value = pTourSerial ?? (object)DBNull.Value;
                cmd.Parameters.Add("@pkpID", SqlDbType.Int).Value = pPickupPointID;
                cmd.Parameters.Add("@afare", SqlDbType.Decimal).Value = pAdultFare;
                cmd.Parameters.Add("@cfare", SqlDbType.Decimal).Value = pChildFare;
                cmd.Parameters.Add("@a2fare", SqlDbType.Decimal).Value = pTwinFare;
                cmd.Parameters.Add("@a3fare", SqlDbType.Decimal).Value = pTripleFare;
                cmd.Parameters.Add("@cbfare", SqlDbType.Decimal).Value = pChildNoBedFare;
                cmd.Parameters.Add("@safare", SqlDbType.Decimal).Value = pSingleFare;
                cmd.Parameters.Add("@ccfee", SqlDbType.Decimal).Value = pCCFee;
                cmd.Parameters.Add("@ccamt", SqlDbType.Decimal).Value = pCCAmount;
                cmd.Parameters.Add("@dormitory", SqlDbType.SmallInt).Value = pDormitory;
                cmd.Parameters.Add("@dormitoryfare", SqlDbType.Decimal).Value = pDormitoryFare;
                cmd.Parameters.Add("@IsLtc", SqlDbType.Char, 1).Value = pIsLtc;
                cmd.Parameters.Add("@OnLineDis", SqlDbType.VarChar, 5).Value = pOnlineDiscont ?? (object)DBNull.Value;
                cmd.Parameters.Add("@MinimumPay", SqlDbType.Decimal).Value = pMinPay;
                cmd.Parameters.Add("@noAdultWithFood", SqlDbType.Int).Value = NoAWFood;
                cmd.Parameters.Add("@noChildWithFood", SqlDbType.Int).Value = NoCWFood;
                cmd.Parameters.Add("@AdultWithFoodFare", SqlDbType.Decimal).Value = AdWFoodfare;
                cmd.Parameters.Add("@ChildWithFoodFare", SqlDbType.Decimal).Value = CWFoodfare;
                cmd.Parameters.Add("@Utm_Source", SqlDbType.VarChar, 250).Value = Utm_Source ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Utm_Medium", SqlDbType.VarChar, 250).Value = Utm_Medium ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Utm_Term", SqlDbType.VarChar, 250).Value = Utm_Term ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Utm_Content", SqlDbType.VarChar, 250).Value = Utm_Content ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Utm_Campaign", SqlDbType.VarChar, 250).Value = Utm_Campaign ?? (object)DBNull.Value;
                cmd.Parameters.Add("@ServiceChargesTotal", SqlDbType.Decimal).Value = ServiceChargesTotal;
                cmd.Parameters.Add("@ServiceChargesTax", SqlDbType.Decimal).Value = ServiceChargesTax;
                cmd.Parameters.Add("@ServiceChargesTaxVal", SqlDbType.Decimal).Value = ServiceChargesTaxVal;
                cmd.Parameters.Add("@AdultServiceCharges", SqlDbType.Decimal).Value = AdultServiceCharges;
                cmd.Parameters.Add("@ChildServiceCharges", SqlDbType.Decimal).Value = ChildServiceCharges;

                // Open connection and execute
                conn.Open();

                // ExecuteNonQuery returns number of rows affected, but since your SP returns int, better use ExecuteScalar or Return Value param
                // Assuming stored proc returns int as return value:
                // Add a parameter for the return value
                SqlParameter returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                result = (int)returnParameter.Value;
            }

            return result;
        }
        public static int Update_OnlineToursBooking(
    DateTime pJDate, char pBusEnvType, int pAdults, int pChilds, int pTwin,
    int pTriple, int pChildNoBed, int pSingle, decimal pAmount, decimal pTax, decimal pTaxAmount, decimal pTotalAmt,
    string pSeatNos, string pBusSerial, int pTourSerial, int pPickupID, decimal pAdultFare, decimal pChildFare,
    decimal pTwinFare, decimal pTripleFare, decimal pChildNoBedFare, decimal pSingleFare, decimal pCCFee, decimal pCCAmount,
    int pRowID, int pDormitory, decimal pDormitoryFare, int NoAWFood, int NoCWFood, decimal AdWFoodfare, decimal CWFoodfarein,
    int lTourID, string lToueName,
    decimal ServiceChargesTotal, decimal ServiceChargesTax, decimal ServiceChargesTaxVal, decimal AdultServiceCharges, decimal ChildServiceCharges,
    bool isLtc = false)
        {
            int result = -1;
            string connectionString = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.Updatebook_sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@jdate", SqlDbType.SmallDateTime).Value = pJDate;
                    cmd.Parameters.Add("@env", SqlDbType.Char, 1).Value = pBusEnvType;
                    cmd.Parameters.Add("@adults", SqlDbType.SmallInt).Value = Convert.ToInt16(pAdults);
                    cmd.Parameters.Add("@child", SqlDbType.SmallInt).Value = Convert.ToInt16(pChilds);
                    cmd.Parameters.Add("@adultstwin", SqlDbType.SmallInt).Value = Convert.ToInt16(pTwin);
                    cmd.Parameters.Add("@adultstriple", SqlDbType.SmallInt).Value = Convert.ToInt16(pTriple);
                    cmd.Parameters.Add("@childbed", SqlDbType.SmallInt).Value = Convert.ToInt16(pChildNoBed);
                    cmd.Parameters.Add("@singleadult", SqlDbType.SmallInt).Value = Convert.ToInt16(pSingle);
                    cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = decimal.Round(pAmount);
                    cmd.Parameters.Add("@tax", SqlDbType.Decimal).Value = pTax;
                    cmd.Parameters.Add("@taxamt", SqlDbType.Decimal).Value = decimal.Round(pTaxAmount);
                    cmd.Parameters.Add("@tot", SqlDbType.Decimal).Value = decimal.Round(pTotalAmt);
                    cmd.Parameters.Add("@tempstr", SqlDbType.VarChar, 500).Value = pSeatNos ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@BusserialNo", SqlDbType.VarChar, 100).Value = pBusSerial ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@TourSerial", SqlDbType.VarChar, 100).Value = pTourSerial.ToString();
                    cmd.Parameters.Add("@pkpID", SqlDbType.Int).Value = pPickupID;
                    cmd.Parameters.Add("@afare", SqlDbType.Decimal).Value = pAdultFare;
                    cmd.Parameters.Add("@cfare", SqlDbType.Decimal).Value = pChildFare;
                    cmd.Parameters.Add("@a2fare", SqlDbType.Decimal).Value = pTwinFare;
                    cmd.Parameters.Add("@a3fare", SqlDbType.Decimal).Value = pTripleFare;
                    cmd.Parameters.Add("@cbfare", SqlDbType.Decimal).Value = pChildNoBedFare;
                    cmd.Parameters.Add("@safare", SqlDbType.Decimal).Value = pSingleFare;
                    cmd.Parameters.Add("@ccfee", SqlDbType.Decimal).Value = pCCFee;
                    cmd.Parameters.Add("@ccamt", SqlDbType.Decimal).Value = decimal.Round(pCCAmount);
                    cmd.Parameters.Add("@Rowid", SqlDbType.Int).Value = pRowID;
                    cmd.Parameters.Add("@dormitory", SqlDbType.SmallInt).Value = Convert.ToInt16(pDormitory);
                    cmd.Parameters.Add("@dormitoryfare", SqlDbType.Decimal).Value = pDormitoryFare;
                    cmd.Parameters.Add("@IsLtc", SqlDbType.Char, 1).Value = isLtc ? '1' : '0';
                    cmd.Parameters.Add("@noAdultWithFood", SqlDbType.Int).Value = NoAWFood;
                    cmd.Parameters.Add("@noChildWithFood", SqlDbType.Int).Value = NoCWFood;
                    cmd.Parameters.Add("@AdultWithFoodFare", SqlDbType.Decimal).Value = AdWFoodfare;
                    cmd.Parameters.Add("@ChildWithFoodFare", SqlDbType.Decimal).Value = CWFoodfarein;
                    cmd.Parameters.Add("@TourID", SqlDbType.VarChar, 100).Value = lTourID.ToString();
                    cmd.Parameters.Add("@TourName", SqlDbType.VarChar, 100).Value = lToueName ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@ServiceChargesTotal", SqlDbType.Decimal).Value = ServiceChargesTotal;
                    cmd.Parameters.Add("@ServiceChargesTax", SqlDbType.Decimal).Value = ServiceChargesTax;
                    cmd.Parameters.Add("@ServiceChargesTaxVal", SqlDbType.Decimal).Value = ServiceChargesTaxVal;
                    cmd.Parameters.Add("@AdultServiceCharges", SqlDbType.Decimal).Value = AdultServiceCharges;
                    cmd.Parameters.Add("@ChildServiceCharges", SqlDbType.Decimal).Value = ChildServiceCharges;

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        result = -1;
                    }
                }
            }

            return result;
        }

    }
}