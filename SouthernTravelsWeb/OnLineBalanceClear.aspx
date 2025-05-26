<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnLineBalanceClear.aspx.cs" Inherits="SouthernTravelsWeb.OnLineBalanceClear" %>

<%@ Register Src="UserControl/UcHolidaySearch.ascx" TagName="UCHolidaySearch" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcFixedTourList.ascx" TagName="UCFixedTour" TagPrefix="UCTourList" %>
<%@ Register Src="UserControl/UcBlog.ascx" TagName="ucBlog" TagPrefix="uc2" %>
<%@ Register Src="UserControl/UcCustomerLeft.ascx" TagPrefix="uc1" TagName="leftuc"  %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" itemscope itemtype="http://schema.org/WebSite">
<head id="Head1"  itemtype="http://schema.org/TravelAgency" runat="server">
    <title>Online Balance Clear : Southern Travels</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="Description" content="Southern Travels ensure to make your payment safe and easy with reliable payment transaction procedure." />
    <script language="javascript" type="text/javascript">
        function approve() {
            window.open('frmterms.aspx?', 'pops', 'width=418,height=249,scrollbars=yes');
        }
        function search() {
            if (document.getElementById('txtticketno').value == "") {
                alert('Please Enter Ticket Number');
                document.getElementById('txtticketno').focus();
                return false;
            }

        }


        function validation() {

            if (document.getElementById('txtticketno').value == "") {
                alert('Please Enter Ticket Number');
                document.getElementById('txtticketno').focus();

                return false;
            }
            if (document.getElementById('txtbalancepaidnow').value == "") {
                alert('Please Enter Balance Paid Amount');
                document.getElementById('txtbalancepaidnow').focus();
                che = false;
                return false;
            }
            if ((parseFloat(document.getElementById('txtbalancepaidnow').value) + parseFloat(document.getElementById('txtESC').value)) <= 0) {
                alert('Please Enter Balance Paid Amount');
                document.getElementById('txtbalancepaidnow').focus();
                che = false;
                return false;
            }

            var total = parseFloat(document.getElementById('txttotalwithtax').value);
            var advance = parseFloat(document.getElementById('txtamountpaidtill').value);
            var presentamt = parseFloat(document.getElementById('txtbalancepaidnow').value);
            if (parseFloat(total) < (parseFloat(advance) + parseFloat(presentamt))) {
                alert('Amount Paid is greater Than Balance Pending Amount');
                document.getElementById('txtbalancepaidnow').value = "";
                document.getElementById('txtbalancepaidnow').value = "0";
                document.getElementById('txtbalancepending').value = "0";
                document.getElementById('txtbalancepaidnow').focus();
                return false;
            }


            if (document.getElementById("rdoNetBanking").checked == false && document.getElementById("rdoCC").checked == false
        && document.getElementById("rdoDC").checked == false && document.getElementById("rbtnPayu").checked == false
        && document.getElementById("rbtnAtom").checked == false && document.getElementById("rbtnInstamojo").checked == false) {
                alert("please choose the payment option");
                return false;
            }

            if (document.getElementById("chkTrue").checked == false) {
                alert("before submit you should agree with terms and conditions");
                return false;
            }


            document.getElementById('btnpay').style.display = 'none';
            return true;



        }


        function balance() {

            var balance = parseFloat(document.getElementById('txtbalancetill').value);
            var paid = parseFloat(document.getElementById('txtbalancepaidnow').value);
            var EscAmount = parseFloat(document.getElementById('txtESC').value);

            if (parseFloat(balance) < parseFloat(paid)) {
                alert('Amount Paid is greater Than Balance Pending Amount');
                document.getElementById('txtbalancepaidnow').value = "0";
                document.getElementById('txtbalancepending').value = "0";
                document.getElementById('txtbalancepaidnow').focus();
                return false;
            }
            else {
                document.getElementById('txtbalancepending').value = roundNumber((parseFloat(balance) - parseFloat(paid)));
                document.getElementById('txtTotalAmunt').value = roundNumber((parseFloat(paid) + parseFloat(EscAmount)));
            }
        }

        function chkNumeric(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode == 13)
                document.getElementById('btnpay').click();
            if (charCode > 31 && (charCode < 45 || charCode > 57) || (charCode == 47 || charCode == 45))
                return false;

            return true;
        }

        function roundNumber(num) {
            var result = Math.round(num * Math.pow(10, 2)) / Math.pow(10, 2);
            return result;
        }



        function setClipBoardData() {
            setInterval("window.clipboardData.setData('text','')", 20);
        }


        var oLastBtn = 0;
        bIsMenu = false;

        if (window.Event)
            document.captureEvents(Event.MOUSEUP);

        function nocontextmenu() {
            event.cancelBubble = true
            event.returnValue = false;
            return false;
        }
        function norightclick(e) {
            if (window.Event) {
                if (e.which != 1)
                    return false;
            }
            else
                if (event.button != 1) {
                    event.cancelBubble = true
                    event.returnValue = false;
                    return false;
                }
        }
        document.oncontextmenu = nocontextmenu;
        document.onmousedown = norightclick;

        function onKeyDown() {

            if ((event.altKey) || ((event.keyCode == 8) && (event.srcElement.type != "text" && event.srcElement.type != "textarea" && event.srcElement.type != "password")) || ((event.ctrlKey) && ((event.keyCode == 78) || (event.keyCode == 82))) || (event.keyCode == 116)) {
                event.keyCode = 0;
                event.returnValue = false;
            }
        }
    
    </script>
    <script type="text/javascript"> 
        
    
    
    </script>
    <style type="text/css">
        .black_overlay
        {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 230%;
            background-color: Gray;
            z-index: 2001;
            -moz-opacity: 0.8;
            opacity: .80;
            filter: alpha(opacity=80);
        }
        .white_content
        {
            display: none;
            position: absolute;
            top: 95%;
            left: 10%;
            width: 80%;
            height: 65%;
            padding: 16px;
            border: 1px solid orange;
            background-color: white;
            z-index: 2002;
            overflow: auto;
        }
    </style>
    <style>
        .gridvwborder
        {
            width: 700px;
            float: left;
            border: #BF3411 solid 1px;
        }
    </style>
    <style>
        .pnl
        {
            background-color: Red;
            font-family: Arial, Helvetica, sans-serif;
            color: #ED1C24;
        }
        .popUpStyle
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
        .modal
        {
            background-color: #ED1C24;
            background-image: url('Assets/images/leaf.gif' );
        }
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.60;
        }
        .updateProgress
        {
            border-width: 1px;
            border-style: solid;
            background-color: #FFFFFF;
            position: absolute;
            width: 210px;
            height: 54px;
            top: 649px;
            left: 0px;
        }
        .updateProgressMessage
        {
            margin: 3px;
            font-family: Trebuchet MS;
            font-size: small;
            vertical-align: middle;
        }
    </style>
    <style type="text/css">
        .black_overlay
        {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 260%;
            background-color: Gray;
            z-index: 2001;
            -moz-opacity: 0.8;
        }
        .white_content
        {
            display: none;
            position: absolute;
            top: 95%;
            left: 10%;
            width: 80%;
            height: 65%;
            padding: 16px;
            border: 1px solid orange;
            background-color: white;
            z-index: 2002;
            overflow: auto;
        }
        .white_11px
        {
            color: #555555;
            font-stretch: condensed;
            font-weight: bold;
            text-decoration: none;
            font-size: 12px;
        }
    </style>
    <script>

        (function (i, s, o, g, r, a, m) {

            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {

                (i[r].q = i[r].q || []).push(arguments)

            }, i[r].l = 1 * new Date(); a = s.createElement(o),

  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)

        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');



        ga('create', 'UA-4994177-1', 'auto');

        ga('require', 'displayfeatures');

        ga('send', 'pageview');

 

    </script>
    <script type="text/javascript">

        function printEscReceipt(escVoucherno) {
            var Cid = document.getElementById('<%=txtticketno.ClientID%>').value;
            var TicketType = document.getElementById('<%=hdnticketType.ClientID%>').value;
            if (Cid == "") {
                alert("please enter ticket no");
                return false;
            }
            if (TicketType == "E") {
                window.open('Branch/ESCCollectionReceipt.aspx?TicketNo=' + Cid + '+&VoucherNo=' + escVoucherno + ' ', 'pops', 'width=1000,height=800');
            }
            else if (TicketType == "S") {
                window.open('Branch/SpecialTourEscCollectionReceipt.aspx?TicketNo=' + Cid + '+&VoucherNo=' + escVoucherno + ' ', 'pops', 'width=1000,height=800');
            }
            else if (TicketType == "G") {
                window.open('Branch/GrptourEscCollectionReceipt.aspx?TicketNo=' + Cid + '+&VoucherNo=' + escVoucherno + ' ', 'pops', 'width=1000,height=800');
            }
            return false;
        }

    </script>
    <!-- Begin Inspectlet Embed Code -->
    <script type="text/javascript" id="inspectletjs">
        window.__insp = window.__insp || [];
        __insp.push(['wid', 996100346]);
        (function () {
            function ldinsp() { if (typeof window.__inspld != "undefined") return; window.__inspld = 1; var insp = document.createElement('script'); insp.type = 'text/javascript'; insp.async = true; insp.id = "inspsync"; insp.src = ('https:' == document.location.protocol ? 'https' : 'http') + '://cdn.inspectlet.com/inspectlet.js'; var x = document.getElementsByTagName('script')[0]; x.parentNode.insertBefore(insp, x); };
            setTimeout(ldinsp, 500); document.readyState != "complete" ? (window.attachEvent ? window.attachEvent('onload', ldinsp) : window.addEventListener('load', ldinsp, false)) : ldinsp();
        })();
    </script>
    <!-- End Inspectlet Embed Code -->
    <!-- Google Tag Manager -->
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
    <form id="form" runat="server" style="margin: 0px;">
    <asp:HiddenField ID="hdnticketType" Value="" runat="server" />
    <asp:HiddenField ID="hdfIsESC" Value="0" runat="server" />
    <!-- Header Start -->
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-clear-balance.jpg)">
  <div class="herobanner">
     <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" fldMainSection="CUST_Login"/>
  </div>
  </header>
    <section class="innersection2">
  <div class="container">
  <div id="fixedtabsection">
    <div class="row subheadrow">
      <div class="col-md-12">
        <h1 class="title">
        <span>My </span> Account
        </h1>
      </div>
    </div>
  
    <uc1:leftuc ID="leftuc" runat="server" />
    </div>
  
  
    <div class="row tabspace">
      <div class="col-md-12">
        <div class="tab-content tab-content-inner">
          
         
        <!-- Balance Clearance -->
          <div class="tab-pane fade in active"  id="tab_balanceclear" runat="server"> 
           <div class="row">
            	<div class="col-md-4">
                <div class="bclear_left">
                	<h3 class="title"><span>Ticket</span> No</h3>
                    
                    <div class="graybrdrbox boxspacer_vert">
                    	
                        <div class="formwrap">
                        	<p class="mrgnbtmno">
                        	<input type="text" class="form-control" id="txtticketno" maxlength="50" name="txtticketno" runat="server" >
                        	
                        	</p>
                             <p class="mrgnbtmno">
                               <asp:Button ID="Submit" class="btn" runat="server" Text="Show Details" OnClientClick="Javascript:return search();" OnClick="Submit_Click"></asp:Button>
                           </p>
                            
                        </div>
                        
                    </div>
                    
                    <div class="graybrdrbox">
                    	<div class="row header">
                        <div class="col-md-5 paddingright0"><span>
                        Tour Name</span></div>
                         <div class="col-md-7 paddingright0">
                        <!--  Kashmir Package-By Ac Volvo -->
                            <asp:Label ID="txttourname" Style="width: 569px; border: none; background: none;
                                        color: #333;" runat="server" />
                         
                         </div>
                         <div class="clearfix"></div>
                         <div class="col-md-5 paddingright0"><span>Group Leader Name</span></div>
                         <div class="col-md-7 paddingright0">
                         <!-- John Smith -->
                           <input id="txtgroupleadername" readonly style="width: 569px; border: none; background: none;
                                        color: #333;" maxlength="150" type="text" name="txtGroupleadername" runat="server" />
                                        
                         </div>
                         
                        </div>
                        
                        <div class="row bgwhite paddingtop15">
                        <div class="formwrap">
                            
                        	<div class="col-md-12">
                            Amount
                            </div>
                        	
                        	
                        	<div class="col-md-12">
                            	<!-- <input type="text" class="form-control" placeholder="Amount">-->
                            	  <asp:Label ID="lblAmtGross" runat="server" Text=""> </asp:Label>
                                            <input id="txtamount" maxlength="10" readonly type="text" name="txtamount" runat="server"
                                               class="form-control" placeholder="Amount" />
                            </div>
                            
                            
                          <div class="col-md-12">
                            Discount
                            </div>
                            <div class="col-md-12">
                            	<!--  <input type="text" class="form-control" placeholder="Discount"> -->
                            	      <input id="txtdiscount" maxlength="10" readonly type="text" name="txtdiscount" runat="server"
                                                class="form-control" placeholder="Discount" />
                            	
                            </div>
                            
                             <div class="col-md-12">
                            GST
                            </div>
                            
                            <div class="col-md-12">
                             <!--input type="text" class="form-control" placeholder="GST"> -->
                              <input id="txtTax" maxlength="10" readonly name="txtTax" runat="server" class="form-control" placeholder="GST" />
                            </div>
                            
                            <div class="col-md-12">
                           Total Amount With Tax
                            </div>
                            
                            <div class="col-md-12">
                                 <!-- <input type="text" class="form-control" placeholder="Total Amount With Tax"> -->
                                 
                                <input id="txttotalwithtax" maxlength="10" readonly type="text" name="txttotalwithtax"
                                               class="form-control" placeholder="Total Amount With Tax" runat="server" />
                                 
                            </div>
                            
                            <div class="col-md-12">
                          Amount paid Till Now
                            </div>
                             <div class="col-md-12">
                              <!-- <input type="text" class="form-control" placeholder="Amount paid Till Now">-->
                              
                            	 <input id="txtamountpaidtill" maxlength="10" readonly type="text" name="txtamountpaidtill"
                                                runat="server" class="form-control" placeholder="Amount paid Till Now" />
                            </div>
                            
                            
                            
                    <div class="col-md-12">
                         Balance Till Now
                            </div>
                            

                            
                             <div class="col-md-12">
                             
                            <!-- <input type="text" class="form-control" placeholder="Balance Till Now"> -->
                            
                             <input id="txtbalancetill" maxlength="10" readonly type="text" name="txtbalancetill"
                                               class="form-control" placeholder="Balance Till Now" runat="server" />
                            	
                            </div>
                            <div class="col-md-12" id="divEscHeading" runat="server" style="display:none;">
                             <span>
                             Extra Service Charge
                             </span>
                            </div>
                            
                             <div class="col-md-12" id="divescAmount" runat="server"  style="display:none;">
                            <!--<input type="text" class="form-control" placeholder="Balance Pay Now"> -->
                             <input id="txtESC" maxlength="6" type="text" name="txtESCDetail"
                                              class="form-control" placeholder="Extra Service Charge" runat="server" value="0" onkeypress="javascript:return chkNumeric(event);"
                                                onblur="javascript:return balance();" />
                            
                            </div>
                            
                             <div class="col-md-12">
                             <span>
                            Balance Pay Now
                             </span>
                            </div>
                             <div class="col-md-12">
                            <!--<input type="text" class="form-control" placeholder="Balance Pay Now"> -->
                             <input id="txtbalancepaidnow" maxlength="6" type="text" name="txtbalancepaidnow"
                                              class="form-control" placeholder="Balance Pay Now" runat="server" value="0" onkeypress="javascript:return chkNumeric(event);"
                                                onblur="javascript:return balance();" />
                            
                            </div>
                            
                            
                            
                            <div class="col-md-12" id="divTotalAmountHead" runat="server" style="display:none">
                             <span>
                           Total Amount 
                             </span>
                            </div>
                             <div class="col-md-12" id="divTotalAmountValue" runat="server" style="display:none">
                            <!--<input type="text" class="form-control" placeholder="Balance Pay Now"> -->
                             <input id="txtTotalAmunt" maxlength="6" type="text" name="TotalAmunt" readonly 
                                              class="form-control" placeholder="Balance Pay Now" runat="server" value="0" onkeypress="javascript:return chkNumeric(event);"
                                                />
                            </div>
                            
                            
                            
                             <div class="col-md-12">
                             <span>
                            Balance Pending
                             </span>
                            </div>
                             <div class="col-md-12">
                            	<!-- <input type="text" class="form-control" placeholder="Balance Pending">-->
                            	  <input id="txtbalancepending" readonly class="form-control" placeholder="Balance Pending" maxlength="6" type="text" name="txtbalancepending"
                                                runat="server" />
                            </div>
                            
                            
                            </div>
                        </div>
                        
                    </div>
                    
                </div>
                </div>
                <div class="col-md-8">
                
                <div class="tablewrap mrgnbtm20">
                
                <!-- <asp:DataGrid ID="dgpaymentdetails" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                                        CssClass="gridvw" CellPadding="0" BorderWidth="0" ShowFooter="false" Width="100%"
                                        BackColor="Silver" GridLines="Horizontal">
                                        <HeaderStyle CssClass="odd orange" />
                                        <AlternatingItemStyle CssClass="odd" />
                                        <ItemStyle CssClass="even" />
                                        <FooterStyle ForeColor="Maroon" Font-Bold="True"></FooterStyle>
                                        <Columns>
                                            <asp:BoundColumn DataField="Bookingdate" HeaderText="Booking Date " DataFormatString="{0:dd/MM/yyyy}"
                                                ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="startdate" ReadOnly="True" HeaderText="Journey Date"
                                                DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="totalamount" HeaderText="Total Amount" ReadOnly="True"
                                                ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="advancepaid" HeaderText="Amount Paid" ReadOnly="True"
                                                ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="paymentdate" HeaderText="Payment Date" ReadOnly="True"
                                                ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px" DataFormatString="{0:dd/MM/yyyy}">
                                            </asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                                    </asp:DataGrid>
                         -->
                         
          <asp:Repeater ID="repPaymentDetails" runat="server">
              <HeaderTemplate>
    <table width="100%" border="0" class="table-bordered" cellpadding="0" cellspacing="0">
  <tr>
    <th>Booking Date</th>
    <th>Journey Date</th>
    <th>Total Amount</th>
    <th>Amount Paid</th>
    <th>Payment Date</th>
  </tr>
 </HeaderTemplate>
   <ItemTemplate>
     <tr>
    <td><%#DataBinder.Eval(Container.DataItem, "Bookingdate", "{0:dd/MM/yyyy}")%></td>
    <td><%#DataBinder.Eval(Container.DataItem, "startdate", "{0:dd/MM/yyyy}")%></td>
    <td><%#DataBinder.Eval(Container.DataItem, "totalamount")%></td>
    <td><%#DataBinder.Eval(Container.DataItem, "advancepaid")%></td>
    <td><%#DataBinder.Eval(Container.DataItem, "paymentdate", "{0:dd/MM/yyyy}")%></td>
  </tr>
              </ItemTemplate>
              <FooterTemplate>
                </table>
              </FooterTemplate>
       </asp:Repeater>                  
