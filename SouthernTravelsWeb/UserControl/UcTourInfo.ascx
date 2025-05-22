<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTourInfo.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcTourInfo" %>
<div class="row rowgap noterow" id="divMsg" runat="server" visible="false">
    <div class="col-md-12 text-center noterow">
        <p>
            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
           </p>
    </div>
</div>
<asp:HiddenField ID="hdnTourInfoHtml" runat="server" Value="" />
<asp:Repeater ID="TourInFo" runat="server">
    <ItemTemplate>
        <div class="row rowgap">
            <div class="col-md-12">
                <h3 class="title">
                    <span>
                        <%#Eval("CategoryName") %></span></h3>
                <p>
                    
            <ul class="sublist"><%# Server.HtmlDecode(Eval("Info_Content").ToString())%></ul>
                </p>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
