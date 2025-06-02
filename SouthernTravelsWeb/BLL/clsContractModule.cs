using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb.BLL
{
    public class clsContractModule
    {

        private string pvConnectionString = string.Empty;

        public string fldConnString
        {
            get
            {
                return pvConnectionString;
            }
            set
            {   
                pvConnectionString = value;
            }
        }

        public DataListResponse<GetCountryWiseStateName_SPResult> fnGetCountryWiseStateName(int iCountryID)
        {
            DataListResponse<GetCountryWiseStateName_SPResult> dataListResponse = new DataListResponse<GetCountryWiseStateName_SPResult>();
            List<GetCountryWiseStateName_SPResult> stateList = new List<GetCountryWiseStateName_SPResult>();

            using (SqlConnection con = new SqlConnection(fldConnString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetCountryWiseStateName_SP, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_CountryID", iCountryID);

                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GetCountryWiseStateName_SPResult item = new GetCountryWiseStateName_SPResult();

                                // Replace below with actual column mappings
                                item.StateID = reader["StateID"] != DBNull.Value ? Convert.ToInt32(reader["StateID"]) : 0;
                                item.StateName = reader["StateName"] != DBNull.Value ? reader["StateName"].ToString() : string.Empty;
                                item.CountryID = reader["CountryID"] != DBNull.Value ? Convert.ToInt32(reader["CountryID"]) : 0;

                                stateList.Add(item);
                            }
                        }

                        dataListResponse.ResultList = stateList;
                        if (stateList.Count > 0)
                        {
                            dataListResponse.Status = ClsCommon.fnGetRequestStatus(true, pbException.SUCCESS);
                        }
                        else
                        {
                            dataListResponse.Status = ClsCommon.fnGetRequestStatus(true, pbException.ERR_DATANOT_FOUND);
                        }
                    }
                    catch (Exception)
                    {
                        dataListResponse.Status = ClsCommon.fnGetRequestStatus(false, pbException.ERR_CATCH_BLOCK);
                    }
                }
            }

            return dataListResponse;
        }
        public DataListResponse<GetCountryName_SPResult> fnGetCountryName(int iCountryID)
        {
            DataListResponse<GetCountryName_SPResult> dataListResponse = new DataListResponse<GetCountryName_SPResult>();
            List<GetCountryName_SPResult> countryList = new List<GetCountryName_SPResult>();

            using (SqlConnection con = new SqlConnection(fldConnString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetCountryName_SP, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_CountryID", iCountryID);

                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GetCountryName_SPResult item = new GetCountryName_SPResult();

                                // Replace with your actual column names and types
                                item.CountryID = reader["CountryID"] != DBNull.Value ? Convert.ToInt32(reader["CountryID"]) : 0;
                                item.CountryName = reader["CountryName"] != DBNull.Value ? reader["CountryName"].ToString() : string.Empty;

                                countryList.Add(item);
                            }
                        }

                        dataListResponse.ResultList = countryList;

                        if (countryList.Count > 0)
                        {
                            dataListResponse.Status = ClsCommon.fnGetRequestStatus(pStatus: true, pbException.SUCCESS);
                        }
                        else
                        {
                            dataListResponse.Status = ClsCommon.fnGetRequestStatus(pStatus: true, pbException.ERR_DATANOT_FOUND);
                        }
                    }
                    catch (Exception)
                    {
                        dataListResponse.Status = ClsCommon.fnGetRequestStatus(pStatus: false, pbException.ERR_CATCH_BLOCK);
                    }
                }
            }

            return dataListResponse;
        }



    }
}