<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelRegistration.aspx.cs" Inherits="SouthernTravelsWeb.HotelRegistration" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Hotel Registration : Southern Travels</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <meta content="Southern Travel offering great deal on accommodation to make your vacation more comfortable and memorable at very low prices."
        name="Description" />
    <meta content="southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package, south india beaches travel packages, south india holiday travel packages, holiday travel package to south india, southern india package travel, south india tourism, tourism in south india, holidays travel in southern india, kerala backwater travel packages in india, north india tour packages, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours, southern travels india, southerntravelsindia, Sirez"
        name="Keywords" />
    <meta content="index,follow" name="robots" />
    <meta content="Designed www.Sirez.com" name="Author" />
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <script language="javascript" type="text/javascript">

        function fnHotelVal() {
            var chek = true;

            if (document.getElementById("<%=ddlVendorType.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please select vendor type.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=ddlVendorType.ClientID  %>").focus();
                chek = false;
                return false;
            }

            if (document.getElementById("<%=ddlVendorType.ClientID  %>").value == "Chain") {
                if (document.getElementById("<%=txtChainName.ClientID  %>").value == "") {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please enter chain name.',
                        confirmButtonColor: '#f2572b'
                    });
                    document.getElementById("<%=txtChainName.ClientID  %>").focus();
                    chek = false;
                    return false
                }
            }

            if (document.getElementById("<%=txtHotelName.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter hotel name.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtHotelName.ClientID  %>").focus();
                return false
            }

            if (document.getElementById("<%=txtContactPerson.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter contact person.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtContactPerson.ClientID %>").focus();
                chek = false;
                return false;
            }

            if (document.getElementById("<%=txtDesignation.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter designation.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtDesignation.ClientID %>").focus();
                chek = false;
                return false;

            }
            if (document.getElementById("<%=txtMobile.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter mobile no.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtMobile.ClientID %>").focus();
                chek = false;
                return false;
            }

            if (document.getElementById("<%=txtStdCode.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please select std code.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtStdCode.ClientID %>").focus();
                chek = false;
                return false;
            }


            if (document.getElementById("<%=txtHotelPhoneNo.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter hotel phone no.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtHotelPhoneNo.ClientID %>").focus();
                chek = false;
                return false;
            }

            if (document.getElementById("<%=txtEmailId.ClientID%>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter emailid.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtEmailId.ClientID %>").focus();
                chek = false;
                return false;
            }
            echeck(document.getElementById("<%=txtEmailId.ClientID%>").value);

            if (document.getElementById("<%=ddlState.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please select state.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=ddlState.ClientID %>").focus();
                chek = false;
                return false;
            }

            if (document.getElementById("<%=txtCity.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter city.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtCity.ClientID %>").focus();
                chek = false;
                return false;
            }
            if (document.getElementById("<%=txtNOOfRooms.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter no of rooms.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtNOOfRooms.ClientID %>").focus();
                chek = false;
                return false;
            }
            if (document.getElementById("<%=ddlCategory.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please select hotel category.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=ddlCategory.ClientID %>").focus();
                chek = false;
                return false;
            }

            if (document.getElementById("<%=txtAddress.ClientID %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter address.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtAddress.ClientID %>").focus();
                chek = false;
                return false;
            }
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 46 || charCode > 57))
                return false;
            return true;
        }
        function echeck(str) {
            if (str.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1) {
                return true;
            }
            else {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Invalid E-mail ID.',
                    confirmButtonColor: '#f2572b'
                });
                return false;
            }
        }
        function hideshowChain() {

            if (document.getElementById("<%=ddlVendorType.ClientID  %>").value == "Chain") {
                var control = document.getElementById("<%=divChain.ClientID  %>");
                control.style.visibility = "visible";
            }
            else {
                document.getElementById("<%=divChain.ClientID  %>").style.display = "visible";
                var control = document.getElementById("<%=divChain.ClientID  %>");
                control.style.visibility = "hidden";
            }

        }
        
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
    <form id="Form1" runat="server">
    <header class="posrel innerheader" style="background-image: url(Assets/images/hotels/banner-hotels.jpg)"><%--style="background-image: url(images/banner-feedback.jpg)"--%>
  
    <UCHeader:UCHeaderEndUser ID="UCHeaderEndUser1" runat="server" />
    
  </header>
    <section class="innersection2">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <h1 class="title mrgnbtmh1"><span>Register Your Hotel</span></h1>
        <p style="display: none">Help us to make our services better, provide us with your valuable suggestions and feedback. </p>
      </div>
    </div>
    <div class="formwrap innerforms">
    
   <div class="row mrgnbtminput">
    	<div class="col-md-6 mrgnbtminput">
    	
    	<asp:DropDownList ID="ddlVendorType" runat="server" class="form-control" onchange="hideshowChain()">
        <asp:ListItem Value="">Vendor Type</asp:ListItem>
        <asp:ListItem Value="Chain">Chain</asp:ListItem>
        <asp:ListItem Value="Single Owner">Single Owner</asp:ListItem>
       </asp:DropDownList>
    	  
       </div>
       
        <div class="col-md-6" id="divChain" runat="server" style="visibility:hidden;">
            
           <asp:TextBox ID="txtChainName" runat="server" class="form-control" placeholder="ChainName" MaxLength="100"></asp:TextBox>
        
        </div>
       
       </div>
    
    <div class="row mrgnbtminput">
    	<div class="col-md-6">
        
        
       <asp:TextBox ID="txtHotelName" runat="server"  class="form-control" placeholder="Name of the Hotel" MaxLength="100"></asp:TextBox></div>
        
        <div class="col-md-6">
        
         <asp:TextBox ID="txtContactPerson" runat="server"  class="form-control" placeholder="Contact Person" MaxLength="100"></asp:TextBox></div></div>
    
    
    <div class="row mrgnbtminput">
    	<div class="col-md-6">
       
               
       <asp:TextBox ID="txtDesignation" runat="server"  class="form-control" placeholder="Designation" MaxLength="50"></asp:TextBox></div>
        
        <div class="col-md-6">
       
               
         <asp:TextBox ID="txtMobile" runat="server"  class="form-control" placeholder="Mobile No" MaxLength="10" onkeypress="javascript:return isNumberKey(event);"></asp:TextBox>
        
        </div>
        
        
        
    </div>
    
    
     <div class="row mrgnbtminput">
    	<div class="col-md-6">
        <asp:TextBox ID="txtStdCode" runat="server"  class="form-control" placeholder="Std Code" MaxLength="10"></asp:TextBox></div>
        <div class="col-md-6">
       
               
        <asp:TextBox ID="txtHotelPhoneNo" runat="server"  class="form-control" placeholder="Hotel Phone No" MaxLength="10" onkeypress="javascript:return isNumberKey(event);"></asp:TextBox>
        
        
        
    </div>
    </div>
    
    
     <div class="row mrgnbtminput">
    	<div class="col-md-6">
       <asp:TextBox ID="txtEmailId" runat="server"  class="form-control" placeholder="Email Id" MaxLength="75"></asp:TextBox>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="txtEmailId" Display="Dynamic" ErrorMessage="Enter valid E-mail"
                                        ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+&amp;lt;(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})&amp;gt;$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$"
                                        SetFocusOnError="True" ValidationGroup="hot"></asp:RegularExpressionValidator>    
       </div>
        
        <div class="col-md-6">
         <asp:TextBox ID="txtPanNo" runat="server" class="form-control" placeholder="Pan No" MaxLength="10"></asp:TextBox>  
               
        </div>
        
        
        
    </div>
    
     <div class="row mrgnbtminput">
    	<div class="col-md-6 mrgnbtminput">
       
               
          <asp:DropDownList ID="ddlState" runat="server" class="form-control" >
     
       </asp:DropDownList>
        </div>
        
        <div class="col-md-6 mrgnbtminput">
         <asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder="City" MaxLength="100"></asp:TextBox>
        
        
        
    </div>
    </div>
    
     <div class="row mrgnbtminput">
    	<div class="col-md-6">
      <asp:TextBox ID="txtNOOfRooms" runat="server" class="form-control" placeholder="No of rooms" MaxLength="4" onkeypress="javascript:return isNumberKey(event);"></asp:TextBox>
               
       </div>
        
        <div class="col-md-6 mrgnbtminput">
        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" >
        <asp:ListItem Value="">Category of Hotel</asp:ListItem>
        <asp:ListItem Value="Chain">Resort</asp:ListItem>
        <asp:ListItem Value="2 Star"> 2 Star (Equivalent)</asp:ListItem>
          <asp:ListItem Value="3 Star">3 Star (Equivalent)</asp:ListItem>
            <asp:ListItem Value="4 Star">4 Star (Equivalent)</asp:ListItem>
              <asp:ListItem Value="5 Star">5 Star (Equivalent)</asp:ListItem>
              <asp:ListItem Value="Guest House">Guest House</asp:ListItem>
              <asp:ListItem Value="Service Apartment">Service Apartment</asp:ListItem>
       </asp:DropDownList>
  
        
    </div>
    </div>
    
      <div class="row mrgnbtminput" style="display:none"> 
    	<div class="col-md-6 mrgnbtminput">
    
       <asp:TextBox ID="txtTax" runat="server" class="form-control" placeholder="Tax" MaxLength="8" onkeypress="javascript:return isDecimalKey(event);"></asp:TextBox>  
               
       </div>
        
        <div class="col-md-6 mrgnbtminput">
    	
       <asp:TextBox ID="txtLuxuryTax" runat="server" class="form-control" placeholder="Luxury Tax" MaxLength="8" onkeypress="javascript:return isDecimalKey(event);"></asp:TextBox>  
               
       </div>
        
        </div>
        
        
        
         <div class="row mrgnbtminput" style="display:none">
    	<div class="col-md-6 mrgnbtminput">
    	
       <asp:TextBox ID="txtServiceTax" runat="server" class="form-control" placeholder="GST" MaxLength="8" onkeypress="javascript:return isDecimalKey(event);"></asp:TextBox>  
               
       </div>
        
        <div class="col-md-6 mrgnbtminput">
      
         
       </div>
        
        </div>
        
       <div class="row mrgnbtminput">
        <div class="col-md-12">
   
       <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Address" TextMode="MultiLine" rows="4" MaxLength="200"></asp:TextBox>  
        <asp:RegularExpressionValidator runat="server"  ID="RegularExpressionValidator2"
                                                                Display="Dynamic" ControlToValidate="txtAddress" ValidationExpression="^[\s\S]{0,200}$"
                                                                ErrorMessage="Please enter address in max 200 characters." ValidationGroup="hot" />
        </div>
        </div>
        
        <div class="row mrgnbtminput">
        <div class="col-md-12">
       <asp:TextBox ID="txtGeneralInfo" runat="server" class="form-control" rows="4" placeholder="General Info" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
             <asp:RegularExpressionValidator runat="server"  ID="RegularExpressionValidator3"
                                                                Display="Dynamic" ControlToValidate="txtGeneralInfo" ValidationExpression="^[\s\S]{0,500}$"
                                                                ErrorMessage="Please enter general info in max 500 characters."  ValidationGroup="hot"/>
    </div>
    </div>
    <div class="row mrgnbtminput">
    	<div class="col-md-6">
    	
    	<div class="g-recaptcha" runat="server" id="divrecaptcha" ></div>
                             <asp:Label ID="MessageLabel" runat="server" CssClass="txt" ForeColor="red"></asp:Label>
    	</div>
    	</div>
        <div class="row mrgnbtminput">
    	<div class="col-md-6">
    	
    	 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="hot" class="commonbtn displayinline"></asp:Button>
    	</div>
        
    </div>
    
  </div>
</section>
    <UCFooter:UCFooterEndUser ID="UCFooterEndUser2" runat="server" />
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
