<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSpecialTourSearch.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcSpecialTourSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script language="javascript" type="text/javascript">



    function GetTourStartFrom() {
        document.getElementById("<%=hdTourStartFrom.ClientID %>").value = document.getElementById("<%=ddlSPLTourStartFrom.ClientID %>").options[document.getElementById("<%=ddlSPLTourStartFrom.ClientID %>").selectedIndex].value;

    }

    function SPLIAmSelected(source, eventArgs) {

        document.getElementById("<%=fldTourID.ClientID %>").value = eventArgs.get_value();

    }
</script>

<script language="Javascript">



    function PopupHide() {
        $find('<%=SplPopEx.ClientID %>').hidePopup()
    }


</script>

<style type="text/css">
    .AutoExtender
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: .8em;
        font-weight: normal;
        border: solid 1px #006699;
        line-height: 20px;
        background-color: White;
        margin-left: -4px !important;
        margin-top: 5px !important;
        z-index: 6 !important;
    }
    .AutoExtenderList
    {
        border-bottom: dotted 1px #006699;
        cursor: pointer;
        color: Maroon;
        margin-left: 5px !important;
    }
    .AutoExtenderHighlight
    {
        color: White;
        background-color: #006699;
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
</style>
<style>
    .rlbGroup
    {
        border: none !important;
    }
</style>

<script language="javascript" type="text/javascript">
    function echeck(str) {
        var at = "@"
        var dot = "."
        var und = "_"
        var lat = str.indexOf(at)
        var lstr = str.length
        var ldot = str.indexOf(dot)
        if (str.indexOf(at) == -1) {
            alert("Please enter valid email id.")
            return false
        }
        if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
            alert("Please enter valid email id.")
            return false
        }
        if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
            alert("Please enter valid email id.")
            return false
        }
        if (str.indexOf(at, (lat + 1)) != -1) {
            alert("Please enter valid email id.")
            return false
        }
        if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
            alert("Please enter valid email id.")
            return false
        }
        if (str.indexOf(dot, (lat + 2)) == -1) {
            alert("Please enter valid email id.")
            return false
        }
        if (str.indexOf(" ") != -1) {
            alert("Please enter valid email id.")
            return false
        }
        if ((str.indexOf("..") > -1) || (str.substring(str.length - 1, str.length) == dot)) {
            alert("Please enter valid email id.")
            return false
        }
        if ((str.substring(0, 1) == und)) {
            alert("Please enter valid email id.")
            return false
        }
        return true
    }
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
    function Left(str, n) {
        if (n <= 0)
            return "";
        else if (n >= String(str).length)
            return str;
        else
            return String(str).substring(0, n);
    }


    function chkNumeric(evt) {
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
        alert("Please enter characters only.");
        return false;
    }

    function CheckForCharacterAndNumeric(evt) {
        var kk
        kk = (evt.which) ? evt.which : event.keyCode
        if ((kk >= 65 && kk <= 90) || (kk >= 97 && kk <= 122) || kk == 32 || kk == 190 || kk == 8 || kk == 9 || kk == 127 || kk == 16 || kk == 20 || kk == 46 || (kk >= 48 && kk <= 57)) {
            return true;
        }
        //        alert("Please enter characters only.");
        return false;
    }
    function CallBtn(IsLeft) {
        document.getElementById('<%=ddlSPLMonth.ClientID %>').value = 1;
    }

    function fnQuickSPLSearchVal() {

        var chek = true;
        if (document.getElementById("<%=ddlSPLTourStartFrom.ClientID  %>").value == "0" || document.getElementById("<%=ddlSPLTourStartFrom.ClientID  %>").value == "") {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Please select Tour Starting From.',
                confirmButtonColor: '#f2572b'
            });
            document.getElementById("<%=ddlSPLTourStartFrom.ClientID  %>").focus();
            return false
        }
        if (document.getElementById("<%=ddlSPLTour.ClientID  %>").value == "0") {
             Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Please select Tour.',
                 confirmButtonColor: '#f2572b'
            });
            document.getElementById("<%=ddlSPLTour.ClientID  %>").focus();
            chek = false;
            return false;
        }
        if (document.getElementById("<%=txtSPLJourneyDate.ClientID  %>").value == "" || document.getElementById("<%=txtSPLJourneyDate.ClientID  %>").value == "dd/mm/yyyy") {
             Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Please select Journey Date.',
                 confirmButtonColor: '#f2572b'
            });
            document.getElementById("<%=txtSPLJourneyDate.ClientID  %>").focus();
            return false;
        }
    }
    function OnShowCal() {

        document.getElementById("<%=tblCal.ClientID %>").style.display = "block";

    }
   
</script>
 <script type="text/javascript">
     $(document).ready(function() {
         $("#<% =ddlSPLTourStartFrom.ClientID %>").addClass("btn-group bootstrap-select form-control dropup");
     });
</script>
<script type="text/javascript">

</script>

