using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    public class GetFbDetail_spResult
    {
        public int UserId { get; set; }
        public int RowId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string Addr1 { get; set; }
        public string addr2 { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string zipcode { get; set; }
        public string PhoneNo { get; set; }
        public string AlternativeName { get; set; }
        public string RelativePhoneNo { get; set; }
        public string AlternativeNo { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public DateTime? DOB { get; set; }
        public string company { get; set; }
        public string occupation { get; set; }
        public string remark { get; set; }
        public string maritalstatus { get; set; }
        public DateTime? DOA { get; set; }
        public char? Sex { get; set; }
        public string CallerID { get; set; }
        public DateTime? CreateedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Title { get; set; }
        public string FaceBookId { get; set; }
        public string UserName { get; set; }
    }


}