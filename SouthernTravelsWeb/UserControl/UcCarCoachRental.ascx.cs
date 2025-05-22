using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcCarCoachRental : System.Web.UI.UserControl
    {

        #region "Member Variable(s)"
        int pvTourID, pvNoOfTours; TOURTYPE pvTourType;
        string pvTourOrigin = "";
        bool pvIsLTC = false;
        bool pvMoreToLanding = false;
        bool pvShowAllTour = false;
        #endregion
        #region "Property(s)"
        /// <summary>
        /// Move more link to Section Landing Page or Detailed page.
        /// </summary>
        public bool fldMoreToLanding
        {
            get { return pvMoreToLanding; }
            set { pvMoreToLanding = value; }
        }
        public bool fldIsLTC
        {
            get { return pvIsLTC; }
            set { pvIsLTC = value; }
        }
        public int fldNoOfTours
        {
            get { return pvNoOfTours; }
            set { pvNoOfTours = value; }
        }

        public TOURTYPE fldTourType
        {
            get { return pvTourType; }
            set { pvTourType = value; }
        }

        public int fldTourID
        {
            get { return pvTourID; }
            set { pvTourID = value; }
        }
        public string fldTourOrigin
        {
            get { return pvTourOrigin; }
            set { pvTourOrigin = value; }
        }
        public bool fldShowAllTour
        {
            get { return pvShowAllTour; }
            set { pvShowAllTour = value; }
        }
        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillTours(fldTourType);


            }
        }
        #endregion
        #region "Method(s)"


        private void FillTours(TOURTYPE lTOURTYPE)
        {
            ClsCommon clsObj = null;
            List<GetTourList_By_Start_RegionResult> lTourList = null;
            try
            {
                clsObj = new ClsCommon();
                lTourList = clsObj.GetTourListByStartRegion(lTOURTYPE, fldTourOrigin);
                if (lTourList != null && lTourList.Count > 0)
                {
                    if (fldTourType == TOURTYPE.FIXED_TOUR)
                    {
                        int lFinalListCount = 0;
                        if (fldShowAllTour)
                        {
                            lFinalListCount = lTourList.Count;
                        }
                        else
                        {
                            lFinalListCount = 17;
                        }

                        if (lTourList.Count > lFinalListCount)
                        {
                            lTourList = lTourList.Take(lFinalListCount).ToList();                          

                        }
                    }
                    else
                    {

                    }
                    rptCarCoachRentals.DataSource = lTourList;
                    rptCarCoachRentals.DataBind();
                }

            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
                if (lTourList != null)
                {
                    lTourList = null;
                }
            }
        }

        #endregion

        protected void rptCarCoachRentals_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltr = (Literal)e.Item.FindControl("ltrNoDaysNight");
                GetTourList_By_Start_RegionResult row = (GetTourList_By_Start_RegionResult)e.Item.DataItem;
                string TourName = row.TourName;
                int TourId = Convert.ToInt32(row.TourNo);
                bool IsLtc = false;  //Has to set the value 
                HtmlAnchor anch = (HtmlAnchor)e.Item.FindControl("anchorTag");

                if (fldTourType == TOURTYPE.FIXED_TOUR)
                {
                    if (IsLtc == true)
                    {
                        anch.HRef = "../Fixed-Departure-LTC-Itinerary-" + TourName.Trim().Replace(" ", "-").Replace(":", "") + "_" + Convert.ToString(TourId); ;
                    }
                    else
                    {
                        anch.HRef = "../Fixed-Departure-Itinerary-" + TourName.Trim().Replace(" ", "-").Replace(":", "") + "_" + Convert.ToString(TourId);
                    }
                }
                else if (fldTourType == TOURTYPE.SPECIAL_TOUR || fldTourType == 0)
                {
                    anch.HRef = "../Holiday-Packages-Itinerary-" + TourName.Replace(" ", "-").Replace(":", "") + "_" + Convert.ToString(TourId);
                }

            }
        }

    }
}