<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="company-profile.aspx.cs" Inherits="SouthernTravelsWeb.company_profile" %>


<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcQuickSearch.ascx" TagPrefix="uc" TagName="QuickSearch" %>
<%@ Register Src="UserControl/UcEntityImgSlider.ascx" TagPrefix="uc" TagName="ImgSlider" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>About Us : Southern Travels</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <meta content="Southern Travels, a travel agency in India offering tour & travel packages that covers various adventures heritage destination in India at very low prices."
        name="Description" />
    <meta content="Heritage Tour to India, adventure tours in India, travel agents India, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, "
        name="Keywords" />
    <meta content="index,follow" name="robots" />
    <meta content="Designed  www.Sirez.com" name="Author" />
    <meta content="MSHTML 6.00.2900.2180" name="GENERATOR" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1" />
    <meta name="vs_defaultClientscript" content="Javascript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
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
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-fixed-tour-detail.jpg)">
    <div class="herobanner">
  <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="AGENT_LOGIN"  /></div>
 </header>
    <section class="innersection2">
  
    <div id="fixedtabsection">
    <div class="container">
      <div class="row subheadrow">
        <div class="col-md-12">
          <h1 class="title"> <span>About</span> Us </h1>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="tabsection_inner">
            <ul class="nav nav-tabs">
             
               <li id="aCompany" runat="server"><a href="#tab_company" data-toggle="tab" >Company</a></li>
             
             
                <li id="aCSR" runat="server"><a href="#tab_csr" data-toggle="tab" >CSR</a></li>
             
                <li id="aAward" runat="server"><a href="#tab_awards" data-toggle="tab" >Award & Accolades</a></li>
              
              
              <li id="aBoard" runat="server"><a href="#tab_bod" data-toggle="tab" >Board of Directors</a></li>
              <li id="aTeam" runat="server"><a href="#tab_team" data-toggle="tab" >Team</a></li>
              
                <li id="aTest" runat="server"><a href="#tab_Offices" data-toggle="tab" >Our Offices</a></li>
              
              
            </ul>
          </div>
        </div>
      </div>
      </div>
    </div>
    <div class="container-fluid">
    <div class="row tabspace">
      <div class="col-md-12">
        <div class="tab-content tab-content-inner"> 
          
          <!-- company -->
          <div class="tab-pane" id="tab_company" runat="server">
          <div class="container">
              <div class="row rowgap">
                <div class="col-md-12">
                  <p>Southern Travels is synonymous with an undoubted assurance and absolute ease to travel. Established in 1970, Southern Travels offers world-class, hassle-free holidaying in India. With a varied experience of over four decades in the tourism industry, the company takes care of all your travel needs, thereby giving you the bliss of enjoying travel at any given point. </p>
                </div>
              </div>
              <div class="aboutus">
                <div class="row">
                  <div class="col-md-2">
                    <div class="vision"> <img src="Assets/images/about/vision.jpg" class="img-responsive" loading="lazy" alt="vision"/> </div>
                  </div>
                  <div class="col-md-10">
                    <div class="vision">
                      <h3><span>The Vision</span></h3>
                      <p>To make you Travel Dream a long-cherished sweet memory by assisting with peerless quality and matchless services</p>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-2">
                    <div class="vision"> <img src="Assets/images/about/mission.jpg" class="img-responsive"  loading="lazy" alt="mission"/> </div>
                  </div>
                  <div class="col-md-10">
                    <div class="vision">
                      <h3><span>Mission</span></h3>
                      <p>Pure-in-action commitment to all the Travel needs, assured value-added services and close monitoring at every step, to ensure delightful Travel with absolute safety and personal touch . </p>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-2">
                    <div class="vision"> <img src="Assets/images/about/approach.jpg" class="img-responsive" loading="lazy" alt="approach"/> </div>
                  </div>
                  <div class="col-md-10">
                    <div class="vision">
                      <h3><span>Approach</span></h3>
                      <p>Honesty and transparency are two focal points, on which all our relationships with customers have been built upon year after year. At Southern Travels, a promise is a promise. Apart from quality, you are firmly assured of no hidden charges. Customer delight and maintenance of good will are much more foremost to us, than profits. </p>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-2">
                    <div class="vision"> <img src="Assets/images/about/comfort.jpg" class="img-responsive" loading="lazy" alt="comfort"/> </div>
                  </div>
                  <div class="col-md-10">
                    <div class="vision">
                      <h3><span>Comfort & Safety</span></h3>
                      <p>With over four decades of service to our clients, Southern Travels has built an excellent reputation for flawless safety, total comfort, friendly approach and efficient services. Our attitude to the safety of our valued clients is uncompromising. We maintain the highest standards of reliability and safety, which our clients relish and would love to have. </p>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-2">
                    <div class="vision"> <img src="Assets/images/about/convenience.jpg" class="img-responsive" loading="lazy"  alt="convenience"/> </div>
                  </div>
                  <div class="col-md-10">
                    <div class="vision">
                      <h3><span>Convenience</span></h3>
                      <p>Individual Tailor-made Packages are exclusive from Southern Travels. Tour itineraries have been perfected to meet the special needs of travelers. Southern Travels provides services individually and personally, as per your own choice of places and visits thereof. Right from ticket booking for traveling, whether it is accommodation, or sightseeing or any other aspect, we take every care and ensure a safe, secure and happy return with utmost satisfaction, back to Southern Travels, thereby tangibly proving our exclusivity in everything. </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <section class="services">
              <div class="container-fluid">
                <div class="container">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="ourservices">
                        <h2 class="title text-center mrgntopno">Our <span>Services</span></h2>
                        <p>We are pioneers in the travel business for the last 46 years. We have a fleet of 50 coaches/ cars of our own, with a network of offices at New Delhi, Mumbai, Chennai, Bengaluru, 	Hyderabad, Visakhapatnam and Vijayawada. Our Indian restaurant is functioning at Durban South Africa. We also own Hotel Southern at New Delhi equipped with 100 available Rooms.</p>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-3">
                      <div class="service"> <img src="Assets/images/about/services.jpg" class="img-responsive" loading="lazy" alt="services"/> </div>
                    </div>
                    <div class="col-md-9">
                      <div class="ourservices">
                        <h3 class="title">Our <span>Services are:</span></h3>
                      </div>
                      <div class="commonlist">
                        <ul>
                          <li>International/ domestic air ticketing</li>
                          <li>Railway Reservation</li>
                          <li>24-hour Airlines Reservation Counter (Jet, Sahara & Indian Airlines)</li>
                          <li>Package tours all over India</li>
                          <li>Hotel reservations all over India</li>
                          <li>Airport transfers</li>
                          <li>Tailor-made tours for Individuals, Groups, Students, Corporate, Business tours</li>
                          <li>Car/ Coach Rentals (Budget & Luxury)</li>
                          <li>Hotel Southern at New Delhi equipped with 100 rooms is of ours.</li>
                        </ul>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <div class="servicesline">
                        <h3 class="title">Friendly <span>Staff:</span></h3>
                        <p>All our staff are friendly, well qualified and are well conversant with many of the languages which includes English, Telugu, Kannada, Tamil, Malayalam & Hindi.</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </section>
            <section class="company">
              <div class="container">
                <div class="row">
                  <div class="col-md-6">
                    <div class="servicesline">
                      <div class="servicehd">
                        <h3 class="title">The background Of the <span>Company:-</span></h3>
                        <p>Southern Travels was a Partnership Firm since 1970. It became a Private Limited Company in 1995. Our Chairman, Shri A.V. Rao, was holding some of the important positions:-</p>
                      </div>
                      <div class="commonlist rowgap">
                        <ul>
                          <li>Chairman - Andhra Pradesh Tourism Development Corporation ( A State Government Undertaking)</li>
                          <li>Chairman - Sri Venkateswara College ( New Delhi )</li>
                          <li>Member - Tourism Promotion Board of Andhra Pradesh Government</li>
                          <li>Director of Vysya Bank ( Bengaluru)</li>
                          <li>Member - National Film Censor Board</li>
                          <li>Member of Tirumala Tirupati Devasthanams Board ( TTD ) Tirupati</li>
                          <li> Vice President - All India Vaish Federation, New Delhi.</li>
                        </ul>
                      </div>
                      <div>
                        <p>Our management consists of Shri A.V. Rao, Chairman ( M.A. ), Shri A. Krishna Mohan, Managing Director (MBA, from Loyola College, Chennai) and Shri A. Venkata Praveen Kumar, Joint Managing Director (MBA from New College, Chennai). These professionally qualified young executives are on the Board of Directors of our company and are assisted by experienced professional / General Managers </p>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6">
                    <div class="graybrdrbox mrgnbtm20">
                      <h3 class="title">Hotel at <span>Vijayawada</span></h3>
                      <p>We have recently inaugurated a 3 Star Facility Hotel at the heart of Vijayawada, Andhra Pradesh, consisting of Guest Rooms, Pure Vegetarian South Indian Restaurant, Banquet / Conference Hall. </p>
                    </div>
                    <div class="graybrdrbox mrgnbtm20">
                      <h3 class="title">Future <span> Plans</span></h3>
                      <p> In the coming 3-5 years, we are going to open Hotels/Resorts at Vishakapatnam, Goa, Hyderabad and Manali. Our offices are also going to get opened shortly in Madurai, Cochin, Bhuvneshwar, Nellore and Kolkata. </p>
                    </div>
                    <div class="member">
                      <h3><span>Member</span></h3>
                      <div class="commonlist">
                        <ul>
                          <li>Indian Association Of Tour Operators</li>
                          <li>All India Motor Transport Congress</li>
                          <li>All India Management Association.</li>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </section>
          </div>
          <!-- end company --> 
          
           <!-- csr -->
          <div class="tab-pane" id="tab_csr" runat="server"> 
            <!-- csr -->
            <div class="socialservice">
              <div class="container">
                <div class="row rowgap">
                  <div class="col-md-12">
                    <div class="servicesline text-center">
                      <h2 class="title">Social <span>Service</span></h2>
                    </div>
                  </div>
                </div>

                <div class="row rowgap">
                  <div class="col-md-3">
                    <div class="social"> <img src="Assets/images/about/KerlaChiefMinistersDistressReliefFund.jpg" class="img-responsive" style="max-width: 93%;" loading="lazy" alt="KerlaChiefMinistersDistressReliefFund"/> </div>
                  </div>
                  <div class="col-md-9">
                    <div class="row">
                    
                    
                      <div class="socialserv">
                      
                      
                      
                      
                      
                         <p>Alone we can do so little, together we can do so much.</p>
                        <ul>
                            <li>The Management & Staff of Southern Travels Pvt Ltd and Southern Grand Hotels Pvt. Ltd. Donated Rs. 5 Lakhs towards �Kerala Chief Minister�s Distress Relief Fund� towards the relief for Kerala flood victims.</li>
                            <li>The amount was handed over by our Managing Director, Shri Alapati Krishna Mohan to Mr. Puneet Kumar, IAS, Resident Commissioner, Kerala House on Aug 27, 2018.</li>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="row rowgap">
                  <div class="col-md-3">
                    <div class="social"> <img src="Assets/images/about/socialservice.jpg" class="img-responsive" loading="lazy" alt="socialservice"/> </div>
                  </div>
                  <div class="col-md-9">
                    <div class="row">
                    
                    
                      <div class="socialserv">
                      
                      
                      
                      
                      
                        <p>As a responsible company, We understand our responsibility of Corporate Social Responsibility. SOUTHERN TRAVELS has contributed voluntarily on various occasions of Natural Disasters, Accidents and scholarships. Few are...</p>
                        <ul>
                            <li>Contributed to Chief Minister's Relief fund for the Hudhud Cyclone in Andhra Pradesh in 2014.</li>
                            <li>Provided free transportation for the effected people for the accident at Beas River in Himachal Pradesh, where 24 students died in 2014.</li>
                            <li>Contributed to Prime Minister's Relief Fund for Uttarakhand Floods in 2013 and provided Accommodation, food and transportation for hundreds of effected persons for free.</li>
                            <li>Contributed to Prime Minister's Fund for Tsunami in 2004.</li>
                            <li>Contributed to Chief Minister's Relief Fund for Floods and heavy rains in Andhra Pradesh in October 2009.</li>
                            <li>We have been giving Scholarships to the Meritorious Students for the last 20 years.</li>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>
                
                  <div class="row">
                  <div class="col-md-3">
                    <div class="social"> <img alt="plantatree"  src="Assets/images/about/plantatree.jpg" class="img-responsive" loading="lazy"/> </div>
                  </div>
                  <div class="col-md-9">
                    <div class="row">
                    
                    
                      <div class="socialserv">
                      <h3 class="title">Plant a Tree</h3>
                      <p>The Eco Line, our "Plant a Tree" program rises against deforestation and climate change through encouraging people for planting more and more trees. With distributing seeds of different plants, we aim to raise awareness of global environmental issues for better environmental practices.</p>
