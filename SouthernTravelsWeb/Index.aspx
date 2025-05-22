<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SouthernTravelsWeb.Index1" %>

<%@ Register Src="UserControl/UcQuickSearch.ascx" TagPrefix="uc" TagName="QuickSearch" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagPrefix="UCHeader" TagName="UCHeaderEndUser" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagPrefix="UCFooter" TagName="UCFooterEndUser" %>
<%@ Register Src="UserControl/UcFixedTourList.ascx" TagPrefix="UCTourList" TagName="UCFixedTour" %>
<%@ Register Src="UserControl/UcNewsNotification.ascx" TagPrefix="uc1" TagName="UcNewsNotification" %>
<%@ Register Src="UserControl/UcImageStrip.ascx" TagPrefix="uc3" TagName="UCImageStrip" %>
<%@ Register Src="UserControl/UcBlog.ascx" TagName="ucBlog" TagPrefix="uc2" %>

<!DOCTYPE html>
<html xmlns="https://www.w3.org/1999/xhtml"  itemtype="https://schema.org/WebSite">
<head id="Head1" runat="server"  itemtype="https://schema.org/TravelAgency">
    <title>International Holiday Packages | Tour & Travel Agency | Car Rental Services</title>

    <!-- Meta Tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta id="mtDescription" name="Description" content="Southern Travels offering you a wide range of national and international holiday packages to enjoy hassle-free holidays with your family and friends. choose the best travel agency to ensure an unforgettable holiday." />
    <meta name="description" content="Southern Travels offers a wide range of national and international holiday packages..." />
    <meta id="mtKeywords" name="Keywords" content="southern travels, tour and travel agency, travel agents in delhi, travel agency in india, tour operators, holiday packages in india, international tour packages, car rental services, north india tour packages, tour packages for south india, west india travel packages, east india tours, one day tour package" />
    <meta name="DC.title" content="International Holiday Packages" />
    <meta name="geo.region" content="IN-DL" />
    <meta name="geo.placename" content="New Delhi" />
    <meta name="geo.position" content="28.645713;77.195666" />
    <meta name="ICBM" content="28.645713, 77.195666" />
    <meta property="og:type" content="business.business" />
    <meta property="og:title" content="Southern Travels Pvt. Ltd." />
    <meta property="og:url" content="https://www.southerntravelsindia.com/" />
    <meta property="og:image" content="https://www.southerntravelsindia.com/Assets/images/fd-slider/delhi.png" />
    <meta property="business:contact_data:street_address" content="18/2, Arya Samaj Road, Karol Bagh" />
    <meta property="business:contact_data:locality" content="New Delhi" />
    <meta property="business:contact_data:region" content="Delhi" />
    <meta property="business:contact_data:postal_code" content="110005" />
    <meta property="business:contact_data:country_name" content="India" />
    <meta name="facebook-domain-verification" content="ikm4u1i0f5ikimuz9h5z0j15tfm28k" />
    <meta name="google-site-verification" content="FlFqlfXz_UJT9317cQ0Om_W2GK0KM6eAtiteItxOKcQ" />

    <!-- Styles -->
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <link href="Assets/css/myStyle.css" rel="stylesheet" />
    <!-- Scripts -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" ></script>
    <script src="Assets/js/myJs.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <!-- Google Tag Manager -->
    <script>        (function (w, d, s, l, i) {
                     w[l] = w[l] || []; w[l].push({ 'gtm.start':
                     new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-WXRG7KM');
        </script>
        <!-- Meta Pixel Code -->

<!-- End Meta Pixel Code -->


<script type="application/ld+json">
{
  "@context": "https://schema.org",
  "@type": "TravelAgency",
  "name": "SouthernTravelsIndia",
  "url": "https://www.southerntravelsindia.com/",
  "logo": "https://www.southerntravelsindia.com/Assets/images/logo-st.png",
  "description": "Southern Travels India offers domestic and international tour packages, holiday planning, and travel booking services across India and abroad.",
  "address": {
    "@type": "PostalAddress",
    "streetAddress": "18/2, Arya Samaj Road, Karol Bagh",
    "addressLocality": "New Delhi",
    "addressRegion": "Delhi",
    "postalCode": "110005",
    "addressCountry": "IN"
  },
  "contactPoint": {
    "@type": "ContactPoint",
    "telephone": "+91-11-43532800",
    "contactType": "Customer Service",
    "areaServed": "IN",
    "availableLanguage": ["English", "Hindi", "Telugu", "Tamil", "Kannada", "Bengali"]
  },
  "openingHoursSpecification": {
    "@type": "OpeningHoursSpecification",
    "dayOfWeek": [
      "Monday",
      "Tuesday",
      "Wednesday",
      "Thursday",
      "Friday",
      "Saturday"
    ],
    "opens": "10:00",
    "closes": "19:00"
  },
  "socialmediahandels": [
    "https://www.facebook.com/SouthernTravels",
    "https://www.instagram.com/southerntravelsofficial",
    "https://x.com/TravelsSouthern",
    "https://www.youtube.com/southerntravels",
    "https://www.linkedin.com/company/southern-travels-pvt-ltd"
  ],
  "potentialAction": {
    "@type": "SearchAction",
    "target": "https://www.southerntravelsindia.com/SearchResult.aspx?prefixText={search_term_string}",
    "query-input": "required name=search_term_string"
  }
}
</script>

    <!-- Zoho SalesIQ -->
    <script type="text/javascript">
        var $zoho = $zoho || {};
        $zoho.salesiq = {
            widgetcode: "f9285012553db7ccdec3cf907b30482c1f0e0a2bd9e18f0f2b52a1810adb9374cd30ce7a28be5ad051877c21011ab9a5",
            values: {},
            ready: function () {
                $zoho.salesiq.visitor.question("Hey, I need assistance!");
                $zoho.salesiq.floatbutton.click(function () {
                    $zoho.salesiq.chat.start();
                });
            }
        };
        (function (d) {
            var s = d.createElement("script");
            s.type = "text/javascript";
            s.id = "zsiqscript";
            s.defer = true;
            s.src = "https://salesiq.zoho.com/widget";
            var t = d.getElementsByTagName("script")[0];
            t.parentNode.insertBefore(s, t);
        })(document);
    </script>

    <!-- PageSense -->
    <script src="https://cdn.pagesense.io/js/southerntravels/95bf3c0ba74f44f9baed4ddf90896ba3.js" defer></script>

    <!-- Page Load Modal -->
    <script defer>
        $(document).ready(function () {
            loadingModal.show();
            $(window).on('load', function () {
                loadingModal.hide();
            });
        });
    </script>
       <style>
        .modal-backdrop.ni
        {
            opacity: .8;
        }
        #onloadmodal .close, .modal-package-container .close
        {
            position: absolute;
            top: 4px;
            right: -25px;
            color: #fff;
            z-index: 99999;
            opacity: 1;
            width: 20px;
            height: 20px;
            font-size: 14px;
            line-height: 20px;
            text-align: center;
            border-radius: 50%;
            background-color: #000;
        }
        #onloadmodal img
        {
            max-width: 700px;
            height: auto;
            border: solid 10px #fff;
        }
        #onloadmodal .modal-body
        {
            max-width: 700px;
            margin: 0 auto;
        }
        #modal-package
        {
            z-index: 99999;
        }
        .vertical-alignment-helper
        {
            display: table;
            height: 100%;
            width: 100%;
        }
        .vertical-align-center
        {
            /* To center vertically */
            display: table-cell;
            vertical-align: middle;
        }
        .modal-content
        {
            /* Bootstrap sets the size of the modal in the modal-dialog class, we need to inherit it */
            width: inherit;
            height: inherit; /* To center horizontally */
            margin: 0 auto;
        }
        .modal-package
        {
            position: absolute;
            top: 50%;
            left: 50%;
            max-width: 800px;
            margin-left: auto;
            margin-right: auto;
            background: white;
            border: 3px solid #ed1b2f;
            -webkit-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
        }
        .modal-package-container
        {
            padding: 15px;
            margin-bottom: -15px;
        }
        .modal-package-item
        {
            padding-left: 7.5px !important;
            padding-right: 7.5px !important;
            margin-bottom: 15px !important;
        }
        @media (max-width: 767px)
        {
            .modal-package
            {
                top: 15px;
                -webkit-transform: translate(-50%, 0);
                transform: translate(-50%, 0);
            }
        }
        .popup
        {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, .74);
        }
        .popup__inner
        {
            width: 100%;
            height: 100%;
            padding: 15px;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
            display: -webkit-box;
            display: -ms-flexbox;
            display: flex;
            -webkit-box-align: center;
            -ms-flex-align: center;
            align-items: center;
            -webkit-box-pack: center;
            -ms-flex-pack: center;
            justify-content: center;
        }
        .popup__imgWrapper
        {
            position: relative;
            display: inline-block;
        }
        .popup__img
        {
            max-width: 100%;
        }
        .popup__linkFirst, .popup__linkSecond, .popup__linkThird, .popup__linkForth, .popup__linkFifth, .popup__linkSix, .popup__linkSeven, .popup__linkEight, .popup__linkNine, .popup__linkTen, .popup__linkEleven, .popup__linkTwelve, .popup__linkThirteen
        {
            position: absolute;
            top: 50%;
            height: 100%;
        }
        .popup__linkFirst
        {
            width: 33%;
            left: 0;
            height: 43%;
            top: 46%;
        }
        .popup__linkSecond
        {
            width: 33%;
            left: 33%;
            height: 43%;
            top: 46%;
        }
        .popup__linkThird
        {
            width: 33%;
            left: 66%;
            height: 43%;
            top: 46%;
        }
        .popup__linkForth
        {
            width: 46%;
            left: 52%;
            height: 85px;
            margin-top: 131px;
        }
        .popup__linkFifth
        {
            width: 61%;
            left: 19%;
            height: 57px;
            margin-top: 226px;
        }
        .popup__linkSix
        {
            width: 30%;
            left: 66%;
            height: 27px;
            margin-top: 38px;
        }
        .popup__linkSeven
        {
            width: 30%;
            left: 66%;
            height: 27px;
            margin-top: 70px;
        }
        .popup__linkEight
        {
            width: 30%;
            left: 66%;
            height: 27px;
            margin-top: 104px;
        }
        .popup__linkNine
        {
            width: 30%;
            left: 66%;
            height: 27px;
            margin-top: 137px;
        }
        .popup__linkTen
        {
            width: 30%;
            left: 66%;
            height: 27px;
            margin-top: 170px;
        }
        .popup__linkEleven
        {
            width: 30%;
            left: 66%;
            height: 27px;
            margin-top: 204px;
        }
        .popup__linkTwelve
        {
            width: 30%;
            left: 66%;
            height: 27px;
            margin-top: 238px;
        }
        .popup__linkThirteen
        {
            width: 30%;
            left: 66%;
            height: 27px;
            margin-top: 268px;
        }
        .popup__imgWrapper .close
        {
            position: absolute;
            color: #fff;
            z-index: 99999;
            opacity: 1;
            width: 20px;
            height: 20px;
            font-size: 14px;
            line-height: 20px;
            text-align: center;
            border-radius: 50%;
            background-color: #000;
            right: -10px !important;
            top: -7px !important;
        }
        .row
        {
            margin-right: 0px !important;
            margin-left: -2px;
        }
        
 /* Latest News Marquee*/
  #latestnews {
      background-color: #f9f9f9;
    }
    .displaytable {
      display: flex;
    }
    .displaycol {
      display: flex;
      align-items: center;
      justify-content: center;
    }
    .bgnews {
      background-color: #343a40;
      color: white;
    }
    .bgnewsdetail {
      background-color: #ffffff;
    }
    .valignmid {
      display: flex;
      align-items: center;
    }

    /* Marquee styling */
    .marqueewrap {
      height: 96px;
      overflow: hidden;
      position: relative;
    }

    .marquee {
      display: inline-block;
      animation: scroll-up 12s linear infinite;
    }

    .marqueewrap:hover .marquee {
      animation-play-state: paused;
    }

    .marquee li {
      list-style: none;
      padding: 5px 0;
      font-size: 16px;
    }

    @keyframes scroll-up {
      0% { transform: translateY(0); }
      100% { transform: translateY(-50%); } /* Adjust based on content length */
    }
 </style>
</head>
<body>
<div class="loadingModal" runat=server id="loadingModal"></div>

    <!-- Google Tag Manager (noscript) -->
    
        <noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-WXRG7KM"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>

    
    <!-- End Google Tag Manager (noscript) -->

<!-- End Meta Pixel Code (noscript) -->
    <form id="form" runat="server" style="margin: 0px;">
    <asp:HiddenField ID="HdnHM" runat="server" />
    <!-- Header Start -->
    <header class="posrel">
  <div class="herobanner">
      <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="HOME" />
      <div class="spacer_banner">
         
      
         
      </div>
    <div class="container">
      <div class="row">
      <div class="col-md-6">
                <div class="hero-tabsection">
        <uc:QuickSearch runat="server" ID="ucQuickSearch" fldShowBanner="false" />
         </div>
            </div>
        <div class="col-md-1">&nbsp;</div>
        <div class="col-md-5">
          <div class="carouselsection">
            <div id="hp-heroslider" class="owl-carousel">
              <%=strSliderItems%>                           
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  
</header>
    <!-- Header End -->
    <!-- Main Content Start -->
   <uc1:UcNewsNotification ID="UcNewsNotification1" runat="server" fldNewsType="News" />
  <!-- Latest News Content -->

   
    <section id="fho">
  <div class="container">
  <div class="row">
      <div class="col-md-12">
        <h2 class="main-title">Tours In India</h2>
      </div>
    </div>
    <div class="row">
      <div class="col-md-5">
        <h2 class="title">Fixed Departure Tours - <span>India</span></h2>
        <div id="fd-slider" class="owl-carousel">
          <div class="item"> <img src="Assets/images/fd-slider/delhi.png" alt="Touch" loading="lazy">
            <div class="fd-content">
              <h3>Tours from New Delhi</h3>
             <UCTourList:UCFixedTour runat = "server" ID = "ucFixedTourDelhi" fldTourType = "FIXED_TOUR" fldTourOrigin="New Delhi"></UCTourList:UCFixedTour>
              <a class="viewall" href="India-Tour-Packages.aspx">View all &nbsp;<i class='fa fa-chevron-right' style="font-weight: lighter"></i></a> </div>
          </div>
          <div class="item"> <img src="Assets/images/fd-slider/Chennai.png" alt="Touch" loading="lazy">
            <div class="fd-content">
              <h3>Tours from Chennai</h3>
              <UCTourList:UCFixedTour runat = "server" ID = "ucFixedTourChennai" fldTourType = "FIXED_TOUR" fldTourOrigin="Chennai"></UCTourList:UCFixedTour>
              <a class="viewall" href="India-Tour-Packages.aspx">View all &nbsp;<i class='fa fa-chevron-right' style="font-weight: lighter"></i></a>
            </div>
          </div>
          <div class="item"> <img src="Assets/images/fd-slider/Hyderabad.png" alt="Touch" loading="lazy"> 
            <div class="fd-content">
              <h3>Tours from Hyderabad</h3>
              <UCTourList:UCFixedTour runat = "server" ID = "ucFixedTourHyderabad" fldTourType = "FIXED_TOUR" fldTourOrigin="Hyderabad"></UCTourList:UCFixedTour>
              <a class="viewall" href="India-Tour-Packages.aspx">View all &nbsp;<i class='fa fa-chevron-right' style="font-weight: lighter"></i></a>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-4">
        <h2 class="title">Holiday Packages - <span>India</span></h2>
        <div class="holidaypkg"> <img src="Assets/images/bnr-holidays-packages.jpg" class="img-responsive" loading="lazy"/>
          <div class="row tourlist">

            <div class="col-md-6 col-xs-6"><a href="HolidayPackages.aspx?ORG=Honeymoon&Code=7">HoneyMoon/leisure Packages</a></div>
            <div class="col-md-6 col-xs-6"><a href="HolidayPackages.aspx?ORG=Pilgrimage&Code=8">Pilgrimage Tours</a></div>
            <div class="col-md-6 col-xs-6"><a href="HolidayPackages.aspx?ORG=LuxuryTrain&Code=13">Luxury Train Offers</a></div>
            <div class="col-md-6 col-xs-6"><a href="HolidayPackages.aspx?ORG=Kerala&Code=6">Kerala Tours</a></div>
          </div>
        </div>
      </div>
      <div class="col-md-3 col-sm-5 col-xs-12">
        <h2 class="title">Hot <span>Deals</span></h2>
        <div class="offerofmonth">
         <div class="item">
        <img src="Assets/images/EMI_Offer.jpg" loading="lazy"/></div>
      </div>
    </div>
  </div>
</section>
    <section id="intlpkg">
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <h2 class="title">International Packages</h2>
      </div>
    </div>
    <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <p><img src="Assets/images/dbl-line-left.png" class="img-responsive" loading="lazy"/></p>
        <p>Our Customers Favourite Destinations</p>
        <p><img src="Assets/images/dbl-line-right.png" class="img-responsive" loading="lazy"/></p>
      </div>
    </div>
    <div class="row">
      <div class="col-md-3">
                <div class="intlbox intlbox-home">
                
                   <a href="InternationalTours_Offer2-Thailand-BestOfFareastThailandMalaysiaAndSingapore10Days09Nights_155">
                	<div class="imgsection"><span class="customtag2">Fixed Tours<img src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                 <img src="Assets/images/intl-pkg/Fareast.jpg" loading="lazy"/></div>
                 <uc3:UCImageStrip ID="UCImageStrip3" runat="server" fldTourID="155" fldTourType="INTERNATIONAL_TOUR" />
                    </a>
                        
                </div>
                
                <div class="intlbox intlbox-home">
                
                   <a href="InternationalTours_Offer2-Dubai-BestOfDubai4Days3Nights_151">
                	<div class="imgsection"><span class="customtag2">Fixed Tours<img src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                 <img src="Assets/images/intl-pkg/Dubai.jpg" loading="lazy"/></div>
                 <uc3:UCImageStrip ID="UCImageStrip4" runat="server" fldTourID="151" fldTourType="INTERNATIONAL_TOUR" />
                    </a>
                        
                </div>
                 
      
      </div>
      <div class="col-md-3">
      <div class="intlbox intlbox-home">
                
                   <a href="InternationalTours_Offer2-Malaysia-BestOfMalaysiaAndSingaporeWith2NightsStarCruise_154">
                	<div class="imgsection"><span class="customtag2">Fixed Tours<img src="Assets/images/custom-arrow.png" loading="lazy"></span>
                 <img src="Assets/images/intl-pkg/Malaysia.jpg" loading="lazy"></div>
                 <uc3:UCImageStrip ID="UCImageStrip7" runat="server" fldTourID="154" fldTourType="INTERNATIONAL_TOUR" />
                <%-- <div class="textsection"><p>Tour Code : FMAS7</p><h3>Best Of Malaysia<br> And Singapore With Cruise 8 D / 7 N</h3><p>Package Starting @ <i class="fa fa-rupee"></i> 1,27,500 /-</p></div>--%>
                    </a>
                        
                </div>
      
       <div class="intlbox intlbox-home">
                
                   <a href="InternationalTours_Offer2-UnitedKingdom-BestOfEurope10Days09Nights_182">
                	<div class="imgsection"><span class="customtag2" loading="lazy">Fixed Tours<img src="Assets/images/custom-arrow.png" loading="lazy"></span>
                 <img src="Assets/images/intl-pkg/Europe.jpg" loading="lazy"></div>
                <uc3:UCImageStrip ID="UCImageStrip6" runat="server" fldTourID="182" fldTourType="INTERNATIONAL_TOUR" />
                 <%--<div class="textsection"><p>Tour Code : FED13</p><h3>Best Of European<br> Discovery 14 D / 13 N</h3><p>Package Starting @ <i class="fa fa-rupee"></i> 3,46,599 /-</p></div>--%>
                    </a>
                        
                </div>
                 
      
       
      </div>
      <div class="col-md-3">
      <div class="intlbox intlbox-home">
                
                   <a href="InternationalTours_Offer2-Thailand-BestOfThailand5Days4Nights_150">
                	<div class="imgsection"><span class="customtag2">Fixed Tours<img src="Assets/images/custom-arrow.png" loading="lazy"></span>
                 <img src="Assets/images/intl-pkg/Thailand.jpg"></div>
                 <uc3:UCImageStrip ID="UCImageStrip2" runat="server" fldTourID="150" fldTourType="INTERNATIONAL_TOUR" />
                <%-- <div class="textsection"><p>Tour Code : FBBP4</p><h3>Best Of Thailand 5 D / 4 N</h3><p>Package Starting @ <i class="fa fa-rupee"></i> 49,400 /-</p></div>--%>
                    </a>
                        
                </div>
      
      <div class="intlbox intlbox-home">
                
                   <a href="InternationalTours_Offer2-NorthAmerica%E2%80%93Newyork-BestOfAmerica14Days13Nights_181">
                	<div class="imgsection">
                	<span class="customtag2">Fixed Tours<img src="Assets/images/custom-arrow.png" loading="lazy"></span>
                 <img src="Assets/images/intl-pkg/1.jpg" loading="lazy"></div>
                 <uc3:UCImageStrip ID="UCImageStrip1" runat="server" fldTourID="181" fldTourType="INTERNATIONAL_TOUR" />
                <%-- <div class="textsection"><p>Tour Code : FUS13</p><h3>Best Of America 14 D / 13 N</h3><p>Package Starting @ <i class="fa fa-rupee"></i> 0 /-</p></div>--%>
                    </a>
                        
                </div>                 
            </div>
      <div class="col-md-3">
      <div class="intlbox intlbox-home">
                
                   <a href="InternationalTours_Offer2-Srilanka-BestOfSrilanka7Days6Nights_152">
                	<div class="imgsection" loading="lazy"><span class="customtag2">Fixed Tours<img src="Assets/images/custom-arrow.png" loading="lazy"></span>
                 <img src="Assets/images/intl-pkg/Srilanka.jpg" loading="lazy"></div>
              <uc3:UCImageStrip ID="UCImageStrip5" runat="server" fldTourID="152" fldTourType="INTERNATIONAL_TOUR" />
              <%--   <div class="textsection"><p>Tour Code : FRSL5</p><h3>Best Of Sri<br> Lanka-Ramayana Trails 6 D / 5 N</h3><p>Package Starting @ <i class="fa fa-rupee"></i> 44,000 /-</p></div>--%>
                    </a>
                        
                </div>
      
                 <div class="intlbox intlbox-home">
                
                   <a href="International-Packages.aspx?off=1">
                	<div class="imgsection">
                 <img src="Assets/images/intl-pkg/8.jpg" loading="lazy"></div>
                
                 
                    </a>
                        
                </div>
      </div>
    </div>
  </div>
</section>
 <style>
  #ownhotel {
    padding: 60px 0;
    background-color: #f9f9f9;
  }

  #ownhotel .title {
    font-size: 32px;
    font-weight: bold;
    margin-bottom: 20px;
    position: relative;
  }

  #ownhotel .title span {
    color: #ff6600;
  }

  #ownhotel .block {
    overflow: hidden;
    border-radius: 15px;
    box-shadow: 0 6px 20px rgba(0, 0, 0, 0.1);
    transition: transform 0.3s ease;
    background-color: #fff;
    margin-bottom: 30px;
  }

  #ownhotel .block img {
    width: 100%;
    height: auto;
    transition: transform 0.4s ease;
    display: block;
  }

  #ownhotel .block:hover img {
    transform: scale(1.05);
  }

  #ownhotel .hotelname {
    text-align: center;
    font-size: 18px;
    font-weight: 600;
    padding: 15px;
    background: #fff;
    color: #333;
  }

  @media (max-width: 767px) {
    #ownhotel .title {
      font-size: 26px;
    }
  }
