using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class TourItenerary_SPResult
    {
        public string Tour_Short_key { get; set; }
        public char? ISAccomodation { get; set; }
        public string TourName { get; set; }
        public string Departuretime { get; set; }
        public string ReturnTime { get; set; }
        public string CostIncludes { get; set; }
        public string CostExcludes { get; set; }
        public string Duration { get; set; }
        public string TourPolicy { get; set; }
        public string Notes { get; set; }
        public string OccasionalItinerary { get; set; }
        public int? NoOfDays { get; set; }
        public int? NoOfNights { get; set; }
        public string DepartureWeekDays { get; set; }
        public string ReturnWweekDays { get; set; }
        public string TourGoingOn { get; set; }
        public string ImagePath { get; set; }
        public string CoachDetails { get; set; }
        public string ZoneName { get; set; }
        public string State { get; set; }
        public decimal Fair { get; set; }
        public string TourCost { get; set; }
        public string HolidayType { get; set; }
        public string OfferZone { get; set; }
        public string Remarks { get; set; }
        public string PageBanner { get; set; }
        public string ImageDescription { get; set; }
        public bool IsQuery { get; set; }
    }

}