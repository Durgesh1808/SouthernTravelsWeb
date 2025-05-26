using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class customer_loginResult
    {
        public string Password { get; set; }
        public int rowid { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
    }

}