</style>

<section id="ownhotel">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <p><img src="Assets/images/dbl-line-left-gray.png" loading="lazy" alt=""></p>
        <h2 class="title">Our Own <span>Hotels</span></h2>
        <p><img src="Assets/images/dbl-line-right-gray.png" loading="lazy" alt=""></p>
      </div>
    </div>
    <div class="row">
      <div class="col-md-4 col-sm-6">
        <div class="block">
          <a href="hotel-southern.aspx?HTLREG=DEL">
            <img src="Assets/images/own-hotel1.jpg" loading="lazy" alt="Hotel Southern Delhi">
            <div class="hotelname">Hotel Southern - Delhi</div>
          </a>
        </div>
      </div>
      <div class="col-md-4 col-sm-6">
        <div class="block">
          <a href="HotelSouthernGrandVijayawada.aspx">
            <img src="Assets/images/own-hotel2.jpg" loading="lazy" alt="Southern Grand Vijayawada">
            <div class="hotelname">Southern Grand - Vijayawada</div>
          </a>
        </div>
      </div>
      <div class="col-md-4 col-sm-6">
        <div class="block">
          <a href="hotel-southern-jaipur.aspx">
            <img src="Assets/images/own-hotel3.jpg" loading="lazy" alt="ZONE By The Park Jaipur">
            <div class="hotelname">ZONE By The Park - Jaipur</div>
          </a>
        </div>
      </div>
    </div>
  </div>
