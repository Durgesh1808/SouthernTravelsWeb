using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcCustomerLeft : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMenu();
            }
        }

        private void GetMenu()
        {
            List<MainMenu> lMainMenu = new List<MainMenu>();

            lMainMenu.Add(new MainMenu(1, "My Profile", "customerprofile.aspx", null));
            MainMenu lBookedTkts = new MainMenu(2, "Booked Tickets", "CustomerBookedtickets.aspx", null);
            lBookedTkts.SubMenu = new List<clsSubMenu>();
            lBookedTkts.SubMenu.Add(new clsSubMenu(21, "Fixed Tour Tickets", "CustomerBookedtickets.aspx"));
            lBookedTkts.SubMenu.Add(new clsSubMenu(22, "Special Tour Tickets", "CustomerSplBookings.aspx"));
            lBookedTkts.SubMenu.Add(new clsSubMenu(23, "Group Tickets", "CustomerGroupBookings.aspx"));
            lMainMenu.Add(lBookedTkts);

            lMainMenu.Add(new MainMenu(3, "Cancelled tickets", "CustomerCancelledtickets.aspx", null));
            lMainMenu.Add(new MainMenu(4, "Balance Clearance", "onlinebalanceclear.aspx", null));
            lMainMenu.Add(new MainMenu(5, "Feedback", "Feedback.aspx", null));

            repCalendar.DataSource = lMainMenu;
            repCalendar.DataBind();
        }


    }
    class MainMenu
    {
        int _MenuID;
        string _MenuName = "", _MenuLink = "";
        List<clsSubMenu> _SubMenu;

        public int MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }

        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }

        public string MenuLink
        {
            get { return _MenuLink; }
            set { _MenuLink = value; }
        }

        public List<clsSubMenu> SubMenu
        {
            get { return _SubMenu; }
            set { _SubMenu = value; }
        }

        public MainMenu(int pMenuID, string pMenuName, string pMenuLink, List<clsSubMenu> pSubMenu)
        {
            MenuID = pMenuID;
            MenuName = pMenuName;
            MenuLink = pMenuLink;
            SubMenu = pSubMenu;
        }
    }
    class clsSubMenu
    {
        int _MenuID;
        string _SubMenuName = "", _MenuLink = "";

        public int MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }
        public string SubMenuName
        {
            get { return _SubMenuName; }
            set { _SubMenuName = value; }
        }

        public string MenuLink
        {
            get { return _MenuLink; }
            set { _MenuLink = value; }
        }
        public clsSubMenu(int pMenuID, string pSubMenuName, string pMenuLink)
        {
            MenuID = pMenuID;
            SubMenuName = pSubMenuName;
            MenuLink = pMenuLink;
        }
    }
}