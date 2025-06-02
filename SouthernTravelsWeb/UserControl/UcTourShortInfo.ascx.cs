using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcTourShortInfo : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        int pvTourID, pvTourTypeID, pTourInfo = 0, pSimilarPKG = 0, pGallery = 0;
        string pvTourType, pvClass = "", pOfferIDs = "";
        bool pvCanBook = true,
            pvIsShow = true, pvIsQuery = false;
        string lDepartTextForMail = "";
        string lReturnTextForMail = "";
        #endregion
        #region "Property(s)"
        public bool fldIsShow
        {
            get
            {
                return pvIsShow;
            }
            set
            {
                pvIsShow = value;
            }
        }
        public bool fldIsQuery
        {
            get
            {
                return pvIsQuery;
            }
            set
            {
                pvIsQuery = value;
            }
        }
        public int fldTourID
        {
            get { return pvTourID; }
            set { pvTourID = value; }
        }
        public bool fldCanBook
        {
            get
            {
                return pvCanBook;
            }
            set
            {
                pvCanBook = value;
            }
        }
        public int fldTourTypeID
        {
            get { return pvTourTypeID; }
            set { pvTourTypeID = value; }
        }
        public string fldTourType
        {
            get { return pvTourType; }
            set { pvTourType = value; }
        }
        public string fldClass
        {
            get { return pvClass; }
            set { pvClass = value; }
        }
        public string fldOfferIDs
        {
            get
            {
                if (Request.QueryString["ofr"] != null && Request.QueryString["ofr"].ToString().Trim() != string.Empty)
                {
                    pOfferIDs = Request.QueryString["ofr"].ToString().Trim();
                }
                else
                {
                    pOfferIDs = "1";
                }
                return pOfferIDs;
            }
            set { pOfferIDs = value; }
        }
        public int fldGallery
        {
            get { return pGallery; }
            set { pGallery = value; }
        }
        public int fldTourInfo
        {
            get { return pTourInfo; }
            set { pTourInfo = value; }
        }
        public int fldSimilarPKG
        {
            get { return pSimilarPKG; }
            set { pSimilarPKG = value; }
        }
        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if(!string.IsNullOrEmpty(Page.RouteData.Values["tourId"]))
                //pvTourID=Convert.ToInt32(Page.RouteData.Values["tourId"]);
                //if (!string.IsNullOrEmpty(Request.QueryString["TourType"]))
                //    pvTourType = Convert.ToInt32(Request.QueryString["TourType"]);
                // pvTourID = 73;
                // pvTourType =1;
                BindTourItenerary();
                BindPlace();
                BindHtmlForSendItineryEmail();
                CheckIntlEBKTourIDs(Convert.ToString(fldTourID));
            }
            if (fldCanBook)
            {
                divhBook.Visible = false; AcvBook.Visible = false;
            }
            if (fldTourTypeID == 3)
            {
                //divhBook.Visible = false; AcvBook.Visible = false;
                divhBook.Visible = true; AcvBook.Visible = false;
            }
            if (!fldIsShow)
                UCPrintMailSms1.Visible = false;

            UCPrintMailSms1.fldTourTypeID = fldTourTypeID;
            UCPrintMailSms1.fldTourID = fldTourID;
            IntLeftUC2.fldOfferID = fldOfferIDs;
        }

        protected void BindHtmlForSendItineryEmail()
        {
            string strTourCodeDetails = "";
            strTourCodeDetails += "<table border='1' style='border-collapse: collapse; width:100%;'><tr><td style='padding:5px 5px 5px 5px;'>";
            if (fldCanBook == true)
            {
                strTourCodeDetails += "<section class='hidbookingnmobile'>";
            }
            else
            {
                strTourCodeDetails += "<section>";
            }
            strTourCodeDetails += "<div style='margin-top:10px;'>";
            strTourCodeDetails += "<div style='width:100%;margin-top:5px;'> <b>Tour Code :</b> " + litTourCode.Text + "</div>";
            strTourCodeDetails += "<div style='width:100%;margin-top:5px;'> " + litDay.Text + "</div>";
            if (fldTourTypeID != 3)
            {
                strTourCodeDetails += lDepartTextForMail + "<br/>";
                strTourCodeDetails += lReturnTextForMail + "<br/>";
            }
            strTourCodeDetails += "<br/>";

            if (fldTourTypeID != 3)
            {
                strTourCodeDetails += "<b>Places Covered :</b>" + litCovered.Text + "<br/>";
            }
            else
            {
                strTourCodeDetails += "<b>City Covered :</b>" + litCovered.Text + "<br/>";
            }

            if (fldTourTypeID != 2)
            {
                strTourCodeDetails += "<br/><p>" + litCoachDetails.Text + "</p>";
            }
            strTourCodeDetails += "<p  runat='server' id ='AcvBook'>";
            strTourCodeDetails += "</div>";
            strTourCodeDetails += "</section>";
            strTourCodeDetails += "</td></tr></table>";

            HiddenField hdnTourCodeDetails = this.Page.FindControl("hdnTourCodeDetails") as HiddenField;
            hdnTourCodeDetails.Value = strTourCodeDetails;
        }

        #endregion
        #region "Method(s)"
        private void BindTourItenerary()
        {
            List<TourItenerary_SPResult> lGetResult = null;
            ClsCommon objOther = new ClsCommon();

            try
            {
                lGetResult = new List<TourItenerary_SPResult>();
                lGetResult = objOther.fnGetTourItenerary(fldTourID, fldTourTypeID).ToList();
                if (lGetResult != null && lGetResult.Count > 0)
                {

                    litCoachDetails.Text = lGetResult[0].CoachDetails.ToString();
                    if (lGetResult[0].Fair <= 0)
                    {
                        fare.Visible = false;
                    }
                    if (lGetResult[0].IsQuery)
                    {
                        divhBook.Visible = false; AcvBook.Visible = false;
                    }
                    CultureInfo CInfo = new CultureInfo("hi-IN");
                    litCost.Text = Convert.ToDecimal(lGetResult[0].Fair).ToString("N", CInfo).Split('.')[0] + " /-";
                    if (lGetResult[0].Notes.ToString() != "")
                    {
                        ltrTourPolicy.Text = "<li><i class=\"fa fa-arrow-right\"></i> Note :<br><span>" +
                            lGetResult[0].Notes.ToString().Replace("notes", "").Replace("note", "").Replace("notes:", "").Replace("note:", "") + "</span></li>";
                        if (lGetResult[0].Notes.Contains("<li>"))
                        {
                            string lTourPolic = lGetResult[0].Notes.ToString().Replace("notes", "").Replace("note", "").Replace("notes:", "").Replace("note:", "").
                             Replace("</ul>", "").Replace("<ul>", "").Replace("\r", "").Replace("\n", "");

                            ltrTourPolicy.Text = "<li><i class=\"fa fa-arrow-right\"></i> Note :<br><ul class=\"leftitinerary\">" +
                             lTourPolic + "</ul></li>";
                        }
                    }
                    //ltrTourIteineray.Text = lGetResult[0].DetailedItenerary.ToString();
                    if (!lGetResult[0].Departuretime.ToString().Trim().StartsWith("00:00 Hrs"))
                    {
                        string lDepartText = "<li class=\"departure\"><i class=\"fa fa-clock-o\"></i> Departure :<span>";
                        lDepartText += Convert.ToString(lGetResult[0].DepartureWeekDays) + "  (" + lGetResult[0].Departuretime.ToString() + ")";
                        lDepartText += "</span></li>";
                        litDepart.Text = lDepartText;

                        lDepartTextForMail = " <b>Departure :</b><span>";
                        lDepartTextForMail += Convert.ToString(lGetResult[0].DepartureWeekDays) + "  (" + lGetResult[0].Departuretime.ToString() + ")";
                        lDepartTextForMail += "</span>";
                    }
                    if (!lGetResult[0].ReturnTime.ToString().Trim().StartsWith("00:00 Hrs"))
                    {
                        string lReturnText = "<li class=\"return\"><i class=\"fa fa-clock-o\"></i> Return : <span>";
                        lReturnText += Convert.ToString(lGetResult[0].ReturnWweekDays) + "  (" + lGetResult[0].ReturnTime.ToString() + ")";
                        lReturnText += "</span></li>";
                        litReturn.Text = lReturnText;

                        lReturnTextForMail = " <b>Return :</b> <span>";
                        lReturnTextForMail += Convert.ToString(lGetResult[0].ReturnWweekDays) + "  (" + lGetResult[0].ReturnTime.ToString() + ")";
                        lReturnTextForMail += "</span>";
                    }

                    litTourCode.Text = Convert.ToString(lGetResult[0].Tour_Short_key).ToUpper();
                    litType.Text = Convert.ToString(lGetResult[0].HolidayType);

                    litStates.Text = Convert.ToString(lGetResult[0].State);
                    litCovered.Text = Convert.ToString(lGetResult[0].TourGoingOn);
                    litCatogory.Text = Convert.ToString(lGetResult[0].OfferZone);
                    if (Convert.ToString(lGetResult[0].Remarks) != "")
                    {
                        ltrRemarks.Text = "<li><i class=\"fa fa-arrow-right\"></i> Remarks :<br><span>" + Convert.ToString(lGetResult[0].Remarks) + "</span></li>";
                    }
                 
                    if ((Convert.ToInt32(lGetResult[0].NoOfDays) == 1) && (Convert.ToInt32(lGetResult[0].NoOfNights) == 0))
                    {
                        litDay.Text = " Daily";
                    }
                    else
                    {
                        if (Convert.ToInt32(lGetResult[0].NoOfDays) > 0)
                        {
                            litDay.Text = Convert.ToString(lGetResult[0].NoOfDays) + " D";
                        }
                        if (Convert.ToInt32(lGetResult[0].NoOfNights) > 0)
                        {

                            litDay.Text += " / " + Convert.ToString(lGetResult[0].NoOfNights) + " N";
                        }
                    }
                    ltrTourName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(lGetResult[0].TourName.ToString()) + " - " + litDay.Text;
                    HiddenField hdnTourName = this.Page.FindControl("hdnTourName") as HiddenField;
                    hdnTourName.Value = ltrTourName.Text;
                   
                    if (lGetResult[0].CoachDetails != null)
                    {
                        litCoachDetails.Text = lGetResult[0].CoachDetails.ToString();
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
        private void BindPlace()
        {
            ClsCommon clsCmn= new ClsCommon();
            List<GetTourPlaceInfo_SPResult> lGetPlaceName = null;
            ArrayList ArrAlpha = new ArrayList();
            ArrAlpha.Add("A"); ArrAlpha.Add("B"); ArrAlpha.Add("C"); ArrAlpha.Add("D"); ArrAlpha.Add("E"); ArrAlpha.Add("F"); ArrAlpha.Add("G");
            ArrAlpha.Add("H"); ArrAlpha.Add("I"); ArrAlpha.Add("J"); ArrAlpha.Add("K"); ArrAlpha.Add("L"); ArrAlpha.Add("M"); ArrAlpha.Add("N");
            ArrAlpha.Add("O"); ArrAlpha.Add("P"); ArrAlpha.Add("Q"); ArrAlpha.Add("R"); ArrAlpha.Add("S"); ArrAlpha.Add("T"); ArrAlpha.Add("U");
            ArrAlpha.Add("V"); ArrAlpha.Add("W"); ArrAlpha.Add("X"); ArrAlpha.Add("R"); ArrAlpha.Add("Z");
            try
            {
                lGetPlaceName = new List<GetTourPlaceInfo_SPResult>();

                lGetPlaceName = clsCmn.fnGetTourPlaceInfo(Convert.ToInt32(Page.RouteData.Values["tourId"]), Convert.ToInt32(fldTourTypeID)).ToList();
                if (lGetPlaceName != null && lGetPlaceName.Count > 0)
                {

                    string lPlace = "", lState = "";
                    for (int iCtr = 0; iCtr < lGetPlaceName.Count; iCtr++)
                    {
                        lPlace += lGetPlaceName[iCtr].PlaceName + ", ";
                        if (!lState.Contains(lGetPlaceName[iCtr].StateName))
                            lState += lGetPlaceName[iCtr].StateName + ", ";
                    }

                    litCovered.Text = lPlace.Trim().TrimEnd(',');
                    litStates.Text = lState.Trim().TrimEnd(',');

                    string strGeoCode = "";
                    string strCity = "";
                    string strAlpha = "";
                    if (lGetPlaceName.Count > 1)
                    {
                        if (lGetPlaceName[0].TourStartCity != "")
                        {
                            strGeoCode = lGetPlaceName[0].TourStartCity.ToString() + "@";
                            strCity = lGetPlaceName[0].TourStartFrom.ToString() + "@";
                            strAlpha = ArrAlpha[0].ToString() + "@";

                        }
                    }
                    else
                    {
                        if (lGetPlaceName[0].TourStartCity != "")
                        {
                            strGeoCode = lGetPlaceName[0].TourStartCity.ToString() + "@" + lGetPlaceName[0].TourStartCity.ToString();
                            strCity = lGetPlaceName[0].TourStartFrom.ToString() + "@" + lGetPlaceName[0].TourStartFrom.ToString();
                            strAlpha = "A@B";

                        }
                    }

                    int lCtr = 1;
                    int lCounter = 1;
                    string htmlTourPlace = "";/* "<table cellpadding='3' cellspacing='3' border='0' width='100%'>  <td align='left' colspan='2' style='color:#DD3E21;font-weight:bold;'>Place Corvered : </td> </tr><tr><td width='20%'> </td> <td>";
                    htmlTourPlace += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";*/
                    string htmlPlaceCol1 = "<div class=\"col1\">", htmlPlaceCol2 = "<div class=\"col2\">";
                    for (int iCtr = 0; iCtr < lGetPlaceName.Count; iCtr++)
                    {
                        if (!strGeoCode.Contains(lGetPlaceName[iCtr].GeoCode.ToString()))
                        {
                            strGeoCode = strGeoCode + lGetPlaceName[iCtr].GeoCode.ToString() + "@";
                            strCity = strCity + lGetPlaceName[iCtr].CityName.ToString() + "@";
                            strAlpha = strAlpha + ArrAlpha[lCtr].ToString() + "@";
                            lCtr = lCtr + 1;
                            hdRoutepUs.Value = "1";
                        }
                    }
                    for (int iCtr = 0; iCtr < lGetPlaceName.Count; iCtr++)
                    {
                        if (!htmlTourPlace.Contains(lGetPlaceName[iCtr].PlaceName.ToString()))
                        {
                            htmlPlaceCol1 += "<a href='#Place" + lGetPlaceName[iCtr].PlaceName.ToString() +
                                "' name='top'>" + lGetPlaceName[iCtr].PlaceName.ToString() + "</a><br />";
                            iCtr++;
                            try
                            {
                                htmlPlaceCol2 += "<a href='#Place" + lGetPlaceName[iCtr].PlaceName.ToString() +
                                "' name='top'>" + lGetPlaceName[iCtr].PlaceName.ToString() + "</a><br />";
                            }
                            catch
                            {
                            }
                        }
                    }
                    htmlTourPlace += htmlPlaceCol1 + "</div>" + htmlPlaceCol2 + "</div>";
                    strGeoCode = strGeoCode.TrimEnd('@');
                    strCity = strCity.TrimEnd('@');
                    strAlpha = strAlpha.TrimEnd('@');
                    hdGeoCode.Value = strGeoCode.ToString();
                    hdCity.Value = strCity.ToString();
                    hdAlpha.Value = strAlpha.ToString();
                }
            }
            catch
            {
            }
            finally
            {
                if (lGetPlaceName != null)
                {
                    lGetPlaceName = null;
                }
            }
        }

        private void CheckIntlEBKTourIDs(string strTourid)
        {
            string Ids = ConfigurationManager.AppSettings["IntlEBKTourIDs"];
            string[] Arr = Ids.Split(',');
            foreach (string str in Arr)
            {
                if (str == strTourid)
                {
                    litDepart.Text = litReturn.Text = string.Empty;
                    break;
                }
            }
        }

        #endregion
    }
}