</section>

 <style>
  #vehiclesection {
    padding: 60px 0;
    background-color: #fff;
  }

  #vehiclesection .block {
    background: #fff;
    border-radius: 15px;
    overflow: hidden;
    box-shadow: 0 4px 18px rgba(0, 0, 0, 0.1);
    margin-bottom: 30px;
    transition: transform 0.3s ease;
  }

  #vehiclesection .block:hover {
    transform: translateY(-5px);
  }

  #vehiclesection .block img {
    width: 100%;
    height: auto;
    transition: transform 0.4s ease;
  }

  #vehiclesection .block:hover img {
    transform: scale(1.05);
  }

  #vehiclesection .block-hd {
    padding: 15px;
    text-align: center;
  }

  #vehiclesection .block-hd .title {
    font-size: 20px;
    font-weight: bold;
    margin: 0;
    color: #333;
  }

  #vehiclesection .block-links {
    padding: 0 15px 15px;
    text-align: center;
  }

  #vehiclesection .block-links a {
    display: block;
    margin: 5px 0;
    color: #007bff;
    text-decoration: none;
    font-weight: 500;
    transition: color 0.3s;
  }

  #vehiclesection .block-links a:hover {
    color: #ff6600;
  }

  /* MICE Section */
  .micecarousel {
    background: #f7f7f7;
    padding: 20px;
    border-radius: 15px;
    box-shadow: 0 4px 18px rgba(0, 0, 0, 0.1);
  }

  .micecarousel .title {
    font-size: 24px;
    font-weight: 600;
    text-align: center;
    margin-bottom: 20px;
  }

  .micecarousel .item {
    position: relative;
    overflow: hidden;
    border-radius: 12px;
  }

  .micecarousel .item img {
    width: 100%;
    height: auto;
    display: block;
    transition: transform 0.3s ease;
  }

  .micecarousel .item:hover img {
    transform: scale(1.03);
  }

  .micecarousel .txtdiv {
    position: absolute;
    bottom: 0;
    width: 100%;
    background: rgba(0,0,0,0.6);
    color: #fff;
    text-align: center;
    padding: 10px;
    font-size: 16px;
  }

  @media (max-width: 767px) {
    .micecarousel .title {
      font-size: 20px;
    }
  }
