using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class TourModel
    {
        public int TourID { get; set; }

        public int TourNo { get; set; }      
        public string TourName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public string TourType { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }
    }

}