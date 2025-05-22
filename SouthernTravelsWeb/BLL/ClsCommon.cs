using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using ASPEMAILLib;
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
    /// <summary>
    /// Summary description for ClsCommon
    /// </summary>
    public class ClsCommon
    {
      
        #region Public Member Variable(s)
        /// <summary>
        /// Web config's connection string name.
        /// </summary>
        public static string pbConnString = "southernconn";
        private static string connectionString;

        #endregion
        #region Propertie(s)
        /// <summary>
        /// Get Connection String
        /// </summary>
       
        public ClsCommon()
        {
            connectionString = ConfigurationManager.AppSettings["southernconn"];
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
                        sb.Append(lTourType + "<img src=\"/Assets/images/custom-arrow.png\"></span><img width='371px' height='385px' src=/Assets/images/EntityImage/" + ResProduct.Tables[0].Rows[lctr]["MainImg"].ToString() + "></div>");



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
                    cmd.Parameters.AddWithValue("@TourId", lTourID);
                    cmd.Parameters.AddWithValue("@TourType", lTourType);

                    SqlParameter statusParam = new SqlParameter("@Status", SqlDbType.Int);
                    statusParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(statusParam);

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
                    cmd.Parameters.AddWithValue("@pOfferID", (object)pOfferID ?? DBNull.Value);

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



    }
}