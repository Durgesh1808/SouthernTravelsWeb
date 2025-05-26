<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerGroupBookings.aspx.cs" Inherits="SouthernTravelsWeb.CustomerGroupBookings" %>

<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcCustomerLeft.ascx" TagPrefix="uc1" TagName="leftuc"  %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Southern India Travel,South India Travel Packages,Travel Packages to South India
    </title>
        <link rel="shortcut icon" href="Assets/images/favicon.ico" />
 <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <meta content="Southern India Travel - South India Travel guides offering southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package."
        name="Description" />
    <meta content="southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package, south india beaches travel packages, south india holiday travel packages, holiday travel package to south india, southern india package travel, south india tourism, tourism in south india, holidays travel in southern india, kerala backwater travel packages in india, north india tour packages, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours, southern travels india, southerntravelsindia, Sirez"
        name="Keywords" />
    <meta content="index,follow" name="robots" />
    <meta content="Designed  www.Sirez.com" name="Author" />
    <meta content="MSHTML 6.00.2900.2180" name="GENERATOR" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientscript" content="Javascript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />


    <script language="javascript" type="text/javascript">
  function funShowDet1()
 {
	    document.getElementById("ddiv1").style.display = "block";
	
 }
    </script>
    
</head>
<body onload="javascript:return funShowDet1();">
 <form id="form1" runat="server">
<header class="posrel innerheader" style="background-image: url(images/banner-clear-balance.jpg)">
  
     <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server"  fldMainSection="CUST_Login"/>
 
</header>
<section class="innersection2">
  <div class="container">
  
  <div id="fixedtabsection">
    <div class="row subheadrow">
      <div class="col-md-12">
        <h1 class="title">
        <span>Booked</span> Tickets
      
        </h1>
      </div>
    </div>
    <%--<div class="row">
      <div class="col-md-12">
        <div class="tabsection_inner">
          <ul class="nav nav-tabs">
            <li ><a href="CustomerProfile.aspx?MM=1" >My Profile</a></li>
            <li class="active"><a href="#tab_bookedtkts" data-toggle="tab">Booked Tickets </a></li>
            <li><a href="CustomerCancelledtickets.aspx" > Cancelled tickets  </a></li>
            <li><a href="OnlineBalanceClear.aspx" >Balance Clearance</a></li>
          </ul>
        </div>
      </div>
    </div>--%>
     <uc1:leftuc ID="leftuc" runat="server" />
    </div>
  
    <div class="row tabspace">
      <div class="col-md-12">
        <div class="tab-content tab-content-inner">
          
          
          
         <!-- booked tickets -->
          <div class="tab-pane  fade in active" id="tab_bookedtkts"> 
          	
            
            <div class="bookedtkts">
            	
                <ul class="breadcrumb">
                <li><a href="CustomerBookedTickets.aspx??MM=2" >Fixed Tour Tickets</a></li>
                <li><a href="CustomerSplBookings.aspx??MM=2" >Special Tour Tickets</a></li>
                <li><a href="#" class="active">Group Tickets</a></li>
                </ul>
                
                <div class="tablewrap">
                	<h3 class="title">My <span>Group Tour Tickets</span><div class="welcometxt">Welcome, <span>  <% =Session["LoggedInUserName"]%></span></div></h3>
                	  <div class="paginationwrap clearfix mrgnbtm20">
                	<div class="pull-right clearfix">
                	<asp:ImageButton ID="cmdPrev1" runat="server" ImageUrl="images/paging-inactive-left.jpg" OnClick="cmdPrev1_Click"  style="vertical-align:middle">
                                        </asp:ImageButton>
                            
                             <asp:Label ID="lblCPage1" runat="server"></asp:Label>
                             
                             <asp:ImageButton ID="cmdNext1" runat="server" ImageUrl="images/paging-active-right.jpg" OnClick="cmdNext1_Click" O style="vertical-align:middle">
                                        </asp:ImageButton>
                                        </div></div>
                	  <asp:Label ID="lblMsg" runat="server"></asp:Label>
                	   <div class="tablewrap">
                                        <asp:DataGrid ID="dgDuplicateTickets" runat="server" Width="100%" CssClass="gridvw"
                                            DataKeyField="TicketCode" AutoGenerateColumns="false" OnPageIndexChanged="dgDuplicateTickets_PageIndexChanged"
                                             OnItemCommand="dgDuplicateTickets_ItemCommand">
                                            <HeaderStyle CssClass="th" />
                                            <AlternatingItemStyle CssClass="odd" />
                                            <ItemStyle CssClass="tr" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="Ticket No">
                                                    <ItemStyle HorizontalAlign="Left" Width="16%"></ItemStyle>
                                                    <ItemTemplate>
                                                        <a href="Customergroup_tickets.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"rowid") %>&Ticket=kps">
                                                            <asp:Label ID="lblticketno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ticketcode") %>'></asp:Label></a>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <%-- <asp:BoundColumn DataField="Ticketcode" HeaderText="TicketCode">
                                                <ItemStyle Width="12%" HorizontalAlign="Left" />
                                            </asp:BoundColumn>--%>
                                                <asp:BoundColumn DataField="doj" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Journey Date">
                                                    <ItemStyle Width="11%" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Dob" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Booking Date">
                                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="groupleader" HeaderText="Group Leader">
                                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="noofseats" HeaderText="Seats">
                                                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <%--<asp:TemplateColumn HeaderText="Cancel Ticket" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="center"
                                                HeaderStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button2" CommandName="btncancel" runat="server" Text="Cancel" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>--%>
                                            </Columns>
                                           <%-- <PagerStyle NextPageText="next" PrevPageText="Prev" CssClass="GridPager" Mode="NumericPages">
                                            </PagerStyle>--%>
                                        </asp:DataGrid>
                	
                	</div>
                	
                	
                </div>
                
            </div>
                 
                
          </div>         <!-- end booked tickets -->
          
       
          
       
          
        </div>
      </div>
    </div>
  </div>
</section>
<!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
<script src="Assets/js/jquery-ui.js"></script>
  <script src="Assets/js/jquery-2.2.0.min.js"></script>
    <script type="text/javascript">

        var $123 = jQuery.noConflict();
        $123(function() {

            $123('.linkqck').click(function(e) {
                $123(".qckenqwrap").show().animate({
                    right: "0px"

                }, 300, function() {

                });



                e.preventDefault();
            });


            $123('.closebtn a').click(function(e) {

                $123(".qckenqwrap").animate({
                    right: "-300px"


                }, 300, function() {
                    // Animation complete.
                    //$('.slider-arrow img').css('cursor','pointer');
                });


                e.preventDefault();
            });


            $123('.placescoveredtbl .pcwrap ul li a').click(function(e) {
                $123('.nav-tabs li').removeClass('active');
                $123('a[href="#tab_tourinfo"]').parent().addClass('active');
                $123('#tab_dateprice').removeClass('active in');
                $123('#tab_tourinfo').addClass('active in');
                //$('a').attr().parent().addClass('active');
                e.preventDefault();
            });



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
</script>


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
</form>
</body>
</html>

