<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTourShortInfo.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcTourShortInfo" %>

<%@ Register Src="UcBlogInnerPages.ascx" TagName="ucBlog" TagPrefix="uc2" %>
<%@ Register Src="UcPrintMailSms.ascx" TagName="UCPrintMailSms" TagPrefix="uc1" %>
<%@ Register Src="UcIntLeftUC.ascx" TagName="IntLeftUC" TagPrefix="uc2" %>

<script src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>

<script type="text/javascript">
    var map = null;
    var ZoomL = null;
    var Lat = null;
    var Logi = null;
    var counterID = 0;
    function getQuerystring(key, default_) {
        if (default_ == null) default_ = "";
        key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
        var qs = regex.exec(window.location.href);
        if (qs == null)
            return default_;
        else
            return qs[1];
    }
    //=================================================Get URLDecod Value==================================================================

    function URLDecode(encodedString) {
        var output = encodedString;
        var binVal, thisString;
        var myregexp = /(%[^%]{2})/;
        while ((match = myregexp.exec(output)) != null
            && match.length > 1
            && match[1] != '') {
            binVal = parseInt(match[1].substr(1), 16);
            thisString = String.fromCharCode(binVal);
            output = output.replace(match[1], thisString);
        }
        return output;
    }
</script>

<script type="text/javascript">

    var rendererOptions = {
        draggable: true
    };
    var directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions);;
    var directionsService = new google.maps.DirectionsService();
    var map;



    function initialize() {

        var mapOptions = {

            mapTypeId: google.maps.MapTypeId.ROADMAP

        };
        map = new google.maps.Map(document.getElementById('myMap'), mapOptions);
        directionsDisplay.setMap(map);
        //directionsDisplay.setPanel(document.getElementById('directionsPanel'));

        google.maps.event.addListener(directionsDisplay, 'directions_changed', function () {
            computeTotalDistance(directionsDisplay.directions);
        });

        calcRoute();
    }

    function calcRoute() {


        var Route = "";
        //Route ='27.191930770874,77.9975280761719@27.4930095672607,77.6729736328125';
        Route = document.getElementById("<%=hdGeoCode.ClientID  %>").value;
        var RoutepUs = document.getElementById("<%=hdRoutepUs.ClientID  %>").value;

        if (RoutepUs == '1') {
            var waypts = [];
            var Route1 = Route.split('@');
            var points = new Array();
            for (i = 0; i < Route1.length; i++) {
                if (i > 0 && i < Route1.length - 1) {
                    waypts.push({
                        location: Route1[i],
                        stopover: true
                    });
                }
            }
            var start = Route1[0];
            var end = Route1[Route1.length - 1];

            var request = {
                origin: start,
                destination: end,
                waypoints: waypts,
                travelMode: google.maps.DirectionsTravelMode.DRIVING
            };
            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                }
            });
        }
        else {
            var lRoute = Route.split(',');
            var lati = lRoute[0];
            var longi = lRoute[1];
            var Company = document.getElementById("<%=hdCity.ClientID  %>").value;

            var map = new google.maps.Map(document.getElementById('myMap'), {
                zoom: 13,
                center: new google.maps.LatLng(lati, longi),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });

            var infoWindow = new google.maps.InfoWindow;

            var onMarkerClick = function () {
                var marker = this;
                var latLng = marker.getPosition();

                infoWindow.setContent('<h3>City Information :</h3>' + '<p>' + Company + '</p>' +
                    latLng.lat() + ', ' + latLng.lng());

                infoWindow.open(map, marker);
            };
            google.maps.event.addListener(map, 'click', function () {
                infoWindow.close();
            });

            var marker1 = new google.maps.Marker({
                map: map,
                position: new google.maps.LatLng(lati, longi)
            }); google.maps.event.addListener(marker1, 'click', onMarkerClick);
        }
    }

    function computeTotalDistance(result) {
        var total = 0;
        var myroute = result.routes[0];
        for (i = 0; i < myroute.legs.length; i++) {
            total += myroute.legs[i].distance.value;
        }
        total = total / 1000.
        //document.getElementById('total').innerHTML = total + ' km';
    }

</script>

