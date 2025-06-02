using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    
        public class GetTourStratFrom_SPResult
        {
            public int TourID { get; set; }

            public string TourCode { get; set; }

            public string TourName { get; set; }

            public int? TourStartFrom { get; set; }

            public int? TourSequence { get; set; }
        }

}