<style>
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
<asp:HiddenField ID="fldTourID" runat="server" Value="0" />
<asp:HiddenField ID="hdTourStartFrom" runat="server" Value="0" />
<%--
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
        <div class="formwrap">
            <div class="row">
                <div class="col-md-12">
                    <h4>
                        I'm here</h4>
                </div>
            </div>
            <div class="row mrgnbtminput">
                <div class="col-md-12">
                    <asp:DropDownList ID="ddlSPLTourStartFrom" class="form-control" runat="server" 
                    OnSelectedIndexChanged="ddlSPLTourStartFrom_SelectedIndexChanged"
                        ValidationGroup="SPLValidation1" AutoPostBack="True">
                    </asp:DropDownList>
                   
                </div>
            </div>
            <div class="row mrgnbtminput">
                <div class="col-md-12">
                    <asp:DropDownList ID="ddlSPLTour" class="form-control" runat="server" OnSelectedIndexChanged="ddlSPLTour_SelectedIndexChanged"
                        ValidationGroup="SPLValidation1" AutoPostBack="True">
                    </asp:DropDownList>
                  
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h4>
                        When</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-7">
                    <div class="input-group date">
                        <asp:TextBox ID="txtSPLJourneyDate" Width="222" runat="server" class="form-control"
                            placeholder="Departure date" ValidationGroup="SPLValidation1">
                        </asp:TextBox>
                        <img src="/Assets/images/icon-calendar.jpg" id="btnSplDate" runat="server" width="38" height="38"
                            alt="select date" onclick="Javascript:OnShowCal();" style="cursor: pointer"  loading="lazy"/>
                      
                        <cc1:PopupControlExtender ID="SplPopEx" runat="server" TargetControlID="btnSplDate"
                            PopupControlID="Panel1" Position="Bottom" OffsetX="-220" OffsetY="0">
                        </cc1:PopupControlExtender>
                        <asp:Panel ID="Panel1" runat="server" Style="z-index: 1;" Width="269">
                     
                            <table width="269" id="tblCal" runat="server" border="0" cellpadding="0" cellspacing="0"
                                style="border-top-width: 1px; border-bottom-width: 1px; border-left-width: 1px;
                                border-right-width: 1px; border-style: solid; border-color: #BF3411;">
                                <tr>
                                    <td bgcolor="#f2572b" height="35px" width="20%" align="center" valign="middle">
                                        <asp:DropDownList ID="ddlSPLMonth" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlSPLMonth_SelectedIndexChanged" Width="50" Visible="false">
                                            <asp:ListItem Text="Jan" Value="Jan"></asp:ListItem>
                                            <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                            <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                            <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                            <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                            <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                            <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                            <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                            <asp:ListItem Text="Sep" Value="Sep"></asp:ListItem>
                                            <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                            <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                            <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                        </asp:DropDownList>
                                 
                                          <asp:LinkButton ID="btnLeft" runat="server" 
                        onclick="btnLeft_Click" style="color:#fff; font-size:28px; font-weight:bold; text-decoration:none;"><</asp:LinkButton>
                        
                
                                    </td>
                                    <td align="center" style="text-align: center" bgcolor="#f2572b" height="35px" width="60%">
                                        <asp:Label ID="lbl" runat="server" Text="" Font-Size="13px" ForeColor="White"></asp:Label>
                                    </td>
                                    <td bgcolor="#f2572b" width="20%" align="center" valign="middle">
                                     
                                         <asp:LinkButton ID="btnRight" runat="server" 
                        onclick="btnRight_Click" style="color:#fff;  font-size:28px; font-weight:bold; text-decoration:none;">></asp:LinkButton>
                                        
                                        <asp:HiddenField ID="hdFromDate" runat="server" />
                                        <asp:HiddenField ID="hdToDate" runat="server" />
                                        <asp:HiddenField ID="lblStartDate" runat="server" />
                                        <asp:HiddenField ID="lblCurrentDate" runat="server" />
                                        <asp:HiddenField ID="hdLastDateCal" runat="server" />
                                       
                                        <asp:DropDownList ID="ddlSPLYear"   runat="server" AutoPostBack="True" Visible="false"
                                         OnSelectedIndexChanged="ddlSPLYear_SelectedIndexChanged"
                                             >
                                           
                                        </asp:DropDownList>
                                     
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:GridView ID="gvRoomDetails" runat="server" AutoGenerateColumns="true" HeaderStyle-Height="25px"
                                            Width="100%" AllowPaging="false" PageSize="20" CssClass="table-bordered" OnRowDataBound="gvRoomDetails_RowDataBound">
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                </div>
                <div class="col-md-5">
                    <asp:Button ID="btnSPLBook" runat="server" class="btn pull-right mrgntopno" ToolTip="Book Now"
                        OnClick="btnSPLBook_Click" ValidationGroup="SPLValidation1" Text="Book Now" />
                          
                </div>
            </div>
        </div>
        <%--</ContentTemplate>
 
</asp:UpdatePanel>--%>
<style type="text/css">
    #UpdateProgress1
    {
        background-color: #CF4342;
        color: #fff;
        top: 0px;
        right: 0px;
        position: fixed;
    }
    #UpdateProgress1 img
    {
        vertical-align: middle;
        margin: 2px;
    }
</style>
