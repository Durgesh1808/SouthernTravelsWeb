<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hotel-Southern-Jaipur.aspx.cs" Inherits="SouthernTravelsWeb.Hotel_Southern_Jaipur" %>


<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcHotelInSouthern.ascx" TagName="UcHotelInSouthern" TagPrefix="uc3" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Southern Travels - Tour and Travel Agency | Holiday Packages in India| Car Rental
        Services</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
     <meta name="Description" content="Zone by The Park at Jaipur provide best ever facilities and comfortable stay to our valuable customer. Book a stay with Zone by The Park and create unique experiences and lifelong memories." />
    <meta name="Keywords" content="Zone by The Park, hotel in jaipur, best hotel in jaipur, budget hotel in jaipur, cheap hotel in jaipur, budget hotel in pink city, luxury rooms, deluxe rooms affordable hotel in india, best budget hotel in india" />
    <meta name="robots" content="index,follow" />
</head>
<body>
    <form id="form1" runat="server">
    <!-- Header Start -->
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-hotels.jpg)">
  <div class="herobanner">
    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="HOTEL_DELHI" />
    
  </div></header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <section class="innersection2">
  
    <div id="fixedtabsection">
    <div class="container">
      <div class="row subheadrow">
        <div class="col-md-12">
          <h1 class="title">Our Own <span>Hotels</span> 
          <ul class="topheadingtabs">
          <li><%--<a href="hotel-southern.aspx?HTLREG=DEL">Hotel Southern, Delhi</a>--%></li>  
          <li><a href=" http://www.hotelsouthern.com/" target="_blank">Hotel Southern, Delhi</a></li>  
         
          <li><a href="HotelSouthernGrandVijayawada.aspx">Southern Grand, Vijayawada</a></li>
          <li><a href="#" class="active">Zone by The Park, Jaipur</a></li>
          </ul>
          </h1>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="tabsection_inner">
          <div id="checkdiv"></div>
            <ul class="nav nav-tabs">
              <li class="active"><a href="#hotel_tab1">Hotel Information</a></li>
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
      <div class="col-md-12">
        <div class="tab-content tab-content-inner"> 
         
          <section id="tabsections">
          <!-- tab_hotelinfo -->
          <section id="hotel_tab1">
          <h2 class="title showonmobile">Accommodation</h2>
          <div class="" id="tab_hotelinfo">
           <div class="container">
            <div class="row rowgap">
              <div class="col-md-3">
					<img src="Assets/images/hotel-zone/logo.jpg" class="img-responsive">           
              </div>
              <div class="col-md-9">
              	<h3 class="title">Welcome to <span>Zone by The Park, Jaipur</span></h3>
                <p>After strengthening hospitality presence in Delhi and Vijayawada, we are on our way to present affordable luxury for value segment with
opening of Zone by The Park in Jaipur. We are delighted to assure you another extraordinary hospitality experience from 18th April, 2015.</p>
<p>
Committed to provide hotel visitors with incomparable personalized guest service, Zone by The Park promises luxurious stay and superlative
amenities at affordable price. With its grand opening in Jaipur, Zone by The Park will be ready to re-interpret the tradition of hospitality
for creating unique experiences and lifelong memories. </p>
                <p class="btnwrap">
                <!--<a href="#" >Book Now</a>-->
                  <a href="#" data-toggle="modal" data-target="#bookingform">Book Now</a>
                
                </p>
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
            
                <div class="row">
                <div class="col-md-12">
                  <div class="tarifftab"> 
                  	<ul class="nav nav-tabs nav-justified">
                    <li class="active"><a href="#tab_delux" data-toggle="tab"><span>Zone Room</span></a></li>
                    <li><a href="#tab_superdelux" data-toggle="tab"><span>Zone Trio</span></a></li>
                    <li><a href="#tab_executive" data-toggle="tab"><span>Zone Quad</span> </a></li>
                    <li><a href="#tab_royalst" data-toggle="tab"><span>Zone Suite</span></a></li>
                    </ul>
                    
                    
                    
                  </div>
                </div>
               
                </div>
                
                 <div class="row tabspace">
      <div class="col-md-12">
        <div class="tab-content tab-content-inner"> 
          
          <!-- tab_delux -->
          <div class="tab-pane fade in active" id="tab_delux">
          		
                <div class="row rowgap">
                	<div class="col-md-8">
                    	<div class="hotel_slider owl-carousel">
                        <div class="item"><img src="Assets/images/hotel-zone/zone-room1.jpg" class="img-responsive"></div>
                        <!-- <div class="item"><img src="Assets/images/hotel-zone/zon-room1.jpg" class="img-responsive"></div> -->
                        
                        </div>
                    </div>
                    
                    <div class="col-md-4">
                    	<div class="txtsection">
                        <h3 class="title"><span>Zone Room</span></h3>
                        <ul class="sublist">
                        
                     <li>Luxury bed</li>
