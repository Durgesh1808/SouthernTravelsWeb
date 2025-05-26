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
    public partial class CustomerGroupBookings : System.Web.UI.Page
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
                Response.Redirect("customerlogin.aspx?LIN=1&Type=U");
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
            DataSet dt = DataLib.GetStoredProcData(DataLib.Connection.ConnectionString, "customer_Groupbookedtickets", param);*/
            DataTable ldtRecSet = pvclsObj.fncustomer_Groupbookedtickets(Convert.ToInt32(Session["custrowid"]));
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
        }
    }
}