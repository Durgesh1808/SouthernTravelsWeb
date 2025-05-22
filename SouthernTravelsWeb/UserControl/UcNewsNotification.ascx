<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcNewsNotification.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcNewsNotification" %>

<section id="latestnews">
  <div class="container-fluid">
    <div class="row displaytable">
      <div class="col-lg-2 col-md-2 displaycol bgnews valignmid">
        <div class="inner text-center pull-right"> <img src="/Assets/images/icon-news.png" loading="lazy">
          <p>Latest<br>
            News</p>
        </div>
      </div>
       <div class="col-lg-10 col-md-10 displaycol bgnewsdetail valignmid">
        <div class="inner">
        <div class="marqueewrap">
        <div id="nt-example1-container">
          <ul id="nt-example1">
            <asp:Repeater ID="repNews" runat=server>
             <ItemTemplate>
                        <span>
                        <%#DataBinder.Eval(Container.DataItem, "EventDate", "{0:MMM dd, yyyy}")== "" ? "":DataBinder.Eval(Container.DataItem, "EventDate", "{0:MMM dd, yyyy}")+" - " %> </span>
                         <asp:Literal ID="ltrNews" runat="server" Text='<%# Eval("shortdescription")%>'></asp:Literal>
                                   
             </ItemTemplate>
            </asp:Repeater>
             </ul></div>
             </div>
        </div>
      </div>
    </div>
  </div>
</section>
