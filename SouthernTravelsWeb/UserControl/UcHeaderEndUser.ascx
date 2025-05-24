<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHeaderEndUser.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcHeaderEndUser" %>
<meta charset="utf-8">
<meta https-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<script src='https://www.google.com/recaptcha/api.js'></script>
<!-- Bootstrap Core CSS -->
<link href="/Assets/css/bootstrap.min.css" rel="stylesheet" />
<!-- End Google Tag Manager -->
<!-- Custom CSS -->
<link href="/Assets/css/style.css" rel="stylesheet" />
<link href="/Assets/css/bootstrap-select.css" rel="stylesheet" />
<link href="/Assets/css/font-awesome.css" rel="stylesheet" />
<link href="/Assets/css/bootstrap-datepicker.css" rel="stylesheet" />
<!-- Custom Fonts -->
<link href='https://fonts.googleapis.com/css?family=Lato:400,300' rel='stylesheet'
    type='text/css'>
<!-- Owl Carousel Assets -->
<link href="/Assets/css/owl-carousel/owl.carousel.css" rel="stylesheet" />
<link href="/Assets/css/owl-carousel/owl.theme.css" rel="stylesheet" />
<script src="/Assets/js/jquery-2.2.0.min.js"></script>
<script src="/Assets/js/bootstrap.min.js"></script>
<script src="/Assets/js/owl-carousel/owl.carousel.min.js"></script>
<script src="/Assets/js/bootstrap-select.min.js"></script>
<link href="/Assets/css/animate.css" rel="stylesheet" />
<script src="/Assets/js/bootstrap-datepicker.js"></script>
<link href="/Assets/css/query-ui.css" rel="stylesheet" />
<style>
    .dropdown-big
    {
        width: 700px;
        max-height: 575px !important;
        overflow: hidden;
    }
    
    .dropdownintl
    {
        left: -200px;
        width: 900px;
    }
    .dropdown.open > a, .dropdown.open > a:hover
    {
        color: #f2572b !important;
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
    @media (max-width: 992px)
    {
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
</style>
<script src="/Assets/js/jquery-ui.js"></script>
<script src="/Assets/js/language.js"></script>
<script type="text/javascript">
    function f1(lang) {
        location.href = "changeLang.aspx?lang=" + lang;

    }

</script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<!-- top note -->
<asp:Literal ID="litNotification" runat="server" Visible=false></asp:Literal>
<!-- end top note -->
<div class="sociallinksright">
    <ul>
        <li><a href="https://api.whatsapp.com/send?phone=917466006600" target="_blank" class="wa">
        </a></li>
        <li><a href="https://www.facebook.com/SouthernTravels/" target="_blank" class="fb"></a>
        </li>
        <li><a href="https://twitter.com/happyholidaying" target="_blank" class="tw"></a>
        </li>
        <li><a href="https://plus.google.com/u/0/108785452021940174807/posts" target="_blank"
            class="gplus"></a></li>
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
            <a class="navbar-brand" href="Index.aspx"><img src="Assets/images/logo-st.png" alt="logo" title="logo" loading="lazy"></a> 
            <a href="#" class="searchicon-top"><i class="fa fa-search"></i></a>
            
               <div id="trophy" class="trophy hideonmobile">
                    <img src="Assets/images/Award_Trophy.png" width="14" height="54" alt="Trophy"  loading="lazy"/>
                    <span>Ranked No.1 Domestic Tour Operator </span>
                    <br />
                    by Ministry of Tourism
                </div>
            
            </div>
          <div class="pull-right">
          
          <div class="top_app_icons">
          <span>Book ticket faster. Download our mobile app</span><br />
            <a href="https://play.google.com/store/apps/details?id=com.virtupaper.android.user.c620" target="_blank"><img src="/Assets/images/icon_gplay.png"  loading="lazy"/></a>
            <a href="https://itunes.apple.com/us/app/southern-travels/id1434666186?mt=8" target="_blank"><img src="/Assets/images/icon_ios.png" loading="lazy"/></a>
          
          </div>
          
          <div class="header_enquiry">
          <a href="Enquiryform.aspx" class="commonbtn" target="_blank"><i class="fa fa-envelope"></i> Send Enquiry</a>
          </div>
          <div id="lang" class="langwrap hideonmobile">
                    <div id="langL" class="langL pull-left">
                        <img src="/Assets/images/ChangeLanguage.gif" alt="Change Language" loading="lazy"/>
                        |&nbsp;<span class="mR5"><a href='javascript:convertnew("en|en");'><img src="/Assets/images/Eng.gif"
                            loading="lazy"/></a></span></div>
                    <div id="langR" class="pull-left">
                        <langbar class="niceform">
              <div class="pull-left ddintl" style="vertical-align:middle;">
                <select size="1" name="international" id="international" onchange="javascript:convertnew(this.value);">
                  <option value="-2">International</option>
                  <option value="en|en">English</option>
                  <option value="en|de">German</option>
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
                  <option value="en|et">Estonian</option>
                </select>
              </div>
              <div class="pull-left ddindia">
                <select  name="domestic" runat="server"  id="domestic" size="1"  onchange="javascript:convertnew(this.value);">
                  <option value="-1">Indian</option>
                  <option value="en|en">English</option>
                  <option value="en|hi">Hindi</option>
                  <option value="en|ta">Tamil</option>
                  <option value="en|te">Telugu</option>
                  <option value="en|kn">Kannad</option>
                  <option value="en|bn">Bangla</option>
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
              <li class="removeonmobile"><a href="/Contact-us.aspx" runat="server" id="MainMCU">Contact us </a></li>
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
                    <li><a href="https://www.southerntravelsindia.com/flipbook/Domestic/Domestic_e-Brochure.pdf" target="_blank">Domestic e-brochure</a></li>
                    <li><a href="https://www.southerntravelsindia.com/flipbook/International/International_e-Brochure.pdf" target="_blank">International e-brochure</a></li>  
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
                        <img src="/Assets/images/ChangeLanguage.gif" alt="Change Language" loading="lazy" />
                        |&nbsp;<span class="mR5"><a href='javascript:convertnew("en|en");'><img src="/Assets/images/Eng.gif" loading="lazy"
                           /></a></span></div>
                    <div id="Div3" class="pull-left">
                        <langbar class="niceform">
              <div class="pull-left ddintl" style="vertical-align:middle;">
                <select size="1" name="international" id="Select1" onchange="javascript:convertnew(this.value);">
                  <option value="-2">International</option>
                  <option value="en|en">English</option>
                  <option value="en|de">German</option>
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
                  <option value="en|et">Estonian</option>
                </select>
              </div>
              <div class="pull-left ddindia">
                <select  name="domestic" runat="server"  id="Select2" size="1"  onchange="javascript:convertnew(this.value);" >
                  <option value="-1">Indian</option>
                  <option value="en|en">English</option>
                  <option value="en|hi">Hindi</option>
                  <option value="en|ta">Tamil</option>
                  <option value="en|te">Telugu</option>
                  <option value="en|kn">Kannad</option>
                  <option value="en|bn">Bangla</option>
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
                 
              <li><a href="/Index.aspx" runat="server" id="MainMHM" class="active"><i class="fa fa-home homelinkicon"></i> <span class="homelink">Home</span></a></li>
              <li><a href="/India-Tour-Packages.aspx" runat="server" id="MainMFD" >Fixed Departure Tours<br /><span class="smalltext">(Domestic / seat in coach basis)</span></a></li>
              <li class="dropdown"> 
               
               
                <a href="/holiday-packages.aspx" runat="server" id="MainMHP" class="dropdown-toggle" data-toggle="dropdown" role="button" 
                aria-haspopup="true" aria-expanded="false">Holiday Packages <span class="caret"></span><br /><span class="smalltext">(India / Nepal / Bhutan)</span> </a>
               
                 <div class="dropdown-menu dropdown-big">
                 <div class="row">
                      <div class="col-md-3"> 
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
                            
                        </ul>
                      </div>
                      <div class="col-md-3 paddingleft0"> 
                        <ul class="nav-list">
                        <li><a href="HolidayPackages.aspx?ORG=North East&Code=29" class="link-navimg15">North East</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=North India&Code=1" class="link-navimg16">North India</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=Odisha&Code=34" class="link-navimg17">Odisha</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=Rajasthan&Code=5" class="link-navimg18">Rajasthan</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=Sikkim Darjeeling&Code=31" class="link-navimg19">Sikkim Darjeeling</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=South India&Code=2" class="link-navimg20">South India</a></li>
                        <li><a href="HolidayPackages.aspx?ORG=Uttarakhand&Code=26" class="link-navimg21">Uttarakhand</a></li>
                         <li><a href="HolidayPackages.aspx?Code=54" class="link-navimg11">NRI Tours</a></li>
                        <li><a href="HolidayPackages.aspx?Code=55" class="link-navimg11">Wildlife Tours</a></li> 
                        <li><a href="HolidayPackages.aspx?ORG=Pilgrimage&Code=8" class="link-navimg11">Pilgrimage Tours</a></li>
                        <li><a href="HolidayPackages.aspx?Code=58" class="link-navimg11">Short Tours</a></li>
                        
                        </ul>
                      </div>
                      <div class="col-md-6 paddingleft0 navimgsection"> 
                      <img src="/Assets/images/nav-Andaman.jpg" class="img-responsive navimg1" loading="lazy"> 
                      <img src="/Assets/images/nav-Bhutan.jpg" class="img-responsive navimg2" loading="lazy"> 
                      <img src="/Assets/images/nav-Goa.jpg" class="img-responsive navimg3" loading="lazy"> 
                      <img src="/Assets/images/nav-Golden-Triangle.jpg" class="img-responsive navimg4" loading="lazy" loading="lazy"> 
                      <img src="/Assets/images/nav-Gujarat2.jpg" class="img-responsive navimg5" loading="lazy"> 
                      <img src="/Assets/images/nav-Himachal2.jpg" class="img-responsive navimg6" loading="lazy"> 
                      <img src="/Assets/images/nav-Kailash-Mansarovar2.jpg" class="img-responsive navimg7" loading="lazy"> 
                      <img src="/Assets/images/nav-Kerala.jpg" class="img-responsive navimg8" loading="lazy"> 
                      <img src="/Assets/images/nav-Kashmir2.jpg" class="img-responsive navimg9" loading="lazy"> 
                      <img src="/Assets/images/nav-Karnataka.jpg" class="img-responsive navimg10" loading="lazy"> 
                      <img src="/Assets/images/nav-Leh-Ladakh.jpg" class="img-responsive navimg11" loading="lazy">                     
                       <img src="/Assets/images/nav-Madhya-Pradesh.jpg" class="img-responsive navimg12" loading="lazy"> 
                      <img src="/Assets/images/nav-Maharashtra.jpg" class="img-responsive navimg13" loading="lazy"> 
                      <img src="/Assets/images/nav-Nepal.jpg" class="img-responsive navimg14" loading="lazy"> 
                      <img src="/Assets/images/nav-NorthEast.jpg" class="img-responsive navimg15" loading="lazy"> 
                      <img src="/Assets/images/nav-North-india-tours.jpg" class="img-responsive navimg16" loading="lazy"> 
                      <img src="/Assets/images/nav-Odisha.jpg" class="img-responsive navimg17" loading="lazy"> 
                      <img src="/Assets/images/nav-Rajasthan-tours.jpg" class="img-responsive navimg18" loading="lazy"> 
                      <img src="/Assets/images/nav-Sikkim-Darjeeling.jpg" class="img-responsive navimg19" loading="lazy"> 
                      <img src="/Assets/images/nav-South-India-Tours.jpg" class="img-responsive navimg20" loading="lazy"> 
                      <img src="/Assets/images/nav-Uttarakhand.jpg" class="img-responsive navimg21" loading="lazy"> 
                      
                    </div>
                    
                  </div>
              </li>
                
               <li class="dropdown"> 
               
                <a href="/International-GroupDeparture.aspx" runat="server" id="MainMINT" class="dropdown-toggle" data-toggle="dropdown" role="button" 
                aria-haspopup="true" aria-expanded="false">International <span class="caret"></span><br /><span class="smalltext">(Fixed / Group Departures)</span> </a>
               
                 <div class="dropdown-menu dropdown-big dropdownintl">
                 <div class="row">
                      <div class="col-md-5"> 
                        <ul class="nav-list">
                             
                             <li><a href="IntItenaryDetails.aspx?TourId=155&ofr=2" class="link-navimg1">Thailand, Malaysia & Singapore - 10D/9N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=154&ofr=2" class="link-navimg2">Malaysia & Singapore with 02Nights Cruise - 7D/6N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=150&ofr=2" class="link-navimg3">Thailand -Bangkok, Pattaya - 5D/4N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=152&ofr=2" class="link-navimg4">Srilanka -Ramayana Trail with Shankari Devi - 6D/5N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=151&ofr=2" class="link-navimg5">Dubai with Abu Dhabi - 5D/4N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=182&ofr=2" class="link-navimg6">Best of Europe Discovery – 14D/13N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=184&ofr=2" class="link-navimg7">Glimpse of Europe – 11D/10N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=181&ofr=2" class="link-navimg8">Best of America - 14D/13N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=183&ofr=2" class="link-navimg9">Best Coast to Coast America – 11D/10N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=188&ofr=2" class="link-navimg10">Malaysia and Singapore - 6D/5N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=195&ofr=2" class="link-navimg11">Cruise With Best Of Far East - 11D/10N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=196&ofr=2" class="link-navimg12">Best of Vietnam and Cambodia - 8D/07N</a></li>

                            <li><a href="IntItenaryDetails.aspx?TourId=229&ofr=2" class="link-navimg20">Best of Czech and Austria - 6D/5N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=228&ofr=2" class="link-navimg20">Best of Egypt - 7D/6N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=227&ofr=2" class="link-navimg20">Best of Italy - 6D/5N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=230&ofr=2" class="link-navimg20">Exotic China - 6D/5N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=233&ofr=2" class="link-navimg13">Best of Sri Lanka Leisure - 6 D / 5 N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=234&ofr=2" class="link-navimg14">Best of New Zealand - 10 D / 9 N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=237&ofr=2" class="link-navimg20">Best of Baku - 5 D / 4 N</a></li>
                             <li><a href="IntItenaryDetails.aspx?TourId=238&ofr=2" class="link-navimg20">Best of Bali - 7 D / 6 N</a></li>
                            
                        </ul>
                        
                	     </div>
                         
                         <div class="col-md-3 paddingleft0 paddingright0"> 
                        <ul class="nav-list">
                           <li><a href="IntItenaryDetails.aspx?TourId=197&ofr=2" class="link-navimg21">Best Of Swiss with Paris – 7D/6N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=187&ofr=2" class="link-navimg11">South Africa - 9D/8N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=186&ofr=2" class="link-navimg12">China - 7D/6N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=185&ofr=2" class="link-navimg13">Australia - 10D/9N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=118&ofr=2" class="link-navimg14">Mauritius - 7D/6N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=189&ofr=2" class="link-navimg15">Hongkong and Macau - 6D/5N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=190&ofr=2" class="link-navimg16">Tashkent - 4D/3N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=193&ofr=2" class="link-navimg17">Kenya - 7D/6N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=194&ofr=2" class="link-navimg18">Turkey - 8D/7N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=192&ofr=2" class="link-navimg19">Greece -7D/6N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=191&ofr=2" class="link-navimg20">Australia with New Zealand - 15D/14N</a></li>

                            <li><a href="IntItenaryDetails.aspx?TourId=231&ofr=2" class="link-navimg20">Exotic Europe - 5D/4N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=232&ofr=2" class="link-navimg20">Mini Switzerland - 5D/4N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=226&ofr=2" class="link-navimg20">Wonders of Europe - 6D/5N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=225&ofr=2" class="link-navimg20">Wonders of Hongkong -7D/6N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=235&ofr=2" class="link-navimg22">Best of Eastern Europe - 6 D / 5 N</a></li>
                            <li><a href="IntItenaryDetails.aspx?TourId=236&ofr=2" class="link-navimg23">Best of Russia - 7 D / 6 N</a></li>
                            
                           <li><a href="IntItenaryDetails.aspx?TourId=239&ofr=2" class="link-navimg20">Tashkent Discovery - 5 D / 4 N</a></li>
                            <li><a href="Fixed-Departure-Itinerary-WAM-Best-Of-Abu-Dhabi-and-Dubai_149" class="link-navimg20">Wam-Best Of Abu Dhabi And Dubai - 5 D / 4 N</a></li>
                            
                            
                            
                        </ul>
                        </div>
                
                      <div class="col-md-4 paddingleft0 navimgsection">
                      <img src="/Assets/images/nav-Fareast.jpg" class="img-responsive navimg1" loading="lazy"> 
                      <img src="/Assets/images/nav-Malaysia.jpg" class="img-responsive navimg2" loading="lazy"> 
                      <img src="/Assets/images/nav-Thailand.jpg" class="img-responsive navimg3" loading="lazy">
                      <img src="/Assets/images/nav-SriLanka.jpg" class="img-responsive navimg4" loading="lazy">
                      <img src="/Assets/images/nav-Dubai-Tashkent.jpg" class="img-responsive navimg5" loading="lazy">
                      <img src="/Assets/images/nav-Europe.jpg" class="img-responsive navimg6" loading="lazy">
                      <img src="/Assets/images/nav-Glimpse-of-Europe.jpg" class="img-responsive navimg7" loading="lazy"> 
                      <img src="/Assets/images/nav-America-Canada.jpg" class="img-responsive navimg8" loading="lazy"> 
                      <img src="/Assets/images/nav-Best-of-Coast-TO-Coast-America.jpg" class="img-responsive navimg9" loading="lazy"> 
                      <img src="/Assets/images/nav-Malaysia-and-Singapore.jpg" class="img-responsive navimg10" loading="lazy"> 
                      <img src="/Assets/images/nav-South-Africa.jpg" class="img-responsive navimg11" loading="lazy"> 
                      <img src="/Assets/images/nav-China.jpg" class="img-responsive navimg12" loading="lazy"> 
                      <img src="/Assets/images/nav-Australia.jpg" class="img-responsive navimg13" loading="lazy"> 
                      <img src="/Assets/images/nav-Mauritius.jpg" class="img-responsive navimg14" loading="lazy"> 
                      <img src="/Assets/images/nav-Hongkong-and-Macau.jpg" class="img-responsive navimg15" loading="lazy"> 
                      <img src="/Assets/images/nav-Tashkent.jpg" class="img-responsive navimg16" loading="lazy"> 
                      <img src="Assets/images/nav-Kenya.jpg" class="img-responsive navimg17" loading="lazy"> 
                      <img src="Assets/images/nav-Turkey.jpg" class="img-responsive navimg18" loading="lazy"> 
                      <img src="Assets/images/nav-Greece.jpg" class="img-responsive navimg19" loading="lazy"> 
                      <img src="Assets/images/nav-ausnz.jpg" class="img-responsive navimg20" loading="lazy"> 
                      
                      
                    
                      </div>
                    </div>
                    
                  </div>
              </li>
            
               <li class="dropdown"> 
               
                <a href="/International-GroupDeparture.aspx" runat="server" id="MainMINTC" class="dropdown-toggle" data-toggle="dropdown" role="button" 
                aria-haspopup="true" aria-expanded="false">International <span class="caret"></span><br /><span class="smalltext">(Customized Holidays)</span> </a>
               
                 <div class="dropdown-menu dropdown-big">
                 <div class="row">
                      <div class="col-md-3"> 
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
                        <ul class="nav-list">
                        <li><a href="International-Packages.aspx?ORG=Hong Kong Macau&Code=45&off=1" class="link-navimg6">Hong Kong Macau</a></li>
                            <li><a href="International-Packages.aspx?ORG=Japan China Korea Taiwan&Code=41&off=1" class="link-navimg7">Japan China Korea Taiwan</a></li>
                            <li><a href="International-Packages.aspx?ORG=Maldives Mauritius Bali Seychelles Phillipines&Code=49&off=1" class="link-navimg8">Maldives Mauritius Bali Seychelles Phillipines</a></li>
                            <li><a href="International-Packages.aspx?ORG=Sri Lanka&Code=46&off=1" class="link-navimg9">Sri Lanka</a></li>
                            <li><a href="International-Packages.aspx?ORG=Thailand Singapore Malaysia&Code=44&off=1" class="link-navimg10">Thailand Singapore Malaysia</a></li>
                           
                            
                         
                        </ul>
                      </div>
                      <div class="col-md-6 paddingleft0 navimgsection" > 
                      <img src="/Assets/images/nav-Africa.jpg" class="img-responsive navimg1" loading="lazy"> 
                      <img src="/Assets/images/nav-America-Canada.jpg" class="img-responsive navimg2" loading="lazy"> 
                      <img src="/Assets/images/nav-Australia-New-Zealand.jpg" class="img-responsive navimg3" loading="lazy"> 
                      <img src="/Assets/images/nav-Dubai-Abu-Dhabi-Oman-Tashkent.jpg" class="img-responsive navimg4" loading="lazy"> 
                      <img src="/Assets/images/nav-Europe.jpg" class="img-responsive navimg5" loading="lazy"> 
                      <img src="/Assets/images/nav-Hong-Kong-Macau.jpg" class="img-responsive navimg6" loading="lazy"> 
                      <img src="/Assets/images/nav-Japan-China-Korea-Taiwan.jpg" class="img-responsive navimg7" loading="lazy"> 
                      <img src="/Assets/images/nav-Maldives-Mauritius-Bali-Seychelles-Phillipines.jpg" class="img-responsive navimg8" loading="lazy"> 
                      <img src="/Assets/images/nav-Sri-Lanka.jpg" class="img-responsive navimg9" loading="lazy"> 
                      <img src="/Assets/images/nav-Thailand-Singapore-Malaysia.jpg" class="img-responsive navimg10" loading="lazy"> 
                     
                    
                      </div>
                    </div>
                    
                  </div>
              </li>
               <li class="dropdown">
                <a href="#"  runat="server" id="MainMHTL" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Our Own Hotels <span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <li><a href="https://www.hotelsouthern.com/" target="_blank">Hotel Southern, Delhi</a></li>
                     
                                 <li><a href="https://www.hotelsoutherngrand.com/">Southern Grand, Vijayawada</a></li>
                                <li><a href="https://www.zonebytheparkjaipur.com/">Zone by The Park, Jaipur</a></li>

                </ul>
              </li>
               <li><a href="/HotelsInIndia.aspx" runat="server" id="MainMHTLI">Hotels in India</a></li>
              <li><a href="/Car-Coach-Rental.aspx?ORG=All"  runat="server" id="MainMCR">Car/Coach Rental </a></li>
              <li><a href="/LFC-Home.aspx" runat="server" id="MainMLLTC" >LFC/LTC Tours</a></li>
          <li class="showonmobile"><a href="/Contact-us.aspx" runat="server" id="A1">Contact us </a></li>
                <li class="dropdown showonmobile">
                <a href="#" runat="server" id="MainMEB" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">e-Brochure <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="https://www.southerntravelsindia.com/flipbook/Domestic/index.html" target=_blank>Domestic e-Brochure</a></li>
                  <li><a href="https://www.southerntravelsindia.com/flipbook/International/Index.html" target="_blank">International e-Brochure</a></li>
                </ul> 
              </li>
              
              
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
            } (i));
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
<script src="/Assets/js/jquery.newsTicker.js"></script>
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
