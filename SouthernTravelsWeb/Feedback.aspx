<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="SouthernTravelsWeb.Feedback" %>


<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcCustomerLeft.ascx" TagPrefix="uc1" TagName="leftuc"  %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Customer Feedback : Southern Travels</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="Description" content="At Southern Travels, We will happy to receive your valuable feedback and suggestions to provide more greatest hospitality." />
    <meta name="Keywords" content="tour and travels agency, tour and travel agency in india, north india tour package, south india tour packages, fixed departure tour, international tour, domestic tour operator, tour operator in india, travel agency, car rental, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours" />
    <meta name="robots" content="index,follow" />
    <link href="Assets/css/star-rating.css" rel="stylesheet" type="text/css" />
    <script src="Assets/js/jquery-2.2.0.min.js"></script>
    <script src="Assets/js/star-rating.js" type="text/javascript"></script>
    <style>
        .radiobtnwrap
        {
            margin-top: 6px;
        }
        .radiobtnwrap input
        {
            margin-right: 4px !important;
        }
        .radiobtnwrap label
        {
            margin-right: 10px !important;
        }
    </style>
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
            debugger;

            var totalRows = $123("#<%=gvFeedBack.ClientID %> tr").length - 1;
            if (totalRows > 0) {
                var hdnid;
                var hdnvalue;
                for (i = 1; i <= totalRows; i++) {
                    var k = i + 1;

                    hdnid = "#gvFeedBack_ctl0" + k + "_hdnRating";

                    if ($123(hdnid).val() <= 0) {
                        var txt = "tr:eq(" + i + ")"
                        var td2 = $('#gvFeedBack').parent().children().find(txt).find("td:nth-child(2)").text();
                        Swal.fire({
                            icon: 'warning',
                            title: 'Oops...',
                            text: 'Please provide rating for.'+td2,
                            confirmButtonColor: '#f2572b'
                        });
                        return false;
                        break;
                    }

                }
            }
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
            if (document.getElementById("<%=txtPlace.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter place.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtPlace.ClientID  %>").focus();
                chek = false;
                return false;
            }
            if (document.getElementById("<%=txtTourName.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter tour name.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtTourName.ClientID  %>").focus();
                chek = false;
                return false;
            }
            if (document.getElementById("<%=txtPax.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter no of pax.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtPax.ClientID  %>").focus();
                chek = false;
                return false;
            }
            if (document.getElementById("<%=txtarrival.ClientID  %>").value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter journy date.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById("<%=txtarrival.ClientID  %>").focus();
                chek = false;
                return false;
            }
            var selectedvalue = $123('#<%= rbtntourtype.ClientID %> input:checked').val()
            if (selectedvalue > 0) {
                //dsd
            }
            else {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please select Tour type.',
                    confirmButtonColor: '#f2572b'
                });
                return false
            }


        }
    
    
    </script>
    <script src="Assets/js/jquery-ui.js"></script>
    <script type="text/javascript">

        var $123 = jQuery.noConflict();

        $123(function () {


            $123("#txtarrival").datepicker({

                numberOfMonths: 2,
                showOn: "button", autoSize: true,
                buttonImage: "Assets/images/calendar.gif",
                buttonImageOnly: true,
                maxDate: new Date(),
                closeText: 'Close',
                dateFormat: 'dd/mm/yy', buttonText: 'Choose a Date'



            });

        });



        $123(function () {

            $123('.linkqck').click(function (e) {
                $123(".qckenqwrap").show().animate({
                    right: "0px"

                }, 300, function () {

                });



                e.preventDefault();
            });


            $123('.closebtn a').click(function (e) {

                $123(".qckenqwrap").animate({
                    right: "-300px"


                }, 300, function () {
                    // Animation complete.
                    //$('.slider-arrow img').css('cursor','pointer');
                });


                e.preventDefault();
            });


            $123('.placescoveredtbl .pcwrap ul li a').click(function (e) {
                $123('.nav-tabs li').removeClass('active');
                $123('a[href="#tab_tourinfo"]').parent().addClass('active');
                $123('#tab_dateprice').removeClass('active in');
                $123('#tab_tourinfo').addClass('active in');
                //$('a').attr().parent().addClass('active');
                e.preventDefault();
            });



        });
    
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
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-feedback.jpg)">
   <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" />
  
  
