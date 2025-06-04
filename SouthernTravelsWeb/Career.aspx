<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Career.aspx.cs" Inherits="SouthernTravelsWeb.Career" %>


<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Career : Southern Travels</title>
    <meta name="Description" content="Southern Travels provide an environment that is very friendly & obtainable. So if you wish to be a part of this hospitality world don't hesitate to approach us." />
    <meta name="Keywords" content="tour and travels agency, tour and travel agency in india, north india tour package, south india tour packages, fixed departure tour, international tour, domestic tour operator, tour operator in india, travel agency, car rental, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours" />
    <meta name="robots" content="index,follow" />
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
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
                    text: 'Please enter valid email id.',
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
            //        alert("Please enter characters only.");
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
    <!-- Google Tag Manager -->
    <script>
        (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({
                'gtm.start':
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
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-career.jpg)">
   <UCHeader:UCHeaderEndUser ID="UCHeaderEndUser1" runat="server"  />
  
</header>
    <section class="innersection2">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12">
        <div class="titlewithbrder">
          <h1 class="title"> <span>Careers </span> </h1>
          <p>At Southern Travels, we work with assiduous people, perfect product and a convivial environment. The employees of our travels are perfect in their own area. Our employees are not just hard working but spirited dedicated and fun loving. We provide an environment that is very friendly and approachable. So if you wish to experience such kind of environment and you're perfect in tour fields don't hesitate to approach us.</p>
        </div>
      </div>
    </div>
  </div>
  <div class="clearfix"></div>
  <div class="container">
    <div class="row careers">
      <div class="col-md-6">
        <div class="row rowgap">
          <div class="col-md-4"><img src="Assets/images/career-ourmotto.jpg" class="img-responsive" loading="lazy" alt="ourmotto"/></div>
          <div class="col-md-8">
            <h2 class="title mrgntopno">Our <span>Motto</span></h2>
            <p>Our motto is to enrich people's lives with minimum of hassles, by creating and providing them, with a unique travel experience which, they can cherish throughout their lives.</p>
          </div>
        </div>
        <div class="row rowgap">
          <div class="col-md-4"><img src="Assets/images/career-values.jpg" class="img-responsive" loading="lazy" alt="career-values"/></div>
          <div class="col-md-8">
            <h2 class="title mrgntopno">Our <span>Values Include</span></h2>
            <ul class="sublist">
              <li>We are passionate about what we do.</li>
              <li>We believe in having a fun filled environment.</li>
              <li>We believe in making our clients the happiest by satisfying their travel needs.</li>
              <li>We believe in growth.</li>
              <li>We welcome innovative growth.</li>
              <li>We work with full dedication.</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-md-6">
        <div class="graybrdrbox brdrnone mrgnbtm20">
          <h2 class="title mrgntopno">Our <span>Work Culture</span></h2>
          <p>There is a strong sense of community, involvement and shared goals and ideas. We are simply dedicated to satisfy the needs of people in a relaxed environment. There are no ego issues and rivalry. We believe in teamwork as only a team can lead to the progress of the company and not an individual alone.</p>
          <p>Southern Group is committed to attracting and retaining the best people by providing a positive work environment. People who enjoy their work will naturally create an environment where guests will feel welcome. We know our employees are the key to building loyal relationships with our guests and are integral part to the success of our Brand. We are always interested in finding new people to join our team. </p>
        </div>
        <div>
          <p>So, if you think you're capable enough to join our travels, we welcome you with open arms.<br>
            Please write to: <a href="mailto:southerntravelsindia@vsnl.com?subject=Southern Travels Pvt. Ltd. Mail Through southerntravelsindia.com">jobs@southerntravels.in</a></p>
        </div>
      </div>
    </div>
  </div>
</section>
    <section class="paddingtop0">
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <div class="careerform">
          <div class="row">
            <div class="col-lg-12 text-center">
              <h2 class="title"><span>Enquiry</span> Form</h2>
              <p>Do fill in the form below to help us know your requirement better.</p>
            </div>
          </div>
          <div class="formwrap innerforms mrgntopno">
                
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
              <div class="col-md-6">&nbsp;</div>
              <div class="col-md-6">
                  <asp:Button ID="btnSend" class="commonbtn" runat="server" Text="Submit" ValidationGroup="FEFEValidation1" 
             OnClientClick = "ga('send', 'event', { eventCategory: 'contact us', eventAction: 'submit'});"
               OnClick="btnSend_Click"></asp:Button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooterEndUser1" runat="server" />
    <!-- Footer Start -->
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

