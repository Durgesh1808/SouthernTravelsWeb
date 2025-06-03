<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHolidaySearch.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcHolidaySearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script language="Javascript">
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
    function CheckOnlyCharacter(evt) {
        var kk
        kk = (evt.which) ? evt.which : event.keyCode
        if ((kk >= 65 && kk <= 90) || (kk >= 97 && kk <= 122) || kk == 32 || kk == 190 || kk == 8 || kk == 9 || kk == 127 || kk == 16 || kk == 20 || kk == 46) {
            return true;
        }
         Swal.fire({
                icon: 'warning',
                text: 'Please enter characters only.',
                 confirmButtonColor: '#f2572b'
            });
        return false;
    }
    function fnQuickHOlySearchVal() {

        var chek = true;

        if (document.getElementById("<%=txtSearch.ClientID  %>").value == "") {
         Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Please enter Tour, City.',
                 confirmButtonColor: '#f2572b'
            });
            document.getElementById("<%=txtSearch.ClientID  %>").focus();
            return false;
        }
    }
    function IAmSelected(source, eventArgs) {
        var lVal = eventArgs.get_value().split('~')
        document.getElementById("<%=fldTourID.ClientID %>").value = lVal[0];
        document.getElementById("<%=fldTourTypeID.ClientID %>").value = lVal[1];
        document.getElementById("<%=txtSearch.ClientID %>").value = lVal[2];

        if (document.getElementById("<%=fldTourTypeID.ClientID %>").value == 1) {
            var str = document.getElementById("<%=txtSearch.ClientID %>").value.split(':');
            var res = str[1].trim().replace(" ", "-") + "_" + document.getElementById("<%=fldTourID.ClientID %>").value;
            window.location = "Fixed-Departure-Itinerary-" + res;
        }
        else if (document.getElementById("<%=fldTourTypeID.ClientID %>").value == 2) {
            var str = document.getElementById("<%=txtSearch.ClientID %>").value.split(':');
            var res = str[1].trim().replace(" ", "-") + "_" + document.getElementById("<%=fldTourID.ClientID %>").value;
            window.location = "Holiday-Packages-Itinerary-" + res;
        }
        else if (document.getElementById("<%=fldTourTypeID.ClientID %>").value == 3) {
            var str = document.getElementById("<%=txtSearch.ClientID %>").value.split(':');
            var res = str[1].trim().replace(" ", "-") + "_" + document.getElementById("<%=fldTourID.ClientID %>").value;
            window.location = "InternationalTours-" + res;
        }

    }
    function ShowProcessImage() {
        var autocomplete = document.getElementById('<%=txtSearch.ClientID %>');
        autocomplete.style.backgroundImage = 'url(https://www.southerntravelsindia.com/images/loading1.gif)';
        autocomplete.style.backgroundRepeat = 'no-repeat';
        autocomplete.style.backgroundPosition = 'right';
    }
    function HideProcessImage(sender, e) {
        var autocomplete = document.getElementById('<%=txtSearch.ClientID %>');
        autocomplete.style.backgroundImage = 'none';

        var employees = sender.get_completionList().childNodes;
        for (var i = 0; i < employees.length; i++) {

            if (employees[i].firstChild.nodeValue == 'City') {
                employees[i].firstChild.nodeValue = "";

                var div = document.createElement("DIV");
                div.innerHTML = "<img style = 'height:26px;width:485px;cursor: default; background-repeat:repeat-x;' src = 'images/City.jpg' loading='lazy' alt='City'/>";
                employees[i].appendChild(div);
            }
            else if (employees[i].firstChild.nodeValue == 'Tours') {
                employees[i].firstChild.nodeValue = "";

                var div = document.createElement("DIV");
                div.innerHTML = "<img style = 'height:26px;width:485px;cursor: default; background-repeat:repeat-x;' src = 'images/Tours.jpg' loading='lazy' alt='Tours' />";
                employees[i].appendChild(div);
            }
            else {


                // Consider value as image path
                var imgeUrl = employees[i]._value;
                //First node will have the text
                var text = employees[i].firstChild.nodeValue;
                employees[i]._value = employees[i]._value + "~" + text;
                //Height and Width of the mage can be customized here...
                employees[i].innerHTML = "<img style = 'height:26px;width:26px;cursor: default;' src = 'images/location2.png'  loading='lazy'  alt='location2' /> &nbsp;" + text;
            }
        }
    }
    
</script>

<style type="text/css">
    .AutoExtender
    {
        /*font-family: Verdana, Helvetica, sans-serif;
        font-size: .8em;
        font-weight: normal;*/
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
<asp:HiddenField ID="fldTourID" runat="server" Value="0" />
<asp:HiddenField ID="fldTourTypeID" runat="server" Value="0" />
<h3>
    Choose your destination
</h3>
<div class="formwrap">
    <div class="row">
        <div class="col-md-12">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" ValidationGroup="HSear" placeholder="Search for Tours, City" AutoCompleteType = "None" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSearch"
                                                            ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="HSear"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtSearch"
                                                            Display="Dynamic" ErrorMessage="Only alphanumeric, # and sapce are allowed."
                                                            ValidationExpression="^[0-9a-zA-Z #,-/]+$" ValidationGroup="HSear"></asp:RegularExpressionValidator>                                                            
            <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtSearch"
                UseContextKey="True" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetTourList"
                MinimumPrefixLength="3" EnableCaching="true" CompletionListCssClass="completionList"
                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                CompletionListElementID="divwidth" OnClientItemSelected="IAmSelected" OnClientPopulating="ShowProcessImage"
                OnClientPopulated="HideProcessImage" FirstRowSelected="false" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:TextBox ID="txtMinDay" runat="server" CssClass="form-control" placeholder="No. of Days(Min)" MaxLength = "2"></asp:TextBox>
        </div>
        <div class="col-md-4 paddingleft0">
            <asp:TextBox ID="txtMaxDay" runat="server" CssClass="form-control" placeholder="No. of Days(Max)" MaxLength = "2"></asp:TextBox>
        </div>
        <div class="col-md-4 paddingleft0">
            <asp:DropDownList ID="ddlMonthofTravel" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row" style="display:none;">
        <div class="col-md-12">
            <asp:DropDownList ID="ddlPackageType" runat="server" CssClass="form-control">
                <asp:ListItem Text="Package Type" Value="0"></asp:ListItem>
                <asp:ListItem Text="Fixed Departure Tours" Value="1"></asp:ListItem>
                <asp:ListItem Text="Holiday Packages" Value="2"></asp:ListItem>
                <asp:ListItem Text="International Holidays" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnSearch" runat="server" Text="Search"  ValidationGroup="HSear"
                CssClass="btn pull-right" onclick="btnSearch_Click" />
        </div>
    </div>
</div>
