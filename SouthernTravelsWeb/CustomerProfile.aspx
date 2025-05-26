<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="SouthernTravelsWeb.CustomerProfile" %>


<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcCustomerLeft.ascx" TagPrefix="uc1" TagName="leftuc"  %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Southern India Travel,South India Travel Packages,Travel Packages to South India
    </title>
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <meta content="Southern India Travel - South India Travel guides offering southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package."
        name="Description" />
    <meta content="southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package, south india beaches travel packages, south india holiday travel packages, holiday travel package to south india, southern india package travel, south india tourism, tourism in south india, holidays travel in southern india, kerala backwater travel packages in india, north india tour packages, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours, southern travels india, southerntravelsindia, Sirez"
        name="Keywords" />
    <meta content="index,follow" name="robots" />
    <meta content="Designed  www.Sirez.com" name="Author" />
    <meta content="MSHTML 6.00.2900.2180" name="GENERATOR" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientscript" content="Javascript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />

    <script language="javascript" src="Assets/js/md5.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function OnShow() {
            if (document.getElementById('chkChangePwd').checked == true) {
                document.getElementById("tblPWS").style.display = "block";

            }
            else {
                document.getElementById("tblPWS").style.display = "none";
            }

        }
        function validatePwd() {
            var invalid = " ";
            var minLength = 6;

            if (document.form1.txtNewPassword.value.length < minLength) {
                alert('Your password must be at least ' + minLength + ' characters long. Try again.');
                return false;
            }
            if (document.form1.txtNewPassword.value.indexOf(invalid) > -1) {
                alert("Sorry, spaces are not allowed.");
                return false;
            }
        }
        function CheckMail(str) {
            if (str.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1) {
                return true;
            }
            else {
                alert("Invalid E-mail ID");
                return false;
            }
        }
        function validate() {
        
            if (Trim(document.form1.txtFname.value) == "") {
                alert("Please enter First Name");
                document.form1.txtFname.value = "";
                document.form1.txtFname.focus();
                return false;
            }
            if (Trim(document.form1.txtLastName.value) == "") {
                alert("Please enter Last Name");
                document.form1.txtLastName.value = "";
                document.form1.txtLastName.focus();
                return false;
            }
            if (Trim(document.form1.txtMobile.value) != "") {
                if (validateOnlyNumber1(Trim(document.form1.txtMobile.value)) == false) {
                    alert("Mobile no. should have numeric value only.");
                    document.form1.txtMobile.value = "";
                    document.form1.txtMobile.focus();
                    return false;
                }
                else {
                    var a = document.form1.txtMobile.value;
                    if ((a.length < 10) | (a.length > 11)) {
                        alert("Invalid Mobile No")
                        document.form1.txtMobile.value = "";
                        document.form1.txtMobile.focus();
                        return false;
                    }
                }
            }
            else {
                alert("Please Enter Mobile No.");
                document.form1.txtMobile.value = "";
                document.form1.txtMobile.focus();
                return false;
            }
            if (Trim(document.form1.txtAlternateNo.value) != "") {
                if (validateOnlyNumber1(Trim(document.form1.txtAlternateNo.value)) == false) {
                    alert("Alternate Mobile no. should have numeric value only.");
                    document.form1.txtAlternateNo.value = "";
                    document.form1.txtAlternateNo.focus();
                    return false;
                }
                else {
                    var a = document.form1.txtAlternateNo.value;
                    if ((a.length < 10) | (a.length > 11)) {
                        alert("Invalid Alternate Mobile No")
                        document.form1.txtAlternateNo.value = "";
                        document.form1.txtAlternateNo.focus();
                        return false;
                    }
                }
            }
            if (Trim(document.form1.txtEmail.value) != "") {
                if (CheckMail(document.form1.txtEmail.value) == false) {
                    document.form1.txtEmail.value = "";
                    document.form1.txtEmail.focus();
                    return false;
                }
            }
            else {
                alert("Please Enter Email ID")
                document.form1.txtEmail.value = "";
                document.form1.txtEmail.focus();
                return false;
            }

            if (Trim(document.form1.txtAddress1.value) == "") {
                alert("Please enter the Address1");
                document.form1.txtAddress1.value = "";
                document.form1.txtAddress1.focus();
                return false;
            }
            if (Trim(document.form1.txtCity.value) == "") {
                alert("Please enter the City");
                document.form1.txtCity.value = "";
                document.form1.txtCity.focus();
                return false;
            }
            if (Trim(document.form1.ddlState.value) == "") {
                alert("Please select state");
                document.form1.ddlState.value = "";
                document.form1.ddlState.focus();
                return false;
            }
            if (Trim(document.form1.txtCountry.value) == "") {
                alert("Please enter the Country");
                document.form1.txtCountry.value = "";
                document.form1.txtCountry.focus();
                return false;
            }

            if (document.getElementById('chkChangePwd').checked == true) {
                if (Trim(document.form1.txtOldPassword.value) == "") {
                    alert("Please Enter the old password");
                    document.form1.txtOldPassword.focus();
                    return false;
                }
                if (Trim(document.form1.txtNewPassword.value) == "") {
                    alert("Please enter the new password");
                    document.form1.txtNewPassword.value = "";
                    document.form1.txtNewPassword.focus();
                    return false;
                }
                if (validatePwd() == false) {
                    document.getElementById("txtNewPassword").value = "";
                    document.getElementById("txtNewPassword").focus();
                    return false;
                }
                if (Trim(document.form1.txtRetypePassword.value) == "") {
                    alert("Please Re-enter Password.");
                    document.form1.txtRetypePassword.value = "";
                    document.form1.txtRetypePassword.focus();
                    return false;
                }
                if (Trim(document.form1.txtNewPassword.value) != Trim(document.form1.txtRetypePassword.value)) {
                    alert("New Password and Re-enter Password mismatch.");
                    document.form1.txtNewPassword.value = "";
                    document.form1.txtRetypePassword.value = "";
                    document.form1.txtNewPassword.focus();
                    return false;
                }
                var pass;
                pass = document.getElementById("txtOldPassword").value;
                encpass = hex_md5(pass);
                document.form1.txtOldPassword.value = encpass;

                var pass;
                pass = document.getElementById("txtNewPassword").value;
                encpass = hex_md5(pass);
                document.form1.txtNewPassword.value = encpass;

                var pass;
                pass = document.getElementById("txtRetypePassword").value;
                encpass = hex_md5(pass);
                document.form1.txtRetypePassword.value = encpass;

                return true;
            }
            else {
                return true;
            }
        }
        function chkNumeric(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function CheckOnlyCharacter(evt) {
            var kk
            kk = (evt.which) ? evt.which : event.keyCode
            if ((kk >= 65 && kk <= 90) || (kk >= 97 && kk <= 122) || kk == 32 || kk == 190 || kk == 8 || kk == 9 || kk == 127 || kk == 16 || kk == 20 || kk == 46) {
                return true;
            }
            alert("Please enter characters only.");
            return false;
        }
        function CheckOnlyCharacteraddress(evt) {
            var kk
            //|| kk==191 || kk==188 || kk==190
            kk = (evt.which) ? evt.which : event.keyCode
            if ((kk >= 65 && kk <= 90) || (kk >= 97 && kk <= 122) || (kk >= 48 && kk <= 57) || kk == 32 || kk == 8 || kk == 9 || kk == 127 || kk == 20 || kk == 46) {
                return true;
            }
            alert("Please enter characters only.");
            return false;
        }

        
    </script>

</head>
<body >
    <form id="form1" runat="server">
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-clear-balance.jpg)">
 
    
    <UCHeader:UCHeaderEndUser ID="UCHeader" runat="server"   fldMainSection="CUST_Login"/>
    
 
