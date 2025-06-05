using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


namespace SouthernTravelsWeb.BLL
{
    /// <summary>
    /// Summary description for clsBLL
    /// </summary>
    public class clsBLL
    {
        public clsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Insert Record In Enquiry Table(ENq_tbl)
        /// </summary>
        /// <param name="pDescription"></param>
        /// <param name="pName"></param>
        /// <param name="pEmail"></param>
        /// <param name="pPhone"></param>
        /// <param name="pFax"></param>
        /// <param name="pStreet"></param>
        /// <param name="pCity"></param>
        /// <param name="pZIP"></param>
        /// <param name="pCountry"></param>
        /// <param name="pAdults"></param>
        /// <param name="pChild"></param>
        /// <param name="pArrivalDate"></param>
        /// <param name="pDeptDate"></param>
        /// <param name="pRequestType"></param>
        /// <param name="pRefNo"></param>
        /// <param name="pCaptcha"></param>
        /// <returns> Identity value of Success Full Insertion of Record </returns>
        public static int EnquiryTable_Entry(string pDescription, string pName, string pEmail, string pPhone,
         string pFax, string pStreet, string pCity, string pZIP, string pCountry, int pAdults, int pChild,
         DateTime pArrivalDate, DateTime pDeptDate, string pRequestType, string pRefNo, string pCaptcha)
        {
            int insertedId = 0;
            string connStr = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.EnquiryTable_Entry_SP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameters
                        cmd.Parameters.AddWithValue("@Description", pDescription);
                        cmd.Parameters.AddWithValue("@Name", pName);
                        cmd.Parameters.AddWithValue("@Email", pEmail);
                        cmd.Parameters.AddWithValue("@Phone", pPhone);
                        cmd.Parameters.AddWithValue("@Fax", pFax);
                        cmd.Parameters.AddWithValue("@Street", pStreet);
                        cmd.Parameters.AddWithValue("@City", pCity);
                        cmd.Parameters.AddWithValue("@Zip", pZIP);
                        cmd.Parameters.AddWithValue("@Country", pCountry);
                        cmd.Parameters.AddWithValue("@Adults", pAdults);
                        cmd.Parameters.AddWithValue("@Child", pChild);
                        cmd.Parameters.AddWithValue("@ArrivalDate", pArrivalDate);
                        cmd.Parameters.AddWithValue("@DepDate", pDeptDate);
                        cmd.Parameters.AddWithValue("@EnqType", pRequestType);
                        cmd.Parameters.AddWithValue("@RefNo", pRefNo);
                        cmd.Parameters.AddWithValue("@Captcha", pCaptcha);
                        cmd.Parameters.AddWithValue("@PanNo", ""); // Default/empty

                        // Output parameter
                        SqlParameter outputIdParam = new SqlParameter("@InsertedID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        insertedId = (int)outputIdParam.Value;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    insertedId = 0;
                }
            }

            return insertedId;
        }



        public static int EnquiryTable_Entry(string pDescription, string pName, string pEmail, string pPhone,
      string pFax, string pStreet, string pCity, string pZIP, string pCountry,
      int pAdults, int pChild, DateTime pArrivalDate, DateTime pDeptDate,
      string pRequestType, string pRefNo, string pCaptcha, string pPanNo)
        {
            int result = 0;
            string connectionString = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.ins_Enq_tbl, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Desc", pDescription ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@uName", pName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", pEmail ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Phone", pPhone ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Fax", pFax ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Street", pStreet ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@City", pCity ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Zip", pZIP ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Country", pCountry ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Adults", pAdults);
                        cmd.Parameters.AddWithValue("@Child", pChild);
                        cmd.Parameters.AddWithValue("@ArrivDate", pArrivalDate);
                        cmd.Parameters.AddWithValue("@DepDate", pDeptDate);
                        cmd.Parameters.AddWithValue("@type", pRequestType ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@refno", pRefNo ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@captcha", pCaptcha ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@I_PanNo", pPanNo ?? (object)DBNull.Value);

                        // Output parameter
                        SqlParameter outParam = new SqlParameter("@res", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);

                        cmd.ExecuteNonQuery();

                        result = outParam.Value != DBNull.Value ? Convert.ToInt32(outParam.Value) : 0;
                    }
                }
                catch (Exception ex)
                {
                    result = 2; 
                }
            }

            return result;
        }

        /// <summary>
        /// For Getting the Enquery Reference Code
        /// </summary>
        /// <param name="pEnqType"></param>
        /// <returns> Reference Code </returns>
        public static DataTable Getcode(string pEnqType)
        {
            DataTable dtResult = new DataTable();
            string connStr =DataLib.getConnectionString(); // Fetch the connection string from config

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.Get_EnqueryCode, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add the parameter for the stored procedure
                        cmd.Parameters.AddWithValue("@type", pEnqType);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtResult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Optional: log error
                    return null;
                }
            }

            return dtResult.Rows.Count > 0 ? dtResult.Copy() : null;
        }


        /// <summary>
        /// Insert Record In tbl_Paymentdetails Table
        /// </summary>
        /// <param name="pOrderID"></param>
        /// <param name="pItemCode"></param>
        /// <param name="pPaidStatus"></param>
        /// <param name="pAmount"></param>
        /// <param name="pCurrencyCode"></param>
        /// <param name="pBankName"></param>
        /// <returns> Integer value of Success Full Insertion of Record  </returns>

        public static int PaymentTable_Entry(
         string pOrderID, string pItemCode, char pPaidStatus, decimal pAmount, string pCurrencyCode,
         string pBankName, string EMIMonth, string SectionName, bool lIsHDFC, bool lIsPayU, string lPayMode)
        {
            try
            {
                string ipAddress = Convert.ToString(HttpContext.Current?.Request?.ServerVariables["REMOTE_ADDR"]) ?? string.Empty;

                ClsCommon clsCommon = new ClsCommon();

                // Call the method using the instance
                return clsCommon.fnInsertPaymentDetail(
                    pOrderID, pItemCode, pPaidStatus, pAmount, pCurrencyCode,
                    ipAddress, pBankName, EMIMonth, SectionName, lIsHDFC, lIsPayU, lPayMode);
            }
            catch
            {
                return 0;
            }
        }


    }
}
