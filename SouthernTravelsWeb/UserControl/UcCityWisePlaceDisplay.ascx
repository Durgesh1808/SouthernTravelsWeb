<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcCityWisePlaceDisplay.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcCityWisePlaceDisplay" %>

<asp:Repeater runat="server" ID="rptShowCity" EnableViewState="false" OnItemDataBound="rptShowCity_ItemDataBound">
    <HeaderTemplate>
        
    </HeaderTemplate>
    <ItemTemplate>
    <div class="row rowmrgn">
        <a id='<%# "Place" + DataBinder.Eval(Container.DataItem, "PlaceName") %>' name='<%# "Place" + Eval("PlaceName") %>'>
        </a>
        <div class="col-md-2">
            <div class="imgsection">
                <img class="img-responsive" src='EntityImage/<%# Eval("ImagePath") %>' title='<%# Eval("PlaceName") %>'
                    alt='<%# Eval("PlaceName") %>'>
            </div>
        </div>
        <div class="col-md-10">
            <div class="contsection">
                <h3>
                    <%# Eval("PlaceName") %></h3>
                <p>
                    <span class="more">
                        <%#Eval("LongDescription") %>
                    </span>
                </p>
            </div>
        </div> 
        </div>
    </ItemTemplate>
    <FooterTemplate>
       
    </FooterTemplate>
</asp:Repeater>