</style>

<section id="vehiclesection">
  <div class="container">
    <div class="row">
      <div class="col-md-3 col-sm-6">
        <div class="block block-car">
          <a href="Car-Coach-Rental.aspx?ORG=All">
            <img src="Assets/images/car-rental.jpg" class="img-responsive" loading="lazy" alt="Car Coach Rental"/>
          </a>
          <div class="block-hd">
            <h2 class="title">Car / Coach Rental</h2>
          </div>
          <div class="block-links">
            <a href="Car-Coach-Rental.aspx?ORG=All">Medium & Large Cars</a>
            <a href="Car-Coach-Rental.aspx?ORG=All">Coaches (25–53 Seater)</a>
          </div>
        </div>
      </div>

      <div class="col-md-3 col-sm-6">
        <div class="block block-ltc1">
          <a href="LFC-Home.aspx?LTC=1">
            <img src="Assets/images/ltc-lfc-tours.jpg" class="img-responsive" loading="lazy" alt="LTC LFC Tours"/>
          </a>
          <div class="block-hd">
            <h2 class="title">LTC / LFC Tours</h2>
          </div>
        </div>
        <div class="block block-ltc2">
          <a href="HolidayPackages.aspx?ORG=LuxuryTrain&Code=13">
            <img src="Assets/images/luxury-train.jpg" class="img-responsive" loading="lazy" alt="Luxury Trains"/>
          </a>
          <div class="block-hd">
            <h2 class="title">Luxury Trains</h2>
          </div>
        </div>
      </div>

      <div class="col-md-6">
        <div class="micecarousel posrel">
          <h2 class="title">MICE</h2>
          <div id="mice-slider" class="owl-carousel">
            <div class="item">
              <img src="Assets/images/mice/2.jpg" alt="MICE Image 1" loading="lazy"/>
              <div class="txtdiv">Meetings, Incentives, Conferences, Exhibitions</div>
            </div>
            <div class="item">
              <img src="Assets/images/mice/3.jpg" alt="MICE Image 2" loading="lazy"/>
              <div class="txtdiv">Meetings, Incentives, Conferences, Exhibitions</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>

