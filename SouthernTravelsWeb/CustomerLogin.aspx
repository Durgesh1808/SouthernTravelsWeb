<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLogin.aspx.cs" Inherits="SouthernTravelsWeb.CustomerLogin" %>


<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online Customer Panel : Southern Travels</title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta name="description" content="Southern Travels has wide checklist of corporate & business travel packages. Choose the best travel agency to ensure an unforgettable holiday!" />
    <meta name="Keywords" content="corporate business travel, corporate travel agencies, corporate travel agency, corporate travel agent, corporate travel services, cruise travel, holiday travel agency, honeymoon travel agents, indian travel agencies, indian travel agency, indian travel agent, international travel agencies, luxury travel agency, online travel agencies, online travel agent, online travel agents, online travel companies, online travel company, tour agency, tour operator, tour operators, travel agencies in india, travel agencies india, travel agency, travel agency franchise, travel agency india, travel agent, travel agent india, travel angency, travel booking agent, travel company, travel site" />
    <noscript>
        <meta http-equiv="Refresh" content="0;URL=index.aspx" />
    </noscript>
    <style>
        #rbtnCustomer td
        {
            padding: 0 15px 0 0;
        }
        #rbtnCustomer label
        {
            margin-left: 5px;
        }
        #rbtnAgent td
        {
            padding: 0 15px 0 0;
        }
        #rbtnAgent label
        {
            margin-left: 5px;
        }
    </style>
                            <script src='https://cdn.jsdelivr.net/npm/sweetalert2@11'></script>

    <script src="Assets/js/md5.js"></script>
    <script language="javascript" src="Assets/js/MyScript.js" type="text/javascript"></script>
    <!-- SweetAlert2 CSS & JS -->
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script language="javascript" type="text/javascript">
        function validate() {
            debugger;
            if (Trim(document.getElementById('<%=txtUserId.ClientID %>').value) == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter your User Name.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('<%=txtUserId.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtUserId.ClientID %>').value.length > 50) {
                Swal.fire({
                    icon: 'warning', 
                    title: 'Oops...',
                    text: 'User ID/Password can\'t be more than 50 characters.', 
                    confirmButtonColor: '#f2572b' 
                });
                document.getElementById('<%=txtUserId.ClientID %>').focus();
                return false;
            }
            if (Trim(document.getElementById('<%=txtPassword.ClientID %>').value) == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter your Password.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('<%=txtPassword.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtPassword.ClientID %>').value.length > 50) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'User ID/Password can\'t be more than 50 characters.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('<%=txtUserId.ClientID %>').focus();
                return false;
            }
            var pass;
            pass = document.getElementById('<%=txtPassword.ClientID %>').value;
            encpass = hex_md5(pass);
            var k = encpass + (document.getElementById('txtsalt').value);
            document.Form1.txtPassword.value = k;
        }
        function validateAgent() {
            if (Trim(document.getElementById('<%=txtAgentID.ClientID %>').value) == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter your User Name.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('<%=txtAgentID.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtAgentID.ClientID %>').value.length > 50) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Agent ID/Password can\'t be more than 50 characters.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('<%=txtAgentID.ClientID %>').focus();
                return false;
            }
            if (Trim(document.getElementById('<%=txtAgentPWD.ClientID %>').value) == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter your Password.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('<%=txtAgentPWD.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtAgentPWD.ClientID %>').value.length > 50) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'User ID/Password can\'t be more than 50 characters.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('<%=txtAgentID.ClientID %>').focus();
                return false;
            }
            var pass;
            pass = document.getElementById('<%=txtAgentPWD.ClientID %>').value;
            encpass = hex_md5(pass);
            var k = encpass + (document.getElementById('txtsalt').value);
            document.Form1.txtAgentPWD.value = k;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function isEmail(s) {
            if (s.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1) {
                return true;
            }
            else {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Invalid E-mail ID',
                    confirmButtonColor: '#f2572b'
                });
                return false;
            }
        }
        function validation() {
            if (document.getElementById('<%= txtmail.ClientID %>').value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Enter your Email- ID or Mobile No',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('<%= txtmail.ClientID %>').focus();
                return false;
            }
            else {
                if (isNaN(document.getElementById('<%= txtmail.ClientID %>').value) == true) {
                    if (!isEmail(Trim(document.getElementById('<%= txtmail.ClientID %>').value))) {
                        document.getElementById('<%= txtmail.ClientID %>').value = "";
                        document.getElementById('<%= txtmail.ClientID %>').focus();
                        return false;
                    }
                    else {
                        document.getElementById('<%= isemail.ClientID %>').value = "Y";
                    }
                }
                else {
                    var a = document.getElementById('<%= txtmail.ClientID %>').value;
                    if ((a.length < 10) | (a.length > 11)) {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Oops...',
                            text: 'Invalid Mobile No.',
                            confirmButtonColor: '#f2572b'
                        });
                        document.getElementById('<%= txtmail.ClientID %>').value = "";
                        document.getElementById('<%= txtmail.ClientID %>').focus();
                        return false;
                    }
                    else {
                        document.getElementById('<%= isemail.ClientID %>').value = "N";
                    }

                }
            }
            return true;
        }
        function ClearCustForgotPwd() {
            document.getElementById('<%= txtmail.ClientID %>').value = "";
            return false;
        }
        function Agentvalidation() {
            if (document.getElementById('<%= txtAgentmail.ClientID %>').value == "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Enter your Email-ID.',
                    confirmButtonColor: '#f2572b'
                });
                document.getElementById('<%= txtAgentmail.ClientID %>').focus();
                return false;
            }
            else {
                if (isNaN(document.getElementById('<%= txtAgentmail.ClientID %>').value) == true) {
                    if (!isEmail(Trim(document.getElementById('<%= txtAgentmail.ClientID %>').value))) {
                        document.getElementById('<%= txtAgentmail.ClientID %>').value = "";
                        document.getElementById('<%= txtAgentmail.ClientID %>').focus();
                        return false;
                    }
                    else {
                        document.getElementById('<%= isemail.ClientID %>').value = "Y";
                    }
                }
                else {
                    document.getElementById('<%= isemail.ClientID %>').value = "N";

                }
            }
            return true;
        }
        function ClearAgentForgotPwd() {
            document.getElementById('<%= txtAgentmail.ClientID %>').value = "";
            return false;
        }
        function fnMd5(saltval) {
            encpass = hex_md5(saltval);
            document.getElementById('tmpEnValue').value = encpass;
            return true;
        }
    </script>
    <!-- Google Tag Manager -->
    <script>
        (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({ 'gtm.start':
        new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
        j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
        'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-T9VTF6H');

    </script>
    <script type="text/javascript">
        var $zoho = $zoho || {}; $zoho.salesiq = $zoho.salesiq || { widgetcode: "f9285012553db7ccdec3cf907b30482c1f0e0a2bd9e18f0f2b52a1810adb9374cd30ce7a28be5ad051877c21011ab9a5", values: {}, ready: function () { } }; var d = document; s = d.createElement("script"); s.type = "text/javascript"; s.id = "zsiqscript"; s.defer = true; s.src = "https://salesiq.zoho.com/widget"; t = d.getElementsByTagName("script")[0]; t.parentNode.insertBefore(s, t); d.write("<div id='zsiqwidget'></div>");
    </script>
    <script src="https://cdn.pagesense.io/js/southerntravels/95bf3c0ba74f44f9baed4ddf90896ba3.js"></script>
</head>
<body>
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-T9VTF6H" height="0"
            width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->
    <form id="Form1" runat="server" defaultbutton="btnLogin">
    <input type="hidden" id="tmpEnValue" runat="server" />
    <input type="hidden" id="isemail" runat="server" />
    <input type="hidden" value='<%=ViewState["salt"]%>' id="txtsalt" />
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-login.jpg)">

   <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server"   />
   
</header>
    <section class="innersection2">
  <div class="container">
   
    <div class="formwrap innerforms innerformssmall">
    
    
    <div class="row">
    <%if (Convert.ToString(Request.QueryString["Type"]) == "A")
      { %>
        <div class="col-md-12">
        	<h2 class="title"><span>Agent</span> Login</h2>
            <asp:RadioButtonList ID="rbtnAgent" runat="server" RepeatColumns="2" Enabled="false">
            <asp:ListItem Selected ="True" Text="Agent Login" Value="1"></asp:ListItem>
            <asp:ListItem  Text="Work From Home" Value="2"></asp:ListItem>
            </asp:RadioButtonList>
            <div class="mrgnbtminput">
             <div class="inner-addon left-addon">
                <i class="glyphicon glyphicon-user"></i>
                <input name="txtAgentID" type="text" id="txtAgentID"  class="form-control" placeholder="Agent ID"
                                                runat="server" maxlength="50" />
       <%-- <input type="text" class="form-control" placeholder="Agent ID">--%></div>
        </div>
            <div class="rowgap">
            <div class="inner-addon left-addon">
                <i class="glyphicon glyphicon-lock"></i>
                 <input name="txtAgentPWD" type="password" id="txtAgentPWD"  class="form-control" placeholder="Password"
                                                runat="server" maxlength="50" />
        <%--<input type="text" class="form-control" placeholder="Password">--%></div>
        </div>
              <div class="mrgnbtminput">
            
            <div class="row">
            <div class="col-md-4"><asp:Button ID="btnAgentLogin"  runat="server" Text="Login" 
                                                CssClass="commonbtn" onclick="btnAgentLogin_Click" /></div>
            <div class="col-md-8 text-right">
            	  <p class="mrgnbtmno"><a href="#" data-toggle="modal" data-target="#forgotModal">Forgot Password?</a></p>
            <p><asp:LinkButton runat="server" ID="LinkButton1" PostBackUrl="AgentRegistrationEnq.aspx">New Agent Registration</asp:LinkButton></p>
            </div>
            </div>
            
            	
            </div>
            
            
        </div>
        <%}
      else if (Convert.ToString(Request.QueryString["Type"]) == "U")
      { %>
        <div class="col-md-12">
        	<h2 class="title"><span>Customer</span> Login</h2>
            <asp:RadioButtonList ID="rbtnCustomer" runat="server" RepeatColumns="2" Enabled="false" >
            <asp:ListItem Selected ="True" Text="Customer Login" Value="1"></asp:ListItem>
            <asp:ListItem  Text="Work From Home" Value="2"></asp:ListItem>
            </asp:RadioButtonList>
            <div class="mrgnbtminput">
             <div class="inner-addon left-addon">
                <i class="glyphicon glyphicon-user"></i>
                <input name="txtUserId" type="text" id="txtUserId" class="form-control" placeholder="Customer ID"
                                                runat="server" maxlength="50" />
        <%--<input type="text" class="form-control" placeholder="Customer ID"></div>--%>
        </div>
            <div class="rowgap">
            <div class="inner-addon left-addon">
                <i class="glyphicon glyphicon-lock"></i>
     
        <input name="txtPassword" type="password" id="txtPassword" class="form-control" placeholder="Password"
                                                runat="server" maxlength="50" />
        </div>
        
        </div>
            
              <div class="mrgnbtminput">
            
            <div class="row">
            <div class="col-md-4"><asp:Button ID="btnLogin" CssClass= "commonbtn" Text="Login" runat="server" 
                     onclick="btnLogin_Click" /></div>
            <div class="col-md-8 text-right">
            	  <p class="mrgnbtmno"><a href="#" data-toggle="modal" data-target="#forgotModal2">Forgot Password?</a></p>
            <p><asp:LinkButton runat="server" ID="lnkNewCustomer" PostBackUrl="Customerregistration.aspx">New Customer Registration</asp:LinkButton></p>
            </div>
            </div>
            
            	
            </div>
           
            
        </div>
        
                
               
    </div>
     <%} %>
    </div>
    
   
  </div>
  </div>
   
</section>
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- forgot password popup Agent-->
    <div class="modal fade" id="forgotModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h3 class="title">
                        Forgot <span>Password ?</span></h3>
                </div>
                <div class="modal-body">
                    <div class="formwrap">
                        <div class="row">
                            <div class="col-md-12">
                                <label>
                                    Email ID*</label>
                                <asp:TextBox ID="txtAgentmail" runat="server" class="inp" Style="width: 292px;" MaxLength="48"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--  <input type="submit" class="commonbtn" value="Submit">--%>
                    <asp:Button runat="server" ID="btnAgent" CssClass="commonbtn" OnClientClick="return Agentvalidation();"
                        Text="Submit" OnClick="btnAgent_Click" />
                    &nbsp;&nbsp;
                    <input type="submit" class="commonbtn" value="Reset" onclick="ClearAgentForgotPwd();" />
                </div>
            </div>
        </div>
    </div>
    <!-- end forgot password popup -->
    <!-- forgot password popup Customer-->
    <div class="modal fade" id="forgotModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h3 class="title">
                        Forgot <span>Password ?</span></h3>
                </div>
                <div class="modal-body">
                    <div class="formwrap">
                        <div class="row">
                            <div class="col-md-12">
                                <label>
                                    E-Mailid/ 10 Digit Mobile No*</label>
                                <asp:TextBox runat="server" ID="txtmail" CssClass="form-control" MaxLength="48"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="imgbtnSendRequest" CssClass="commonbtn" Text="Submit"
                        OnClientClick="return validation();" OnClick="imgbtnSendRequest_Click" />&nbsp;&nbsp;
                    <input type="submit" class="commonbtn" value="Reset" onclick="ClearCustForgotPwd();" />
                </div>
            </div>
        </div>
    </div>
    <!-- end forgot password popup -->
    </form>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-4994177-1', 'auto');
        ga('require', 'displayfeatures');
        ga('send', 'pageview');
 
    </script>
</body>
</html>
