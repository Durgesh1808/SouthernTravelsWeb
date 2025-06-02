<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHeaderEndUser.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcHeaderEndUser" %>

<meta charset="utf-8">
<meta https-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">

<script src='https://www.google.com/recaptcha/api.js'></script>

<!-- Bootstrap Core CSS -->
<link href="Assets/css/bootstrap.min.css" rel="stylesheet">
<!-- End Google Tag Manager -->
<!-- Custom CSS -->
<link href="Assets/css/style.css" rel="stylesheet">
<link href="Assets/css/bootstrap-select.css" rel="stylesheet">
<link href="Assets/css/font-awesome.css" rel="stylesheet">
<link href="Assets/css/bootstrap-datepicker.css" rel="stylesheet">
<!-- Custom Fonts -->
<link href='https://fonts.googleapis.com/css?family=Lato:400,300' rel='stylesheet'
    type='text/css'>
<!-- Owl Carousel Assets -->
<link href="Assets/css/owl-carousel/owl.carousel.css" rel="stylesheet">
<link href="Assets/css/owl-carousel/owl.theme.css" rel="stylesheet">

<script src="Assets/js/jquery-2.2.0.min.js"></script>

<script src="Assets/js/bootstrap.min.js"></script>

<script src="Assets/js/owl-carousel/owl.carousel.min.js"></script>

<script src="Assets/js/bootstrap-select.min.js"></script>

<link href="Assets/css/animate.css" rel="stylesheet">

<script type="text/javascript" src="Assets/js/bootstrap-datepicker.js"></script>

<link href="/Assets/css/query-ui.css" rel="stylesheet" />
<style>
    .dropdown-big
    {
        width: 700px;
        max-height: 575px !important;
        overflow: hidden;
        overflow-y: auto;
    }
    .dropdownintl
    {
        left: -350px;
        width: 1140px;
    }
    .dropdownintl.dropdownintl2
    {
        left: -495px;
    }
    .dropdown.open > a, .dropdown.open > a:hover
    {
        color: #fbbf00 !important;
    }
    .headertop .dropdown-menu li a
    {
        font-size: 12px;
        padding: 2px 15px !important;
        padding-left: 30px !important;
        position: relative;
    }
    .headertop .dropdown-menu li a:after
    {
        content: "";
        position: absolute;
        left: 15px;
        top: 6px;
        width: 6px;
        height: 6px;
        border-top: solid 1px #000;
        border-right: solid 1px #000;
        transform: rotate(45deg);
    }
    .header_enquiry
    {
        float: left;
        margin-top: 10px;
        margin-left: 75px;
    }
    .header_enquiry .commonbtn
    {
        padding: 3px 10px;
        font-size: 14px;
    }
    .dropdownintl .nav-list
    {
        padding-top: 0 !important;
        padding-bottom: 0 !important;
    }
    /*.dropdownintl .nav-list li{width: 33.33%}*/.dropdown-menu h3
    {
        font-size: 14px !important;
        padding: 5px 15px 0px;
        font-family: 'centurygothic-bold' , Sans-Serif;
        text-transform: uppercase;
        text-align: left;
    }
    @media (max-width: 992px)
    {
        .dropdownintl .nav-list li
        {
            width: 100%;
        }
        .header_enquiry
        {
            display: none;
        }
    }
    .top_app_icons
    {
        position: absolute;
        right: 500px;
        top: -3px;
        text-align: right;
    }
    .top_app_icons span
    {
        font-size: 11px;
        color: #fff;
    }
    .top_app_icons img
    {
        max-height: 23px;
    }
    .mob_foot_app_icon img
    {
        max-height: 50px;
    }
    .footer_app_icon
    {
        margin-bottom: 5px !important;
    }
    .footer_app_icon img
    {
        max-height: 41px;
    }
    .footer_app_icon a
    {
        background: none !important;
        padding: 0 !important;
        height: auto !important;
    }
    @media (max-width: 1024px)
    {
        .top_app_icons
        {
            display: none;
        }
    }
    .dropdown-submenu
    {
        position: relative;
    }
    .dropdown-submenu > .dropdown-menu
    {
        top: 0;
        left: 100%;
        margin-top: -6px;
    }
    </style>

<script>
    $(document).ready(function () {
        $('.dropdown-submenu > a').on("click", function (e) {
            var submenu = $(this).next('.dropdown-menu');
            $('.dropdown-submenu .dropdown-menu').not(submenu).hide(); // Close other submenus
            submenu.toggle(); // Toggle the clicked one
            e.stopPropagation();
            e.preventDefault();
        });

        // Close all menus when clicking outside
        $(document).click(function () {
            $('.dropdown-submenu .dropdown-menu').hide();
        });
    });
</script>

<script src="Assets/js/jquery-ui.js"></script>

<script src="Assets/js/language.js" type="text/javascript"></script>

<script type="text/javascript">
    function f1(lang) {
        location.href = "changeLang.aspx?lang=" + lang;

    }

</script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<!-- top note -->
<asp:Literal ID="litNotification" runat="server"></asp:Literal>
<!-- end top note -->
<div class="sociallinksright">
    <ul>
        <li><a href="https://api.whatsapp.com/send?phone=917466006600" target="_blank" class="wa">
        </a></li>
        <li><a href="https://www.facebook.com/SouthernTravels/" target="_blank" class="fb"></a>
        </li>
        <li><a href="https://www.instagram.com/southerntravelsofficial/" target="_blank"
            class="instagram"></a></li>
        <li><a href="https://www.linkedin.com/company/southern-travels-pvt-ltd" target="_blank"
            class="linkedin"></a></li>
        <li><a href="https://twitter.com/TravelsSouthern" target="_blank" class="tw"></a>
        </li>
        <%--<li><a href="https://plus.google.com/u/0/108785452021940174807/posts" target="_blank"
            class="gplus"></a></li>
        
        <li><a href="https://plus.google.com/b/105500167792879378506/105500167792879378506/posts"
            target="_blank" class="gplus"></a></li>--%>
        <li><a href="https://www.youtube.com/southerntravels" target="_blank" class="yt"></a>
        </li>
        <li><a href="#" class="quick_link linkqck"></a></li>
    </ul>
</div>
<div class="headertop">
    <nav class="navbar navbar-inverse">
        <div class="container">
          <div class="navbar-header posrel">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar"> <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>
            <a class="navbar-brand" href="https://www.southerntravelsindia.com"><img  loading="lazy" src="Assets/images/logo-st.png" alt="" title=""></a> 
            <a href="#" class="searchicon-top"><i class="fa fa-search"></i></a>
            
               <div id="trophy" class="trophy hideonmobile">
                    <img loading="lazy" src="Assets/images/Award_Trophy.png" width="14" height="54" alt="Trophy" />
                    <span>Ranked No.1 Domestic Tour Operator </span>
                    <br />
                    by Ministry of Tourism
                </div>
            
            <%--<div onclick="showNotice();" title="Corona Update" id="coronaUpdateAnchorId" class="blink-text" data-toggle="modal" data-target="#coronaUpdate" rel="noreferrer" 
                style="position: relative;width: 45px;height: 40px;border-radius: 25px;background-color: #ed1c24;margin-left: 465px;margin-top: 17px;">
                <a onclick="showNotice();" style="color: white;font-size: 9px;top: 10px;left: 2px;font-weight: 700;line-height: 10px;position: absolute;text-align: center;" 
                for="">CORONA<br>Updates</a></div>--%>
            </div>
          <div class="pull-right">
          
          <div class="top_app_icons">
          <span>Book ticket faster. Download our mobile app</span><br />
            <a href="https://play.google.com/store/apps/details?id=com.virtupaper.android.user.c620" target="_blank"><img loading="lazy" src="Assets/images/icon_gplay.png" alt="icon" /></a>
            <a href="https://itunes.apple.com/us/app/southern-travels/id1434666186?mt=8" target="_blank"><img loading="lazy" src="Assets/images/icon_ios.png" alt="icon" /></a>
          
          </div>
          
          <div class="header_enquiry">
          <%--<a href="#" class="commonbtn quick_link linkqck"><i class="fa fa-envelope"></i> Send Enquiry</a>--%>
          <a href="Enquiryform.aspx" class="commonbtn" target="_blank"><i class="fa fa-envelope"></i> Send Enquiry</a>
          </div>
          <div id="lang" class="langwrap hideonmobile">
                    <div id="langL" class="langL pull-left">
                        <img loading="lazy" src="Assets/images/ChangeLanguage.gif" alt="Change Language" />
                        |&nbsp;<span class="mR5"><a href='javascript:convertnew("en|en");'><img loading="lazy" src="Assets/images/Eng.gif" alt="eng"
                            /></a></span></div>
                    <div id="langR" class="pull-left">
                        <langbar class="niceform">
              <div class="pull-left ddintl" style="vertical-align:middle;">
                <select size="1" name="international" id="international" onchange="javascript:convertnew(this.value);">
                  <option value="-2">International</option>
                  <option value="en|en">English</option>
<%--                  <option value="en|de">German</option>
                  <option value="en|fr">French</option>
                  <option value="en|es">Spanish</option>
                  <option value="en|zh">Chinese</option>
                  <option value="en|nl">Dutch</option>
                  <option value="en|ar">Arabic</option>
                  <option value="en|ja">Japanese</option>
                  <option value="en|ko">Korean</option>
                  <option value="en|ms">Malay</option>
                  <option value="en|ru">Russian</option>
                  <option value="en|tr">Turkish</option>
                  <option value="en|id">Indonesian</option>
                  <option value="en|th">Thai</option>
                  <option value="en|et">Estonian</option>--%>
                </select>
              </div>
              <div class="pull-left ddindia">
                <select  name="domestic" runat="server"  id="domestic" size="1"  onchange="javascript:convertnew(this.value);">
                  <option value="-1">Indian</option>
                  <option value="en|en">English</option>