<section id="blog" style="padding-bottom: 7px">
  <div class="container">
   <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <p><img src="Assets/images/dbl-line-left-gray.png" loading="lazy"/></p>
        <h2 class="title">Latest from our <span>blogs</span></h2>
        <p><img src="Assets/images/dbl-line-right-gray.png" loading="lazy"/></p>
      </div>
    </div>
    
    <!----- User control ---------->
  <uc2:ucBlog ID="ucBlog1" runat="server" fldBlogCount = "3" />    
    
  </div>
</section>
    <div>
        <div class="modal fade" id="modal-package">
        <div class="popup__inner">
            <div class="popup__imgWrapper">
                <a class="close" data-dismiss="modal" style="right: -15px !important; top: -12px">X</a>
				<%=strHomePageBanner%> 
                <%--<asp:Image  runat="server" id="ImgHmBanner" AlternateText="" CssClass="popup__img" Height="600px" />--%>
                <%--<a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=152&ofr=2"> <img src="images/Ramayana-Trail-Pop-Up.png" alt="" class="popup__img" height="600px" /></a>--%>
                <div class="container popup__img" style="background-color: White;display:none;">
                    <div style="height: 450px; overflow: scroll;">
                        <div class="row subheadrow">
                            <div class="col-md-12">
                                <h1 class="title">
                                    <span>PUBLIC NOTICE FOR TRAVELLERS No 1 Dated 1st MAY 2021</span>
                                </h1>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="privacybox">
                                    <p>
                                        Dear Guest,</p>
                                    <p>
                                        Greetings from Southern Travels Pvt Ltd !!!
                                    </p>
                                </div>
                                <div class="privacybox">
                                    <p>
                                        As per the Directives of the Governments, for the health & safety of everyone and
                                        to restrict the spread of Second wave of COVID-19 which is more seriously spreading
                                        the cases as against the first one of the disease. There is daily spikes in the
                                        cases reported of COVID diseases in the Country which was well under the control
                                        till end of March, 2021. But its spurt started somewhere slowly and gradually from
                                        1st week of April, 2021 which is at its peak by end of April, 2021.
                                    </p>
                                    <p>
                                        The Hospitals are finding it difficult to provide medical facilities to all patients
                                        due to daily spurt in COVID patients. Though the Hospitals have scaled or are engaged
                                        in scaling testing facilities, beds, doctors, recruiting more medical and nursing
                                        staff etc. But there is acute shortage of medicines, oxygen, ventilators etc. as
                                        such they are unable to cope up with the situation and as such death reported are
                                        increasing due to lack of treatment to all patients. There is pressure on the Hospitals
                                        and other health care facilities which are running on full capacity and Health Care
                                        administration have warned that the peak of Second wave will hit India harder if
                                        this situation Continues. Therefore, the Government have no other options then to
                                        resort to lockdowns to break the chain and arrest the disease from further spreading.
                                    </p>
                                    <p>
                                        So, the Central Government had allowed States/ UT’s to take appropriate decision
                                        under the <b>“Disaster Management Act”</b> to declare night curfews , weekend curfews
                                        or mini lockdowns etc. depending upon the situation in their States and UT’s to
                                        arrest the second wave of the Covid patients. Hence, many States and UT’s had already
                                        declared lockdowns such as Delhi, Maharashtra, Gujarat, Punjab, Goa etc. and many
                                        other States are in the process of imposing it to control its spread in the coming
                                        weeks or extend it further. Thus, the situation is uncertain and unpredictable when
                                        the situation will be normalized.
                                    </p>
                                    Under the circumstances, Southern Travels Private Limited is prevented from operating
                                    tours under the “Disaster Management Act” to suspend all its tours starting from
                                    8th April, 2021 till 10th May, 2021 until further notice as a “Force Majeure” conditions
                                    imposed by the action of the Government since it has no control on such unprecedented
                                    situation due to Government orders and for the further safety of its Guests as well
                                    as under :-
                                    <ul>
                                        <li>Guests, have options to Reschedule or postpone their suspended tours due to lockdowns
                                            to future dates till end of 31st December, 2021 or extended period till 31st March,
                                            2022 with no cancellation charges and Tour Prices unchanged. If they wish further
                                            extension then the Prices charged shall be as per the Prices announced wef 1st April,
                                            2022. </li>
                                        <li>Accordingly, the advance paid by them shall be kept in the credit shell and they
                                            will be issued Credit Voucher Redeemable against future bookings by them. However,
                                            they will also have options to transfer or gift their bookings to their relatives
                                            and friends etc. so as to give you flexibility. </li>
                                        <li>However, if you wish to cancel the scheduled tours operated by us on such dates
                                            of Journey when tours are not suspended by STPL then in such an event the cancellations
                                            rules shall apply as per the T&C of the applicable tours if you choose to cancel
                                            the same.</li>
                                        <li>Guests may kindly also appreciate that as soon as you book the tours you agree with
                                            the T&C of such tours including the cancellation policy of the tours and the Company
                                            as well as published in our booklet, tickets and in the public domain on our web-site.
                                        </li>
                                        <li><b>Guests may kindly note as soon as the lockdown is lifted you have grace time
                                            of 5 days to reach/ arrive at the Ex- starting point of scheduled departures dates
                                            of the tours booked by you. So, accordingly the suspended tour dates shall stand
                                            rescheduled. If you don’t reach on such dates you shall be treated “NO –SHOW” travelers.
                                        </b></li>
                                    </ul>
                                    <p>
                                        Our Tourists may also note that, we are committed to provide excellent feel factor,
                                        quality services and shall observe extra care to monitor hygiene and sanitization
                                        requirements for the safety of our Guests post lockdowns. The STPL also expects
                                        from their Guests to carry COVID -19 negative tests reports, vaccination’s certificates,
                                        or any other prescribed documents so as to prove that they are a-systomatic in their
                                        own interest in order to fulfill quarantine protocols of the concerned States or
                                        UT’s etc.
                                    </p>
                                    <p>
                                        We look forward to resume at the earliest. However, the Guests can always reach
                                        us if they can arrive of their own at the visiting destinations and wish us to book
                                        their tours or any other services such as hotels, coach or a complete package tours
                                        in the unlock States and UT’s of the Guests though Ex- starting points of our tours
                                        may be under lockdowns. So, please Contact your respective Travel Executives on
                                        phone for any queries or assistance or write to <a href="mailto:tours@southUndererntravels.in">
                                            tours@southUndererntravels.in</a>
                                    </p>
                                    <p>
                                        Note; Decision regarding tours departing post lockdowns/ unlocks by the respective
                                        States/ UT’s shall be conducted as per the scheduled dates mentioned on your tickets
                                        of such tours depending on the Situation & Advisory/ Order/ Notifications of Government
                                        of India, State Government, UT’s regarding containment free zones etc. as well as
                                        Starting States, visiting States and or Residing States of the Guests. In the event
                                        of any changes in the schedule dates of departures the same will be notified to
                                        you.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
        
    </div>
    
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    <script src="Assets/js/jquery.newsTicker.js"></script>
    <script>

        var nt_example1 = $('#nt-example1').newsTicker({
            row_height: 32,
            max_rows: 3,
            duration: 4000,
            prevButton: $('#nt-example1-prev'),
            nextButton: $('#nt-example1-next')
        });

    </script>
    <script type="text/javascript" defer>
        function showNotice() {
            $('#modal-package').modal('show');
        }
        function showHomePageBanner() {
            var hv = $('#HdnHM').val();
            if (hv=='1')
                $('#modal-package').modal('show');   
                                        
        }
        $(document).ready(function ($) {

            $('#DivHmPopup').addClass('qe_open slideInRight');
            $('body').addClass('formOpen');
            checkCookie();

            //$('#modal-package').modal('show');
            showHomePageBanner();
            setTimeout(function () {
                $('#modal-package').modal('hide')
            }, 30000);


            //top close
            $('.topclose').click(function (e) {
                $('.topnote').slideUp();
                e.preventDefault();
            });

            // datepicker
            $('.txtdate').datepicker();
            $('.txtdate').on('change', function () {
                $('.datepicker').hide();
            });

            // carousel
            $("#hp-heroslider").owlCarousel({
                items: 1,
                autoPlay: true,
                itemsDesktop: [1170, 1],
                itemsDesktopSmall: [991, 1],
                itemsTablet: [768, 1],
                itemsTabletSmall: false,
                itemsMobile: [480, 1]
            });
            // carousel

            $("#fd-slider").owlCarousel({
                items: 1,
                pagination: false,
                // Navigation
                navigation: true,
                navigationText: ["<i class='fa fa-chevron-left'></i>", "<i class='fa fa-chevron-right'></i>"],
                rewindNav: true,
                scrollPerPage: false,
                itemsDesktop: [1170, 1],
                itemsDesktopSmall: [991, 1],
                itemsTablet: [768, 1],
                itemsTabletSmall: false,
                itemsMobile: [480, 1]
            });

            $("#mice-slider").owlCarousel({
                items: 1,
                pagination: false,
                // Navigation
                navigation: true,
                navigationText: ["<img src='Assets/images/arrow-prev.png'loading='lazy'>", "<img src='Assets/images/arrow-next.png' loading='lazy'/>"],
                rewindNav: true,
                scrollPerPage: false,
                autoplay: true,
                autoplayTimeout: 1000,
                autoplayHoverPause: true,
                itemsDesktop: [1170, 1],
                itemsDesktopSmall: [991, 1],
                itemsTablet: [768, 1],
                itemsTabletSmall: false,
                itemsMobile: [480, 1]
            });


        });
	    
    </script>
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
    <%--Popup Form Start --%>  
    <div class="qckenqwrap animated" style="" id="DivHmPopup">
    <div class="container">
        <div class="formwrap pull-right">
            <p class="closebtn" style="display:none;">
                <a href="#"><span class="glyphicon glyphicon-remove-circle" aria-hidden="true"></span>
                </a>
            </p>
            <div class="heading">
                <h4 class="title"><strong><span>Served more than 4 Million Happy Travelers!</span></strong></h4>
                <p>To build your dream holiday please fill the below details. Our expert will reach you.</p>
            </div>
            <ul class="row">
                <li class="col-md-6 col-sm-6 col-xs-6 paddingright0">
                    <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Full name"
                        MaxLength="50" ValidationGroup="FOOHome"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqCheckOutDel" runat="server" ControlToValidate="txtName"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOOHome" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                        ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Only alphabetic characters are allowed."
                        ValidationExpression="^[a-zA-Z ]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z ]*)*$" ValidationGroup="FOOHome"></asp:RegularExpressionValidator>
                    </li>
                <li class="col-md-6 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtPhone" runat="server" class="form-control" ValidationGroup="FOOHome"
                        placeholder="Phone number" MaxLength="15" onkeypress="javascript:return isNumberKey(event);"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhone"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOOHome" Display="Dynamic"></asp:RequiredFieldValidator>
                    </li>
            </ul>
            <ul class="row">
                <li class="col-md-6 col-sm-6 col-xs-6 paddingright0">
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"
                        MaxLength="50" ValidationGroup="FOOHome"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOOHome" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="Reguemail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Please enter valid email id." SetFocusOnError="True" ValidationGroup="FOOHome"
                        Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </li>
                <li class="col-md-6 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder="City of Residence"
                        ValidationGroup="FOOHome" MaxLength="50"> </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCity"
                        Display="Dynamic" ErrorMessage="Only alphabetic characters are allowed." ValidationExpression="^[a-zA-Z ]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z ]*)*$"
                        ValidationGroup="FOOHome"></asp:RegularExpressionValidator>
                    </li>
            </ul>            
            <ul class="row captchaRow">
                <li >
                    <div id="dvCaptchaF">
                    </div>                       
                        <div class="col-md-5">
                        <asp:TextBox ID="txtCaptcha" runat="server" ValidationGroup="FOOHome" autocomplete="off" placeholder="Enter Captcha"
                            AutoCompleteType="None" MaxLength="10" CssClass="form-control"></asp:TextBox>
                         </div>
                         <div class="col-md-4 col-xs-6">
                          <img src="JpegImage.aspx?cache=1394701635527" id="captchImg" alt="captcha" width="110px"  loading="lazy"/>
                         </div>
                         <div class="col-md-3 col-xs-6">
                          <img id="refresh_captcha" src="Assets/images/captcha_refresh.jpg" style="height:28px; cursor:pointer;" loading="lazy"/>
                         </div>
                    
                            
                       <asp:RequiredFieldValidator ID="RequiredFieldtxtCaptcha" CssClass="errorMessage" ValidationGroup="FOOHome" ForeColor="Red"
                       runat="server" ControlToValidate="txtCaptcha" Display="Dynamic" ErrorMessage="Enter Captcha"></asp:RequiredFieldValidator>
                        
                        
                </li>
            </ul>            
            
            <ul class="row btnRow">
                <li class="col-md-12">
                      	
                    <asp:Button ID="btnSubmitPop" runat="server" Text="Submit" OnClientClick="ga('send', 'event', { eventCategory: 'quick enquiry', eventAction: 'enquiry'});"
                        OnClick="btnSubmitPop_Click" class="btn pull-right" ValidationGroup="FOOHome" />
                        <input type="button" id="BtnMesgClose" class="btn pull-right" value="Close" />
                         <%--<asp:Button ID="BtnMesgClose1" runat="server" Text="Close" class="btn pull-right"  OnClientClick="SetBtnMesg();return false;"/> --%>
                </li>
            </ul>
        </div>
    </div>
