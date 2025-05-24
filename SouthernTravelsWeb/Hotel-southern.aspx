<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hotel-southern.aspx.cs" Inherits="SouthernTravelsWeb.Hotel_southern" %>


<%@ Register Src="UserControl/UcHolidaySearch.ascx" TagName="UCHolidaySearch" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcHotelInSouthern.ascx" TagName="UcHotelInSouthern" TagPrefix="uc3" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" itemscope itemtype="http://schema.org/TravelAgency" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Budget Hotels in Delhi | Accomodation in Delhi | Delhi Hotel | Budget Accomodation
        in New Delhi</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="Description" content="Hotel Southern - offers budget hotel accommodation in india, budget accommodation in delhi, budget accommodation in new delhi, hotel accommodations in delhi, budget accommodations in hotels of delhi, new delhi budget hotel accommodation, delhi budget hotel southern, budget hotels in delhi, budget hotel in delhi, delhi budget hotels, budget hotels in delhi." />
    <meta name="Keywords" content="budget hotel accommodation, budget hotel accommodation, budget hotels in india, hotel reservation in india, budget accommodation in india, hotel reservation in india, 3 star hotel in delhi, 3 star hotels delhi, 3 star hotels in delhi, 3star hotels in delhi, accommodation in delhi, accomodation in hotel, accomodation in india, budget accomadation, budget accommodation in delhi, budget hotel delhi, business hotels delhi, business hotels in delhi, cheap accommodation delhi, delhi accommodation, deluxe hotel in delhi, hotel accommodation delhi, hotel accomodation, hotel booking in delhi, hotels booking in delhi, low cost hotels in delhi" />
    <meta name="robots" content="index,follow" />
    <meta name="Author" content="Designed by www.sirez.com" />

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
     <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="HOTEL_DELHI"/>
  </div>
  </header>
    <!-- Main Content Start-->
    <section class="innersection2">
  <div style="display:none">
    <div id="fixedtabsection">
    <div class="container">
      <div class="row subheadrow">
        <div class="col-md-12">
          <h1 class="title">Our Own <span>Hotels</span> 
          <ul class="topheadingtabs">
          <li><a href="#" class="active">Hotel Southern, Delhi</a></li>   
          <li><a href="HotelSouthernGrandVijayawada.aspx">Southern Grand, Vijayawada</a></li>
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
					<img src="Assets/images/hotel-southern.jpg" class="img-responsive" loading="lazy"/>           
              </div>
              <div class="col-md-9">
              	<h3 class="title">Welcome to <span>Hotel Southern, New Delhi</span></h3>
                <p>Hotel Southern is a 'Friendly Hotel' located strategically in the heart of India's capital and in close proximity to Connaught Place. We are committed to providing personalized, professional guest service and 'genuine hospitality'. Our mission is to create loyal, satisfied customers who will return to our hotel repeatedly because of the quality and value offered.</p>
                <p class="btnwrap">
                <!--<a href="http://www.hotelsouthern.com">Book Now</a>-->
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
                    <li class="active"><a href="#tab_delux" data-toggle="tab" ><span>Deluxe</span></a></li>
                    <li><a href="#tab_superdelux" data-toggle="tab"><span>Super Deluxe</span></a></li>
                    <li><a href="#tab_executive" data-toggle="tab"><span>Executive Room</span> </a></li>
                    <li><a href="#tab_royalst" data-toggle="tab"><span>Royal Southern</span></a></li>
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
                        <div class="item"><img src="Assets/images/hotels/deluxe1.jpg" class="img-responsive" loading="lazy"/></div>
                        <div class="item"><img src="Assets/images/hotels/deluxe2.jpg" class="img-responsive" loading="lazy"/></div>
                        </div>
                    </div>
                    
                    <div class="col-md-4">
                    	<div class="txtsection">
                        <h3 class="title"><span>Deluxe</span> </h3>
                        <ul class="sublist">
                        
                       <li> Buffet Breakfast</li>
<li>Pickup from Station ( New Delhi/ Nizamuddin Station )</li>
<li>Internet/Wi-Fi Facility</li>
                        
                        </ul>
                        <p class="hotelprice"><span><i class="fa fa-rupee"></i>2090 / $32</span> Per Night</p>
                        <p class="btnwrap">
                        <!--<a href="http://www.hotelsouthern.com/best-hotel-deluxe-room-delhi.html" target="_blank">Book Now</a>-->
                         <a href="#" data-toggle="modal" data-target="#bookingform">Book Now</a>
                        
                        </p>
                        </div>
                    </div>
                    
                </div>
                
                <div class="row">
                <div class="col-md-8">
                	<p><strong>Note:</strong> <ol>
