<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News-Events.aspx.cs" Inherits="SouthernTravelsWeb.News_Events" %>


<%@ Register Src="UserControl/UCHeaderEndUser.ascx" TagName="UcHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UCFooterEndUser.ascx" TagName="UcFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>News | Media | Events : Southern Travels</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="Description" content="Our Press releases and event section will give you more insights and upcoming traveling announcements of Southern Travels." />
    <meta name="Keywords" content=" holiday packages in india, holiday india packages, india travel holiday packages, india holiday travel packages, india holiday tours, india package holidays, india holiday tour packages, india holiday travels, holiday tour packages in india, india tours, india holidays, india travels, india tour packages, india travel packages, india tourism, india tourist attractions, india travel destinations, india travel tours, holidays in india, southern travels india" />
    <meta name="robots" content="index,follow" />
    <link href="Assets/css/ekko-lightbox.css" rel="stylesheet">
    <style>
        .modal
        {
            top: 70px !important;
        }
    </style>
   
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
    <!-- Header Start -->
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-fixed-tour-detail.jpg)">
  <div class="herobanner">
    <UCHeader:UCHeaderEndUser ID="UCHeaderEndUser1" runat="server"  />
    </div></header>
    <!-- Header End -->
    <!-- Main Content Start -->
    <section class="innersection2">
<div id="fixedtabsection">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12">
        <h1 class="title">News & <span>Media</span></h1>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12">
        <div class="tabsection_inner">
          <ul class="nav nav-tabs">
            <li class="active"><a href="#tab_presscoverage" data-toggle="tab">Press Coverage</a></li>
            <li><a href="#tab_awardceremony" data-toggle="tab">Award Ceremony</a></li>
            <li><a href="#tab_inauguration" data-toggle="tab">Inauguration</a></li>
            <li><a href="javascript:void(0);" data-toggle="tab">News and Media</a></li>
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
<!-- press Coverage -->
<div class="tab-pane fade in active" id="tab_presscoverage">
  <div class="container">
    <div class="row rowgap">
      <div class="col-md-12">
        <h4><span class="title">2015</span> / 2014</h4>
      </div>
    </div>
    <div class="presscoverage">
      <div class="row">
     <asp:DataList runat="server" ID="ddlPressCoverage" RepeatColumns="3" RepeatDirection="Horizontal"
                                CellPadding="5" ItemStyle-VerticalAlign="Middle" RepeatLayout="Flow">
                                <ItemTemplate>
                    <div class="col-md-4"> 
                                  <a href='<%# Convert.ToInt32(Eval("IsImg")) == 1 ? "Assets/images/news-event/big-" + Eval("EventImgThumbPath") : Eval("EventVideo") %>'
                                     data-toggle="lightbox" data-gallery="multiimages" >
                                    
                                              <div class="newsbox"> 
                                              
                                              <%# Convert.ToInt32(Eval("IsImg")) == 1 ? "" : "<div class='video-icon'><img src='Assets/images/icon-video.png'></div>" %> 
                                              
                                              <img src='<%# "Assets/images/news-event/thumb/" + Eval("EventImgThumbPath") %>' style="width:360px; height:373px" class="img-responsive"  width="360" height="373" loading="lazy"/>
                                                <div class="newstext">
                                                  <h4><%# Eval("EventDesc") %></h4>
                                                </div>
                                              </div>
                                              </a> </div>
                                </ItemTemplate>
                            </asp:DataList>
                            
      
   
    </div>
     </div>
  </div>
</div>
<!-- end press Coverage --> 

<!-- awardceremony -->
<div class="tab-pane" id="tab_awardceremony">
  <div class="container">
  <div class="row rowgap">
      <div class="col-md-12">
        <h4><span class="title">2015</span> / 2014</h4>
      </div>
    </div>
    <div class="presscoverage">
      <div class="row">
    <asp:DataList runat="server" ID="ddlAwardCeremony" RepeatColumns="3" RepeatDirection="Horizontal"
                                 RepeatLayout="Flow">
                                <ItemTemplate>

                                   <div class="col-md-4">
                                    <a href='<%# Convert.ToInt32(Eval("IsImg")) == 1 ? "Assets/images/news-event/big-" + Eval("EventImgThumbPath") : Eval("EventVideo") %>'
                                     data-toggle="lightbox" data-gallery="multiimages" >
                                    
                                     
                                   
                                              <div class="newsbox"> 
                                              <%# Convert.ToInt32(Eval("IsImg")) == 1 ? "" : "<div class='video-icon'><img src='Assets/images/icon-video.png'></div>" %> 
                                              <img src='<%# "Assets/images/news-event/thumb/" + Eval("EventImgThumbPath") %>' style="width:360px; height:373px" class="img-responsive"  width="360" height="373" loading="lazy"/>
                                                <div class="newstext">
                                                  <h4><%# Eval("EventDesc") %></h4>
                                                </div>
                                              </div>
                                              </a> </div>
                                </ItemTemplate>
                            </asp:DataList>
     </div>
     </div>
  </div>
  
  
</div>
    <!-- end awardceremony --> 
    
