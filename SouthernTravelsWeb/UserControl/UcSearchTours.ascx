<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSearchTours.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcSearchTours" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="/Assets/css/bootstrap-slider.css" rel="stylesheet">
 <!-- Main Content Start -->
    <section class="innersection1 searchtop">
  <div class="container">
    <div class="row subheadrow">
      <div class="col-md-12 text-center">
        <h1 class="title uppercase">Search Your <span>Holiday</span></h1>
      </div>
    </div>
    
    <div class="row" >
    <div class="formwrap">
    	<div class="col-md-4 paddingright0">
       
         <asp:TextBox ID="TxtCountryStateCity" runat="server" placeholder="Search for Tours, City"  class="form-control" ValidationGroup="HSear"></asp:TextBox>
       
           <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TxtCountryStateCity"
                                                            Display="Dynamic" ErrorMessage="Only alphanumeric, # and sapce are allowed."
                                                            ValidationExpression="^[0-9a-zA-Z #,-/]+$" ValidationGroup="HSear"></asp:RegularExpressionValidator>                                                            
            <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="TxtCountryStateCity"
                UseContextKey="True" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetTourList"
                MinimumPrefixLength="3" EnableCaching="true" CompletionListCssClass="completionList"
                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                CompletionListElementID="divwidth" OnClientItemSelected="IAmSelected" OnClientPopulating="ShowProcessImage"
                OnClientPopulated="HideProcessImage" FirstRowSelected="false" />
        </div>
        <div class="col-md-2 paddingright0" style="display:none;">
        
          <asp:DropDownList ID="ddlPackageType" runat="server" class="form-control">
            <asp:ListItem Value="0">Package Type </asp:ListItem>
           <asp:ListItem Value="1">Fixed Departure Tours </asp:ListItem>
           <asp:ListItem Value="2">Holiday Package </asp:ListItem>
           <asp:ListItem Value="3">International Holidays</asp:ListItem>
          </asp:DropDownList>
        	
        </div>
        <div class="col-md-2 paddingright0">
         <!-- <input type="text" class="form-control" placeholder="No. of Days (min)"> -->
          <asp:TextBox ID="txtNoOfDaysMin" runat="server" class="form-control" placeholder="No. of Days (min)" MaxLength="2"></asp:TextBox>
        </div>
        
        <div class="col-md-2 paddingright0">
        <!-- <input type="text" class="form-control" placeholder="No. of Days (max)"> -->
         <asp:TextBox ID="txtNoOfDaysMax" runat="server" class="form-control" placeholder="No. of Days (max)" MaxLength="2"></asp:TextBox>
        </div>
        
        <div class="col-md-3 paddingright0">
        <!-- <input type="text" class="form-control" placeholder="Month of Travel">-->
         <%--<asp:TextBox ID="txtMonthOfTravel" runat="server" class="form-control" placeholder="Month of Travel"></asp:TextBox>--%>
         <asp:DropDownList ID="ddlMonthofTravel" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        
        <div class="col-md-1 paddingright0">
        <input type="submit" class="btn" value="Search" onclick="return valid();"> 
        <!--   <asp:Button ID="btnSubmit" runat="server" Text="Submit"  class="btn" OnClientClick="return valid();"></asp:Button> -->
        </div>
        
        </div>
    </div>
    
  </div>
