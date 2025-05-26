using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using SouthernTravelsWeb.DAL.DbObjects;

namespace SouthernTravelsWeb.BLL
{
    public abstract class DataLib
    {
        //To Store the Command Object Details
        public SqlCommand cmdInvitesCommand;
        //To Store the DataReader Object Details
        public SqlDataReader drInvitesdatareader;
        //To Store the DataView Object Details
        public DataView viewInvites;
        //To Store the DataSet Object Details
        public DataSet dsInvitesDataset;
        //To Store the DataTable Object Details
        public DataTable tblInvitestable;
        //To Store the DataAdapter Object Details
        public SqlDataAdapter adptrInvitesAdapter;
        //Holds a Transaction object by veerendra
        SqlTransaction InvitesTranscation;
        public int intmodID;
        public string strCon;
        public int num;
        public string Rupees, Paisa, length, querystr1;
        public DataSet dscorrespondance = new DataSet();
        public SqlCommand cmd = new SqlCommand();
        public static string ConString = ConfigurationManager.AppSettings["southernconn"];
        //public int strTour = 0;

        #region Updated By Murli on 11 July 2024
        public static System.Collections.Generic.List<int> vacentSeatNumber = new System.Collections.Generic.List<int>();
        public static System.Collections.Generic.List<int> occupiedSeatNumber = new System.Collections.Generic.List<int>();
        public static System.Collections.Generic.List<string> bus_vac_Number = new System.Collections.Generic.List<string>();
        #endregion

        public DataLib()
        {
        }

        public enum Connection
        {
            ConnectionString
            // Add more here (using comma's!)
        }

        // Get Connection String from Web.Config
        public static string GetConnectionString(Connection connType)
        {
            string retValue = "";
            AppSettingsReader appReader = new AppSettingsReader();
            switch (connType)
            {
                case Connection.ConnectionString:
                    {
                        //				retValue = appReader.GetValue("Main.ConnectionStringZD",typeof(string)).ToString();
                        retValue = appReader.GetValue("southernconn", typeof(string)).ToString();
                        break;
                    }
            }
            return retValue;
        }
        public static SqlConnection GetConnection(SqlConnection conInvitesConnection)
        {

            //Dim conInvitesConnection As New OracleConnection
            conInvitesConnection = new SqlConnection(ConString);
            //conInvitesConnection.ConnectionString = ConString;
            conInvitesConnection.Open();
            return conInvitesConnection;
        }

        public static SqlConnection CloseConnection(SqlConnection conInvitesConnection)
        {
            conInvitesConnection.Close();
            conInvitesConnection.Dispose();
            return conInvitesConnection;
        }


        //Execute SQL query that will return a single value

        public static string GetStringData(Connection connType, string sql)
        {
            return GetStringData(GetConnectionString(connType), sql);
        }
        private static string GetStringData(string connectStr, string sql)
        {
            string retValue = "";
            using (SqlConnection localSqlConnection = new SqlConnection(connectStr))
            {
                using (SqlCommand localSqlCommand = new SqlCommand(sql, localSqlConnection))
                {
                    localSqlCommand.CommandTimeout = 1000;
                    localSqlCommand.Connection.Open();
                    retValue = Convert.ToString(localSqlCommand.ExecuteScalar());
                }
            }
            return retValue;
        }
        public static SqlConnection GetConnectionObj(Connection connType)
        {
            SqlConnection localSqlConnection = new SqlConnection();
            return localSqlConnection;
        }

