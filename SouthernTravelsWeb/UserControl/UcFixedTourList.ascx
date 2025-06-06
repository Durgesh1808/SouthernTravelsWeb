<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcFixedTourList.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcFixedTourList" %>
<asp:GridView runat="server" ID="gvTourList" Width="100%" AutoGenerateColumns="false" ShowHeader = "false"
    GridLines="None" PageSize = "7" AllowPaging = "true" ShowFooter = "false" OnRowDataBound="gvTourList_RowDataBound">
    <PagerSettings Visible="false" />
    <Columns>
        <asp:TemplateField HeaderStyle-Width="60%"  ItemStyle-Width="60%">
            <ItemTemplate>
                <asp:HyperLink ID="lbtnTour" runat="server">
                    <asp:Label ID="lblTourName" runat="server" CssClass="tour-name" Text='<%# System.Threading.Thread.CurrentThread
                                                .CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(Eval("TourName")).Length > 25 ? Convert.ToString(Eval("TourName")).Substring(0, (Convert.ToString(Eval("TourName")).Substring(0, 25).LastIndexOf(" ") > 0 ? Convert.ToString(Eval("TourName")).Substring(0, 25).LastIndexOf(" ") : Convert.ToString(Eval("TourName")).Substring(0, 25).LastIndexOf("-"))).ToLower() + " ..."  : Convert.ToString(Eval("TourName")).ToLower())%>'
                        ToolTip='<%# System.Threading.Thread.CurrentThread
                                                .CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(DataBinder.Eval(Container.DataItem,"TourName")).ToLower()) %>'>
                    </asp:Label>
                </asp:HyperLink>
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