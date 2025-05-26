<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerCancelledTickets.aspx.cs" Inherits="SouthernTravelsWeb.CustomerCancelledTickets" %>

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


    
    
</head>
<body>
 <form id="form1" runat="server">
<header class="posrel innerheader" style="background-image: url(Assets/images/banner-clear-balance.jpg)">
  
     <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server"  fldMainSection="CUST_Login"/>
  
</header>
<section class="innersection2">
  <div class="container">
  
  <div id="fixedtabsection">
    <div class="row subheadrow">
      <div class="col-md-12">
        <h1 class="title">
        <span>Cancelled</span> tickets
      <%--<div class="welcometxt pull-right">Welcome, <span>  <% =Session["LoggedInUserName"]%></span></div>--%>
        </h1>
      </div>
    </div>
    <%--<div class="row">
      <div class="col-md-12">
        <div class="tabsection_inner">
          <ul class="nav nav-tabs">
            <li ><a href="CustomerProfile.aspx?MM=1" >My Profile</a></li>
            <li><a href="CustomerBookedtickets.aspx?SM=21" >Booked Tickets </a></li>
            <li class="active"><a href="#" > Cancelled tickets  </a></li>
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
            	
                
                
                <div class="tablewrap">
                	<h3 class="title">My <span>Cancelled Tour Tickets</span><div class="welcometxt">Welcome, <span>  <% =Session["LoggedInUserName"]%></span></div></h3>
                	<div class="paginationwrap clearfix mrgnbtm20">
                	<div class="pull-right clearfix">
                	<asp:ImageButton ID="cmdPrev1" runat="server" ImageUrl="Assets/images/paging-inactive-left.jpg" OnClick="cmdPrev1_Click"  style="vertical-align:middle">
                                        </asp:ImageButton>
                            
                             <asp:Label ID="lblCPage1" runat="server"></asp:Label>
                             
                             <asp:ImageButton ID="cmdNext1" runat="server" ImageUrl="Assets/images/paging-active-right.jpg" OnClick="cmdNext1_Click" O style="vertical-align:middle">
                                        </asp:ImageButton>
                                        </div></div>
                	 <asp:Label ID="lblMsg" runat="server"></asp:Label>
                	 <div class="tablewrap">
                                        <asp:DataGrid ID="dgrReports" runat="server" AutoGenerateColumns="False" DataKeyField="RowId"
                                            CssClass="tablewrap" Width="100%" OnPageIndexChanged="dgrReports_PageIndexChanged"
                                            OnItemDataBound="dgrReports_ItemDataBound">
                                            <HeaderStyle CssClass="th"/>
                                            <AlternatingItemStyle  />
                                            <ItemStyle />
                                            <Columns>
                                                <asp:BoundColumn DataField="RowId" Visible="False" ReadOnly="True"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="S No">
                                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <span>
                                                            <%#(dgrReports.CurrentPageIndex * dgrReports.PageSize)+ (Container.ItemIndex) + 1%>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="TransactionDate" HeaderText="Booking Date" DataFormatString="{0:dd/MM/yyyy}">
                                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Transaction No">
                                                    <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdOrderNo" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"Ticketno") %>' />
                                                        <asp:HiddenField ID="hdRowID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"RowID") %>' />
                                                        <%--<a href="Customercancel_ticket.aspx?orderid=<%#DataBinder.Eval(Container.DataItem,"Ticketno") %>&Ticket=kps">--%>
                                                        <asp:HyperLink ID="hrLink" runat="server">
                                                            <asp:Label ID="lblticketno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RefNo") %>'></asp:Label>
                                                        </asp:HyperLink><%--</a>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="Cannotick" HeaderText="No Of Pax">
                                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="TicketAmount" HeaderText="Ticket Amount">
                                                    <ItemStyle HorizontalAlign="Right" Width="9%" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="CanCharges" HeaderText="Cancellation Charge">
                                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="RefundAmt" HeaderText="Refund Amount">
                                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Ticketno" HeaderText="Ticket No">
                                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                                </asp:BoundColumn>
                                            </Columns>
                                            <%-- <PagerStyle NextPageText="next" PrevPageText="Prev" CssClass="GridPager" Mode="NumericPages"
                                                Height="8px" />--%>
                                        </asp:DataGrid>
                	</div>
                	
                	
                	
                	
                	
                	
                	
                	
                	
                	
                	
                	
                	<%--<table width="100%" border="0" class="table-bordered">
                      <tr>
                        <th>Ticket No.</th>
                        <th>Journey Date</th>
                        <th>Booking Date</th>
                        <th>Group Leader</th>
                        <th>Seats</th>
                        <th>Cancel Ticket</th>
                      </tr>
                      
                      <tr>
                        <td><a href="#">SPL003567</a></td>
                        <td>16/07/2015</td>
                        <td>07/05/2015</td>
                        <td>Mr. K Sridhar</td>
                        <td>4</td>
                        <td><input type="submit" value="Cancel" class="commonbtn"></td>
                      </tr>
                      
                       <tr>
                        <td><a href="#">SPL003567</a></td>
                        <td>16/07/2015</td>
                        <td>07/05/2015</td>
                        <td>Mr. K Sridhar</td>
                        <td>4</td>
                        <td><input type="submit" value="Cancel" class="commonbtn"></td>
                      </tr>
                      
                    </table>--%>

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




<!-- SCRIPTS -->
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

