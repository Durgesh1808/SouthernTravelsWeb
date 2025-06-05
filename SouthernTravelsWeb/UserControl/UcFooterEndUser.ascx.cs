using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcFooterEndUser : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        protected static string ReCaptcha_KeyFooter = System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Sitekey"];
        protected static string ReCaptcha_SecretFooter = System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Secretkey"];
        protected static string baseurlFooter = System.Configuration.ConfigurationManager.AppSettings["SouthernBasePathWithoutHttps"];
        #endregion

        #region "Property(s)"

        #endregion

        #region "Event(s)"

        protected void Page_Load(object sender, EventArgs e)
        {
            txtDeparturedate.Attributes.Add("readonly", "readonly");
            txtArrivaldate.Attributes.Add("readonly", "readonly");
            btnSubmitDe.Attributes.Add("onclick", "javascript:return Valid();");
        }

        #endregion

        #region "Method(s)"

        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
        }
        protected void btnSubmitDe_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["CaptchaImageText"]) == Convert.ToString(txtCaptcha.Text.Trim()))
            {
                string refno = DataLib.Code("QIKENQ");

                string sPlan = txtShortDescription.Text;
                string sName = txtName.Text;

                string sEmail = refno + "@temp.com";
                if (txtEmail.Text != "")
                {
                    sEmail = txtEmail.Text;
                }
                string sPhone = txtMobile.Text;

                string sStreet = "";

                string mStreet = "";
                string sCity = txtCity.Text;
                string sZip = "";
                string sCountry = "";
                int strAdults = 0;
                int strChild = 0;
                int Val = clsBLL.EnquiryTable_Entry(sPlan, sName, sEmail, sPhone, "", sStreet, sCity, sZip, sCountry,
                    strAdults, strChild, Convert.ToDateTime("01/01/1900"), Convert.ToDateTime("01/01/1900"), "QIKENQ", refno, "");


                // ================================= Mail Format Start Here ==============================
                string mailbody = "<table width=\"350\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" ";
                mailbody += " style='border-style: solid;border-color: Black; border-width: 1px;'>"; ;
                mailbody += "<tr><td><table width=\"350\" align=\"center\"><tr><td><table width=\"100%\"><tr><td align=\"center\"><img src=\"https://www.southerntravelsindia.com/Assets/images/southern-travel.gif\" >";
                mailbody += "</td></tr> <tr><td height=\"20\"></td></tr><tr><td><table width=\"94%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\">";
                mailbody += "<tr><td align=\"left\" style=\"height: 16px; background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif;color: #333333; padding: 0; margin: 0; text-align: justify;\">";
                mailbody += "Dear Executive,</td> </tr> <tr><td height=\"10\"> </td>  </tr> <tr> <td align=\"left\" style=\"height: 32px; background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif;color: #333333; padding: 0; margin: 0; text-align: justify;\">";
                mailbody += "One valued Customer has put a quick enquiry, for which he / she has provided the relative details as below. Please help him / her regarding the query.";
                mailbody += " </td></tr> <tr> <td height=\"10\"> </td></tr> <tr> <td height=\"1\" bgcolor=\"#cccccc\" align = center>Customer Detail</td><tr> <td height=\"10\">";
                mailbody += "<table width=\"94%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"background-repeat: no-repeat\">";

                mailbody += "<tr>";
                mailbody += "<td width=\"50%\" align=\"left\" height=\"10\"><span style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif; color: #333333; padding: 0; margin: 0; text-align: justify; color: #df411a!important;\">";
                mailbody += "<b>Full Name :</b>";
                mailbody += "</span><td width=\"50%\" height=\"10\" style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif;color: #333333; padding: 0; margin: 0; text-align: justify;\">";
                mailbody += txtName.Text;
                mailbody += "</td></tr><tr>";
                mailbody += "<td width=\"50%\" align=\"left\"><span style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif;color: #333333; padding: 0; margin: 0; text-align: justify; color: #df411a!important;\">";
                mailbody += "<b>Phone Number:</b></span></td><td width=\"50%\" style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif; color: #333333; padding: 0; margin: 0; text-align: justify;\">";
                mailbody += txtPhone.Text;
                mailbody += "</td></tr>";

                mailbody += "<tr>";
                mailbody += "<td width=\"50%\" align=\"left\" height=\"10\"><span style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif; color: #333333; padding: 0; margin: 0; text-align: justify; color: #df411a!important;\">";
                mailbody += "<b>Email :</b>";
                mailbody += "</span><td width=\"50%\" height=\"10\" style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif;color: #333333; padding: 0; margin: 0; text-align: justify;\">";
                mailbody += txtEmail.Text;
                mailbody += "</td></tr><tr>";
                mailbody += "<td width=\"50%\" align=\"left\"><span style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif;color: #333333; padding: 0; margin: 0; text-align: justify; color: #df411a!important;\">";
                mailbody += "<b>City:</b></span></td><td width=\"50%\" style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif; color: #333333; padding: 0; margin: 0; text-align: justify;\">";
                mailbody += txtCity.Text;
                mailbody += "</td></tr>";


                mailbody += "<tr>";
                mailbody += "<td width=\"50%\" align=\"left\" height=\"10\"><span style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif; color: #333333; padding: 0; margin: 0; text-align: justify; color: #df411a!important;\">";
                mailbody += "<b>Arrival Date :</b>";
                mailbody += "</span><td width=\"50%\" height=\"10\" style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif;color: #333333; padding: 0; margin: 0; text-align: justify;\">";
                mailbody += Convert.ToDateTime(ClsCommon.mmddyy2ddmmyy(txtArrivaldate.Text)).ToString("dd MMM yyyy");
                mailbody += "</td></tr><tr>";
                mailbody += "<td width=\"50%\" align=\"left\"><span style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif;color: #333333; padding: 0; margin: 0; text-align: justify; color: #df411a!important;\">";
                mailbody += "<b>Departure Date:</b></span></td><td width=\"50%\" style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif; color: #333333; padding: 0; margin: 0; text-align: justify;\">";
                mailbody += Convert.ToDateTime(ClsCommon.mmddyy2ddmmyy(txtDeparturedate.Text)).ToString("dd MMM yyyy");
                mailbody += "</td></tr>";

                mailbody += "<tr>";
                mailbody += "<td width=\"25%\" align=\"left\" height=\"10\"><span style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif; color: #333333; padding: 0; margin: 0; text-align: justify; color: #df411a!important;\">";
                mailbody += "<b>Description :</b>";
                mailbody += "</span><td colspan=\"3\" width=\"75%\" height=\"10\" style=\"background: #ffffff; font-size: 12px; font-family: Trebuchet MS, Tahoma, Arial, Helvetica, sans-serif;color: #333333; padding: 0; margin: 0; text-align: justify;\">";
                mailbody += txtShortDescription.Text;
                mailbody += "</td></tr></table>";


                mailbody += "</td></tr></tr></table></td></tr></table></td></tr></table></td></tr></table>";

                btnSubmitDe.Visible = false;
               MailSend(ConfigurationManager.AppSettings["QIKENQformTO"].ToString(), ConfigurationManager.AppSettings["GenEnquiryformBCC"].ToString(),
                  "", sEmail, refno + ": Enquiry detail ( " + ddlInterested.SelectedItem.Text + " )", mailbody, sEmail);
                Clear();
                ScriptManager.RegisterStartupScript(this, GetType(), "response", "alert('Thanks for your enquiry. our executive be contacting you very soon.');", true);
                //}
                txtCaptcha.Text = "";
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
        private void MailSend(string pTO, string pBCC, string pCC, string pFrom, string pSubject, string pBody, string pFromName)
        {
            try
            {
                //Add TLS 1.2
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(3072);
                MailStatus statusEnum = MailStatus.Sent; // or MailStatus.Failed if caught in catch
                MailRequestFrom requestFromEnum = MailRequestFrom.Website;
                string errorMessage = "";
                //ClsCommon clsCommon = new ClsCommon();
                System.Net.Mail.MailMessage lMail = null;
                SmtpClient lSmtp = null;
                try
                {
                    lMail = new System.Net.Mail.MailMessage();
                    lSmtp = new SmtpClient();
                    lSmtp.UseDefaultCredentials = false;
                    lMail.From = new MailAddress(ConfigurationManager.AppSettings["SupportEmail"]);//pFrom
                    lMail.To.Add(pTO);
                    //lMail.CC.Add(pFrom);
                    lMail.Subject = pSubject;
                    lMail.IsBodyHtml = true;
                    lMail.Body = pBody;
                    lMail.ReplyTo = new MailAddress(pFromName);
                    string smtpEmail = "";
                    string smtpPassword = "";
                    smtpEmail = ConfigurationSettings.AppSettings["support@southerntravels.com".ToLower() + "_UserName"].ToString();//"etickets@southerntravels.in";//ConfigurationSettings.AppSettings["SmtpUserName"].ToString();"enquiry@southerntravels.com";
                    smtpPassword = ConfigurationSettings.AppSettings["support@southerntravels.com".ToLower() + "_Password"].ToString(); ;

                    string smtpAddress = ConfigurationSettings.AppSettings["AuthMailSmtpIP"].ToString();//"smtp.gmail.com";
                    string smtpPort = ConfigurationSettings.AppSettings["AuthMailSmtpPort"].ToString(); ;
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
                    ClsCommon.LogEmailToDB(0, pFrom, pTO, pCC, pBCC, pSubject, pBody, statusEnum.ToString(), errorMessage, "", "", requestFromEnum.ToString());

                }
                catch (Exception ex)
                {
                    statusEnum = MailStatus.Failed;
                    errorMessage = ex.ToString();
                    ClsCommon.LogEmailToDB(0, pFrom, pTO, pCC, pBCC, pSubject, pBody, statusEnum.ToString(), errorMessage, "", "", requestFromEnum.ToString());
                    Response.Write(ex.Message);
                }
                finally
                {
                    //ClsCommon.LogEmailToDB(0, pFrom, pTO, pCC, pBCC, pSubject, pBody, statusEnum.ToString(), errorMessage, "", "", requestFromEnum.ToString());
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

        private void Clear()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtCity.Text = "";
            txtDeparturedate.Text = "";
            txtArrivaldate.Text = "";
            ddlInterested.SelectedIndex = -1;
            txtShortDescription.Text = "";
            btnSubmitDe.Visible = true; ;
        }


            
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

        //[WebMethod]
        //public static string VerifyCaptcha(string response)
        //{
        //    string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + ReCaptcha_Secret + "&response=" + response;
        //    return (new WebClient()).DownloadString(url);
        //}
    }
}