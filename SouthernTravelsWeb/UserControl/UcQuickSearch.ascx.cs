using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcQuickSearch : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        Current_Section pvSearchSection;
        private bool pvShowBanner;
        #endregion
        #region "Property(s)"
        public Current_Section fldSearchSection
        {
            get
            {
                return pvSearchSection;
            }
            set
            {
                pvSearchSection = value;
                //SetSearchSection();
            }
        }
        public bool fldShowBanner
        {
            get
            {
                return pvShowBanner;
            }
            set
            {
                pvShowBanner = value;
                SetBanner();
            }
        }
        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetSearchSection();
              

            }
            else
            {
                if (hdMenuSubTab.Value != "")
                {
                    SetSearchSection();
                }
            }
        }
        #endregion
        #region "Method(s)"
        private void SetSearchSection()
        {
            try
            {
                QSFD.Attributes.Add("class", "t1 tab");
                QSFDDIV.Style.Add("display", "none");
                QSHP.Attributes.Add("class", "t2 tab");
                QSHPDIV.Style.Add("display", "none");
                //QSCR.Attributes.Add("class", "t3 tab");
                //QSCRDIV.Style.Add("display", "none");
                QSHTL.Attributes.Add("class", "t4 tab");
                QSHTLDIV.Style.Add("display", "none");
                QSDELHTLDIV.Style.Add("display", "none");
                QSINDHTLDIV.Style.Add("display", "none");
                QSFLIGHT.Attributes.Add("class", "t5 tab");
                QSFLIGHTDIV.Style.Add("display", "none");
                //QSDELHTL.Attributes.Add("class", "s1 ssTab");
                //QSINDHTL.Attributes.Add("class", "s2 ssTab");
            }
            catch { }

            if (hdMenuSubTab.Value == "1")
            {
                fldSearchSection = Current_Section.FIXED_DEPARTURE;
            }
            else if (hdMenuSubTab.Value == "2")
            {
                fldSearchSection = Current_Section.HOLIDAY_PACKAGE_CAR;
            }
            else if (hdMenuSubTab.Value == "5")
            {
                fldSearchSection = Current_Section.HOTEL_DELHI;
            }
            else if (hdMenuSubTab.Value == "6")
            {
                fldSearchSection = Current_Section.HOTEL_IN_INDIA;
            }
            else if (hdMenuSubTab.Value == "7")
            {
                fldSearchSection = Current_Section.CAR_COACH_RENTAL;
            }
            else if (hdMenuSubTab.Value == "8")
            {
                fldSearchSection = Current_Section.DOMESTIC_FLIGHT;
            }

            switch (fldSearchSection)
            {
                case Current_Section.HOLIDAY_PACKAGE_CAR:
                    QSHP.Attributes.Add("class", "t2 tab active");
                    QSHPDIV.Style.Add("display", "block");
                    QSHPDIV.Attributes.Add("class", "tab-pane fade  in active");
                    break;
                case Current_Section.HOLIDAY_PACKAGE_INTERNATIONAL:
                    QSHP.Attributes.Add("class", "t2 tab active");
                    QSHPDIV.Style.Add("display", "block");
                    break;
                case Current_Section.HOLIDAY_PACKAGE_CRUISE:
                    QSHP.Attributes.Add("class", "t2 tab active");
                    QSHPDIV.Style.Add("display", "block");
                    break;
                case Current_Section.CAR_COACH_RENTAL:
                    //QSCR.Attributes.Add("class", "t3 tab active");
                    //QSCRDIV.Style.Add("display", "block");
                    QSHPDIV.Style.Add("display", "block");
                    break;
                case Current_Section.HOTEL_DELHI:
                    QSHTL.Attributes.Add("class", "t4 tab active");
                    QSHTLDIV.Style.Add("display", "block");
                    QSDELHTLDIV.Style.Add("display", "block");
                    QSDELHTL.Attributes.Add("class", "s1 ssTab subact");
                    break;
                case Current_Section.HOTEL_IN_INDIA:
                    QSHTL.Attributes.Add("class", "t4 tab active");
                    QSHTLDIV.Style.Add("display", "block");
                    QSINDHTLDIV.Style.Add("display", "block");
                    QSINDHTL.Attributes.Add("class", "s2 ssTab subact");
                    break;
                case Current_Section.DOMESTIC_FLIGHT:
                    QSFLIGHT.Attributes.Add("class", "t5 tab active");
                    QSFLIGHTDIV.Style.Add("display", "block");
                    break;
                default:
                    QSFD.Attributes.Add("class", "t1 tab active");
                    QSFDDIV.Style.Add("display", "block");
                    QSFD.Attributes.Add("class", "tab-pane fade  in active");
                    break;
            }
        }
        private void SetBanner()
        {
        }
        #endregion
    }
}