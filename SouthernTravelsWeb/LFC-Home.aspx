<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LFC-Home.aspx.cs" Inherits="SouthernTravelsWeb.LFC_Home" %>

<%@ Register Src="UserControl/UcQuickSearch.ascx" TagPrefix="uc" TagName="QuickSearch" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="author" content="">
    <title>LFC Tours | Tours for Bank | Tour for Government Employees </title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="Description" content="Southern Travels India – provides travel services for state & central government employees and LFC tour package. Choose your trip from a wide checklist." />
    <meta name="Keywords" content="ltc tours, lfc tours, tours for banks, tours for corporate sector organisations, tour package for central government employee, tours for state government employee, west india tour package, south india tours, pilgrimage tours, Rajasthan tours, international tour packages, north india tour packages" />
    <meta name="robots" content="index,follow" />
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
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-lfcltc.jpg)">
  <div class="herobanner">
<UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="LTC_LFC_TOUR" />
  </div>
  
</header>
    <section class="innersection1">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <h1 class="title"><span>LFC / LTC</span> - Tours<br>
        <span class="heading-subtext">We are running tours for central/ state Government Employees in collaboration with Central / State run Tourism Corporations.</span>
        </h1>
        
      </div>
    </div>
    
     <div class="row tblrow">
    	<div class="col-md-6">
       		
           <div class="ltctourbox row displaytable">
           	<div class="imgsection col-md-6 displaycol valigntop padding0">
            	<img src="Assets/images/ltc-tour.jpg" class="img-responsive" loading="lazy">
            </div>
            <div class="txtsection col-md-6 displaycol ">
            	<div class="row">
                <div class="col-md-12">
                	<h2 class="title">LTC Tours</h2>
                    <p>LTC Tours for State/ Central Government Employees
                    </p>
                    <%--<p class="btnwrap"><a href="#" class="btn">Book Now</a></p>--%>
                </div>
               
                </div>
                
            </div>
           </div>
           
            
        </div>
        
        <div class="col-md-6">
        	
             <div class="ltctourbox row displaytable lfctourbox">
           	<div class="imgsection col-md-6 displaycol valigntop padding0">
            	<img src="Assets/images/lfc-tour.jpg" class="img-responsive" loading="lazy">
            </div>
            <div class="txtsection col-md-6 displaycol">
            	<div class="row">
                <div class="col-md-12">
                	<h2 class="title">LFC Tours</h2>
                                       <p>LFC Tours for Banks/LIC/ Corporate Sector organizations / some of the public sector undertakings.</p>
                    </p>
                    <p class="btnwrap"><a href="India-Tour-Packages.aspx?LTC=1" class="btn">Book Now</a></p>
                </div>
               
                </div>
                
            </div>
           </div>
            
            
        </div>
        
    </div>
    
    
  </div>
</section>
    <!-- Main Content End -->
    <!-- widget -->
    <div class="homePageWigdet">
        <div class="searchWidget">
            <div class="searchWidgetContainer">
                <div class="hero-tabsection">
                    <uc:QuickSearch runat="server" ID="ucQuickSearch" fldShowBanner="false" />
                </div>
            </div>
            <div class="widgetHandle">
                <img loading="lazy" src="Assets/images/widget-icon-inactive.jpg" id="widgetHandle" class="iconInactive"></div>
        </div>
    </div>
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    <script type="text/javascript">
        $(function () {
            $('#widgetHandle').click(function () {
                //alert('');

                if ($(this).hasClass('iconActive')) {
                    //alert('');
                    $(this).attr('src', 'Assets/images/widget-icon-inactive.jpg').removeClass('iconActive').addClass('iconInactive');
                    $(".searchWidget").animate({ "left": "-450px" }, "slow").css('z-index', '1');
                    //$('#twHandle').css('opacity','1');
                    $(".twWidget").css('z-index', '1');
                }

                else {
                    $(this).attr('src', 'Assets/images/widget-icon-active.jpg').removeClass('iconInactive').addClass('iconActive');
                    $(".searchWidget").animate({ "left": "0px" }, "slow").css('z-index', '100');
                }

            });

            $('select.form-control').selectpicker({
                style: 'btn-info',
                size: 4
            });

        });
    </script>
    </form>
    <script type="text/javascript">
        setTimeout(function () {
            var a = document.createElement("script");
            var b = document.getElementsByTagName('script')[0];
            a.src = document.location.protocol + "//dnn506yrbagrg.cloudfront.net/pages/scripts/0011/9178.js?" + Math.floor(new Date().getTime() / 3600000);
            a.async = true; a.type = "text/javascript"; b.parentNode.insertBefore(a, b)
        }, 1);
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
</body>
</html>
