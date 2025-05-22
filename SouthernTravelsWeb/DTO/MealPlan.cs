using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class MealPlan
    {
        public string DayMealPlan { get; set; }
        public string MealPlanDescripation { get; set; }
        public int Day { get; internal set; }
        public string Meal { get; internal set; }

        public int DayNo { get; set; }
        public string MealType { get; set; }
    }

}