using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.DTO
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using SouthernTravelsWeb.DAL.DbObjects;

    public class OnlineBalanceClear_Result
    {
        private string _connectionString;

        public OnlineBalanceClear_Result(string connectionString)
        {
            _connectionString = connectionString;
        }

        public (List<FirstResult>, List<SecondResult>) GetOnlineBalanceClear(string ticketNo)
        {
            List<FirstResult> firstResults = new List<FirstResult>();
            List<SecondResult> secondResults = new List<SecondResult>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.OnlineBalanceClear_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketNo", ticketNo);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // First result set
                    while (reader.Read())
                    {
                        firstResults.Add(new FirstResult
                        {
                            TourName = reader["TourName"].ToString(),
                            CustomerName = reader["CustomerName"].ToString(),
                            Totalamount = reader.GetDecimal(reader.GetOrdinal("Totalamount")),
                            STaxValue = reader["STaxValue"] as decimal?,
                            AmtWithTax = reader["AmtWithTax"] as decimal?,
                            Discount = reader.GetDecimal(reader.GetOrdinal("Discount")),
                            Advance = reader["Advance"] as decimal?,
                            address = reader["address"].ToString(),
                            email = reader["email"].ToString(),
                            TelNo = reader["TelNo"].ToString(),
                            Cancelled = reader["Cancelled"].ToString()
                        });
                    }

                    // Move to second result set
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            secondResults.Add(new SecondResult
                            {
                                Bookingdate = reader["Bookingdate"] as DateTime?,
                                startdate = reader.GetDateTime(reader.GetOrdinal("startdate")),
                                totalamount = reader["totalamount"] as decimal?,
                                advancepaid = reader["advancepaid"] as decimal?,
                                paymentdate = reader["paymentdate"] as DateTime?,
                                orderid = reader["orderid"].ToString()
                            });
                        }
                    }

                }
            }

            return (firstResults, secondResults);
        }

        public class FirstResult
        {
            public string TourName { get; set; }
            public string CustomerName { get; set; }
            public decimal Totalamount { get; set; }
            public decimal? STaxValue { get; set; }
            public decimal? AmtWithTax { get; set; }
            public decimal Discount { get; set; }
            public decimal? Advance { get; set; }
            public string address { get; set; }
            public string email { get; set; }
            public string TelNo { get; set; }
            public string Cancelled { get; set; }
        }

        public class SecondResult
        {
            public DateTime? Bookingdate { get; set; }
            public DateTime startdate { get; set; }
            public decimal? totalamount { get; set; }
            public decimal? advancepaid { get; set; }
            public DateTime? paymentdate { get; set; }
            public string orderid { get; set; }
        }

        public class ThridResult
        {
            public decimal Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string Country { get; set; }
            public DateTime? Dob { get; set; }
            public string TourName { get; set; }
            public DateTime? JourneyDate { get; set; }
            public int? TotalPax { get; set; }
            public string CarType { get; set; }
            public string FareCategoryType { get; set; }
            public string PassengerPerVehicle { get; set; }
            public int? AgentId { get; set; }
            public char? Status { get; set; }
            public int? TourId { get; set; }
            public decimal? Fare { get; set; }
            public string TicketNo { get; set; }
            public decimal? Servicetax { get; set; }
            public string SingleSharing { get; set; }
            public string PickUpVeh { get; set; }
            public string PickVehNo { get; set; }
            public string PickTime { get; set; }
            public string DropVeh { get; set; }
            public string DropVehNo { get; set; }
            public string DropTime { get; set; }
            public string Mobile { get; set; }
            public string Phone { get; set; }
            public string BranchCode { get; set; }
            public decimal? AdvancePaid { get; set; }
            public char Iscancel { get; set; }
            public decimal? CCCharges { get; set; }
            public string Comments { get; set; }
            public string Station { get; set; }
            public string PkStation { get; set; }
            public decimal? Discount { get; set; }
            public string PnrNo { get; set; }
            public string UserName { get; set; }
        }

        public class FourResult
        {
            public DateTime? Bookingdate { get; set; }
            public DateTime? Startdate { get; set; }
            public decimal? Totalamount { get; set; }
            public decimal? Advancepaid { get; set; }
            public DateTime? Paymentdate { get; set; }
            public int? Transactiontype { get; set; }
            public string PnrNo { get; set; }
        }
        public class SixResult
        {
            public DateTime Bookingdate { get; set; }
            public string Status { get; set; }
            public DateTime? Startdate { get; set; }
            public decimal? TotalAmount { get; set; }
            public decimal? Advancepaid { get; set; }
            public DateTime? Paymentdate { get; set; }
            public int? Transactiontype { get; set; }
            public string PnrNo { get; set; }

            public SixResult()
            {
            }
        }
        public class EightResult
        {
            public DateTime? Bookingdate { get; set; }
            public bool? Status { get; set; }
            public DateTime? Startdate { get; set; }
            public decimal? TotalAmount { get; set; }
            public decimal? Advancepaid { get; set; }
            public DateTime? Paymentdate { get; set; }
            public int? Transactiontype { get; set; }
            public string PnrNo { get; set; }

            public EightResult()
            {
            }
        }
    }

 

}