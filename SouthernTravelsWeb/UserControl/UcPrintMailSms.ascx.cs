using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcPrintMailSms : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"

        protected static string ReCaptcha_KeyPrint = System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Sitekey"];
        protected static string ReCaptcha_SecretPrint = System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Secretkey"];
        protected static string baseurlPrint = System.Configuration.ConfigurationManager.AppSettings["SouthernBasePathWithoutHttps"];
        int pvTourID, pvTourTypeID; TOURTYPE pvTourType;
        string pvClass = ""; bool pvIsShow = true;

        #endregion
        #region "Property(s)"
        public int fldTourID
        {
            get { return pvTourID; }
            set { pvTourID = value; }
        }
        public bool fldIsShow
        {
            get
            {
                return pvIsShow;
            }
            set
            {
                pvIsShow = value;
            }
        }
        public int fldTourTypeID
        {
            get { return pvTourTypeID; }
            set { pvTourTypeID = value; }
        }
        public TOURTYPE fldTourType
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


        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ShowItinerary();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string SMSTextInnerString = "";
            if (txtMobile.Text != "")
            {
                string SMSText = "Hi,I found this website and thought you might like it ";
                SMSText = SMSText + Request.Url;
                //SMSText = String.Format(SMSText, SMSTextInnerString, Session["orderid"].ToString());
                DataLib.sendsms(0, txtMobile.Text.Trim(),
                    SMSText, "OnLineUser", "EBK0001", "ENQItenSMS", SMSTextInnerString, "");
            }
        }

        protected void btnPanelSendEmail_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["CaptchaImageText"]) == Convert.ToString(txtCaptcha.Text.Trim()))
            {
                if (txtEmailTo.Text != "")
                {
                    string tourname = "";
                    HiddenField hdnTourName = this.Page.FindControl("hdnTourName") as HiddenField;
                    tourname = hdnTourName.Value;

                    HiddenField hdnTourCodeDetails = this.Page.FindControl("hdnTourCodeDetails") as HiddenField;

                    string Subject = "southerntravelsindia.com Tour enquiry for - " + tourname;
                    string strBody = System.IO.File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["mailerTemplatesPath"].ToString() + "\\TourDetailsEmailTemplate.htm"));
                    string finalhtmlgeneratedtext = "";
                    finalhtmlgeneratedtext = "<div style=\"margin:auto; padding:0px; width:800px;\">";
                    finalhtmlgeneratedtext = finalhtmlgeneratedtext + "<b>Dear Sir/Mam,</b><br/><br/>Greetings from Southern Travels !<br/><br/>";
                    finalhtmlgeneratedtext = finalhtmlgeneratedtext + hdnTourCodeDetails.Value + "<br/><br/>";
                    //<h3 class='title'>Itinerary <span>Details</span></h3>
                    finalhtmlgeneratedtext = finalhtmlgeneratedtext + "<h3 class='title'>Itinerary of  <span>" + hdnTourName.Value + "</span></h3><br/>";
                    finalhtmlgeneratedtext = finalhtmlgeneratedtext + hdnFinalHtmlGenerated.Value;
                    finalhtmlgeneratedtext = finalhtmlgeneratedtext + "</div>";
                    strBody = strBody.Replace("#htmlcontent", finalhtmlgeneratedtext);
                    ClsCommon.sendmail(txtEmailTo.Text, "arvind@southerntravels.in", "", "etickets@southerntravels.in", Subject, strBody, "Southren");
                    Page.ClientScript.RegisterStartupScript(GetType(), "alertmdg", "<Script>alert('Tour information has been send successfully.')</script>");
                    txtEmailTo.Text = "";
                    // txtCaptchaPrint.Text = "";
                    txtCaptcha.Text = "";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCaptcha.Text))
                {
                    ClsCommon.ShowAlert("Please Enter Valid Captcha");
                    return;
                }
            }
        }

        private void ShowItinerary()
        {
            List<GetTourItinerary_Meal_spResult> lTourItinerary = new List<GetTourItinerary_Meal_spResult>();
            List<MealPlan> lMealPlan = new List<MealPlan>();
            string connStr = DataLib.getConnectionString();

            try
            {   
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourItinerary_Meal_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@I_TourType", fldTourTypeID);
                        cmd.Parameters.AddWithValue("@I_TourID", fldTourID);

                        SqlParameter returnValue = new SqlParameter("@O_ReturnValue", SqlDbType.Int);
                        returnValue.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(returnValue);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // First result: Itinerary
                            while (reader.Read())
                            {
                                lTourItinerary.Add(new GetTourItinerary_Meal_spResult
                                {
                                    DayNo = reader["DayNo"] != DBNull.Value ? Convert.ToInt32(reader["DayNo"]) : 0,
                                    ItineraryTime = reader["ItineraryTime"] != DBNull.Value ? Convert.ToString(reader["ItineraryTime"]) : "",
                                    DayTitle = reader["DayTitle"]?.ToString(),
                                    PlaceOfVisit = reader["PlaceOfVisit"]?.ToString(),
                                    MealPlan = reader["MealPlan"]?.ToString(),
                                    NightHalt = reader["NightHalt"]?.ToString()
                                });
                            }

                            // Move to next result set
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    lMealPlan.Add(new MealPlan
                                    {
                                        DayNo = reader["DayNo"] != DBNull.Value ? Convert.ToInt32(reader["DayNo"]) : 0,
                                        MealType = reader["MealType"]?.ToString()
                                    });
                                }
                            }
                        }
                    }
                }

                // Build HTML
                if (lTourItinerary != null && lTourItinerary.Count > 0)
                {
                    StringBuilder lItinerary = new StringBuilder();
                    string pHDRItinerary = "<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"1\" style=\"font-family:Arial; font-size:12px;\">" +
                        "<tr>" +
                        "<td align=\"center\" width=\"5%\"><b>Day No</b></td>" +
                        "<td align=\"center\" width=\"10%\"><b>Time</b></td>" +
                        "<td align=\"center\" width=\"10%\"><b>Day Title</b></td>" +
                        "<td align=\"center\" width=\"55%\"><b>Itinerary</b></td>" +
                        "<td align=\"center\" width=\"10%\"><b>Meal Plan</b></td>" +
                        "<td align=\"center\" width=\"10%\"><b>Night Halt</b></td>" +
                        "</tr>";

                    lItinerary.Append(pHDRItinerary);

                    string pItineraryTemplate = "<tr>" +
                        "<td align=\"center\" width=\"5%\">#Day</td>" +
                        "<td align=\"center\" width=\"10%\">#Time</td>" +
                        "<td align=\"left\" width=\"20%\">#Title</td>" +
                        "<td align=\"left\" width=\"45%\">#Itinerary</td>" +
                        "<td align=\"left\" width=\"10%\">#MealPlan</td>" +
                        "<td align=\"center\" width=\"10%\">#NightHalt</td></tr>";

                    foreach (var item in lTourItinerary)
                    {
                        string lTemp = pItineraryTemplate;
                        lTemp = lTemp.Replace("#Day", item.DayNo.ToString())
                                     .Replace("#Time", item.ItineraryTime)
                                     .Replace("#Title", item.DayTitle)
                                     .Replace("#Itinerary", item.PlaceOfVisit)
                                     .Replace("#MealPlan", item.MealPlan)
                                     .Replace("#NightHalt", item.NightHalt);
                        lItinerary.Append(lTemp);
                    }

                    lItinerary.Append("</table>");
                    ltrIten.InnerHtml = lItinerary.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it)
                ltrIten.InnerHtml = "<p style='color:red;'>Error loading itinerary.</p>";
            }
        }

        #endregion
    }
}