<li>Large screen hd television</li>
<li>Hi-speed Wi-Fi connectivity</li>
<%--<li>Touch pad for in-room ordering, billing access and surfing</li>--%>
<li>Bathrooms with shower and toiletries</li>
<li>Fully loaded mini bar</li>
                        
                        </ul>
                        
                        <p><a href="http://www.zonebythepark.com/jaipur/rooms.php" target=_blank>More Details</a></p>
                        
                        <%--<p class="hotelprice"><span><i class="fa fa-rupee"></i>2,250</span> Per Night</p>--%>
                        <p class="btnwrap" style="visibility:hidden">
                         <!--<a href="#">Book Now</a>-->
                        <a href="#" data-toggle="modal" data-target="#bookingform">Book Now</a>
                        </p>
                        </div>
                    </div>
                    
                </div>
                
                <div class="row">
                <div class="col-md-8">
                	<p><strong>Check In</strong> @ 14:00, <strong>Check Out</strong>  @ 12:00</p>
                </div>
              
                </div>
                
          </div> <!-- end tab_delux -->
          
          <!-- tab_superdelux -->
          <div class="tab-pane" id="tab_superdelux">
          	   <div class="row rowgap">
                	<div class="col-md-8">
                    	<div class="hotel_slider owl-carousel">
                        <div class="item"><img src="Assets/images/hotel-zone/zone-trio1.jpg" class="img-responsive"></div>
                        <!-- <div class="item"><img src="Assets/images/hotel-zone/zon-room1.jpg" class="img-responsive"></div> -->
                        
                        </div>
                    </div>
                    
                    <div class="col-md-4">
                    	<div class="txtsection">
                        <h3 class="title"><span>Zone Trio</span></h3>
                        <ul class="sublist">
                        
                     <li>Luxury bed</li>
<li>Large screen hd television</li>
<li>Hi-speed Wi-Fi connectivity</li>
<%--<li>Touch pad for in-room ordering, billing access and surfing</li>--%>
<li>Bathrooms with shower and toiletries</li>
<li>Fully loaded mini bar</li>
                        
                        </ul>
                        
                        <p><a href="http://www.zonebythepark.com/jaipur/rooms.php" target=_blank>More Details</a></p>
                        
                        <%--<p class="hotelprice"><span><i class="fa fa-rupee"></i>2,250</span> Per Night</p>--%>
                        <p class="btnwrap">
                        <!-- <a href="#">Book Now</a>-->
                        <a href="#" data-toggle="modal" data-target="#bookingform">Book Now</a>
                        </p>
                        </div>
                    </div>
                    
                </div>
                
                <div class="row">
                <div class="col-md-8">
                	<p><strong>Check In</strong> @ 14:00, <strong>Check Out</strong>  @ 12:00</p>
                </div>
              
                </div>
                
          </div> <!-- end tab_superdelux -->
          
           <!-- tab_executive -->
          <div class="tab-pane" id="tab_executive">
          		
              
                 <div class="row rowgap">
                	<div class="col-md-8">
                    	<div class="hotel_slider owl-carousel">
                        <div class="item"><img src="Assets/images/hotel-zone/zone-quad1.jpg" class="img-responsive"></div>
                        <!-- <div class="item"><img src="Assets/images/hotel-zone/zon-room1.jpg" class="img-responsive"></div> -->
                        
                        </div>
                    </div>
                    
                    <div class="col-md-4">
                    	<div class="txtsection">
                        <h3 class="title"><span>Zone Quad</span></h3>
                        <ul class="sublist">
                        
                     <li>Luxury bed</li>
