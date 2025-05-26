using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SouthernTravelsWeb
{
    public partial class OnLineBalanceClear : System.Web.UI.Page
    {
        #region "Property"
        #region "Properties"
        public string TicketNoOfESC
        {
            get
            {
                if (this.ViewState["TicketNoOfESC"] == null)
                    return "";
                else
                    return Convert.ToString(this.ViewState["TicketNoOfESC"]);
            }
            set
            {
                this.ViewState["TicketNoOfESC"] = value;
            }
        }
        public string TicketType
        {
            get
            {
                if (this.ViewState["TicketType"] == null)
                    return "EBK";
                else
                    return Convert.ToString(this.ViewState["TicketType"]);
            }
            set
            {
                this.ViewState["TicketType"] = "EBK";
            }
        }
        public string VoucehrNo
        {
            get
            {
                if (this.ViewState["VoucehrNo"] == null)
                    return "";
                else
                    return Convert.ToString(this.ViewState["VoucehrNo"]);
            }
            set
            {
                this.ViewState["VoucehrNo"] = value;
            }
        }
        public int fldIsESC
        {
            get
            {
                if (this.ViewState["fldIsESC"] == null)
                    return 0;
                else
                    return Convert.ToInt32(this.ViewState["fldIsESC"]);
            }
            set
            {
                this.ViewState["fldIsESC"] = value;
            }
        }


        #endregion

        #endregion

        #region "Event(s)"
        clsAdo pClsObj = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Submit.Attributes.Add("onclick", "javascript:return search();");
            btnpay.Attributes.Add("onclick", "javascript:return validation();");
            //string start = Convert.ToString(txtticketno.Value).Substring(0, 3).ToUpper();
            if (Request.QueryString["Code"] != null)
            {
                GB_ITI_PaymentInfo(Convert.ToString(Request.QueryString["TicketNo"]));
            }
            else
            {
                GroupInfo();
            }
        }

        protected void lnkClose_Click(object sender, EventArgs e)
        {
            //mdlPopup.Hide();
            rdoNetBanking.Checked = true;
            rdoCC.Checked = false;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            string start = string.Empty;
            if (CheckMBKTicket() == false)      // updated on 08/08/2018
                start = "MBK";

            txtticketno.Disabled = true;
            // SetONlineBalanceClearSelected();
            if ((txtticketno.Value != "") && (txtticketno.Value.Trim().Length > 3))
            {
                #region Optimize Code
                /*SqlParameter[] paramst = new SqlParameter[1];
                paramst[0] = new SqlParameter("@TicketNo", DataLib.funClear(txtticketno.Value));
                DataSet dtticketdetils = DataLib.GetStoredProcData(DataLib.Connection.ConnectionString, "OnlineBalanceClear_sp", paramst);*/
                #endregion
                start = Convert.ToString(txtticketno.Value).Substring(0, 3).ToUpper();
                DataSet dtticketdetils = null;
                pClsObj = null;
                try
                {
                    pClsObj = new clsAdo();

                    if (start == "EBK")
                    {
                        hdnticketType.Value = "E";
                        dtticketdetils = pClsObj.fnOnlineBalanceClear(DataLib.funClear(txtticketno.Value), start);
                        fixedtour(dtticketdetils);
                        BindExtraServiceDetails();
                    }
                    else if (start == "SPL")
                    {
                        hdnticketType.Value = "S";
                        dtticketdetils = pClsObj.fnOnlineBalanceClear(DataLib.funClear(txtticketno.Value), start);
                        special(dtticketdetils);
                        BindExtraServiceDetails();
                    }
                    else if (start == "GRP")
                    {
                        hdnticketType.Value = "G";
                        dtticketdetils = pClsObj.fnOnlineBalanceClear(DataLib.funClear(txtticketno.Value), start);
                        GroupDetails(dtticketdetils);
                        BindExtraServiceDetails();
                    }
                    else if (start == "MBK")
                    {
                        GB_ITI_PaymentInfo(Convert.ToString("0"));
                    }
                    else if (start == "INT")
                    {
                        dtticketdetils = pClsObj.fnOnlineBalanceClear(DataLib.funClear(txtticketno.Value), start);
                        INT_PaymentInfo(dtticketdetils);
                    }
                    else
                    {
                        btnpay.Enabled = false;
                        ClientScript.RegisterStartupScript(GetType(), "invalid", "<script>alert('Please Enter valid Ticket no');</script>");
                        return;
                    }

                   
                }
                finally
                {
                    if (pClsObj != null)
                    {
                        pClsObj = null;
                    }
                    if (dtticketdetils != null)
                    {
                        dtticketdetils.Dispose();
                        dtticketdetils = null;
                    }
                }
            }
            else
            {
                btnpay.Enabled = false;
                ClientScript.RegisterStartupScript(GetType(), "Warning", "<script>alert('Please Enter Ticket Number');</script>");
            }
        }

        /// <summary>
        /// Checking if the user is going to clear the balance of ticket which is booked under mbk then show the message.
        /// </summary>
        private bool CheckMBKTicket()
        {
            bool ret = true;
            string ticketNo = txtticketno.Value.Trim();

            if (!ticketNo.StartsWith("MBK", StringComparison.OrdinalIgnoreCase))
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                SqlDataAdapter adapter = null;
                DataTable dt = new DataTable();

                try
                {
                    conn = new SqlConnection(DataLib.getConnectionString());
                    conn.Open();

                    cmd = new SqlCommand(StoredProcedures.CheckInMbkTicket_sp, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TicketNo", ticketNo);

                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string voucherNo = Convert.ToString(dt.Rows[0]["VoucherNo"]);
                        if (!string.IsNullOrEmpty(voucherNo))
                        {
                            txtticketno.Value = voucherNo;
                            ret = false;
                            ClsCommon.ShowAlert("This ticket is part of mbk ticket. Please clear balance by MBKNO-" + voucherNo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Optional: log the exception
                    ClsCommon.ShowAlert("Error: " + ex.Message);
                }
                finally
                {
                    if (adapter != null) adapter.Dispose();
                    if (cmd != null) cmd.Dispose();
                    if (dt != null) dt.Dispose();
                    if (conn != null && conn.State == ConnectionState.Open) conn.Close();
                }
            }

            return ret;
        }

        protected void btnpay_Click(object sender, EventArgs e)
        {
            if ((txtticketno.Value != "") && (txtticketno.Value.Trim().Length > 3))
            {
                string ts = Convert.ToString(Session["TravelSector"]);
                if (ts.Length > 0)
                    ts = ts.Replace("&", "");
                string ba = Convert.ToString(Session["billingAddress"]);
                if (ba.Length > 0)
                    ba = ba.Replace("&", "");
                if (ba.Length > 250)
                    ba = ba.Substring(0, 249);
                string mb = Convert.ToString(Session["mobile"]);

                string start = Convert.ToString(txtticketno.Value).Substring(0, 3).ToUpper();



                if (start == "EBK")
                    PayFixedBalance(ts, ba, mb);
                else if (start == "SPL")
                    PaySpecialBal(ts, ba, mb);
                else if (start == "GRP")
                    PayGroupBal(ts, ba, mb);
                else if (start == "MBK")
                    PayITI_GroupBal(ts, ba, mb);
                else if (start == "INT")
                    PayInternationalBal(ts, ba, mb);
            }


        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            clear();
        }
        protected void RptPaidUnpaidSeviceChargeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button BtnPrint = (Button)e.Item.FindControl("btnPrint");
                Label lblVoucher = (Label)e.Item.FindControl("lblVoucherNo");
                Label lblst = (Label)e.Item.FindControl("lblstatus");

                if (lblst.Text.ToLower().Contains("not"))
                {
                    BtnPrint.Visible = false;
                }
                else
                {
                    BtnPrint.Visible = true;
                }
                BtnPrint.Attributes.Add("onclick", "return printEscReceipt('" + lblVoucher.Text + "');");
            }

        }
        #endregion

        #region "Method(s)"
        private void GB_ITI_PaymentInfo(string pEnquiryNo)
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            SqlParameter lParamStDate = null;
            SqlParameter lParamEndDate = null;
            DataSet ldsDetail = new DataSet();
            SqlDataAdapter lDataAdp = null;
            DataTable ldtItinerary = null;
            try
            {
                lConn = new SqlConnection(DataLib.getConnectionString());// For  Live
                lCommand = new SqlCommand(StoredProcedures.MBKGetGroupEnquiryByOrderID_sp, lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@OrderID", txtticketno.Value.Trim());
                lCommand.Parameters.AddWithValue("@I_EnqID", pEnquiryNo.Trim());

                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }
                lCommand.ExecuteNonQuery();

                lDataAdp = new SqlDataAdapter(lCommand);
                lDataAdp.Fill(ldsDetail);
                if (ldsDetail != null && ldsDetail.Tables.Count > 0)
                {
                    DataTable ldtOrderDetail = new DataTable();
                    ldtOrderDetail = ldsDetail.Tables[0];
                    txtticketno.Disabled = true;
                    txtticketno.Value = Convert.ToString(ldtOrderDetail.Rows[0]["VoucherNo"]);
                    txttourname.Text = Convert.ToString(ldtOrderDetail.Rows[0]["TourName"]);

                    txtgroupleadername.Value = Convert.ToString(ldtOrderDetail.Rows[0]["FName"]);
                    decimal lTotalAmount = Convert.ToDecimal(ldtOrderDetail.Rows[0]["Amount"]) + Convert.ToDecimal(ldtOrderDetail.Rows[0]["STax"]);


                    txtamount.Value = Convert.ToString(ldtOrderDetail.Rows[0]["Amount"]);
                    txtTax.Value = Convert.ToString(ldtOrderDetail.Rows[0]["STax"]);
                    txtdiscount.Value = Convert.ToString("0");
                    txttotalwithtax.Value = Convert.ToString(lTotalAmount);
                    txtamountpaidtill.Value = Convert.ToString(ldtOrderDetail.Rows[0]["Advance"]);
                    txtbalancetill.Value = Convert.ToString(Convert.ToDecimal(txttotalwithtax.Value) - Convert.ToDecimal(txtamountpaidtill.Value));
                    if (ldsDetail.Tables[1].Rows.Count > 0)
                    {
                        ViewState["orderid"] = Convert.ToString(ldtOrderDetail.Rows[0]["OrderID"]);
                        repPaymentDetails.DataSource = ldsDetail.Tables[3];
                        repPaymentDetails.DataBind();
                        btnpay.Enabled = true;
                    }

                    string lTravelSector = txttourname.Text;
                    string lBillingAddress = Convert.ToString(ldtOrderDetail.Rows[0]["CustAddress"]);
                    string lMobile = Convert.ToString(ldtOrderDetail.Rows[0]["Mobile"]);
                    string lPhone = Convert.ToString(ldtOrderDetail.Rows[0]["AlternateNo"]);
                    string lEmail = Convert.ToString(ldtOrderDetail.Rows[0]["EmailID"]);

                    Session["orderid"] = Convert.ToString(ldtOrderDetail.Rows[0]["OrderID"]);
                    Session["ENQID"] = Convert.ToString(ldtOrderDetail.Rows[0]["ENQID"]);
                    ViewState["EmailId"] = lEmail;
                    Session["TravelSector"] = Convert.ToString(lTravelSector);
                    Session["billingAddress"] = DataLib.funClear(Convert.ToString(lBillingAddress)).Replace(":", "").Replace(",", "").Replace("/", "").Replace("(", "").Replace(")", "")
                        .Replace("-", "").Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                    Session["mobile"] = lMobile.Replace("/", "").Replace("(", "").Replace(")", "").Replace("-", "");
                }
                else
                {
                    btnpay.Enabled = false;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "UniqueID", "alert('No such Enquiry number exists.');", true);
                }
            }
            finally
            {
                if (lConn != null)
                {
                    if (lConn.State != ConnectionState.Closed)
                    {
                        lConn.Close();
                    }
                    lConn.Dispose();
                    lConn = null;
                }
                if (lCommand != null)
                {
                    lCommand.Dispose();
                    lCommand = null;
                }
                if (ldsDetail != null)
                {
                    ldsDetail.Dispose();
                    ldsDetail = null;
                }
                if (lDataAdp != null)
                {
                    lDataAdp.Dispose();
                    lDataAdp = null;
                }
                if (lParamStDate != null)
                {
                    lParamStDate = null;
                }
                if (lParamEndDate != null)
                {
                    lParamEndDate = null;
                }
                if (ldtItinerary != null)
                {
                    ldtItinerary.Dispose();
                    ldtItinerary = null;
                }
            }
        }

        private void GroupInfo()
        {
            if (Request.QueryString["TicketNo"] != null)
            {
                string start = Convert.ToString(Request.QueryString["TicketNo"]).Substring(0, 3).ToUpper();
                DataSet dtticketdetils = null;
                pClsObj = null;
                try
                {
                    pClsObj = new clsAdo();
                    if (start == "GRP")
                    {
                        txtticketno.Value = Convert.ToString(Request.QueryString["TicketNo"]);
                        dtticketdetils = pClsObj.fnOnlineBalanceClear(Convert.ToString(Request.QueryString["TicketNo"]), start);
                        if (dtticketdetils != null && dtticketdetils.Tables[0] != null && dtticketdetils.Tables[0].Rows.Count > 0)
                        {
                            GroupDetails(dtticketdetils);
                            txtticketno.Disabled = true;
                        }
                        else
                        {
                            btnpay.Enabled = false;
                            ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Invalid Ticket Details');</script>");
                        }
                    }

                }

                finally
                {
                    if (pClsObj != null)
                    {
                        pClsObj = null;
                    }
                    if (dtticketdetils != null)
                    {
                        dtticketdetils.Dispose();
                        dtticketdetils = null;
                    }
                }
            }
        }
        public void fixedtour(DataSet dtticketdetils)
        {
            Session["TravelSector"]
                = DataLib.funClear(Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TourName"])).Replace(":", "").Replace(",", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("-", "");//Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Address"]);Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TourName"]);
            Session["billingAddress"] = DataLib.funClear(Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Address"])).Replace(":", "").Replace(",", "").
                Replace("/", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);//Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Address"]);
            Session["mobile"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TelNo"]);
            ViewState["EmailId"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Email"]);

            txttourname.Text = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TourName"]);
            txtgroupleadername.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["CustomerName"]);
            txtamount.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Totalamount"]);
            txtTax.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["STaxValue"]);
            txtdiscount.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Discount"]);
            txttotalwithtax.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["AmtWithTax"]);
            txtamountpaidtill.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Advance"]);
            txtbalancetill.Value = Convert.ToString(Convert.ToDecimal(txttotalwithtax.Value) - Convert.ToDecimal(txtamountpaidtill.Value));

            try
            {
                if (Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Cancelled"]) == "Y")
                {
                    ClsCommon.ShowAlert("Ticket is already cancelled");
                }
            }
            catch (Exception ex)
            {

            }

            if (dtticketdetils.Tables[1].Rows.Count > 0)
            {
                ViewState["orderid"] = Convert.ToString(dtticketdetils.Tables[1].Rows[0]["orderid"]); ;
                repPaymentDetails.DataSource = dtticketdetils.Tables[1];
                repPaymentDetails.DataBind();
                btnpay.Enabled = true;
            }
        }
        public void special(DataSet dtticketdetils)
        {
            if ((Convert.ToInt32(dtticketdetils.Tables[0].Rows[0]["AgentId"]) > 0))
            {
                btnpay.Enabled = false;
                ClientScript.RegisterStartupScript(GetType(), "Notbranch", "<script>alert('This is Not a Branch/online Booked Ticket');</script>");
            }
            else
            {
                txttourname.Text = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TourName"]);
                Session["TravelSector"] = DataLib.funClear(txttourname.Text).Replace(",", "").Replace(":", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("-", "");
                Session["billingAddress"] = DataLib.funClear(Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Address"])).Replace(":", "").Replace(",", "").
                    Replace("/", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);//Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Address"]);
                Session["mobile"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Mobile"]);
                Session["mobile"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Phone"]);

                ViewState["EmailId"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Email"]);
                txtgroupleadername.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["FirstName"]);
                txtamount.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["fare"]);
                txtTax.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["servicetax"]);
                txtdiscount.Value = "0";
                txttotalwithtax.Value = Convert.ToString(Convert.ToDecimal(txtamount.Value) + Convert.ToDecimal(txtTax.Value));
                txtamountpaidtill.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["AdvancePaid"]);
                txtbalancetill.Value = Convert.ToString(Convert.ToDecimal(txttotalwithtax.Value) - Convert.ToDecimal(txtamountpaidtill.Value));

                try
                {
                    if (Convert.ToString(dtticketdetils.Tables[0].Rows[0]["IsCancel"]) == "Y")
                    {
                        ClsCommon.ShowAlert("Ticket is already cancelled");
                    }
                }
                catch (Exception ex)
                {

                }
                if (dtticketdetils.Tables[1].Rows.Count > 0)
                {
                    ViewState["orderid"] = Convert.ToString(dtticketdetils.Tables[1].Rows[0]["PnrNo"]);
                    repPaymentDetails.DataSource = dtticketdetils.Tables[1];
                    repPaymentDetails.DataBind();
                    btnpay.Enabled = true;
                }
            }
        }
        public void GroupDetails(DataSet dtticketdetils)
        {
            txttourname.Text = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TourName"]);
            Session["TravelSector"] = DataLib.funClear(txttourname.Text).Replace(":", "").Replace(",", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("-", "");
            Session["billingAddress"] = DataLib.funClear(Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Address"])).Replace(":", "").
                Replace(",", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
            Session["mobile"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["CustomerMobile"]);
            if (Session["mobile"] == null)
                Session["mobile"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["CustomerPhone"]);

            ViewState["EmailId"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["CustomerEmailID"]);
            txtgroupleadername.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["CustomerName"]);
            txtamount.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Totalamount"]);
            txtTax.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["STaxValue"]);
            txtdiscount.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Discount"]);
            txttotalwithtax.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["AmtWithTax"]);
            txtamountpaidtill.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Advance"]);
            txtbalancetill.Value = Convert.ToString(Convert.ToDecimal(txttotalwithtax.Value) - Convert.ToDecimal(txtamountpaidtill.Value));

            try
            {
                if (Convert.ToString(dtticketdetils.Tables[0].Rows[0]["IsCancel"]) == "Y")
                {
                    ClsCommon.ShowAlert("Ticket is already cancelled");
                }
            }
            catch (Exception ex)
            {

            }
            if (dtticketdetils.Tables[1].Rows.Count > 0)
            {
                ViewState["orderid"] = Convert.ToString(dtticketdetils.Tables[1].Rows[0]["PnrNo"]);
                repPaymentDetails.DataSource = dtticketdetils.Tables[1];
                repPaymentDetails.DataBind();
                btnpay.Enabled = true;
            }
        }
        private void INT_PaymentInfo(DataSet dtticketdetils)
        {
            Session["TravelSector"]
                = DataLib.funClear(Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TourName"])).Replace(":", "").Replace(",", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("-", "");//Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Address"]);Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TourName"]);
            Session["billingAddress"] = DataLib.funClear(Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Address"])).Replace(":", "").Replace(",", "").Replace("/", "").
                Replace("(", "").Replace(")", "").Replace("-", "").Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);//Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Address"]);
            Session["mobile"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["Mobile"]);
            ViewState["EmailId"] = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["EmailID"]);

            txttourname.Text = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TourName"]);
            txtgroupleadername.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["GroupLeaderName"]);
            txtamount.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TicketAmount"]);
            txtTax.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["ServiceTax"]);
            txtdiscount.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["DiscountAmount"]);
            txttotalwithtax.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["TotalAmount"]);
            txtamountpaidtill.Value = Convert.ToString(dtticketdetils.Tables[0].Rows[0]["AdvanceAmount"]);
            txtbalancetill.Value = Convert.ToString(Convert.ToDecimal(txttotalwithtax.Value) - Convert.ToDecimal(txtamountpaidtill.Value));
            if (dtticketdetils.Tables[1].Rows.Count > 0)
            {
                ViewState["orderid"] = Convert.ToString(dtticketdetils.Tables[1].Rows[0]["PnrNo"]); ;
                repPaymentDetails.DataSource = dtticketdetils.Tables[1];
                repPaymentDetails.DataBind();
                btnpay.Enabled = true;
            }
        }
        void PayFixedBalance(string ts, string ba, string mb)
        {
            Session["BranchCumOn"] = "BranchCumOnLine";
            Session["BalancePaid"] = DataLib.funClear(txtbalancepaidnow.Value);
         


            Session["BranchTicket"] = DataLib.funClear(txtticketno.Value);
            Session["strBankCode"] = CSTBANKID.Value;
            Session["BalClear"] = "Yes";
            Session["orderid"] = ViewState["orderid"].ToString();

            string bName = "";
            if (rdoNetBanking.Checked)
                bName = CSTBANKID.Value;
            clsAdo pclsObj = null;
            int val = 0;
            if (fldIsESC == 1)
                CreateEscFields("FixFare");

            if (rbtnAtom.Checked)
            {

                string TranAmount = txtbalancepaidnow.Value;

                clsAdo clsObj = null;
                try
                {
                    pclsObj = new clsAdo();
                    val = pclsObj.fnInsertPaymentDetail(ViewState["orderid"].ToString(), "ST", 'N',
                        Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", "", "",
                        "FullPayment", "FixedBranchCumOn", false, false, "Atom Payment");
                    Session["val"] = val;
                }
                finally
                {
                    if (pclsObj != null)
                    {
                        pclsObj = null;
                    }
                }
                int? lStatus = 0;
                if (val > 0)
                {
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
                   System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", txtgroupleadername.Value, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "FixedBranchCumOn");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }

                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("AtomPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedBranchCumOn" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");
                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rbtnPayu.Checked)
            {
                string TranAmount = txtbalancepaidnow.Value;
                clsAdo clsObj = null;
                try
                {
                    pclsObj = new clsAdo();
                    val = pclsObj.fnInsertPaymentDetail(ViewState["orderid"].ToString(), "ST", 'N',
                        Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", "", "",
                        "FullPayment", "FixedBranchCumOn", false, true, "PayU Payment");
                    Session["val"] = val;
                }
                finally
                {
                    if (pclsObj != null)
                    {
                        pclsObj = null;
                    }
                }
                int? lStatus = 0;
                if (val > 0)
                {
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
                   System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "FixedBranchCumOn");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }

                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("PayUPaymet.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedBranchCumOn" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");
                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rdoCC.Checked || rdoDC.Checked)
            {
                try
                {
                    pclsObj = new clsAdo();
                    val = pclsObj.fnInsertPaymentDetail(ViewState["orderid"].ToString(), "ST", 'N',
                        Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", "", bName,
                        "FullPayment", "FixedBranchCumOn", true, false, "CC Payment");
                    Session["val"] = val;
                }
                finally
                {
                    if (pclsObj != null)
                    {
                        pclsObj = null;
                    }
                }
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", "", "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "FixedBranchCumOn");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("HDFCCreditCardPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedBranchCumOn");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");
                        // Response.Redirect("payment.aspx");
                    }

                    
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rdoNetBanking.Checked)
            {
                string TranAmount = txtbalancepaidnow.Value;

                clsAdo clsObj = null;
                try
                {
                    pclsObj = new clsAdo();
                    val = pclsObj.fnInsertPaymentDetail(ViewState["orderid"].ToString(), "ST", 'N',
                        Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", "", "",
                        "FullPayment", "FixedBranchCumOn", false, false, "Tech Process");
                    Session["val"] = val;
                }
                finally
                {
                    if (pclsObj != null)
                    {
                        pclsObj = null;
                    }
                }
                int? lStatus = 0;
                if (val > 0)
                {
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
                   System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "FixedBranchCumOn");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }

                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("TechProcessPayment_Request.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedBranchCumOn" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");
                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
               
            }
            else if (rbtnInstamojo.Checked)
            {

                string TranAmount = txtbalancepaidnow.Value;

                clsAdo clsObj = null;
                try
                {
                    pclsObj = new clsAdo();
                    val = pclsObj.fnInsertPaymentDetail(ViewState["orderid"].ToString(), "ST", 'N',
                        Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", "", "",
                        "FullPayment", "FixedBranchCumOn", false, false, "Instamojo Payment");
                    Session["val"] = val;
                }
                finally
                {
                    if (pclsObj != null)
                    {
                        pclsObj = null;
                    }
                }
                int? lStatus = 0;
                if (val > 0)
                {
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
                   System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", txtgroupleadername.Value, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "FixedBranchCumOn");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }

                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("InstaMojoPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedBranchCumOn" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");
                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else
            {
                Response.Write("Sorry..........");
                Response.End();
            }


        }
        void PayGroupBal(string ts, string ba, string mb)
        {
            Session["GRPTours"] = "GroupBooking";
            Session["strBankCode"] = CSTBANKID.Value;
            Session["GRPId"] = ViewState["orderid"].ToString();
            Session["PaidAmount"] = DataLib.funClear(txtbalancepaidnow.Value);
            Session["BalClear"] = "Yes";
            Session["orderid"] = ViewState["orderid"].ToString();
            Session["FirstPay"] = null;
            string bname = "";


            if (fldIsESC == 1)
                CreateEscFields("GroupFare");

            if (rdoNetBanking.Checked)
                bname = CSTBANKID.Value;
            int val = 0;
            //if (val > 0)
            //{
            if (rbtnAtom.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", "", "FullPayment", "GroupBooking", false, false, "Atom Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", txtgroupleadername.Value, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("AtomPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=GroupBooking" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rbtnPayu.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", bname, "FullPayment", "GroupBooking", false, true, "PayU Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("PayUPaymet.aspx?RID=" + lStatus.ToString() + "&SectionName=GroupBooking" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rdoCC.Checked || rdoDC.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", bname, "FullPayment", "GroupBooking", true, false, "CC Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", "", "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("HDFCCreditCardPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=GroupBooking");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");
                        //Response.Redirect("payment.aspx");
                    }

                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rdoNetBanking.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", bname, "FullPayment", "GroupBooking", false, false, "Tech Process");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("TechProcessPayment_Request.aspx?RID=" + lStatus.ToString() + "&SectionName=GroupBooking" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
           
            }
            else if (rbtnInstamojo.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", bname, "FullPayment", "GroupBooking", false, true, "Instamojo Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("InstaMojoPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=GroupBooking" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else
            {
                Response.Write("Sorry..........");
                Response.End();
            }
         
        }
        void PaySpecialBal(string ts, string ba, string mb)
        {
            Session["BranchCumSPL"] = "BranchCumSpecial";
            Session["BalancePaid"] = DataLib.funClear(txtbalancepaidnow.Value);
            Session["BranchTicket"] = DataLib.funClear(txtticketno.Value);
            Session["strBankCode"] = CSTBANKID.Value;
            Session["orderid"] = ViewState["orderid"].ToString();
            string bName = "";

            if (rdoNetBanking.Checked)
                bName = CSTBANKID.Value;
            int val = 0;
            if (fldIsESC == 1)
                CreateEscFields("SplFare");
            //if (val > 0)
            //{
            if (rbtnAtom.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
            Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", "", "FullPayment", "BranchCumSpecial", false, false, "Atom Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
            System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", txtgroupleadername.Value, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "BranchCumSpecial");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("AtomPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=BranchCumSpecial" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rbtnPayu.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
            Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", bName, "FullPayment", "BranchCumSpecial", false, true, "PayU Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
            System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "BranchCumSpecial");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("PayUPaymet.aspx?RID=" + lStatus.ToString() + "&SectionName=BranchCumSpecial" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rdoCC.Checked || rdoDC.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
            Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", bName, "FullPayment", "BranchCumSpecial", true, false, "CC Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", "", "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "BranchCumSpecial");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("HDFCCreditCardPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=BranchCumSpecial");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");
                    }

                 
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rdoNetBanking.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", bName, "FullPayment", "BranchCumSpecial", false, false, "Tech Process");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
            System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "BranchCumSpecial");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("TechProcessPayment_Request.aspx?RID=" + lStatus.ToString() + "&SectionName=BranchCumSpecial" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
             
            }
            else if (rbtnInstamojo.Checked)
            {

                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
            Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)) + GetEscAmount(), "INR", "", "FullPayment", "BranchCumSpecial", false, false, "Instamojo Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
            System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "",
                            Convert.ToDecimal(TranAmount) + GetEscAmount(),
                            "", lTempTranID, "", "", "", "balclear", txtgroupleadername.Value, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "BranchCumSpecial");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("InstaMojoPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=BranchCumSpecial" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }



            }
            else
            {
                Response.Write("Sorry..........");
                Response.End();
            }
        
        }
        void PayITI_GroupBal(string ts, string ba, string mb)
        {
            Session["ITI_GRPTours"] = "ITI_GroupBooking";
            Session["strBankCode"] = CSTBANKID.Value;
            Session["ITI_GRPId"] = ViewState["orderid"].ToString();
            Session["PaidAmount"] = DataLib.funClear(txtbalancepaidnow.Value);
            Session["BalClear"] = "Yes";
            Session["orderid"] = ViewState["orderid"].ToString();
            Session["ITI_FirstPay"] = null;
            string bname = "";

            if (rdoNetBanking.Checked)
                bname = CSTBANKID.Value;
            int val = 0;

            #region Atom Payment
            if (rbtnAtom.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", "", "FullPayment", "ITI_GroupBooking", false, false, "Atom Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", lTempTranID, "", "", "", "balclear", txtgroupleadername.Value, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "ITI_GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("AtomPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=ITI_GroupBooking" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            #endregion

            #region PayU Payment
            if (rbtnPayu.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", bname, "FullPayment", "ITI_GroupBooking", false, true, "PayU Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "ITI_GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("PayUPaymet.aspx?RID=" + lStatus.ToString() + "&SectionName=ITI_GroupBooking" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            #endregion

            #region HDFC Payment
            if (rdoCC.Checked || rdoDC.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", bname, "FullPayment", "ITI_GroupBooking", true, false, "CC Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;
                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", "", "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "ITI_GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        
                        // Local Payment gateway
                        Response.Redirect("TestCreditCardPayment.aspx?Amt=" + DataLib.funClear(txtbalancepaidnow.Value) + "&OrderId=" +
                        ViewState["orderid"].ToString() + "&EmailId=" + ViewState["EmailId"] + "&ts=" + ts + "&ba=" + ba + "&mb=" + mb +
                        "&SectionName=ITI_GroupBooking");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");
                    }

                   
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            #endregion

            #region Net Banking
            if (rdoNetBanking.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
          Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", bname, "FullPayment", "ITI_GroupBooking", false, false, "Tech Process");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "ITI_GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("TechProcessPayment_Request.aspx?RID=" + lStatus.ToString() + "&SectionName=ITI_GroupBooking" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
             
            }
            #endregion

            #region Instamojo Payment
            if (rbtnInstamojo.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", "", "FullPayment", "ITI_GroupBooking", false, false, "Instamojo Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", lTempTranID, "", "", "", "balclear", txtgroupleadername.Value, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "ITI_GroupBooking");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("InstaMojoPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=ITI_GroupBooking" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            #endregion

        }
        void PayInternationalBal(string ts, string ba, string mb)
        {
            Session["PaidAmount"] = DataLib.funClear(txtbalancepaidnow.Value);
            Session["BalClear"] = "Yes";
            Session["orderid"] = ViewState["orderid"].ToString();
            Session["FirstPay"] = null;

            string bname = "";
            if (rdoNetBanking.Checked)
                bname = CSTBANKID.Value;
            int val = 0;
            if (rbtnAtom.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", "", "FullPayment", "InternationalTours", false, false, "Atom Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", lTempTranID, "", "", "", "balclear", txtgroupleadername.Value, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "InternationalTours");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("AtomPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=InternationalTours" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rbtnPayu.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", bname, "FullPayment", "InternationalTours", false, true, "PayU Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "InternationalTours");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("PayUPaymet.aspx?RID=" + lStatus.ToString() + "&SectionName=InternationalTours" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rdoCC.Checked || rdoDC.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", bname, "FullPayment", "InternationalTours", true, false, "CC Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;
                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", "", "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "InternationalTours");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("HDFCCreditCardPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=InternationalTours");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");
                        //Response.Redirect("payment.aspx");
                    }
                    }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else if (rdoNetBanking.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", bname, "FullPayment", "InternationalTours", false, false, "Tech Process");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", lTempTranID, "", "", "", "balclear", ts, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "InternationalTours");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("TechProcessPayment_Request.aspx?RID=" + lStatus.ToString() + "&SectionName=InternationalTours" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }

            }
            else if (rbtnInstamojo.Checked)
            {
                val = clsBLL.PaymentTable_Entry(ViewState["orderid"].ToString(), "ST", 'N',
           Convert.ToDecimal(DataLib.funClear(txtbalancepaidnow.Value)), "INR", "", "FullPayment", "InternationalTours", false, false, "Instamojo Payment");
                Session["val"] = val;
                if (val > 0)
                {
                    string TranAmount = txtbalancepaidnow.Value;

                    clsAdo clsObj = null;
                    int? lStatus = 0;
                    try
                    {
                        clsObj = new clsAdo();
                        string lTempTranID = val.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
             System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                        lStatus = clsObj.fnInsertPaymentHDFCPG("", ViewState["orderid"].ToString(), ViewState["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                            "", lTempTranID, "", "", "", "balclear", txtgroupleadername.Value, ViewState["EmailId"].ToString(), mb, ba, ViewState["orderid"].ToString(), "", "InternationalTours");
                    }
                    finally
                    {
                        if (clsObj != null)
                        {
                            clsObj = null;
                        }

                    }
                    if (lStatus > 0)
                    {
                        UpdateTicketDeatilsByOrderID(Convert.ToString(ViewState["orderid"]), Convert.ToString(txtticketno.Value.Trim()));
                        Response.Redirect("InstaMojoPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=InternationalTours" + "&FirstName=" + txtgroupleadername.Value.Trim());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "Error", "<script>alert('There is an error in the input fields, please contact administrator');</script>");

                    }
                }
                else
                {
                    Response.Write("Sorry..........");
                    Response.End();
                }
            }
            else
            {
                Response.Write("Sorry..........");
                Response.End();
            }
        }
        public void clear()
        {
            txttourname.Text = "";
            txtgroupleadername.Value = "";
            txtamount.Value = "";
            txtTax.Value = "";
            txtdiscount.Value = "";
            txttotalwithtax.Value = "";
            txtamountpaidtill.Value = "";
            txtbalancetill.Value = "";
            txtbalancepaidnow.Value = "0";
            txtbalancepending.Value = "";
            txtticketno.Value = "";
            txtticketno.Disabled = false;
            repPaymentDetails.DataSource = null;
            repPaymentDetails.DataBind();
            chkTrue.Checked = false;
            rdoNetBanking.Checked = false;
            rdoCC.Checked = false;
            //Response.Redirect("onlinebalanceclear.aspx");
        }
        private void BindExtraServiceDetails()
        {
            string ticketNo = txtticketno.Value;
            DataSet dsEs = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@I_TicketNo", ticketNo);
                dsEs = DataLib.GetStoredProcData(DataLib.Connection.ConnectionString, StoredProcedures.GetExtraServiceCollectionDetails_sp, param);
                dt = dsEs.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    RptPaidUnpaidSeviceChargeList.Visible = true;
                    RptPaidUnpaidSeviceChargeList.DataSource = dt;
                    RptPaidUnpaidSeviceChargeList.DataBind();
                    txtESC.Value = Convert.ToString(dt.Rows[0]["AmountPendingToCollect"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["AmountPendingToCollect"]);

                    if (Convert.ToDecimal(txtESC.Value == "" ? "0" : txtESC.Value) > 0)
                    {
                        string lServiceName = Convert.ToString(dt.DefaultView[0]["ServiceName"]);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "invalid", "alert('There`s extra amount to be collected against `" + lServiceName + "` of  " + Convert.ToString(dt.DefaultView[0]["AmountPendingToCollect"]) + "/- , Please collect this mandatory amount before clearing the balance.');", true);
                    }

                }
                else
                {
                    RptPaidUnpaidSeviceChargeList.Visible = false;
                }

                if (txtESC.Value == "0" || txtESC.Value == "")
                {
                    hdfIsESC.Value = "0";
                    fldIsESC = 0;
                    HideEscFields();
                }
                else
                {
                    hdfIsESC.Value = "1";
                    fldIsESC = 1;
                    showEscFields();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (dsEs != null)
                {
                    dsEs = null;
                }
                if (dsEs != null)
                {
                    dsEs = null;
                }
            }
        }
        private void HideEscFields()
        {
            divEscHeading.Style.Add("display", "none");
            divescAmount.Style.Add("display", "none");
            divTotalAmountHead.Style.Add("display", "none");
            divTotalAmountValue.Style.Add("display", "none");
        }
        private void showEscFields()
        {
            divEscHeading.Style.Add("display", "block");
            divescAmount.Style.Add("display", "block");
            divTotalAmountHead.Style.Add("display", "block");
            divTotalAmountValue.Style.Add("display", "block");
        }
        private void CreateEscFields(string escticketType)
        {
            if (fldIsESC == 1) // Esc amount are there to save
            {
                Session["EscAount"] = txtESC.Value;  //we will use it in PaymentResult.aspx Page
                Session["EscTicketType"] = escticketType;
                Session["EscTourTicketNo"] = txtticketno.Value;

                StringBuilder sbXDoc = new StringBuilder();

                sbXDoc.Append("<Voucher>");
                try
                {
                    for (int i = 0; i < RptPaidUnpaidSeviceChargeList.Items.Count; i++)
                    {
                        Label lblVoucherNo = (Label)RptPaidUnpaidSeviceChargeList.Items[i].FindControl("lblVoucherNo");
                        Label lblAmount = (Label)RptPaidUnpaidSeviceChargeList.Items[i].FindControl("lblAmount");
                        Label lblst = (Label)RptPaidUnpaidSeviceChargeList.Items[i].FindControl("lblstatus");
                        if (lblst.Text.ToLower().Contains("not")) // if amount was not collected only then we take it
                        {
                            sbXDoc.Append(string.Format("<VoucherItem  VoucherNo=\"{0}\" Amount=\"{1}\">", Convert.ToString(lblVoucherNo.Text), lblAmount.Text));
                            sbXDoc.Append("</VoucherItem>");
                        }
                    }
                    sbXDoc.Append("</Voucher>");
                }
                catch (Exception ex)
                {

                }
                Session["EscVoucherAmountxml"] = sbXDoc.ToString(); // we will use it in PaymentResult.aspx Page
            }
        }
        /*  private void SetONlineBalanceClearSelected()
         {
             liBalanceClear.Attributes["class"] = "active";
             liBookticket.Attributes["class"] = "";
             liCanCelTicket.Attributes["class"] = "";
             LiMyProfile.Attributes["class"] = "";

             tab_balanceclear.Attributes["class"] = "tab-pane active in";
             tab_profile.Attributes["class"] = "tab-pane";
             tab_bookedtkts.Attributes["class"] = "tab-pane";
             tab_cancelledtkts.Attributes["class"] = "tab-pane";

         }

         */

        private Decimal GetEscAmount()
        {
            if (fldIsESC == 1)
                return Convert.ToDecimal(txtESC.Value.Trim() == "" ? "0" : txtESC.Value.Trim());
            else
                return 0;
        }

        public void UpdateTicketDeatilsByOrderID(string orderId, string ticketNo)
        {
            //int lStatus = 0;
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            try
            {
                lConn = new SqlConnection(DataLib.getConnectionString());
                lCommand = new SqlCommand(StoredProcedures.UpdateTicketDeatilsByOrderID, lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@OrderId", orderId);
                lCommand.Parameters.AddWithValue("@TicketNo", ticketNo);

                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }

                lCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //return lStatus = 0;
            }
            finally
            {
                lConn.Close();
            }
        }
        #endregion

    }
}