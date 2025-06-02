using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        clsAdo pvclsObj = new clsAdo();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnsubmit.Attributes.Add("onclick", "javascript:return validatesubmit();");
            divrecaptcha.Attributes.Add("data-sitekey", System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Sitekey"]);
            if (Request.QueryString["fb"] != null)
            {
                if (Convert.ToString(Request.QueryString["fb"]) == "y")
                {
                    BindFaceBookValue();

                }
            }
            if (!IsPostBack)
            {
                fillState();
                chkPromotions.Checked = true;
            }


        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            bool lFlag = reCaptcha();
            //if ((this.Session["CaptchaImageText"] != null) && (this.txtCaptchImage.Text.ToString() == this.Session["CaptchaImageText"].ToString()))
            //    valid = "true";
            if (lFlag)
            {

                string add1, add2, alterno, city, country, email, fname, lname, mobile, pincode, state;
                add1 = DataLib.funClear(Convert.ToString(txtAddress1.Value));
                add2 = DataLib.funClear(Convert.ToString(txtAddress2.Value));
                alterno = DataLib.funClear(Convert.ToString(txtAlternateNo.Value));
                city = DataLib.funClear(Convert.ToString(txtCity.Value));
                country = DataLib.funClear(Convert.ToString(txtCountry.Value));
                email = DataLib.funClear(Convert.ToString(txtEmail.Value));
                fname = DataLib.funClear(Convert.ToString(txtFname.Value));
                lname = DataLib.funClear(Convert.ToString(txtLastName.Value));
                mobile = DataLib.funClear(Convert.ToString(txtMobile.Value));
                pincode = DataLib.funClear(Convert.ToString(txtPinCode.Value));
                // state = DataLib.funClear(Convert.ToString(txtState.Value));

                state = ddlState.SelectedItem.Text;
                ViewState["Spass"] = Convert.ToString(txtNewPassword.Value);

                List<customer_loginResult> lLoginInfo = null;
                clsAdo clsObj = null;
                try
                {
                    clsObj = new clsAdo();
                    lLoginInfo = clsObj.fnGetCustomer_LoginInfo(email);
                    if (lLoginInfo != null && lLoginInfo.Count > 0)
                        ClientScript.RegisterStartupScript(GetType(), "emailexists", "<script>alert('Email Already Exists');</script>");
                    else
                    {
                        lLoginInfo = new List<customer_loginResult>();
                        lLoginInfo = clsObj.fnGetCustomer_LoginInfo(mobile);
                        if (lLoginInfo != null && lLoginInfo.Count > 0)
                            ClientScript.RegisterStartupScript(GetType(), "mobileexists", "<script>alert('Mobile No Already Exists');</script>");
                        else
                        {
                            if (txtNewPassword.Value.Trim().ToString() != "" && txtRetypePassword.Value.Trim().ToString() != "")
                            {
                                if (txtNewPassword.Value.Trim().ToString() == txtRetypePassword.Value.Trim().ToString())
                                {
                                    string sPassword = txtNewPassword.Value.Trim().ToString().Replace("'", "''");
                                    int Val = pvclsObj.fninsert_OnlineCustomer(fname, lname, email, add1, add2, city, state, country,
                                    pincode, alterno, mobile, sPassword, select.Value, chkPromotions.Checked);
                                    if (Val > 0)
                                    {
                                        ClientScript.RegisterStartupScript(GetType(), "SuccessUpdate", "<script>alert('Registered Successfully');</script>");
                                        SendMail(Val, txtFname.Value, txtEmail.Value.Trim(), txtMobile.Value);
                                        Globals.ClearControls(this);
                                        Session["custrowid"] = Val.ToString();
                                        Response.Redirect("Customerprofile.aspx?MM=1");
                                    }
                                }
                                else
                                    ClientScript.RegisterStartupScript(typeof(string), "startupAdd", "<script>alert('Both password must be same !');</script>");
                            }
                            else
                                ClientScript.RegisterStartupScript(typeof(string), "startuperr", "<script>alert('password can not be blank !');</script>");
                        }
                    }
                }
                finally
                {
                    if (clsObj != null)
                    {

                        clsObj = null;
                    }
                    if (lLoginInfo != null)
                    {
                        lLoginInfo = null;
                    }
                }
            }
            else
            {
            }
        }

        private void BindFaceBookValue()
        {
            try
            {
                if (Session["fc_Email"] != null)
                {
                    txtEmail.Value = Convert.ToString(Session["fc_Email"]);
                    txtFname.Value = Convert.ToString(Session["fc_FirstName"]);
                    txtLastName.Value = Convert.ToString(Session["fc_LastName"]);

                    txtEmail.Attributes.Add("readonly", "readonly");

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (Session["fc_Email"] != null)
                {
                    Session["fc_Email"] = null;
                }
                if (Session["fc_FirstName"] != null)
                {
                    Session["fc_FirstName"] = null;
                }
                if (Session["fc_LastName"] != null)
                {
                    Session["fc_LastName"] = null;
                }
            }

        }
        private void fillState()
        {

            clsAdo pClsObj = null;
            try
            {
                pClsObj = new clsAdo();
                ddlState.DataSource = pClsObj.fnGetState();
                ddlState.DataTextField = "State";
                ddlState.DataValueField = "State";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("State*", ""));
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
            }

        }

        private void SendMail(int lRowId, string lCustName, string lemailId, string lMobile)
        {

            string filepath = Server.MapPath(ConfigurationManager.AppSettings["mailerTemplatesPath"].ToString() + "\\forgotpass.html");
            System.IO.StreamReader sr = new System.IO.StreamReader(filepath);
            string strToSend = sr.ReadToEnd();
            strToSend = strToSend.Replace("#membername#", lCustName);
            strToSend = strToSend.Replace("#MemberUserName#", lemailId);
            strToSend = strToSend.Replace("#MemberPassword#", hdnpwd.Value.ToString());
            string strMobile = lMobile;

            try
            {
                string pTO = lemailId;
                string pFrom = "info@southerntravels.in";
                string pSubject = "Your Southern Travels Account Details.";
                string pBody = strToSend;
                ClsCommon.sendmail(pTO, "", "", pFrom, pSubject, pBody, "");

                if (strMobile != "")
                {
                    StringBuilder strMsg = new StringBuilder();

                    string strSms = "Your Login Password is:" + hdnpwd.Value.ToString() + " Happy Holidaying...";
                    string strPhNo = strMobile.Trim().TrimStart('0');
                    strSms.Replace("\n", "");
                    string rtnmessage = DataLib.sendsms(Convert.ToInt32(lRowId), strPhNo, strSms, "OnLineUser", "EBK0001");
                }
            }

            catch (Exception ex)
            {
                Response.Write("<!-- " + ex.ToString() + " -->");
            }
            finally
            {
            }
        }
        public bool reCaptcha()
        {
            bool lFlag = false;

            var secretKey = System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Secretkey"];
            var reCaptchaResponse = Request["g-recaptcha-response"];

            if (string.IsNullOrEmpty(secretKey))
            {
                MessageLabel.Text = "Secret key is not configured.";
                return false;
            }

            if (string.IsNullOrEmpty(reCaptchaResponse))
            {
                MessageLabel.Text = "Captcha response is empty.";
                return false;
            }

            var sb = new System.Text.StringBuilder();
            sb.Append("https://www.google.com/recaptcha/api/siteverify?secret=");
            sb.Append(HttpUtility.UrlEncode(secretKey));

            sb.Append("&response=");
            sb.Append(HttpUtility.UrlEncode(reCaptchaResponse));

            var clientIpAddress = GetUserIp();
            if (!string.IsNullOrEmpty(clientIpAddress))
            {
                sb.Append("&remoteip=");
                sb.Append(HttpUtility.UrlEncode(clientIpAddress));
            }

            using (var client = new System.Net.WebClient())
            {
                var uri = sb.ToString();
                var json = client.DownloadString(uri);

                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(RecaptchaApiResponse));
                using (var ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
                {
                    var result = serializer.ReadObject(ms) as RecaptchaApiResponse;

                    if (result == null)
                    {
                        MessageLabel.Text = "Captcha was unable to make the api call";
                    }
                    else if (result.ErrorCodes != null && result.ErrorCodes.Count > 0)
                    {
                        MessageLabel.Text = "Captcha error: " + string.Join(", ", result.ErrorCodes);
                    }
                    else if (!result.Success)
                    {
                        MessageLabel.Text = "Captcha did not pass, please try again.";
                    }
                    else
                    {
                        MessageLabel.Text = "Captcha cleared";
                        lFlag = true;
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