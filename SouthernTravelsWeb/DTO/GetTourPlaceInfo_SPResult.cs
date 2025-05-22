using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class GetTourPlaceInfo_SPResult
    {
        public int RowID { get; set; }
        public int? TourTypeID { get; set; }
        public int? TourID { get; set; }
        public int? CityID { get; set; }
        public int? PlaceID { get; set; }
        public string CityName { get; set; }
        public string PlaceName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImagePath { get; set; }
        public string GeoCode { get; set; }
        public string TourStartCity { get; set; }
        public string TourStartFrom { get; set; }
        public int? TourStartFromID { get; set; }
        public string StateName { get; set; }
    }

}