<li>Children under the age of 6-10 years sharing parent's room shall not be charged for accommodation. However if extra bed is required extra person rate mentioned below will be applicable. A nominal amount of <i class="fa fa-rupee"></i> 145/- net, $ 2 to 3 is charged towards buffet breakfast per children under the age of 6-10 years.</li>
<li>Children sharing parent's room below the age of 6 years will not be charged for extra person.</li>
<li>Complimentary breakfast will be provided for the extra person charged.</li>
</ol></p>
                </div>
                <div class="col-md-4">
                <p><strong>Check Out :</strong> 8.00 AM / 12 noon (as per check in time)<br>
<strong>Note:</strong>  24.00 % Taxes are applicable for all above tariffs.</p>
                </div>
                </div>
                
          </div> <!-- end tab_delux -->
          
          <!-- tab_superdelux -->
          <div class="tab-pane" id="tab_superdelux">
          		
                <div class="row rowgap">
                	<div class="col-md-8">
                    	<div class="hotel_slider owl-carousel">
                        <div class="item"><img src="Assets/images/hotels/superdeluxe1.jpg" class="img-responsive" loading="lazy"/></div>
                        
                        </div>
                    </div>
                    
                    <div class="col-md-4">
                    	<div class="txtsection">
                        <h3 class="title"><span>Super Deluxe</span> </h3>
                        <ul class="sublist">
                        <li>Buffet Breakfast</li>
						<li>Pickup from Airport/ Station ( New Delhi/ Nizamuddin )</li>
						<li>Internet/Wi-Fi Facility</li>
						<li>Mineral Water</li>
						<li>Tea Coffee Maker</li>
						<li>Refrigerator</li>
                        </ul>
                        <p class="hotelprice"><span><i class="fa fa-rupee"></i>2390 / $37</span> Per Night</p>
                        <p class="btnwrap">
                        <!--<a href="http://www.hotelsouthern.com/super-deluxe-hotel-room-delhi.html">Book Now</a>-->
                         <a href="#" data-toggle="modal" data-target="#bookingform">Book Now</a>
                        </p>
                        </div>
                    </div>
                    
                </div>
                
                <div class="row">
                <div class="col-md-8">
                	<p><strong>Note:</strong> <ol>
<li>Children under the age of 6-10 years sharing parent's room shall not be charged for accommodation. However if extra bed is required extra person rate mentioned below will be applicable. A nominal amount of <i class="fa fa-rupee"></i> 145/- net, $ 2 to 3 is charged towards buffet breakfast per children under the age of 6-10 years.</li>
<li>Children sharing parent's room below the age of 6 years will not be charged for extra person.</li>
<li>Complimentary breakfast will be provided for the extra person charged.</li>
</ol></p>
                </div>
                <div class="col-md-4">
                <p><strong>Check Out :</strong> 8.00 AM / 12 noon (as per check in time)<br>
<strong>Note:</strong>  24.00 % Taxes are applicable for all above tariffs.</p>
                </div>
                </div>
                
          </div> <!-- end tab_superdelux -->
          
           <!-- tab_executive -->
          <div class="tab-pane" id="tab_executive">
          		
                <div class="row rowgap">
                	<div class="col-md-8">
                    	<div class="hotel_slider owl-carousel">
                        <div class="item"><img src="Assets/images/hotels/executive1.jpg" class="img-responsive" loading="lazy"/></div>
                        <div class="item"><img src="Assets/images/hotels/executive2.jpg" class="img-responsive" loading="lazy"/></div>
                        <div class="item"><img src="Assets/images/hotels/executive3.jpg" class="img-responsive" loading="lazy"/></div>
                        </div>
                    </div>
                    
                    <div class="col-md-4">
                    	<div class="txtsection">
                        <h3 class="title"><span>Executive Room</span> </h3>
                        <ul class="sublist">
                       <li>Buffet Breakfast</li>
