<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcModifySearch.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcModifySearch" %>
images
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript">
    function ShoHide() {

    }
</script>

<style type="text/css">
    /*AutoComplete flyout */.autocomplete_completionListElement
    {
        margin: 0px !important;
        background-color: inherit;
        color: windowtext;
        border: buttonshadow;
        border-width: 1px;
        border-style: solid;
        cursor: 'default';
        overflow: auto;
        height: auto;
        text-align: left;
        list-style-type: none;
    }
    /* AutoComplete highlighted item */.autocomplete_highlightedListItem
    {
        background-color: #ffff99;
        color: black;
        padding: 1px;
    }
    /* AutoComplete item */.autocomplete_listItem
    {
        background-color: window;
        color: windowtext;
        padding: 1px;
    }
    .AutoExtender
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: .8em;
        font-weight: normal;
        border: solid 1px #006699;
        line-height: 20px;
        padding: 10px;
        background-color: White;
        margin-left: 10px;
        list-style: none;
        margin: 0px;
    }
    .AutoExtenderList
    {
        cursor: pointer;
        color: Maroon;
        font-style: normal;
    }
    .WaterMark-Text
    {
        color: #DEDEDE;
        font-style: italic;
        font-size: 10px;
    }
    .seatavailmonth .dropdown-menu
    {
        max-height: 360px !important;
    }
    .ddlJDate .dropdown-menu
    {
        max-height: 250px !important;
    }
    @media screen and (max-width: 1024px)
    {
        .ddlJDate .dropdown-menu
        {
            max-height: 140px !important;
        }
    }
</style>
<style>
    .link-blue
    {
        font-family: Arial, Helvetica, sans-serif;
        font-size: 10px;
        color: #0000FF;
        text-decoration: none;
    }
    .link-blue:hover
    {
        text-align: right;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 10px;
        color: #5a9305;
        text-decoration: none;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
        <asp:HiddenField ID="hdFromDate" runat="server" />
        <asp:HiddenField ID="hdToDate" runat="server" />
        <asp:HiddenField ID="lblStartDate" runat="server" />
        <asp:HiddenField ID="lblCurrentDate" runat="server" />
        <asp:HiddenField ID="hdLastDateCal" runat="server" />
        <div class="calendarwrap">
            <div class="calanderwrap">
                <div class="seatavailhd">
                    <h3 class="title pull-left">
                        Seat <span>Availability in</span></h3>
                    <div class="formwrap pull-left smallselect seatavailmonth">
                        <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" class="form-control"
                            OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
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
                    </div>
                    <div class="formwrap pull-left smallselect seatavailmonth">
                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" class="form-control"
                            OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="formwrap pull-right ddlJDate" style="width: 240px">
                        <asp:DropDownList ID="ddlJDate" runat="server" AutoPostBack="True" class="form-control"
                            OnSelectedIndexChanged="ddlJDate_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="clearfix">
                </div>
                <div class="seatavailmonth">
                    <div class="calheader posrel ">
                        <div class="calnav calnavleft">
                            <asp:ImageButton ID="btnLeft" runat="server" Text="Submit" ImageUrl="../images/arrowbtn-left.png"
                                OnClick="btnLeft_Click" />
                        </div>
                        <h3 class="title text-center">
                            <asp:Label ID="lblMonth" runat="server" Text="" CssClass="txtcolor"></asp:Label>
                        </h3>
                        <div class="calnav calnavright">
                            <asp:ImageButton ID="btnRight" runat="server" Text="Submit" ImageUrl="/Assets//images/arrowbtn-right.png"
                                OnClick="btnRight_Click" />
                        </div>
                    </div>
                    <div class="tablewrap">
                        <asp:GridView ID="gvRoomDetails" runat="server" AutoGenerateColumns="true" HeaderStyle-Height="25px"
                            Width="100%" AllowPaging="false" PageSize="20" OnRowDataBound="gvRoomDetails_RowDataBound"
                            CssClass="table-bordered" GridLines="None">
                        </asp:GridView>
                    </div>
                </div>
            </div>
       
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
