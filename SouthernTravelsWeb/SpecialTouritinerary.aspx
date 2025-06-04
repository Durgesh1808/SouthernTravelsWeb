<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecialTouritinerary.aspx.cs" Inherits="SouthernTravelsWeb.SpecialTouritinerary" %>


<%@ Register Src="UserControl/UcMatchingTour.ascx" TagName="ucMatchingTour" TagPrefix="uc3" %>
<%@ Register Src="~/UserControl/UcTourItinerary.ascx" TagPrefix="UC" TagName="Itinerary" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcCityWisePlaceDisplay.ascx" TagName="UCCityWisePlaceDisplay"
    TagPrefix="uc1" %>
<%@ Register Src="UserControl/UcTourShortInfo.ascx" TagName="ucTourShortInfo" TagPrefix="uc2" %>
<%@ Register Src="UserControl/UcSpecialTourFarePanel.ascx" TagName="SpecialTourFarePanel"
    TagPrefix="uc3" %>
<%@ Register Src="UserControl/UcTourCostIncludeExcIude.ascx" TagName="ucTourCostIncludeExcIude"
    TagPrefix="ucCostIncludeExclue" %>
<%@ Register Src="UserControl/UcSPLModifySearch.ascx" TagName="UcSPLModifySearch"
    TagPrefix="uc3" %>