<br />
<br />
                        
 <asp:Repeater ID="RptPaidUnpaidSeviceChargeList" runat="server" 
                        onitemdatabound="RptPaidUnpaidSeviceChargeList_ItemDataBound"               >
              <HeaderTemplate>
    <table width="100%" border="0" class="table-bordered" cellpadding="0" cellspacing="0">
  <tr>
    <th>VoucherNo</th>
    <th>ServiceName</th>
    <th>Amount</th>
    <th>Status</th>
     <th>Paymentdate</th>
     <th>Print Receipt</th>
  </tr>
 </HeaderTemplate>
   <ItemTemplate>
    <tr>
    <td>   <asp:Label runat="server" ID="lblVoucherNo" Text='<%# DataBinder.Eval(Container, "DataItem.VoucherNo") %>'></asp:Label></td>
    <td><%# DataBinder.Eval(Container, "DataItem.ServiceName")%></td>
    <td><asp:Label runat="server" ID="lblAmount" Text='<%# DataBinder.Eval(Container, "DataItem.Amount") %>'></asp:Label></td>
    <td> <asp:Label runat="server" ID="lblstatus" Text='<%# DataBinder.Eval(Container, "DataItem.Status") %>'></asp:Label></td>
   <td><%#DataBinder.Eval(Container.DataItem, "paymentdate", "{0:dd/MM/yyyy}")%></td>
  <td> <asp:Button ID="btnPrint" runat="server" Text="Print Receipt" class="commonbtn"></asp:Button> </td>
   
  </tr>
              </ItemTemplate>
              <FooterTemplate>
                </table>
              </FooterTemplate>
          
      </asp:Repeater>  
      
 


                </div>
                
                <h3 class="title"><span>Payment</span> Option</h3>
                <div class="custpaydetail mrgntopno">
                
                <div class="graybrdrbox">
                	 <div class="paymentoption">
                            	
                                <ul class="payoptionlist">
                                
                                  <li><asp:RadioButton CssClass="radiobtnwrap" ID="rbtnInstamojo" runat="server" Text="" GroupName="rdoPayment"
                                                         onclick="CardShow('divSubOpt',this);changeBank(this.value,'');AtomCardShow('tblAtom',this);" />        
                                    
                                     <!-- Icon and text change section -->
                                            <span>Credit Card/Debit Card/Net Banking/UPI/Wallets- Powered by <asp:Image ID="Image4" runat="server" ImageUrl="Assets/images/instamojo-logo.png" Height="35px" ></asp:Image> </span>
                                             <!-- End -->
                                             </li> 
                                             
                                             
                                               <li><label>
                                     <!-- <input type="radio" name="payoption"> Amex Credit Card</label> -->
                                     <asp:RadioButton ID="rbtnPayu" runat="server" Text="" GroupName="rdoPayment"
                                                    CssClass="RB2"/>
                                                     <span>Credit Card/Debit Card/Net Banking/UPI/EMI/Wallets- Powered by<asp:Image ID="Image6" runat="server" ImageUrl="Assets/images/payu.jpg" Height="35px" ></asp:Image> </span>
                                      </li>
                                
                                	<li><label>
                                	   <!--  <input type="radio" name="payoption"> Atom Payment <span>( Credit / Debit Card, Net Banking, EMI Options )</span> -->
                                	     <asp:RadioButton ID="rbtnAtom" runat="server"  GroupName="rdoPayment" />
                                                      <!-- Icon and text change section -->
                                            <span> Credit / Debit Card / Net Banking- Powered by <asp:Image ID="imgPaymentLogoAtom" runat="server" ImageUrl="Assets/images/atompayment.png" Height="35px" ></asp:Image> </span>
                                             <!-- End -->
                                	  
                                	  </label> 
                                	 
                                	 
                                    </li>
                                    
                                    
                                   
                                    
                                    
                                    
                                    <li style="display:none;"><label>
                                    
                                    <!--  <input type="radio" name="payoption"> Tech Process<span> ( Credit / Debit Card, Net Banking ) </span> -->
                                               <asp:RadioButton ID="rdoNetBanking" runat="server" Text="&nbsp;Tech Process" GroupName="rdoPayment"
                                                    />
                                                      <!-- Icon and text change section -->
                                            <span>Credit / Debit Card / Net Banking- Powered by <asp:Image ID="Image1" runat="server" ImageUrl="Assets/images/techprocesspayment.png" Height="40px" ></asp:Image> </span>
                                             <!-- End -->
                                     
                                     </label>
                                     
                                      </li>
                                    
                                    
                                    
                                    
                                    <li><label>
                                    
                                    <!--  <input type="radio" name="payoption"> Tech Process<span> ( Credit / Debit Card, Net Banking ) </span> -->
                                                
                                                <asp:RadioButton ID="rdoDC" runat="server"  GroupName="rdoPayment"     />
                                                
                                                  <!-- Icon and text change section -->
                                            <span> Debit Card- Powered by <asp:Image ID="Image2" runat="server" ImageUrl="Assets/images/hdfcpayment.png" Height="35px" ></asp:Image> </span>
                                             <!-- End -->
                                     
                                     </label>
                                     
                                      </li>
                                     <!-- 
                                    <li>
                                      <label>
                                         <input type="radio" name="payoption"> Debit Card
                                       
                                       </label>
                                    
                                     </li>
                                     -->
                                     
                                    <li><label> 
                                     <!--  <input type="radio" name="payoption"> Credit Card -->
                                          <asp:RadioButton ID="rdoCC" runat="server" GroupName="rdoPayment"
                                             />
                                     
                                     </label> 
                                       <!-- Icon and text change section -->
                                            <span> Credit Card- Powered by <asp:Image ID="Image3" runat="server" ImageUrl="Assets/images/hdfcpayment.png" Height="35px" ></asp:Image> </span>
                                             <!-- End -->
                                    </li>
                                    
                                  
                                      
                                      
                                    
                                    
                                    
                                </ul>
                                
                                
                                <ul class="chkboxlist">
                                <li><label>
                                
                             <!--    <input type="checkbox"> I here by agree to the terms &amp; conditions.  </label> -->
                                   <asp:CheckBox ID="chkTrue" runat="server" CssClass="CB" />
                                                I here by agree to the  <a href="Terms-Conditions.aspx"  target="_blank"><b>terms &amp; conditions.</b></a>
                                                </label>
                                
                                </li>
                                <li><label>
                                      <!-- <input type="checkbox"> I would like to be kept infromed of special promotions and offers by Southern Travels. </label> -->
                                       <asp:CheckBox ID="chkInformed" runat="server" Text="I would like to be kept infromed of special promotions and offers by Southern Travels."/>
                                   </li>
                                </ul>
                                
                                <div class="btnwrap">
                                
                                	<!-- <input type="button" value="Submit &amp; Pay Now" class="commonbtn"> -->
                                	   <asp:Button ID="btnpay" runat="server" Text="Submit &amp; Pay Now" class="commonbtn" OnClick="btnpay_Click"></asp:Button>
                                	   <asp:Button ID="btnPrint" runat="server" Text="Reset" class="commonbtn" OnClick="btnPrint_Click"></asp:Button>
                                
                                </div>
                                
                            </div>
                            </div>
                 
                  <div class="weaccept paddingleft0">
                               <h3 class="title">We <span>Accept</span></h3>
                               <p><a href="#"><img src="Assets/images/weaccept1.jpg"></a> <a href="#"><img src="Assets/images/weaccept2.jpg"></a> <a href="#"><img src="Assets/images/weaccept3.jpg"></a> <a href="#"><img src="Assets/images/weaccept4.jpg"></a> <a href="#"><img src="Assets/images/weaccept5.jpg"></a> <a href="#"><img src="Assets/images/weaccept6.jpg"></a> <a href="#"><img src="Assets/images/weaccept7.jpg"></a><a href="#"><img src="Assets/images/weaccept8.jpg"></a> <a href="#"><img src="Assets/images/weaccept9.jpg"></a></p>
                             
                                
                            </div>
                            
				</div>
                	
                </div>
            </div>
                  
                 
                
          </div>         <!-- end Balance Clearance -->
          
       
          
        </div>
      </div>
    </div>
    <div id="fade" class="black_overlay">
        </div>
        <input id="CSTBANKID" type="hidden" runat="server" />
  </div>
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    <asp:Panel ID="Panel3" runat="server" class="PopUp" BackColor="White" BorderWidth="1"
        BorderColor="Red" Style="display: none; padding: 20px;" Width="951px">
        <%--<div style="float: left;">
                <h1 class="orange24">
                    Payment</h1>
            </div>--%>
        <div style="float: right; margin-right: -30px; margin-top: -30px;">
            <asp:ImageButton runat="server" ID="lnkClose" ImageUrl="Assets/images/facebox/closelabel.png" OnClick="lnkClose_Click" /></div>
        <%-- <div align="right" style="padding-right: 10px;">
                <asp:LinkButton ID="lnkClose" runat="server" Font-Size="12pt" OnClick="lnkClose_Click">Close</asp:LinkButton>--%>
        <div class="hPP">
            <div class="tPD top0">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td height="30">
                            <input id="Radio1" type="radio" onclick="changeBank(this.value,'Allahabad Bank');"
                                name="rbPayOpt" value="280" />
                            <img src="Assets/images/allahabadbank.jpg" alt="Allahabad Bank" border="0" style="vertical-align: top" />
                            Allahabad Bank
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle;">
                                <input id="Radio2" type="radio" onclick="changeBank(this.value,'AXIS Bank');" name="rbPayOpt"
                                    value="50" />
                                <img src="Assets/images/axis_bank.gif" alt="AXIS Bank" border="0" style="vertical-align: top" />
                                AXIS Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb19" type="radio" onclick="changeBank(this.value,'Bank of Bahrain and Kuwait');"
                                    name="rbPayOpt" value="340" />
                                <img src="Assets/images/Bank-of-Bahrain-and-Kuwait.jpg" alt="Bank of Bahrain and Kuwait"
                                    border="0" style="vertical-align: top" />
                                Bank of Bahrain and Kuwait</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle;">
                                <input id="Radio3" type="radio" onclick="changeBank(this.value,'Bank of Baroda');"
                                    name="rbPayOpt" value="310" />
                                <img src="Assets/images/bob.jpg" alt="Bank of Baroda" border="0" style="vertical-align: middle" />
                                Bank of Baroda</div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio4" type="radio" onclick="changeBank(this.value,'Bank of India');"
                                    name="rbPayOpt" value="240" />
                                <img src="Assets/images/bank_ofindia.gif" alt="Bank of India" border="0" style="vertical-align: top" />
                                Bank of India
                            </div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio11" type="radio" onclick="changeBank(this.value,'Bank of Maharashtra');"
                                    name="rbPayOpt" value="750" />
                                <img src="Assets/images/Bank-of-Maharashtra.jpg" alt="Bank of Maharashtra" width="70px"
                                    height="24px" border="0" style="vertical-align: top" />
                                Bank of Maharashtra
                            </div>
                        </td>
                       
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <%----%>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio5" type="radio" onclick="changeBank(this.value,'Beam Cash Card');"
                                    name="rbPayOpt" value="320" />
                                <img src="Assets/images/beam-cash-card.jpg" alt="Beam Cash Card" border="0" style="vertical-align: middle" />
                                Beam Cash Card
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio6" type="radio" onclick="changeBank(this.value,'Central Bank of India');"
                                    name="rbPayOpt" value="740" />
                                <img src="Assets/images/Central-Bank-Of-India.jpg" alt="Central Bank of India" border="0"
                                    style="vertical-align: middle" />
                                Central Bank of India
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb24" type="radio" onclick="changeBank(this.value,'Citi Bank');" name="rbPayOpt"
                                    value="230" />
                                <img src="Assets/images/Citi-Bank.jpg" alt="Citi Bank" border="0" style="vertical-align: middle" />
                                Citi Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio12" type="radio" onclick="changeBank(this.value,'City Union Bank');"
                                    name="rbPayOpt" value="440" />
                                <img src="Assets/images/City_Union_Bank.jpg" alt="City Union Bank" border="0" style="vertical-align: middle" />
                                City Union Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio25" type="radio" onclick="changeBank(this.value,'Canara Bank');"
                                    name="rbPayOpt" value="930" />
                                <img src="Assets/images/Canarabank_Logo.gif" alt="Canara Bank" border="0" style="vertical-align: middle"
                                    height="24" width="70" />
                                Canara Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio5" type="radio" onclick="changeBank(this.value,'Catholic Syrian Bank');"
                                    name="rbPayOpt" value="1130" />
                                <img src="Assets/images/csb.jpg" alt="Catholic Syrian Bank" border="0" style="vertical-align: middle"
                                    height="24" width="70" />
                                Catholic Syrian Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb17" type="radio" onclick="changeBank(this.value,'Deutsche Bank');" name="rbPayOpt"
                                    value="330" />
                                <img src="Assets/images/Deutsche-Bank.jpg" alt="Deutsche Bank" border="0" style="vertical-align: middle" />
                                Deutsche Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio13" type="radio" onclick="changeBank(this.value,'Development Credit Bank');"
                                    name="rbPayOpt" value="540" />
                                <img src="Assets/images/Development_Credit_Bank.jpg" alt="Development Credit Bank" border="0"
                                    style="vertical-align: middle" />
                                Development Credit Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb18" type="radio" onclick="changeBank(this.value,'Dhanlaxmi Bank');"
                                    name="rbPayOpt" value="370" />
                                <img src="Assets/images/Dhanlaxmi-Bank.jpg" alt="Dhanlaxmi Bank" border="0" style="vertical-align: middle" />
                                Dhanlaxmi Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio7" type="radio" onclick="changeBank(this.value,'Federal Bank');"
                                    name="rbPayOpt" value="270" />
                                <img src="Assets/images/fbllogo.jpg" alt="Federal Bank" border="0" style="vertical-align: middle" />
                                Federal Bank
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio8" type="radio" onclick="changeBank(this.value,'Hdfc Net Banking');"
                                    name="rbPayOpt" value="300" />
                                <img src="Assets/images/hdfcbank.jpg" alt="Hdfc Net Banking" border="0" style="vertical-align: middle" />
                                Hdfc Net Banking</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio14" type="radio" onclick="changeBank(this.value,'I-Cash Card');"
                                    name="rbPayOpt" value="460" checked="CHECKED" />
                                <img src="Assets/images/ICashCard.jpg" alt="I-Cash Card" border="0" style="vertical-align: middle" />
                                I-Cash Card</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio9" type="radio" onclick="changeBank(this.value,'ICICI Bank');" name="rbPayOpt"
                                    value="10" checked="CHECKED" />
                                <img src="Assets/images/icici_bank.gif" alt="ICICI Bank" border="0" style="vertical-align: middle" />
                                ICICI Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb25" type="radio" onclick="changeBank(this.value,'IDBI Bank');" name="rbPayOpt"
                                    value="520" />
                                <img src="Assets/images/IDBI-Bank.jpg" alt="IDBI Bank" border="0" style="vertical-align: middle" />
                                IDBI Bank
                            </div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio15" type="radio" onclick="changeBank(this.value,'Indian Bank');"
                                    name="rbPayOpt" value="490" />
                                <img src="Assets/images/Indian_Bank.jpg" alt="Indian Bank" border="0" style="vertical-align: middle" />
                                Indian Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio16" type="radio" onclick="changeBank(this.value,'Indian Overseas Bank');"
                                    name="rbPayOpt" value="420" />
                                <img src="Assets/images/Indian-Overseas-Bank.jpg" alt="Indian Overseas Bank" border="0"
                                    style="vertical-align: middle" />
                                Indian Overseas Bank</div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio17" type="radio" onclick="changeBank(this.value,'ING Vysya Bank');"
                                    name="rbPayOpt" value="830" />
                                <img src="Assets/images/ING-Vysya.jpg" alt="ING Vysya Bank" border="0" style="vertical-align: middle" />
                                ING Vysya Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio10" type="radio" onclick="changeBank(this.value,'J&amp;K Bank');"
                                    name="rbPayOpt" value="350" />
                                <img src="Assets/images/J-and-K-Bank.jpg" alt="J&amp;K Bank" border="0" style="vertical-align: middle" />
                                J&amp;K Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio24" type="radio" onclick="changeBank(this.value,'Kotak Mahindra bank');"
                                    name="rbPayOpt" value="910" />
                                <img src="Assets/images/Kotak_Logo.gif" alt="Kotak Mahindra bank" border="0" style="vertical-align: middle"
                                    height="24" width="70" />
                                Kotak Mahindra bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb20" type="radio" onclick="changeBank(this.value,'Karnataka Bank');"
                                    name="rbPayOpt" value="140" />
                                <img src="Assets/images/Karnataka-Bank.jpg" alt="Karnataka Bank" border="0" style="vertical-align: middle" />
                                Karnataka Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio18" type="radio" onclick="changeBank(this.value,'Karur Vysya Bank');"
                                    name="rbPayOpt" value="760" />
                                <img src="Assets/images/Karur_Vysya_Bank.jpg" alt="Karur Vysya Bank" border="0" style="vertical-align: middle" />
                                Karur Vysya Bank</div>
                        </td
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb12" type="radio" onclick="changeBank(this.value,'Oriental Bank Of Commerce');"
                                    name="rbPayOpt" value="160" />
                                <img src="Assets/images/orintal_bank.gif" alt="Oriental Bank Of Commerce" border="0" style="vertical-align: middle" />Oriental
                                Bank Of Commerce</div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="rb14" type="radio" onclick="changeBank(this.value,'Punjab National Bank');"
                                    name="rbPayOpt" value="1220" />
                                <img src="Assets/images/PNB.JPG" alt="Punjab National Bank" border="0" style="vertical-align: middle"
                                    height="24" width="70" />
                                Punjab National Bank
                            </div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio28" type="radio" onclick="changeBank(this.value,'South Indian Bank');"
                                    name="rbPayOpt" value="180" />
                                <img src="Assets/images/south_indian_bank.gif" alt="South Indian Bank" border="0" style="vertical-align: middle" />
                                South Indian Bank
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb21" type="radio" onclick="changeBank(this.value,'Standard Chartered Bank');"
                                    name="rbPayOpt" value="450" />
                                <img src="Assets/images/Standard-Chartered-Bank.jpg" alt="Standard Chartered Bank" border="0"
                                    style="vertical-align: middle" />
                                Standard Chartered Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio19" type="radio" onclick="changeBank(this.value,'State Bank of Hyderabad');"
                                    name="rbPayOpt" value="560" />
                                <img src="Assets/images/State_Bank_of_Hyderabad.jpg" alt="State Bank of Hyderabad" border="0"
                                    style="vertical-align: middle" />
                                State Bank of Hyderabad
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb26" type="radio" onclick="changeBank(this.value,'State Bank of India');"
                                    name="rbPayOpt" value="530" />
                                <img src="Assets/images/sbi_logo_main.gif" alt="State Bank of India" border="0" style="vertical-align: middle" />
                                State Bank of India
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio26" type="radio" onclick="changeBank(this.value,'State Bank Of Bikaner and Jaipur');"
                                    name="rbPayOpt" value="950" />
                                <img src="Assets/images/State Bank of Bikaner.jpg" alt="State Bank Of Bikaner and Jaipur"
                                    border="0" style="vertical-align: middle" width="70" width="24" />
                                State Bank Of Bikaner and Jaipur
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio27" type="radio" onclick="changeBank(this.value,'State Bank of Patiala');"
                                    name="rbPayOpt" value="880" />
                                <img src="Assets/images/State Bank of patiala.jpg" alt="State Bank of Patiala" border="0"
                                    style="vertical-align: middle" width="70" width="24" />
                                State Bank of Patiala
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio20" type="radio" onclick="changeBank(this.value,'State Bank of Mysore');"
                                    name="rbPayOpt" value="550" />
                                <img src="Assets/images/State_Bank_of_Mysore.jpg" alt="State Bank of Mysore" border="0"
                                    style="vertical-align: middle" />
                                State Bank of Mysore
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio22" type="radio" onclick="changeBank(this.value,'State Bank of Travencore');"
                                    name="rbPayOpt" value="680" />
                                <img src="Assets/images/State-Bank-of-Travencore.png" alt="State Bank of Travencore" width="70px"
                                    height="24px" border="0" style="vertical-align: middle" />
                                State Bank of Travencore</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio21" type="radio" onclick="changeBank(this.value,'Tamilnad Mercantile Bank');"
                                    name="rbPayOpt" value="620" />
                                <img src="Assets/images/Tamilnad_Mercantile_Bank.jpg" alt="Tamilnad Mercantile Bank" border="0"
                                    style="vertical-align: middle" />
                                Tamilnad Mercantile Bank</div>
                        </td>
                       
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb23" type="radio" onclick="changeBank(this.value,'Union Bank of India');"
                                    name="rbPayOpt" value="190" />
                                <img src="Assets/images/Union-Bank-of-India.jpg" alt="Union Bank of India" border="0" style="vertical-align: middle" />
                                Union Bank of India</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb15" type="radio" onclick="changeBank(this.value,'United Bank of India');"
                                    name="rbPayOpt" value="570" />
                                <img src="Assets/images/United-Bank-of-India.jpg" alt="United Bank of India" border="0"
                                    style="vertical-align: middle" />
                                United Bank of India</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio23" type="radio" onclick="changeBank(this.value,'Vijaya bank');"
                                    name="rbPayOpt" value="200" />
                                <img src="Assets/images/vijayabank.gif" alt="Vijaya bank" border="0" style="vertical-align: middle" />
                                Vijaya Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio30" type="radio" onclick="changeBank(this.value,'Visa Master Maestro Credit Card Gateway');"
                                    name="rbPayOpt" value="820" />
                                <img src="Assets/images/sbi_logo_main.gif" alt="Visa Master Maestro Credit Card Gateway"
                                    border="0" style="vertical-align: middle" />
                                Visa Master Maestro Credit Card Gateway</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio29" type="radio" onclick="changeBank(this.value,'Visa Master Maestro Debit Card Gateway');"
                                    name="rbPayOpt" value="1180" />
                                <img src="Assets/images/sbi_logo_main.gif" alt="Visa Master Maestro Debit Card Gateway"
                                    border="0" style="vertical-align: middle" />
                                Visa Master Maestro Debit Card Gateway</div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%--</div>--%>
    </asp:Panel>
    </form>
    <script src="Assets/js/jquery-2.2.0.min.js"></script>
    <script src="Assets/js/jquery-ui.js"></script>
    <script type="text/javascript">

        var $123 = jQuery.noConflict();



        $123(function () {

            $123('.linkqck').click(function (e) {
                $123(".qckenqwrap").show().animate({
                    right: "0px"

                }, 300, function () {

                });



                e.preventDefault();
            });


            $123('.closebtn a').click(function (e) {

                $123(".qckenqwrap").animate({
                    right: "-300px"


                }, 300, function () {
                   
                });


                e.preventDefault();
            });


            $123('.placescoveredtbl .pcwrap ul li a').click(function (e) {
                $123('.nav-tabs li').removeClass('active');
                $123('a[href="#tab_tourinfo"]').parent().addClass('active');
                $123('#tab_dateprice').removeClass('active in');
                $123('#tab_tourinfo').addClass('active in');
                //$('a').attr().parent().addClass('active');
                e.preventDefault();
            });



        });
        $123(function () {
            var stickyRibbonTop = $('.stickymenu').offset().top;

            $123(window).scroll(function () {
                if ($123(window).scrollTop() > stickyRibbonTop) {
                    $123('.stickymenu').addClass('sticky'); //css({position: 'fixed', top: '0px'});
                } else {
                    $123('.stickymenu').removeClass('sticky'); //css({position: 'static', top: '0px'});
                }
            });
        });
    </script>
    <script language="javascript" type="text/javascript">
        function changeBank(t) {
            document.getElementById('CSTBANKID').value = t;
        }
        x = 20;
        y = 70;
        function placeIt(obj) {
            obj = document.getElementById(obj);
            if (document.documentElement) {
                theLeft = document.documentElement.scrollLeft;
                theTop = document.documentElement.scrollTop;
            }
            else if (document.body) {
                theLeft = document.body.scrollLeft;
                theTop = document.body.scrollTop;
            }
            theLeft += x;
            theTop += y;
            obj.style.left = theLeft + 'px';
            obj.style.top = theTop + 'px';
            setTimeout("placeIt('light')", 500);
        }
        balance();                        
    </script>
</body>
</html>

