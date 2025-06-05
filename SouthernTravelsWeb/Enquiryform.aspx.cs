using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class Enquiryform : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //divrecaptcha.Attributes.Add("data-sitekey", System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Sitekey"]);
            if (!IsPostBack)
            {
                if (Request.QueryString["Text"] != null)
                {
                    txtDescription.Value = Request.QueryString["Text"].ToString() + " - ";
                }
                if (Request.QueryString["Type"] != null)
                {
                    for (int i = 0; i < this.ChkInterest.Items.Count; i++)
                    {
                        if (this.ChkInterest.Items[i].Value == "Tour of India" && Request.QueryString["Type"].ToString() == "Tours")
                        {
                            ChkInterest.Items[i].Selected = true;
                        }
                        else if (this.ChkInterest.Items[i].Value == "Car/Coach Rental" && Request.QueryString["Type"].ToString() == "Car")
                        {
                            ChkInterest.Items[i].Selected = true;
                        }
                        else
                        {
                            ChkInterest.Items[i].Enabled = false;
                        }
                    }
                }
            }
        }

        #region commented code


        #endregion

        protected void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (FormIsValid())
                {
                    //bool lFlag = reCaptcha();
                    //if (lFlag)
                    //{
                    if (Convert.ToString(Session["CaptchaImageText"]) == Convert.ToString(txtCaptcha.Text.Trim()))
                    {
                        string refno = DataLib.Code("GenEnq");
                        string sArrivalDate = this.txtarrival.Value.ToString().Replace("'", "''");
                        string sDepDate = this.txtDept.Value.ToString().Replace("'", "''");
                        DateTime Adate, Ddate;
                        if (sDepDate == "")
                            Ddate = DateTime.Today.Date;
                        else
                        {
                            string[] DateArr3 = new string[3];
                            char[] splitter1 = { '/' };
                            DateArr3 = sDepDate.Split(splitter1);
                            Ddate = new DateTime(Convert.ToInt32(DateArr3[2]), Convert.ToInt32(DateArr3[1]),
                                Convert.ToInt32(DateArr3[0]));
                        }
                        if (sArrivalDate == "")
                            Adate = DateTime.Today.Date;
                        else
                        {
                            string[] DateArr3 = new string[3];
                            char[] splitter1 = { '/' };
                            DateArr3 = sArrivalDate.Split(splitter1);
                            Adate = new DateTime(Convert.ToInt32(DateArr3[2]), Convert.ToInt32(DateArr3[1]),
                                Convert.ToInt32(DateArr3[0]));
                        }
                        string sInterest = "", mInterest = "";
                        for (int i = 0; i < this.ChkInterest.Items.Count; i++)
                        {
                            if (this.ChkInterest.Items[i].Selected == true)
                            {
                                sInterest += "," + this.ChkInterest.Items[i].Value.ToString().Split(' ')[0].ToString();
                                mInterest += "," + this.ChkInterest.Items[i].Value.ToString();
                            }
                        }
                        if (sInterest.ToString() != "")
                        {
                            sInterest = sInterest.Trim().TrimEnd(',');
                            mInterest = mInterest.Trim().TrimEnd(',');
                        }
                        sInterest = sInterest.Substring(1, sInterest.Length - 1);

                        mInterest = mInterest.Substring(1, mInterest.Length - 1);

                        string sPlan = DataLib.funClear(txtDescription.Value.ToString());
                        string sName = DataLib.funClear(S_name.Value.ToString());
                        string sEmail = this.S_email.Value.ToString().Replace("'", "''").Replace("--", "");
                        string sPhone = DataLib.funClear(S_phone.Value.ToString());
                        string sFax = DataLib.funClear(S_fax.Value.ToString());

                        string sStreet = DataLib.funClear(S_streetaddress.Value.ToString()) + "#~#" + sInterest;

                        string mStreet = DataLib.funClear(S_streetaddress.Value.ToString());
                        string sCity = DataLib.funClear(S_city.Value.ToString());
                        string sZip = DataLib.funClear(S_pin.Value.ToString());
                        string sCountry = DataLib.funClear(S_country.Value.ToString());
                        int strAdults = Convert.ToInt32(ddlAdults.SelectedValue);
                        int strChild = Convert.ToInt32(ddlChilds.SelectedValue);
                        int Val = clsBLL.EnquiryTable_Entry(sPlan, sName, sEmail, sPhone, sFax, sStreet, sCity, sZip, sCountry,
                            strAdults, strChild, Adate, Ddate, "GenEnq", refno, "");

                        if ((Val == 1) || (Val == 2))
                        {
                        }
                        else
                        {
                            // ================================= Mail Format Start Here ==============================
                            string mailbody = "";
                            mailbody = mailbody + "<br><table width='60%' border='1' cellspacing='1' cellpadding='2' align='center'>";
                            mailbody = mailbody + "<tr><td bgcolor='#CCCCCC' colspan='2'><font face='Verdana' size='-1'><b>Enquiry Details :</b>" + refno + "</font></td>";
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
                            mailbody = mailbody + "<td><font size='-1' face='Verdana'> No. of Adults</font></td>";
                            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + ddlAdults.SelectedValue + " </font></td>";
                            mailbody = mailbody + "</tr>";
                            mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                            mailbody = mailbody + "<td><font size='-1' face='Verdana'> No. of Children </font></td>";
                            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + ddlChilds.SelectedValue + " </font></td>";
                            mailbody = mailbody + "</tr>";
                            mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                            mailbody = mailbody + "<td><font size='-1' face='Verdana'>Interested In</font></td>";
                            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + mInterest + " </font></td>";
                            mailbody = mailbody + "</tr>";
                            mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
                            mailbody = mailbody + "<td><font size='-1' face='Verdana'>Travel Plan / Requirements</font></td>";
                            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + sPlan + " </font></td>";
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
                            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + mStreet + " </font></td>";
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
                            // ================================= Mail Format End Here ==============================

                        

                            MailSend(ConfigurationManager.AppSettings["GenEnquiryformTO"].ToString(), ConfigurationManager.AppSettings["GenEnquiryformBCC"].ToString(),
                              "", sEmail, refno + ": Enquiry details (" + mInterest + " )", mailbody, sEmail);

                            
                            lblMsg.Text = "Thanks for your enquiry. our executive be contacting you very soon.";
                           
                            ClientScript.RegisterStartupScript(GetType(), "response", "<script>alert('Thanks for your enquiry. our executive be contacting you very soon.');</script>");
                            Clear();
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtCaptcha.Text))
                        {
                            //ClsCommon.ShowAlert("Please Enter Valid Captcha");
                            string script = "Swal.fire({ icon: 'warning', title: 'Oops...', text: 'Please Enter Valid Captcha..', timer: 3000,confirmButtonColor: '#f2572b' });";
                            ClientScript.RegisterStartupScript(this.GetType(), "swalWarning", script, true);
                            return;
                        }
                        else
                        {
                            //ClsCommon.ShowAlert("Please Enter  Captcha");
                            string script = "Swal.fire({ icon: 'warning', title: 'Oops...', text: 'Please Enter  Captcha..', timer: 3000,confirmButtonColor: '#f2572b' });";
                            ClientScript.RegisterStartupScript(this.GetType(), "swalWarning", script, true);
                            return;
                        }
                    }

                }
           
            }
        }
        private void MailSend(string pTO, string pBCC, string pCC, string pFrom, string pSubject, string pBody, string pFromName)
        {
            MailStatus statusEnum = MailStatus.Sent; // or MailStatus.Failed if caught in catch
            MailRequestFrom requestFromEnum = MailRequestFrom.Website;
            string errorMessage = "";
            try
            {
                string smtpEmail = ConfigurationManager.AppSettings["EnquiryEmailIn"];
                string smtpPassword = ConfigurationManager.AppSettings["EnquiryEmailInPassword"];
                string smtpAddress = ConfigurationManager.AppSettings["AuthMailSmtpIP"];
                int smtpPort = int.Parse(ConfigurationManager.AppSettings["AuthMailSmtpPort"]);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(pFrom, pFromName);
                mail.To.Add(pTO);
                if (!string.IsNullOrEmpty(pCC)) mail.CC.Add(pCC);
                if (!string.IsNullOrEmpty(pBCC)) mail.Bcc.Add(pBCC);
                mail.Subject = pSubject;
                mail.Body = pBody;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient(smtpAddress, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpEmail, smtpPassword),
                    EnableSsl = true
                };

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                statusEnum = MailStatus.Failed;
                errorMessage = ex.ToString();
               ClsCommon.LogEmailToDB(0, pFrom, pTO, pCC, pBCC, pSubject, pBody, statusEnum.ToString(), errorMessage, "", "", requestFromEnum.ToString());

                // Consider logging the error
            }
            finally
            {
                ClsCommon.LogEmailToDB(0, pFrom, pTO, pCC, pBCC, pSubject, pBody, statusEnum.ToString(), errorMessage, "", "", requestFromEnum.ToString());
            }
        }
        private bool FormIsValid()
        {
            int count = 0;
            bool ret = false;
            for (int j = 0; j < ChkInterest.Items.Count; j++)
            {
                if (ChkInterest.Items[j].Selected == true)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                lblMsgTour.Text = "Select tour of your choice";
                ret = false;
                string script = "Swal.fire({ icon: 'warning', title: 'Oops...', text: 'Select tour of your choice..', timer: 3000,confirmButtonColor: '#f2572b' });";
                ClientScript.RegisterStartupScript(this.GetType(), "swalWarning", script, true);
                //ClientScript.RegisterStartupScript(GetType(), "response", "<script>alert('Select tour of your choice.');</script>");
            }
            else
            {
                ret = true;
                lblMsgTour.Text = string.Empty;
            }
            return ret;

        }

        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            S_name.Value = "";
            S_email.Value = ""; ;
            S_phone.Value = "";
            S_fax.Value = "";
            S_streetaddress.Value = "";
            S_city.Value = "";
            S_pin.Value = "";
            S_country.Value = "";
            ddlAdults.SelectedIndex = -1;
            ddlChilds.SelectedIndex = -1;
            txtDescription.Value = "";
            txtDept.Value = "";
            txtarrival.Value = "";
            ChkInterest.SelectedIndex = -1;
            txtCaptcha.Text = "";
        }

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
    }
}