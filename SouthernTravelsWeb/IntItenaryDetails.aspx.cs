using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class IntItenaryDetails : System.Web.UI.Page
    {

        #region Member Variable(s)
        public string pbFBImage1, pbFBImage2;
        string pOfferIDs = "";
        int pvTourID = 0;
        protected string connectionString;
        #endregion
        #region Property(s)
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
        public string TourID
        {
            get
            {
                if (ViewState["TourID"] != null)
                {
                    return (string)ViewState["TourID"];
                }
                else
                {
                    return null;
                }
            }
            set { ViewState["TourID"] = value; }
        }
        public string fldOfferIDs
        {
            get
            {
                if (Request.QueryString["ofr"] != null && Request.QueryString["ofr"].ToString().Trim() != string.Empty)
                {
                    pOfferIDs = Request.QueryString["ofr"].ToString().Trim();
                }
                else
                {
                    pOfferIDs = "1";
                }
                return pOfferIDs;
            }
            set { pOfferIDs = value; }
        }
        #endregion
        #region Event(s)

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.AppSettings["southernconn"];
            divrecaptcha.Attributes.Add("data-sitekey", ConfigurationManager.AppSettings["GooglereCaptcha_Sitekey"]);
            if (!IsPostBack)
            {
                ViewState["TourID"] = fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
                int offid = ClsCommon.ConvertStringint(Request.QueryString["ofr"]);
                if (fldTourID == 182 && offid == 1)
                { Response.Redirect("InternationalTours_Offer2-UnitedKingdom-BestOfEurope10Days09Nights_182"); }
                if (fldTourID == 155)
                {
                    psplNote.Visible = false;
                }
                else
                {
                    psplNote.Visible = false;
                }
                HideShowDateEnquiryBox();
                BindCost();

                ModifyMetaTag();
            }
            ucItinerary.fldTourType = TOURTYPE.INTERNATIONAL_TOUR;
            ucItinerary.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            ucMatchingTour1.fldTourType = ClsCommon.ConvertStringint(TOURTYPE.INTERNATIONAL_TOUR);
            ucMatchingTour1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);

            ucTourShortInfo1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            ucTourShortInfo1.fldTourTypeID = ClsCommon.ConvertStringint(TOURTYPE.INTERNATIONAL_TOUR);
            ucTourShortInfo1.fldTourType = "International Tour";
            ucTourShortInfo1.fldClass = "active";

            ucInclu.fldTourType = ClsCommon.ConvertStringint(TOURTYPE.INTERNATIONAL_TOUR);
            ucInclu.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            UCTourInfo1.fldTourType = TOURTYPE.INTERNATIONAL_TOUR;
            UCTourInfo1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            UCTourGallery1.fldTourType = TOURTYPE.INTERNATIONAL_TOUR;
            UCTourGallery1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            if (Request.QueryString["ofr"] != null && Request.QueryString["ofr"].ToString() == "1")
            {
                UCHeader.fldMainSection = Current_Section.HOLIDAY_PACKAGE_INTERNATIONAL_CUSTOMIZED;
            }
            else if (Request.QueryString["ofr"] != null && Request.QueryString["ofr"].ToString() == "2")
            {
                UCHeader.fldMainSection = Current_Section.HOLIDAY_PACKAGE_INTERNATIONAL_FIXED;
            }
            BindTourItenerary();
        }
        protected void imgbtnSendRequest_Click1(object sender, EventArgs e)
        {
            bool lFlag = reCaptcha();
            if (lFlag)
            {
                string refno = "";// refCode();


                string sInterest = lblTitle.Text.Trim();
                
                DateTime lDepartureDate, lArrivalDate;

                if (!string.IsNullOrEmpty(hdnStartDate.Value)) // user is interseted in fixed departure tour
                {

                    string[] DateArr3 = new string[3];
                    char[] splitter1 = { '/' };
                    DateArr3 = hdnStartDate.Value.Split(splitter1);
                    lDepartureDate = new DateTime(ClsCommon.ConvertStringint(DateArr3[2]), ClsCommon.ConvertStringint(DateArr3[1]), ClsCommon.ConvertStringint(DateArr3[0]));

                }
                else
                {
                    if (txtDept.Value == "")
                    {
                        lDepartureDate = DateTime.Today.Date;
                    }
                    else
                    {
                        lDepartureDate = DateTime.ParseExact(txtDept.Value, "mm/dd/yyyy", CultureInfo.CurrentCulture);
                       
                    }
                }


                if (txtarrival.Value == "")
                    lArrivalDate = DateTime.Today.Date;
                else
                {
                    lArrivalDate = DateTime.ParseExact(txtarrival.Value, "mm/dd/yyyy", CultureInfo.CurrentCulture);
                    
                }

                int RetVal = insData(sInterest, ddlAdults.SelectedValue, ddlChilds.SelectedValue, S_name.Value, S_phone.Value,
                    S_email.Value, S_city.Value, S_streetaddress.Value, S_pin.Value, lDepartureDate, lArrivalDate, txtDescription.Value, ref refno,
                    "", ddlInfants.SelectedValue);

                if ((RetVal == 1) || (RetVal == 2))
                {
                    lblMsg.Text = "Sorry!.. There is a mistake in the input fields,  Please try again.";
                
                }
                else
                {
                    string sArrivalDate = this.txtarrival.Value.ToString().Replace("'", "''");
                    string sDepDate = this.txtDept.Value.ToString().Replace("'", "''");
                    string sPlan = this.txtDescription.Value.ToString().Replace("'", "''");
                    string sName = this.S_name.Value.ToString().Replace("'", "''");
                    string sEmail = this.S_email.Value.ToString().Replace("'", "''");
                    string sPhone = this.S_phone.Value.ToString().Replace("'", "''");
                    string sFax = this.S_fax.Value.ToString().Replace("'", "''");
                    string sStreet = this.S_streetaddress.Value.ToString().Replace("'", "''");
                    string sCity = this.S_city.Value.ToString().Replace("'", "''");
                    string sZip = this.S_pin.Value.ToString().Replace("'", "''");
                    string sCountry = this.S_country.Value.ToString().Replace("'", "''");
                    string sNoOfAdults = ddlAdults.SelectedValue;
                    string sNoOfChild = ddlChilds.SelectedValue;
                    string sNoOfInfants = ddlInfants.SelectedValue;
                    // ================================= Mail Format Start Here ==============================
                    string mailbody = "";
                    mailbody = mailbody + "<br><table width='60%' border='1' cellspacing='1' cellpadding='2' align='center'>";
                    mailbody = mailbody + "<tr><td bgcolor='#CCCCCC' colspan='2'><font face='Verdana' size='-1'><b>Enquiry Details : </b>" + refno + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Arrival Date</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sArrivalDate + "  </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Departure Date</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sDepDate + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Interested In</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sInterest + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Travel Plan / Requirements</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sPlan + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>No of Adult</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sNoOfAdults + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>No of Children</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sNoOfChild + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>No of Infants</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sNoOfInfants + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Name</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sName + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Email</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sEmail + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Phone / Mobile</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sPhone + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Fax</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sFax + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Street Address</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sStreet + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>City / State</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sCity + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Zip / Postal Code</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sZip + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                    mailbody = mailbody + "<td><font size='-1' face='Verdana'>Country</font></td>";
                    mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sCountry + " </font></td>";
                    mailbody = mailbody + "</tr>";
                    mailbody = mailbody + "</table>";
                   
                    MailSend(ConfigurationSettings.AppSettings["IntEnquiryTo"].ToString(), ConfigurationSettings.AppSettings["IntEnquiryBCC"].ToString(),
                       "", sEmail, refno + ": " + sInterest + " Package Enquiry details", mailbody, sEmail);

                   
                    lblMsg.Text = "Thanks for your interest. Our executive will get back you very soon.";
                    Response.Redirect("ThankYou.aspx?TourId=" + ClsCommon.ConvertStringint(ViewState["TourID"]) + "&ofr=" + Request.QueryString["ofr"] + "&PrevPage=IntItenaryDetails&ThankYouMsg=Thanks for your interest. Our executive will get back you very soon.");
                }
            }
        }
        #endregion

        #region Method(s)
        /// <summary>
        /// With Xml Read
        /// </summary>
        /// 
        private void BindCost()
        {
            List<TourItenerary_SPResult> lGetResult = null;
            try
            {
                int tourID = ClsCommon.ConvertStringint(Request.QueryString["fldTourID"]);
                int tourType = ClsCommon.ConvertStringint(TOURTYPE.INTERNATIONAL_TOUR);
                lGetResult =  GetTourIteneraryADO(tourID, tourType);


                if (lGetResult != null && lGetResult.Count > 0)
                {
                    if (fldOfferIDs != "0")
                    {
                        string url = "~/StatFarePanel.aspx?TourID=" + Request.QueryString["TourID"].ToString() + "&TourType=3";

                        StringBuilder htmlHtmlContent = new StringBuilder();
                        StringWriter htmlStringWriter = new StringWriter();
                        HttpContext.Current.Server.Execute(url, htmlStringWriter);
                        htmlHtmlContent = htmlStringWriter.GetStringBuilder();
                        htmlStringWriter.Close();

                        litcoutCost.Text = htmlHtmlContent.ToString();
                        pnlCoustem.Visible = true;
                        pnlcost.Visible = false;

                        string arrSplStr = "<div class=\"tablewrap\">";
                        if (htmlHtmlContent.ToString().Contains(arrSplStr))
                        {
                            string strContent = htmlHtmlContent.ToString().Split(new string[] { arrSplStr }, StringSplitOptions.None)[1];
                            hdnTourFare.Value = "<h3 class='title'>Tour <span>Price</span></h3><div id='pnlCoustem'><div class='tablewrap'>" + strContent + "</div></div>";
                        }
                    }

                    if (!string.IsNullOrEmpty(lGetResult[0].TourCost))
                    {
                        if (fldOfferIDs == "1")
                        {
                            litcost.Text = lGetResult[0].TourCost;
                            hdnTourFare.Value = "<h3 class='title'>Tour <span>Price</span></h3><table width='100%' border='0' cellpadding='0' cellspacing='0' class='table-bordered'><tbody><tr><th class='th2'>Cost</th><th class='th2'>" + lGetResult[0].TourCost + "</th></tr><tr><td colspan ='2'><i class='fa fa-rupee'></i> * Terms & Conditions Apply</td></tr></tbody></table>";
                        }

                        lblTitle.Text = lGetResult[0].TourName;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }


        public List<TourItenerary_SPResult> GetTourIteneraryADO(int tourID, int tourType)
        {
            List<TourItenerary_SPResult> resultList = new List<TourItenerary_SPResult>();


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.TourItenerary_SP, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@I_TourID", tourID);
                    cmd.Parameters.AddWithValue("@I_TourType", tourType);

                    SqlParameter outputParam = new SqlParameter("@O_ReturnValue", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TourItenerary_SPResult item = new TourItenerary_SPResult
                            {
                                Tour_Short_key = reader["Tour_Short_key"] as string,
                                ISAccomodation = reader["ISAccomodation"] != DBNull.Value ? Convert.ToChar(reader["ISAccomodation"]) : (char?)null,
                                TourName = reader["TourName"] as string,
                                Departuretime = reader["Departuretime"] as string,
                                ReturnTime = reader["ReturnTime"] as string,
                                CostIncludes = reader["CostIncludes"] as string,
                                CostExcludes = reader["CostExcludes"] as string,
                                Duration = reader["Duration"] as string,
                                TourPolicy = reader["TourPolicy"] as string,
                                Notes = reader["Notes"] as string,
                                OccasionalItinerary = reader["OccasionalItinerary"] as string,
                                NoOfDays = reader["NoOfDays"] != DBNull.Value ? Convert.ToInt32(reader["NoOfDays"]) : (int?)null,
                                NoOfNights = reader["NoOfNights"] != DBNull.Value ? Convert.ToInt32(reader["NoOfNights"]) : (int?)null,
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

                            resultList.Add(item);
                        }
                    }
                }
            }

            return resultList;
        }

        private void ModifyMetaTag()
        {
            ClsCommon clsCmn= new ClsCommon();
            try
            {
                int TourId, CountryID, ZoneId;
                if (Request.QueryString["TourID"] != null && Request.QueryString["tourId"] != "")
                {
                    TourId = ClsCommon.ConvertStringint(Request.QueryString["tourId"]);
                }
                else
                {
                    TourId = 0;
                }
                ZoneId = 0; CountryID = 0;
                DataTable dtM = clsCmn.fnGetMetaTagForTours(ClsCommon.ConvertStringint(TOURTYPE.INTERNATIONAL_TOUR), TourId, CountryID, ZoneId);
                if (dtM.Rows.Count > 0)
                {
                    HtmlHead hd = (HtmlHead)Page.FindControl("HeadST");
                    HtmlMeta htmMeta1 = new HtmlMeta();
                    string strMetaID = "";
                    string strContentText = "";
                    string strMetaName = "";
                    foreach (DataRow dr in dtM.Rows)
                    {
                        strMetaID = Convert.ToString(dr["MetaTagId"]).ToUpper();
                        strContentText = Convert.ToString(dr["MetaContent"]);
                        strMetaName = Convert.ToString(dr["MetaTagName"]);
                        if (strMetaName.ToLower() == "title")
                        {
                            this.Title = strContentText;
                        }
                        else
                        {
                            htmMeta1 = (HtmlMeta)hd.FindControl(strMetaID);

                            if (htmMeta1 != null)
                            {
                                htmMeta1.Content = strContentText;
                            }
                            else
                            {
                                HtmlMeta htmnewmeta = new HtmlMeta();
                                htmnewmeta.ID = strMetaID;
                                htmnewmeta.Name = strMetaName;
                                htmnewmeta.Content = strContentText;
                                hd.Controls.Add(htmnewmeta);
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

        private void BindTourItenerary()
        {
            List<TourItenerary_SPResult> lGetResult = null;
            hd.Style.Add("background-image", "url(Assets/images/banner.jpg)");
            try
            {
                int tourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
                int tourType = ClsCommon.ConvertStringint(TOURTYPE.INTERNATIONAL_TOUR);

                lGetResult = GetTourIteneraryADO(tourID, tourType);

                if (lGetResult != null && lGetResult.Count > 0)
                {
                    bool lFlag = false;

                    if (!string.IsNullOrEmpty(lGetResult[0].PageBanner))
                    {
                        hd.Style.Add("background-image", "url(images/PageBanner/InternationalTours/" + lGetResult[0].PageBanner + ")");
                        lFlag = true;
                    }
                    else
                    {
                        try
                        {
                            string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("~/Images/PageBanner/InternationalTours/"));
                            foreach (string item in filesindirectory)
                            {
                                string lFileName = System.IO.Path.GetFileName(item).Split('.')[0];
                                if (lFileName.Trim().ToUpper() == lGetResult[0].Tour_Short_key.Trim().ToUpper())
                                {
                                    hd.Style.Add("background-image", "url(images/PageBanner/InternationalTours/" + System.IO.Path.GetFileName(item) + ")");
                                    lFlag = true;
                                    break;
                                }
                            }
                        }
                        catch { }
                    }

                    if (!lFlag)
                    {
                        hd.Style.Add("background-image", "url(Assets/images/banner.jpg)");
                    }
                }
            }
            catch
            {
            }
        }


        public int insData(string strTourName, string strAdults, string strchilds, string strFname, string strMobile, string strEmailId,
            string strCity, string strAddress, string strPinCode, DateTime strJourneyDate, DateTime strReturnDate, string strDescription,
           ref string refno, string captcha, string strInfants)
        {
            int status = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.sp_tbl_intquery, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    cmd.Parameters.AddWithValue("@TourName", strTourName);
                    cmd.Parameters.AddWithValue("@Adults", Convert.ToDecimal(strAdults));
                    cmd.Parameters.AddWithValue("@childs", Convert.ToDecimal(strchilds));
                    cmd.Parameters.AddWithValue("@Fname", DataLib.funClear(strFname));
                    cmd.Parameters.AddWithValue("@Mobile", DataLib.funClear(strMobile));
                    cmd.Parameters.AddWithValue("@EmailId", DataLib.funClear(strEmailId));
                    cmd.Parameters.AddWithValue("@City", DataLib.funClear(strCity));
                    cmd.Parameters.AddWithValue("@Address", DataLib.funClear(strAddress));
                    cmd.Parameters.AddWithValue("@PinCode", DataLib.funClear(strPinCode));
                    cmd.Parameters.AddWithValue("@JourneyDate", strJourneyDate);
                    cmd.Parameters.AddWithValue("@ReturnDate", strReturnDate);
                    cmd.Parameters.AddWithValue("@Description", DataLib.funClear(strDescription));
                    cmd.Parameters.AddWithValue("@captcha", DataLib.funClear(captcha));
                    cmd.Parameters.AddWithValue("@Infants", ClsCommon.ConvertStringint(strInfants));
                    cmd.Parameters.AddWithValue("@TourID", ClsCommon.ConvertStringint(ViewState["TourID"]));
                    // Output parameters
                    SqlParameter statusParam = new SqlParameter("@Status", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(statusParam);

                    SqlParameter refnoParam = new SqlParameter("@TicketNo", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(refnoParam);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        status = Convert.ToInt32(statusParam.Value);
                        refno = Convert.ToString(refnoParam.Value);
                    }
                    catch (Exception ex)
                    {
                        status = -2;
                        // Optionally log exception
                        throw;
                    }
                }
            }

            return status;
        }

        #endregion

        private void HideShowDateEnquiryBox()
        {
            if (fldOfferIDs == "1")
            {
                divSpecialFields.Visible = true; // user has chosend customized plan
                divFixedDate.Visible = false;
                hdnIsFixedIntTour.Value = "0";
            }

            else
            {
                divSpecialFields.Visible = false; // user has fixed holiday
                divFixedDate.Visible = true;
                hdnIsFixedIntTour.Value = "1";
            }

        }

        private void MailSend(string pTO, string pBCC, string pCC, string pFrom, string pSubject, string pBody, string pFromName)
        {
            try
            {
                //Add TLS 1.2
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(3072);

                System.Net.Mail.MailMessage lMail = null;
                SmtpClient lSmtp = null;
                try
                {
                    lMail = new System.Net.Mail.MailMessage();
                    lSmtp = new SmtpClient();
                    lMail.From = new MailAddress("enquiry@southerntravels.com");//pFrom;
                    lMail.To.Add(pTO);
                    lMail.CC.Add(pFrom);
                    lMail.Subject = pSubject;
                    lMail.IsBodyHtml = true;
                    lMail.Body = pBody;
                    lMail.ReplyTo = new MailAddress(pFromName);
                    string smtpEmail = "";
                    string smtpPassword = "";
                    smtpEmail = ConfigurationSettings.AppSettings["enquiry@southerntravels.com".ToLower() + "_UserName"].ToString();//"etickets@southerntravels.in";//ConfigurationSettings.AppSettings["SmtpUserName"].ToString();"enquiry@southerntravels.com";
                    smtpPassword = ConfigurationSettings.AppSettings["enquiry@southerntravels.com".ToLower() + "_Password"].ToString(); ;

                    string smtpAddress = ConfigurationSettings.AppSettings["AuthMailSmtpIP"].ToString();//"smtp.gmail.com";
                    string smtpPort = ConfigurationSettings.AppSettings["AuthMailSmtpPort"].ToString(); ;
                    if (smtpEmail != "")
                    {
                        lSmtp.Host = smtpAddress;
                        lSmtp.Port = ClsCommon.ConvertStringint(smtpPort);
                        lSmtp.Credentials = new System.Net.NetworkCredential(smtpEmail, smtpPassword);
                        lSmtp.EnableSsl = true;
                    }
                    else
                    {
                        lSmtp = new SmtpClient(smtpAddress);
                    }

                    lSmtp.Send(lMail);

                }
                catch (Exception ex)
                {
                    throw ex;
                    //Response.Write(ex.Message);
                }
                finally
                {
                    if (lMail != null)
                    {
                        lMail = null;
                    }
                    if (lSmtp != null)
                    {
                        lSmtp = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public bool reCaptcha()
        {
            bool lFlag = false;
            //start building recaptch api call
            var sb = new System.Text.StringBuilder();
            sb.Append("https://www.google.com/recaptcha/api/siteverify?secret=");

            //our secret key
            var secretKey = ConfigurationManager.AppSettings["GooglereCaptcha_Secretkey"]; //"6LesfBwTAAAAAPKzkHq9ny59cb_BtZa1D6ZLLBGf";
            sb.Append(secretKey);

            //response from recaptch control
            sb.Append("&");
            sb.Append("response=");
            var reCaptchaResponse = Request["g-recaptcha-response"];
            sb.Append(reCaptchaResponse);

            //client ip address
            //---- This Ip address part is optional. If you donot want to send IP address you can
            //---- Skip(Remove below 4 lines)
            sb.Append("&");
            sb.Append("remoteip=");
            var clientIpAddress = GetUserIp();
            sb.Append(clientIpAddress);

            //make the api call and determine validity
            using (var client = new System.Net.WebClient())
            {
                var uri = sb.ToString();
                var json = client.DownloadString(uri);
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(RecaptchaApiResponse));
                var ms = new System.IO.MemoryStream(System.Text.Encoding.Unicode.GetBytes(json));
                var result = serializer.ReadObject(ms) as RecaptchaApiResponse;

                //--- Check if we are able to call api or not.
                if (result == null)
                {
                    MessageLabel.Text = "Captcha was unable to make the api call";
                }
                else // If Yes
                {
                    //api call contains errors
                    if (result.ErrorCodes != null)
                    {
                        if (result.ErrorCodes.Count > 0)
                        {
                            foreach (var error in result.ErrorCodes)
                            {
                                MessageLabel.Text = "Captcha is required.";
                            }
                        }
                    }
                    else //api does not contain errors
                    {
                        if (!result.Success) //captcha was unsuccessful for some reason
                        {
                            MessageLabel.Text = "Captcha did not pass, please try again.";
                        }
                        else //---- If successfully verified. Do your rest of logic.
                        {
                            MessageLabel.Text = "Captcha cleared ";
                            lFlag = true;
                        }
                    }

                }

            }
            return lFlag;
        }

        [DataContract]
        public class RecaptchaApiResponse
        {
            [DataMember(Name = "success")]
            public bool Success { get; set; }

            [DataMember(Name = "error-codes")]
            public List<string> ErrorCodes { get; set; }
        }

        //--- To get user IP(Optional)
        private string GetUserIp()
        {
            var visitorsIpAddr = string.Empty;

            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                visitorsIpAddr = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (!string.IsNullOrEmpty(Request.UserHostAddress))
            {
                visitorsIpAddr = Request.UserHostAddress;
            }

            return visitorsIpAddr;
        }
    }
}