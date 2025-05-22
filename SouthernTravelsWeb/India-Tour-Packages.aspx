<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="India-Tour-Packages.aspx.cs" Inherits="SouthernTravelsWeb.India_Tour_Packages" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcTourLink.ascx" TagName="ucTourLink" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>India Tour Packages | Coach Tours in India | Budget Tour Packages | India Tours
    </title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="Description" content="Southern Travels India - Tour and Travel Agency  offer exclusive tour services heritage tour packages, golden triangle tour packages, cultural tour packages, coach tours in india with adjustable cost, delhi-manali tour package, budget tour india, apply online here to book your tour and travel packages !" />
    <meta name="Keywords" content="india tour packages, india fixed departure tour packages, india package tours, tour packages for india, india tours, india fixed departure tours, tour india packages, india fixed tour packages, india tours, india travel packages, north india tours, south india tours, eastern india tours, india tourist destinations, india tourist packages, india tourism, golden triangle tours india, india travel packages, india holidays, tourism in india, southern travels india, haridwar-rishikesh, golden triangle travel packages, vaishnodevi yatra, kashmir tour, delhi to manali, amarnath yatra, hydrabad tour, package tours, coach tours in india, budget tours in india, packages in india, mussorie" />
    <meta name="robots" content="index,follow" />
    <meta name="Author" content="Designed by www.sirez.com" />
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-4994177-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>
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
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-fixed-tour-india.jpg)">
  <div class="herobanner">
    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="FIXED_DEPARTURE" />
    </div>
</header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <section class="innersection1">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <h1 class="title uppercase">Fixed Departure Tours - <span>India</span></h1>
      </div>
    </div>
    
     <div class="row tblrow">
    	<div class="col-md-6">
       		
            <div class="tourlistwrap">
            
            <div class="imgsection">
        	<img src="Assets/images/fdt.jpg" class="img-responsive" loading="lazy"/></div>
            
            <div class="heading"><h2 class="title">Tours from <span>New Delhi</span> </h2></div>
            
            <div class="tablewrap">
            	
                 <%if (Request.QueryString["ltc"] != null)
                   {%>
                                        <uc1:ucTourLink ID="ucTourLinkDelhi1" runat="server" fldTourType="FIXED_TOUR" fldTourOrigin="New Delhi"
                                            fldIsLTC="true" fldShowAllTour = "true" />
                                        <%}
                   else
                   { %>
                                        <uc1:ucTourLink ID="ucTourLinkDelhi2" runat="server" fldTourType="FIXED_TOUR" fldTourOrigin="New Delhi"
                                            fldIsLTC="false" fldShowAllTour="true"  />
                                        <%} %>
                
            </div>
            
            </div>
            
        </div>
        
        <div class="col-md-6">
        	
            <div class="tourlistwrap">
            
            <div class="imgsection">
        	<img src="Assets/images/fdt-2.jpg" class="img-responsive" loading="lazy"/></div>
            
            <div class="heading"><h2 class="title">Tours from <span>Hyderabad</span> </h2></div>
            
            <div class="tablewrap">
            	
                <%if (Request.QueryString["ltc"] != null)
                  {%>
                                        <uc1:ucTourLink ID="ucTourLinkHyderabad1" runat="server" fldTourType="FIXED_TOUR"
                                            fldTourOrigin="Hyderabad" fldIsLTC="true" />
                                        <%}
                  else
                  { %>
                                        <uc1:ucTourLink ID="ucTourLinkHyderabad2" runat="server" fldTourType="FIXED_TOUR"
                                            fldTourOrigin="Hyderabad" fldIsLTC="false" />
                                        <%} %>
                
            </div>
            
            </div>
            
          <div class="tourlistwrap">
          
            
            <div class="tablewrap">
            	
                   <%if (Request.QueryString["ltc"] != null)
                     {%>
                                        <uc1:ucTourLink ID="ucTousvinay1" runat="server" fldTourType="FIXED_TOUR" fldTourOrigin="Vijayawada"
                                            fldIsLTC="true" />
                                        <%}
                     else
                     { %>
                                        <uc1:ucTourLink ID="ucTousvinay2" runat="server" fldTourType="FIXED_TOUR" fldTourOrigin="Vijayawada"
                                            fldIsLTC="false" />
                                        <%} %>
            </div>
            
            </div>
            
            
             <div class="tourlistwrap">
            
            
            <div class="heading"><h2 class="title">Tours from <span>Chennai</span> </h2></div>
            
            <div class="tablewrap">
            	
                   <%if (Request.QueryString["ltc"] != null)
                     {%>
                                        <uc1:ucTourLink ID="ucTourLinkChennai1" runat="server" fldTourType="FIXED_TOUR" fldTourOrigin="Chennai"
                                            fldIsLTC="true" />
                                        <%}
                     else
                     { %>
                                        <uc1:ucTourLink ID="ucTourLinkChennai2" runat="server" fldTourType="FIXED_TOUR" fldTourOrigin="Chennai"
                                            fldIsLTC="false" />
                                        <%} %>
            </div>
            
            </div>

            <div class="tourlistwrap">
            
            
            
            
           <div class="heading"><h2 class="title">Tours from <span>Ahmedabad</span> </h2></div>
             
             
            <div class="tablewrap">
            	
                   <%if (Request.QueryString["ltc"] != null)
                     {%>
                                        
                                        <uc1:ucTourLink ID="ucTourLink1" runat="server" fldTourType="FIXED_TOUR" fldTourOrigin="Ahmedabad"
                                            fldIsLTC="true" />
                                        <%}
                     else
                     { %>
                                        <uc1:ucTourLink ID="ucTourLink2" runat="server" fldTourType="FIXED_TOUR" fldTourOrigin="Ahmedabad"
                                            fldIsLTC="false" />
                                        <%} %>
            </div>
            
            </div>

            
            
            
        </div>
        
    </div>
    
    
  </div>
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    </form>
</body>
</html>
