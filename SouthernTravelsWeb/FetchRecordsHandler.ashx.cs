using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthernTravelsWeb
{
    /// <summary>
    /// Summary description for FetchRecordsHandler
    /// </summary>
    public class FetchRecordsHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Threading.Thread.Sleep(500);

            int lPageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            int lPageSize = Convert.ToInt32(9);
            int lastProdID = Convert.ToInt32(context.Request.QueryString["lastSortID"]);

            int pSortBy = Convert.ToInt32(context.Request.QueryString["SortBy"]);


            int pvTourID = 0;
            string[] pSearchStr = Convert.ToString(context.Request.QueryString["SearchStr"]).Split('~');

            string pvprefixText = Convert.ToString(pSearchStr[0]);
            int pvMinDay = Convert.ToInt32(pSearchStr[1]);
            int pvMaxDay = Convert.ToInt32(pSearchStr[2]);
            int pvTravelMonth = Convert.ToInt32(pSearchStr[3]);
            int pvTourType = Convert.ToInt32(context.Request.QueryString["TourType"]); ;//pSearchStr[4]);
            int pvZoneID = Convert.ToInt32(context.Request.QueryString["ZoneID"]); ;
            bool pvIncludeCityOutput = false;
            int pvNoOfDays = Convert.ToInt32(context.Request.QueryString["NoOfDays"]); ;
            int pvPriceMin = Convert.ToInt32(context.Request.QueryString["PriceMin"]); ;
            int pvPriceMax = Convert.ToInt32(context.Request.QueryString["PriceMax"]); ;
            int pvOfferID = Convert.ToInt32(context.Request.QueryString["OfferID"]);

            string lSearchedTours = ClsCommon.GetTourList_New(lPageIndex, lPageSize, pSortBy, pvprefixText, pvMinDay, pvMaxDay,
                pvTravelMonth, pvTourType, pvIncludeCityOutput, pvTourID, pvZoneID, pvNoOfDays, pvPriceMin, pvPriceMax, pvOfferID);
            lSearchedTours = lSearchedTours.Replace(">Usa ", ">USA ").Replace(" Usa ", " USA ").Replace(" Usa<", " USA<");

            context.Response.Write(lSearchedTours);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}