<p>At Southern Travels, we believe that the earth and all life on it deserve a clean and safe environment, now and in the future. Our Plant a Tree Program is nurtured by dream of stopping climate change, sustainable agriculture, preserving the oceans and preventing another nuclear catastrophe. Come and collect seeds from our Office counters for pricking out the saplings to support a worthwhile cause. No matter how you participate, you will be changing the future of our planet. </p>
                      </div>
                    </div>
                  </div>
                </div>
                
              </div>
            </div>
            
            <!-- end csr --> 
            
          </div>
          <!-- end csr --> 
          
          <!--awards -->
          <div class="tab-pane" id="tab_awards" runat="server">
            <div class="awards">
              <div class="container">
                <div class="row rowgap">
                
                 <div class="col-md-1">
                    	 <img alt="awards"  src="Assets/images/about/awards.jpg" class="img-responsive imagebrdr8px award-pic" loading="lazy"/>
                    </div>
                
                  <div class="col-md-11">
                    <div class="">
                      <h2 class="title">Winners of National Tourism Award as the Best Domestic Tour Operator for <span>8 <br>
                        Consecutive Years (2008 to 2015)</span></h2>
                     </div>
                    </div>
                    </div>
                  
                  
                  <div class="row rowgap">
                    <div class="col-md-12 text-center">
                     <div class="posrel">  
                     <span class="customtag2">2015 <img alt="custom"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>  
                      <img alt="award_2015"  src="Assets/images/about/award_2015.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                      
                      <div>
                      <p>We won National Tourism Award consecutively for the 8th time from the Ministry of Tourism, Govt. of India, as 
