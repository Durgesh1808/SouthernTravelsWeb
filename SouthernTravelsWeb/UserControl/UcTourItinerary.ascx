<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTourItinerary.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcTourItinerary" %>

<asp:Repeater ID="rptItinerary" runat="server" OnItemDataBound="rptItinerary_ItemDataBound">
    <HeaderTemplate>
        <table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="paddingbtm40">
                <div class="row_day">
                    <div class="day">
                        <div class="daydesc">
                            Day
                            <%# Eval("DayNo")%>
                            <br />
                            <%# Eval("ItineraryTime").ToString() == "00:00 Hrs" ? "" : Eval("ItineraryTime").ToString()%>
                        </div>
                    </div>
                    <div class="desc">
                        <%# Eval("DayTitle")%></div>
                    <%if (Convert.ToString(fldTourType) != "INTERNATIONAL_TOUR")
                      {%>
                 
                    <%} %>
                </div>
                <div class="row_desc">
                    <div class="dotlist">
                        <p>
                            <%# Eval("PlaceOfVisit")%>
                        </p>
                    </div>
                </div>
              
                <asp:Literal ID="ltrText" runat="server"></asp:Literal>
                <asp:HiddenField ID="hdNightHalt" runat="server" Value='<%#Eval("NightHalt") %>' />
                <asp:HiddenField ID="hdMealPlan" runat="server" Value='<%#Eval("MealPlan") %>' />
                <asp:HiddenField ID="hdnItinairyDayNo" runat="server" Value='<%# Eval("DayNo")%>' />
                <asp:HiddenField ID="hdnItiniraryTime" runat="server" Value='<%# Eval("ItineraryTime").ToString() == "00:00 Hrs" ? "" : Eval("ItineraryTime").ToString()%>' />
                <asp:HiddenField ID="hdnItiDayTitle" runat="server" Value='<%# Eval("DayTitle")%>' />
                <asp:HiddenField ID="hdnItiPlaceOfVisit" runat="server" Value='<%# Eval("PlaceOfVisit")%>' />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:HiddenField ID="hdnTourItineraryHtml" runat="server" Value="" />