<script type="text/javascript">
    function PrintPage() {


        var Path = "Print.htm";
        var RoutepUs = document.getElementById("<%=hdRoutepUs.ClientID  %>").value;
        if (RoutepUs == '2') {
            window.open("Print.htm?GeoCode=" + document.getElementById("<%=hdGeoCode.ClientID  %>").value + "&City=" + document.getElementById("<%=hdCity.ClientID  %>").value + "&Alpha=" + document.getElementById("<%=hdAlpha.ClientID  %>").value + "&RoutepUs=" + RoutepUs, "mywindow", "width=600,height=620,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,copyhistory=no,resizable=yes,top=100,screenX=0,screenY=100");
        }
        else {
            window.open("Print.htm?GeoCode=" + document.getElementById("<%=hdGeoCode.ClientID  %>").value + "&City=" + document.getElementById("<%=hdCity.ClientID  %>").value + "&Alpha=" + document.getElementById("<%=hdAlpha.ClientID  %>").value, "mywindow", "width=600,height=620,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,copyhistory=no,resizable=yes,top=100,screenX=0,screenY=100");
        }



    }
</script>

<div id="fixedtabsection">
    <div class="row subheadrow">
        <div class="col-md-12">
            <h1 class="title uppercase">
                <span>
                    <asp:Literal ID="ltrTourName" runat="server"></asp:Literal></span><br />
                    <%if (fldTourTypeID == 1 && fldTourID == 0)
                      {%>
                <span class = "smallheadtxt">(Operated by Andhra Pradesh Tourism Development Corp. Govt. of A.P.)</span>
                <%} %>
                <%--<asp:Literal ID="lblCoachDetails" runat="server"></asp:Literal>BY AC VOLVO--%>
                <%--<ul class="sharelist">
        <li><a href="https://www.facebook.com/SouthernTravels/" target="_blank" class="fb"></a></li>
        <li><a href="https://twitter.com/happyholidaying"  target="_blank" class="tw"></a></li>
        <li><a href="https://plus.google.com/b/105500167792879378506/105500167792879378506/posts"  target="_blank" class="gplus"></a></li>
        <li><a href="#" class="more"></a></li>
        </ul>--%>
                <ul class="sharelist hideonmobile">
                    <li><a class="addthis_button_preferred_1"></a></li>
                    <li><a class="addthis_button_preferred_2"></a></li>
                    <li><a class="addthis_button_preferred_3"></a></li>
                    <li><a class="addthis_button_preferred_4"></a></li>
                    <li><a class="addthis_button_compact"></a></li>
                    <li><a class="addthis_counter addthis_bubble_style"></a></li></ul>
<!-- Go to www.addthis.com/dashboard to generate a new set of sharing buttons -->
<!-- Go to www.addthis.com/dashboard to generate a new set of sharing buttons -->
<!-- Go to www.addthis.com/dashboard to generate a new set of sharing buttons -->