the "BEST DOMESTIC TOUR OPERATOR" on 18th September 2015. The Award was presented by His 
Excellency Shri Pranab Mukherjee, President of India. The Award was received by Shri A. Krishna Mohan - 
Managing Director and Shri A. V. Praveen Kumar - Joint Managing Director<br>
<a href="#videoModal" data-toggle="modal">Watch Video <i class="fa fa-video-camera"></i></a>
</p>
                      </div>
                      
                    </div>
                  </div>
                  
                    <div class="row rowgap">
                    
                  <div class="col-md-6 text-center">
                     <div class="posrel">    
                     <span class="customtag2">2015 <img alt="custom"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                      <img alt="award_2015_2"  src="Assets/images/about/award_2015_2.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                        <div>
                      <p>Won "BEST TOUR OPERATOR" Award for Tourism Excellence by 
Department of Tourism. Govt. of Telangana on 27th September, 2015. 
The Award was presented by Shri Kalvakuntla Taraka Rama Rao, 
Hon'ble Minister for Panchayat Raj & Information Technology.</p>
                      </div>
                      
                    </div>
                    
                  <div class="col-md-6 text-center"> 
                  <div class="posrel">
                  <span class="customtag2">2014 <img alt="arrow"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                  <img alt="award_2014"  src="Assets/images/about/award_2014.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                  </div>
                    <div class="awardspara">
                      <p>We won the National Tourism Award continuously for the 
