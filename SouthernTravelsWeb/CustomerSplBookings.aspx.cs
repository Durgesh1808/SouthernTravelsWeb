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
    public partial class CustomerSplBookings : System.Web.UI.Page
    {
        clsAdo pvclsObj = new clsAdo();
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
                Response.Redirect("customerlogin.aspx");
        }
        protected void dgDuplicateTickets_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            //dgDuplicateTickets.CurrentPageIndex = e.NewPageIndex;
            //BindData();
        }
        protected void BindData()
        {
            /*SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@rowid", Convert.ToInt32(Session["custrowid"]));       
            DataSet dt = DataLib.GetStoredProcData(DataLib.Connection.ConnectionString, "customer_splbookedtickets", param);*/
            DataTable ldtRecSet = pvclsObj.fncustomer_splbookedtickets(Convert.ToInt32(Session["custrowid"]));
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
                cmdNext1.Enabled = !objPds.IsLastPage;


                dgDuplicateTickets.DataSource = objPds;
                dgDuplicateTickets.DataBind();
            }
            else
            {
                cmdPrev1.Visible = false;
                cmdNext1.Visible = false;
            }
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
                if (e.CommandName.ToString() == "btncancel")
                {
                    string lTktNo = "", lOrderID = "", lJDate = "";
                    lTktNo = ((Label)(dgDuplicateTickets.Items[e.Item.ItemIndex].Cells[0].FindControl("lblticketno"))).Text;
                    lOrderID = ((HiddenField)(dgDuplicateTickets.Items[e.Item.ItemIndex].Cells[0].FindControl("hdPnr"))).Value;
                    lJDate = dgDuplicateTickets.Items[e.Item.ItemIndex].Cells[1].Text;

                    string jdate = e.Item.Cells[1].Text;
                    string[] dd = jdate.Split('/');
                    jdate = dd[1] + "/" + dd[0] + "/" + dd[2];
                    if (Convert.ToDateTime(jdate) <= Convert.ToDateTime(DateTime.Now))
                        ClientScript.RegisterStartupScript(GetType(), "already over", "<script>alert('Journey Date passed');</script>");
                    else
                        Response.Redirect("customerpasswordrequest.aspx?type=spl&PNRNo=" + lOrderID + "&TKTNO=" + lTktNo + "&JDate=" + lJDate);
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
                    if (lhidBranch.Value != "EBK0001" || Convert.ToInt32(lhidAgentID.Value) > 0)
                    {
                        Button lbtnRequest = (Button)e.Item.FindControl("Button2");
                        lbtnRequest.Visible = false;
                    }
                }
            }
        }
    }
}