<li>Pickup from Airport/ Station ( New Delhi/ Nizamuddin )</li>
<li>Internet/Wi-Fi Facility</li>
<li>Mineral Water</li>
<li>Tea Coffee Maker</li>
<li>Refrigerator</li>
                        </ul>
                        <p class="hotelprice"><span><i class="fa fa-rupee"> </i>2690 / $42</span> Per Night</p>
                        <p class="btnwrap">
                        <!--<a href="http://www.hotelsouthern.com/book-executive-suite-rooms-delhi.html">Book Now</a>-->
                         <a href="#" data-toggle="modal" data-target="#bookingform">Book Now</a>
                        </p>
                        </div>
                    </div>
                    
                </div>
                
                <div class="row">
                <div class="col-md-8">
                	<p><strong>Note:</strong> <ol>
<li>Children under the age of 6-10 years sharing parent's room shall not be charged for accommodation. However if extra bed is required extra person rate mentioned below will be applicable. A nominal amount of <i class="fa fa-rupee"></i> 145/- net, $ 2 to 3 is charged towards buffet breakfast per children under the age of 6-10 years.</li>
<li>Children sharing parent's room below the age of 6 years will not be charged for extra person.</li>
<li>Complimentary breakfast will be provided for the extra person charged.</li>
</ol></p>
                </div>
                <div class="col-md-4">
                <p><strong>Check Out :</strong> 8.00 AM / 12 noon (as per check in time)<br>
<strong>Note:</strong>  24.00 % Taxes are applicable for all above tariffs.</p>
                </div>
                </div>
                
          </div> <!-- end tab_executive -->
          
          
            <!-- tab_royalst -->
          <div class="tab-pane" id="tab_royalst">
          		
                <div class="row rowgap">
                	<div class="col-md-8">
                    	<div class="hotel_slider owl-carousel">
                        <div class="item"><img src="Assets/images/hotels/royal1.jpg" class="img-responsive" loading="lazy"/></div>
                        <div class="item"><img src="Assets/images/hotels/royal2.jpg" class="img-responsive" loading="lazy"/></div>
                        <div class="item"><img src="Assets/images/hotels/royal3.jpg" class="img-responsive" loading="lazy"/></div>
                        </div>
                    </div>
                    
                    <div class="col-md-4">
                    	<div class="txtsection">
                        <h3 class="title"><span>Royal Southern</span></h3>
                        <ul class="sublist">
                      <li>Buffet Breakfast</li>
                    <li>Pickup from Airport/ Station ( New Delhi/ Nizamuddin )</li>
                    <li>Internet/Wi-Fi Facility</li>
                    <li>Mineral Water</li>
                    <li>Tea Coffee Maker</li>
                    <li>Refrigerator</li>
                        </ul>
                        <p class="hotelprice"><span><i class="fa fa-rupee"> </i>3490 / $56</span> Per Night</p>
                        <p class="btnwrap">
                        <!--<a href="http://www.hotelsouthern.com/budget-hotel-room-royal-southern-delhi.html">Book Now</a>-->
                         <a href="#" data-toggle="modal" data-target="#bookingform">Book Now</a>
                        </p>
                        </div>
                    </div>
                    
                </div>
                
                <div class="row">
                <div class="col-md-8">
                	<p><strong>Note:</strong> <ol>
<li>Children under the age of 6-10 years sharing parent's room shall not be charged for accommodation. However if extra bed is required extra person rate mentioned below will be applicable. A nominal amount of <i class="fa fa-rupee"></i> 145/- net, $ 2 to 3 is charged towards buffet breakfast per children under the age of 6-10 years.</li>
<li>Children sharing parent's room below the age of 6 years will not be charged for extra person.</li>
<li>Complimentary breakfast will be provided for the extra person charged.</li>
</ol></p>
                </div>
                <div class="col-md-4">
                <p><strong>Check Out :</strong> 8.00 AM / 12 noon (as per check in time)<br>
