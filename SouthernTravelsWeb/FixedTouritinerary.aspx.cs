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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class FixedTouritinerary : System.Web.UI.Page
    {
        #region Member Variable(s)
        public string pbFBImage1, pbFBImage2;
        #endregion
        #region Property(s)

        #endregion
        #region Event(s)

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["utm_source"] != null
                    || Request.QueryString["utm_medium"] != null
                    || Request.QueryString["utm_term"] != null
                    || Request.QueryString["utm_content"] != null
                    || Request.QueryString["utm_campaign"] != null)
            {
                Session["utm_source"] = Convert.ToString(Request.QueryString["utm_source"]);
                Session["utm_medium"] = Convert.ToString(Request.QueryString["utm_medium"]);
                Session["utm_term"] = Convert.ToString(Request.QueryString["utm_term"]);
                Session["utm_content"] = Convert.ToString(Request.QueryString["utm_content"]);
                Session["utm_campaign"] = Convert.ToString(Request.QueryString["utm_campaign"]);
            }
            string URl = HttpContext.Current.Request.Url.ToString();
            if (!IsPostBack)
            {
              
                DataTable dttour = null;
                try
                {
                    dttour = fnFindTourDetail(Convert.ToInt32(Page.RouteData.Values["tourId"]));
                    if (dttour != null && dttour.Rows.Count > 0)
                    {
                        string mesg = GetPopupMessage(Convert.ToInt32(Page.RouteData.Values["tourId"]));
                        if (mesg != string.Empty)
                        { ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('" + mesg + "');</script>"); }
                        
                        if (Convert.ToString(dttour.Rows[0]["Activated"]) == "N")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Warning", "<script>alert('Tour is closed.');window.location='index.aspx';</script>");
                            return;
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    dttour = null;
                }
                FTFarePane91.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
                FTFarePane91.fldJourneyDate = Convert.ToString(Page.RouteData.Values["jdate"]);
                if (Request.QueryString["ltc"] != null)
                {
                    FTFarePane91.fldCanBook = false;
                    FTFarePane91.fldIsLTC = true;
                    ClientScript.RegisterStartupScript(typeof(Page), "Error", "<script language='JavaScript'>alert('For availing LTC, you have to submit an application " +
                            "to the State/central government well in advance in a prescribed " +
                            "format. \\nPlease contact our Toll Free No: 1800 11 0606 for further details..'); </script>");
                }


            }
            ucItinerary.fldTourType = TOURTYPE.FIXED_TOUR;
            ucItinerary.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            UCCityWisePlaceDisplay1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            UCCityWisePlaceDisplay1.fldTourTypeID = Convert.ToInt32(TOURTYPE.FIXED_TOUR);

            ucMatchingTour1.fldTourType = Convert.ToInt32(TOURTYPE.FIXED_TOUR);
            UCTourInfo1.fldTourType = TOURTYPE.FIXED_TOUR;
            UCTourInfo1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            UCTourGallery1.fldTourType = TOURTYPE.FIXED_TOUR;
            UCTourGallery1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);

            ucTourShortInfo1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            ucTourShortInfo1.fldTourTypeID = Convert.ToInt32(TOURTYPE.FIXED_TOUR);
            ucTourShortInfo1.fldTourType = "Fixed Departure";
            ucTourShortInfo1.fldClass = "active";
            ucMatchingTour1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);

            BindTourItenerary();
            Session["Panel2Step"] = null;
            ModifyMetaTag();

            hdnTourItitearyHTML.Value = "";
        }

        #endregion
        #region Method(s)

        public DataTable fnFindTourDetail(int? lTourNo)
        {
            DataTable dtResult = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.FindTourDetail_sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@i_TourNo", SqlDbType.Int).Value = (object)lTourNo ?? DBNull.Value;

                        conn.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtResult);
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

        private void BindTourItenerary()
        {
            List<TourItenerary_SPResult> lGetResult = null;
            ClsCommon objOther = new ClsCommon();
            hd.Style.Add("background-image", "url(Assets/images/banner.jpg)");
            try
            {
                lGetResult = new List<TourItenerary_SPResult>();

                lGetResult = objOther.fnGetTourItenerary(Convert.ToInt32(Page.RouteData.Values["tourId"]), Convert.ToInt32(TOURTYPE.FIXED_TOUR)).ToList();

                if (lGetResult != null && lGetResult.Count > 0)
                {

                    if (lGetResult[0].IsQuery)
                    {
                        divCal.Visible = false;
                    }
                    bool lFlag = false;
                    if (lGetResult[0].PageBanner != null && Convert.ToString(lGetResult[0].PageBanner) != "")
                    {
                        hd.Style.Add("background-image", "url(Assets/images/PageBanner/FixedTours/" + lGetResult[0].PageBanner + ")");
                        lFlag = true;
                    }
                    else
                    {
                        try
                        {
                            string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("~/Images/PageBanner/FixedTours/"));
                            List<String> images = new List<string>(filesindirectory.Count());
                            foreach (string item in filesindirectory)
                            {
                                string lFileName = System.IO.Path.GetFileName(item).Split('.')[0].ToString();
                                if (lFileName.Trim().ToUpper() == lGetResult[0].Tour_Short_key.Trim().ToUpper())
                                {
                                    hd.Style.Add("background-image", "url(images/PageBanner/FixedTours/" + System.IO.Path.GetFileName(item) + ")");
                                    lFlag = true;
                                    break;
                                }
                            }
                        }
                        catch { }
                    }
                    if (!lFlag)
                    {
                        hd.Style.Add("background-image", "url(Assets/images/banner.jpg)");
                    }


                    if (Page.RouteData.Values["jdate"] != null)
                    {
                        UcModifySearch1.fldJDate = Convert.ToDateTime(Page.RouteData.Values["jdate"]).ToString("dddd, MMMM d, yyyy");
                    }

                
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
        private void ModifyMetaTag()
        {

            ClsCommon clsCmn = new ClsCommon();
            try
            {
                int TourId, CountryID, ZoneId;
                if (Page.RouteData.Values["tourId"] != null && Page.RouteData.Values["tourId"] != "")
                {
                    TourId = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
                }
                else
                {
                    TourId = 0;
                }
                ZoneId = 0; CountryID = 0;
                DataTable dtM = clsCmn.fnGetMetaTagForTours(Request.QueryString["ltc"] == null ? Convert.ToInt32(TOURTYPE.FIXED_TOUR) : Convert.ToInt32(TOURTYPE.LTC_FIXED_TOUR), TourId, CountryID, ZoneId);
                if (dtM.Rows.Count > 0)
                {
                    HtmlHead hd = (HtmlHead)Page.FindControl("HeadST");
                    HtmlMeta htmMeta1 = new HtmlMeta();
                    string strMetaID = "";
                    string strContentText = "";
                    string strMetaName = "";
                    foreach (DataRow dr in dtM.Rows)
                    {
                        strMetaID = Convert.ToString(dr["MetaTagId"]).ToUpper();
                        strContentText = Convert.ToString(dr["MetaContent"]);
                        strMetaName = Convert.ToString(dr["MetaTagName"]);
                        if (strMetaName.ToLower() == "title")
                        {
                            this.Title = strContentText;
                        }
                        else
                        {
                            htmMeta1 = (HtmlMeta)hd.FindControl(strMetaID);

                            if (htmMeta1 != null)
                            {
                                htmMeta1.Content = strContentText;
                            }
                            else
                            {
                                HtmlMeta htmnewmeta = new HtmlMeta();
                                htmnewmeta.ID = strMetaID;
                                htmnewmeta.Name = strMetaName;
                                htmnewmeta.Content = strContentText;
                                hd.Controls.Add(htmnewmeta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (clsCmn != null)
                {
                    clsCmn = null;
                }
            }
        }


        private string GetPopupMessage(int tourno)
        {
            DataTable dttour = null;
            string strResult = "";
            try
            {
                SqlConnection lConn = null;
                SqlCommand lCommand = null;
                DataSet ldsDetail = new DataSet();
                SqlDataAdapter lDataAdp = null;
                String strCn = System.Configuration.ConfigurationManager.AppSettings["southernconn"];
                lConn = new SqlConnection(strCn);// For  Live
                lCommand = new SqlCommand("Get_PopupTourMessage", lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;
                lCommand.Parameters.AddWithValue("@TourNo", Convert.ToInt32(tourno));
                lCommand.Parameters.AddWithValue("@Action", "select");

                lDataAdp = new SqlDataAdapter(lCommand);
                lDataAdp.Fill(ldsDetail);

                dttour = ldsDetail.Tables[0];

                foreach (DataRow dr in dttour.Rows)
                {
                    strResult = Convert.ToString(dr["PopupMesg"]);
                }
                return strResult;
            }
            finally
            {
                if (dttour != null)
                {
                    dttour.Dispose();
                    dttour = null;
                }
            }
        }
        #endregion

    }
}