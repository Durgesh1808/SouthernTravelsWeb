using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcHotelInSouthern : System.Web.UI.UserControl
    {

        enum HotelType
        {
            HotelSouthernDelhi = 1,
            HotelSouthernJaipur = 2
        }

        #region "Member Variable(s)"

        #endregion
        #region "Property(s)"

        public int fldHotelType
        {
            get;
            set;
        }
        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCheckInDel.Attributes.Add("readonly", "readonly");
            txtCheckOutDel.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            {
                // Populate ddlAdultDel with values from 1 to 3
                for (int i = 1; i <= 3; i++)
                {
                    ddlAdultDel.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                // Populate ddlChildDel with values from 0 to 2
                for (int i = 0; i <= 2; i++)
                {
                    ddlChildDel.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                // Populate ddlRoomDel with values from 1 to 10
                for (int i = 1; i <= 10; i++)
                {
                    ddlRoomDel.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                ddlAdultDel.SelectedValue = "-1";
                ddlChildDel.SelectedValue = "-1";
                ddlRoomDel.SelectedValue = "-1";
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //http://southerntravels.dyndns.org/ibookingsetup/BrowseHotel.aspx?ArrDate=29/08/2012&DeptDate=30/08/2012&NoofRooms=1&NoofAdults=1&NoofChilds=0&Location=NEW%20DELHI

            if (fldHotelType == Convert.ToInt32(HotelType.HotelSouthernJaipur))
            {

                //https://zonebythepark-jaipur.reztrip.com/classic/search?rooms=1&arrival_date=2016-03-28&departure_date=2016-03-29&adults=2&children=1
                string lPostUrl = "https://zonebythepark-jaipur.reztrip.com/classic/search?";
                lPostUrl += "rooms=" + ddlRoomDel.SelectedValue + "&departure_date=" + GetDateInYYMMDD(txtCheckOutDel.Text.Trim()) + "&arrival_date=" + GetDateInYYMMDD(txtCheckInDel.Text.Trim()) + "&NoofRooms=" + ddlRoomDel.SelectedValue;
                lPostUrl += "&adults=" + ddlAdultDel.SelectedValue + "&children=" + ddlChildDel.SelectedValue;
                Response.Redirect(lPostUrl, false);

            }
            else
            {
                string pLocation = "NEW DELHI";
                string lPostUrl = "http://southerntravels.dyndns.org/ibookingsetup/BrowseHotel.aspx?";
                lPostUrl += "ArrDate=" + txtCheckInDel.Text.Trim() + "&DeptDate=" + txtCheckOutDel.Text.Trim() + "&NoofRooms=" + ddlRoomDel.SelectedValue;
                lPostUrl += "&NoofAdults=" + ddlAdultDel.SelectedValue + "&NoofChilds=" + ddlChildDel.SelectedValue + "&Location=" + pLocation;
                Response.Redirect(lPostUrl);
            }
        }
        #endregion
        #region "Method(s)"
        private string GetDateInYYMMDD(string strddmmyyDate)
        {
            string ret = "";
            try
            {
                if (!string.IsNullOrEmpty(strddmmyyDate))
                {
                    string[] DateArr3 = new string[3];
                    char[] splitter1 = { '/' };
                    DateArr3 = strddmmyyDate.Split(splitter1);
                    ret = DateArr3[2] + "-" + DateArr3[1] + "-" + DateArr3[0];
                    //lDepartureDate = new DateTime(Convert.ToInt32(DateArr3[2]), Convert.ToInt32(DateArr3[1]), Convert.ToInt32(DateArr3[0]));
                }
                return ret;
            }
            catch (Exception ex)
            {
                return ret;
            }
        }
        #endregion
    }
}