<strong>Note:</strong>  24.00 % Taxes are applicable for all above tariffs.</p>
                </div>
                </div>
                
          </div> <!-- end tab_royalst -->
          
          
          </div>
          </div>
          </div>
                <div class="row">
          	
            <div class="col-md-12">
            	
                <div class="tablewrap">
                	
                    <table width="100%" border="0" class="table-bordered">
  <tr>
    <th>Room Type</th>
    <th>INR</th>
    <th>USD</th>
  </tr>


  <tr>
    <td>Deluxe</td>
    <td><i class="fa fa-rupee"></i> 2,090/-</td>
    <td> $ 32/-</td>
    
  </tr>
  <tr>
    <td>Super Deluxe</td>
    <td><i class="fa fa-rupee"></i> 2,390/-</td>
    <td> $ 37/-</td>
    
  </tr>
  
   <tr>
    <td>Executive Deluxe</td>
     <td><i class="fa fa-rupee"></i> 2,690/-</td>
    <td> $ 42/-</td>
      </tr>
  
   <tr>
    <td>Family Suite</td>
     <td><i class="fa fa-rupee"></i> 4,390/-</td>
    <td> $ 80/-</td>
      </tr>
  
   <tr>
    <td>Royal Southern</td>
     <td><i class="fa fa-rupee"></i> 3,490/-</td>
    <td> $ 56/-</td>
      </tr>
  
   <tr>
    <td>Extra Person (above 10 years)</td>
    <td><i class="fa fa-rupee"></i> 600/-</td>
     <td> $ 10/-</td>
      </tr>
  
   <tr>
    <td>Breakfast charges (6-10 years)</td>
    <td><i class="fa fa-rupee"></i> 147/-</td>
     <td> $ 2 to 3/-</td>
      </tr>
  
   <tr>
    <td>Breakfast sharing with parents (under 6 years)</td>
    <td>No Charges</td>
     <td>No Charges</td>
      </tr>
  
  

</table>

                    
                </div>
                
            </div>
            
          </div>
              </div>
            </div>
            
         
          </section><!-- end tab_tariff --> 
          
           <!--tab_restaurants -->
           <section id="hotel_tab3">
          		<%--<h2 class="title showonmobile">Restaurants</h2>--%>
                <div class="container restaurants">
                	<div class="row">
                    <div class="col-md-5"><img src="Assets/images/restaurants.jpg" class="img-responsive" loading="lazy"/></div>
                    <div class="col-md-7">
                    	<div class="rastraucontent">
                        	<h2 class="title"><span>Restaurants</span></h2>
                            <h4 class="title"><span>Adyar Ananda Bhavan 'A2B Veg Restaurant'</span><br>Centrally Air-Conditioned. Serves the best South & North Indian /Chinese, Vegetarian & Cuisine.</h4>
                            <%--<p>Our Speciailties are :</p>
                            <ul class="sublist">
                            <li>South Indian Thali (Meals)</li>
<li>A2B South Indian Platter</li>
<li>Mini Meal</li>
<li>Parotta Khurma</li>
<li>Spring Roll Dosa</li>
<li>North Indian Thali</li>
<li>Room Service Available</li>
                            </ul>--%>
                            <div class="timing">
                            	<div class="displayinline redcolor">Open</div>
                                <div class="displayinline">11.00 AM TO 03.30 PM<br>07.30 PM TO 10.30 PM</div>
                            </div>
                            <div class="roomservice">
                            	<h4 class="title"><span>Room Service Available :</span></h4>
                                <p><strong>Location :</strong> In Hotel - First Floor<br>
									<strong>Serves  :</strong> Lunch | Dinner</p>
                            </div>
                        </div>
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
                        	<h2 class="title"><span>Amenities</span></h2>
                        	
                        	
                        	  <div class="row">
                     <div class="col-md-4">
                     	 <ul class="sublist">
                    
<li>100 (available) Newly furnished rooms with modern amenities</li>
                            <li>Lift, EPABX ,Cloak Room</li>
                            <li>100 channel cable TV with Remote</li>
                            <li>Laundry & Dry Cleaning</li>
                            <li>Doctor on call</li>
                            <li>Safe Deposit Lockers</li>

                      </ul>
                     </div>
                     
                      <div class="col-md-4">
                     	 <ul class="sublist">
                      <li>Refrigerator in Super Deluxe & Suits</li>
                            <li>Tea/Coffee Making facility in Super Deluxe & Suits</li>
                            <li>Power Supply 220 Volts</li>
                            <li>24 Hrs. Tea/Coffee ,Snacks Bar</li>
                            <li>Internet Access through "Wi fi"</li>

                      </ul>
                     </div>
                     
                       <div class="col-md-4">
                     	 <ul class="sublist">
                       <li>24 Hrs. Power Backup</li>
                            <li>All Major Credit cards accepted</li>
                            <li>Currency exchange Facility.</li>
                            <li>24 Hours Business Services : Xerox, Fax, Courier Service, E-mail & Internet, STD/ISD,</li>
                            <li>Mobile Phones Charger facility</li>
                      </ul>
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
                  <div class="col-md-5">
                   <img src="Assets/images/conference.jpg" class="img-responsive"  loading="lazy"/>
                   
                  </div>
                  <div class="col-md-7">
                    
                     <div>
                      <h2 class="title"><span>Banquet Hall / Conference Hall</span></h2>
                       <ul class="sublist">
                
                <li>We provide exclusive conference facility, offers elegant conference rooms with seating capacities ranging from 40 to 100 conferees.</li>
