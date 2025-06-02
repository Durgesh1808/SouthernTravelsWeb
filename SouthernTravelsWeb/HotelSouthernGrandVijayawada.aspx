<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelSouthernGrandVijayawada.aspx.cs" Inherits="SouthernTravelsWeb.HotelSouthernGrandVijayawada" %>


<%@ Register Src="UserControl/UcHolidaySearch.ascx" TagName="UCHolidaySearch" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" itemscope itemtype="http://schema.org/TravelAgency" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Southern Grand at Vijayawada offers you comfortable stay and genuine hospitality. Visit us for a unforgettable experience.">
        <meta name="Keywords" content="southern grand, best hotel in india, southern grand in india, hotel in vijayawada, best hotel, deluxe room, executive rooms, best hospitality, budget hotel in india, affordable hotel in india, hotel in budeget prices, cheap hotel in india" />
    <meta name="author" content="">
    <title>Hotel Southern Grand - Vijayawada</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="robots" content="index,follow" />
    <meta name="WebsiteSpark" content="ltS2mkWvjn" />

    

    <script>

        (function(i, s, o, g, r, a, m) {

            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function() {

                (i[r].q = i[r].q || []).push(arguments)

            }, i[r].l = 1 * new Date(); a = s.createElement(o),

  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)

        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');



        ga('create', 'UA-4994177-1', 'auto');

        ga('require', 'displayfeatures');

        ga('send', 'pageview');

 

    </script>

</head>
<body>
    <form id="form" runat="server" style="margin: 0px;">
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-hotels.jpg)">
  <div class="herobanner">
     <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="HOTEL_DELHI" />
  </div>
  </header>
    <!-- Main Content Start-->
    <section class="innersection2">
  <div id="fixedtabsection">
    <div class="container">
      <div class="row subheadrow">
        <div class="col-md-12">
          <h1 class="title">Our Own <span>Hotels</span> 
          <ul class="topheadingtabs">
          <%--<li><a href="hotel-southern.aspx?HTLREG=DEL" >Hotel Southern, Delhi</a></li> --%>  
          <li><a href="http://www.hotelsouthern.com/" target="_blank">Hotel Southern, Delhi</a></li> 
          <li><a href="#" class="active">Southern Grand, Vijayawada</a></li>
          <li><a href="hotel-southern-jaipur.aspx">Zone by The Park, Jaipur</a></li>
          </ul>
          </h1>
          
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="tabsection_inner">
            <div id="checkdiv"></div>
            <ul class="nav nav-tabs">
              <li class="active"><a href="#hotel_tab1">Accommodation</a></li>
              <li><a href="#hotel_tab2">Tariff</a></li>
              <li><a href="#hotel_tab3">Restaurants</a></li>
              <li><a href="#hotel_tab4">Facilities & Amenities</a></li>
              <li><a href="#hotel_tab5">Conference Room</a></li>
              <li><a href="#hotel_tab6">Accessibility</a></li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="container-fluid">
    <div class="row tabspace">
      <div class="col-md-12 paddingleft0 paddingright0">
        <div class="tab-content tab-content-inner">
          <section id="tabsections"> 
            <!-- tab_hotelinfo -->
            <section id="hotel_tab1">
            <h2 class="title showonmobile">Accommodation</h2>
              <div class="" id="tab_hotelinfo">
                <div class="container">
                  <div class="row rowgap">
                    <div class="col-md-3"> <img loading="lazy" src="Assets/images/hotel-st-grand.jpg" class="img-responsive"> </div>
                    <div class="col-md-9">
                      <h3 class="title">Welcome to <span>Southern Grand, Vijayawada</span></h3>
                      <p>Strategically located in Gandhi Nagar - the heart of Vijayawada, Southern Grand offers you comfortable stay, genuine hospitality, personalized guest service, quality food and a plethora of other amenities at an affordable price.</p>
                      <p>After elevating the hospitality standards in Delhi, we are ready to set another example in Andhra Pradesh with splendid opening of Southern Grand. We welcome our guests with a true friendliness to ensure that they have a memorable visit and stay in Vijaywada. All efforts are made to provide luxurious comfort combined with exceptional and personalized service.</p>
                      <p>Visit us for a wonderful and unforgettable experience!</p>
                      <%--<p class="btnwrap"><a href="http://live.reznext.com/WBE/searchresults.aspx?CUSTCODE=3363" target="_blank">Book Now</a></p>--%>
                      <p class="btnwrap"><a href="https://SouthernGrand.reznextbookingengine.com/SouthernGrand-Vijayawada" target="_blank">Book Now</a></p>
                    </div>
                  </div>
                </div>
              </div>
            </section>
            <!-- end tab_hotelinfo --> 
            
            <!-- tab_tariff -->
            <section id="hotel_tab2" class="tab_tariff gray">
            <h2 class="title showonmobile">Tariff</h2>
              <div class="">
                <div class="container">
                  <%--<div class="row rowgap">
                    <div class="col-md-12">
                      <div class="text-center">
                        <h2 class="title brdrnone mrgnbtmno">Room <span>Tariff</span></h2>
                      </div>
                    </div>
                  </div>--%>
                  <div class="row">
                    <div class="col-md-12">
                      <div class="tarifftab">
                        <ul class="nav nav-tabs nav-justified">
                          <li class="active"><a href="#tab_delux" data-toggle="tab"><span>Deluxe</span></a></li>
                          <li><a href="#tab_executive" data-toggle="tab"><span>Executive Deluxe </span></a></li>
                          <li><a href="#tab_royalst" data-toggle="tab"><span>Royal Southern</span></a></li>
                        </ul>
                      </div>
                    </div>
                  </div>
                  <div class="row tabspace rowgap">
                    <div class="col-md-12">
                      <div class="tab-content tab-content-inner"> 
                        
                        <!-- tab_delux -->
                        <div class="tab-pane fade in active" id="tab_delux">
                          <div class="row rowgap">
                            <div class="col-md-8">
                              <div class="hotel_slider owl-carousel">
                                <div class="item"><img loading="lazy" src="Assets/images/hotel-st-grand/deluxe1.jpg" class="img-responsive"></div>
                                
                              </div>
                            </div>
                            <div class="col-md-4">
                              <div class="txtsection">
                                <h3 class="title"><span>Deluxe</span> </h3>
                                <ul class="sublist">
                                  <li>Complimentary Breakfast</li>
                                    <li>In-Room coffee/tea maker</li>
                                    <li>32" LCD TV with all Popular Channels</li>
                                    <li>Electronic door locks</li>
                                    <li>Mini Bar</li>
                                </ul>
                                <p><a href="http://www.reznextbookingengine.com/property/SouthernGrand-Vijayawada">More details</a></p>
                                <p class="hotelprice"><span><i class="fa fa-rupee"></i>2,200</span> Single Room</p>
                                <p class="hotelprice"><span><i class="fa fa-rupee"></i>2,600</span> Double Room (Extra Person: <i class="fa fa-rupee"></i>450)</p>
                                <%--<p class="btnwrap"><a href="http://live.reznext.com/WBE/searchresults.aspx?CUSTCODE=3363" target="_blank">Book Now</a></p>--%>
                                <p class="btnwrap"><a href="https://SouthernGrand.reznextbookingengine.com/SouthernGrand-Vijayawada" target="_blank">Book Now</a></p>
                              </div>
                            </div>
                          </div>
                         
                        </div>
                        <!-- end tab_delux --> 
                        
                        <!-- tab_executive -->
                        <div class="tab-pane" id="tab_executive">
                          <div class="row rowgap">
                            <div class="col-md-8">
                              <div class="hotel_slider owl-carousel">
                                <div class="item"><img loading="lazy" src="Assets/images/hotel-st-grand/executive1.jpg" class="img-responsive"></div>
                                <div class="item"><img loading="lazy" src="Assets/images/hotel-st-grand/executive2.jpg" class="img-responsive"></div>
                                <div class="item"><img loading="lazy" src="Assets/images/hotel-st-grand/executive3.jpg" class="img-responsive"></div>
                              </div>
                            </div>
                            <div class="col-md-4">
                              <div class="txtsection">
                                <h3 class="title"><span>Executive Room</span> </h3>
                               <ul class="sublist">
                                  <li>Complimentary Breakfast</li>
                                    <li>In-Room coffee/tea maker</li>
                                    <li>32" LCD TV with all Popular Channels</li>
                                    <li>Electronic door locks</li>
                                    <li>Mini Bar</li>
                                </ul>
                                <p><a href="http://www.reznextbookingengine.com/property/SouthernGrand-Vijayawada">More details</a></p>
                                
                                  <p class="hotelprice"><span><i class="fa fa-rupee"></i>2,600</span> Single Room</p>
                                <p class="hotelprice"><span><i class="fa fa-rupee"></i>3,000</span> Double Room (Extra Person: <i class="fa fa-rupee"></i>450)</p>
                                <%--<p class="btnwrap"><a href="http://live.reznext.com/WBE/searchresults.aspx?CUSTCODE=3363" target="_blank">Book Now</a></p>--%>
                                <p class="btnwrap"><a href="https://SouthernGrand.reznextbookingengine.com/SouthernGrand-Vijayawada" target="_blank">Book Now</a></p>
                              </div>
                            </div>
                          </div>
                         
                        </div>
                        <!-- end tab_executive --> 
                        
                        <!-- tab_royalst -->
                        <div class="tab-pane" id="tab_royalst">
                          <div class="row rowgap">
                            <div class="col-md-8">
                              <div class="hotel_slider owl-carousel">
                                <div class="item"><img loading="lazy" src="Assets/images/hotel-st-grand/royal1.jpg" class="img-responsive"></div>
                                
                              </div>
                            </div>
                            <div class="col-md-4">
                              <div class="txtsection">
                                <h3 class="title"><span>Royal Southern</span> </h3>
                                
                                 <ul class="sublist">
                                  <li>Complimentary Breakfast</li>
                                    <li>In-Room coffee/tea maker</li>
                                    <li>32" LCD TV with all Popular Channels</li>
                                    <li>Electronic door locks</li>
                                    <li>Mini Bar</li>
                                </ul>
                                <p><a href="http://www.reznextbookingengine.com/property/SouthernGrand-Vijayawada">More details</a></p>
                                
                                  <p class="hotelprice"><span><i class="fa fa-rupee"></i>4,100</span> Single Room</p>
                                <p class="hotelprice"><span><i class="fa fa-rupee"></i>4,100</span> Double Room (Extra Person: <i class="fa fa-rupee"></i>450)</p>
                                
                                <%--<p class="btnwrap"><a href="http://live.reznext.com/WBE/searchresults.aspx?CUSTCODE=3363" target="_blank">Book Now</a></p>--%>
                                <p class="btnwrap"><a href="https://SouthernGrand.reznextbookingengine.com/SouthernGrand-Vijayawada" target="_blank">Book Now</a></p>
                              </div>
                            </div>
                          </div>
                         
                        </div>
                        <!-- end tab_royalst --> 
                        
                         <div class="row">
                            <div class="col-md-8">
                              <p class="mrgnbtmno"><strong>Child Policy :</strong><br>
