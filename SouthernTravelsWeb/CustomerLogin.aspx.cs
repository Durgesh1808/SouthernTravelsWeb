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

namespace SouthernTravelsWeb
{
    public partial class CustomerLogin : System.Web.UI.Page
    {

        #region "Member Variable(s)"
        string strPassword;
        #endregion
        #region "Property(s)"
        protected string sSalt
        {
            get
            {
                if (ViewState["sSalt"] == null)
                    return "";
                else
                    return (string)ViewState["sSalt"];
            }
            set
            {
                ViewState["sSalt"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                #region "Customer Forgot Password"
                ViewState["strPass"] = tmpEnValue.Value;
                #endregion
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["LIN"]))
                {
                    switch ((Request.QueryString["LIN"]).ToString().Trim())
                    {
                        case "1":// Customer Login
                            Title = "Southern Travels : Online Customer Panel";
                            break;
                        case "2": // Agent Login
                            Title = "Southern Travels : Online Travel Agent";
                            break;
                        default:
                            Title = "Southern Travels : Online Customer Panel | Online Travel Agent";
                            break;
                    }
                }
                btnLogin.Attributes.Add("onclick", "javascript:return validate();");
                btnAgentLogin.Attributes.Add("onclick", "javascript:return validateAgent();");
                txtUserId.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13){validate(); __doPostBack('" + btnLogin.UniqueID + "','')}");
                txtPassword.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13){validate(); __doPostBack('" + btnLogin.UniqueID + "','')}");