<li>Large screen hd television</li>
<li>Hi-speed Wi-Fi connectivity</li>
<%--<li>Touch pad for in-room ordering, billing access and surfing</li>--%>
<li>Bathrooms with shower and toiletries</li>
<li>Fully loaded mini bar</li>
                        
                        </ul>
                        
                       <p><a href="http://www.zonebythepark.com/jaipur/rooms.php" target=_blank>More Details</a></p>
                        
                        <%--<p class="hotelprice"><span><i class="fa fa-rupee"></i>2,250</span> Per Night</p>--%>
                        <p class="btnwrap">
                        <!--<a href="#">Book Now</a>-->
                        <a href="#" data-toggle="modal" data-target="#bookingform">Book Now</a>
                        </p>
                        </div>
                    </div>
                    
                </div>
                
                <div class="row">
                <div class="col-md-8">
                	<p><strong>Check In</strong> @ 14:00, <strong>Check Out</strong>  @ 12:00</p>
                </div>
              
                </div>
                
              
              
          </div> <!-- end tab_executive -->
          
          
            <!-- tab_royalst -->
          <div class="tab-pane" id="tab_royalst">
          		
                   <div class="row rowgap">
                	<div class="col-md-8">
                    	<div class="hotel_slider owl-carousel">
                        <div class="item"><img src="Assets/images/hotel-zone/zone-suite1.jpg" class="img-responsive"></div>
                        <!-- <div class="item"><img src="Assets/images/hotel-zone/zon-room1.jpg" class="img-responsive"></div> -->
                        
                        </div>
                    </div>
                    
                    <div class="col-md-4">
                    	<div class="txtsection">
                        <h3 class="title"><span>Zone Suite</span></h3>
                        <ul class="sublist">
                        
                     <li>Luxury bed</li>
<li>Large screen hd television</li>
<li>Hi-speed Wi-Fi connectivity</li>
<%--<li>Touch pad for in-room ordering, billing access and surfing</li>--%>
<li>Bathrooms with shower and toiletries</li>
<li>Fully loaded mini bar</li>
                        
                        </ul>
                        
                    <p><a href="http://www.zonebythepark.com/jaipur/rooms.php" target=_blank>More Details</a></p>
                        
                        <%--<p class="hotelprice"><span><i class="fa fa-rupee"></i>2,250</span> Per Night</p>--%>
                        <p class="btnwrap">
                        <!--<a href="#">Book Now</a>-->
                        <a href="#" data-toggle="modal" data-target="#bookingform">Book Now</a>
                        </p>
                        </div>
                    </div>
                    
                </div>
                
                <div class="row">
                <div class="col-md-8">
                	<p><strong>Check In</strong> @ 14:00, <strong>Check Out</strong>  @ 12:00</p>
                </div>
              
                </div>
                
          </div> <!-- end tab_royalst -->
          
          
          </div>
          </div>
          </div>
                <div class="row">
          	
            <div class="col-md-12">
            	
                <div class="tablewrap">
                	
                   

                    
                </div>
                
            </div>
            
          </div>
              </div>
            </div>
            
         
          </section><!-- end tab_tariff --> 
          
           <!--tab_restaurants -->
           <section id="hotel_tab3">
          		
                <div class="container restaurants">
                  <div class="row">
               <div class="col-md-12"><h2 class="title">Restaurants</h2>
               </div></div>
               
               <div class="row rowgap">
               <div class="col-md-4">
                <img src="Assets/images/hotel-zone/restaurant.jpg" class="img-responsive">
               </div> 
               <div class="col-md-8">
               <div class="rastraucontent">
                <h4 class="title"><span>Bazaar</span></h4>
                            
                            <p>Inspired by multi-hued charismatic native bazaars, bazaar is a potpourri of food, people and ideas. an open and free-flowing plan encourages the discovery of new experiences, both culinary and social.</p>