</section>
    <section class="resultsection">
	
    <div class="container">
    	<div class="row">
        	<div class="col-md-12"><asp:Label ID="lblNoRec" runat="server" Text=""></asp:Label> </div>
        </div>
        
        <div class="row">
        	<div class="col-md-12"><h2 class="title text-center"><asp:Label ID="lblText" runat="server" Text=""></asp:Label></h2></div>
        </div>
        
         <div class="row">

          <div class="col-md-12">
            <ul class="portfolio-sorting list-inline text-center">
            <li><a href="" onclick="return GetTourType(0,0)" data-group="all" class='<%= fldTourType== 0 ?"activable active":"activable"  %>' >All Packages<br /><span class="smalltext">&nbsp;</span></a></li>
            <li><a href="" onclick="return GetTourType(1,0)" data-group="fixeddept" class='<%= fldTourType== 1 ?"activable active":"activable"  %>'>Fixed Departure Tours <br /><span class="smalltext">(Domestic / seat in Coach basis)</span></a></li>
            <li><a href="" onclick="return GetTourType(2,0)" data-group="holiday" class='<%= fldTourType== 2 ?"activable active":"activable"  %>'>Holiday Packages <br /><span class="smalltext">(India / Nepal / Bhutan)</span></a></li>
            <li><a href="" onclick="return GetTourType(3,2)" data-group="holiday" class='<%= fldTourType== 18 ?"activable active":"activable"  %>'>International <br /><span class="smalltext">(Fixed / Group Departures)</span></a></li>
            <li><a href="" onclick="return GetTourType(3,1)" data-group="holiday" class='<%= fldTourType== 17 ?"activable active":"activable"  %>'>International <br /><span class="smalltext">(Customized Holidays)</span></a></li>
          </ul> 
          </div>
          </div>
          
          <div class="row" style="display:none">
          <div class="col-md-12">
          	<ul class="searchcatlist">
                <asp:Repeater ID="repZone" runat="server" onitemcommand="repZone_ItemCommand" 
                    onitemdatabound="repZone_ItemDataBound" >
                 <ItemTemplate>
                  <li onclick='return GetSearchResultZone(<%# Eval("ZoneId") %>)'>
                  <asp:HiddenField runat="server" ID="hdZoneName" Value = '<%# Eval("ZoneName") %>' />
                  <asp:HiddenField runat="server" ID="hdZoneId" Value = '<%# Eval("ZoneId") %>' />
                  
                   <a href='#' id="lnkZone" runat="server"  class="Zone">
                   <img src='="/Assets/images/Zone/<%# Eval("ZoneImg") %>' alt="zone" loading="lazy"/> <%#Eval("ZoneName")%></a> 
                 </li>
               
                 </ItemTemplate>
                
                </asp:Repeater>
            </ul>
          </div>
          </div>
          
          
          <div class="row">
          	<div class="col-md-4">
            	
                <div class="rangediv">
					Price: <i class="fa fa-rupee"></i> <span id="price_lbl_min">200</span> 
					<input id="price_val" type="text" class="span2" value="" />
					<%--<asp:TextBox ID="price_val" runat="server" class="span2" Text=""></asp:TextBox>--%> 
					<span class="resultamt"><i class="fa fa-rupee"></i> <span id="price_lbl_max">1000000</span></span>
				</div>
                
                
            </div>
            
            <div class="col-md-4">
            	
                <div class="rangediv">
					Days: 1 <input id="days_num" type="text" data-slider-min="1" data-slider-max="15" data-slider-step="1" data-slider-value="15">
					 <span class="resultamt" id="days_num_val">Days: <span id="ex6SliderVal">15</span></span>	
				</div>
                
                
            </div>
            
            <div class="col-md-4">
            	<div class="sortby pull-right">
                	Sort By : <a href="" onclick="return GetSearchSort(1)"   class="sort ">Name</a> | <a href="" class="sort " onclick="return GetSearchSort(2)">Price</a> | <a href="" class="sort " onclick="return GetSearchSort(3)">No. of Days</a> | <a href="" class="sort " onclick="return GetSearchSort(4)">Tour Code</a>
                 </div>
            </div>
            
          </div>

<div class="row">
<div class="col-md-12">
         <asp:HiddenField ID="fldTourID" runat="server" Value="0" />
<asp:HiddenField ID="fldTourTypeID" runat="server" Value="0" />
         <asp:HiddenField runat="server" ID="hiddenLastSortID" />
     		 <asp:HiddenField runat="server" ID="hdSortBy" Value = "0" />
     		 <asp:HiddenField runat="server" ID="hdTourType" Value = "0" />
     		 <asp:HiddenField runat="server" ID="hdTourZone" Value = "0" />
     		 <asp:HiddenField runat="server" ID="hdOfferID" Value = "0" />
     		 <asp:HiddenField runat="server" ID="hdNoOfDays" Value = "15" />
     		 <asp:HiddenField runat="server" ID="hdPriceMin" Value = "0" />
     		 <asp:HiddenField runat="server" ID="hdPriceMax" Value = "1000000" />
                                        <asp:HiddenField runat="server" ID="hdnContentHight" Value="1500" />
                                        <asp:HiddenField runat="server" ID="hdnPreviousSortId" Value="0" />
          <div class="row rowgap"  id="dlProduct" runat="server">
     		 
     		
                                        
            <div style="display: none">1</div>
            
    </div>
    
    
    <div id="divProgress" runat="server" align="center">
        loading......
    </div>
    
         
         
