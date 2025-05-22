using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcSearchTours : System.Web.UI.UserControl
    {

        #region "Member Variable(s)"
        string pvTourOrigin = "";
        int pvTourType = 0;


        #endregion

        #region "Property(s)"
        public int fldTourType
        {
            get { return pvTourType; }
            set { pvTourType = value; }
        }
        public string fldTourOrigin
        {
            get
            {
                if (Request.QueryString["ORG"] != null)
                {
                    pvTourOrigin = Convert.ToString(Request.QueryString["ORG"]);
                }
                else
                {
                    pvTourOrigin = "";
                }
                return pvTourOrigin;
            }
            set
            {
                pvTourOrigin = value;
            }
        }
        #endregion

        #region "Event(s)"

        protected void Page_Load(object sender, EventArgs e)
        {
            txtNoOfDaysMin.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
            txtNoOfDaysMax.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
            hdTourType.Value = fldTourType.ToString();
            if (fldTourType == 17 || fldTourType == 18)
            {
                hdTourType.Value = "3";
            }

            if (!IsPostBack)
            {
                FillMonth();
                ShowSearchTour();
                //lnkBtnAllPackages.CssClass = "active";
                if (Request.QueryString["Code"] != null)
                {
                    hdTourZone.Value = Request.QueryString["Code"].ToString();
                }
                else
                {
                    hdTourZone.Value = "0";
                }
                if (Request.QueryString["off"] != null)
                {
                    hdOfferID.Value = Request.QueryString["off"].ToString();
                }
                else
                {
                    hdOfferID.Value = "0";
                }
            }
        }
        protected void lnkZone_Click(object sender, EventArgs e)
        {
        }
        protected void lnkBtnAllPackages_Click(object sender, EventArgs e)
        {
            hdTourType.Value = "1";
            //lnkBtnHolidayPackages.CssClass = "active";
            //lnkBtnAllPackages.CssClass = "";
            //lnkBtnFixedPackages.CssClass = "";
            ShowSearchTour();
        }
        protected void lnkBtnHolidayPackages_Click(object sender, EventArgs e)
        {
            hdTourType.Value = "2";
            //lnkBtnHolidayPackages.CssClass = "";
            //lnkBtnAllPackages.CssClass = "active";
            //lnkBtnFixedPackages.CssClass = "";
            ShowSearchTour();
        }
        protected void lnkBtnFixedPackages_Click(object sender, EventArgs e)
        {
            hdTourType.Value = "1";
            //lnkBtnHolidayPackages.CssClass = "";
            //lnkBtnAllPackages.CssClass = "";
            //lnkBtnFixedPackages.CssClass = "active";
            ShowSearchTour();
        }
        protected void lnkName_Click(object sender, EventArgs e)
        {
            hdSortBy.Value = "1";
            //lnkName.CssClass = "active";
            //lnkPrice.CssClass = "";
            //lnkNoOfDays.CssClass = "";
            //lnkTourCode.CssClass = "";
            ShowSearchTour();
        }
        protected void lnkPrice_Click(object sender, EventArgs e)
        {
            hdSortBy.Value = "2";
            //lnkPrice.CssClass = "active";
            //lnkName.CssClass = "";
            //lnkNoOfDays.CssClass = "";
            //lnkTourCode.CssClass = "";
            ShowSearchTour();
        }
        protected void lnkNoOfDays_Click(object sender, EventArgs e)
        {
            hdSortBy.Value = "3";
            //lnkName.CssClass = "";
            //lnkPrice.CssClass = "";
            //lnkNoOfDays.CssClass = "active";
            //lnkTourCode.CssClass = "";
            ShowSearchTour();
        }
        protected void lnkTourCode_Click(object sender, EventArgs e)
        {
            hdSortBy.Value = "4";
            //lnkName.CssClass = "";
            //lnkPrice.CssClass = "";
            //lnkNoOfDays.CssClass = "";
            //lnkTourCode.CssClass = "active";
            ShowSearchTour();
        }
        protected void repZone_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Zone")
            {
                //    bool isDbSeach = true;
                //    pvZoneID = ConvertStringToInt(e.CommandArgument.ToString());
                //    ShowSearchTour(isDbSeach);
            }

        }
        protected void repZone_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HtmlAnchor lnkZone = (HtmlAnchor)e.Item.FindControl("lnkZone");
                    HiddenField hdZoneName = (HiddenField)e.Item.FindControl("hdZoneName");
                    HiddenField hdZoneId = (HiddenField)e.Item.FindControl("hdZoneId");
                    if (fldTourOrigin != "")
                    {
                        if (hdZoneName.Value.Contains(fldTourOrigin))
                        {
                            lnkZone.Attributes.Add("class", "active");
                            hdTourZone.Value = hdZoneId.Value;
                        }
                    }
                }

            }
            catch { }
        }
        #endregion

        #region "Method(s)"
        private void ShowSearchTour()
        {
            if (Request.QueryString["TourType"] != null)
            {
                hdTourType.Value = Request.QueryString["TourType"];
            }
            if (Request.QueryString["prefixText"] != null)
            {
                TxtCountryStateCity.Text = Request.QueryString["prefixText"];
            }

            if (Request.QueryString["MinDay"] != null)
            {
                txtNoOfDaysMin.Text = Request.QueryString["MinDay"];
            }

            if (Request.QueryString["MaxDay"] != null)
            {
                txtNoOfDaysMax.Text = Request.QueryString["MaxDay"];
            }

            if (Request.QueryString["TravelMonth"] != null)
            {
                ddlMonthofTravel.SelectedValue = Request.QueryString["TravelMonth"];
            }
            bool pvIncludeCityOutput = false;
            if (Request.QueryString["IncludeCityOutput"] != null)
            {
                pvIncludeCityOutput = Convert.ToString(Request.QueryString["IncludeCityOutput"]) == "false" ? false : true;
            }
            int pvTourType = Convert.ToInt32(hdTourType.Value);//Convert.ToInt32(ddlPackageType.SelectedValue);
            int pvTourID = 0;
            lblText.Text = TxtCountryStateCity.Text;
            string pvprefixText = TxtCountryStateCity.Text;
            int pvMinDay = txtNoOfDaysMin.Text == "" ? 0 : Convert.ToInt32(txtNoOfDaysMin.Text);
            int pvMaxDay = txtNoOfDaysMax.Text == "" ? 0 : Convert.ToInt32(txtNoOfDaysMax.Text);
            int pvTravelMonth = Convert.ToInt32(ddlMonthofTravel.SelectedValue); //txtMonthOfTravel.Text == "" ? 0 : Convert.ToInt32(txtMonthOfTravel.Text);
            int pvZoneID = Convert.ToInt32(hdTourZone.Value);

            int pvNoOfDays = Convert.ToInt32(hdNoOfDays.Value);
            int pvPriceMin = Convert.ToInt32(hdPriceMin.Value);
            int pvPriceMax = Convert.ToInt32(hdPriceMax.Value);
            int pSortBy = Convert.ToInt32(hdSortBy.Value);
            int pOfferID = Convert.ToInt32(hdOfferID.Value);
            int lPageIndex = 1, lPageSize = 6;

            DataSet ds = new DataSet();
            DataTable dtSearchTour = new DataTable();
            try
            {
                ds = ClsCommon.GetTourListAll(lPageIndex, lPageSize, pSortBy, pvprefixText, pvMinDay,
                    pvMaxDay, pvTravelMonth, pvTourType, pvIncludeCityOutput, pvTourID, pvZoneID, pvNoOfDays, pvPriceMin, pvPriceMax, pOfferID);

                //lblNoRec.Text = "No Results found";

                if (ds != null && ds.Tables[2].Rows.Count > 0)
                {
                    //lblNoRec.Text = ds.Tables[2].Rows[0]["RecordCount"].ToString() + " Results found";

                    //dtSearchTour = ds.Tables[0];
                    //dlProduct.DataSource = dtSearchTour;
                    //dlProduct.DataBind();
                }

                if (ds != null && ds.Tables[1].Rows.Count > 0)
                {
                    repZone.DataSource = ds.Tables[1];
                    repZone.DataBind();

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (ds != null)
                {
                    ds = null;
                }
                if (dtSearchTour != null)
                {
                    dtSearchTour = null;
                }
            }
        }
        private void FillMonth()
        {
            DateTime lCurrDate = DateTime.Now;
            int lCurrMonth = lCurrDate.Month, lLimit = 12, Ctr = 1;
            ddlMonthofTravel.Items.Add(new ListItem("Month of Travel", "0"));
            while (Ctr <= lLimit)
            {
                ddlMonthofTravel.Items.Add(new ListItem(lCurrDate.ToString("MMMM - yyyy"), lCurrMonth.ToString()));
                lCurrDate = lCurrDate.AddMonths(1);
                lCurrMonth = (lCurrMonth == 12 ? 1 : (lCurrMonth + 1));
                Ctr++;
            }
        }
        #endregion
    }
}