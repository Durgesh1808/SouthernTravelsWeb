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


        public List<GetTourStratFrom_SPResult> fnGetTourStratFrom(int lTourID, int lTourType)
        {
            List<GetTourStratFrom_SPResult> lResult = new List<GetTourStratFrom_SPResult>();

            string connString = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourStratFrom_SP, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@I_TourNo", lTourID);
                    cmd.Parameters.AddWithValue("@I_TourType", lTourType);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GetTourStratFrom_SPResult item = new GetTourStratFrom_SPResult
                                {
                                    TourID = reader.GetInt32(reader.GetOrdinal("TourID")),
                                    TourCode = reader["TourCode"] as string,
                                    TourName = reader["TourName"] as string,
                                    TourStartFrom = reader["TourStartFrom"] != DBNull.Value ? (int?)Convert.ToInt32(reader["TourStartFrom"]) : null,
                                    TourSequence = reader["TourSequence"] != DBNull.Value ? (int?)Convert.ToInt32(reader["TourSequence"]) : null
                                };

                                lResult.Add(item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle/log error
                        return null;
                    }
                }
            }

            return lResult;
        }

        public List<GetTourStartFromSearch_SPResult> fnGetTourStartFromSearch(int lTourType)
        {
            List<GetTourStartFromSearch_SPResult> lResult = new List<GetTourStartFromSearch_SPResult>();

            string connString = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourStartFromSearch_SP, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@I_TourType", lTourType);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GetTourStartFromSearch_SPResult item = new GetTourStartFromSearch_SPResult
                                {
                                    CityID = reader.GetInt32(reader.GetOrdinal("CityID")),
                                    CityName = reader["CityName"] as string
                                };

                                lResult.Add(item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle/log error here as needed
                        return null;
                    }
                }
            }

            return lResult;
        }

        public DataTable fnGetSpecialTourJourneyDate(int lTourNo, int lMonth, int lYear, int lHours)
        {
            DataTable ldtRecSet = new DataTable();

            String connString = System.Configuration.ConfigurationManager.AppSettings["southernconn"];

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetSpecialTourJourneyDate_SP, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@I_TourNo", lTourNo);  
                    cmd.Parameters.AddWithValue("@I_Month", lMonth);
                    cmd.Parameters.AddWithValue("@I_Year", lYear);
                    cmd.Parameters.AddWithValue("@I_Hours", lHours);

                    try
                    {
                        conn.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ldtRecSet);
                        }

                        return ldtRecSet;
                    }
                    catch (Exception ex)
                    {
                        // Log or handle error
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
        }
        public List<GetTourS_Search_SPResult> fnGetTourS_Search(string lStartFrom, string lTourSearchText, int lTourType)
        {
            List<GetTourS_Search_SPResult> lResult = new List<GetTourS_Search_SPResult>();
            string connString = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourS_Search_SP, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@I_StartFrom", lStartFrom ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@I_TourSearchText", lTourSearchText ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@I_TourType", lTourType);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GetTourS_Search_SPResult item = new GetTourS_Search_SPResult
                                {
                                    TourNo = reader.GetInt16(reader.GetOrdinal("TourNo")),
                                    Tour_Short_key = reader["Tour_Short_key"] as string,
                                    TourName = reader["TourName"] as string
                                };

                                lResult.Add(item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }

            return lResult;
        }
        public List<FindSpl_TourMaster_spResult> fnFindSpl_TourMaster(int? lTourID)
        {
            List<FindSpl_TourMaster_spResult> result = new List<FindSpl_TourMaster_spResult>();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.FindSpl_TourMaster_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_TourID", (object)lTourID ?? DBNull.Value);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new FindSpl_TourMaster_spResult
                            {
                                Tourid = reader.GetInt32(reader.GetOrdinal("Tourid")),
                                Tourcode = reader["Tourcode"] as string,
                                TourName = reader["TourName"] as string,
                                Duration = reader["Duration"] as string,
                                Fare = reader["Fare"] as decimal?,
                                Remarks = reader["Remarks"] as string,
                                Addedby = reader["Addedby"] as string,
                                addeddate = reader["addeddate"] as DateTime?,
                                AgentComission1 = reader["AgentComission1"] as double?,
                                AgentComission2 = reader["AgentComission2"] as double?,
                                AgentComission3 = reader["AgentComission3"] as double?,
                                DeptTime = reader["DeptTime"] as string,
                                CostIncludes = reader["CostIncludes"] as string,
                                CostExcludes = reader["CostExcludes"] as string,
                                InstentBooking = reader["InstentBooking"] as char?,
                                BlockJdatefrom = reader["BlockJdatefrom"] as DateTime?,
                                BlockJdateTo = reader["BlockJdateTo"] as DateTime?,
                                ZoneId = reader["ZoneId"] as decimal?,
                                Notes = reader["Notes"] as string,
                                City = reader["City"] as string,
                                Itinerary = reader["Itinerary"] as string,
                                UpdatedBy = reader["UpdatedBy"] as string,
                                UpdatedOn = reader["UpdatedOn"] as DateTime?,
                                AgentComission4 = reader["AgentComission4"] as double?,
                                isweekendtour = reader["isweekendtour"] as char?,
                                DestCovered = reader["DestCovered"] as string,
                                Conditions = reader["Conditions"] as string,
                                RegionId = reader["RegionId"] as int?,
                                NoOfDays = reader["NoOfDays"] as int?,
                                NoOfNights = reader["NoOfNights"] as int?,
                                IsNonAccommodation = reader["IsNonAccommodation"] as bool?,
                                TourStartFrom = reader["TourStartFrom"] as int?,
                                ReturnTime = reader["ReturnTime"] as string,
                                TourPolicy = reader["TourPolicy"] as string,
                                IsQuery = reader["IsQuery"] as bool?
                            };

                            result.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Optional: log the exception
                    // LogError(ex);
                    return null;
                }
            }

            return result;
        }
        public List<TourItenerary_SPResult> fnGetTourItenerary(int lTourID, int lTourType)
        {
            List<TourItenerary_SPResult> lResult = new List<TourItenerary_SPResult>();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.TourItenerary_SP, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@I_TourID", lTourID);
                    cmd.Parameters.AddWithValue("@I_TourType", lTourType);

                    SqlParameter outputParam = new SqlParameter("@O_ReturnValue", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TourItenerary_SPResult result = new TourItenerary_SPResult
                                {
                                    Tour_Short_key = reader["Tour_Short_key"] as string,
                                    ISAccomodation = reader["ISAccomodation"] as char?,
                                    TourName = reader["TourName"] as string,
                                    Departuretime = reader["Departuretime"] as string,
                                    ReturnTime = reader["ReturnTime"] as string,
                                    CostIncludes = reader["CostIncludes"] as string,
                                    CostExcludes = reader["CostExcludes"] as string,
                                    Duration = reader["Duration"] as string,
                                    TourPolicy = reader["TourPolicy"] as string,
                                    Notes = reader["Notes"] as string,
                                    OccasionalItinerary = reader["OccasionalItinerary"] as string,
                                    NoOfDays = reader["NoOfDays"] as int?,
                                    NoOfNights = reader["NoOfNights"] as int?,
                                    DepartureWeekDays = reader["DepartureWeekDays"] as string,
                                    ReturnWweekDays = reader["ReturnWweekDays"] as string,
                                    TourGoingOn = reader["TourGoingOn"] as string,
                                    ImagePath = reader["ImagePath"] as string,
                                    CoachDetails = reader["CoachDetails"] as string,
                                    ZoneName = reader["ZoneName"] as string,
                                    State = reader["State"] as string,
                                    Fair = reader["Fair"] != DBNull.Value ? Convert.ToDecimal(reader["Fair"]) : 0,
                                    TourCost = reader["TourCost"] as string,
                                    HolidayType = reader["HolidayType"] as string,
                                    OfferZone = reader["OfferZone"] as string,
                                    Remarks = reader["Remarks"] as string,
                                    PageBanner = reader["PageBanner"] as string,
                                    ImageDescription = reader["ImageDescription"] as string,
                                    IsQuery = reader["IsQuery"] != DBNull.Value ? Convert.ToBoolean(reader["IsQuery"]) : false
                                };

                                lResult.Add(result);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle as needed
                        return new List<TourItenerary_SPResult>(); // Return empty list on error
                    }
                }
            }

            return lResult;
        }

        public DataTable fnGetMetaTagForTours(int? TourTypeId, int? TourId, int? CountryId, int? ZoneId)
        {
            DataTable dtResult = new DataTable();

            try
            {
                string connectionString = DataLib.getConnectionString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetMetTagForTours_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TourTypeId", (object)TourTypeId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@TourId", (object)TourId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CountryId", (object)CountryId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ZoneId", (object)ZoneId ?? DBNull.Value);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dtResult);
                        }
                    }
                }

                return dtResult;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (dtResult != null)
                {
                    dtResult.Dispose();
                }
            }
        }
        public List<Get_SPL_Fare_Panel_spResult> Get_SpecialTour_FarePanel(
       string i_FareType, int? i_TourID, bool? i_IsLTC,
       out bool? o_IsAccomodation, out int? o_ReturnValue,
       out string o_TourName, out string o_Notes, out bool? o_IsQuery)
        {
            var list = new List<Get_SPL_Fare_Panel_spResult>();

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.Get_SpecialTour_FarePanel_NEW_sp, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input Parameters
                cmd.Parameters.AddWithValue("@I_FareType", i_FareType ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@I_TourID", i_TourID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@I_IsLTC", i_IsLTC ?? (object)DBNull.Value);

                // Output Parameters
                SqlParameter p1 = new SqlParameter("@O_IsAccomodation", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                SqlParameter p2 = new SqlParameter("@O_ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter p3 = new SqlParameter("@O_TourName", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                SqlParameter p4 = new SqlParameter("@O_Notes", SqlDbType.VarChar, 1000) { Direction = ParameterDirection.Output };
                SqlParameter p5 = new SqlParameter("@O_IsQuery", SqlDbType.Bit) { Direction = ParameterDirection.Output };

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new Get_SPL_Fare_Panel_spResult
                        {
                            PanelID = dr.GetInt32(dr.GetOrdinal("PanelID")),
                            FareID = dr.GetInt32(dr.GetOrdinal("FareID")),
                            CategoryName = dr["CategoryName"] as string,
                            Fare = dr["Fare"] as decimal?,
                            FromDate = dr["FromDate"] as DateTime?,
                            ToDate = dr["ToDate"] as DateTime?,
                            s_month = dr["s_month"] as string,
                            CategoryID = dr["CategoryID"] as int?,
                            Season = dr["Season"] as string,
                            SeasonID = dr["SeasonID"] as long?,
                            VehicleID = dr.GetInt32(dr.GetOrdinal("VehicleID")),
                            VehicleName = dr["VehicleName"] as string,
                            PaxID = dr.GetInt32(dr.GetOrdinal("PaxID")),
                            PaxType = dr["PaxType"] as string,
                            ParentID = dr.GetInt32(dr.GetOrdinal("ParentID")),
                            ParentCategory = dr["ParentCategory"] as string,
                            DiscountedFare = dr["DiscountedFare"] as decimal?,
                            IsAgent = Convert.ToBoolean(dr["IsAgent"]),
                            IsBranch = Convert.ToBoolean(dr["IsBranch"]),
                            IsOnline = Convert.ToBoolean(dr["IsOnline"])
                        };

                        list.Add(item);
                    }
                }

                // Get Output Values
                o_IsAccomodation = p1.Value != DBNull.Value ? (bool?)Convert.ToBoolean(p1.Value) : null;
                o_ReturnValue = p2.Value != DBNull.Value ? (int?)Convert.ToInt32(p2.Value) : null;
                o_TourName = p3.Value?.ToString();
                o_Notes = p4.Value?.ToString();
                o_IsQuery = p5.Value != DBNull.Value ? (bool?)Convert.ToBoolean(p5.Value) : null;
            }

            return list;
        }
        public DataTable fnGetTour(int? lHour)
        {
            DataTable pdtTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTour_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Handle nullable int parameter
                        cmd.Parameters.Add("@i_Hr", SqlDbType.Int).Value = (object)lHour ?? DBNull.Value;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(pdtTable);
                        }
                    }
                }

                return pdtTable;
            }
            catch (Exception ex)
            {
                // Log or handle error
                return null;
            }
            finally
            {
                if (pdtTable != null)
                {
                    pdtTable.Dispose();
                }
            }
        }
        public string fnGetServiceTaxIsAcc(int? lTourNo)
        {
            string lTaxValue = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetServiceTaxIsAcc_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameter
                        cmd.Parameters.Add("@i_TourNo", SqlDbType.Int).Value = (object)lTourNo ?? DBNull.Value;

                        // Output parameter
                        SqlParameter outputParam = new SqlParameter("@o_ReturnValue", SqlDbType.VarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        // Return value
                        SqlParameter returnValue = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        cmd.Parameters.Add(returnValue);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Get the output parameter value
                        lTaxValue = outputParam.Value != DBNull.Value ? outputParam.Value.ToString() : "";

                        // Optionally, get return value if needed:
                        // int returnVal = (int)returnValue.Value;
                    }
                }

                return lTaxValue;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public decimal fnGetServiceTaxValue(string pTaxType)
        {
            decimal lTaxValue = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetServiceTaxValue_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameter
                        cmd.Parameters.Add("@I_TaxType", SqlDbType.VarChar, 50).Value = pTaxType ?? (object)DBNull.Value;

                        // Output parameter
                        SqlParameter outputParam = new SqlParameter("@I_OReturnValue", SqlDbType.Float)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        if (outputParam.Value != DBNull.Value)
                            lTaxValue = Convert.ToDecimal(outputParam.Value);
                    }
                }

                return lTaxValue;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public List<GetOverrideServiceTax_SPResult> fnGetOverrideServiceTax(int lTourType, int lTourID, string lTaxCode)
        {
            List<GetOverrideServiceTax_SPResult> resultList = new List<GetOverrideServiceTax_SPResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("GetOverrideServiceTax_SP", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@I_TourType", SqlDbType.Int).Value = lTourType;
                    cmd.Parameters.Add("@I_TourID", SqlDbType.Int).Value = lTourID;
                    cmd.Parameters.Add("@I_TaxCode", SqlDbType.VarChar, 50).Value = lTaxCode ?? (object)DBNull.Value;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new GetOverrideServiceTax_SPResult
                            {
                                RowID = reader.GetInt32(reader.GetOrdinal("RowID")),
                                TaxID = reader["TaxID"] as int?,
                                TaxCode = reader["TaxCode"] as string,
                                TourType = reader["TourType"] as int?,
                                TourID = reader["TourID"] as int?,
                                NewTax = reader["NewTax"] as decimal?,
                                ApplicableOn = reader["ApplicableOn"] != DBNull.Value ? Convert.ToChar(reader["ApplicableOn"]) : (char?)null,
                                IsActive = reader["IsActive"] as bool?,
                                ApplicableFrom = reader["ApplicableFrom"] as DateTime?,
                                ApplicableTo = reader["ApplicableTo"] as DateTime?,
                                CreatedOn = reader["CreatedOn"] as DateTime?,
                                CreatedBy = reader.GetInt32(reader.GetOrdinal("CreatedBy")),
                                LastUpdatedOn = reader["LastUpdatedOn"] as DateTime?,
                                LastUpdatedBy = reader["LastUpdatedBy"] as int?
                            };

                            resultList.Add(item);
                        }
                    }
                }

                return resultList;
            }
            catch (Exception ex)
            {
                // Log the error if needed
                return null;
            }
        }
        public string fnGetCombinationTour(int? lTourID)
        {
            string lStatus = "-1";

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetCombinationTour_sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameter
                        cmd.Parameters.AddWithValue("@i_TourNo", (object)lTourID ?? DBNull.Value);

                        // Output parameter
                        SqlParameter outParam = new SqlParameter("@o_ReturnValue", SqlDbType.VarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);

                        // Open connection and execute
                        con.Open();
                        cmd.ExecuteNonQuery();

                        // Get output value
                        lStatus = outParam.Value?.ToString() ?? "-1";
                    }
                }
                catch (Exception ex)
                {
                    // Log error as needed
                    return null;
                }
            }

            return lStatus;
        }
        public string fnGetLTCCharges()
        {
            string result = null;

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetLTCCharges_sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Output parameter
                        SqlParameter outParam = new SqlParameter("@o_ReturnValue", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 2,
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        // Read and return the output value as string
                        if (outParam.Value != DBNull.Value)
                            result = Convert.ToString(outParam.Value);
                    }
                }
                catch (Exception ex)
                {
                    result = null;
                }
            }

            return result;
        }
        public int fnGet_RowWiseTourID(int? lRowID)
        {
            int lTourID = 0;

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.RowWiseTourID_sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameter
                        cmd.Parameters.Add(new SqlParameter("@i_RowID", SqlDbType.Int)
                        {
                            Value = (object)lRowID ?? DBNull.Value
                        });

                        // Output parameter
                        SqlParameter outParam = new SqlParameter("@o_ReturnValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        if (outParam.Value != DBNull.Value)
                            lTourID = Convert.ToInt32(outParam.Value);
                    }
                }
                catch (Exception ex)
                {
                    lTourID = 0;
                }
            }

            return lTourID;
        }
        public int fnDeleteOnlineToursBooking(string lRowID)
        {
            int lStatus = 0;

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.DeleteOnlineToursBooking_sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameter
                        cmd.Parameters.Add(new SqlParameter("@i_RowID", SqlDbType.VarChar, 50)
                        {
                            Value = lRowID
                        });

                        // Output parameter
                        SqlParameter outParam = new SqlParameter("@o_ReturnValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        if (outParam.Value != DBNull.Value)
                            lStatus = Convert.ToInt32(outParam.Value);
                    }
                }
                catch (Exception ex)
                {
                    lStatus = 0;
                }
            }

            return lStatus;
        }
        public DataTable fnGetCustomerDetail(string lSearchValue)
        {
            DataTable pdtTable = new DataTable();

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetCustomerDetail_sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameter
                        cmd.Parameters.Add(new SqlParameter("@i_EmailorMbNo", SqlDbType.VarChar, 50)
                        {
                            Value = lSearchValue
                        });

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(pdtTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return pdtTable;
        }
        public void SaveTransactionByPromoCode(string pOrderID, string pPromoCode, bool pIsPercentage,
    ref double? pPromoDiscount, ref int? pStatus)
        {
            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.SaveTransactionByPromoCode_sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameters
                        cmd.Parameters.Add(new SqlParameter("@I_OrderID", SqlDbType.VarChar, 50) { Value = pOrderID });
                        cmd.Parameters.Add(new SqlParameter("@I_PromoCode", SqlDbType.Char, 10) { Value = pPromoCode });
                        cmd.Parameters.Add(new SqlParameter("@I_IsPercentage", SqlDbType.Bit) { Value = pIsPercentage });

                        // Output parameters
                        SqlParameter promoDiscountParam = new SqlParameter("@O_PromoCodeDiscount", SqlDbType.Float)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(promoDiscountParam);

                        SqlParameter statusParam = new SqlParameter("@O_ReturnValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(statusParam);

                        // Open connection and execute
                        con.Open();
                        cmd.ExecuteNonQuery();

                        // Retrieve output values
                        pPromoDiscount = promoDiscountParam.Value != DBNull.Value ? Convert.ToDouble(promoDiscountParam.Value) : (double?)null;
                        pStatus = statusParam.Value != DBNull.Value ? Convert.ToInt32(statusParam.Value) : (int?)0;
                    }
                }
                catch (Exception)
                {
                    pStatus = 0;
                }
            }
        }
        public DataTable fnGetSumOfTourAmt(string lOrderID)
        {
            DataTable dtResult = new DataTable();

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetSumOfTourAmt_sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@i_OrderID", SqlDbType.VarChar, 50) { Value = lOrderID });

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtResult);
                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return dtResult;
        }


        public int fninsert_tbl_PaymentDetails(string lOrderID, string lItemCode, decimal? lAmount, string lBankName, char? lIsPaid, string lGatewayBID,
    string lOrderDetail, string lCurrency, string lPayMode, decimal lCcChargeAmt, bool? lIsHDFC, string lIP, decimal? lTotalAmt, string EMIMonth, string SectionName)
        {
            int result = -1;

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.insert_tbl_PaymentDetails, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@orderId", string.IsNullOrEmpty(lOrderID) ? (object)DBNull.Value : lOrderID);
                        cmd.Parameters.AddWithValue("@itemCode", string.IsNullOrEmpty(lItemCode) ? (object)DBNull.Value : lItemCode);
                        cmd.Parameters.AddWithValue("@Amount", lAmount.HasValue ? (object)lAmount.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@BankName", string.IsNullOrEmpty(lBankName) ? (object)DBNull.Value : lBankName);
                        cmd.Parameters.AddWithValue("@IsPaid", lIsPaid.HasValue ? (object)lIsPaid.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@gatewayBID", string.IsNullOrEmpty(lGatewayBID) ? (object)DBNull.Value : lGatewayBID);
                        cmd.Parameters.AddWithValue("@orderDetails", string.IsNullOrEmpty(lOrderDetail) ? (object)DBNull.Value : lOrderDetail);
                        cmd.Parameters.AddWithValue("@currency", string.IsNullOrEmpty(lCurrency) ? (object)DBNull.Value : lCurrency);
                        cmd.Parameters.AddWithValue("@payMode", string.IsNullOrEmpty(lPayMode) ? (object)DBNull.Value : lPayMode);
                        cmd.Parameters.AddWithValue("@ccChargeAmt", lCcChargeAmt); // assuming always passed
                        cmd.Parameters.AddWithValue("@isHDFC", lIsHDFC.HasValue ? (object)lIsHDFC.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@ip", string.IsNullOrEmpty(lIP) ? (object)DBNull.Value : lIP);
                        cmd.Parameters.AddWithValue("@EMIMonth", string.IsNullOrEmpty(EMIMonth) ? (object)DBNull.Value : EMIMonth);
                        cmd.Parameters.AddWithValue("@SectionName", string.IsNullOrEmpty(SectionName) ? (object)DBNull.Value : SectionName);
                        cmd.Parameters.AddWithValue("@TotalAmount", lTotalAmt.HasValue ? (object)lTotalAmt.Value : DBNull.Value);

                        con.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    result = -1;
                }
            }

            return result;
        }
        public int fnGetPickUpMAsterRowID(int? lTourNo, string pFromSection, int? pROwID)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetPickUpMAsterRowID_sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@i_TourNo", lTourNo.HasValue ? (object)lTourNo.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@I_FromSection", string.IsNullOrEmpty(pFromSection) ? (object)DBNull.Value : pFromSection);
                        cmd.Parameters.AddWithValue("@I_RowID", pROwID.HasValue ? (object)pROwID.Value : DBNull.Value);

                        SqlParameter outputParam = new SqlParameter("@o_ReturnValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        if (outputParam.Value != DBNull.Value)
                        {
                            result = Convert.ToInt32(outputParam.Value);
                        }
                    }
                }
                catch (Exception)
                {
                    result = 0;
                }
            }

            return result;
        }
        public DataSet fnGetDiscount_Detail(int? lTourNo, DateTime? ljDate)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetDiscount_Detail, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@i_TourNo", lTourNo.HasValue ? (object)lTourNo.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_jDate", ljDate.HasValue ? (object)ljDate.Value : DBNull.Value);

                    try
                    {
                        con.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                    catch (Exception)
                    {
                        return null; // Or handle/log the error as needed
                    }
                }
            }

            return ds;
        }


        public List<GetFbDetail_spResult> fnGetFaceBookDetail(string lEmailMob, string lFaceBookID)
        {
            List<GetFbDetail_spResult> results = new List<GetFbDetail_spResult>();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetFbDetail_sp ,conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FaceBookId", string.IsNullOrEmpty(lFaceBookID) ? (object)DBNull.Value : lFaceBookID);
                cmd.Parameters.AddWithValue("@i_EmailorMbNo", string.IsNullOrEmpty(lEmailMob) ? (object)DBNull.Value : lEmailMob);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetFbDetail_spResult item = new GetFbDetail_spResult
                            {
                                UserId = reader["UserId"] != DBNull.Value ? Convert.ToInt32(reader["UserId"]) : 0,
                                RowId = reader["RowId"] != DBNull.Value ? Convert.ToInt32(reader["RowId"]) : 0,
                                FirstName = reader["FirstName"]?.ToString(),
                                LastName = reader["LastName"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                password = reader["password"]?.ToString(),
                                Addr1 = reader["Addr1"]?.ToString(),
                                addr2 = reader["addr2"]?.ToString(),
                                City = reader["City"]?.ToString(),
                                state = reader["state"]?.ToString(),
                                Country = reader["Country"]?.ToString(),
                                zipcode = reader["zipcode"]?.ToString(),
                                PhoneNo = reader["PhoneNo"]?.ToString(),
                                AlternativeName = reader["AlternativeName"]?.ToString(),
                                RelativePhoneNo = reader["RelativePhoneNo"]?.ToString(),
                                AlternativeNo = reader["AlternativeNo"]?.ToString(),
                                Mobile = reader["Mobile"]?.ToString(),
                                Fax = reader["Fax"]?.ToString(),
                                DOB = reader["DOB"] != DBNull.Value ? Convert.ToDateTime(reader["DOB"]) : (DateTime?)null,
                                company = reader["company"]?.ToString(),
                                occupation = reader["occupation"]?.ToString(),
                                remark = reader["remark"]?.ToString(),
                                maritalstatus = reader["maritalstatus"]?.ToString(),
                                DOA = reader["DOA"] != DBNull.Value ? Convert.ToDateTime(reader["DOA"]) : (DateTime?)null,
                                Sex = reader["Sex"] != DBNull.Value ? Convert.ToChar(reader["Sex"]) : (char?)null,
                                CallerID = reader["CallerID"]?.ToString(),
                                CreateedOn = reader["CreateedOn"] != DBNull.Value ? Convert.ToDateTime(reader["CreateedOn"]) : (DateTime?)null,
                                CreatedOn = reader["CreatedOn"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedOn"]) : (DateTime?)null,
                                Title = reader["Title"]?.ToString(),
                                FaceBookId = reader["FaceBookId"]?.ToString(),
                                UserName = reader["UserName"]?.ToString()
                            };

                            results.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // You can log the error here
                    return null;
                }
            }

            return results;
        }

        public int fnGetCustRowID()
        {
            int rowId = 0;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetCustRowID_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Declare the output parameter
                SqlParameter outputParam = new SqlParameter("@o_RowID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    if (outputParam.Value != DBNull.Value)
                        rowId = Convert.ToInt32(outputParam.Value);
                }
                catch (Exception ex)
                {
                    // Log exception if necessary
                    rowId = 0;
                }
            }

            return rowId;
        }
        public DataSet fnGetNoOfSeats_ADO(int tourNo, string tourDate)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.sp_NoOfSeats, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tourNo", tourNo);
                    cmd.Parameters.AddWithValue("@tDate", tourDate);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            return ds;
        }

        public string fnGetTAXValue_ADO(string taxType)
        {
            string taxValue = null;
            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.sp_GetTAXValue, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaxType", taxType);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taxValue = reader["taxvalue"] != DBNull.Value ? reader["taxvalue"].ToString() : null;
                        }
                    }
                }
            }
            return taxValue;
        }

        public DataSet fnGetSeatArrangementDetail(long? tourserial)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.sp_GetSeatArrangement, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input 
                    cmd.Parameters.Add(new SqlParameter("@tourserial", SqlDbType.BigInt)).Value = tourserial ?? (object)DBNull.Value;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        da.Fill(dataSet); 
                    }
                }

                return dataSet;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet fnGetFixedTour_Fare(int? tourNo, DateTime? tourDate, char? isLTC, string requestFrom)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.Get_FixedTour_Fare, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@TourNo", SqlDbType.Int)
                    { Value = (object)tourNo ?? DBNull.Value });

                    cmd.Parameters.Add(new SqlParameter("@TourDate", SqlDbType.DateTime)
                    { Value = (object)tourDate ?? DBNull.Value });

                    cmd.Parameters.Add(new SqlParameter("@IsLTC", SqlDbType.Char, 1)
                    { Value = (object)isLTC ?? DBNull.Value });

                    cmd.Parameters.Add(new SqlParameter("@RequestFrom", SqlDbType.VarChar, 10)
                    { Value = (object)requestFrom ?? DBNull.Value });

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        da.Fill(ds);  
                    }
                }

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable fnFixed_PickupAddr_DeptTime(int? lTourNo)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.Fixed_PickupAddr_DeptTime, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@tourno", SqlDbType.Int)
                    { Value = (object)lTourNo ?? DBNull.Value });

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        da.Fill(dt);  
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet fnFixed_Default_PickupAddress(int? lTourNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.Fixed_Default_PickupAddress, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@tourno", SqlDbType.Int) { Value = (object)lTourNo ?? DBNull.Value });

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int fnInsertUpdatedispup(int? lRowID, int? lTourNo, string lPckUpPlace, string lstrArrHrs, string lstrDroHrs, char lActive,
       string lBCode, string lAddress)
        {
            int status = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.dispup_sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@rowId", SqlDbType.SmallInt) { Value = (object)lRowID ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@tourno", SqlDbType.SmallInt) { Value = (object)lTourNo ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@PickPlace", SqlDbType.VarChar, 100) { Value = (object)lPckUpPlace ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@strarrHrs", SqlDbType.VarChar, 15) { Value = (object)lstrArrHrs ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@strDropHrs", SqlDbType.VarChar, 15) { Value = (object)lstrDroHrs ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@active", SqlDbType.Char, 1) { Value = lActive });
                    cmd.Parameters.Add(new SqlParameter("@bcode", SqlDbType.VarChar, 15) { Value = (object)lBCode ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@strAddress", SqlDbType.VarChar, 500) { Value = (object)lAddress ?? DBNull.Value });

                    conn.Open();

                    status = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                status = -1;
            }
            return status;
        }
        public DataTable fnGetMultiplePickupPoint(int? lTourNo)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetMultiplePickupPoint_sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TourNo", SqlDbType.Int) { Value = (object)lTourNo ?? DBNull.Value });

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int fnBlockUnBlockSeats_sp(string lTourSrNo, string lSeats, string lBlkString, bool? lBklOrUnBlh)
        {
            int status = 0;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.BlockUnBlockSeats_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TSerial", lTourSrNo);
                cmd.Parameters.AddWithValue("@Seat", lSeats);
                cmd.Parameters.AddWithValue("@BlockedString", lBlkString);
                cmd.Parameters.AddWithValue("@flag", (object)lBklOrUnBlh ?? DBNull.Value);

                SqlParameter returnParam = new SqlParameter("@ReturnValue", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(returnParam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    status = (returnParam.Value != DBNull.Value) ? Convert.ToInt32(returnParam.Value) : 0;
                }
                catch (Exception ex)
                {
                    status = -1;
                    // Log or rethrow if needed
                }
            }

            return status;
        }

        public DataTable fnGetBusAllot_Detail(string lTourSr, string lBusEnv, string lBusNo)
        {
            DataTable pdtTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetBusAllot_Detail_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_TourSerial", lTourSr);
                cmd.Parameters.AddWithValue("@i_BusEnvType", lBusEnv);
                cmd.Parameters.AddWithValue("@i_Busno", lBusNo);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        pdtTable.Load(reader); // Load the first result set into DataTable
                    }
                }
                catch (Exception ex)
                {
                    // Log exception if needed
                    return null;
                }
            }

            return pdtTable;
        }
        public  string fnGetOrderID()
        {
            string lOrderID = "";

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetOrderID_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter outputParam = new SqlParameter("@o_ReturnValue", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lOrderID = outputParam.Value?.ToString();
                }
                catch (Exception ex)
                {
                    // Log exception if needed
                    lOrderID = null;
                }
            }

            return lOrderID;
        }
        public string fnValidateDiscount(DateTime? JDate, int? lTourID)
        {
            string result = null;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.ValidateDiscount_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@i_JourneyDate", SqlDbType.DateTime)
                {
                    Value = (object)JDate ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter("@i_TourId", SqlDbType.Int)
                {
                    Value = (object)lTourID ?? DBNull.Value
                });

                SqlParameter outputParam = new SqlParameter("@o_ReturnValue", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = Convert.ToString(outputParam.Value);
                }
                catch (Exception ex)
                {
                    result = null;
                }
            }

            return result;
        }
        public string fnChkBusType(DateTime? JDate, int? lTourID)
        {
            string lStatus = "0";

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.ChkBusType_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                cmd.Parameters.Add(new SqlParameter("@i_TourNo", SqlDbType.Int)
                {
                    Value = (object)lTourID ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter("@i_JourneyDate", SqlDbType.SmallDateTime)
                {
                    Value = (object)JDate ?? DBNull.Value
                });

                // Output parameter
                SqlParameter outputParam = new SqlParameter("@o_BusType", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lStatus = Convert.ToString(outputParam.Value);
                }
                catch (Exception ex)
                {
                    // Optional: Log the exception
                    lStatus = null;
                }
            }

            return lStatus;
        }
        public DataTable fnFixed_TourSerial(DateTime? lJDate, string lHour, int? lTourNo)
        {
            DataTable pdtTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.Fixed_TourSerial, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Jdate", SqlDbType.SmallDateTime)
                {
                    Value = (object)lJDate ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter("@hr", SqlDbType.VarChar, 5)
                {
                    Value = (object)lHour ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter("@tourno", SqlDbType.Int)
                {
                    Value = (object)lTourNo ?? DBNull.Value
                });

                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(pdtTable);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return pdtTable;
        }
        public int fnGet_TourWiseTourSr(int? lTourID, DateTime? lJDate)
        {
            int lTourSr = 0;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.TourWiseTourSr_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                cmd.Parameters.Add(new SqlParameter("@i_TourID", SqlDbType.Int)
                {
                    Value = (object)lTourID ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter("@i_JDate", SqlDbType.SmallDateTime)
                {
                    Value = (object)lJDate ?? DBNull.Value
                });

                // Output parameter
                SqlParameter outputParam = new SqlParameter("@o_ReturnValue", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    if (outputParam.Value != DBNull.Value)
                        lTourSr = Convert.ToInt32(outputParam.Value);
                }
                catch (Exception ex)
                {
                    lTourSr = 0; // Fallback
                }
            }

            return lTourSr;
        }
        public DataTable fnGetSeatDetail(int? lRowID)
        {
            DataTable pdtTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.SeatDetail_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Add input parameter
                cmd.Parameters.Add(new SqlParameter("@i_RowID", SqlDbType.Int)
                {
                    Value = (object)lRowID ?? DBNull.Value
                });

                try
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(pdtTable);
                    }

                    return pdtTable;
                }
                catch (Exception ex)
                {
                    // Optionally log or handle the exception
                    return null;
                }
                finally
                {
                    if (pdtTable != null)
                    {
                        pdtTable.Dispose();
                    }
                }
            }
        }
        public int fnUpdaterTourDeatil(int? lRowID, DateTime? lJDate, string lTourSerial, string lBusSerialNo, string lSeatNo)
        {
            int? lStatus = 0;

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.UpdaterTourDeatil_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                cmd.Parameters.Add(new SqlParameter("@i_RowID", SqlDbType.Int) { Value = (object)lRowID ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@i_JDate", SqlDbType.SmallDateTime) { Value = (object)lJDate ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@i_TourSerial", SqlDbType.VarChar, 100) { Value = (object)lTourSerial ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@i_BusSerialNo", SqlDbType.VarChar, 100) { Value = (object)lBusSerialNo ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@i_SeatNo", SqlDbType.VarChar, 100) { Value = (object)lSeatNo ?? DBNull.Value });

                // Output parameter
                SqlParameter statusParam = new SqlParameter("@o_ReturnValue", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(statusParam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lStatus = (int?)statusParam.Value;
                }
                catch (Exception ex)
                {
                    lStatus = 0;
                }

                return Convert.ToInt32(lStatus);
            }
        }
        public DataTable fnGetJourneyDate(int? pHours, int? pTourNo)
        {
            DataTable ldtRecSet = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetJourneyDate_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Hours", SqlDbType.Int) { Value = (object)pHours ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@TourNo", SqlDbType.Int) { Value = (object)pTourNo ?? DBNull.Value });

                try
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ldtRecSet.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return ldtRecSet;
        }
        public DataTable fnCheck_Promocode(string lpromoCode)
        {
            DataTable pdtTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.Check_Promocode, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@promocode", SqlDbType.VarChar, 10)
                {
                    Value = (object)lpromoCode ?? DBNull.Value
                });

                try
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        pdtTable.Load(reader);
                    }
                }
                catch (Exception)
                {
                    // Optionally log exception here
                    return null;
                }
            }

            return pdtTable;
        }
        public DataSet fnGetToursBookingInfo(string lOrderID)
        {
            DataSet pdtDTSet = new DataSet();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetToursBookingInfo_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@i_OrderID", SqlDbType.VarChar, 100) { Value = (object)lOrderID ?? DBNull.Value });

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Load first result set into a DataTable and add to DataSet
                        DataTable dtFirst = new DataTable("FirstResult");
                        dtFirst.Load(reader);
                        pdtDTSet.Tables.Add(dtFirst);

                        // Load second result set
                        if (reader.NextResult())
                        {
                            DataTable dtSecond = new DataTable("SecondResult");
                            dtSecond.Load(reader);
                            pdtDTSet.Tables.Add(dtSecond);
                        }

                        // Load third result set
                        if (reader.NextResult())
                        {
                            DataTable dtThird = new DataTable("ThirdResult");
                            dtThird.Load(reader);
                            pdtDTSet.Tables.Add(dtThird);
                        }
                    }
                }
                catch (Exception)
                {
                    // Optionally log the exception
                    return null;
                }
            }

            return pdtDTSet;
        }

    }
}