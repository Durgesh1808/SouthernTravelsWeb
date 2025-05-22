<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcCarCoachRental.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcCarCoachRental" %> 
<asp:Repeater ID="rptCarCoachRentals" runat="server" 
  
    onitemdatabound="rptCarCoachRentals_ItemDataBound"  >
 <HeaderTemplate>
 
 </HeaderTemplate>
  <ItemTemplate>
     
     <div class="col-md-4">
 <ul class="sublist padding0 mrgnbtmno">
     <li><a href="#" id="anchorTag" runat="server">
      <asp:Label ID="lblTourName" runat="server" Text='<%# System.Threading.Thread.CurrentThread
                                                .CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(Eval("TourName")).ToLower())%>'
                        ToolTip='<%# System.Threading.Thread.CurrentThread
                                                .CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(DataBinder.Eval(Container.DataItem,"TourName")).ToLower()) %>'>
                    </asp:Label>
     
     </a>
     
     </li>   
     </ul>
       </div>
       </ItemTemplate>
      <FooterTemplate>
         </FooterTemplate>
  </asp:Repeater>
  