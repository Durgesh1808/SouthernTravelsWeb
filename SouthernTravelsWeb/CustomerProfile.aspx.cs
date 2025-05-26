using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class CustomerProfile : System.Web.UI.Page
    {

        clsAdo clsobj = new clsAdo();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnsubmit.Attributes.Add("onclick", "javascript:return validate();");
            if (!IsPostBack)
            {

                if (Convert.ToString(Session["custrowid"]) != "")
                {
                    fillState();
                    BindProFile();
                }
                else
                    Response.Redirect("customerlogin.aspx");

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
                ddlState.Items.Insert(0, new ListItem("State", ""));
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
        private void BindProFile()
        {
            DataTable dtdetails = null;
            clsAdo clsObj = null;
            try
            {
                clsObj = new clsAdo();
                dtdetails = clsObj.fnonlinecustomer_details(Convert.ToInt32(Session["custrowid"]));
                if (dtdetails != null && dtdetails.Rows.Count > 0)
                {
                    if (dtdetails.Rows[0]["Title"] != null)
                    {
                        select.SelectedItem.Text = Convert.ToString(dtdetails.Rows[0]["Title"]);
                    }
                    txtAddress1.Value = Convert.ToString(dtdetails.Rows[0]["Addr1"]);
                    txtAddress2.Value = Convert.ToString(dtdetails.Rows[0]["addr2"]);
                    txtAlternateNo.Value = Convert.ToString(dtdetails.Rows[0]["AlternativeNo"]);
                    txtCity.Value = Convert.ToString(dtdetails.Rows[0]["City"]);
                    txtCountry.Value = Convert.ToString(dtdetails.Rows[0]["Country"]);
                    txtEmail.Value = Convert.ToString(dtdetails.Rows[0]["email"]);
                    txtFname.Value = Convert.ToString(dtdetails.Rows[0]["FirstName"]);
                    txtLastName.Value = Convert.ToString(dtdetails.Rows[0]["LastName"]);
                    txtMobile.Value = Convert.ToString(dtdetails.Rows[0]["Mobile"]);
                    txtPinCode.Value = Convert.ToString(dtdetails.Rows[0]["zipcode"]);
                    chkPromotions.Checked = Convert.ToBoolean(dtdetails.Rows[0]["CanSendPromotions"] != DBNull.Value ?
                        Convert.ToInt16(dtdetails.Rows[0]["CanSendPromotions"]) : 1);
                    //txtState.Value = Convert.ToString(dtdetails.Rows[0]["state"]);

                    try
                    {
                        ddlState.SelectedValue = Convert.ToString(dtdetails.Rows[0]["state"]);
                    }
                    catch (Exception ex)
                    {

                    }

                    Session["LoggedInUserName"] = Convert.ToString(dtdetails.Rows[0]["FirstName"]) + " " + Convert.ToString(dtdetails.Rows[0]["LastName"]);
                }
            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
                if (dtdetails != null)
                {
                    dtdetails.Dispose();
                    dtdetails = null;
                }
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string add1, add2, alterno, city, country, email, fname, lname, mobile, pincode, state, password = "";
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

            state = DataLib.funClear(Convert.ToString(ddlState.SelectedItem.Text));

            DataTable dtcheck = ClsCommon.CheckUpdateCustomerEmailMobile(Convert.ToInt32(Session["custrowid"]), email, 'E');
            if (dtcheck.Rows.Count > 0)
                ClientScript.RegisterStartupScript(GetType(), "emailexists", "<script>alert('Email Already Exists');</script>");
            else
            {
                dtcheck.Clear();
                dtcheck = ClsCommon.CheckUpdateCustomerEmailMobile(Convert.ToInt32(Session["custrowid"]), mobile, 'M');
                if (dtcheck.Rows.Count > 0)
                    ClientScript.RegisterStartupScript(GetType(), "mobileexists", "<script>alert('Mobile No Already Exists');</script>");
                else
                {
                    if (chkChangePwd.Checked == true)
                    {
                        if (txtOldPassword.Value.Trim().ToString() != "" && txtNewPassword.Value.Trim().ToString() != "" && txtRetypePassword.Value.Trim().ToString() != "")
                        {
                            if (txtNewPassword.Value.Trim().ToString() == txtRetypePassword.Value.Trim().ToString())
                            {
                                string oldpwd = "";
                                dtcheck.Clear();
                                clsAdo clsObj = null;
                                try
                                {
                                    clsObj = new clsAdo();
                                    dtcheck = clsObj.fnonlinecustomer_details(Convert.ToInt32(Session["custrowid"]));
                                    if (dtcheck != null && dtcheck.Rows.Count > 0)
                                        oldpwd = dtcheck.Rows[0]["password"].ToString();
                                }
                                finally
                                {
                                    if (clsObj != null)
                                    {
                                        clsObj = null;
                                    }
                                }
                                string stxtoldpwd = txtOldPassword.Value.Trim().Replace("'", "''");
                                string Encryptstxtoldpwd = Convert.ToString(GetMD5Code(stxtoldpwd)).ToLower();

                                if (oldpwd == Encryptstxtoldpwd)
                                {
                                    string sPassword = txtNewPassword.Value.Trim().ToString().Replace("'", "''");
                                    string EncryptsPassword = Convert.ToString(GetMD5Code(sPassword)).ToLower();

                                    int Val = clsobj.fnupdate_OnlineCustomer_PWD(Convert.ToInt32(Session["custrowid"]), fname, lname, email, add1, add2, city, state, country,
                            pincode, alterno, mobile, EncryptsPassword, chkPromotions.Checked);
                                    if (Val == 0)
                                    {
                                        //Globals.ClearControls(this);
                                        ClientScript.RegisterStartupScript(GetType(), "SuccessUpdate", "<script>alert('Record Updated Successfully');</script>");
                                    }
                                    else
                                        ClientScript.RegisterStartupScript(GetType(), "FailedUpdate", "<script>alert('Sorry!.. There is a problem in updating the record');</script>");
                                }
                                else
                                {
                                    txtOldPassword.Value = "";
                                    ClientScript.RegisterStartupScript(typeof(string), "startupAdd", "<script>alert('Your old password is Wrong !');</script>");
                                }
                            }
                            else
                                ClientScript.RegisterStartupScript(typeof(string), "startupAdd", "<script>alert('Both passwords must be same !');</script>");
                        }
                        else
                            ClientScript.RegisterStartupScript(typeof(string), "startuperr", "<script>alert('password can not be blank !');</script>");
                    }
                    else
                    {
                        int lRowID = 0;
                        if (Session["custrowid"] != null)
                        {
                            lRowID = Convert.ToInt32(Session["custrowid"]);
                        }
                        int Val = clsobj.fnupdate_OnlineCustomer(lRowID, select.SelectedValue, fname, lname, email, add1, add2, city, state, country,
                            pincode, alterno, mobile, 'A', chkPromotions.Checked); // A : Active User
                        if (Val == 0)
                        {
                            Globals.ClearControls(this);
                            BindProFile();
                            ClientScript.RegisterStartupScript(GetType(), "SuccessUpdate", "<script>alert('Record Updated Successfully');</script>");
                        }
                        else
                            ClientScript.RegisterStartupScript(GetType(), "PwdUpdateFails", "<script>alert('Sorry!.. There is a problem in updating the record');</script>");
                    }
                }
            }
        }


        public string GetMD5Code(string EncryptPassword)
        {
            byte[] dataToHashBytes = System.Text.Encoding.ASCII.GetBytes(EncryptPassword);
            var hashed = "";
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                hashed = BitConverter.ToString(md5.ComputeHash(dataToHashBytes)).Replace("-", "");

            }

            return hashed;
        }
    }
}