</div>
<%--Popup Form End --%>
    </form>
    
    <!-- The Modal Popup -->
    <div id="myModal" class="modal">
        <!-- Modal content -->
        <div class="modal-content">
            <span class="closePopup">&times;</span>
            <input type="button" id="btnGotIt" class="btn btn-success pull-right btnGotIt" value="Got It!" />
            <p>
                We use cookies to provide you the most relevant information and ensure you get the
                best experience on our website. By using our website, you consent to our use of
                cookies.</p>
        </div>
    </div>
    <!--End of Model Popup-->
</body>


<style>
        body
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        /* The Modal (background) */.modal
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 10px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        /* Modal Content */.modal-content
        {
            position: fixed;
            bottom: 0;
            padding: 20px;
            border: 1px solid #888;
            width: 78%;
            height: 11%;
            background-color: #BB1E17;
            color: #F9E8E8;
        }
        /* The Close Button */.closePopup
        {
            color: #F9E8E8;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }
        .closePopup:hover, .close:focus
        {
            color: #F9E8E8;
            text-decoration: none;
            cursor: pointer;
        }
        .btn-success
        {
            color: #fff;
            background-color: #5cb85c;
            border-color: #4cae4c;
        }
        .pull-right
        {
            float: right !important;
            margin-right: 15px;
            margin-left: 17px;
        }
        .swal2-popup {
          z-index: 99999 !important; 
        }

        #DivHmPopup {
          z-index: 1000 !important; 
        }

        .swal2-backdrop {
          z-index: 99998 !important;  
        }