7th year from the Ministry of Tourism, Government 
of India as the "BEST DOMESTIC TOUR. OPERATOR" 
securing the Second position on the 18th 
February 2014. The Award was presented to us by 
Shri Shashi Thereat., Minister for Human Resources 
Development, on behalf of the President of India. The 
award was received by Shri A. Venkateswara Rao, 
Chairman and Shri A. Krishna Mohan, Managing 
Director</p>
                    </div>
                  </div>
                    

                    
                  </div>
                
                <div class="row">

                
                  
                  
                  <div class="col-md-6 text-center"> 
                  <div class="posrel">
                  <span class="customtag2">2013 <img alt="custom-arrow"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                  <img alt="award_2013"  src="Assets/images/about/award_2013.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                    <div class="awardspara">
                      <p>We won National Tourism Award consecutively for the 
6th time from the Ministry of Tourism, Govt. of India, as 
the "BEST DOMESTIC TOUR OPERATOR" securing the 
FIRST position on 18th March, 2013. The Award was 
presented by His Excellency Shri Pranab Mukherjee, 
President of India, presided over by Dr. K. Chiranjeevi, 
Hon'ble Minister of State for Tourism (IC) Govt. of India. 
The Award was received by Shri A. Venkateswara Rao - 
Chairman and Shri A. Krishna Mohan - Managing 
Director.</p>
                    </div>
                  </div>
                  <div class="col-md-6 text-center"> 
                  
                   <div class="posrel">
                  <span class="customtag2">2013 <img alt="custom-arrow."  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                  <img alt="award_2013_2"  src="Assets/images/about/award_2013_2.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                    <div class="awardspara">
                      <p>We won National Tourism Award from the Ministry of 
Tourism, Govt. of India, as the "Best Tour Operator for 
Promoting North East India including Sikkim" at a 
function held at Vigyan Bhavan on 18th March, 2013. 
The Award was presented by His Excellency Shri 
Pranab Mukherjee, President of India, presided over by 
Dr. K. Chiranjeevi, Hon'ble Minister of State for Tourism 
(IC) Govt. of India. The Award was received by Shri 
A.Krishna Mohan - Managing Director and 
Shri A. V. Praveen Kumar - Joint Managing Director.</p>
                    </div>
                  
                  
                  </div>
                </div>
                <div class="row">
                  
                  <div class="col-md-6 text-center"> 
                  
                   <div class="posrel">
                  <span class="customtag2">2012 <img alt="custom-arrow"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                  <img alt="award_2012"  src="Assets/images/about/award_2012.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                    <div class="awardspara">
                      <p>
                      We won National Tourism Award for the consecutive time from Ministry of Tourism, Government of India, at a function held at Vigyan Bhavan on 29th February, 2012. The award was presented by Hon'ble President of India,
Smt Pratibha Devi Singh Patil as Chief Guest. The
function Presided over by Mr. Subodh Kant Sahai, 
Hon'ble Minister for Tourism. The Award was received
by Shri A. Venkateswara Rao - Chairman & Shri A.V.
Praveen Kumar - Joint Managing Director.
                      </p>
                    </div>
                  
                 
                  </div>
                  <div class="col-md-6 text-center"> 
                  
                  
                    <div class="posrel">
                  <span class="customtag2">2011 <img alt="custom-arrow"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                  <img alt="award_2011"  src="Assets/images/about/award_2011.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                    <div class="awardspara">
                      <p>
                      	We won National Tourism Award for the fourth time from 
Ministry of Tourism, Government of India, at a function
held at Hotel Ashok on 28th March 2011. The Award was presented by Hon'ble Speaker of Lok Sabha, Smt Meira Kumar as Chief Guest and Ms Priyanka Chopra, Actor as Guest of Honour. The function Presided over by Mr Subodh Kant Sahai, Hon'ble Minister for Tourism. The Award was received by Shri A. Venkateswara Rao - Chairman, Shri A. Krishna Mohan - Managing Director &
Shri A.V. Praveen Kumar - Joint Managing Director.
                      </p>
                    </div>
                  
                  
                  </div>
                </div>
                <div class="row">
                  
                  <div class="col-md-6 text-center"> 
                  
                   <div class="posrel">
                  <span class="customtag2">2010 <img alt="custom-arrow"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                  <img alt="award_2010"  src="Assets/images/about/award_2010.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                    <div class="awardspara">
                      <p>Our company received National Tourism Award on 3-3-2010 at Vigyan Bhavan, New Delhi as the Best Domestic Tour Operator" securing the FIRST position from Ministry of Tourism,
Govt. of India. New Delhi. The Award was presented to us before a galaxy of important invited audience by Dr. Hamid Anson, Honourable Vice President of India. The function was presided over
by Kumari Selja, Minister for Tourism, Housing & Urban Poverty Alleviation, Govt. of India.</p>
                    </div>
                  
                  
                  </div>
                  <div class="col-md-6 text-center"> 
                  
                     <div class="posrel">
                  <span class="customtag2">2009 <img alt="custom-arrow"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                  <img alt="award_2009"  src="Assets/images/about/award_2009.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                    <div class="awardspara">
                      <p>Our company received National Tourism Award on 24-2-2009 at Hotel Ashok, New Delhi
