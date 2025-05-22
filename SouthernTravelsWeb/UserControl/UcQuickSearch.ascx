<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcQuickSearch.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcQuickSearch" %>

<%@ Register Src="UcHolidaySearch.ascx" TagName="UCHolidaySearch" TagPrefix="uc1" %>
<%@ Register Src="UcSpecialTourSearch.ascx" TagName="UcSpecialTourSearch" TagPrefix="uc2" %>
<%@ Register Src="UcHotelInSouthern.ascx" TagName="UcHotelInSouthern" TagPrefix="uc3" %>
<%@ Register Src="UcHotelInIndia.ascx" TagName="UCHotelinIndia" TagPrefix="uc4" %>
<%@ Register Src="UcFlightSearch.ascx" TagName="ucFlightSearch" TagPrefix="uc5" %>
<%@ Register Src="UcNewsUpdateShow.ascx" TagName="ucNewsUpdateShow" TagPrefix="uc6" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
    function OnSPLShowSub2(id) {
        OnSPLShow2('QSHTL');
        document.getElementById("<%=QSFDDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSHPDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSHTLDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSFLIGHTDIV.ClientID %>").style.display = "none";

        document.getElementById("<%=QSFD.ClientID %>").setAttribute("class", "t1 tab");
        document.getElementById("<%=QSHP.ClientID %>").setAttribute("class", "t2 tab");

        document.getElementById("<%=QSHTL.ClientID %>").setAttribute("class", "t4 tab");
        document.getElementById("<%=QSFLIGHT.ClientID %>").setAttribute("class", "t5 tab");
        document.getElementById("<%=QSINDHTL.ClientID %>").setAttribute("class", "s1 ssTab");
        document.getElementById("<%=QSINDHTL.ClientID %>").setAttribute("class", "s2 ssTab");

        document.getElementById("<%=QSHTLDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSHTL.ClientID %>").setAttribute("class", "t4 tab");
        document.getElementById("<%=QSDELHTLDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSDELHTL.ClientID %>").setAttribute("class", "s1 ssTab");

        if (document.getElementById("<%=hdMenuSubTab.ClientID %>").value == '5') {
            if (id == 'QSDELHTL') {
                document.getElementById("<%=QSHTLDIV.ClientID %>").style.display = "block";
                document.getElementById("<%=QSHTL.ClientID %>").setAttribute("class", "t4 tab active");
                document.getElementById("<%=QSDELHTLDIV.ClientID %>").style.display = "block";
                document.getElementById("<%=QSDELHTL.ClientID %>").setAttribute("class", "s1 ssTab subact");
                document.getElementById("<%=hdMenuSubTab.ClientID %>").value = "5";
            }
            if (id == 'QSINDHTL') {
                document.getElementById("<%=QSHTLDIV.ClientID %>").style.display = "block";
                document.getElementById("<%=QSHTL.ClientID %>").setAttribute("class", "t4 tab active");
                document.getElementById("<%=QSINDHTLDIV.ClientID %>").style.display = "block";
                document.getElementById("<%=QSINDHTL.ClientID %>").setAttribute("class", "s2 ssTab subact");
                document.getElementById("<%=hdMenuSubTab.ClientID %>").value = "6";
            }
        }
    }
    function OnSPLShow2(id) {
        //alert(id);
        document.getElementById("<%=QSFDDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSHPDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSHTLDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSFLIGHTDIV.ClientID %>").style.display = "none";

        document.getElementById("<%=QSFD.ClientID %>").setAttribute("class", "");
        document.getElementById("<%=QSHP.ClientID %>").setAttribute("class", "");

        document.getElementById("<%=QSHTL.ClientID %>").setAttribute("class", "");
        document.getElementById("<%=QSFLIGHT.ClientID %>").setAttribute("class", "");

        document.getElementById("<%=QSHTLDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSHTL.ClientID %>").setAttribute("class", "");
        document.getElementById("<%=QSINDHTLDIV.ClientID %>").style.display = "none";
        document.getElementById("<%=QSINDHTL.ClientID %>").setAttribute("class", "");

        document.getElementById("<%=hdMenuSubTab.ClientID %>").value = id;

        if (document.getElementById("<%=hdMenuSubTab.ClientID %>").value == 'QSFD') {
            document.getElementById("<%=QSFDDIV.ClientID %>").style.display = "block";
            document.getElementById("<%=QSFD.ClientID %>").setAttribute("class", "active");
            document.getElementById("<%=QSFDDIV.ClientID %>").setAttribute("class", "tab-pane fade in active");
            document.getElementById("<%=hdMenuSubTab.ClientID %>").value = "1";
        }
        if (document.getElementById("<%=hdMenuSubTab.ClientID %>").value == 'QSHP') {
            document.getElementById("<%=QSHPDIV.ClientID %>").style.display = "block";
            document.getElementById("<%=QSHP.ClientID %>").setAttribute("class", "active");
            document.getElementById("<%=QSHPDIV.ClientID %>").setAttribute("class", "tab-pane fade in active");
            document.getElementById("<%=hdMenuSubTab.ClientID %>").value = "2";
        }
        
        if (document.getElementById("<%=hdMenuSubTab.ClientID %>").value == 'QSHTL') {
                debugger;
            document.getElementById("<%=QSHTLDIV.ClientID %>").style.display = "block";
            document.getElementById("<%=QSHTLDIV.ClientID %>").setAttribute("class", "tab-pane fade in active padding0");
            document.getElementById("<%=QSHTL.ClientID %>").setAttribute("class", "active");

            document.getElementById("<%=QSDELHTLDIV.ClientID %>").style.display = "block";
            document.getElementById("<%=QSDELHTLDIV.ClientID %>").setAttribute("class", "tab-pane fade in active padding0");


            document.getElementById("<%=hdMenuSubTab.ClientID %>").value = "5";

        }
        if (document.getElementById("<%=hdMenuSubTab.ClientID %>").value == 'QSDELHTL') {

            document.getElementById("<%=QSHTLDIV.ClientID %>").style.display = "block";
            document.getElementById("<%=QSHTLDIV.ClientID %>").setAttribute("class", "tab-pane fade in active padding0");
            document.getElementById("<%=QSHTL.ClientID %>").setAttribute("class", "active");

            document.getElementById("<%=QSDELHTLDIV.ClientID %>").style.display = "block";
            document.getElementById("<%=QSDELHTLDIV.ClientID %>").setAttribute("class", "tab-pane fade in active padding0");

            document.getElementById("<%=QSINDHTLDIV.ClientID %>").style.display = "none";
            document.getElementById("<%=QSINDHTLDIV.ClientID %>").setAttribute("class", "tab-pane fade");

            document.getElementById("<%=hdMenuSubTab.ClientID %>").value = "5";

        }
        if (document.getElementById("<%=hdMenuSubTab.ClientID %>").value == 'QSINDHTL') {

            document.getElementById("<%=QSHTLDIV.ClientID %>").style.display = "block";
            document.getElementById("<%=QSHTLDIV.ClientID %>").setAttribute("class", "tab-pane fade in active padding0");
            document.getElementById("<%=QSHTL.ClientID %>").setAttribute("class", "active");

            document.getElementById("<%=QSDELHTLDIV.ClientID %>").style.display = "none";
            document.getElementById("<%=QSDELHTLDIV.ClientID %>").setAttribute("class", "tab-pane fade");

            document.getElementById("<%=QSINDHTLDIV.ClientID %>").style.display = "block";
            document.getElementById("<%=QSINDHTLDIV.ClientID %>").setAttribute("class", "tab-pane fade in active padding0");


            document.getElementById("<%=hdMenuSubTab.ClientID %>").value = "5";

        }
        if (document.getElementById("<%=hdMenuSubTab.ClientID %>").value == 'QSFLIGHT') {
            document.getElementById("<%=QSFLIGHTDIV.ClientID %>").style.display = "block";
            document.getElementById("<%=QSFLIGHT.ClientID %>").setAttribute("class", "active");
            document.getElementById("<%=QSFLIGHTDIV.ClientID %>").setAttribute("class", "tab-pane fade in active padding0");
            document.getElementById("<%=hdMenuSubTab.ClientID %>").value = "8";
        }
    }
      
