<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntItenaryDetails.aspx.cs" Inherits="SouthernTravelsWeb.IntItenaryDetails" %>


<%@ Register Src="UserControl/UcTourItinerary.ascx" TagPrefix="UC" TagName="Itinerary" %>
<%@ Register Src="UserControl/UCHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UCFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcMatchingTour.ascx" TagName="ucMatchingTour" TagPrefix="uc3" %>

<%@ Register Src="UserControl/UcTourShortInfo.ascx" TagName="ucTourShortInfo" TagPrefix="uc2" %>
<%@ Register Src="UserControl/UcTourCostIncludeExcIude.ascx" TagName="ucTourCostIncludeExcIude"
    TagPrefix="ucCostIncludeExclue" %>
<%@ Register Src="UserControl/UcTourInfo.ascx" TagName="UCTourInfo" TagPrefix="uc4" %>
<%@ Register Src="UserControl/UcTourGallery.ascx" TagName="UCTourGallery" TagPrefix="uc5" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="HeadST" runat="server">
    <title>International Holiday Packages - Thailand Tour Packages | Bangkok Pattaya | Singapore
        | Malaysia Package Tour</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta id="mtDescription" name="Description" content="Great deals to International holiday packages, comfort accommodation and travel to malaysia, singapore, thailand, bankok pattaya, srilanka, newzealand and dubai destinations of world from southerntravelsindia. Free online Enquiry on tours!" />
    <meta id="mtKeywords" name="Keywords" content="international tour packages, international holiday packages, srilanka tours, australia tours, middle east tours, egypt tour, new zealand tours, africa tour, malaysia holidays packages, singapore tour, mauritius tour, hong kong tour, thailand tour, colombo, kandy tour, dubai tour, south Africa package tour, new Zealand tour packages, north island package tour, south island, bangkok pattaya, thailand package, bangkok package, mauritius tour, thailand tour packages, singapore package, santosa singapore, santose, malaysia singapore, sentosa singapore, santos" />
    <meta id="mtrobots" name="robots" content="index,follow" />
    <asp:placeholder runat="server" id="plcItHead">
        <meta property="og:image" content="https://www.southerntravelsindia.com/Assets/images/EntityImage/<%= pbFBImage1 %>" />
        <meta property="og:image" content="https://www.southerntravelsindia.com/Assets/images/EntityImage/<%= pbFBImage2 %>" />
    </asp:placeholder>
    <script language="javascript" type="text/javascript">
        function fnRest() {
            document.getElementById("txtDescription").value = "";
            document.getElementById("S_name").value = "";
            document.getElementById("ddlAdults").value = "0";
            document.getElementById("ddlAdults").value == "0";
            document.getElementById("S_email").value = "";
            document.getElementById("S_email").value = "";
            document.getElementById("S_phone").value = "";
            document.getElementById("S_city").value = "";
            document.getElementById("S_country").value = "";

            return false;
        }
        function fnValidation() {

            if (document.getElementById("hdnIsFixedIntTour").value == "1") {
                if (document.getElementById("hdnStartDate").value == "") {
                    alert("Please select your departure date");
                    return false;
                }
            }

            if (document.getElementById("hdnIsFixedIntTour").value == "0") {
                if (document.getElementById("txtDescription").value == "") {
                    alert("Please describe your travel plan / requirements");
                    document.getElementById("txtDescription").value = "";
                    document.getElementById("txtDescription").focus();
                    return false;
                }
            }

            if (document.getElementById("ddlAdults").value == "0") {
                alert("Please select the no of pax");
                document.getElementById("ddlAdults").focus();
                return false;
            }

            if (document.getElementById("S_name").value == "") {
                alert("Please enter your name");
                document.getElementById("S_name").value = "";
                document.getElementById("S_name").focus();
                return false;
            }

            if (document.getElementById("S_email").value == "") {
                alert("Please enter your email");
                document.getElementById("S_email").value = "";
                document.getElementById("S_email").focus();
                return false;
            }
            if (!echeck(document.getElementById("S_email").value)) {
                document.getElementById("S_email").value = "";
                document.getElementById("S_email").focus();
                return false;
            }
            if (document.getElementById("S_phone").value == "") {
                alert("Please enter your phone number");
                document.getElementById("S_phone").value = "";
                document.getElementById("S_phone").focus();
                return false; chkMail
            }
            if (document.getElementById("S_city").value == "") {
                alert("Please enter your City name");
                document.getElementById("S_city").value = "";
                document.getElementById("S_city").focus();
                return false;
            }
            if (document.getElementById("S_country").value == "") {
                alert("Please enter your country name");
                document.getElementById("S_country").value = "";
                document.getElementById("S_country").focus();
                return false;
            }

            // ******   Java Script Start here for Email Checking ***********
            function echeck(str) {
                if (str.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1) {
                    return true;
                }
                else {
                    alert("Invalid E-mail ID");
                    return false;
                }
            }
            // ******   Java Script end here for Email Checking ***********
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <script src="Assets/js/jquery-2.2.0.min.js"></script>
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

        function SetDate(strdate) {

            document.getElementById("<%=hdnStartDate.ClientID  %>").value = strdate;
            document.getElementById("<%=txtfixedDeprtureDate.ClientID  %>").value = strdate;

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
    <form id="form1" runat="server">
    <!-- Header Start -->
    <asp:HiddenField ID="hdnTourItitearyHTML" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourFare" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourInfo" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourName" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourCodeDetails" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourInclusionExculision" runat="server" Value="" />
    <asp:HiddenField ID="hdnStartDate" runat="server" />
    <asp:HiddenField ID="hdnIsFixedIntTour" runat="server" Value="0" />
    <header class="posrel innerheader" runat="server" id="hd">
  <div class="herobanner">
    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" />
      </div>
</header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <section class="innersection2">
  <div class="container">
  

  <uc2:ucTourShortInfo ID="ucTourShortInfo1" runat="server" fldCanBook="false" />
   
      
      
      
      <div class="col-md-8">
        <div class="tab-content tab-content-inner">
          <div class="tab-pane fade in active" id="tab_itinerary">
          <h2 class="title showonmobile">Itinerary</h2>
            <div class="tbldetail">
            
              <UC:Itinerary runat="server" ID="ucItinerary" fldTourType="INTERNATIONAL_TOUR" />
              
               
            </div>
          </div>
          <div class="tab-pane" id="tab_dateprice"> 
          	<h2 class="title showonmobile">Date & Price Info</h2>
            
            <!-- tour Price -->
            <div class="tourprice">
              <h3 class="title">Tour <span>Price</span></h3>
              <div class="">
              <asp:Panel runat=server ID="pnlcost">
               <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table-bordered"><tbody><tr>
               <th class="th2">Cost</th>
                    <th class="th2"><asp:Literal ID=litcost runat=server></asp:Literal>/-  for per person</th></tr>
                    <tr><td colspan ="2"><i class="fa fa-rupee"></i> * Terms & Conditions Apply</td></tr>
                    </tbody></table>
                
                </asp:Panel>
                 <asp:Panel runat=server ID="pnlCoustem">
                <asp:Literal ID=litcoutCost runat=server></asp:Literal>
                </asp:Panel>
        
        <!-- Fixed Date Section will be visible only in case of fixed date-->        
             <div id="divFixedDate" runat="server">
              <div class="row"><div class="col-md-12"><h4 class="title">Departure Date *</h4>	</div></div>
     
     <div class="row mrgnbtminput">
      <div class="col-md-3">
       <input type="text" class="form-control"  runat="server" id="txtfixedDeprtureDate"  name="txtDept" readonly="readonly" >
       </div>
    	
    </div>
    </div>
 <!-- Fixed Date Section-->     
                <p class="notepara"><span>Note : </span>Government Services Tax 5% payable extra<br />TCS 5% on gross bill payable extra</p>
                <p id="psplNote" runat="server" visible="false" class="notepara" style="color:Red"><span style="color:Red">Note: </span>INR 2000 additional fee will be charged for all FBFE9 departures, in lieu of increased visa fee for Thailand w.e.f. 01st Sept,2017.</p>
                
                
              </div>
            </div>
             <!-- end tour Price -->
               
               
               
               <!-- calendar -->
                <div class="formwrap innerforms fullwidth">
             <h3 class="title">Enquiry For: <span><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></span></h3>
    
    <div id="divSpecialFields" runat="server" visible="false">
    <div class="row"><div class="col-md-12"><h4 class="title">When</h4></div></div>
    <div class="row mrgnbtminput">
        <div class="col-md-6">
         	<div class="input-group width100">
                <input type="text" class="form-control" placeholder="Departure date" runat="server" id="txtarrival"  name="txtarrival">
                <%--<div class="input-group-addon"> <span class="glyphicon glyphicon-th"></span> </div>--%>
              </div>
              </div>
       
    	<div class="col-md-6">
        	<div class="input-group width100">
                <input type="text" class="form-control" placeholder="Return date" runat="server" id="txtDept"
                                        name="txtDept">
                <%--<div class="input-group-addon"> <span class="glyphicon glyphicon-th"></span> </div>--%>
              </div>
        </div>
    </div>
  
    
    <div class="row"><div class="col-md-12"><h4 class="title">Describe Your Travel Plan/Requirements: *</h4>	</div></div>
     
     <div class="row mrgnbtminput">
    
        <div class="col-md-12"><textarea class="form-control" placeholder="Enter your travel plan" runat="server"
                                    id="txtDescription" name="txtDescription"></textarea></div>
    	
    </div>
    </div>
    
     <div class="row"><div class="col-md-12"><h4 class="title">Your Contact Information</h4>
     <p>* represents mandatory fields</p></div></div>
     
    <div class="row mrgnbtminput">
     <div class="col-md-6">
     
    
                                        
         <asp:DropDownList ID="ddlAdults" runat="server" CssClass="form-control">
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
                                        
                                        </div>
     <div class="col-md-6">
     
     <asp:DropDownList ID="ddlChilds" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="No. of Children (2 to 11 years)" Value="0"></asp:ListItem>
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
     
      <input type="text" class="form-control" placeholder="Name*"  maxlength="48" name="S_name"
                                        runat="server" id="S_name">
     
     
                                    </div>
     <div class="col-md-6">
    
     <asp:DropDownList ID="ddlInfants" runat="server"  CssClass="form-control">
                                        <asp:ListItem Text="No of Infants (1 to 23 Months)" Value="0"></asp:ListItem>
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
     <input type="text" class="form-control" placeholder="Email*" maxlength="48" name="S_email"
                                        runat="server" id="S_email">
     </div>
     <div class="col-md-6">
     <input type="text" class="form-control" placeholder="Phone / Mobile no.*" name="S_phone" runat="server" id="S_phone" onkeypress="javascript:return isNumberKey(event);"
                                        maxlength="11">
     </div>
    </div>
    
    <div class="row mrgnbtminput">
    <div class="col-md-6">
    <input type="text" class="form-control" placeholder="Fax no." id="S_fax" runat="server" onkeypress="javascript:return isNumberKey(event);" maxlength="12" visible="false">
       <input type="text" class="form-control" placeholder="Street Address" id="S_streetaddress" maxlength="200" runat="server" >                                 
                                        
                                        
                                        </div>
        <div class="col-md-6">
        <input type="text" class="form-control" placeholder="City / State*" maxlength="48" id="S_city" runat="server">
        </div>
    </div>
   
   
    <div class="row mrgnbtminput">
     <div class="col-md-6">
     <input type="text" class="form-control" placeholder="Zip / Postal Code" maxlength="20" id="S_pin" runat="server" onclick="return S_pin_onclick()">
     </div>
     <div class="col-md-6">
     <input type="text" class="form-control" placeholder="Country*" maxlength="48" name="S_country"
                                        runat="server" id="S_country">
     
     </div>
    </div>
    
    <div class="row mrgnbtminput">
    
        <div class="col-md-6"></div>
    	
    </div>
    
    
    <div class="row mrgnbtminput">
    <%-- <div class="col-md-6">
     <div class="g-recaptcha" runat="server" id="divrecaptcha" ></div>
     <p>This helps Southern Travels prevent automated Enquiries.</p>
                   
     </div>
     <div class="col-md-6"> <%--<asp:TextBox ID="txtCaptchImage" class="form-control" placeholder="Captcha Code" MaxLength="50" runat="server"></asp:TextBox>--%>
     <asp:Label
                                        ID="MessageLabel" runat="server" CssClass="txt" ForeColor="red"></asp:Label>
                                        
     
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
    </div>
    
	
    <div class="row mrgnbtminput">
    
        <div class="col-md-12">
        <div class="btnwrap">
        
        <asp:Button runat="server" class="btn" Text="Submit" ID="imgbtnSendRequest" 
                OnClientClick="ga('send', 'event', { eventCategory: 'international tour enquiry', eventAction: 'submit query'}); return fnValidation();" onclick="imgbtnSendRequest_Click1" />
       &nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" ID="imgbtnReset" OnClientClick="return fnRest();" class="btn" Text="Reset" />
         
        </div>
        
            	
    </div>
    
  </div>
  <div><asp:Label ID="lblMsg" class="txt" runat="server" Text=""></asp:Label></div>
  </div>
                <!-- end calendar -->
               
               
                
          </div>
           <div class="tab-pane" id="tab_inclexcl"> 
           <h2 class="title showonmobile">Inclusions/Exclusions</h2>
           <!-- tour Price -->
          <ucCostIncludeExclue:ucTourCostIncludeExcIude ID="ucInclu"  
        runat="server" />
                
          </div>
          <div class="tab-pane" id="tab_tourinfo"> 
          	<h2 class="title showonmobile">Tour Info</h2>
          	<uc4:UCTourInfo ID="UCTourInfo1" runat="server" />
           
          </div>
          
          
          <div class="tab-pane" id="tab_similar"> 
          <h2 class="title showonmobile">Similar Packages</h2>
          <uc3:ucMatchingTour ID="ucMatchingTour1" runat="server" /> 
          
          
          </div>
          
          <div class="tab-pane" id="tab_gallery" style="display:none !important">
          <h2 class="title showonmobile">Tour Gallery</h2>
          <uc5:UCTourGallery ID="UCTourGallery1" runat="server" /></div>
        </div>
      </div>
    </div>
 
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    </form>
    <script type="text/javascript">
	    $(document).ready(function($) {
    	  
		  
		  $("#blog-slider").owlCarousel({
			    items : 1,
				pagination : false,
				// Navigation
				navigation : true,
				navigationText : ["<i class='fa fa-caret-left'></i>","<i class='fa fa-caret-right'></i>"],
				rewindNav : true,
				scrollPerPage : false,
		  });
		  
		  $("#like-slider").owlCarousel({
			    items : 1,
				pagination : false,
				// Navigation
				navigation : false,
				loop:true,
				autoPlay:true,
				autoplayTimeout:1000,
				autoplayHoverPause:true
		  });
		  
		  
		  
	    });
    </script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {

            initialize();
        });
        
    </script>
    <script>
        $('select').selectpicker({
            style: 'btn-info',
            size: 4
        });

     
    </script>
    <script src="/Assets/js/jquery-ui.js"></script>
    <script>
   
    </script>
    <script type="text/javascript">
        $(function () {
            $('.tabsection_inner .nav-tabs li a').on('click', function (e) {
              
                $("html, body").animate({ scrollTop: 0 }, "slow");
                e.preventDefault();
            });
        });
    </script>
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
        $('#refresh_captcha').click(function (e) {
            $('#captchImg').attr('src', 'JpegImage.aspx?cache=' + new Date().getTime());
            e.preventDefault();
        });
    </script>
</body>
</html>
