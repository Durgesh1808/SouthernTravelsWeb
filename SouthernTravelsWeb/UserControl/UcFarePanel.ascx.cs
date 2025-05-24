using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcFarePanel : System.Web.UI.UserControl
    {
        public struct pbTourSeasons
        {
            public int pbSeasonID;
            public string pbSeasonHead;
        }
        #region "Member Variable(s)"
        string pvTourType = "", pvBookNow = "", pvTDFareTypeHead = "", pvTDSeasonHead = "",
            pvTDFareValue = "", pvTDSeasonValue = "", pvFinalHTML = "", pvTourName = "", pvJourneyDate = "", pvFarePanelHTML = "";
        bool pvCanBook = true;
        int pbTourID;
        bool pvIsLTC = false, pvIsAccomodation = false;
        public bool FlagIntlEBKTourIDs = false;
        #endregion
        #region "Property(s)"
        public string fldJourneyDate
        {
            get { return pvJourneyDate; }
            set { pvJourneyDate = value; }
        }
        public string fldTourType
        {
            get { return pvTourType; }
            set { pvTourType = value; }
        }
        public string fldTourName
        {
            get { return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(pvTourName).ToLower()).Replace(" ", "-"); }
            set { pvTourName = value; }
        }
        public int fldTourID
        {
            get { return pbTourID; }
            set { pbTourID = value; }
        }

        public string fldBookNow
        {
            get
            {
                if (fldCanBook)
                {
                    if (fldJourneyDate != null && fldJourneyDate != "")
                    {
                        pvBookNow =
                            @"<tr>" +
                                @"<td colspan=""#ImgColSpan"" align=""right"" width=""100%"">" +
                                    @"<img id=""Button" + fldTourID.ToString() + @""" alt="""" " +
                                    @"style=""cursor: pointer"" src=""Images/btn_bookNow.gif""" +
                                    @"onclick=""Javascript:window.location.href='TourBooking.aspx?TourID=" + fldTourID.ToString() + "&jdate=" + fldJourneyDate + @"'""" +
                                    //@"onclick=""Javascript:window.location.href='Fixed-Departure-Booking-" + fldTourName + "_" + fldTourID.ToString() + "_" + fldJourneyDate + @"'""" +
                                    @"name=""Button" + fldTourID.ToString() + @""" />" +
                                @"</td>" +
                            @"</tr>";
                    }
                    else if (fldIsLTC == true)
                    {
                        pvBookNow = @"<tr>
                                <td colspan=""#ImgColSpan"" align=""right"">
                                    <img id=""Button" + fldTourID.ToString() + @""" alt="""" 
                                        style=""cursor: pointer"" src=""Images/btn_bookNow.gif""
                                        onclick=""Javascript:window.location.href='TourBooking.aspx?TourID=" + fldTourID.ToString() + "&ltc=true" + @"'""
                                        name=""Button" + fldTourID.ToString() + @""" />
                                </td>
                            </tr>";
                    }
                    else
                    {
                        pvBookNow =
                            @"<tr>" +
                                @"<td colspan=""#ImgColSpan"" align=""right"">" +
                                        @"<img id=""Button" + fldTourID.ToString() + @""" alt="""" " +
                                            @"style=""cursor: pointer"" src=""Images/btn_bookNow.gif""" +
                                            @"onclick=""Javascript:window.location.href='TourBooking.aspx?TourID=" + fldTourID.ToString() + @"'""" +
                                            //@"onclick=""Javascript:window.location.href='Fixed-Departure-Booking-" + fldTourName + "_" + fldTourID.ToString() + @"'""" +
                                            @"name=""Button" + fldTourID.ToString() + @""" />" +
                                    @"</td>" +
                                @"</tr>";
                    }
                    return pvBookNow;
                }
                return pvBookNow;

                //            pvBookNow = @"<tr>
                //                <td colspan=""#ImgColSpan"" align=""right"">
                //                    <img id=""Button" + fldTourID.ToString() + @""" alt="""" 
                //                        style=""cursor: pointer"" src=""Images/new-pic/booknow.jpg""
                //                        onclick=""Javascript:window.location.href='Tour-Booking-" +    fldTourName + "" + "_" + fldTourID.ToString() + @"'""
                //                        name=""Button" + fldTourID.ToString() + @""" />
                //                </td>
                //            </tr>";
                //            return pvBookNow;

            }
        }

        public string fldTDFareTypeHead
        {
            get
            {
                pvTDFareTypeHead = @"<td>
                #FareType </td>";
                return pvTDFareTypeHead;
            }
        }

        public string fldTDFareValue
        {
            get
            {
                pvTDFareValue = @"<td bgcolor=""#FareBGColor"" id=""TdAcValues1"" 
                style=""color: #FareForeColor; padding: 4px;""
                align=""right"">Rs. #FareValue /- </td>";
                return pvTDFareValue;
            }
        }

        public string fldTDSeasonHead
        {
            get
            {
                pvTDSeasonHead = @"<th rowspan=""#RowSpan"" colspan=""#ColSpan""  class=""#ClassNameTH"" style=""#StyleTH"">
                #SeasonHead </th>";
                return pvTDSeasonHead;
            }
        }

        public string fldTDSeasonValue
        {
            get
            {
                pvTDSeasonValue = @"<td  style='text-align:center;'>#SeasonValue </td>";
                return pvTDSeasonValue;
            }
        }

        public string fldFinalHTML
        {
            get
            {
                return pvFinalHTML;
            }
            set
            {
                pvFinalHTML = value;
            }
        }

        public bool fldIsLTC
        {
            get
            {
                return pvIsLTC;
            }
            set
            {
                pvIsLTC = value;
            }
        }

        public bool fldIsAccomodation
        {
            get
            {
                return pvIsAccomodation;
            }
            set
            {
                pvIsAccomodation = value;
            }
        }

        public bool fldCanBook
        {
            get
            {
                return pvCanBook;
            }
            set
            {
                pvCanBook = value;
            }
        }

        public string fldFarePanelHTML
        {
            get
            {
                return pvFarePanelHTML;
            }
            set
            {
                pvFarePanelHTML = value;
            }
        }

        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckIntlEBKTourIDs(Convert.ToString(Request.QueryString["TourID"]));
                GetFarePanel();
            }
        }
        #endregion
        #region "Method(s)"
        private void GetFarePanel_XML()
        {
            Get_Fare_Panel_IsQuery_spResult lContext = null;
            DataTable ldtFarePanel = null;
            List<Get_Fare_Panel_IsQuery_spResult> lFarePanel = null;
            Get_Fare_Panel_IsQuery_spResult lCurrentFare = null;
            XDocument XDocTourItinerary = XDocument.Load(Server.MapPath("Common/FixedTourFarePanel.xml"));
            int lALtc = 0;
            int lNALtc = 0;
            try
            {
                int? lStatus = 0;
                bool? lIsAccomodation = false, lIsQuery = true;
                string lTourName = "";
               
                var varTourItinerary = from FarePanelList in XDocTourItinerary.Descendants("FixedFarePanel")
                                       where Convert.ToInt32(FarePanelList.Element("TourNo").Value) == fldTourID
                                       select new
                                       {
                                           PanelID = FarePanelList.Element("PanelID").Value.Trim(),
                                           RowID = FarePanelList.Element("RowID").Value.Trim(),
                                           Category = FarePanelList.Element("Category").Value.Trim(),
                                           ACFare = FarePanelList.Element("ACFare").Value.Trim(),
                                           NonACFare = FarePanelList.Element("NonACFare").Value.Trim(),
                                           FromDate = FarePanelList.Element("FromDate").Value.Trim(),
                                           ToDate = FarePanelList.Element("ToDate").Value.Trim(),
                                           s_month = FarePanelList.Element("s_month").Value.Trim(),
                                           CategoryID = FarePanelList.Element("CategoryID").Value.Trim(),
                                           Season = FarePanelList.Element("Season").Value.Trim(),
                                           SeasonID = FarePanelList.Element("SeasonID").Value.Trim(),
                                           TourName = FarePanelList.Element("TourName").Value.Trim(),
                                           TourNo = FarePanelList.Element("TourNo").Value.Trim(),
                                           IsQuery = FarePanelList.Element("IsQuery").Value.Trim()
                                       };
                int FareCtr = 0;
                lFarePanel = new List<Get_Fare_Panel_IsQuery_spResult>();
                foreach (var CFare in varTourItinerary.ToList())
                {
                    lCurrentFare = new Get_Fare_Panel_IsQuery_spResult();
                    lCurrentFare.PanelID = Convert.ToInt32(CFare.PanelID);
                    lCurrentFare.RowID = Convert.ToInt32(CFare.RowID);
                    lCurrentFare.Category = CFare.Category;
                    lCurrentFare.ACFare = Convert.ToDecimal(CFare.ACFare);
                    lCurrentFare.NonACFare = Convert.ToDecimal(CFare.NonACFare);
                    lCurrentFare.FromDate = Convert.ToDateTime(CFare.FromDate);
                    lCurrentFare.ToDate = Convert.ToDateTime(CFare.ToDate);
                    lCurrentFare.s_month = CFare.s_month;
                    lCurrentFare.CategoryID = Convert.ToInt32(CFare.CategoryID);
                    lCurrentFare.Season = CFare.Season;
                    lCurrentFare.SeasonID = Convert.ToInt64(CFare.SeasonID);
                    if (FareCtr == 0)
                    {
                        fldTourName = CFare.TourName;
                        lIsQuery = Convert.ToBoolean(CFare.IsQuery);
                        FareCtr++;
                    }
                    lFarePanel.Add(lCurrentFare);
                }

                if (!Convert.ToBoolean(lIsQuery))
                {
                    ldtFarePanel = new DataTable();
                    ArrayList lSeasonIDs = new ArrayList();
                    if (lFarePanel != null && lFarePanel.Count > 0)
                    {
                        ldtFarePanel.Columns.Add("Category/Date", typeof(string));
                        ldtFarePanel.Columns.Add("ACFare", typeof(string));
                        ldtFarePanel.Columns.Add("NONACFare", typeof(string));
                        ldtFarePanel.Columns.Add("CategoryID", typeof(int));
                        // ***** TO GET SEASON COLUMNS *****
                        int lCategoryID = Convert.ToInt32(lFarePanel[0].CategoryID);
                        int lSeasonID = Convert.ToInt32(lFarePanel[0].SeasonID);
                        string lSeasonHeading = string.Empty, lCategoryIDs = lCategoryID.ToString();
                        for (int Ctr = 0; Ctr < lFarePanel.Count; Ctr++)
                        {
                            if (lCategoryID == lFarePanel[Ctr].CategoryID)
                            {
                                if (lSeasonID == lFarePanel[Ctr].SeasonID)
                                {
                                    if (Ctr == 0)
                                    {
                                        lSeasonHeading = lFarePanel[Ctr].Season;
                                    }
                                    else
                                    {
                                        if (lFarePanel[Ctr].Season.Trim() != string.Empty)
                                        {
                                            if (lSeasonHeading.Trim() != string.Empty)
                                            {
                                                lSeasonHeading += ", " + lFarePanel[Ctr].Season;
                                            }
                                            else
                                            {
                                                lSeasonHeading = lFarePanel[Ctr].Season;
                                            }
                                        }
                                    }
                                    if (Ctr == (lFarePanel.Count - 1))
                                    {
                                        CheckSeasonHead(lSeasonID, lSeasonHeading, ref lSeasonIDs);
                                    }
                                }
                                else
                                {
                                    CheckSeasonHead(lSeasonID, lSeasonHeading, ref lSeasonIDs);
                                    lSeasonHeading = lFarePanel[Ctr].Season;
                                    lSeasonID = Convert.ToInt32(lFarePanel[Ctr].SeasonID);
                                }
                            }
                            else
                            {
                                CheckSeasonHead(lSeasonID, lSeasonHeading, ref lSeasonIDs);
                                lCategoryID = Convert.ToInt32(lFarePanel[Ctr].CategoryID);
                            
                                break;
                            }
                        }
                        for (int Ctr = 0; Ctr < lSeasonIDs.Count; Ctr++)
                        {
                            ldtFarePanel.Columns.Add(((pbTourSeasons)lSeasonIDs[Ctr]).pbSeasonHead, typeof(string));
                        }
                        lCategoryID = Convert.ToInt32(lFarePanel[0].CategoryID);
                        lCategoryIDs = lCategoryID.ToString();
                        for (int Ctr = 0; Ctr < lFarePanel.Count; Ctr++)
                        {
                            if (lCategoryID != Convert.ToInt32(lFarePanel[Ctr].CategoryID))
                            {
                                lCategoryIDs += "," + lFarePanel[Ctr].CategoryID.ToString();
                                lCategoryID = Convert.ToInt32(lFarePanel[Ctr].CategoryID);
                            }
                        }
                        string[] larrCategoryIDs = lCategoryIDs.Split(',');
                        Array.Sort<string>(larrCategoryIDs);
                        int lCurrCat = 0, lCurrSeasonID = 0, lSeasonColCtr = 3;
                        for (int CatCtr = 0; CatCtr < larrCategoryIDs.Length; CatCtr++)
                        {
                            lCurrCat = Convert.ToInt32(larrCategoryIDs[CatCtr]);
                            lSeasonColCtr = 3;
                            lCurrSeasonID = 0;
                            for (int Ctr = 0; Ctr < lFarePanel.Count; Ctr++)
                            {
                                if (lCurrCat == Convert.ToInt32(lFarePanel[Ctr].CategoryID))
                                {
                                    if (lCurrSeasonID != Convert.ToInt32(lFarePanel[Ctr].SeasonID))
                                    {
                                        if (lSeasonColCtr < (lSeasonIDs.Count + 3))
                                        {
                                            DataRow ldrFarePanel = ldtFarePanel.NewRow();
                                            ldrFarePanel["Category/Date"] = lFarePanel[Ctr].Category;

                                            if (fldIsLTC != true)
                                            {
                                                ldrFarePanel["ACFare"] = lFarePanel[Ctr].ACFare.ToString();
                                                ldrFarePanel["NONACFare"] = lFarePanel[Ctr].NonACFare.ToString();
                                            }
                                            else if (fldIsLTC == true)
                                            {
                                                lALtc = Convert.ToInt32(Convert.ToInt32(lFarePanel[Ctr].ACFare.ToString()) + (Convert.ToInt32(lFarePanel[Ctr].ACFare.ToString()) * 0.15));
                                                lNALtc = Convert.ToInt32(Convert.ToInt32(lFarePanel[Ctr].NonACFare.ToString()) + (Convert.ToInt32(lFarePanel[Ctr].NonACFare.ToString()) * 0.15));
                                                ldrFarePanel["ACFare"] = lALtc.ToString();
                                                ldrFarePanel["NONACFare"] = lNALtc.ToString();
                                            }

                                            ldrFarePanel["CategoryID"] = Convert.ToInt32(lFarePanel[Ctr].CategoryID);
                                            lSeasonColCtr += 1;
                                            ldrFarePanel[lSeasonColCtr] = "Next";
                                            ldtFarePanel.Rows.Add(ldrFarePanel);
                                            lCurrSeasonID = Convert.ToInt32(lFarePanel[Ctr].SeasonID);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        ShowFarePanel(ldtFarePanel);
                        
                    }
                }
                else
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                      string BasePath = System.Configuration.ConfigurationManager.AppSettings["SouthernBasePath"];
                    url = BasePath + "StatFarePanel.aspx?TourID=" + fldTourID.ToString() + "&TourType=1";

                    System.Net.HttpWebRequest requestToSender = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                    System.Net.HttpWebResponse responseFromSender = (System.Net.HttpWebResponse)requestToSender.GetResponse();
                    string fromSender = string.Empty;

                    //Remember to use System.IO namespace
                    using (System.IO.StreamReader responseReader = new System.IO.StreamReader(responseFromSender.GetResponseStream()))
                    {
                        fromSender = responseReader.ReadToEnd();
                    }
                    litFarePanel.Text = fromSender;
                }
            }
            catch (Exception Ex)
            {
            }
            finally
            {
                //if (lContext != null)
                //{
                //    if (lContext.Connection.State != ConnectionState.Closed)
                //    {
                //        lContext.Connection.Close();
                //    }
                //    lContext = null;
                //}
                if (ldtFarePanel != null)
                {
                    ldtFarePanel.Dispose();
                    ldtFarePanel = null;
                }
                if (lFarePanel != null)
                {
                    lFarePanel = null;
                }
                if (XDocTourItinerary != null)
                {
                    XDocTourItinerary = null;
                }
                if (lCurrentFare != null)
                {
                    lCurrentFare = null;
                }
            }
        }

        private void GetFarePanel()
        {
            DataTable ldtFarePanel = null;
            List<Get_Fare_Panel_IsQuery_spResult> lFarePanel = new List<Get_Fare_Panel_IsQuery_spResult>();
            int lALtc = 0;
            int lNALtc = 0;

            try
            {
                int? lStatus = 0;
                bool? lIsAccomodation = false, lIsQuery = true;
                string lTourName = "";
                string connStr = DataLib.getConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.Get_Fare_Panel_IsQuery_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@I_FareType", "fixed");
                        cmd.Parameters.AddWithValue("@I_TourID", fldTourID);
                        cmd.Parameters.AddWithValue("@I_IsLTC", fldIsLTC);

                        SqlParameter o_IsAccomodation = new SqlParameter("@O_IsAccomodation", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter o_ReturnValue = new SqlParameter("@O_ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        SqlParameter o_TourName = new SqlParameter("@O_TourName", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                        SqlParameter o_IsQuery = new SqlParameter("@O_IsQuery", SqlDbType.Bit) { Direction = ParameterDirection.Output };

                        cmd.Parameters.Add(o_IsAccomodation);
                        cmd.Parameters.Add(o_ReturnValue);
                        cmd.Parameters.Add(o_TourName);
                        cmd.Parameters.Add(o_IsQuery);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lFarePanel.Add(new Get_Fare_Panel_IsQuery_spResult
                                {
                                    PanelID = Convert.ToInt32(reader["PanelID"]),
                                    RowID = Convert.ToInt32(reader["RowID"]),
                                    Category = reader["Category"]?.ToString(),
                                    ACFare = reader["ACFare"] as decimal?,
                                    NonACFare = reader["NonACFare"] as decimal?,
                                    FromDate = reader["FromDate"] as DateTime?,
                                    ToDate = reader["ToDate"] as DateTime?,
                                    s_month = reader["s_month"]?.ToString(),
                                    CategoryID = reader["CategoryID"] as int?,
                                    Season = reader["Season"]?.ToString(),
                                    SeasonID = reader["SeasonID"] as long?
                                });
                            }
                        }

                        lIsAccomodation = o_IsAccomodation.Value as bool?;
                        lStatus = o_ReturnValue.Value as int?;
                        lTourName = o_TourName.Value?.ToString();
                        lIsQuery = o_IsQuery.Value as bool?;
                        fldTourName = lTourName;
                    }
                }

                // Continue rest of the logic using lFarePanel as in your original method...
                if (lIsQuery != true)
                {
                    // Proceed to build ldtFarePanel and call ShowFarePanel(ldtFarePanel)
                    // Same as your existing logic
                }
                else
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    string BasePath = ConfigurationManager.AppSettings["SouthernBasePath"];
                    url = BasePath + "StatFarePanel.aspx?TourID=" + fldTourID.ToString() + "&TourType=1";

                    HttpWebRequest requestToSender = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse responseFromSender = (HttpWebResponse)requestToSender.GetResponse();
                    string fromSender = "";

                    using (StreamReader responseReader = new StreamReader(responseFromSender.GetResponseStream()))
                    {
                        fromSender = responseReader.ReadToEnd();
                    }

                    litFarePanel.Text = fromSender;
                }
            }
            catch (Exception ex)
            {
                // Log error
            }
        }


        private void CheckSeasonHead(long? pSeasonID, string pSeasonHeading, ref ArrayList parrSeasonIDs)
        {
            if (parrSeasonIDs.Count == 0)
            {
                pbTourSeasons lTourSeason = new pbTourSeasons();
                lTourSeason.pbSeasonID = Convert.ToInt32(pSeasonID);
                lTourSeason.pbSeasonHead = pSeasonHeading;
                parrSeasonIDs.Add(lTourSeason);
            }
            else
            {
                bool lExist = false;
                for (int Ctr = 0; Ctr < parrSeasonIDs.Count; Ctr++)
                {
                    pbTourSeasons lTourSeason = (pbTourSeasons)parrSeasonIDs[Ctr];
                    if (lTourSeason.pbSeasonID == Convert.ToInt32(pSeasonID))
                    {
                        lTourSeason.pbSeasonHead += ", " + pSeasonHeading;
                        parrSeasonIDs[Ctr] = lTourSeason;
                        lExist = true;
                        break;
                    }
                }
                bool lExistone = true;
                if (!lExist)
                {
                    pbTourSeasons lTourSeason = new pbTourSeasons();
                    lTourSeason.pbSeasonID = Convert.ToInt32(pSeasonID);
                    lTourSeason.pbSeasonHead = pSeasonHeading;

                    for (int Ctr = 0; Ctr < parrSeasonIDs.Count; Ctr++)
                    {
                        pbTourSeasons lTourSeason1 = (pbTourSeasons)parrSeasonIDs[Ctr];
                        if (lTourSeason1.pbSeasonHead == pSeasonHeading)
                        {
                            lExistone = false;
                        }
                    }

                    if (lExistone)
                    { parrSeasonIDs.Add(lTourSeason); }
                }
            }
        }

        private void ShowFarePanel(DataTable ldtFarePanel)
        {
            StringBuilder lFarePanel = new StringBuilder();
            lFarePanel.Append("<table class=\"table-bordered\"  cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
            int lAC = 0, lNonAC = 0;
            for (int Ctr = 0; Ctr < ldtFarePanel.Rows.Count; Ctr++)
            {
                if (Convert.ToInt32(ldtFarePanel.Rows[Ctr]["ACFare"]) > 0)
                {
                    lAC = 1;
                }
                if (Convert.ToInt32(ldtFarePanel.Rows[Ctr]["NONACFare"]) > 0)
                {
                    lNonAC = 1;
                }
            }
            // ***** FOT GETTING HEADER *****
            lFarePanel.Append("<tr>");
            lFarePanel.Append(fldTDSeasonHead.Replace("#SeasonHead", "").Replace("#RowSpan", "1").Replace("#valign", "middle").
                            Replace("#FareBGColor", "#d7e9ff").
                            Replace("#FareForeColor", "#DF411A"));
            for (int HeadCtr = 4; HeadCtr < ldtFarePanel.Columns.Count; HeadCtr++)
            {
                lFarePanel.Append(fldTDSeasonHead.Replace("#SeasonHead", ldtFarePanel.Columns[HeadCtr].ColumnName).
                    Replace("#ColSpan", (lAC + lNonAC).ToString()).Replace("#valign", "middle").
                            Replace("#ClassNameTH", ""));
            }
            lFarePanel.Append("</tr>");
            //*****FOR GETTING SUB-HEADER
            lFarePanel.Append("<tr>");
            lFarePanel.Append(fldTDSeasonHead.Replace("#SeasonHead", "Category").Replace("#RowSpan", "1").Replace("#valign", "middle").
                            Replace("#ClassNameTH", "th2"));
            for (int HeadCtr = 4; HeadCtr < ldtFarePanel.Columns.Count; HeadCtr++)
            {

                if (lAC > 0)
                {
                    if (FlagIntlEBKTourIDs)
                    {
                        lFarePanel.Append(fldTDSeasonHead.Replace("#SeasonHead", "WAM Member").Replace("#StyleTH", "text-align:center").
                          Replace("#ColSpan", "0").
                              Replace("#ClassNameTH", "th2"));
                    }
                    else
                    {
                        lFarePanel.Append(fldTDSeasonHead.Replace("#SeasonHead", "AC").Replace("#StyleTH", "text-align:center").
                            Replace("#ColSpan", "0").
                                Replace("#ClassNameTH", "th2"));
                    }
                }
                if (lNonAC > 0)
                {
                    if (FlagIntlEBKTourIDs)
                    {
                        lFarePanel.Append(fldTDSeasonHead.Replace("#SeasonHead", "WAM NonMember").Replace("#StyleTH", "text-align:center").
                            Replace("#ColSpan", "0").
                                Replace("#ClassNameTH", "th2"));
                    }
                    else
                    {
                        lFarePanel.Append(fldTDSeasonHead.Replace("#SeasonHead", "Non-AC").Replace("#StyleTH", "text-align:center").
                            Replace("#ColSpan", "0").
                                Replace("#ClassNameTH", "th2"));
                    }
                }
            }
            lFarePanel.Append("</tr>");

            int lCategoryID = 0;
            bool lAddFareType = true, lIsEvenRow = true;
            string lCurrentBGColor = "#bcdbff", lCurrentForeColor = "";
            for (int Ctr = 0; Ctr < ldtFarePanel.Rows.Count; Ctr++)
            {
                if (lCategoryID == 0)
                {
                    lCategoryID = Convert.ToInt32(ldtFarePanel.Rows[Ctr]["CategoryID"]);
                    if ((Convert.ToInt32(ldtFarePanel.Rows[Ctr]["ACFare"]) + Convert.ToInt32(ldtFarePanel.Rows[Ctr]["NONACFare"])) > 0)
                    {
                        if (lIsEvenRow)
                        {
                            lCurrentBGColor = "";
                            lIsEvenRow = false;
                        }
                        else
                        {
                            lCurrentBGColor = "";
                            lIsEvenRow = true;
                        }
                        lFarePanel.Append("<tr>");
                        lFarePanel.Append(fldTDFareTypeHead.Replace("#FareType", ldtFarePanel.Rows[Ctr]["Category/Date"].ToString()).
                            Replace("#FareBGColor", lCurrentBGColor).
                            Replace("#FareForeColor", lCurrentForeColor).
                            Replace("#THClass", "orange"));
                        if (lAC > 0)
                        {
                            lFarePanel.Append(fldTDSeasonValue.Replace("#SeasonValue",
                                ((Convert.ToInt32(ldtFarePanel.Rows[Ctr]["ACFare"]) == 0) ? "-" : "<i class=\"fa fa-rupee\"></i>" + Convert.ToDecimal(ldtFarePanel.Rows[Ctr]["ACFare"]).ToString("#,##0") +
                                "/-")).
                            Replace("#FareBGColor", lCurrentBGColor).
                            Replace("#FareForeColor", lCurrentForeColor));
                        }
                        if (lNonAC > 0)
                        {
                            lFarePanel.Append(fldTDSeasonValue.Replace("#SeasonValue",
                                ((Convert.ToInt32(ldtFarePanel.Rows[Ctr]["NONACFare"]) == 0) ? "-" : " <i class=\"fa fa-rupee\"></i>" + Convert.ToDecimal(ldtFarePanel.Rows[Ctr]["NONACFare"]).ToString("#,##0") +
                                "/-")).
                            Replace("#FareBGColor", lCurrentBGColor).
                            Replace("#FareForeColor", lCurrentForeColor));
                        }
                    }
                    else
                    {
                        lAddFareType = false;
                    }
                }
                else if (lCategoryID == Convert.ToInt32(ldtFarePanel.Rows[Ctr]["CategoryID"]))
                {
                    if (lAddFareType)
                    {
                        if (lAC > 0)
                        {
                            lFarePanel.Append(fldTDSeasonValue.Replace("#SeasonValue",
                                ((Convert.ToInt32(ldtFarePanel.Rows[Ctr]["ACFare"]) == 0) ? "-" : "<i class=\"fa fa-rupee\"></i>" + Convert.ToDecimal(ldtFarePanel.Rows[Ctr]["ACFare"]).ToString("#,##0") +
                                "/-")).
                            Replace("#FareBGColor", lCurrentBGColor).
                            Replace("#FareForeColor", lCurrentForeColor));
                        }
                        if (lNonAC > 0)
                        {
                            lFarePanel.Append(fldTDSeasonValue.Replace("#SeasonValue",
                                ((Convert.ToInt32(ldtFarePanel.Rows[Ctr]["NONACFare"]) == 0) ? "-" : "<i class=\"fa fa-rupee\"></i>" + Convert.ToDecimal(ldtFarePanel.Rows[Ctr]["NONACFare"]).ToString("#,##0") +
                                "/-")).
                            Replace("#FareBGColor", lCurrentBGColor).
                            Replace("#FareForeColor", lCurrentForeColor));
                        }
                    }
                }
                else
                {
                    if (lAddFareType)
                    {
                        lFarePanel.Append("</tr>");
                    }
                    else
                    {
                        lAddFareType = true;
                    }
                    if ((Convert.ToInt32(ldtFarePanel.Rows[Ctr]["ACFare"]) + Convert.ToInt32(ldtFarePanel.Rows[Ctr]["NONACFare"])) > 0)
                    {
                        lFarePanel.Append("<tr>");
                        if (lIsEvenRow)
                        {
                            lCurrentBGColor = "";
                            lIsEvenRow = false;
                        }
                        else
                        {
                            lCurrentBGColor = "";
                            lIsEvenRow = true;
                        }
                        lFarePanel.Append(fldTDFareTypeHead.Replace("#FareType", ldtFarePanel.Rows[Ctr]["Category/Date"].ToString()).
                            Replace("#FareBGColor", lCurrentBGColor).
                            Replace("#FareForeColor", lCurrentForeColor).
                            Replace("#THClass", "orange"));
                        if (lAC > 0)
                        {
                            lFarePanel.Append(fldTDSeasonValue.Replace("#SeasonValue",
                                ((Convert.ToInt32(ldtFarePanel.Rows[Ctr]["ACFare"]) == 0) ? "-" : "<i class=\"fa fa-rupee\"></i>" + Convert.ToDecimal(ldtFarePanel.Rows[Ctr]["ACFare"]).ToString("#,##0") +
                                "/-")).
                            Replace("#FareBGColor", lCurrentBGColor).
                            Replace("#FareForeColor", lCurrentForeColor));
                        }
                        if (lNonAC > 0)
                        {
                            lFarePanel.Append(fldTDSeasonValue.Replace("#SeasonValue",
                                ((Convert.ToInt32(ldtFarePanel.Rows[Ctr]["NONACFare"]) == 0) ? "-" : "<i class=\"fa fa-rupee\"></i>" + Convert.ToDecimal(ldtFarePanel.Rows[Ctr]["NONACFare"]).ToString("#,##0") +
                                "/-")).
                            Replace("#FareBGColor", lCurrentBGColor).
                            Replace("#FareForeColor", lCurrentForeColor));
                        }
                    }
                    else
                    {
                        lAddFareType = false;
                    }
                    lCategoryID = Convert.ToInt32(ldtFarePanel.Rows[Ctr]["CategoryID"]);
                }
            }
            lFarePanel.Append("</tr>");
            lFarePanel.Append("</table>");
            litFarePanelBookNow.Text = "<table width=\"100%\"  cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"tb10\" >" +
                fldBookNow.Replace("#ImgColSpan", ((ldtFarePanel.Columns.Count * (lAC + lNonAC)) - 2).ToString()) + "</table>";
            litFarePanel.Text = lFarePanel.ToString();

            hdnFarePanelItineraryHtml.Value = lFarePanel.ToString();
            fldFarePanelHTML = lFarePanel.ToString();
            HiddenField hdnTourFare = this.Page.FindControl("hdnTourFare") as HiddenField;
            hdnTourFare.Value = hdnTourFare.Value + "<h3 class='title'>Tour <span>Price</span></h3><div class='tablewrap'>" + lFarePanel.ToString() + "</div>";
        }

        private void CheckIntlEBKTourIDs(string strTourid)
        {
            string Ids = ConfigurationManager.AppSettings["IntlEBKTourIDs"];
            string[] Arr = Ids.Split(',');
            foreach (string str in Arr)
            {
                if (str == strTourid)
                {
                    FlagIntlEBKTourIDs = true; break;
                }
            }
        }
        #endregion
    }
}