0 to 5 Years - No Charges & No Extra Bed Provided<br>
6 to 12 Years - <i class="fa fa-rupee"></i>100/- will be charged for Breakfast<br>
Above 12 Years - Considered as an Extra Person and will be charged <i class="fa fa-rupee"></i>450/- with Breakfast whether Extra Bed is availed or not
</p>
                              
                            </div>
                            <div class="col-md-4">
                              <p class="mrgnbtmno"><strong>Taxes:</strong> Luxury Tax - 5% & Service Tax - 9.00% extra</p>
                              <p class="mrgnbtmno"><strong>Check In</strong> @ 12:00, <strong>Check Out</strong>  @ 12:00</p>
                               <p class="mrgnbtmno"><strong>Note:</strong> Extra Person in a double room will be charged <i class="fa fa-rupee"></i>450/- Per Night.</p>
                            </div>
                          </div>
                        
                      </div>
                    </div>
                  </div>
                  <div class="row">
          	
            <div class="col-md-12">
            	
                <div class="tablewrap">
                	
                    <table width="100%" border="0" class="table-bordered">
  <tr>
    <th>Room Type</th>
    <th>Single</th>
    <th>Double</th>
  </tr>


  <tr>
    <td>Deluxe</td>
    <td><i class="fa fa-rupee"></i> 2,200/-</td>
    <td> <i class="fa fa-rupee"></i> 2,600/-</td>
    
  </tr>
  
   <tr>
    <td>Executive Deluxe/td>
     <td><i class="fa fa-rupee"></i> 2,600/-</td>
    <td> <i class="fa fa-rupee"></i> 3,000/-</td>
      </tr>
  
   <tr>
    <td>Royal Southern</td>
     <td><i class="fa fa-rupee"></i> 4,100/-</td>
    <td> <i class="fa fa-rupee"></i> 4,100/-</td>
      </tr>
  
   <tr>
    <td>Extra Person</td>
    <td>-</td>
     <td> <i class="fa fa-rupee"></i> 400/-</td>
      </tr>
  
  

