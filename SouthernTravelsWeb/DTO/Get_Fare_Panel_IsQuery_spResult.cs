using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class Get_Fare_Panel_IsQuery_spResult
    {
        public int PanelID { get; set; }
        public int RowID { get; set; }
        public string Category { get; set; }
        public decimal? ACFare { get; set; }
        public decimal? NonACFare { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string s_month { get; set; }
        public int? CategoryID { get; set; }
        public string Season { get; set; }
        public long? SeasonID { get; set; }
    }

}