as the 'Best Domestic Tour Operator" in India from Ministry of Tourism,
Govt. of India, New Delhi. The Award was presented to us before a galaxy of important invited audience
by Sri P. Chidambaram -
Hon'ble Minister for Home Affairs.
The function was presided over by Smt. Ambika Soni, Minister for Tourism & Culture, Govt. of India</p>
                    </div>
                  
                 
                  
                  
                
                  </div>
                </div>
                <div class="row">
                  
                  <div class="col-md-6 text-center"> 
                   <div class="posrel">
                  <span class="customtag2">2009 <img alt="custom-arrow"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                  <img alt="award_2009_2"  src="Assets/images/about/award_2009_2.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                    <div class="awardspara">
                      <p>Our company won the Excellency Award in Tourism (Travel Agent and Tour Operator) from the Department of Tourism, Govt. of Andhra Pradesh. The Award was presented by our Honourable Chief Minister, Dr. K. Rosaiah, in the presence of Dr. Geetha Reddy, Minister for Tourism on 27-0-2010.</p>
                    </div>
                  
                  
                  </div>
                  <div class="col-md-6 text-center"> 
                    <div class="posrel">
                  <span class="customtag2">2008 <img alt="custom-arrow"  src="Assets/images/custom-arrow.png" loading="lazy"/></span>
                  <img alt="award_2008"  src="Assets/images/about/award_2008.jpg" class="img-responsive imagebrdr8px" loading="lazy"/></div>
                    <div class="awardspara">
                      <p>Our company received National Tourism Award on 27-2-2008 at Vigyan Bhavan, New Delhi as the "Best Domestic Tour Operator" in India from Ministry of Tourism, Govt. of India, New Delhi. The Award was presented to us before a galaxy of important invited audience by Sri Pranab Mukherjee, Minister for External Affairs. The function was presided over by Smt.