</table>

                    
                </div>
                
            </div>
            
          </div>
                </div>
              </div>
            </section>
            <!-- end tab_tariff --> 
            
            <!--tab_restaurants -->
           <section id="hotel_tab3">
          		<%--<h2 class="title showonmobile">Restaurants</h2>--%>
                <div class="container restaurants">
                	<div class="row">
                    <div class="col-md-5"><img loading="lazy" src="Assets/images/restaurants-Vij.jpg" class="img-responsive"></div>
                    <div class="col-md-7">
                    	<div class="rastraucontent">
                        	<h2 class="title"><span>Restaurants</span></h2>
                            <h4 class="title"><span>Arya Bhavan</span><br>&nbsp;<br />Centrally Air-Conditioned. Serves the best South & North Indian /Chinese, Vegetarian & Cuisine.</h4>
                            <%--<p>Our Speciailties are :</p>
                            <ul class="sublist">
                            <li>South Indian Thali (Meals)</li>

<li>Mini Meal</li>
<li>Parotta Khurma</li>
<li>Spring Roll Dosa</li>
<li>North Indian Thali</li>
<li>Room Service Available</li>
                            </ul>--%>
                            <div class="timing">
                            	<div class="displayinline redcolor">Open</div>
                                <div class="displayinline">07.00 AM TO 10.30 PM</div>
                            </div>
                            <div class="roomservice">
                            	<h4 class="title"><span>Room Service Available :</span></h4>
                                <p><strong>Location :</strong> In Hotel - Ground Floor<br>
									<strong>Serves  :</strong>Breakfast | Lunch | Dinner</p>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>
                
          </section>
            <!--tab_restaurants --> 
            
            <!--tab_facilities -->
            <section id="hotel_tab4">
            <%--<h2 class="title showonmobile">Facilities & Amenities</h2>--%>
              <div class="container restaurants">
                <div class="row">
                 
                  <div class="col-md-12">
                    <div class="rastraucontent">
                      <h2 class="title"><span>Facilities & Amenities</span></h2>
                     <div class="row">
                     <div class="col-md-4">
                     	 <ul class="sublist">
                      <li> Well Appointed 37 Rooms</li>
