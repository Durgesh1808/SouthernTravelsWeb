using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SouthernTravelsWeb.UserControl
{
    public partial class UcTourLink : System.Web.UI.UserControl
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
        protected void gvTourList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                  e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink lbtnTour = (HyperLink)e.Item.FindControl("lbtnTour");
                HiddenField hdTourID = (HiddenField)e.Item.FindControl("hdTourID");
                HiddenField hdTourName = (HiddenField)e.Item.FindControl("hdTourName");
                //Label lblTourName = (Label)e.Item.FindControl("lblTourName");
                string lURL = "";
                if (fldTourType == TOURTYPE.FIXED_TOUR)
                {
                    if (fldIsLTC == true)
                    {
                        lURL = "Fixed-Departure-LTC-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                    }
                    else
                    {
                        lURL = "Fixed-Departure-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                    }

                }
                else if (fldTourType == TOURTYPE.SPECIAL_TOUR)
                {
                    lURL = "Holiday-Packages-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                }
                lbtnTour.NavigateUrl = lURL;
               }
        }
        protected void gvTourList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink lbtnTour = (HyperLink)e.Row.Cells[0].FindControl("lbtnTour");
                HiddenField hdTourID = (HiddenField)e.Row.Cells[0].FindControl("hdTourID");
                HiddenField hdTourName = (HiddenField)e.Row.Cells[0].FindControl("hdTourName");
                Label lblTourName = (Label)e.Row.Cells[0].FindControl("lblTourName");
                string lURL = "";
                if (fldTourType == TOURTYPE.FIXED_TOUR)
                {
                    if (fldIsLTC == true)
                    {
                        lURL = "Fixed-Departure-LTC-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                    }
                    else
                    {
                        lURL = "Fixed-Departure-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                    }

                }
                else if (fldTourType == TOURTYPE.SPECIAL_TOUR)
                {
                    lURL = "Holiday-Packages-Itinerary-" + hdTourName.Value.Trim().Replace(" ", "-") + "_" + hdTourID.Value.Trim();
                }
                lbtnTour.NavigateUrl = lURL;
            }
        }
        #endregion
        #region "Method(s)"


        private void FillTours(TOURTYPE lTOURTYPE)
        {
            ClsCommon objCommon = new ClsCommon();
            List<GetTourList_By_Start_RegionResult> lTourList = objCommon.GetTourListByStartRegion(lTOURTYPE, fldTourOrigin);

            if (lTourList != null && lTourList.Count > 0)
            {
                if ((fldTourType == TOURTYPE.FIXED_TOUR) && (fldTourOrigin.Trim().ToLower() == "new delhi"))
                {
                    int lFinalListCount = fldShowAllTour ? lTourList.Count : 17;

                    if (lTourList.Count > lFinalListCount)
                    {
                        lTourList = lTourList.Take(lFinalListCount).ToList();
                    }
                }

                gvTourList.DataSource = lTourList;
                gvTourList.DataBind();
            }
        }



        #endregion
    }
}