Ambika Soni, Minister for Tourism & Culture, Govt. of India.</p>
                    </div>
                  </div>
                </div>
                
                
                
              </div>
            </div>
          </div>
          
          <!--end awards --> 
          
          <!-- board of directors -->
          <div class="tab-pane" id="tab_bod" runat="server">
            <div class="container">
              <div class="board">
                <div class="row">
                  <div class="col-md-12 text-center">
                    <img alt="directors"  src="Assets/images/about/directors.jpg" class="imagebrdr8px img-responsive displayinline" loading="lazy"/>
                  </div>
                 
                </div>
                <div class="row">
                  <div class="col-md-12">
                    <h2 class="title text-center"><span>Directors</span></h2>
                  </div>
                </div>
                <div class="row" id="bodcontainer">
                  <div class="col-md-3 text-center"> 
                  
             <!--     <a class="directorlink"> -->
                  <img alt="avrao"  src="Assets/images/about/avrao.jpg" class="imagebrdr8px" loading="lazy"/>
                    <div class="brdrdiv">
                    <h4>Mr. A.V. Rao</h4>
                   <p>Chairman  <%--(M.A.)--%></p>
                    </div>
                  
                    
                  </div>
                  <div class="col-md-3 text-center"> 
                  
                  <img alt="akmohan"  src="Assets/images/about/akmohan.jpg" class="imagebrdr8px" loading="lazy"/>
                     <div class="brdrdiv">
                    <h4>Mr. A. Krishna Mohan</h4>
                    <p>Managing Director </p>
                      </div>
                      <!-- </a> -->
                      
                      
                      
                  </div>
                  <div class="col-md-3 text-center"> 
                    <!--     <a class="directorlink"> -->
                  <img alt="director4"  src="Assets/images/about/director4.jpg" class="imagebrdr8px" loading="lazy"/>
                    <div class="brdrdiv">
                    <h4>Ms. Divya Alapati</h4>
                    <p>Director<br>
                      </p>
                      </div>
                      
                       
                      
                  </div>
                </div>
              </div>
            </div>
          </div>
          <!-- end board of directors --> 
       
          <!-- team -->
          <div class="tab-pane" id="tab_team" runat="server">
            <div class="container">
              <div class="team">
                <div class="row">
                  <div class="col-md-12">
                    <p>Our team strives for your satisfaction. Professionalism and warmth form the basis of all our interactions at all points. Most of our team members are well conversant with many Indian Languages.</p>
                    <h2 class="title">Meet Ours <span>Team</span></h2>
                  </div>
                </div>
                
                <div class="row">
                  <div class="teamwrap">
                    <div class="col-md-12"> <img alt="team"  src="Assets/images/about/team.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text-center">
                        <h3 class="title"><span>Southern Travels Team, New Delhi</span></h3>
                      </div>
                    </div>
                  </div>
                </div>
                
                <div class="row">
                  <div class="teamwrap">
                    <div class="col-md-6"> <img alt="hyderabad"  src="Assets/images/about/team-hyderabad.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text">
                        <h3 class="title"><span>Southern Travels Team, Hyderabad</span> </h3>
                        
                      </div>
                    </div>
                    <div class="col-md-6"><img alt="warangal"  src="Assets/images/about/team-warangal.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text">
                        <h3 class="title"><span>Southern Travels Team, Warangal</span> </h3>
                      
                      </div>
                    </div>
                  </div>
                </div>
                
                  <div class="row">
                  <div class="teamwrap">
                    <div class="col-md-6"> <img alt="rajahmundry"  src="Assets/images/about/team-rajahmundry.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text">
                        <h3 class="title"><span>Southern Travels Team, Rajahmundry</span> </h3>
                        
                      </div>
                    </div>
                    <div class="col-md-6"><img alt="kphb"  src="Assets/images/about/team-kphb-hyd.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text">
                        <h3 class="title"><span>Southern Travels Team Kakatpally (KPHB), Hyderabad</span> </h3>
                      
                      </div>
                    </div>
                  </div>
                </div>
                
                  <div class="row">
                  <div class="teamwrap">
                    <div class="col-md-6"> <img alt="chennai"  src="Assets/images/about/team-chennai.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text">
                        <h3 class="title"><span>Southern Travels Team, Chennai</span> </h3>
                        
                      </div>
                    </div>
                    <div class="col-md-6"><img alt="vizag"  src="Assets/images/about/team-vizag.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text">
                        <h3 class="title"><span>Southern Travels Team, Vizag</span> </h3>
                      
                      </div>
                    </div>
                  </div>
                </div>
                
                  <div class="row">
                  <div class="teamwrap">
                    <div class="col-md-6"> <img alt="coimatore"  src="Assets/images/about/team-coimatore.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text">
                        <h3 class="title"><span>Southern Travels Team, Coimbatore</span> </h3>
                        
                      </div>
                    </div>
                    <div class="col-md-6"><img alt="vijaywada"  src="Assets/images/about/team-vijaywada.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text">
                        <h3 class="title"><span>Southern Travels Team, Vijaywada</span> </h3>
                      
                      </div>
                    </div>
                  </div>
                </div>
                
                  <div class="row">
                  <div class="teamwrap">
                    <div class="col-md-6"> <img alt="bengaluru"  src="Assets/images/about/team-bengaluru.jpg" class="img-responsive imagebrdr8px" loading="lazy"/>
                      <div class="text">
                        <h3 class="title"><span>Southern Travels Team, Bengaluru</span> </h3>
                        
                      </div>
                    </div>
                  
                  </div>
                </div>
                
              </div>
            </div>
          </div>
          <!-- end team -->
          
          <!-- our branch Officess--->
          <div class="tab-pane" id="tab_Offices" runat="server">
            <div class="container contact-tabspace">
           <div  id="branch_offices" runat="server" >
            <div class="row">
            <div class="col-md-12">
            <h2 class="title">Branches in <span>India</span></h2>
            </div>
            </div>
           <div class="row">
           <div class="col-md-4">
            <div class="con-map">
               <!-- <iframe src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d31104.03290083473!2d77.55783247154724!3d12.971588414766725!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1sSouthern+Travels%2C+Madhava+Nagar%2C+Seshadripuram%2C+Bangalore%2C+Karnataka!5e0!3m2!1sen!2sin!4v1457150676824" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>-->
          <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3887.692891967175!2d77.57913931482229!3d12.991483990842799!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x62ab14fd3b0ee6a5!2sSouthern+Travels!5e0!3m2!1sen!2s!4v1458113240898" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          </div>
           </div>
           
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>BENGALURU</h3>
              <p>Hotel Rajkamal Complex, Near Sivananda<br>
                Stores, Kumara Park East,<br>
                Bengaluru-560 001.
                 </p>
                 <div class="clearfix"></div>
         	</address>
            <div class="clearfix"></div>
             <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-80-22262633, 22375536</p>
          </address>
            </div>
            <div class="col-md-4">
           
          
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9379923236</p>
          </address>
            </div>
            <div class="col-md-4">
             <address>
          <div class="icondv"><i class="fax"></i></div>
          <h3>Fax No.</h3>
          <p>+91-80-22252222</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="mailto:bangalore@southerntravels.in">bangalore@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          <div class="row">
           <div class="col-md-4">
            <div class="con-map">
          <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3886.2910886125082!2d80.26764471482315!3d13.080729190784307!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xa2374a299173533d!2sSouthern+Travels+Pvt+Ltd!5e0!3m2!1sen!2sin!4v1457151979729" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>CHENNAI </h3>
              <p>No.1098, Poonamallee High Road, Opp.<br>
                Hotel Royal Regency, Besides Hotel Golden<br>
                tower, Periyamet, Chennai-600 003.
                 </p>
                 <div class="clearfix"></div>
         	</address>
             <div class="clearfix"></div>
             <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-44-43235353 , 45126271</p>
          </address>
            </div>
            <div class="col-md-4">
           
         
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-7299923236</p>
          </address>
            </div>
            <div class="col-md-4">
             <address>
          <div class="icondv"><i class="fax"></i></div>
          <h3>Fax No.</h3>
          <p>+91-44-25386833</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="mailto:chennai@southerntravels.in">chennai@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          <div class="row">
           <div class="col-md-4">
            <div class="con-map">
         <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3916.48492579097!2d76.94935531480276!3d11.002196992168525!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x0!2zMTHCsDAwJzA3LjkiTiA3NsKwNTcnMDUuNiJF!5e0!3m2!1sen!2sin!4v1457152070836" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>COIMBATORE</h3>
              <p>New No. 206 / 2, D.B.Road, (Next to Axis<br>
                Bank), R.S. Puram, Coimbatore.<br>
                Tamil Nadu - 641002.
                 </p>
                 <div class="clearfix"></div>
         	</address>
            <div class="clearfix"></div>
             <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-422-4200999, 2470235 / 6</p>
          </address>
            </div>
            <div class="col-md-4">
           
          
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9551323236</p>
          </address>
            </div>
            <div class="col-md-4">
            
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="mailto:coimbatore@southerntravels.in">coimbatore@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
           <div class="col-md-4">
            <div class="con-map">
           <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3807.1962579309943!2d78.45986791487651!3d17.402366688069595!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xfced2c8a24059dad!2sSouthern+Travels!5e0!3m2!1sen!2sin!4v1457152128397" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>HYDERABAD</h3>
              <p>No.7 & 8, Mustafa Towers,<br>
                Near Ayodhya Junction, Lakdi-ka-pul,<br>
                Hyderabad-500 004.
                 </p>
                 <div class="clearfix"></div>
         	</address>
             <div class="clearfix"></div>
             <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-40-2331 8866, 23303561</p>
          </address>
            </div>
            <div class="col-md-4">
           
         
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848023236, 9346115536</p>
          </address>
            </div>
            <div class="col-md-4">
             <address>
          <div class="icondv"><i class="fax"></i></div>
          <h3>Fax No.</h3>
          <p>+91-40-23328993</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="mailto:hyd@southerntravels.in">hyd@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          
          
          <div class="row">
           <div class="col-md-4">
            <div class="con-map">
          <!--<iframe src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d31104.03290083473!2d77.55783247154724!3d12.971588414766725!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1sSouthern+Travels%2C+Madhava+Nagar%2C+Seshadripuram%2C+Bangalore%2C+Karnataka!5e0!3m2!1sen!2sin!4v1457150676824" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>-->
          <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d15222.710035659358!2d78.4101578!3d17.4751428!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x61b41e9b42124dd9!2sSouthern+Travels!5e0!3m2!1sen!2s!4v1458113435449" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>HYDERABAD (Kukatpally) </h3>
              <p>Punnami Plaza, 15-24-336, Ground Floor<br>
                Besides Remedy Hospital, KPHB colony,<br>
                Kukatpally, Hyderabad 500072.
                 </p>
                 <div class="clearfix"></div>
         	</address>
             <div class="clearfix"></div>
              <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-40-65505536, 23155536</p>
          </address>
            </div>
            <div class="col-md-4">
          
         
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9848071155</p>
          </address>
            </div>
            <div class="col-md-4">
             <address>
          <div class="icondv"><i class="fax"></i></div>
          <h3>Fax No.</h3>
          <p>+91-40-23055536</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="mailto:kphb@southerntravels.in">kphb@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          <div class="row">
           <div class="col-md-4">
            <div class="con-map">
         <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d942.6598032335177!2d72.90683982920207!3d19.07959399919289!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x0!2zMTnCsDA0JzQ2LjUiTiA3MsKwNTQnMjYuNiJF!5e0!3m2!1sen!2sin!4v1457152181383" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>MUMBAI</h3>
              <p>Office no. 4, Vijay Kunj, 142, Vallabh Baugh<br>
                Lane, Ghatkopar(e),<br>
                Mumbai-400077.
                 </p>
                 <div class="clearfix"></div>
         	</address>
             <div class="clearfix"></div>
             <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-22-25010027, 67991999</p>
          </address>
            </div>
            <div class="col-md-4">
           
         
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9892216168</p>
          </address>
            </div>
            <div class="col-md-4">
             <address>
          <div class="icondv"><i class="fax"></i></div>
          <h3>Fax No.</h3>
          <p>+91-22-21023664</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="maito:mumbai@southerntravels.in">mumbai@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          <div class="row">
            <div class="col-md-4">
            <div class="con-map">
         <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3815.2842867508625!2d81.77112431487106!3d17.009719988305932!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x0!2zMTfCsDAwJzM1LjAiTiA4McKwNDYnMjMuOSJF!5e0!3m2!1sen!2sin!4v1457152240701" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>RAJAHMUNDRY</h3>
              <p>Shop No. 3, Bharat Complex, Opposite<br>
                Naga Devi Theatre, Near Gokavarm Bus Stand,<br>
                Trunk Road, Rajahmundry - 533 104
                 </p>
                 <div class="clearfix"></div>
         	</address>
            <div class="clearfix"></div>
              <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-883-242 5536, 2 448 448</p>
          </address>
            </div>
            <div class="col-md-4">
          
          
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-99495 23236</p>
          </address>
            </div>
            <div class="col-md-4">
            
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="maito:rajahmundry@southerntravels.in">rajahmundry@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          
          <div class="row">
          
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          <div class="row">
           <div class="col-md-4">
            <div class="con-map">
         <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3825.25147210272!2d80.62404901486438!3d16.5133973886078!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3a35effdeedd1357%3A0xea1e580e3408dd1f!2sSouthern+Travels+PVT+LTD!5e0!3m2!1sen!2sin!4v1457152293560" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>VIJAYAWADA</h3>
              <p>No.10, Swarnalok Complex, Near Apsara<br>
                Theatre, Eluru Road, Governorpet,<br>
                Gandhinagar, Vijayawada-520002
                 </p>
                 <div class="clearfix"></div>
         	</address>
             <div class="clearfix"></div>
             <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-866-2576624, 2574771</p>
          </address>
            </div>
            <div class="col-md-4">
           
         
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9010123236</p>
          </address>
            </div>
            <div class="col-md-4">
             <address>
          <div class="icondv"><i class="fax"></i></div>
          <h3>Fax No.</h3>
          <p>+91-866-2572227</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="mailto:bza@southerntravels.in">bza@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          <div class="row">
           <div class="col-md-4">
            <div class="con-map">
         <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3801.225257578226!2d83.21629281488059!3d17.686815887899787!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x1bd8ef7f8789d3d3!2sSouthern+Travels+Private+Limited!5e0!3m2!1sen!2sin!4v1457152340991" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>VISAKHAPATNAM</h3>
              <p>A-5, Pavan Palace,(G. Floor) Opp. TSR.<br>
                Complex, Dwaraka Nagar,<br>
                Visakhapatnam-530016
                 </p>
                 <div class="clearfix"></div>
         	</address>
            <div class="clearfix"></div>
             <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-891-2745565, 2541099</p>
          </address>
            </div>
            <div class="col-md-4">
           
          
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-9912123236</p>
          </address>
            </div>
            <div class="col-md-4">
             <address>
          <div class="icondv"><i class="fax"></i></div>
          <h3>Fax No.</h3>
          <p>+91-891-2505551</p>
          </address>
          <div class="clearfix"></div>
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="mailto:vizag@southerntravels.in">vizag@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          
          
          <div class="row">
          	<div class="col-lg-12">
            	<hr>
            </div>
          </div>
          <div class="row">
            <div class="col-md-4">
            <div class="con-map">
          <!--<iframe src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d31104.03290083473!2d77.55783247154724!3d12.971588414766725!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1sSouthern+Travels%2C+Madhava+Nagar%2C+Seshadripuram%2C+Bangalore%2C+Karnataka!5e0!3m2!1sen!2sin!4v1457150676824" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>-->
          <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d15177.639279267956!2d79.5699742!3d18.0061747!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x977de952133a0597!2sSouthern+Travels+India+Pvt+Ltd!5e0!3m2!1sen!2sin!4v1458191149483" width="100%" height="180" frameborder="0" style="border:0" allowfullscreen></iframe>
          
          </div>
           </div>
            <div class="col-md-4">
            <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>WARANGAL </h3>
              <p>NO.6-2-199,Jeevanlal Complex,<br>
                Choowrasta.<br>
                Hanamkonda - 506001
                 </p>
                 <div class="clearfix"></div>
         	</address>
             <div class="clearfix"></div>
             <address>
          <div class="icondv"><i class="callus"></i></div>
          <h3>Call us</h3>
          <p>+91-0870-2555536, 257, 8888</p>
          </address>
            </div>
            <div class="col-md-4">
           
         
          <address>
          <div class="icondv"><i class="phone"></i></div>
          <h3>Mobile No</h3>
          <p>+91-81250 23236</p>
          </address>
            </div>
            <div class="col-md-4">
            
          <address>
          <div class="icondv"><i class="email"></i></div>
          <h3>Email us At</h3>
          <p><a href="mailto:warangal@southerntravels.in">warangal@southerntravels.in</a></p>
          </address>
            </div>
          </div>
          
          
          
          
          </div>
              </div>
          </div>
          
       <!-- end of our branch officess-->         
          </div>
        </div>
      </div>
    </div>
   
  
 
