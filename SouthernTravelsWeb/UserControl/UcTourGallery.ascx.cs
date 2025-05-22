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

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcTourGallery : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        TourGallery pvTourGallery = null;
        TOURTYPE pvTourType;
        int pvTourID;
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
        public TourGallery fldTourGallery
        {
            get
            {
                if (pvTourGallery == null)
                    pvTourGallery = new TourGallery();
                pvTourGallery.fldGallery = Convert.ToInt32(hdCount.Value);

                return pvTourGallery;
            }
        }

        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTourGallery();
        }
        private void BindTourGallery()
        {
            List<TourItenerary_SPResult> lGetResult = null;
            ClsCommon objOther = new ClsCommon();

            try
            {
                lGetResult = new List<TourItenerary_SPResult>();
                divMsg.Visible = false;
                lGetResult = objOther.fnGetTourItenerary(Convert.ToInt32(fldTourID), Convert.ToInt32(fldTourType)).ToList();
                if (lGetResult != null && lGetResult.Count > 0)
                {
                    rptGallery.DataSource = lGetResult.ToList();
                    rptGallery.DataBind();
                    hdCount.Value = "1";
                }
                else
                {
                    divMsg.Visible = true;
                    ltrMsg.Text = "Currently we are not having gallery for tour.";
                }
            }
            catch
            {
            }
            finally
            {
                if (lGetResult != null)
                {
                    lGetResult = null;
                }

                if (objOther != null)
                {
                    objOther = null;
                }
            }
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

                if (ldsetail != null && ldsetail.Tables.Count > 0)
                {
                    //TourInFo.DataSource = ldsetail.Tables[0];
                    //TourInFo.DataBind();
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
        protected void rptGallery_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
    public class TourGallery
    {
        #region "Member Variable(s)"
        int pGallery = 0;

        #endregion
        #region "Properties"
        public int fldGallery
        {
            get { return pGallery; }
            set { pGallery = value; }
        }
        #endregion
    }
}