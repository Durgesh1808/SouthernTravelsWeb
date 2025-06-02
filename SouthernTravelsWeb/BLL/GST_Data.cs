using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.BLL
{
    public class GST_Data
    {

        public List<GST_GetCityListByStateIdAndSearchedCityTextResult> GST_GetCityListByStateIdAndSearchedCityText(string search, int? StateId)
        {
            List<GST_GetCityListByStateIdAndSearchedCityTextResult> cityList = new List<GST_GetCityListByStateIdAndSearchedCityTextResult>();

            using (SqlConnection con = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GST_GetCityListByStateIdAndSearchedCityText, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@search", string.IsNullOrEmpty(search) ? (object)DBNull.Value : search);
                    cmd.Parameters.AddWithValue("@StateId", StateId.HasValue ? (object)StateId.Value : DBNull.Value);

                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GST_GetCityListByStateIdAndSearchedCityTextResult city = new GST_GetCityListByStateIdAndSearchedCityTextResult();

                                // Sample property mapping — replace with actual column/property names
                                city.CityID = reader["CityID"] != DBNull.Value ? reader["CityID"].ToString() : null;
                                city.CityName = reader["CityName"] != DBNull.Value ? reader["CityName"].ToString() : null;
                                city.StateID = reader["StateID"] != DBNull.Value ? Convert.ToInt32(reader["StateID"]) : 0;

                                cityList.Add(city);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }

            return cityList;
        }
        public DataTable GST_fnExistCustomerDetail(string lOrderID, int? lRowID)
        {
            DataTable pdtTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.GST_ExistCustomerDetail_sp, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@i_OrderID", SqlDbType.VarChar, 50) { Value = (object)lOrderID ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@i_RowID", SqlDbType.Int) { Value = (object)lRowID ?? DBNull.Value });

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
                    // Optionally log the error here
                    return null;
                }
            }

            return pdtTable;
        }

        //public int GST_fnInsertUpdateCustDetail(GST_OnlineCustomer pclsOnlineCustomer_tbl, string lOrderID)
        //{
        //    int status = 0;

        //    using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
        //    using (SqlCommand cmd = new SqlCommand("GST_InsertUpdateCustDetail_sp", conn))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        // Input Parameters
        //        cmd.Parameters.AddWithValue("@i_RowID", (object)pclsOnlineCustomer_tbl.RowId ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_Title", (object)pclsOnlineCustomer_tbl.Title ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_FirstName", (object)pclsOnlineCustomer_tbl.FirstName ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_Add1", (object)pclsOnlineCustomer_tbl.Addr1 ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_Country", (object)pclsOnlineCustomer_tbl.Country ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_State", (object)pclsOnlineCustomer_tbl.state ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_City", (object)pclsOnlineCustomer_tbl.City ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_Phone", (object)pclsOnlineCustomer_tbl.PhoneNo ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_Mobile", (object)pclsOnlineCustomer_tbl.Mobile ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@AlterMobileNo", (object)pclsOnlineCustomer_tbl.AlternativeNo ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_EmailID", (object)pclsOnlineCustomer_tbl.email ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_FaceBookId", (object)pclsOnlineCustomer_tbl.FaceBookID ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_PWS", (object)pclsOnlineCustomer_tbl.password ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_OrderID", (object)lOrderID ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@I_CanSendPromotions", (object)pclsOnlineCustomer_tbl.CanSendPromotions ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_ISGSTIN", (object)pclsOnlineCustomer_tbl.ISGSITIN ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_CustomerGSTIN", (object)pclsOnlineCustomer_tbl.CustomerGSTIN ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_GSTINHolderName", (object)pclsOnlineCustomer_tbl.GstHolderName ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_Nationality", (object)pclsOnlineCustomer_tbl.Nationality ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_AadharNo", (object)pclsOnlineCustomer_tbl.AadharNo ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@i_AadharImg", (object)pclsOnlineCustomer_tbl.AadharImg ?? DBNull.Value);

        //        // Output parameter
        //        SqlParameter outputParam = new SqlParameter("@o_ReturnValue", SqlDbType.Int)
        //        {
        //            Direction = ParameterDirection.Output
        //        };
        //        cmd.Parameters.Add(outputParam);

        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            if (outputParam.Value != DBNull.Value)
        //                status = Convert.ToInt32(outputParam.Value);
        //        }
        //        catch (Exception ex)
        //        {
        //            // You can log the error using your preferred logger
        //            status = -2;
        //        }
        //    }

        //    return status;
        //}
        public int GST_fnInsertUpdateCustDetail(GST_OnlineCustomer pclsOnlineCustomer_tbl, string lOrderID)
        {
            int lStatus = 0; // output param
            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.GST_InsertUpdateCustDetail_sp", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    cmd.Parameters.AddWithValue("@i_RowID", (object)pclsOnlineCustomer_tbl.RowId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_Title", (object)pclsOnlineCustomer_tbl.Title ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_FirstName", (object)pclsOnlineCustomer_tbl.FirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_Add1", (object)pclsOnlineCustomer_tbl.Addr1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_Country", (object)pclsOnlineCustomer_tbl.Country ?? DBNull.Value);
                    //cmd.Parameters.AddWithValue("@i_State", (object)pclsOnlineCustomer_tbl.state ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_City", (object)pclsOnlineCustomer_tbl.City ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_Phone", (object)pclsOnlineCustomer_tbl.PhoneNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_Mobile", (object)pclsOnlineCustomer_tbl.Mobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AlterMobileNo", (object)pclsOnlineCustomer_tbl.AlternativeNo ?? DBNull.Value);
                    //cmd.Parameters.AddWithValue("@i_EmailID", (object)pclsOnlineCustomer_tbl.email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_FaceBookId", (object)pclsOnlineCustomer_tbl.FaceBookID ?? DBNull.Value);
                    //cmd.Parameters.AddWithValue("@i_PWS", (object)pclsOnlineCustomer_tbl.password ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_OrderID", (object)lOrderID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_CanSendPromotions", (object)pclsOnlineCustomer_tbl.CanSendPromotions ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_ISGSTIN", (object)pclsOnlineCustomer_tbl.ISGSITIN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_CustomerGSTIN", (object)pclsOnlineCustomer_tbl.CustomerGSTIN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_GSTINHolderName", (object)pclsOnlineCustomer_tbl.GstHolderName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_Nationality", (object)pclsOnlineCustomer_tbl.Nationality ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_AadharNo", (object)pclsOnlineCustomer_tbl.AadharNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@i_AadharImg", (object)pclsOnlineCustomer_tbl.AadharImg ?? DBNull.Value);

                    SqlParameter outputParam = new SqlParameter("@o_ReturnValue", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        lStatus = (outputParam.Value != DBNull.Value) ? (int)outputParam.Value : 0;
                    }
                    catch (Exception ex)
                    {
                        lStatus = -2; // your error code
                    }
                }
            }
            return lStatus;
        }

    }
}