</section>
    <div id="videoModal" class="modal fade" style="margin-top: 40px!important">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        X</button>
                </div>
                <div class="modal-body">
                    <iframe id="awardVideo" width="100%" height="500" src="https://www.youtube.com/embed/ax5muD-6Opw"
                        frameborder="0" allowfullscreen></iframe>
                </div>
            </div>
        </div>
    </div>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    <!-- Modal video -->
    <script type="text/javascript">
        $(function () {
            $('.tabsection_inner .nav-tabs li a').on('click', function (e) {
                //alert('');
                //var href = $(this).attr('href');
                $("html, body").animate({ scrollTop: 0 }, "slow");
                e.preventDefault();
            });
            $('#tab_bod .txtsection').hide();

            $('.directorlink').click(function (e) {
                //alert('');
                $('#tab_bod .txtsection').slideUp();
                $(this).parent().find('.txtsection').slideDown();
                e.preventDefault();
            });

            $('#bodcontainer').focusout(function () {
                $('#tab_bod .txtsection').hide();
            });
        });
    </script>
    </form>
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <!--Install Crazy Egg code for Tracking Visitor Behavior-->
    <script type="text/javascript">
        setTimeout(function () {
            var a = document.createElement("script");
            var b = document.getElementsByTagName('script')[0];
            a.src = document.location.protocol + "//dnn506yrbagrg.cloudfront.net/pages/scripts/0011/9178.js?" + Math.floor(new Date().getTime() / 3600000);
            a.async = true; a.type = "text/javascript"; b.parentNode.insertBefore(a, b)
        }, 1);
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
 
    </script>
    <script>
        $(document).ready(function () {
            /* Get iframe src attribute value i.e. YouTube video url
            and store it in a variable */
            var url = $("#awardVideo").attr('src');

            /* Assign empty url value to the iframe src attribute when
            modal hide, which stop the video playing */
            $("#videoModal").on('hide.bs.modal', function () {
                $("#awardVideo").attr('src', '');
            });

            /* Assign the initially stored url back to the iframe src
            attribute when modal is displayed again */
            $("#videoModal").on('show.bs.modal', function () {
                $("#awardVideo").attr('src', url);
            });


            $('#tab_bod .txtsection').hide();

            $('.directorlink').click(function (e) {
                //alert('');
                $('#tab_bod .txtsection').slideUp();
                $(this).parent().find('.txtsection').slideDown();
                e.preventDefault();
            });

            $('#bodcontainer').focusout(function () {
                $('#tab_bod .txtsection').hide();
            });

        });


    </script>
</body>
</html>