<%--<ul class="sharelist  hideonmobile">
<li><a href="https://api.addthis.com/oexchange/0.8/forward/facebook/offer?url=http%3A%2F%2Fwww.addthis.com&pubid=ra-570f1ce0bd2fe442&ct=1&title=AddThis%20-%20Get%20likes%2C%20get%20shares%2C%20get%20followers&pco=tbxnj-1.0" target="_blank"><img src="https://cache.addthiscdn.com/icons/v3/thumbs/32x32/facebook.png" border="0" alt="Facebook"/></a>
</li><li><a href="https://api.addthis.com/oexchange/0.8/forward/twitter/offer?url=http%3A%2F%2Fwww.addthis.com&pubid=ra-570f1ce0bd2fe442&ct=1&title=AddThis%20-%20Get%20likes%2C%20get%20shares%2C%20get%20followers&pco=tbxnj-1.0" target="_blank"><img src="https://cache.addthiscdn.com/icons/v3/thumbs/32x32/twitter.png" border="0" alt="Twitter"/></a>
</li><li><a href="https://api.addthis.com/oexchange/0.8/forward/email/offer?url=http%3A%2F%2Fwww.addthis.com&pubid=ra-5073e7951ddeab53&ct=1&title=AddThis%20-%20Get%20likes%2C%20get%20shares%2C%20get%20followers&pco=tbxnj-1.0" target="_blank"><img src="https://cache.addthiscdn.com/icons/v3/thumbs/32x32/email.png" border="0" alt="Email"/></a>
</li><li><a href="https://api.addthis.com/oexchange/0.8/forward/print/offer?url=http%3A%2F%2Fwww.addthis.com&pubid=ra-5073e7951ddeab53&ct=1&title=AddThis%20-%20Get%20likes%2C%20get%20shares%2C%20get%20followers&pco=tbxnj-1.0" target="_blank"><img src="https://cache.addthiscdn.com/icons/v3/thumbs/32x32/print.png" border="0" alt="Print"/></a>
</li><li><a href="https://www.addthis.com/bookmark.php?source=tbx32nj-1.0&v=300&url=http%3A%2F%2Fwww.addthis.com&pubid=ra-570f1ce0bd2fe442&ct=1&title=AddThis%20-%20Get%20likes%2C%20get%20shares%2C%20get%20followers&pco=tbxnj-1.0" target="_blank"><img src="https://cache.addthiscdn.com/icons/v3/thumbs/32x32/addthis.png" border="0" alt="Addthis"/></a>
</li></ul>--%>
<%--                    <script type="text/javascript" src="https://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-5073e7951ddeab53"></script>--%>

               
            </h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="tabsection_inner">
                <div class="btnbooknow" runat="server" id="divhBook">
                    <%if (fldTourTypeID == 1)
                      {%>
                    <a href='TourBooking.aspx?TourID=<%= Page.RouteData.Values["tourId"] %>#DateSelect'>Book
                        now</a>
                        <asp:Button ID="BtnDomesticEnq" runat="server" Text="Enquire Now" class="commonbtn" style="font-size: 14px;line-height: 1.42857143;" />
                    <%} %>
                    <%else if (fldTourTypeID == 2)
                        {%>
                    <a href='BookSpecialTour.aspx?TourID=<%= Page.RouteData.Values["tourId"] %>#DateSelect'>
                        Book now</a>
                    <%} %>
                    <%else if (fldTourTypeID == 3)
                        {%>
                    <%--<a href='International-Packages.aspx'>Book now</a>--%>
                    <asp:Button ID="BtnIntEnq" runat="server" Text="Enquire Now" class="commonbtn" style="font-size: 14px;line-height: 1.42857143;"/>
                    
                    <%} %>
                </div>
                <ul class="nav nav-tabs">
                    <%if (fldTourTypeID != 3)
                      {%>
                    <li class='<%= fldCanBook== false ?"active":""  %>'><a href="#tab_itinerary" data-toggle="tab">
                        Itinerary</a></li>
                    <li class='<%= fldCanBook== true ?"active":""  %>'><a href="#tab_dateprice" data-toggle="tab">
                        Date & Price Info</a></li>
                    <%}
                      else
                      { %>
                    <li class='<%= fldCanBook== true ?"active":"active"  %>'><a href="#tab_itinerary"
                        data-toggle="tab">Itinerary</a></li>
                    <li class='<%= fldCanBook== false ?"":""  %>'><a href="#tab_dateprice" data-toggle="tab">
                        Date & Price Info</a></li>
                    <%} %>
                    <%if (fldTourTypeID != 1)
                      {%>
                    <li><a href="#tab_inclexcl" data-toggle="tab">Inclusions/Exclusions</a></li>
                    <%} %>
                    <li><a href="#tab_tourinfo" data-toggle="tab">Tour Info</a></li>
                    <%if (fldTourTypeID != 3)
                      {%>
                    <li><a href="#tab_tourPlaces" data-toggle="tab">Places Covered</a></li>
                    <%} %>
                    <%--<li><a href="#tab_tourinfo" data-toggle="tab">Tour Info</a></li>--%>
                    <%if (fldTourTypeID != 1 && fldTourTypeID != 2 && fldTourTypeID != 3)
                      {%>
                    <li><a href="#tab_terms" data-toggle="tab">Terms</a></li>
                    <%} %>
                    <li><a href="#tab_similar" data-toggle="tab">Similar Packages</a></li>
                    <%if (fldTourTypeID != 3)
                      {%>
                    <li><a href="#tab_gallery" data-toggle="tab">Tour Gallery</a></li>
                    <%} %>
                    <%--<li><a href="#tab_testimonial" data-toggle="tab">Guest Gallery</a></li>--%>
                    <li><a href="javascript:return void(0)" data-toggle="tab">Guest Gallery</a></li>
                </ul>
            </div>
        </div>
    </div>
