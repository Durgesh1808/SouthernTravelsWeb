<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enquiryform.aspx.cs" Inherits="SouthernTravelsWeb.Enquiryform" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Enquiry : Southern Travels </title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <meta content="Southern Travels love to fulfil your desire to vacation. Fill our enquiry form to complete travel solutions at affordable prices."
        name="Description" />
    <meta content="southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package, south india beaches travel packages, south india holiday travel packages, holiday travel package to south india, southern india package travel, south india tourism, tourism in south india, holidays travel in southern india, kerala backwater travel packages in india, north india tour packages, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours, southern travels india, southerntravelsindia, Sirez"
        name="Keywords" />
    <meta content="index,follow" name="robots" />
    <meta content="Designed www.Sirez.com" name="Author" />
    <script src="Assets/js/jquery-2.2.0.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <script type="text/javascript">

        $(function () {


            $("#txtarrival").datepicker({

                numberOfMonths: 2,
                showOn: "button", autoSize: true,
                buttonImage: "Assets/images/calendar.gif",
                buttonImageOnly: true,
                minDate: new Date(),
                closeText: 'Close',
                dateFormat: 'dd/mm/yy', buttonText: 'Choose a Date'



            });

        });

        $(function () {


            $("#txtDept").datepicker({

                numberOfMonths: 2,
                showOn: "button", autoSize: true,
                buttonImage: "Assets/images/calendar.gif",
                buttonImageOnly: true,
                minDate: new Date(),
                closeText: 'Close',
                dateFormat: 'dd/mm/yy', buttonText: 'Choose a Date'



            });

        });
    </script>
    <script language="javascript" type="text/javascript">

        function ValidateChkList(source, arguments) {

            arguments.IsValid = IsCheckBoxChecked() ? true : false;



        }



        function IsCheckBoxChecked() {

            var isChecked = false;

            var list = document.getElementById('<%= ChkInterest.ClientID %>');

            if (list != null) {

                for (var i = 0; i < list.rows.length; i++) {

                    for (var j = 0; j < list.rows[i].cells.length; j++) {

                        var listControl = list.rows[i].cells[j].childNodes[0];

                        if (listControl.checked) {

                            isChecked = true;

                        }

                    }

                }

            }

            return isChecked;



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
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-enquiry.jpg)">
  
    <UCHeader:UCHeaderEndUser ID="UCHeaderEndUser1" runat="server" />
    
  </header>
    <section class="innersection2">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <h1 class="title mrgnbtmh1"><span>Enquiry</span> Form</h1>
        <p>Do fill in the form below to help us know your requirement better.</p>
      </div>
    </div>
    <div class="formwrap innerforms">
    
    <div class="row"><div class="col-md-12"><h4 class="title">When</h4></div></div>
    <div class="row mrgnbtminput">
        <div class="col-md-6">
         	<div class="input-group width100" >
                <input  class="form-control " placeholder="Arrival Date" id="txtarrival" name="txtarrival" readonly="readonly" type="text" runat="server" />
               <%-- <div class="input-group-addon"> <span class="glyphicon glyphicon-th"></span> </div>--%>
              </div>
              </div>
       
    	<div class="col-md-6">
        	<div class="input-group width100" >
                <input class="form-control " placeholder="Departure date" id="txtDept" name="txtDept" readonly="readonly" type="text" runat="server">
                <%--<div class="input-group-addon"> <span class="glyphicon glyphicon-th"></span> </div>--%>
              </div>
        </div>
    </div>
    
    <div class="row"><div class="col-md-12"><h4 class="title">Interested in *</h4></div></div>
    <div class="row mrgnbtminput">
    	
    <div class="brdrwrap">
        <%--<div class="col-md-4"><label> <input type="checkbox"> Air/Rail Ticketing</label></div>
    	<div class="col-md-4"><label> <input type="checkbox"> Hotel Reservation</label></div>
        <div class="col-md-4"><label> <input type="checkbox"> International Tour</label></div>
        <div class="col-md-4"><label> <input type="checkbox"> Tour of India</label></div>
        <div class="col-md-4"><label> <input type="checkbox"> Car / Coach Rental</label></div>--%>
       <asp:CheckBoxList ID="ChkInterest" runat="server"  RepeatDirection="Vertical"   ValidationGroup="Enq">
                                        <asp:ListItem Value="Air/Rail Ticketing"> Air / Rail Ticketing</asp:ListItem>
                                        <asp:ListItem Value="Tour of India"> Tour of India</asp:ListItem>
                                        <asp:ListItem Value="Hotel Reservation"> Hotel Reservation</asp:ListItem>
                                        <asp:ListItem Value="Car/Coach Rental"> Car / Coach Rental</asp:ListItem>
                                         <asp:ListItem Value="International Tour"> International Tour</asp:ListItem>
                                    </asp:CheckBoxList>
                                    <asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="ValidateChkList"  ValidationGroup="Enq"
                                        runat="server">Enter your interested in</asp:CustomValidator>
                                    <asp:Label ID="lblMsgTour" runat="server" CssClass="txt" ForeColor="Red"></asp:Label>
        </div>
    </div>
    
    <div class="row"><div class="col-md-12"><h4 class="title">Requirements *</h4>	</div></div>
     
     <div class="row mrgnbtminput">
    
        <div class="col-md-12">
        <textarea name="txtDescription" rows="3" cols="29" runat="server" id="txtDescription"
                                        class="form-control" placeholder="Enter your travel plan" ></textarea>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription"
                                        ValidationGroup="Enq" Display="Dynamic" ErrorMessage="Enter your travel plan"
                                        SetFocusOnError="True">Enter your travel plan</asp:RequiredFieldValidator>
        </div>
    	
    </div>
    
     <div class="row"><div class="col-md-12"><h4 class="title">Your Contact Information</h4>
     <p>* represents mandatory fields</p></div></div>
     
    <div class="row mrgnbtminput">
     <div class="col-md-6">
     <input maxlength="48" size="35" name="S_name" runat="server" id="S_name" class="form-control" placeholder="Name*"/>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="S_name"
      ValidationGroup="Enq" Display="Dynamic" ErrorMessage="Enter your name" SetFocusOnError="True"></asp:RequiredFieldValidator>
     </div>
     <div class="col-md-6" id="trHide6">
     <input maxlength="48" size="35" name="S_email" runat="server" id="S_email" class="form-control" placeholder="Email*" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="S_email"
                                        ValidationGroup="Enq" Display="Dynamic" ErrorMessage="Enter E-Mail" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="S_email" Display="Dynamic" ErrorMessage="Enter valid E-mail"
                                        ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+&amp;lt;(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})&amp;gt;$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$"
                                        SetFocusOnError="True" ValidationGroup="Enq"></asp:RegularExpressionValidator>
     </div>
    </div>
    
    <div class="row mrgnbtminput">
     <div class="col-md-6">
      <asp:DropDownList ID="ddlAdults" runat="server"  CssClass="form-control">
                                        <asp:ListItem Text="No. of Adults*" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlAdults"
                                        ValidationGroup="Enq" Display="Dynamic" ErrorMessage="Select no of adults" InitialValue="0"></asp:RequiredFieldValidator>
     </div>
     <div class="col-md-6" id="tr1" >
      <asp:DropDownList ID="ddlChilds" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="No. of Children*" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    </asp:DropDownList>
     </div>
    </div>
    
    <div class="row mrgnbtminput">
     <div class="col-md-6">
     <input size="35" name="S_phone" runat="server" id="S_phone" maxlength="11" class="form-control" placeholder="Phone / Mobile no.*" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="S_phone"
                                        ValidationGroup="Enq" ErrorMessage="Enter mobile no" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="S_phone"
                                        Display="Dynamic" ErrorMessage="Enter valid phone/mobile no" SetFocusOnError="True"
                                        ValidationGroup="Enq" ValidationExpression="^(-?\d{0,13}\.\d{0,5}|\d{0,13})$"></asp:RegularExpressionValidator>
     </div>
     <div class="col-md-6">
     <input size="35" id="S_fax" runat="server" onkeypress="javascript:return isNumberKey(event);"
                                        maxlength="12" class="form-control" placeholder="Fax no.*" />
     </div>
    </div>
    
     <div class="row mrgnbtminput">
    
        <div class="col-md-12"><%--<textarea class="form-control" placeholder="Address"></textarea>--%>
         <textarea size="35" id="S_streetaddress" maxlength="150" runat="server" class="form-control" placeholder="Address"/></textarea>
        </div>
    	
    </div>
    
     <div class="row mrgnbtminput">
     <div class="col-md-6">
     <input maxlength="48" size="35" id="S_city" runat="server" class="form-control" placeholder="City / State"  />
     </div>
     <div class="col-md-6">
     <input maxlength="20" size="15" id="S_pin" runat="server" class="form-control" placeholder="Zip / Postal Code" />
     </div>
    </div>
    
     <div class="row mrgnbtminput">
    
        <div class="col-md-6">
        <input maxlength="48" size="35" name="S_country" runat="server" id="S_country" class="form-control" placeholder="Country" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="S_country"
                                        ValidationGroup="Enq" Display="Dynamic" ErrorMessage="Enter  your country" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    	
    </div>
    
    
    
   <%--  <div class="col-md-6">     
                             <div class="g-recaptcha" runat="server" id="divrecaptcha" ></div>
                             </div>
     
     <div class="col-md-6">
                                    <asp:Label ID="MessageLabel" runat="server" CssClass="txt" ForeColor="red"></asp:Label>
                                    <br />
     </div>--%>
   
    
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
    <div class="row mrgnbtminput"><div class="col-md-12">
    <p class="mrgnbtmno">**This helps Southern Travels prevent automated Enquiries. </p>
	<p class="mrgnbtmno">***Please give your Phone no. or Mobile no. or both </p>
    </div></div>
    
    
    <div class="row mrgnbtminput">
    
        <div class="col-md-12">
        <div class="btnwrap">
        <%--<input type="submit" class="btn" value="Submit">&nbsp;&nbsp;&nbsp;
        <input type="submit" class="btn" value="Reset">--%>
        
         <asp:Button ID="btnSubmitQuery" runat="server" OnClick="btnSubmitQuery_Click" CssClass="btn" Text="Submit"
         OnClientClick = "ga('send', 'event', { eventCategory: 'amazing tour enquiry', eventAction: 'submit'});"
                                        runat="Server" ControlToValidate="txtDescription"
                                        ValidationGroup="Enq" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="ImageButton1" CssClass="btn" Text="Reset" runat="Server" OnClick="ImageButton1_Click" />
        </div>
        
            	
    </div>
    
  </div> <asp:Label ID="lblMsg" class="txt" runat="server" Text="" CssClass="orange14"></asp:Label>
  </div>
  </div>
</section>
    <UCFooter:UCFooterEndUser ID="UCFooterEndUser2" runat="server" />
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
        $('#refresh_captcha').click(function (e) {
            $('#captchImg').attr('src', 'JpegImage.aspx?cache=' + new Date().getTime());
            e.preventDefault();
        });
    </script>
</body>
</html>

