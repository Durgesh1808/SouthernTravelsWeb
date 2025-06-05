<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact-us.aspx.cs" Inherits="SouthernTravelsWeb.contact_us" %>



<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Contact Us : Southern Travels</title>
    <meta name="Description" content="Southern Travels love to hear your query, contact us for any kind of enquiry related to tour packages, hotel, flight, car rental or other assistance." />
    <meta name="Keywords" content="india tour packages, india fixed departure tour packages, india package tours, tour packages for india, india tours, india fixed departure tours, tour india packages, india fixed tour packages, india tours, india travel packages, north india tours, south india tours, eastern india tours, india tourist destinations, india tourist packages, india tourism, india travel packages, india holidays, tourism in india, southern travels india" />
    <meta name="robots" content="index,follow" />
    <meta name="Author" content="Designed by www.sirez.com" />
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />


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
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <script language="javascript" type="text/javascript">

        function echeck(str) {
            var at = "@"
            var dot = "."
            var und = "_"
            var lat = str.indexOf(at)
            var lstr = str.length
            var ldot = str.indexOf(dot)
            if (str.indexOf(at) == -1) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter valid email id.',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }
            if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter valid email id.',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }
            if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter valid email id.',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }
            if (str.indexOf(at, (lat + 1)) != -1) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter valid email id.',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }
            if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter valid email id."',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }
            if (str.indexOf(dot, (lat + 2)) == -1) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter valid email id.',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }
            if (str.indexOf(" ") != -1) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter valid email id.',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }
            if ((str.indexOf("..") > -1) || (str.substring(str.length - 1, str.length) == dot)) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter valid email id.',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }
            if ((str.substring(0, 1) == und)) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter valid email id.',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }
            return true
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function Left(str, n) {
            if (n <= 0)
                return "";
            else if (n >= String(str).length)
                return str;
            else
                return String(str).substring(0, n);
        }


        function chkNumeric(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function CheckOnlyCharacter(evt) {
            var kk
            kk = (evt.which) ? evt.which : event.keyCode
            if ((kk >= 65 && kk <= 90) || (kk >= 97 && kk <= 122) || kk == 32 || kk == 190 || kk == 8 || kk == 9 || kk == 127 || kk == 16 || kk == 20 || kk == 46) {
                return true;
            }
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Please enter characters only.',
                confirmButtonColor: '#f2572b'
            });
            return false;
        }

        function CheckForCharacterAndNumeric(evt) {
            var kk
            kk = (evt.which) ? evt.which : event.keyCode
            if ((kk >= 65 && kk <= 90) || (kk >= 97 && kk <= 122) || kk == 32 || kk == 190 || kk == 8 || kk == 9 || kk == 127 || kk == 16 || kk == 20 || kk == 46 || (kk >= 48 && kk <= 57)) {
                return true;
            }
            return false;
        }


        function fnFeedbackVal() {

            var chek = true;
            if (document.getElementById("<%=txtFullName.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter Full Name.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtFullName.ClientID  %>").focus();
                return false
            }
            if (document.getElementById("<%=txtFeedEmail.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter Email.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtFeedEmail.ClientID  %>").focus();
                chek = false;
                return false;
            }
            if (document.getElementById("<%=txtFeedEmail.ClientID  %>").value != "") {
                if (echeck(document.getElementById("<%=txtFeedEmail.ClientID  %>").value) == false) {
                    document.getElementById("<%=txtFeedEmail.ClientID  %>").value = "";
                    document.getElementById("<%=txtFeedEmail.ClientID  %>").focus();
                    chek = false;
                    return false;
                }
            }
            if (document.getElementById("<%=txtMobile.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter Mobile.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtMobile.ClientID  %>").focus();
                chek = false;
                return false;
            }
            if (document.getElementById("<%=ddlPurpose.ClientID  %>").value == "Select Purpose") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please select Purpose.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=ddlPurpose.ClientID  %>").focus();
                chek = false;
                return false;
            }
            if (document.getElementById("<%=txtComments.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter Comments.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtComments.ClientID  %>").focus();
                chek = false;
                return false;
            }
        }
    
    
    </script>

    <script language="JavaScript" type="text/javascript">

        function MM_jumpMenu(targ, selObj, restore) { //v3.0
            eval(targ + ".location='" + selObj.options[selObj.selectedIndex].value + "'");
            if (restore) selObj.selectedIndex = 0;
        }

    </script>

    <style type="text/css">
        .anclink ul
        {
            margin: 0 !important;
            padding: 0 !important;
            width: 100% !important;
            background: none !important;
        }
        .anclink li
        {
            list-style: none;
            float: left;
            margin-right: 10px !important;
            background: none !important;
            padding-left: 2px !important;
            width: 180px;
        }
        .anclink li a
        {
            text-decoration: none;
            color: rgb(223, 65, 26) !important;
            background: none !important;
            height: 30px !important;
            padding: 2px 5px 4px !important;
            display: block;
            line-height: 15px !important;
        }
        .brpmenu
        {
            width: 180px;
            height: 25px;
            border: 1px solid #C8C8C8;
        }
    </style>
    <!-- Google Tag Manager -->

    <script>        (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({ 'gtm.start':
new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-WXRG7KM');</script>

    <!-- End Google Tag Manager -->
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
    } (window, document, 'script',
'https://connect.facebook.net/en_US/fbevents.js');
    fbq('init', '520605323053563');
    fbq('track', 'PageView');
</script>
<!-- End Meta Pixel Code -->
    <script type="text/javascript">
        var $zoho = $zoho || {}; $zoho.salesiq = $zoho.salesiq || { widgetcode: "f9285012553db7ccdec3cf907b30482c1f0e0a2bd9e18f0f2b52a1810adb9374cd30ce7a28be5ad051877c21011ab9a5", values: {}, ready: function () { } }; var d = document; s = d.createElement("script"); s.type = "text/javascript"; s.id = "zsiqscript"; s.defer = true; s.src = "https://salesiq.zoho.com/widget"; t = d.getElementsByTagName("script")[0]; t.parentNode.insertBefore(s, t); d.write("<div id='zsiqwidget'></div>");
    </script>

    <script src="https://cdn.pagesense.io/js/southerntravels/95bf3c0ba74f44f9baed4ddf90896ba3.js"></script>
<!-- Google tag (gtag.js) -->
<script async src="https://www.googletagmanager.com/gtag/js?id=AW-10777805346"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'AW-10777805346');
</script>
<!-- Google tag (gtag.js) -->
<!-- Event snippet for Submit lead form conversion page
In your html page, add the snippet and call gtag_report_conversion when someone clicks on the chosen link or button. -->
<script>
    function gtag_report_conversion(url) {
        var callback = function () {
            if (typeof (url) != 'undefined') {
                window.location = url;
            }
        };
        gtag('event', 'conversion', {
            'send_to': 'AW-10777805346/oBUICP7pjIUYEKKEoZMo',
            'event_callback': callback
        });
        return false;
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
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-contact.jpg)">
  <div class="herobanner">
    <UCHeader:UCHeaderEndUser ID="UCHeaderEndUser1" runat="server" fldMainSection="CONTACT_US"  />
      </div>
</header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <section class="innersection2">
  
   <section class="innersection2">
  
    <div id="fixedtabsection">
    <div class="container">
      <div class="row subheadrow">
        <div class="col-md-12">
          <h1 class="title"><span>Get In</span> Touch</h1>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="tabsection_inner">
            <ul class="nav nav-tabs">
              <li  id="licontactus" runat="server" ><a href="#contactus" data-toggle="tab">Contact us</a></li>
              <li id="libranch_offices" runat="server"><a href="#brand_stores" data-toggle="tab">Brand Stores</a></li>
              <li id="lipreferredsalesagents" runat="server" visible="true"><a href="#preferredsalesagents" data-toggle="tab">Preferred Sales Agents</a></li>
            </ul>
          </div>
        </div>
      </div>
      </div>
    </div>
    <div class="container">
    <div class="row contact-tabspace">
      <div class="col-md-12">
        <div class="tab-content tab-content-inner"> 
          
          <!-- contact us -->
          <div  id="contactus" runat="server">
          <div class="contact-data">
          <div class="detail">
          
          <div class="row">
          <div class="col-md-6">
           <div class="row">
          <div class="col-md-12"><h2 class="title">Corporate <span>Office</span></h2></div>
          
          </div>
          <div class="row">
          <div class="col-md-6">
          
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="location"></i></div>
          <h3>Southern Travels Private Limited</h3>
          <p>18/1, Arya Samaj Road,<br>
             Karol Bagh, New Delhi<br>
             Delhi-110005 (INDIA)</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us At</h3>
          <p>
          +91-11-43532800 (100 Lines),<br>
          43532806, 43532807, 28753466 
          </p>   
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="tollfree"></i></div>
          <h3>Toll Free</h3>
          <p>1800 11 0606</p>
          </address>
          <div class="clearfix"></div>
         
          </div>
          <div class="col-md-6">
<%--           <address class="fax">
          <div class="icondv"><i class="fax"></i></div>
          <h3>Fax No.</h3>
          <p>+91-11-28757308</p>
          </address>--%>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="mailto:enquiry@southerntravels.com?subject=Southern travels Pvt. Ltd. Mail Through southerntravelsindia.com">enquiry@southerntravels.com</a></p>
          <p><a href="mailto:tours@southerntravels.com?subject=Southern travels Pvt. Ltd. Mail Through southerntravelsindia.com">tours@southerntravels.com</a></p>
          </address>
          <div class="clearfix"></div>
           <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>For Marketing queries -Email us At</h3>
          <p><a href="mailto:marketing@southerntravels.com?subject=Southern travels Pvt. Ltd. Mail Through southerntravelsindia.com">marketing@southerntravels.com</a></p>          
          </address>
          <%--<address>
          <div class="icondv"><i class="sms"></i></div>
          <h3>SMS us</h3>
          <p>SOUTHERN &lt;requirement&gt; to 53030<br />e.g:- SOUTHERN "TOURS" <br /> OR "HOTEL" </p>
          </address>--%>
          </div>
         
          </div>
          </div>
          <div class="col-md-6"> <div class="con-map">
          <!--<iframe  src="https://www.google.com/maps/embed/v1/place?q=Southern+Travels,+Arya+Samaj+Road,+Karol+Bagh,+New+Delhi,+India&key=AIzaSyAN0om9mFmy1QN6Wf54tXAowK4eT0ZUPrU" width="100%" height="287" frameborder="0" style="border:0" allowfullscreen></iframe>-->
          <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3501.4438500311285!2d77.19312731508285!3d28.646425982412293!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xb98ccf4935af8f0b!2sSouthern+Travels!5e0!3m2!1sen!2s!4v1499752152510" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
          </div></div>
          </div>
          
         
          </div>
          <div class="form-dv">
          <div class="row">
          
         <%-- <div class="col-md-4">
           <div class="youmaylike">
              <h2 class="title">You May Also <span>Like</span></h2>
              <!-- slider --> 
              <!-- <img src="images/youmaylike/1.jpg" class="img-responsive"> -->
              
              <div id="like-slider" class="owl-carousel">
                <div class="item"> <img src="images/youmaylike/1.jpg" alt="Touch"> </div>
                <div class="item"> <img src="images/youmaylike/1.jpg" alt="Touch"> </div>
                <div class="item"> <img src="images/youmaylike/1.jpg" alt="Touch"> </div>
              </div>
            </div>
             <div class="sploffer">
              <h2 class="title">Special <span>Offer</span></h2>
              <!-- slider --> 
              <img src="images/spl-offer.jpg" class="img-responsive"> </div>
          </div>--%>
          
          <div class="col-md-8">
          <h2 class="title"><span>Enquiry</span> Form</h2>
          <p class="mrgnbtm20 clearfix">Do fill in the form below to help us know your requirement better.</p>
          <div class="formwrap">
    
    
  <div class="row mrgnbtminput">
    	<div class="col-md-6">
        <div class="inner-addon left-addon">
                <i class="glyphicon glyphicon-user"></i>
                 <asp:TextBox ID="txtFullName"  runat="server" MaxLength="250" ValidationGroup="FEValidation1"
                                                                class="form-control" placeholder="Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFullName"
                                                                Display="Dynamic" ErrorMessage="Please enter your name!" SetFocusOnError="True"
                                                                ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
        </div>
        </div>
        <div class="col-md-6">
        <div class="inner-addon left-addon">
                <i class="glyphicon glyphicon-envelope"></i>
                 <asp:TextBox ID="txtFeedEmail" runat="server" MaxLength="150" ValidationGroup="FEValidation1"
                                                                class="form-control" placeholder="Email"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFeedEmail"
                                                                Display="Dynamic" ErrorMessage="Please enter a valid email id!" SetFocusOnError="True"
                                                                ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="Reguemail" runat="server" ControlToValidate="txtFeedEmail"
                                                                ErrorMessage="Please enter valid email id." SetFocusOnError="True" ValidationGroup="FEValidation1"
                                                                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
       </div></div>
    </div>
    
     <div class="row mrgnbtminput">
    	<div class="col-md-6">
        <div class="inner-addon left-addon">
                <i class="glyphicon glyphicon-phone"></i>
                <asp:TextBox ID="txtMobile" runat="server" MaxLength="15" ValidationGroup="FEValidation1"
                                                                class="form-control" placeholder="Contact"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMobile"
                                                                Display="Dynamic" ErrorMessage="Please enter your contact number!" SetFocusOnError="True"
                                                                ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtMobile"
                                                                Display="Dynamic" ErrorMessage="Please enter contact No. in numerics." ValidationExpression="^[0-9]+$"
                                                                ValidationGroup="FEValidation1"></asp:RegularExpressionValidator>
        </div></div>
        <div class="col-md-6">
        <div class="inner-addon left-addon">
                <i class="glyphicon glyphicon-phone"></i>
                <asp:DropDownList ID="ddlPurpose" runat="server" class="form-control" ValidationGroup="FEFEValidation1">
                                                                <asp:ListItem Selected="True" Text="Select Purpose" Value="Select Purpose"></asp:ListItem>
                                                                <asp:ListItem Text="Careers" Value="Careers"></asp:ListItem>
                                                                <asp:ListItem Text="Hotel Contracting & Ground Handling" Value="Hotel Contracting & Ground Handling"></asp:ListItem>
                                                                <asp:ListItem Text="Marketing & Promotions" Value="Marketing & Promotions"></asp:ListItem>
                                                                <asp:ListItem Text="Media Planning" Value="Media Planning"></asp:ListItem>
                                                                <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqddlPurpose" runat="server" ControlToValidate="ddlPurpose"
                                                                Display="Dynamic" ErrorMessage="Please select your Purpose!." SetFocusOnError="True"
                                                                InitialValue="Select Purpose" ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
      <asp:FileUpload ID="flUpload" runat="server" Style="display: none;" />
        </div>
        </div>
    </div>
    <div class="row mrgnbtminput">
    	
        <div class="col-md-12">
        	<div class="inner-addon left-addon">
                <i class="glyphicon glyphicon-pencil"></i>
                 <asp:TextBox ID="txtComments" Columns="46" Rows="5" TextMode="MultiLine" runat="server"
                                                                Style="resize: none;" ValidationGroup="FEValidation1" class="form-control" placeholder="Suggestions / Feedback" Height="150px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="ReqtxtComments" runat="server" ControlToValidate="txtComments"
                                                                Display="Dynamic" ErrorMessage="Please enter your comments!." SetFocusOnError="True"
                                                                ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator runat="server" ValidationGroup="FEValidation1" ID="RegularExpressionValidator1"
                                                                Display="Dynamic" ControlToValidate="txtComments" ValidationExpression="^[\s\S]{0,500}$"
                                                                ErrorMessage="Please enter Comments in 500 characters." />
               
            </div>
        </div>
    	
    </div>
    
    <div class="row">
    	<%--<div class="col-md-6">
    	 <div class="g-recaptcha" runat="server" id="divrecaptcha" ></div>
                             </div>
                              <asp:Label ID="MessageLabel" runat="server" CssClass="txt" ForeColor="red"></asp:Label>--%>
          <div class="col-md-12">
             <ul class="row" style="list-style-type: none; padding-left: 0;">
             <li >
                 <div id="dvCaptchaF">
                 </div>
 
         
        
                     <div class="col-md-3">
                     <asp:TextBox ID="txtCaptcha" runat="server" ValidationGroup="FOO" autocomplete="off" Width="114px" placeholder="Enter Captcha"
                         AutoCompleteType="None" MaxLength="10" CssClass="form-control"></asp:TextBox>
                      </div>
                      <div class="col-md-2" style="margin-left: 49px;">
                       <img src="JpegImage.aspx?cache=1394701635527" id="captchImg" alt="captcha" width="110px" loading="lazy" />
                      </div>
                      <div class="col-md-2" style="margin-left: 53px;">
                       <img id="refresh_captcha" src="Assets/images/captcha_refresh.jpg" alt="captcha_refresh" style="height:28px; cursor:pointer;" loading="lazy"/>
                      </div>
     
             
                    <asp:RequiredFieldValidator ID="RequiredFieldtxtCaptcha" CssClass="errorMessage" ValidationGroup="FOO" ForeColor="Red"
                    runat="server" ControlToValidate="txtCaptcha" Display="Dynamic" ErrorMessage="Enter Captcha"></asp:RequiredFieldValidator>
         
         
             </li>
         </ul>
   </div>
    	</div>
     <div class="row">
    	<div class="col-md-6">
        <div class="btnwrap">
         <asp:Button ID="btnSend" class="commonbtn" runat="server" Text="Submit" ValidationGroup="FEFEValidation1" 
             OnClientClick = "ga('send', 'event', { eventCategory: 'contact us', eventAction: 'submit'});"
               OnClick="btnSend_Click"></asp:Button>    </div></div>
        <div class="col-md-6"></div>
    </div>
  
    
  </div>
          </div>
          </div>
          
          </div>
          </div>
          </div>
          <!-- end contact us --> 
          
          <!-- Brand Stores -->
          <div  id="brand_stores" runat="server" > 
            <div class="row">
            <div class="col-md-12">
            <h2 class="title">Branches in <span>India</span></h2>
            </div>
            </div>
            <asp:Repeater ID="RptTours" runat="server">                        
                        <ItemTemplate>
            
             <div class="row">
           <div class="col-md-4">
            <div class="con-map">                  
         <%#Eval("GoogleMap")%>
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
           <a href='brandstore.aspx?Id=<%#Eval("ID")%>' target="_blank" ><h3><%#Eval("BranchName")%></h3></a>              
              <p><%#Eval("BranchAdd")%>
                 </p>
                 <div class="clearfix"></div>                 
         	</address>
             <div class="clearfix"></div>
             <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p style="text-align:left;"><%#strCallus(DataBinder.Eval(Container.DataItem, "Callus2").ToString())%>
            </p>
          </address>
            </div>
            <div class="col-md-4" style="display:<%#ShowNo(DataBinder.Eval(Container.DataItem,"TollFree").ToString())%>;">
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Toll Free </h3>
          <p style="text-align:left;"><%#strCallus(DataBinder.Eval(Container.DataItem, "TollFree").ToString())%> </p>
          </address>
            </div>
            
            <div class="col-md-4" style="display:<%#ShowNo(DataBinder.Eval(Container.DataItem,"MobileNo").ToString())%>;">          
         
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p style="text-align:left;"><%#strCallus(DataBinder.Eval(Container.DataItem,"MobileNo").ToString())%></p>
          </address>
            </div>
            <div class="col-md-4" style="display:<%#ShowNo(DataBinder.Eval(Container.DataItem,"Email").ToString())%>;">

          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p style="text-align:left;"><%#strEmil(DataBinder.Eval(Container.DataItem, "Email").ToString())%> 
          </p>
          </address>
            </div>
          </div> 
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>  
         
          </ItemTemplate>
                        </asp:Repeater> 
                    
          </div>
          <!-- end Brand Stores --> 
          
          <!--sales agent -->
          <div  id="preferredsalesagents" runat="server">
          <h2 class="title showonmobile">Preferred Sales Agents</h2>
          <div class="row sales-agent">
          <div class="col-md-3"><h2 class="title"><i>Coming Soon..</i></h2>
          <div class="nav-agent" style="display:none";>
          <ul class="nav nav-stacked">
            <li class="active"><a href="#andhra_pradesh" data-toggle="tab">ANDHRA PRADESH</a></li>
            <li><a href="#gujrat" data-toggle="tab">GUJARAT</a></li>
            <li><a href="#gurgaon" data-toggle="tab">GURGAON ( NCR )</a></li>
            <li><a href="#karnatka" data-toggle="tab">KARNATAKA</a></li>
            <li><a href="#kerla" data-toggle="tab">KERALA</a></li>
            <li><a href="#madhya_pradesh" data-toggle="tab">MADHYA PRADESH</a></li>
            <li><a href="#maharastra" data-toggle="tab">MAHARASHTRA</a></li>
            <li><a href="#orisa" data-toggle="tab">ORISSA</a></li>
            <li><a href="#tamilnadu" data-toggle="tab">TAMIL NADU</a></li>
          </ul>
          </div>
          
          </div>
          <div class="col-md-9">
          <div class="tab-content" style="display:none";>
          <div id="andhra_pradesh" class="tab-pane in active">
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Anantapur - The Anantapur Air Travels</h3>
              <p>#53, Ground Floor, <br>
                Raghuveera Towers, Subhash Road,<br>
                Anantapur - 515 001. </p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8554-274603</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9866174648</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
         
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Bhimavaram - Leo Tours and Travels</h3>
              <p>3-1-143, Subbamma Complex ,<br>
                Opp Kishore Theatre, <br>
                Undi Road, 534202 . </p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8816-231915</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848111248</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
                  
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Chittoor - Victory Solutions</h3>
              <p>10-315/1, D.I.Road – 517 001.</p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-857-234995 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9246995995</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Eluru - Sri Gayatri Tours & Travels</h3>
                  <p>25-5-57,Shobha Complex, <br>
                    Narasimharao Pet, Opp. DIG, <br>
                    Bunglow, G.N.T Road.</p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8812-227408, 325289 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848611744, +91-9985295684</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Hanamkonda</h3>
              <p>1-8-516, Balasamudram,<br>
                Nr. Ekasila Park, <br>
                Hanamkonda - 506001. </p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-870-3291288</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848228892</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
           
           <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Hanamkonda - Padmaja Murthy Group</h3>
              <p>2-5-294,2nd floor,<br> 
                Opp.TMC SBH Kaloji Circle,<br>
                Nakkalagutta.</p>
                 
         	</address>
            </div>
            <div class="col-md-6">
           
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9966489416</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Kodad - Balaji E Services</h3>
              <p>Main Road , <br>Kodad - 508206.</p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8683-255221</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9948063738</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Kakinada - Prem Travels</h3>
              <p>D.No.14-1-9, <br>Cinema Road - 533 001.</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-9848162076</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848162076</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Kakinada - Ramana Travels</h3>
              <p>Opp. R.T.C.<br>Complex - 533 003.</p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-884-2341043</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848048128</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Khammam - Happy Travels</h3>
              <p>H.No:10-2-78,Mayuri Centre Bus<br>Depo Road - 507001, </p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8742-252323</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9030835301</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Kurnool - Sairaj Communications & Travels</h3>
              <p>40-318-10, Nallanda Complex,<br>Raj Vihar Center - 518 001. </p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8518-222458</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9849629439</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Mukarampura (Karimnagar) - Money Point</h3>
              <p>Opp.Govt Arts College,<br>Bus Stand Road. </p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-878-2243000</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9849547755</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
                    
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Machilipatnam - Sri N.N.V Ramana Babu</h3>
              <p>No. 79, Pattabhi Market.</p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8672-221449</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9885588325 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Narsannapet - Raghu Internet Café</h3>
              <p>Main Road, Narsannapeta,<br>Srikakulam Dist -532421,</p>
                 
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8576997699 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>8576997699</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Nellore - Sri Sai International Travels</h3>
              <p>No.12 Rangasai Complex Accenter,<br>Trunk Road.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-861-2328678</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848053078 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Ongole - Bhavishya Computers</h3>
              <p>Old Governament Hospital Road Opp, <br>Dr.Rajeswara Rao Hospital Ongole</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-08592-233483/231891</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9849990158</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Srikakulum - Sri Sankar Travels</h3>
              <p>26-123/2, Opp.Gandhi Stadium,<br>Main Road, Parvathipuram,<br>Vizianagaram - 535 501.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8963-221466 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9440383577 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Srikakulum - Kameswari Travels</h3>
              <p>D.No.8-4-38, Opp:Raja Lodge,<br>G.T.Road, Srikakulum - 532 001.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8942-225266 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9390611666 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Siddipet - Sai Ram Services</h3>
              <p>8-4-55 Opp Buruzu,Markandeya<br>Street - 502103 </p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8457-224196 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848802654 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Sircilla - Roopa Sri Associates Travel & Tour</h3>
              <p>3-3-27, Velishala Arcade, Shop No.1,<br>Ground Floor, Opp. Nimmapolli Bus Stop,<br>Sircilla - 505301 </p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8723-230323 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9440858483</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Sullurpet - Sri Saibaba Travels</h3>
              <p>No.12 Rangasai Complex Accenter,<br>Trunk Road.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8623-241130 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9440018080</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Suryapet - Tejaswi Services</h3>
              <p>1-4-2491541,Near Vijetha Hotel,<br>Suryapet-508213.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8684-223389</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9966934455 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Suryapet - Sri Shabarinath Tours</h3>
              <p>3-3-96,Opp:Suman Medical stores,<br>Bodrai Bazar - 508213,</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8684-254955 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9246736878</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Nizamabad - Sri Geethanjali Tour</h3>
              <p>1st Floor,Hari Charan Marwadi School <br>Complex,Station Road, Nizamabad - 503001.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-846-2225599 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9849825599 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Guntur - Smile Tours & Travels</h3>
              <p>C/0 Vaibhav Fashions, P.R.Raju Plaza,<br>Opp.Hanuman Temple,Naaz Center,<br>Guntur - 522001</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-863-2224015 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848105857</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
           <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Tenali - Surya Travels</h3>
              <p>Sri Balaji Complex, Old Current <br>Office Line, Main Road - 522 201.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8644-226008 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>++91-9912421612 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
          <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Tirupati - G.B. Travels</h3>
              <p>Opp. Railway Station.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-877-2227390 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9849179637</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Vizianagaram - Kameswari Tours & Travels</h3>
              <p>No. 19 & 32, "B" Block, P.S.R.<br>Complex - 535 003.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8922-274834 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9866638394 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Nellore - Sri Sai International Travels</h3>
              <p>No.12 Rangasai Complex Accenter,<br>Trunk Road.</p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-861-2328678</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848053078 </p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          </div>
          <div id="gujrat" class="tab-pane">
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Rajkot - Kalyan Tours Travels </h3>
              <p>3, Star Shopping Center,<br>20 New Jagnath Dr, <br>Yagnik Road, Rajkot- 360001. </p>
                
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-281-3040277</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9824636111</p>
          </address>
            </div>
            
          </div>
          </div>
          <div id="gurgaon" class="tab-pane">
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Rajkot - Kalyan Tours Travels </h3>
              <p>Sushant Estate, Tower No. IV <br>803, Sushantlok Phase - I , <br>Sector - 52 - 122 002. </p>
                
         	</address>
            </div>
            <div class="col-md-6">
            
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9811141969</p>
          </address>
            </div>
            
          </div>
          </div>
          <div id="karnatka" class="tab-pane">
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Arsikere (Hassan Dist) Renuka Travel Agency</h3>
              <p>Opp KEB, BH Road,<br>NH-206 - 573103.</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-422-4200999, 2470235 / 6</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-98410 40906, 09884004408</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Bellary Destination Seven Tours</h3>
              <p>1, Karnataka Engineers Association,<br>
					Building, S.N.Pet Circle.</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8392-270027</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-94480 79191</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Bidar Shree Travels</h3>
              <p>Shop No:14,APMC yard,<br>Next to I.B.Humabad</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8482-585330</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-8483271009, +91-8792115489</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
           <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Chikballapur Travel Solutions</h3>
              <p>Opp. hot n Tasty Bakery,<br>
                    Near 1st Grade Muncipal College,<br>
                    Station Road,M.G.Raoad, Chikballapur. </p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8156-270440</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-92417 77367</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
           <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Chitradurga Star Tours & Travels</h3>
              <p>C/O MotiLal Oswal<br>
                1st Floor, Vanigotra Complex,<br>
                BD Road. - 577501</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8194-225999</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-85537 80971</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Dharwad Globe Travels</h3>
              <p>Bikkannavar Building,<br>
                Near Melawanki Hospital,<br>
                Laxmi Nagar, Vidhyagiri - 580004.</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-836-274 7898</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-94481 84214</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Davanagere Vinayaka Enterprises</h3>
              <p>Opp Vijaya Bank , High School<br>
                Ground , P B Road<br>
                Davangere - 577001</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8192253021</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9448534800</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Gulbarga Jyothi Tours & Travels</h3>
              <p>C-1, Inderdas Market<br>Super Market - 585101</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-8472-261235</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-94481 12744</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Siruguppa Sri Hari Tours & Travels</h3>
              <p>Rathnamma Complex<br>Sada Shiva Nagar - 583121</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <!-- <p>+91-9036507740</p>-->
          <p>+91-07676944777</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Kochi Blue Bird Travel & Tourism </h3>
              <p>55/2735,Krishna Vihar<br>
				Ravipuram, Eranakulam Kochi</p>
                 <div class="clearfix"></div>
                 <%--<a href="#" class="view-map">View on Map <i class="fa fa-long-arrow-right"></i></a>--%>
         	</address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-484-4031082, 233471,</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9961337082, +91-98441 74172.</p>
          </address>
            </div>
            
          </div>
          </div>
          <div id="kerla" class="tab-pane">
          
          </div>
          <div id="madhya_pradesh" class="tab-pane">
          <div class="row">
                <div class="col-md-6">
                <address>
                  <div class="icondv"><i class="location"></i></div>
                  <h3>Seoni - Singh Travels </h3>
                  <p>Babariya Road<br>Barapatther - 480661</p>
                  </address>
                </div>
                <div class="col-md-6">
                <address>
              <div class="icondv"><i class="callus"></i></div>
              <h3>Call us</h3>
              <p>+91-7692225561</p>
              </address>
              <div class="clearfix"></div>
              <address>
              <div class="icondv"><i class="phone"></i></div>
              <h3>Mobile No</h3>
              <p>+91-99424904912</p>
              </address>
                </div>
                
              </div>
          </div>
          <div id="maharastra" class="tab-pane">
        
          <div class="row">
                <div class="col-md-6">
                <address>
                  <div class="icondv"><i class="location"></i></div>
                  <h3>Mumbai - Mr. Hiren Joshi</h3>
                  <p>4, Vijay Kunj,142,Vallabh Baugh Lane,<br>Ghatkopar East, Mumbai,</p>
                  </address>
                </div>
                <div class="col-md-6">
                <address>
              <div class="icondv"><i class="callus"></i></div>
              <h3>Call us</h3>
              <p>+91-22-25010027</p>
              </address>
              <div class="clearfix"></div>
              <address>
              <div class="icondv"><i class="phone"></i></div>
              <h3>Mobile No</h3>
              <p>+91-98922 16168</p>
              </address>
                </div>
                
              </div>
          
          <div class="row">
              <div class="col-lg-12">
              <hr>
              </div>
              </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Nagpur - Vivek Travels</h3>
              <p>185,Trimurthy Nagar,<br>Ring Road, Nagpur - 440022.</p>
              </address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-7122241344</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9422111161</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
              <div class="col-lg-12">
              <hr>
              </div>
              </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Pune - Shanatanu Travworld </h3>
              <p>Sarvashri Housing Society<br>1 flat No. 103, Sadashiv <br>peth, Pune - 411030,</p>
              </address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-20-2449 7406,<br>2437 0295</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-94220 02821</p>
          </address>
            </div>
            
          </div>
          
          </div>
          <div id="orisa" class="tab-pane">
          
     	  <div class="row">
                <div class="col-md-6">
                <address>
                  <div class="icondv"><i class="location"></i></div>
                  <h3>Parlakamidi - M.M. Tours & Travels </h3>
                  <p>Palace Street, Gajapathi Dist,<br>Orissa - 761200</p>
                  </address>
                </div>
                <div class="col-md-6">
                <address>
              <div class="icondv"><i class="callus"></i></div>
              <h3>Call us</h3>
              <p>+91-6815-223277 </p>
              </address>
              <div class="clearfix"></div>
              <address>
              <div class="icondv"><i class="phone"></i></div>
              <h3>Mobile No</h3>
              <p>+91-93377 06698</p>
              </address>
                </div>
                
              </div>
              
              <div class="row">
              <div class="col-lg-12">
              <hr>
              </div>
              </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Rayagada - Sagar Tours & Travels</h3>
              <p>Opp. Union Bank of India,<br>New Colony, Orissa - 765 001</p>
              </address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-6856-225666 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-94377 79666</p>
          </address>
            </div>
            
          </div>
          
          </div>
          <div id="tamilnadu" class="tab-pane">
          
          <div class="row">
                <div class="col-md-6">
                <address>
                  <div class="icondv"><i class="location"></i></div>
                  <h3>Madurai - Trips Guru Travels</h3>
                  <p>35/36 Nehru Street,<br>SS Colony - 625010.</p>
                  </address>
                </div>
                <div class="col-md-6">
                <address>
              <div class="icondv"><i class="callus"></i></div>
              <h3>Call us</h3>
              <p>+91-452-4352626</p>
              </address>
              <div class="clearfix"></div>
              <address>
              <div class="icondv"><i class="phone"></i></div>
              <h3>Mobile No</h3>
              <p>+91-9842146406</p>
              </address>
                </div>
                
              </div>
              
              <div class="row">
              <div class="col-lg-12">
              <hr>
              </div>
              </div>
          
          <div class="row">
            <div class="col-md-6">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Neyveli - Sri Annapoorani Travels</h3>
              <p>Kottakal J K Ayurvedic, First Floor, <br>K S V Complex, Opp.<br>NLC Arch Gate - 607 801.</p>
              </address>
            </div>
            <div class="col-md-6">
            <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-4142-269495 </p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9443229495</p>
          </address>
            </div>
            
          </div>
          
          <div class="row">
              <div class="col-lg-12">
              <hr>
              </div>
              </div>
          
          <div class="row">
                <div class="col-md-6">
                <address>
                  <div class="icondv"><i class="location"></i></div>
                  <h3>Salem - Tinku Travels</h3>
                  <p>B26 Rajaji Street, Swarnapuri. </p>
                  </address>
                </div>
                <div class="col-md-6">
                <address>
              <div class="icondv"><i class="callus"></i></div>
              <h3>Call us</h3>
              <p>+91-427-2448275</p>
              </address>
              <div class="clearfix"></div>
              <address>
              <div class="icondv"><i class="phone"></i></div>
              <h3>Mobile No</h3>
              <p>+91-9994395821</p>
              </address>
                </div>
                
              </div>
          
          </div>
          </div>
          </div>
          </div>
          </div>
          <!--end sales agent --> 
          
         
        </div>
      </div>
    </div>
    </div>
  
  </div>
</section>
  
  
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooterEndUser1" runat="server" />
    <!-- Footer Start -->
    </form>
    <!--Install Crazy Egg code for Tracking Visitor Behavior-->

    <script type="text/javascript">
        setTimeout(function () {
            var a = document.createElement("script");
            var b = document.getElementsByTagName('script')[0];
            a.src = document.location.protocol + "//dnn506yrbagrg.cloudfront.net/pages/scripts/0011/9178.js?" + Math.floor(new Date().getTime() / 3600000);
            a.async = true; a.type = "text/javascript"; b.parentNode.insertBefore(a, b)
        }, 1);
        $('#refresh_captcha').click(function (e) {
            $('#captchImg').attr('src', 'JpegImage.aspx?cache=' + new Date().getTime());
            e.preventDefault();
        });
    </script>

</body>
</html>
