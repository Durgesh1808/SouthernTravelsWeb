using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class contact_us : System.Web.UI.Page
    {

        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            //divrecaptcha.Attributes.Add("data-sitekey", System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Sitekey"]);
            txtMobile.Attributes.Add("onkeypress", "return chkNumeric(event);");
            btnSend.Attributes.Add("onclick", "javascript:return fnFeedbackVal();");
            if (!IsPostBack)
            {
                SetSearchSection();
                FillBranchDetails();
                /*((HtmlGenericControl)ucHeader.FindControl("spnCustSupport")).Visible = true;
                ((HtmlAnchor)ucHeader.FindControl("aCustSupport")).Visible = false;*/
            }
        }
        private void FillBranchDetails()
        {
            string spName = "Get_HomePageBanner";
            string constr = System.Configuration.ConfigurationManager.AppSettings["southernconn"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.Parameters.AddWithValue("@Action", "Cont-All");
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RptTours.DataSource = dt;
                            RptTours.DataBind();
                        }
                    }
                }
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            SaveComment();
        }
        #endregion

        #region "Method(s)"
        protected void ClearComment()
        {
            txtFullName.Text = ""; txtFeedEmail.Text = ""; txtMobile.Text = ""; txtComments.Text = "";
            ddlPurpose.SelectedIndex = -1; txtCaptcha.Text="";

        }
        protected void SaveComment()
        {
            //bool lFlag = reCaptcha();
            //if (lFlag)
            //{
            if (Convert.ToString(Session["CaptchaImageText"]) == Convert.ToString(txtCaptcha.Text.Trim()))
            {
                string lFileName = "", lFileExtension = "";
                if (flUpload.HasFile)
                {
                    if (IsValidated())
                    {
                        lFileExtension = flUpload.FileName.Substring(flUpload.FileName.LastIndexOf('.'));
                    }
                }
                try
                {
                    string Contact_USNo = "";
                    int lStatus = fnSaveCustomerContactUS(txtFullName.Text.Trim(), txtFeedEmail.Text.Trim(), txtMobile.Text.Trim(), txtComments.Text.Trim(), ddlPurpose.SelectedValue,
                        lFileExtension, ref Contact_USNo);
                    if (lStatus > 0)
                    {
                        SaveImage(Contact_USNo);
                        SendMail(Contact_USNo, Contact_USNo + lFileExtension, flUpload.HasFile);
                        ClearComment();
                        Response.Redirect("ThankYou.aspx?PrevPage=contact-us&ThankYouMsg=Thanks for your enquiry. Our executive be contacting you very soon.", false);
                    }
                    else if (lStatus == -1)
                    {
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alrt", "alert('Error for sending comments.');", true);
                    }
                }
                finally
                {
                   
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
        private void SaveImage(string lFileName)
        {
            if (IsValidated())
            {
                try
                {
                    string pFileName = "";
                    string lFileExtension = "";
                    if (flUpload.HasFile)
                    {
                        pFileName = flUpload.FileName;
                        lFileExtension = pFileName.Substring(pFileName.LastIndexOf('.'));
                        SavePhysicalImg(flUpload.PostedFile, lFileName, lFileExtension);
                    }
                }
                finally
                {

                }
            }
        }
        private bool IsValidated()
        {
            if (flUpload.HasFile)
            {
                if (Convert.ToInt32(flUpload.PostedFile.ContentLength.ToString()) > 5242880)
                {
                    string lFileExtension = flUpload.FileName.Substring(flUpload.FileName.LastIndexOf('.'));
                    if (!(lFileExtension.ToLower() == ".pdf"
                       || lFileExtension.ToLower() == ".doc"
                       || lFileExtension.ToLower() == ".docx"
                       || lFileExtension.ToLower() == ".xls"
                       || lFileExtension.ToLower() == ".xlsx"
                       || lFileExtension.ToLower() == ".jpeg"
                       || lFileExtension.ToLower() == ".png"
                       || lFileExtension.ToLower() == ".jpg"
                       || lFileExtension.ToLower() == ".bmp"
                       || lFileExtension.ToLower() == ".gif"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alrt", "alert('Not a valid file.');", true);
                        return false;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alrt", "alert('File size exceeds 5 MB.');", true);
                    return false;
                }
            }

            return true;
        }
        private void SavePhysicalImg(HttpPostedFile file, string pFileName, string pFileExtension)
        {
            // Specify the path to save the uploaded file to.
            string lSavePath = Server.MapPath("ContectUSFile\\");

            string lFileName = "";
            // Get the name of the file to upload.
            lFileName = pFileName + pFileExtension;
            // Create the path and file name to check for duplicates.
            string lPathToCheck = lSavePath + lFileName;
            flUpload.PostedFile.SaveAs(lPathToCheck);
        }
        private void SendMail(string Contact_USNo, string lFileName, bool pSendAttachment)
        {
            // ================================= Mail Format Start Here ==============================
            string mailbody = "";
            mailbody = mailbody + "<br><table width='60%' border='1' cellspacing='1' cellpadding='2' align='center'>";
            mailbody = mailbody + "<tr><td bgcolor='#CCCCCC' colspan='2'><font face='Verdana' size='-1'><b>Contact US  :</b>" + Contact_USNo + "</font></td>";
            mailbody = mailbody + "</tr>";
            mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
            mailbody = mailbody + "<td><font size='-1' face='Verdana'>Name</font></td>";
            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + txtFullName.Text + " </font></td>";
            mailbody = mailbody + "</tr>";
            mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
            mailbody = mailbody + "<td><font size='-1' face='Verdana'>Email</font></td>";
            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + txtFeedEmail.Text + " </font></td>";
            mailbody = mailbody + "</tr>";
            mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
            mailbody = mailbody + "<td><font size='-1' face='Verdana'>Phone / Mobile</font></td>";
            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + txtMobile.Text + " </font></td>";
            mailbody = mailbody + "</tr>";
            mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
            mailbody = mailbody + "<td><font size='-1' face='Verdana'>Purpose</font></td>";
            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + ddlPurpose.SelectedValue + " </font></td>";
            mailbody = mailbody + "</tr>";
            mailbody = mailbody + "<tr bgcolor='#FFFFFF'>";
            mailbody = mailbody + "<td><font size='-1' face='Verdana'>Comments</font></td>";
            mailbody = mailbody + "<td><font face='Verdana' size='-1'>" + txtComments.Text + " </font></td>";
            mailbody = mailbody + "</tr>";

            mailbody = mailbody + "</table>";
            // ================================= Mail Format End Here ==============================

            string pFilePath = Server.MapPath("ContectUSFile\\" + lFileName);

            if (pSendAttachment)
            {
                ClsCommon.sendmail(ConfigurationManager.AppSettings["SupportEmail"], "", "", ConfigurationManager.AppSettings["EnquiryEmail"], "Contact US " + Contact_USNo, mailbody, "", pFilePath);
            }
            else
            {
                //ClsCommon.sendmail("support@southerntravels.com", "", "", "enquiry@southerntravels.com", "Contact US " + Contact_USNo, mailbody, txtFeedEmail.Text);
                MailSend(ConfigurationManager.AppSettings["SupportEmail"], "", "", ConfigurationManager.AppSettings["EnquiryEmail"], "Contact US " + Contact_USNo, mailbody, txtFeedEmail.Text);
            }
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
                    smtpEmail = ConfigurationManager.AppSettings["EnquiryEmail"];
                    smtpPassword = ">6BTuWZE";

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
        private void SetSearchSection()
        {

            contactus.Attributes.Add("class", "tab-pane");
            brand_stores.Attributes.Add("class", "tab-pane");
            preferredsalesagents.Attributes.Add("class", "tab-pane");





            if (!string.IsNullOrEmpty(Request.QueryString["CONREG"]))
            {
                if (Request.QueryString["CONREG"].ToLower() == "brandstores")
                {
                    libranch_offices.Attributes.Add("class", "active");
                    brand_stores.Attributes.Add("class", "tab-pane in active");
                }
                else
                {
                    licontactus.Attributes.Add("class", "active");
                    contactus.Attributes.Add("class", "tab-pane in active");
                }
            }
            else
            {
                licontactus.Attributes.Add("class", "active");
                contactus.Attributes.Add("class", "tab-pane in active");
            }
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
        #endregion

        public string ShowNo(string restricted)
        {
            if (restricted == string.Empty) return "none";
            else return "block";

        }
        public string strCallus(string restricted)
        {
            string strCallus = string.Empty;
            if (restricted != "")
            {
                string[] stringArray = restricted.Split(',');

                for (int i = 0; i < stringArray.Length; i++)
                {
                    if (i == 0)
                    { strCallus = "<a href='tel:" + stringArray[i] + "'>" + stringArray[i] + "</a>"; }
                    else
                    { strCallus += ", <a href='tel:" + stringArray[i] + "'>" + stringArray[i] + "</a>"; }
                }
            }
            return strCallus;
        }
        public string strEmil(string restricted)
        {
            string strEmil = string.Empty;
            if (restricted != "")
            {
                string[] stringArray = restricted.Split('/');

                for (int i = 0; i < stringArray.Length; i++)
                {
                    if (i == 0)
                    { strEmil = "<a href='mailto:" + stringArray[i] + "'>" + stringArray[i] + "</a>"; }
                    else
                    { strEmil += ", <a href='mailto:" + stringArray[i] + "'>" + stringArray[i] + "</a>"; }
                }
            }
            return strEmil;
        }
        public int fnSaveCustomerContactUS(string pFullName, string pEmailID, string pContactNo, string pComment, string pPurpose, string pFileName, ref string lContactNo)
        {
            int pStatus = 0;

            string connStr = DataLib.getConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.SaveCustomerContactUS_SP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input Parameters
                        cmd.Parameters.AddWithValue("@I_FullName", pFullName);
                        cmd.Parameters.AddWithValue("@I_Email", pEmailID);
                        cmd.Parameters.AddWithValue("@I_ContactNumber", pContactNo);
                        cmd.Parameters.AddWithValue("@I_Comments", pComment);
                        cmd.Parameters.AddWithValue("@I_Purpose", pPurpose);
                        cmd.Parameters.AddWithValue("@I_FileName", pFileName);

                        // Output Parameters
                        SqlParameter outContactNo = new SqlParameter("@O_ContactUSNo", SqlDbType.VarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outContactNo);

                        SqlParameter outStatus = new SqlParameter("@O_ReturnValues", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outStatus);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        lContactNo = outContactNo.Value.ToString();
                        pStatus = Convert.ToInt32(outStatus.Value);
                    }
                }
                catch (Exception ex)
                {
                    pStatus = 0;
                }
            }

            return pStatus;
        }

    }
}