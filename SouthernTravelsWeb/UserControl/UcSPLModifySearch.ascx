<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSPLModifySearch.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcSPLModifySearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UcQuickSearch.ascx" TagPrefix="uc" TagName="QuickSearch" %>


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
    .seatavailmonthspl .dropdown-menu{ max-height: 360px!important}
    
    @media screen and (max-width: 1024px)
    {
    	 .seatavailmonthspl .dropdown-menu{ max-height: 140px!important}
    }
    
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
        <asp:Label ID="lblJDate" runat="server" Text="" ></asp:Label>
        <asp:HiddenField ID="hdTourName" runat="server" />
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
                    	<div class="formwrap pull-left smallselect seatavailmonthspl">
                   <asp:DropDownList ID="ddlSPLMonth" runat="server" AutoPostBack="True"
            class="form-control" OnSelectedIndexChanged="ddlSPLMonth_SelectedIndexChanged">
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
                  
                  <div class="formwrap pull-left smallselect">
                  <asp:DropDownList ID="ddlSPLYear" runat="server" AutoPostBack="True" 
            class="form-control" OnSelectedIndexChanged="ddlSPLYear_SelectedIndexChanged">
        </asp:DropDownList>
                   
                  
                  </div>
                </div>
                <div class="clearfix">
                </div>
                <div>
                    <div class="calheader posrel">
                    
        
                        
                        <div class="calnav calnavleft">
                            <asp:ImageButton ID="btnLeft" runat="server" Text="Submit" ImageUrl="/Assets/images/arrowbtn-left.png"  OnClick="btnLeft_Click"/>
                            <%--<a href="#"><i class="fa fa-angle-left"></i></a>--%>
                        </div>
                        <h3 class="title text-center">
                           <asp:Label ID="lblMonth" runat="server" Text="" CssClass="txtcolor"></asp:Label> </h3>
                        <div class="calnav calnavright">
                            <asp:ImageButton ID="btnRight" runat="server" Text="Submit" ImageUrl="../images/arrowbtn-right.png" OnClick="btnRight_Click"/>
                            <%--<a href="#"><i class="fa fa-angle-right"></i></a>--%>
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