<%--                  <option value="en|hi">Hindi</option>
                  <option value="en|ta">Tamil</option>
                  <option value="en|te">Telugu</option>
                  <option value="en|kn">Kannad</option>
                  <option value="en|bn">Bangla</option>--%>
                </select>
              </div>
            </langbar>
                    </div>
                </div>
                 <div class="clearfix"></div>
            <ul class="topphone">
              <li class="mobpos2"><i class="fa fa-mobile" style="font-size: 20px; line-height: 16px;"></i> 1800 11 0606</li>
              <li class="mobpos4">8686 028 028</li>
               <li class="mobpos1">74 6600 6600 </li>
              <li class="mobpos3">011-43532800 </li>
              <li class="removeonmobile"><a href="../Contact-us.aspx" runat="server" id="MainMCU">Contact us </a></li>
               <%if (Session["custrowid"] != null)
                 { %>
              <li class="navwrap bgnone hideonmobile"><a href="#" class="commonbtn dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Welcome, <% =Session["LoggedInUserName"]%> <span class="caret"></span></a>
               <ul class="dropdown-menu ">
                    <li ><a href="CustomerProfile.aspx?MM=1">My Account</a></li>
                    <li ><a href="Customerlogout.aspx">Logout</a></li>
                  </ul>
              </li><%}
                 else
                 {%><li class="hideonmobile" ><a href="CustomerLogin.aspx?LIN=1&Type=U" class="commonbtn">Sign in</a></li><%} %>
            </ul>
            <div class="clearfix"></div>
             <div class="searchbox">
              <div class="right-inner-addon">
                <asp:TextBox ID="txtSearch" class="form-control"  runat="server" placeholder="Search Your Holiday" ValidationGroup="Sear"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSearch"
                                                            ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="Sear"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtSearch"
                                                            Display="Dynamic" ErrorMessage="Only alphanumeric, # and sapce are allowed."
                                                            ValidationExpression="^[0-9a-zA-Z #,-/]+$" ValidationGroup="Sear"></asp:RegularExpressionValidator>                                                            
                 
                 <asp:Button ID="btnSubmit" runat="server"  CssClass="searchbtn" OnClick="btnSubmit_click" ValidationGroup="Sear"></asp:Button>
              </div>
              
                <div class="downloadbtn posrel navwrap bgnone"><a href="#" class="commonbtn dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">e-Brochure <span class="caret"></span></a>
             
                <ul class="dropdown-menu">
                    <%--<li><a href="https://www.southerntravelsindia.com/flipbook/Domestic/index.html" target=_blank>Domestic e-Brochure</a></li>--%>
                    <li><a href="https://www.southerntravelsindia.com/flipbook/Domestic/Domestic_e-Brochure.pdf" target=_blank>Domestic e-Brochure</a></li>
                   <%--<li><a href="https://www.southerntravelsindia.com/flipbook/International/Index.html" target="_blank">International e-Brochure</a></li>--%>
                   <li><a href="https://www.southerntravelsindia.com/flipbook/International/Brochure-International-Tours.pdf" target="_blank">International e-Brochure</a></li>
                  </ul>
             
             </div>
             
              
            </div>
            <div class="clearfix"></div>
           
          </div>
          </div>
          <div class="clearfix"></div>
         <div class="navwrap stickymenu">
         <div class="container">
          <div id="navbar" class="navbar-collapse collapse">
          
           <div id="Div1" class="langwrap showonmobile">
                    <div id="Div2" class="pull-left langL">
                        <img loading="lazy" src="Assets/images/ChangeLanguage.gif" alt="Change Language" />
                        |&nbsp;<span class="mR5"><a href='javascript:convertnew("en|en");'><img loading="lazy" src="Assets/images/Eng.gif"
                           /></a></span></div>
                    <div id="Div3" class="pull-left">
                        <langbar class="niceform">
              <div class="pull-left ddintl" style="vertical-align:middle;">
                <select size="1" name="international" id="Select1" onchange="javascript:convertnew(this.value);">
                  <option value="-2">International</option>
                  <option value="en|en">English</option>
<%--                  <option value="en|de">German</option>
                  <option value="en|fr">French</option>
                  <option value="en|es">Spanish</option>
                  <option value="en|zh">Chinese</option>
                  <option value="en|nl">Dutch</option>
                  <option value="en|ar">Arabic</option>
                  <option value="en|ja">Japanese</option>
                  <option value="en|ko">Korean</option>
                  <option value="en|ms">Malay</option>
                  <option value="en|ru">Russian</option>
                  <option value="en|tr">Turkish</option>
                  <option value="en|id">Indonesian</option>
                  <option value="en|th">Thai</option>
                  <option value="en|et">Estonian</option>--%>
                </select>
              </div>
              <div class="pull-left ddindia">
                <select  name="domestic" runat="server"  id="Select2" size="1"  onchange="javascript:convertnew(this.value);" >
                  <option value="-1">Indian</option>
                  <option value="en|en">English</option>
