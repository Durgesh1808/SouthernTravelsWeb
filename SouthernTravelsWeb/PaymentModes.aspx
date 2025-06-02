<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentModes.aspx.cs" Inherits="SouthernTravelsWeb.PaymentModes" %>

<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcQuickSearch.ascx" TagPrefix="uc" TagName="QuickSearch" %>
<%@ Register Src="UserControl/UCPaymentOptionNetBanking.ascx" TagName="UCPaymentOptionNetBanking"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Payment Modes : Southern Travels</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="Description" content="At Southern Travels, We have various payment transaction modes to pay, that make a hassel-free experience to our valuable customers." />
    <meta name="Keywords" content="tour and travels agency, tour and travel agency in india, north india tour package, south india tour packages, fixed departure tour, international tour, domestic tour operator, tour operator in india, travel agency, car rental, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours" />
    <meta name="robots" content="index,follow" />
    <!-- Google Tag Manager -->
    <script>        (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({ 'gtm.start':
new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-WXRG7KM');</script>
    <!-- End Google Tag Manager -->
    <script type="text/javascript">
        var $zoho = $zoho || {}; $zoho.salesiq = $zoho.salesiq || { widgetcode: "f9285012553db7ccdec3cf907b30482c1f0e0a2bd9e18f0f2b52a1810adb9374cd30ce7a28be5ad051877c21011ab9a5", values: {}, ready: function () { } }; var d = document; s = d.createElement("script"); s.type = "text/javascript"; s.id = "zsiqscript"; s.defer = true; s.src = "https://salesiq.zoho.com/widget"; t = d.getElementsByTagName("script")[0]; t.parentNode.insertBefore(s, t); d.write("<div id='zsiqwidget'></div>");
    </script>
    <script src="https://cdn.pagesense.io/js/southerntravels/95bf3c0ba74f44f9baed4ddf90896ba3.js"></script>
</head>
<body>
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-WXRG7KM" height="0"
            width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->
    <form id="form1" runat="server">
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-fixed-tour-detail.jpg)">
    <UCHeader:UCHeaderEndUser ID="UCHeaderEndUser1" runat="server"  fldMainSection="CUST_Login"/>
    </header>
    <section class="innersection2">
  
   
    <div class="container">
      <div class="row subheadrow">
        <div class="col-md-12">
        	
          <h1 class="title"><span>Payment </span> modes </h1>
        </div>
      </div>
      <div class="paymodediv">
      
      <div class="row">
      <div class="col-md-12">
      	  <div class="weaccept">
                    <h2 class="title"><span>Credit card</span> and <span>Debit Card</span></h2>
                    <p><a><img loading="lazy" src="Assets/images/paymentmodes/visa_logo.jpg"></a> <a><img loading="lazy" src="Assets/images/paymentmodes/Maestro_logo.jpg"></a>  <a><img loading="lazy" src="Assets/images/paymentmodes/MasterCard_Logo.jpg"></a> <a><img loading="lazy" src="Assets/images/paymentmodes/amex-card.jpg"></a> </p>
                  </div>
                  </div>
      </div>
      
       <div class="row subheadrow">
        <div class="col-md-12">
        	
          <h2 class="title"> <span>Bank </span> transfer</h2>
          <h5 class="title"><span>Name of the account: </span>SOUTHERN TRAVELS PVT LTD.</h5>
        </div>
      </div>
      
      <div class="row">
       	<div class="col-md-6">
        
       <div class="bankbox">
       
       <h4><span>STATE BANK OF INDIA</span></h4>
       <p>Account Number : 37070052215</p>
       <p>Bank Address : SME BRANCH AJMAL KHAN ROAD 12/56 DESH BANDHU GUPTA ROAD KAROL BAGH, NEW DELHI-110005</p>
       <p>IFSC Code : SBIN0000666</p>
       <p>Swift Code : SBININBB550</p>
       <p>Branch : SME BRANCH AJMAL KHAN ROAD</p>
       
       </div>
                   
        
        <div class="bankbox" style="display:none">
        
        
        <h4 class="title"><span>ICICI Bank</span></h4>
        
        <p>Address: 2692, Deshbandu Gupta Road, Karol Bagh, New Delhi 110005.</p>
		<p>Account number: 6291 0503 6409</p>
		<p>Swift Code: ICICINBBNRI</p>
		<p>RTGS / NEFT/IFSC CODE: ICIC0006291</p>
        
        
         </div>
        	
        	<div class="bankbox" style="display:none">
        <h4><span>ING Vysya Bank Ltd.</span></h4>
        
        <p>Address: 16/11,R.D.Chambers,1 Floor, Arya Samaj Road, Karol Bagh, New Delhi 110005.</p>
		<p>Account number: 5300 1100 9431</p>
		<p>Swift Code: VY SAIN BB NDL</p>
        
       
        </div>
        
        <div class="bankbox" style="display:none">
       <h4><span>HDFC Bank</span></h4>
        <p>Address: No. 2212, Gali no. 64-65, J-Block Naiwala, Gurudwara Road, Karol Bagh,</p> 					        
        <p>New Delhi – 110005</p>
		<p>Account number: 04398520000023</p>
		<p>Swift Code: BOFAUS3N</p>
		<p>RTGS / NEFT/IFSC CODE: HDFC0000439</p>
       
         </div>
	    
        </div>
        
        	<div class="col-md-6">
				
          <div class="bankbox">
        <h4 class="title"><span>CENTRAL BANK OF INDIA</span></h4>
      
         <p>Account Number : 3171074362</p>
         <p>Bank Address : CONNAUGHT CIRCUS New Delhi 110001</p>
        <p>IFSC Code: CBIN0280301</p>
        <p>Swift Code: CBININBBPAR</p>
        <p>Branch : CONNAUGHT CIRCUS</p>
        
         </div>
         
         
         
        
       		 <div class="bankbox" style="display:none">
        <h4><span>INDIAN OVERSEAS BANK</span></h4>
        
        <p>Account number: 044202000005218</p>
		<p>Swift Code: IOBAINBB442</p>
		<p>RTGS / NEFT/IFSC CODE: IOBA0000442</p>
       
        </div>
        
         		<div class="bankbox" style="display:none">
       <h4><span>AXIS BANK</span></h4>
        <p> Address: JHANDEWALAN EXTENSION NEW DELHI</p>
       <p> Account number: 911020049660426</p>
        <p>Swift Code: AXISINBB738</p>
        <p>RTGS / NEFT/IFSC CODE: UTIB0000738</p>
       
         </div>
         
             
        </div>
       
        <div class="mail">
        	<div class="col-md-12">
            	<p>After the payment is made you are requested to Fax / Email us a copy of the pay-in-slip along with the details of the tour, to our Fax: +91-11-2875 7308 / Email :<a href= "mailto:support@southerntravels.in"><span>support@southerntravels.in</span></a></p>
            </div>
        </div>
      </div>
      </div>
    </div>
    
  
    
      <div class="container">
       	<div class="row subheadrow">
        	<div class="col-md-12">
                	<h2 class="title"><span>Net Banking</span> List:</h2>
                	</div>
                </div>
                <div class="row">
                	<div class="col-md-4">
                    	<div class="bankdiv">
                      	
                        <ul class="sublist">
                        <li>Allahabad Bank</li>
                     	<li>Bank of Baroda</li>
                        <li>Beam Cash Card</li>
                        <li>City Union Bank</li>
                        <li>Deutsche Bank</li>
                        <li>Federal Bank</li>
                     	<li>ICICI Bank</li>
                        <li>Indian Overseas Bank</li>
                        <li>Kotak Mahindra bank</li>
                        <li>Oriental Bank Of Commerce</li>
                        <li>RuPay</li>
                     	<li>Standard Chartered Bank</li>
                        <li>State Bank Of Bikaner and Jaipur</li>
                        <li>State Bank of Travencore</li>
                        <li>United Bank of India</li>
                        <li>Visa Master Maestro Debit Card Gateway</li>
                        </ul>
                        
                        
                        
                        </div>
                    </div>
                    <div class="col-md-4">
                    <div class="bankdiv">
                      	<ul class="sublist">
                        <li>AXIS Bank</li>
                     	<li>Bank of India</li>
                        <li>Central Bank of India</li>
                        <li>Canara Bank</li>
                        <li>Development Credit Bank</li>
                        <li>Hdfc Net Banking</li>
                     	<li>IDBI Bank</li>
                        <li>ING Vysya Bank</li>
                        <li>Karnataka Bank</li>
                        <li>Pay Zapp</li>
                        <li>Punjab National Bank</li>
                     	<li>State Bank of Hyderabad</li>
                        <li>State Bank of Patiala</li>
                        <li>Tamilnad Mercantile Bank</li>
                        <li>Vijaya Bank</li>
                        </ul>
                        
                        </div>
                    </div>
                    <div class="col-md-4">
                    	<div class="bankdiv">
                        <ul class="sublist">
                      	<li>Bank of Bahrain and Kuwait</li>
                     	<li>Bank of Maharashtra</li>
                        <li>Citi Bank</li>
                        <li>Catholic Syrian Bank</li>
                        <li>Dhanlaxmi Bank</li>
                        <li>I-Cash Card</li>
                     	<li>Indian Bank</li>
                        <li>J&K Bank</li>
                        <li>Karur Vysya Bank</li>
                        <li>Pay Zapp Debit</li>
                        <li>South Indian Bank</li>
                        <li>State Bank of India</li>
                        <li>State Bank of Mysore</li>
                        <li>Union Bank of India</li>
                        <li>Visa Master Maestro Credit Card Gateway</li>
                       </ul>
                        </div>
                        
                        </div>
                </div>
             </div>
         
  
 
</section>
    <UCFooter:UCFooterEndUser ID="UCFooterEndUser1" runat="server" />
    </form>
</body>
</html>
