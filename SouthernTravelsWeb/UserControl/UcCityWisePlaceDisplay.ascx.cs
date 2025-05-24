using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcCityWisePlaceDisplay : System.Web.UI.UserControl
    {
        #region Member Variable(s)
        int _tourType = 0;
        int _tourID = 0;
        bool _isAdmin = true;
        #endregion
        #region Property(s)
        public bool fldIsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
        public int fldTourTypeID
        {
            get { return _tourType; }
            set { _tourType = value; }
        }
        public int fldTourID
        {
            get { return _tourID; }
            set { _tourID = value; }
        }
        #endregion
        #region Event(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            BindPlace();
            //}
        }
        protected void rptShowCity_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {


        }
        #endregion
        #region Method(s)
        /// <summary>
        /// With Xml Read
        /// </summary>
        private void BindPlace_XML()
        {
            List<GetTourPlaceInfo_SPResult> lGetPlaceName = new List<GetTourPlaceInfo_SPResult>();
            GetTourPlaceInfo_SPResult GetPlaceName = null;
            XDocument XDocTourList = XDocument.Load(Server.MapPath("Common/TourPlace.xml"));
            try
            {

                var varPlaceName = from TourPlace in XDocTourList.Descendants("TourPlace")
                                   where Convert.ToInt32(TourPlace.Element("TourTypeID").Value) == Convert.ToInt32(fldTourTypeID)
                                  && Convert.ToInt32(TourPlace.Element("TourID").Value) == Convert.ToInt32(fldTourID)
                                   select new
                                   {
                                       RowID = TourPlace.Element("RowID").Value.Trim(),
                                       TourTypeID = TourPlace.Element("TourTypeID").Value.Trim(),
                                       TourID = TourPlace.Element("TourID").Value.Trim(),
                                       CityID = TourPlace.Element("CityID").Value.Trim(),
                                       PlaceID = TourPlace.Element("PlaceID").Value.Trim(),
                                       CityName = TourPlace.Element("CityName").Value.Trim(),
                                       PlaceName = TourPlace.Element("PlaceName").Value.Trim(),
                                       ShortDescription = TourPlace.Element("ShortDescription").Value.Trim(),
                                       LongDescription = TourPlace.Element("LongDescription").Value.Trim(),
                                       ImagePath = TourPlace.Element("ImagePath").Value.Trim(),
                                       GeoCode = TourPlace.Element("GeoCode").Value.Trim(),
                                       TourStartCity = TourPlace.Element("TourStartCity").Value.Trim(),
                                       TourStartFrom = TourPlace.Element("TourStartFrom").Value.Trim(),
                                       TourStartFromID = TourPlace.Element("TourStartFromID").Value.Trim()
                                   };
                foreach (var PlaceName in varPlaceName)
                {
                    GetPlaceName = new GetTourPlaceInfo_SPResult();
                    GetPlaceName.RowID = Convert.ToInt32(PlaceName.RowID);
                    GetPlaceName.TourTypeID = Convert.ToInt32(PlaceName.TourID);
                    GetPlaceName.TourID = Convert.ToInt32(PlaceName.TourID);

                    GetPlaceName.PlaceID = Convert.ToInt32(PlaceName.PlaceID);
                    GetPlaceName.CityName = PlaceName.CityName;
                    GetPlaceName.PlaceName = PlaceName.PlaceName;
                    GetPlaceName.ShortDescription = PlaceName.ShortDescription;
                    GetPlaceName.LongDescription = PlaceName.LongDescription;

                    GetPlaceName.ImagePath = PlaceName.ImagePath;
                    GetPlaceName.GeoCode = PlaceName.GeoCode;
                    GetPlaceName.TourStartCity = PlaceName.TourStartCity;
                    GetPlaceName.TourStartFrom = PlaceName.TourStartFrom;
                    GetPlaceName.TourStartFromID = Convert.ToInt32(PlaceName.TourStartFromID);
                    lGetPlaceName.Add(GetPlaceName);
                }
                if (lGetPlaceName != null && lGetPlaceName.Count > 0)
                {
                    rptShowCity.DataSource = lGetPlaceName;
                    rptShowCity.DataBind();

                }
            }
            catch
            {
            }
            finally
            {
                if (lGetPlaceName != null)
                {
                    lGetPlaceName = null;
                }
                if (GetPlaceName != null)
                {
                    GetPlaceName = null;
                }
                if (XDocTourList != null)
                {
                    XDocTourList = null;
                }
            }
        }
        private void BindPlace()
        {
            List<GetTourPlaceInfo_SPResult> lGetPlaceName = null;
            ClsCommon clsCmn = new ClsCommon();
            try
            {
                lGetPlaceName = new List<GetTourPlaceInfo_SPResult>();

                lGetPlaceName = clsCmn.fnGetTourPlaceInfo(fldTourID, fldTourTypeID).ToList();
                if (lGetPlaceName != null && lGetPlaceName.Count > 0)
                {
                    rptShowCity.DataSource = lGetPlaceName;
                    rptShowCity.DataBind();

                }
            }
            catch
            {
            }
            finally
            {
                if (lGetPlaceName != null)
                {
                    lGetPlaceName = null;
                }

                if (clsCmn != null)
                {
                    clsCmn = null;
                }
            }
        }
        #endregion

    }
}