<%--                  <option value="en|hi">Hindi</option>
                  <option value="en|ta">Tamil</option>
                  <option value="en|te">Telugu</option>
                  <option value="en|kn">Kannad</option>
                  <option value="en|bn">Bangla</option>--%>
                </select>
              </div>
            </langbar>
                    </div>
                </div>
           <div class="clearfix"></div>
            <ul class="nav navbar-nav">
               <%if (Session["custrowid"] != null)
                 { %>
              <li class="navwrap bgnone menuinner showonmobile"><a href="#" class="commonbtn dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Welcome, <% =Session["LoggedInUserName"]%> <span class="caret"></span></a>
               <ul class="dropdown-menu ">
                    <li ><a href="CustomerProfile.aspx?MM=1">My Account</a></li>
                    <li ><a href="Customerlogout.aspx">Logout</a></li>
                  </ul>
              </li><%}
                 else
                 {%><li class="menuinner showonmobile" ><a href="CustomerLogin.aspx?LIN=1&Type=U" class="commonbtn">Sign in</a></li><%} %>
                 
              <li><a href="https://www.southerntravelsindia.com/" runat="server" id="MainMHM" class="active"><i class="fa fa-home homelinkicon"></i> <span class="homelink">Home</span></a></li>
              <li><a href="../India-Tour-Packages.aspx" runat="server" id="MainMFD" >Fixed Departure Tours<br /><span class="smalltext">(Domestic / seat in coach basis)</span></a></li>
              <li class="dropdown"> 
               
               
                <a href="../holiday-packages.aspx" runat="server" id="MainMHP" class="dropdown-toggle" data-toggle="dropdown" role="button" 
                aria-haspopup="true" aria-expanded="false">Holiday Packages <span class="caret"></span><br /><span class="smalltext">(India / Nepal / Bhutan)</span> </a>
               
                 <div class="dropdown-menu dropdown-big">
                 <div class="row">
                      <div class="col-md-3"> 
                        <!-- <h3 class="title"><span>Indian Tours</span></h3> -->
                        <ul class="nav-list">
                            <li><a href="HolidayPackages.aspx?ORG=Andaman&Code=19" class="link-navimg1">Andaman</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Bhutan&Code=28" class="link-navimg2">Bhutan</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Goa&Code=20" class="link-navimg3">Goa</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Golden Triangle&Code=30" class="link-navimg4">Golden Triangle</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Gujarat&Code=21" class="link-navimg5">Gujarat</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Himachal&Code=22" class="link-navimg6">Himachal</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Kailash Mansarovar&Code=17" class="link-navimg7">Kailash Mansarovar</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Kerala&Code=6" class="link-navimg8">Kerala</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Kashmir&Code=23" class="link-navimg9">Kashmir</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Karnataka&Code=32" class="link-navimg10">Karnataka</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Leh Ladakh&Code=24" class="link-navimg11">Leh Ladakh</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Madhya Pradesh&Code=25" class="link-navimg12">Madhya Pradesh</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Maharashtra&Code=33" class="link-navimg13">Maharashtra</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Nepal&Code=27" class="link-navimg14">Nepal</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=Honeymoon&Code=7" class="link-navimg14">HoneyMoon/leisure Packages</a></li>
                            <li><a href="HolidayPackages.aspx?ORG=OBTTours&Code=59" class="link-navimg14">Short OBT Tours</a></li>
                            
                            
                          <%--<li><a href="HolidayPackages.aspx?ORG=North India&Code=1" class="link-navimg1">North india tours</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=Rajasthan&Code=5" class="link-navimg2">Rajasthan tours</a> </li>
                          <li><a href="HolidayPackages.aspx?ORG=Kerala&Code=6" class="link-navimg3">Kerala tours</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=South India&Code=2" class="link-navimg4">South India Tours</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=Pilgrimage&Code=8" class="link-navimg5">Pilgrimage tour</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=Western India&Code=3" class="link-navimg6">Western india tours</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=Eastern India&Code=4" class="link-navimg7">Eastern india tours</a></li>--%>
                        </ul>
                      </div>
                      <div class="col-md-3 paddingleft0"> 
                        <!-- <h3 class="title"><span>Indian Tours</span></h3> -->
                        <ul class="nav-list">
                        <li><a href="HolidayPackages.aspx?ORG=North East&Code=29" class="link-navimg15">North East</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=North India&Code=1" class="link-navimg16">North India</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=Odisha&Code=34" class="link-navimg17">Odisha</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=Rajasthan&Code=5" class="link-navimg18">Rajasthan</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=Sikkim Darjeeling&Code=31" class="link-navimg19">Sikkim Darjeeling</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=South India&Code=2" class="link-navimg20">South India</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=Uttarakhand&Code=26" class="link-navimg21">Uttarakhand</a></li>
                        <%--<li><a href="HolidayPackages.aspx?Code=52" class="link-navimg11">Rs.7999/- Super Saver Packages</a></li> 
                        <li><a href="HolidayPackages.aspx?Code=53" class="link-navimg11">Rs.9999/- Super Saver Packages</a></li> 
                        <li><a href="HolidayPackages.aspx?Code=50" class="link-navimg11">Rs.11699/- Super Saver Packages</a></li> 
                        <li><a href="HolidayPackages.aspx?Code=51" class="link-navimg11">Rs.13699/- Super Saver Packages</a></li>--%>
                        <li><a href="HolidayPackages.aspx?Code=54" class="link-navimg11">NRI Tours</a></li>
                        <li><a href="HolidayPackages.aspx?Code=55" class="link-navimg11">Wildlife Tours</a></li> 
                        <li><a href="HolidayPackages.aspx?ORG=Pilgrimage&Code=8" class="link-navimg11">Pilgrimage Tours</a></li>
                        <li><a href="HolidayPackages.aspx?Code=58" class="link-navimg11">Short Tours</a></li>
                        
                        
                         <%-- <li><a href="HolidayPackages.aspx?ORG=Honeymoon&Code=7" class="link-navimg8">Honeymoon tours</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=LuxuryTrain&Code=13" class="link-navimg9">Luxury train offers</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=Eastern India&Code=4" class="link-navimg10">Nepal & Bhutan tours</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=Mumbai&Code=11" class="link-navimg11">Mumbai Tours</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=Bengaluru&Code=10" class="link-navimg12">Bengaluru Tours</a></li>
                          <li><a href="HolidayPackages.aspx?ORG=Visakhapatnam&Code=9" class="link-navimg13">Visakhapatnam Tours</a></li>--%>
                        </ul>
                      </div>
                      <div class="col-md-6 paddingleft0 navimgsection"> 
                      <img loading="lazy" src="Assets/images/nav-Andaman.jpg" class="img-responsive navimg1" alt="Andaman Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Bhutan.jpg" class="img-responsive navimg2" alt="Bhutan Tour" />
                      <img loading="lazy" src="Assets/images/nav-Goa.jpg" class="img-responsive navimg3" alt="Goa Tour" />
                      <img loading="lazy" src="Assets/images/nav-Golden-Triangle.jpg" class="img-responsive navimg4" alt="Triangle Tour" />
                      <img loading="lazy" src="Assets/images/nav-Gujarat.jpg" class="img-responsive navimg5" alt="Gujarat Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Himachal.jpg" class="img-responsive navimg6" alt="Gujarat Tour" /> 
                      <%--<img loading="lazy" src="Assets/images/nav-Western-india-tours.jpg" class="img-responsive navimg6">--%>
                      <img loading="lazy" src="Assets/images/nav-Kailash-Mansarovar.jpg" class="img-responsive navimg7" alt="Mansarover Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Kerala.jpg" class="img-responsive navimg8" alt="Kerala Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Kashmir.jpg" class="img-responsive navimg9" alt="Kashmir Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Karnataka.jpg" class="img-responsive navimg10" alt="Karnataka Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Leh-Ladakh.jpg" class="img-responsive navimg11" alt="Ladakh Tour" /> 
                     <%-- <img loading="lazy" src="Assets/images/nav-bengaluru-tours.jpg" class="img-responsive navimg12"> 
                      <img loading="lazy" src="Assets/images/nav-vishakhapatnam-tours.jpg" class="img-responsive navimg13">--%>
                      
                       <img loading="lazy" src="Assets/images/nav-Madhya-Pradesh.jpg" class="img-responsive navimg12" alt="Madhya Pradesh Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Maharashtra.jpg" class="img-responsive navimg13" alt="Maharashtra Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Nepal.jpg" class="img-responsive navimg14" alt="Nepal Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-NorthEast.jpg" class="img-responsive navimg15" alt="NorthEast Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-North-india-tours.jpg" class="img-responsive navimg16" alt="Tours Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Odisha.jpg" class="img-responsive navimg17" alt="Odisha Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Rajasthan-tours.jpg" class="img-responsive navimg18" alt="Rajasthan Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Sikkim-Darjeeling.jpg" class="img-responsive navimg19" alt="Darjeeling Tour" />
                      <img loading="lazy" src="Assets/images/nav-South-India-Tours.jpg" class="img-responsive navimg20" alt="Tours Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Uttarakhand.jpg" class="img-responsive navimg21" alt="Uttarakhand Tour" /> 
                      
                      <%--<img loading="lazy" src="Assets/images/nav-North-india-tours.jpg" class="img-responsive navimg1"> 
                      <img loading="lazy" src="Assets/images/nav-Rajasthan-tours.jpg" class="img-responsive navimg2"> 
                      <img loading="lazy" src="Assets/images/nav-Kerala-tours.jpg" class="img-responsive navimg3"> 
                      <img loading="lazy" src="Assets/images/nav-South-India-Tours.jpg" class="img-responsive navimg4"> 
                      <img loading="lazy" src="Assets/images/nav-Pilgrim-tour.jpg" class="img-responsive navimg5"> 
                      <img loading="lazy" src="Assets/images/nav-Western-india-tours.jpg" class="img-responsive navimg6"> 
                      <img loading="lazy" src="Assets/images/nav-Eastern-India-Tours.jpg" class="img-responsive navimg7"> 
                      <img loading="lazy" src="Assets/images/nav-Honeymoon-tours.jpg" class="img-responsive navimg8"> 
                      <img loading="lazy" src="Assets/images/nav-Luxury-train.jpg" class="img-responsive navimg9"> 
                      <img loading="lazy" src="Assets/images/nav-Nepal-Bhutan.jpg" class="img-responsive navimg10"> 
                      <img loading="lazy" src="Assets/images/nav-mumbai-tours.jpg" class="img-responsive navimg11"> 
                      <img loading="lazy" src="Assets/images/nav-bengaluru-tours.jpg" class="img-responsive navimg12"> 
                      <img loading="lazy" src="Assets/images/nav-vishakhapatnam-tours.jpg" class="img-responsive navimg13">--%> </div>
                    </div>
                    
                  </div>
              </li>
              <%--<li>
                <a href="../International-GroupDeparture.aspx" runat="server" id="MainMINT_Old"> International<br /><span class="smalltext">(Fixed / Group Departures)</span></a>
              
              </li>--%>  <%--<ul class="dropdown-menu">
                  <li><a href="International-GroupDeparture.aspx">International(Fixed / Group Departures)</a></li>
                  <li><a href="International-Packages.aspx">International(Customized Holidays)</a></li>
                </ul>--%>
                
               <li class="dropdown"> 
               
                <a href="../International-GroupDeparture.aspx" runat="server" id="MainMINT" class="dropdown-toggle" data-toggle="dropdown" role="button" 
                aria-haspopup="true" aria-expanded="false">International <span class="caret"></span><br /><span class="smalltext">(Fixed / Group Departures)</span> </a>
               
                <div class="dropdown-menu dropdown-big dropdownintl">
                 <div class="row">
                      <div class="col-md-9"> 

                      <div class="row">
                      <div class="col-md-4"> 

                       <h3 class="title"><span>Europe - UK</span></h3>
                            <ul class="nav-list">
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=182&ofr=1" class="link-navimg6">Best Of European Discovery - 14D/13N</a></li>
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=184&ofr=2" class="link-navimg7">Glimpse Of Europe - 11D/10N</a></li>
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=197&ofr=2&tourname=Paris-And-Swiss-Delight%E2%80%937D/6N" class="link-navimg21">Paris And Swiss Delight 7D/6N</a></li>
                            <%--<li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=192&ofr=2&tourname=Greece-7D/6N" class="link-navimg19">Best of Greece - 7D/6N</a></li>
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=269&ofr=2" class="link-navimg40">Scandic Capitals Winter Season - 10D/9N</a></li>
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=274&ofr=2" class="link-navimg18">Northern Lights - 10D/9N</a></li>--%>
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=275&ofr=2" class="link-navimg6">Experience Europe - 11D/10N</a></li>
                            <%--<li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=276&ofr=2" class="link-navimg6">Best Of European Discovery - 14D / 13N</a></li> --%>                                                       
                            <%--<li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=283&ofr=2" class="link-navimg7">Glimpse of Europe - Winter Season 11D/10N</a></li>--%>
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=284&ofr=2&tourname=Best-of-Eastern-Europe-7D/6N" class="link-navimg22">Best of Eastern Europe – 7D/6N</a></li>
                            
                            <%--<li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=235&ofr=2&tourname=Best-of-Eastern-Europe-7D/6N" class="link-navimg22">Best of Eastern Europe – 7D/6N</a></li>
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=247&ofr=2&tourname=Best-of-Europe-14D/13N" class="link-navimg6"> Best of Europe - 14D/13N</a></li>                            
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=250&ofr=2" class="link-navimg40">Scandic Capitals - 11D/10N</a></li>                            
                            <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=194&ofr=2&tourname=Turkey-8D/7N" class="link-navimg18">Best of Turkey - 8D/7N</a></li>--%>
                            
                         </ul>

                         <h3 class="title"><span>Far East - South East Asia</span></h3>
                        <ul class="nav-list">
                            <%--<li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=38&ofr=2" class="link-navimg7">Glimpse of Far East - 10D/9N</a></li>
                             <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=143&ofr=2" class="link-navimg7">Glimpse of Far East With Cruise- 12D/11N</a></li>--%>
                             <li><a href="IntItenaryDetails.aspx?TourId=155&amp;ofr=2&amp;tourname=Best-of-Far-East-10D/9N" class="link-navimg1">Best of Far East - 10D/9N</a></li>
                             <li><a href="IntItenaryDetails.aspx?TourId=195&amp;ofr=2&amp;tourname=Cruise-With-Best-Of-Far-East-11D/10N" class="link-navimg80">Best of Far East with Cruise - 12D/11N</a></li>
                             <%--<li><a href="IntItenaryDetails.aspx?TourId=97&amp;ofr=2&amp;tourname=Highlights-of-Malaysia-and-Singapore-6D/5N" class="link-navimg2">Highlights of Malaysia and Singapore - 6D/5N</a></li>
                             <li><a href="IntItenaryDetails.aspx?TourId=112&amp;ofr=2&amp;tourname=Highlights-of-Malaysia-and-Singapore-With-Cruise-8D/7N" class="link-navimg2">Highlights of Malaysia and Singapore with Cruise - 8D/7N</a></li>--%>
                             <li><a href="IntItenaryDetails.aspx?TourId=188&amp;ofr=2&amp;tourname=Malaysia-and-Singapore-6D/5N" class="link-navimg10"> Best Of Malaysia And Singapore - 6D/5N</a></li>
                             <li><a href="IntItenaryDetails.aspx?TourId=154&amp;ofr=2&amp;tourname=Malaysia-and-Singapore-with-Cruise-8D/7N" class="link-navimg2">Best Of Malaysia And Singapore With Cruise - 8D/7N</a></li>
                             <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=459&ofr=1" class="link-navimg10">Best Of Singapore With Cruise - 6D/5N</a></li>
                             <%--<li><a href="IntItenaryDetails.aspx?TourId=39&amp;ofr=2&amp;tourname=Thailand-Splendour-5D/4N" class="link-navimg2">Thailand Splendour - 5D/4N</a></li>--%>
                             <li><a href="IntItenaryDetails.aspx?TourId=150&amp;ofr=2&amp;tourname=Best-of-Thailand-5D/4N" class="link-navimg81">Best of Thailand - 5D/4N</a></li>
                             <li><a href="IntItenaryDetails.aspx?TourId=460&amp;ofr=2&amp;tourname=Affordable-Thailand-5D/4N" class="link-navimg2">Affordable Thailand - 5D/4N</a></li>
                             <%--<li><a href="IntItenaryDetails.aspx?TourId=249&amp;ofr=1&amp;tourname=Best-of-Cambodia-6D/5N" class="link-navimg20">Best of Cambodia - 6D/5N </a></li>
                             <li><a href="IntItenaryDetails.aspx?TourId=248&amp;ofr=2&amp;tourname=Best-of-Vietnam-7D/6N" class="link-navimg20">Best of Vietnam - 7D/6N</a></li>--%>
                             <li><a href="IntItenaryDetails.aspx?TourId=457&amp;ofr=2&amp;tourname=Best-Of-Vietnam-6D/5N" class="link-navimg82"> Best Of Vietnam - 6D/5N</a></li>
                             <%--<li><a href="IntItenaryDetails.aspx?TourId=271&amp;ofr=2&amp;tourname=Best-of-Vietnam-and-Cambodia-8D/07N" class="link-navimg12"> Best of Vietnam and Cambodia with Angkor Wat – 8D/7N</a></li>--%>
                             <li><a href="IntItenaryDetails.aspx?TourId=458&amp;ofr=2&amp;tourname=Best-of-Angkor-Wat-with-Cambodia-and-Vietnam-8D/7N" class="link-navimg83"> Best of Angkor Wat with Cambodia & Vietnam-8D/7N</a></li>
                             <li><a href="https://www.southerntravelsindia.com/IntItenaryDetails.aspx?TourId=472&ofr=1" class="link-navimg83">Best Of Bali - 6 D / 5 N</a></li>
                             <%--<li><a href="IntItenaryDetails.aspx?TourId=189&amp;ofr=2&amp;tourname=Hongkong-and-Macau-6D/5N" class="link-navimg15">Best of Hongkong And Macau – 6D/5N</a></li>
                             <li><a href="IntItenaryDetails.aspx?TourId=225&amp;ofr=2&amp;tourname=Wonders-of-Hongkong-7D/6N" class="link-navimg20">Wonders of Hongkong – 7D/6N</a></li>--%>
                             
                            <%--<li><a href="IntItenaryDetails.aspx?TourId=280&amp;ofr=2&amp;tourname=Best-of-Far-East-Winter-Season-10D/9N" class="link-navimg1">Best of Far East -Winter Season - 10D/9N</a></li>                            
                            <li><a href="IntItenaryDetails.aspx?TourId=272&amp;ofr=2&amp;tourname=Malaysia-and-Singapore-Winter-Season-6D/5N" class="link-navimg10"> Best of Malaysia with Singapore Winter Season - 6D/5N</a></li>                                                        
                            <li><a href="IntItenaryDetails.aspx?TourId=196&amp;ofr=2&amp;tourname=Best-of-Vietnam-and-Cambodia-Winter-Season-8D/07N" class="link-navimg12"> Best of Vietnam and Cambodia with Angkor Wat Winter Season – 8D/7N</a></li>                            
                            <li><a href="IntItenaryDetails.aspx?TourId=287&amp;ofr=2&amp;tourname=Best-of-Vietnam-7D/6N" class="link-navimg20">Best of Vietnam - Winter Season - 7D / 6N</a></li>                            
                            <li><a href="IntItenaryDetails.aspx?TourId=238&amp;ofr=2&amp;tourname=Best-of-Bali-5D/4N" class="link-navimg20">Best of Bali – 5D/4N</a></li>--%>
                            </ul>
                      
                      </div>
                       <div class="col-md-4"> 

                        <%-- <h3 class="title"><span>Eurasia</span></h3> 
                        <ul class="nav-list">
                        <li><a href="IntItenaryDetails.aspx?TourId=190&amp;ofr=1&amp;tourname=Tashkent-4D/3N" class="link-navimg16">Best of Tashkent – 4D/3N</a></li>
                        <li><a href="IntItenaryDetails.aspx?TourId=239&amp;ofr=2&amp;tourname=Tashkent-Discovery-5D/4N" class="link-navimg20">Tashkent Discovery – 12D/11N</a></li>
                        <li><a href="IntItenaryDetails.aspx?TourId=236&amp;ofr=2&amp;tourname=Best-of-Russia-7D/6N" class="link-navimg23">Best of Russia – 7D/6N</a></li>                        
                        <li><a href="IntItenaryDetails.aspx?TourId=246&amp;ofr=1&amp;tourname=Best-of-Baku-Azerbaijan-6D/5N" class="link-navimg20">Best of Baku - Azerbaijan – 6D/5N</a></li>
                         </ul>--%>

                        <h3 class="title"><span>Dubai - Middle East</span></h3> 
                        <ul class="nav-list">
                           <li><a href="IntItenaryDetails.aspx?TourId=251&amp;ofr=2&amp;tourname=Best-of-Dubai-With-Abu-Dhabi-6D/5N" class="link-navimg5">Best Of Dubai With Abu Dhabi- 6D/5N</a></li>
                           <%--<li><a href="IntItenaryDetails.aspx?TourId=363&amp;ofr=2&amp;tourname=Dubai-With-Abu-Dhabi-Highlights-6D/5N" class="link-navimg5">Dubai With Abu Dhabi Highlights-6D/5N</a></li>--%>
                           <li><a href="IntItenaryDetails.aspx?TourId=228&amp;ofr=2&amp;tourname=Best-of-Egypt-9D/8N" class="link-navimg84">Best of Egypt – 9D/8N</a></li>  
                           <%--<li><a href="IntItenaryDetails.aspx?TourId=151&amp;ofr=1&amp;tourname=Best-of-Dubai-5D/4N" class="link-navimg5">Best of Dubai - 5D/4N</a></li>--%>                         
                           <li><a href="IntItenaryDetails.aspx?TourId=465&amp;ofr=1&amp;tourname=Dazzling-Dubai-5D/4N" class="link-navimg84">Dazzling Dubai - 5D/4N</a></li>  
                           <li><a href="IntItenaryDetails.aspx?TourId=470&ofr=2" class="link-navimg84">Amazing Baku - 6D/5N</a></li> 
                           <li><a href="IntItenaryDetails.aspx?TourId=471&ofr=2" class="link-navimg84">Highlights Of Baku - 5D/4N</a></li>
                                                    
                         </ul>


                          <h3 class="title"><span>Srilanka - Maldives</span></h3> 
                        <ul class="nav-list">
                           <%--<li><a href="IntItenaryDetails.aspx?TourId=141&amp;ofr=2&amp;tourname=Best-of-Sri-Lanka-Ramayana-Trails-6D/5N" class="link-navimg4">Best Of Sri Lanka-Ramayana Trails - 6D/5N</a></li>--%>
                           <li><a href="IntItenaryDetails.aspx?TourId=152&amp;ofr=2&amp;tourname=Srilanka-Ramayana-Trail-with-6D/5N" class="link-navimg85">Best Of Sri Lanka-Ramayana Trails - 6D/5N</a></li>                           
                          <li><a href="IntItenaryDetails.aspx?TourId=233&amp;ofr=2&amp;tourname=Best-of-Sri-Lanka-Leisure-6D/5N" class="link-navimg86">Best of Sri Lanka Leisure – 6D/5N</a></li>
                          <%--<li><a href="IntItenaryDetails.aspx?TourId=277&amp;ofr=2&amp;tourname=Best-of-Sri-Lanka-Leisure-Winter-Season-6D/5N" class="link-navimg13">Best of Sri Lanka Leisure Winter Season – 6D/5N</a></li>--%>
                         </ul>


                          <h3 class="title"><span>Africa</span></h3> 
                        <ul class="nav-list">
                          <li><a href="IntItenaryDetails.aspx?TourId=187&amp;ofr=1&amp;tourname=South-Africa-10D/9N" class="link-navimg11">Best of South Africa – 10D/9N</a></li>
                          <li><a href="IntItenaryDetails.aspx?TourId=193&amp;ofr=2&amp;tourname=Kenya-7D/6N" class="link-navimg17"> Best of Kenya – 7D/6N</a></li>
                          <%--<li><a href="IntItenaryDetails.aspx?TourId=282&amp;ofr=2&amp;tourname=South-Africa-Winter-Season-12D/11N" class="link-navimg11">Best of South Africa Winter Season – 12D/11N</a></li>--%>
                         
                         <%--<li><a href="IntItenaryDetails.aspx?TourId=273&amp;ofr=2&amp;tourname=Kenya-7D/6N" class="link-navimg17"> Best of Kenya – Winter Season - 7D/6N</a></li>--%>
                         </ul>

                           <h3 class="title"><span>America - Canada</span></h3> 
                        <ul class="nav-list">
                         <li><a href="IntItenaryDetails.aspx?TourId=449&amp;ofr=2&amp;tourname=Best-of-West-Coast-USA–7D/6N" class="link-navimg87">Best Of West Coast USA - 7D/6N</a></li>
                         <li><a href="IntItenaryDetails.aspx?TourId=450&amp;ofr=2&amp;tourname=Best-of-East-Coast-USA–6D/5N" class="link-navimg9">Best Of East Coast USA - 6D/5N</a></li>
                         <li><a href="IntItenaryDetails.aspx?TourId=451&amp;ofr=2&amp;tourname=Best-of-America-With-Orlando-15D/14N" class="link-navimg9">Best Of America With Orlando - 15D/14N</a></li>
                         <li><a href="IntItenaryDetails.aspx?TourId=452&amp;ofr=2&amp;tourname=Best-Of-Coast-To-Coast-America-12D/11N" class="link-navimg9">Best Of Coast To Coast America - 12D/11N</a></li>                         
                         <%--<li><a href="IntItenaryDetails.aspx?TourId=181&amp;ofr=2&amp;tourname=Best-of-America-14D/13N" class="link-navimg8">Best of America – 14D/13N</a></li> --%>                        
                         </ul>

                          <h3 class="title"><span>Australia - Newzealand</span></h3> 
                        <ul class="nav-list">
                        <li><a href="IntItenaryDetails.aspx?TourId=185&amp;ofr=2&amp;tourname=Australia-11D/10N" class="link-navimg13"> Best of Australia - 12D/11N</a></li>                                                
                        <li><a href="IntItenaryDetails.aspx?TourId=191&amp;ofr=2&amp;tourname=Australia-with-New-Zealand-19D/18N" class="link-navimg88">Best of Australia with New Zealand – 19D/18N</a></li>
                        <%--<li><a href="IntItenaryDetails.aspx?TourId=234&amp;ofr=2&amp;tourname=Best-of-New-Zealand-10D/9N" class="link-navimg14">Best of New Zealand – 10D/9N</a></li>--%>
                        </ul>
                        
                       
                       </div>
                        <div class="col-md-4"> 
                          <%--<h3 class="title"><span>Japan - China</span></h3> 
                        <ul class="nav-list">
                        <li><a href="IntItenaryDetails.aspx?TourId=230&amp;ofr=2&amp;tourname=Exotic-China-6D/5N" class="link-navimg20">Exotic China – 6D/5N</a></li>
                        <%--<li><a href="IntItenaryDetails.aspx?TourId=186&amp;ofr=2&amp;tourname=China-8D/7N" class="link-navimg12">Best of China – 8D/7N</a></li>
                         </ul>

                          <h3 class="title"><span>Mauritius - Seychelles</span></h3> 
                        <ul class="nav-list">
                         <li><a href="IntItenaryDetails.aspx?TourId=118&amp;ofr=1&amp;tourname=Mauritius-7D/6N" class="link-navimg14">Best of Mauritius – 7D/6N</a></li>
                        
                         </ul>--%>
                         <h3 class="title"><span>Nepal - Bhutan</span></h3> 
                        <ul class="nav-list">
                         <li><a href="Fixed-Departure-Itinerary-Nepal-Muktinath-Pilgrimage_179" class="link-navimg41">Nepal Muktinath Pilgrimage - 8D/7N</a></li>
                        
                         </ul>
                        
                         <h3 class="title"><span>Senior’s Special</span></h3> 
                        <ul class="nav-list">
                         <li><a href="IntItenaryDetails.aspx?TourId=476&ofr=1">Senior Citizen Special Malaysia And Singapore - 6 D / 5 N</a></li>
                        <li><a href="IntItenaryDetails.aspx?TourId=474&ofr=1">Senior Citizen Special Sri Lanka Ramayana Trail Summer - 6 D / 5 N</a></li>
                        <li><a href="IntItenaryDetails.aspx?TourId=473&ofr=1">Senior Citizen Special Angkor Wat With Cambodia And Vietnam - 8 D / 7 N</a></li>
                         </ul>
                         
                           <h3 class="title"><span>Women’s Special</span></h3> 
                        <ul class="nav-list">
                         <li><a href="IntItenaryDetails.aspx?TourId=272&ofr=2">Women Special Malaysia And Singapore - 6 D / 5 N</a></li>
                        <li><a href="IntItenaryDetails.aspx?TourId=475&ofr=1" >Women Special Sri Lanka Ramayana Trail Summer - 6 D / 5 N</a></li>
                        <li><a href="IntItenaryDetails.aspx?TourId=477&ofr=1" >Women Special Angkor Wat With Cambodia And Vietnam - 8 D / 7 N</a></li>
                         </ul>
                         
                         
                        </div>
                      </div>

                     </div>
                         
                         <!--<div class="col-md-3 paddingleft0 paddingright0"> -->
                       
                      <!--  </div>-->
                
                      <div class="col-md-3 paddingleft0 navimgsection">
                      <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg1" alt="Fareast Tour" /> 
                      <%--<img loading="lazy" src="Assets/images/nav-Malaysia.jpg" class="img-responsive navimg2" alt="Malaysia Tour" /> --%>
                      <img loading="lazy" src="Assets/images/nav-Thailand.jpg" class="img-responsive navimg3" alt="Thailand Tour" />
                      <img loading="lazy" src="Assets/images/nav-SriLanka.jpg" class="img-responsive navimg4" alt="SriLanka Tour" />
                      <img loading="lazy" src="Assets/images/nav-Dubai-Tashkent.jpg" class="img-responsive navimg5" alt="Tashkent Tour" />
                     <%-- <img loading="lazy" src="Assets/images/nav-Europe.jpg" class="img-responsive navimg6" alt="Europe Tour" />--%>
                      <img loading="lazy" src="Assets/images/nav-Glimpse-of-Europe.jpg" class="img-responsive navimg7" alt="Europe Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-America-Canada.jpg" class="img-responsive navimg8" alt="Canada Tour" /> 
                      <%-- <img loading="lazy" src="Assets/images/nav-Best-of-Coast-TO-Coast-America.jpg" class="img-responsive navimg9" alt="America Tour" /> 
                     <img loading="lazy" src="Assets/images/nav-Malaysia-and-Singapore.jpg" class="img-responsive navimg10" alt="Singapore Tour" /> --%>
                      <img loading="lazy" src="Assets/images/nav-South-Africa.jpg" class="img-responsive navimg11" alt="Africa Tour" />
                      <img loading="lazy" src="Assets/images/nav-South-Africa.jpg" class="img-responsive navimgFE" alt="Best of Far East with Cruise" /> 
                      <img loading="lazy" src="Assets/images/nav-China.jpg" class="img-responsive navimg12" alt="China Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Australia.jpg" class="img-responsive navimg13" alt="Australia Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Mauritius.jpg" class="img-responsive navimg14" alt="Mauritius Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Hongkong-and-Macau.jpg" class="img-responsive navimg15" alt="Macau Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Tashkent.jpg" class="img-responsive navimg16" alt="Tashkent Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Kenya.jpg" class="img-responsive navimg17" alt="Kenya Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Turkey.jpg" class="img-responsive navimg18" alt="Turkey Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Greece.jpg" class="img-responsive navimg19" alt="Greece Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-ausnz.jpg" class="img-responsive navimg20" alt="Ausnz Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Best-Of-Swiss-with-Paris.jpg" class="img-responsive navimg21" alt="Paris Tour" />
                      <img loading="lazy" src="Assets/images/nav-scandic.jpg" class="img-responsive navimg40" alt="Scandic Tour" />                     
                       <img loading="lazy" src="Assets/images/nav-Nepal-Bhutan.jpg" class="img-responsive navimg41" alt="Nepal Bhutan Tour" /> 
                       <img loading="lazy" src="Assets/images/nav-Best-of-Far-East-with-Cruise.jpg" class="img-responsive navimg80" alt="Best of Far East with Cruise" /> 
                       <img loading="lazy" src="Assets/images/nav-Best-of-Thailand.jpg" class="img-responsive navimg81" alt="Best of Thailand" /> 
                       <img loading="lazy" src="Assets/images/nav-Best-of-Vietnam.jpg" class="img-responsive navimg82" alt="Best Of Vietnam Summer Season" /> 
                       <%--<img loading="lazy" src="Assets/images/nav-Best-of-Vietnam-Cambodia-with-Angkor-Wat.jpg" class="img-responsive navimg83" alt="Best Of Vietnam and Cambodia with Angkor Wat Summer Season" />
                       <img loading="lazy" src="Assets/images/nav-Best-of-Egypt.jpg" class="img-responsive navimg84" alt="Best of Egypt" />  --%>
                       <img loading="lazy" src="Assets/images/Ramayana-Trails.jpg" class="img-responsive navimg85" alt="Ramayana Trails" /> 
                       <img loading="lazy" src="Assets/images/Sri-Lanka-Leisure.jpg" class="img-responsive navimg86" alt="Best of Sri Lanka Leisure" /> 
                       <img loading="lazy" src="Assets/images/nav-Best-of-West-Coast-USA.jpg" class="img-responsive navimg87" alt="Best Of West Coast USA" /> 
                       <img loading="lazy" src="Assets/images/nav-Best-of-Australia-New-Zealand.jpg" class="img-responsive navimg88" alt="Best of Australia with New Zealand" /> 
                      </div>
                    </div>
                    
                  </div>
               
              </li>
              <%--<li>
                <a href="../International-Packages.aspx" runat="server" id="MainMINTC">International<br /><span class="smalltext">(Customized Holidays)</span></a>
              </li>--%>
               <li class="dropdown"> 
               
                <a href="../International-GroupDeparture.aspx" runat="server" id="MainMINTC" class="dropdown-toggle" data-toggle="dropdown" role="button" 
                aria-haspopup="true" aria-expanded="false">International <span class="caret"></span><br /><span class="smalltext">(Customized Holidays)</span> </a>
               
               <div class="dropdown-menu dropdown-big dropdownintl dropdownintl2">
                 <div class="row">
                 <div class="col-md-9"> 
                      <div class="row">
                      <div class="col-md-3"> 
                        <h3 class="title"><span>EUROPE – UK</span></h3>
                            <ul class="nav-list">
                            <li><a href="/SearchResult.aspx?prefixText=Switzerland&off=1" class="link-navimg21">Switzerland</a></li>
                            <li><a href="/SearchResult.aspx?prefixText=France&off=1" class="link-navimg22">France</a></li>
                            <li><a href="/SearchResult.aspx?prefixText=Austria&off=1" class="link-navimg23">Austria</a></li>
                            <li><a href="/SearchResult.aspx?prefixText=Italy&off=1" class="link-navimg24">Italy</a></li>
                            <li><a href="/SearchResult.aspx?prefixText=Germany&off=1" class="link-navimg34">Germany</a></li>
                            <li><a href="/SearchResult.aspx?prefixText=Spain&off=1" class="link-navimg33">Spain</a></li>
                            <li><a href="/SearchResult.aspx?prefixText=Greece&off=1" class="link-navimg25">Greece</a></li>
                            <li><a href="/SearchResult.aspx?prefixText=London&off=1" class="link-navimg32">United Kingdom</a></li> <%--England--%>
                            <li><a href="/SearchResult.aspx?prefixText=Scotland&off=1" class="link-navimg35">Scotland</a></li>
                            <li><a href="/SearchResult.aspx?prefixText=Ireland&off=1" class="link-navimg26">Ireland</a></li>
                            <li><a href="/SearchResult.aspx?prefixText=Finland&off=1" class="link-navimg31">Finland</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Norway&off=1" class="link-navimg30">Norway</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Sweden&off=1" class="link-navimg29">Sweden</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Iceland&off=1" class="link-navimg27">Iceland</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Netherlands&off=1" class="link-navimg28">Netherlands</a></li>
                            </ul>
                        <h3 class="title"><span>EASTERN EUROPE</span></h3> 
                         <ul class="nav-list">
                            <li><a href="../SearchResult.aspx?prefixText=Croatia&off=1" class="link-navimg36">Croatia</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Czech Republic&off=1" class="link-navimg37">Czech Republic</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Uzbekistan&off=1" class="link-navimg38">Uzbekistan</a></li>                            
                         </ul>    
                      </div>
                      <div class="col-md-3">                          
                         <h3 class="title"><span>ASIA</span></h3> 
                         <ul class="nav-list">
                            <li><a href="../SearchResult.aspx?prefixText=Thailand&off=1" class="link-navimg39">Thailand</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Malaysia&off=1" class="link-navimg40">Malaysia</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Singapore&off=1" class="link-navimg41">Singapore</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Vietnam&off=1" class="link-navimg42">Vietnam</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Cambodia&off=1" class="link-navimg43">Cambodia</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=China&off=1" class="link-navimg44">China</a></li>                             
                            <li><a href="../SearchResult.aspx?prefixText=Indonesia&off=1" class="link-navimg45">Indonesia</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Hong Kong&off=1" class="link-navimg46">Hong Kong & Macau</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Japan&off=1" class="link-navimg47">Japan</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Korea&off=1" class="link-navimg48">Korea</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Philippines&off=1" class="link-navimg49">Philippines</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Laos&off=1" class="link-navimg50">Laos</a></li>    
                            <li><a href="../SearchResult.aspx?prefixText=kathmandu&off=1" class="link-navimg50">Nepal</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Bhutan&off=1" class="link-navimg50">Bhutan</a></li>                        
                         </ul>
                         <h3 class="title"><span>EURASIA</span></h3>
                          <ul class="nav-list">
                            <li><a href="../SearchResult.aspx?prefixText=Azerbaijan&off=1" class="link-navimg51">Azerbaijan</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Russia&off=1" class="link-navimg52">Russia</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Georgia&off=1" class="link-navimg53">Georgia</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Turkey&off=1" class="link-navimg54">Turkey</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Portugal&off=1" class="link-navimg55">Portugal</a></li>              
                         </ul>
                         
                      </div> 
                      <div class="col-md-3">
                      <h3 class="title"><span>PACIFIC</span></h3>
                          <ul class="nav-list">
                            <li><a href="../SearchResult.aspx?prefixText=Australia&off=1" class="link-navimg71">Australia</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=New Zealand&off=1" class="link-navimg72">New Zealand</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=French Polynesia&off=1" class="link-navimg73">French Polynesia</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Fiji&off=1" class="link-navimg74">Fiji</a></li>       
                         </ul>       
                                        
                         <h3 class="title"><span>MIDDLE EAST</span></h3>
                          <ul class="nav-list">
                            <li><a href="../SearchResult.aspx?prefixText=Dubai&off=1" class="link-navimg59">Dubai</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Oman&off=1" class="link-navimg60">Oman</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Jordan&off=1" class="link-navimg61">Jordan</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Qatar&off=1" class="link-navimg62">Qatar</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Egypt&off=1" class="link-navimg63">Egypt</a></li> 
                            <li><a href="../SearchResult.aspx?prefixText=Israel&off=1" class="link-navimg64">Israel</a></li>              
                         </ul>                         
                         <h3 class="title"><span>AMERICAS - CANADA</span></h3>
                          <ul class="nav-list">
                            <li><a href="../SearchResult.aspx?prefixText=USA&off=1" class="link-navimg65">USA</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Canada&off=1" class="link-navimg66">Canada</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Alaska&off=1" class="link-navimg67">Alaska</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=South America&off=1" class="link-navimg68">South America</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=North America&off=1" class="link-navimg69">North America</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Mexico&off=1" class="link-navimg70">Mexico</a></li>       
                         </ul>                         
                      </div>     
                      <div class="col-md-3">
                        <h3 class="title"><span>AFRICA</span></h3>
                          <ul class="nav-list">
                            <li><a href="../SearchResult.aspx?prefixText=South Africa&off=1" class="link-navimg56">South Africa</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Kenya&off=1" class="link-navimg57">Kenya</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Tanzania&off=1" class="link-navimg58">Tanzania</a></li>       
                         </ul> 
                         <h3 class="title"><span>ISLANDS</span></h3>
                          <ul class="nav-list">
                            <li><a href="../SearchResult.aspx?prefixText=Maldives&off=1" class="link-navimg75">Maldives</a></li>                            
                            <li><a href="../SearchResult.aspx?prefixText=Seychelles&off=1" class="link-navimg76">Seychelles</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Mauritius&off=1" class="link-navimg77">Mauritius</a></li>
                            <li><a href="../SearchResult.aspx?prefixText=Sri Lanka&off=1" class="link-navimg78">Sri Lanka</a></li>       
                         </ul>
                      </div>
                      </div>
                 </div>     
                 <div class="col-md-3 paddingleft0 navimgsection">
                 <img loading="lazy" src="Assets/images/nav-switzerland.jpg" class="img-responsive navimg21" alt="Switzerland" />
                 <img loading="lazy" src="Assets/images/nav-France.jpg" class="img-responsive navimg22" alt="France" />
                 <img loading="lazy" src="Assets/images/nav-austria.jpg" class="img-responsive navimg23" alt="Austria" />
                  <%-- <img loading="lazy" src="Assets/images/nav-Europe.jpg" class="img-responsive navimg24" alt="Italy" />
               <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg34" alt="Germany" /> 
                 <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg33" alt="Spain" />
                 <img loading="lazy" src="Assets/images/nav-Europe.jpg" class="img-responsive navimg25" alt="Greece" />
                 <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg32" alt="England" />--%>
                 <img loading="lazy" src="Assets/images/nav-switzerland.jpg" class="img-responsive navimg35" alt="Scotland" />
                 <img loading="lazy" src="Assets/images/nav-ireland.jpg" class="img-responsive navimg26" alt="Ireland" />
             <%--    <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg31" alt="Finland" />
                 <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg30" alt="Norway" />
                 <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg29" alt="Sweden" />--%>
                 <img loading="lazy" src="Assets/images/nav-iceland.jpg" class="img-responsive navimg27" alt="Iceland" />
                <%-- <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg28" alt="Netherlands" />
                 <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg36" alt="Croatia" />
                 <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg37" alt="Czech Republic" />--%>
                 <img loading="lazy" src="Assets/images/nav-uzbekistan.jpg" class="img-responsive navimg38" alt="Uzbekistan" />
                 <img loading="lazy" src="Assets/images/nav-Thailand.jpg" class="img-responsive navimg39" alt="Thailand" />
                <%-- <img loading="lazy" src="Assets/images/nav-Thailand-Singapore-Malaysia.jpg" class="img-responsive navimg40" alt="Malaysia" />--%>
                 <img loading="lazy" src="Assets/images/nav-Thailand-Singapore-Malaysia.jpg" class="img-responsive navimg41" alt="Singapore" />
                <%-- <img loading="lazy" src="Assets/images/nav-vietnam.jpg" class="img-responsive navimg42" alt="Vietnam" />--%>
                 <img loading="lazy" src="Assets/images/nav-vietnam.jpg" class="img-responsive navimg43" alt="Cambodia" />
                 <img loading="lazy" src="Assets/images/nav-China.jpg" class="img-responsive navimg44" alt="China" />
                <%-- <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg45" alt="Indonesia" />--%>
                 <img loading="lazy" src="Assets/images/nav-Hongkong-and-Macau.jpg" class="img-responsive navimg46" alt="Hong Kong & Macau" />
                 <img loading="lazy" src="Assets/images/nav-Japan-China-Korea-Taiwan.jpg" class="img-responsive navimg47" alt="Japan" />
                 <%--<img loading="lazy" src="Assets/images/nav-Japan-China-Korea-Taiwan.jpg" class="img-responsive navimg48" alt="Korea" />--%>
                 <img loading="lazy" src="Assets/images/nav-Maldives-Mauritius-Bali-Seychelles-Phillipines.jpg" class="img-responsive navimg49" alt="Philippines" />
                <%-- <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg50" alt="Laos" />
                 <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg51" alt="Azerbaijan" />
                 <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg52" alt="Russia" />
                 <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg53" alt="Georgia" />--%>
                 <img loading="lazy" src="Assets/images/nav-Turkey.jpg" class="img-responsive navimg54" alt="Turkey" />
                <%-- <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg55" alt="Portugal" />--%>
                 <img loading="lazy" src="Assets/images/nav-South-Africa.jpg" class="img-responsive navimg56" alt="South Africa" />
                 <img loading="lazy" src="Assets/images/nav-Kenya.jpg" class="img-responsive navimg57" alt="Kenya" />
                  <%-- <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg58" alt="Tanzania" />
                 <img loading="lazy" src="Assets/images/nav-Dubai-Abu-Dhabi-Oman-Tashkent.jpg" class="img-responsive navimg59" alt="UAE" />
                 <img loading="lazy" src="Assets/images/nav-Dubai-Abu-Dhabi-Oman-Tashkent.jpg" class="img-responsive navimg60" alt="Oman" />
                 <img loading="lazy" src="Assets/images/nav-Dubai-Abu-Dhabi-Oman-Tashkent.jpg" class="img-responsive navimg61" alt="Jordan" />
                 <img loading="lazy" src="Assets/images/nav-Dubai-Abu-Dhabi-Oman-Tashkent.jpg" class="img-responsive navimg62" alt="Qatar" />--%>
                 <img loading="lazy" src="Assets/images/nav-egypt.jpg" class="img-responsive navimg63" alt="Egypt" />
                <%-- <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg64" alt="Israel" />--%>
                 <img loading="lazy" src="Assets/images/nav-usa.jpg" class="img-responsive navimg65" alt="USA" />
                <%-- <img loading="lazy" src="Assets/images/nav-America-Canada.jpg" class="img-responsive navimg66" alt="Canada" />--%>
                 <img loading="lazy" src="Assets/images/nav-Maldives-Mauritius-Bali-Seychelles-Phillipines.jpg" class="img-responsive navimg67" alt="Alaska" />
                 <%--  <img loading="lazy" src="Assets/images/nav-Best-of-Coast-TO-Coast-America.jpg" class="img-responsive navimg68" alt="South America" />
               <img loading="lazy" src="Assets/images/nav-Best-of-Coast-TO-Coast-America.jpg" class="img-responsive navimg69" alt="North America" />--%>
                 <%--<img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg70" alt="Mexico" />--%>
                 <img loading="lazy" src="Assets/images/nav-Australia-New-Zealand.jpg" class="img-responsive navimg71" alt="Australia" />
                 <%--<img loading="lazy" src="Assets/images/nav-Australia-New-Zealand.jpg" class="img-responsive navimg72" alt="New Zealand" />--%>
                <%-- <img loading="lazy" src="Assets/images/nav-Fareast.jpg" class="img-responsive navimg73" alt="French Polynesia" />--%>
                 <img loading="lazy" src="Assets/images/nav-Africa.jpg" class="img-responsive navimg74" alt="Fiji" />
                 <img loading="lazy" src="Assets/images/nav-Maldives-Mauritius-Bali-Seychelles-Phillipines.jpg" class="img-responsive navimg75" alt="Maldives" />
                 <%--<img loading="lazy" src="Assets/images/nav-Maldives-Mauritius-Bali-Seychelles-Phillipines.jpg" class="img-responsive navimg76" alt="Seychelles" />
                 <img loading="lazy" src="Assets/images/nav-Maldives-Mauritius-Bali-Seychelles-Phillipines.jpg" class="img-responsive navimg77" alt="Mauritius" />--%>
                 <img loading="lazy" src="Assets/images/nav-Sri-Lanka.jpg" class="img-responsive navimg78" alt="Sri Lanka" />              
                 
                 </div>
                 </div>
                    
                  </div>
                 <div class="dropdown-menu dropdown-big" style="display:none;">
                 <div class="row">
                      <div class="col-md-3"> 
                        <!-- <h3 class="title"><span>Indian Tours</span></h3> -->
                        <ul class="nav-list">
                            <li><a href="International-Packages.aspx?ORG=Africa&Code=35&off=1" class="link-navimg1">Africa</a></li>
                            <li><a href="International-Packages.aspx?ORG=America Canada&Code=47&off=1" class="link-navimg2">America Canada</a></li>
                            <li><a href="International-Packages.aspx?ORG=Australia New Zealand&Code=38&off=1" class="link-navimg3">Australia New Zealand</a></li>
                            <li><a href="International-Packages.aspx?ORG=Dubai Oman Tashkent&Code=48&off=1" class="link-navimg4">Dubai Oman Tashkent Sharjah</a></li>
                            <li><a href="International-Packages.aspx?ORG=Europe&Code=40&off=1" class="link-navimg5">Europe</a></li>
                            <li><a href="International-Packages.aspx?Code=57&off=1" class="link-navimg5">Honeymooners tours</a></li>
                            <li><a href="International-Packages.aspx?Code=59&off=1" class="link-navimg5">Short OBT Tours</a></li>
                            
                            
                        
                        </ul>
                      </div>
                      <div class="col-md-3 paddingleft0"> 
                        <!-- <h3 class="title"><span>Indian Tours</span></h3> -->
                        <ul class="nav-list">
                        <li><a href="International-Packages.aspx?ORG=Hong Kong Macau&Code=45&off=1" class="link-navimg6">Hong Kong Macau</a></li>
                            <li><a href="International-Packages.aspx?ORG=Japan China Korea Taiwan&Code=41&off=1" class="link-navimg7">Japan China Korea Taiwan</a></li>
                            <li><a href="International-Packages.aspx?ORG=Maldives Mauritius Bali Seychelles Phillipines&Code=49&off=1" class="link-navimg8">Maldives Mauritius Bali Seychelles Phillipines</a></li>
                            <li><a href="International-Packages.aspx?ORG=Sri Lanka&Code=46&off=1" class="link-navimg9">Sri Lanka</a></li>
                            <li><a href="International-Packages.aspx?ORG=Thailand Singapore Malaysia&Code=44&off=1" class="link-navimg10">Thailand Singapore Malaysia</a></li>
                           
                            
                         
                        </ul>
                      </div>
                      <div class="col-md-6 paddingleft0 navimgsection" > 
                      <img loading="lazy" src="Assets/images/nav-Africa.jpg" class="img-responsive navimg1" alt="Africa Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-America-Canada.jpg" class="img-responsive navimg2" alt="Canada Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Australia-New-Zealand.jpg" class="img-responsive navimg3" alt="NewZealand Tour" />
                      <img loading="lazy" src="Assets/images/nav-Dubai-Abu-Dhabi-Oman-Tashkent.jpg" class="img-responsive navimg4" alt="Tashkent Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Europe.jpg" class="img-responsive navimg5" alt="Europe Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Hong-Kong-Macau.jpg" class="img-responsive navimg6" alt="Macau Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Japan-China-Korea-Taiwan.jpg" class="img-responsive navimg7" alt="Taiwan Tour" />
                      <img loading="lazy" src="Assets/images/nav-Maldives-Mauritius-Bali-Seychelles-Phillipines.jpg" class="img-responsive navimg8" alt="Phillipines Tour" />
                      <img loading="lazy" src="Assets/images/nav-Sri-Lanka.jpg" class="img-responsive navimg9" alt="SriLanka Tour" /> 
                      <img loading="lazy" src="Assets/images/nav-Thailand-Singapore-Malaysia.jpg" class="img-responsive navimg10" alt="Malaysia Tour" />                       
                     
                    
                      </div>
                    </div>
                    
                  </div>
              </li>
              
              <li class="dropdown">
              <a href="#" runat="server" id="MainCruisePackages" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Speciality Tours <span class="caret"></span></a>
             <div class="dropdown-menu dropdown-big" style=" width:538px">
               
               <div style="width: 538px; height: 117px; position: relative">
              <div style="width: 538px; height: 117px; left: 0px; top: 0px; position: absolute; background: white; border: 0.50px black solid"></div>
              <div style="width: 150px; height: 65px; left: 22px; top: 14px; position: absolute"><a href="SearchResult.aspx?prefixText=women%20special">

                <img loading="lazy" style="width: 150px; height: 65px; left: 0px; top: 0px; position: absolute; box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25); border-radius: 5px"
                 src="Assets/images/womans.jpg" /></a>
              </div>
              <div style="width: 150px; height: 65px; left: 194px; top: 14px; position: absolute; box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25); border-radius: 5px">
                <a href="SearchResult.aspx?prefixText=Senior%20Citizen">

                <img loading="lazy" style="width: 150px; height: 65px; left: 0px; top: 0px; position: absolute; border-radius: 5px" src="Assets/images/seniors.png" />
                </a>
              </div>
              <div style="width: 150px; height: 65px; left: 366px; top: 14px; position: absolute; box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25)">
              <a href="SearchResult.aspx?prefixText=Cruise">

                <img loading="lazy" style="width: 150px; height: 65px; left: 0px; top: 0px; position: absolute; border-radius: 5px" src="Assets/images/cruise.jpg" />
              </a>
              </div>
              <div style="width: 112px; height: 18px; left: 22px; top: 85px; position: absolute; color: #F1562B; font-size: 14px; font-family: Inter; font-weight: 700; word-wrap: break-word">Women’s Special</div>
              <div style="width: 118px; height: 18px; left: 194px; top: 85px; position: absolute; color: #F1562B; font-size: 14px; font-family: Inter; font-weight: 700; word-wrap: break-word">Senior’s Special</div>
              <div style="width: 99px; height: 18px; left: 366px; top: 85px; position: absolute; color: #F1562B; font-size: 14px; font-family: Inter; font-weight: 700; word-wrap: break-word">Cruise Special</div>
            </div>
                 
              </div>
            </li>
              
            
               <li class="dropdown">
                <a href="#"  runat="server" id="MainMHTL" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Our Own Hotels <span class="caret"></span></a>
                <ul class="dropdown-menu">
                   <%--<li><a href="hotel-southern.aspx?HTLREG=DEL">Hotel Southern, Delhi</a></li>--%>
                    <li><a href="https://www.hotelsouthern.com/" target="_blank">Hotel Southern, Delhi</a></li>
                                <%--<li><a href="HotelSouthernGrandVijayawada.aspx">Southern Grand, Vijayawada</a></li>
                                <li><a href="hotel-southern-jaipur.aspx">Zone by The Park, Jaipur</a></li>--%>
                                <%--<li><a href="hotel-southern.aspx?HTLREG=IND">Hotels In India</a></li>--%>
                                 <li><a href="https://www.hotelsoutherngrand.com/">Southern Grand, Vijayawada</a></li>
                                 <li><a href="https://www.southerngrandkashi.com/">Southern Grand, Kashi</a></li>
                                <li><a href="https://www.zonebytheparkjaipur.com/">Zone by The Park, Jaipur</a></li>

                </ul>
              </li>
               <li><a href="../HotelsInIndia.aspx" runat="server" id="MainMHTLI">Hotels in India</a></li>
              <li><a href="../Car-Coach-Rental.aspx?ORG=All"  runat="server" id="MainMCR">Car/Coach Rental </a></li>
              <%--<li><a href="#" runat="server" id="MainMFLIGHT">Flights </a></li>--%>
              <li style="display:none;"><a href="../LFC-Home.aspx" runat="server" id="MainMLLTC" >LFC/LTC Tours</a></li>
             <%-- <%if (Session["custrowid"] == null)
                { %>
              <li><a href="../CustomerLogin.aspx?LIN=2" runat="server" id="MainMAL">Agent Login</a></li>
              <li><a href="../CustomerLogin.aspx?LIN=1" runat="server" id="MainMCL">Customer Login</a></li>
               <%}%>
                    <%else
                        {%>
                        <li><a href="../CustomerProfile.aspx?MM=1" runat="server" id="aMyAccount"  >
                        My Account</a></li>
                        <li><a href="../Customerlogout.aspx" runat="server" id="a1" >
                        Logout</a></li>
                        <%}%>--%>
              
             	<li class="showonmobile"><a href="../Contact-us.aspx" runat="server" id="A1">Contact us </a></li>
                <li class="dropdown showonmobile">
                <a href="#" runat="server" id="MainMEB" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">e-Brochure <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="https://www.southerntravelsindia.com/flipbook/Domestic/index.html" target=_blank>Domestic e-Brochure</a></li>
                  <li><a href="https://www.southerntravelsindia.com/flipbook/International/Index.html" target="_blank">International e-Brochure</a></li>
                </ul> 
              </li>
              
              
              
              <%--<li class="dropdown">
                <a href="#" runat="server" id="MainMINT" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" 
                aria-expanded="false">International Holidays<span class="caret"></span></a>
              
              
              <ul class="dropdown-menu">
                  <li><a href="International-GroupDeparture.aspx">International(Fixed / Group Departures)</a></li>
                  <li><a href="International-Packages.aspx">International(Customized Holidays)</a></li>
                </ul>
              </li>--%>
            </ul>
          </div>
          </div>
          </div>
        
      </nav>
