using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcHolidaySearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("onKeyPress", "javascript:return CheckOnlyCharacter(event);");
            txtMinDay.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
            txtMaxDay.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
            btnSearch.Attributes.Add("onclick", "javascript:return fnQuickHOlySearchVal();");
            if (!IsPostBack)
            {
                FillMonth();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string TourType;

            string prefixText = "";
            string MinDay;
            string MaxDay;
            string TravelMonth;
            string IncludeCityOutput;
            bool pvIsLTC = false;
            TourType = ddlPackageType.SelectedValue;
            prefixText = txtSearch.Text.Trim();
            MinDay = txtMinDay.Text;
            MaxDay = txtMaxDay.Text;
            TravelMonth = ddlMonthofTravel.SelectedValue;
            IncludeCityOutput = "false";
            Response.Redirect("SearchResult.aspx?TourType=" + TourType + "&prefixText=" + prefixText + "&MinDay=" + MinDay + "&MaxDay=" + MaxDay + "&TravelMonth=" + TravelMonth + "&IncludeCityOutput=" + IncludeCityOutput);
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
    }
}