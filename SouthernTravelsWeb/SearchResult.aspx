<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="SouthernTravelsWeb.SearchResult" %>


<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcSearchTours.ascx" TagName="UCSearchTours" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
   <title>Southern Travels - Tour and Travel Agency | Holiday Packages in India| Car Rental
        Services</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="Description" content="Southern Travels India - Tour and Travel Agency  offer exclusive tour services heritage tour packages, golden triangle tour packages, cultural tour packages, coach tours in india with adjustable cost, delhi-manali tour package, budget tour india, apply online here to book your tour and travel packages !" />
    <meta name="Keywords" content="india tour packages, india fixed departure tour packages, india package tours, tour packages for india, india tours, india fixed departure tours, tour india packages, india fixed tour packages, india tours, india travel packages, north india tours, south india tours, eastern india tours, india tourist destinations, india tourist packages, india tourism, golden triangle tours india, india travel packages, india holidays, tourism in india, southern travels india, haridwar-rishikesh, golden triangle travel packages, vaishnodevi yatra, kashmir tour, delhi to manali, amarnath yatra, hydrabad tour, package tours, coach tours in india, budget tours in india, packages in india, mussorie" />
    <meta name="robots" content="index,follow" />
    <meta name="Author" content="Designed by www.sirez.com" />

    <script type="text/javascript">

        (function(i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function() {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-4994177-1', 'auto');
        ga('require', 'displayfeatures');
        ga('send', 'pageview');


    </script>

 

</head>
<body>
 <form id="form1" runat="server">
    <!-- Header Start -->
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-searchpage.jpg)">
  <div class="herobanner">

    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" />
    
  </div></header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <uc1:UCSearchTours ID="UCSearchTours1" runat="server"  />
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    </form>
</body>
</html>