<!--inauguration -->
<div class="tab-pane" id="tab_inauguration">
   <div class="container">
    <div class="row rowgap">
      <div class="col-md-12">
        <h4><span class="title">2015</span> / 2014</h4>
      </div>
    </div>
    <div class="presscoverage">
      <div class="row">
       <asp:DataList runat="server" ID="dlInauguration" RepeatColumns="3" RepeatDirection="Horizontal"
                                 RepeatLayout="Flow">
                                <ItemTemplate>

                                   <div class="col-md-4">
                                    <a href='<%# Convert.ToInt32(Eval("IsImg")) == 1 ? "Assets/images/news-event/big-" + Eval("EventImgThumbPath") : Eval("EventVideo") %>'
                                     data-toggle="lightbox" data-gallery="multiimages" >
                                    
                                     
                                   
                                              <div class="newsbox">
                                              <%# Convert.ToInt32(Eval("IsImg")) == 1 ? "" : "<div class='video-icon'><img src='Assets/images/icon-video.png'></div>" %>  
                                              <img src='<%# "Assets/images/news-event/thumb/" + Eval("EventImgThumbPath") %>' style="width:360px; height:373px" class="img-responsive"  width="360" height="373" loading="lazy"/>
                                                <div class="newstext">
                                                  <h4><%# Eval("EventDesc") %></h4>
                                                </div>
                                              </div>
                                              </a> </div>
                                </ItemTemplate>
                            </asp:DataList>
      </div>
      
     
   
    </div>
  </div>
</div>

<!--end inauguration --> 

<!-- newsandmedia -->
<div class="tab-pane" id="tab_newsandmedia">
   <div class="container">
    <div class="row rowgap">
      <div class="col-md-12">
        <h4><span class="title">2015</span> / 2014</h4>
      </div>
    </div>
    <div class="presscoverage">
      <div class="row">
       <asp:DataList runat="server" ID="ddlNewsAndMedia" RepeatColumns="3" RepeatDirection="Horizontal"
                                 RepeatLayout="Flow">
                                <ItemTemplate>

                                   <div class="col-md-4">
                                    <a href='<%# Convert.ToInt32(Eval("IsImg")) == 1 ? "Assets/images/news-event/big-" + Eval("EventImgThumbPath") : Eval("EventVideo") %>'
                                     data-toggle="lightbox" data-gallery="multiimages" >
                                    
                                     
                                   
                                              <div class="newsbox"> 
                                              <%# Convert.ToInt32(Eval("IsImg")) == 1 ? "" : "<div class='video-icon'><img src='images/icon-video.png'></div>" %> 
                                              <img src='<%# "Assets/images/news-event/thumb/" + Eval("EventImgThumbPath") %>' class="img-responsive"  width="360" height="373" style="width:360px; height:373px" loading="lazy"/>
                                                <div class="newstext">
                                                  <h4><%# Eval("EventDesc") %></h4>
                                                </div>
                                              </div>
                                              </a> </div>
                                </ItemTemplate>
                            </asp:DataList>
      </div>
      
      
   
    </div>
  </div>
</div>
<!-- newsandmedia -->

   <!-- Main Content End --> <!-- Footer Start --> <UCFooter:UCFooterEndUser
    ID="UCFooterEndUser1" runat="server" /> <!-- Footer Start -->
    </form>

    <script src="Assets/js/bootstrap.min.js"></script>--%>
    <script type="text/javascript" src="Assets/js/jquery-scrolltofixed.js"></script>
    <script src="Assets/js/ekko-lightbox.js"></script>
    <script type="text/javascript">
        //var $123 = jQuery.noConflict();
        $(document).ready(function ($) {
            $(document).delegate('*[data-toggle="lightbox"]:not([data-gallery="navigateTo"])', 'click', function (event) {
                event.preventDefault();
                return $(this).ekkoLightbox({
                    onShown: function () {
                        if (window.console) {
                            return console.log('Checking our the events huh?');
                        }
                    },
                    onNavigate: function (direction, itemIndex) {
                        if (window.console) {
                            return console.log('Navigating ' + direction + '. Current item: ' + itemIndex);
                        }
                    }
                });
            });

            //Programatically call
            $('#open-image').click(function (e) {
                e.preventDefault();
                $(this).ekkoLightbox();
            });
            $('#open-youtube').click(function (e) {
                e.preventDefault();
                $(this).ekkoLightbox();
            });

            // navigateTo
            $(document).delegate('*[data-gallery="navigateTo"]', 'click', function (event) {
                event.preventDefault();

                var lb;
                return $(this).ekkoLightbox({
                    onShown: function () {

                        lb = this;

                        $(lb.modal_content).on('click', '.modal-footer a', function (e) {

                            e.preventDefault();
                            lb.navigateTo(2);

                        });

                    }
                });
            });


        });

        $(function () {


            $('.nav-tabs li a').on('click', function (e) {
              
                $("html, body").animate({ scrollTop: 200 }, "slow");
                e.preventDefault();
            });
            $('.presscoverage .col-md-4:nth-child(3n)').after('<div class="clearfix"></div>');
        });
    </script>
</body>
</html>