<li>Centrally Air-Conditioned</li>
<li>Complimentary Breakfast</li>
<li>In-Room coffee/tea maker</li>
<li>32" LCD TV with all Popular Channels</li>
<li>Unlimited Wi-Fi usage in Lobby & Rooms</li>
<li>Hair Dryer (Executive & Royal Southern)</li>



                      </ul>
                     </div>
                     
                      <div class="col-md-4">
                     	 <ul class="sublist">
                     	 <li>Room service 24 hrs</li>
<li>Laundry Facility</li>
<li>Doctor on call</li>
                       <li>Writing Desk</li>
 <li>Valet Parking</li>
<li>Daily Newspaper</li>
<li>Electronic Safes</li>

                      </ul>
                     </div>
                     
                       <div class="col-md-4">
                     	 <ul class="sublist">
                     	 <li>Electronic door locks</li>
<li>Travel Desk</li>

                       <li>Mini Bar</li>
<li>Foreign Exchange on request</li>
<li>Luggage storage facility,if required</li>
<li>Iron board and Iron on request</li>
<li>All Major Credit Cards accepted</li>
                      </ul>
                     </div>
                     
                     </div>
                     
                     
                    </div>
                  </div>
                  
                   <div class="col-md-5"> <%--<img loading="lazy" src="images/aminities.jpg" class="img-responsive">--%></div>
                  
                </div>
              </div>
            </section>
            <!--end tab_facilities --> 
            
            <!-- tab_conference -->
            <section id="hotel_tab5" class="gray">
            <h2 class="title showonmobile">Conference Room</h2>
              <div class="container">
                <div class="row">
                  <div class="col-md-3">
                   <img loading="lazy" src="Assets/images/hotel-st-grand-conferenceroom.jpg" class="img-responsive">
                   
                  </div>
                  <div class="col-md-9">
                    
                     <div>
                      <h2 class="title"><span>Banquet Hall / Conference Hall</span></h2>
                      <p>Elegantly appointed Banquet/Meeting Hall with Private entrance can accommodate up to 200 persons. Suitable for Birthday Parties, Kitty Parties, Wedding, Receptions, Conference, Meeting and Private Get Togethers.</p>
                    </div>
                      
                      <!-- <img loading="lazy" src="images/hotel-map.jpg" class="img-responsive">--> 
                   
                  
                  </div>
                </div>
              </div>
            </section>
            <!-- end tab_conference --> 
            
            
              <!--tab_Accessibility-->
            <section id="hotel_tab6">
             <h2 class="title showonmobile">Accessibility</h2>
              <div class="container tab_accessibility">
                <div class="row">
                  <div class="col-md-7 paddingright0">  
                  <iframe width="100%" height="500" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.co.in/maps?ie=UTF8&cid=4357259629728853768&q=Southern+Grand+Hotels+and+Resorts+LLP&gl=IN&hl=en_uk&ll=16.515264,80.624113&spn=0.006295,0.006295&t=m&iwloc=A&output=embed"> </iframe>
                 </div>
                  <div class="col-md-5 paddingleft0">
                   	
                      <div class="accessibility">
                      <h2 class="title"><span>Accessibility</span></h2>
                      <ul class="sublist">
                        <li>Distance from Railway Station - 0.5 Km(furlong)</li>
