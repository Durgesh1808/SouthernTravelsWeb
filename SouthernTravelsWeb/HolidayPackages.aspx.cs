using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class HolidayPackages : System.Web.UI.Page
    {
        #region "Member Variable(s)"
        string pvTourOrigin = "";
        #endregion
        #region "Property(s)"
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
            UCSearchTours1.fldTourType = 2;
            if (!IsPostBack)
            {
                if (fldTourOrigin != string.Empty)
                {
                    title.Text = fldTourOrigin + " Tours";

                    SetPageTitle(fldTourOrigin);
                }
            }
            if (Request.QueryString["Off"] != null && Request.QueryString["Off"].ToString() == "1")
            {
                UCHeader.fldMainSection = Current_Section.HOLIDAY_PACKAGE_INTERNATIONAL_CUSTOMIZED;
            }
            else if (Request.QueryString["Off"] != null && Request.QueryString["Off"].ToString() == "2")
            {
                UCHeader.fldMainSection = Current_Section.HOLIDAY_PACKAGE_INTERNATIONAL_FIXED;
            }
            else
            {
                UCHeader.fldMainSection = Current_Section.HOLIDAY_PACKAGE_CAR;
            }
        }
        #endregion
        #region "Method(s)"
        private void SetPageTitle(string pTourOrigin)
        {
            switch (pTourOrigin.ToLower())
            {
                case "rajasthan":
                    this.title.Text = "Book Rajasthan Holiday Tour Packages | SouthernTravelsIndia";// "Rajasthan Tours | Rajasthan Tour Packages | Rajasthan Travel Packages";
                    mtagDescription.Content = "Best offers on Rajasthan holiday tour packages at SouthernTravelsIndia. Click to book Rajasthan tour packages & get exciting deals on Rajasthan holiday packages.";
                    break;
                case "himachal":
                    this.title.Text = "Himachal Holiday Packages | Holidays Tour packages Himachal | Southern Travels";
                    mtagDescription.Content = "Southern Travels - Your key to paradise. Explore curated holiday tour Packages in Himachal designed for every soul. Book Himachal Holiday Packages today!";
                    break;
                case "kashmir":
                    this.title.Text = "Kashmir Holiday Packages | Holidays Tour Packages Kashmir | Southern Travels";
                    mtagDescription.Content = "Southern Travels: Your Kashmir bliss starts here holidays Tour Packages in Kashmir crafted with care.Explore Kashmir Holiday Packages & escape to paradise.";
                    break;
                case "honeymoon":
                    this.title.Text = "Honeymoon Tours | Honeymoon Tour Packages | Honeymoon Packages";
                    break;
                case "south india":
                    this.title.Text = "South India Tours | South India Travel Packages";
                    break;
                case "north india":
                    this.title.Text = "North India Tours | North India Holidays | North India Travel Packages";
                    break;
                case "north":
                    this.title.Text = "North Tours | North Holidays | North Travel Packages";
                    break;
                case "western india":
                    this.title.Text = "Western India Tours | Western India Holidays | West India Tour Packages";
                    break;
                case "eastern india":
                    this.title.Text = "East India Tours | East India Holidays | East India Tour Packages";
                    break;
                case "pilgrimage":
                    this.title.Text = "Pilgrimage Tours | Pilgrimage Tour Packages";
                    break;
                case "kerala":
                    this.title.Text = "Kerala Tours | Kerala Holiday Packages | Kerala Tour Packages";
                    mtagDescription.Content = "Discover extraordinary Kerala Tours with Southern Travels! Immerse in unparalleled comfort, safety, and personalized packages. Explore Kerala Tours Packages now!";
                    break;
                case "bengaluru":
                    this.title.Text = "Tours from Bengaluru |Bengaluru Tours";
                    break;
                case "mumbai":
                    this.title.Text = "Tours from Mumbai | Mumbai Tours";
                    break;
                case "visakhapatnam":
                    this.title.Text = "Tours from Visakhapatnam | Visakhapatnam Tours";
                    break;
                case "luxurytrain":
                    this.title.Text = "Luxury Train Tours | Luxury Train Packages | Luxury Tour Packages";
                    break;
                case "andaman":
                    this.title.Text = "Andaman Tour Nicobar Tour Packages| Best Deals On Andaman Holiday Packages";
                    mtagDescription.Content = "Southern Travels India offers best deals on Andaman tour packages, andaman hotel booking with exciting discounts. Explore top attractions of Port Blair & the beautiful beaches in Havelock Island. Book customized tours to explore more.";
                    break;
                case "goa":
                    this.title.Text = "Goa Holiday Packages | Holiday Package Goa | Holidays Tour Packages Goa";
                    mtagDescription.Content = "Embark on a journey with Southern Travels - where assurance meets ease! Discover blissful travel with our Goa Holiday Packages. Your dream getaway is just a click away!";
                    break;
                case "gujarat":
                    this.title.Text = "Book Gujarat Holiday Tourism Packages at Best Price | Southern Travels";
                    mtagDescription.Content = "If you want an unforgettable trip to Gujarat, consider Gujarat holiday packages. With a variety of experiences and tours included in these Gujarat tourism packages, you will be able to explore everything that this wonderful state has to offer.";
                    break;
                default:
                    this.title.Text = (pTourOrigin.Trim() != "" ? pTourOrigin : "India") + " Holiday Packages | " +
                        "Holiday Package " + (pTourOrigin.Trim() != "" ? pTourOrigin : "India") + " | Holidays Tour packages " +
                        (pTourOrigin.Trim() != "" ? pTourOrigin : "India") + "";
                    break;
            }
            if (fldTourOrigin != "")
            {
                mtagDescription.Content = mtagDescription.Content.Replace("from southerntravelsindia", "from southerntravelsindia " + fldTourOrigin);
            }
        }
        #endregion
    }
}