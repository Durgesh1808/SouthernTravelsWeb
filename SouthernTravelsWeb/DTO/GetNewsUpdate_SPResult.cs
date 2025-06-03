using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class GetNewsUpdate_SPResult
    {
        public int RowID { get; set; }
        public string HeadLine { get; set; }
        public string ShortNews { get; set; }
        public string LongNews { get; set; }
        public string ImagePath { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
    }

}