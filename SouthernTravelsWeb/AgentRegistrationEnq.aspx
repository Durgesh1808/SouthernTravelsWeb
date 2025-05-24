<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentRegistrationEnq.aspx.cs" Inherits="SouthernTravelsWeb.AgentRegistrationEnq" %>


<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Agent Registration : Southern Travels</title>
    <meta id="mtDescription" name="Description" content="Southern Travels has wide checklist of corporate & business travel packages. Choose the best travel agency to ensure an unforgettable holiday!" />
    <meta id="mtKeywords" name="Keywords" content="corporate business travel, corporate travel agencies, corporate travel agency, corporate travel agent, travel agency, travel agency franchise, travel agency india, travel agent, travel agent india, travel angency, travel booking agent, travel company, travel site" />
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <script language="javascript" src="Assets/js/md5.js" type="text/javascript"></script>
    <script src="Assets/js/jquery-2.2.0.min.js"></script>
    <style>
        #RadioButtonList2 td
        {
            padding: 0 15px 0 0;
        }
        #RadioButtonList2 label
        {
            margin-left: 5px;
            padding: 0 15px 0 0;
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function CheckMail(str) {
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
        function validate() {
            if (Trim(document.getElementById("<%=txtfirstname.ClientID %>").value) == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'First name should not be Empty.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("txtfirstname").focus();
                return false;
            }
            if (validateOnlyNumber1(parseInt(document.getElementById("txtfirstname").value)) == true) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: '"First name should not be numeric.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("txtfirstname").value = "";
                document.getElementById("txtfirstname").focus();
                return false;
            }

            if (Trim(document.getElementById("txtlastname").value) == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Last name should not be Empty.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("txtlastname").focus();
                return false;
            }
            var rbgender = document.getElementsByName("RadioButtonList2");
            var vargenderChecked = false;
            for (var i = 0; i < rbgender.length; i++) {
                if (rbgender[i].type == 'radio' && rbgender[i].checked == true) {
                    vargenderChecked = true;
                    break;
                }
            }
            if (!vargenderChecked) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Select Gender.',
                    confirmButtonColor: '#f2572b'
                });
                return false;
            }
            if (Trim(document.getElementById("txtaddress").value) == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Address should not be Empty.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("txtaddress").focus();
                return false;
            }
            if (document.getElementById("ddlstate").value == "0") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please select state.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("txtmobile").focus();
                return false;
            }
            if (document.getElementById("txtmobile").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Mobile No should not be Empty.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("txtmobile").focus();
                return false;
            }
            if (document.getElementById("txtmobile").value != "") {
                var k = document.getElementById("txtmobile").value;
                if (k.length < 10) {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Mobile No should be 10 digits.',
                        confirmButtonColor: '#f2572b'
                    });
                    document.getElementById("txtmobile").focus();
                    return false;
                }
            }
            if (document.getElementById("txtphone").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Phone No should not be Empty.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("txtphone").focus();
                return false;
            }

            if (document.getElementById("txtphone").value != "") {
                var k = document.getElementById("txtphone").value;
                if (k.length < 6) {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Phone No should be 6 digits.',
                        confirmButtonColor: '#f2572b'
                    });
                    document.getElementById("txtphone").focus();
                    return false;
                }
            }



            if (document.getElementById('txtemail').value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please fill the e-mail field.It is Mandatory.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('txtemail').focus();
                return false;
            }
            else {
                if (document.getElementById('txtemail').value != "") {
                    if (CheckMail(document.getElementById('txtemail').value) == false) {
                        document.getElementById('txtemail').value = "";
                        document.getElementById('txtemail').focus();
                        return false;
                    }
                }
            }


        }



        function chkCharacter() {

            if ((event.keyCode > 90) || (event.keyCode < 65) && event.keyCode != 8 && event.keyCode != 37 && event.keyCode != 38 && event.keyCode != 39 && event.keyCode != 40 && event.keyCode != 46 && event.keyCode != 13 && event.keyCode != 116 && event.keyCode != 16 && (event.keyCode < 96 || event.keyCode > 105) && event.keyCode != 9 && event.keyCode != 110) event.returnValue = false

        }

        function CheckOnlyCharacter(evt) {
            debugger;
            var kk
            kk = (evt.which) ? evt.which : event.keyCode

            if ((k > 64 && k < 91) || (k > 96 && k < 123) || kk == 8 || kk == 32 || kk == 9 || kk == 127 || kk == 16 || kk == 20 || kk == 46) {
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

    </script>
    <script type="text/javascript">

        $(function () {


            $("#txtdob").datepicker({

                numberOfMonths: 1,
                showOn: "button", autoSize: true,
                buttonImage: "Assets/images/date.gif",
                buttonImageOnly: true,
                maxDate: new Date(),
                //minDate: new Date('01/01/1947'),
                closeText: 'Close', changeMonth: true,
                changeYear: true,
                yearRange: "-80:+0",
                monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'], // Names of months for drop-down and formatting
                monthNamesShort: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                dateFormat: 'dd/mm/yy', buttonText: 'Choose a Date'



            });

        });


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
    <form id="Form1" runat="server">
    <input type="hidden" id="tmpEnValue" runat="server" />
    <input type="hidden" id="isemail" runat="server" />
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-enquiry.jpg)">
  
   <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server"  />
   
  
  </header>
    <section class="innersection2">
  <div class="container">
   
    <div class="formwrap innerforms">
    
    <div class="row">
    <div class="col-md-12">
    	<h1 class="title"><span>Agent</span> Registration</h1>
    </div>
    </div>
    
    <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	 <asp:TextBox ID="txtfirstname" runat="server"  CssClass="form-control" placeholder="First Name*" ValidationGroup="Validation1"></asp:TextBox>
    	  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfirstname"
                                                            ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="Validation1"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                            ControlToValidate="txtfirstname" Display="Dynamic" ErrorMessage="Please enter only alphabetic characters."
                                                            ValidationExpression="^[a-zA-Z ]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z ]*)*$" ValidationGroup="Validation1"></asp:RegularExpressionValidator>
    </div>  
    
    <div class="col-md-6">
    	<asp:TextBox ID="txtlastname" runat="server" placeholder="Last Name" CssClass="form-control" ValidationGroup="Validation1"></asp:TextBox>
    	<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                            ControlToValidate="txtlastname" Display="Dynamic" ErrorMessage="Please enter only alphabetic characters."
                                                            ValidationExpression="^[a-zA-Z ]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z ]*)*$" 
                                                            ValidationGroup="Validation1"></asp:RegularExpressionValidator>
    </div>  
        
    </div>
    
      <div class="row mrgnbtminput">
    	<div class="col-md-6">
         	<div class="input-group width100" >
                <input  class="form-control " placeholder="Date of Birth" id="txtdob" name="txtarrival" readonly="readonly" type="text" runat="server" />
              </div>
              </div>
      
    
    <div class="col-md-6">
    	<label>Gender: </label> <br><label>
    	<asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" 
                                        RepeatLayout="Flow">
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                    </asp:RadioButtonList>
    </div>  
        
    </div>
    
    <div class="row mrgnbtminput">
    <div class="col-md-12">
    	<asp:TextBox ID="txtaddress" runat="server" MaxLength="200" placeholder="Address*"
    	 TextMode="MultiLine"  CssClass="form-control"  ValidationGroup="Validation1"></asp:TextBox>
    	 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="True"
                                                            ControlToValidate="txtaddress" ErrorMessage="Required Field." ValidationGroup="Validation1"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ValidationGroup="Validation1" SetFocusOnError="True"
                                                            ID="RegularExpressionValidator4" Display="Dynamic" ControlToValidate="txtaddress"
                                                            ValidationExpression="^[\s\S]{0,200}$" ErrorMessage="Please enter address in 200 characters." />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtaddress"
                                                            Display="Dynamic" ErrorMessage="Please enter Address in alphanumeric, # and sapce."
                                                            ValidationExpression="^[0-9a-zA-Z #,-/]+$" ValidationGroup="Validation1"></asp:RegularExpressionValidator>
    </div>
    </div>
    
    
      <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	<asp:TextBox ID="txtcity" runat="server" placeholder="City" CssClass="form-control"  ValidationGroup="Validation1"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                            ControlToValidate="txtcity" Display="Dynamic" ErrorMessage="Please enter only alphabetic characters."
                                                            ValidationExpression="^[a-zA-Z ]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z ]*)*$" 
                                                            ValidationGroup="Validation1"></asp:RegularExpressionValidator>	
    </div>  
    
    <div class="col-md-6">
    	  <select id="ddlstate" runat="server" class="form-control" >
                                        <option selected="selected" value="0">State</option>
                                        <option value="Andhra Pradesh">Andhra Pradesh</option>
                                        <option value="Andaman Nicobar">Andaman &amp; Nicobar</option>
                                        <option value="Arunachal Pradesh">Arunachal Pradesh</option>
                                        <option value="Assam">Assam</option>
                                        <option value="Bihar">Bihar</option>
                                        <option value="Chhattisgarh">Chhattisgarh</option>
                                        <option value="Dadar Nagar Haveli">Dadar &amp; Nagar Haveli</option>
                                        <option value="Delhi">Delhi</option>
                                        <option value="Goa">Goa</option>
                                        <option value="Gujrat">Gujrat</option>
                                        <option value="Haryana">Haryana</option>
                                        <option value="Himachal Pradesh">Himachal Pradesh</option>
                                        <option value="Jammu and Kashmir">Jammu &amp; Kashmir </option>
                                        <option value="Jharkhand">Jharkhand</option>
                                        <option value="Karnataka">Karnataka</option>
                                        <option value="Kerala">Kerala</option>
                                        <option value="Lakshadweep">Lakshadweep</option>
                                        <option value="Madhya Pradesh">Madhya Pradesh</option>
                                        <option value="Maharashtra">Maharashtra</option>
                                        <option value="Manipur">Manipur</option>
                                        <option value="Meghalaya">Meghalaya</option>
                                        <option value="Mizoram">Mizoram</option>
                                        <option value="Nagaland">Nagaland</option>
                                        <option value="Orissa">Orissa</option>
                                        <option value="Pondicherry">Pondicherry</option>
                                        <option value="Punjab">Punjab</option>
                                        <option value="Rajasthan">Rajasthan</option>
                                        <option value="Sikkim">Sikkim</option>
                                        <option value="Tamil Nadu">Tamil Nadu</option>
                                        <option value="Tripura">Tripura</option>
                                        <option value="Uttaranchal">Uttaranchal</option>
                                        <option value="Uttar Pradesh">Uttar Pradesh</option>
                                        <option value="West Bengal">West Bengal</option>
                                    </select>
    </div>  
        
    </div>
    
    
      <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	
       
	 <select id="ddlcountry" runat="server" class="form-control" name="ddlcountry" >
                                        <option  value="0">Country</option>
                                        <option value="India" selected="selected">India</option>
                                        <option value="Nepal">Nepal</option>
                                    </select>

        
        
    </div>  
    
    <div class="col-md-6">
    	<asp:TextBox ID="txtpin" runat="server"  MaxLength="6" CssClass="form-control" placeholder="Pincode"></asp:TextBox>
        
    </div>  
        
    </div>
    
    
      <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	<asp:TextBox ID="txtmobile" runat="server" MaxLength="10"  CssClass="form-control" placeholder="Mobile No*" ValidationGroup="Validation1"></asp:TextBox>
    	 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="True"
                                                            ControlToValidate="txtmobile" ErrorMessage="Required Field." ValidationGroup="Validation1"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
    </div>  
    
    <div class="col-md-6">
    	<asp:TextBox ID="txtphone" runat="server" MaxLength="15"  CssClass="form-control" placeholder="Phone No*" ValidationGroup="Validation1"></asp:TextBox>
    	 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="True"
                                                            ControlToValidate="txtphone" ErrorMessage="Required Field." ValidationGroup="Validation1"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
    </div>  
    
        
    </div>
    
      <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	<select id="ddlauthority" runat="server"  Class="form-control" name="ddlauthority" >
                                        <option selected="selected" value="0">Authority Member</option>
                                        <option value="IATO">IATO</option>
                                        <option value="AIMTC">AIMTC</option>
                                        <option value="AIMA">AIMA</option>
                                        <option value="IITA">IITA</option>
                                        <option value="FHRAI">FHRAI</option>
                                        <option value="HRAI">HRAI</option>
                                    </select>
    </div>  
    
    <div class="col-md-6">
    	<asp:TextBox ID="txtemail" runat="server"  CssClass="form-control" placeholder="Email Id*" ValidationGroup="Validation1"></asp:TextBox>
    	 <asp:RequiredFieldValidator ID="Reqemail" runat="server" ControlToValidate="txtemail"
                                                            ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="Validation1"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="Reguemail" runat="server" ControlToValidate="txtemail"
                                                            ErrorMessage="Please enter valid email id." SetFocusOnError="True" ValidationGroup="Validation1"
                                                            Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    </div>  
        
    </div>
    
   
    
    <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	<div class="mrgnbtminput">
    	<asp:TextBox ID="txtPanNo" runat="server"  CssClass="form-control" placeholder="PAN No."></asp:TextBox>
    	</div>
      
    </div>  
    
    <div class="col-md-6">
    	 
    	<asp:TextBox ID="txtfax" runat="server" MaxLength="11" CssClass="form-control"  placeholder="Fax No*" ValidationGroup="Validation1"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtfax"
                                                            ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="Validation1"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
    </div>  
        
    </div>
    
    
    <div class="row mrgnbtminput">
    	
    <div class="col-md-12">
    <asp:TextBox ID="txtDescription" runat="server"  TextMode="MultiLine"  CssClass="form-control" placeholder="Description"></asp:TextBox>
    </div>
    </div>
    
     <div class="row">
    	
    <div class="col-md-6">
   	  <div class="g-recaptcha" runat="server" id="divrecaptcha" ></div>
       
      
    </div>  
    
    <div class="col-md-6">
<asp:Label ID="MessageLabel" runat="server" CssClass="verdana11bk" ForeColor="red"></asp:Label>
    </div>
        
    </div>
   
   <div class="row mrgnbtminput">
   <div class="col-md-12">          <p class="notepara">This helps Southern Travels prevent automated Enquiries.</p></div>
   </div>
   
    <div class="row mrgnbtminput">
    	<div class="col-md-6">
         <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click"  Text="Submit" CssClass="commonbtn displayinline" ValidationGroup="Validation1"/>
        </div>
    
    </div>
   
  </div>
  </div>
</section>
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    </form>
    <script>
        $('#refresh_captcha').click(function (e) {

            $('#imgCaptcha').attr('src', 'JpegImage.aspx?cache=' + new Date().getTime());
            e.preventDefault();
        });
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

