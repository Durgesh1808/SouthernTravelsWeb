using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class Feedback : System.Web.UI.Page
    {
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            //divrecaptcha.Attributes.Add("data-sitekey", System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Sitekey"]);
            txtMobile.Attributes.Add("onkeypress", "return chkNumeric(event);");
            txtPax.Attributes.Add("onkeypress", "return chkNumeric(event);");
            btnSend.Attributes.Add("onclick", "javascript:return fnFeedbackVal();");
            if (!IsPostBack)
            {
                ShowFeedBackHierarchy();
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
                SaveComment();
        }

        #endregion
        #region "Method(s)"
        protected void ClearComment()
        {
            txtFullName.Text = ""; txtFeedEmail.Text = ""; txtMobile.Text = ""; txtComments.Text = "";
            txtPlace.Text = ""; rbtntourtype.SelectedValue = null; txtTourName.Text = "";
            txtPax.Text = ""; txtarrival.Value = ""; txtPnr.Text = ""; txtTicket.Text = "";
            txtCaptcha.Text = "";
        }
        protected void SaveComment()
        {
            //bool lFlag = reCaptcha();
            //if (lFlag)
            //{
            if (Convert.ToString(Session["CaptchaImageText"]) == Convert.ToString(txtCaptcha.Text.Trim()))
            {
                DateTime Adate;
                string sDepDate = this.txtarrival.Value.ToString().Replace("'", "''");
                string[] DateArr3 = new string[3];
                char[] splitter1 = { '/' };
                DateArr3 = sDepDate.Split(splitter1);
                Adate = new DateTime(Convert.ToInt32(DateArr3[2]), Convert.ToInt32(DateArr3[1]),
                               Convert.ToInt32(DateArr3[0]));
                Adate = DateTime.Now;

                string lSelectedQuestion = "";
                GridView gv = Form.FindControl("gvFeedBack") as GridView;

                foreach (GridViewRow gvFeed in gv.Rows)
                {
                    HiddenField hdParentID = (HiddenField)gvFeed.Cells[0].FindControl("hdParentID");
                    if (Convert.ToInt32(hdParentID.Value) == 0)// Its a Parent Question
                    {
                        int gvColumns = gv.Columns.Count;
                        for (int Ctr = 2; Ctr < gvColumns; Ctr++)
                        {

                            if (gvFeed.Cells[Ctr].Controls.Count > 0)
                            {
                                HiddenField lhdFeedRatID = (HiddenField)gvFeed.FindControl("hdnRating");
                                if (lhdFeedRatID.Value != "0")
                                {
                                    HiddenField lhdFeedOptID = (HiddenField)gvFeed.FindControl("hdFeedOptID");
                                    lhdFeedRatID = (HiddenField)gvFeed.FindControl("hdnRating");


                                    lSelectedQuestion += lhdFeedOptID.Value + "-" + lhdFeedRatID.Value + "#";
                                }
                            }
                        }
                    }
                }
                if (lSelectedQuestion.Trim() != string.Empty)
                {
                    try
                    {

                        int lStatus = fSaveCustomerFeedback(txtFullName.Text.Trim(), txtFeedEmail.Text.Trim(), txtMobile.Text.Trim(),
                        txtComments.Text.Trim(), txtPlace.Text.Trim(), Convert.ToInt32(rbtntourtype.SelectedValue), txtTourName.Text.Trim(), Convert.ToInt32(txtPax.Text.Trim()),
                        Adate, txtPnr.Text.Trim(), txtTicket.Text.Trim(), lSelectedQuestion, "GeneralFeed");

                        if (lStatus > 0)
                        {
                            ClearComment();
                            string script = "Swal.fire({ icon: 'success', title: 'Thank you!', text: 'Thank you for your valuable feedback and time.', timer: 3000, confirmButtonColor: '#f2572b' });";
                            ClientScript.RegisterStartupScript(this.GetType(), "swal", script, true);
                        }
                        else
                        {
                            string script = "Swal.fire({ icon: 'warning', title: 'Oops...', text: 'Error for sending feedback..', timer: 3000,confirmButtonColor: '#f2572b' });";
                            ClientScript.RegisterStartupScript(this.GetType(), "swalWarning", script, true);
                        }
                    }
                    finally
                    {
                    }
                }
            }

            else
            {
                if (!string.IsNullOrEmpty(txtCaptcha.Text))
                {
                    //ClsCommon.ShowAlert("Please Enter Valid Captcha");
                    string script = "Swal.fire({ icon: 'warning', title: 'Oops...', text: 'Please Enter Valid Captcha..', timer: 3000,confirmButtonColor: '#f2572b' });";
                    ClientScript.RegisterStartupScript(this.GetType(), "swalWarning", script, true);
                    return;
                }
                else
                {
                    string script = "Swal.fire({ icon: 'warning', title: 'Oops...', text: 'Please Enter  Captcha..', timer: 3000,confirmButtonColor: '#f2572b' });";
                    ClientScript.RegisterStartupScript(this.GetType(), "swalWarning", script, true);
                    return;
                }
            }
        }

        private void ShowFeedBackHierarchy()
        {
            List<FeedBackHierarchy_spResult> lFeedBackHierarchy = null;
            List<FeedBackHierarchy_spResult> lParentHierarchy = null;
            List<FeedBackHierarchy_spResult> lChildHierarchy = null;
            int? lStatus = 0;
            DataTable ldtFeedBack = new DataTable("FeedBack");
            try
            {
                lFeedBackHierarchy = fnFeedBackHierarchy(ref lStatus);
                if (Convert.ToInt32(lStatus) == 1)
                {
                    ldtFeedBack.Columns.Add("FeedOptID", typeof(int));
                    ldtFeedBack.Columns.Add("FeedQuest", typeof(string));
                    ldtFeedBack.Columns.Add("ParentID", typeof(int));
                    int lCurrFeedID = 0, lPrevFeedID = 0;
                    lCurrFeedID = lFeedBackHierarchy[0].FeedOptID;
                    lPrevFeedID = lCurrFeedID;
                    int Ctr = 0;
                    for (Ctr = 0; lCurrFeedID == lPrevFeedID;)
                    {
                        ldtFeedBack.Columns.Add("RatingID" + lFeedBackHierarchy[Ctr].RatingID.ToString(), typeof(int));
                        ldtFeedBack.Columns.Add(lFeedBackHierarchy[Ctr].RatingDesc, typeof(bool));
                        ldtFeedBack.Columns.Add("RatingPoints" + lFeedBackHierarchy[Ctr].RatingID.ToString(), typeof(int));
                        Ctr = Ctr + 1;
                        lCurrFeedID = lFeedBackHierarchy[Ctr].FeedOptID;
                    }
                    lParentHierarchy = (from FeedH in lFeedBackHierarchy
                                        where FeedH.ParentID == 0
                                        select FeedH).OrderBy(p => p.Seqen).ToList();
                    lCurrFeedID = lParentHierarchy[0].FeedOptID;
                    lPrevFeedID = lCurrFeedID;
                    DataRow dr = ldtFeedBack.NewRow();
                    for (Ctr = 0; Ctr < lParentHierarchy.Count;)
                    {
                        if (lPrevFeedID == lCurrFeedID)
                        {
                            dr["FeedOptID"] = lParentHierarchy[Ctr].FeedOptID;
                            dr["FeedQuest"] = lParentHierarchy[Ctr].FeedQuest;
                            dr["ParentID"] = lParentHierarchy[Ctr].ParentID;
                            dr["RatingID" + lParentHierarchy[Ctr].RatingID.ToString()] = lParentHierarchy[Ctr].RatingID;
                            dr["RatingPoints" + lParentHierarchy[Ctr].RatingID.ToString()] = lParentHierarchy[Ctr].RatingPoints;
                        }
                        else
                        {

                            ldtFeedBack.Rows.Add(dr);
                            //AddChild(ref ldtFeedBack, lPrevFeedID, ref lFeedBackHierarchy, lChildHierarchy);
                            lPrevFeedID = lCurrFeedID;
                            dr = ldtFeedBack.NewRow();
                            dr["RatingID" + lParentHierarchy[Ctr].RatingID.ToString()] = lParentHierarchy[Ctr].RatingID;
                            dr["RatingPoints" + lParentHierarchy[Ctr].RatingID.ToString()] = lParentHierarchy[Ctr].RatingPoints;
                        }
                        Ctr = Ctr + 1;
                        if (Ctr < lParentHierarchy.Count)
                        {
                            lCurrFeedID = lParentHierarchy[Ctr].FeedOptID;
                        }
                    }
                    ldtFeedBack.Rows.Add(dr);
                    //AddChild(ref ldtFeedBack, lPrevFeedID, ref lFeedBackHierarchy, lChildHierarchy);



                    gvFeedBack.DataSource = ldtFeedBack;
                    gvFeedBack.DataBind();

                }
            }
            catch (Exception Ex)
            {
                lStatus = -1;
            }
            finally
            {
              
                if (lFeedBackHierarchy != null)
                {
                    lFeedBackHierarchy = null;
                }
                if (lParentHierarchy != null)
                {
                    lParentHierarchy = null;
                }
                if (lChildHierarchy != null)
                {
                    lChildHierarchy = null;
                }
                if (ldtFeedBack != null)
                {
                    ldtFeedBack.Dispose();
                    ldtFeedBack = null;
                }
            }
        }

        private void ShowDynamicColumn()
        {
            List<FeedBackHierarchy_spResult> lFeedBackHierarchy = null;
            int? lStatus = 0;
            try
            {
                lFeedBackHierarchy = fnFeedBackHierarchy(ref lStatus);
                if (Convert.ToInt32(lStatus) == 1)
                {
                    int lCurrFeedID = 0, lPrevFeedID = 0;
                    lCurrFeedID = lFeedBackHierarchy[0].FeedOptID;
                    lPrevFeedID = lCurrFeedID;
                    int Ctr = 0;
                    for (Ctr = 0; lCurrFeedID == lPrevFeedID;)
                    {
                        TemplateField TmpCol = new TemplateField();
                        TmpCol.HeaderText = lFeedBackHierarchy[Ctr].RatingDesc;
                        TmpCol.ItemTemplate = new AddTemplateToGridView(ListItemType.Item, "RatingID" + lFeedBackHierarchy[Ctr].RatingID.ToString());
                        TmpCol.ItemStyle.Width = Unit.Parse("50px");
                        gvFeedBack.Columns.Add(TmpCol);
                        Ctr = Ctr + 1;
                        lCurrFeedID = lFeedBackHierarchy[Ctr].FeedOptID;
                    }
                }
            }
            catch (Exception Ex)
            {
                lStatus = -1;
            }
            finally
            {
                
            }
        }

        private void AddChild(ref DataTable ldtFeedBack, int lCurrFeedID, ref List<FeedBackHierarchy_spResult> lFeedBackHierarchy,
            List<FeedBackHierarchy_spResult> lChildHierarchy)
        {
            lChildHierarchy = (from FeedH in lFeedBackHierarchy
                               where FeedH.ParentID == lCurrFeedID
                               select FeedH).OrderBy(p => p.Seqen).ToList();
            int lPrevFeedID = 0, lCurrentID = 0;
            lPrevFeedID = lChildHierarchy[0].FeedOptID;
            lCurrentID = lPrevFeedID;
            DataRow dr = ldtFeedBack.NewRow();
            for (int Ctr = 0; Ctr < lChildHierarchy.Count;)
            {
                if (lPrevFeedID == lCurrentID)
                {
                    dr["FeedOptID"] = lChildHierarchy[Ctr].FeedOptID;
                    dr["FeedQuest"] = lChildHierarchy[Ctr].FeedQuest;
                    dr["ParentID"] = lChildHierarchy[Ctr].ParentID;
                    dr["RatingID" + lChildHierarchy[Ctr].RatingID.ToString()] = lChildHierarchy[Ctr].RatingID;
                    dr["RatingPoints" + lChildHierarchy[Ctr].RatingID.ToString()] = lChildHierarchy[Ctr].RatingPoints;
                }
                else
                {

                    ldtFeedBack.Rows.Add(dr);
                    dr = ldtFeedBack.NewRow();
                    lPrevFeedID = lCurrentID;
                    dr["RatingID" + lChildHierarchy[Ctr].RatingID.ToString()] = lChildHierarchy[Ctr].RatingID;
                    dr["RatingPoints" + lChildHierarchy[Ctr].RatingID.ToString()] = lChildHierarchy[Ctr].RatingPoints;
                }
                Ctr = Ctr + 1;
                if (Ctr < lChildHierarchy.Count)
                {
                    lCurrentID = lChildHierarchy[Ctr].FeedOptID;
                }
            }
            ldtFeedBack.Rows.Add(dr);
        }
        private string get500Char(string pstr)
        {
            //ClsCommon.ShowAlert(pstr);   
            string lstr = "";
            if (!string.IsNullOrEmpty(pstr))
            {
                if (pstr.Trim().Length > 500)
                    lstr = pstr.Substring(0, 500);
                else
                    lstr = pstr;
            }
            return lstr;

        }
        protected void gvFeedBack_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdParentID = (HiddenField)e.Row.Cells[0].FindControl("hdParentID");
                HiddenField hdFeedID = (HiddenField)e.Row.Cells[0].FindControl("hdFeedOptID");
                Label tmplblSr = (Label)e.Row.Cells[0].FindControl("lblSrNo");
                
            }
        }

        public bool reCaptcha()
        {
            bool lFlag = false;
            //var sb = new System.Text.StringBuilder();
            //sb.Append("https://www.google.com/recaptcha/api/siteverify?secret=");

            ////our secret key
            //var secretKey = System.Configuration.ConfigurationManager.AppSettings["GooglereCaptcha_Secretkey"]; //"6LesfBwTAAAAAPKzkHq9ny59cb_BtZa1D6ZLLBGf";
            //sb.Append(secretKey);

            ////response from recaptch control
            //sb.Append("&");
            //sb.Append("response=");
            //var reCaptchaResponse = Request["g-recaptcha-response"];
            //sb.Append(reCaptchaResponse);

            ////client ip address
            ////---- This Ip address part is optional. If you donot want to send IP address you can
            ////---- Skip(Remove below 4 lines)
            //sb.Append("&");
            //sb.Append("remoteip=");
            //var clientIpAddress = GetUserIp();
            //sb.Append(clientIpAddress);

            ////make the api call and determine validity
            //using (var client = new System.Net.WebClient())
            //{
            //    var uri = sb.ToString();
            //    var json = client.DownloadString(uri);
            //    var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(RecaptchaApiResponse));
            //    var ms = new System.IO.MemoryStream(System.Text.Encoding.Unicode.GetBytes(json));
            //    var result = serializer.ReadObject(ms) as RecaptchaApiResponse;

            //    //--- Check if we are able to call api or not.
            //    if (result == null)
            //    {
            //        MessageLabel.Text = "Captcha was unable to make the api call";
            //    }
            //    else // If Yes
            //    {
            //        //api call contains errors
            //        if (result.ErrorCodes != null)
            //        {
            //            if (result.ErrorCodes.Count > 0)
            //            {
            //                foreach (var error in result.ErrorCodes)
            //                {
            //                    MessageLabel.Text = "Captcha is required.";
            //                }
            //            }
            //        }
            //        else //api does not contain errors
            //        {
            //            if (!result.Success) //captcha was unsuccessful for some reason
            //            {
            //                MessageLabel.Text = "Captcha did not pass, please try again.";
            //            }
            //            else //---- If successfully verified. Do your rest of logic.
            //            {
            //                MessageLabel.Text = "Captcha cleared ";
            //                lFlag = true;
            //            }
            //        }

            //    }

            //}
            return lFlag;
        }
        [System.Runtime.Serialization.DataContract]
        public class RecaptchaApiResponse
        {
            [System.Runtime.Serialization.DataMember(Name = "success")]
            public bool Success;

            [System.Runtime.Serialization.DataMember(Name = "error-codes")]
            public System.Collections.Generic.List<string> ErrorCodes;
        }

        //--- To get user IP(Optional)
        private string GetUserIp()
        {
            var visitorsIpAddr = string.Empty;

            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                visitorsIpAddr = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (!string.IsNullOrEmpty(Request.UserHostAddress))
            {
                visitorsIpAddr = Request.UserHostAddress;
            }

            return visitorsIpAddr;
        }
        public int fSaveCustomerFeedback(string pFullName, string pEmailID, string pContactNo, string pComment, string pPlace,
                                 int pTourType, string pTourName, int Noofpax, DateTime JournyDate, string pPNR,
                                 string pTicketNo, string pFeedBackList, string pFeedType)
        {
            int status = 0;
            string connectionString = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.SaveCustomerFeedback_SP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@I_FullName", pFullName);
                        cmd.Parameters.AddWithValue("@I_Email", pEmailID);
                        cmd.Parameters.AddWithValue("@I_ContactNumber", pContactNo);
                        cmd.Parameters.AddWithValue("@I_Comments", pComment);
                        cmd.Parameters.AddWithValue("@I_Place", pPlace);
                        cmd.Parameters.AddWithValue("@I_TourType", pTourType);
                        cmd.Parameters.AddWithValue("@I_TourName", pTourName);
                        cmd.Parameters.AddWithValue("@I_NoOfPax", Noofpax);
                        cmd.Parameters.AddWithValue("@I_JourntDate", JournyDate);
                        cmd.Parameters.AddWithValue("@I_PNRNo", pPNR);
                        cmd.Parameters.AddWithValue("@I_TicketNo", pTicketNo);
                        cmd.Parameters.AddWithValue("@I_FeedBackList", pFeedBackList);
                        cmd.Parameters.AddWithValue("@I_FeedType", pFeedType);

                        SqlParameter outputStatus = new SqlParameter("@O_ReturnValues", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputStatus);

                        cmd.ExecuteNonQuery();

                        status = Convert.ToInt32(outputStatus.Value);
                    }
                }
                catch (Exception ex)
                {
                    status = 0;
                }
            }

            return status;
        }
        public List<FeedBackHierarchy_spResult> fnFeedBackHierarchy(ref int? pStatus)
        {
            List<FeedBackHierarchy_spResult> lFeedBackHierarchy = new List<FeedBackHierarchy_spResult>();
            string connectionString = DataLib.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.FeedBackHierarchy_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Output parameter
                        SqlParameter statusParam = new SqlParameter("@O_ReturnValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(statusParam);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FeedBackHierarchy_spResult item = new FeedBackHierarchy_spResult
                                {
                                    FeedOptID = reader["FeedOptID"] != DBNull.Value ? Convert.ToInt32(reader["FeedOptID"]) : 0,
                                    FeedQuest = reader["FeedQuest"]?.ToString(),
                                    ParentID = reader["ParentID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ParentID"]) : null,
                                    Seqen = reader["Seqen"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Seqen"]) : null,
                                    RatingID = reader["RatingID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["RatingID"]) : null,
                                    RatingDesc = reader["RatingDesc"]?.ToString(),
                                    RatingPoints = reader["RatingPoints"] != DBNull.Value ? (int?)Convert.ToInt32(reader["RatingPoints"]) : null
                                };

                                lFeedBackHierarchy.Add(item);
                            }
                        }

                        // Assign output status
                        if (statusParam.Value != DBNull.Value)
                        {
                            pStatus = Convert.ToInt32(statusParam.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    pStatus = 0;
                    lFeedBackHierarchy = null;
                }
            }

            return lFeedBackHierarchy;
        }

        #endregion
    }
    public class AddTemplateToGridView : ITemplate
    {
        ListItemType _type;
        string _colName;

        public AddTemplateToGridView(ListItemType type, string colname)
        {
            _type = type;
            _colName = colname;
        }
        void ITemplate.InstantiateIn(System.Web.UI.Control container)
        {

            switch (_type)
            {
                case ListItemType.Item:

                    RadioButton rbt = new RadioButton();
                    rbt.ID = "rbt" + _colName;
                    rbt.GroupName = "rbt";
                    container.Controls.Add(rbt);


                    HiddenField hd = new HiddenField();
                    hd.ID = "hd" + _colName;
                    hd.DataBinding += new EventHandler(hd_DataBinding);
                    container.Controls.Add(hd);

                    break;
            }

        }
        void hd_DataBinding(object sender, EventArgs e)
        {
            HiddenField hd = (HiddenField)sender;
            GridViewRow container = (GridViewRow)hd.NamingContainer;
            object dataValue = DataBinder.Eval(container.DataItem, _colName);
            if (dataValue != DBNull.Value)
            {
                hd.Value = dataValue.ToString();
            }
        }

    }
}