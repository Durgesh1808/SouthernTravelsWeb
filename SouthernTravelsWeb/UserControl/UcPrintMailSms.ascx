<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcPrintMailSms.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcPrintMailSms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type"text/css">
.PopUp{ padding: 15px!important; background-color: #f7f7f7!important; border: solid 1px #dbdbdb!important}
.PopUp input[type=text]{ margin-bottom: 10px; padding: 0 10px; left: 233px!important; top: 553px!important;  z-index:999}
</style>

<script type="text/javascript" src="https://www.google.com/recaptcha/api.js?onload=onloadCallback1&render=explicit"
    async defer></script>

<script>
    function SendLinkByMail() {
        
        $('[id$=hdnFinalHtmlGenerated]').val('');
        var str = $('#hdnTourItitearyHTML').val() + $('#hdnTourFare').val() + $('#hdnTourInclusionExculision').val() + $('#hdnTourInfo').val();
        str = str.replace(new RegExp('images/', 'gi'), "http://www.southerntravelsindia.com/images/");
        //console.log(str);
        $('[id$=hdnFinalHtmlGenerated]').val(str);        
        $find('PopupEmail').showPopup();

    }
    function ValidateEmail() {
        //var val = true;
        var err = '';
        var EmailId = $('[id$=txtEmailTo]').val().replace(/\s/g, '');
        if (EmailId == '') {
            err = 'Please enter email id.\n';
            //$('[id$=txtEmailTo]').focus();
        }
        else {
            var emails = EmailId.split(",");
            emails.forEach(function(email) {
                var boolret = validate(email.trim());
                if (boolret == false) {
                    err += 'Please enter valid email id.\n';
                }
            });
        }

        if ($("[id$=txtCaptcha]").val() == "") {
            err += "Captcha validation is required.";            
        }
        
        if (err.length > 0) {
            alert(err);
            return false;
        }
        else {
            SendLinkByMail();
            return true;
        }
    }
    function validate(field) {
        var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        return (regex.test(field)) ? true : false;
    }
    
    function PrintPanel() {
        var panel = document.getElementById("<%=ltrIten.ClientID  %>");
        var printWindow = window.open('', '', 'height=400,width=800');
        printWindow.document.write('<html><head><title>DIV Contents</title>');
        printWindow.document.write('</head><body >');
        printWindow.document.write(panel.innerHTML);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        setTimeout(function() {
            printWindow.print();
        }, 500);
        return false;
    }
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
</script>

<div class="printmailsms">
    <div class="row">
        <div class="col-md-4 col-sm-4 col-xs-4">
            <a href="#" class="print" onclick="return PrintPanel();"><i class="fa fa-print"></i> Print</a>
        </div>
        <div class="col-md-4 col-sm-4 col-xs-4">
            <a href="javascript:" id="btnSendEMail" runat="server" onclick="SendLinkByMail();">
               <i class="fa fa-envelope-o"> </i> Email</a>
        </div>
        <div class="col-md-4 col-sm-4 col-xs-4">
            <a href="javascript:" class="last" id="btnDate" runat="server" onclick="$find('PopExSMS').showPopup();"
                ><i class="fa fa-wechat"></i> SMS</a>
        </div>
    </div>
</div>

<asp:HiddenField ID="hdnFinalHtmlGenerated" runat="server" Value="" />

<div id="ltrIten" runat="server" style="display: none;">
</div>
<cc1:PopupControlExtender ID="PopExSMS" runat="server" BehaviorID="PopExSMS" TargetControlID="btnDate"
    PopupControlID="Panel123" Position="Top"  OffsetX="-30" OffsetY="-40">
</cc1:PopupControlExtender>
<asp:Panel ID="Panel123" runat="server" class="PopUp" BackColor="White" BorderWidth="1"
    BorderColor="Red" style="display:none; z-index: 999;">
    <asp:TextBox ID="txtMobile" runat="server" class="" placeholder="Mobile no." MaxLength="12"
        onkeypress="javascript:return isNumberKey(event);" ValidationGroup="FOO2"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobile"
        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="FOO2"
        Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
        ValidationGroup="FOO2" />
</asp:Panel>

<cc1:PopupControlExtender ID="PopupEmail" runat="server" BehaviorID="PopupEmail" TargetControlID="btnSendEMail"
    PopupControlID="PanelSendEmail" Position="Top"  OffsetX="-30" OffsetY="-40">
</cc1:PopupControlExtender>
<asp:Panel ID="PanelSendEmail" runat="server" class="PopUp" BackColor="White" BorderWidth="1"
    BorderColor="Red" style="display:none; z-index: 999; top:375px !important;" Width="350">
    <asp:TextBox ID="txtEmailTo" runat="server" class="" placeholder="Email" Width="100%"
        ></asp:TextBox>
                    
                    <div class="col-md-3" style="margin-left: -15px;">
                        <asp:TextBox ID="txtCaptcha" runat="server" ValidationGroup="FOO" autocomplete="off" Width="142px"  placeholder="Enter Captcha"
                            AutoCompleteType="None" MaxLength="10" CssClass="form-control"></asp:TextBox>
                         </div>
                         <div class="col-md-2" style="margin-left: 66px;">
                          <img src="JpegImage.aspx?cache=1394701635527" id="captchImg1" alt="captcha" width="130px" />
                         </div>
                         <div class="col-md-2" style="margin-left: 81px;">
                          <img id="refresh_captcha1" src="Assets/images/captcha_refresh.jpg" style="height:34px; cursor:pointer;">
                         </div>
                    
                        <br /> <br /> <br />
                        <div style="margin-left: 232px;">
    <asp:Button ID="btnPanelSendEmail" runat="server" Text="Send Email" onClientClick="return ValidateEmail();" OnClick="btnPanelSendEmail_Click" />
    </div>
        
</asp:Panel>

<script type="text/javascript">
    $('#refresh_captcha1').click(function(e) {
        $('#captchImg1').attr('src', 'JpegImage.aspx?cache=' + new Date().getTime());
        e.preventDefault();
    });
</script>
