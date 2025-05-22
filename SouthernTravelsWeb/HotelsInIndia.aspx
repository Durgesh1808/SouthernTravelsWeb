<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelsInIndia.aspx.cs" Inherits="SouthernTravelsWeb.HotelsInIndia" %>

<%@ Register Src="UserControl/UCHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UCFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Holiday | Hotels | Accommodation</title>
    <meta id="mtDescription" name="Description" content="At Southern Travels, We have a wide list of accommodation in India to make your holiday experience more comfortable and memorable." />
    <meta id="mtKeywords" name="Keywords" content="tour operator in india, domestic hotel, domestic hotel bookings, international hotel bookings, budget hotels, best hotels in india, best international hotels" />
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
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
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-hotels.jpg)">
  <div class="herobanner">

    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="HOTEL_IN_INDIA"/>
    
  </div></header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <section class="innersection2">
    <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <h1 class="title mrgnbtmh1">Hotels in <span>India</span></h1>
       </div>
    </div>
    <div class="formwrap innerforms">
     <iframe src="/HtmlPages/Southerntravelhotels.htm" height="850" width="100%"></iframe>
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
