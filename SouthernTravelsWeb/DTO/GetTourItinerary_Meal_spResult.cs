using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class GetTourItinerary_Meal_spResult
    {
        public int? DayNo { get; set; }
        public string ItineraryTime { get; set; }
        public string PlaceOfVisit { get; set; }
        public string NightHalt { get; set; }
        public string DayTitle { get; set; }
        public string MealPlan { get; set; }
    }

}