<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcCustomerLeft.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcCustomerLeft" %>

<script type="text/javascript" src="Assets/js/jquery-1.6.1.min.js"></script>
<style>
.tarifftab, .tabsection_inner .nav-tabs{ display: block!important}
@media screen and (max-width: 992px)
{
	.tarifftab, .tabsection_inner .nav-tabs{ display: block!important}
	.accounttabs{ margin-bottom: 15px}
	.accounttabs .nav-tabs > li > a{ font-size: 13px!important; padding: 5px!important}
	.welcometxt{ margin: 10px; width: 100%}
}
</style>
<input type="hidden" runat="server" id="ActUrl" />
<div class="row">
    <div class="col-md-12">
        <div class="tabsection_inner">
            <div class="btnbooknow">
            <%if (Session["custrowid"] != null)
              { %>
                <%} %></div>
                <div class="accounttabs">
            <ul class="nav nav-tabs" id="accordionNested">
                <asp:Repeater ID="repCalendar" runat="server">
                    <ItemTemplate>
                        <li runat="server" id="aSelRegion">
                            <asp:HiddenField runat="server" ID="RegionIndex" Value='<%# Container.ItemIndex%>' />
                            <asp:HiddenField runat="server" ID="hdnRegion" Value='<%# "_MM=" + Eval("MenuID") + "_"%>' />
                            <a href='<%# Eval("MenuLink") + "?MM=" + Eval("MenuID")%>'>
                                <div >
                                    <span>
                                        <%# Eval("MenuName")%></span></div>
                            </a></li>
                       
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            </div>
        </div>
    </div>
</div>

<script language="javascript" type="text/javascript">
    var defaultShow = 0;
    var defaultChildShow = 0;
    var elementsDiv = document.getElementById('accordionNested').getElementsByTagName("input");
    var searchUrl = document.location.href.substring((document.location.href.lastIndexOf('?') + 1), document.location.href.length) + "_";
    if (searchUrl.indexOf("SM=") >= 0) {
        for (var i = 0; i < elementsDiv.length; i++) {
            if (elementsDiv[i].value.indexOf(searchUrl) > 0) {
                var LinkId = elementsDiv[i].id;
                var defaultTour = LinkId.replace("hdnCountryRegion", "aCountry");
                document.getElementById(defaultTour).setAttribute("class", "active");
                document.getElementById(LinkId.substring(0, LinkId.lastIndexOf("repCalendarEvent")) + "aSelRegion").setAttribute("class", "IloginS");
                defaultShow = document.getElementById(LinkId.substring(0, LinkId.lastIndexOf("repCalendarEvent")) + "RegionIndex").value;
                defaultChildShow = document.getElementById(LinkId.replace("hdnCountryRegion", "CountryIndex")).value;
                break;
            }
        }
    }
    else {
        
        for (var i = 0; i < elementsDiv.length; i++) {
            if (elementsDiv[i].value.indexOf(searchUrl) > 0) {
                var LinkId = elementsDiv[i].id;
             
                var defaultTour = LinkId.replace("hdnRegion", "aSelRegion");
                document.getElementById(defaultTour).setAttribute("class", "active");
                defaultShow = document.getElementById(LinkId).value;
                defaultChildShow = document.getElementById(LinkId).value;
                break;
            }
        }
    }

    $(document).ready(function() {
        $("#accordionNested").msAccordion({ defaultid: defaultShow, vertical: true });
        $(".accordionNestedChild").each(function() {
            $(this).msAccordion({ defaultid: defaultChildShow, vertical: true });
        });
    });
</script>

<asp:HiddenField ID="hdnC" runat="server" />
