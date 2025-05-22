using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
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
    public partial class UcFixedTourList : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        int pvTourID, pvNoOfTours; TOURTYPE pvTourType;
        string pvTourOrigin = "";
        bool pvIsLTC = false;
        bool pvMoreToLanding = false;
        bool pvShowAllTour = false;
        protected string connectionString;
        #endregion
        #region "Property(s)"
        /// <summary>
        /// Move more link to Section Landing Page or Detailed page.
        /// </summary>
        public bool fldMoreToLanding
        {
            get { return pvMoreToLanding; }
            set { pvMoreToLanding = value; }
        }
        public bool fldIsLTC
        {
            get { return pvIsLTC; }
            set { pvIsLTC = value; }
        }
        public int fldNoOfTours
        {
            get { return pvNoOfTours; }
            set { pvNoOfTours = value; }
        }

        public TOURTYPE fldTourType
        {
            get { return pvTourType; }
            set { pvTourType = value; }
        }

        public int fldTourID
        {
            get { return pvTourID; }
            set { pvTourID = value; }
        }
        public string fldTourOrigin
        {
            get { return pvTourOrigin; }
            set { pvTourOrigin = value; }
        }
        protected string fldOrigin
        {
            get { return pvTourOrigin; }
        }
        public bool fldShowAllTour
        {
            get { return pvShowAllTour; }
            set { pvShowAllTour = value; }
        }
        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.AppSettings["southernconn"];

            if (!IsPostBack)
            {

                FillTours(fldTourType);


            }
        }
        protected void gvTourList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink lbtnTour = (HyperLink)e.Row.Cells[0].FindControl("lbtnTour");
                HiddenField hdTourID = (HiddenField)e.Row.Cells[0].FindControl("hdTourID");
                HiddenField hdTourName = (HiddenField)e.Row.Cells[0].FindControl("hdTourName");
                Label lblTourName = (Label)e.Row.Cells[0].FindControl("lblTourName");
                if (fldTourType == TOURTYPE.FIXED_TOUR)
                {
                    if (fldIsLTC == true)
                    {
                        lbtnTour.NavigateUrl = "../Fixed-Departure-LTC-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                    }
                    else
                    {
                        lbtnTour.NavigateUrl = "../Fixed-Departure-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                    }
                    if (hdTourID.Value.Trim() == "45")
                    {
                        lblTourName.ToolTip += " (Starts From 06-Sep-2014)";
                    }
                    if (hdTourID.Value.Trim() == "130")
                    {
                        lblTourName.ToolTip += " (25-Sep-2014 To 05-Oct-2014)";
                    }
                }
                else if (fldTourType == TOURTYPE.SPECIAL_TOUR)
                {
                    lbtnTour.NavigateUrl = "../Holiday-Packages-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                }
            }
        }
        #endregion
        #region "Method(s)"
        private void FillTours_XML(TOURTYPE lTOURTYPE)
        {
            List<GetTourList_By_Start_RegionResult> lTourList = new List<GetTourList_By_Start_RegionResult>();
            GetTourList_By_Start_RegionResult lTour = null;
            XDocument XDocTourList = XDocument.Load(Server.MapPath("Common/TourListLink.xml"));
            try
            {
                if (fldTourOrigin.ToLower() == "all")
                {
                    var varTourList = from TourList in XDocTourList.Descendants("AllTours")
                                      where Convert.ToInt32(TourList.Element("TourType").Value) == Convert.ToInt32(lTOURTYPE)
                                      orderby Convert.ToInt32(TourList.Element("TourSequence").Value)
                                      select new
                                      {
                                          RowID = TourList.Element("RowID").Value.Trim(),
                                          TourNo = TourList.Element("TourNo").Value.Trim(),
                                          Tour_Short_Key = TourList.Element("Tour_Short_Key").Value.Trim(),
                                          TourName = TourList.Element("TourName").Value.Trim(),
                                          FullTourName = TourList.Element("FullTourName").Value.Trim(),
                                          Remarks = TourList.Element("Remarks").Value.Trim(),
                                          Tour_DisplayName = TourList.Element("Tour_DisplayName").Value.Trim(),
                                          Notes = TourList.Element("Notes").Value.Trim()
                                      };
                    foreach (var Tour in varTourList.ToList().GroupBy(o => o.TourNo).Select(o => o.First()))
                    {
                        lTour = new GetTourList_By_Start_RegionResult();
                        lTour.RowID = Convert.ToInt32(Tour.RowID);
                        lTour.TourNo = Convert.ToInt32(Tour.TourNo);
                        lTour.Tour_Short_Key = Tour.Tour_Short_Key;
                        lTour.TourName = Tour.TourName;
                        lTour.FullTourName = Tour.FullTourName;
                        lTour.Remarks = Tour.Remarks;
                        lTour.Tour_DisplayName = Tour.Tour_DisplayName;
                        lTour.Notes = Tour.Notes;
                        lTourList.Add(lTour);
                    }
                }
                else
                {
                    var varTourList = from TourList in XDocTourList.Descendants("AllTours")
                                      where Convert.ToInt32(TourList.Element("TourType").Value) == Convert.ToInt32(lTOURTYPE) && TourList.Element("ZoneName").Value.Trim().ToLower() == fldTourOrigin.Trim().ToLower()
                                      orderby Convert.ToInt32(TourList.Element("TourSequence").Value)
                                      select new
                                      {
                                          RowID = TourList.Element("RowID").Value.Trim(),
                                          TourNo = TourList.Element("TourNo").Value.Trim(),
                                          Tour_Short_Key = TourList.Element("Tour_Short_Key").Value.Trim(),
                                          TourName = TourList.Element("TourName").Value.Trim(),
                                          FullTourName = TourList.Element("FullTourName").Value.Trim(),
                                          Remarks = TourList.Element("Remarks").Value.Trim(),
                                          Tour_DisplayName = TourList.Element("Tour_DisplayName").Value.Trim(),
                                          Notes = TourList.Element("Notes").Value.Trim()
                                      };
                    foreach (var Tour in varTourList.ToList().GroupBy(o => o.TourNo).Select(o => o.First()))
                    {
                        lTour = new GetTourList_By_Start_RegionResult();
                        lTour.RowID = Convert.ToInt32(Tour.RowID);
                        lTour.TourNo = Convert.ToInt32(Tour.TourNo);
                        lTour.Tour_Short_Key = Tour.Tour_Short_Key;
                        lTour.TourName = Tour.TourName;
                        lTour.FullTourName = Tour.FullTourName;
                        lTour.Remarks = Tour.Remarks;
                        lTour.Tour_DisplayName = Tour.Tour_DisplayName;
                        lTour.Notes = Tour.Notes;
                        lTourList.Add(lTour);
                    }
                }


                if (lTourList != null && lTourList.Count > 0)
                {
                    gvTourList.Style.Add("display", "block");
                    if ((fldTourType == TOURTYPE.FIXED_TOUR) && (fldTourOrigin.Trim().ToLower() == "new delhi"))
                    {
                        int lFinalListCount = 0;
                        if (fldShowAllTour)
                        {
                            lFinalListCount = lTourList.Count;
                        }
                        else
                        {
                            lFinalListCount = 17;
                        }
                        if (lTourList.Count > lFinalListCount)
                        {
                            lTourList = lTourList.Take(lFinalListCount).ToList();
                            if (fldIsLTC == true)
                            {
                                //lbtnTourLink.NavigateUrl = "../India-Tours.aspx?ORG=New Delhi&ltc=Y";
                            }
                            else
                            {
                                //lbtnTourLink.NavigateUrl = "../India-Tours.aspx?ORG=New Delhi";
                            }
                            //lbtnTourLink.Text = "more";
                        }
                    }
                    else
                    {
                        if (lTourList.Count > 4)
                        {
                            lTourList = lTourList.Take(4).ToList();
                            if (fldTourType == TOURTYPE.FIXED_TOUR)
                            {
                                if (fldMoreToLanding == true)
                                {
                                    //lbtnTourLink.NavigateUrl = "../India-Tour-Packages.aspx";
                                }
                                else
                                {
                                    if (fldIsLTC == true)
                                    {
                                        //lbtnTourLink.NavigateUrl = "../India-Tours.aspx?ORG=New Delhi&ltc=Y";
                                        //lbtnTourLink.NavigateUrl = "../India-Tours.aspx?ORG=" + fldTourOrigin.Trim() + "&ltc=Y";
                                    }
                                    else
                                    {
                                        //lbtnTourLink.NavigateUrl = "../India-Tours.aspx?ORG=" + fldTourOrigin.Trim();
                                    }

                                }
                                //lbtnTourLink.Text = "more";
                            }
                            else
                            {
                                if (fldMoreToLanding == true)
                                {
                                    //lbtnTourLink.NavigateUrl = "../holiday-packages.aspx";
                                }
                                else
                                {
                                    //lbtnTourLink.NavigateUrl = "../HolidayPackages.aspx?ORG=" + fldTourOrigin.Trim();
                                }
                                //lbtnTourLink.Text = "more";
                            }
                        }
                    }
                    gvTourList.DataSource = lTourList;
                    gvTourList.DataBind();
                }
                else
                {
                    gvTourList.Style.Add("display", "none");
                }

            }
            finally
            {
                if (lTour != null)
                {
                    lTour = null;
                }
                if (lTourList != null)
                {
                    lTourList = null;
                }
                if (XDocTourList != null)
                {
                    XDocTourList = null;
                }
            }
        }

        private void FillTours(TOURTYPE lTOURTYPE)
        {
            var lTourList = new List<TourModel>();

            try
            {
                // use your AppSettings key for the connection string
                //var connString = ConfigurationManager.AppSettings["southernconn"];
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(StoredProcedures.GetTourList_By_Start_Region, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 1) Input parameters
                    cmd.Parameters.Add("@I_TourType", SqlDbType.Int).Value = (int)lTOURTYPE;
                    cmd.Parameters.Add("@I_Region", SqlDbType.VarChar, 100).Value = fldTourOrigin.Trim();

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
                            lTourList.Add(new TourModel
                            {
                                TourID = reader.GetInt32(reader.GetOrdinal("RowID")),
                                TourNo= reader.GetInt32(reader.GetOrdinal("TourNo")),
                                TourName = reader.GetString(reader.GetOrdinal("TourName")),
                                StartLocation = reader.GetString(reader.GetOrdinal("Tour_Short_Key")), // adjust if you want another
                                EndLocation = reader.GetString(reader.GetOrdinal("FullTourName")),
                                DurationDays = reader.GetInt32(reader.GetOrdinal("TourSequence")),   // as example
                                Price = reader.GetDecimal(reader.GetOrdinal("MinCost")),
                                TourType = reader.GetString(reader.GetOrdinal("TourGoingOn")),
                                ImageUrl = null,    // SP doesn’t return ImageUrl; set if you extend SP
                                Description = reader.GetString(reader.GetOrdinal("Remarks")),
                                IsFeatured = false    // SP doesn’t return this; omit or extend
                            });
                        }
                    }

                    // 3) (Optional) read the procedure’s return flag
                    int returnFlag = (outParam.Value != DBNull.Value)
                                       ? (int)outParam.Value
                                       : 0;
                    // you could log or branch on returnFlag == 1
                }

                // ==== your existing display / trimming logic ====
                if (lTourList.Any())
                {
                    gvTourList.Style.Add("display", "block");

                    if (fldTourType == TOURTYPE.FIXED_TOUR
                        && fldTourOrigin.Trim().Equals("new delhi", StringComparison.OrdinalIgnoreCase))
                    {
                        int maxCount = fldShowAllTour ? lTourList.Count : 17;
                        if (lTourList.Count > maxCount)
                            lTourList = lTourList.Take(maxCount).ToList();
                    }
                    else if (lTourList.Count > 4)
                    {
                        lTourList = lTourList.Take(4).ToList();
                    }

                    gvTourList.DataSource = lTourList;
                    gvTourList.DataBind();
                }
                else
                {
                    gvTourList.Style.Add("display", "none");
                }
            }
            catch (Exception ex)
            {
                // hide grid and optionally log ex.Message
                gvTourList.Style.Add("display", "none");
            }
        }





        #endregion
    }
}