</header>
    <section class="innersection2">
    <div  class="tab-pane fade in active" id="tab_Feedback">
  <div class="container">
   <div class="row subheadrow">
      <div class="col-md-12">
        <h1 class="title">
        <span>Feedback</span> Form
        </h1>
      </div>
    </div>
    
  <uc1:leftuc ID="leftuc" runat="server" />
  </div>
   <%----%> <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <h1 class="title mrgnbtmh1"><span>Feedback</span></h1><%----%>
        <p>Help us to make our services better, provide us with your valuable suggestions and feedback. </p>
      </div>
    </div>
    <div class="formwrap innerforms">
    
    <div class="row mrgnbtminput">
    	<div class="col-md-6">
        
        <asp:TextBox ID="txtFullName" runat="server" MaxLength="250" ValidationGroup="FEValidation1"
        CssClass="form-control" placeholder="Name"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFullName"
        Display="Dynamic" ErrorMessage="Please enter your name!" SetFocusOnError="True"
        ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
       
        </div>
        <div class="col-md-6">
      
       <asp:TextBox ID="txtFeedEmail" runat="server" placeholder="Email" MaxLength="150" ValidationGroup="FEValidation1"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFeedEmail"
                                        Display="Dynamic" ErrorMessage="Please enter a valid email id!" SetFocusOnError="True"
                                        ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Reguemail" runat="server" ControlToValidate="txtFeedEmail"
                                        ErrorMessage="Please enter valid email id." SetFocusOnError="True" ValidationGroup="FEValidation1"
                                        Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
       </div>
    </div>
    
     <div class="row">
    	<div class="col-md-6">
        
               <asp:TextBox ID="txtMobile" runat="server" MaxLength="15" ValidationGroup="FEValidation1"  placeholder="Contact No."
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMobile"
                                        Display="Dynamic" ErrorMessage="Please enter your contact number!" SetFocusOnError="True"
                                        ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtMobile"
                                        Display="Dynamic" ErrorMessage="Please enter contact No. in numerics." ValidationExpression="^[0-9]+$"
                                        ValidationGroup="FEValidation1"></asp:RegularExpressionValidator>
       </div>
       <div class="col-md-6">
        
                <asp:TextBox ID="txtPlace" CssClass="form-control" placeholder="Place" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPlace"
                Display="Dynamic" ErrorMessage="Please enter place!" SetFocusOnError="True"
                 ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
                </div>
       </div>
      <div class="row">
    	<div class="col-md-6">
       
              <asp:RadioButtonList runat="server" ID="rbtntourtype" RepeatDirection=Horizontal CssClass="radiobtnwrap" >
       <asp:ListItem Value="1" Text="Domestic " ></asp:ListItem>
       <asp:ListItem Value="3" Text="International  "></asp:ListItem>
       </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rbtntourtype"
                Display="Dynamic" ErrorMessage="Please select tour type!" SetFocusOnError="True"
                 ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
       </div>
       <div class="col-md-6">
        
                <asp:TextBox ID="txtTourName" CssClass="form-control" placeholder="Tour Name" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTourName"
                Display="Dynamic" ErrorMessage="Please enter tour name!" SetFocusOnError="True"
                 ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
               </div>
       </div>
       
       <div class="row">
    	<div class="col-md-6">
        
              
       <asp:TextBox ID="txtPax" CssClass="form-control" placeholder="No of pax" runat="server" MaxLength="2"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPax"
                                        Display="Dynamic" ErrorMessage="Please enter No of pax!" SetFocusOnError="True"
                                        ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPax"
                                        Display="Dynamic" ErrorMessage="Please enter No of pax in numerics." ValidationExpression="^[0-9]+$"
                                        ValidationGroup="FEValidation1"></asp:RegularExpressionValidator>
      
       </div>
       <div class="col-md-6">
     <div class="input-group width100" >
                <input  class="form-control" placeholder="Journey Date" id="txtarrival" name="txtarrival" readonly="readonly" type="text" runat="server" />
                
               </div>
       
       </div>
       </div>
       <div class="row">
    	<div class="col-md-6">
      
                
        <asp:TextBox ID="txtPnr" CssClass="form-control" placeholder="PNR no(optional)" runat="server" MaxLength="15"></asp:TextBox>
      
      </div>
       <div class="col-md-6">
      
               
               <asp:TextBox ID="txtTicket" CssClass="form-control" placeholder="Ticket no(optional)" runat="server" MaxLength="15"></asp:TextBox>
                </div>
       </div>
       
        <div class="row mrgnbtminput">
        	
            <div class="col-md-12">
        	    <div class="inner-addon left-addon">
                    <i class="glyphicon glyphicon-pencil"></i>
                    <asp:TextBox ID="txtComments" Columns="46" Rows="5" TextMode="MultiLine" runat="server" placeholder="Suggestions / Feedback"
                                            Style="resize: none;" ValidationGroup="FEValidation1" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComments"
                                            Display="Dynamic" ErrorMessage="Please enter your comments!." SetFocusOnError="True"
                                            ValidationGroup="FEValidation1"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ValidationGroup="FEValidation1" ID="RegularExpressionValidator1"
                                            Display="Dynamic" ControlToValidate="txtComments" ValidationExpression="^[\s\S]{0,250}$"
                                            ErrorMessage="Please enter Comments in 250 characters." />
                </div>
            </div>
        	
        </div>
       <div class="row rowgap">
      	
        <div class="col-md-12">
        	
            <div class="tablewrap">
            	      <asp:GridView runat="server" ID="gvFeedBack" AutoGenerateColumns="False" Width="100%"
                                            GridLines="Horizontal" CellPadding="2" OnRowDataBound="gvFeedBack_RowDataBound"
                                            HeaderStyle-BackColor="#DE4118" HeaderStyle-ForeColor="#fffff" style="border:solid 1px #e5e5e5!important">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderStyle />
                                                    <ItemStyle  />
                                                    <ItemTemplate>
                                                       
                                                            <%--<%# Container.DataItemIndex + 1 %>--%>
                                                            <asp:Label ID="lblSrNo" runat="server" Text=' <%#Container.DataItemIndex+1 %>'></asp:Label>
                                                       
                                                        <asp:HiddenField ID="hdFeedOptID" runat="server" Value='<%# Eval("FeedOptID") %>' />
                                                        <asp:HiddenField ID="hdParentID" runat="server" Value='<%# Eval("ParentID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="FeedQuest" HeaderText="FeedBack Question " />
                                                  <asp:TemplateField>
                                                    <HeaderStyle />
                                                    <ItemStyle  />
                                                    <ItemTemplate>
                                                    
                                                    <asp:HiddenField runat="server" ID="hdnRating" Value=0/>
                                                       <input type="text" runat="server" id="txtstar"  class="rating rating-loading" value="0" data-size="xs" title=""/>
                                                         
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#DE4118" ForeColor="White"></HeaderStyle>
                                        </asp:GridView>

            </div>
            
        </div>
        
      </div>
