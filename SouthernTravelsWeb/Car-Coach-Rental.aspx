<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Car-Coach-Rental.aspx.cs" Inherits="SouthernTravelsWeb.Car_Coach_Rental" %>

<%@ Register Src="UserControl/UcHolidaySearch.ascx" TagName="UCHolidaySearch" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcFixedTourList.ascx" TagName="UCFixedTour" TagPrefix="UCTourList" %>
<%@ Register Src="UserControl/UcCarCoachRental.ascx" TagName="ucCarCoachRental" TagPrefix="uc2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" itemtype="http://schema.org/TravelAgency" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Car Coach Rental | Volvo Bus Service </title>
    <meta name="Description" content="We provides car coach on rent, economy & luxury buses and  Volvo buses at most affordable prices and best services." />
    <meta name="keywords" content="car rental services in Delhi, Volvo bus services in Delhi, car rental in Delhi, car rental in Bangalore, car rental service in Hyderabad, car rental in Chennai, Volvo bus service in Bangalore, car rentals Bangalore, Volvo bus services Hyderabad, car rental company India, car rental agency Delhi, car rental in Mumbai, AC Volvo, Volvo rental India, luxury coaches rental, car hire in India, travel agency, travel agent" />
    <meta name="robots" content="index,follow" />
    <meta name="Author" content="Designed by www.sirez.com" />
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
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
    <form id="form" runat="server" style="margin: 0px;">
    <!-- Header Start -->
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-car-coach.jpg)">
  <div class="herobanner">
     <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="CAR_COACH_RENTAL" />
  </div>
  </header>
    <section class="innersection2 carcoachsection">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12">
        <h1 class="title"> <span>Car / Coach </span> Rental </h1>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12">
        <div class="carcoach">
          <p>Southern Travels has been appreciated for its car & coach rental services with a wide range of cars and luxury coaches. Car & Coach Rental can be a hassle-free job with Southern Travels for the Business and Leisure Travelers. We offer modern Economy, Luxury Cars, Vans, Mini vans, Minibuses and Large Buses, having up to 60 seats at most affordable prices and best services.</p>
        </div>
        
      </div>
    </div>
  </div>
  
  <div class="clearfix"></div>

  <div class="clearfix"></div>
   
   <div class="container">
   		
        <div class="row">
        	<div class="col-md-12 text-center">
            <h2 class="title mrgntopno"><span>Transport at Southern Travels</span> comes with a huge bonus "Choice"</h2>
           
            <hr>
            </div>
        </div>
        
        
        <div class="row rowgap">
        	<div class="col-md-4">
            	<div>
                <p class="posrel imgsection"><img src="Assets/images/car-coach/car-sedan.jpg" class="img-responsive imgborder3px" loading="lazy" />
                </p>
                <div class="carcoachbox">
                	<h3 class="title mrgnbtmno"><span>Car (Economy) Sedan</span></h3>
                    <p>Tata Indigo/Swift Dzire/Toyota Etios</p>
                    <ul class="sublist">
                    <li>Air-Condition (cool + Warm)</li>
<li>Audio System</li>
<li>Comfortable Seats</li>
<li>Spacious leg space</li>
<li>Driver + 4 Seating</li>
                    </ul>
                    </div>
                    <p><a href="javascript:void(0);" class="commonbtn">Book now</a></p>
                </div>
            </div>
            
           	<div class="col-md-4">
            	<div>
                <p class="posrel imgsection"><img src="Assets/images/car-coach/car-suv.jpg" class="img-responsive imgborder3px" loading="lazy" />
                </p>
                <div class="carcoachbox">
                	<h3 class="title mrgnbtmno"><span>Car (Deluxe), SUV</span></h3>
                    <p>Toyota Innova (6 / 7 seater)</p>
                    <ul class="sublist">
                    <li>Air-Condition(Cool + Warm)</li>
