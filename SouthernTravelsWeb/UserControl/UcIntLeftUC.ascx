<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcIntLeftUC.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcIntLeftUC" %>
<link href="Assets/css/accordion.css" rel="stylesheet" type="text/css" />

<script src="Assets/js/jquery.msAccordion.js" type="text/javascript"></script>

<link href="Assets/css/Inttour.css" rel="stylesheet" type="text/css" />
<table width="100%">
    <tr>
        <td>
            <input type="hidden" runat="server" id="ActUrl" />
            <div class="accordionWrapper I_nav" id="accordionNested">
                <%--<asp:Repeater ID="repCalendar" runat="server" OnItemDataBound="repCalendar_ItemDataBound">
                    <ItemTemplate>--%>
                <asp:Repeater ID="repCalendarEvent" runat="server">
                    <ItemTemplate>
                        <div id='divDate'+'<%# Container.ItemIndex%>'>
                            <asp:HiddenField runat="server" ID="RegionIndex" Value='<%# Container.ItemIndex%>' />
                            <div class="title">
                                <div class="cName" runat="server" id="aSelRegion">
                                    <span>
                                        <%# Eval("ZoneName")%></span>
                                </div>
                            </div>
                            <div class="content">
                                <div id="accordionNestedChild" class="accordionNestedChild" runat="server">
                                    <asp:Repeater ID="repCalendarEventReply" runat="server" DataSource='<%# Eval("Tours")%>'>
                                        <ItemTemplate>
                                            <div class="content">
                                                <asp:HiddenField runat="server" ID="CountryIndex" Value='<%# Container.ItemIndex%>' />
                                                <asp:HiddenField runat="server" ID="hdnCountryRegion" Value='<%#"CountryId="+Eval("TourId")+"&ZoneId="+Eval("ZoneId")%>' />
                                                <asp:HiddenField ID="hdnc" runat="server" Value='<%# Eval("TourId")%>' />
                                                <ul>
                                                    <li runat="server" id="aCountry">
                                                        <div class="title">
                                                            <%--<li runat="server" id="lihrefClick">--%>
                                                            <a id="hrefClick" runat="server" href='<%# "~/" + "InternationalTours"+fldOffers+"-"  +  
                                                            System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(Eval("ZoneName")).ToLower()).Replace(" ", "").Replace("-", "") + "-" + 
                                                            System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(Eval("TourName")).ToLower()).Replace("&", "AND").Replace(" ", "").Replace("-", "").Replace("[", "").Replace("]", "")+ 
                                                            "_" + Eval("TourId") %>'>
                                                                <%# System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(Eval("TourName")).ToLower()).Replace("Usa ", "USA ").Replace(" Usa ", " USA ").Replace(" Usa", " USA")%></a></div>
                                                        
                                                        <%--</li>--%>
                                                        <%--<ul runat="server" id="ulCountryTours">
                                                            <div class="content">
                                                                <li runat="server" id="lihrefClick"><a id="hrefClick" runat="server" href='<%# "~/" + "InternationalTours"+fldOffers+"-"  +  System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(hdnC.Value).ToLower()).Replace(" ", "").Replace("-", "") + "-" + 
                                                                                System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(Eval("TourName")).ToLower()).Replace("&", "AND").Replace(" ", "").Replace("-", "").Replace("[", "").Replace("]", "") + "_" + Eval("TourId") %>'>
                                                                    <%# System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(Eval("TourName")).ToLower())%>
                                                                </a></li>
                                                            </div>
                                                        </ul>--%>
                                                    </li>
                                                </ul>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <%--</ItemTemplate>
                </asp:Repeater>--%>
            </div>
        </td>
    </tr>
</table>