<p>Interactive service formats and live cooking stations such as the pizzeria and the wokerie open your mind to new flavours.</p>
<ul class="sublist">
    <li class="col-md-3 paddingleft0">Multi Cuisine</li>
    <li class="col-md-3 paddingleft0">Indian</li>
    <li class="col-md-3 paddingleft0">Chinese</li>
    <li class="col-md-3 paddingleft0">Continental</li>
</ul>
<p>The street cart lends a new perspective to street food with its dramatic chef and theatrical cooking style.</p>
                            
                            <ul class="sublist">
                           
                           
                           <li class="col-md-6 paddingleft0">Open 7:00 am to 11:30 pm</li>
<li class="col-md-6 paddingleft0">Breakfast: 7:00 am to 10:00 am</li>
<li class="col-md-6 paddingleft0">Lunch : 12:30 pm to 3:00 pm</li>
<li class="col-md-6 paddingleft0">Dinner : 7:30 pm to 11:30 pm</li>
                           
                            </ul>
                            </div>
               </div>
               </div>
               
                 <div class="row">
               <div class="col-md-4">
               <img src="Assets/images/hotel-zone/Zone-Playa.jpg" class="img-responsive">
               </div> 
               <div class="col-md-8">
             
             	<div class="rastraucontent">
                        	
                            
                           
                           <h4 class="title" style = "margin-top:15px;"><span>Playa by Zone (Rooftop restaurant & bar)</span></h4>
                           <p>A relaxing spot for drinks and dine, invites guests to mingle in a soothing social atmosphere.</p>
                           <ul class="sublist">
                           <li>Timings: 11:00 am to 11:00 pm</li>
                           </ul>
                           <p>Seductive aromas of mixed grills meet the gallant night sky at this exclusive rooftop indian grill and kebab restaurant.</p>
                           <ul class="sublist">
                           <li>Timings: 07:30 pm to 11:30 pm</li>
                           </ul>
                        </div>
             
               </div>
               </div>
               
                	<div class="row">
              
                    <div class="col-md-7">
                    
                    </div>
                    </div>
                </div>
                
          </section>
          <!--tab_restaurants -->
          
          <!--tab_facilities -->
           <section id="hotel_tab4" class="gray">
        		<%--<h2 class="title showonmobile">Facilities & Amenities</h2>--%>
                 <div class="container restaurants">
                	<div class="row">
                   
                    <div class="col-md-12">
                    	<div class="rastraucontent">
                        	
                        	
                        	
                        	  <div class="row">
                     <div class="col-md-4">
                     	 <div class="hotel_slider owl-carousel">
                        <div class="item"> <img src="Assets/images/hotel-zone/Zone-Swimming-Pool.jpg" class="img-responsive"></div>
                        <div class="item"> <img src="Assets/images/hotel-zone/Zone-Gym.jpg" class="img-responsive"></div>
                        <div class="item"> <img src="Assets/images/hotel-zone/Zone-Spa.jpg" class="img-responsive"></div>
                        </div>
                     </div>
                     
                     <div class="col-md-8">
                     <div><h2 class="title"><span>Facilities</span> &amp; <span>Amenities</span></h2></div>
                     
                     <div>
                        <div class="col-md-6">
                     	 <ul class="sublist">
                     	 <li>Luxury bed</li>
<li>Neat storage spaces and nooks</li>
<li>Fully integrated work desk area</li>
<li>Large screen hd television</li>
                  <li>Multimedia hub</li>
<li>Hi-speed Wi-Fi connectivity</li>
<li>Ipod docking station</li>
<%--<li>Touch pad for in-room ordering, billing access and surfing</li>--%>
<li>Touch screen controls lighting and temperature</li>
                      </ul>
                     </div>
                     
                       <div class="col-md-6">
                     	 <ul class="sublist">
                  