</div>
<div class="row tabspace ">
    <div class="col-md-4">
        <div class="itineraryleft">
            <section class='<%= fldCanBook== true ?"hidbookingnmobile":""  %>'>
<div class="itinerarydtl">
      	<h2 runat="server" id="fare"><i class="fa fa-rupee"></i> &nbsp;<asp:Literal ID="litCost" runat=server></asp:Literal> <span>(Onwards per person)</span></h2>
        <ul class="tourdetail">
        	<li class="tourcode"><i class="fa fa-map-marker"></i> Tour Code : <asp:Literal ID="litTourCode" runat="server"></asp:Literal></li>
            <li class="days"><i class="fa fa-calendar"></i> <asp:Literal ID="litDay" runat=server>/</asp:Literal></li>
             <%if (fldTourTypeID != 3)
               {%>
            <asp:Literal ID="litDepart" runat="server"></asp:Literal>
            <asp:Literal ID="litReturn" runat="server"></asp:Literal>
            <%} %>
        </ul>
        <ul class="holidaytype">
        	<li><i class="fa fa-arrow-right"></i> Holiday Category :<br><span><asp:Literal ID="litCatogory" runat=server></asp:Literal></span></li>
             
            <li><i class="fa fa-arrow-right"></i> Holiday Type :<br><span><asp:Literal ID="litType" runat=server></asp:Literal></span></li>
             
            <li><i class="fa fa-arrow-right"></i> <%if (fldTourTypeID != 3)
                                                    {%>States<%} %><%else
                                  {%>Country<%} %> :<br><span><asp:Literal ID="litStates" runat=server></asp:Literal></span></li>
            
            <li><i class="fa fa-arrow-right"></i> <%if (fldTourTypeID != 3)
                                                    {%>Places<%} %><%else
                                  {%>City<%} %> Covered :<br><span><asp:Literal ID="litCovered" runat=server></asp:Literal>
              <%if (fldTourTypeID != 3)
                {%>
            <asp:Literal ID="ltrTourPolicy" runat=server></asp:Literal></span></li> 
            <%if (fldTourTypeID != 3 && fldTourTypeID != 2)
              {%>
            <asp:Literal ID="ltrRemarks" runat="server" Visible="false"  ></asp:Literal>   
             <%} %>
            <%} %>
        </ul>
         <%if (fldTourTypeID != 2)
           {%>
        <p><asp:Literal ID="litCoachDetails" runat=server></asp:Literal></p>
        <%} %>
        <p  runat="server" id ="AcvBook">
        
            &nbsp;
        
         <div class="btnbooknow"  runat="server" id ="div1">
        <%if (fldTourTypeID == 1)
          {%>
       <a href='TourBooking.aspx?TourID=<%= Page.RouteData.Values["tourId"] %>' class="bookbtn">Book Now</a>
        <%} %>
        <%else if (fldTourTypeID == 2)
            {%>
        <a href='BookSpecialTour.aspx?TourID=<%= Page.RouteData.Values["tourId"] %>' class="bookbtn">Book now</a>
        <%} %>
         <%else if (fldTourTypeID == 3)
             {%>
        <a href='International-Packages.aspx' class="bookbtn">Book now</a>
        <%} %>
        </div>
        </p>
        
        <p class="text-align-right">
        <%if (fldTourTypeID == 3)
          { %>
        <a href="International-Terms-Conditions.aspx">Terms and Conditions <i class="fa fa-angle-double-right"></i></a>
        <%}
          else
          { %>
          <a href="Terms-Conditions.aspx">Terms and Conditions <i class="fa fa-angle-double-right"></i></a>
        <%} %>
        </p>
        
</div>
<uc1:UCPrintMailSms ID="UCPrintMailSms1" runat="server" />
</section>
            <%if (fldTourTypeID == 3)
              {%>
            <section>
            <div class="accordionwrap">
            <uc2:IntLeftUC ID="IntLeftUC2" runat="server" />
              
            </div>
          </section>
            <%} %>
            <section>
