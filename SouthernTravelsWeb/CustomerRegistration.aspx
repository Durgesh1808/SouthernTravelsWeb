<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="SouthernTravelsWeb.CustomerRegistration" %>

<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Summer Holidays Packages | Family Package Holidays | Group Holiday Package | 
        Indian Holiday Package</title>
        <link rel="shortcut icon" href="Assets/images/favicon.ico" />
          <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <meta content="Southern Travels India – “offer holiday packages, summer holidays packages, cheap holiday packages india, family holiday package, family package holiday, international holidays packages, best holidays packages, travel holidays, cheapest holidays"
        name="Description" />
    <meta content="holiday package offers, winter holiday package, cheapest holiday package, holiday package deal, summer holidays packages, holiday package to Egypt, beach holiday package, cheap holiday packages india, cheap holiday packages in india, travel holidays, holiday package, holidays package, cheap holidays packages, package holiday, holidays packages india, cheap package holidays, cheapest package holidays, holidays packages, cheap holiday packages, family package holidays, international holidays packages, indian holidays packages, holiday packages to sri lanka, cheap holiday packages to malaysia, best holiday package, indian holiday package, group holiday package, book holiday package, international holiday package, africa holiday package, winter holiday packages, asia holiday package, cheapest holiday packages, egypt holiday packages, family holiday package"
        name="Keywords" />
    <meta content="index,follow" name="robots" />
    <meta content="Designed  www.Sirez.com" name="Author" />
    <meta content="MSHTML 6.00.2900.2180" name="GENERATOR" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientscript" content="Javascript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <script src="Assets/js/md5.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <script language="javascript" src="Assets/js/MyScript.js" type="text/javascript"></script>

        <script language="javascript" type="text/javascript">
            function validatePwd() {
                
                    var invalid = " "; 
                    var minLength = 6;                 
                    
                    if (document.getElementById('<%= txtNewPassword.ClientID%>').value.length < minLength) 
                    {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Oops...',
                            text: 'Your password must be at least ' + minLength + ' characters long. Try again.',
                            confirmButtonColor: '#f2572b'
                        });
                        return false;
                    }           
                    if (document.getElementById('<%= txtNewPassword.ClientID%>').value.indexOf(invalid) > -1)
                    {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Oops...',
                            text: 'Sorry, spaces are not allowed.',
                            confirmButtonColor: '#f2572b'
                        });
                        return false;
                    }
                }   
    	
			
			 function CheckMail(str) 
		    {
			    if (str.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
                {
                    return true;
                }
                else
                {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Invalid E-mail ID.',
                        confirmButtonColor: '#f2572b'
                    });
                    return false;
                }			
		    }
    			
			
			function validatesubmit()
			{		
				
			    if(document.form1.select.value=="Title")
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please select title.',
                        confirmButtonColor: '#f2572b'
                    });
					document.form1.select.focus();
					return false;
				}
			    if(document.getElementById('<%= txtFname.ClientID%>').value=="")
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please enter First Name.',
                        confirmButtonColor: '#f2572b'
                    });
					document.getElementById('<%= txtFname.ClientID%>').value="";
					document.getElementById('<%= txtFname.ClientID%>').focus();
					return false;
				}
				if(document.getElementById('<%= txtLastName.ClientID%>').value=="")
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please enter Last Name.',
                        confirmButtonColor: '#f2572b'
                    });
					document.getElementById('<%= txtLastName.ClientID%>').value="";
					document.getElementById('<%= txtLastName.ClientID%>').focus();
					return false;
				}
				if (document.getElementById('<%= txtMobile.ClientID%>').value!= "")
		        {
			        if (validateOnlyNumber1(Trim(document.getElementById('<%= txtMobile.ClientID%>').value)) == false)
			        {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Oops...',
                            text: 'Mobile no. should have numeric value only.',
                            confirmButtonColor: '#f2572b'
                        });
				        document.getElementById('<%= txtMobile.ClientID%>').value="";
				        document.getElementById('<%= txtMobile.ClientID%>').focus();				       
				        return false;
			        }
			        else
				    {								
			            var a=document.getElementById('<%= txtMobile.ClientID%>').value;
			            if((a.length<10)|(a.length>11))
			            {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Oops...',
                                text: 'Invalid Mobile No.',
                                confirmButtonColor: '#f2572b'
                            });
			                document.getElementById('<%= txtMobile.ClientID%>').value="";
				            document.getElementById('<%= txtMobile.ClientID%>').focus();
				            return false;
			            }
				    }    			    
		        } 
		        else
		        {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please Enter Mobile No.',
                        confirmButtonColor: '#f2572b'
                    });
			        document.getElementById('<%= txtMobile.ClientID%>').value="";
			        document.getElementById('<%= txtMobile.ClientID%>').focus();				       
			        return false;
		        }
		        if (document.getElementById('<%= txtAlternateNo.ClientID%>').value!= "")
		        {
			        if (validateOnlyNumber1(Trim(document.getElementById('<%= txtAlternateNo.ClientID%>').value)) == false)
			        {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Oops...',
                            text: 'Alternate Mobile no. should have numeric value only.',
                            confirmButtonColor: '#f2572b'
                        });
				        document.getElementById('<%= txtAlternateNo.ClientID%>').value="";
				        document.getElementById('<%= txtAlternateNo.ClientID%>').focus();				       
				        return false;
			        }
			        else
				    {								
			            var a=document.getElementById('<%= txtAlternateNo.ClientID%>').value;
			            if((a.length<10)|(a.length>11))
			            {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Oops...',
                                text: 'Invalid Alternate Mobile No',
                                confirmButtonColor: '#f2572b'
                            });
			                document.getElementById('<%= txtAlternateNo.ClientID%>').value="";
				            document.getElementById('<%= txtAlternateNo.ClientID%>').focus();
				            return false;
			            }
				    }    			    
		        } 
	            if (document.getElementById('<%= txtEmail.ClientID%>').value!= "" )
		        {
			        if (CheckMail(document.getElementById('<%= txtEmail.ClientID%>').value)== false)
			        {					   
				        document.getElementById('<%= txtEmail.ClientID%>').focus();					    
				        return false;
			        }
		        }
		        else
		        {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please Enter Email ID',
                        confirmButtonColor: '#f2572b'
                    });
	                    document.getElementById('<%= txtEmail.ClientID%>').value="";
		                document.getElementById('<%= txtEmail.ClientID%>').focus();
		                return false;
		        }
		        
			    if(document.getElementById('<%= txtAddress1.ClientID%>').value=="")
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please enter the Address1',
                        confirmButtonColor: '#f2572b'
                    });
					document.getElementById('<%= txtAddress1.ClientID%>').value="";
					document.getElementById('<%= txtAddress1.ClientID%>').focus();
					return false;
				}
				if(document.getElementById('<%= txtCity.ClientID%>').value=="")
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please enter the City',
                        confirmButtonColor: '#f2572b'
                    });
					document.getElementById('<%= txtCity.ClientID%>').value="";
					document.getElementById('<%= txtCity.ClientID%>').focus();
					return false;
				}
				if (document.getElementById('<%= ddlState.ClientID%>').value == "")
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please select state',
                        confirmButtonColor: '#f2572b'
                    });
					document.getElementById('<%= ddlState.ClientID%>').value = "";
					document.getElementById('<%= ddlState.ClientID%>').focus();
					return false;
				}
				if(document.getElementById('<%= txtCountry.ClientID%>').value=="")
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please enter the Country',
                        confirmButtonColor: '#f2572b'
                    });
					document.getElementById('<%= txtCountry.ClientID%>').value="";
					document.getElementById('<%= txtCountry.ClientID%>').focus();
					return false;
				}
				if(document.getElementById('<%= txtNewPassword.ClientID%>').value=="")
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please enter the password',
                        confirmButtonColor: '#f2572b'
                    });
					document.getElementById('<%= txtNewPassword.ClientID%>').value="";
					document.getElementById('<%= txtNewPassword.ClientID%>').focus();
					return false;
				}
				if(validatePwd()==false)
			    {
			        document.getElementById('<%= txtNewPassword.ClientID%>').value = "";
			        document.getElementById('<%= txtNewPassword.ClientID%>').focus();
				    return false;
				}
	
				if(Trim(document.getElementById('<%= txtRetypePassword.ClientID%>').value)=="")
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Please enter the password',
                        confirmButtonColor: '#f2572b'
                    });
					document.getElementById('<%= txtRetypePassword.ClientID%>').value="";
					document.getElementById('<%= txtRetypePassword.ClientID%>').focus();
					return false;
				}
				
				if(Trim(document.getElementById('<%= txtNewPassword.ClientID%>').value)!=Trim(document.getElementById('<%= txtRetypePassword.ClientID%>').value))
				{
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Password and Re-enter Password mismatch.',
                        confirmButtonColor: '#f2572b'
                    });
						document.getElementById('<%= txtNewPassword.ClientID%>').value="";
					document.getElementById('<%= txtRetypePassword.ClientID%>').value="";
					document.getElementById('<%= txtNewPassword.ClientID%>').focus();
					return false;
				}				 
		        var pass;
		        pass=document.getElementById('<%= txtNewPassword.ClientID%>').value;
		        document.getElementById('<%= hdnpwd.ClientID%>').value = pass;
		        encpass=hex_md5(pass);		       
		        document.getElementById('<%= txtNewPassword.ClientID%>').value= encpass ;
		        
		        var pass;
		        pass=document.getElementById('<%=txtRetypePassword.ClientID%>').value;
		        encpass=hex_md5(pass);		       
		        document.getElementById('<%= txtRetypePassword.ClientID%>').value= encpass;	     				
				return true;
				
			}
			function chkNumeric(evt)
	        {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;
               return true;
	        } 
	        function CheckOnlyCharacter(evt)
	        {
			        var kk
			        kk=(evt.which) ? evt.which : event.keyCode		
			        if((kk>=65 && kk<=90)||(kk>=97 && kk<=122)|| kk==32 || kk==190 || kk==8 || kk==9 || kk==127 || kk==16 || kk==20|| kk==46)
			         {
				        return true;
			         }
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Please enter characters only.',
                    confirmButtonColor: '#f2572b'
                });
				        return false;
            }
             function CheckOnlyCharacteraddress(evt)
	        {
			        var kk
			        //|| kk==191 || kk==188 || kk==190
			        kk=(evt.which) ? evt.which : event.keyCode
			        if((kk>=65 && kk<=90)||(kk>=97 && kk<=122)||(kk>=48 && kk<=57) || kk==32 || kk==8 || kk==9 || kk==127 || kk==20|| kk==46 || kk==44 || kk == 45)
			         {
				        return true;
			         }
                     Swal.fire({
                         icon: 'warning',
                         title: 'Oops...',
                         text: 'Please enter characters only.',
                         confirmButtonColor: '#f2572b'
                     });
                 return false;
            }        
            
            
    </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnsubmit">
    <!-- Header Start -->
    