</script>

<div id="booking">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdMenuSubTab" runat="server" Value="" />
            <div id="exTab2"> 
                <ul class="nav nav-tabs">
                    <li id="QSFD" runat="server" onclick="JavaScript:OnSPLShow2('QSFD');"><a href="#"
                        data-toggle="tab"><i class="fa fa-suitcase"></i>Holidays</a></li>
                    <li id="QSHP" runat="server" onclick="JavaScript:OnSPLShow2('QSHP');"><a href="#"
                        data-toggle="tab"><i class="fa fa-car"></i>Car Rentals</a></li>
                   
                    <li id="QSHTL" runat="server" onclick="JavaScript:OnSPLShow2('QSHTL');"><a href="#"
                        data-toggle="tab"><i class="fa fa-building"></i>Hotels</a></li>
                         <li onclick="JavaScript:OnSPLShow2('QSFLIGHT');" id="QSFLIGHT" runat="server"><a
                        href="#" data-toggle="tab"><i class="fa fa-plane"></i>Flights</a></li>
                </ul>
                <div class="tab-content">
                    <div runat="server" id="QSFDDIV" class="tab-pane fade  in active">
                        <uc1:UCHolidaySearch ID="UCHolidaySearch1" runat="server" />
                    </div>
                    <div runat="server" id="QSHPDIV" class="tab-pane fade">
                        <uc2:UcSpecialTourSearch ID="UcSpecialTourSearch2" runat="server" />
                    </div>
                    <div runat="server" id="QSFLIGHTDIV" class="tab-pane fade padding0">
                        <iframe src="/HtmlPages/SouthernTravels.htm" width="100%" height="270px">
                        </iframe>
                    </div>
                    <div class="tab-pane fade padding0" runat="server" id="QSHTLDIV" >
                  <ul class="nav nav-tabs">
                    <li class="active" runat="server" onclick="JavaScript:OnSPLShow2('QSDELHTL');" id="QSDELHTL"><a href="#hotel_southern" data-toggle="tab">Hotel Southern</a></li>
                    <li id="QSINDHTL" runat="server" onclick="JavaScript:OnSPLShow2('QSINDHTL');"><a href="#hotel_india" data-toggle="tab">Hotels in India</a></li>
                  </ul>
                  <div class="tab-content subtabcontent subtabcontent-height" >
                    
                    <div class="tab-pane fade in active" runat="server" id="QSDELHTLDIV" style="padding: 0 20px!important;">
                      
                      <uc3:UcHotelInSouthern ID="UcHotelInSouthern1" runat="server" />
                    </div>
                   
                   <div class="tab-pane fade" runat="server" id="QSINDHTLDIV">
                     <iframe src="/HtmlPages/SouthernTravelHotels.htm" width="100%" height="230px"></iframe>
                    </div>
                  </div>
                </div>
                   
                </div>
            </div>
         </ContentTemplate>
    </asp:UpdatePanel>
</div>
