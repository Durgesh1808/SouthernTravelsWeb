using SouthernTravelsWeb.BLL;
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
    public partial class UcIntLeftUC : System.Web.UI.UserControl
    {

        #region "Member variables"
        ClsCommon pvbal = null;
        string pvOfferID = "";

        public string fldOfferID
        {
            get { return pvOfferID; }
            set { pvOfferID = value; }
        }
        public string fldOffers
        {
            get
            {
                if (fldOfferID == "1")
                {
                    return "";
                }
                else
                {
                    return "_Offer" + fldOfferID;
                }
            }
        }
        #endregion
        #region "Events"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fnBindMenu();
                ActUrl.Value = Request.Url.ToString();
            }
        }
        protected void repCalendar_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


            }
        }

        void repCalendarEvent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
        }
        #endregion
        #region "Methods"
        private void fnBindMenu()
        {
            pvbal = new ClsCommon();
            DataSet ldsmenu = pvbal.fnGetIntMenu(fldOfferID);
            DataTable dtAllTours = null;
            try
            {
                if (ldsmenu != null && ldsmenu.Tables.Count > 0)
                {
                    dtAllTours = GetAllTours_New(GetTourWithZone());

                    repCalendarEvent.DataSource = dtAllTours;

                    repCalendarEvent.DataBind();
                }
            }
            finally
            {
                if (pvbal != null)
                {
                    pvbal = null;
                }
                if (ldsmenu != null)
                {
                    ldsmenu.Dispose();
                    ldsmenu = null;
                }
                if (dtAllTours != null)
                {
                    dtAllTours.Dispose();
                    dtAllTours = null;
                }
            }
        }

        public DataSet GetTourWithZone()
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            DataSet ldsetail = new DataSet();
            SqlDataAdapter lDataAdp = null;
            try
            {
                String strCn = System.Configuration.ConfigurationManager.AppSettings["southernconn"];
                lConn = new SqlConnection(strCn);// For  Live

                lCommand = new SqlCommand("GetInternationMenuItem_SP", lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@OfferID", fldOfferID);
                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }
                lCommand.ExecuteNonQuery();

                lDataAdp = new SqlDataAdapter(lCommand);
                lDataAdp.Fill(ldsetail);

                if (ldsetail != null && ldsetail.Tables.Count > 0)
                {
                    return ldsetail.Copy();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
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

        private DataTable GetAllTours_New(DataSet pdsmenu)
        {
            DataTable ldtZone = new DataTable(), ldtTours = new DataTable();
            int lZoneID = 0;
            ldtZone = pdsmenu.Tables[0];
            ldtTours = pdsmenu.Tables[1];
            RemoveZoneWithoutTour(ldtTours, ref ldtZone);
            ldtZone.Columns.Add("Tours", typeof(DataTable));

            try
            {
                for (int ZoneCtr = 0; ZoneCtr < ldtZone.Rows.Count; ZoneCtr++)
                {
                    DataTable ldtZoneTours = null;
                    try
                    {
                        ldtZoneTours = new DataTable();
                        ldtZoneTours = ldtTours.Clone();
                        lZoneID = Convert.ToInt32(ldtZone.Rows[ZoneCtr]["ZoneID"]);
                        DataRow[] drTours = ldtTours.Select("ZoneID=" + lZoneID.ToString());
                        drTours.CopyToDataTable(ldtZoneTours, LoadOption.OverwriteChanges);
                        ldtZone.Rows[ZoneCtr]["Tours"] = ldtZoneTours.Copy();
                    }
                    finally
                    {
                        if (ldtZoneTours != null)
                        {
                            ldtZoneTours.Dispose();
                            ldtZoneTours = null;
                        }
                    }
                }
                return ldtZone;
            }
            finally
            {

                if (ldtZone != null)
                {
                    ldtZone.Dispose();
                    ldtZone = null;
                }
                if (ldtTours != null)
                {
                    ldtTours.Dispose();
                    ldtTours = null;
                }
            }
        }
        private void RemoveZoneWithoutTour(DataTable ldtTours, ref DataTable ldtZone)
        {
            bool lFoundTour = false;
            for (int Ctr = 0; Ctr < ldtZone.Rows.Count; Ctr++)
            {
                lFoundTour = false;
                for (int TourCtr = 0; TourCtr < ldtTours.Rows.Count; TourCtr++)
                {
                    if (Convert.ToInt32(ldtTours.Rows[TourCtr]["ZoneID"]) == Convert.ToInt32(ldtZone.Rows[Ctr]["ZoneID"]))
                    {
                        lFoundTour = true;
                        break;
                    }
                }
                if (!lFoundTour)
                {
                    ldtZone.Rows.RemoveAt(Ctr);
                }
            }
        }

        private DataTable GetAllTours(DataSet pdsmenu)
        {
            DataTable ldtRegions = new DataTable(), ldtCountry = new DataTable(), ldtTours = new DataTable();
            int lRegionID = 0, lCountryID = 0;
            ldtRegions = pdsmenu.Tables[0];
            ldtCountry = pdsmenu.Tables[1];
            ldtTours = pdsmenu.Tables[2];
            RemoveRegionWithoutTour(ldtTours, ref ldtRegions);
            RemoveCountryWithoutTour(ldtTours, ref ldtCountry);
            ldtRegions.Columns.Add("Countries", typeof(DataTable));
            try
            {
                for (int RegionCtr = 0; RegionCtr < ldtRegions.Rows.Count; RegionCtr++)
                {
                    lRegionID = Convert.ToInt32(ldtRegions.Rows[RegionCtr]["Region_Id"]);
                    DataRow[] drCountry = ldtCountry.Select("region_id=" + lRegionID.ToString());
                    DataTable ldtRegCountry = null;
                    try
                    {
                        ldtRegCountry = new DataTable();
                        ldtRegCountry = ldtCountry.Clone();
                        drCountry.CopyToDataTable(ldtRegCountry, LoadOption.OverwriteChanges);
                        ldtRegCountry.Columns.Add("Tours", typeof(DataTable));
                        if (ldtRegCountry != null && ldtRegCountry.Rows.Count > 0)
                        {
                            for (int CountryCtr = 0; CountryCtr < ldtRegCountry.Rows.Count; CountryCtr++)
                            {
                                DataTable ldtCountryTours = null;
                                try
                                {
                                    ldtCountryTours = new DataTable();
                                    ldtCountryTours = ldtTours.Clone();
                                    lCountryID = Convert.ToInt32(ldtRegCountry.Rows[CountryCtr]["Country_id"]);
                                    DataRow[] drTours = ldtTours.Select("region_id=" + lRegionID.ToString() + " and Country_Id=" + lCountryID.ToString());
                                    drTours.CopyToDataTable(ldtCountryTours, LoadOption.OverwriteChanges);
                                    ldtRegCountry.Rows[CountryCtr]["Tours"] = ldtCountryTours.Copy();
                                }
                                finally
                                {
                                    if (ldtCountryTours != null)
                                    {
                                        ldtCountryTours.Dispose();
                                        ldtCountryTours = null;
                                    }
                                }
                            }
                        }
                        ldtRegions.Rows[RegionCtr]["Countries"] = ldtRegCountry.Copy();
                    }
                    finally
                    {
                        if (ldtRegCountry != null)
                        {
                            ldtRegCountry.Dispose();
                            ldtRegCountry = null;
                        }
                    }
                }
                return ldtRegions;
            }
            finally
            {

                if (ldtRegions != null)
                {
                    ldtRegions.Dispose();
                    ldtRegions = null;
                }
                if (ldtCountry != null)
                {
                    ldtCountry.Dispose();
                    ldtCountry = null;
                }
                if (ldtTours != null)
                {
                    ldtTours.Dispose();
                    ldtTours = null;
                }
            }
        }

        private void RemoveCountryWithoutTour(DataTable ldtTours, ref DataTable ldtCountry)
        {
            bool lFoundTour = false;
            for (int Ctr = 0; Ctr < ldtCountry.Rows.Count; Ctr++)
            {
                lFoundTour = false;
                for (int TourCtr = 0; TourCtr < ldtTours.Rows.Count; TourCtr++)
                {
                    if (Convert.ToInt32(ldtTours.Rows[TourCtr]["country_id"]) == Convert.ToInt32(ldtCountry.Rows[Ctr]["country_id"]))
                    {
                        lFoundTour = true;
                        break;
                    }
                }
                if (!lFoundTour)
                {
                    ldtCountry.Rows.RemoveAt(Ctr);
                }
            }
        }

        private void RemoveRegionWithoutTour(DataTable ldtTours, ref DataTable ldtRegions)
        {
            bool lFoundTour = false;
            for (int Ctr = 0; Ctr < ldtRegions.Rows.Count; Ctr++)
            {
                lFoundTour = false;
                for (int TourCtr = 0; TourCtr < ldtTours.Rows.Count; TourCtr++)
                {
                    if (Convert.ToInt32(ldtTours.Rows[TourCtr]["region_id"]) == Convert.ToInt32(ldtRegions.Rows[Ctr]["region_id"]))
                    {
                        lFoundTour = true;
                        break;
                    }
                }
                if (!lFoundTour)
                {
                    ldtRegions.Rows.RemoveAt(Ctr);
                }
            }
        }
        #endregion
    }
}