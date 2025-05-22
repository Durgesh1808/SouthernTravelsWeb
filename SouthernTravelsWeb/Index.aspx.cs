using SouthernTravelsWeb.BLL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
namespace SouthernTravelsWeb
{
    public partial class Index1 : System.Web.UI.Page
    {
        public string strSliderItems = string.Empty;
        public string strHomePageBanner = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmitPop_Click(object sender, EventArgs e)
        {


            if (Convert.ToString(Session["CaptchaImageText"]) == Convert.ToString(txtCaptcha.Text.Trim()))
            {
                string refno = DataLib.Code("QIKENQ");

                string sPlan = "";// txtShortDescription.Text;
                string sName = txtName.Text;

                string sEmail = refno + "@temp.com";
                if (txtEmail.Text != "")
                {
                    sEmail = txtEmail.Text;
                }
                string sPhone = txtPhone.Text;

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
                mailbody += "<tr><td><table width=\"350\" align=\"center\"><tr><td><table width=\"100%\"><tr><td align=\"center\"><img src=\"http://www.southerntravelsindia.com/Assets/images/southern-travel.gif\" >";
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
                mailbody += "</table>";


                mailbody += "</td></tr></tr></table></td></tr></table></td></tr></table></td></tr></table>";

                btnSubmitPop.Visible = false;
                MailSend(ConfigurationManager.AppSettings["QIKENQformTO"].ToString(), ConfigurationManager.AppSettings["GenEnquiryformBCC"].ToString(),
                  "", sEmail, refno + ": Enquiry detail ( " + txtName.Text + " )", mailbody, sEmail);
                Clear();
                //ScriptManager.RegisterStartupScript(this, GetType(), "response", "alert('Thanks for your enquiry. our executive be contacting you very soon.');", true);
                //}
                txtCaptcha.Text = "";
                Response.Redirect("ThankYou.aspx?PrevPage=Index&ThankYouMsg=Thanks for your enquiry. Our executive be contacting you very soon.");
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

                System.Net.Mail.MailMessage lMail = null;
                SmtpClient lSmtp = null;
                try
                {
                    lMail = new System.Net.Mail.MailMessage();
                    lSmtp = new SmtpClient();
                    lSmtp.UseDefaultCredentials = false;
                    lMail.From = new MailAddress("support@southerntravels.com");//pFrom
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
        private void Clear()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtCity.Text = "";
            btnSubmitPop.Visible = true; ;
        }
        private void GetHomePageBanners()
        {
            DataSet ds = new DataSet();
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            SqlDataAdapter adp = null;
            try
            {
                #region Home Page Banner
                String strCn = System.Configuration.ConfigurationManager.AppSettings["southernconn"];
                using (lConn = new SqlConnection(strCn))
                {
                    using (lCommand = new SqlCommand("Get_HomePageBanner", lConn))
                    {
                        //lCommand = new SqlCommand("Get_HomePageBanner", lConn);
                        lCommand.CommandTimeout = 20 * 1000;
                        lCommand.CommandType = CommandType.StoredProcedure;
                        lCommand.Parameters.AddWithValue("@Action", "select");
                        lCommand.Parameters.AddWithValue("@ImgType", "HM");
                        adp = new SqlDataAdapter(lCommand);
                        adp.Fill(ds);
                    }
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    strHomePageBanner += "<a href = '" + Convert.ToString(dr["ImgWebURL"]) + "'><img src='Assets/images/" + Convert.ToString(dr["Img"]) + "' alt='" + Convert.ToString(dr["ImgAlt"]) + "' CssClass='popup__img' Height='600px'></a>";
                    //ImgHmBanner.AlternateText = Convert.ToString(dr["ImgAlt"]);
                    //Live
                    //ImgHmBanner.Src = Server.MapPath("..\\images\\") + Convert.ToString(dr["Img"]);
                    //Local
                    //ImgHmBanner.ImageUrl = "Assets/images/" + Convert.ToString(dr["Img"]);
                    ViewState["HM"] = 1; HdnHM.Value = "1";
                }
                #endregion

                #region Home Page Slider
                ds = new DataSet();
                using (lConn = new SqlConnection(strCn))
                {
                    using (lCommand = new SqlCommand("Get_HomePageBanner", lConn))
                    {
                        //lCommand = new SqlCommand("Get_HomePageBanner", lConn);
                        lCommand.CommandTimeout = 20 * 1000;
                        lCommand.CommandType = CommandType.StoredProcedure;
                        lCommand.Parameters.AddWithValue("@Action", "select");
                        lCommand.Parameters.AddWithValue("@ImgType", "SL");
                        adp = new SqlDataAdapter(lCommand);
                        adp.Fill(ds);
                    }
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    strSliderItems += "<div class='item'> <a href = '" + Convert.ToString(dr["ImgWebURL"]) + "'><img src='Assets/images/hero-slider/" + Convert.ToString(dr["Img"]) + "' alt='" + Convert.ToString(dr["ImgAlt"]) + "'></a></div>";
                }
                #endregion
            }
            catch (Exception ex) { ex.ToString(); }
            finally { ds = null; }

        }
    }
}