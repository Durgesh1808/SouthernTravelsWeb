<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMatchingTour.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcMatchingTour" %>

<div class="row rowgap noterow" id="divMsg" runat="server" visible="false">
    <div class="col-md-12 text-center noterow">
        <p>
            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
           </p>
    </div>
</div>
 <asp:Repeater ID="repMatchingTour" runat="server" OnItemDataBound="repMatchingTour_ItemDataBound">
   <HeaderTemplate>
     	<div class="row">
   </HeaderTemplate>
   
   <ItemTemplate>
             
         <div class="col-md-6">
            <div class="intlbox"> <a id="anchorTag" runat="server">
              <div class="imgsection">
                  <asp:HiddenField ID="hdHolidayType" runat="server" Value='<%# Eval("HolidayType")%>'/>
                  <asp:HiddenField ID="hdTourType" runat="server" Value='<%# Eval("TourType")%>'/>
                <span class="customtag2"><asp:Literal ID="ltrTourTypeText" runat="server" Text ='<%# Eval("HolidayType")%>'></asp:Literal><img src="Assets/images/custom-arrow.png" loading="lazy" alt="custom-arrow"/></span> 
               
            <img src="Assets/images/EntityImage/<%# Eval("MainImg") %>" width="365px" height="380px" alt='<%# Eval("TourType") %>' />
              <div class="textsection">
                <asp:Literal ID="ltrTourName" runat="server"></asp:Literal><%--<%# Eval("HolidayType")%>--%>
               
                 <p>
                               <asp:Literal ID="ltrNoDaysNight" runat="server"></asp:Literal>
                             </p>
                              <asp:Literal ID="litCost" runat="server"></asp:Literal>
              </div>
              </a> </div>
          </div>
                
    
   </ItemTemplate>
  
 
 </asp:Repeater>
   
  
            	
           
