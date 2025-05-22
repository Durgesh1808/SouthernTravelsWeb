<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HolidayPackages.aspx.cs" Inherits="SouthernTravelsWeb.HolidayPackages" %>

<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcSearchTours.ascx" TagName="UCSearchTours" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title id="title" runat="server"></title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta runat="server" id="mtagDescription" name="Description" content="Book online for best north India tour packages from southerntravelsindia, enjoy your holiday at best heritage and historical resort place of north India, agra delhi tour, delhi Jaipur tour, golden triangle tours, rajasthan tours, himachal, Kashmir, uttranchal, nainital tours, honeymoon tours in north india, Jaipur, Ajmer, north india tour from Hyderabad. Book at at +91-11- 4353 2800." />
    <meta name="Keywords" content="north india tour holiday, north india holidays tour packages, holiday tours of north india, north india tours, north india tour, northern india holiday tour packages for north india, northern india holiday tour, northern india holiday packages, tour packages for north india, northern india tourism, north india tour from bangalore, chennai, hyderabad, mumbai, coimbatore, agra Tour, tajmahal tour, lotus temple, qutab minar, char dham Yatra, 4 dham, badrinath – kedarnath yatra, delhi to jaipur, india gate, delhi tourism, around delhi, nepal tour, holiday package for north india, southern travels tour package in north india, fixed departure tour packages, mussoorie tour package, kullu-manali, Shimla-manali, rishikesh tour packages, north india golden triangle, tour agra-delhi-jaipur" />
    <meta name="robots" content="index,follow" />
    <meta name="Author" content="Designed by www.sirez.com" />
    <script type="text/javascript">

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
    <header class="posrel innerheader" style="background-image: url(/Assets/images/banner-searchpage.jpg)">
  <div class="herobanner">

    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server"  />
    
  </div></header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <uc1:UCSearchTours ID="UCSearchTours1" runat="server" />
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    </form>
</body>
</html>
