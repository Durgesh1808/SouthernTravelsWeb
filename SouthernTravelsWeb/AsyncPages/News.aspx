<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="SouthernTravelsWeb.AsyncPages.News" %>

    <asp:Repeater ID="repNews" runat="server">
        <ItemTemplate>
                <span>
                    <%# DataBinder.Eval(Container.DataItem, "EventDate", "{0:MMM dd, yyyy}") == "" 
                        ? "" 
                        : DataBinder.Eval(Container.DataItem, "EventDate", "{0:MMM dd, yyyy}") + " - " %>
                </span>
                <asp:Literal ID="ltrNews" runat="server" Text='<%# Eval("shortdescription") %>'></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>


