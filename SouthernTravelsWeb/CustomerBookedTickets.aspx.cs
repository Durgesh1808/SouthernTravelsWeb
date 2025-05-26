using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class CustomerBookedTickets : System.Web.UI.Page
    {

        clsAdo clsObj = new clsAdo();
        private int CurrentPage
        {
            get
            {
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0; // default page index of 0
                else
                    return (int)o;
            }
            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["custrowid"]) != "")
            {
                if (!IsPostBack)
                    BindData();
            }
            else
                Response.Redirect("customerlogin.aspx?LIN=1&Type=U");
        }
        protected void dgDuplicateTickets_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
        }
        protected void BindData()
        {
            DataTable ldtRecSet = clsObj.fncustomer_bookedtickets(Convert.ToInt32(Session["custrowid"]));
            if (ldtRecSet != null && ldtRecSet.Rows.Count > 0)
            {
                cmdPrev1.Visible = true;
                cmdNext1.Visible = true;
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = ldtRecSet.DefaultView;
                objPds.AllowPaging = true;

                objPds.PageSize = 10;
                objPds.CurrentPageIndex = CurrentPage;

                lblCPage1.Text = "Page: " + (CurrentPage + 1).ToString() + " of " + objPds.PageCount.ToString();

                if (Convert.ToInt32(CurrentPage + 1) > 1)
                {
                    cmdPrev1.ImageUrl = "images/paging-active-left.jpg";
                }
                else
                {
                    cmdPrev1.ImageUrl = "images/paging-inactive-left.jpg";
                }
                if (Convert.ToInt32(CurrentPage + 1) == objPds.PageCount)
                {
                    cmdNext1.ImageUrl = "images/paging-inactive-right.jpg";
                }
                else
                {
                    cmdNext1.ImageUrl = "images/paging-active-right.jpg";
                }
                cmdPrev1.Enabled = !objPds.IsFirstPage;

                //if (!objPds.IsLastPage)
                //    cmdNext1.Disabled.Equals(false);
                //else
                //    cmdNext1.Disabled.Equals(true);
                cmdNext1.Enabled = !objPds.IsLastPage;


                dgDuplicateTickets.DataSource = objPds;
                dgDuplicateTickets.DataBind();
            }
            else
            {
                cmdPrev1.Visible = false;
                cmdNext1.Visible = false;
            }
            //dgDuplicateTickets.DataSource = ldtRecSet;
            Globals.CheckData(ref dgDuplicateTickets, ldtRecSet, ref lblMsg);
        }
        protected void cmdNext1_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            BindData();
        }
        protected void cmdPrev1_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage -= 1;
            BindData();
        }
        protected void dgDuplicateTickets_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                string ticketcode = dgDuplicateTickets.DataKeys[e.Item.ItemIndex].ToString();
                if (e.CommandName.ToString() == "btncancel")
                {
                    string lOrderID = "", lTktNo = "", lJDate = "";
                    lOrderID = ((Label)(dgDuplicateTickets.Items[e.Item.ItemIndex].Cells[0].FindControl("lblticketno"))).Text;
                    lTktNo = dgDuplicateTickets.Items[e.Item.ItemIndex].Cells[1].Text;
                    lJDate = dgDuplicateTickets.Items[e.Item.ItemIndex].Cells[2].Text;
                    DataTable ldtRec = clsObj.fncustomer_journeydate(ticketcode);
                    DataSet dt = new DataSet();
                    if (ldtRec != null)
                        dt.Tables.Add(ldtRec);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDateTime(dt.Tables[0].Rows[0]["journeydate"]) <= Convert.ToDateTime(DateTime.Now))
                            ClientScript.RegisterStartupScript(GetType(), "already over", "<script>alert('Journey Date passed.');</script>");
                        else
                            Response.Redirect("customerpasswordrequest.aspx?type=fixed&PNRNo=" + lOrderID + "&TKTNO=" + lTktNo + "&JDate=" + lJDate);
                    }
                }
                if (e.CommandName.ToString() == "btnRequest")
                {
                    int? pStatus = -1;
                    DataTable ldtLTCRqs = clsObj.fnrequest_ltc(ticketcode, Convert.ToInt32(Session["custrowid"]), ref pStatus);
                    DataSet dtcheck = new DataSet();
                    if (ldtLTCRqs != null)
                        dtcheck.Tables.Add(ldtLTCRqs);
                    if (pStatus == 0)
                    {

                        string custmail = dtcheck.Tables[0].Rows[0]["email"].ToString();
                        string address = dtcheck.Tables[0].Rows[0]["addr1"].ToString() + ",<br/>" + dtcheck.Tables[0].Rows[0]["addr2"].ToString() + ",<br/>" + dtcheck.Tables[0].Rows[0]["city"].ToString() + ",<br/>" + dtcheck.Tables[0].Rows[0]["state"].ToString() + ",<br/>" + dtcheck.Tables[0].Rows[0]["country"].ToString() + ",<br/>" + dtcheck.Tables[0].Rows[0]["zipcode"].ToString() + ",<br/> Contact No:" + dtcheck.Tables[0].Rows[0]["mobile"].ToString();
                        string filepath = Server.MapPath(ConfigurationManager.AppSettings["travelMail"].ToString() + "\\LTC-LFCrequest.htm");
                        System.IO.StreamReader sr = new System.IO.StreamReader(filepath);
                        string strToSend = sr.ReadToEnd();
                        strToSend = strToSend.Replace("#Cname#", dtcheck.Tables[0].Rows[0]["firstname"].ToString());
                        strToSend = strToSend.Replace("#ticketno#", ticketcode);
                        strToSend = strToSend.Replace("#address#", address);

                        ClsCommon.sendmail("alerts@southerntravels.in", "", "", custmail, "Request for LTC/LFC Certificate", strToSend);
                        ClientScript.RegisterStartupScript(GetType(), "eligibleforLTC", "<script>alert('Your Request Sent Successfully');</script>");
                    }
                    else if (pStatus == 1)
                        ClientScript.RegisterStartupScript(GetType(), "noteligibleforLTC", "<script>alert('Eligible Only On/After the Return Date');</script>");
                }
            }
        }
        protected void dgDuplicateTickets_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField lhidBranch = (HiddenField)e.Item.FindControl("hidBranch");
                HiddenField lhidAgentID = (HiddenField)e.Item.FindControl("hidAgentID");
                if (lhidAgentID != null && lhidBranch != null)
                {
                    if (lhidAgentID.Value != "" && (lhidBranch.Value != "EBK0001" || Convert.ToInt32(lhidAgentID.Value) > 0))
                    {
                        Button lbtnRequest = (Button)e.Item.FindControl("Button2");
                        lbtnRequest.Visible = false;
                    }
                }
            }
        }
        protected void cmdPrev1_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindData();
        }
    }
}