<script language="javascript" type="text/javascript">

    var defaultShow = 0;
    var defaultChildShow = 0;
    var urlofPage = document.getElementById("<%=ActUrl.ClientID%>").value;
    //
    if (urlofPage.toLowerCase().indexOf('tourid') > 0) {
        var elementsDiv = document.getElementById('accordionNested').getElementsByTagName("a");
        //var searchUrl = document.location.href.substring(document.location.href.lastIndexOf('_'), document.location.href.length);
        var searchUrl = '_' + urlofPage.substring(urlofPage.toLowerCase().lastIndexOf('tourid') + 7, (urlofPage.indexOf('&') > 0 ? urlofPage.indexOf('&') : urlofPage.length));
        //alert(searchUrl);
        //alert(urlofPage.endsWith(searchUrl));
        for (var i = 0; i < elementsDiv.length; i++) {
            if (elementsDiv[i].href.endsWith(searchUrl)) {
                var LinkId = elementsDiv[i].id;
                //alert(LinkId);
                var hdnParentId = LinkId.replace("hrefClick", "CountryIndex"); 
                // LinkId.substring(0, LinkId.lastIndexOf('repCalendarEventReply')) + "CountryIndex";
                //alert(hdnParentId);
                var defaultShowhdn = LinkId.substring(0, LinkId.lastIndexOf('repCalendarEventReply')) + "RegionIndex";
                //alert(defaultShowhdn);
                var dafaultCountryShown = LinkId.substring(0, LinkId.lastIndexOf("repCalendarEventReply_")) + "aSelRegion";
                //alert(dafaultCountryShown);
                var defaultTour = LinkId.replace("hrefClick", "aCountry");
                document.getElementById(defaultTour).setAttribute("class", "Iactive");
                
                //document.getElementById(LinkId.substring(0, LinkId.lastIndexOf("repCalendarEventReply_")) + "aCountry").setAttribute("class", "Iactive");

                document.getElementById(defaultTour).setAttribute("class", "Iactive");
                
                document.getElementById(dafaultCountryShown).setAttribute("class", "cSelected");
                defaultShow = document.getElementById(defaultShowhdn).value;
                defaultChildShow = document.getElementById(hdnParentId).value;
                break;
            }
        }
    }
    else {
        var elementsDiv = document.getElementById('accordionNested').getElementsByTagName("input");
        //alert(elementsDiv[0].href);
        var searchUrl = urlofPage.substring(urlofPage.lastIndexOf('?'), urlofPage.length);
        for (var i = 0; i < elementsDiv.length; i++) {
            if (elementsDiv[i].id.indexOf("hdnCountryRegion") > 0 && searchUrl.indexOf(elementsDiv[i].value) > 0) {
                var LinkId = elementsDiv[i].id;
                var hdnParentId = LinkId.substring(0, LinkId.lastIndexOf("repCalendarEventReply")) + "RegionIndex";
                var defaultShowhdn = LinkId.replace("hdnCountryRegion", "CountryIndex");
                var dafaultCountryShown = LinkId.substring(0, LinkId.lastIndexOf("repCalendarEventReply")) + "aSelRegion";
                var element = document.getElementById(dafaultCountryShown);
                if (element) {
                    element.setAttribute("class", "cSelected");
                }
                //document.getElementById(dafaultCountryShown).setAttribute("class", "cSelected");
                defaultShow = document.getElementById(hdnParentId).value;
                defaultChildShow = document.getElementById(defaultShowhdn).value;
                //alert(defaultShow);
                //alert(defaultChildShow);
                /* ***** To Have current Tour Control Name ***** */
                // ***** START *****
                document.getElementById(LinkId.replace("hdnCountryRegion", "aCountry")).setAttribute("class", "Iactive");
                var CurrentCountryTours = document.getElementById(LinkId.replace("hdnCountryRegion", "ulCountryTours")).getElementsByTagName("li");
                document.getElementById(CurrentCountryTours[0].id).setAttribute("class", "Iactive");
                // ***** END *****
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

<asp:HiddenField ID="HiddenField1" runat="server" />
<asp:HiddenField ID="hdnC" runat="server" />