<li>Distance from Airport - 19 Kms</li>
<li>Distance from Main Bus Stand - 1 Km</li>
                      </ul>
                    </div>
                   <div class="contact-hotel">
                    <h2 class="title"><span>Get In Touch</span></h2>
                  
              <address>
              <div class="icondv"><i class="location"></i></div>
              <h3> A Unit of Southern Grand Hotels and Resorts LLP</h3>
              <p>26-6-8 Papaiah Street, Gandhi Nagar <br>
                 Vijayawada,<br>
                Andhra Pradesh </p>
            </address>
            
            <address>
              <div class="icondv"><i class="callus"></i></div>
              <h3>Call Us At</h3>
              <p>+91-866-6677777<br>+91-866-6655777 </p>
            </address>
            
            <!-- 
             <address>
              <div class="icondv"><i class="fax"></i></div>
              <h3>Call Us At</h3>
              <p>+91-866-2572227 </p>
            </address>
            -->
            
             <address>
              <div class="icondv"><i class="email"></i></div>
              <h3>Email Us At</h3>
              <p><a href="mailto:bookings@hotelsoutherngrand.com">bookings@hotelsoutherngrand.com</a> </p>
            </address>
                        
              <address>
              <div class="icondv"><i class="web"></i></div>
              <h3>Website</h3>
              <p><a href="http://www.hotelsoutherngrand.com" target="_blank">www.hotelsoutherngrand.com</a> </p>
            </address>    
                   </div>
                 
                  </div>
                </div>
              </div>
            </section>
            <!-- end tab_Accessibility-->
            
            
          </section>
        </div>
      </div>
    </div>
  </div>
  </div>
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    </form>

    <script>
        $('select').selectpicker();

    </script>

    <script type="text/javascript">
        $(document).ready(function($) {

            $(".hotel_slider").owlCarousel({
                items: 1,
                pagination: false,
                // Navigation
                navigation: false,
                loop: true,
                autoPlay: true,
                autoplayTimeout: 1000,
                autoplayHoverPause: true,
                itemsDesktop: [1170, 1],
                itemsDesktopSmall: [991, 1],
                itemsTablet: [768, 1],
                itemsTabletSmall: false,
                itemsMobile: [480, 1]
            });



        });
    </script>

    

    <script type="text/javascript">
        $(function() {

            $(window).scroll(function() {
                var window_top = $(window).scrollTop();
                // the "12" should equal the margin-top value for nav.stickydiv
                var div_top = $('#checkdiv').offset().top;

            });

            $(document).on("scroll", onScroll);
            $('.tabsection_inner .nav li a[href^="#"]').on('click', function(e) {
                e.preventDefault();
                $(document).off("scroll");
                $('.tabsection_inner .nav li a').each(function() {
                    $(this).parent().removeClass('active');
                })
                $(this).parent().addClass('active');
                var target = this.hash,
                //menu = target;
		$target = $(target);
                //alert($target.offset().top-120);
                $('html, body').stop().animate({
                    'scrollTop': $target.offset().top - 160
                }, 600, 'swing', function() {
                    //window.location.hash = target;
                    $(document).on("scroll", onScroll);
                });
            });
        });

        function onScroll(event) {
            var scrollPos = $(document).scrollTop();
            //alert(scrollPos);
            $('.tabsection_inner .nav li a').each(function() {
                var currLink = $(this);
                var refElement = $(currLink.attr("href"));
                if (refElement.position().top <= scrollPos && refElement.position().top + refElement.height() > scrollPos) {
                    $('.tabsection_inner .nav li a').parent().removeClass("active");
                    currLink.parent().addClass("active");

                }
                else {
                    currLink.parent().removeClass("active");

                }
            });
        }

    </script>

</body>
</html>

