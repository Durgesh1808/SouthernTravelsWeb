<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="SouthernTravelsWeb.ThankYou" %>


<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Southern India Travel,South India Travel Packages,Travel Packages to South India
    </title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <meta content="Southern India Travel - South India Travel guides offering southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package."
        name="Description" />
    <meta content="southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package, south india beaches travel packages, south india holiday travel packages, holiday travel package to south india, southern india package travel, south india tourism, tourism in south india, holidays travel in southern india, kerala backwater travel packages in india, north india tour packages, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours, southern travels india, southerntravelsindia, Sirez"
        name="Keywords" />
    <meta content="index,follow" name="robots" />
    <meta content="Designed  www.Sirez.com" name="Author" />
    <meta content="MSHTML 6.00.2900.2180" name="GENERATOR" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientscript" content="Javascript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <!-- Begin Inspectlet Embed Code -->

    <script type="text/javascript" id="inspectletjs">
    window.__insp = window.__insp || [];
    __insp.push(['wid', 996100346]);
    (function() {
        function ldinsp() { if (typeof window.__inspld != "undefined") return; window.__inspld = 1; var insp = document.createElement('script'); insp.type = 'text/javascript'; insp.async = true; insp.id = "inspsync"; insp.src = ('https:' == document.location.protocol ? 'https' : 'http') + '://cdn.inspectlet.com/inspectlet.js'; var x = document.getElementsByTagName('script')[0]; x.parentNode.insertBefore(insp, x); };
        setTimeout(ldinsp, 500); document.readyState != "complete" ? (window.attachEvent ? window.attachEvent('onload', ldinsp) : window.addEventListener('load', ldinsp, false)) : ldinsp();
    })();
    </script>

    <!-- End Inspectlet Embed Code -->
    <style>
    .subheadrow h3 {
        margin-top: 50px!important;
    }
    .subheadrow h3 a{
        font-weight: bold;
        color: #dc8244!important;
    }
    .subheadrow h3 span{
        display: block;
        text-align: right;
    }

    .innersection2 h1,
.innersection2 h2,
.innersection2 h3 {
  font-family: 'Segoe UI', sans-serif;
}

.innersection2 a.btn {
  transition: all 0.3s ease-in-out;
}

.innersection2 a.btn:hover {
  background-color: #f1572b;
  border-color: #dc8244;
  color: white;
}

    </style>
<!-- Google tag (gtag.js) -->
<script async src="https://www.googletagmanager.com/gtag/js?id=AW-10777805346"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'AW-10777805346');
</script>

<!-- Event snippet for Submit lead form conversion page -->
<script>
  gtag('event', 'conversion', {'send_to': 'AW-10777805346/oBUICP7pjIUYEKKEoZMo'});
</script>
<!-- WHATSAPP journey code  -->
<script id="gs-sdk" src="https://web-widget.gupshup.io/v3/demo/static/js/sdk.js" appId="130b2aaf-0bd4-44a1-9626-398815363c27" ref="ar"></script>    
</head>
<body onunload="checkBack();">
    <form id="Form1" method="post" runat="server">
    <input type="hidden" id="type" value="" runat="server" />
    <header class="posrel innerheader" style="background-image: url(/Assets/images/banner-searchpage.jpg)">
  <div class="herobanner">

    <UCHeader:UCHeaderEndUser ID="UCHeaderEndUser1" runat="server" />
    
  </div></header>
    <!-- Header End -->
    <!-- Main Content Start -->
   <section class="py-5 bg-light innersection2">
  <div class="container innerforms">
    <div class="row justify-content-center">
      <div class="col-lg-10 text-center">
        <h1 class="mb-4" style="font-weight: 600; color: #f1572b;">
  Thank you for choosing Southern Travels!
</h1>


        <!-- User Submission Confirmation -->
        <div id="divother" runat="server">
          <h2 class=" mb-3">Your submission has been received.</h2>
          <h3 class="title mb-3">Our destination expert will reach you soon.</h3>
          <h4 class="mb-4" style="font-size: 1rem;">
            You can also reach us at 
            <a href="mailto:tours@southerntravels.in" class="text-primary">tours@southerntravels.in</a> 
            or call us on 
            <a href="tel:1800110606" class="text-primary">1800-110-606</a>
          </h4>
          <a href="index.aspx" class="btn btn-outline-primary btn-lg mt-3">← Go to Home</a>
        </div>

        <!-- Agent Submission Confirmation -->
        <div id="DivAgent" runat="server" visible="false">
          <h2 class="text-success mb-3">Your submission has been received.</h2>
          <h3 class="title mb-3">Our executive will reach you soon.</h3>
          <h4 class="mb-4" style="font-size: 1rem;">
            You can also reach us at 
            <a href="mailto:franchise@southerntravels.in" class="text-primary">franchise@southerntravels.in</a> 
            or call us on 
            <a href="tel:9289780951" class="text-primary">92897-80951</a>
          </h4>
          <a href="index.aspx" class="btn btn-outline-primary btn-lg mt-3">← Go to Home</a>
        </div>

      </div>
    </div>
  </div>
</section>

    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooterEndUser1" runat="server" />
    <!-- Footer Start -->
    </form>
</body>
</html>