<header class="posrel innerheader" style="background-image: url((Assets/images/banner-enquiry.jpg)">
  <div class="herobanner">
    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server" />
    </div></header>
  
    <!-- Header End -->
    <!-- Main Content Start -->
   <section class="innersection2">
  <div class="container">
   
    <div class="formwrap innerforms">
    
    <div class="row">
    <div class="col-md-12">
    	<h1 class="title text-center mrgntopno"><span>Customer</span> Registration</h1>
    </div>
    </div>
    
    <div class="row mrgnbtminput">
    
    
    <div class="col-md-2 paddingright0">
     <select name="select" class="form-control"  id="select" runat="server" tabindex="1">
       <option selected="selected">Title</option>
       <option>Mr.</option>
       <option>Mrs.</option>
       <option>Miss.</option>
       <option>Dr.</option>
       <option>Prof.</option>
        </select>
    	
    </div>  
    
    <div class="col-md-5 paddingright0">
    	<input name="txtFname" type="text" class="form-control" placeholder="First Name*" id="txtFname" size="25" runat="server"
         maxlength="35" onkeypress="return CheckOnlyCharacter(event);" tabindex="1" oncopy="return false"
          ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off" />
    </div>  
    
    <div class="col-md-5">
    	 <input name="txtLastName" type="text" class="form-control" placeholder="Last Name" id="txtLastName" onkeypress="return CheckOnlyCharacter(event);"
         runat="server" size="25" maxlength="35" tabindex="2" oncopy="return false" ondrag="return false"
          ondrop="return false" onpaste="return false" autocomplete="off" />
    </div>  
        
    </div>
    
      <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	<input name="txtAddress1" type="text"  class="form-control" placeholder="Address1*" id="txtAddress1" maxlength="150"
        runat="server" onkeypress="return CheckOnlyCharacteraddress(event);" tabindex="6"
        oncopy="return false" ondrag="return false" ondrop="return false" onpaste="return false"
        autocomplete="off" />
    </div>  
    
    <div class="col-md-6">
    	 <input name="txtAddress2" type="text" class="form-control" placeholder="Address2" maxlength="150" id="txtAddress2"
         onkeypress="return CheckOnlyCharacteraddress(event);" runat="server" tabindex="7"
         oncopy="return false" ondrag="return false" ondrop="return false" onpaste="return false"
         autocomplete="off" />
    </div>  
        
    </div>
    
    
      <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	 <input name="txtCity" type="text"  class="form-control" placeholder="City" id="txtCity" maxlength="50" onkeypress="return CheckOnlyCharacter(event);"
          runat="server" tabindex="8" oncopy="return false" ondrag="return false" ondrop="return false"
          onpaste="return false" autocomplete="off" />
    </div>  
    
    <div class="col-md-6">
     <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" ></asp:DropDownList>  
    	  
    </div>  
        
    </div>
    
    
      <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	<input name="txtCountry" type="text" class="form-control" placeholder="Country" id="txtCountry" maxlength="50"
        runat="server" onkeypress="return CheckOnlyCharacter(event);" tabindex="10" oncopy="return false"
        ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off" />
     
        
        
    </div>  
    
    <div class="col-md-6">
    	<input name="txtPinCode" type="text"  class="form-control" placeholder="Pincode" id="txtPinCode" maxlength="10"
        runat="server" onkeypress="return chkNumeric(event);" tabindex="11" oncopy="return false"
        ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off" />
        
    </div>  
        
    </div>
    
    
      <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    	<input name="txtMobile" type="text" class="form-control" placeholder="Mobile No*" id="txtMobile" maxlength="15" runat="server"
        onkeypress="return chkNumeric(event);" tabindex="3" oncopy="return false" ondrag="return false"
        ondrop="return false" onpaste="return false" autocomplete="off" />
    </div>  
    
    <div class="col-md-6">
    	<input name="txtAlternateNo" type="text" class="form-control" placeholder="Alternate No" id="txtAlternateNo" maxlength="15"
        runat="server" onkeypress="return chkNumeric(event);" tabindex="4" oncopy="return false"
        ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off" />
    </div>  
        
    </div>
    
      <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    <input name="txtEmail" type="text" class="form-control" placeholder="Email Id*" id="txtEmail" maxlength="150" runat="server"
    tabindex="5" oncopy="return false" ondrag="return false" ondrop="return false"
    onpaste="return false" autocomplete="off" />
    </div>  
    
    <div class="col-md-6">
    	<input name="txtNewPassword" type="password" class="form-control" placeholder="Choose Password*" id="txtNewPassword" runat="server"
        maxlength="50" tabindex="12" oncopy="return false" ondrag="return false" ondrop="return false"
        onpaste="return false" autocomplete="off" />
        <input id="hdnpwd" type="hidden" runat="server" />
    </div>  
       
    </div>
    
     <div class="row mrgnbtminput">
    	
    <div class="col-md-6">
    <input name="txtRetypePassword" type="password" class="form-control" placeholder="Re-type Password*" id="txtRetypePassword"
    runat="server" maxlength="50" tabindex="13" oncopy="return false" ondrag="return false"
     ondrop="return false" onpaste="return false" autocomplete="off" />
    </div>  
    
       
    </div>
    <div class="row">
    	
   <%-- <div class="col-md-6">
   	  
  
      <div class="g-recaptcha" runat="server" id="divrecaptcha" ></div>
      
    </div>  
    
    <div class="col-md-6">
            <asp:Label ID="MessageLabel" runat="server" CssClass="verdana11bk" ForeColor="red"></asp:Label>

    </div>--%>
     <div class="col-md-12">
                <ul class="row" style="list-style-type: none; padding-left: 0;">
                <li >
                    <div id="dvCaptchaF">
                    </div>
    
            
           
                        <div class="col-md-3">
                        <asp:TextBox ID="txtCaptcha" runat="server" ValidationGroup="FOO" autocomplete="off" Width="114px" placeholder="Enter Captcha"
                            AutoCompleteType="None" MaxLength="10" CssClass="form-control"></asp:TextBox>
                         </div>
                         <div class="col-md-2" style="margin-left: 49px;">
                          <img src="JpegImage.aspx?cache=1394701635527" id="captchImg" alt="captcha" width="110px" loading="lazy" />
                         </div>
                         <div class="col-md-2" style="margin-left: 53px;">
                          <img id="refresh_captcha" src="Assets/images/captcha_refresh.jpg" alt="captcha_refresh" style="height:28px; cursor:pointer;" loading="lazy"/>
                         </div>
        
                
                       <asp:RequiredFieldValidator ID="RequiredFieldtxtCaptcha" CssClass="errorMessage" ValidationGroup="FOO" ForeColor="Red"
                       runat="server" ControlToValidate="txtCaptcha" Display="Dynamic" ErrorMessage="Enter Captcha"></asp:RequiredFieldValidator>
            
            
                </li>
            </ul>
      </div>
    </div>
     <div class="row mrgnbtminput">
    	
    <div class="col-md-12">
    <label><input type="checkbox" name="chkPromotions" id="chkPromotions" runat="Server"
                                        tabindex="14"> I would like to be kept informed of special promotions and offers by Southern Travels</label>
    </div>  
    
       
    </div>
    
   
    <div class="row mrgnbtminput">
    	<div class="col-md-6">
        <asp:Button ID="btnsubmit" CssClass="commonbtn displayinline" runat="server" OnClick="btnsubmit_Click" TabIndex="15" Text="Submit" />
        </div>
    
    </div>
   
  </div>
  </div>
</section>
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooter" runat="server" />
    <!-- Footer Start -->
    </form>
</body>
<script>
    $('#refresh_captcha').click(function(e) {

        $('#imgCaptcha').attr('src', 'JpegImage.aspx?cache=' + new Date().getTime());
        e.preventDefault();
    });
    
    (function(i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function() {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-4994177-1', 'auto');
    ga('require', 'displayfeatures');
    ga('send', 'pageview');


    $('#refresh_captcha').click(function (e) {
            $('#captchImg').attr('src', 'JpegImage.aspx?cache=' + new Date().getTime());
        e.preventDefault();
    });
</script>
</html>

