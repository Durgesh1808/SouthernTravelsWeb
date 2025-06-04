<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcFooterEndUser.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcFooterEndUser" %>
<%@ Register Src="UCPaymentOptionNetBanking.ascx" TagName="UCPaymentOptionNetBanking"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<script src="/Assets/js/jquery-scrolltofixed.js" type="text/javascript"></script>--%>
<%--<script type="text/javascript" src="https://www.google.com/recaptcha/api.js?onload=onloadCallbackF&render=explicit"
     defer></script>--%>

    <style>
        
        body.formOpen:before {
        content: "";
        width: 100%;
        height: 100%;
        position: fixed;
        left: 0;
        top: 0;
        background: rgba(0, 0, 0, 0.75);
        z-index: 100;
    }
       
    .qckenqwrap.qe_open
    {
        right: auto; width: auto;  top: 35%;
        left: 50%; 
        transform: translateY(-50%);
        margin-left: -220px;
        }
        
         #DivHmPopup ul li
        {
            width: 100%;
            padding: 0 15px!important;
            margin-bottom: 10px;
        }
        .qckenqwrap .formwrap {max-width: 440px; padding: 30px 20px 15px; background-color: #f7f7f7;}
        .qckenqwrap .closebtn a
        {
            top: -25px;
            right: -15px;
            font-size: 24px;
        }
        .qckenqwrap .formwrap .form-control
        {
            height: 40px;
        }
         #DivHmPopup.qckenqwrap .formwrap .captchaRow [class^="col-"]
        {
         padding-left: 0;   
        }
        #DivHmPopup.qckenqwrap .heading 
        {
            padding: 0 15px;
        }
        
        #DivHmPopup .btnRow li
        {
            display: flex;
            padding: 0!important;
        }
        #DivHmPopup.qckenqwrap .formwrap .btn
        {
            width: 50%;
            padding: 7px 30px;
        }
        #DivHmPopup.qckenqwrap .formwrap #txtName {width: 100%!important;}
        @media (max-width: 768px)
        {
             #DivHmPopup.qckenqwrap.qe_open{top: 60px; left: 0; margin-left: 0;}
             #DivHmPopup.qckenqwrap .formwrap .captchaRow [class^="col-"]{ padding-right: 0; }
              #DivHmPopup ul li {margin-bottom: 5px;}
        } 
   #divSCPop {
    z-index: 1000; /* Still under swal */
}
.swal2-container {
    z-index: 9999 !important;
}

    </style>

<%--<script type="text/javascript">
    var onloadCallbackF = function() {
        //$("[id$=dvCaptcha]").children("iframe").css("width", "350px");
        grecaptcha.render('dvCaptchaF', {
            'sitekey': '<%=ReCaptcha_KeyFooter %>',
            'callback': function(response) {
                var url = '<%=baseurlFooter %>' + "CallCityFromBranch.aspx/VerifyCaptcha";
                //alert(url);
                $.ajax({
                    type: "POST",
                    url: url,
                    data: "{response: '" + response + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(r) {
                        var captchaResponse = jQuery.parseJSON(r.d);
                        if (captchaResponse.success) {
                            $("[id*=txtCaptchaF]").val(captchaResponse.success);
                            $("[id*=rfvCaptchaF]").hide();
                        } else {
                            $("[id*=txtCaptchaF]").val("");
                            $("[id*=rfvCaptchaF]").show();
                            var error = captchaResponse["error-codes"][0];
                            $("[id*=rfvCaptchaF]").html("RECaptcha error. " + error);
                        }
                    }
                });
            }
        });
    };
</script>--%>



<script type="text/javascript">
    let captchaLoaded = false;

    window.addEventListener('DOMContentLoaded', function () {
        const captchaInput = document.getElementById('txtCaptcha');

        if (captchaInput) {
            captchaInput.addEventListener('focus', function () {
                if (!captchaLoaded) {
                    const script = document.createElement('script');
                    script.src = 'https://www.google.com/recaptcha/api.js';
                    document.body.appendChild(script);
                    captchaLoaded = true;
                }
            });
        }
    });

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
    function Check_Length(my_Object) {
        var maxLen = 250;
        if (document.getElementById("<%=txtShortDescription.ClientID  %>").value.length >= maxLen) {
            // document.getElementById("<%=txtShortDescription.ClientID  %>").value = '';
            var msg = "Please enter maximum 250 characters allowed.";
            alert(msg);
            document.getElementById('<%=txtShortDescription.ClientID  %>').focus();
        }
    }
    function Valid() {
            let chk = true;

        // helper to show Swal and focus
        function showError(msg, clientId) {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                 confirmButtonColor: '#f2572b',
                text: msg,
            }).then(() => {
                document.getElementById(clientId).focus();
            });
            chk = false;
        }

        const nameId       = '<%= txtName.ClientID %>';
        const phoneId      = '<%= txtPhone.ClientID %>';
        const emailId      = '<%= txtEmail.ClientID %>';
        const departId     = '<%= txtDeparturedate.ClientID %>';
        const arrivalId    = '<%= txtArrivaldate.ClientID %>';
        const descId       = '<%= txtShortDescription.ClientID %>';
        const captchaId    = '<%= txtCaptcha.ClientID %>';

        if (document.getElementById(nameId).value.trim() === "") {
            showError("Please enter the name.", nameId);
            return false;
        }
        if (document.getElementById(phoneId).value.trim() === "") {
            showError("Please enter the phone.", phoneId);
            return false;
        }
        if (document.getElementById(emailId).value.trim() === "") {
            showError("Please enter the email.", emailId);
            return false;
        }
        if (document.getElementById(departId).value.trim() === "") {
            showError("Please enter the departure date.", departId);
            return false;
        }
        if (document.getElementById(arrivalId).value.trim() === "") {
            showError("Please enter the arrival date.", arrivalId);
            return false;
        }
        if (document.getElementById(descId).value.trim() === "") {
            showError("Please enter short description.", descId);
            return false;
        }
        if (document.getElementById(captchaId).value.trim() === "") {
            showError("Please enter captcha text.", captchaId);
            return false;
        }