<li>Audio System</li>
<li>Comfortable Seats (6 - Seater Bucket seating, 7 - Seater Sofa Seating)</li>
<li>Spacious leg space</li>
<li>Driver + (6 / 7 Seating)</li>
                    </ul>
                    </div>
                     <p><a href="Enquiryform.aspx?Type=Car&Text=Car (Deluxe), SUV" class="commonbtn">Book now</a></p>
                </div>
            </div>
            
           	<div class="col-md-4">
            	<div>
                <p class="posrel imgsection"><img src="Assets/images/car-coach/car-luxury.jpg" class="img-responsive imgborder3px" loading="lazy" />
                </p>
                <div class="carcoachbox">
                	<h3 class="title mrgnbtmno"><span>Car (Luxury)</span></h3>
                    <p>Skoda Superb / Toyota Camry / Toyota Fortuner / BMW / Mercedes Benz / Audi Car / Land Rover </p>
                    <ul class="sublist">
                  <li>  Air-Condition(Cool + Warm)</li>
<li>Bluetooth Audio Streaming, Ipad / MP3 Media interface</li>
<li>LCD Screen Video system</li>
<li>Spacious leg space, Arm Rest</li>
<li>Adjustable Power seats</li>
<li>Navigation System</li>
                    </ul>
                    </div>
                     <p><a href="Enquiryform.aspx?Type=Car?Text=Car (Luxury)" class="commonbtn">Book now</a></p>
                </div>
            </div>
        </div>
        
          <div class="row rowgap">
        	<div class="col-md-4">
            	<div>
                <p class="posrel imgsection"><img src="Assets/images/car-coach/tempo-traveller.jpg" class="img-responsive imgborder3px" loading="lazy" />
                </p>
                <div class="carcoachbox2">
                	<h3 class="title mrgnbtmno"><span>Tempo Traveller</span></h3>
                    <p>9+1 Seater</p>
                    <ul class="sublist">
                   <li>Fully Air-Condition(Cool + Warm)</li>
<li>Audio System</li>
<li>Equipped with LCD Screen</li>
<li>Maharaja Seats (1 X 1)</li>
<li>Spacious leg space with foot rest</li>
<li>Luxurious Interior </li>
<li>Fixed Glasses </li>
                    </ul>
                    </div>
                    <p><a href="Enquiryform.aspx?Type=car&Text=Tempo Traveller : 9+1 Seater" class="commonbtn">Book now</a></p>
                </div>
            </div>
            
           	<div class="col-md-4">
            	<div>
                <p class="posrel imgsection"><img src="Assets/images/car-coach/hitech-coach.jpg" class="img-responsive imgborder3px" loading="lazy" />
                </p>
                 <div class="carcoachbox2">
                	<h3 class="title mrgnbtmno"><span>Hi-Tech Coaches</span></h3>
                    <p>35 / 40 / 45 Seater</p>
                    <ul class="sublist">
                   <li>Fully Air-Condition (Cool + Warm)</li>
<li>Audio System</li>
<li>Equipped with LCD Screen</li>
<li>Comfortable Seats with fully push back (2 X 2)</li>
<li>Spacious leg space with foot rest</li>
<li>Air Suspension</li>
<li>Mike System</li>
                    </ul>
                    </div>
                     <p><a href="Enquiryform.aspx?Type=car&Text=Hi-Tech Coaches : 35 / 40 / 45 Seater" class="commonbtn">Book now</a></p>
                </div>
            </div>
            
           	<div class="col-md-4">
            	<div>
                <p class="posrel imgsection"><img src="Assets/images/car-coach/mini-coach.jpg" class="img-responsive imgborder3px" loading="lazy" />
                </p>
                 <div class="carcoachbox2">
                	<h3 class="title mrgnbtmno"><span>Mini - Coaches</span></h3>
                    <p>25 / 27  Seater </p>
                    <ul class="sublist">
                 <li>Fully Air-Condition (Cool + Warm)</li>
<li>Audio System</li>
<li>Video System</li>
<li>Comfortable Seats with  push back (2 X 2)</li>
<li>Spacious leg space with foot rest</li>
<li>Air Suspension</li>
<li>Mike System</li>
                    </ul>
                    </div>
                     <p><a href="Enquiryform.aspx?Type=car&Text=Mini - Coaches : 25 / 27  Seater" class="commonbtn">Book now</a></p>
                </div>
            </div>
        </div>
        
          <div class="row rowgap">
        	<div class="col-md-4">
            	<div>
                <p class="posrel imgsection"><img src="Assets/images/car-coach/volvocoach.jpg" class="img-responsive imgborder3px" loading="lazy" />
                </p>
                 <div class="carcoachbox3">
                	<h3 class="title mrgnbtmno"><span>Volvo Coach</span></h3>
                    <p>45 Seater</p>
                    <ul class="sublist">
                  <li>Fully Air-Condition(Cool + Warm)</li>
