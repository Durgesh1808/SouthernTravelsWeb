using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class FindSpl_TourMaster_spResult
    {
        public int Tourid { get; set; }
        public string Tourcode { get; set; }
        public string TourName { get; set; }
        public string Duration { get; set; }
        public decimal? Fare { get; set; }
        public string Remarks { get; set; }
        public string Addedby { get; set; }
        public DateTime? addeddate { get; set; }
        public double? AgentComission1 { get; set; }
        public double? AgentComission2 { get; set; }
        public double? AgentComission3 { get; set; }
        public string DeptTime { get; set; }
        public string CostIncludes { get; set; }
        public string CostExcludes { get; set; }
        public char? InstentBooking { get; set; }
        public DateTime? BlockJdatefrom { get; set; }
        public DateTime? BlockJdateTo { get; set; }
        public decimal? ZoneId { get; set; }
        public string Notes { get; set; }
        public string City { get; set; }
        public string Itinerary { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public double? AgentComission4 { get; set; }
        public char? isweekendtour { get; set; }
        public string DestCovered { get; set; }
        public string Conditions { get; set; }
        public int? RegionId { get; set; }
        public int? NoOfDays { get; set; }
        public int? NoOfNights { get; set; }
        public bool? IsNonAccommodation { get; set; }
        public int? TourStartFrom { get; set; }
        public string ReturnTime { get; set; }
        public string TourPolicy { get; set; }
        public bool? IsQuery { get; set; }
    }

}