<%@ Register Src="UserControl/UcTourInfo.ascx" TagName="UCTourInfo" TagPrefix="uc4" %>
<%@ Register Src="UserControl/UcTourGallery.ascx" TagName="UCTourGallery" TagPrefix="uc5" %>
<%@ Register Src="UserControl/UcSpecialFarePaneltable.ascx" TagName="SpecialFarePaneltable"
    TagPrefix="uc6" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="HeadST" runat="server">
    <meta id="mtDescription" name="Description" content="" />
    <meta id="mtKeywords" name="Keywords" content="" />
    <meta id="mtrobots" name="robots" content="" />
    <title>Southern Travels - Tour and Travel Agency | Holiday Packages in India| Car Rental
        Services</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <style>
        .mb-15px
        {
            margin-bottom: 15px;
        }
        .tabbtn_mrgn
        {
            margin-top: 40px;
            margin-bottom: 40px;
        }
        .tab_btn
        {
            float: left;
            width: 100%;
            border-bottom: solid 1px #b1b1b1;
            margin: 0;
            padding: 0;
            list-style: none;
            text-align: center;
        }
        .tab_btn li
        {
            display: inline-block;
            width: 285px;
            margin-right: 15px;
            min-height: 60px;
        }
        .tab_btn a
        {
            padding: 10px 15px;
            background: #fff;
            display: block;
            text-align: center;
            text-transform: uppercase;
            color: #8c8c8c;
            border: solid 1px #b1b1b1;
            text-decoration: none;
            border-bottom: none;
            font-size: 15px;
        }
        .tab_btn a.active
        {
            background: #ff6000;
            color: #fff;
        }
        /*.book_transfer_wrap, .book_tourpackage_wrap {
	display: none
}*/.book_transfer_wrap
        {
            margin: 30px 0;
        }
        .packageDiv
        {
            margin-top: 30px;
            margin-bottom: 30px;
        }
        /*.check{ background: rgba(0,0,0,.5)}*/.tour-check
        {
            width: 100%;
        }
        .tour-check img
        {
            margin-bottom: 10px;
            width: 100%;
        }
        .tourbox
        {
            margin-bottom: 20px;
        }
        .bootstrap-timepicker-widget .icon-chevron-down::after
        {
            content: "\f078";
            font-family: 'FontAwesome';
            text-align: center;
            font-style: normal;
        }
        .bootstrap-timepicker-widget .icon-chevron-up::after
        {
            content: "\f077";
            font-family: 'FontAwesome';
            text-align: center;
            font-style: normal;
        }
        .tourbox label
        {
            display: block;
            position: relative;
            cursor: pointer;
        }
        .tourbox input
        {
            position: absolute;
            top: 0;
            right: 5px;
        }
        .tourbox img
        {
            width: 100%;
        }
        .tourbox .tourname
        {
            position: absolute;
            background: rgba(0,0,0,.5);
            color: #fff;
            bottom: 0;
            left: 0;
            width: 100%;
            padding: 10px 15px;
        }
        .selecteditems
        {
            display: none;
        }
        .w-event
        {
            background: url(images/inner-bg.jpg);
            background-size: cover;
        }
        .checkbox
        {
            margin-top: 0 !important;
        }
        .checkbox label:after, .radio label:after
        {
            content: '';
            display: table;
            clear: both;
        }
        .checkbox .cr, .radio .cr
        {
            position: relative;
            display: inline-block;
            border: 1px solid #a9a9a9;
            border-radius: .25em;
            width: 1.3em;
            height: 1.3em;
            float: left;
            margin-right: .5em;
            background: #fff;
        }
        .radio .cr
        {
            border-radius: 50%;
        }
        .checkbox .cr .cr-icon, .radio .cr .cr-icon
        {
            position: absolute;
            font-size: .8em;
            line-height: 0;
            top: 50%;
            left: 20%;
        }
        .radio .cr .cr-icon
        {
            margin-left: 0.04em;
        }
        .checkbox label input[type="checkbox"], .radio label input[type="radio"]
        {
            display: none;
        }
        .checkbox label input[type="checkbox"] + .cr > .cr-icon, .radio label input[type="radio"] + .cr > .cr-icon
        {
            transform: scale(3) rotateZ(-20deg);
            opacity: 0;
            transition: all .3s ease-in;
        }
        .checkbox label input[type="checkbox"]:checked + .cr > .cr-icon, .radio label input[type="radio"]:checked + .cr > .cr-icon
        {
            transform: scale(1) rotateZ(0deg);
            opacity: 1;
        }
        .checkbox label input[type="checkbox"]:disabled + .cr, .radio label input[type="radio"]:disabled + .cr
        {
            opacity: .5;
        }
        .checkbox, .radio
        {
            margin: 0 !important;
        }
        .checkbox label, .radio label
        {
            padding-left: 0 !important;
        }
        .transfer_tablerow
        {
            margin-top: 20px;
        }
        .guestForm
        {
            margin-top: 30px;
            padding-top: 30px;
            border-top: solid 1px #d2d2d2;
        }
        .guestForm h3
        {
            margin: 0 0 15px 0;
        }
        .bootstrap-select.btn-group .dropdown-toggle .filter-option
        {
            height: 34px !important;
            padding-top: 6px !important;
        }
        .formwrap .form-control
        {
            height: 34px !important;
        }
        .tablewrap th, .tablewrap td
        {
            vertical-align: top !important;
        }
        .tablewrap input
        {
            margin-right: 4px !important;
        }
        .bootstrap-select.form-control
        {
            margin-bottom: 6px !important;
        }
        .tableblock
        {
            margin-bottom: 30px;
        }
        .tableblock h2
        {
            font-size: 17px;
            margin-bottom: 15px;
        }
        .tablewrap th
        {
            background: #fbbf00 !important;
            color: #fff !important;
        }
        .headerspn
        {
            font-size: 15px;
            font-weight: 600;
        }
        .mt-md
        {
            margin-top: 24px;
        }
        .spltourbox
        {
            margin-bottom: 15px;
            padding-bottom: 15px;
            border-bottom: solid 1px #ddd;
            position: relative;
            padding-right: 150px;
        }
        .spltourbox:last-child
        {
            border: none;
        }
        .spltourbox .pos_booknow
        {
            position: absolute;
            right: 0;
            bottom: 15px;
        }
        .spl_tourpkg h2
        {
            margin-bottom: 20px;
        }
        .tournum
        {
            background: #fbbf00;
            color: #fff !important;
            display: inline-block;
            padding: 5px 10px;
        }
        .row_day
        {
            margin-bottom: 40px !important;
        }
        @media (max-width: 1023px)
        {
            .tablewrap table
            {
                width: 800px !important;
            }
            .spltourbox
            {
                padding-right: 0;
            }
            .spltourbox .pos_booknow
            {
                position: relative;
                margin-top: 15px;
            }
        }
        .spltoursection
        {
            background: none !important;
            padding-bottom: 0 !important;
        }
        .spltoursection .intlbox .imgsection img
        {
            max-height: 160px;
            width: 100%;
        }
        .spltoursection .intlbox .textsection
        {
            bottom: 15px;
        }
        .spltoursection .intlbox-home
        {
            margin-bottom: 0 !important;
        }
        .posrel
        {
            position: relative;
        }
        .backlinks
        {
            position: absolute;
            right: -30px;
            top: 0px;
        }
        .backlinks a
        {
            padding-left: 10px;
            padding-right: 10px;
        }
        .intlbox .textsection h3
        {
            text-shadow: 2px 2px 5px #000;
        }
    </style>
    <!-- Google Tag Manager -->
    <script>
        (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({ 'gtm.start':
        new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
        j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
        'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-T9VTF6H');

    </script>
    <script type="text/javascript">
        var $zoho = $zoho || {}; $zoho.salesiq = $zoho.salesiq || { widgetcode: "f9285012553db7ccdec3cf907b30482c1f0e0a2bd9e18f0f2b52a1810adb9374cd30ce7a28be5ad051877c21011ab9a5", values: {}, ready: function () { } }; var d = document; s = d.createElement("script"); s.type = "text/javascript"; s.id = "zsiqscript"; s.defer = true; s.src = "https://salesiq.zoho.com/widget"; t = d.getElementsByTagName("script")[0]; t.parentNode.insertBefore(s, t); d.write("<div id='zsiqwidget'></div>");
    </script>
    <script src="https://cdn.pagesense.io/js/southerntravels/95bf3c0ba74f44f9baed4ddf90896ba3.js"></script>
</head>
<body>
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-T9VTF6H" height="0"
            width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->
    <form id="form1" runat="server">
    <!-- Header Start -->
    <header class="posrel innerheader" runat="server" id="hd">
  <div class="herobanner">
     
    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="HOLIDAY_PACKAGE_CAR" />
      </div>
</header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <section class="innersection2">
    
    
    <asp:HiddenField ID="hdnTourItitearyHTML" runat="server" Value="" />    		
      <asp:HiddenField ID="hdnTourFare" runat="server" Value="" />
      <asp:HiddenField ID="hdnTourInfo" runat="server" Value="" />
      <asp:HiddenField ID="hdnTourName" runat="server" Value="" />
      <asp:HiddenField ID="hdnTourCodeDetails" runat="server" Value="" />
      <asp:HiddenField ID="hdnTourInclusionExculision" runat="server" Value="" />
      
    <asp:HiddenField ID="hdfIswed" runat="server" Value="0"></asp:HiddenField>
  <div class="container">
  
  <div class="spl_tourpkg" id="SplTours" runat="server" visible="false">
  
  <!-- special tours -->
  
  <section id="intlpkg" class="spltoursection posrel">
  
   <div class="backlinks">
  <a href="https://westofmoon.com" target="_blank">Go to westofmoon.com</a> | 
  <a href="weddingevent.aspx">Back to Wedding Event</a>
  </div>
  
  <div class="container">
    <div class="row">
    <div class="col-md-3">
      <div class="intlbox intlbox-home">
                   <a href="http://www.southerntravelsindia.com/Holiday-Packages-Itinerary-Delhi---Jaipur---Delhi_176">
                	<div class="imgsection">
                 <img src="images/spl-jaipuragra-tour.jpg" alt="jaipuragra" loading="lazy"/></div>
                 <div class="textsection"><h3>Jaipur <br />[01Night / 02Days tour]</h3></div>
                    </a>
                </div>
      </div>
    
      <div class="col-md-3">
      <div class="intlbox intlbox-home">
                
                   <a href="http://www.southerntravelsindia.com/Holiday-Packages-Itinerary-Delhi---Jaipur---Fatehpur-Sikri----Agra---Mathura---Delhi_177">
                	<div class="imgsection">
                 <img src="images/spl-jaipur-tour.jpg" alt="jaipur" loading="lazy"/></div>
                 <div class="textsection"><h3>Jaipur & Agra<br /> [02Nights / 03Days tour]</h3></div>
                 
                    </a>
                        
                </div>
      
               
       
       
      </div>
    
    <div class="col-md-3">
      <div class="intlbox intlbox-home">
                
                   <a href="http://www.southerntravelsindia.com/Holiday-Packages-Itinerary-Delhi---Bharatpur---Delhi_178">
                	<div class="imgsection">
                 <img src="images/spl-bharatpur-tour.jpg"  alt="bharatpur" loading="lazy"/></div>
                 <div class="textsection"><h3>Bharatpur<br /> [01Night / 02Days]</h3></div>
                 
                    </a>
                        
                </div>
      
             
       
       
      </div>
      
      <div class="col-md-3">
      <div class="intlbox intlbox-home">
                
                   <a href="http://www.southerntravelsindia.com/Holiday-Packages-Itinerary-Delhi---Ranthambore---Delhi_179">
                	<div class="imgsection">
                 <img src="images/spl-ranthambore-tour.jpg"  alt="ranthambore" loading="lazy"/></div>
                 <div class="textsection"><h3>Ranthambore <br />[01Night / 02Days]</h3></div>
                 
                    </a>
                        
                </div>
      
             
       
       
      </div>
    
    </div>
  </div>
</section>
  
  <!-- end special tours -->
  
		<div style="display:none">	
			<div style="height: 42px;"><a href="http://www.southerntravelsindia.com/weddingevent.aspx"  style="float: right;">Back To Wedding Event</a></div>
			
			
			<div class="row_day">
                    <div class="day">
                    <div class="daydesc">
                       Tours
                        <br>
                        </div>
                        </div>
                    <div class="desc">
                    
                        Per person cost <small>(Kindly select your requirement)</small></div>
                    
                </div>
			
				
				
			
			<div class="spltourbox">
				
				<h3 class="title"><span class="tournum">1.</span> <span>Jaipur [01Night / 02Days tour]</span></h3>
				<p><b>Cost Includes</b><br />
01 Nights Accommodation at Zone By the park or Similar , Buffet/ fixed Menu Breakfast, Air-conditioned car for Sightseeing and excursions</p>
				
				<p class="pos_booknow"><a href="http://www.southerntravelsindia.com/Holiday-Packages-Itinerary-Delhi---Jaipur---Delhi_176" class="commonbtn">Book Now</a></p>
				
			</div>
			
			<div class="spltourbox">
				
				<h3 class="title"><span class="tournum">2.</span> <span>Jaipur & Agra [02Nights / 03Days tour]</span></h3>
				<p><b>Cost Includes</b><br />
02 Nights Accommodation (1 Night Jaipur Zone by the park & 1 Night At Agra Howard plaza the Fern or Similar a Buffet/ fixed Menu Breakfast, Air-conditioned car for Sightseeing and excursions</p>
				
				<p class="pos_booknow"><a href="http://www.southerntravelsindia.com/Holiday-Packages-Itinerary-Delhi---Jaipur---Fatehpur-Sikri----Agra---Mathura---Delhi_177" class="commonbtn">Book Now</a></p>
				
			</div>
			
			<div class="spltourbox">
				
				<h3 class="title"><span class="tournum">3.</span> <span>Bharatpur [01Night / 02Days]</span></h3>
				<p><b>Cost Includes</b><br />
01 Nights Accommodation(1 Night at Lakshmi Vilas Palace or Similar a Buffet/ fixed Menu Breakfast, Air-conditioned car for Sightseeing and excursions(500/-KM Up & Down One way 4 Hrs)</p>
				
				<p class="pos_booknow"><a href=" http://www.southerntravelsindia.com/Holiday-Packages-Itinerary-Delhi---Bharatpur---Delhi_178" class="commonbtn">Book Now</a></p>
				
			</div>
			
			<div class="spltourbox">
				
				<h3 class="title"><span class="tournum">4.</span> <span>Ranthambore [01Night / 02Days]</span></h3>
				<p><b>Cost Includes</b><br />
01 Nights Accommodation(1 Night at Regent Resort Vanya Villa Similar a Buffet/ fixed Menu Breakfast, Air-conditioned car for Sightseeing and excursions(900/-KM Up & Down- One way 8 Hrs)</p>
				
	<p class="pos_booknow"><a href="   http://www.southerntravelsindia.com/Holiday-Packages-Itinerary-Delhi---Ranthambore---Delhi_179" class="commonbtn">Book Now</a></p>
				
			</div>
			
			</div>
				
			</div>
			
  <uc2:ucTourShortInfo ID="ucTourShortInfo1" runat="server"  fldCanBook = "false" />

      
      <div class="col-md-8">
        <div class="tab-content tab-content-inner">
          <div class="tab-pane fade in active" id="tab_itinerary">
          <h2 class="title showonmobile">Itinerary</h2>
            <div class="tbldetail">
            
              <UC:Itinerary runat="server" ID="ucItinerary"  />
              
              
            </div>
          </div>
          
           <div class="tab-pane" id="tab_inclexcl">
          <h2 class="title showonmobile">Inclusions/Exclusions</h2>
           
          
          <ucCostIncludeExclue:ucTourCostIncludeExcIude ID="ucTourCostIncludeExcIude1" 
        runat="server" />
          
          </div>
          
          
          <div class="tab-pane" id="tab_dateprice"> 
          	<h2 class="title showonmobile">Date & Price Info</h2>
            
            <!-- tour Price -->
            <div class="tourprice">
            	<h3 class="title">Tour <span>Price</span></h3>
                
                <div class="tablewrap">
             
                                    
                    <uc6:SpecialFarePaneltable ID="SpecialTourFarePanel81" runat="server" fldPanelSection="SEC_EndUser"
                                 CanBook="false" NotShowEBroucher="false" fldShowNotes="false"
                                 fldWidth="748px"  />
                
               </div> <!-- end tour Price -->
               
                <!-- Starting of calendar -->
                <div    id="divCal" runat="server">
                 <uc3:UcSPLModifySearch ID="UcSPLModifySearch1" runat="server" />
                 </div>
                <!-- End of Control Seat Availability-->
                
               
                
          </div>
          </div>
          <div class="tab-pane" id="tab_tourinfo"> 
          	<h2 class="title showonmobile">Tour Info</h2>
          	<uc4:UCTourInfo ID="UCTourInfo1" runat="server" />
           
          </div>
          <div class="tab-pane" id="tab_tourPlaces"> 
          <h2 class="title showonmobile">Places Covered</h2>
          	<uc1:UCCityWisePlaceDisplay ID="UCCityWisePlaceDisplay1" runat="server" />
          	
           
          </div>
          <div class="tab-pane" id="tab_similar"> 
          <h2 class="title showonmobile">Similar Packages</h2>
           <uc3:ucMatchingTour ID="ucMatchingTour1" runat="server" /> 
          
          </div>
          
           <div class="tab-pane" id="tab_gallery">
           <h2 class="title showonmobile">Tour Gallery</h2>
           <uc5:UCTourGallery ID="UCTourGallery1" runat="server" /></div>
          
        </div>
      </div>
    </div>
  
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {

            initialize();
        });
        
    </script>
    <script>
        $('select').selectpicker();

    </script>
    </form>
    <script>

        (function (i, s, o, g, r, a, m) {

            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {

                (i[r].q = i[r].q || []).push(arguments)

            }, i[r].l = 1 * new Date(); a = s.createElement(o),

  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)

        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');



        ga('create', 'UA-4994177-1', 'auto');

        ga('require', 'displayfeatures');

        ga('send', 'pageview');

 

    </script>
</body>
</html>
