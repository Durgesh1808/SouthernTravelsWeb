using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class Career : System.Web.UI.Page
    {
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            txtMobile.Attributes.Add("onkeypress", "return chkNumeric(event);");
            btnSend.Attributes.Add("onclick", "javascript:return fnFeedbackVal();");
            if (!IsPostBack)
            {
                SetSearchSection();
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
            ddlPurpose.SelectedIndex = -1;
        }
        protected void SaveComment()
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
                    ClientScript.RegisterStartupScript(this.GetType(), "alrt", "alert('Thank you for your valuable comments and time.');", true);
                }
                else if (lStatus == -1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alrt", "alert('Your request has already been sent to respective department. Our Executive will contact you soon.');", true);
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
                ClsCommon.sendmail("support@southerntravels.in", "", "", "enquiry@southerntravels.in", "Contact US " + Contact_USNo, mailbody, "", pFilePath);
            }
            else
            {
                MailSend("support@southerntravels.in", "", "", "enquiry@southerntravels.in", "Contact US " + Contact_USNo, mailbody, txtFeedEmail.Text);
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
        private void SetSearchSection()
        {
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
                        cmd.Parameters.AddWithValue("@FullName", pFullName);
                        cmd.Parameters.AddWithValue("@EmailID", pEmailID);
                        cmd.Parameters.AddWithValue("@ContactNo", pContactNo);
                        cmd.Parameters.AddWithValue("@Comment", pComment);
                        cmd.Parameters.AddWithValue("@Purpose", pPurpose);
                        cmd.Parameters.AddWithValue("@FileName", pFileName);

                        // Output Parameters
                        SqlParameter outContactNo = new SqlParameter("@OutContactNo", SqlDbType.VarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outContactNo);

                        SqlParameter outStatus = new SqlParameter("@Status", SqlDbType.Int)
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

        #endregion
    }
}