<li>Available for Conference, Board Meeting, Birthdays, Kitty parties & Get together.</li>
<li>We can customize the seating arrangement into Theatre, Cluster, U-shaped, Conference as per the requirements.</li>
<li>Conference rooms are tastefully decorated, centrally air conditioned with 100% back
up along with facilities like ample parking space, pantry services, telephone, fax, internet
access, computers and laptop. A single point of contact is provided to each customer to
ensure smooth and hassle free conferencing experience.</li>
                
                </ul>
                    </div>
                      
                  
                  
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
                  <iframe width="100%" height="600" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?hl=en&amp;ie=UTF8&amp;q=hotel+southern&amp;fb=1&amp;hq=hotel+southern&amp;cid=0,0,4776325580920556916&amp;hnear=&amp;ll=28.646383,77.195468&amp;spn=0.006295,0.006295&amp;t=m&amp;iwloc=A&amp;output=embed"> </iframe>
                 </div>
                  <div class="col-md-5 paddingleft0">
                   	
                      <div class="accessibility">
                      <h2 class="title"><span>Accessibility</span></h2>
                       <ul class="sublist">
                
                <li>9 Kms from Nizamuddin Railway Station</li>
<li>2 Kms from New Delhi Railway Station</li>
<li>14 Kms from Domestic Airport</li>
<li>19 Kms from International Airport</li>
<li>5 Minutes walk from Jhandewalan Metro Rail Station.</li>
                
                </ul>
                    </div>
                   <div class="contact-hotel">
                    <h2 class="title"><span>Get In Touch</span></h2>
                  
              <address>
              <div class="icondv"><i class="location"></i></div>
              <h3> A unit of Southern Travels Pvt. Ltd.</h3>
              <p>18/2, Arya Samaj Road, W.E.A Karol Bagh,
 <br>
                 New Delhi-110005 (INDIA)</p>
            </address>
            
            <address>
              <div class="icondv"><i class="callus"></i></div>
              <h3>Call Us At</h3>
              <p>+(91)+(11)+41450200 <br>+(91)+(11)+43532828 (100lines) 28754210, 28754213, 28756724, 28751075  </p>
            </address>
            
           
             <address>
              <div class="icondv"><i class="fax"></i></div>
              <h3>Fax</h3>
              <p> +(91)+(11)+28757308 </p>
            </address>
           
            
             <address>
              <div class="icondv"><i class="email"></i></div>
              <h3>Email Us At</h3>
              <p><a href="mailto:info@hotelsouthern.com">info@hotelsouthern.com</a> </p>
            </address>
                        
             
               <address>
              <div class="icondv"><i class="web"></i></div>
              <h3>Website</h3>
              <p><a href="http://www.hotelsouthern.com" target="_blank">www.hotelsouthern.com </a> </p>
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
<%--<iframe id="Ihotelsouthern" style="width:100%; background-color:#e0effb; height:600px" frameborder="0" allowfullscreen  src="http://www.hotelsouthern.com/index.html"></iframe>--%>

 <!-- start of popup div -->
 
<div class="modal fade" id="bookingform" style="display:none">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
        <h4 class="modal-title">Book a Hotel</h4>
      </div>
      <div class="modal-body">
       <uc3:UcHotelInSouthern ID="UcHotelInSouthern1" runat="server" />
        
      </div>
    
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
 
 <!-- end of popup div -->
 
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

    <!--Install Crazy Egg code for Tracking Visitor Behavior-->

    <script type="text/javascript">
        setTimeout(function() {
            var a = document.createElement("script");
            var b = document.getElementsByTagName('script')[0];
            a.src = document.location.protocol + "//dnn506yrbagrg.cloudfront.net/pages/scripts/0011/9178.js?" + Math.floor(new Date().getTime() / 3600000);
            a.async = true; a.type = "text/javascript"; b.parentNode.insertBefore(a, b)
        }, 1);
        
    </script>

</body>
</html>

