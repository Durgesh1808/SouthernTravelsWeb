using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class AgentRegistrationEnq : System.Web.UI.Page
    {
        protected string dtDOB;
        protected string dtDOB1;
        protected void Page_Load(object sender, EventArgs e)
        {
            divrecaptcha.Attributes.Add("data-sitekey", System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Sitekey"]);
            //btnSend.Attributes.Add("onclick", "return validate();");

            txtfax.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
            txtmobile.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
            txtphone.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
            txtpin.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");

            this.txtlastname.Attributes.Add("onKeyPress", "return CheckOnlyCharacter(event);");
            this.txtfirstname.Attributes.Add("onKeyPress", "return CheckOnlyCharacter(event);");
            this.txtcity.Attributes.Add("onKeyPress", "return CheckOnlyCharacter(event);");

            dtDOB = this.txtdob.Value.ToString().Replace("'", "''");

            if (dtDOB == "")
            {
                dtDOB1 = Convert.ToDateTime(System.DateTime.Now.Date).AddDays(-0).ToShortDateString();
                txtdob.Value = ClsCommon.mmddyy2ddmmyy(dtDOB1);
            }
            else
                dtDOB1 = Convert.ToDateTime(ClsCommon.mmddyy2ddmmyy(dtDOB)).ToShortDateString();
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            bool lFlag = reCaptcha();
           
            if (lFlag)
            {
                string refno = DataLib.Code("AGTENQ");
                int Val = clsBLL.EnquiryTable_Entry("Agent Details:" + refno, DataLib.funClear(txtfirstname.Text) + " " + DataLib.funClear(txtlastname.Text), txtemail.Text.Replace("'", "''").Replace("--", ""),
                    DataLib.funClear(txtmobile.Text), "", DataLib.funClear(txtaddress.Text), DataLib.funClear(txtcity.Text), "0", ddlcountry.Value.ToString(),
                    0, 0, DateTime.Today.Date, DateTime.Today.Date, "AGTENQ", refno, "", txtPanNo.Text);
                if ((Val == 1) || (Val == 2))
                {
                    clear();
                }
                else
                {
                    SnedMail(refno);
                    ClientScript.RegisterStartupScript(typeof(string), "status", "<script>alert('Request send Successfully ');</script>");
                    
                    clear();
                }
            }
           
        }
        private void SnedMail(string refno)
        {
            try
            {
                string mailbody = "";
                mailbody += "<font size='3' face='Arial, Helvetica, sans-serif'><strong>Agent Details <br></strong></font>";
                mailbody += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                mailbody += "<tr bgcolor='#FFFFE1'>";
                mailbody += "<td width='25%'><font size='2' face='Arial, Helvetica, sans-serif'>Name</font></td>";
                mailbody += "<td width='75%'><font size='2' face='Arial, Helvetica, sans-serif'>" + txtfirstname.Text + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFDFFF'>";
                mailbody += "<td> <font size='2' face='Arial, Helvetica, sans-serif'>Lastname </font>  </td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + txtlastname.Text + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFFFE1'>";
                mailbody += "<td>  <font size='2' face='Arial, Helvetica, sans-serif'>DOB</font> <br></td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + txtdob.Value.ToString() + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFDFFF'>";
                mailbody += "<td>  <font size='2' face='Arial, Helvetica, sans-serif'>Address </font> <br></td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + txtaddress.Text + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFFFE1'>";
                mailbody += "<td>  <font size='2' face='Arial, Helvetica, sans-serif'>City </font> <br></td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + txtcity.Text + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFDFFF'>";
                mailbody += "<td>  <font size='2' face='Arial, Helvetica, sans-serif'>Country </font> <br></td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + ddlcountry.Value + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFFFE1'>";
                mailbody += "<td> <font size='2' face='Arial, Helvetica, sans-serif'>Phone No </font>  </td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + txtphone.Text + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFDFFF'>";
                mailbody += "<td> <font size='2' face='Arial, Helvetica, sans-serif'>Mobile No </font>  </td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + txtmobile.Text + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFFFE1'>";
                mailbody += "<td> <font size='2' face='Arial, Helvetica, sans-serif'>E-mail </font>  </td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + txtemail.Text + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFDFFF'>";
                mailbody += "<td> <font size='2' face='Arial, Helvetica, sans-serif'>AuthorityMember </font>  </td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + ddlauthority.Value + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFFFE1'>";
                mailbody += "<td> <font size='2' face='Arial, Helvetica, sans-serif'>Pan No </font>  </td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + txtPanNo.Text + "</font></td>";
                mailbody += "</tr>";
                mailbody += "<tr bgcolor='#FFDFFF'>";
                mailbody += "<td> <font size='2' face='Arial, Helvetica, sans-serif'>Description </font>  </td>";
                mailbody += "<td><font size='2' face='Arial, Helvetica, sans-serif'>" + txtDescription.Text + "</font></td>";
                mailbody += "</tr>";
                mailbody += "</table>";

                string Toemail = ConfigurationManager.AppSettings["agentRegistrationMails"].ToString();
                ClsCommon.sendmail(Toemail, "", "", "enquiry@southerntravels.in", refno + ": Agent Registration Request", mailbody.ToString(), txtemail.Text);

                Toemail = ConfigurationManager.AppSettings["agentregform"].ToString();
                mailbody = "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                mailbody += "<tr>";
                mailbody += "<td width='100%'><font size='2' face='Arial, Helvetica, sans-serif'>Dear " + txtfirstname.Text + " " + txtlastname.Text +
                    "</font></td></tr>" +
                    "<tr>" +
                    "<td width='100%'><font size='2' face='Arial, Helvetica, sans-serif'>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Greetings of the Day!!!" +
                    "</font></td></tr>" +
                    "<tr>" +
                    "<td width='100%'><font size='2' face='Arial, Helvetica, sans-serif'>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;We request you to fill in the attached " +
                    "form and revert back to us to initiate the process of your Agency request." +
                    "</font></td></tr>" +
                    "<tr>" +
                    "<td width='100%'><font size='2' face='Arial, Helvetica, sans-serif'>" +
                    "Regards" +
                    "</font></td></tr>" +
                    "<tr>" +
                    "<td width='100%'><font size='2' face='Arial, Helvetica, sans-serif'>" +
                    "Krishna Chaitanya" +
                    "</font></td></tr>" +
                    "<tr>" +
                    "<td width='100%'><font size='2' face='Arial, Helvetica, sans-serif'>" +
                    "Manager - IT" +
                    "</font></td></tr>" +
                    "<tr>" +
                    "<td width='100%'><font size='2' face='Arial, Helvetica, sans-serif'>" +
                    "Ph : +91 9350279226 | +91 11 43532868" +
                    "</font></td></tr>";
                mailbody += "</tr>";
                mailbody += "</table>";

                ClsCommon.sendmail(txtemail.Text, Toemail, "", "enquiry@southerntravels.in", refno + ": Agent Registration Request", mailbody.ToString(), "", Server.MapPath("Common/OnlineAgencyProfileRequest.doc"));
            }
            catch (Exception ex)
            {
                Response.Write("<!-- " + ex.ToString() + " -->");
            }
        }
        private void clear()
        {
            this.RadioButtonList2.SelectedIndex = -1;
            this.ddlauthority.SelectedIndex = -1;
            this.ddlstate.SelectedIndex = -1;
            this.ddlcountry.SelectedIndex = -1;
            this.MessageLabel.Text = "";
         
        }
        public void AuthMail(string pTO, string pBCC, string pCC, string pFrom, string pSubject, string pBody, string pFromName, string pFileName)
        {
            System.Web.Mail.MailMessage sendMail = null;
            try
            {
                sendMail = new System.Web.Mail.MailMessage();
                sendMail.To = pTO;
                if (pBCC != null && pBCC != "")
                    sendMail.Bcc = pBCC;
                if (pCC != null && pCC != "")
                    sendMail.Cc = pCC;
                sendMail.From = pFrom;
                sendMail.Subject = pSubject;
                sendMail.BodyFormat = System.Web.Mail.MailFormat.Html;
                sendMail.Body = pBody;

                System.Web.Mail.MailAttachment lAttachment = new System.Web.Mail.MailAttachment(pFileName);
                sendMail.Attachments.Add(lAttachment);

                string smtpEmail = ConfigurationSettings.AppSettings[pFrom.ToLower() + "_UserName"].ToString();//"etickets@southerntravels.in";//ConfigurationSettings.AppSettings["SmtpUserName"].ToString();
                string smtpPassword = ConfigurationSettings.AppSettings[pFrom.ToLower() + "_Password"].ToString(); //"etickets123";
                string smtpAddress = ConfigurationSettings.AppSettings["AuthMailSmtpIP"].ToString();//"smtp.gmail.com";
                string smtpPort = ConfigurationSettings.AppSettings["AuthMailSmtpPort"].ToString();// "465";//ConfigurationSettings.AppSettings["SmtpPort"].ToString();
                if (smtpEmail != "")
                {
                    sendMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                    sendMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpAddress);
                    sendMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", smtpPort);
                    sendMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                    sendMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpEmail);
                    sendMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword);
                    sendMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "True");
                }
                else
                {
                    System.Web.Mail.SmtpMail.SmtpServer = smtpAddress;
                }


                System.Web.Mail.SmtpMail.Send(sendMail);
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                if (sendMail != null)
                {
                    sendMail = null;
                }
            }
        }
        public bool reCaptcha()
        {
            bool lFlag = false;
            //start building recaptch api call
            var sb = new System.Text.StringBuilder();
            sb.Append("https://www.google.com/recaptcha/api/siteverify?secret=");

            //our secret key
            var secretKey = System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Secretkey"]; //"6LesfBwTAAAAAPKzkHq9ny59cb_BtZa1D6ZLLBGf";
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
            public bool Success;

            [DataMember(Name = "error-codes")]
            public List<string> ErrorCodes;
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