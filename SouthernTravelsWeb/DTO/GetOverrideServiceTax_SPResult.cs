using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class GetOverrideServiceTax_SPResult
    {
        public int RowID { get; set; }
        public int? TaxID { get; set; }
        public string TaxCode { get; set; }
        public int? TourType { get; set; }
        public int? TourID { get; set; }
        public decimal? NewTax { get; set; }
        public char? ApplicableOn { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ApplicableFrom { get; set; }
        public DateTime? ApplicableTo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
    }

}