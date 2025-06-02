using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class SpecialTouritinerary : System.Web.UI.Page
    {

        #region Member Variable(s)
        public string pbFBImage1, pbFBImage2;
        #endregion

        #region Property(s)

        #endregion

        #region Event(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            string pURL = Request.Url.ToString();
         

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

            if (ClsCommon.ConvertStringint(Request.QueryString["TourID"]) == 176 ||
                ClsCommon.ConvertStringint(Request.QueryString["TourID"]) == 177 ||
                ClsCommon.ConvertStringint(Request.QueryString["TourID"]) == 178 ||
                ClsCommon.ConvertStringint(Request.QueryString["TourID"]) == 179)
            {
                hdfIswed.Value = "1";
                SplTours.Visible = true;
            }
            else
            {
                SplTours.Visible = false;
            }

            if (!IsPostBack)
            {
                clsAdo clsObj = new clsAdo();
                List<FindSpl_TourMaster_spResult> lTourInfo = clsObj.fnFindSpl_TourMaster(ClsCommon.ConvertStringint(Request.QueryString["TourID"]));
                try
                {
                    if (lTourInfo != null && lTourInfo.Count > 0)
                    {
                        if (Convert.ToString(lTourInfo[0].InstentBooking) == "N")
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
                    clsObj = null;
                    lTourInfo = null;
                }
                ModifyMetaTag();




                //ucItinerary.fldTourType = TOURTYPE.SPECIAL_TOUR;
                //ucItinerary.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
                //UCCityWisePlaceDisplay1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
                //UCCityWisePlaceDisplay1.fldTourTypeID = ClsCommon.ConvertStringint(TOURTYPE.SPECIAL_TOUR);
                //ucShowFeedBack1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
                //ucShowFeedBack1.fldFeedBCKTourType = TOURTYPE.SPECIAL_TOUR;
                //ucShowFeedBack1.fldShowAll = 1;
                //UCWeatherInfo1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
                //UCWeatherInfo1.fldTourType = ClsCommon.ConvertStringint(TOURTYPE.SPECIAL_TOUR);
                BindTourItenerary();
                //BindPlace();
                //if (IsValidTour(Request.QueryString["TourID"].ToString()))
                //{
                //    lblSpecialNote.Text = "Special rates are defined for this tour from 15-Dec-2013 to 04-Jan-2014. Please <a href=\"http://www.southerntravelsindia.com/Contact-us.aspx\" target=\"_blank\">contact us</a> for more details.";
                //}
                //else
                //{
                //    lblSpecialNote.Text = "";
                //}
                HideDateSelection();



            }
            SpecialTourFarePanel81.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            SpecialTourFarePanel81.fldShowNotes = false;
            SpecialTourFarePanel81.CanBook = false;
            SpecialTourFarePanel81.fldWidth = "748";
            SpecialTourFarePanel81.fldJourneyDate = Convert.ToString(Request.QueryString["jdate"]);



            ucItinerary.fldTourType = TOURTYPE.SPECIAL_TOUR;
            ucItinerary.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            UCCityWisePlaceDisplay1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            UCCityWisePlaceDisplay1.fldTourTypeID = ClsCommon.ConvertStringint(TOURTYPE.SPECIAL_TOUR);
            ucTourShortInfo1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            ucTourShortInfo1.fldTourTypeID = ClsCommon.ConvertStringint(TOURTYPE.SPECIAL_TOUR);
            ucTourShortInfo1.fldTourType = "Holiday Packages";
            ucTourCostIncludeExcIude1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            ucTourCostIncludeExcIude1.fldTourType = ClsCommon.ConvertStringint(TOURTYPE.SPECIAL_TOUR);
            ucMatchingTour1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            ucMatchingTour1.fldTourType = ClsCommon.ConvertStringint(TOURTYPE.SPECIAL_TOUR);
            //ucMatchingTour1.fldZoneID = ClsCommon.ConvertStringint(Request.QueryString["Code"]);
            UcSPLModifySearch1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            UcSPLModifySearch1.fldTourType = ClsCommon.ConvertStringint(TOURTYPE.SPECIAL_TOUR);
            UCTourInfo1.fldTourType = TOURTYPE.SPECIAL_TOUR;
            UCTourInfo1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
            UCTourGallery1.fldTourType = TOURTYPE.SPECIAL_TOUR;
            UCTourGallery1.fldTourID = ClsCommon.ConvertStringint(Request.QueryString["TourID"]);
        }
        #endregion

        #region Old Page code commented


        #region Event(s)




        private void HideDateSelection()
        {
            int lTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            int[] lTours = new int[] { 46, 49, 67, 50, 115, 119, 120, 121, 123, 124, 132, 133 };
            if (Array.IndexOf(lTours, lTourID) >= 0)
                UcSPLModifySearch1.Visible = false;
            else
                UcSPLModifySearch1.Visible = true;
        }

        #endregion
        #region Method(s)
        private void BindTourItenerary()
        {
            List<TourItenerary_SPResult> lGetResult = null;
            clsAdo objOther = new clsAdo();
            hd.Style.Add("background-image", "url(Assets/images/banner.jpg)");
            try
            {
                lGetResult = new List<TourItenerary_SPResult>();

                lGetResult = objOther.fnGetTourItenerary(ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]), ClsCommon.ConvertStringint(TOURTYPE.SPECIAL_TOUR)).ToList();
                if (lGetResult != null && lGetResult.Count > 0)
                {
                    if (lGetResult[0].IsQuery)
                    {
                        divCal.Visible = false;
                    }
                    bool lFlag = false;
                    if (lGetResult[0].PageBanner != null && Convert.ToString(lGetResult[0].PageBanner) != "")
                    {
                        hd.Style.Add("background-image", "url(Assets/images/PageBanner/SPLTour/" + lGetResult[0].PageBanner + ")");
                        lFlag = true;
                    }
                    else
                    {
                        try
                        {
                            string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("Assets//images/PageBanner/SPLTour/"));
                            List<String> images = new List<string>(filesindirectory.Count());
                            foreach (string item in filesindirectory)
                            {
                                string lFileName = System.IO.Path.GetFileName(item).Split('.')[0].ToString();
                                if (lFileName.Trim().ToUpper() == lGetResult[0].Tour_Short_key.Trim().ToUpper())
                                {
                                    hd.Style.Add("background-image", "url(Assets/images/PageBanner/SPLTour/" + System.IO.Path.GetFileName(item) + ")");
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

            clsAdo objOther = new clsAdo();
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
                DataTable dtM = objOther.fnGetMetaTagForTours(ClsCommon.ConvertStringint(TOURTYPE.SPECIAL_TOUR), TourId, CountryID, ZoneId);
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
                            Page.Title = strContentText;
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
                if (objOther != null)
                {
                    objOther = null;
                }
            }
        }
        private bool IsDiscountValid(string pTourID)
        {
            return (IsValidTour(pTourID));
        }
        private bool IsValidTour(string lTourToFind)
        {
            string[] lValidTours = new string[] { "1", "18", "19", "20", "22", "23", "25", "27", "28", "29", "30", "31", "33", "34", "39", "40", "41", "49", "66", "67", "68", "69", "79", "83", "84", "85", "86", "90", "93", "94", "97", "98", "99", "100", "101", "102", "103", "105", "110", "114", "131" };
            return lValidTours.Any(lTourToFind.Equals);
        }
        #endregion
        #endregion
    }
}