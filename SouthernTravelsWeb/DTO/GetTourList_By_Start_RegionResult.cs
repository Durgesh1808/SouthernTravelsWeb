using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class GetTourList_By_Start_RegionResult
    {
        public int? RowID { get; set; }
        public int? TourNo { get; set; }
        public int? TourID { get; set; }

        public string Tour_Short_Key { get; set; }  
        public string TourName { get; set; }
        public string FullTourName { get; set; }
        public string Remarks { get; set; }
        public string Tour_DisplayName { get; set; }
        public string Notes { get; set; }
        public int? TourSequence { get; set; }
        public string TourGoingOn { get; set; }
        public decimal? MinCost { get; set; }
        public decimal? MaxCost { get; set; }
        public string DepartureWeekDays { get; set; }
        public string Origin { get; set; }

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