<li>Audio System</li>
<li>Equipped with LCD Screen</li>
<li>Reclaining Seats (2 X 2)</li>
<li>Spacious leg space with foot rest</li>
<li>Hydraulic Retrader</li>
<li>Full Air Suspension</li>
<li>Luxurious Interior </li>
<li>Fixed Glasses </li>
                    </ul>
                    </div>
                    <p><a href="Enquiryform.aspx?Type=car&Text=Volvo Coach : 45 Seater" class="commonbtn">Book now</a></p>
                </div>
            </div>
            
           	<div class="col-md-4">
            	<div>
                <p class="posrel imgsection"><img src="Assets/images/car-coach/multi_axel_volvo.jpg" class="img-responsive imgborder3px" loading="lazy" />
                </p>
                <div class="carcoachbox3">
                	<h3 class="title mrgnbtmno"><span>Volvo Multi Axle Coach</span></h3>
                    <p>53 Seater</p>
                    <ul class="sublist">
                   <li>Fully Air-Condition(Cool + Warm)</li>
<li>Audio System</li>
<li>Equipped with LCD Screen</li>
<li>Reclaining Seats (2 X 2)</li>
<li>Spacious leg space with foot rest</li>
<li>Hydraulic Retrader</li>
<li>Full Air Multi - Axle Suspension</li>
<li>Luxurious Interior </li>
<li>Fixed Glasses </li>
                    </ul>
                    </div>
                     <p><a href="Enquiryform.aspx?Type=car&Text=Volvo Multi Axle Coach : 53 Seater" class="commonbtn">Book now</a></p>
                     <%--<p><a href="javascript:void(0);" class="commonbtn">Book now</a></p>--%>
                </div>
            </div>
            
        
        </div>
        
   </div>
  
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    <asp:Panel ID="Panel3" runat="server" class="PopUp" BackColor="White" BorderWidth="1"
        BorderColor="Red" Style="display: none; padding: 20px;" Width="951px">

        <div style="float: right; margin-right: -30px; margin-top: -30px;">
            <asp:ImageButton runat="server" ID="lnkClose" ImageUrl="Assets/images/facebox/closelabel.png" /></div>
        <div class="hPP">
            <div class="tPD top0">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td height="30">
                            <input id="Radio1" type="radio" onclick="changeBank(this.value,'Allahabad Bank');"
                                name="rbPayOpt" value="280" />
                            <img src="Assets/images/allahabadbank.jpg" alt="Allahabad Bank" border="0" style="vertical-align: top"  loading="lazy" />
                            Allahabad Bank
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle;">
                                <input id="Radio2" type="radio" onclick="changeBank(this.value,'AXIS Bank');" name="rbPayOpt"
                                    value="50" />
                                <img src="Assets/images/axis_bank.gif" alt="AXIS Bank" border="0" style="vertical-align: top"  loading="lazy" />
                                AXIS Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb19" type="radio" onclick="changeBank(this.value,'Bank of Bahrain and Kuwait');"
                                    name="rbPayOpt" value="340" />
                                <img src="Assets/images/Bank-of-Bahrain-and-Kuwait.jpg" alt="Bank of Bahrain and Kuwait"
                                    border="0" style="vertical-align: top"   loading="lazy" />
                                Bank of Bahrain and Kuwait</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle;">
                                <input id="Radio3" type="radio" onclick="changeBank(this.value,'Bank of Baroda');"
                                    name="rbPayOpt" value="310" />
                                <img src="Assets/images/bob.jpg" alt="Bank of Baroda" border="0" style="vertical-align: middle"   loading="lazy"/>
                                Bank of Baroda</div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio4" type="radio" onclick="changeBank(this.value,'Bank of India');"
                                    name="rbPayOpt" value="240" />
                                <img src="Assets/images/bank_ofindia.gif" alt="Bank of India" border="0" style="vertical-align: top"  loading="lazy" />
                                Bank of India
                            </div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio11" type="radio" onclick="changeBank(this.value,'Bank of Maharashtra');"
                                    name="rbPayOpt" value="750" />
                                <img src="Assets/images/Bank-of-Maharashtra.jpg" alt="Bank of Maharashtra" width="70px"
                                    height="24px" border="0" style="vertical-align: top"   loading="lazy"/>
                                Bank of Maharashtra
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""   loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio5" type="radio" onclick="changeBank(this.value,'Beam Cash Card');"
                                    name="rbPayOpt" value="320" />
                                <img src="Assets/images/beam-cash-card.jpg" alt="Beam Cash Card" border="0" style="vertical-align: middle"   loading="lazy"/>
                                Beam Cash Card
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio6" type="radio" onclick="changeBank(this.value,'Central Bank of India');"
                                    name="rbPayOpt" value="740" />
                                <img src="Assets/images/Central-Bank-Of-India.jpg" alt="Central Bank of India" border="0"
                                    style="vertical-align: middle"   loading="lazy"/>
                                Central Bank of India
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb24" type="radio" onclick="changeBank(this.value,'Citi Bank');" name="rbPayOpt"
                                    value="230" />
                                <img src="Assets/images/Citi-Bank.jpg" alt="Citi Bank" border="0" style="vertical-align: middle"   loading="lazy" />
                                Citi Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio12" type="radio" onclick="changeBank(this.value,'City Union Bank');"
                                    name="rbPayOpt" value="440" />
                                <img src="Assets/images/City_Union_Bank.jpg" alt="City Union Bank" border="0" style="vertical-align: middle"   loading="lazy"/>
                                City Union Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio25" type="radio" onclick="changeBank(this.value,'Canara Bank');"
                                    name="rbPayOpt" value="930" />
                                <img src="Assets/images/Canarabank_Logo.gif" alt="Canara Bank" border="0" style="vertical-align: middle"
                                    height="24" width="70"  loading="lazy" />
                                Canara Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio5" type="radio" onclick="changeBank(this.value,'Catholic Syrian Bank');"
                                    name="rbPayOpt" value="1130" />
                                <img src="Assets/images/csb.jpg" alt="Catholic Syrian Bank" border="0" style="vertical-align: middle"
                                    height="24" width="70"  loading="lazy" />
                                Catholic Syrian Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""   loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb17" type="radio" onclick="changeBank(this.value,'Deutsche Bank');" name="rbPayOpt"
                                    value="330" />
                                <img src="Assets/images/Deutsche-Bank.jpg" alt="Deutsche Bank" border="0" style="vertical-align: middle"   loading="lazy"/>
                                Deutsche Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio13" type="radio" onclick="changeBank(this.value,'Development Credit Bank');"
                                    name="rbPayOpt" value="540" />
                                <img src="Assets/images/Development_Credit_Bank.jpg" alt="Development Credit Bank" border="0"
                                    style="vertical-align: middle"   loading="lazy"/>
                                Development Credit Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb18" type="radio" onclick="changeBank(this.value,'Dhanlaxmi Bank');"
                                    name="rbPayOpt" value="370" />
                                <img src="Assets/images/Dhanlaxmi-Bank.jpg" alt="Dhanlaxmi Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                Dhanlaxmi Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio7" type="radio" onclick="changeBank(this.value,'Federal Bank');"
                                    name="rbPayOpt" value="270" />
                                <img src="Assets/images/fbllogo.jpg" alt="Federal Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                Federal Bank
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio8" type="radio" onclick="changeBank(this.value,'Hdfc Net Banking');"
                                    name="rbPayOpt" value="300" />
                                <img src="Assets/images/hdfcbank.jpg" alt="Hdfc Net Banking" border="0" style="vertical-align: middle"  loading="lazy" />
                                Hdfc Net Banking</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio14" type="radio" onclick="changeBank(this.value,'I-Cash Card');"
                                    name="rbPayOpt" value="460" checked="CHECKED" />
                                <img src="Assets/images/ICashCard.jpg" alt="I-Cash Card" border="0" style="vertical-align: middle"  loading="lazy" />
                                I-Cash Card</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio9" type="radio" onclick="changeBank(this.value,'ICICI Bank');" name="rbPayOpt"
                                    value="10" checked="CHECKED" />
                                <img src="Assets/images/icici_bank.gif" alt="ICICI Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                ICICI Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb25" type="radio" onclick="changeBank(this.value,'IDBI Bank');" name="rbPayOpt"
                                    value="520" />
                                <img src="Assets/images/IDBI-Bank.jpg" alt="IDBI Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                IDBI Bank
                            </div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio15" type="radio" onclick="changeBank(this.value,'Indian Bank');"
                                    name="rbPayOpt" value="490" />
                                <img src="Assets/images/Indian_Bank.jpg" alt="Indian Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                Indian Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio16" type="radio" onclick="changeBank(this.value,'Indian Overseas Bank');"
                                    name="rbPayOpt" value="420" />
                                <img src="Assets/images/Indian-Overseas-Bank.jpg" alt="Indian Overseas Bank" border="0"
                                    style="vertical-align: middle"  loading="lazy" />
                                Indian Overseas Bank</div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio17" type="radio" onclick="changeBank(this.value,'ING Vysya Bank');"
                                    name="rbPayOpt" value="830" />
                                <img src="Assets/images/ING-Vysya.jpg" alt="ING Vysya Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                ING Vysya Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio10" type="radio" onclick="changeBank(this.value,'J&amp;K Bank');"
                                    name="rbPayOpt" value="350" />
                                <img src="Assets/images/J-and-K-Bank.jpg" alt="J&amp;K Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                J&amp;K Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio24" type="radio" onclick="changeBank(this.value,'Kotak Mahindra bank');"
                                    name="rbPayOpt" value="910" />
                                <img src="Assets/images/Kotak_Logo.gif" alt="Kotak Mahindra bank" border="0" style="vertical-align: middle"
                                    height="24" width="70"  loading="lazy" />
                                Kotak Mahindra bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb20" type="radio" onclick="changeBank(this.value,'Karnataka Bank');"
                                    name="rbPayOpt" value="140" />
                                <img src="Assets/images/Karnataka-Bank.jpg" alt="Karnataka Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                Karnataka Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio18" type="radio" onclick="changeBank(this.value,'Karur Vysya Bank');"
                                    name="rbPayOpt" value="760" />
                                <img src="Assets/images/Karur_Vysya_Bank.jpg" alt="Karur Vysya Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                Karur Vysya Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""   loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb12" type="radio" onclick="changeBank(this.value,'Oriental Bank Of Commerce');"
                                    name="rbPayOpt" value="160" />
                                <img src="Assets/images/orintal_bank.gif" alt="Oriental Bank Of Commerce" border="0" style="vertical-align: middle"  loading="lazy" />Oriental
                                Bank Of Commerce</div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="rb14" type="radio" onclick="changeBank(this.value,'Punjab National Bank');"
                                    name="rbPayOpt" value="1220" />
                                <img src="Assets/images/PNB.JPG" alt="Punjab National Bank" border="0" style="vertical-align: middle"
                                    height="24" width="70"  loading="lazy" />
                                Punjab National Bank
                            </div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio28" type="radio" onclick="changeBank(this.value,'South Indian Bank');"
                                    name="rbPayOpt" value="180" />
                                <img src="Assets/images/south_indian_bank.gif" alt="South Indian Bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                South Indian Bank
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb21" type="radio" onclick="changeBank(this.value,'Standard Chartered Bank');"
                                    name="rbPayOpt" value="450" />
                                <img src="Assets/images/Standard-Chartered-Bank.jpg" alt="Standard Chartered Bank" border="0"
                                    style="vertical-align: middle"  loading="lazy" />
                                Standard Chartered Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio19" type="radio" onclick="changeBank(this.value,'State Bank of Hyderabad');"
                                    name="rbPayOpt" value="560" />
                                <img src="Assets/images/State_Bank_of_Hyderabad.jpg" alt="State Bank of Hyderabad" border="0"
                                    style="vertical-align: middle"  loading="lazy" />
                                State Bank of Hyderabad
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb26" type="radio" onclick="changeBank(this.value,'State Bank of India');"
                                    name="rbPayOpt" value="530" />
                                <img src="Assets/images/sbi_logo_main.gif" alt="State Bank of India" border="0" style="vertical-align: middle"  loading="lazy" />
                                State Bank of India
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio26" type="radio" onclick="changeBank(this.value,'State Bank Of Bikaner and Jaipur');"
                                    name="rbPayOpt" value="950" />
                                <img src="Assets/images/State Bank of Bikaner.jpg" alt="State Bank Of Bikaner and Jaipur"
                                    border="0" style="vertical-align: middle" width="70" width="24"  loading="lazy" />
                                State Bank Of Bikaner and Jaipur
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio27" type="radio" onclick="changeBank(this.value,'State Bank of Patiala');"
                                    name="rbPayOpt" value="880" />
                                <img src="Assets/images/State Bank of patiala.jpg" alt="State Bank of Patiala" border="0"
                                    style="vertical-align: middle" width="70" width="24"  loading="lazy" />
                                State Bank of Patiala
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio20" type="radio" onclick="changeBank(this.value,'State Bank of Mysore');"
                                    name="rbPayOpt" value="550" />
                                <img src="Assets/images/State_Bank_of_Mysore.jpg" alt="State Bank of Mysore" border="0"
                                    style="vertical-align: middle"  loading="lazy" />
                                State Bank of Mysore
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio22" type="radio" onclick="changeBank(this.value,'State Bank of Travencore');"
                                    name="rbPayOpt" value="680" />
                                <img src="Assets/images/State-Bank-of-Travencore.png" alt="State Bank of Travencore" width="70px"
                                    height="24px" border="0" style="vertical-align: middle"  loading="lazy" />
                                State Bank of Travencore</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio21" type="radio" onclick="changeBank(this.value,'Tamilnad Mercantile Bank');"
                                    name="rbPayOpt" value="620" />
                                <img src="Assets/images/Tamilnad_Mercantile_Bank.jpg" alt="Tamilnad Mercantile Bank" border="0"
                                    style="vertical-align: middle"  loading="lazy" />
                                Tamilnad Mercantile Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb23" type="radio" onclick="changeBank(this.value,'Union Bank of India');"
                                    name="rbPayOpt" value="190" />
                                <img src="Assets/images/Union-Bank-of-India.jpg" alt="Union Bank of India" border="0" style="vertical-align: middle"  loading="lazy" />
                                Union Bank of India</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb15" type="radio" onclick="changeBank(this.value,'United Bank of India');"
                                    name="rbPayOpt" value="570" />
                                <img src="Assets/images/United-Bank-of-India.jpg" alt="United Bank of India" border="0"
                                    style="vertical-align: middle"  loading="lazy" />
                                United Bank of India</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio23" type="radio" onclick="changeBank(this.value,'Vijaya bank');"
                                    name="rbPayOpt" value="200" />
                                <img src="Assets/images/vijayabank.gif" alt="Vijaya bank" border="0" style="vertical-align: middle"  loading="lazy" />
                                Vijaya Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio30" type="radio" onclick="changeBank(this.value,'Visa Master Maestro Credit Card Gateway');"
                                    name="rbPayOpt" value="820" />
                                <img src="Assets/images/sbi_logo_main.gif" alt="Visa Master Maestro Credit Card Gateway"
                                    border="0" style="vertical-align: middle"  loading="lazy" />
                                Visa Master Maestro Credit Card Gateway</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio29" type="radio" onclick="changeBank(this.value,'Visa Master Maestro Debit Card Gateway');"
                                    name="rbPayOpt" value="1180" />
                                <img src="Assets/images/sbi_logo_main.gif" alt="Visa Master Maestro Debit Card Gateway"
                                    border="0" style="vertical-align: middle"  loading="lazy" />
                                Visa Master Maestro Debit Card Gateway</div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%--</div>--%>
    </asp:Panel>
    <script type="text/javascript">
	    $(document).ready(function($) {
    	  
		  //top close
		  $('.topclose').click(function(e){
			  $('.topnote').slideUp();
			  e.preventDefault();
			  });
		  
		  // datepicker
		   	$('.txtdate').datepicker();
			$('.txtdate').on('change', function () {
        			$('.datepicker').hide();
			});
		  
		  // carousel
		  $("#hp-heroslider").owlCarousel({
			    items : 1
		  });
		  
		  $("#fd-slider").owlCarousel({
			    items : 1,
				pagination : false,
				// Navigation
				navigation : true,
				navigationText : ["<i class='fa fa-chevron-left'></i>","<i class='fa fa-chevron-right'></i>"],
				rewindNav : true,
				scrollPerPage : false,
		  });
		  
		  $("#mice-slider").owlCarousel({
			    items : 1,
				pagination : false,
				// Navigation
				navigation : true,
				navigationText : ["<img src='Assets/images/arrow-prev.png'>","<img src='Assets/images/arrow-next.png'>"],
				rewindNav : true,
				scrollPerPage : false,
				autoplay:true,
				autoplayTimeout:1000,
				autoplayHoverPause:true
		  });
		  
		  
	    });
    </script>
    <script>
        $('select').selectpicker({
            style: 'btn-info',
            size: 4
        });

    </script>
    </form>
    <script language="javascript" type="text/javascript">
        function changeBank(t) {
            document.getElementById('CSTBANKID').value = t;
        }
        x = 20;
        y = 70;
        function placeIt(obj) {
            obj = document.getElementById(obj);
            if (document.documentElement) {
                theLeft = document.documentElement.scrollLeft;
                theTop = document.documentElement.scrollTop;
            }
            else if (document.body) {
                theLeft = document.body.scrollLeft;
                theTop = document.body.scrollTop;
            }
            theLeft += x;
            theTop += y;
            obj.style.left = theLeft + 'px';
            obj.style.top = theTop + 'px';
            setTimeout("placeIt('light')", 500);
        }                              
    </script>
    <!--<script src="js/jquery-2.2.0.min.js"></script> 
