using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class HotelRegistration : System.Web.UI.Page
    {

        #region "Private Variable"

        #endregion

        #region "Page Events"
        protected void Page_Load(object sender, EventArgs e)
        {
            //divrecaptcha.Attributes.Add("data-sitekey", System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Sitekey"]);

            this.btnSubmit.Attributes.Add("onclick", "javascript:return fnHotelVal();");
            if (!IsPostBack)
            {
                BindState();
            }

            if (ddlVendorType.SelectedValue.ToLower() == "chain")
            {
                divChain.Style.Add("visibility", "visible");
            }
            else
            {
                divChain.Style.Add("visibility", "hidden");
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            //bool lFlag = reCaptcha();
            //if (!lFlag)
            //{
            //    return;
            //}
            if (Convert.ToString(Session["CaptchaImageText"]) == Convert.ToString(txtCaptcha.Text.Trim()))
            {

                string vendorType = ddlVendorType.SelectedValue;
                string ChainName = txtChainName.Text.Trim();
                string HotelName = txtHotelName.Text.Trim();

                Decimal Tax = ConvertStringDecimal(txtTax.Text.Trim());
                Decimal LuxuryTax = ConvertStringDecimal(txtLuxuryTax.Text.Trim());
                Decimal ServiceTax = ConvertStringDecimal(txtServiceTax.Text.Trim());

                string Address = txtAddress.Text.Trim();
                string StdCode = txtStdCode.Text.Trim();
                string PhoneNO = txtHotelPhoneNo.Text.Trim();
                string Mobile = txtMobile.Text.Trim();
                string ContactPerson = txtContactPerson.Text.Trim();

                string Designation = txtDesignation.Text.Trim();
                string Email = txtEmailId.Text.Trim();
                string PanNO = txtPanNo.Text.Trim();
                string Category = ddlCategory.SelectedValue;

                int NoOfRoom = ConvertStringToInt(txtNOOfRooms.Text.Trim());
                int State = ConvertStringToInt(ddlState.SelectedValue);
                string City = txtCity.Text.Trim().Trim();
                string GeneralIfo = txtGeneralInfo.Text.Trim().Trim();

                int Status = SaveVendorHotel(vendorType, ChainName, HotelName, Tax, LuxuryTax,
                    ServiceTax, Address, StdCode, PhoneNO,
                    Mobile, ContactPerson, Designation, Email, PanNO, Category, NoOfRoom, State,
                   City, GeneralIfo);

                if (Status > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Save", "<script>alert('Your query has been submitted successfully. Our executive will soon be in touch with you.');</Script>");
                    SendMeailToSouthern(Status);
                    SendMeailToVendor(Status);
                    Clear();
                }
                else if (Status == -2)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Save", "<script>alert('Your email id is already registered. Please try with some other email id');</Script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Save", "<script>alert('Please try again.');</Script>");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCaptcha.Text))
                {
                    ClsCommon.ShowAlert("Please Enter Valid Captcha");
                    //string script = "Swal.fire({ icon: 'warning', title: 'Oops...', text: 'Please Enter Valid Captcha..', timer: 3000,confirmButtonColor: '#f2572b' });";
                    //ClientScript.RegisterStartupScript(this.GetType(), "swalWarning", script, true);
                    return;
                }
                else
                {
                    ClsCommon.ShowAlert("Please Enter  Captcha");
                    //string script = "Swal.fire({ icon: 'warning', title: 'Oops...', text: 'Please Enter  Captcha..', timer: 3000,confirmButtonColor: '#f2572b' });";
                    //ClientScript.RegisterStartupScript(this.GetType(), "swalWarning", script, true);
                    return;
                }
            }

        }
        #endregion

        #region "Page Methods"
        private void BindState()
        {
            try
            {
                clsAdo clsAdo = new clsAdo();
                ddlState.DataSource = clsAdo.fnGetState();
                ddlState.DataTextField = "State";
                ddlState.DataValueField = "RowID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("State", "0"));
            }
            catch (Exception ex)
            {

            }
            finally
            {
               
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
        public decimal ConvertStringDecimal(string IntString)
        {
            decimal decval = 0;
            if (string.IsNullOrEmpty(IntString))
            {
                decval = 0;
            }
            else
            {
                try
                {
                    decval = Convert.ToDecimal(IntString);
                }
                catch (Exception ex)
                {
                    decval = 0;
                }

            }
            return decval;
        }

        private void SendMeailToSouthern(int Hotelid)
        {

            StringBuilder strTable = new StringBuilder();
            strTable.Append(System.IO.File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["mailerTemplatesPath"].ToString() +
                "\\HotelRegistationSouthern.htm")));

            string SouthernemailId = ConfigurationManager.AppSettings["VendorHotelRegMail"].ToString();// will be get from web config

            string FromemailId = ConfigurationManager.AppSettings["InfoEmail"];
            string EnquiryNo = GetEqnuiryNo(Hotelid);
            string subject = EnquiryNo + "-" + txtHotelName.Text + "(" + ddlCategory.SelectedValue + ") Registration";

            strTable = strTable.Replace("#VerndorName", txtContactPerson.Text);
            strTable = strTable.Replace("#Category", ddlCategory.SelectedValue);
            strTable = strTable.Replace("#VendorType", ddlVendorType.SelectedValue);
            strTable = strTable.Replace("#ChainName", txtChainName.Text);

            strTable = strTable.Replace("#HotelName", txtHotelName.Text);
            strTable = strTable.Replace("#ContactPerson", txtContactPerson.Text);
            strTable = strTable.Replace("#Designation", txtDesignation.Text);
            strTable = strTable.Replace("#Email", txtEmailId.Text);
            strTable = strTable.Replace("#Mobile", txtMobile.Text);
            strTable = strTable.Replace("#State", ddlState.SelectedItem.Text);
            strTable = strTable.Replace("#City", txtCity.Text);
            strTable = strTable.Replace("#Address", txtAddress.Text);
            strTable = strTable.Replace("#GeneralInfo", txtGeneralInfo.Text);

            try
            {
                ClsCommon.sendmail(SouthernemailId, "", "", FromemailId, subject, strTable.ToString(), FromemailId);
                //  MailSend(txtEmailId.Text, "", "", FromemailId, subject, strTable.ToString(), "enquiry@southerntravels.in");
            }
            catch (Exception ex)
            {
            }

        }
        private void SendMeailToVendor(int HotelId)
        {
            StringBuilder strTable = new StringBuilder();
            strTable.Append(System.IO.File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["mailerTemplatesPath"].ToString() +
                 "\\HotelRegistationVendor.htm")));

            strTable = strTable.Replace("#VendorName", txtContactPerson.Text);

            string FromemailId = ConfigurationManager.AppSettings["InfoEmail"];
            string EnquiryNo = GetEqnuiryNo(HotelId);
            string subject = EnquiryNo + "-" + txtHotelName.Text + "(" + ddlCategory.SelectedValue + ") " + "Registration In Southern";
            try
            {
                ClsCommon.sendmail(txtEmailId.Text, "", "", FromemailId, subject, strTable.ToString(), FromemailId);
                // MailSend(txtEmailId.Text, "", "", FromemailId, subject, strTable.ToString(), txtEmailId.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private string GetEqnuiryNo(int HotelId)
        {
            string zero = "000000";
            string HotelEnquiryString = "HTLREGEN";
            int Len = Convert.ToString(HotelId).Length;
            HotelEnquiryString = HotelEnquiryString + zero.Substring(0, 6 - Len) + Convert.ToString(HotelId);
            return HotelEnquiryString;
        }
        private void Clear()
        {
            ddlVendorType.SelectedValue = "";
            txtChainName.Text = "";
            txtHotelName.Text = "";
            txtTax.Text = "";
            txtLuxuryTax.Text = "";
            txtServiceTax.Text = "";
            txtAddress.Text = "";
            txtStdCode.Text = "";
            txtHotelPhoneNo.Text = "";
            txtDesignation.Text = "";
            txtEmailId.Text = "";
            txtPanNo.Text = "";
            txtNOOfRooms.Text = "";
            txtPanNo.Text = "";
            txtCity.Text = "";
            ddlState.SelectedValue = "0";
            txtGeneralInfo.Text = "";
            txtMobile.Text = "";
            ddlCategory.SelectedValue = "";
            txtContactPerson.Text = "";
            txtCaptcha.Text = "";

        }
        #endregion
        //public bool reCaptcha()
        //{
        //    bool lFlag = false;
        //    //start building recaptch api call
        //    var sb = new System.Text.StringBuilder();
        //    sb.Append("https://www.google.com/recaptcha/api/siteverify?secret=");

        //    //our secret key
        //    var secretKey = System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Secretkey"]; //"6LesfBwTAAAAAPKzkHq9ny59cb_BtZa1D6ZLLBGf";
        //    sb.Append(secretKey);

        //    //response from recaptch control
        //    sb.Append("&");
        //    sb.Append("response=");
        //    var reCaptchaResponse = Request["g-recaptcha-response"];
        //    sb.Append(reCaptchaResponse);

        //    //client ip address
        //    //---- This Ip address part is optional. If you donot want to send IP address you can
        //    //---- Skip(Remove below 4 lines)
        //    sb.Append("&");
        //    sb.Append("remoteip=");
        //    var clientIpAddress = GetUserIp();
        //    sb.Append(clientIpAddress);

        //    //make the api call and determine validity
        //    using (var client = new System.Net.WebClient())
        //    {
        //        var uri = sb.ToString();
        //        var json = client.DownloadString(uri);
        //        var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(RecaptchaApiResponse));
        //        var ms = new System.IO.MemoryStream(System.Text.Encoding.Unicode.GetBytes(json));
        //        var result = serializer.ReadObject(ms) as RecaptchaApiResponse;

        //        //--- Check if we are able to call api or not.
        //        if (result == null)
        //        {
        //            MessageLabel.Text = "Captcha was unable to make the api call";
        //        }
        //        else // If Yes
        //        {
        //            //api call contains errors
        //            if (result.ErrorCodes != null)
        //            {
        //                if (result.ErrorCodes.Count > 0)
        //                {
        //                    foreach (var error in result.ErrorCodes)
        //                    {
        //                        MessageLabel.Text = "Captcha is required.";
        //                    }
        //                }
        //            }
        //            else //api does not contain errors
        //            {
        //                if (!result.Success) //captcha was unsuccessful for some reason
        //                {
        //                    MessageLabel.Text = "Captcha did not pass, please try again.";
        //                }
        //                else //---- If successfully verified. Do your rest of logic.
        //                {
        //                    MessageLabel.Text = "Captcha cleared ";
        //                    lFlag = true;
        //                }
        //            }

        //        }

        //    }
        //    return lFlag;
        //}
        [System.Runtime.Serialization.DataContract]
        public class RecaptchaApiResponse
        {
            [System.Runtime.Serialization.DataMember(Name = "success")]
            public bool Success;

            [System.Runtime.Serialization.DataMember(Name = "error-codes")]
            public System.Collections.Generic.List<string> ErrorCodes;
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
        private void MailSend(string pTO, string pBCC, string pCC, string pFrom, string pSubject, string pBody, string pFromName)
        {
            try
            {
                MailMessage lMail = null;
                SmtpClient lSmtp = null;
                try
                {
                    lMail = new MailMessage();
                    lSmtp = new SmtpClient();
                    lMail.From = new MailAddress(pFrom);
                    lMail.To.Add(pTO);
                    lMail.Subject = pSubject;
                    lMail.IsBodyHtml = true;
                    lMail.Body = pBody;
                    lMail.ReplyTo = new MailAddress(pFromName);
                    string smtpEmail = "";
                    string smtpPassword = "";
                    smtpEmail = "enquiry@southerntravels.in";
                    smtpPassword = "stpl@123";

                    string smtpAddress = "smtp.gmail.com";
                    string smtpPort = "587";
                    if (smtpEmail != "")
                    {
                        lSmtp.Host = smtpAddress;
                        lSmtp.Port = Convert.ToInt32(smtpPort);
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
                    Response.Write(ex.Message);
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


        public int SaveVendorHotel(string pvendorType, string pChainName, string pHotelName, decimal pTax, decimal pLuxuryTax,
    decimal pServiceTax, string pAddress, string pStdCode, string pPhoneNO, string pMobile, string pContactPerson,
    string pDesignation, string pEmail, string pPanNO, string pCategory, int pNoOfRoom, int pState, string pCity, string pGeneralInfo)
        {
            int status = 0;
            string connectionString = DataLib.getConnectionString(); // Use your actual connection string retrieval

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.SaveVendor_Hotel_SP, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add input parameters
                    cmd.Parameters.AddWithValue("@I_VendorType", pvendorType);
                    cmd.Parameters.AddWithValue("@I_ChainName", pChainName);
                    cmd.Parameters.AddWithValue("@I_HotelName", pHotelName);
                    cmd.Parameters.AddWithValue("@I_Tax", pTax);
                    cmd.Parameters.AddWithValue("@I_LuxuryTax", pLuxuryTax);
                    cmd.Parameters.AddWithValue("@I_ServiceTax", pServiceTax);
                    cmd.Parameters.AddWithValue("@I_Address", pAddress);
                    cmd.Parameters.AddWithValue("@I_StdCode", pStdCode);
                    cmd.Parameters.AddWithValue("@I_PhoneNo", pPhoneNO);
                    cmd.Parameters.AddWithValue("@I_Mobile", pMobile);
                    cmd.Parameters.AddWithValue("@I_ContactPerson", pContactPerson);
                    cmd.Parameters.AddWithValue("@I_Designation", pDesignation);
                    cmd.Parameters.AddWithValue("@I_Email", pEmail);
                    cmd.Parameters.AddWithValue("@I_PanNo", pPanNO);
                    cmd.Parameters.AddWithValue("@I_Category", pCategory);
                    cmd.Parameters.AddWithValue("@I_NoOfRoom", pNoOfRoom);
                    cmd.Parameters.AddWithValue("@I_State", pState);
                    cmd.Parameters.AddWithValue("@I_City", pCity);
                    cmd.Parameters.AddWithValue("@I_GeneralInfo", pGeneralInfo);

                    // Add output parameter
                    SqlParameter outputParam = new SqlParameter("@O_Status", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        status = Convert.ToInt32(outputParam.Value);
                    }
                    catch (Exception ex)
                    {
                        status = -1;
                    }
                }
            }

            return status;
        }

    }
}