</header>
    <section class="innersection2">
  <div class="container">
  
  <div id="fixedtabsection">
    <div class="row subheadrow">
      <div class="col-md-12">
        <h1 class="title">
        <span>My</span> Profile
        </h1>
      </div>
       
    </div>
  
     <uc1:leftuc ID="leftuc" runat="server" />
    </div>
  
  
    <div class="row tabspace">
      <div class="col-md-12">
        <div class="tab-content tab-content-inner">
          
          <!-- my profile -->
          <div class="tab-pane fade in active" id="tab_profile">
          	
            <div class="formwrap">
           
            	<div class="row mrgnbtminput">
                	<div class="col-md-2">
                	
                    	<%--<select class="form-control">
                        <option>Title</option><option>Mr.</option><option>Ms.</option>
                        </select>--%>
                        <asp:DropDownList ID="select" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Mr." Value="Mr"></asp:ListItem>
                                                        <asp:ListItem Text="Mrs." Value="Mrs"></asp:ListItem>
                                                        <asp:ListItem Text="Miss." Value="Miss"></asp:ListItem>
                                                        <asp:ListItem Text="Dr." Value="Dr"></asp:ListItem>
                                                        <asp:ListItem Text="Prof." Value="Prof"></asp:ListItem>
                                                    </asp:DropDownList>
                    </div>
                    
                    <div class="col-md-5">
                    	<%--<input type="text" class="form-control" placeholder="First Name*">--%>
                    	 <input name="txtFname" type="text" id="txtFname" maxlength="50" size="25" class="form-control" placeholder="First Name*"
                         runat="server" onkeypress="return CheckOnlyCharacter(event);" tabindex="2" oncopy="return false"
                         ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off" />
                    </div>
                    
                    <div class="col-md-5">
                    	<%--<input type="text" class="form-control" placeholder="First Name*">--%>
                    	<input name="txtLastName" type="text" id="txtLastName" maxlength="50" class="form-control" placeholder="LastName*"
                        runat="server" size="25" onkeypress="return CheckOnlyCharacter(event);" tabindex="3"
                        oncopy="return false" ondrag="return false" ondrop="return false" onpaste="return false"
                        autocomplete="off" />
                    </div>
                    
                </div>
                
                <div class="row mrgnbtminput">
                	<div class="col-md-4">
                    	<%--<input type="text" class="form-control" placeholder="Mobile Number*">--%>
                    	<input name="txtMobile" type="text" id="txtMobile" maxlength="15" class="form-control" runat="server" placeholder="Mobile Number*"
                        onkeypress="return chkNumeric(event);" tabindex="4" oncopy="return false" ondrag="return false"
                        ondrop="return false" onpaste="return false" autocomplete="off" />
                    </div>
                    
                    <div class="col-md-4">
                    	<%--<input type="text" class="form-control" placeholder="Alternate Number">--%>
                    	 <input name="txtAlternateNo" type="text" id="txtAlternateNo" maxlength="15" class="form-control" placeholder="Alternate Number"
                         runat="server" onkeypress="return chkNumeric(event);" tabindex="5" oncopy="return false"
                         ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off" />
                    </div>
                    
                    <div class="col-md-4">
                    	<%--<input type="text" class="form-control" placeholder="E-mail ID*">--%>
                    	<input name="txtEmail" type="text" id="txtEmail" maxlength="150" class="form-control" runat="server" placeholder="E-mail ID*"
                        tabindex="6" oncopy="return false" ondrag="return false" ondrop="return false"
                        onpaste="return false" autocomplete="off" />
                    </div>
                    
                </div>
                
                  <div class="row mrgnbtminput">
                	<div class="col-md-6">
                    	<%--<input type="text" class="form-control" placeholder="Address1*">--%>
                    	 <input name="txtAddress1" type="text" class="form-control" id="txtAddress1" maxlength="150" placeholder="Address1*"
                         runat="server" onkeypress="return CheckOnlyCharacteraddress(event);" tabindex="7"
                         oncopy="return false" ondrag="return false" ondrop="return false" onpaste="return false"
                         autocomplete="off" />
                    </div>
                    
                    <div class="col-md-6">
                    	<%--<input type="text" class="form-control" placeholder="Address2">--%>
                    	<input name="txtAddress2" type="text" id="txtAddress2" maxlength="150" class="form-control" placeholder="Address2"
                        runat="server" onkeypress="return CheckOnlyCharacteraddress(event);" tabindex="8"
                        oncopy="return false" ondrag="return false" ondrop="return false" onpaste="return false"
                        autocomplete="off" />
                    </div>
                    
                    
                    
                </div>
                
                  <div class="row mrgnbtminput">
                	<div class="col-md-3">
                    	<%--<input type="text" class="form-control" placeholder="City*">--%>
                    	<input name="txtCity" type="text" id="txtCity" maxlength="50" runat="server" class="form-control" placeholder="City*"
                        onkeypress="return CheckOnlyCharacter(event);" tabindex="9" oncopy="return false"
                        ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off" />
                    </div>
                    
                    <div class="col-md-3">
                    	<%--<select class="form-control">
                        <option>State</option>
                        </select>--%>
                        <asp:DropDownList ID="ddlState" runat="server" class="form-control" Style="width: 135px;">
                                                        </asp:DropDownList>
                    </div>
                    
                    <div class="col-md-3">
                    	<%--<input type="text" class="form-control" placeholder="Country*">--%>
                    	<input name="txtCountry" type="text" id="txtCountry" maxlength="50" class="form-control" placeholder="Country*"
                       runat="server" onkeypress="return CheckOnlyCharacter(event);" tabindex="11" oncopy="return false"
                        ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off" />
                    </div>
                    
                    <div class="col-md-3">
                    	<%--<input type="text" class="form-control" placeholder="Pincode">--%>
                    	 <input name="txtPinCode" type="text" id="txtPinCode" maxlength="10" class="form-control" placeholder="Pincode"
                        runat="server" onkeypress="return chkNumeric(event);" tabindex="12" oncopy="return false"
                        ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off" />
                    </div>
                    
                    
                </div>
                
                <div class="row mrgnbtminput">
                	<div class="col-md-12">
                    	<p class="mrgnbtmno"><label> <input type="checkbox" name="chkPromotions" id="chkPromotions" runat="Server" tabindex="17"
                                                        class="CB" /> I would like to be kept infromed of special promotions and offers by Southern Travels</label></p>
                        <p><label> <input type="checkbox" name="chkChangePwd" id="chkChangePwd" runat="server" tabindex="13"
                                                            onclick="OnShow ()" onchange="OnShow ()" class="CB" /> Change Password </label></p>
                        <div id="tblPWS" style="display: none;">
                         <div class="row">
                         <div class="col-md-3">
                    	<%--<input type="text" class="form-control" placeholder="Pincode">--%>
                    	 <input name="txtOldPassword" type="password" id="txtOldPassword" class="form-control" maxlength="50" placeholder="Old Password"
                         runat="server" tabindex="14" oncopy="return false" ondrag="return false" ondrop="return false"
                         onpaste="return false" autocomplete="off" />
                        </div></div>
                         <div class="row">
                        <div class="col-md-3">
                    	<%--<input type="text" class="form-control" placeholder="Pincode">--%>
                    	  <input name="txtNewPassword" type="password" id="txtNewPassword" class="form-control" maxlength="50"  placeholder="New Password"
                          runat="server" tabindex="15" oncopy="return false" ondrag="return false" ondrop="return false"
                          onpaste="return false" autocomplete="off" />
                        </div>
                        <div class="col-md-3">
                    	<%--<input type="text" class="form-control" placeholder="Pincode">--%>
                    	 <input name="txtRetypePassword" type="password" id="txtRetypePassword" class="form-control" placeholder ="Confirm Password"
                         maxlength="50" runat="server" tabindex="16" oncopy="return false" ondrag="return false"
                         ondrop="return false" onpaste="return false" autocomplete="off" />
                        </div>
                        </div>
                        
                        </div>
                    </div>
                </div>
                
                <div class="row">
                	<div class="col-md-12">
                    <p class="btnwrap"><%--<input type="submit" value="Submit" class="commonbtn">--%>
                    
                    <asp:Button ID="btnsubmit" runat="server"  CssClass="commonbtn" Text="submit" 
                            TabIndex="18" onclick="btnsubmit_Click" />
                    </p>
                    </div>
                    </div>
                
            </div>
            
          </div>
          
          
         
          
       
          
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
    <script src="Assets/js/jquery-ui.js"></script>
    <script src="Assets/js/jquery-2.2.0.min.js"></script>
    <script src="Assets/js/bootstrap-select.min.js"></script>
    <script type="text/javascript">

        var $123 = jQuery.noConflict();
        $123('select.form-control').selectpicker({
            style: 'btn-info',
            size: 4
        });
        $123(function() {

            $123('.linkqck').click(function(e) {
                $123(".qckenqwrap").show().animate({
                    right: "0px"

                }, 300, function() {

                });



                e.preventDefault();
            });


            $123('.closebtn a').click(function(e) {

                $123(".qckenqwrap").animate({
                    right: "-300px"


                }, 300, function() {
                    // Animation complete.
                    //$('.slider-arrow img').css('cursor','pointer');
                });


                e.preventDefault();
            });


            $123('.placescoveredtbl .pcwrap ul li a').click(function(e) {
                $123('.nav-tabs li').removeClass('active');
                $123('a[href="#tab_tourinfo"]').parent().addClass('active');
                $123('#tab_dateprice').removeClass('active in');
                $123('#tab_tourinfo').addClass('active in');
                //$('a').attr().parent().addClass('active');
                e.preventDefault();
            });



        });
        $123(function() {
            var stickyRibbonTop = $('.stickymenu').offset().top;

            $123(window).scroll(function() {
                if ($123(window).scrollTop() > stickyRibbonTop) {
                    $123('.stickymenu').addClass('sticky'); //css({position: 'fixed', top: '0px'});
                } else {
                    $123('.stickymenu').removeClass('sticky'); //css({position: 'static', top: '0px'});
                }
            });
        });
</script>
    <script>
    (function(i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function() {
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