<%if (fldTourTypeID != 3)
  {%>            
      <div class="mapdiv">
      <asp:HiddenField ID="hdGeoCode" runat="server" />
    <asp:HiddenField ID="hdRoutepUs" runat="server" Value="2" />
    <asp:HiddenField ID="hdCity" runat="server" />
    <asp:HiddenField ID="hdAlpha" runat="server" />
    <div id="myMap" style="position: relative; width: 100%; height: 245px; float: left;">

        <script type="text/javascript">
            var PathL = "<center><img alt='' loading='lazy' src='";
            PathL += "Assets/images/loader.gif'/><br/></center>";
            document.write('<div id="loading" style="position: absolute; float: right; z-index: 2; margin-left: 110px; margin-top:100px;"> ' + PathL + '</div>');
        </script>

    </div>  <p>
                                    <small>
                                        <%--<asp:LinkButton ID="btnViewLarger" CssClass="inverse" runat="server" OnClientClick="return PrintPage();"
                                            Style="font-size: 12px;"><strong>View Larger Map</strong></asp:LinkButton>--%>
                                        <a href="#" style="font-size: 12px;" onclick="return PrintPage();" class="inverse"><strong>
                                            View Larger Map</strong></a></small></p>
      <%--<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d13386.88252085959!2d74.92184398999579!3d32.98477169363976!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x391e78e6316b55cb%3A0xf3ea3335c5a9638!2sKatra+182301!5e0!3m2!1sen!2sin!4v1455176424025" width="380" height="240" frameborder="0" style="border:0" allowfullscreen></iframe>--%>
      </div>
      <%} %>
      </section>
            <%-- <section>
      	<div class="youmaylike">
        <h2 class="title">You May Also <span>Like</span></h2>
        	<!-- slider -->
            <!-- <img src="images/youmaylike/1.jpg" class="img-responsive"> -->
            
             <div id="like-slider" class="owl-carousel">
          <div class="item"> 
          <img src="images/youmaylike/1.jpg" alt="Touch">
            
          </div>
           <div class="item"> 
         <img src="images/youmaylike/1.jpg" alt="Touch">
          
          </div>
          
           <div class="item"> 
          <img src="images/youmaylike/1.jpg" alt="Touch">
           
          </div>
          
        </div>
            
        </div>
      </section>
            <section>
      	<div class="sploffer">
        <h2 class="title">Hot <span>Deals</span></h2>
        	<!-- slider -->
            <img src="images/spl-offer.jpg" class="img-responsive">
        </div>
      </section>--%>
            <section>
      	<div class="latestblogs">
      	
        <h2 class="title">Latest <span>Blogs</span></h2>
        	<!-- slider -->
            
            
          <div id="blog-slider" class="owl-carousel">
          <uc2:ucBlog ID="ucBlog1" runat="server" fldBlogCount = "3" />
          
          
          
        </div>
            
        </div>
      </section>
        </div>
    </div>
<script type="text/javascript">
    $('#ankEnq').click(function (e) {
        $('.tabsection_inner .nav-tabs>li').removeClass('active');
        $('.tabsection_inner [href="#tab_dateprice"]').parent().addClass('active');
        e.preventDefault();
    })
    $('#ucTourShortInfo1_BtnDomesticEnq').click(function (e) {
        $("#divSCPop").addClass('qe_open slideInRight');
        //$('#UCFooter_BtnMesgClose').css("display", "none");
        e.preventDefault();
        $('body').addClass('formOpen');
    })
    $('#ucTourShortInfo1_BtnSpecialEnq').click(function (e) {
        $("#DivScPopup").addClass('qe_open slideInRight');
        //$('#UCFooter_BtnMesgClose').css("display", "none");
        e.preventDefault();
        $('body').addClass('formOpen');
    })
    $('#ucTourShortInfo1_BtnDSEnq').click(function (e) {
        $("#DivScPopup").addClass('qe_open slideInRight');
        //$('#UCFooter_BtnMesgClose').css("display", "none");
        e.preventDefault();
        $('body').addClass('formOpen');
    })
    $('#ucTourShortInfo1_BtnIntEnq').click(function (e) {
        $('.tabsection_inner .nav-tabs>li').removeClass('active');
        $('.tabsection_inner [href="#tab_dateprice"]').parent().addClass('active');
        e.preventDefault();
    })
</script>