</style>
<script defer>
    window.onload = function () {
        modal.style.display = "block";
        checkCookie();
    }

    // Get the modal
    var modal = document.getElementById("myModal");

    // Get the button that opens the modal
    var btn = document.getElementById("myBtn");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("closePopup")[0];

    var btnGotIt = document.getElementById("btnGotIt");

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }
    btnGotIt.onclick = function () {
        setCookie("GotItcookies", "GotItcookies", 365);
        modal.style.display = "none";
    }
    BtnMesgClose.onclick = function () {//debugger
        setCookiehr("GotPopcookies", "GotPopcookies", 4);
        //DivHmPopup.style.display = "none";
        DivHmPopup.className = "qckenqwrap animated";
        document.querySelector('body').classList.remove('formOpen');
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
    function checkCookie() {
        var GotItcookies = getCookie("GotItcookies");
        var GotPopcookies = getCookie("GotPopcookies");
        if (GotItcookies != null && GotItcookies != "") {
            modal.style.display = "none";
        }
        if (GotPopcookies != null && GotPopcookies != "") {
            DivHmPopup.className = "qckenqwrap animated";
            document.querySelector('body').classList.remove('formOpen');
            setTimeout(function () {
                $('#modal-package').modal('hide')
            }, 30000);
        }
    }
    function getCookie(c_name) {
        var i, x, y, ARRcookies = document.cookie.split(";");
        for (i = 0; i < ARRcookies.length; i++) {
            x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
            y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
            x = x.replace(/^\s+|\s+$/g, "");
            if (x == c_name) {
                return unescape(y);
            }
        }
    }
    function setCookie(c_name, value, exdays) {
        var exdate = new Date();
        exdate.setDate(exdate.getDate() + exdays);
        var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
        document.cookie = c_name + "=" + c_value;
    }
    function setCookiehr(c_name, value, exdays) {
        var exdate = new Date();
        exdate.setDate(exdate.getTime() + (4 * 3600 * 1000));
        var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
        document.cookie = c_name + "=" + c_value;
    }

    function ValidSubmitPop() {
        const name = document.getElementById('<%=txtName.ClientID%>');
      const phone = document.getElementById('<%=txtPhone.ClientID%>');
      const email = document.getElementById('<%=txtEmail.ClientID%>');
    const captcha = document.getElementById('<%=txtCaptcha.ClientID%>');
    const submitBtn = document.getElementById('<%=btnSubmitPop.ClientID%>');

        const fields = [
            { element: name, message: "Please enter the name." },
            { element: phone, message: "Please enter the phone." },
            { element: email, message: "Please enter the email." },
            { element: captcha, message: "Please enter Captcha Text." }
        ];

        for (const field of fields) {
            if (!field.element.value.trim()) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: field.message,
                    confirmButtonColor: '#f2572b'
                }).then(() => {
                    field.element.focus();
                });
                return false;
            }
        }

        submitBtn.style.display = 'none'; // hide the button only if validation passed
        return true;
    }
</script>



</html>