<script src="js/bootstrap.min.js"></script> 
-->
    <script>
        $('select').selectpicker();

    </script>
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
    <!-- Moment.js -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.8.2/moment.min.js"></script>

    <!-- FullCalendar 2.1.1 -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/2.1.1/fullcalendar.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-modal/2.2.6/js/bootstrap-modal.min.js"></script>
    <script>

        $(document).ready(function () {
            $.getScript('https://arshaw.com/js/fullcalendar-1.6.4/fullcalendar/fullcalendar.min.js', function () {
                var date = new Date();
                var d = date.getDate();
                var m = date.getMonth();
                var y = date.getFullYear();

                $('#calendar').fullCalendar({
                    header: {
                        left: 'prev,next today',
                        center: 'title',
                        right: 'month,agendaWeek,agendaDay'
                    },
                    editable: true,
                    events: [
                        {
                            title: 'All Day Event',
                            start: new Date(y, m, 1)
                        },
                        {
                            title: 'Long Event',
                            start: new Date(y, m, d - 5),
                            end: new Date(y, m, d - 2)
                        },
                        {
                            id: 999,
                            title: 'Repeating Event',
                            start: new Date(y, m, d - 3, 16, 0),
                            allDay: false
                        },
                        {
                            id: 999,
                            title: 'Repeating Event',
                            start: new Date(y, m, d + 4, 16, 0),
                            allDay: false
                        },
                        {
                            title: 'Meeting',
                            start: new Date(y, m, d, 10, 30),
                            allDay: false
                        },
                        {
                            title: 'Lunch',
                            start: new Date(y, m, d, 12, 0),
                            end: new Date(y, m, d, 14, 0),
                            allDay: false
                        },
                        {
                            title: 'Birthday Party',
                            start: new Date(y, m, d + 1, 19, 0),
                            end: new Date(y, m, d + 1, 22, 30),
                            allDay: false
                        },
                        {
                            title: 'Click for Google',
                            start: new Date(y, m, 28),
                            end: new Date(y, m, 29),
                            url: 'http://google.com/'
                        }
                    ]
                });
            });
        });

    </script>
    <script type="text/javascript">
        setTimeout(function () {
            var a = document.createElement("script");
            var b = document.getElementsByTagName('script')[0];
            a.src = document.location.protocol + "//dnn506yrbagrg.cloudfront.net/pages/scripts/0011/9178.js?" + Math.floor(new Date().getTime() / 3600000);
            a.async = true; a.type = "text/javascript"; b.parentNode.insertBefore(a, b)
        }, 1);
    </script>
</body>
</html>