</div>

<script>
    $(function () {

        $('.searchicon-top').click(function () {
            $('.searchbox').slideToggle();
        });

        /*$('.nav-list a').mouseenter(function(){
        $('.nav-list img').fadeOut();
        $('.nav-list a').removeClass('active');
        $(this).addClass('active');
        $(this).parent().find('img').fadeIn();
        }).mouseleave(function(){
        	
        });		*/

        $('.navimgsection img').hide();
        $('.navimgsection img.navimg1').show();
        var numofsubnav = $('.navimgsection img').length;
        for (var i = 1; i <= numofsubnav; i++) {
            var $linknavimg = $('.link-navimg' + i);
            (function (i) {
                $linknavimg.mouseenter(function () {
                    //alert('you clicked ' + i);
                    $('.nav-list a').removeClass('active');
                    $(this).addClass('active');
                    $('.navimgsection img').hide();
                    $('.navimg' + i).fadeIn('fast');
                });
            }(i));
        }



    });
    /* back to top */
    $(document).ready(function () {
        // hide #back-top first
        $("#back-top").hide();
        // fade in #back-top
        $(function () {
            $(window).scroll(function () {
                if ($(this).scrollTop() > 100) {
                    $('#back-top').fadeIn();
                } else {
                    $('#back-top').fadeOut();
                }
            });

            // scroll body to 0px on click
            $('#back-top a').click(function () {
                $('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });
        });

    });




</script>

<script type="text/javascript">

    $(function () {

        /* tooltip */
        $('.tip').each(function () {
            $(this).tooltip(
                {
                    html: true,
                    title: $('#' + $(this).data('tip')).html()
                });
        });


        //top close
        $('.topclose').click(function (e) {
            $('.topnote').slideUp();
            e.preventDefault();
        });

        // datepicker
        $('.txtdate').datepicker();
        $('.txtdate').on('change', function () {
            $('.datepicker').hide();
        });





        $('select').selectpicker({
            style: 'btn-info',
            size: 4
        });


    });
</script>

<script type="text/javascript">
    function alphanumeric(inputtxt) {
        var letters = /^[a-zA-Z_0-9]$/;
        if (document.getElementById("<%=txtSearch.ClientID  %>").value.match(letters)) {
            return true;
        }
        else {
            document.getElementById("<%=txtSearch.ClientID  %>").focus();
            alert('Please input alphanumeric characters only');
            return false;
        }
    }

</script>

<script>
    $(function () {
        $('.nav-list a').mouseenter(function () {
            $('.nav-list img').fadeOut();
            $('.nav-list a').removeClass('active');
            $(this).addClass('active');
            $(this).parent().find('img').fadeIn();
        }).mouseleave(function () {

        });

    });
</script>

<script src="Assets/js/jquery.newsTicker.js"></script>

<script>

    var nt_example1 = $('#nt-example1').newsTicker({
        row_height: 30,
        max_rows: 3,
        duration: 4000,
        prevButton: $('#nt-example1-prev'),
        nextButton: $('#nt-example1-next')
    });

</script>

<script>
    $(function () {
        var stickyRibbonTop = $('.stickymenu').offset().top;

        $(window).scroll(function () {
            if ($(window).scrollTop() > stickyRibbonTop) {
                $('.stickymenu').addClass('sticky'); //css({position: 'fixed', top: '0px'});
            } else {
                $('.stickymenu').removeClass('sticky'); //css({position: 'static', top: '0px'});
            }
        });
    });

</script>


