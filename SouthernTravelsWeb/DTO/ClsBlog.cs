using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class ClsBlog
    {
        public string BlogTitle { get; set; }
        public string BlogUrl { get; set; }
        public string SmallDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public List<ClsBlogCategory> CategoryList { get; set; } = new List<ClsBlogCategory>();
    }

    public class ClsBlogCategory
    {
        public string CategoryName { get; set; }
    }

}