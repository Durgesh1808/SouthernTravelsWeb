<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CareerThankYou.aspx.cs" Inherits="SouthernTravelsWeb.CareerThankYou" %>

<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register TagPrefix="uc1" TagName="leftuc" Src="UserControl/UcCustomerLeft.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Southern Travels: Career At Southern</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="Description" content="At Southern Travels, We will happy to receive your valuable feedback & suggetions and we ensure to serve you more better services." />
    <meta name="Keywords" content="tour and travels agency, tour and travel agency in india, north india tour package, south india tour packages, fixed departure tour, international tour, domestic tour operator, tour operator in india, travel agency, car rental, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours" />
    <meta name="robots" content="index,follow" />
    <!-- Bootstrap Core CSS -->
<link href="Career/css/bootstrap.min.css" rel="stylesheet">

<!-- Custom CSS -->
<link href="Career/css/style.css" rel="stylesheet">
<link href="Career/css/bootstrap-select.css" rel="stylesheet">
<link href="Career/css/font-awesome.css" rel="stylesheet">
<link href="Career/css/bootstrap-datepicker.css" rel="stylesheet">
<!-- Custom Fonts -->
<link href='https://fonts.googleapis.com/css?family=Lato:400,300' rel='stylesheet' type='text/css'>



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
   

    <script src="Assets/js/jquery-ui.js"></script>

    
</head>
<body>
    <form id="form1" runat="server">
    <header class="posrel innerheader" style="background-image: url(images/banner-feedback.jpg)">
   <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" />
  
  
</header>
    <section class="innersection2">
    <div  class="tab-pane fade in active" id="tab_Feedback">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12">
        <div class="titlewithbrder">
          <h1 class="title"> <span>Careers </span> </h1>
          <p>Thank you, Your application request submitted successfully. We will get back to you soon. </p>
        </div>
      </div>
    </div>
  </div>
  <div class="clearfix"></div>
  
  
   
  </div>
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->

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

    <script type="text/javascript">
        $123('.rating').on('rating.change', function(event, value) {
            
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

        $123(function() {
            var stickyRibbonTop = $('.stickymenu').offset().top;

            $123(window).scroll(function() {
                if ($123(window).scrollTop() > stickyRibbonTop) {
                    $123('.stickymenu').addClass('sticky'); //css({position: 'fixed', top: '0px'});
                } else {
                    $123('.stickymenu').removeClass('sticky'); //css({position: 'static', top: '0px'});
                }
            });
        });


        $('a.btn btn-blue').on('click', function(e) {
            e.preventDefault();
            var url = $(this).attr('href');
            $(".modal-body").load("'+url+'");

        });

    </script>

    </form>
</body>
</html>