                txtAgentID.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13){validateAgent(); __doPostBack('" + btnAgentLogin.UniqueID + "','')}");
                txtAgentPWD.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13){validateAgent(); __doPostBack('" + btnAgentLogin.UniqueID + "','')}");

                imgbtnSendRequest.Attributes.Add("onclick", "return validation();");

                ViewState["salt"] = System.DateTime.Now.Minute + System.DateTime.Now.Second;
             
                sSalt = Convert.ToString(System.DateTime.Now.Minute + System.DateTime.Now.Second);
                #region "Customer Forgot Password"
                Random r = new Random();
                string password = r.Next().ToString();
                if (password.Length > 6)
                    password = password.Remove(6);
                ViewState["strPass"] = "";
                ViewState["Spass"] = password.Trim().ToString();
                ClientScript.RegisterStartupScript(typeof(string), "stsrtupSend8", "<script>fnMd5('" + ViewState["Spass"].ToString() + "');</script>");
                #endregion


            }
        }

        #region  OnlineCustomer Login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClsCommon.Decrypt("ee7e8401425247b676142c06d680e252");
            string strpswd = "";
            List<customer_loginResult> lLoginInfo = null;
            clsAdo clsObj = null;
            try
            {
                if (ValidateEUser())
                {
                    clsObj = new clsAdo();
                    lLoginInfo = clsObj.fnGetCustomer_LoginInfo(txtUserId.Value.Trim().Replace("'", "''"));
                    if (lLoginInfo != null && lLoginInfo.Count > 0)
                        strpswd = lLoginInfo[0].Password;
                    if (strpswd != "" && strpswd != null)
                        conformation(strpswd);
                    else
                        ClientScript.RegisterStartupScript(typeof(string), "strValidate", "<script>alert('User is not Activated!');</script>");
                }
            }
            finally
            {
                //if (clsObj != null)
                //{

                //    clsObj = null;
                //}
                //if (lLoginInfo != null)
                //{
                //    lLoginInfo = null;
                //}
            }
        }
        private bool ValidateEUser()
        {
            if (txtUserId.Value.Length > 50)
            {
                ClientScript.RegisterStartupScript(typeof(string), "strValidate", "<script>alert('User ID/Password can\'t be more than 50 characters.');</script>");
                txtUserId.Focus();
                return false;
            }
            else if (txtPassword.Value.Length > 50)
            {
                ClientScript.RegisterStartupScript(typeof(string), "strValidate", "<script>alert('User ID/Password can\'t be more than 50 characters.');</script>");
                txtUserId.Focus();
                return false;
            }
            return true;
        }

        private bool ValidateAgentUser()
        {
            if (txtAgentID.Value.Length > 50)
            {
                ClientScript.RegisterStartupScript(typeof(string), "strValidate", "<script>alert('User ID/Password can\'t be more than 50 characters.');</script>");
                txtAgentID.Focus();
                return false;
            }
            else if (txtAgentPWD.Value.Length > 50)
            {
                ClientScript.RegisterStartupScript(typeof(string), "strValidate", "<script>alert('User ID/Password can\'t be more than 50 characters.');</script>");
                txtAgentID.Focus();
                return false;
            }
            return true;
        }

        void conformation(string strpass)
        {
            string pas = strpass + ViewState["salt"].ToString();
            string pas1 = txtPassword.Value.Trim();
            if ((pas == pas1) && (ifconform()))
                Response.Redirect("Customerprofile.aspx?MM=1");
            else
                ClientScript.RegisterStartupScript(typeof(string), "strValidate", "<script>alert('Invalid Username or Password!');</script>");
        }
        private Boolean ifconform()
        {
            List<customer_loginResult> lLoginInfo = null;
            clsAdo clsObj = null;
            try
            {
                clsObj = new clsAdo();
                lLoginInfo = clsObj.fnGetCustomer_LoginInfo(txtUserId.Value.Trim().Replace("'", "''"));
                if (lLoginInfo != null && lLoginInfo.Count > 0)
                {
                    Session["custrowid"] = Convert.ToString(lLoginInfo[0].rowid);
                    return true;
                }
                else
                    return false;
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
        protected void imgbtnSendRequest_Click(object sender, EventArgs e)
        {
            string strMobile = "";
            clsAdo clsObj = null;
            List<customer_loginResult> lLoginInfo = null;
            try
            {
                clsObj = new clsAdo();
                lLoginInfo = clsObj.fnGetCustomer_LoginInfo(txtmail.Text.Trim().Replace("'", "''"));
                if (lLoginInfo != null && lLoginInfo.Count > 0)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath(ConfigurationManager.AppSettings["mailerTemplatesPath"].ToString() + "\\forgotpass.html"));
                    string strToSend = sr.ReadToEnd();
                    int rowid = Convert.ToInt32(lLoginInfo[0].rowid);
                    strToSend = strToSend.Replace("#membername#", lLoginInfo[0].firstname);
                    strToSend = strToSend.Replace("#MemberUserName#", lLoginInfo[0].email);
                    strToSend = strToSend.Replace("#MemberPassword#", ViewState["Spass"].ToString());
                    strMobile = lLoginInfo[0].mobile;

                    SqlParameter[] param3 = new SqlParameter[3];
                    param3[0] = new SqlParameter("@password", ViewState["strPass"].ToString());
                    param3[1] = new SqlParameter("@email", txtmail.Text.Replace("'", "''").Trim().ToString());
                    param3[2] = new SqlParameter("@rowid", rowid);
                    string supportEmail = ConfigurationManager.AppSettings["SupportEmail"];

                    int val = DataLib.InsStoredProcData(StoredProcedures.customer_updatepassword, param3);
                    try
                    {
                        if (isemail.Value == "Y")
                            ClsCommon.sendmail(txtmail.Text, "", "", supportEmail, "Southern Travels – Your new password", strToSend, "");

                        if (strMobile != "")
                        {
                            StringBuilder strMsg = new StringBuilder();
                            string strSms = "Your Login Password is:" + ViewState["Spass"].ToString() + " Happy Holidaying...";
                            strSms.Replace("\n", "");
                            //---For Sending the SMS By Using M-Campaigner----
                            string rtnmessage = DataLib.sendsms(Convert.ToInt32(rowid), strMobile.Trim().TrimStart('0'), strSms, "OnLineUser", "EBK0001");
                        }
                        ClientScript.RegisterStartupScript(typeof(string), "stsrtupSend7",
                            "<script>alert('You will get the new Password shortly on your registered Mail id/Mobile');window.location.href='index.aspx'</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<!-- " + ex.ToString() + " -->");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(string), "stsrtupSend1",
                        "<script>alert('This Email id/Mobile No is not registerd with us or please enter valid email id/Mobile No.');</script>");
                    Globals.ClearControls(this);
                    this.txtmail.Focus();
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
        #endregion
        #region  Agent Login
        protected void btnAgent_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            try
            {
                ViewState["strPass"] = tmpEnValue.Value;

                string email = txtAgentmail.Text.Trim().Replace("'", "''").Replace("</script>", "").Replace("--", "").ToString();
                dt = ClsCommon.Agent_ForgotPassword(email, tmpEnValue.Value);
                if (dt.Rows.Count > 0)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath(ConfigurationManager.AppSettings["mailerTemplatesPath"].ToString() + "\\forgotpass.html"));
                    string strToSend = sr.ReadToEnd();
                    strToSend = strToSend.Replace("#membername#", dt.Rows[0]["Fname"].ToString());
                    strToSend = strToSend.Replace("#MemberUserName#", dt.Rows[0]["UserId"].ToString());
                    strToSend = strToSend.Replace("#MemberPassword#", ViewState["Spass"].ToString());
                    string supportEmail = ConfigurationManager.AppSettings["SupportEmail"];
                    //ClsCommon.sendmail(email, "", "", "support@southerntravels.in", "Your reset password.", strToSend);
                    ClsCommon.SendMail(email, "", "", supportEmail, "Your reset password.", strToSend);

                    ClientScript.RegisterStartupScript(typeof(string), "stsrtupSend7", "<script>alert('You will get the new Password shortly on your registered Mail id');window.location.href='index.aspx'</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(string), "stsrtupSend1", "<script>alert('This email id is not registerd with us or please input valid email id.');</script>");
                    txtAgentmail.Text = "";
                    txtAgentmail.Focus();
                }


            }
            finally
            {
                if (dt != null)
                {
                    dt = null;
                }
            }
        }

        protected void btnAgentLogin_Click(object sender, EventArgs e)
        {
            DataTable ldtAgentDetails = null;
            ClsCommon clsCommon= new ClsCommon();
            try
            {
                if (ValidateAgentUser())
                {
                    string strAgentName = DataLib.funClear(txtAgentID.Value.Replace("'", "''").Trim());

                    ldtAgentDetails = clsCommon.ValidateAgent(strAgentName);
                    if (ldtAgentDetails != null)
                    {
                        string strpswd = Convert.ToString(ldtAgentDetails.Rows[0]["password"]);
                        if (!string.IsNullOrEmpty(strpswd))
                            Agentconformation(strpswd);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "strValidate",
                            "<script>alert('Invalid Agent ID/Password provided!');</script>");
                    }
                }
            }
            catch (Exception)
            {
                //Response.Write("Please Enter Proper Details and Login");
                Server.Execute("agentlogin.aspx", false);
            }
            finally
            {
               
                if (ldtAgentDetails != null)
                {
                    ldtAgentDetails.Dispose();
                    ldtAgentDetails = null;
                }

            }

        }

        void Agentconformation(string strpass)
        {
            string pas = strpass + sSalt;
            string pas1 = txtAgentPWD.Value.Trim(); //client digest
            if (pas == pas1)
                Agentifconform();
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "strValidate", "<script>alert('Invalid Username or Password!');</script>");
                txtAgentID.Value = "";
            }
        }
        void Agentifconform()
        {
            DataSet dtagent = null;
            DataTable ldtRecSet = null;
            try
            {
                string strAgentName = DataLib.funClear(txtAgentID.Value.Replace("'", "''").Trim());
                strPassword = DataLib.funClear(txtAgentPWD.Value.Replace("'", "''").Trim());
                string strIPAdd = Request.UserHostAddress.ToString();
                string stripname = Request.UserHostName.ToString();
                #region Optimize Code
                /*SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@userid", strAgentName);
                DataSet dtagent = DataLib.GetStoredProcData(DataLib.Connection.ConnectionString, "agent_session_details", param);*/
                #endregion


                ldtRecSet = new DataTable();
                ldtRecSet = fnagent_session_details(strAgentName);

                dtagent = new DataSet();
                if (ldtRecSet != null)
                {
                    dtagent.Tables.Add(ldtRecSet);
                }
                if (dtagent.Tables[0].Rows.Count > 0)
                {
                    string virtualPath = "", CancelCharge = "";
                    if (Session["virtualPath"] != null)
                    {
                        virtualPath = Session["virtualPath"].ToString();
                        CancelCharge = Session["CancelCharge"].ToString();
                    }
                    Session.Clear();
                    Session["virtualPath"] = virtualPath;
                    Session["CancelCharge"] = CancelCharge;
                    Session["AgentId"] = dtagent.Tables[0].Rows[0][0];
                    Session["AgentFname"] = dtagent.Tables[0].Rows[0][1];
                    Session["AgentLname"] = dtagent.Tables[0].Rows[0][2];
                    Session["AgentLevel"] = dtagent.Tables[0].Rows[0][3];
                    Session["UserId"] = dtagent.Tables[0].Rows[0][4];
                    Session["AgentEmail"] = dtagent.Tables[0].Rows[0][5];
                    Session["LocalBranch"] = dtagent.Tables[0].Rows[0][7];
                    Globals.AgentAddress = Convert.ToString(dtagent.Tables[0].Rows[0]["address"]) + " " + Convert.ToString(dtagent.Tables[0].Rows[0]["city"]);
                    Globals.AgentPhone = Convert.ToString(dtagent.Tables[0].Rows[0]["Mobile"]) + ", " + Convert.ToString(dtagent.Tables[0].Rows[0]["landline"]);
                    Session["AgentAddress"] = Convert.ToString(dtagent.Tables[0].Rows[0]["address"]) + " " + Convert.ToString(dtagent.Tables[0].Rows[0]["city"]);
                    Session["AgentPhone"] = Convert.ToString(dtagent.Tables[0].Rows[0]["Mobile"]) + ", " + Convert.ToString(dtagent.Tables[0].Rows[0]["landline"]);
                    string strForgot = Convert.ToString(dtagent.Tables[0].Rows[0][6]);
                    /* string strLog = "insert into agent_log(AgentId,IpAddress) values('" + Session["AgentId"].ToString() + "' ,'" + strIPAdd + "')";
                     DataLib.ExecuteSQL1(DataLib.Connection.ConnectionString, strLog, false);*/
                    ClsCommon clsCommon = new ClsCommon();
                    try
                    {
                        int val = clsCommon.fnSaveAgentLogInInfo(Convert.ToInt32(Session["AgentId"]), strIPAdd);
                    }
                    finally
                    {
                        clsCommon = null;
                    }
                    if (strForgot == "Y")
                    {
                        Session["IsForgot"] = "Y";
                        Response.Redirect("Agent/AgentChangePassWord.aspx", false);
                    }
                    else
                        Response.Redirect("Agent/agenthomepage.aspx", false);
                        Response.Redirect("Agent/agenthomepage.aspx", false);
                }
            }
            catch (Exception)
            {
                //Response.Write("Please Enter Proper Details and Login");
                Response.Redirect("agentlogin.aspx", false);
            }

            finally
            {
               
                if (dtagent != null)
                {
                    dtagent.Dispose();
                    dtagent = null;
                }
                if (ldtRecSet != null)
                {
                    ldtRecSet.Dispose();
                    ldtRecSet = null;
                }
            }
        }

        public DataTable fnagent_session_details(string lUserID)
        {
            DataTable dtSessionDetails = new DataTable();
            string connString = DataLib.getConnectionString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.agent_session_details, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter (adjust size as needed)
                    cmd.Parameters.Add(new SqlParameter("@userid", SqlDbType.VarChar, 50) { Value = lUserID });

                    conn.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtSessionDetails);
                    }
                }

                return dtSessionDetails;
            }
            catch (Exception ex)
            {
                // Optionally log ex
                return null;
            }
        }

        #endregion

    }
}