<li>Noise and light blackout</li>
<li>Fully loaded mini bar</li>
<li>Bathrooms with shower and toiletries</li>
<li>Swimming pool</li>
<li>Gym</li>
<li>Spa</li>
                      </ul>
                     </div>
                     
                     </div>
                     </div>
                     
                   
                     </div>
                        	
                        	
                        	
                         
                          
                        </div>
                    </div>
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
                  <img src="Assets/images/hotel-zone/Conference-Hall.jpg" class="img-responsive">
                  </div>
                   <div class="col-md-3">
                  <img src="Assets/images/hotel-zone/conference-room.jpg" class="img-responsive">
                  </div>
                  
                  <div class="col-md-6">
                    
                     <div>
                      <h2 class="title"><span>Banquet Hall / Conference Hall / Board Room</span></h2>
                      <p>Fully equipped and serviced meeting rooms and a boardroom offer a highly productive collaborative environment.</p>
                      <ul class="sublist">
                      	<li>Smart technologies with the latest audio visual equipment</li>
<li>Multi-dimensional banqueting spaces, services and brand signature cuisine concepts for any cultural preferences or group size.</li>
<li>Energetic and guest-centric service with innovative service designs.</li>
                      </ul>
                    </div>
                      
                      <!-- <img src="images/hotel-map.jpg" class="img-responsive">--> 
                   
                  
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
                  <iframe width="100%" height="500" src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d7114.075670090369!2d75.793935!3d26.934015!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x1f87f1cdec8518d5!2sZone+by+The+Park+Jaipur!5e0!3m2!1sen!2sin!4v1457955966554" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe> 
                 </div>
                  <div class="col-md-5 paddingleft0">
                   	
                      <div class="accessibility">
                      <h2 class="title"><span>Accessibility</span></h2>
                      <ul class="sublist">
                       <li>Airport - 13.6 kms</li>
<li>Railway station - 3 kms</li>
<li>Central bus station - 2 kms</li>
                      </ul>
                    </div>
                   <div class="contact-hotel">
                    <h2 class="title"><span>Get In Touch</span></h2>
                  
              <address>
              <div class="icondv"><i class="location"></i></div>
              <h3>Zone by the park</h3>
              <p>65 A, Bani park   <br>
               Madho Singh Road, Jaipur.
                </p>
            </address>
            <address>
              <div class="icondv"><i class="callus"></i></div>
              <h3>Call Us At</h3>
              <p>0141 4231000 </p>
            </address>
            
             <address>
              <div class="icondv"><i class="fax"></i></div>
              <h3>Fax No</h3>
              <p>0141 4231000</p>
            </address>
            
             <address>
              <div class="icondv"><i class="email"></i></div>
              <h3>Email Us At</h3>
              <p><a href="mailto:resv.jpr@zonebythepark.com">resv.jpr@zonebythepark.com</a> </p>
            </address>
            
             <address>
              <div class="icondv"><i class="web"></i></div>
              <h3>Website</h3>
              <p><a href="https://www.zonebythepark.com/jaipur/overview.php" target="_blank">www.zonebythepark.com/jaipur/overview.php</a> </p>
            </address>
                        
                  
                   </div>
                 
                  </div>
                </div>
              </div>
            </section>
            <!-- end tab_Accessibility-->
            
        
       
        
          </section>
        
        
         <!-- start of popup div -->
 
<div class="modal fade" id="bookingform">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
        <h4 class="modal-title">Book a Hotel</h4>
      </div>
      <div class="modal-body">
        <uc3:UcHotelInSouthern ID="UcHotelInSouthern1" runat="server" fldHotelType="2"/>
      </div>
    
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
 
 <!-- end of popup div -->
        
        </div>
      </div>
    </div>
    </div>
  
  </div>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    <script type="text/javascript">
        $('#fixedtabsection').scrollToFixed();
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
    </form>
</body>
</html>
