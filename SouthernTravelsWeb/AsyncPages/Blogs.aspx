<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blogs.aspx.cs" Inherits="SouthernTravelsWeb.AsyncPages.Blogs" %>


 <asp:Repeater ID="repBlog" runat="server" >
   <HeaderTemplate>
     	  <div class="row">
   </HeaderTemplate>
   
   <ItemTemplate>
      <div class="col-md-4">
        <div class="block eqheightcol">
          <div class="imgsection"><img src='<%# Eval("ImageUrl")%>' class="img-responsive" alt="Blog" loading="lazy"></div>
          <div class="txtsection">
            <h3> <%# Eval("BlogTitle")%></h3>
            <p>
              <%# System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(Eval("SmallDescription")).Length > 220 ? Convert.ToString(Eval("SmallDescription")).Substring(0, (Convert.ToString(Eval("SmallDescription")).Substring(0, 220).LastIndexOf(" ") > 0 ? Convert.ToString(Eval("SmallDescription")).Substring(0, 220).LastIndexOf(" ") : Convert.ToString(Eval("SmallDescription")).Substring(0, 220).LastIndexOf("-"))).ToLower() + "..." : Convert.ToString(Eval("SmallDescription")).ToLower())%>  
           <a href="<%# Eval("BlogUrl")%>" target="_blank">Read more <i class="fa fa-long-arrow-right"></i></a> <%--</p>--%>
            </p>
          </div>
        </div>
      </div>
   </ItemTemplate>
   <FooterTemplate>
     </div>
    <div class="row">
      <div class="col-md-12">
        <p class="visitblog"><a href="https://blog.southerntravelsindia.com/" target="_blank">Visit Our Blog</a></p>
      </div>
    </div>
   </FooterTemplate>
 
 </asp:Repeater>  
