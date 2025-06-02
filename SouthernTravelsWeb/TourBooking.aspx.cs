using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class TourBooking : System.Web.UI.Page
    {
        #region "Member Variable(s)"
        protected int[] busserial = new int[30];
        protected string tCBNACFare, tSACFare, tSNACFare, tAnonacfare, tCACFAre, tCnonacfare, tCBACSBfare, tCBNACSBfare, tCBACinffare, tCBNACinffare,
            tAACFAre, tA2ACFare, tA2NACFare, tA3ACFare, tA3NACFare, tCBACFare, tDACFare, tDNACFare, tAWFACFAre, tAWFnonacfare, tCWFACFAre, tCWFnonacfare;
        protected string tempstr, strEncrypt = "", BusEnvType, orderid;
        protected int totpax = 0, TourSerial, AvailSeat, Tourno, BusSeaterType;
        protected StringBuilder Chart;
        public string endecript = System.Configuration.ConfigurationManager.AppSettings["ENCRY"].ToString();
        DateTime pvQStrJDate = new DateTime(), pvDDLJDate = new DateTime();

        protected decimal GrandTotal = 0.0m, PayNowTotal = 0.0m;
        protected int tourid, TotalPaxAdults = 0, TotalPaxChilds = 0, adulttwin = 0, adults = 0, dormitory = 0, ADWFood = 0, CWFood = 0;
        protected int childs = 0, adulttriple = 0, singleadult = 0, childwithoutbed = 0, childinf = 0, sqlreadexist, rowid, childwithoutseatbed;
        protected ArrayList datearr1 = new ArrayList();
        protected ArrayList datearr = new ArrayList();
        protected ArrayList datearr11 = new ArrayList();
        protected ArrayList datearr12 = new ArrayList();
        public DataView TempDataView;
        protected string strtourid = "";

        protected int[] nseats = new int[100];
        //------ for Customer Details ----//

        public string strDeCrypt = "", strEncryptedval = "";
        //-------------Linq To DB----------------------
        public string IntlEBKTourIDs = string.Empty;
        public bool FlagIntlEBKTourIDs = false;
        #endregion
        #region "Property(s)"
        public DateTime fldQStrJDate
        {
            get
            {
                try
                {
                    //string lstrJDate = DataLib.scriptclear(Page.RouteData.Values["jdate"].ToString());
                    string lstrJDate = DataLib.scriptclear(Page.RouteData.Values["jdate"].ToString().Replace("-", "/"));
                    ddlJdate.Value = DataLib.scriptclear(Page.RouteData.Values["jdate"].ToString().Replace("-", "/"));
                    ddlJdate1.Value = DataLib.scriptclear(Page.RouteData.Values["jdate"].ToString().Replace("-", "/"));
                    string[] lJDate = lstrJDate.Split('/');
                    pvQStrJDate = new DateTime(ClsCommon.ConvertStringint(lJDate[2]), ClsCommon.ConvertStringint(lJDate[0]),
                        ClsCommon.ConvertStringint(lJDate[1]));
                }
                catch
                {
                }
                return pvQStrJDate;
            }
            set
            {
                pvQStrJDate = value;
            }
        }

        public DateTime fldDDLJDate
        {
            get
            {
                string lstrJDate = DataLib.scriptclear(Page.RouteData.Values["jdate"].ToString().Replace("-", "/"));
                string[] lJDate = lstrJDate.Split('/');
                try
                {
                    pvDDLJDate = new DateTime(ClsCommon.ConvertStringint(lJDate[2]), ClsCommon.ConvertStringint(lJDate[0]),
                    ClsCommon.ConvertStringint(lJDate[1]));
                }
                catch { }
                return pvDDLJDate;
            }
            set
            {
                pvDDLJDate = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            Form1.Action = Request.RawUrl;
            clsAdo pClsObj = null;
            string pURL = Request.Url.ToString();
            btnFaceBook_BookFixed.Attributes["style"] = "visibility: hidden";
            CheckIntlEBKTourIDs(Convert.ToString(Page.RouteData.Values["tourId"]));
            if (!IsPostBack)
            {
                short pinDex = 0;
                if (ViewState["pickUpIndex"] != null)
                    pinDex = short.Parse(ViewState["pickUpIndex"].ToString());
                ddlPickUp.SelectedIndex = pinDex;
                hidDepTime.Value = "";
                hidPickupPlace.Value = "";
                CheckIntlEBKTourIDs(Convert.ToString(Page.RouteData.Values["tourId"]));
                FTFarePane91.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
                ViewState["ptourid"] = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
                FTFarePane91.fldJourneyDate = Convert.ToString(Page.RouteData.Values["jdate"]);
                if (Request.QueryString["ltc"] != null)
                {
                    //FTFarePane91.fldCanBook = false;
                    FTFarePane91.fldIsLTC = true;
                    ClientScript.RegisterStartupScript(typeof(Page), "Error", "<script language='JavaScript'>alert('For availing LTC, you have to submit an application " +
                            "to the State/central government well in advance in a prescribed " +
                            "format. \\nPlease contact our Toll Free No: 1800 11 0606 for further details..'); </script>");
                }


            }
            ucItinerary.fldTourType = TOURTYPE.FIXED_TOUR;
            ucItinerary.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            UCCityWisePlaceDisplay1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            UCCityWisePlaceDisplay1.fldTourTypeID = ClsCommon.ConvertStringint(TOURTYPE.FIXED_TOUR);
            ucTourShortInfo1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            ucTourShortInfo1.fldTourTypeID = ClsCommon.ConvertStringint(TOURTYPE.FIXED_TOUR);
            ucTourShortInfo1.fldTourType = "Fixed Departure";
            ucTourShortInfo1.fldCanBook = true;
            ucTourShortInfo1.fldIsShow = false;
            ucTourShortInfo1.fldClass = "active";
            ucMatchingTour1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            ucMatchingTour1.fldTourType = ClsCommon.ConvertStringint(TOURTYPE.FIXED_TOUR);
            UCTourInfo1.fldTourType = TOURTYPE.FIXED_TOUR;
            UCTourInfo1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            UCTourGallery1.fldTourType = TOURTYPE.FIXED_TOUR;
            UCTourGallery1.fldTourID = ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]);
            //Session["Panel2Step"] = null;
            if (Session["Panel2Step"] != null)
            {
                FTFarePane91.Visible = false;
                UcModifySearch1.Visible = false;
                pnl1Step.Visible = false;
                Pnl2Step.Visible = true;

                Session["mode"] = "";
                txtName.Attributes.Add("onkeypress", "javascript:return CheckOnlyCharacter();");
                CheckSubmit.Attributes.Add("onclick", "return chk1()");
                btngo.Attributes.Add("onclick", "return checkonsubmit()");

                if (!(Request.QueryString["orderid"] == null))
                {
                    //strEncryptedval = Request.QueryString["orderid"].ToString();
                    strEncryptedval = AddSlashAmp(Request.QueryString["orderid"].ToString());


                    strDeCrypt = DataLib.TripleDESDecode(strEncryptedval.Replace(" ", "+"), endecript);
                    ViewState["strDeCrypt"] = strDeCrypt;
                }
                if (!Page.IsPostBack)
                {
                    CheckIntlEBKTourIDs(Convert.ToString(Page.RouteData.Values["tourId"]));
                    try
                    {
                        string sTourshortcode = GetTourShortCodeByTourID(Convert.ToString(ViewState["ptourid"]));
                        //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('For hassle free booking, please complete your transaction within 20 minutes.');</script>");
                        ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MesgPopup_1()", true);
                        //comment below popup new mesg show on YGBK-H and BK-H tour booking
                        if (sTourshortcode.ToLower() == "YGBK-H".ToLower() || sTourshortcode.ToLower() == "BK-H".ToLower() || sTourshortcode.ToLower() == "AMAR-VH".ToLower())
                        { ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MesgPopup()", true); }
                        else
                        { ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MesgPopup_1()", true); }


                        BindCountryName();
                        BindNationalityName();
                        //BindStateName();
                    }
                    finally
                    {
                        if (pClsObj != null)
                        {
                            pClsObj = null;
                        }
                    }

                    if (Session["custrowid"] != null)
                    {
                        BindProFile();

                        //CheckSubmit_Click(this, new ImageClickEventArgs(0,0));
                    }


                    if (!(Request.QueryString["orderid"] == null))
                    {
                        //  strEncryptedval = Request.QueryString["orderid"].ToString();
                        strEncryptedval = AddSlashAmp(Request.QueryString["orderid"].ToString());

                        strDeCrypt = DataLib.TripleDESDecode(strEncryptedval.Replace(" ", "+"), endecript);
                        ViewState["strDeCrypt"] = strDeCrypt;
                        string strQuetring = ViewState["strDeCrypt"].ToString();
                        Response.Write("<input type=hidden id=orderid name=orderid value=" + ViewState["strDeCrypt"].ToString() + ">");
                        lblbookingdate.Text = System.DateTime.Now.ToLongDateString();
                        string str1, hr;
                        hr = ConfigurationManager.AppSettings["CustomerFixedTourHours"].ToString();
                        hr = "-" + hr;
                        #region Optimize Code

                        #endregion
                        pClsObj = new clsAdo();
                        int? pHours = ClsCommon.ConvertStringint(hr);
                        DataTable dtTour = pClsObj.fnGetTour(pHours);
                        try
                        {

                            ddlTour.Items.Clear();
                            ddlTour.DataSource = pClsObj.fnGetTour(pHours);
                            ddlTour.DataValueField = "TourNo";
                            ddlTour.DataTextField = "TourName";
                            ddlTour.DataBind();
                            ddlTour.Items.Insert(0, new ListItem("Book Another Tour Package", "0"));
                            FillDgtour();
                        }
                        finally
                        {
                            if (pClsObj != null)
                            {
                                pClsObj = null;
                            }
                        }
                    }

                    // for MD5 Password Purpose Start
                    Random r = new Random();
                    string password = r.Next().ToString();
                    if (password.Length > 6)
                    {
                        password = password.Remove(6);
                    }
                    ViewState["Spass"] = password.Trim().ToString();
                    ClientScript.RegisterStartupScript(typeof(string), "stsrtupSend8", "<script>fnMd5('" + ViewState["Spass"].ToString() + "');</script>");
                    password = tmpEnValue.Value;
                    // End For MD5 Password

                    TieButton(emailid, CheckSubmit);
                }
                else
                {
                    ViewState["strPass"] = tmpEnValue.Value;
                }
                this.Submit1.Attributes.Add("onclick", "return doValidate2();");
                if (Convert.ToString(ViewState["tourid"]) != "")
                    tourid = ClsCommon.ConvertStringint(ViewState["tourid"]);
            }
            else
            {
                try
                {
                    ModifyMetaTag(ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]));
                    BindTourItenerary(ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]));

                    divPickupPoint.Visible = true;

                    pClsObj = new clsAdo();
                    string redirectUrl = "";
                    string url = this.Request.Url.ToString();
                    //For Checking Weather the Booking is LTC or Normal Booking
                    if (url.IndexOf("true") != -1)
                    {
                        lblLTCMsg.Visible = true;
                        lblLTCMsg.Text = "For availing LTC, you have to submit an application " +
                            "to the State/central government well in advance in a prescribed " +
                            "format. Please contact our Toll Free No: 1800 11 0606 for further details.";
                    }
                    else
                        lblLTCMsg.Visible = false;
                    //For Checking the Proper URL For Payment gate way Purpose, they Accept Http://www.southerntravelsindia.com only
                    if (this.Context.Request.Url.AbsoluteUri.Contains("http://southern"))
                    {
                        redirectUrl = this.Context.Request.Url.AbsoluteUri.Replace("http://southern",
                            "http://www.southern");
                        Response.Redirect(redirectUrl);
                    }
                    Session["mode"] = "";
                    Session["EndUserId"] = "EndUser";
                    if (Session["EndUserId"] == null)
                        Response.Redirect("sessionexpire.aspx");
                    else if (Session["EndUserId"] != null)
                        sess.Value = "1";
                    if ((Request.QueryString["orderid"] == "") || (Request.QueryString["orderid"] == null) || (Request.QueryString["orderid"] == "0"))
                    {
                        if (Session["blockStatus_EndUser"] != null)
                        {
                            string[] seat = Convert.ToString(Session["blockStr_EndUser"]).Split('#');
                            doUnBlock(seat[0], Convert.ToInt32(seat[1]));
                            refresh();
                        }
                    }

                    if (Convert.ToString(Page.RouteData.Values["tourId"]) != "")
                    {
                        if (Page.RouteData.Values["jdate"] != null && Page.RouteData.Values["jdate"] != "")
                        {
                            discount.Value = validateDiscount(fldQStrJDate);

                            string acnonac = DataLib.getvacantseats(ClsCommon.ConvertStringint(DataLib.
                                funClear(Page.RouteData.Values["tourId"]?.ToString())), Convert.ToString(
                                Page.RouteData.Values["jdate"]).Replace("-", "/"));

                            string[] ac = acnonac.Split('^');
                            if (FlagIntlEBKTourIDs)
                            {
                                lblavailcheck.Text = "";
                                lblNONACAVAIL.Text = "";
                            }
                            else
                            {
                                lblavailcheck.Text = "(" + ac[0] + ")";
                                lblNONACAVAIL.Text = "(" + ac[1] + ")";
                            }
                            BuschkType.Value = ChkBusType(fldQStrJDate);

                        }
                        else
                        {

                        }
                        #region Optimize Code

                        if (Request.QueryString["ltc"] != null)
                        {
                            service.Value = Convert.ToString(pClsObj.fnGetServiceTaxValue("LTC"));
                            List<GetOverrideServiceTax_SPResult> lResult = null;
                            lResult = pClsObj.fnGetOverrideServiceTax(1, ClsCommon.ConvertStringint(
                                Page.RouteData.Values["tourId"]), "");
                            if (lResult != null && lResult.Count > 0)
                            {
                                service.Value = lResult[0].NewTax.ToString();
                            }
                        }
                        else
                        {
                            service.Value = pClsObj.fnGetServiceTaxIsAcc(ClsCommon.ConvertStringint(
                                Page.RouteData.Values["tourId"]));
                        }

                        credit.Value = DataLib.GetserviceTax("CC");
                        hdServiceChargeTax.Value = Convert.ToString(pClsObj.fnGetServiceTaxValue("SCTax"));
                        if (!Page.IsPostBack)
                        {
                            CheckIntlEBKTourIDs(Convert.ToString(Page.RouteData.Values["tourId"]));
                            BindPlace();
                            Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "addScript", "Getfare()", true);

                            if (Session["utm_source"] == null
                                && Session["utm_medium"] == null
                                && Session["utm_term"] == null
                                && Session["utm_content"] == null
                                && Session["utm_campaign"] == null)
                            {
                                if (Request.QueryString["orderid"] == null)
                                {
                                    if (Session["custrowid"] == null && Session["FromDate"] == null)
                                    {
                                        Session.Clear();
                                    }
                                }
                            }


                            Session["EndUserId"] = "EndUser";
                            if (Session["EndUserId"] != null)
                                sess.Value = "1";
                            if ((Page.RouteData.Values["tourId"] != null) &&
                               ((Request.QueryString["combination"] == null) || Request.QueryString["combination"] == "0"))
                            {
                                #region Optimize Code

                                #endregion

                                string str = pClsObj.fnGetCombinationTour(ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]));
                                if (str == "0")
                                {
                                    // For Single Tour
                                    fillddlJdate(ClsCommon.ConvertStringint(DataLib.funClear(
                                         Page.RouteData.Values["tourId"]?.ToString())), 0);
                                    //Geting a Dispatur Time
                                    Dispup(ClsCommon.ConvertStringint(DataLib.funClear(
                                         Page.RouteData.Values["tourId"]?.ToString())), "N");
                                    hidTourId.Value = DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString());
                                    combination.Value = "N";
                                }
                                else
                                {
                                    #region Optimize Code
                                    fillddlJdate(ClsCommon.ConvertStringint(DataLib.funClear(
                                     Page.RouteData.Values["tourId"]?.ToString())), 0);

                                    //Geting a Dipatur Time [Need To ] combinationtour Y/N
                                    Dispup(ClsCommon.ConvertStringint(DataLib.funClear(
                                         Page.RouteData.Values["tourId"]?.ToString())), "N");

                                    // For Multiple Tour Associated.

                                    fillddlJdate(ClsCommon.ConvertStringint(str), 1);
                                    Dispup(ClsCommon.ConvertStringint(str), "Y");
                                    hidTourId.Value = DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString());
                                    hidTourId1.Value = str;
                                    ViewState["OT"] = hidTourId.Value;
                                    ViewState["NT"] = hidTourId1.Value;
                                    combination.Value = "Y";
                                    #endregion
                                }
                            }
                            if ((Page.RouteData.Values["tourId"] != null) &&
                                ((combination.Value != null) && combination.Value != "0"))
                            {
                                fillddlJdate(ClsCommon.ConvertStringint(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString())), 0);
                                Dispup(ClsCommon.ConvertStringint(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString())), "N");
                                hidTourId.Value = DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString());
                            }
                            else
                            {
                                string TId = null;
                                fillddlJdate(ClsCommon.ConvertStringint(TId), 0);
                            }
                            table5.Visible = false;
                            AssignOrderID();
                            if ((Request.QueryString["ltc"] != null) && (Request.QueryString["ltc"] != "0"))
                            {
                                #region Optimize Code
                                /*decimal ltCharges = Convert.ToDecimal(DataLib.GetStringData(
                            DataLib.Connection.ConnectionString, "select isnull(LTCCharges,0)" + 
                            " from Tbl_LTCCharges where rowid=1"));*/
                                #endregion
                                //  pClsObj = new clsAdo();
                                decimal ltCharges = Convert.ToDecimal(pClsObj.fnGetLTCCharges());

                                lblLTC.Text = " Extra @" + ltCharges.ToString() + "% for LTC ";
                            }
                            if (Request.QueryString["TourName"] != null)
                            {
                                hdfTourName.Value = Request.QueryString["TourName"].ToString();
                            }
                        }

                        if (Page.RouteData.Values["jdate"] != null && Page.RouteData.Values["jdate"] != "")
                        {
                            table5.Visible = true;
                            int tourid = ClsCommon.ConvertStringint(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString()));
                            getfaregrid(fldQStrJDate, tourid);
                            AssignOrderID();

                        }
                        else
                        {

                            Chart = new StringBuilder();
                            Chart.Append("");
                        }
                    }
                    else
                    {
                        table5.Visible = false;
                        btnContinuee.Visible = false;
                        colorindication.Visible = false;
                        btnRe.Visible = false;
                    }
                    btncheckavail.Enabled = true;
                    btnContinuee.Visible = false;
                    btnRe.Visible = false;
                    colorindication.Visible = false;
                    btncheckavail.Attributes.Add("onclick", "return checkradio();");
                    btncheckavail.Attributes.Add("onclick", "return Displayfare();");
                    btncheckavail.Attributes.Add("onclick", "return chkfield();");
                    btnContinuee.Attributes.Add("onclick", "return checkseats();");
                    btncheckavail.Attributes.Add("onclick", "return checkOnsubmit();");

                }
                finally
                {
                    if (pClsObj != null)
                    {
                        pClsObj = null;
                    }
                }
            }

            // Form.Action = Request.RawUrl;
        }
        protected void btncheckavail_Click(object sender, EventArgs e)
        {
            DataLib.vacentSeatNumber = new List<int>();
            DataLib.occupiedSeatNumber = new List<int>();
            DataLib.bus_vac_Number = new List<string>();

            if (IsHelicopterAvailable(ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]), Convert.ToString(Page.RouteData.Values["jdate"])) == false)
            {
                ClsCommon.ShowAlert("The Helicopter tickets are not available on this date. Please choose other date");
                return;
            }
            if (hdnWam.Value == "1" && !ChkTCS.Checked)
            {
                ClsCommon.ShowAlert("Please select I agree with the International Tours Terms & Conditions");
                return;
            }

            ViewState["chkbusno"] = "a";
            btncheckavail.Enabled = false;
            btncheckavail.Visible = false;
            btnRe.Visible = true;
            btnReset.Visible = false;
            txtNoOfAdults.ReadOnly = true;
            txtNoOfChilds.ReadOnly = true;
            txtNoOfAdultsTriple.ReadOnly = true;
            txtNoOfAdultsTwin.ReadOnly = true;
            txtNoOfSingles.ReadOnly = true;
            txtNoOfChildBed.ReadOnly = true;
            txtNoofdormitory.ReadOnly = true;
            btncheckavail.Enabled = false;
            txtNoAWFNoOfAdults.ReadOnly = true;
            txtNoCWFNoOfChilds.ReadOnly = true;
            AssignValue();
            AssignOrderID();
            orderid = OrderIDH.Value;
            Tourno = ClsCommon.ConvertStringint(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString()));
            ViewState["pickUpIndex"] = ddlPickUp.SelectedValue;
            lblPickupPlace.Text = hidPickupPlace.Value;
            lblDepTime.Text = hidDepTime.Value;
            if (FlagIntlEBKTourIDs) { lblDepTime.Visible = false; }

            //divPickupPoint.Visible = false;
            int lAdult = 0, lChild = 0;
            if (traf.Visible == true)
            {
                if ((txtNoOfAdults.Text == "") && (txtNoOfChilds.Text == ""))
                    totpax = 0;
                else
                {
                    totpax = ClsCommon.ConvertStringint(txtNoOfAdults.Text.ToString().Trim()) +
                        ClsCommon.ConvertStringint(txtNoOfChilds.Text.ToString().Trim());
                    lAdult = ClsCommon.ConvertStringint(txtNoOfAdults.Text.ToString().Trim());
                    lChild = ClsCommon.ConvertStringint(txtNoOfChilds.Text.ToString().Trim());
                }
            }
            if (trAWF.Visible == true)
            {
                if ((txtNoAWFNoOfAdults.Text == "") && (txtNoCWFNoOfChilds.Text == ""))
                {
                    totpax = 0;
                }
                else
                {
                    totpax = totpax + ClsCommon.ConvertStringint(txtNoAWFNoOfAdults.Text.ToString().Trim()) + ClsCommon.ConvertStringint(txtNoCWFNoOfChilds.Text.ToString().Trim());
                    lAdult = ClsCommon.ConvertStringint(txtNoAWFNoOfAdults.Text.ToString().Trim());
                    lChild = ClsCommon.ConvertStringint(txtNoCWFNoOfChilds.Text.ToString().Trim());
                }
            }
            if ((tra2f.Visible == true) || (tra3f.Visible == true) ||
                (trsf.Visible == true) || (tradf.Visible == true))
            {
                if ((txtNoOfAdultsTwin.Text == "") && (txtNoOfAdultsTriple.Text == "") &&
                    (txtNoOfChildBed.Text == "") && (txtNoOfSingles.Text == "") &&
                    (txtNoofdormitory.Text == ""))
                    totpax = 0;
                else
                {
                    totpax = ClsCommon.ConvertStringint(txtNoOfAdultsTwin.Text.ToString().Trim()) +
                        ClsCommon.ConvertStringint(txtNoOfAdultsTriple.Text.ToString().Trim()) +
                        ClsCommon.ConvertStringint(txtNoOfChildBed.Text.ToString().Trim()) +
                        ClsCommon.ConvertStringint(txtNoOfSingles.Text.ToString().Trim()) +
                        ClsCommon.ConvertStringint(txtNoofdormitory.Text.ToString().Trim());

                    lAdult = ClsCommon.ConvertStringint(txtNoOfAdultsTwin.Text.ToString().Trim()) +
                        ClsCommon.ConvertStringint(txtNoOfAdultsTriple.Text.ToString().Trim()) +
                        ClsCommon.ConvertStringint(txtNoOfSingles.Text.ToString().Trim());
                    lChild = ClsCommon.ConvertStringint(txtNoOfChildBed.Text.ToString().Trim()) + ClsCommon.ConvertStringint(txtNoofdormitory.Text.ToString().Trim());
                }
            }

            if (totpax == 0)
            {
                Response.Write("<script>alert('Please Enter No OF Passengers')</script>");
                btncheckavail.Enabled = true;
                return;
            }
            else
            {
                int lCurrPax = 0;
                if (txtNoOfAdultsTwin.Text.Trim() != "")
                {
                    lCurrPax = ClsCommon.ConvertStringint(txtNoOfAdultsTwin.Text.Trim());
                    if (lCurrPax % 2 != 0)
                    {
                        Response.Write("<script>alert('Enter Multiples of 2 Only')</script>");
                        btncheckavail.Enabled = true;
                        return;
                    }
                }
                lCurrPax = 0;
                if (txtNoOfAdultsTriple.Text.Trim() != "")
                {
                    lCurrPax = ClsCommon.ConvertStringint(txtNoOfAdultsTriple.Text.Trim());
                    if (lCurrPax % 3 != 0)
                    {
                        Response.Write("<script>alert('Enter Multiples of 3 Only')</script>");
                        btncheckavail.Enabled = true;
                        return;
                    }
                }
            }
            if (lChild > 0)
            {
                if (lAdult == 0)
                {
                    btncheckavail.Enabled = true;
                    return;
                    Response.Write("<script>alert('Please Enter At Least 1 Adult.')</script>");
                }
            }
            int availaseat, serialno = 0;
            string avail = ChekAvailability1(totpax, Tourno, fldDDLJDate);
            string[] ss = avail.Split('-');
            string busNo = "";
            if (ss.Length > 1)
            {
                availaseat = ClsCommon.ConvertStringint(ss[0]);
                serialno = ClsCommon.ConvertStringint(ss[1]);
                busNo = Convert.ToString(ss[2]);
                GetAlertAccordingToBusNo(ClsCommon.ConvertStringint(busNo), Convert.ToDateTime(fldDDLJDate), Tourno);
            }
            else
                availaseat = ClsCommon.ConvertStringint(ss[0]);
            maxSeatAllowed.Value = Convert.ToString(totpax);


            if (availaseat >= totpax)
            {
                btnContinuee.Visible = true;
                colorindication.Visible = true;
                btncheckavail.Visible = false;
                btnRe.Visible = true;
                btnReset.Visible = false;


                Chart = new StringBuilder();
                Chart.Append(DataLib.seatarr(Convert.ToString(BusSeaterType), serialno,
                    Convert.ToInt32(busNo)));
                Chart.Append("<script>Displayfare();</script>");
            }
            else
            {
                //for multiple busseating chart Purpose
                if (Convert.ToString(ViewState["MultiPle"]) == "Y")
                {
                    string ser = "", bt = "", bno = "";
                    avail = ChekAvailabilitymultiple(totpax, Tourno, fldDDLJDate);
                    ss = avail.Split('-');
                    if (ss.Length > 1)
                    {
                        availaseat = ClsCommon.ConvertStringint(ss[0]);
                        ser = Convert.ToString(ss[1]);
                        bt = Convert.ToString(ss[2]);
                        bno = Convert.ToString(ss[3]);
                        if (bno.Contains("2"))
                            GetAlertAccordingToBusNo(2, Convert.ToDateTime(fldDDLJDate), Tourno);
                    }
                    else
                        availaseat = ClsCommon.ConvertStringint(ss[0]);
                    if (availaseat >= totpax)
                    {
                        btnContinuee.Visible = true;

                        colorindication.Visible = true;

                        btnRe.Visible = true;
                        btncheckavail.Visible = false;
                        btnReset.Visible = false;
                        string[] sss = ser.Split('$');
                        string[] btt = bt.Split('@');
                        string[] bbno = bno.Split('*');
                        StringBuilder st = new StringBuilder();
                        DataLib.vacentSeatNumber.Clear();   //Updated By Murli on 11 July 2024
                        DataLib.occupiedSeatNumber.Clear(); //Updated By Murli on 11 July 2024
                        DataLib.bus_vac_Number.Clear();

                        for (int k = 0; k <= sss.Length - 1; k++)
                        {
                            st.Append(DataLib.seatarr(btt[k], ClsCommon.ConvertStringint(sss[k]),
                                ClsCommon.ConvertStringint(bbno[k])));
                            Chart = new StringBuilder();
                            Chart.Append(st);
                            Chart.Append("<script>Displayfare();</script>");
                        }
                    }
                    else
                    {
                        btnContinuee.Visible = false;
                        colorindication.Visible = false;
                        btnRe.Visible = false;

                        if (!(Request.QueryString["Rowid"] == null))
                        {
                            btnRe.Visible = false;
                            btncheckavail.Visible = true;
                            btnReset.Visible = true;
                            txtNoOfAdults.ReadOnly = false;
                            txtNoOfChilds.ReadOnly = false;
                            txtNoOfAdultsTriple.ReadOnly = false;
                            txtNoOfAdultsTwin.ReadOnly = false;
                            txtNoOfSingles.ReadOnly = false;
                            txtNoOfChildBed.ReadOnly = false;
                            txtNoofdormitory.ReadOnly = false;
                            txtNoAWFNoOfAdults.ReadOnly = false;
                            txtNoCWFNoOfChilds.ReadOnly = false;

                            strEncrypt = DataLib.TripleDESEncode(lblTourName.Text, endecript);
                            if (availaseat == 0)
                                lbMsgErr.Text = "Currently there is No Available seats on " +
                                    "your selected date <br/> You can Send us a special request <a href=\"" +
                                    "SeatRequestForm.aspx?TourName=" + strEncrypt +
                                    "\"> Send Request</a> Click here";
                            else
                            {
                                string multi = Convert.ToString(ViewState["MultiPle"]);
                                int tt = ClsCommon.ConvertStringint(ViewState["tot"]);
                                if (multi == "Y")
                                    lbMsgErr.Text = "Currently there are " + tt +
                                        " available seats on Multiple Buses for this date " +
                                        "<br/> You can Send us a special request <a href=\"SeatRequestForm.aspx?TourName=" +
                                        strEncrypt + "\"> Send Request</a> Click here";
                                else
                                    lbMsgErr.Text = "Currently there is Only " + availaseat +
                                        " available seats on Your Selected date <br/> You " +
                                        "Want to <a href=\"SeatRequestForm.aspx?TourName=" +
                                        strEncrypt + "\"> Send Request</a> Click here";
                            }
                            hlmsgerr.Text = "Click here to change date.";
                            strEncrypt = DataLib.TripleDESEncode(orderid, endecript);
                            //hlmsgerr.NavigateUrl = "bookedtour.aspx?orderid=" + strEncrypt;
                            Session["Panel2Step"] = "Panel2Step";
                            hlmsgerr.NavigateUrl = "Booking-" + Convert.ToString(hdfTourName.Value) + "_" + RemoveSlashAmp(strEncrypt) + "_" +
                                Page.RouteData.Values["tourId"] + "_" + Page.RouteData.Values["jdate"];
                            //hlmsgerr.NavigateUrl = "Fixed-Departure-Booking_Availability-" + Convert.ToString(hdfTourName.Value).Replace(" ", "-") + "_" + RemoveSlashAmp(strEncrypt);

                        }
                        else
                        {
                            btnRe.Visible = false;
                            btncheckavail.Visible = true;
                            btnReset.Visible = true;
                            txtNoOfAdults.ReadOnly = false;
                            txtNoOfChilds.ReadOnly = false;
                            txtNoOfAdultsTriple.ReadOnly = false;
                            txtNoOfAdultsTwin.ReadOnly = false;
                            txtNoOfSingles.ReadOnly = false;
                            txtNoOfChildBed.ReadOnly = false;
                            txtNoofdormitory.ReadOnly = false;
                            txtNoAWFNoOfAdults.ReadOnly = false;
                            txtNoCWFNoOfChilds.ReadOnly = false;
                            strEncrypt = DataLib.TripleDESEncode(lblTourName.Text, endecript);
                            if (availaseat == 0)
                                lbMsgErr.Text = "Currently there is No Available seats on " +
                                    "your selected date <br/> You can Send us a special request<a href=\"" +
                                    "SeatRequestForm.aspx?TourName=" + strEncrypt +
                                    "\"> Send Request</a> ";
                            else
                            {
                                int tt = ClsCommon.ConvertStringint(ViewState["tot"]);
                                if (Convert.ToString(ViewState["MultiPle"]).ToUpper() == "Y")
                                    lbMsgErr.Text = "Currently there are " + tt +
                                        " available seats on multiple buses for the selected date. " +
                                        "<br/> You can Send us a special request <a href=\"SeatRequestForm.aspx?TourName=" +
                                        strEncrypt + "\"> Send Request</a> ";
                                else
                                    lbMsgErr.Text = "Currently there are only " + availaseat +
                                        " seats available for the selected date. <br/> You can Send us a special request " +
                                        "<a href=\"SeatRequestForm.aspx?TourName=" + strEncrypt +
                                        "\"> Send Request</a> ";
                            }
                            hlmsgerr.Text = "or Book another Tour.";
                            hlmsgerr.NavigateUrl = "index.aspx";
                        }
                    }
                }
                else
                {
                    btnRe.Visible = false;
                    btncheckavail.Visible = true;
                    btnReset.Visible = true;
                    txtNoOfAdults.ReadOnly = false;
                    txtNoOfChilds.ReadOnly = false;
                    txtNoOfAdultsTriple.ReadOnly = false;
                    txtNoOfAdultsTwin.ReadOnly = false;
                    txtNoOfSingles.ReadOnly = false;
                    txtNoOfChildBed.ReadOnly = false;
                    txtNoofdormitory.ReadOnly = false;
                    txtNoAWFNoOfAdults.ReadOnly = false;
                    txtNoCWFNoOfChilds.ReadOnly = false;
                    strEncrypt = DataLib.TripleDESEncode(lblTourName.Text, endecript);
                    if (availaseat == 0)
                        lbMsgErr.Text = "Currently there is no available seats on your selected " +
                            "date <br/> <a href=\"SeatRequestForm.aspx?TourName=" +
                            strEncrypt + "\"> You can Send us a special request</a> or";

                    else if (availaseat == 1)
                        lbMsgErr.Text = "Currently there are only " + availaseat + " seat available for the selected date." +
                            "<br/> <a href=\"SeatRequestForm.aspx?TourName=" +
                            strEncrypt + "\"> You can Send us a special request</a> or ";
                    else
                        lbMsgErr.Text = "Currently there is only " + availaseat + " seats available for the selected date" +
                            "<br/> <a href=\"SeatRequestForm.aspx?TourName=" +
                            strEncrypt + "\"> You can Send us a special request</a> ";

                    hlmsgerr.Text = "or Book another Tour.";
                    hlmsgerr.NavigateUrl = "index.aspx";
                }
                //================END================== 
            }
            btncheckavail.Enabled = true;
            btnContinuee.Attributes.Add("onclick", "return checkseats();");
            //Session["Panel2Step"] = null;
            #region Updated By Murli on 11 July 2024
            if (Convert.ToBoolean(ViewState["FlagIntlEBKTourIDs"]))
            {
                string Num = "10";
                if (Num == "10")
                {
                    int numberofPerson = Convert.ToInt32(maxSeatAllowed.Value);
                    List<int> vacentSeatNumber = DataLib.vacentSeatNumber;
                    List<int> occupiedSeatNumber = DataLib.occupiedSeatNumber;


                    string directOccupiedSeats = "";


                    //if (vacentSeatNumber.Count >= numberofPerson && _busNo != "")
                    if (vacentSeatNumber.Count >= numberofPerson && busNo != "")
                    {
                        for (int i = 0; i < numberofPerson; i++)
                        {
                            if (Convert.ToInt32(vacentSeatNumber[i]) > 0) directOccupiedSeats += "," + busNo + (Convert.ToInt32(vacentSeatNumber[i]) * 1).ToString();
                        }
                        optedSeatNos.Value = directOccupiedSeats;
                        Session["Panel2Step"] = null;
                        btnContinuee_Click(sender, e);
                    }
                    else
                    {
                        btnContinuee.Visible = false; colorindication.Visible = false; btnRe.Visible = false; btncheckavail.Visible = true;
                        string cVacantSeat = vacentSeatNumber.Count > 0 ? vacentSeatNumber.Count.ToString() : availaseat.ToString();
                        LitMesg.Text = "<script>alert('Currently there is only " + cVacantSeat + " seats available for the selected date');</script>";
                    }

                }
            }
            #endregion
        }

        protected void btnContinuee_Click(object sender, EventArgs e)
        {

            string numbers = "", chkbus = "", chkbus1 = "", seat;
            seat = optedSeatNos.Value.Replace(",,", ",").TrimStart(',').TrimEnd(',');
            string[] seatnumbers = seat.Split(',');
            for (int i = 0; i <= seatnumbers.Length - 1; i++)
            {
                if (seatnumbers[i].Length > 2)
                {
                    numbers = "s" + seatnumbers[i].Substring(1, 2);
                    chkbus = seatnumbers[i].Substring(0, 1);
                }
                else
                {
                    numbers = "s" + seatnumbers[i].Substring(1, 1);
                    chkbus = seatnumbers[i].Substring(0, 1);
                }
                tempstr = tempstr + "," + numbers;
                if (chkbus1 == "")
                    chkbus1 = chkbus;
                else
                    chkbus1 = chkbus1 + "," + chkbus;
            }
            tempstr = tempstr.Replace(",,", ",").TrimStart(',').TrimEnd(',');
            chkbus1 = chkbus1.Replace(",,", ",").TrimStart(',').TrimEnd(',');
            ViewState["chkbusno"] = chkbus1;
            int availaseat, serialno = 0;
            string avail = ChekAvailability1(seatnumbers.Length,
                Convert.ToInt32(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString())), fldDDLJDate);
            string[] ss = avail.Split('-');
            if (ss.Length > 1)
            {
                availaseat = ClsCommon.ConvertStringint(ss[0]);
                serialno = ClsCommon.ConvertStringint(ss[1]);
            }
            else
                availaseat = ClsCommon.ConvertStringint(ss[0]);
            if (availaseat < seatnumbers.Length)
            {
                if (Convert.ToString(ViewState["MultiPle"]) == "Y")
                {
                    string ser = "", bt = "", bno = "";
                    avail = ChekAvailabilitymultiple(seatnumbers.Length,
                        Convert.ToInt32(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString())), fldDDLJDate);
                    ss = avail.Split('-');
                    if (ss.Length > 1)
                    {
                        availaseat = ClsCommon.ConvertStringint(ss[0]);
                        ser = Convert.ToString(ss[1]);
                        bt = Convert.ToString(ss[2]);
                        bno = Convert.ToString(ss[3]);
                    }
                    else
                        availaseat = ClsCommon.ConvertStringint(ss[0]);
                    if (availaseat < seatnumbers.Length)
                    {
                        btnContinuee.Visible = false;
                        colorindication.Visible = false;
                        btnRe.Visible = false;
                        if (!(Request.QueryString["Rowid"] == null))
                        {
                            strEncrypt = DataLib.TripleDESEncode(lblTourName.Text, endecript);
                            if (availaseat == 0)
                                lbMsgErr.Text = "Currently there is No Available seats on your " +
                                    "selected date <br/> You Want to <a href=\"SeatRequestForm.aspx?" +
                                    "TourName=" + strEncrypt + "\"> Send Request</a> Click here";
                            else
                            {
                                string multi = Convert.ToString(ViewState["MultiPle"]);
                                int tt = ClsCommon.ConvertStringint(ViewState["tot"]);
                                if (multi == "Y")
                                    lbMsgErr.Text = "Currently there are " + tt + " available seats on" +
                                        " Multiple Buses for this date <br/> You Want to <a href=" +
                                        "\"SeatRequestForm.aspx?TourName=" + strEncrypt +
                                        "\"> Send Request</a> Click here";
                                else
                                    lbMsgErr.Text = "Currently there is Only " + availaseat +
                                        " available seats on Your Selected date <br/> You " +
                                        "Want to <a href=\"SeatRequestForm.aspx?TourName=" +
                                        strEncrypt + "\"> Send Request</a> Click here";
                            }
                            hlmsgerr.Text = "Click here to change date.";
                            strEncrypt = DataLib.TripleDESEncode(orderid, endecript);
                            Session["Panel2Step"] = "Panel2Step";
                            hlmsgerr.NavigateUrl = "Booking-" + Convert.ToString(hdfTourName.Value) + "_" + RemoveSlashAmp(strEncrypt) + "_" +
                                Page.RouteData.Values["tourId"] + "_" + RemoveSlashAmp(Request.QueryString["jdate"]); ;
                        }
                        else
                        {
                            strEncrypt = DataLib.TripleDESEncode(lblTourName.Text, endecript);
                            if (availaseat == 0)
                                lbMsgErr.Text = "Currently there is No Available seats on your " +
                                    "selected date <br/> You Want to <a href=\"SeatRequestForm.aspx?" +
                                    "TourName=" + strEncrypt + "\"> Send Request</a> Click here";
                            else
                            {
                                string multi = Convert.ToString(ViewState["MultiPle"]);
                                int tt = ClsCommon.ConvertStringint(ViewState["tot"]);
                                if (multi == "Y")
                                    lbMsgErr.Text = "Currently there are " + tt + " available seats " +
                                        "on Multiple Buses for this date <br/> You Want to <a href=" +
                                        "\"SeatRequestForm.aspx?TourName=" + strEncrypt +
                                        "\"> Send Request</a> Click here";
                                else
                                    lbMsgErr.Text = "Currently there is Only " + availaseat +
                                        " available seats on Your Selected date <br/> You Want to " +
                                        "<a href=\"SeatRequestForm.aspx?TourName=" + strEncrypt +
                                        "\"> Send Request</a> Click here";
                            }
                            hlmsgerr.Text = "Book another Tour.";
                            hlmsgerr.NavigateUrl = "index.aspx";
                        }
                    }
                    else
                    {
                        seat = optedSeatNos.Value.Replace(",,", ",").TrimStart(',').TrimEnd(',');
                        seatnumbers = seat.Split(',');
                        string[] serial = ser.Split('$');
                        string ttstr = "", sno = "";
                        for (int jj = 0; jj <= serial.Length - 1; jj++)
                        {
                            ttstr = "";
                            Array.Sort(seatnumbers);
                            for (int i = 0; i <= seatnumbers.Length - 1; i++)
                            {
                                if (ClsCommon.ConvertStringint(seatnumbers[i].Substring(0, 1)) == jj + 1)
                                {
                                    if (seatnumbers[i].Length > 2)
                                        numbers = "s" + seatnumbers[i].Substring(1, 2);
                                    else
                                        numbers = "s" + seatnumbers[i].Substring(1, 1);
                                    ttstr = ttstr + "," + numbers;
                                }
                            }
                            if (sno == "")
                                sno = serial[jj];
                            else
                                sno = sno + "," + serial[jj];
                            ttstr = ttstr.Replace(",,", ",").TrimStart(',').TrimEnd(',');
                            string seatcheck = doBlock(ttstr, ClsCommon.ConvertStringint(serial[jj]));
                            if (seatcheck == "No")
                            {
                                optedSeatNos.Value = "";
                                ClientScript.RegisterStartupScript(GetType(), "check1",
                                    "<script>alert('Sorry, These Seats were Booked, Please " +
                                    "Choose Another Seats');</script>");
                                return;
                            }
                        }
                        tempstr = "";
                        for (int i = 0; i <= seatnumbers.Length - 1; i++)
                        {
                            numbers = "s" + seatnumbers[i];
                            tempstr = tempstr + "," + numbers;
                        }
                        tempstr = tempstr.Replace(",,", ",").TrimStart(',').TrimEnd(',');
                        AssignValue();
                        AssignOrderID();
                        if (!(Request.QueryString["Rowid"] == null))
                            updatebook(Convert.ToInt32(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString())),
                                seatnumbers.Length, fldDDLJDate, OrderIDH.Value, ClsCommon.ConvertStringint(DataLib.funClear(
                                Request.QueryString["Rowid"])), sno);
                        else
                            insertbook(Convert.ToInt32(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString())),
                                seatnumbers.Length, fldDDLJDate, OrderIDH.Value, sno);
                    }
                }
                else
                {
                    btnContinuee.Visible = false;
                    colorindication.Visible = false;
                    btnRe.Visible = false;
                    strEncrypt = DataLib.TripleDESEncode(lblTourName.Text, endecript);
                    if (availaseat == 0)
                        lbMsgErr.Text = "Currently there is no available seat for the selected date" +
                            " <br/> You want to <a href=\"SeatRequestForm.aspx?TourName=" + strEncrypt +
                            "\"> Send Request</a> Click here or ";
                    else if (availaseat == 1)
                        lbMsgErr.Text = "Currently there are only " + availaseat + " seat available for the selected date." +
                            "<br/> <a href=\"SeatRequestForm.aspx?TourName=" +
                            strEncrypt + "\"> You can Send us a special request</a> or ";
                    else
                        lbMsgErr.Text = "Currently there is only " + availaseat + " seats available for the selected date" +
                            "<br/> You want to <a href=\"SeatRequestForm.aspx?TourName=" +
                            strEncrypt + "\"> You can Send us a special request</a> or ";
                    if (!(Request.QueryString["Rowid"] == null))
                    {
                        hlmsgerr.Text = "Click here to change date.";
                        strEncrypt = DataLib.TripleDESEncode(orderid, endecript);
                        Session["Panel2Step"] = "Panel2Step";
                        hlmsgerr.NavigateUrl = "Booking-" + Convert.ToString(hdfTourName.Value) + "_" + RemoveSlashAmp(strEncrypt) + "_" +
                                Page.RouteData.Values["tourId"] + "_" + RemoveSlashAmp(Request.QueryString["jdate"]); ;

                    }
                    else
                    {
                        hlmsgerr.Text = "Book another Tour.";
                        hlmsgerr.NavigateUrl = "index.aspx";
                    }
                }
            }
            else
            {
                AssignValue();
                AssignOrderID();
                string seatcheck = doBlock(tempstr, serialno);
                if (seatcheck == "No")
                {
                    optedSeatNos.Value = "";
                    ClientScript.RegisterStartupScript(GetType(), "check2", "<script>alert('Sorry, " +
                        "These Seats were Booked, Please Choose Another Seats');</script>");
                    return;
                }


                if (!(Request.QueryString["Rowid"] == null))
                {
                    updatebook(ClsCommon.ConvertStringint(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString())),
                        seatnumbers.Length, fldDDLJDate, OrderIDH.Value,
                        ClsCommon.ConvertStringint(DataLib.funClear(Request.QueryString["Rowid"])),
                        Convert.ToString(serialno));
                    Session["Panel2Step"] = "Panel2Step";
                }
                else
                {
                    insertbook(ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]), seatnumbers.Length,
                        fldDDLJDate, OrderIDH.Value,
                        Convert.ToString(serialno));
                    Session["Panel2Step"] = "Panel2Step";
                }
            }


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtNoOfAdults.Text = "0";
            txtNoOfChilds.Text = "0";
            txtNoOfAdultsTriple.Text = "0";
            txtNoOfAdultsTwin.Text = "0";
            txtNoOfSingles.Text = "0";
            txtNoOfChildBed.Text = "0";
            txtNoOfAdults.Text = "0";
            txtNoofdormitory.Text = "0";
            txtNoAWFNoOfAdults.Text = "0";
            txtNoCWFNoOfChilds.Text = "0";
            btnContinuee.Visible = false;
            btnRe.Visible = false;
            btnReset.Visible = true;
            btncheckavail.Visible = true;
            txtNoOfAdults.ReadOnly = false;
            txtNoOfChilds.ReadOnly = false;
            txtNoOfAdultsTriple.ReadOnly = false;
            txtNoOfAdultsTwin.ReadOnly = false;
            txtNoOfSingles.ReadOnly = false;
            txtNoOfChildBed.ReadOnly = false;
            txtNoofdormitory.ReadOnly = false;
            optedSeatNos.Value = "";
            txtNoAWFNoOfAdults.ReadOnly = false;
            txtNoCWFNoOfChilds.ReadOnly = false;
            Session["Panel2Step"] = null;
            Session["BookMore"] = null;
            lbMsgErr.Text = "";
            lblLTCMsg.Text = "";
            LblMsg.Text = "";
            cmbrow.Visible = false;
            hlmsgerr.Visible = false;

        }


        protected void dgtourdt_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item)))
            {
                if ((e.Item.Cells[6].Text.ToString() == "Y") || (e.Item.Cells[6].Text.ToString() == "AC"))
                    e.Item.Cells[6].Text = "AC";
                else
                    e.Item.Cells[6].Text = "Non-AC";
                e.Item.Cells[1].CssClass = "col4";
                e.Item.Cells[2].CssClass = "col5";
                e.Item.Cells[3].CssClass = "col6";
                e.Item.Cells[5].CssClass = "col5";
                e.Item.Cells[6].CssClass = "col5";
                e.Item.Cells[7].CssClass = "col5";
                e.Item.Cells[8].CssClass = "col6";
                e.Item.Cells[9].CssClass = "col5";
            }
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[1].CssClass = "col4";
                e.Item.Cells[2].CssClass = "col5";
                e.Item.Cells[3].CssClass = "col6";
                e.Item.Cells[5].CssClass = "col5";
                e.Item.Cells[6].CssClass = "col5";
                e.Item.Cells[7].CssClass = "col5";
                e.Item.Cells[8].CssClass = "col6";
                e.Item.Cells[9].CssClass = "col5";
            }
        }
        protected void dgtourdt_ItemCreated(object sender, DataGridItemEventArgs e)
        {

        }
        protected void dgtourdt_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {
                clsAdo pClsObj = null;
                try
                {
                    pClsObj = new clsAdo();

                    string pRowID = dgtourdt.DataKeys[e.Item.ItemIndex].ToString();

                    string pTourId = Convert.ToString(pClsObj.fnGet_RowWiseTourID(ClsCommon.ConvertStringint(pRowID)));

                    Session["Panel2Step"] = null;


                    FillDgtour();

                    if (dgtourdt.Rows.Count > 1)
                    {
                        Response.Redirect("TourBooking.aspx?orderid=" + ViewState["strDeCrypt"].ToString() + "&TourId=" + pTourId +
                            "&A=" + ViewState["TotalPaxAdults"] + "&C=" + ViewState["TotalPaxChilds"] + "&IsEdit=Y&Rowid=" + pRowID);
                    }
                    else
                    {
                        Response.Redirect("TourBooking.aspx?orderid=" + ViewState["strDeCrypt"].ToString() + "&TourId=" + pTourId + "&IsEdit=Y&Rowid=" + pRowID);
                    }
                }
                finally
                {
                    if (pClsObj != null)
                    {
                        pClsObj = null;
                    }
                }
            }
            if (e.CommandName == "Delete")
            {
                clsAdo pClsObj = null;
                try
                {

                    pClsObj = new clsAdo();
                    string pRowId = dgtourdt.DataKeys[e.Item.ItemIndex].ToString();
                    int Val = pClsObj.fnDeleteOnlineToursBooking(pRowId);
                    FillDgtour();
                }
                catch (Exception ex)
                {
                    ClsCommon.LogAndSendError(ex.ToString() + " Tour Booking Page - dgtourdt_ItemCommand FillDgtour");
                    Response.Write(ex.ToString());
                }
                finally
                {
                    if (pClsObj != null)
                    {
                        pClsObj = null;
                    }
                }
            }
        }

        protected void dgtourdt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                clsAdo pClsObj = null;
                try
                {
                    pClsObj = new clsAdo();
                    int rowIndex = ClsCommon.ConvertStringint(e.CommandArgument);
                    string pRowID = dgtourdt.DataKeys[rowIndex].Values[0].ToString();

                    string pTourId = Convert.ToString(pClsObj.fnGet_RowWiseTourID(ClsCommon.ConvertStringint(pRowID)));

                    Session["Panel2Step"] = null;


                    FillDgtour();

                    if (dgtourdt.Rows.Count > 1)
                    {
                        Response.Redirect("TourBooking.aspx?orderid=" + ViewState["strDeCrypt"].ToString() + "&TourId=" + pTourId +
                            "&A=" + ViewState["TotalPaxAdults"] + "&C=" + ViewState["TotalPaxChilds"] + "&IsEdit=Y&Rowid=" + pRowID);
                    }
                    else
                    {
                        Response.Redirect("TourBooking.aspx?orderid=" + ViewState["strDeCrypt"].ToString() + "&TourId=" + pTourId + "&IsEdit=Y&Rowid=" + pRowID);
                    }
                }
                finally
                {
                    if (pClsObj != null)
                    {
                        pClsObj = null;
                    }
                }
            }
            if (e.CommandName == "Delete")
            {
                clsAdo pClsObj = null;
                try
                {
                    int rowIndex = ClsCommon.ConvertStringint(e.CommandArgument);
                    pClsObj = new clsAdo();

                    string pRowId = dgtourdt.DataKeys[rowIndex].Values[0].ToString();

                    int Val = pClsObj.fnDeleteOnlineToursBooking(pRowId);
                    FillDgtour();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                finally
                {
                    if (pClsObj != null)
                    {
                        pClsObj = null;
                    }
                }
            }
        }
        protected void dgtourdt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ImageButton lnk = (ImageButton)e.Row.FindControl("ImageButton1");
                lnk.Attributes.Add("OnClick", "return confirm('Are you sure to delete this Tour?');");

                Label lbldeparttime = (Label)e.Row.FindControl("lbldeparttime");
                string[] lDepartTime = lbldeparttime.Text.Trim().Split(':');
                if (lDepartTime[0] != string.Empty)
                    lbldeparttime.Text = lDepartTime[0] + ":" + lDepartTime[1] + " " + lDepartTime[2].ToString().Split(' ')[1];
            }

        }
        protected void dgtourdt_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }
        protected void dgtourdt_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void CheckSubmit_Click(object sender, EventArgs e)
        {

            if (Session["Panel2Step"] == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "check2", "<script>alert('Sorry for the inconvenience, " +
                            "Your session got expired, Please repeat the steps to book ticket(s).');window.location.href='index.aspx';</script>");
                return;
            }
            clsAdo pClsObj = null;
            DataTable dtOnlineCust = null;
            try
            {
                pClsObj = new clsAdo();

                string str1;
                ViewState["rowid"] = "";
                string emailidt = emailid.Text.Trim().Replace("'", "").Replace("<", "").Replace(">", "").Replace("alert", "");
                if (emailid.Text.Trim() != "")
                {
                    #region Optimize Code

                    #endregion

                    dtOnlineCust = pClsObj.fnGetCustomerDetail(emailidt);
                    orderid = ViewState["strDeCrypt"].ToString();
                    if (dtOnlineCust != null && dtOnlineCust.Rows.Count > 0)
                    {
                        orderid = ViewState["strDeCrypt"].ToString();
                        ViewState["rowid"] = ClsCommon.ConvertStringint(dtOnlineCust.Rows[0]["RowId"]);
                        existingcustomer(ClsCommon.ConvertStringint(dtOnlineCust.Rows[0]["RowId"]), ViewState["strDeCrypt"].ToString());
                        GrandTotal = decimal.Round(Convert.ToDecimal(ViewState["GrandTotal"]));
                        Session["Amt"] = decimal.Round(Convert.ToDecimal(ViewState["PayNow"]));
                    }
                    else
                    {
                        txtName.Attributes.Remove("readonly");
                        txtName.Text = "";
                        txtAddress.Text = "";
                        ddlState.SelectedValue = "0";
                        if (type.Value == "email")
                        {
                            txtMobile.Text = "";
                            txtMail.Text = emailid.Text;
                        }
                        else if (type.Value == "Mobile")
                        {
                            txtMobile.Text = emailid.Text;
                            txtMail.Text = "";
                        }
                        txtPhone.Text = "";
                        txtPhoneCountryCode.Text = "";
                        orderid = ViewState["strDeCrypt"].ToString();
                        GrandTotal = decimal.Round(Convert.ToDecimal(ViewState["GrandTotal"]));
                        Session["Amt"] = decimal.Round(Convert.ToDecimal(ViewState["PayNow"]));
                        if (Session["custrowid"] != null)
                        {
                            BindProFile();
                        }
                        chkPromotions.Checked = true;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('Please Enter the Email Id / Mobile No');</script>");
                }
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (dtOnlineCust != null)
                {
                    dtOnlineCust.Dispose();
                    dtOnlineCust = null;
                }
            }
        }

        protected void btngo_Click1(object sender, EventArgs e)
        {
            if (Session["Panel2Step"] == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "check2", "<script>alert('Sorry for the inconvenience, " +
                            "Your session got expired, Please repeat the steps to book ticket(s).');</script>");
                return;
            }

            if (!(ddlTour.SelectedIndex == 0))
            {
                Session["blockStatus"] = null;
                Session["blockStr"] = null;
                Session["Panel2Step"] = null;
                Session["BookMore"] = "BookMore";
                Response.Redirect("TourBooking.aspx?orderid=" + ViewState["strDeCrypt"].ToString() + "&TourId=" + ddlTour.SelectedValue + "&A=" + ViewState["TotalPaxAdults"] + "&C=" + ViewState["TotalPaxChilds"] + "&TourName=" + ddlTour.SelectedItem.ToString() + "&IsBookMore=BookMore");

            }
            else
            {
                Session["BookMore"] = "BookMore";
                Session["Panel2Step"] = null;
                Response.Redirect("TourBooking.aspx?orderid=" + ViewState["strDeCrypt"].ToString() + "&A=" + ViewState["TotalPaxAdults"] + "&C=" + ViewState["TotalPaxChilds"] + "");
            }
        }
        protected void btndelete_Click(object sender, EventArgs e)
        {
            deleteTours();
            FillDgtour();
        }
        protected void ddlTour_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btnOK_ServerClick(object sender, EventArgs e)//--- for submit and pay now button click----//
        {
            if (ConfigurationManager.AppSettings["LocalEnv"] == "1")
            {
                Session["blockStatus_EndUser"] = null;
                Session["blockStr_EndUser"] = null;

                Response.Redirect("Tickets.aspx?orderid=" + Convert.ToString(ViewState["strDeCrypt"]));
                return;
            }

            if (Session["Panel2Step"] == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "check2", "<script>alert('Sorry for the inconvenience, " +
                            "Your session got expired, Please repeat the steps to book ticket(s).');window.location.href='index.aspx';</script>");
                return;
            }
            Session["Fixed"] = "FixedTours";
            clsAdo pClsObj = null;
            DataTable dtTour = null;
            try
            {
                pClsObj = new clsAdo();


                if (chkTrue.Checked == true)
                {
                    Boolean tt = false;
                    Boolean lIsPromoCode = false;
                    double? lPromoDiscount = 0;
                    tt = insertCustomerDetails();

                    if (!string.IsNullOrEmpty(Convert.ToString(Session["orderid"])))
                    {
                        if (!CheckSeatBlockOrReleased(Convert.ToString(Session["orderid"])))
                        {
                            ClientScript.RegisterStartupScript(GetType(), "check2", "<script>alert('Sorry for the inconvenience, " +
                                            "Your booking time has been passed So Your Seat has been released, Please repeat the steps to book ticket(s).');window.location.href='index.aspx';</script>");

                            return;
                        }
                    }

                    lIsPromoCode = promocheck();
                    if (!lIsPromoCode)
                    {
                        FillDgtour();
                        ClientScript.RegisterStartupScript(GetType(), "Invalidpromo", "<script>alert('Invalid PromoCode Entered, Please Check');</script>");
                        return;
                    }
                    if ((tt == true) && (lIsPromoCode == true))
                    {
                        Session["blockStatus_EndUser"] = null;
                        Session["blockStr_EndUser"] = null;

                        Session["promo"] = promocode.Text.Trim();
                        if (Convert.ToString(promocode.Text) != "")
                        {
                            int? lStatus = 0;
                            pClsObj.SaveTransactionByPromoCode(Convert.ToString(Session["orderid"]),
                                Convert.ToString(promocode.Text), true, ref lPromoDiscount, ref lStatus);
                            if (ClsCommon.ConvertStringint(lStatus) == 0)
                            {
                                lPromoDiscount = 0;
                            }
                            Session["PromoDisValue"] = lPromoDiscount;
                        }
                        #region Atom Payment
                        if (rbtnAtom.Checked == true)
                        {
                            dtTour = null;
                            dtTour = new DataTable();
                            dtTour = pClsObj.fnGetSumOfTourAmt(Convert.ToString(Session["orderid"]));
                            decimal strtotalAmount = 0.0m;
                            string strAmt = ""; decimal ccvalue = 0.0M;
                            if (dtTour != null && dtTour.Rows.Count > 0)
                            {
                                strAmt = Convert.ToString(dtTour.Rows[0]["TotalPaidAmount"]);
                                ccvalue = Convert.ToDecimal(dtTour.Rows[0]["CalcCreditCardFee"]);
                                strtotalAmount = Convert.ToDecimal(dtTour.Rows[0]["TotalAmount"]);
                                if (Convert.ToDecimal(strAmt) < 0)
                                    strAmt = "0";
                            }
                            string lEMIMonth = "FullPayment";
                            string lBankName = "Atom Bank";
                            if (Convert.ToDecimal(strAmt) >= 2500
                                && (rdoAtom3.Checked || rdoAtom6.Checked || rdoAtom9.Checked || rdoAtom12.Checked || rdoAtom18.Checked || rdoAtom24.Checked))
                            {
                                if (rdoAtom3.Checked)
                                {
                                    lEMIMonth = "3 Month";
                                }
                                else if (rdoAtom6.Checked)
                                {
                                    lEMIMonth = "6 Month";
                                }
                                else if (rdoAtom9.Checked)
                                {
                                    lEMIMonth = "9 Month";
                                }
                                else if (rdoAtom12.Checked)
                                {
                                    lEMIMonth = "12 Month";
                                }
                                else if (rdoAtom18.Checked)
                                {
                                    lEMIMonth = "18 Month";
                                }
                                else if (rdoAtom24.Checked)
                                {
                                    lEMIMonth = "24 Month";
                                }
                                if (ddlAtomEMIBank.SelectedValue != "0")
                                {
                                    lBankName = ddlAtomEMIBank.SelectedValue;
                                }
                            }
                            string REMOTE_ADDR = Request.ServerVariables["REMOTE_ADDR"].ToString();

                            int val = pClsObj.fninsert_tbl_PaymentDetails(Convert.ToString(Session["orderid"]), "ST", Convert.ToDecimal(strAmt), lBankName, 'N',
                                "", "", "INR", "Atom Payment", decimal.Round(Convert.ToDecimal(ccvalue)), false, REMOTE_ADDR, strtotalAmount, lEMIMonth, "FixedTours");
                            if (val == 0)
                            {
                                string ts = txtName.Text;// Convert.ToString(Session["TravelSector"]);
                                if (ts.Length > 0)
                                    ts = ts.Replace("&", "");
                                string ba = Convert.ToString(Session["billingAddress"]);
                                if (ba.Length > 0)
                                    ba = ba.Replace("&", "");
                                if (ba.Length > 250)
                                    ba = ba.Substring(0, 249);
                                string mb = Convert.ToString(Session["mobile"]);
                                //for Promo code amount deduction
                                if (Convert.ToString(promocode.Text) != "")
                                {
                                    Session["Amt"] = strAmt;//Convert.ToString(ClsCommon.ConvertStringint(Session["Amt"]) - ClsCommon.ConvertStringint(lPromoDiscount));
                                }

                                string TranAmount = Convert.ToString(decimal.Round(Convert.ToDecimal(strAmt)));

                                string url = "";
                                clsAdo clsObj = null;
                                int? lStatus = 0;
                                try
                                {

                                    clsObj = new clsAdo();
                                    string lTempTranID = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
                                     System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                                    lStatus = clsObj.fnInsertPaymentHDFCPG("", Convert.ToString(Session["orderid"].ToString()), Session["EmailId"].ToString(), lBankName, Convert.ToDecimal(TranAmount),
                                        "", lTempTranID, "", "", "", "", ts, Session["EmailId"].ToString(), mb, ba, Session["orderid"].ToString(), lEMIMonth, "FixedTours");
                                }
                                finally
                                {
                                    if (clsObj != null)
                                    {
                                        clsObj = null;
                                    }

                                }
                                if (lStatus > 0)
                                {
                                    url = "AtomPayment.aspx?RID=" + lStatus.ToString() + "&lEMIMonth=" + lEMIMonth + "&lEMIBank=" + lBankName
                                        + "&SectionName=FixedTours" + "&FirstName=" + txtName.Text.Trim();


                                }
                                else
                                {
                                    Response.Write("Error Occured");
                                    Response.End();
                                }
                                Session["Panel2Step"] = null;
                                Response.Redirect(url, false);
                            }
                        }
                        #endregion

                        #region PayU Payment
                        if (rbtnPayu.Checked == true)
                        {
                            dtTour = null;
                            dtTour = new DataTable();
                            dtTour = pClsObj.fnGetSumOfTourAmt(Convert.ToString(Session["orderid"]));
                            decimal strtotalAmount = 0.0m;
                            string strAmt = ""; decimal ccvalue = 0.0M;
                            if (dtTour != null && dtTour.Rows.Count > 0)
                            {
                                strAmt = Convert.ToString(dtTour.Rows[0]["TotalPaidAmount"]);
                                ccvalue = Convert.ToDecimal(dtTour.Rows[0]["CalcCreditCardFee"]);
                                strtotalAmount = Convert.ToDecimal(dtTour.Rows[0]["TotalAmount"]);
                                if (Convert.ToDecimal(strAmt) < 0)
                                    strAmt = "0";
                            }

                            string REMOTE_ADDR = Request.ServerVariables["REMOTE_ADDR"].ToString();

                            int val = pClsObj.fninsert_tbl_PaymentDetails(Convert.ToString(Session["orderid"]), "ST", Convert.ToDecimal(strAmt), "", 'N',
                                "", "", "INR", "PayU Payment", decimal.Round(Convert.ToDecimal(ccvalue)), false, REMOTE_ADDR, strtotalAmount, "", "FixedTours");
                            if (val == 0)
                            {
                                string ts = Convert.ToString(Session["TravelSector"]);
                                if (ts.Length > 0)
                                    ts = ts.Replace("&", "");
                                string ba = Convert.ToString(Session["billingAddress"]);
                                if (ba.Length > 0)
                                    ba = ba.Replace("&", "");
                                if (ba.Length > 250)
                                    ba = ba.Substring(0, 249);
                                string mb = Convert.ToString(Session["mobile"]);
                                //for Promo code amount deduction
                                if (Convert.ToString(promocode.Text) != "")
                                {
                                    Session["Amt"] = strAmt;//Convert.ToString(ClsCommon.ConvertStringint(Session["Amt"]) - ClsCommon.ConvertStringint(lPromoDiscount));
                                }

                                string TranAmount = Convert.ToString(decimal.Round(Convert.ToDecimal(strAmt)));

                                string url = "";
                                clsAdo clsObj = null;
                                int? lStatus = 0;
                                try
                                {
                                    clsObj = new clsAdo();
                                    string lTempTranID = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
                                    System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                                    lStatus = clsObj.fnInsertPaymentHDFCPG("", Convert.ToString(Session["orderid"].ToString()), Session["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                                        "", lTempTranID, "", "", "", "", ts, Session["EmailId"].ToString(), mb, ba, Session["orderid"].ToString(), "", "FixedTours");
                                }
                                finally
                                {
                                    if (clsObj != null)
                                    {
                                        clsObj = null;
                                    }

                                }
                                if (lStatus > 0)
                                {
                                    url = "PayUPaymet.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedTours" + "&FirstName=" + txtName.Text.Trim();
                                }
                                else
                                {
                                    Response.Write("Error Occured");
                                    Response.End();
                                }
                                Session["Panel2Step"] = null;
                                Response.Redirect(url, false);
                            }
                        }
                        #endregion

                        #region Net Banking
                        if (rdoNetBanking.Checked == true)
                        {
                            dtTour = null;
                            dtTour = new DataTable();
                            dtTour = pClsObj.fnGetSumOfTourAmt(Convert.ToString(Session["orderid"]));
                            decimal strtotalAmount = 0.0m;
                            string strAmt = ""; decimal ccvalue = 0.0M;
                            if (dtTour != null && dtTour.Rows.Count > 0)
                            {
                                strAmt = Convert.ToString(dtTour.Rows[0]["TotalPaidAmount"]);
                                ccvalue = Convert.ToDecimal(dtTour.Rows[0]["CalcCreditCardFee"]);
                                strtotalAmount = Convert.ToDecimal(dtTour.Rows[0]["TotalAmount"]);
                                if (Convert.ToDecimal(strAmt) < 0)
                                    strAmt = "0";
                            }

                            string REMOTE_ADDR = Request.ServerVariables["REMOTE_ADDR"].ToString();

                            int val = pClsObj.fninsert_tbl_PaymentDetails(Convert.ToString(Session["orderid"]), "ST", Convert.ToDecimal(strAmt), "", 'N',
                                "", "", "INR", "Tech Process", decimal.Round(Convert.ToDecimal(ccvalue)), false, REMOTE_ADDR, strtotalAmount, "", "FixedTours");
                            if (val == 0)
                            {
                                string ts = Convert.ToString(Session["TravelSector"]);
                                if (ts.Length > 0)
                                    ts = ts.Replace("&", "");
                                string ba = Convert.ToString(Session["billingAddress"]);
                                if (ba.Length > 0)
                                    ba = ba.Replace("&", "");
                                if (ba.Length > 250)
                                    ba = ba.Substring(0, 249);
                                string mb = Convert.ToString(Session["mobile"]);
                                //for Promo code amount deduction
                                if (Convert.ToString(promocode.Text) != "")
                                {
                                    Session["Amt"] = strAmt;//Convert.ToString(ClsCommon.ConvertStringint(Session["Amt"]) - ClsCommon.ConvertStringint(lPromoDiscount));
                                }

                                string TranAmount = Convert.ToString(decimal.Round(Convert.ToDecimal(strAmt)));

                                string url = "";
                                clsAdo clsObj = null;
                                int? lStatus = 0;
                                try
                                {
                                    clsObj = new clsAdo();
                                    string lTempTranID = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
    System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

                                    lStatus = clsObj.fnInsertPaymentHDFCPG("", Convert.ToString(Session["orderid"].ToString()), Session["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                                        "", lTempTranID, "", "", "", "", ts, Session["EmailId"].ToString(), mb, ba, Session["orderid"].ToString(), "", "FixedTours");
                                }
                                finally
                                {
                                    if (clsObj != null)
                                    {
                                        clsObj = null;
                                    }

                                }
                                if (lStatus > 0)
                                {
                                    url = "TechProcessPayment_Request.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedTours" + "&FirstName=" + txtName.Text.Trim();
                                }
                                else
                                {
                                    Response.Write("Error Occured");
                                    Response.End();
                                }
                                Session["Panel2Step"] = null;
                                Response.Redirect(url, false);
                            }


                        }
                        #endregion

                        #region Credit Card With EMI
                        #region Old CC Payment Code

                        #endregion
                        if (rdoCCMs.Checked || rdoDC.Checked)
                        {


                            dtTour = null;
                            dtTour = new DataTable();
                            dtTour = pClsObj.fnGetSumOfTourAmt(Convert.ToString(Session["orderid"]));
                            decimal strtotalAmount = 0.0m;
                            string strAmt = ""; decimal ccvalue = 0.0M;
                            if (dtTour != null && dtTour.Rows.Count > 0)
                            {
                                strAmt = Convert.ToString(dtTour.Rows[0]["TotalPaidAmount"]);
                                ccvalue = Convert.ToDecimal(dtTour.Rows[0]["CalcCreditCardFee"]);
                                strtotalAmount = Convert.ToDecimal(dtTour.Rows[0]["TotalAmount"]);

                                if (Convert.ToDecimal(strAmt) < 0)
                                    strAmt = "0";
                            }

                            string lEMIMonth = "FullPayment";
                            if ((Convert.ToDecimal(strAmt) > 100)
                                && (rbtnEMI3Month.Checked || rbtnEMI6Month.Checked || rdoCC.Checked))
                            {
                                if (rbtnEMI3Month.Checked)
                                {
                                    lEMIMonth = "3 Month";

                                }
                                if (rbtnEMI6Month.Checked)
                                {
                                    lEMIMonth = "6 Month";

                                }
                                if (rdoCC.Checked)
                                {
                                    lEMIMonth = "FullPayment";

                                }
                            }
                            if (rdoDC.Checked)
                            {
                                lEMIMonth = "FullPayment";

                            }
                            string REMOTE_ADDR = Request.ServerVariables["REMOTE_ADDR"].ToString();

                            int val = pClsObj.fninsert_tbl_PaymentDetails(Convert.ToString(Session["orderid"]), "ST", Convert.ToDecimal(strAmt), "", 'N',
                                "", "", "INR", "CC Payment", decimal.Round(Convert.ToDecimal(ccvalue)), true, REMOTE_ADDR, strtotalAmount, lEMIMonth, "FixedTours");
                            if (val == 0)
                            {
                                string ts = Convert.ToString(Session["TravelSector"]);
                                if (ts.Length > 0)
                                    ts = ts.Replace("&", "");
                                string ba = Convert.ToString(Session["billingAddress"]);
                                if (ba.Length > 0)
                                    ba = ba.Replace("&", "");
                                if (ba.Length > 250)
                                    ba = ba.Substring(0, 249);
                                string mb = Convert.ToString(Session["mobile"]);
                                //for Promo code amount deduction
                                if (Convert.ToString(promocode.Text) != "")
                                {

                                    Session["Amt"] = strAmt;//Convert.ToString(ClsCommon.ConvertStringint(Session["Amt"]) - ClsCommon.ConvertStringint(lPromoDiscount));
                                }

                                string TranAmount = Convert.ToString(decimal.Round(Convert.ToDecimal(strAmt)));

                                string url = "";
                                clsAdo clsObj = null;
                                int? lStatus = 0;
                                try
                                {
                                    clsObj = new clsAdo();

                                    lStatus = clsObj.fnInsertPaymentHDFCPG("", Convert.ToString(Session["orderid"].ToString()), Session["EmailId"].ToString(), "", Convert.ToDecimal(TranAmount),
                                        "", "", "", "", "", "", ts, Session["EmailId"].ToString(), mb, ba, Session["orderid"].ToString(), "", "FixedTours");
                                }
                                finally
                                {
                                    if (clsObj != null)
                                    {
                                        clsObj = null;
                                    }

                                }
                                if (lStatus > 0)
                                {
                                    url = "HDFCCreditCardPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedTours&lEMIMonth=" + lEMIMonth;

                                }
                                else
                                {
                                    Response.Write("Error Occured");
                                    Response.End();
                                }



                                Session["Panel2Step"] = null;
                                Response.Redirect(url, false);

                            }

                        }
                        #endregion

                        #region AMEX Payment
                        if (rdoamex.Checked == true)
                        {
                            dtTour = null;
                            dtTour = new DataTable();
                            dtTour = pClsObj.fnGetSumOfTourAmt(Convert.ToString(Session["orderid"]));
                            decimal strtotalAmount = 0.0m;
                            string strAmt = ""; decimal ccvalue = 0.0M;
                            if (dtTour != null && dtTour.Rows.Count > 0)
                            {
                                strAmt = Convert.ToString(dtTour.Rows[0]["TotalPaidAmount"]);
                                ccvalue = Convert.ToDecimal(dtTour.Rows[0]["CalcCreditCardFee"]);
                                strtotalAmount = Convert.ToDecimal(dtTour.Rows[0]["TotalAmount"]);
                                if (Convert.ToDecimal(strAmt) < 0)
                                    strAmt = "0";
                            }

                            string REMOTE_ADDR = Request.ServerVariables["REMOTE_ADDR"].ToString();

                            int val = pClsObj.fninsert_tbl_PaymentDetails(Convert.ToString(Session["orderid"]), "ST", Convert.ToDecimal(strAmt), "", 'N',
                                "", "", "INR", "AMEX Payment", decimal.Round(Convert.ToDecimal(ccvalue)), false, REMOTE_ADDR, strtotalAmount, "", "FixedTours");
                            if (val == 0)
                            {
                                string ts = Convert.ToString(Session["TravelSector"]);
                                if (ts.Length > 0)
                                    ts = ts.Replace("&", "");
                                string ba = Convert.ToString(Session["billingAddress"]);
                                if (ba.Length > 0)
                                    ba = ba.Replace("&", "");
                                if (ba.Length > 250)
                                    ba = ba.Substring(0, 249);
                                string mb = Convert.ToString(Session["mobile"]);
                                if (Convert.ToString(promocode.Text) != "")
                                {
                                    Session["Amt"] = strAmt;//Convert.ToString(ClsCommon.ConvertStringint(Session["Amt"]) - ClsCommon.ConvertStringint(lPromoDiscount));
                                }

                                string TranAmount = Convert.ToString(decimal.Round(Convert.ToDecimal(strAmt)));

                                string url = "";
                                clsAdo clsObj = null;
                                int? lStatus = 0;
                                try
                                {
                                    clsObj = new clsAdo();
                                    string lTempTranID = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
                                                         System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() +
                                                         System.DateTime.Now.Millisecond.ToString();

                                    lStatus = clsObj.fnInsertPaymentHDFCPG("", Convert.ToString(Session["orderid"].ToString()), Session["EmailId"].ToString(), "",
                                        Convert.ToDecimal(TranAmount), "", lTempTranID, "", "", "", "", ts, Session["EmailId"].ToString(), mb,
                                        ba, Session["orderid"].ToString(), "", "FixedTours");
                                }
                                finally
                                {
                                    if (clsObj != null)
                                    {
                                        clsObj = null;
                                    }

                                }
                                if (lStatus > 0)
                                {
                                    url = "AMEXPayment_Request.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedTours" + "&FirstName=" + txtName.Text.Trim();
                                }
                                else
                                {
                                    Response.Write("Error Occured");
                                    Response.End();
                                }
                                Session["Panel2Step"] = null;
                                Response.Redirect(url, false);
                            }


                            #region Old Code

                            #endregion
                        }
                        #endregion


                        #region Instamojo Payment
                        if (rbtnInstamojo.Checked == true)
                        {
                            dtTour = null;
                            dtTour = new DataTable();
                            dtTour = pClsObj.fnGetSumOfTourAmt(Convert.ToString(Session["orderid"]));
                            decimal strtotalAmount = 0.0m;
                            string strAmt = ""; decimal ccvalue = 0.0M;
                            if (dtTour != null && dtTour.Rows.Count > 0)
                            {
                                strAmt = Convert.ToString(dtTour.Rows[0]["TotalPaidAmount"]);
                                ccvalue = Convert.ToDecimal(dtTour.Rows[0]["CalcCreditCardFee"]);
                                strtotalAmount = Convert.ToDecimal(dtTour.Rows[0]["TotalAmount"]);
                                if (Convert.ToDecimal(strAmt) < 0)
                                    strAmt = "0";
                            }

                            string REMOTE_ADDR = Request.ServerVariables["REMOTE_ADDR"].ToString();

                            int val = pClsObj.fninsert_tbl_PaymentDetails(Convert.ToString(Session["orderid"]), "ST", Convert.ToDecimal(strAmt), "Instamojo Bank", 'N',
                                "", "", "INR", "Instamojo Payment", decimal.Round(Convert.ToDecimal(ccvalue)), false, REMOTE_ADDR, strtotalAmount, "FullPayment", "FixedTours");
                            if (val == 0)
                            {
                                string ts = txtName.Text.Trim();//Convert.ToString(Session["TravelSector"]);
                                if (ts.Length > 0)
                                    ts = ts.Replace("&", "");
                                string ba = Convert.ToString(Session["billingAddress"]);
                                if (ba.Length > 0)
                                    ba = ba.Replace("&", "");
                                if (ba.Length > 250)
                                    ba = ba.Substring(0, 249);
                                string mb = Convert.ToString(Session["mobile"]);
                                //for Promo code amount deduction
                                if (Convert.ToString(promocode.Text) != "")
                                {
                                    Session["Amt"] = strAmt;//Convert.ToString(ClsCommon.ConvertStringint(Session["Amt"]) - ClsCommon.ConvertStringint(lPromoDiscount));
                                }
                                string url = "";
                                clsAdo clsObj = null;
                                int? lStatus = 0;
                                try
                                {
                                    clsObj = new clsAdo();
                                    string lTempTranID = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
                                                         System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() +
                                                         System.DateTime.Now.Millisecond.ToString();

                                    lStatus = clsObj.fnInsertPaymentHDFCPG("", Convert.ToString(Session["orderid"].ToString()), Session["EmailId"].ToString(), "Instamojo Bank", Convert.ToDecimal(strAmt),
                                        "", lTempTranID, "", "", "", "", ts, Session["EmailId"].ToString(), mb, ba, Session["orderid"].ToString(), "FullPayment", "FixedTours");
                                }
                                finally
                                {
                                    if (clsObj != null)
                                    {
                                        clsObj = null;
                                    }

                                }
                                if (lStatus > 0)
                                {
                                    url = "InstaMojoPayment.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedTours" + "&FirstName=" + txtName.Text.Trim();
                                }
                                else
                                {
                                    Response.Write("Error Occured");
                                    Response.End();
                                }
                                Session["Panel2Step"] = null;
                                Response.Redirect(url, false);
                            }



                        }
                        #endregion


                        #region RazorPay Payment
                        if (rdoRazorPay.Checked == true)
                        {
                            dtTour = null;
                            dtTour = new DataTable();
                            dtTour = pClsObj.fnGetSumOfTourAmt(Convert.ToString(Session["orderid"]));
                            decimal strtotalAmount = 0.0m;
                            string strAmt = ""; decimal ccvalue = 0.0M;
                            if (dtTour != null && dtTour.Rows.Count > 0)
                            {
                                strAmt = Convert.ToString(dtTour.Rows[0]["TotalPaidAmount"]);
                                ccvalue = Convert.ToDecimal(dtTour.Rows[0]["CalcCreditCardFee"]);
                                strtotalAmount = Convert.ToDecimal(dtTour.Rows[0]["TotalAmount"]);
                                if (Convert.ToDecimal(strAmt) < 0)
                                    strAmt = "0";
                            }

                            string REMOTE_ADDR = Request.ServerVariables["REMOTE_ADDR"].ToString();

                            int val = pClsObj.fninsert_tbl_PaymentDetails(Convert.ToString(Session["orderid"]), "ST", Convert.ToDecimal(strAmt), "RazorPay Bank", 'N',
                                "", "", "INR", "RazorPay Payment", decimal.Round(Convert.ToDecimal(ccvalue)), false, REMOTE_ADDR, strtotalAmount, "FullPayment", "FixedTours");
                            if (val == 0)
                            {
                                string ts = txtName.Text.Trim();//Convert.ToString(Session["TravelSector"]);
                                if (ts.Length > 0)
                                    ts = ts.Replace("&", "");
                                string ba = Convert.ToString(Session["billingAddress"]);
                                if (ba.Length > 0)
                                    ba = ba.Replace("&", "");
                                if (ba.Length > 250)
                                    ba = ba.Substring(0, 249);
                                string mb = Convert.ToString(Session["mobile"]);
                                //for Promo code amount deduction
                                if (Convert.ToString(promocode.Text) != "")
                                {
                                    Session["Amt"] = strAmt;//Convert.ToString(ClsCommon.ConvertStringint(Session["Amt"]) - ClsCommon.ConvertStringint(lPromoDiscount));
                                }
                                string url = "";
                                clsAdo clsObj = null;
                                int? lStatus = 0;
                                try
                                {
                                    clsObj = new clsAdo();
                                    string lTempTranID = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() +
                                                         System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() +
                                                         System.DateTime.Now.Millisecond.ToString();

                                    lStatus = clsObj.fnInsertPaymentHDFCPG("", Convert.ToString(Session["orderid"].ToString()), Session["EmailId"].ToString(), "RazorPay Bank", Convert.ToDecimal(strAmt),
                                        "", lTempTranID, "", "", "", "", ts, Session["EmailId"].ToString(), mb, ba, Session["orderid"].ToString(), "FullPayment", "FixedTours");
                                }
                                finally
                                {
                                    if (clsObj != null)
                                    {
                                        clsObj = null;
                                    }

                                }
                                if (lStatus > 0)
                                {
                                    url = "Razorpay_Payment.aspx?RID=" + lStatus.ToString() + "&SectionName=FixedTours" + "&FirstName=" + txtName.Text.Trim();
                                }
                                else
                                {
                                    Response.Write("Error Occured");
                                    Response.End();
                                }

                                Session["Panel2Step"] = null;
                                Response.Redirect(url, false);
                            }



                        }
                        #endregion


                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "terms", "<script>alert('Please Agree our terms & Conditions Before going to pay online');</script>");
                }
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (dtTour != null)
                {
                    dtTour.Dispose();
                    dtTour = null;
                }
            }
        }

        protected void hlback_Click(object sender, EventArgs e)
        {
            Session["Panel2Step"] = "Panel2Step";
            strEncrypt = DataLib.TripleDESEncode(OrderIDH.Value, endecript);
            if ((Request.QueryString["ltc"] == null) && (Request.QueryString["ltc"] != "0"))
            {
                Response.Redirect("TourBooking.aspx?orderid=" + strEncrypt + "&TourID=" + Page.RouteData.Values["tourId"]);
            }
            else
            {
                Response.Redirect("TourBooking.aspx?orderid=" + strEncrypt + "&TourID=" + Page.RouteData.Values["tourId"]);

            }
        }

        #endregion
        #region "Method(s)"
        private bool CheackSeatsForFD_Tour(int pTourID, DateTime pDOJ, int pUserType, int pSeat)
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            SqlParameter lParam = null;
            DataSet ldsDetail = new DataSet();
            SqlDataAdapter lDataAdp = null;
            bool lFlag = false;
            try
            {
                lConn = new SqlConnection(DataLib.getConnectionString());
                lCommand = new SqlCommand("CheackSeatsForFD_Tour_SP", lConn);
                lCommand.CommandTimeout = 20 * 1000;
                lCommand.CommandType = CommandType.StoredProcedure;

                lParam = new SqlParameter("@I_TourID", SqlDbType.Int);
                lParam.Value = pTourID;
                lCommand.Parameters.Add(lParam);

                lParam = new SqlParameter("@I_DOJ", SqlDbType.SmallDateTime);
                lParam.Value = pDOJ;
                lCommand.Parameters.Add(lParam);

                lParam = new SqlParameter("@I_UserType", SqlDbType.Int);
                lParam.Value = pUserType;
                lCommand.Parameters.Add(lParam);


                lParam = new SqlParameter("@o_ReturnValue", SqlDbType.Int);
                lParam.Value = "0";
                lParam.Direction = ParameterDirection.Output;
                lCommand.Parameters.Add(lParam);

                lParam = new SqlParameter("@o_Availability", SqlDbType.Int);
                lParam.Value = "0";
                lParam.Direction = ParameterDirection.Output;
                lCommand.Parameters.Add(lParam);



                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }
                lCommand.ExecuteNonQuery();
                int pStatus = ClsCommon.ConvertStringint(lCommand.Parameters["@o_ReturnValue"].Value);
                int pAvailability = ClsCommon.ConvertStringint(lCommand.Parameters["@o_Availability"].Value);
                if (pStatus > 0)
                {
                    if (pSeat <= pAvailability)
                    {
                        lFlag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.LogAndSendError(ex.ToString() + " Tour Booking - CheckSeatsforFD_Tour");
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
                if (ldsDetail != null)
                {
                    ldsDetail.Dispose();
                    ldsDetail = null;
                }
                if (lDataAdp != null)
                {
                    lDataAdp.Dispose();
                    lDataAdp = null;
                }
            }
            return lFlag;
        }
        private void BindTourItenerary(int ltourid)
        {
            List<TourItenerary_SPResult> lGetResult = null;
            clsAdo objOther = new clsAdo();

            try
            {
                lGetResult = new List<TourItenerary_SPResult>();

                lGetResult = objOther.fnGetTourItenerary(ltourid, ClsCommon.ConvertStringint(TOURTYPE.FIXED_TOUR)).ToList();
                if (lGetResult != null && lGetResult.Count > 0)
                {
                    //UcModifySearch1.fldTourName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(lGetResult[0].TourName.ToString() + " ( " + lGetResult[0].Tour_Short_key.ToString().ToUpper() + " )");
                    hdfTourName.Value = lGetResult[0].TourName.ToString();
                    //lblTourName1.Text = lGetResult[0].TourName.ToString();
                    if (Page.RouteData.Values["jdate"] != null && Page.RouteData.Values["jdate"] != "")
                    {
                        UcModifySearch1.fldJDate = fldQStrJDate.ToString("dddd, MMMM d, yyyy"); ;

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
        private void fillddlJdate(int TourNo, int No)
        {

            string hr = ConfigurationManager.AppSettings["CustomerFixedTourHours"].ToString();
            hr = "-" + hr;
            DataTable dtdates = null;
            DataSet lds = null;
            ClsCommon clsObj = null;
            try
            {
                clsObj = new ClsCommon();
                lds = clsObj.fnGetjdates_vacantseats(TourNo, ClsCommon.ConvertStringint(hr));
                if (lds != null ? lds.Tables.Count > 0 : false)
                {
                    dtdates = lds.Tables[0];
                }
                if (dtdates != null && dtdates.Rows.Count > 0)
                {

                    if (No == 1)
                    {
                        cmbrow.Visible = true;
                    }
                }
                else
                {
                    if (No == 0)
                        redirect(TourNo);
                }

            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
                if (dtdates != null)
                {
                    dtdates.Dispose();
                    dtdates = null;
                }
                if (lds != null)
                {
                    lds.Dispose();
                    lds = null;
                }
            }
        }
        private void insertbook(int tourno, int totpax, System.DateTime jdate, string orderid,
            string BusserialNo)
        {
            clsAdo pClsObj = null;
            DataSet ldsRecSet = null;
            DataTable dtPartpay = null;
            try
            {
                pClsObj = new clsAdo();
                decimal afare = 0, cfare = 0, a2fare = 0, a3fare = 0, cbfare = 0, safare = 0, dfare = 0, AdWFoodfare = 0, CWFoodfare = 0;
                float cbsbfare = 0, Inffare = 0;
                int NoAWFood = ClsCommon.ConvertStringint(txtNoAWFNoOfAdults.Text.ToString());
                int NoCWFood = ClsCommon.ConvertStringint(txtNoCWFNoOfChilds.Text.ToString());
                DateTime doj = jdate;
                DateTime dob = System.DateTime.Now;
                string[] CalAmt = CalCulateAmount(tourno).Split('^');
                decimal amt, tax, taxamt, ccfee, ccamt, tot;
                amt = Convert.ToDecimal(CalAmt[0]);
                tax = Convert.ToDecimal(CalAmt[1]);
                taxamt = Convert.ToDecimal(CalAmt[2]);
                ccfee = Convert.ToDecimal(CalAmt[3]);
                ccamt = Convert.ToDecimal(CalAmt[4]);
                tot = Math.Round(Convert.ToDecimal(CalAmt[5]), 0, MidpointRounding.AwayFromZero); ;
                char env = Convert.ToChar(CalAmt[6]);
                TourSerial = TSerial(jdate, tourno);
                int pkpID = ClsCommon.ConvertStringint(pClsObj.fnGetPickUpMAsterRowID(tourno, "Branch", ClsCommon.ConvertStringint(ddlPickUp.SelectedValue)));
                if (RadAC.Checked == true)
                {
                    afare = decimal.Round(Convert.ToDecimal(tAACFAre));
                    cfare = decimal.Round(Convert.ToDecimal(tCACFAre));
                    a2fare = decimal.Round(Convert.ToDecimal(tA2ACFare));
                    a3fare = decimal.Round(Convert.ToDecimal(tA3ACFare));
                    cbfare = decimal.Round(Convert.ToDecimal(tCBACFare));
                    safare = decimal.Round(Convert.ToDecimal(tSACFare));
                    dfare = decimal.Round(Convert.ToDecimal(tDACFare));
                    AdWFoodfare = decimal.Round(Convert.ToDecimal(tAWFACFAre));
                    CWFoodfare = decimal.Round(Convert.ToDecimal(tCWFACFAre));

                    cbsbfare = float.Parse(tCBACSBfare);
                    Inffare = float.Parse(tCBACinffare);

                }
                if (RadNAC.Checked == true)
                {
                    afare = decimal.Round(Convert.ToDecimal(tAnonacfare));
                    cfare = decimal.Round(Convert.ToDecimal(tCnonacfare));
                    a2fare = decimal.Round(Convert.ToDecimal(tA2NACFare));
                    a3fare = decimal.Round(Convert.ToDecimal(tA3NACFare));
                    cbfare = decimal.Round(Convert.ToDecimal(tCBNACFare));
                    safare = decimal.Round(Convert.ToDecimal(tSNACFare));
                    dfare = decimal.Round(Convert.ToDecimal(tDNACFare));
                    AdWFoodfare = decimal.Round(Convert.ToDecimal(tAWFnonacfare));
                    CWFoodfare = decimal.Round(Convert.ToDecimal(tCWFnonacfare));

                    cbsbfare = float.Parse(tCBNACSBfare);
                    Inffare = float.Parse(tCBNACinffare);

                }
                char isLtc = '0';
                if ((Request.QueryString["ltc"] != null) && Request.QueryString["ltc"] != "0")
                    isLtc = '1';
                tempstr = tempstr.Replace(",,", ",").TrimStart(',').TrimEnd(',');
                #region Optimize Code
                /* // to  get the discount on a particular tour
            string strDis = "select discount from tourmaster where tourno=" + tourno + 
                " and IsDiscountActive='Y' and Activated='Y'";
            string strValue = DataLib.GetStringData(DataLib.Connection.ConnectionString, strDis);


            //  End
          //---------Part payment Option Code Starts here

            SqlParameter[] paramPart = new SqlParameter[1];
            paramPart[0] = new SqlParameter("@tourid", tourno);      
            string sql = @"select IspartPay,IsMiniMum from tourmaster(nolock) where ('" + 
                jdate + @"' between journeyfrom  and journeyTo ) and tourNo=@tourid  and IsMiniMum='Y'";
            DataTable dtPartpay = DataLib.GetDataTableWithparam(DataLib.Connection.ConnectionString, 
                sql, paramPart);*/
                #endregion
                // to  get the discount on a particular tour
                //---------Part payment Option Code Starts here
                string strValue = "";
                pClsObj = new clsAdo();
                ldsRecSet = pClsObj.fnGetDiscount_Detail(tourno, jdate);
                if (ldsRecSet != null && ldsRecSet.Tables[0].Rows.Count > 0)
                {
                    strValue = Convert.ToString(ldsRecSet.Tables[0].Rows[0]["discount"]);
                }
                dtPartpay = ldsRecSet.Tables[1];
                decimal strMinValue = 0.0m, strMinPay = 0.0m;
                if (dtPartpay != null && dtPartpay.Rows.Count > 0)
                {
                    strMinValue = Convert.ToDecimal(dtPartpay.Rows[0]["IspartPay"].ToString());
                    strMinPay = Math.Round(((tot * strMinValue) / 100), 0, MidpointRounding.AwayFromZero);//decimal.Round((tot * strMinValue) / 100);
                }
                else
                    strMinPay = Math.Round(tot, 0, MidpointRounding.AwayFromZero); //decimal.Round(tot);

                string sUtm_Source = "", sUtm_Medium = "", sUtm_Term = "", sUtm_Content = "", sUtm_Campaign = "";
                if (Session["utm_source"] != null)
                {
                    sUtm_Source = Convert.ToString(Session["utm_source"]);
                }
                if (Session["utm_medium"] != null)
                {
                    sUtm_Medium = Convert.ToString(Session["utm_medium"]);
                }
                if (Session["utm_term"] != null)
                {
                    sUtm_Term = Convert.ToString(Session["utm_term"]);
                }
                if (Session["utm_content"] != null)
                {
                    sUtm_Content = Convert.ToString(Session["utm_content"]);
                }
                if (Session["utm_campaign"] != null)
                {
                    sUtm_Campaign = Convert.ToString(Session["utm_campaign"]);
                }
                decimal pServiceChargesTotal = 0;
                int pATotPax = ClsCommon.ConvertStringint(txtNoOfAdults.Text) + ClsCommon.ConvertStringint(txtNoOfAdultsTwin.Text) + ClsCommon.ConvertStringint(txtNoOfAdultsTriple.Text) +
                      ClsCommon.ConvertStringint(txtNoOfSingles.Text) + ClsCommon.ConvertStringint(txtNoofdormitory.Text) + ClsCommon.ConvertStringint(txtNoAWFNoOfAdults.Text);
                int pCTotPax = ClsCommon.ConvertStringint(txtNoOfChilds.Text) + ClsCommon.ConvertStringint(txtNoOfChildBed.Text) + ClsCommon.ConvertStringint(txtNoCWFNoOfChilds.Text) + ClsCommon.ConvertStringint(txtNoOfChildBedSB.Text) + ClsCommon.ConvertStringint(txtNoOfInfBed.Text);
                decimal pServiceChargesTax = Convert.ToDecimal(DataLib.GetserviceTax("SCTax"));
                //if (tourno == 130)
                //{
                //    pServiceChargesTax = 0;
                //}
                decimal pServiceChargesTaxValue = 0;
                if (hdAServiceChargeFare.Value != "" && Convert.ToDecimal(hdAServiceChargeFare.Value) > 0)
                {
                    pServiceChargesTaxValue = (((Convert.ToDecimal(hdAServiceChargeFare.Value) * pATotPax) + (Convert.ToDecimal(hdCServiceChargeFare.Value) * pCTotPax)) * pServiceChargesTax) / 100;
                    pServiceChargesTotal = (Convert.ToDecimal(hdAServiceChargeFare.Value) * pATotPax) + (Convert.ToDecimal(hdCServiceChargeFare.Value) * pCTotPax) + pServiceChargesTaxValue;
                }
                tot = tot + pServiceChargesTotal;
                strMinPay = strMinPay + pServiceChargesTotal;

                int val = ClsCommon.Insert_OnlineToursBooking(orderid, tourno, doj, dob, env,
                    ClsCommon.ConvertStringint(txtNoOfAdults.Text),
                    ClsCommon.ConvertStringint(txtNoOfChilds.Text), ClsCommon.ConvertStringint(txtNoOfAdultsTwin.Text),
                    ClsCommon.ConvertStringint(txtNoOfAdultsTriple.Text),
                    ClsCommon.ConvertStringint(txtNoOfChildBed.Text), ClsCommon.ConvertStringint(txtNoOfSingles.Text),
                    lblTourName.Text, decimal.Round(amt), tax, Math.Round(taxamt, 0, MidpointRounding.AwayFromZero),
                    Math.Round(tot, 0, MidpointRounding.AwayFromZero), tempstr, BusserialNo, Convert.ToString(TourSerial), pkpID,
                    afare, cfare, a2fare, a3fare, cbfare, safare, ccfee, decimal.Round(ccamt),
                    ClsCommon.ConvertStringint(txtNoofdormitory.Text), dfare, isLtc, strValue, Math.Round(strMinPay, 0, MidpointRounding.AwayFromZero), NoAWFood, NoCWFood, AdWFoodfare, CWFoodfare, sUtm_Source, sUtm_Medium,
                    sUtm_Term, sUtm_Content, sUtm_Campaign, pServiceChargesTotal, pServiceChargesTax, pServiceChargesTaxValue, Convert.ToDecimal(hdAServiceChargeFare.Value),
                    Convert.ToDecimal(hdCServiceChargeFare.Value));

                Session["utm_source"] = null;
                Session["utm_medium"] = null;
                Session["utm_term"] = null;
                Session["utm_content"] = null;
                Session["utm_campaign"] = null;
                UpdateInfantChiildfare(orderid, Convert.ToString(tourno), ClsCommon.ConvertStringint(txtNoOfInfBed.Text), ClsCommon.ConvertStringint(txtNoOfChildBedSB.Text), Inffare, cbsbfare);
                if (hdnWam.Value == "1") { UpdateTcsValByRowID(orderid, Convert.ToString(tourno), hdnTCSVal.Value, "updOnline"); }
                strEncrypt = DataLib.TripleDESEncode(orderid, endecript);

                Session["Panel2Step"] = "Panel2Step";
                Response.Redirect("TourBooking.aspx?orderid=" + strEncrypt + "&TourID=" + tourno + "&jdate=" + doj.ToString().Split(' ')[0].ToString());

            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (ldsRecSet != null)
                {
                    ldsRecSet.Dispose();
                    ldsRecSet = null;
                }
                if (dtPartpay != null)
                {
                    dtPartpay.Dispose();
                    dtPartpay = null;
                }
            }
        }
        private void updatebook(int tourno, int totpax, System.DateTime jdate, string orderid,
            int Rowid, string BusserialNo)
        {
            clsAdo pClsObj = null;
            try
            {
                pClsObj = new clsAdo();
                decimal afare = 0, cfare = 0, a2fare = 0, a3fare = 0, cbfare = 0, safare = 0,
                    dfare = 0, AdWFoodfare = 0, CWFoodfare = 0;
                float cbsbfare = 0, Inffare = 0;
                int NoAWFood = ClsCommon.ConvertStringint(txtNoAWFNoOfAdults.Text.ToString());
                int NoCWFood = ClsCommon.ConvertStringint(txtNoCWFNoOfChilds.Text.ToString());
                DateTime doj = jdate;
                DateTime dob = DateTime.Now;
                string[] CalAmt = CalCulateAmount(tourno).Split('^');
                decimal amt, tax, taxamt, ccfee, ccamt, tot;
                amt = Convert.ToDecimal(CalAmt[0]);
                tax = Convert.ToDecimal(CalAmt[1]);
                taxamt = Convert.ToDecimal(CalAmt[2]);
                ccfee = Convert.ToDecimal(CalAmt[3]);
                ccamt = Convert.ToDecimal(CalAmt[4]);
                tot = Math.Round(Convert.ToDecimal(CalAmt[5]), 0, MidpointRounding.AwayFromZero); ;
                char env = Convert.ToChar(CalAmt[6]);
                TourSerial = TSerial(jdate, tourno);
                /*int pkpID = clsBLL.FixedTour_PickupPointID(tourno); */
                //int pkpID = pClsObj.fnGetPickUpMAsterRowID(tourno, "EndUser", ClsCommon.ConvertStringint(ddlPickUp.SelectedValue));
                int pkpID = pClsObj.fnGetPickUpMAsterRowID(tourno, "Branch", ClsCommon.ConvertStringint(ddlPickUp.SelectedValue));
                if (RadAC.Checked == true)
                {
                    afare = decimal.Round(Convert.ToDecimal(tAACFAre));
                    cfare = decimal.Round(Convert.ToDecimal(tCACFAre));
                    a2fare = decimal.Round(Convert.ToDecimal(tA2ACFare));
                    a3fare = decimal.Round(Convert.ToDecimal(tA3ACFare));
                    cbfare = decimal.Round(Convert.ToDecimal(tCBACFare));
                    safare = decimal.Round(Convert.ToDecimal(tSACFare));
                    dfare = decimal.Round(Convert.ToDecimal(tDACFare));
                    AdWFoodfare = decimal.Round(Convert.ToDecimal(tAWFACFAre));
                    CWFoodfare = decimal.Round(Convert.ToDecimal(tCWFACFAre));
                    cbsbfare = float.Parse(tCBACSBfare);
                    Inffare = float.Parse(tCBACinffare);
                }
                if (RadNAC.Checked == true)
                {
                    afare = decimal.Round(Convert.ToDecimal(tAnonacfare));
                    cfare = decimal.Round(Convert.ToDecimal(tCnonacfare));
                    a2fare = decimal.Round(Convert.ToDecimal(tA2NACFare));
                    a3fare = decimal.Round(Convert.ToDecimal(tA3NACFare));
                    cbfare = decimal.Round(Convert.ToDecimal(tCBNACFare));
                    safare = decimal.Round(Convert.ToDecimal(tSNACFare));
                    dfare = decimal.Round(Convert.ToDecimal(tDNACFare));
                    AdWFoodfare = decimal.Round(Convert.ToDecimal(tAWFnonacfare));
                    CWFoodfare = decimal.Round(Convert.ToDecimal(tCWFnonacfare));

                    cbsbfare = float.Parse(tCBNACSBfare);
                    Inffare = float.Parse(tCBNACinffare);
                }
                tempstr = tempstr.Replace(",,", ",").TrimStart(',').TrimEnd(',');
                decimal pServiceChargesTotal = 0;

                int pATotPax = ClsCommon.ConvertStringint(txtNoOfAdults.Text) + ClsCommon.ConvertStringint(txtNoOfAdultsTwin.Text) + ClsCommon.ConvertStringint(txtNoOfAdultsTriple.Text) +
                    ClsCommon.ConvertStringint(txtNoOfSingles.Text) + ClsCommon.ConvertStringint(txtNoofdormitory.Text) + ClsCommon.ConvertStringint(txtNoAWFNoOfAdults.Text);
                int pCTotPax = ClsCommon.ConvertStringint(txtNoOfChilds.Text) + ClsCommon.ConvertStringint(txtNoOfChildBed.Text) + ClsCommon.ConvertStringint(txtNoCWFNoOfChilds.Text) + ClsCommon.ConvertStringint(txtNoOfChildBedSB.Text) + ClsCommon.ConvertStringint(txtNoOfInfBed.Text);
                decimal pServiceChargesTax = Convert.ToDecimal(DataLib.GetserviceTax("SCTax"));
                //if (tourno == 130)
                //{
                //    pServiceChargesTax = 0;
                //}
                decimal pServiceChargesTaxValue = 0;
                if (hdAServiceChargeFare.Value != "" && Convert.ToDecimal(hdAServiceChargeFare.Value) > 0)
                {
                    pServiceChargesTaxValue = (((Convert.ToDecimal(hdAServiceChargeFare.Value) * pATotPax) + (Convert.ToDecimal(hdCServiceChargeFare.Value) * pCTotPax)) * pServiceChargesTax) / 100;
                    pServiceChargesTotal = (Convert.ToDecimal(hdAServiceChargeFare.Value) * pATotPax) + (Convert.ToDecimal(hdCServiceChargeFare.Value) * pCTotPax) + pServiceChargesTaxValue;
                }
                tot = tot + pServiceChargesTotal;

                int val = ClsCommon.Update_OnlineToursBooking(jdate, env,
                    ClsCommon.ConvertStringint(txtNoOfAdults.Text),
                    ClsCommon.ConvertStringint(txtNoOfChilds.Text), ClsCommon.ConvertStringint(txtNoOfAdultsTwin.Text),
                    ClsCommon.ConvertStringint(txtNoOfAdultsTriple.Text), ClsCommon.ConvertStringint(txtNoOfChildBed.Text),
                    ClsCommon.ConvertStringint(txtNoOfSingles.Text), decimal.Round(amt), tax, Math.Round(taxamt, 0, MidpointRounding.AwayFromZero),
                    Math.Round(tot, 0, MidpointRounding.AwayFromZero), tempstr, BusserialNo, TourSerial, pkpID, afare, cfare, a2fare,
                    a3fare, cbfare, safare, ccfee, decimal.Round(ccamt),
                    Rowid, ClsCommon.ConvertStringint(txtNoofdormitory.Text), dfare, NoAWFood, NoCWFood, AdWFoodfare, CWFoodfare, tourno, lblTourName.Text,
                    pServiceChargesTotal, pServiceChargesTax, pServiceChargesTaxValue, Convert.ToDecimal(hdAServiceChargeFare.Value),
                    Convert.ToDecimal(hdCServiceChargeFare.Value));

                UpdateInfantChiildfare(orderid, Convert.ToString(tourno), ClsCommon.ConvertStringint(txtNoOfInfBed.Text), ClsCommon.ConvertStringint(txtNoOfChildBedSB.Text), Inffare, cbsbfare);
                if (hdnWam.Value == "1") { UpdateTcsValByRowID(Convert.ToString(Rowid), Convert.ToString(tourno), hdnTCSVal.Value, "insOnline"); }

                strEncrypt = DataLib.TripleDESEncode(orderid, endecript);
                Session["Panel2Step"] = "Panel2Step";
                if ((Request.QueryString["ltc"] == null) && (Request.QueryString["ltc"] != "0"))

                    Response.Redirect("TourBooking.aspx?orderid=" + RemoveSlashAmp(strEncrypt) + "&TourID=" + Page.RouteData.Values["tourId"] + "&jdate=" +
                         Page.RouteData.Values["jdate"].ToString().Split(' ')[0].ToString());

                else
                    Response.Redirect("TourBooking.aspx?orderid=" + RemoveSlashAmp(strEncrypt) + "&TourID=" + Page.RouteData.Values["tourId"] + "&jdate=" +
                        Page.RouteData.Values["jdate"].ToString().Split(' ')[0].ToString());


            }

            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }

            }
        }

        private void UpdateInfantChiildfare(string orderid, string tourid, int Infant, int ChildwithoutSeatBed, float Infantfare, float ChildwithoutSeatBedfare)
        {
            int res = 0;
            SqlConnection lConn = null;
            try
            {
                String strCn = System.Configuration.ConfigurationManager.AppSettings["southernconn"];
                lConn = new SqlConnection(strCn);// For  Live
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.SP_AddOperatingBranchForEBK_SPL, lConn))
                {

                    cmd.CommandTimeout = 20 * 1000;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "EBKfare");
                    cmd.Parameters.AddWithValue("@OrderID ", orderid);
                    cmd.Parameters.AddWithValue("@tourid", tourid);
                    cmd.Parameters.AddWithValue("@Infant", Infant);
                    cmd.Parameters.AddWithValue("@ChildwithoutSeatBed", ChildwithoutSeatBed);
                    cmd.Parameters.AddWithValue("@Infantfare", Infantfare);
                    cmd.Parameters.AddWithValue("@ChildwithoutSeatBedfare", ChildwithoutSeatBedfare);
                    if (lConn.State == ConnectionState.Closed)
                    {
                        lConn.Open();
                    }
                    res = Convert.ToInt32(cmd.ExecuteNonQuery());
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally { lConn.Close(); }

        }

        public void getfaregrid(DateTime jd, Int32 tourid)
        {
            char isLtc = 'N';
            if ((Request.QueryString["ltc"] != null) && (Request.QueryString["ltc"] != "0"))
                isLtc = 'Y';
            DataSet ldsTourFare = null;
            clsAdo clsObj = null;
            try
            {
                clsObj = new clsAdo();
                ldsTourFare = clsObj.fnGetFixedTour_Fare(tourid, jd, isLtc, "Online");
                if (ldsTourFare != null && ldsTourFare.Tables.Count > 0 && ldsTourFare.Tables[0].Rows.Count > 0)
                {
                    string strValue = "";
                    decimal newAcFare = 0.0m, newAcValue = 0.0m, newNAcFare = 0.0m, newNAcValue = 0.0m;
                    if (discount.Value != "4")
                    {
                        if (ldsTourFare.Tables[1].Rows.Count > 0)
                        {
                            strValue = Convert.ToString(ldsTourFare.Tables[1].Rows[0][0]);
                        }
                    }
                    if (ldsTourFare.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ldsTourFare.Tables[0].Rows.Count; i++)
                        {
                            if (strValue != "" && strValue != null && Convert.ToDecimal(strValue) > 0)
                            {

                                newAcValue = Convert.ToDecimal(ldsTourFare.Tables[0].Rows[i]["ACFare"] == DBNull.Value ? "0" : ldsTourFare.Tables[0].Rows[i]["ACFare"]);


                                newAcValue = ((newAcValue * Convert.ToDecimal(strValue)) / 100);
                               
                                newAcFare = Math.Round(Convert.ToDecimal(
                                    ldsTourFare.Tables[0].Rows[i]["ACFare"] == DBNull.Value ? "0" : ldsTourFare.Tables[0].Rows[i]["ACFare"]) - newAcValue, 0);

                            }
                            else
                            {
                                newAcFare = Math.Round(Convert.ToDecimal(
                                    ldsTourFare.Tables[0].Rows[i]["ACFare"]), 0);
                                strValue = "0";
                            }
                            if (strValue != "" && strValue != null && Convert.ToDecimal(strValue) > 0)
                            {
                                newNAcValue = Convert.ToDecimal(ldsTourFare.Tables[0].Rows[i]["NonACFare"]);
                                newNAcValue = ((newNAcValue * Convert.ToDecimal(strValue)) / 100);
                                newNAcFare = Math.Round(Convert.ToDecimal(
                                    ldsTourFare.Tables[0].Rows[i]["NonACFare"]) - newNAcValue, 0);
                            }
                            else
                            {
                                newNAcFare = Math.Round(Convert.ToDecimal(
                                    ldsTourFare.Tables[0].Rows[i]["NonACFare"]), 0);
                                strValue = "0";
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 1)
                            {
                                this.lblAACfare.Text = Convert.ToString(newAcFare);
                                this.lblANACfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 2)
                            {
                                this.lblA2ACfare.Text = Convert.ToString(newAcFare);
                                this.lblA2NACfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 3)
                            {
                                this.lblA3ACfare.Text = Convert.ToString(newAcFare);
                                this.lblA3NACfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 4)
                            {
                                this.lblCBACfare.Text = Convert.ToString(newAcFare);
                                this.lblCBNACfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 5)
                            {
                                this.lblSACfare.Text = Convert.ToString(newAcFare);
                                this.lblSNACfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 6)
                            {
                                this.lblCACfare.Text = Convert.ToString(newAcFare);
                                this.lblCNACfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 7)
                            {
                                this.lbldACfare.Text = Convert.ToString(newAcFare);
                                this.lbldNACfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 8)
                            {
                                this.lblAWFfare.Text = Convert.ToString(newAcFare);
                                this.lblAWFNACfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 9)
                            {
                                this.lblCWFfare.Text = Convert.ToString(newAcFare);
                                this.lblCWFNACfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 10)
                            {
                                this.lblCBACSBfare.Text = Convert.ToString(newAcFare);
                                this.lblCBNACSBfare.Text = Convert.ToString(newNAcFare);
                            }
                            if (ClsCommon.ConvertStringint(ldsTourFare.Tables[0].Rows[i]["Rowid"]) == 11)
                            {
                                this.lblCBACinffare.Text = Convert.ToString(newAcFare);
                                this.lblCBNACinffare.Text = Convert.ToString(newNAcFare);
                            }
                        }
                        if (((this.lblAACfare.Text == "0") || (this.lblAACfare.Text == "")) &&
                            ((this.lblANACfare.Text == "0") || (this.lblANACfare.Text == "")))
                        {
                            traf.Visible = false;
                   
                        }
                        if (((this.lblCACfare.Text == "0") || (this.lblCACfare.Text == "")) &&
                            ((this.lblCNACfare.Text == "0") || (this.lblCNACfare.Text == "")))
                        {
                            trcf.Visible = false;
                        }
                        if (((this.lblAWFfare.Text == "0") || (this.lblAWFfare.Text == "")) &&
                            ((this.lblAWFNACfare.Text == "0") || (this.lblAWFNACfare.Text == "")))
                        {
                            trAWF.Visible = false;
                        }
                        if (((this.lblCWFfare.Text == "0") || (this.lblCWFfare.Text == "")) &&
                            ((this.lblCWFNACfare.Text == "0") || (this.lblCWFNACfare.Text == "")))
                        {
                            trCWF.Visible = false;
                        }
                        if (((this.lblA2ACfare.Text == "0") || (this.lblA2ACfare.Text == "")) &&
                            ((this.lblA2NACfare.Text == "0") || (this.lblA2NACfare.Text == "")))
                        {
                            tra2f.Visible = false;
                        }
                        if (((this.lblA3ACfare.Text == "0") || (this.lblA3ACfare.Text == "")) &&
                            ((this.lblA3NACfare.Text == "0") || (this.lblA3NACfare.Text == "")))
                        {
                            tra3f.Visible = false;
                        }
                        if (((this.lblCBACSBfare.Text == "0") || (this.lblCBACSBfare.Text == "")) &&
                            ((this.lblCBNACSBfare.Text == "0") || (this.lblCBNACSBfare.Text == "")))
                        {
                            trcbsb.Visible = false;
                        }
                        if (((this.lblCBACinffare.Text == "0") || (this.lblCBACinffare.Text == "")) &&
                            ((this.lblCBNACinffare.Text == "0") || (this.lblCBNACinffare.Text == "")))
                        {
                            trcbinf.Visible = false;
                        }
                        if (((this.lblCBACfare.Text == "0") || (this.lblCBACfare.Text == "")) &&
                            ((this.lblCBNACfare.Text == "0") || (this.lblCBNACfare.Text == "")))
                        {
                            trcbf.Visible = false;
                        }
                        if (((this.lblSACfare.Text == "0") || (this.lblSACfare.Text == "")) &&
                            ((this.lblSNACfare.Text == "0") || (this.lblSNACfare.Text == "")))
                        {


                            trsf.Visible = false;
                        }
                        if (((this.lbldACfare.Text == "0") || (this.lbldACfare.Text == "")) &&
                            ((this.lbldNACfare.Text == "0") || (this.lbldNACfare.Text == "")))
                        {
                            tradf.Visible = false;
                        }
                        if ((tra2f.Visible) || (tra3f.Visible) || (trcbf.Visible) ||
                            (trsf.Visible) || (tradf.Visible) || (trcbsb.Visible) || (trcbinf.Visible))
                        {
                            if (((this.lblA2ACfare.Text == "0") || (this.lblA2ACfare.Text == "")) &&
                                ((this.lblA3ACfare.Text == "0") || (this.lblA3ACfare.Text == "")) &&
                                ((this.lblCBACfare.Text == "0") || (this.lblCBACfare.Text == "")) &&
                                ((this.lblSACfare.Text == "0") || (this.lblSACfare.Text == "")) &&
                                ((this.lbldACfare.Text == "0") || (this.lbldACfare.Text == "")) &&
                                ((this.lblCBACSBfare.Text == "0") || (this.lblCBACSBfare.Text == "")) &&
                                ((this.lblCBACinffare.Text == "0") || (this.lblCBACinffare.Text == "")))
                            {
                                RadAC.Enabled = false;
                                RadNAC.Checked = true;
                            }
                            if (((this.lblA2NACfare.Text == "0") || (this.lblA2NACfare.Text == "")) &&
                                ((this.lblA3NACfare.Text == "0") || (this.lblA3NACfare.Text == "")) &&
                                ((this.lblCBNACfare.Text == "0") || (this.lblCBNACfare.Text == "")) &&
                                ((this.lblSNACfare.Text == "0") || (this.lblSNACfare.Text == "")) &&
                                ((this.lbldNACfare.Text == "0") || (this.lbldNACfare.Text == "")) &&
                                ((this.lblCBNACSBfare.Text == "0") || (this.lblCBNACSBfare.Text == "")) &&
                                ((this.lblCBNACinffare.Text == "0") || (this.lblCBNACinffare.Text == "")))
                            {
                                RadNAC.Enabled = false;
                                RadAC.Checked = true;
                            }
                        }
                        if ((traf.Visible) || (trcf.Visible))
                        {
                            if (((this.lblAACfare.Text == "0") || (this.lblAACfare.Text == "")) &&
                                ((this.lblCACfare.Text == "0") || (this.lblCACfare.Text == "")))
                            {
                                RadAC.Enabled = false;
                                RadNAC.Checked = true;
                            }
                            if (((this.lblANACfare.Text == "0") || (this.lblANACfare.Text == "")) &&
                                ((this.lblCNACfare.Text == "0") || (this.lblCNACfare.Text == "")))
                            {
                                RadNAC.Enabled = false;
                                RadAC.Checked = true;
                            }
                        }
                        if ((trAWF.Visible) || (trCWF.Visible))
                        {
                            if (((this.lblAWFfare.Text == "0") || (this.lblAWFfare.Text == "")) &&
                                ((this.lblCWFfare.Text == "0") || (this.lblCWFfare.Text == "")))
                            {
                                RadAC.Enabled = false;
                                RadNAC.Checked = true;
                            }
                            if (((this.lblAWFNACfare.Text == "0") || (this.lblAWFNACfare.Text == "")) &&
                                ((this.lblCWFNACfare.Text == "0") || (this.lblCWFNACfare.Text == "")))
                            {
                                RadNAC.Enabled = false;
                                RadAC.Checked = true;
                            }
                        }
                    }
                }
                else
                {
                    RadNAC.Enabled = false;
                    RadAC.Enabled = false;
                }
            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
                if (ldsTourFare != null)
                {
                    ldsTourFare.Dispose();
                    ldsTourFare = null;
                }
            }
        }
        private void redirect(int TourNo)
        {
            string reurl = ConfigurationSettings.AppSettings["virtualPath"].ToString();
            if (Convert.ToString(TourNo) == "13")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey " +
                    "date for this tour.You are redirected to the Agra-Mathura TOUR BY VOLVO" +
                    " For the Same');window.location.href='" + reurl + "/TourBooking.aspx?" +
                    "tourid=39';</script>");
            //" For the Same');window.location.href='" + reurl + "/Fixed-Departure-Booking-" +
            //"Agra-Mathura-Volvo_39';</script>");
            else if (Convert.ToString(TourNo) == "39")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey date" +
                    " for this tour.You are redirected to the Agra-Mathura  For the Same');" +
                    "window.location.href='" + reurl + "/TourBooking.aspx?tourid=13';</script>");
            //"window.location.href='" + reurl + "/Fixed-Departure-Booking-Agra-Mathura_13';</script>");
            else if (Convert.ToString(TourNo) == "16")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey date" +
                    " for this tour.You are redirected to the JAIPUR-AGRA (VOLVO). A.C  For the " +
                    "Same');window.location.href='" + reurl + "/TourBooking.aspx?tourid=40';</script>");
            //"Same');window.location.href='" + reurl + "/Fixed-Departure-Booking-Jaipur-Agra-(Volvo).-A.C_40';</script>");
            else if (Convert.ToString(TourNo) == "40")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey date" +
                    " for this tour.You are redirected to the JAIPUR-AGRA A.C  For the Same');" +
                    "window.location.href='" + reurl + "/TourBooking.aspx?tourid=16';</script>");
            //"window.location.href='" + reurl + "/Fixed-Departure-Booking-Jaipur-Agra-A.C_16';</script>");
            else if (Convert.ToString(TourNo) == "18")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey date" +
                    " for this tour.You are redirected to the MUSSOORIE-HARIDWAR-RISHIKESH.AC  " +
                    "For the Same');window.location.href='" + reurl + "/TourBooking.aspx?tourid=52';</script>");
            //"For the Same');window.location.href='" + reurl + "/Fixed-Departure-Booking-Mussoorie-Haridwar-Rishikesh.Ac_52';</script>");
            else if (Convert.ToString(TourNo) == "52")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey " +
                    "date for this tour.You are redirected to the MUSSOORIE-HARIDWAR  For the " +
                    "Same');window.location.href='" + reurl + "/TourBooking.aspx?tourid=18';</script>");
            //"Same');window.location.href='" + reurl + "/Fixed-Departure-Booking-Mussoorie-Haridwar_18';</script>");
            else if (Convert.ToString(TourNo) == "21")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey date" +
                    " for this tour.You are redirected to the 4 DHAM For the Same');window.location.href='" +
                    reurl + "/TourBooking.aspx?tourid=22';</script>");
            //reurl + "/Fixed-Departure-Booking-4-Dham_22';</script>");
            else if (Convert.ToString(TourNo) == "22")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey date" +
                    " for this tour.You are redirected to the BADRINATH-KEDARNATH  For the Same');" +
                    "window.location.href='" + reurl + "/TourBooking.aspx?tourid=21';</script>");
            //"window.location.href='" + reurl + "/Fixed-Departure-Booking-Badrinath-Kedarnath_21';</script>");
            else if (Convert.ToString(TourNo) == "41")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey date" +
                    " for this tour.You are redirected to the SHIMLA-KULLU-MANALI-VOLVO (FOOD)  " +
                    "For the Same');window.location.href='" + reurl + "/TourBooking.aspx?tourid=71';</script>");
            //"For the Same');window.location.href='" + reurl + "/Fixed-Departure-Booking-Shimla-Kullu-Manali-Volvo-(Food)_71';</script>");
            else if (Convert.ToString(TourNo) == "71")
                this.RegisterStartupScript("Ypdation", "<script>alert('There is no Journey date" +
                    " for this tour.You are redirected to the SHIMLA-KULLU-MANALI -WITH FOOD.A.C  " +
                    "For the Same');window.location.href='" + reurl + "/TourBooking.aspx?tourid=41';</script>");
            //"For the Same');window.location.href='" + reurl + "/Fixed-Departure-Booking-Shimla-Kullu-Manali-With-Food.A.C_41';</script>");
        }
        private void Dispup(int tourno, string iscombination)
        {
            DataTable dtdetails = null, dtPickup = null;
            clsAdo clsObj = null;

            try
            {
                clsObj = new clsAdo();
                dtdetails = clsObj.fnFixed_PickupAddr_DeptTime(tourno);
                if (dtdetails != null && dtdetails.Rows.Count > 0)
                {
                    if (iscombination == "Y")
                        tourdisp(dtdetails, tourno);
                    else
                        tourdisp(dtdetails, 0);
                }
                else
                {
                    if (ClsCommon.Add_Fixed_PickupPlace(tourno) == 0)
                    {
                        dtdetails = clsObj.fnFixed_PickupAddr_DeptTime(tourno);
                        if (dtdetails != null && dtdetails.Rows.Count > 0)
                        {
                            if (iscombination == "Y")
                                tourdisp(dtdetails, tourno);
                            else
                                tourdisp(dtdetails, 0);
                        }
                    }
                    else
                    {
                        table5.Visible = false;
                        btnContinuee.Visible = false;
                        colorindication.Visible = false;
                        btnRe.Visible = false;
                    }
                }
                clsObj = new clsAdo();
                dtPickup = clsObj.fnGetMultiplePickupPoint(tourno);
                ddlPickUp.DataSource = dtPickup;
                ddlPickUp.DataBind();
            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
                if (dtdetails != null)
                {
                    dtdetails.Dispose();
                    dtdetails = null;
                }
                if (dtPickup != null)
                {
                    dtPickup.Dispose();
                    dtPickup = null;
                }
            }
        }
        private void tourdisp(DataTable dtdetails, int No)
        {

            if (dtdetails != null && dtdetails.Rows.Count > 0)
            {
                if (No > 0)
                {
                }
                else
                {
                    lblTourName.Text = Convert.ToString(dtdetails.Rows[0]["TourName"]);
                    lblFare.Text = "";
                    hdAServiceChargeFare.Value = "0";
                    hdCServiceChargeFare.Value = "0";
                    if (!IsPostBack)
                    {
                        lblPickupPlace.Text = Convert.ToString(dtdetails.Rows[0]["Address"]);
                        string[] lDepartTime = Convert.ToString(dtdetails.Rows[0]["DepartTime"]).Split(':');
                        lblDepTime.Text = lDepartTime[0] + ":" + lDepartTime[1] + " " + lDepartTime[2].ToString().Split(' ')[1];
                        hidPickupPlace.Value = Convert.ToString(dtdetails.Rows[0]["Address"]);
                        hidDepTime.Value = Convert.ToString(lblDepTime.Text);
                        if (FlagIntlEBKTourIDs) { lblDepTime.Visible = false; }
                        if (Convert.ToDecimal(dtdetails.Rows[0]["AdultFare"].ToString()) > 0)
                        {
                            lblFare.Text = "<b>Current selected Pickup Point`s Service charge is  (Adult / Child)  : <span class=rupee>`</span>" + Convert.ToString(dtdetails.Rows[0]["AdultFare"].ToString())
                                + "/- <span class=rupee>`</span> " + Convert.ToString(dtdetails.Rows[0]["ChildFare"].ToString()) + "/-.</b>";
                            hdAServiceChargeFare.Value = Convert.ToString(dtdetails.Rows[0]["AdultFare"].ToString());
                            hdCServiceChargeFare.Value = Convert.ToString(dtdetails.Rows[0]["ChildFare"].ToString());
                        }
                    }
                }
                if (Convert.ToString(dtdetails.Rows[0]["isaccomodation"]) == "N")
                {

                    this.traf.Visible = true;
                    this.trcf.Visible = true;
                    this.trAWF.Visible = true;
                    this.trCWF.Visible = true;
                }
                else
                {


                    this.tra2f.Visible = true;
                    this.tra3f.Visible = true;
                    this.trcbf.Visible = true;
                    this.trsf.Visible = true;
                    this.tradf.Visible = true;
                    this.trcbsb.Visible = true;
                }
            }
        }
        private int GetAvailBusSeat(int CurrentBusSerial)
        {
            int Seat = 0;
            Seat = ClsCommon.NoofAvailableSeats(BusSeaterType, CurrentBusSerial);
            return Seat;
        }
        private string doBlock(string tstr, int tserial)
        {
            string BlockedString, BlockedString1, BlockedString2, BlockedString3;
            BlockedString1 = Convert.ToString(DateTime.Now.ToString("dd-MMM-yyyy"));
            BlockedString2 = Convert.ToString(DateTime.Now.ToString("HH:mm"));
            BlockedString3 = OrderIDH.Value; ;
            //BlockedString = "Blocked By EBK0001" + "\n" + BlockedString1 + "\n" + BlockedString2 + "\n" + BlockedString3;
            BlockedString = "Blocked By EBK0001" + "\n" + BlockedString1 + "\n" + BlockedString2 + "\n" + BlockedString3; ;

            Boolean tt = ClsCommon.Block_Seats(tstr, tserial, BlockedString);
            if (tt == true)
            {
                Session["blockStatus_EndUser"] = "blocked";
                Session["blockStr_EndUser"] = tstr + "#" + tserial;
                return "Yes";
            }
            else
                return "No";
        }
        private void doUnBlock(string tstr, int tserial)
        {
            optedSeatNos.Value = "";
            ClsCommon.UnBlock_Seats(tstr, tserial);
            Session["blockStatus_EndUser"] = null;
            Session["blockStr_EndUser"] = null;
        }
        private string CalCulateAmount(int tourno)
        {
            string Env = "";
            if (tAACFAre == "") tAACFAre = "0";
            if (tCACFAre == "") tCACFAre = "0";
            if (tA2ACFare == "") tA2ACFare = "0";
            if (tA3ACFare == "") tA3ACFare = "0";
            if (tCBACFare == "") tCBACFare = "0";
            if (tCBACSBfare == "") tCBACSBfare = "0";
            if (tCBACinffare == "") tCBACinffare = "0";
            if (tSACFare == "") tSACFare = "0";
            if (tAnonacfare == "") tAnonacfare = "0";
            if (tCnonacfare == "") tCnonacfare = "0";
            if (tA2NACFare == "") tA2NACFare = "0";
            if (tA3NACFare == "") tA3NACFare = "0";
            if (tCBNACFare == "") tCBNACFare = "0";
            if (tCBNACSBfare == "") tCBNACSBfare = "0";
            if (tCBNACinffare == "") tCBNACinffare = "0";
            if (tSNACFare == "") tSNACFare = "0";
            if (tDACFare == "") tDACFare = "0";
            if (tDNACFare == "") tDNACFare = "0";
            if (tAWFACFAre == "") tAWFACFAre = "0";
            if (tCWFACFAre == "") tCWFACFAre = "0";
            if (tAWFnonacfare == "") tAWFnonacfare = "0";
            if (tCWFnonacfare == "") tCWFnonacfare = "0";
            decimal amt = 0, TcsVal = 0;
            if (RadAC.Checked)
            {
                Env = "Y";
                amt = Convert.ToDecimal(tAACFAre) * Convert.ToDecimal(txtNoOfAdults.Text);
                amt = amt + (Convert.ToDecimal(tCACFAre) * Convert.ToDecimal(txtNoOfChilds.Text));
                amt = amt + (Convert.ToDecimal(tA2ACFare) * Convert.ToDecimal(txtNoOfAdultsTwin.Text));
                amt = amt + (Convert.ToDecimal(tA3ACFare) * Convert.ToDecimal(txtNoOfAdultsTriple.Text));
                amt = amt + (Convert.ToDecimal(tCBACFare) * Convert.ToDecimal(txtNoOfChildBed.Text));
                amt = amt + (Convert.ToDecimal(tCBACSBfare) * Convert.ToDecimal(txtNoOfChildBedSB.Text));
                amt = amt + (Convert.ToDecimal(tCBACinffare) * Convert.ToDecimal(txtNoOfInfBed.Text));
                amt = amt + (Convert.ToDecimal(tSACFare) * Convert.ToDecimal(txtNoOfSingles.Text));
                amt = amt + (Convert.ToDecimal(tDACFare) * Convert.ToDecimal(txtNoofdormitory.Text));
                amt = amt + (Convert.ToDecimal(tAWFACFAre) * Convert.ToDecimal(txtNoAWFNoOfAdults.Text));
                amt = amt + (Convert.ToDecimal(tCWFACFAre) * Convert.ToDecimal(txtNoCWFNoOfChilds.Text));
            }
            if (RadNAC.Checked)
            {
                Env = "N";
                amt = (Convert.ToDecimal(tAnonacfare) * Convert.ToDecimal(txtNoOfAdults.Text));
                amt = amt + (Convert.ToDecimal(tCnonacfare) * Convert.ToDecimal(txtNoOfChilds.Text));
                amt = amt + (Convert.ToDecimal(tA2NACFare) * Convert.ToDecimal(txtNoOfAdultsTwin.Text));
                amt = amt + (Convert.ToDecimal(tA3NACFare) * Convert.ToDecimal(txtNoOfAdultsTriple.Text));
                amt = amt + (Convert.ToDecimal(tCBNACFare) * Convert.ToDecimal(txtNoOfChildBed.Text));
                amt = amt + (Convert.ToDecimal(tCBNACSBfare) * Convert.ToDecimal(txtNoOfChildBedSB.Text));
                amt = amt + (Convert.ToDecimal(tCBNACinffare) * Convert.ToDecimal(txtNoOfInfBed.Text));
                amt = amt + (Convert.ToDecimal(tSNACFare) * Convert.ToDecimal(txtNoOfSingles.Text));
                amt = amt + (Convert.ToDecimal(tDNACFare) * Convert.ToDecimal(txtNoofdormitory.Text));
                amt = amt + (Convert.ToDecimal(tAWFnonacfare) * Convert.ToDecimal(txtNoAWFNoOfAdults.Text));
                amt = amt + (Convert.ToDecimal(tCWFnonacfare) * Convert.ToDecimal(txtNoCWFNoOfChilds.Text));
            }
            amt = decimal.Round(amt);
            decimal tax, taxamt, ccfee, ccamt, tot;
            #region Optimize Code
            #endregion
            clsAdo pClsObj = null;
            try
            {
                pClsObj = new clsAdo();
                if (Request.QueryString["ltc"] != null)
                {
                    tax = Convert.ToDecimal(DataLib.GetserviceTax("LTC"));
                    List<GetOverrideServiceTax_SPResult> lResult = null;
                    lResult = pClsObj.fnGetOverrideServiceTax(1, ClsCommon.ConvertStringint(
                        Page.RouteData.Values["tourId"]), "");
                    if (lResult != null && lResult.Count > 0)
                    {
                        tax = Convert.ToDecimal(lResult[0].NewTax.ToString());
                    }
                }
                else
                {
                    tax = Convert.ToDecimal(pClsObj.fnGetServiceTaxIsAcc(ClsCommon.ConvertStringint(tourno)));
                }
                taxamt = (amt * (tax / 100));
                ccfee = Convert.ToDecimal(DataLib.GetserviceTax("CC"));
                tot = (amt) + (taxamt);
                ccamt = (tot * (ccfee / 100));
                tot = tot + (ccamt);
                //Tcs val
                if (hdnWam.Value == "1")
                {
                    TcsVal = CalculateTCSAmount(taxamt, amt, ChkFilledTCS.Checked ? 1 : 0);
                    tot = tot + (TcsVal);
                }

                return Convert.ToString(amt + "^" + tax + "^" + taxamt + "^" + ccfee + "^" + ccamt + "^" + tot + "^" + Env);
            }

            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }

            }
        }
        private string ChekAvailability1(int sreq, int tourno, System.DateTime jdate)
        {
            hlmsgerr.Text = "";
            lbMsgErr.Text = "";
            TourSerial = TSerial(jdate, tourno);
            if (RadAC.Checked == true)
                BusEnvType = "Y";
            if (RadNAC.Checked == true)
                BusEnvType = "N";
            DataTable busallot = null;
            string avail = "";
            int tot = 0;

         

            clsAdo pClsObj = null;
            try
            {
                pClsObj = new clsAdo();
                if (Convert.ToString(ViewState["chkbusno"]) != "a")
                    busallot = pClsObj.fnGetBusAllot_Detail(Convert.ToString(TourSerial), BusEnvType, Convert.ToString(ViewState["chkbusno"]));
                else
                    busallot = pClsObj.fnGetBusAllot_Detail(Convert.ToString(TourSerial), BusEnvType, "a");

                if (busallot != null && busallot.Rows.Count > 1)
                    ViewState["MultiPle"] = "Y";
                else
                    ViewState["MultiPle"] = "N";
                for (int i = 0; i < ClsCommon.ConvertStringint(busallot.Rows.Count); i++)
                {
                    int seat = 0;
                    busserial[i] = ClsCommon.ConvertStringint(busallot.Rows[i]["RowId"]);                //totalbuses = totalbuses + 1
                    BusSeaterType = ClsCommon.ConvertStringint(busallot.Rows[i]["BusType"].ToString().Substring(0, 2));
                    seat = GetAvailBusSeat(busserial[i]);
                    AvailSeat = seat;
                    if (sreq <= AvailSeat)
                    {
                        avail = Convert.ToString(AvailSeat) + "-" + busserial[i] + "-" +
                            Convert.ToString(busallot.Rows[i]["busno"]);
                        break;
                    }
                }
                ViewState["tot"] = Convert.ToString(tot);
                if (avail == "")
                    avail = Convert.ToString(AvailSeat);
                if ((sreq > AvailSeat))
                {
                    strEncrypt = DataLib.TripleDESEncode(lblTourName.Text, endecript);
                    if (BusEnvType == "Y")
                        lbMsgErr.Text = "Currently there are Only " + AvailSeat + " seats available " +
                            "in AC bus on your selected date. <br/> You Want to <a href=\"SeatRequestForm." +
                            "aspx?TourName=" + strEncrypt + "\" > Send Request</a> Click here";
                    else
                        lbMsgErr.Text = "Currently there are Only " + AvailSeat + " seats available in " +
                            "Non-AC bus on your selected date. <br/> You Want to <a href=\"SeatRequestForm" +
                            ".aspx?TourName=" + strEncrypt + "\"> Send Request</a> Click here";
                    if ((Request.QueryString["RowId"] != null) || Request.QueryString["OrderId"] != null)
                    {
                        orderid = Convert.ToString(Request.QueryString["OrderId"]);
                        hlmsgerr.Text = "Click here to choose another tour.";
                        strEncrypt = DataLib.TripleDESEncode(orderid, endecript);

                        Session["Panel2Step"] = "Panel2Step";
                        hlmsgerr.NavigateUrl = "Booking-" + Convert.ToString(hdfTourName.Value) + "_" + RemoveSlashAmp(strEncrypt) + "_" +
                                Page.RouteData.Values["tourId"] + "_" + Page.RouteData.Values["jdate"]; ;
                      

                    }
                    return avail;
                }
                return avail;
            }

            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (busallot != null)
                {
                    busallot.Dispose();
                    busallot = null;
                }
            }
        }
        private string ChekAvailabilitymultiple(int sreq, int tourno, System.DateTime jdate)
        {
            hlmsgerr.Text = "";
            lbMsgErr.Text = "";
            TourSerial = TSerial(jdate, tourno);
            if (RadAC.Checked == true)
                BusEnvType = "Y";
            if (RadNAC.Checked == true)
                BusEnvType = "N";
            DataTable busallot = null;
            string avail = "", seatertype = "", busno = "", seril = "";
            int tot = 0;
            #region Optimize Code
            /*SqlParameter[] parambus = new SqlParameter[2];
            parambus[0] = new SqlParameter("@TourSerial", TourSerial);
            parambus[1] = new SqlParameter("@BusEnvType", BusEnvType);
            busallot = DataLib.GetDataTableWithparam(DataLib.Connection.ConnectionString, 
                "Select * from busallot where TourSerial=@TourSerial and AC=@BusEnvType and " + 
                "(active='Y' or active='y') order by busno", parambus);*/
            #endregion
            clsAdo pClsObj = null;
            try
            {
                pClsObj = new clsAdo();
                busallot = pClsObj.fnGetBusAllot_Detail(Convert.ToString(TourSerial), BusEnvType, "a");
                if (busallot != null && busallot.Rows.Count > 1)
                    ViewState["MultiPle"] = "Y";
                else
                    ViewState["MultiPle"] = "N";
                AvailSeat = 0;
                for (int i = 0; i < ClsCommon.ConvertStringint(busallot.Rows.Count); i++)
                {
                    int seat = 0;
                    busserial[i] = ClsCommon.ConvertStringint(busallot.Rows[i]["RowId"]);                //totalbuses = totalbuses + 1
                    BusSeaterType = ClsCommon.ConvertStringint(busallot.Rows[i]["BusType"].ToString().Substring(0, 2));
                    if (busno == "")
                        busno = Convert.ToString(busallot.Rows[i]["BusNo"]);
                    else
                        busno = busno + "*" + Convert.ToString(busallot.Rows[i]["BusNo"]);
                    if (seatertype == "")
                        seatertype = Convert.ToString(BusSeaterType);
                    else
                        seatertype = seatertype + "@" + Convert.ToString(BusSeaterType);
                    if (seril == "")
                        seril = Convert.ToString(busserial[i]);
                    else
                        seril = seril + "$" + Convert.ToString(busserial[i]);
                    seat = GetAvailBusSeat(busserial[i]);
                    AvailSeat = AvailSeat + seat;
                    tot = tot + seat;
                    if (sreq <= AvailSeat)
                    {
                        avail = Convert.ToString(AvailSeat) + "-" + seril + "-" + seatertype + "-" + busno;
                        break;
                    }
                    else
                        avail = Convert.ToString(AvailSeat) + "-" + seril + "-" + seatertype + "-" + busno;
                }
                ViewState["tot"] = Convert.ToString(tot);
                if (avail == "")
                    avail = Convert.ToString(AvailSeat);
                return avail;
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (busallot != null)
                {
                    busallot.Dispose();
                    busallot = null;
                }
            }
        }
        private void refresh()
        {
            btncheckavail.Enabled = false;
            AssignValue();
            AssignOrderID();
            orderid = OrderIDH.Value;
            Tourno = ClsCommon.ConvertStringint(DataLib.funClear(Page.RouteData.Values["tourId"]?.ToString()));
        }
        private void AssignOrderID()
        {

            if ((Request.QueryString["orderid"] != " ") && (Request.QueryString["orderid"] != null) && Request.QueryString["orderid"] != "" && Request.QueryString["orderid"] != "0")
            {
                OrderIDH.Value = Request.QueryString["orderid"].ToString();
                prevadu.Value = Convert.ToString(DataLib.funClear(Request.QueryString["A"]));
                prevchi.Value = Convert.ToString(DataLib.funClear(Request.QueryString["C"]));
                order.Value = Request.QueryString["orderid"].ToString();
                strEncrypt = DataLib.TripleDESEncode(OrderIDH.Value, endecript);
                if ((Request.QueryString["ltc"] == null) || (Request.QueryString["ltc"] == "0"))
                {
                    if (Session["BookMore"] != null)
                    {
                        Session["Panel2Step"] = null;
                        hlback.Visible = true;
                    }
                    else
                    {
                        Session["Panel2Step"] = "Panel2Step";
                    }
                    if (Request.QueryString["IsEdit"] != null)
                    {
                        Session["Panel2Step"] = null;
                        hlback.Visible = true;
                    }
                }
                else
                {
                    if (Session["BookMore"] != null)
                    {
                        Session["Panel2Step"] = null;
                        hlback.Visible = true;
                    }
                    else
                    {
                        Session["Panel2Step"] = "Panel2Step";
                    }
                    if (Request.QueryString["IsEdit"] != null)
                    {
                        Session["Panel2Step"] = null;
                        hlback.Visible = true;
                    }

                }
            }
            else
            {
                try
                {
                    OrderIDH.Value = DataLib.pnr();
                }
                catch { }
            }
        }
        private string validateDiscount(DateTime pJDate)
        {
            clsAdo pClsObj = null;
            try
            {
                string validateDiscount = "";
                pClsObj = new clsAdo();
                validateDiscount = pClsObj.fnValidateDiscount(pJDate, ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]));
                return validateDiscount;
            }

            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }

            }
          
        }
        private string ChkBusType(DateTime pJDate)
        {
            clsAdo pClsObj = null;
            try
            {
                string ChkBusType = "";
                pClsObj = new clsAdo();
                ChkBusType = pClsObj.fnChkBusType(pJDate, ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]));
                return ChkBusType;
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }

            }
           
        }
        private void AssignValue()
        {
            tAACFAre = lblAACfare.Text.ToString();
            tAnonacfare = lblANACfare.Text.ToString();
            tCACFAre = lblCACfare.Text.ToString();
            tCnonacfare = lblCNACfare.Text.ToString();
            tA2ACFare = lblA2ACfare.Text.ToString();
            tA2NACFare = lblA2NACfare.Text.ToString();
            tA3ACFare = lblA3ACfare.Text.ToString();
            tA3NACFare = lblA3NACfare.Text.ToString();
            tCBACFare = lblCBACfare.Text.ToString();
            tCBNACFare = lblCBNACfare.Text.ToString();
            tCBACSBfare = lblCBACSBfare.Text.ToString();
            tCBNACSBfare = lblCBNACSBfare.Text.ToString();
            tCBACinffare = lblCBACinffare.Text.ToString();
            tCBNACinffare = lblCBNACinffare.Text.ToString();
            tSACFare = lblSACfare.Text.ToString();
            tSNACFare = lblSNACfare.Text.ToString();
            tDACFare = lbldACfare.Text.ToString();
            tDNACFare = lbldNACfare.Text.ToString();
            tAWFACFAre = lblAWFfare.Text.ToString();
            tAWFnonacfare = lblAWFNACfare.Text.ToString();
            tCWFACFAre = lblCWFfare.Text.ToString();
            tCWFnonacfare = lblCWFNACfare.Text.ToString();

        }
        private int TSerial(DateTime jdate, int tourno)
        {
            string hr = ConfigurationManager.AppSettings["CustomerFixedTourHours"].ToString();
            clsAdo clsObj = null;
            DataTable ldtRecSet = null;
            try
            {
                clsObj = new clsAdo();
                ldtRecSet = clsObj.fnFixed_TourSerial(jdate, hr, tourno);
                if (ldtRecSet != null && ldtRecSet.Rows.Count > 0)
                {
                    return ClsCommon.ConvertStringint(ldtRecSet.Rows[0][0]);
                }
                else
                {
                    return -1;
                }
            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
                if (ldtRecSet != null)
                {
                    ldtRecSet.Dispose();
                    ldtRecSet = null;
                }
            }
        }
        private string RemoveSlashAmp(string EncrptStr)
        {
            string TempEnstr = EncrptStr;
            if (!string.IsNullOrEmpty(EncrptStr))
            {
                TempEnstr = EncrptStr.Replace("/", "SlashSlash");
                TempEnstr = TempEnstr.Replace("&", "AmpAmp").Replace("+", "plusplus");
            }
            return TempEnstr;
        }

        private void BindPlace()
        {
            if (Page.RouteData.Values["jdate"] != null && Page.RouteData.Values["jdate"] != "")
            {
                string[] lJDate = Page.RouteData.Values["jdate"].ToString().Split('/');
                lblJDate.Text = (new DateTime(ClsCommon.ConvertStringint(lJDate[2]), ClsCommon.ConvertStringint(lJDate[0]), ClsCommon.ConvertStringint(lJDate[1]))).ToString("dd-MMM-yyyy");
            }
            List<GetTourPlaceInfo_SPResult> lGetPlaceName = null;
            ClsCommon objOther = new ClsCommon();

            try
            {
                lGetPlaceName = new List<GetTourPlaceInfo_SPResult>();

                lGetPlaceName = objOther.fnGetTourPlaceInfo(ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]), 1).ToList();
                if (lGetPlaceName != null && lGetPlaceName.Count > 0)
                {

                    int lCtr = 1;
                    int lCounter = 1;
                    string htmlTourPlace = "";
                    htmlTourPlace += "<ul class=\"placeslist\">";
                    for (int iCtr = 0; iCtr < lGetPlaceName.Count; iCtr++)
                    {
                        if (!htmlTourPlace.Contains(lGetPlaceName[iCtr].PlaceName.ToString()))
                        {
                            htmlTourPlace += "<li><span class=\"glyphicon glyphicon-ok\"></span>" + lGetPlaceName[iCtr].PlaceName.ToString() + "</li>";
                          
                        }
                        lCounter++;
                    }
                    htmlTourPlace += "</ul>";
                    ltrplaceslist.Text = htmlTourPlace;
                    BindTourItenerary(htmlTourPlace);
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

                if (objOther != null)
                {
                    objOther = null;
                }
            }
        }
        private void BindTourItenerary(string lhtmlTourPlace)
        {
            List<TourItenerary_SPResult> lGetResult = null;
            clsAdo objOther = new clsAdo();

            try
            {
                lGetResult = new List<TourItenerary_SPResult>();

                lGetResult = objOther.fnGetTourItenerary(ClsCommon.ConvertStringint(Page.RouteData.Values["tourId"]), 1).ToList();
                if (lGetResult != null && lGetResult.Count > 0)
                {ltrNotes.Text = lGetResult[0].Notes.ToString().Replace("<p>", "").Replace("</p>", "").Replace("color: #ffffff", "color: #000000");

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

        private void ModifyMetaTag(int pTourID)
        {

            ClsCommon objOther = new ClsCommon();
            try
            {
                int TourId, CountryID, ZoneId;
                TourId = pTourID;
                ZoneId = 0; CountryID = 0;
                //DataTable dtM = objOther.fnGetMetaTagForTours(ClsCommon.ConvertStringint(TOURTYPE.FIXED_TOUR), TourId, CountryID, ZoneId);
                DataTable dtM = objOther.fnGetMetaTagForTours(Request.QueryString["ltc"] != null ? ClsCommon.ConvertStringint(TOURTYPE.LTC_FIXED_TOUR_BOOKING) : ClsCommon.ConvertStringint(TOURTYPE.FIXED_TOUR_BOOKING), TourId, CountryID, ZoneId);
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
                                if (htmnewmeta != null)
                                {
                                    hd.Controls.Add(htmnewmeta);
                                }
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

        #endregion
        #region "Method(s) Final Booking"
        private void BindProFile()
        {
            DataTable dtdetails = null;
            clsAdo clsObj = null;
            try
            {
                clsObj = new clsAdo();

                dtdetails = clsObj.fnonlinecustomer_details(ClsCommon.ConvertStringint(Session["custrowid"]));
                if (dtdetails != null && dtdetails.Rows.Count > 0)
                {
                    ViewState["rowid"] = Convert.ToString(dtdetails.Rows[0]["RowID"]);
                    emailid.Attributes.Add("readonly", "readonly");
                    txtMail.Attributes.Add("readonly", "readonly");
                    txtMobile.Attributes.Add("readonly", "readonly");
                    if (dtdetails.Rows[0]["email"].ToString().Contains("temp"))
                    {
                        emailid.Text = Convert.ToString(dtdetails.Rows[0]["Mobile"]);
                    }
                    else
                    {
                        emailid.Text = Convert.ToString(dtdetails.Rows[0]["email"]);
                    }
                    txtAddress.Text = Convert.ToString(dtdetails.Rows[0]["Addr1"]);

                    txtMail.Text = Convert.ToString(dtdetails.Rows[0]["email"]);

                    txtName.Text = Convert.ToString(dtdetails.Rows[0]["FirstName"]);
                    txtMobile.Text = Convert.ToString(dtdetails.Rows[0]["Mobile"]);
                    if (dtdetails.Rows[0]["PhoneNo"] != null)
                    {
                        if (dtdetails.Rows[0]["PhoneNo"].ToString().Contains('-'))
                        {
                            string[] strPh = dtdetails.Rows[0]["PhoneNo"].ToString().Split('-');
                            txtPhoneCountryCode.Text = Convert.ToString(strPh[0]);
                            txtPhone.Text = Convert.ToString(strPh[1]);
                        }
                        else
                        {
                            txtPhone.Text = Convert.ToString(dtdetails.Rows[0]["PhoneNo"].ToString());
                        }
                    }
                    try
                    {
                        ddlState.SelectedValue = Convert.ToString(GetStateID(dtdetails.Rows[0]["state"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        ClsCommon.LogAndSendError(ex.ToString() + " Tour Booking Page - select state");
                    }
                    Session["LoggedInUserName"] = Convert.ToString(dtdetails.Rows[0]["FirstName"]) + " " + Convert.ToString(dtdetails.Rows[0]["LastName"]);
                }
                existingcustomer(ClsCommon.ConvertStringint(Session["custrowid"]), Convert.ToString(ViewState["strDeCrypt"]));
            }
            catch (Exception ex)
            {
                ClsCommon.LogAndSendError(ex.ToString() + " Tour Booking Page - BindProfile");
            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
                if (dtdetails != null)
                {
                    dtdetails.Dispose();
                    dtdetails = null;
                }
            }
        }

        public void DoEdit(object sender, DataGridCommandEventArgs e)
        {

        }
        protected void dgtourdt_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgtourdt.EditIndex = -1;
            emailid.Text = "";
            FillDgtour();
        }
        public void DoCancel(object sender, DataGridCommandEventArgs e)
        {
        }
        protected void dgtourdt_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void dgtourdt_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable unblock = null;
            clsAdo pClsObj = null;
            try
            {
                pClsObj = new clsAdo();


                emailid.Text = "";
                DropDownList doj;
                string journdate, bus = "";
                int totalpax = 0, available = 0, tourserial = 0;
                GridViewRow row = dgtourdt.Rows[e.RowIndex];
                bus = row.Cells[6].Text;
                if (bus == "AC")
                {
                    bus = "Y";
                }
                else if (bus == "Non-AC")
                {
                    bus = "N";
                }
                DateTime dt;
                string pRowID = dgtourdt.DataKeys[e.RowIndex].Values[0].ToString(); //dgtourdt.DataKeys[e.Item.ItemIndex].ToString();

                strtourid = Convert.ToString(pClsObj.fnGet_RowWiseTourID(ClsCommon.ConvertStringint(pRowID)));
                totalpax = (ClsCommon.ConvertStringint(ViewState["TotalPaxAdults"]) + ClsCommon.ConvertStringint(ViewState["TotalPaxChilds"]));
                doj = (DropDownList)(row.FindControl("cmbdoj"));
                journdate = doj.Text.ToString();
                dt = Convert.ToDateTime(doj.SelectedValue.ToString());
                available = ChekAvailability1(totalpax, ClsCommon.ConvertStringint(strtourid), Convert.ToDateTime(journdate), bus);
                int tourNo = ClsCommon.ConvertStringint(strtourid);

                tourserial = pClsObj.fnGet_TourWiseTourSr(tourNo, Convert.ToDateTime(journdate));

                if (totalpax <= available)
                {

                    int? iRowID = ClsCommon.ConvertStringint(dgtourdt.DataKeys[e.RowIndex]);
                    unblock = pClsObj.fnGetSeatDetail(iRowID);
                    if (unblock != null && unblock.Rows.Count > 0)
                    {
                        string preseat = Convert.ToString(unblock.Rows[0]["seatNo"]);
                        string serialno = Convert.ToString(unblock.Rows[0]["busserialno"]);
                        string[] seatnumbers = preseat.Split(',');
                        string[] ser = serialno.Split(',');
                        string numbers = "";
                        string tempstr = "";
                        if (ser.Length > 1)
                        {
                            for (int k = 0; k < ser.Length; k++)
                            {
                                tempstr = "";
                                for (int i = 0; i < seatnumbers.Length; i++)
                                {
                                    if (seatnumbers[i].Length > 3)
                                    {
                                        if (seatnumbers[i].Substring(1, 1) == Convert.ToString(k + 1))
                                        {
                                            numbers = "s" + seatnumbers[i].Substring(2, 2);
                                            tempstr = tempstr + "," + numbers;
                                        }
                                    }
                                    else
                                    {
                                        if (seatnumbers[i].Substring(1, 1) == Convert.ToString(k + 1))
                                        {
                                            numbers = "s" + seatnumbers[i].Substring(2, 1);
                                            tempstr = tempstr + "," + numbers;
                                        }
                                    }
                                }

                                tempstr = tempstr.Replace(",,", ",").TrimStart(',').TrimEnd(',');
                                doUnBlock(tempstr, ClsCommon.ConvertStringint(ser[k]));
                            }
                        }
                        else
                        {
                            doUnBlock(preseat, ClsCommon.ConvertStringint(ser[0]));
                        }
                    }
                    string seat = returnseat(totalpax, Convert.ToString(BusSeaterType));
                    int busserialno = ClsCommon.ConvertStringint(ViewState["busserial"]);
                    doBlock(seat, busserialno);
                    int? pRowid = ClsCommon.ConvertStringint(dgtourdt.DataKeys[e.RowIndex]);

                    int val = pClsObj.fnUpdaterTourDeatil(pRowid, Convert.ToDateTime(journdate), Convert.ToString(tourserial), Convert.ToString(busserialno), seat);
                    if (val > 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Update", "<script>alert('Updated Successfully !')</script>");
                        dgtourdt.EditIndex = -1;
                        FillDgtour();
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "startupUpdate", "<script>alert('Seats Are Not Available!')</script>");
                    dgtourdt.EditIndex = -1;
                    FillDgtour();
                }
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (unblock != null)
                {
                    unblock.Dispose();
                    unblock = null;
                }
            }
        }
        private void fillddlJdate(int TourNo)
        {
            #region Optimize Code
            /* DataTable dt;
            string hr = ConfigurationManager.AppSettings["CustomerFixedTourHours"].ToString();
            hr = "-" + hr;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@hr",hr);
            param[1] = new SqlParameter("@TourNo",TourNo);
            dt = DataLib.GetDataTableWithparam(DataLib.Connection.ConnectionString, "select distinct(JourneyDate) as doj 
             * from Tours a,busallot b where dateadd(hour," + @hr + ",journeydate)>=getdate() and TourNo=@TourNo  
             * and b.tourserial=a.rowid and b.active='Y' order by journeydate DESC",param);*/
            #endregion
            string hr = ConfigurationManager.AppSettings["CustomerFixedTourHours"].ToString();
            hr = "-" + hr;
            DataTable dt = null;
            clsAdo pClsObj = null;
            try
            {
                pClsObj = new clsAdo();
                dt = pClsObj.fnGetJourneyDate(ClsCommon.ConvertStringint(hr), TourNo);


                TempDataView = new DataView();
                TempDataView = dt.DefaultView;
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
            }
        }
        protected void dgtourdt_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }
        public void DoUpdate(object sender, DataGridCommandEventArgs e)
        {
           
        }

        private int ChekAvailability1(int sreq, int tourno, System.DateTime jdate, string bustype)
        {
            #region Optimize Code
            /*string str1;
            int TourSerial1 = 0;        
            str1 = "Select RowId from Tours where datediff(\"d\",'" + jdate + "',JourneyDate) = 0 and TourNo=" + tourno + "";
            TourSerial1 = ClsCommon.ConvertStringint(DataLib.GetStringData(DataLib.Connection.ConnectionString, str1));*/
            #endregion


            #region Optimize Code
            /*SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@TourSerial",TourSerial);
            param[1] = new SqlParameter("@bustype",bustype);
            busallot = DataLib.GetDataTableWithparam(DataLib.Connection.ConnectionString, "Select * from busallot where TourSerial=@TourSerial 
             * and AC=@bustype and (active='Y' or active='y')",param);*/
            #endregion
            clsAdo pClsObj = null;
            DataTable busallot = null;
            try
            {
                pClsObj = new clsAdo();
                int TourSerial = pClsObj.fnGet_TourWiseTourSr(tourno, jdate);

                busallot = pClsObj.fnGetBusAllot_Detail(Convert.ToString(TourSerial), bustype, "a");
                for (int i = 0; i < ClsCommon.ConvertStringint(busallot.Rows.Count); i++)
                {
                    int seat = 0;
                    busserial[i] = ClsCommon.ConvertStringint(busallot.Rows[i]["RowId"]);                //totalbuses = totalbuses + 1
                    ViewState["busserial"] = Convert.ToString(busallot.Rows[i]["RowId"]);
                    BusSeaterType = ClsCommon.ConvertStringint(busallot.Rows[i]["BusType"].ToString().Substring(0, 2));
                    seat = GetAvailBusSeat(busserial[i]);
                    if (sreq <= seat)
                    {
                        AvailSeat = AvailSeat + seat;
                        break;
                    }
                    else
                    {
                        AvailSeat = 0;
                    }
                }
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (busallot != null)
                {
                    busallot.Dispose();
                    busallot = null;
                }
            }
            return AvailSeat;
        }

        private string returnseat(int seatreq, string seattype)
        {
            int tmp;
            int tmp1;
            int seat = ClsCommon.ConvertStringint(seattype);
            string tmpstr;
            tmp1 = seatreq;
            tmpstr = "";
            for (tmp = 1; tmp <= seat; tmp++)
            {
                if (nseats[tmp] == 1)
                {
                    tmpstr = tmpstr + "s" + tmp + ",";
                    tmp1 = tmp1 - 1;
                    if (tmp1 == 0)
                    {
                        break;
                    }
                }
                else
                {
                }
            }
            return tmpstr;
        }
        public void pageload()//----------page load of customer details------------------------------//
        {
            this.Submit1.Attributes.Add("onclick", "return doValidate2();");
        }
        public void existingcustomer(int rowid, string orderid)
        {
            #region Optimize Code
            /* orderid = ViewState["strDeCrypt"].ToString();       
           SqlParameter[] param = new SqlParameter[1];
             * param[0] = new SqlParameter("@orderid",orderid);
            sqlreadexist = Convert.ToInt32(DataLib.GetStringDataWithParam(DataLib.Connection.ConnectionString, "select count(*) from onlinecustbyorder where orderid=@orderid",param));       
            SqlParameter[] param1 = new SqlParameter[1];
            param1[0] = new SqlParameter("@rowid",rowid);
            string emailID = DataLib.GetStringDataWithParam(DataLib.Connection.ConnectionString, "select email from OnlineCustomer where rowid=@rowid",param1);      
            SqlParameter[] param2 = new SqlParameter[1];
            param2[0] = new SqlParameter("@emailID",emailID);
            string str1 = "SELECT   * FROM  OnlineCustomer WHERE  email = @emailID ";
            DataTable dtX = DataLib.GetDataTableWithparam(DataLib.Connection.ConnectionString, str1,param2);*/
            #endregion
            GST_Data pClsGST = null;
            DataTable dtX = null;
            try
            {
                pClsGST = new GST_Data();
                dtX = pClsGST.GST_fnExistCustomerDetail(orderid, rowid);


                if (dtX != null && dtX.Rows.Count > 0)
                {
                    Session["custrowid"] = dtX.Rows[0]["RowId"].ToString();
                    txtName.Attributes.Add("readonly", "readonly");
                    txtMail.Attributes.Add("readonly", "readonly");

                    txtName.Text = dtX.Rows[0]["FirstName"].ToString();
                    try
                    {
                        ddlTitle.SelectedValue = dtX.Rows[0]["Title"].ToString();
                    }
                    catch { }
                    txtAddress.Text = dtX.Rows[0]["Addr1"].ToString();

                    if (DBNull.Value != dtX.Rows[0]["Country"] && dtX.Rows[0]["Country"].ToString() != "")
                    {
                        BindCountryName();
                        try
                        {
                            ddlCountry.Items.FindByValue(Convert.ToString(dtX.Rows[0]["Country"])).Selected = true;
                        }
                        catch
                        {
                            ddlCountry.Items.FindByText(Convert.ToString(dtX.Rows[0]["Country"])).Selected = true;
                        }

                        if (Convert.ToString(dtX.Rows[0]["Country"]) == "59" || Convert.ToString(dtX.Rows[0]["Country"]).ToLower() == "india")
                        {
                            divState.Style["display"] = "block";
                            txtCity.Style["display"] = "block";
                            TxtForeignState.Style["display"] = "none";
                            txtForeignCity.Style["display"] = "none";
                            try
                            {
                                txtCity.Text = dtX.Rows[0]["City"].ToString();
                                //ddlCity.SelectedValue = dtX.Rows[0]["City"].ToString();
                            }
                            catch { }
                            string s;
                            BindStateName();
                            s = GetStateID(dtX.Rows[0]["state"].ToString());
                            if (s.Length > 0)
                            {
                                try
                                {
                                    ddlState.SelectedValue = char.ToUpper(Convert.ToChar(s.Substring(0, 1))).ToString() + s.Substring(1, s.Length - 1);
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            divState.Style["display"] = "none";
                            txtCity.Style["display"] = "none";
                            TxtForeignState.Style["display"] = "block";
                            txtForeignCity.Style["display"] = "block";
                            TxtForeignState.Text = dtX.Rows[0]["state"].ToString();
                            txtForeignCity.Text = dtX.Rows[0]["City"].ToString();
                        }
                    }
                    if (DBNull.Value != dtX.Rows[0]["Nationality"] && dtX.Rows[0]["Nationality"].ToString() != "")
                    {
                        BindNationalityName();
                        if (ddlNationality.Items.FindByValue(dtX.Rows[0]["Nationality"].ToString()) != null)
                            ddlNationality.Items.FindByValue(dtX.Rows[0]["Nationality"].ToString()).Selected = true;
                    }


                    //else
                    //{
                    //    ddlNationality.Items.FindByValue("0").Selected = true;
                    //}
                    txtAadharNo.Text = dtX.Rows[0]["Aadharno"].ToString();
                    //BindStateName();

                    //BindCityName();

                    txtMobile.Text = dtX.Rows[0]["Mobile"].ToString();
                    txtAlternateMobileNo.Text = dtX.Rows[0]["AlternativeNo"].ToString();
                    txtMail.Text = dtX.Rows[0]["email"].ToString();
                    Session["EmailId"] = txtMail.Text;
                    if (dtX.Rows[0]["PhoneNo"].ToString().IndexOf("-") != -1)
                    {
                        string[] tempPhone = dtX.Rows[0]["PhoneNo"].ToString().Split('-');
                        txtPhoneCountryCode.Text = tempPhone[0];
                        txtPhone.Text = tempPhone[1];
                    }
                    else
                    {
                        txtPhone.Text = dtX.Rows[0]["PhoneNo"].ToString();
                    }
                    bool isGSTIN = DBNull.Value != dtX.Rows[0]["ISGSITIN"] ? Convert.ToBoolean(dtX.Rows[0]["ISGSITIN"]) : false;
                    string customerGSTIN = DBNull.Value != dtX.Rows[0]["CustomerGSTIN"] ? Convert.ToString(dtX.Rows[0]["CustomerGSTIN"]) : "";
                    string GSTINHolderName = DBNull.Value != dtX.Rows[0]["GstHolderName"] ? Convert.ToString(dtX.Rows[0]["GstHolderName"]) : "";
                    if (isGSTIN)
                    {
                        rdbIsGSTApplicableYes.Checked = true;
                        rdbIsGSTApplicableNo.Checked = false;
                        divGSTDetails.Style["display"] = "";
                        txtCustomerGSTIN.Text = customerGSTIN;
                        txtGstHolderName.Text = GSTINHolderName;
                    }
                    else
                    {
                        rdbIsGSTApplicableYes.Checked = false;
                        rdbIsGSTApplicableNo.Checked = true;
                        divGSTDetails.Style["display"] = "none";
                        txtCustomerGSTIN.Text = "";
                        txtGstHolderName.Text = "";
                    }

                    chkPromotions.Checked = Convert.ToBoolean(dtX.Rows[0]["CanSendPromotions"] != DBNull.Value ?
                       Convert.ToInt32(dtX.Rows[0]["CanSendPromotions"]) : 1);
                }
                else
                {
                    txtName.Attributes.Remove("readonly");
                    txtName.Text = "";
                    txtAddress.Text = "";
                    ddlState.SelectedValue = "";
                    if (type.Value == "email")
                    {
                        txtMobile.Text = "";
                        txtMail.Text = emailid.Text;
                    }
                    else if (type.Value == "Mobile")
                    {
                        txtMobile.Text = emailid.Text;
                        txtMail.Text = "";
                    }
                    txtPhone.Text = "";
                    txtPhoneCountryCode.Text = "";
                    chkPromotions.Checked = true;
                    if (ddlNationality.Items.FindByValue("0") != null)
                    {
                        ddlNationality.SelectedValue = "0";
                    }

                    txtAadharNo.Text = "";
                }
            }

            finally
            {
                if (pClsGST != null)
                {
                    pClsGST = null;
                }
                if (dtX != null)
                {
                    dtX.Dispose();
                    dtX = null;
                }
            }
        }

        Boolean promocheck()
        {
            clsAdo pClsObj = null;
            if (promocode.Text.Trim() != "")
            {
                #region Optimize Code
                /*SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@promocode", promocode.Text);
                DataSet dspromo = DataLib.GetStoredProcData(DataLib.Connection.ConnectionString, "Check_Promocode", param);*/
                #endregion
                DataTable ldtRecSet = null;
                try
                {
                    pClsObj = new clsAdo();
                    ldtRecSet = pClsObj.fnCheck_Promocode(promocode.Text);
                    if (ldtRecSet != null && ldtRecSet.Rows.Count > 0)
                    {
                        if (ClsCommon.ConvertStringint(ldtRecSet.Rows[0][0]) == 1)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    if (pClsObj != null)
                    {
                        pClsObj = null;
                    }
                    if (ldtRecSet != null)
                    {
                        ldtRecSet.Dispose();
                        ldtRecSet = null;
                    }
                }
            }
            else
                return true;
        }
        private void FillDgtour()
        {
            string strdecode = ViewState["strDeCrypt"].ToString();
            #region Optimize Code
            /*SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@strdecode", strdecode);
            string str = "SELECT OnlineToursBooking.rowid as rowid,(OnlineToursBooking.CalcTaxvalue+OnlineToursBooking.CalcCreditCardFee) as CalcTaxvalue, OnlineToursBooking.orderid, TourMaster.TourName, convert(varchar(10),OnlineToursBooking.doj,103) as doj, OnlineToursBooking.dob,convert(varchar(10),tours.ReturnDate,103)as ReturnDate,PickUpMaster.departtime,case OnlineToursBooking.BusEnvType when 'Y' then 'AC' when 'N' then 'Non-AC' end as BusEnvType,OnlineToursBooking.tourid,OnlineToursBooking.noofadults,OnlineToursBooking.noofchild,OnlineToursBooking.NoofAdultsTwin,OnlineToursBooking.NoofAdultsTriple,OnlineToursBooking.ChildWithoutbed,OnlineToursBooking.SingleAdult,OnlineToursBooking.dormitory,OnlineToursBooking.amount,OnlineToursBooking.tax,OnlineToursBooking.totalamount,OnlineToursBooking.CreditCardFee,TourMaster.Tour_Short_key,OnlineToursBooking.MinimumPay  FROM OnlineToursBooking INNER JOIN TourMaster ON OnlineToursBooking.tourid = TourMaster.TourNo INNER JOIN PickUpMaster ON OnlineToursBooking.tourid = PickUpMaster.TourNo and pickupmaster.rowid=OnlineToursBooking.pickuppointid INNER JOIN PickupAddress ON PickUpMaster.RowId = PickupAddress.PickupMasterRowId inner join Tours on tours.Tourno=OnlineToursBooking.tourid and tours.rowid= OnlineToursBooking.tourserial and datediff(d,tours.Journeydate,OnlineToursBooking.doj)=0 AND OnlineToursBooking.orderid = @strdecode ORDER BY OnlineToursBooking.rowid ";
            DataTable dtTourDisp = DataLib.GetDataTableWithparam(DataLib.Connection.ConnectionString, str, param);*/
            #endregion
            clsAdo pClsObj = null;
            DataSet ldsRecSet = null;
            DataTable dtTourDisp = null;
            try
            {
                pClsObj = new clsAdo();
                ldsRecSet = pClsObj.fnGetToursBookingInfo(strdecode);
                if (ldsRecSet != null)
                {
                    dtTourDisp = ldsRecSet.Tables[0];
                }

                if (dtTourDisp != null && dtTourDisp.Rows.Count > 0)
                {
                    BindTourItenerary(ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["tourid"].ToString()));
                    ModifyMetaTag(ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["tourid"].ToString()));
                    string[] lJDate = dtTourDisp.Rows[0]["doj"].ToString().Split('/');
                    DateTime lQStrJDate = new DateTime(ClsCommon.ConvertStringint(lJDate[2]), ClsCommon.ConvertStringint(lJDate[1]),
                        ClsCommon.ConvertStringint(lJDate[0]));

                    UcModifySearch1.fldJDate = lQStrJDate.ToString("dddd, MMMM d, yyyy");


                    Session["TravelSector"] = Convert.ToString(dtTourDisp.Rows[0]["Tour_Short_key"]);
                    adults = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["noofadults"].ToString());
                    childs = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["noofchild"].ToString());
                    adulttwin = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["NoofAdultsTwin"].ToString());
                    adulttriple = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["NoofAdultsTriple"].ToString());
                    childwithoutbed = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["ChildWithoutbed"].ToString());
                    singleadult = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["SingleAdult"].ToString());
                    dormitory = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["dormitory"].ToString());
                    ADWFood = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["noAdultWithFood"].ToString());
                    CWFood = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["noChildWithFood"].ToString());
                    if ((strtourid) == "")
                    {
                        fillddlJdate(ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["tourid"].ToString()));
                    }
                    else
                    {
                        fillddlJdate(ClsCommon.ConvertStringint(strtourid));
                    }
                    tourid = ClsCommon.ConvertStringint(dtTourDisp.Rows[0]["tourid"].ToString());
                    ViewState["tourid"] = Convert.ToString(tourid);
                    dgtourdt.DataSource = dtTourDisp;
                    dgtourdt.DataBind();
                    #region Optimize Code
                    /*string oID = ViewState["strDeCrypt"].ToString();
                SqlParameter[] param1 = new SqlParameter[1];
                param1[0] = new SqlParameter("@orderid", oID);
                GrandTotal = decimal.Round(Convert.ToDecimal(DataLib.GetStringDataWithParam(DataLib.Connection.ConnectionString, "select sum(totalamount) from OnlineToursBooking where orderid=@orderid", param1)));*/
                    #endregion
                    GrandTotal = decimal.Round(Convert.ToDecimal(ldsRecSet.Tables[1].Rows[0]["totalamount"]));
                    ViewState["GrandTotal"] = GrandTotal;
                    Session["MinAmt"] = GrandTotal;
                    GrandTotal = Convert.ToDecimal(string.Format("{0:n}", GrandTotal));

                    hdAmount.Value = Convert.ToString(ldsRecSet.Tables[0].Rows[0]["amount"]);
                    hdStax.Value = Convert.ToString(ldsRecSet.Tables[0].Rows[0]["tax"]);


                    #region Optimize Code
                    //To find the Total of Minimum To be paid Amount----------------

                    /* SqlParameter[] strMinPay = new SqlParameter[1];
                     strMinPay[0] = new SqlParameter("@orderid", oID);
                     PayNowTotal = decimal.Round(Convert.ToDecimal(DataLib.GetStringDataWithParam(DataLib.Connection.ConnectionString, "select sum(minimumPay) from OnlineToursBooking where orderid=@orderid", strMinPay)));*/
                    #endregion

                    PayNowTotal = decimal.Round(Convert.ToDecimal(ldsRecSet.Tables[2].Rows[0]["minimumPay"]));
                    ViewState["PayNow"] = PayNowTotal;
                    Session["Amt"] = ViewState["PayNow"].ToString();
                    TotalPaxAdults = (adults + adulttwin + adulttriple + singleadult + ADWFood);
                    ViewState["TotalPaxAdults"] = TotalPaxAdults;
                    TotalPaxChilds = (childs + childwithoutbed + CWFood + dormitory);
                    ViewState["TotalPaxChilds"] = TotalPaxChilds;
                    Session["Adults"] = TotalPaxAdults;
                    Session["Childs"] = TotalPaxChilds;
                    this.lblNoofAdults.Text = Convert.ToString(TotalPaxAdults);
                    this.lblNoofchild.Text = Convert.ToString(TotalPaxChilds);
                }
                else
                {
                    dgtourdt.DataSource = null;
                    dgtourdt.DataBind();
                    Response.Redirect("index.aspx");
                }
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (ldsRecSet != null)
                {
                    ldsRecSet.Dispose();
                    ldsRecSet = null;
                }
                if (dtTourDisp != null)
                {
                    dtTourDisp.Dispose();
                    dtTourDisp = null;
                }
            }
        }
        private void deleteTours()
        {
            clsAdo pClsObj = null;
            string str1, i = "";
            foreach (GridViewRow di in dgtourdt.Rows)
            {
                bool checksel = ((CheckBox)di.Cells[1].FindControl("chkdelete")).Checked;
                if (checksel == true)
                {
                    i = dgtourdt.DataKeys[di.RowIndex] + "," + i;
                }
            }
            #region Optimize Code
            /*SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@i", i);
            str1 = "DELETE FROM OnlineToursBooking WHERE rowid in (" + @i + ")";
            try
            {
                int val = DataLib.InsOrUpdateParam(str1, param);
            }*/
            #endregion
            try
            {
                pClsObj = new clsAdo();
                int Val = pClsObj.fnDeleteOnlineToursBooking(i);
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message.ToString());
                ClsCommon.LogAndSendError(ex.ToString() + " Tour Booking Page - fnDeleteOnlineToursBooking");
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
            }
        }
        Boolean insertCustomerDetails()
        {
            GST_Data objGst_Data = null;
            clsAdo pClsObj = null;
            try
            {
                objGst_Data = new GST_Data();
                pClsObj = new clsAdo();

                int rowidtemp;
                string state = "";
                string CustName = txtName.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "");
                string Address = txtAddress.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "");
                if (ddlCountry.SelectedValue == "59" || ddlCountry.SelectedValue == "India")
                {
                    state = ddlState.SelectedItem.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "");
                }
                else
                {
                    state = TxtForeignState.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "");
                }
                string Mobile = txtMobile.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "");
                string emailID = txtMail.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "");
                string phone = txtPhoneCountryCode.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "") + "-" +
                    txtPhone.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "");
                int[] busserial = new int[31];
                string str71, pwd1;
                string fileName = "";
                pwd1 = Convert.ToString(ViewState["strPass"]);
                Session["billingAddress"] = DataLib.funClear(Address.Replace("-", "").Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty));
                if (Mobile != "")
                {
                    Session["mobile"] = Mobile;
                }
                else
                {
                    Session["mobile"] = phone;
                }
                if (Convert.ToString(emailID) == "")
                {
                    emailID = ViewState["strDeCrypt"].ToString() + "@temp.com";
                }

                if (!(Convert.ToString(ViewState["rowid"]) == ""))
                {
                    GST_OnlineCustomer clsTblObj = new GST_OnlineCustomer();
                    clsTblObj.RowId = ClsCommon.ConvertStringint(ViewState["rowid"]);
                    clsTblObj.Title = ddlTitle.SelectedValue;
                    clsTblObj.FirstName = CustName;
                    clsTblObj.Addr1 = Address;
                    clsTblObj.Country = ddlCountry.SelectedItem.Text;
                    clsTblObj.Nationality = ddlNationality.SelectedValue;
                    if (ddlCountry.SelectedValue == "59")
                    {
                        //clsTblObj.state = ddlState.SelectedItem.Text;
                        clsTblObj.City = txtCity.Text.Trim();
                    }
                    else
                    {
                        //clsTblObj.state = TxtForeignState.Text.Trim();
                        clsTblObj.City = txtForeignCity.Text.Trim();
                    }
                    clsTblObj.AadharNo = txtAadharNo.Text.Trim();
                    clsTblObj.AadharImg = "";
                    if (fupAadhar.HasFile)
                    {
                        fileName = Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) + Convert.ToString(DateTime.Now.Millisecond) + "_" + fupAadhar.FileName.Split('.')[0];
                        clsTblObj.AadharImg = fileName + ".jpg";
                    }

                    clsTblObj.PhoneNo = phone;
                    clsTblObj.Mobile = Mobile;
                    clsTblObj.AlternativeNo = txtAlternateMobileNo.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "");
                    //clsTblObj.email = emailID;
                    if (rdbIsGSTApplicableYes.Checked == true)
                    {
                        clsTblObj.ISGSITIN = true;
                    }
                    else
                    {
                        clsTblObj.ISGSITIN = false;
                    }
                    if (clsTblObj.ISGSITIN == true)
                    {
                        clsTblObj.CustomerGSTIN = txtCustomerGSTIN.Text.Trim();
                        clsTblObj.GstHolderName = txtGstHolderName.Text.Trim();
                    }
                    else
                    {
                        clsTblObj.CustomerGSTIN = "";
                        clsTblObj.GstHolderName = "";
                    }

                    clsTblObj.CanSendPromotions = chkPromotions.Checked;
                    if (Session["Fc_Id"] != null)
                    {
                        clsTblObj.FaceBookID = Convert.ToString(Session["Fc_Id"]);
                    }

                    ClientScript.RegisterStartupScript(GetType(), "error1", "<script>alert('" + Convert.ToString(Session["fc_Id"]) + "');</script>");


                    int val = objGst_Data.GST_fnInsertUpdateCustDetail(clsTblObj, Convert.ToString(ViewState["strDeCrypt"]));
                    if (val == -1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "error1", "<script>alert('Email already exists');</script>");
                        return false;
                    }
                    else if (val > 0)
                    {
                        Session["custrowid"] = val.ToString();
                        ClientScript.RegisterStartupScript(GetType(), "error1", "<script>alert('Customer Record Successfully Updated.');</script>");

                    }
                }
                else
                {
                    GST_OnlineCustomer clsTblObj = new GST_OnlineCustomer();
                    clsTblObj.RowId = -1;
                    clsTblObj.FirstName = CustName;
                    clsTblObj.Title = ddlTitle.SelectedValue;
                    clsTblObj.Addr1 = Address;
                    clsTblObj.Nationality = ddlNationality.SelectedValue;
                    clsTblObj.Country = ddlCountry.SelectedItem.Text;

                    if (ddlCountry.SelectedValue == "59")
                    {
                        //clsTblObj.state = state;
                        clsTblObj.City = txtCity.Text.Trim();
                    }
                    else
                    {
                        //clsTblObj.state = TxtForeignState.Text.Trim();
                        clsTblObj.City = TxtForeignState.Text.Trim();
                    }
                    clsTblObj.AadharNo = txtAadharNo.Text.Trim();
                    clsTblObj.AadharImg = "";
                    if (fupAadhar.HasFile)
                    {
                        fileName = Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) + Convert.ToString(DateTime.Now.Millisecond) + "_" + fupAadhar.FileName.Split('.')[0];
                        clsTblObj.AadharImg = fileName + ".jpg";
                    }

                    clsTblObj.PhoneNo = phone;
                    clsTblObj.Mobile = Mobile;
                    clsTblObj.AlternativeNo = txtAlternateMobileNo.Text.Trim().Replace("'", "''").Replace("<", "").Replace(">", "").Replace("alert", "");
                    //clsTblObj.email = emailID;
                    //clsTblObj.password = pwd1;

                    if (Session["Fc_Id"] != null)
                    {
                        clsTblObj.FaceBookID = Convert.ToString(Session["Fc_Id"]);
                    }

                    int val = objGst_Data.GST_fnInsertUpdateCustDetail(clsTblObj, Convert.ToString(ViewState["strDeCrypt"]));
                    if (val == -1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "error1", "<script>alert('Email already exists');</script>");
                        return false;
                    }
                    else if (val > 0)
                    {
                        Session["custrowid"] = val.ToString();
                        ClientScript.RegisterStartupScript(GetType(), "error1", "<script>alert('Customer Record Successfully Save.');</script>");

                        string filepath = Server.MapPath(ConfigurationManager.AppSettings["mailerTemplatesPath"].ToString() + "\\forgotpass.html");
                        System.IO.StreamReader sr = new System.IO.StreamReader(filepath);
                        string strToSend = sr.ReadToEnd();
                        #region Optimize Code
                        /*string strrr = "select top 1 rowid from onlinecustomer order by 1 desc";
                    string rr = DataLib.GetStringData(DataLib.Connection.ConnectionString, strrr);*/
                        #endregion
                        int crowid = pClsObj.fnGetCustRowID();
                        strToSend = strToSend.Replace("#membername#", CustName);
                        strToSend = strToSend.Replace("#MemberUserName#", emailID);
                        strToSend = strToSend.Replace("#MemberPassword#", ViewState["Spass"].ToString());
                        string strMobile = Mobile;

                        try
                        {
                            string pTO = emailID;
                            string pFrom = "info@southerntravels.in";
                            string pSubject = "Your Southern Travels Account Details.";
                            string pBody = strToSend;
                            ClsCommon.sendmail(pTO, "", "", pFrom, pSubject, pBody, "");
                            if (strMobile != "")
                            {
                                StringBuilder strMsg = new StringBuilder();
                                string strSms = "Your Login Password is:" + ViewState["Spass"].ToString() + " Happy Holidaying...";
                                string strPhNo = strMobile.Trim().TrimStart('0');
                                strSms.Replace("\n", "");
                                string rtnmessage = DataLib.sendsms(ClsCommon.ConvertStringint(crowid), strPhNo, strSms, "OnLineUser", "EBK0001");
                            }
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.LogAndSendError(ex.ToString() + " Tour Booking Page - InsertCustomerDetails Send Mail");
                            Response.Write("<!-- " + ex.ToString() + " -->");
                        }
                        finally
                        {
                        }
                    }
                }
                if (fupAadhar.HasFile && fileName != "")
                {
                    SaveAadharPhysicalImg(fileName);
                }
                Session["EmailId"] = Convert.ToString(emailID);
                Session["orderid"] = ViewState["strDeCrypt"].ToString();
                return true;
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (Session["Fc_Id"] != null)
                {
                    Session["Fc_Id"] = null;
                }
                if (objGst_Data != null)
                {
                    objGst_Data = null;
                }
            }
            #region Optimize Code

            #endregion
        }

        private void SaveAadharPhysicalImg(string pFileName)
        {
            // Specify the path to save the uploaded file to.
            string lSavePath = Server.MapPath("~\\AadharImg\\");
            SaveResizedAadharImage(pFileName);
            //F1ImageName.PostedFile.SaveAs(lSavePath + pFileName);
        }
        private void SaveResizedAadharImage(string pFileName)
        {
            string newpath = Server.MapPath("~\\AadharImg\\" + pFileName + ".jpg");
            if (fupAadhar.HasFile)
            {
                System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(fupAadhar.PostedFile.InputStream);
                System.Drawing.Image objImage = ScaleImage(bmpPostedImage, 850);
                objImage.Save(newpath, ImageFormat.Png);
            }
        }
        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxHeight)
        {
            if (image.Height < maxHeight)
            {
                maxHeight = image.Height;
            }
            var ratio = (double)maxHeight / image.Height;

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                if (image.Height <= maxHeight)
                {
                    g.DrawImage(image, 0, 0);
                }
                else
                {
                    g.DrawImage(image, 0, 0, newWidth, newHeight);
                }
            }
            return newImage;
        }

        public static bool IsInteger(string theValue)
        {
            try
            {
                ClsCommon.ConvertStringint(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsInteger
        public static void TieButton(Control TextBoxToTie, Control ButtonToTie)
        {
            string formName;
            try
            {
                int i = 0;
                Control c = ButtonToTie.Parent;
                while (!(c is System.Web.UI.HtmlControls.HtmlForm) & !(c is System.Web.UI.Page) && i < 500)
                {
                    c = c.Parent;
                    i++;
                }
                if (c is System.Web.UI.HtmlControls.HtmlForm)
                    formName = c.ClientID;
                else
                    formName = "forms[0]";
            }
            catch
            {
                //If we catch an exception, we should use the first form on the page ("forms[0]").
                formName = "forms[0]";
            }
            TieButton(TextBoxToTie, ButtonToTie, formName);
        }
        public static void TieButton(Control TextBoxToTie, Control ButtonToTie, string formName)
        {
            // This is our javascript - we fire the client-side click event of the button if the enter key is pressed.
            string jsString = "if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)) {document." + formName + ".all['" + ButtonToTie.ClientID + "'].click();return false;} else return true; ";
            // We attach this to the onkeydown attribute - we have to cater for HtmlControl or WebControl.
            if (TextBoxToTie is System.Web.UI.HtmlControls.HtmlControl)
                ((System.Web.UI.HtmlControls.HtmlControl)TextBoxToTie).Attributes.Add("onkeydown", jsString);
            else if (TextBoxToTie is System.Web.UI.WebControls.WebControl)
                ((System.Web.UI.WebControls.WebControl)TextBoxToTie).Attributes.Add("onkeydown", jsString);
            else
            {
                // We throw an exception if TextBoxToTie is not of type HtmlControl or WebControl.
                throw new ArgumentException("Control TextBoxToTie should be derived from either System.Web.UI.HtmlControls.HtmlControl or System.Web.UI.WebControls.WebControl", "TextBoxToTie");
            }
        }
        private string AddSlashAmp(string EncrptStr)
        {
            string TempEnstr = EncrptStr;
            if (!string.IsNullOrEmpty(EncrptStr))
            {
                TempEnstr = EncrptStr.Replace("SlashSlash", "/");
                TempEnstr = TempEnstr.Replace("AmpAmp", "&").Replace("plusplus", "+");
            }
            return TempEnstr;
        }

        #endregion
        #region "Facebook"
        private void BindFaceBookValue()
        {

            clsAdo pClsObj = null;
            List<GetFbDetail_spResult> lResult = null;
            try
            {
                pClsObj = new clsAdo();
                ViewState["rowid"] = "";
                string FaceBookID = "";

                string emailidt = "";
                if (Session["fc_Email"] != null)
                {

                    emailidt = Convert.ToString(Session["fc_Email"]);
                    emailid.Text = emailidt;
                    FaceBookID = Convert.ToString(Session["fc_Id"]);

                    lResult = new List<GetFbDetail_spResult>();
                    lResult = pClsObj.fnGetFaceBookDetail(emailidt, FaceBookID);

                    orderid = ViewState["strDeCrypt"].ToString();
                    if (lResult != null && lResult.Count > 0)
                    {
                        Session["custrowid"] = lResult[0].RowId.ToString();
                        orderid = ViewState["strDeCrypt"].ToString();
                        ViewState["rowid"] = ClsCommon.ConvertStringint(lResult[0].RowId);
                        existingcustomer(ClsCommon.ConvertStringint(lResult[0].RowId), ViewState["strDeCrypt"].ToString());
                        GrandTotal = decimal.Round(Convert.ToDecimal(ViewState["GrandTotal"]));
                        Session["Amt"] = decimal.Round(Convert.ToDecimal(ViewState["PayNow"]));
                    }
                    else
                    {
                        if (Session["fc_FirstName"] != null && Session["fc_LastName"] != null)
                        {
                            txtName.Text = Convert.ToString(Session["fc_FirstName"]) + " " + Convert.ToString(Session["fc_LastName"]);
                        }

                        txtName.Attributes.Add("readonly", "readonly");
                        txtMail.Attributes.Add("readonly", "readonly");
                        //txtName.Text = "";
                        ddlState.SelectedValue = "";
                        if (type.Value == "email")
                        {
                            txtMobile.Text = "";
                            txtMail.Text = emailid.Text;
                        }
                        else if (type.Value == "Mobile")
                        {
                            txtMobile.Text = emailid.Text;
                            txtMail.Text = "";
                        }

                        txtMail.Text = emailid.Text;
                        orderid = ViewState["strDeCrypt"].ToString();
                        GrandTotal = decimal.Round(Convert.ToDecimal(ViewState["GrandTotal"]));
                        Session["Amt"] = decimal.Round(Convert.ToDecimal(ViewState["PayNow"]));
                        if (Session["custrowid"] != null)
                        {
                            BindProFile();
                        }
                    }
                }
            }
            finally
            {
                if (pClsObj != null)
                {
                    pClsObj = null;
                }
                if (lResult != null)
                {
                    lResult = null;
                }
                if (Session["fc_Email"] != null)
                {
                    Session["fc_Email"] = null;
                }
                if (Session["fc_FirstName"] != null)
                {
                    Session["fc_FirstName"] = null;
                }

                if (Session["fc_LastName"] != null)
                {
                    Session["fc_LastName"] = null;
                }
            }


        }
        protected void btnFaceBook_BookFixed_Click(object sender, EventArgs e)
        {
            BindFaceBookValue();
        }
        #endregion

        private bool CheckSeatBlockOrReleased(string orderid)
        {
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            String strCn = System.Configuration.ConfigurationManager.AppSettings["southernconn"];
            lConn = new SqlConnection(strCn);// For  Live
            lCommand = new SqlCommand("CheckSeatReleaseOrNot_sp", lConn);
            lCommand.CommandTimeout = 20 * 1000;
            lCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[2];
            try
            {
                int rowId = 0;
                param[0] = new SqlParameter("@Orderid", orderid);
                param[1] = new SqlParameter("@RetResult", rowId);
                param[1].Direction = ParameterDirection.Output;
                param[1].Size = 200;
                if (param != null)
                {
                    foreach (SqlParameter param1 in param)
                    {
                        lCommand.Parameters.Add(param1);
                    }
                }
                if (lConn.State == ConnectionState.Closed)
                {
                    lConn.Open();
                }
                lCommand.ExecuteNonQuery();
                rowId = ConvertStringInt(lCommand.Parameters[1].Value);
                if (rowId > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.ShowAlert("Something Wrong");
                return false;
            }
            finally
            {
                if (lConn.State != ConnectionState.Closed)
                {
                    lConn.Close();
                }
                lConn.Dispose();
                lConn = null;

                if (param != null)
                    param = null;

                if (lCommand != null)
                    lCommand = null;
                if (lConn != null)
                    lConn = null;
            }
        }

        public int ConvertStringInt(object intString)
        {
            Int32 intVal = 0;
            string intStr = Convert.ToString(intString);
            if (string.IsNullOrEmpty(intStr) || intString == "&nbsp;")
            {
                intVal = 0;
            }
            else
            {
                try
                {
                    intVal = Convert.ToInt32(intStr);
                }
                catch (Exception ex)
                {
                    intVal = 0;
                }
            }
            return intVal;
        }
        protected void ddlPickUp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnPromo_Click(object sender, EventArgs e)
        {
            lblPromoMsg.Text = "";
            FillDgtour();
            if (!promocheck())
            {
                lblPromoMsg.Text = "Invalid PromoCode Entered, Please Check";
                ClientScript.RegisterStartupScript(GetType(), "Invalidpromo", "<script>alert('Invalid PromoCode Entered, Please Check');</script>");
                return;
            }
            else
            {
                lblPromoMsg.Text = "Promo code apply successfully.";
            }
        }
        private void BindCountryName()
        {
            DataListResponse<GetCountryName_SPResult> lGetCountryName = null;
            clsContractModule clsHCobj = new clsContractModule();
            ddlCountry.Items.Clear();
            try
            {

                lGetCountryName = new DataListResponse<GetCountryName_SPResult>();
                clsHCobj.fldConnString = DataLib.getConnectionString();
                lGetCountryName = clsHCobj.fnGetCountryName(0);
                if (lGetCountryName.Status.Status)
                {
                    ddlCountry.DataSource = lGetCountryName.ResultList;
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, new ListItem("Country", "0"));
                    //ddlCountry.SelectedValue = "59";
                }
            }
            finally
            {
                if (clsHCobj != null)
                {
                    clsHCobj = null;
                }
                if (lGetCountryName != null)
                {
                    lGetCountryName = null;
                }
            }
        }

        private void BindNationalityName()
        {
            DataListResponse<GetCountryName_SPResult> lGetCountryName = null;
            clsContractModule clsHCobj = new clsContractModule();
            ddlNationality.Items.Clear();
            try
            {

                lGetCountryName = new DataListResponse<GetCountryName_SPResult>();
                clsHCobj.fldConnString = DataLib.getConnectionString();
                lGetCountryName = clsHCobj.fnGetCountryName(0);
                if (lGetCountryName.Status.Status)
                {
                    ddlNationality.DataSource = lGetCountryName.ResultList;
                    ddlNationality.DataTextField = "CountryName";
                    ddlNationality.DataValueField = "CountryID";
                    ddlNationality.DataBind();
                    ddlNationality.Items.Insert(0, new ListItem("Nationality", "0"));
                }
            }
            finally
            {
                if (clsHCobj != null)
                {
                    clsHCobj = null;
                }
                if (lGetCountryName != null)
                {
                    lGetCountryName = null;
                }
            }
        }

        private void BindStateName()
        {
            DataListResponse<GetCountryWiseStateName_SPResult> lGetStateName = null;
            clsContractModule clsHCobj = new clsContractModule();
            ddlState.Items.Clear();
            ddlState.SelectedValue = null;
            ddlState.DataBind();
            try
            {
                lGetStateName = new DataListResponse<GetCountryWiseStateName_SPResult>();
                int lCountryID = -2;
                if (ClsCommon.ConvertStringint(ddlCountry.SelectedValue) > 0)
                    lCountryID = 1;//ClsCommon.ConvertStringint(ddlCountry.SelectedValue);
                clsHCobj.fldConnString = DataLib.getConnectionString();
                lGetStateName = clsHCobj.fnGetCountryWiseStateName(lCountryID);
                if (lGetStateName.Status.Status)
                {
                    ddlState.DataSource = lGetStateName.ResultList;
                    ddlState.DataTextField = "StateName";
                    ddlState.DataValueField = "StateID";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, new ListItem("State", "0"));
                }
            }
            finally
            {
                if (clsHCobj != null)
                {
                    clsHCobj = null;
                }
                if (lGetStateName != null)
                {
                    lGetStateName = null;
                }
            }
        }

        private string GetStateID(string lStateName)
        {
            DataListResponse<GetCountryWiseStateName_SPResult> lGetStateName = null;
            clsContractModule clsHCobj = new clsContractModule();
            string pStateID = "0";
            try
            {

                lGetStateName = new DataListResponse<GetCountryWiseStateName_SPResult>();
                int lCountryID = -2;
                if (ClsCommon.ConvertStringint(ddlCountry.SelectedValue) > 0)
                {
                    if (ddlCountry.SelectedValue == "59")
                    {
                        lCountryID = 1;
                    }
                    else
                    {
                        lCountryID = ClsCommon.ConvertStringint(ddlCountry.SelectedValue);
                    }
                }
                //lCountryID = ClsCommon.ConvertStringint(ddlCountry.SelectedValue);
                clsHCobj.fldConnString = DataLib.getConnectionString();
                lGetStateName = clsHCobj.fnGetCountryWiseStateName(lCountryID);
                if (lGetStateName.Status.Status)
                {
                    var result = lGetStateName.ResultList.Where(q => (q.StateName)
                       .ToLower()
                       .Contains(lStateName.ToLower()))
                       .ToList();
                    if (result != null && result.Count > 0)
                    {
                        pStateID = result[0].StateID.ToString();
                    }
                }
            }
            finally
            {
                if (clsHCobj != null)
                {
                    clsHCobj = null;
                }
                if (lGetStateName != null)
                {
                    lGetStateName = null;
                }
            }
            return pStateID;
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDgtour();
            BindStateName();
            if (ddlCountry.SelectedValue == "59")
            {
                divState.Style["display"] = "block";
                txtCity.Style["display"] = "block";
                TxtForeignState.Style["display"] = "none";
                txtForeignCity.Style["display"] = "none";
            }
            else
            {
                divState.Style["display"] = "none";
                txtCity.Style["display"] = "none";
                TxtForeignState.Style["display"] = "block";
                txtForeignCity.Style["display"] = "block";
            }
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillDgtour();
            //BindCityName();
        }
        private bool IsHelicopterAvailable(int TourId, string HelDat)
        {
            bool ret = true;
            if (TourId == 131) // for  checking helicoper available for amar-vh 
            {
                DataSet dsMbk = null;
                DataTable dtMaster = null;

                try
                {
                    string helNotavsp = "HelNotAvail_sp";
                    SqlParameter[] param = new SqlParameter[2];

                    param[0] = new SqlParameter("@TourId", TourId);
                    param[1] = new SqlParameter("@HelDate", HelDat);

                    // if there is any entry of this date in master_HelBlockDate then booking will not allowed
                    dsMbk = DataLib.GetStoredProcData(DataLib.Connection.ConnectionString, helNotavsp, param);
                    dtMaster = dsMbk.Tables[0];
                    if (dtMaster.Rows.Count > 0) // if helicopter no available then dtmaster count will be > 0
                    {
                        ret = false;
                    }

                    return ret;
                }
                catch (Exception ex)
                {
                    ClsCommon.LogAndSendError(ex.ToString() + " Tour Booking Page - IsHelicopterAvailable");
                    return false;
                }
                finally
                {
                    if (dsMbk != null)
                    {
                        dsMbk = null;
                    }
                    if (dtMaster != null)
                    {
                        dtMaster = null;
                    }
                }
            }
            return ret;
        }

        private void CheckIntlEBKTourIDs(string strTourid)
        {
            string Ids = ConfigurationManager.AppSettings["IntlEBKTourIDs"];
            string[] Arr = Ids.Split(',');
            foreach (string str in Arr)
            {
                if (str == strTourid)
                {
                    FlagIntlEBKTourIDs = true; ViewState["FlagIntlEBKTourIDs"] = FlagIntlEBKTourIDs;
                    btncheckavail.Text = "Proceed"; hdnWam.Value = "1";
                    RadAC.Checked = true; RadAC.Text = "WAM Member"; RadNAC.Text = "WAM NonMember"; LtrlPickupPlace.Text = "Departure Hub";
                    ChkTCS.Visible = true; LtrlPickupPoint.Text = string.Empty; lblDepTime.Visible = pNotes.Visible = false;
                    ChkFilledTCS.Visible = true; LblTCSText.Visible = true; LblChkTcs.Visible = true;
                    break;
                }
            }
        }
        public string GetWAMBusType(string Val, string IDs)
        {
            string strres = Val;
            if (Convert.ToBoolean(ViewState["FlagIntlEBKTourIDs"]))
            {
                if (IDs == "1")
                { strres = "Type"; }

                if (IDs == "2")
                {
                    if (Val.ToUpper() == "AC") { strres = "WAM Member"; }
                    else { strres = "WAM NonMember"; }
                }
                if (IDs == "9")
                { strres = ""; }
            }
            return strres;
        }
        private void GetAlertAccordingToBusNo(int BusNo, DateTime Jdate, int Tourno)
        {
            if (BusNo == 2 && Jdate == Convert.ToDateTime("06/26/2017") && Tourno == 123)
            {
                ClsCommon.ShowAlert("The tour will be starting from Night 9PM instead of 3PM from Hotel Southern. For more details please contact 1800110606");
            }
        }

        private string GetTourShortCodeByTourID(string ptourID)
        {
            DataSet d1 = new DataSet();
            string strTourCode = "";
            SqlConnection lConn = null;
            SqlDataAdapter lDataAdp = null;
            try
            {
                String strCn = System.Configuration.ConfigurationManager.AppSettings["southernconn"];
                lConn = new SqlConnection(strCn);// For  Live
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GST_FindTourDetail_sp, lConn))
                {
                    cmd.CommandTimeout = 20 * 1000;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_TourNo", Convert.ToInt32(ptourID));
                    lDataAdp = new SqlDataAdapter(cmd);
                    lDataAdp.Fill(d1);
                }

                foreach (DataRow dr in d1.Tables[0].Rows)
                { strTourCode = Convert.ToString(dr["Tour_Short_key"]); }
            }
            catch (Exception ex) { ex.ToString(); }
            finally { d1 = null; }
            return strTourCode;

        }

        protected void OnCheckChanged_rdbIsGSTApplicableYes(object sender, EventArgs e)
        {
            divGSTDetails.Style["display"] = "";
        }
        protected void OnCheckChanged_rdbIsGSTApplicableNo(object sender, EventArgs e)
        {
            divGSTDetails.Style["display"] = "none";
        }

        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public static string[] GetCity(string prefixText, int count, int? contextKey)
        {
            int? lStateID1 = null;
            if (contextKey > 0)
                lStateID1 = contextKey;

            GST_Data obj = new GST_Data();
            List<GST_GetCityListByStateIdAndSearchedCityTextResult> objCity = obj.GST_GetCityListByStateIdAndSearchedCityText(prefixText, lStateID1);
            List<string> txtItems = new List<string>();
            String dbValues;
            foreach (GST_GetCityListByStateIdAndSearchedCityTextResult item in objCity)
            {
                dbValues = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(item.CityName.ToString(), item.CityID.ToString());
                txtItems.Add(dbValues);
            }
            return txtItems.ToArray();
        }

        protected void btnSetStateByCity_Click(object sender, EventArgs e)
        {
            //ddlState.Items.Clear();
            BindStateName();
            try
            {
                ddlState.Items.FindByValue(hdnStateIdBasedOnCity.Value).Selected = true;
            }
            catch (Exception ex)
            {
                ClsCommon.LogAndSendError(ex.ToString() + " Tour Booking Page - btnSetStateByCity_Click");
            }
        }

        private void UpdateTcsValByRowID(string pRowID, string pTourNo, string pTCSVal, string pAction)
        {
            DataSet d1 = new DataSet();
            string strTourCode = "";
            SqlConnection lConn = null;
            SqlCommand lCommand = null;
            SqlDataAdapter lDataAdp = null;
            try
            {
                String strCn = System.Configuration.ConfigurationManager.AppSettings["southernconn"];
                lConn = new SqlConnection(strCn);// For  Live
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.SP_Update_EBK_TCSVAL, lConn))
                {
                    cmd.CommandTimeout = 20 * 1000;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", pRowID);
                    cmd.Parameters.AddWithValue("@Tourid", pTourNo);
                    cmd.Parameters.AddWithValue("@TCSVal", pTCSVal);
                    cmd.Parameters.AddWithValue("@IsTCSsubmit", ChkFilledTCS.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Action", pAction);
                    lConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ex.ToString(); }
            finally { d1 = null; lConn.Close(); }
        }

        private decimal CalculateTCSAmount(decimal gstAmt, decimal totalAmount, int ItrFiled)
        {
            decimal TCSAmount = 0;
            decimal _gstAmt = (gstAmt);
            decimal _totalAmount = (totalAmount);
            decimal totalAmountToPaid = _gstAmt + _totalAmount; //1050000
            decimal _ItrFiled = (ItrFiled);
            decimal tempAmt = 0;
            decimal conditinalAmt = 700000;
            if (_ItrFiled == 0)
            {
                if (totalAmountToPaid > conditinalAmt)
                {
                    tempAmt = (totalAmountToPaid - conditinalAmt); //350000

                    totalAmountToPaid = totalAmountToPaid - tempAmt; //700000
                    TCSAmount = (tempAmt * 20) / 100;
                }
                if (totalAmountToPaid == conditinalAmt)
                {
                    TCSAmount += (conditinalAmt * 10) / 100;
                }
                if (totalAmountToPaid < conditinalAmt)
                {
                    TCSAmount += (totalAmountToPaid * 10) / 100;
                }
            }
            else
            {
                if (totalAmountToPaid > conditinalAmt)
                {
                    tempAmt = (totalAmountToPaid - conditinalAmt); //350000

                    totalAmountToPaid = totalAmountToPaid - tempAmt; //700000
                    TCSAmount = (tempAmt * 20) / 100;
                }
                if (totalAmountToPaid == conditinalAmt)
                {
                    TCSAmount += (conditinalAmt * 5) / 100;
                }
                if (totalAmountToPaid < conditinalAmt)
                {
                    TCSAmount += (totalAmountToPaid * 5) / 100;
                }
            }
            return Math.Round(TCSAmount);
        }
    }
}