//        var CaptchText = '<%=Session["CaptchaImageText"] %>';
//        
//        if (CaptchText != null || CaptchText != '') {
//            if (document.getElementById("<%=txtCaptcha.ClientID  %>").value.trim() != CaptchText.trim()) {
//                var msg = "Please enter Captcha Text";
//                alert(msg);
//                document.getElementById('<%=txtCaptcha.ClientID  %>').focus();
//                chk = false;
//                return false;
//            }
//        }
        
    

        //var ret = ValidateCaptch();
//        if ($("[id$=txtCaptchaF]").val() == "") {
//            var msg = "Captcha validation is required.";
//            alert(msg);
//            chk = false;
//            return false;
//        }

        if (chk) {
            document.getElementById('<%=btnSubmitDe.ClientID  %>').style.display = 'none';
        }
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

    //    function ValidateCaptch() {
    //        $.ajax({
    //            type: "POST",
    //            url: "UCFooterEndUser.ascx/VerifyCaptcha",
    //            data: "{response: '" + response + "'}",
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            success: function(r) {
    //                var captchaResponse = jQuery.parseJSON(r.d);
    //                if (captchaResponse.success) {
    //                    $("[id*=txtCaptcha]").val(captchaResponse.success);
    //                    $("[id*=rfvCaptcha]").hide();
    //                    return true;
    //                } else {
    //                    $("[id*=txtCaptcha]").val("");
    //                    $("[id*=rfvCaptcha]").show();
    //                    var error = captchaResponse["error-codes"][0];
    //                    $("[id*=rfvCaptcha]").html("RECaptcha error. " + error);
    //                    return true;
    //                }
    //            }
    //        });
    //        return true;
    //    }
</script>

<style>
    .ddate .ui-datepicker-trigger
    {
        right: 7px;
        top: 9px;
    }
    .adate .ui-datepicker-trigger
    {
        right: 21px;
        top: 9px;
    }
</style>

<script type="text/javascript">

    //function pageLoad(sender, args) {

    $(function() {
        var checkInDate = $('#<%=txtDeparturedate.ClientID  %>');
        var checkOutDate = $('#<%=txtArrivaldate.ClientID  %>');
        var dt = '';
        $("#<%=txtDeparturedate.ClientID  %>").datepicker({

            numberOfMonths: 1,
            showOn: "button", autoSize: true,
            buttonImage: "Assets/images/calendar.gif",
            buttonImageOnly: true, changeMonth: true, showButtonPanel: true,
            minDate: new Date(),
            closeText: 'Close',
            dateFormat: 'dd/mm/yy', buttonText: 'Choose a Date',
            onSelect: function(date) {

                dt = checkInDate.datepicker('getDate');
                var Tow = dt;
                Tow.setDate(dt.getDate() + 1); //get yesterday's date
                //alert(Tow);
                $('#<%=txtArrivaldate.ClientID  %>').datepicker('option', 'defaultDate', new Date(dt));
                $("#<%=txtArrivaldate.ClientID  %>").datepicker("option", "minDate", new Date(dt));

            },
            onClose: function clearEndDate(date, inst) {

                if (dt == '') {
                    checkOutDate.val('');
                }
                else {
                    var today = new Date(dt);
                    var dd = today.getDate();
                    var mm = today.getMonth() + 1; //January is 0!
                    var yyyy = today.getFullYear();
                    if (dd < 10) { dd = '0' + dd }
                    if (mm < 10) { mm = '0' + mm }

                    checkOutDate.val(dd + '/' + mm + '/' + yyyy);
                }
            }


        });


        $("#<%=txtArrivaldate.ClientID  %>").datepicker({
            numberOfMonths: 1,
            //  maxDate:"+4Y",
            buttonImage: "Assets/images/calendar.gif",
            buttonImageOnly: true, changeMonth: true, showButtonPanel: true,
            minDate: new Date(), dateFormat: 'dd/mm/yy', buttonText: 'Choose a Date',
            showOn: 'button', autoSize: true,
            closeText: 'Close', onSelect: function() { }

        });

    });

    //}
	
	
</script>

<footer class="mobilefooter">

	<div class="container">
	 <div class="accordionwrap">
              <div class="panel-group" id="accordion-footer">
                <div class="panel panel-default">
                  <div class="panel-heading">
                    <h4 class="panel-title"> <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion-footer" href="#collapseF1"> <i class="indicator glyphicon glyphicon-plus"></i> Corporate </a> </h4>
                  </div>
                  <div id="collapseF1" class="panel-collapse collapse">
                    <div class="panel-body">
                     <ul>
          <li><a href="company-profile.aspx?Check=About">About us</a></li>
          <li>Testimonials</li>
          <li><a href="News-Events.aspx">News &amp; Media</a></li>
          <li><a href="Career.aspx">Careers</a></li>
          <li><a href="Company-Profile.aspx?Check=csr">Plant a Tree Program</a></li>
          <li><a target="_blank" href="https://www.southerntravelsindia.com/flipbook/Domestic/index.html">Domestic e-brochure</a></li>
          <li><a target="_blank" href="https://www.southerntravelsindia.com/flipbook/International/Complete_International_Brochure-2020.pdf">International e-brochure</a></li>
          <li><a href="Company-Profile.aspx?Check=Award">Award &amp; Accolades</a></li>
          <li><a href="CustomerLogin.aspx?LIN=1&amp;Type=A">Agent Login</a></li>
        </ul>
                    </div>
                  </div>
                </div>
                <div class="panel panel-default">
                  <div class="panel-heading">
                    <h4 class="panel-title"> <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion-footer" href="#collapseF2"> <i class="indicator glyphicon glyphicon-plus"></i> Products offerings </a> </h4>
                  </div>
                  <div id="collapseF2" class="panel-collapse collapse">
                    <div class="panel-body">
                     <ul>
                            <li>
                      <a href="India-Tour-Packages.aspx" aria-label="Fixed Departure Tours, Domestic, seat in Coach basis">
                        Fixed Departure Tours <span class="smalltext">(Domestic / seat in Coach basis)</span>
                      </a>
                    </li>
                    <li>
                      <a href="HolidayPackages.aspx" aria-label="Holiday Packages for India, Nepal, Bhutan">
                        Holiday Packages <span class="smalltext">(India / Nepal / Bhutan)</span>
                      </a>
                    </li>
                    <li>
                      <a href="International-GroupDeparture.aspx?off=2" aria-label="International Fixed and Group Departure Tours">
                        International <span class="smalltext">(Fixed / Group Departures)</span>
                      </a>
                    </li>
                    <li>
                      <a href="International-Packages.aspx?off=1" aria-label="International Customized Holidays">
                        International <span class="smalltext">(Customized Holidays)</span>
                      </a>
                    </li>
                    <li>
                      <a href="hotel-southern.aspx?HTLREG=DEL" aria-label="Our Hotels in Delhi">
                        Our Hotels
                      </a>
                    </li>
                    <li>
                      <a href="Car-Coach-Rental.aspx?ORG=All" aria-label="Car and Coach Rental Services">
                        Car / Coach Rental
                      </a>
                    </li>
                    <li>
                      <a href="LFC-Home.aspx" aria-label="LFC and LTC Tours">
                        LFC / LTC Tours
                      </a>
                    </li>

        </ul>
                    </div>
                  </div>
                </div>
				
				 <div class="panel panel-default">
                  <div class="panel-heading">
                    <h4 class="panel-title"> <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion-footer" href="#collapseF3"> <i class="indicator glyphicon glyphicon-plus"></i> Partner With us </a> </h4>
                  </div>
                  <div id="collapseF3" class="panel-collapse collapse">
                    <div class="panel-body">
                     <ul>
          <li>Work From Home</li>
          <li><a href="HotelRegistration.aspx">Register Your Hotel</a></li>
          <li><a href="AgentRegistrationEnq.aspx">Become a preferred Agent</a></li>
          
        </ul>
                    </div>
                  </div>
                </div>
				
				 <div class="panel panel-default">
                  <div class="panel-heading">
                    <h4 class="panel-title"> <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion-footer" href="#collapseF4"> <i class="indicator glyphicon glyphicon-plus"></i>  Terms & policy </a> </h4>
                  </div>
                  <div id="collapseF4" class="panel-collapse collapse">
                    <div class="panel-body">
                     <ul>
          <li><a href="Terms-Conditions.aspx">Domestic Tours T&amp;C</a></li>
          <li><a href="International-Terms-Conditions.aspx">International Tours T&amp;C</a></li>
          <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
          <li><a href="Terms-Conditions.aspx#CancellationPolicy">Cancellation Policy</a></li>
        </ul>
                    </div>
                  </div>
                </div>
				
				 <div class="panel panel-default">
                  <div class="panel-heading">
                    <h4 class="panel-title"> <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion-footer" href="#collapseF5"> <i class="indicator glyphicon glyphicon-plus"></i> Contact us</a> </h4>
                  </div>
                  <div id="collapseF5" class="panel-collapse collapse">
                    <div class="panel-body">
                  <ul>
                          <li><a href="contact-us.aspx?CONREG=Corporate">Corporate Office</a></li>
                          <li><a href="contact-us.aspx?CONREG=Branches">Branch Office</a></li>
                          <li><a href="contact-us.aspx#Customer">Customer Care</a></li>
                          <li><a href="Feedback.aspx?MM=5">Feedback Form</a></li>
                          <li><a href="Enquiryform.aspx">Enquiry Form</a></li>
                          <li><a href="site-map.aspx">Site Map</a></li>
                          <li class="mob_foot_app_icon">
                            <a href="https://play.google.com/store/apps/details?id=com.virtupaper.android.user.c620" target="_blank" rel="noopener noreferrer" aria-label="Download on Google Play Store">
                              <img src="Assets/images/icon_gplay.png" loading="lazy" alt="Google Play Store Icon" />
                            </a>
                          </li>
                          <li class="mob_foot_app_icon">
                            <a href="https://itunes.apple.com/us/app/southern-travels/id1434666186?mt=8" target="_blank" rel="noopener noreferrer" aria-label="Download on Apple App Store">
                              <img src="Assets/images/icon_ios.png" alt="Apple App Store Icon" loading="lazy" />
                            </a>
                          </li>
                        </ul>

                    </div>
                  </div>
                </div>
				
				 <div class="panel panel-default">
                  <div class="panel-heading">
                    <h4 class="panel-title"> <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion-footer" href="#collapseF6"> <i class="indicator glyphicon glyphicon-plus"></i> Useful links </a> </h4>
                  </div>
                  <div id="collapseF6" class="panel-collapse collapse">
                    <div class="panel-body">
                     <ul>
          <li><a href="FAQs.aspx">FAQs</a></li>
         
          <li>Travel Tips</li>
          <li>Destination facts</li>
          <li><a href="PaymentModes.aspx">How to pay</a></li>
          <li><a href="OnlineBalanceClear.aspx?MM=4">Clear Balance</a></li>
          <li class="buttonwrap"><a href="Feedback.aspx?MM=5">Help us Improve</a></li>
        </ul>
                    </div>
                  </div>
                </div>
				
				 <div class="panel panel-default">
                  <div class="panel-heading">
                    <h4 class="panel-title"> <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion-footer" href="#collapseF7"> <i class="indicator glyphicon glyphicon-plus"></i> Connect with us </a> </h4>
                  </div>
                  <div id="collapseF7" class="panel-collapse collapse">
                    <div class="panel-body">
                    <ul class="footer-social-links">
          <li><a class="fb" href="https://www.facebook.com/SouthernTravels/">Facebook</a></li>
          <li><a class="tw" href="https://twitter.com/happyholidaying">Twitter</a></li>
          <li><a class="gplus" href="https://plus.google.com/b/105500167792879378506/105500167792879378506/posts">Google+</a></li>
          <li><a class="yt" href="https://www.youtube.com/southerntravels">YouTube</a></li>
        </ul>
   
                    </div>
                  </div>
                </div>
                
                
              </div>
            </div>
	</div>
</footer>
<footer id="footer">
  <div class="container">
    <div class="row">
      <div class="col-sm-4 col-md-2">
        <h4>Corporate</h4>
        <ul>
          <li><a href="company-profile.aspx?Check=About">About us</a></li>
          <li>Testimonials</li>
          <li><a href="News-Events.aspx">News & Media</a></li>
          <li><a href="Career.aspx">Careers</a></li>
          <li><a href="Company-Profile.aspx?Check=csr">Plant a Tree Program</a></li>
          <li><a href="https://www.southerntravelsindia.com/flipbook/Domestic/Domestic_e-Brochure.pdf" target="_blank">Domestic e-brochure</a></li>
          <li><a href="https://www.southerntravelsindia.com/flipbook/International/International_e-Brochure.pdf" target="_blank">International e-brochure</a></li>
          <li><a href="Company-Profile.aspx?Check=Award">Award & Accolades</a></li>
          <li><a href="CustomerLogin.aspx?LIN=1&Type=A">Agent Login</a></li>
        </ul>
      </div>
      <div class="col-sm-4 col-md-2">
        <h4>Products offerings</h4>
        <ul>
          <li><a href="India-Tour-Packages.aspx">Fixed Departure Tours <span class="smalltext">(Domestic / seat in Coach basis)</span></a></li>
          <li><a href="HolidayPackages.aspx">Holiday Packages <span class="smalltext">(India / Nepal / Bhutan)</span></a></li>
          <li><a href="International-GroupDeparture.aspx?off=2">International <span class="smalltext">(Fixed / Group Departures)</span></a></li>
          <li><a href="International-Packages.aspx?off=1">International <span class="smalltext">(Customized Holidays)</span></a></li>
          <li><a href="hotel-southern.aspx?HTLREG=DEL">Our Hotels</a></li>
          <li><a href="Car-Coach-Rental.aspx?ORG=All">Car / Coach Rental</a></li>
          <li><a href="LFC-Home.aspx">LFC / LTC Tours</a></li>
        </ul>
      </div>
      <div class="col-sm-4 col-md-2">
        <h4>Partner With us</h4>
        <ul>
          <li><%--<a href="AgentRegistrationEnq.aspx">--%>Work From Home<%--</a>--%></li>
          <li><a href="HotelRegistration.aspx">Register Your Hotel</a></li>
          <li><a href="AgentRegistrationEnq.aspx">Become a preferred Agent</a></li>
          <%--<li><a href="#">Advertise with us</a></li>--%>
        </ul>
        <h4> Terms & policy</h4>
        <ul>
          <li><a href="Terms-Conditions.aspx">Domestic Tours T&C</a></li>
          <li><a href="International-Terms-Conditions.aspx">International Tours T&C</a></li>
          <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
          <li><a href="Terms-Conditions.aspx#CancellationPolicy">Cancellation Policy</a></li>
        </ul>
      </div>
      <div class="col-sm-4 col-md-2">
        <h4>Contact us</h4>
        <ul>
          <li><a href="contact-us.aspx?CONREG=Corporate">Coporate Office</a></li>
          <li><a href="contact-us.aspx?CONREG=Branches">Branch Office</a></li>
          <li><a href="contact-us.aspx#Customer">Customer Care</a></li>
          <li><a href="Feedback.aspx?MM=5">Feedback Form</a></li>
          <li><a href="Enquiryform.aspx">Enquiry Form</a></li>
          <li><a href="site-map.aspx">Site Map</a></li>
          
        </ul>
      </div>
      <div class="col-sm-4 col-md-2">
        <h4>Useful links</h4>
        <ul>
          <li><a href="FAQs.aspx">FAQs</a></li>
         <li><a href="https://blog.southerntravelsindia.com/">Blog</a></li>
          <li><%--<a href="#">--%>Travel Tips<%--</a>--%></li>
          <li><%--<a href="#">--%>Destination facts<%--</a>--%></li>
          <li><a href="PaymentModes.aspx">How to pay</a></li>
          <li><a href="OnlineBalanceClear.aspx?MM=4">Clear Balance</a></li>
          <li class="buttonwrap"><a href="Feedback.aspx?MM=5">Help us Improve</a></li>
        </ul>
      </div>
      <div class="col-sm-4 col-md-2">
          <h4>Connect with us</h4>
          <ul class="footer-social-links">
            <!-- WhatsApp -->
            <li>
              <a href="https://api.whatsapp.com/send?phone=917466006600" class="wa" target="_blank" aria-label="Chat with us on WhatsApp">
                <i class="fab fa-whatsapp" aria-hidden="true"></i>
              </a>
            </li>

            <!-- Facebook -->
            <li>
              <a href="https://www.facebook.com/SouthernTravels/" class="fb" target="_blank" aria-label="Visit us on Facebook">
                <i class="fab fa-facebook-f" aria-hidden="true"></i>
              </a>
            </li>

            <!-- Twitter -->
            <li>
              <a href="https://twitter.com/happyholidaying" class="tw" target="_blank" aria-label="Follow us on Twitter">
                <i class="fab fa-twitter" aria-hidden="true"></i>
              </a>
            </li>

            <!-- Google+ (deprecated, but kept if still needed) -->
            <li>
              <a href="https://plus.google.com/b/105500167792879378506/105500167792879378506/posts" class="gplus" target="_blank" aria-label="Visit us on Google Plus">
                <i class="fab fa-google-plus-g" aria-hidden="true"></i>
              </a>
            </li>

            <!-- YouTube -->
            <li>
              <a href="https://www.youtube.com/southerntravels" class="yt" target="_blank" aria-label="Watch our videos on YouTube">
                <i class="fab fa-youtube" aria-hidden="true"></i>
              </a>
            </li>

            <!-- Mobile App Info -->
            <li class="footer_app_icon">
              <span class="smalltext1">Book ticket faster. <br />Download our mobile app</span>
            </li>

            <!-- Google Play Store -->
            <li class="footer_app_icon">
              <a href="https://play.google.com/store/apps/details?id=com.virtupaper.android.user.c620" target="_blank" aria-label="Download on Google Play Store">
                <img src="Assets/images/icon_gplay.png" loading="lazy" alt="Google Play Icon" />
              </a>
            </li>

            <!-- Apple App Store -->
            <li class="footer_app_icon">
              <a href="https://itunes.apple.com/us/app/southern-travels/id1434666186?mt=8" target="_blank" aria-label="Download on Apple App Store">
                <img src="Assets/images/icon_ios.png" loading="lazy" alt="Apple App Store Icon" />
              </a>
            </li>
          </ul>
        </div>

    </div>
  </div>
</footer>
<footer id="footerbtm" class="hideonmobile">
  <div class="container">
    <div class="row">
      <div class="col-md-5">
        <h4>Payment Methods</h4>
        <ul class="paymodelist paymodelist1">
          <li><img src="../Assets/images/netbanking.jpg" id="btnDate" runat="server"  loading="lazy"
                    alt="Bank" style="cursor: pointer" onmouseover="$find('PopExNet').showPopup();"
                    onmouseout="$find('PopExNet').hidePopup();" />
          <cc1:PopupControlExtender ID="PopExNet" runat="server" BehaviorID="PopExNet" TargetControlID="btnDate"
                    PopupControlID="Panel123" Position="Top" OffsetX="-230" OffsetY="-450">
                    
                </cc1:PopupControlExtender>
                <asp:Panel ID="Panel123" runat="server" class="PopUp" BackColor="White" BorderWidth="1"
                    BorderColor="Red" Style="display: none; padding: 20px;" Width="951px">
                    <uc1:UCPaymentOptionNetBanking ID="UCPaymentOptionNetBanking1" runat="server" />
                </asp:Panel>
          </li>
          <li><a href="#"><img src="Assets/images/emioption.jpg" alt="EMI Option" loading="lazy"></a></li>
          <li><a href="#"><img src="Assets/images/visa.png" alt="Visa" loading="lazy"></a></li>
          <li><a href="#"><img src="Assets/images/mastercard.png" alt="mastercard" loading="lazy"></a></li>
          <li><a href="#"><img src="Assets/images/amex.png" alt="amex" loading="lazy"></a></li>
          <li><a href="#"><img src="Assets/images/rupay.png"  alt="rupay" loading="lazy"></a></li>
          <li><a href="#"><img src="Assets/images/americaexpress.png" alt="americaexpress" loading="lazy"></a></li>
        </ul>
        <%--<ul class="paymodelist paymodelist2">
        </ul>--%>
      </div>
      <%--<div class="col-md-2">
        <h4>Verisign Secure</h4>
        <ul class="paymodelist">
          <li><a href="#"><img src="Assets/images/verisign.png"></a></li>
        </ul>
      </div>--%>
      <div class="col-md-7">
        <h4>Memberships & Accreditations</h4>
        <ul class="memberlogolist">
          <li><img src="Assets/images/member-logo1.png" loading="lazy" alt="Member Logo 1"></li>
        <li><img src="Assets/images/member-logo2.png" loading="lazy" alt="Member Logo 2"></li>
        <li><img src="Assets/images/member-logo3.png" loading="lazy" alt="Member Logo 3"></li>
        <li><img src="Assets/images/member-logo4.png" loading="lazy" alt="Member Logo 4"></li>
        <li><img src="Assets/images/member-logo5.png" loading="lazy" alt="Member Logo 5"></li>
        <li><img src="Assets/images/member-logo6.png" loading="lazy" alt="Member Logo 6"></li>
        <li><img src="Assets/images/member-logo7.png" loading="lazy" alt="Member Logo 7"></li>
        <li><img src="Assets/images/member-logo8.png" loading="lazy" alt="Member Logo 8"></li>
        <li><img src="Assets/images/member-logo9.png" loading="lazy" alt="Member Logo 9"></li>
        <li><img src="Assets/images/member-logo10.png" loading="lazy" alt="Member Logo 10"></li>
        <li><img src="Assets/images/member-logo11.png" loading="lazy" alt="Member Logo 11"></li>
        </ul>
      </div>
    </div>
  </div>
</footer>
<section id="copyright">
  <div class="container">
    <div class="row">
      <div class="col-md-6">
        <p> Copyright <%= DateTime.Now.Year.ToString() %> © Southern Travels Pvt. Ltd., All Rights Reserved</p>
      </div>
      <%--<div class="col-md-6">
        <p class="pull-right"> Site by <a href = "https://www.sirez.com/" target = "_blank">Sirez Limited</a></p>
      </div>--%>
    </div>
  </div>
</section>
<div class="hero-btnrow">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <ul class="btns">
                    <li class="request" style="display: none;">Request a Callback
                        <asp:TextBox ID="txtMobile" runat="server" class="" placeholder="Mobile no." MaxLength="12"
                            onkeypress="javascript:return isNumberKey(event);" ValidationGroup="FOO1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobile"
                            ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOO1"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="ga('send', 'event', { eventCategory: 'callback', eventAction: 'callback request'});"
                            OnClick="btnSubmit_Click" ValidationGroup="FOO1" />
                        <%--<input type="text" class="" placeholder="Mobile no." maxlength="12" accesskey> <input type="submit" value="Submit">--%>
                    </li>
                    <li class="enquiry"><a href="#" class="linkqck">Quick Enquiry</a> </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<div class="qckenqwrap animated" style="" id="divSCPop">
    <div class="container">
        <div class="formwrap pull-right">
            <p class="closebtn">
                <a href="#" aria-label="Close popup"><span class="glyphicon glyphicon-remove-circle" aria-hidden="true"></span>
                </a>
            </p>
             <div class="heading">
                <h4 class="title"><strong><span>Served more than 4 Million Happy Travelers!</span></strong></h4>
                <p>To build your dream holiday please fill the below details. Our expert will reach you.</p>
            </div>
            <ul class="row">
                <li class="col-md-6 col-sm-6 col-xs-6 paddingright0">
                    <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Full name"
                        MaxLength="50" ValidationGroup="FOO"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqCheckOutDel" runat="server" ControlToValidate="txtName"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOO" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                        ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Only alphabetic characters are allowed."
                        ValidationExpression="^[a-zA-Z ]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z ]*)*$" ValidationGroup="FOO"></asp:RegularExpressionValidator>
                    <%--<input type="text" class="form-control" placeholder="User name">--%></li>
                <li class="col-md-6 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtPhone" runat="server" class="form-control" ValidationGroup="FOO"
                        placeholder="Phone number" MaxLength="15" onkeypress="javascript:return isNumberKey(event);"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhone"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOO" Display="Dynamic"></asp:RequiredFieldValidator>
                    <%--<input type="text" class="form-control" placeholder="Phone number">--%></li>
            </ul>
            <ul class="row">
                <li class="col-md-6 col-sm-6 col-xs-6 paddingright0">
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"
                        MaxLength="50" ValidationGroup="FOO"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOO" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="Reguemail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Please enter valid email id." SetFocusOnError="True" ValidationGroup="FOO"
                        Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <%-- <input type="text" class="form-control" placeholder="Email">--%></li>
                <li class="col-md-6 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder="City of Residence"
                        ValidationGroup="FOO" MaxLength="50"> </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCity"
                        Display="Dynamic" ErrorMessage="Only alphabetic characters are allowed." ValidationExpression="^[a-zA-Z ]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z ]*)*$"
                        ValidationGroup="FOO"></asp:RegularExpressionValidator>
                    <%--<input type="text" class="form-control" placeholder="City of Residence">--%></li>
            </ul>
            <ul class="row">
                <li class="col-md-6 col-sm-6 col-xs-6 paddingright0 ddate">
                    <asp:TextBox ID="txtDeparturedate" runat="server" class="form-control" placeholder="Departure date"
                        MaxLength="10" ValidationGroup="FOO"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDeparturedate"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOO" Display="Dynamic"></asp:RequiredFieldValidator>
                    <%--<input type="text" class="form-control" placeholder="Arrival date">--%></li>
                <li class="col-md-6 col-sm-6 col-xs-6 adate">
                    <asp:TextBox ID="txtArrivaldate" runat="server" class="form-control" placeholder="Arrival date"
                        ValidationGroup="FOO" MaxLength="10"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator244" runat="server" ControlToValidate="txtArrivaldate"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOO" Display="Dynamic"></asp:RequiredFieldValidator>
                    <%--<input type="text" class="form-control" placeholder="Departure date">--%></li>
            </ul>
            <ul class="row">
                <li class="col-md-12">
                    <asp:DropDownList ID="ddlInterested" runat="server" class="form-control">
                        <asp:ListItem Selected="True">Interested in</asp:ListItem>
                        <asp:ListItem>Air / Rail Ticketing</asp:ListItem>
                        <asp:ListItem>Tour of India</asp:ListItem>
                        <asp:ListItem>Hotel Reservation</asp:ListItem>
                        <asp:ListItem>Car / Coach Rental</asp:ListItem>
                        <asp:ListItem>International Tour</asp:ListItem>
                    </asp:DropDownList>
                    <%--<select class="form-control">
        <option>Interested in</option>
        <option>Air / Rail Ticketing</option>
        <option>Tour of India</option>
         <option>Hotel Reservation</option>
         <option>Car / Coach Rental</option>
         <option>International Tour</option>
        </select>--%>
                </li>
            </ul>
            <ul class="row">
                <li class="col-md-12">
                    <asp:TextBox ID="txtShortDescription" runat="server" class="form-control" placeholder="Short Description"
                        TextMode="MultiLine" ValidationGroup="FOO"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtShortDescription"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOO" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ValidationGroup="FOO" SetFocusOnError="True"
                        ID="revTBIssueDescription" Display="Dynamic" ControlToValidate="txtShortDescription"
                        ValidationExpression="^[\s\S]{0,150}$" ErrorMessage="Please enter Short Description in 150 characters." />
                    <%--<textarea class="form-control" placeholder="Short Description" rows="3"></textarea>	--%>
                </li>
            </ul>
            <ul class="row">
                <li >
                    <div id="dvCaptchaF">
                    </div>
                    <%--<asp:TextBox ID="txtCaptchaF" runat="server" Style="display: none" />--%>
                    <%--<asp:RequiredFieldValidator ID="rfvCaptchaF" ValidationGroup="FOO" ErrorMessage="Captcha validation is required."
                        ControlToValidate="txtCaptchaF" runat="server" ForeColor="Red" Display="Dynamic" />--%>
                        
                       
                        <div class="col-md-3">
                        <asp:TextBox ID="txtCaptcha" runat="server" ValidationGroup="FOO" autocomplete="off" Width="114px" placeholder="Enter Captcha"
                            AutoCompleteType="None" MaxLength="10" CssClass="form-control"></asp:TextBox>
                         </div>
                         <div class="col-md-2" style="margin-left: 49px;">
                          <img src="JpegImage.aspx?cache=1394701635527" id="captchImg" alt="captcha" width="110px" loading="lazy" />
                         </div>
                         <div class="col-md-2" style="margin-left: 53px;">
                          <img id="refresh_captcha" src="Assets/images/captcha_refresh.jpg" alt="captcha_refresh" style="height:28px; cursor:pointer;" loading="lazy">
                         </div>
                    
                            
                       <asp:RequiredFieldValidator ID="RequiredFieldtxtCaptcha" CssClass="errorMessage" ValidationGroup="FOO" ForeColor="Red"
                       runat="server" ControlToValidate="txtCaptcha" Display="Dynamic" ErrorMessage="Enter Captcha"></asp:RequiredFieldValidator>
                        
                        
                </li>
            </ul>
            
            <%--<ul class="row">
                <li class="col-md-12">
                    <div class="g-recaptcha" runat="server" id="divrecaptcha">
                    </div>
                </li>
                <asp:Label ID="MessageLabel" runat="server" CssClass="txt" ForeColor="red"></asp:Label>
            </ul>--%>
            <ul class="row">
                <li class="col-md-12">
                    <asp:Button ID="btnSubmitDe" runat="server" Text="Submit" OnClientClick="ga('send', 'event', { eventCategory: 'quick enquiry', eventAction: 'enquiry'});"
                        OnClick="btnSubmitDe_Click" class="btn pull-right" ValidationGroup="FOO" />
                </li>
            </ul>
        </div>
    </div>
</div>
<div id="back-top" style="margin-bottom: 24px;">
    <a href="#top" aria-label="Back to top of page">
        <img src="Assets/images/back-top.png" alt="Back to top" loading="lazy"><br>
        Back to Top
    </a>
</div>


<script>
    $('select.form-control').selectpicker({
        style: 'btn-info',
        size: 4
    });
    /* back to top */
    $(document).ready(function() {
        // hide #back-top first
        $("#back-top").hide();
        // fade in #back-top
        $(function() {
            $(window).scroll(function() {
                if ($(this).scrollTop() > 100) {
                    $('#back-top').fadeIn();
                } else {
                    $('#back-top').fadeOut();
                }
            });

            // scroll body to 0px on click
            $('#back-top a').click(function() {
                $('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });
        });

    });
</script>

<script>
    function pageLoad(sender, args) {

        $('select.form-control').selectpicker();
        
    }

</script>

<script type="text/javascript">
	    $(document).ready(function($) {
    	  
		  
		  $("#blog-slider").owlCarousel({
			    items : 1,
				pagination : false,
				// Navigation
				navigation : true,
				navigationText : ["<i class='fa fa-caret-left'></i>","<i class='fa fa-caret-right'></i>"],
				rewindNav : true,
				scrollPerPage : false,
		  });
		  
		  $("#like-slider").owlCarousel({
			    items : 1,
				pagination : false,
				// Navigation
				navigation : false,
				loop:true,
				autoPlay:true,
				autoplayTimeout:1000,
				autoplayHoverPause:true
		  });
		  
		  
		  
	    });
</script>

<script>
    $(function() {

        $('.linkqck').click(function (e) {
            $("#divSCPop").addClass('qe_open slideInRight');
            e.preventDefault();
            $('body').addClass('formOpen');
            
        });


        $('.closebtn a').click(function(e) {

            $(".qckenqwrap").removeClass('qe_open slideInRight');

            $('body').removeClass('formOpen');
            e.preventDefault();
        });



        $('.placescoveredtbl .pcwrap ul li a').click(function(e) {
            $('.nav-tabs li').removeClass('active');
            $('a[href="#tab_tourinfo"]').parent().addClass('active');
            $('#tab_dateprice').removeClass('active in');
            $('#tab_tourinfo').addClass('active in');
            //$('a').attr().parent().addClass('active');
            e.preventDefault();
        });



    });
    
</script>

<script type="text/javascript">
    $('#fixedtabsection').scrollToFixed();
</script>

<script type="text/javascript">
	    $(document).ready(function($) {
    	  
		  
		  $("#blog-slider").owlCarousel({
			    items : 1,
				pagination : false,
				// Navigation
				navigation : true,
				navigationText : ["<i class='fa fa-caret-left'></i>","<i class='fa fa-caret-right'></i>"],
				rewindNav : true,
				scrollPerPage : false,
		  });
		  
		  $("#like-slider").owlCarousel({
			    items : 1,
				pagination : false,
				// Navigation
				navigation : false,
				loop:true,
				autoPlay:true,
				autoplayTimeout:1000,
				autoplayHoverPause:true
		  });
		  
		  
		  
	    });
</script>

<script>
    $(function() {
        $('input[type=text]').each(function() {
            titleText = $(this).attr('placeholder');
            $(this).attr('title', titleText);
            $(this).attr('data-toggle', 'tooltip').tooltip({

                placement: "right",
                trigger: "focus"


            });


        });



        $('.placescoveredtbl .pcwrap ul li a').click(function(e) {
            $('.nav-tabs li').removeClass('active');
            $('a[href="#tab_tourinfo"]').parent().addClass('active');
            $('#tab_dateprice').removeClass('active in');
            $('#tab_tourinfo').addClass('active in');
            //$('a').attr().parent().addClass('active');
            e.preventDefault();
        });



    });


    $(document).ready(function() {

        /* read more read less */
        var showChar = 350;
        var ellipsestext = "...";
        var moretext = "Read more <i class='fa fa-plus'></i>";
        var lesstext = "Read less <i class='fa fa-minus'></i>";


        $('.more').each(function() {
            var content = $(this).html();

            if (content.length > showChar) {

                var c = content.substr(0, showChar);
                var h = content.substr(showChar, content.length - showChar);

                var html = c + '<span class="moreellipses">' + ellipsestext + '&nbsp;</span><span class="morecontent"><span>' + h + '</span>&nbsp;&nbsp;<a href="" class="morelink">' + moretext + '</a></span>';

                $(this).html(html);
            }

        });

        $(".morelink").click(function() {
            if ($(this).hasClass("less")) {
                $(this).removeClass("less");
                $(this).html(moretext);
            } else {
                $(this).addClass("less");
                $(this).html(lesstext);
            }
            $(this).parent().prev().toggle();
            $(this).prev().toggle();
            return false;
        }); /* end read more read less */




    });


    /* ================================================	center modal popup ============================================*/
    // initialise on document ready
    jQuery(document).ready(function($) {
        'use strict';

        // CENTERED MODALS
        // phase one - store every dialog's height
        $('.modal').each(function() {
            var t = $(this),
            d = t.find('.modal-dialog'),
            fadeClass = (t.is('.fade') ? 'fade' : '');
            // render dialog
            t.removeClass('fade')
            .addClass('invisible')
            .css('display', 'block');
            // read and store dialog height
            d.data('height', d.height());
            // hide dialog again
            t.css('display', '')
            .removeClass('invisible')
            .addClass(fadeClass);
        });
        // phase two - set margin-top on every dialog show
        $('.modal').on('show.bs.modal', function() {
            var t = $(this),
            d = t.find('.modal-dialog'),
            dh = d.data('height'),
            w = $(window).width(),
            h = $(window).height();
            // if it is desktop & dialog is lower than viewport
            // (set your own values)
            if (w > 380 && (dh + 60) < h) {
                d.css('margin-top', Math.round(0.96 * (h - dh) / 2));
            } else {
                d.css('margin-top', '');
            }
        });

    }); /* ================================================	center modal popup ============================================*/


</script>

<script type="text/javascript">
    $(function() {
        //        if (document.getElementById("hdfIswed").value == "1") {

        //            $('.tabsection_inner .nav-tabs li a').on('click', function(e) {

        //                $("html, body").animate({ scrollTop: 0 }, "slow").stop();
        //                e.preventDefault();
        //            });
        //        }
        //else {
        $('.tabsection_inner .nav-tabs li a').on('click', function(e) {

            $("html, body").animate({ scrollTop: 0 }, "slow");
            e.preventDefault();
        });

        // }
    });
</script>

<script>
    function toggleChevron(e) {
        $(e.target)
        .prev('.panel-heading')
        .find('i.indicator')
        .toggleClass('glyphicon-minus glyphicon-plus');
        //$('#accordion-tourlist','.panel-heading').css('background-color', 'green');
    }
    $('#accordion-footer').on('hidden.bs.collapse', toggleChevron);
    $('#accordion-footer').on('shown.bs.collapse', toggleChevron);

    /*$('.parentlist a').click(function(){
    $(this).parent().find('ul.sublist').slideToggle();
    });*/
</script>

<script type="text/javascript">
    $('#refresh_captcha').click(function(e) {
        
        $('#captchImg').attr('src', 'JpegImage.aspx?cache=' + new Date().getTime());
        e.preventDefault();
    });
</script>



