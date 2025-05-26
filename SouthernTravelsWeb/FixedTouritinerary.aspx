<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FixedTouritinerary.aspx.cs" Inherits="SouthernTravelsWeb.FixedTouritinerary" %>

<%@ Register Src="~/UserControl/UcTourItinerary.ascx" TagPrefix="UC" TagName="Itinerary" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcCityWisePlaceDisplay.ascx" TagName="UCCityWisePlaceDisplay"
    TagPrefix="uc1" %>
<%@ Register Src="UserControl/UcTourShortInfo.ascx" TagName="ucTourShortInfo" TagPrefix="uc2" %>
<%@ Register Src="UserControl/UcFarePanel.ascx" TagPrefix="UC" TagName="FTFarePanel" %>
<%@ Register Src="UserControl/UcModifySearch.ascx" TagName="UcModifySearch" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UcMatchingTour.ascx" TagName="ucMatchingTour" TagPrefix="uc3" %>
<%@ Register Src="UserControl/UcTourInfo.ascx" TagName="UCTourInfo" TagPrefix="uc4" %>
<%@ Register Src="UserControl/UcTourGallery.ascx" TagName="UCTourGallery" TagPrefix="uc5" %>
<%@ Register Src="UserControl/UcTourCostIncludeExcIude.ascx" TagName="ucTourCostIncludeExcIude"
    TagPrefix="ucCostIncludeExclue" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="HeadST" runat="server">
    <meta id="mtDescription" name="Description" content="" />
    <meta id="mtKeywords" name="Keywords" content="" />
    <meta id="mtrobots" name="robots" content="" />
    <title>Southern Travels - Tour and Travel Agency | Holiday Packages in India| Car Rental
        Services</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
     <!-- Google Tag Manager -->
    <script>        (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({
                'gtm.start':
                    new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
                j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
                    'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-WXRG7KM');</script>
    <!-- End Google Tag Manager -->
    <!-- Google tag (gtag.js) -->
<script async src="https://www.googletagmanager.com/gtag/js?id=AW-10777805346"></script>
<script>
    window.dataLayer = window.dataLayer || [];
    function gtag() { dataLayer.push(arguments); }
    gtag('js', new Date());

    gtag('config', 'AW-10777805346');
</script>
<!-- Google tag (gtag.js) -->
<!-- Meta Pixel Code -->
<script>
    !function (f, b, e, v, n, t, s) {
        if (f.fbq) return; n = f.fbq = function () {
            n.callMethod ?
                n.callMethod.apply(n, arguments) : n.queue.push(arguments)
        };
        if (!f._fbq) f._fbq = n; n.push = n; n.loaded = !0; n.version = '2.0';
        n.queue = []; t = b.createElement(e); t.async = !0;
        t.src = v; s = b.getElementsByTagName(e)[0];
        s.parentNode.insertBefore(t, s)
    }(window, document, 'script',
        'https://connect.facebook.net/en_US/fbevents.js');
    fbq('init', '520605323053563');
    fbq('track', 'PageView');
</script>
<!-- End Meta Pixel Code -->
<script type="text/javascript">
    var $zoho = $zoho || {}; $zoho.salesiq = $zoho.salesiq || { widgetcode: "f9285012553db7ccdec3cf907b30482c1f0e0a2bd9e18f0f2b52a1810adb9374cd30ce7a28be5ad051877c21011ab9a5", values: {}, ready: function () { } }; var d = document; s = d.createElement("script"); s.type = "text/javascript"; s.id = "zsiqscript"; s.defer = true; s.src = "https://salesiq.zoho.com/widget"; t = d.getElementsByTagName("script")[0]; t.parentNode.insertBefore(s, t); d.write("<div id='zsiqwidget'></div>");
    </script>
    <script src="https://cdn.pagesense.io/js/southerntravels/95bf3c0ba74f44f9baed4ddf90896ba3.js"></script>
    <script type="application/ld+json">
{
  "@context": "https://schema.org/",
  "@type": "WebSite",
  "name": "SouthernTravelsIndia",
  "url": "https://www.southerntravelsindia.com/",
  "potentialAction": {
    "@type": "SearchAction",
    "target": "https://www.southerntravelsindia.com/SearchResult.aspx?prefixText={search_term_string}",
    "query-input": "required name=search_term_string"
  }
}
</script>
<!--Clarity tracking code-->
<script type="text/javascript">
    (function (c, l, a, r, i, t, y) {
        c[a] = c[a] || function () { (c[a].q = c[a].q || []).push(arguments) };
        t = l.createElement(r); t.async = 1; t.src = "https://www.clarity.ms/tag/" + i;
        y = l.getElementsByTagName(r)[0]; y.parentNode.insertBefore(t, y);
    })(window, document, "clarity", "script", "juyakimapd");
</script>
<meta name="google-site-verification" content="FlFqlfXz_UJT9317cQ0Om_W2GK0KM6eAtiteItxOKcQ" />
</head>
<body>
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-WXRG7KM" height="0"
            width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->
    <!-- Meta Pixel Code (noscript) -->
<noscript><img height="1" width="1" style="display:none"
src="https://www.facebook.com/tr?id=520605323053563&ev=PageView&noscript=1"
/></noscript>
<!-- End Meta Pixel Code (noscript) -->
    <form id="form1" runat="server">
    <!-- Header Start -->
    <header class="posrel innerheader" runat="server" id="hd">
  <div class="herobanner">
    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="FIXED_DEPARTURE"  />
      </div>
</header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <section class="innersection2">
  <div class="container">
  

  <uc2:ucTourShortInfo ID="ucTourShortInfo1" runat="server"  fldCanBook="false"/>
   
      
      
      <asp:HiddenField ID="hdnTourItitearyHTML" runat="server" Value="" />
      <asp:HiddenField ID="hdnTourFare" runat="server" Value="" />
      <asp:HiddenField ID="hdnTourInfo" runat="server" Value="" />
      <asp:HiddenField ID="hdnTourName" runat="server" Value="" />
      <asp:HiddenField ID="hdnTourCodeDetails" runat="server" Value="" />
      <asp:HiddenField ID="hdnTourInclusionExculision" runat="server" Value="" />
      
      <div class="col-md-8">
        <div class="tab-content tab-content-inner">
          <div class="tab-pane fade in active" id="tab_itinerary">
          <h2 class="title showonmobile">Itinerary</h2>
            <div class="tbldetail">
            
              <UC:Itinerary runat="server" ID="ucItinerary" fldTourType="FIXED_TOUR" />
              
              
            </div>
          </div>
          <div class="tab-pane" id="tab_dateprice"> 
          	
            <h2 class="title showonmobile">Date & Price Info</h2>
            <!-- tour Price -->
            <div class="tourprice">
            	<%--<h3 class="title">Tour <span>Price</span></h3>--%>
                
                <%--<div class="tablewrap">--%>
                <UC:FTFarePanel runat="server" ID="FTFarePane91" fldTourType="fixed" Visible="true" fldCanBook="false" />
                </div>
				<%--</div>--%>
                
               <%--</div> --%><!-- end tour Price -->
               
               <!-- calendar -->
                <div class="calendarwrap" id="divCal" runat="server" >
                <uc1:UcModifySearch ID="UcModifySearch1" runat="server" />
                	<%--<img src="images/calendarpic.jpg" class="img-responsive">--%>
                </div>
                <!-- end calendar -->
               
               
                
          
          </div>
           <%--<div class="tab-pane" id="tab_inclexcl">
           <h2 class="title showonmobile">Inclusions/Exclusions</h2>
            <ucCostIncludeExclue:ucTourCostIncludeExcIude ID="ucTourCostIncludeExcIude1" 
        runat="server" />
           </div>--%>
          
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
          
           <%--<div class="tab-pane" id="tab_terms">Terms</div>--%>
          
          
          
          <div class="tab-pane" id="tab_gallery">
          <h2 class="title showonmobile">Tour Gallery</h2>
          <uc5:UCTourGallery ID="UCTourGallery1" runat="server" /></div>
          
          <%--<div class="tab-pane" id="tab_testimonial">Testimonial</div>--%>
        </div>
      </div>
    </div>
  
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    <script type="text/javascript">
        $(document).ready(function ($) {


            $("#blog-slider").owlCarousel({
                items: 1,
                pagination: false,
                // Navigation
                navigation: true,
                navigationText: ["<i class='fa fa-caret-left'></i>", "<i class='fa fa-caret-right'></i>"],
                rewindNav: true,
                scrollPerPage: false,
            });

            $("#like-slider").owlCarousel({
                items: 1,
                pagination: false,
                // Navigation
                navigation: false,
                loop: true,
                autoPlay: true,
                autoplayTimeout: 1000,
                autoplayHoverPause: true
            });



        });
    </script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {

            initialize();
        });

    </script>
    <script>
        $('select').selectpicker();

    </script>
    <script type="text/javascript">
        $(document).ready(function ($) {


            $("#blog-slider").owlCarousel({
                items: 1,
                pagination: false,
                // Navigation
                navigation: true,
                navigationText: ["<i class='fa fa-caret-left'></i>", "<i class='fa fa-caret-right'></i>"],
                rewindNav: true,
                scrollPerPage: false,
            });

            $("#like-slider").owlCarousel({
                items: 1,
                pagination: false,
                // Navigation
                navigation: false,
                loop: true,
                autoPlay: true,
                autoplayTimeout: 1000,
                autoplayHoverPause: true
            });



        });
    </script>
<script>
    /* ================================================================================= map =========================================================================*/
    var map;
    var myCenter = new google.maps.LatLng(32.9914962, 74.9318173);
    var marker = new google.maps.Marker({
        position: myCenter
    });

    function initialize() {
        var mapProp = {
            center: myCenter,
            zoom: 14,
            draggable: true,
            scrollwheel: false,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        map = new google.maps.Map(document.getElementById("map-canvas"), mapProp);
        marker.setMap(map);

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.setContent(contentString);
            infowindow.open(map, marker);
        });
    };
    google.maps.event.addDomListener(window, 'load', initialize);

    // Pass function reference, do NOT call it here
    google.maps.event.addDomListener(window, "resize", resizingMap);

    $('#myMapModal').on('show.bs.modal', function () {
        // Must wait until modal is rendered, use resizeMap not resizingMap here
        resizeMap();
    })

    function resizeMap() {
        if (typeof map == "undefined") return;
        setTimeout(function () { resizingMap(); }, 400);
    }

    function resizingMap() {
        if (typeof map == "undefined") return;
        var center = map.getCenter();
        google.maps.event.trigger(map, "resize");
        map.setCenter(center);
    }
    /* ================================================================================= end map =========================================================================*/


    /* ================================================	center modal popup ============================================*/
    // initialise on document ready
    jQuery(document).ready(function ($) {
        'use strict';

        // CENTERED MODALS
        // phase one - store every dialog's height
        $('.modal').each(function () {
            var t = $(this),
                d = t.find('.modal-dialog'),
                fadeClass = (t.is('.fade') ? 'fade' : '');
            // render dialog
            t.removeClass('fade')
                .addClass('invisible')
                .css('display', 'block');
            // read and store dialog height
            d.data('height', d.height());
            // hide dialog again
            t.css('display', '')
                .removeClass('invisible')
                .addClass(fadeClass);
        });
        // phase two - set margin-top on every dialog show
        $('.modal').on('show.bs.modal', function () {
            var t = $(this),
                d = t.find('.modal-dialog'),
                dh = d.data('height'),
                w = $(window).width(),
                h = $(window).height();
            // if it is desktop & dialog is lower than viewport
            // (set your own values)
            if (w > 380 && (dh + 60) < h) {
                d.css('margin-top', Math.round(0.96 * (h - dh) / 2));
            } else {
                d.css('margin-top', '');
            }
        });
    }); /* ================================================	center modal popup ============================================*/
</script>

    <script type="text/javascript">
        $(function () {
            $('.tabsection_inner .nav-tabs li a').on('click', function (e) {
                //alert('');
                //var href = $(this).attr('href');
                $("html, body").animate({ scrollTop: 0 }, "slow");
                e.preventDefault();
            });
        });
    </script>
    </form>
   
</body>
</html>
