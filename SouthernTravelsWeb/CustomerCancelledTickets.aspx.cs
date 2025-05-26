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
    public partial class CustomerCancelledTickets : System.Web.UI.Page
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
                {
                    BindData();
                }
            }
            else
            {
                Response.Redirect("customerlogin.aspx?LIN=1&Type=U");
            }
        }
        protected void BindData()
        {
            #region Optimize Code
           
            #endregion
            DataTable ldtRecSet = pvclsObj.fncustomer_cancelledtickets(Convert.ToInt32(Session["custrowid"]));

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
                    cmdPrev1.ImageUrl = "Assets/images/paging-active-left.jpg";
                }
                else
                {
                    cmdPrev1.ImageUrl = "Assets/images/paging-inactive-left.jpg";
                }
                if (Convert.ToInt32(CurrentPage + 1) == objPds.PageCount)
                {
                    cmdNext1.ImageUrl = "Assets/images/paging-inactive-right.jpg";
                }
                else
                {
                    cmdNext1.ImageUrl = "Assets/images/paging-active-right.jpg";
                }
                cmdPrev1.Enabled = !objPds.IsFirstPage;
                cmdNext1.Enabled = !objPds.IsLastPage;


                dgrReports.DataSource = objPds;
                dgrReports.DataBind();
            }
            else
            {
                cmdPrev1.Visible = false;
                cmdNext1.Visible = false;
            }
            Globals.CheckData(ref dgrReports, ldtRecSet, ref lblMsg);
        }
        protected void dgrReports_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            //dgrReports.CurrentPageIndex = e.NewPageIndex;
            //BindData();
        }
        protected void dgrReports_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hrLink = (HyperLink)e.Item.Cells[3].FindControl("hrLink");
                HiddenField hdOrderNo = (HiddenField)e.Item.Cells[3].FindControl("hdOrderNo");
                HiddenField hdRowID = (HiddenField)e.Item.Cells[3].FindControl("hdRowID");

                if (e.Item.Cells[8].Text.Trim().StartsWith("EBK"))
                {
                    hrLink.NavigateUrl = "Customercancel_ticket.aspx?orderid=" + hdOrderNo.Value.Trim() + "&Ticket=kps";
                }
                if (e.Item.Cells[8].Text.Trim().StartsWith("SPL"))
                {
                    hrLink.NavigateUrl = "SPlCan-Ticket.aspx?Id=" + hdRowID.Value.Trim() + "&Ticket=kps";
                }
                if (e.Item.Cells[8].Text.Trim().StartsWith("GRP"))
                {
                    hrLink.NavigateUrl = "SPlCan-Ticket.aspx?Id=" + hdRowID.Value.Trim() + "&Ticket=kps";
                }

            }
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
    }
}