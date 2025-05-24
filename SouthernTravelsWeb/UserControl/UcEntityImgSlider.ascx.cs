using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcEntityImgSlider : System.Web.UI.UserControl
    {

        string pvImgSliderImages = "";

        public string fldImgSliderImages
        {
            get
            {
                if (pvImgSliderImages.Trim() == string.Empty)
                {
                    pvImgSliderImages = "<a href=\"#\">" +
                             "<img src=\"images/Award20112012.jpg\" width=\"595\" height=\"225\" alt=\"Jaipur Agra\" /></a>" +
                        "<a href=\"Holiday-Packages-Itinerary-Kashmir-Package_6\">" +
                            "<img src=\"images/Kashmir_Package_HP.jpg\" width=\"595\" height=\"225\" alt=\"Kashmir Package\" /></a>" +
                         "<a href=\"Fixed-Departure-Itinerary-Jaipur-Agra-Volvo.-A.c_40\">" +
                             "<img src=\"images/jaipur_agra.jpg\" width=\"595\" height=\"225\" alt=\"Jaipur Agra\" /></a>" +
                        "<a href=\"Fixed-Departure-Itinerary-Shimla-Manali-Kullu_71\">" +
                            "<img src=\"images/shimla_manali_kullu_FD.jpg\" width=\"595\" height=\"225\" alt=\"Shimla Manali Kullu\" /></a>" +
                        "<a href=\"InternationalTours-Hongkong-HongkongWithMacau04Nights05Days_110\">" +
                            "<img src=\"images/Hongkong-with-Macau.jpg\" width=\"595\" height=\"225\" alt=\"HongKong with Macau 04 Days 03 Nights\" /></a>" +
                        "<a href=\"Holiday-Packages-Itinerary-Leh-With-Nubra-Valley-Discover-Himalayas_111\">" +
                            "<img src=\"images/Leh_With_Nebura_Valley.jpg\" width=\"595\" height=\"225\" alt=\"Leh With Nebura Valley\" /></a>" +
                        "<a href=\"Holiday-Packages-Itinerary-Badrinath-Kedarnath-Haridwar-Rishikesh_15\">" +
                            "<img src=\"images/BKHR.jpg\" width=\"595\" height=\"225\" alt=\"Badrinath Kedarnath Haridwar Rishikesh\" /></a>";
                  
                }
                return pvImgSliderImages;
            }
            set
            {
                pvImgSliderImages = value;
                litEntityImgSlider.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            litEntityImgSlider.Text = fldImgSliderImages;
        }
    }
}