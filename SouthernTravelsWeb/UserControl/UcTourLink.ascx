<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTourLink.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcTourLink" %>
<style>
    th[align="right"]
    {
        text-align: right;
    }
</style>

<asp:GridView runat="server" ID="gvTourList" Width="100%" AutoGenerateColumns="false"
    GridLines="None" ShowHeader="true" CssClass="table-bordered" OnRowDataBound="gvTourList_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="Tour Code" HeaderStyle-Width="20%" ItemStyle-Width="20%">
            <ItemTemplate>
                <%# Eval("Tour_Short_Key")%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Package Name" HeaderStyle-Width="40%" ItemStyle-Width="40%">
            <ItemTemplate>
                <asp:HyperLink ID="lbtnTour" runat="server">
                    <asp:Label ID="lblTourName" runat="server" Text='<%# System.Threading.Thread.CurrentThread
                                                .CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(Eval("TourName")).ToLower())%>'
                        ToolTip='<%# System.Threading.Thread.CurrentThread
                                                .CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(DataBinder.Eval(Container.DataItem,"TourName")).ToLower()) %>'>
                    </asp:Label><br />
                <span style="font-size: 11px; color: #f1562b">
                    <%# Eval("TourNo").ToString() == "0" ? "(Operated by Andhra Pradesh Tourism Development Corp. Govt. of A.P.)" : ""%></span>
                </asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Days" HeaderStyle-Width="20%" ItemStyle-Width="20%">
            <ItemTemplate>
                <%# Eval("TourGoingOn")%><br />
                <span style="font-size: 11px; color: #f1562b">
                    <%# Eval("DepartureWeekDays")%></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Price" HeaderStyle-Width="20%" ItemStyle-Width="20%"
            ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <%# Convert.ToInt32(Eval("MinCost")) == 0 ? "On Request" : "<i class='fa fa-rupee'></i>" + Convert.ToString(Eval("MinCost", "{0:N}")).Split('.')[0] + "/-"%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField Visible="false">
            <ItemTemplate>
                <asp:HiddenField ID="hdTourID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"TourNo") %>' />
                <asp:HiddenField ID="hdTourName" runat="server" Value='<%# Eval("TourName") %>' />
               
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


<script type="text/javascript">
    function OpenNewPage(strRowIndex) {
        window.location = strRowIndex;
    }
</script>