        public static string GetEncrypted(string data)
        {
            byte[] encData_byte = new byte[data.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

        public static string GetDecrypted(string data)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(data);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;

        }

        //Return DataTable of the SQL Query
        public static DataTable GetDataTable(Connection connType, string sql)
        {
            return GetDataTable(GetConnectionString(connType), sql);
        }
        private static DataTable GetDataTable(string connectStr, string sql)
        {
            DataTable theTable = new DataTable();
            using (SqlConnection localSqlConnection = new SqlConnection(connectStr))
            {
                using (SqlDataAdapter localSqlAdapter = new SqlDataAdapter(sql, localSqlConnection))
                {
                    localSqlAdapter.Fill(theTable);
                }
            }
            return theTable;
        }


        //Return Data Set
        public static DataSet GetDataSet(Connection connType, string sql)
        {
            return GetDataSet(GetConnectionString(connType), sql);
        }

        private static DataSet GetDataSet(string connectStr, string sql)
        {
            DataSet theDSet = new DataSet();
            using (SqlConnection localSqlConnection = new SqlConnection(connectStr))
            {
                using (SqlDataAdapter localSqlAdapter = new SqlDataAdapter(sql, localSqlConnection))
                {
                    localSqlAdapter.Fill(theDSet);
                }
            }
            return theDSet;
        }

        //Execute Stored Procedure and return result in DataSet
        public static DataSet GetStoredProcData(Connection connType, string strSP, SqlParameter[] arrSPParam)
        {
            return GetStoredProcData(GetConnectionString(connType), strSP, arrSPParam);
        }


        private static DataSet GetStoredProcData(string connectStr, string strSP, SqlParameter[] arrSPParam)
        {
            DataSet ds = new DataSet();
            using (SqlConnection localSqlConnection = new SqlConnection(connectStr))
            {
                using (SqlCommand localSqlCommand = localSqlConnection.CreateCommand())
                {
                    localSqlCommand.Connection = localSqlConnection;
                    localSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    localSqlCommand.CommandText = strSP;
                    localSqlCommand.CommandTimeout = 1000;
                    if (arrSPParam != null)
                    {
                        foreach (SqlParameter param in arrSPParam)
                        {
                            localSqlCommand.Parameters.Add(param);
                        }
                    }
                    using (SqlDataAdapter localSqlAdapter = new SqlDataAdapter(localSqlCommand))
                    {
                        localSqlAdapter.SelectCommand = localSqlCommand;
                        localSqlAdapter.Fill(ds);
                        localSqlAdapter.SelectCommand = null;
                    }
                }
            }
            return ds;
        }



        //Execute Insert, Update, Delete Query and return ID

        public static int ExecuteSQL(Connection connType, string sql, bool ret)
        {
            return ExecuteSQL(GetConnectionString(connType), sql, ret);
        }

        public static int ExecuteSQL1(Connection connType, string sql, bool ret)
        {
            return ExecuteSQL(GetConnectionString(connType), sql, false);
        }
        public static int ExecuteSQL2(Connection connType, string sql)
        {
            return ExecuteSQL(GetConnectionString(connType), sql, false);
        }
        private static int ExecuteSQL(string connectStr, string sql, bool getIDVal)
        {
            int newID = 0;

            using (SqlConnection localSqlConnection = new SqlConnection(connectStr))
            {
                using (SqlCommand localSqlCommand = new SqlCommand(sql, localSqlConnection))
                {
                    localSqlCommand.CommandTimeout = 15;
                    localSqlCommand.Connection.Open();
                    if (getIDVal == true)
                    {
                        if (localSqlCommand.CommandText.IndexOf("@@Identity") > 0)
                        {
                            localSqlCommand.CommandText = "SET NOCOUNT ON " + localSqlCommand.CommandText;
                        }
                        else
                        {
                            localSqlCommand.CommandText = "SET NOCOUNT ON " + localSqlCommand.CommandText + "SELECT @@IDENTITY";
                        }
                        using (SqlDataReader localSqlReader = localSqlCommand.ExecuteReader())
                        {
                            if (localSqlReader.Read() == true)
                            {
                                newID = Convert.ToInt32(localSqlReader[0].ToString());
                            }
                        }
                    }
                    else
                    {
                        newID = localSqlCommand.ExecuteNonQuery();
                    }
                }
            }
            return newID;
        }

        //Updated on 20/10/2008

        public static string funClear(string strText)
        {
            if (strText == null || strText.Length == 0) return "";
            return replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(strText, "<", ""), ">", ""), "--", ""), "'", ""), ";", ""), "+", ""), "\"", ""), "/", ""), "&quot;", ""), "&lt", ""), "&gt", ""), "&#40", ""), "&#41", ""), "&#35", ""), "&#38", ""), "&apos;", ""), "\u0027", ""), "(", ""), ")", "");
        }
        public static string bankvalidator(string strtext)
        {
            if (strtext == null || strtext.Length == 0) return "";
            return Regex.Replace(strtext, @"[^\w\.@-_/ ]", "");
            //return replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(strtext, "`", ""), "~", ""), "!", ""), "#", ""), "$", ""), "%", ""), "^", ""), "&", ""), "*", ""), "(", ""), ")", ""), "+", ""), "=", ""), "|", ""), "\"", ""), "{", ""), "}", ""), "[", ""), "]", ""), ";", ""), ":", ""), "'", ""), "<", ""), ",", ""), ">", ""), "?", "");
        }
        // Last Updated
        //public static string funClear(string strText)
        //{
        //    if (strText == null || strText.Length == 0) return "";
        //    return replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(strText, "<", ""), ">", ""), "--", ""), "'", ""), ";", ""), "+", ""), "\"", ""), "/", ""), "&quot;", ""), "&lt", ""), "&gt", ""), "&#40", ""), "&#41", ""), "&#35", ""), "&#38", ""), "&apos;", ""), "\u0027", "");
        //}

        private static string replace(string text, string findwhat, string replWith)
        {
            return text.Replace(findwhat, replWith);
        }

        public static DataTable get_tablequery(string querytext, string[] parameters, string[] values)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.CommandText = querytext;
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i <= parameters.Length - 1; i++)
            {
                SqlParameter param = new SqlParameter(parameters[i], values[i]);
                cmd.Parameters.Add(param);
            }
            SqlConnection pvConnection = new SqlConnection();
            try
            {
                cmd.Connection = GetConnection(pvConnection);
                adp = new SqlDataAdapter(cmd);
                dt.Clear();
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                CloseConnection(pvConnection);
                if (pvConnection != null)
                {
                    pvConnection = null;
                }
            }
            return dt;
        }
        public static void executeSqlQueryWithParam(string querytext, SqlParameter[] spm)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.CommandText = querytext;
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i <= spm.Length - 1; i++)
            {
                SqlParameter param = spm[i];
                cmd.Parameters.Add(param);
            }
            SqlConnection pvConnection = new SqlConnection();
            try
            {
                cmd.Connection = GetConnection(pvConnection);
                adp = new SqlDataAdapter(cmd);
                dt.Clear();
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                CloseConnection(pvConnection);
                if (pvConnection != null)
                {
                    pvConnection = null;
                }
            }

        }

        public static string get_stringquery(string querytext, string[] parameters, string[] values)
        {
            SqlConnection pvConnection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sclarvalue = "";
                cmd.CommandText = querytext;
                cmd.CommandType = CommandType.Text;
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    SqlParameter param = new SqlParameter(parameters[i], values[i]);
                    cmd.Parameters.Add(param);
                }
                cmd.Connection = GetConnection(pvConnection);
                sclarvalue = Convert.ToString(cmd.ExecuteScalar());
                return sclarvalue;
            }
            catch (Exception x)
            {
                // string strMsg = x.ToString();
                x.Message.ToString();
                string sx = "";
                return sx;
            }
            finally
            {
                CloseConnection(pvConnection);
                if (pvConnection != null)
                {
                    pvConnection = null;
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }
        public static int execute_query(string querytext, string[] parameters, string[] values)
        {
            int id = 0;
            SqlCommand cmd = new SqlCommand();
            SqlConnection pvConnection = new SqlConnection();
            try
            {
                cmd.CommandText = querytext;
                cmd.CommandType = CommandType.Text;
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    SqlParameter param = new SqlParameter(parameters[i], values[i]);
                    cmd.Parameters.Add(param);
                }
                cmd.Connection = GetConnection(pvConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection(pvConnection);
                if (pvConnection != null)
                {
                    pvConnection = null;
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
            return id;
        }
        public static string getConnectionString()
        {
            return ConfigurationSettings.AppSettings["southernconn"];
        }

        public static string Code(string Enquerytype)
        {
            DataTable dtcode = null;
            dtcode = clsBLL.Getcode(Enquerytype);
            if (dtcode != null && dtcode.Rows.Count > 0)
            {
                int code = Convert.ToInt32(dtcode.Rows[0][0]);
                return Convert.ToString(Enquerytype + code.ToString("000000"));
            }
            else
                return Convert.ToString(Enquerytype + "000001");
        }

        public static DataTable GetDataTableWithParamSP(string connectionString, string storedProcedureName, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static string sendsms(int rowid, string mobileno, string message, string sender, string branch, string TransactionType, string TicketNo, string OrderId)
        {
            if (!Convert.ToBoolean(ConfigurationSettings.AppSettings["IsSMS"]))
            {
                return "True";
            }
            ClsCommon clsObj = null;

            try
            {
                WebClient wc = new WebClient();
                string pSenderName = ConfigurationSettings.AppSettings["SenderName"].ToString().Trim();
                string pSenderID = ConfigurationSettings.AppSettings["SenderID"].ToString().Trim();
                string pSMSUID = ConfigurationSettings.AppSettings["SMSUID"].ToString().Trim();
                string pSMSKEY = ConfigurationSettings.AppSettings["SMSKEY"].ToString().Trim();
                string pAccessKey = ConfigurationSettings.AppSettings["AccessKey"].ToString().Trim();
                //string strData = Encoding.Default.GetString(wc.DownloadData("https://mobilnxt.in/api/push?accesskey=" + pAccessKey + "&to=" + mobileno.Substring(0, 10) + "&text=" + message + "&from=" + pSenderName + ""));
                string strData = Encoding.Default.GetString(wc.DownloadData("http://app.m-campaigner.in/SendIndividualSMS.aspx?UserID=" + pSMSUID + "&Key=" + pSMSKEY + "&SenderName=" + pSenderName + "&SenderID=" + pSenderID + "&MobileNo=" + mobileno.Substring(0, 10) + "&Message=" + message + ""));
                //string strData = Encoding.Default.GetString(wc.DownloadData("http://app.m-campaigner.in/SendIndividualSMS.aspx?UserID=c291dGhlcm5j&Key=c3RwbDEyIw==&SenderName=STPL&SenderID=55&MobileNo=" + mobileno.Substring(0, 10) + "&Message=" + message + ""));
                string sIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();


                if (strData.IndexOf("ERROR") < 0)
                {
                    #region Optimize Code
                    #endregion
                    clsObj = new ClsCommon();
                    int Val1 = clsObj.fninsert_SmsSend_tbl(Convert.ToDecimal(rowid), mobileno, sIPAddress, message, sender, branch, TransactionType, TicketNo, OrderId);
                    if (Val1 == 0)
                    {
                        return "True";
                    }
                    else
                        return "False";
                }
                else
                    return "False";
            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
            }
        }

        public static int InsStoredProcData(string strSP, SqlParameter[] arrSPParam)
        {
            int strTour = 0;
            string paramOut = "";

            SqlConnection pvConnection = new SqlConnection();
            SqlCommand localSqlCommand = new SqlCommand();
            localSqlCommand.Connection = GetConnection(pvConnection);
            localSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            localSqlCommand.CommandText = strSP;
            try
            {

                if (arrSPParam != null)
                {
                    strTour = 0;
                    foreach (SqlParameter param in arrSPParam)
                    {
                        localSqlCommand.Parameters.Add(param);
                        if (param.Direction == ParameterDirection.Output)
                        {
                            paramOut = param.ParameterName;
                            strTour = 1;
                        }
                    }
                }
                localSqlCommand.ExecuteNonQuery();
                localSqlCommand.Dispose();
                if (strTour == 1)
                {
                    strTour = Convert.ToInt32(localSqlCommand.Parameters[paramOut].Value);
                }
            }
            catch (Exception ex)
            {
                strTour = -1;
            }
            finally
            {
                CloseConnection(pvConnection);
                if (pvConnection != null)
                {
                    pvConnection = null;
                }
                if (localSqlCommand != null)
                {
                    localSqlCommand.Dispose();
                    localSqlCommand = null;
                }

            }
            return strTour;
        }

        public static string sendsms(int rowid, string mobileno, string message, string sender, string branch)
        {
            if (!Convert.ToBoolean(ConfigurationSettings.AppSettings["IsSMS"]))
            {
                return "True";
            }

            WebClient wc = new WebClient();
            string pSenderName = ConfigurationSettings.AppSettings["SenderName"].ToString().Trim();
            string pSenderID = ConfigurationSettings.AppSettings["SenderID"].ToString().Trim();
            string pSMSUID = ConfigurationSettings.AppSettings["SMSUID"].ToString().Trim();
            string pSMSKEY = ConfigurationSettings.AppSettings["SMSKEY"].ToString().Trim();
            string pAccessKey = ConfigurationSettings.AppSettings["AccessKey"].ToString().Trim();

            string strData = Encoding.Default.GetString(wc.DownloadData(
                $"https://mobilnxt.in/api/push?accesskey={pAccessKey}&to={mobileno.Substring(0, 10)}&text={message}&from={pSenderName}"
            ));

            string sIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();

            try
            {
                if (strData.IndexOf("ERROR", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    int val = fninsert_SmsSend_tbl_ADO(rowid, mobileno, sIPAddress, message, sender, branch, null, null, null);
                    return val == 0 ? "True" : "False";
                }
                else
                {
                    return "False";
                }
            }
            catch
            {
                return "False";
            }
        }

        public static int fninsert_SmsSend_tbl_ADO(decimal? pCustID, string pMblNo, string pUserID, string pMsg, string pUserName,
    string pBranchCode, string transactionType, string ticketNo, string orderId)
        {
            int result = 1;
            string connStr = DataLib.getConnectionString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.insert_SmsSend_tbl, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerId", (object)pCustID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MobileNo", (object)pMblNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserIP", (object)pUserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@message", (object)pMsg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@username", (object)pUserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@branchcode", (object)pBranchCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TransactionType", (object)transactionType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TicketNo", (object)ticketNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OrderId", (object)orderId ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = 0; // success
                }
            }
            catch (Exception)
            {
                result = 1; // failure
            }

            return result;
        }

    }

}