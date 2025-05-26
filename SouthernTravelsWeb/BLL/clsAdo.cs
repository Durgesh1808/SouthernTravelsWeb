using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.BLL
{
    public class clsAdo
    {

        public List<customer_loginResult> fnGetCustomer_LoginInfo(string lEmail)
        {
            var resultList = new List<customer_loginResult>();
            string connString = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.customer_login, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 150) { Value = lEmail });

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new customer_loginResult();

                            item.Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : null;
                            item.rowid = reader["rowid"] != DBNull.Value ? Convert.ToInt32(reader["rowid"]) : 0;
                            item.firstname = reader["firstname"] != DBNull.Value ? reader["firstname"].ToString() : null;
                            item.email = reader["email"] != DBNull.Value ? reader["email"].ToString() : null;
                            item.mobile = reader["mobile"] != DBNull.Value ? reader["mobile"].ToString() : null;

                            resultList.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {             
                    return null;
                }
            }

            return resultList;
        }
        public int fninsert_OnlineCustomer(string lFname, string lLName, string lEmail, string lAdd1, string lAdd2,
string lCity, string lState, string lCountry, string lZip, string lAlterNo,
string lMobile, string lPWS, string lTitle, bool lCanSendPromotion)
        {
            int returnValue = -2;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand( StoredProcedures.insert_OnlineCustomer, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", lFname);
                    cmd.Parameters.AddWithValue("@LastName", lLName);
                    cmd.Parameters.AddWithValue("@email", lEmail);
                    cmd.Parameters.AddWithValue("@Addr1", lAdd1);
                    cmd.Parameters.AddWithValue("@Addr2", lAdd2);
                    cmd.Parameters.AddWithValue("@City", lCity);
                    cmd.Parameters.AddWithValue("@State", lState);
                    cmd.Parameters.AddWithValue("@Country", lCountry);
                    cmd.Parameters.AddWithValue("@zipcode", lZip);
                    cmd.Parameters.AddWithValue("@AlternativeNo", lAlterNo);
                    cmd.Parameters.AddWithValue("@Mobile", lMobile);
                    cmd.Parameters.AddWithValue("@password", lPWS);
                    cmd.Parameters.AddWithValue("@Title", lTitle);
                    cmd.Parameters.AddWithValue("@CanSendPromotions", lCanSendPromotion);

                    SqlParameter outputParam = new SqlParameter("@O_RetVal", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        returnValue = Convert.ToInt32(outputParam.Value);
                    }
                    catch (Exception)
                    {
                        returnValue = -2; // Indicates failure
                    }
                }
            }

            return returnValue;
        }
        public DataTable fnGetState()
        {
            DataTable dtStates = new DataTable();

            string connectionString = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.sp_GetState, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dtStates);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }

            return dtStates;
        }
        public DataTable fnonlinecustomer_details(int? lRowID)
        {
            DataTable ldtRecSet = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.onlinecustomer_details, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameter
                        cmd.Parameters.AddWithValue("@rowid", (object)lRowID ?? DBNull.Value);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ldtRecSet);
                        }
                    }

                    return ldtRecSet;
                }
                catch (Exception ex)
                {
                    // Log the exception if needed
                    return null;
                }
                finally
                {
                    if (ldtRecSet != null)
                    {
                        ldtRecSet.Dispose();
                    }
                }
            }
        }
        public int fnupdate_OnlineCustomer_PWD(int? lRowID, string lFname, string lLName, string lEmail,
            string lAdd1, string lAdd2, string lCity, string lState, string lCountry, string lZip,
            string lAlterNo, string lMobile, string lPWS, bool pCanSendPromotions)
        {
            int result = -1;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.update_OnlineCustomer_PWD, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@RowId", (object)lRowID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FirstName", lFname ?? "");
                        cmd.Parameters.AddWithValue("@LastName", lLName ?? "");
                        cmd.Parameters.AddWithValue("@email", lEmail ?? "");
                        cmd.Parameters.AddWithValue("@Addr1", lAdd1 ?? "");
                        cmd.Parameters.AddWithValue("@addr2", lAdd2 ?? "");
                        cmd.Parameters.AddWithValue("@City", lCity ?? "");
                        cmd.Parameters.AddWithValue("@state", lState ?? "");
                        cmd.Parameters.AddWithValue("@Country", lCountry ?? "");
                        cmd.Parameters.AddWithValue("@zipcode", lZip ?? "");
                        cmd.Parameters.AddWithValue("@AlternativeNo", lAlterNo ?? "");
                        cmd.Parameters.AddWithValue("@Mobile", lMobile ?? "");
                        cmd.Parameters.AddWithValue("@password", lPWS ?? "");
                        cmd.Parameters.AddWithValue("@CanSendPromotions", pCanSendPromotions);

                        // Optional: if the procedure returns an output parameter or result
                        SqlParameter returnParameter = new SqlParameter();
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returnParameter);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        result = Convert.ToInt32(returnParameter.Value);
                    }
                }
                catch (Exception ex)
                {
                    // Optional: log error
                    result = -2;
                }
            }

            return result;
        }
        public int fnupdate_OnlineCustomer(int? lRowID, string lTitel, string lFname, string lLName, string lEmail,
    string lAdd1, string lAdd2, string lCity, string lState, string lCountry, string lZip, string lAlterNo,
    string lMobile, char lUserStatus, bool lCanSendPromotions)
        {
            int result = -1;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.update_OnlineCustomer, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@RowId", (object)lRowID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Title", lTitel ?? "");
                        cmd.Parameters.AddWithValue("@FirstName", lFname ?? "");
                        cmd.Parameters.AddWithValue("@LastName", lLName ?? "");
                        cmd.Parameters.AddWithValue("@email", lEmail ?? "");
                        cmd.Parameters.AddWithValue("@Addr1", lAdd1 ?? "");
                        cmd.Parameters.AddWithValue("@addr2", lAdd2 ?? "");
                        cmd.Parameters.AddWithValue("@City", lCity ?? "");
                        cmd.Parameters.AddWithValue("@state", lState ?? "");
                        cmd.Parameters.AddWithValue("@Country", lCountry ?? "");
                        cmd.Parameters.AddWithValue("@zipcode", lZip ?? "");
                        cmd.Parameters.AddWithValue("@AlternativeNo", lAlterNo ?? "");
                        cmd.Parameters.AddWithValue("@Mobile", lMobile ?? "");
                        cmd.Parameters.AddWithValue("@Status", lUserStatus);
                        cmd.Parameters.AddWithValue("@CanSendPromotions", lCanSendPromotions);

                        // If the stored procedure uses a RETURN value:
                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returnValue);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        result = Convert.ToInt32(returnValue.Value);
                    }
                }
                catch (Exception ex)
                {
                    result = -2;
                }
            }

            return result;
        }

        public DataTable fncustomer_bookedtickets(int? lRowID)
        {
            DataTable ldtRecSet = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.customer_bookedtickets, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@rowid", (object)lRowID ?? DBNull.Value);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ldtRecSet);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (ldtRecSet != null)
                    {
                        ldtRecSet.Dispose();
                    }
                }
            }

            return ldtRecSet;
        }
        public DataTable fncustomer_journeydate(string lTicketCode)
        {
            DataTable pdtTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.customer_journeydate, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ticketcode", string.IsNullOrEmpty(lTicketCode) ? DBNull.Value : (object)lTicketCode);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(pdtTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Optional: log exception here
                    return null;
                }
                finally
                {
                    if (pdtTable != null)
                    {
                        pdtTable.Dispose();
                        pdtTable = null;
                    }
                }
            }

            return pdtTable;
        }
        public DataTable fnrequest_ltc(string lTicketCode, int? lCustID, ref int? pStatus)
        {
            DataTable pdtTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.request_ltc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ticket", string.IsNullOrEmpty(lTicketCode) ? DBNull.Value : (object)lTicketCode);
                        cmd.Parameters.AddWithValue("@rowid", lCustID.HasValue ? (object)lCustID.Value : DBNull.Value);

                        SqlParameter statusParam = new SqlParameter("@ReturnValue", SqlDbType.Int);
                        statusParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(statusParam);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(pdtTable);
                        }

                        if (statusParam.Value != DBNull.Value)
                        {
                            pStatus = Convert.ToInt32(statusParam.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Optional: log the error
                    return null;
                }
                finally
                {
                    if (pdtTable != null)
                    {
                        pdtTable.Dispose();
                        pdtTable = null;
                    }
                }
            }

            return pdtTable;
        }
        public DataTable fncustomer_cancelledtickets(int? lRowID)
        {
            DataTable ldtRecSet = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.customer_cancelledtickets, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@rowid", lRowID.HasValue ? (object)lRowID.Value : DBNull.Value);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ldtRecSet);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return ldtRecSet;
        }
        public int fnInsertPaymentDetail(string pOrderID, string pItemCode, char pPaidStatus, decimal pAmount, string pCurrencyCode, string pIPAdd, string pBankName, string pEMIMonth,
    string pSectionName, bool lIsHDFC, bool lIsPayU, string lPayMode)
        {
            int lStatus = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.InsertPaymentDetail_Sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@OrderId", pOrderID);
                        cmd.Parameters.AddWithValue("@ItemCode", pItemCode);
                        cmd.Parameters.AddWithValue("@Amount", pAmount);
                        cmd.Parameters.AddWithValue("@IsPaid", pPaidStatus);
                        cmd.Parameters.AddWithValue("@Currency", pCurrencyCode);
                        cmd.Parameters.AddWithValue("@IP", pIPAdd);
                        cmd.Parameters.AddWithValue("@EMIMonth", pEMIMonth);
                        cmd.Parameters.AddWithValue("@BankName", pBankName);
                        cmd.Parameters.AddWithValue("@SectionName", pSectionName);
                        cmd.Parameters.AddWithValue("@IsHDFC", lIsHDFC);
                        cmd.Parameters.AddWithValue("@IsPayU", lIsPayU);
                        cmd.Parameters.AddWithValue("@PayMode", lPayMode);

                        SqlParameter outParam = new SqlParameter("@TourRowId", SqlDbType.Int);
                        outParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        if (outParam.Value != DBNull.Value)
                            lStatus = Convert.ToInt32(outParam.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception if needed
                lStatus = 0;
            }

            return lStatus;
        }

        public DataSet fnOnlineBalanceClear(string lTicketNo, string lTktCode)
        {
            DataSet pdtDTSet = new DataSet();


            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.OnlineBalanceClear_sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TicketNo", lTicketNo);

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (lTktCode == "EBK")
                            {
                                // First result set
                                DataTable dt1 = new DataTable("FirstResult");
                                dt1.Load(reader);
                                pdtDTSet.Tables.Add(dt1);

                                // Move to second result set
                                if (reader.NextResult())
                                {
                                    DataTable dt2 = new DataTable("SecondResult");
                                    dt2.Load(reader);
                                    pdtDTSet.Tables.Add(dt2);
                                }
                            }
                            else if (lTktCode == "SPL")
                            {
                                // Third result set
                                DataTable dt3 = new DataTable("ThridResult");
                                dt3.Load(reader);
                                pdtDTSet.Tables.Add(dt3);

                                // Fourth result set
                                if (reader.NextResult())
                                {
                                    DataTable dt4 = new DataTable("FourResult");
                                    dt4.Load(reader);
                                    pdtDTSet.Tables.Add(dt4);
                                }
                            }
                            else if (lTktCode == "GRP")
                            {
                                // Fifth result set
                                DataTable dt5 = new DataTable("FiveResult");
                                dt5.Load(reader);
                                pdtDTSet.Tables.Add(dt5);

                                // Sixth result set
                                if (reader.NextResult())
                                {
                                    DataTable dt6 = new DataTable("SixResult");
                                    dt6.Load(reader);
                                    pdtDTSet.Tables.Add(dt6);
                                }
                            }
                            else if (lTktCode == "INT")
                            {
                                // Seventh result set
                                DataTable dt7 = new DataTable("SevenResult");
                                dt7.Load(reader);
                                pdtDTSet.Tables.Add(dt7);

                                // Eighth result set
                                if (reader.NextResult())
                                {
                                    DataTable dt8 = new DataTable("EightResult");
                                    dt8.Load(reader);
                                    pdtDTSet.Tables.Add(dt8);
                                }
                            }
                        }
                        return pdtDTSet;
                    }
                    catch (Exception ex)
                    {
                        // Log error as needed
                        return null;
                    }
                }
            }
        }

        public int fnInsertPaymentHDFCPG(
    string lPaymentID, string lOrderID, string lEmailId, string lAuth,
    decimal lAmount, string lRef, string lTranID, string lTrackID, string lPostDate,
    string lResult, string lErrorText, string lUDF1, string lUDF2, string lUDF3,
    string lUDF4, string lUDF5, string lUDF6, string lSectionName)
        {
            int returnValue = 0;

            string connStr = DataLib.getConnectionString(); // Your method for connection string

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.InsertPaymentHDFCPG_SP, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input Parameters
                cmd.Parameters.AddWithValue("@I_PaymentID", lPaymentID);
                cmd.Parameters.AddWithValue("@I_OrderID", lOrderID);
                cmd.Parameters.AddWithValue("@I_EmailID", lEmailId);
                cmd.Parameters.AddWithValue("@I_Auth", lAuth);
                cmd.Parameters.AddWithValue("@I_Amount", lAmount);
                cmd.Parameters.AddWithValue("@I_Ref", lRef);
                cmd.Parameters.AddWithValue("@I_TranID", lTranID);
                cmd.Parameters.AddWithValue("@I_TrackID", lTrackID);
                cmd.Parameters.AddWithValue("@I_PostDate", lPostDate);
                cmd.Parameters.AddWithValue("@I_Result", lResult);
                cmd.Parameters.AddWithValue("@I_ErrorText", lErrorText);
                cmd.Parameters.AddWithValue("@I_Udf1", lUDF1);
                cmd.Parameters.AddWithValue("@I_Udf2", lUDF2);
                cmd.Parameters.AddWithValue("@I_Udf3", lUDF3);
                cmd.Parameters.AddWithValue("@I_Udf4", lUDF4);
                cmd.Parameters.AddWithValue("@I_Udf5", lUDF5);
                cmd.Parameters.AddWithValue("@I_Udf6", lUDF6);
                cmd.Parameters.AddWithValue("@I_SectionName", lSectionName);

                // Output parameter
                SqlParameter outputParam = new SqlParameter("@I_RetrunValue", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(outputParam.Value);
                }
                catch (Exception ex)
                {
                    // Optionally log the error
                    returnValue = -2;
                }
            }

            return returnValue;
        }


        public DataTable fncustomer_splbookedtickets(int? lRowID)
        {
            DataTable ldtRecSet = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.customer_splbookedtickets, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter
                    cmd.Parameters.AddWithValue("@rowid", (object)lRowID ?? DBNull.Value);

                    // Fill DataTable
                    da.Fill(ldtRecSet);
                }

                return ldtRecSet;
            }
            catch (Exception ex)
            {
                // You may log the exception here if needed
                return null;
            }
        }
        public DataTable fncustomer_Groupbookedtickets(int? lRowID)
        {
            DataTable ldtRecSet = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.customer_Groupbookedtickets, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@rowid", (object)lRowID ?? DBNull.Value);

                    conn.Open();
                    da.Fill(ldtRecSet);
                }

                return ldtRecSet;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}