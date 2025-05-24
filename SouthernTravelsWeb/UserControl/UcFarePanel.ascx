<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcFarePanel.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcFarePanel" %>
 <div class="">
            	<h3 class="title">Tour <span>Price</span></h3>
<div class="tablewrap">

<asp:Literal runat="server" ID="litFarePanel">
</asp:Literal>
<p class="notepara">
<%if (fldTourID != 130)
  { %>
    <span>Note:</span> GST @5.00% applicable.
    <%} %>
</p>
<asp:Literal runat="server" ID="litFarePanelBookNow">
</asp:Literal>
<asp:HiddenField ID="hdnFarePanelItineraryHtml" runat="server" Value="" />
</div>
</div>