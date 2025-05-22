using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcTourInfo : System.Web.UI.UserControl
    {

        #region "Member Variable(s)"
        TOURTYPE pvTourType;
        int pvTourID;
        string pvTourinfoHTML;
        #endregion
        #region "Property(s)"
        public TOURTYPE fldTourType
        {
            get
            {
                return pvTourType;
            }
            set
            {
                pvTourType = value;
            }
        }

        public int fldTourID
        {
            get
            {
                return pvTourID;
            }
            set
            {
                pvTourID = value;
            }
        }
        public string fldpvTourinfoHTML
        {
            get
            {
                return pvTourinfoHTML;
            }
            set
            {
                pvTourinfoHTML = value;
            }
        }
        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTourInfo();
        }
        public void GetTourInfo()
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            DataSet ldsetail = new DataSet();
            SqlDataAdapter lDataAdp = null;

            try
            {
                String strCn = System.Configuration.ConfigurationManager.AppSettings["southernconn"];
                lConn = new SqlConnection(strCn);// For  Live

                lCommand = new SqlCommand(StoredProcedures.GetTourInfo_SP, lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@I_TourID", fldTourID);
                lCommand.Parameters.AddWithValue("@I_TourType", Convert.ToInt32(fldTourType));

                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }
                lCommand.ExecuteNonQuery();

                lDataAdp = new SqlDataAdapter(lCommand);
                lDataAdp.Fill(ldsetail);
                divMsg.Visible = false;
                if (ldsetail.Tables[0] != null && ldsetail.Tables[0].Rows.Count > 0)
                {
                    TourInFo.DataSource = ldsetail.Tables[0];
                    TourInFo.DataBind();

                    #region "For Tour Itinerary Html in mail added on 25/06/2018 by Sandeep"
                    string TourInfoHtml = string.Empty;
                    TourInfoHtml += "<h3 class='title'>Tour <span>Info</span></h3>";
                    foreach (DataRow dr in ldsetail.Tables[0].Rows)
                    {
                        TourInfoHtml += "<div>";
                        TourInfoHtml += "<div class='row rowgap'>";
                        TourInfoHtml += "<div style='width:100%; padding: 0px 10px 0px 10px;'>";
                        TourInfoHtml += "<h3 class='title'>";
                        TourInfoHtml += "<span>";
                        TourInfoHtml += Convert.ToString(dr["CategoryName"]);
                        TourInfoHtml += "</span></h3>";
                        TourInfoHtml += "<p>";
                        TourInfoHtml += "<ul class='sublist'>";
                        TourInfoHtml += Convert.ToString(dr["Info_Content"]);
                        TourInfoHtml += "</ul>";
                        TourInfoHtml += "</p>";
                        TourInfoHtml += "</div>";
                        TourInfoHtml += "</div>";
                        TourInfoHtml += "</div>";
                    }
                    hdnTourInfoHtml.Value = TourInfoHtml;
                    HiddenField hdnTourInfo = this.Page.FindControl("hdnTourInfo") as HiddenField;
                    hdnTourInfo.Value = TourInfoHtml;
                    fldpvTourinfoHTML = TourInfoHtml;
                    #endregion
                }
                else
                {
                    divMsg.Visible = true;
                    ltrMsg.Text = "Will update soon.";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lConn != null)
                {
                    if (lConn.State != ConnectionState.Closed)
                    {
                        lConn.Close();
                    }
                    lConn.Dispose();
                    lConn = null;
                }
                if (lCommand != null)
                {
                    lCommand.Dispose();
                    lCommand = null;
                }
                if (ldsetail != null)
                {
                    ldsetail.Dispose();
                    ldsetail = null;
                }
                if (lDataAdp != null)
                {
                    lDataAdp.Dispose();
                    lDataAdp = null;
                }
            }

        }
        #endregion
    }
}