<div class="row rowgap">
        <div class="col-md-12">
         <div class="g-recaptcha" runat="server" id="divrecaptcha" ></div>
                             <asp:Label ID="MessageLabel" runat="server" CssClass="txt" ForeColor="red"></asp:Label></div></div>
        <div class="row">
        <div class="col-md-12">
        <asp:Button runat="server" ID="btnSend" CssClass="commonbtn" Text="Submit"
                                        ValidationGroup="FEFEValidation1" 
                onclick="btnSend_Click" />
         
        </div>
    </div>
    
  </div>
  </div>
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
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
    <script type="text/javascript">
        $123('.rating').on('rating.change', function (event, value) {
            debugger;
            var id = $(this).attr('id');
            var Ratingid, points;
            points = Math.ceil(value)
            var newId = id.replace('txtstar', 'hdnRating');
            switch (points) {
                case 5: Ratingid = 1;
                    break;
                case 4: Ratingid = 2;
                    break;
                case 3: Ratingid = 3;
                    break;
                case 2: Ratingid = 4;
                    break;
                case 1: Ratingid = 5;
                    break;
            }
            (document.getElementById(newId)).value = Ratingid;



        });

        $123(function () {
            var stickyRibbonTop = $('.stickymenu').offset().top;

            $123(window).scroll(function () {
                if ($123(window).scrollTop() > stickyRibbonTop) {
                    $123('.stickymenu').addClass('sticky'); //css({position: 'fixed', top: '0px'});
                } else {
                    $123('.stickymenu').removeClass('sticky'); //css({position: 'static', top: '0px'});
                }
            });
        });

    </script>
    </form>
</body>
</html>