</div>

          </div> 
        
        
    </div>
    
    
</section>

<style type="text/css">
    .AutoExtender
    {
        border: solid 1px #006699;
        line-height: 30px;
        background-color: White;
        margin-left: -10px !important;
        margin-top: 5px !important;
        z-index: 6 !important;
        overflow: auto;
        height: 100px;
    }
    .AutoExtenderList
    {
        border-bottom: dotted 1px #006699;
        cursor: pointer;
        color: #555;/*maroon*/
        margin-left: 5px !important;
    }
    .AutoExtenderHighlight
    {
        color: White;
        background-color: #F04E20;
        cursor: pointer;
        margin-left: 1px !important;
    }
    #divwidth
    {
        width: 170px !important;
        margin-left: 0px !important;
    }
    #divwidth div
    {
        width: 170px !important;
        margin-left: 0px !important;
    }
    /*AutoComplete flyout */.completionList
    {
        border: solid 1px #444444;
        margin: 0px;
        padding: 2px;
        height: 150px;
        overflow: auto;
        background-color: #FFFFFF;
        z-index: 6 !important;
    }
    .listItem
    {
        color: #1C1C1C;
    }
    .itemHighlighted
    {
        background-color: #ffc0c0;
    }
</style>


    <script src="../Assets/js/jquery-2.2.0.min.js"></script>
    <script type='text/javascript' src="../Assets/js/bootstrap-slider.js"></script>
    
    <script>
        var $no = jQuery.noConflict();
        $no(function() {

            $no('ul.searchcatlist li a').click(function(e) {
                $no('ul.searchcatlist li a').removeClass('active');
                $no(this).addClass('active');
                e.preventDefault();
            });

            $no('#price_val').attr('data-slider-min', '200').attr('data-slider-max', '1000000').attr('data-slider-step', '5').attr('data-slider-value', '[200,1000000]');

            $no("#price_val").slider();
            //alert(document.getElementById('price_val').value);
            $no("#price_val").on("slide", function(slideEvt) {
                pricemax = $no(this).parent().find('.tooltip-max .tooltip-inner').text();
                pricemin = $no(this).parent().find('.tooltip-min .tooltip-inner').text();
                $no("#price_lbl_max").text(pricemax);
                $no("#price_lbl_min").text(pricemin);

            });

            $no('.slider').on('slideStop', function() {
                //alert('');
                pricemax = $no(this).find('.tooltip-max .tooltip-inner').text();
                pricemin = $no(this).find('.tooltip-min .tooltip-inner').text();
                $no("#price_lbl_max").text(pricemax);
                $no("#price_lbl_min").text(pricemin);
                //alert(document.getElementById('price_val').value);
                $no("#<%=hdPriceMin.ClientID %>").val(pricemin);
                $no("#<%=hdPriceMax.ClientID %>").val(pricemax);
                GetPage();
            });


            $no("#days_num").slider();
            $no("#days_num").on("slide", function(slideEvt) {
                $no("#days_num_val").text(slideEvt.value);
            });


            $no("#days_num").on("slideStop", function(slideEvt) {
                //alert('');
                $no("#days_num_val").text(slideEvt.value);
                $no("#<%=hdNoOfDays.ClientID %>").val(slideEvt.value);
                GetPage();
            });


        });
    </script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <script type="text/javascript">
    function valid() {
        if (document.getElementById('<%=TxtCountryStateCity.ClientID  %>').value == "") {
            Swal.fire({ icon: 'warning', title: 'Oops...', text: 'Please enter Tours, City.', confirmButtonColor: '#f2572b' });
            document.getElementById('<%=TxtCountryStateCity.ClientID  %>').focus();
            return false;
        }
        else {
            document.getElementById("<%=hdTourType.ClientID  %>").value = "0";
            document.getElementById("<%=hdOfferID.ClientID  %>").value = "0";
            document.getElementById("<%=hdTourZone.ClientID  %>").value = "0"
            GetPage();
            return false;

        }

    }
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
  
    function GetTourType(TourType,OfferID) {
        document.getElementById("<%=hdTourType.ClientID  %>").value = TourType;
        document.getElementById("<%=hdOfferID.ClientID  %>").value = OfferID;
        document.getElementById("<%=hdTourZone.ClientID  %>").value = "0"
        GetPage();
        return false;
    }
    function GetSearchResultZone(zoneId) {
        document.getElementById("<%=hdTourZone.ClientID  %>").value = zoneId;
        GetPage();
        return false;
    }
    function GetSearchSort(SortID) {
        document.getElementById("<%=hdSortBy.ClientID  %>").value = SortID;
        GetPage();
        return false;
    }
    function IAmSelected(source, eventArgs) {
        var lVal = eventArgs.get_value().split('~')
        document.getElementById("<%=fldTourID.ClientID %>").value = lVal[0];
        document.getElementById("<%=fldTourTypeID.ClientID %>").value = lVal[1];
        document.getElementById("<%=TxtCountryStateCity.ClientID %>").value = lVal[2];

        if (document.getElementById("<%=fldTourTypeID.ClientID %>").value == 1) {
            var str = document.getElementById("<%=TxtCountryStateCity.ClientID %>").value.split(':');
            var res = str[1].trim().replace(" ", "-") + "_" + document.getElementById("<%=fldTourID.ClientID %>").value;
            window.location = "Fixed-Departure-Itinerary-" + res;
        }
        else if (document.getElementById("<%=fldTourTypeID.ClientID %>").value == 2) {
            var str = document.getElementById("<%=TxtCountryStateCity.ClientID %>").value.split(':');
            var res = str[1].trim().replace(" ", "-") + "_" + document.getElementById("<%=fldTourID.ClientID %>").value;
            window.location = "Holiday-Packages-Itinerary-" + res;
        }
        else if (document.getElementById("<%=fldTourTypeID.ClientID %>").value == 3) {
            var str = document.getElementById("<%=TxtCountryStateCity.ClientID %>").value.split(':');
            var res = str[1].trim().replace(" ", "-") + "_" + document.getElementById("<%=fldTourID.ClientID %>").value;
            window.location = "IntItenaryDetails.aspx?TourID=" + document.getElementById("<%=fldTourID.ClientID %>").value + "&off=1";
        }

    }
    function ShowProcessImage() {
        var autocomplete = document.getElementById('<%=TxtCountryStateCity.ClientID %>');
        autocomplete.style.backgroundImage = 'url(https://www.southerntravelsindia.com/images/loading1.gif)';
        autocomplete.style.backgroundRepeat = 'no-repeat';
        autocomplete.style.backgroundPosition = 'right';
    }
    function HideProcessImage(sender, e) {
        var autocomplete = document.getElementById('<%=TxtCountryStateCity.ClientID %>');
        autocomplete.style.backgroundImage = 'none';

        var employees = sender.get_completionList().childNodes;
        for (var i = 0; i < employees.length; i++) {

            if (employees[i].firstChild.nodeValue == 'City') {
                employees[i].firstChild.nodeValue = "";

                var div = document.createElement("DIV");
                div.innerHTML = "<img style = 'height:26px;width:485px;cursor: default; background-repeat:repeat-x;' src = 'images/City.jpg' />";
                employees[i].appendChild(div);
            }
            else if (employees[i].firstChild.nodeValue == 'Tours') {
                employees[i].firstChild.nodeValue = "";

                var div = document.createElement("DIV");
                div.innerHTML = "<img style = 'height:26px;width:485px;cursor: default; background-repeat:repeat-x;' src = 'images/Tours.jpg' />";
                employees[i].appendChild(div);
            }
            else {
                var imgeUrl = employees[i]._value;
                //First node will have the text
                var text = employees[i].firstChild.nodeValue;
                employees[i]._value = employees[i]._value + "~" + text;
                //Height and Width of the mage can be customized here...
                employees[i].innerHTML = "<img style = 'height:26px;width:26px;cursor: default;' src = 'images/location2.png' /> &nbsp;" + text;
            }
        }
    }
    </script>
    
    <script language="javascript" type="text/javascript">
        $no("a.activable").click(function() {
            $no("a.activable.active").removeClass("active");
            $no(this).addClass("active");
        });
        $no("a.sort").click(function() {
        $no("a.sort.active").removeClass("active");
            $no(this).addClass("active");
        });
        $no("a.Zone").click(function() {
            $no("a.Zone.active").removeClass("active");
            $no(this).addClass("active");
           
        });
        $no(document).ready(function() {
            GetPage();
        });
        function GetPage() {
            
            document.getElementById("<%=lblText.ClientID  %>").innerHTML = document.getElementById("<%=TxtCountryStateCity.ClientID  %>").value;
            
            var lastSortId = 1
                
            var pSearchStr = document.getElementById("<%=TxtCountryStateCity.ClientID  %>").value + "~";

            if (document.getElementById("<%=txtNoOfDaysMin.ClientID  %>").value != "") {
                pSearchStr += document.getElementById("<%=txtNoOfDaysMin.ClientID  %>").value + "~";
            }
            else {
                pSearchStr += "0~";
            }
            if (document.getElementById("<%=txtNoOfDaysMax.ClientID  %>").value != "") {
                pSearchStr += document.getElementById("<%=txtNoOfDaysMax.ClientID  %>").value + "~";
            }
            else {
                pSearchStr += "0~";
            }
            pSearchStr += document.getElementById("<%=ddlMonthofTravel.ClientID  %>").value + "~";

            if (document.getElementById("<%=ddlMonthofTravel.ClientID  %>").value != "") {
                pSearchStr += +"~";
            }
            else {
                pSearchStr += "0";
            }

            var pSortBy = document.getElementById("<%=hdSortBy.ClientID  %>").value;
            var pTourType = document.getElementById("<%=hdTourType.ClientID  %>").value;
            var pZoneID = document.getElementById("<%=hdTourZone.ClientID  %>").value;
            var pOfferID = document.getElementById("<%=hdOfferID.ClientID  %>").value;
            
            var pNoOfDays = document.getElementById("<%=hdNoOfDays.ClientID  %>").value;
            if (document.getElementById("<%=txtNoOfDaysMax.ClientID  %>").value != "") {
                document.getElementById("<%=hdNoOfDays.ClientID  %>").value = document.getElementById("<%=txtNoOfDaysMax.ClientID  %>").value;
                pNoOfDays = document.getElementById("<%=txtNoOfDaysMax.ClientID  %>").value;
            }
            var pPriceMin = document.getElementById("<%=hdPriceMin.ClientID  %>").value;
            var pPriceMax = document.getElementById("<%=hdPriceMax.ClientID  %>").value;
            document.getElementById("<%=hdnPreviousSortId.ClientID  %>").value = '0';
            $no("#<%=dlProduct.ClientID %>").html('');
            $no(document).ajaxStart(function() {
                document.getElementById("<%=divProgress.ClientID  %>").style.display = "block";
            });
            $no(document).ajaxStop(function() {
                document.getElementById("<%=divProgress.ClientID  %>").style.display = "none";
            });
            $no.ajax({
                type: "POST",
                url: "FetchRecordsHandler.ashx?PageIndex=" + lastSortId + "&SearchStr=" + pSearchStr + "&TourType=" + pTourType + "&ZoneID=" + pZoneID +
            "&SortBy=" + pSortBy + "&NoOfDays=" + pNoOfDays + "&PriceMin=" + pPriceMin + "&PriceMax=" + pPriceMax + "&OfferID=" + pOfferID,
                success: function(response) {
                    $no("#<%=dlProduct.ClientID %>").append(response);
                }
            });
        }
        //function pageLoad(sender, args) {
        var contentHeight;
        var pageHeight = document.documentElement.clientHeight;
        var scrollPosition;

        var previousProductId = 0;

        $no(document).ready(function() {
            document.getElementById("<%=divProgress.ClientID  %>").style.display = "none";
            $no(window).scroll(function() {
                Search();
            });
        });
        function Search() {
            //alert('+++');
            //
            previousSortId = parseInt(document.getElementById("<%=hdnPreviousSortId.ClientID  %>").value);
            contentHeight = parseInt(document.getElementById("<%=hdnContentHight.ClientID  %>").value);

            if (navigator.appName == "Microsoft Internet Explorer")
                scrollPosition = document.documentElement.scrollTop;
            else
                scrollPosition = window.pageYOffset;

            if ((contentHeight - pageHeight - scrollPosition) < 20000) {
                $no(document).ajaxStart(function() {
                    document.getElementById("<%=divProgress.ClientID  %>").style.display = "block";
                });
                $no(document).ajaxStop(function() {
                    document.getElementById("<%=divProgress.ClientID  %>").style.display = "none";
                });

                var lastSortId = $no("#<%=dlProduct.ClientID %> div:last").html(); //.children("td:first").html();

                lastSortId = parseInt(lastSortId) + 1;

                var pSearchStr = document.getElementById("<%=TxtCountryStateCity.ClientID  %>").value + "~";

                if (document.getElementById("<%=txtNoOfDaysMin.ClientID  %>").value != "") {
                    pSearchStr += document.getElementById("<%=txtNoOfDaysMin.ClientID  %>").value + "~";
                }
                else {
                    pSearchStr += "0~";
                }
                if (document.getElementById("<%=txtNoOfDaysMax.ClientID  %>").value != "") {
                    pSearchStr += document.getElementById("<%=txtNoOfDaysMax.ClientID  %>").value + "~";
                }
                else {
                    pSearchStr += "0~";
                }
                pSearchStr += document.getElementById("<%=ddlMonthofTravel.ClientID  %>").value + "~";

                if (document.getElementById("<%=ddlMonthofTravel.ClientID  %>").value != "") {
                    pSearchStr += +"~";
                }
                else {
                    pSearchStr += "0";
                }

                var pSortBy = document.getElementById("<%=hdSortBy.ClientID  %>").value;
                var pTourType = document.getElementById("<%=hdTourType.ClientID  %>").value;
                var pZoneID = document.getElementById("<%=hdTourZone.ClientID  %>").value;
                var pOfferID = document.getElementById("<%=hdOfferID.ClientID  %>").value;
                var pNoOfDays = document.getElementById("<%=hdNoOfDays.ClientID  %>").value;
                var pPriceMin = document.getElementById("<%=hdPriceMin.ClientID  %>").value;
                var pPriceMax = document.getElementById("<%=hdPriceMax.ClientID  %>").value;
                
                var lastRow = $no("#<%=dlProduct.ClientID %> div:last");
                
                if ((parseInt(lastSortId, 10) > parseInt(previousSortId, 10)) || (parseInt(lastSortId, 10) < parseInt(previousSortId, 10))) {
                    $no('#<%=hdnPreviousSortId.ClientID %>').val(lastSortId);
                    $no.post("FetchRecordsHandler.ashx?PageIndex=" + lastSortId + "&SearchStr=" + pSearchStr + "&TourType=" + pTourType + "&ZoneID=" + pZoneID +
                            "&SortBy=" + pSortBy + "&NoOfDays=" + pNoOfDays + "&PriceMin=" + pPriceMin + "&PriceMax=" + pPriceMax + "&OfferID=" + pOfferID, 
                            function(data) {
                                document.getElementById("<%=hdnContentHight.ClientID  %>").value = parseInt(contentHeight) + 1250;
                                if (data.toString().length > 25) {
                                    //                    //alert(data);
                                    lastRow.after(data);
                                }
                                document.getElementById("<%=divProgress.ClientID  %>").style.display = "none";
                            });
                }
            }
        }

    </script>

