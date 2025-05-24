using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class FeedBackHierarchy_spResult
    {
        public int FeedOptID { get; set; }

        public string FeedQuest { get; set; }

        public int? ParentID { get; set; }

        public int? Seqen { get; set; }

        public int? RatingID { get; set; }

        public string RatingDesc { get; set; }

        public int? RatingPoints { get; set; }
    }

}