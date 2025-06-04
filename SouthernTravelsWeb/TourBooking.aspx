<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TourBooking.aspx.cs" Inherits="SouthernTravelsWeb.TourBooking" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/UCPaymentOptionNetBanking.ascx" TagName="UCPaymentOptionNetBanking"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/UcTourItinerary.ascx" TagPrefix="UC" TagName="Itinerary" %>
<%@ Register Src="UserControl/UcHeaderEndUser.ascx" TagName="UCHeaderEndUser" TagPrefix="UCHeader" %>
<%@ Register Src="UserControl/UcFooterEndUser.ascx" TagName="UCFooterEndUser" TagPrefix="UCFooter" %>
<%@ Register Src="UserControl/UcCityWisePlaceDisplay.ascx" TagName="UCCityWisePlaceDisplay"
    TagPrefix="uc1" %>       
<%@ Register Src="UserControl/UcTourShortInfo.ascx" TagName="ucTourShortInfo" TagPrefix="uc2" %>
<%@ Register Src="UserControl/UcFarePanel.ascx" TagPrefix="UC" TagName="FTFarePanel" %>
<%@ Register Src="UserControl/UcModifySearch.ascx" TagName="UcModifySearch" TagPrefix="uc1" %>
<%@ Register Src="UserControl/ucMatchingTour.ascx" TagName="ucMatchingTour" TagPrefix="uc3" %>
<%@ Register Src="UserControl/UCTourInfo.ascx" TagName="UCTourInfo" TagPrefix="uc4" %>
<%@ Register Src="UserControl/UCTourGallery.ascx" TagName="UCTourGallery" TagPrefix="uc5" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="HeadST">
    <title>Southern India Travel,South India Travel Packages,Travel Packages to South 
        India
    </title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <meta content="Southern India Travel - South India Travel guides offering southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package."
        name="Description" id="mtDescription" />
    <meta content="southern india travel, south india travel packages, travel packages to south india, travel holidays package to south india, south india travel, southern india travel packages for south india, southern india travel packages, travel package for south india, south india pilgrimage travel package, south india beaches travel packages, south india holiday travel packages, holiday travel package to south india, southern india package travel, south india tourism, tourism in south india, holidays travel in southern india, kerala backwater travel packages in india, north india tour packages, north india tours, tours to north india, tourism in north india, golden triangle tours, kathamandu tours, kashmir tour package, chennai tours, delhi tours, hyderabad tours, pilgrimage tours in india, kerala backwater tours, southern travels india, southerntravelsindia, Sirez"
        name="Keywords" id="mtKeywords" />
    <meta content="index,follow" name="robots" id="mtrobots" />
    <meta content="Designed  www.Sirez.com" name="Author" />
    <meta content="MSHTML 6.00.2900.2180" name="GENERATOR" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 8" />
    <meta name="CODE_LANGUAGE" content="c#" />
    <meta name="vs_defaultClientscript" content="Javascript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link rel="shortcut icon" href="Assets/images/favicon.ico" />
    
   
    <style>
        .Throug
        {
            text-decoration: line-through;
        }
        .DatePickerImage
        {
            position: relative;
            padding-left: 5px;
        }
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.60;
        }
        .updateProgress
        {
            border-width: 1px;
            border-style: solid;
            background-color: #FFFFFF;
            position: absolute;
            width: 150px;
            height: 50px;
        }
        .updateProgressMessage
        {
            margin: 3px;
            font-family: Trebuchet MS;
            font-size: small;
            vertical-align: middle;
        }
        .loading
        {
            background-image: url(https://www.southerntravelsindia.com/images/loading1.gif);
            background-position: right;
            background-repeat: no-repeat;
        }
        .AutoExtender
        {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            background-color: White;
        }
        .AutoExtenderList
        {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: Maroon;
        }
        .AutoExtenderHighlight
        {
            color: White;
            background-color: #006699;
            cursor: pointer;
        }
        .completionList
        {
            border: solid 1px #444444;
            margin: 0px;
            padding: 2px;
            overflow: auto;
            background-color: #FFFFFF;
            z-index: 6 !important;
        }
        .ui-dialog {position:fixed!important;  z-index: 1001!important}
        .ui-widget-overlay {z-index: 1000!important}
    </style>
<style type="text/css">
#videoModel-new{position:fixed; overflow: hidden; left:50%; top:50%; -webkit-transform: translate(-50%, -50%);transform: translate(-50%, -50%); width:450px; height:auto; background-color: #f5f5f5; z-index:9999; padding:30px 20px; display: none;cursor:default;}
#videoModel-new .modelBody{float: left; width:100%; background-color: #f5f5f5;cursor:default;}
.rightText {width: 90%; float: left; margin-left: 5%; text-align: center; color: #292929; font-size: 18px; margin-top: 10px;}
#lightboxOverlay-new{position:fixed; width:100%; height:100%; left:0; top:0; background:rgba(0, 0, 0, 0.5); z-index:99; display: none;cursor:default;}
	.rightText span {border-radius: 4px;
    background-color: #f15125;
    color: #fff;
    padding: 10px 15px;
    display: inline-block;
    text-decoration: none;border: none; cursor: pointer;}
    
    .rightText p {font-size: 18px; margin: 0 0 20px 0;text-align: center;}


    #videoModel-second{position:fixed; overflow: hidden; left:50%; top:50%; -webkit-transform: translate(-50%, -50%);transform: translate(-50%, -50%); width:550px; height:auto;padding:30px 20px; background-color: #f5f5f5; z-index:9999; display: none;cursor:default;}
#videoModel-second .modelBody{float: left; width:100%; background-color: #f5f5f5;cursor:default;}
	 @media (max-width: 460px) {
     #videoModel-new {width: 90% !important;}
     #videoModel-second {width: 90% !important;}
     .rightText_N {width: 90%;}
     .rightText_N {margin-top: 60px; font-size: 12px;}
     .rightText_N span {border-radius: 4px;
    background-color: #f15125;
    color: #fff;
    padding: 10px 15px;
    display: inline-block;
    text-decoration: none;border: none; cursor: pointer;}
    
    .rightText_N p {font-size: 13px; margin: 0 0 20px 0;text-align: center;}

  }
</style>
<script>
window.__cfRLUnblockHandlers = true;
</script>
    <script type="text/javascript">
var __cfRLUnblockHandlers = 1;
        function clearCitylist() {
            document.getElementById('txtCity').value = "";
            document.getElementById('hdnCity').value = "";
            document.getElementById('hdnCityId').value = "";
            document.getElementById('hdnStateIdBasedOnCity').value = "";
            return false;
        }
        function SetContextKey() {
            $find('<%=AutoCompleteExtender2.ClientID%>').set_contextKey($get("<%=ddlState.ClientID %>").value);
        }
        function ShowProcessImage(sender, e) {
            sender._element.className = "loading";
        }
        function HideProcessImage(sender, e) {
            sender._element.className = "";
        }
        function OnClientSelectedCity(source, eventArgs) {
            if (source) {
                document.getElementById("txtCity").className = "form-control";
                var hdHACCity = source.get_id().replace("AutoCompleteExtender2", "hdnCity");
                $get(hdHACCity).value = eventArgs.get_text(); //.get_value();

                var hdnCityId = source.get_id().replace("AutoCompleteExtender2", "hdnCityId");
                var hdnStateIdBasedOnCity = source.get_id().replace("AutoCompleteExtender2", "hdnStateIdBasedOnCity");
                $get(hdnCityId).value = eventArgs.get_value().split("##")[0];
                $get(hdnStateIdBasedOnCity).value = eventArgs.get_value().split("##")[1];

                var stateid = document.getElementById("ddlState");
                var state = stateid.options[stateid.selectedIndex].value;
                if (state == "" || state == "0") {
                    document.getElementById('btnSetStateByCity').click(); return false;
                }
            }
        }
        
    </script>

    <script language="javascript" type="text/javascript">
        function LTrim(value) {

            var re = /\s*((\S+\s*)*)/;
            return value.replace(re, "$1");

        }

        // Removes ending whitespaces
        function RTrim(value) {

            var re = /((\s*\S+)*)\s*/;
            return value.replace(re, "$1");

        }

        // Removes leading and ending whitespaces
        function Trim(value) {

            return LTrim(RTrim(value));

        }
        function FireFacebookButtonOnFixed() {
            document.getElementById('btnFaceBook_BookFixed').click();
        }

        function fillTransfer(MasterId) {
            xmlHttp = GetXmlHttpObject()
            var url = 'getaddress.aspx?RowId=';
            url = url + MasterId;
            url = url + "&sid=" + Math.random();
            // alert(url);
            xmlHttp.onreadystatechange = stateChanged5;
            xmlHttp.open("GET", url, true);
            xmlHttp.send(null);
        }
        function stateChanged5() {

            if ((xmlHttp.readyState == 4 || xmlHttp.readyState == "complete")) {
                var k = xmlHttp.responseText;

                var aa = k.split("^");
                var sd = aa[0];
                document.getElementById('lblPickupPlace').innerHTML = sd;
                var sd1 = aa[1];
                //alert(sd1);
                document.getElementById('lblDepTime').innerHTML = sd1;
                document.getElementById('hidPickupPlace').value = sd;
                document.getElementById('hidDepTime').value = sd1;
                var pAFare = aa[2];
                var pCFare = aa[3];
                document.getElementById('hdAServiceChargeFare').value = pAFare;
                document.getElementById('hdCServiceChargeFare').value = pCFare;
                if (pAFare > 0) {
                    document.getElementById('lblFare').innerHTML = '<b>Current selected Pickup Point`s Service charge is  (Adult / Child) : <span class="rupee">`</span> ' + pAFare + ' /- <span class="rupee">`</span> ' + pCFare + '/-.</b>';
                }
                else {
                    document.getElementById('lblFare').innerHTML = '';
                }
            }
        }
        function GSTHideUnhide(val) {
            if (val == "yes") {
                document.getElementById('<%= divGSTDetails.ClientID%>').style.display = "";
                //                document.getElementById('<%= txtGstHolderName.ClientID%>').value = "";
                //                document.getElementById('<%= txtCustomerGSTIN.ClientID%>').value = "";
            }
            else {
                document.getElementById('<%= divGSTDetails.ClientID%>').style.display = "none";
                //                document.getElementById('<%= txtGstHolderName.ClientID%>').value = "";
                //                document.getElementById('<%= txtCustomerGSTIN.ClientID%>').value = "";
            }
        } 
    </script>

    <script language="javascript" src="Assets/js/MyScript.js" type="text/javascript"></script>

    <script language="javascript" src="Scripts/tourbooking.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
    <!--
        var backColorOver = "#fcefc7";
        var backColorOut = "#ffffff";
        function SetColor(val) {
            var tdNo = 4;
            tdNo = tdNo + val
            chkValidObj(document.getElementById('td' + tdNo), backColorOver);
            chkValidObj(document.getElementById('td' + (tdNo + 2)), backColorOver);
            chkValidObj(document.getElementById('td' + tdNo + 'twin'), backColorOver);
            chkValidObj(document.getElementById('td' + tdNo + 'triple'), backColorOver);
            chkValidObj(document.getElementById('td' + tdNo + 'childbed'), backColorOver);
            chkValidObj(document.getElementById('td' + tdNo + 'single'), backColorOver);
            chkValidObj(document.getElementById('td' + tdNo + 'dormitory'), backColorOver);
            chkValidObj(document.getElementById('tdAWF' + tdNo), backColorOver);
            chkValidObj(document.getElementById('tdCWF' + (tdNo + 2)), backColorOver);
            val++;
            clearColor(val);

        }
     function CardShow (it,box)
        {
           debugger;
            if(box.id=='rdoCCMs')
            {
                var lTotalAmt=<%=GrandTotal%>;
                if( parseFloat(lTotalAmt)>100)
                {   
                    document.getElementById(it).style.display = "block"; 
                     UnSelectAtmSubPaymentOption();
                }
                
            }
            else
            {
                var lTotalAmt=<%=GrandTotal%>;
                if( parseFloat(lTotalAmt)>100)
                {   
                    document.getElementById(it).style.display = "block"; 
                    UnSelectAtmSubPaymentOption();
                    UnSelectHdfcSubPaymentOption();
                }
                else
                {
                  document.getElementById(it).style.display = "none"; 
                   UnSelectAtmSubPaymentOption();
                   UnSelectHdfcSubPaymentOption();
                }
            }
        }
        function AtomCardShow(it, box) {
            if (box.id == 'rbtnAtom') {
                var lTotalAmt = <%=GrandTotal%>;;
                if (parseFloat(lTotalAmt) >= 2500) {
                    document.getElementById(it).style.display = "inline-table";
                    UnSelectHdfcSubPaymentOption();
                }
            }
            else {
                
                var lTotalAmt = <%=GrandTotal%>;;
                if (parseFloat(lTotalAmt) >= 2500) {
                    document.getElementById(it).style.display = "inline-table";
                    UnSelectAtmSubPaymentOption();
                }
                else
                 {
                   document.getElementById(it).style.display = "none";
                     UnSelectAtmSubPaymentOption();
                     UnSelectHdfcSubPaymentOption();
                 }
            }
        }
        function chkValidObj(obj, color) {
            if (obj != null) {
                obj.style.backgroundColor = color;
            }
        }
        function clearColor(c) {

            var tdNo = (4 + (c % 2));
            chkValidObj(document.getElementById('td' + tdNo), backColorOut);
            chkValidObj(document.getElementById('td' + (tdNo + 2)), backColorOut);
            chkValidObj(document.getElementById('td' + tdNo + 'twin'), backColorOut);
            chkValidObj(document.getElementById('td' + tdNo + 'triple'), backColorOut);
            chkValidObj(document.getElementById('td' + tdNo + 'childbed'), backColorOut);
            chkValidObj(document.getElementById('td' + tdNo + 'single'), backColorOut);
            chkValidObj(document.getElementById('td' + tdNo + 'dormitory'), backColorOut);
            chkValidObj(document.getElementById('tdAWF' + tdNo), backColorOut);
            chkValidObj(document.getElementById('tdCWF' + (tdNo + 2)), backColorOut);
        }

        function chkTypeAc() {
            var k = document.getElementById('BuschkType').value;
            if (k == "N") {
                alert("OOPs....!, Selected journey date is not available in AC,Try another date or choose NoN-AC");
                document.getElementById('RadAC').checked = false;
                return false;
            }
        }

        function chkTypeNAc() {
            var k = document.getElementById('BuschkType').value;
            if (k == "Y") {
                alert("OOPs...! Selected journey date is not available in NON-AC,Try another date or choose AC");
                document.getElementById('RadNAC').checked = false;
                //document.getElementById('RadNAC').style.display='none';
                return false;

            }
        }
        
        
      
        
    -->
    </script>

    <!-- new Icon change -->

    <script type="text/javascript">
        function UnSelectAtmSubPaymentOption() {
            document.getElementById('<%=rdoAtomF.ClientID %>').checked = false;
            document.getElementById('<%=rdoAtom3.ClientID %>').checked = false;
            document.getElementById('<%=rdoAtom6.ClientID %>').checked = false;
            document.getElementById('<%=rdoAtom9.ClientID %>').checked = false;
            document.getElementById('<%=rdoAtom12.ClientID %>').checked = false;
        }

        function UnSelectHdfcSubPaymentOption() {
            document.getElementById('<%=rdoCC.ClientID %>').checked = false;
            document.getElementById('<%=rbtnEMI3Month.ClientID %>').checked = false;
            document.getElementById('<%=rbtnEMI6Month.ClientID %>').checked = false;
        }

        function SelectAtomMainPayment() {

            if (document.getElementById('<%=rdoAtomF.ClientID %>').checked == true ||
            document.getElementById('<%=rdoAtom3.ClientID %>').checked == true ||
            document.getElementById('<%=rdoAtom6.ClientID %>').checked == true ||
            document.getElementById('<%=rdoAtom9.ClientID %>').checked == true ||
            document.getElementById('<%=rdoAtom12.ClientID %>').checked == true) {
                UnSelectHdfcSubPaymentOption();
                document.getElementById('<%=rbtnAtom.ClientID %>').checked = true;
            }

        }
        function SelectHdfcMainPayment() {
            if (document.getElementById('<%=rdoCC.ClientID %>').checked == true ||
            document.getElementById('<%=rbtnEMI3Month.ClientID %>').checked == true ||
            document.getElementById('<%=rbtnEMI6Month.ClientID %>').checked == true) {
                document.getElementById('<%=rdoCCMs.ClientID %>').checked = true;
                UnSelectAtmSubPaymentOption();
            }

        }
    
    </script>

    <style>
        .Watermark
        {
            width: 425px;
            margin: 5px;
            color: Gray;
        }
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.60;
        }
        .updateProgress
        {
            border-width: 1px;
            border-style: solid;
            background-color: #FFFFFF;
            position: absolute;
            width: 210px;
            height: 54px;
            top: 649px;
            left: 0px;
        }
        .updateProgressMessage
        {
            margin: 3px;
            font-family: Trebuchet MS;
            font-size: small;
            vertical-align: middle;
        }
    </style>

    <script language="javascript" type="text/javascript">
    
    window.history.forward(1);
     function approve()
     {
       
          window.open('frmterms.aspx?','pops','width=418,height=249,scrollbars=yes');
    }
    
    function CheckMail(str) 
		{
			if (str.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
            {
                return true;
            }
            else
            {
                alert("Invalid E-mail ID");
                return false;
            }			
		}
function PromoCodeCHK()
	{
	 if (document.getElementById("promocode").value=="")
		    {
		        alert("Enter Promocode.");
		        document.getElementById("promocode").focus();
		        return false;
		    }	
	}	
	function chk1()
	{	
	
	    if (document.Form1.emailid.value=="" || document.Form1.emailid.value=="Email ID / Mobile")
		    {
		        alert("Enter your Email-ID or Mobile No");
		        document.Form1.emailid.focus();
		        return false;
		    }
	    else
		{
		if (isNaN(document.Form1.emailid.value)==true)
			{		
		        if ((CheckMail(document.Form1.emailid.value))== false)
			        {        				
				        document.Form1.emailid.value="";
				        document.Form1.emailid.focus();
				        return false;
			        }
			   else
			        {
			        document.Form1.type.value="email";
			        }
			 }
		else
			{
			    var a=document.Form1.emailid.value;
			    if((a.length<10)|(a.length>11))
			    {
			        alert("Invalid Mobile No")
			        document.Form1.emailid.value="";
	                document.Form1.emailid.focus();
	                return false;
			    }
			    else
			    {
			    document.Form1.type.value="Mobile";
			    }
			}			
		}
		        
	}
	
	function checkonsubmit()
	{
		if (document.getElementById("ddlTour").value=="0")
			{
				alert("Please choose a tour.");
				document.getElementById("ddlTour").focus();
				return false
			}
	}	
	function doValidate2()
	{
		   var chek = true;
		    if (Trim(document.Form1.txtName.value) == "" || document.Form1.txtName.value == "Enter the Full Name")
		    {
		        alert("Please fill the first name.It is mandatory.");
		        document.Form1.txtName.focus();	
		        chek = false;	
		        return false;
		    }
		    var nam=document.Form1.txtName.value;
		    if((nam.length)<3) 
		    {
		        alert("Please Enter Minimum Three Charecters in the name field");
		        document.Form1.txtName.focus();	
		        chek = false;	
		        return false;
		    }

		    if (Trim(document.Form1.txtMail.value)== "" || document.Form1.txtMail.value == "Enter the E-Mail")	
		    {
			    alert("Plese fill the e-mail field.It is mandatory.");
			    document.Form1.txtMail.focus();
			    return false;
		    }
		    
		    else
		    {
			    if (Trim(document.Form1.txtMail.value)!= "" )
			    {
				    if (CheckMail(document.Form1.txtMail.value)== false)
				    {
					    //alert("Plese enter your valid email Id.");
					    document.Form1.txtMail.value="";
					    document.Form1.txtMail.focus();
					    chek = false;
					    return false;
				    }
			    }
		    }	
						
		                              
		  if (Trim(document.Form1.txtAddress.value) == "" || document.Form1.txtAddress.value == "Enter the Address")
		    {
			    alert("Please fill the address in address field.It is mandatory.");
			    document.Form1.txtAddress.focus();
			    chek = false;
			    return false;
		    } 
		    if (Trim(document.Form1.ddlNationality.value) == "" || document.Form1.ddlNationality.value == "0")
		    {
			    alert("Please select nationality.");
			    document.Form1.ddlNationality.focus();
			    chek = false;
			    return false;
		    }
		    if(Trim(document.Form1.ddlCountry.value)=="59")
		    { 
		     if (Trim(document.Form1.ddlState.value) == "" || document.Form1.ddlState.value == "0")
		    {
			    alert("Please select State.");
			    document.Form1.ddlState.focus();
			    chek = false;
			    return false;
		    }
		      if (Trim(document.Form1.txtCity.value) == "" || document.Form1.txtCity.value == "0")
		    {
			    alert("Please select City.");
			    document.Form1.txtCity.focus();
			    chek = false;
			    return false;
		    }
		    }
		    else
		    {
		    if (Trim(document.Form1.TxtForeignState.value) == "" || document.Form1.TxtForeignState.value == "0")
		    {
			    alert("Please enter state.");
			    document.Form1.TxtForeignState.focus();
			    chek = false;
			    return false;
		    }
		    if (Trim(document.Form1.txtForeignCity.value) == "" || document.Form1.txtForeignCity.value == "0")
		    {
			    alert("Please enter city.");
			    document.Form1.txtForeignCity.focus();
			    chek = false;
			    return false;
		    }
		    }       
    		/*if (Trim(document.Form1.txtPhoneCountryCode.value) == "" || document.Form1.txtPhoneCountryCode.value == "Enter the Code")
		    {
			    alert("Please fill the country code field.It is mandatory.");
			    document.Form1.txtPhoneCountryCode.focus();
			    chek = false;
			    return false;
		    }
		    else
		    {
		        if (validateOnlyNumber1(Trim(document.Form1.txtPhoneCountryCode.value)) == false)
			    {
				    alert("country code field should have numeric value only.");
				    document.Form1.txtPhoneCountryCode.value="";
				    document.Form1.txtPhoneCountryCode.focus();
				    return false;
			    }
		    }
	*/
		    if (Trim(document.Form1.txtPhone.value) == "" || document.Form1.txtPhone.value == "Enter the Phone")
		    {
			    alert("Please fill the Phone no. in phone field.It is mandatory.");
			    document.Form1.txtPhone.focus();
			    chek = false;
			    return false;
		    }		
		    else
		    {
		        var pho=document.Form1.txtPhone.value;
			    if (validateOnlyNumber1(Trim(document.Form1.txtPhone.value)) == false)
			    {
				    alert("Phone no. should have numeric value only.");
				    document.Form1.txtPhone.value="";
				    document.Form1.txtPhone.focus();
				    chek = false;
				    return false;
			    }
			    else if((pho.length)<6) 
			    {
			        alert("Phone no. should have minimum 6 numbers");				    
				    document.Form1.txtPhone.focus();
				    chek = false;
				    return false;
			    }
		    }
		  
		    var txtmobile = document.getElementById('txtMobile');
		     if (Trim(txtmobile.value)== "" || txtmobile.value== "Enter the Mobile")
		       {
			       alert("Please enter Mobile No..");
				    txtmobile.value="";
				    txtmobile.focus();
				    chek = false;
				    return false;
			    }
		   
    	  
		    if (Trim(document.Form1.txtMobile.value)!= "")
		    {
			    if (validateOnlyNumber1(Trim(document.Form1.txtMobile.value)) == false)
			    {
				    alert("Mobile no. should have numeric value only.");
				    document.Form1.txtMobile.value="";
				    document.Form1.txtMobile.focus();
				    chek = false;
				    return false;
			    }
			    else
				{								
			        var a=document.Form1.txtMobile.value;
			        if((a.length<10)|(a.length>11))
			        {
			            alert("Invalid Mobile No")
			            document.Form1.txtMobile.value="";
				        document.Form1.txtMobile.focus();
				        return false;
			        }
				}
			    
		    } 
		    
		    if (document.getElementById('<%= rdbIsGSTApplicableYes.ClientID%>').checked == true) {
                if (document.getElementById('<%= txtCustomerGSTIN.ClientID%>').value == "") {
                    alert('Please Enter Customer GSTIN.');
                    document.getElementById('<%= txtCustomerGSTIN.ClientID%>').focus();
                    chek = false;
                    return false;
                }
                else {
                    var GSTINNO = document.getElementById("<%= txtCustomerGSTIN.ClientID %>").value;
                    //if (!/([A-Z,a-z]){3}([A,B,C,F,G,H,J,L,P,T,a,b,c,f,g,h,j,l,p,t]){1}([A-Z,a-z]){1}([0-9]){4}([A-Z,a-z]){1}/.test(GSTINNO)) {
                    if (!/^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9]{1}Z[0-9A-Z]{1}$/.test(GSTINNO)) {
                        alert('Please enter Valid Customer GSTIN');
                        document.getElementById("<%=txtCustomerGSTIN.ClientID  %>").focus();
                        chek = false;
                        return false;
                    }
                }
                if (document.getElementById('<%= txtGstHolderName.ClientID%>').value == "") {
                    alert('Please Enter GST Holder Name.');
                    document.getElementById('<%= txtGstHolderName.ClientID%>').focus();
                    chek = false;
                    return false;
                }
            }
		    
		    var txtAlternateMobileNo = document.getElementById('txtAlternateMobileNo');
		     if (Trim(txtAlternateMobileNo.value)== "" || txtAlternateMobileNo.value== "Enter the Emergency Contact No")
		       {
			       alert("Please enter Emergency Contact No..");
				    txtAlternateMobileNo.value="";
				    txtAlternateMobileNo.focus();
				    chek = false;
				    return false;
			    }
		   
    	  
		    if (Trim(document.Form1.txtAlternateMobileNo.value)!= "")
		    {
			    if (validateOnlyNumber1(Trim(document.Form1.txtAlternateMobileNo.value)) == false)
			    {
				    alert("Emergency Contact No should have numeric value only.");
				    document.Form1.txtAlternateMobileNo.value="";
				    document.Form1.txtAlternateMobileNo.focus();
				    chek = false;
				    return false;
			    }
			    
			    
		    } 
		    if(!(document.getElementById("rdoNetBanking").checked) 
		    && !(document.getElementById("rdoCCMs").checked) 
		    && !(document.getElementById("rdoamex").checked)
		    && !(document.getElementById("rdoDC").checked)
		    && !(document.getElementById("rbtnPayu").checked)
		    && !(document.getElementById("rbtnAtom").checked)
		    && !(document.getElementById("rbtnInstamojo").checked)
		    && !(document.getElementById("rdoRazorPay").checked))
		    {
		        alert("Please choose any payment mode!");
		        chek = false;
		        return false;
		    }
		    var lTotalAmt=<%=GrandTotal%>;
            
		    if(document.getElementById("rdoCCMs").checked && parseFloat(lTotalAmt)>250)
		    {
		         if(!(document.getElementById("rbtnEMI3Month").checked) && !(document.getElementById("rdoCC").checked) && !(document.getElementById("rbtnEMI6Month").checked))
		        {
		            alert("Please choose any payment mode!");
		            chek = false;
		            return false;
		        }
		    }
		     if (document.getElementById("rbtnAtom").checked == true && parseFloat(lTotalAmt) >= 2500) {
                if (document.getElementById("rdoAtomF").checked == false
                && document.getElementById("rdoAtom3").checked == false
                && document.getElementById("rdoAtom6").checked == false
                && document.getElementById("rdoAtom9").checked == false
                && document.getElementById("rdoAtom12").checked == false
                && document.getElementById("rdoAtom18").checked == false
                && document.getElementById("rdoAtom24").checked == false) {
                    alert("please choose the payment option");
                    return false;
                }
            }
            if (document.getElementById("rbtnAtom").checked == true && parseFloat(lTotalAmt) >= 2500) {
                if (document.getElementById("rdoAtom3").checked == true
                || document.getElementById("rdoAtom6").checked == true
                || document.getElementById("rdoAtom9").checked == true
                || document.getElementById("rdoAtom12").checked == true
                || document.getElementById("rdoAtom18").checked == true
                || document.getElementById("rdoAtom24").checked == true) {
                    if (document.getElementById("ddlAtomEMIBank").value=='0') {
                        alert("Please Select Bank.");
                        return false;
                    }
                }
            }
		    if(document.getElementById("chkTrue").checked==false)
		    {
		        alert("Please agree our terms & Conditions Before going to Pay online");
		        chek = false;
		        return false;
		    }	    
		   
		    if(chek)
                  {
		            document.getElementById('Submit1').style.display='none';	     		          
		          }
		    return chek;
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
				        alert("Please enter characters only.");
				        return false;
            }
             function CheckOnlyCharacteraddress(evt)
	        {
			        var kk
			        //|| kk==191 || kk==188 || kk==190
			        kk=(evt.which) ? evt.which : event.keyCode
			        if((kk>=65 && kk<=90)||(kk>=97 && kk<=122)||(kk>=48 && kk<=57) || kk==32 || kk==8 || kk==9 || kk==127 || kk==20|| kk==46)
			         {
				        return true;
			         }
				        alert("Please enter characters only.");
				        return false;
            }        
            
            

               /*var message="Due to security reason, Right Click is not allowed";
               function clickIE4()
               {
                 if (event.button==2)
                 {
                     alert(message);
                     return false;
                 }
               }

               function clickNS4(e)
               {
                 if (document.layers||document.getElementById&&!document.all)
                 {
                    if (e.which==2||e.which==3)
                    {
                      alert(message);
                      return false;
                    }
                 }
               }

               if (document.layers)
               {
                    document.captureEvents(Event.MOUSEDOWN);
                    document.onmousedown=clickNS4;
               }
               else if (document.all&&!document.getElementById)
               {
                    document.onmousedown=clickIE4;
               }
               document.oncontextmenu=new Function("alert(message);return false;")  */
	
    </script>

    <script src="Assets/js/md5.js"></script>

    <script language="javascript" type="text/javascript">
        function fnMd5(saltval) {

            encpass = hex_md5(saltval);
            document.getElementById('tmpEnValue').value = encpass;
            return true;
        }
			
    </script>

    <style type="text/css">
        .pnl
        {
            background-color: Red;
            font-family: Arial, Helvetica, sans-serif;
            color: #ED1C24;
        }
        .popUpStyle
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
        .modal
        {
            background-color: #ED1C24;
            background-image: url('Assets/images/leaf.gif' );
        }
    </style>
    <style type="text/css">
        .PopUp
        {
            border: solid 0px #337201;
            border-color: Black;
        }
        .PDk15
        {
            color: #003300;
            font-size: 15px;
        }
        .PLG14
        {
            color: #337201;
            font-size: 14px;
        }
        .Inpt
        {
            border: solid 1px #337201;
            width: 172px;
            height: 19px;
            line-height: 19px;
            padding-left: 4px;
            font-size: 14px;
            color: #337201;
        }
        .tablepadding5 td, tablepadding th
        {
            padding: 5px !important;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function changeBank(t, name) {
            if (name == '') {
                document.getElementById('lblPayment').style.display = 'none';
                return;
            }
            if (document.getElementById('CSTBANKID')) {
                document.getElementById('hdBankName').value = name;
                document.getElementById('lblPayment').innerHTML = "<span class=\"orange\">Selected Bank:</span> " + name;
                document.getElementById('CSTBANKID').value = t;
            }

        }
        function fnSlide() {


            $(".slidingDiv").slideToggle();

            return false;
            //});

        }
    </script>

    <style>
        .mGrid
        {
            background-color: #FFFFFF;
            border: 1px solid #F0F0F0;
            border-collapse: collapse;
            margin: 5px 0 10px;
            width: 100%;
        }
        .mGrid th
        {
            background: none repeat scroll 0 0 #C7EDFF;
            border-left: 1px solid #FFF;
            color: #DF411A;
            font-size: 10px;
            padding: 4px 2px;
            text-align: left;
            vertical-align: top;
        }
        .mGrid td
        {
            background: none repeat scroll 0 0 #DEF5FF;
            border-left: 1px solid #FFF;
            font-size: 10px;
            padding: 4px 2px;
            text-align: left;
            vertical-align: top;
        }
        .paxBox .col2
        {
            width: 66px;
        }
        .paxBox .col3
        {
            width: 92px;
        }
        .paxBox .col4
        {
            width: 53px;
        }
        .paxBox .col5
        {
            width: 36px;
        }
        .paxBox .col6
        {
            border: medium none;
            text-align: right;
            width: 58px;
        }
        .paxBox .blank
        {
            float: left;
            height: 33px;
            width: 433px;
        }
        .paxBox .inp
        {
            border: 1px solid #ABADB3;
            color: #6D6D6D;
            font-size: 11px;
            margin: 0;
            padding: 2px;
            width: 35px;
        }
    </style>

    <script language="javascript">
        function fnFb() {
            window.open('fb-login.aspx?tofb=y', 'login', 'height=600px, width=900px');
            return false;
        }
       
    </script>


            <!-- Begin Inspectlet Embed Code -->

    <script type="text/javascript" id="inspectletjs">
        window.__insp = window.__insp || [];
        __insp.push(['wid', 996100346]);
        (function () {
            function ldinsp() { if (typeof window.__inspld != "undefined") return; window.__inspld = 1; var insp = document.createElement('script'); insp.type = 'text/javascript'; insp.async = true; insp.id = "inspsync"; insp.src = ('https:' == document.location.protocol ? 'https' : 'http') + '://cdn.inspectlet.com/inspectlet.js'; var x = document.getElementsByTagName('script')[0]; x.parentNode.insertBefore(insp, x); };
            setTimeout(ldinsp, 500); document.readyState != "complete" ? (window.attachEvent ? window.attachEvent('onload', ldinsp) : window.addEventListener('load', ldinsp, false)) : ldinsp();
        })();
    </script>

    <!-- End Inspectlet Embed Code -->

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <input id="hdBankName" type="hidden" name="hdBankName" runat="server" />
    <input id="BusserialH" type="hidden" name="BusserialH" runat="server" />
    <input id="OrderIDH" type="hidden" name="OrderIDH" runat="server" />
    <input id="TourNoH" type="hidden" name="TourNoH" runat="server" />
    <input id="totamt" type="hidden" value="1" name="totamt" runat="server" />
    <input id="nadults" type="hidden" value="1" name="nadults" />
    <input id="nchild" type="hidden" value="1" name="nchild" />
    <input type="hidden" name="hidTourId" id="hidTourId" runat="server" />
    <input type="hidden" name="hidTourId1" id="hidTourId1" runat="server" />
    <input type="hidden" name="hidTourId1" id="Hidden1" runat="server" />
    <input type="hidden" id="combination" name="combination" runat="server" />
    <input type="hidden" id="raac" name="raac" runat="server" />
    <input type="hidden" id="ranac" name="ranac" runat="server" />
    <input type="hidden" id="rcac" name="rcac" runat="server" />
    <input type="hidden" id="rcnac" name="rcnac" runat="server" />
    <input type="hidden" id="rdac" name="rdac" runat="server" />
    <input type="hidden" id="rdnac" name="rdnac" runat="server" />
    <input type="hidden" id="ra2ac" name="ra2ac" runat="server" />
    <input type="hidden" id="ra2nac" name="ra2nac" runat="server" />
    <input type="hidden" id="ra3ac" name="ra3ac" runat="server" />
    <input type="hidden" id="ra3nac" name="ra3nac" runat="server" />
    <input type="hidden" id="rcbac" name="rcbac" runat="server" />
    <input type="hidden" id="rcbnac" name="rcbnac" runat="server" />
    <input type="hidden" id="rsac" name="rsac" runat="server" />
    <input type="hidden" id="rsnac" name="rsnac" runat="server" />
    <input type="hidden" id="aac" name="aac" runat="server" />
    <input type="hidden" id="anac" name="anac" runat="server" />
    <input type="hidden" id="cac" name="cac" runat="server" />
    <input type="hidden" id="cnac" name="cnac" runat="server" />
    <input type="hidden" id="dac" name="dac" runat="server" />
    <input type="hidden" id="dnac" name="dnac" runat="server" />
    <input type="hidden" id="a2ac" name="a2ac" runat="server" />
    <input type="hidden" id="a2nac" name="a2nac" runat="server" />
    <input type="hidden" id="a3ac" name="a3ac" runat="server" />
    <input type="hidden" id="a3nac" name="a3nac" runat="server" />
    <input type="hidden" id="cbac" name="cbac" runat="server" />
    <input type="hidden" id="cbnac" name="cbnac" runat="server" />
    <input type="hidden" id="sac" name="sac" runat="server" />
    <input type="hidden" id="snac" name="snac" runat="server" />
    <input type="hidden" id="prevadu" name="prevadu" runat="server" />
    <input type="hidden" id="prevchi" name="prevchi" runat="server" />
    <input type="hidden" id="order" name="order" runat="server" />
    <input type="hidden" id="optedSeatNos" value="" runat="server" />
    <input type="hidden" id="maxSeatAllowed" runat="server" />
    <input type="hidden" id="service" name="service" runat="server" />
    <input type="hidden" id="credit" name="credit" runat="server" />
    <input type="hidden" id="sess" name="sess" runat="server" />
    <input type="hidden" id="stax" name="stax" value="0" runat="server" />
    <input type="hidden" id="cc" name="cc" value="0" runat="server" />
    <input type="hidden" id="discount" name="discount" value="0" runat="server" />
    <input type="hidden" id="BuschkType" name="BuschkType" value="0" runat="server" />
    <input type="hidden" id="hdfTourName" name="hdfTourName" value="0" runat="server" />
    <input type="hidden" id="ddlJdate" name="ddlJdate" value="0" runat="server" />
    <input type="hidden" id="ddlJdate1" name="ddlJdate" value="0" runat="server" />
    <input id="CSTBANKID" type="hidden" runat="server" />
    <asp:HiddenField ID="hdAmount" runat="server" Value="0" />
    <asp:HiddenField ID="hdStax" runat="server" Value="0" />
    <asp:HiddenField ID="hdAdults" runat="server" />
    <asp:HiddenField ID="hdChild" runat="server" />
    <asp:HiddenField ID="hdnTourItitearyHTML" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourFare" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourInfo" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourName" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourCodeDetails" runat="server" Value="" />
    <asp:HiddenField ID="hdnTourInclusionExculision" runat="server" Value="" />
    <asp:HiddenField ID="hdnWam" runat="server" Value="0" />
    <asp:HiddenField ID="hdnTCSVal" Value="0" runat="server" />
    <!-- Header Start -->
    <header class="posrel innerheader" style="background-image: url(Assets/images/banner-fixed-tour-detail.jpg)">
  <div class="herobanner">
    <UCHeader:UCHeaderEndUser ID="UCHeaderEndUser1" runat="server" fldMainSection="FIXED_DEPARTURE" />
      </div>
</header>
    <!-- Header End -->
    <!-- Main Content Start -->
    
   
    
    
    
    <section class="innersection2">
  <div class="container">
  

  <uc2:ucTourShortInfo ID="ucTourShortInfo1" runat="server"   fldCanBook = "false"/>

      
     
      
      <div class="col-md-8">
        <div class="tab-content tab-content-inner">
          <div class="tab-pane hidbookingnmobile" id="tab_itinerary">
          <h2 class="title showonmobile">Itinerary</h2>
            <div class="tbldetail">
            
              <UC:Itinerary runat="server" ID="ucItinerary" fldTourType="FIXED_TOUR" />
                <!--Custom Alert -->
                <div id="dialog-confirm"></div> 
                <!----End------------- -->
              
            </div>
          </div>
          <div class="tab-pane  fade in active" id="tab_dateprice"> 
          	 <h2 class="title showonmobile">Date &amp; PriDate &amp; Price Info</h2>
            
            <!-- tour Price -->
           
                
                <%--<div class="tablewrap">--%>
                <UC:FTFarePanel runat="server" ID="FTFarePane91" fldTourType="fixed" Visible="true" fldCanBook="false" />
                
				<%--</div>--%>
                
                <!-- end tour Price -->
               
               <!-- calendar -->
               <a name="DateSelect"></a>
               <%--<a href="#DateSelect">--%>
                <%--<div class="calendarwrap">--%>
                <uc1:UcModifySearch ID="UcModifySearch1" runat="server" />
                
                	<%--<img src="images/calendarpic.jpg" class="img-responsive">--%>
                <%--</div>--%>
                <!-- end calendar -->
                <asp:Panel ID="pnl1Step" runat="server" DefaultButton="btncheckavail">
                   
                    
                   
               <div class="row" align="right">
                        <div class="row tb10 orange">
                            <asp:Label ID="lbMsgErr" runat="server" CssClass="size14"></asp:Label>
                            <asp:Label ID="lblLTCMsg" runat="server" CssClass="size14" Visible="false"></asp:Label>
                            <asp:HyperLink ID="hlmsgerr" runat="server" CssClass="size14"></asp:HyperLink>
                            <asp:Label ID="LblMsg" runat="server" CssClass="size14"></asp:Label>
                            <%--<asp:HyperLink ID="hlback" runat="server" CssClass="heads" Font-Bold="true" NavigateUrl="~/index.aspx">Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:HyperLink>--%>
                            <%--<a href="javascript:history.go(-1)" id CssClass="heads" Font-Bold="true">Back</a>--%>
                        </div>
                        <div class="row tb10 orange" id="cmbrow" runat="server" visible="false">
                            <asp:Label ID="Label3" runat="server" CssClass="" Text="We are operating the below tour in Volvo as well Hi-tech buses.  The date on which the tour is operated is given below separately"></asp:Label>
                        </div>
                        <asp:LinkButton ID="hlback" runat="server" CssClass="" Font-Bold="true" Visible="false"
                            OnClick="hlback_Click">CONTINUE WITH SAME BOOKING</asp:LinkButton>
                    </div>
               <!-- tour detail table -->
               <div class="tourdtltable">
               		
                    <div class="tablewrap">
                    	<table width="100%" border="0" class="table-bordered  rwd-table" cellpadding="0" cellspacing="0">
                                <tr >
                                   <th>Tour Name</th>
                            <th><asp:Literal ID="LtrlPickupPlace" runat="server" Text="Pickup Place"></asp:Literal></th>
                            <th>Departure Time</th>
                            <th>Journey Date</th>
                                </tr>
                                <tr >
                                    <td data-th="Tour Name">
                                        <asp:Label ID="lblTourName" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <div style="height: auto; min-height: 36px; max-height: 72px;" runat="server" id="divPickupPoint">
                                            <b ><asp:Literal ID="LtrlPickupPoint" runat="server" Text="Pickup Point"></asp:Literal> &nbsp;&nbsp;</b>
                                            <div class="formwrap">
                                            <asp:DropDownList runat="server" ID="ddlPickUp" DataTextField="PickupPlace" DataValueField="Rowid" class="form-control"
                                                onchange="javascript:fillTransfer(this.value);" OnSelectedIndexChanged="ddlPickUp_SelectedIndexChanged">
                                            </asp:DropDownList></div>
                                            <asp:HiddenField runat="server" ID="hidPickupPlace" />
                                            <asp:HiddenField runat="server" ID="hidDepTime" />
                                            
                                        </div>
                                                                                
                                        <asp:Label ID="lblFare" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdAServiceChargeFare" Value="0" runat="server" />
                                        <asp:HiddenField ID="hdCServiceChargeFare" Value="0" runat="server" />
                                        <asp:HiddenField ID="hdServiceChargeTax" Value="0" runat="server" />
                                    </td>
                                    <td  data-th="Departure Time">
                                        <asp:Label ID="lblDepTime" runat="server"></asp:Label>
                                    </td>
                                    <td  data-th="Journey Date">
                                        <asp:Label ID="lblJDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                       
<p class="notepara" id="pNotes" runat="server"><span>Note :</span> * Marked Pickup Point will comprise of some 
    service charge. <br /><asp:Label ID="lblPickupPlace" runat="server" style="color:#f1572b"></asp:Label></p>
                        
                    </div>
                    
                  
                    
               </div>
               <!-- end tour detail table -->
              <a name="BookSelect"></a>
              <!-- places covered -->
                <div class="placescoveredtbl  hidbookingnmobile">
                    	
                        <h3 class="title">Places <span>Covered</span></h3>
                       	
                        <div class="pcwrap">
                        <asp:Literal ID="ltrplaceslist" runat="server"></asp:Literal>
                        
                       
                        
                        </div>
                         <p class="notepara" style="color:Black;"><span>Note :</span> <asp:Literal ID="ltrNotes" runat="server" ></asp:Literal></p>
                    </div>
                    <!-- end places covered -->
            
            <!-- amount table -->
            
            	<div class="amounttbl" id="table5" runat="server" >
                	
                   <div class="tablewrap">
                   	<%--	<div id="table5" runat="server">
                       </div>--%>
                    
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table-bordered">
                          <tr>
                            <th  width="30%">Category</th>
                            <th width="15%">
                             <asp:RadioButton ID="RadAC" CssClass="radiobtnwrap" onclick="Displayfare();javascript:return chkTypeAc();"
                                            runat="server" GroupName="RadioType" Text="AC"  >
                                        </asp:RadioButton>&nbsp;<asp:Label ID="lblavailcheck" runat="server" ToolTip="Available Seats In AC"
                                            ></asp:Label>
                                            
                            </th>
                            <th width="15%"> <asp:RadioButton ID="RadNAC" CssClass="radiobtnwrap" onclick="Displayfare();javascript:return chkTypeNAc();"
                                            runat="server" GroupName="RadioType" Text="Non-AC" >
                                        </asp:RadioButton>&nbsp;<asp:Label ID="lblNONACAVAIL" runat="server" ToolTip="Available Seats In Non-AC"
                                           ></asp:Label></th>
                            <th width="10%">No. of Persons</th>
                            <th width="15%">Fare Per Person</th>
                            <th width="15%">Calculated Amount</th>
                          </tr>
                          
                          <tr id="traf" runat="server">
                                    <td data-th="Category">
                                        Adults</td>
                                    <td data-th="AC" id="divAACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblAACfare" runat="server" Text="0"></asp:Label></td>
                                    <td data-th="Non-AC" id="divCACFAre" runat="server" align="right" >
                                        <asp:Label ID="lblANACfare" runat="server" Text="0"></asp:Label></td>
                                    <td  data-th="No. of Persons" id="tx">
                                        <asp:TextBox ID="txtNoOfAdults" runat="server" class="inp" oncopy="return false" 
                                            ondrag="return false" ondrop="return false" onpaste="return false" onkeypress="return chkNumeric(event);"
                                            onblur="Displayfare();" MaxLength="2" Columns="2" EnableViewState="False" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" >0</asp:TextBox>
                                        </td>
                                    <td data-th="Fare Per Person" id="divAdultAmt" runat="server"  align="right">
                                        <asp:Label ID="lblFareAdults" runat="server" Text="0"></asp:Label>
                                        
                                    </td>
                                    <td data-th="Calculated Amount" id="divCalcAdult" runat="server"  align="right">
                                       <b> <asp:Label ID="lblCalcAdults" runat="server" Text="0" ></asp:Label></b>
                                    </td>
                                </tr>
                                
                          <tr  id="trcf" runat="server">
                                    <td  id="ANonACFAre" runat="server"  >
                                        Children</td>
                                    <td align="right">
                                        <asp:Label ID="lblCACfare" runat="server" Text="0"></asp:Label></td>
                                    <td id="td7"  align="right">
                                        <asp:Label ID="lblCNACfare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfChilds" runat="server" class="inp" oncopy="return false" onfocus="javascript: if(this.value == '0'){ this.value = ''; }"
                                            ondrag="return false" ondrop="return false" onpaste="return false" onkeypress="return chkNumeric(event);"
                                            onblur="Displayfare();" MaxLength="2" Columns="2" EnableViewState="False"   >0</asp:TextBox>
                                        </td>
                                    <td id="divChildAmt" runat="server"  align="right">
                                        <asp:Label ID="lblfareChild" runat="server" Text="0"></asp:Label>
                                        
                                    </td>
                                    <td id="divCalcChild" runat="server"  align="right">
                                       <b> <asp:Label ID="lblCalcChild" runat="server" Text="0"></asp:Label></b>
                                    </td>
                                </tr>
                          
                          <tr id="trAWF" runat="server">
                                    <td>
                                        Adult With South Veg Food</td>
                                    <td class="col2" id="AWFACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblAWFfare" runat="server" Text="0"></asp:Label></td>
                                    <td id="AWFNonACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblAWFNACfare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoAWFNoOfAdults" runat="server" CssClass="inp" onkeypress="return chkNumeric(event);"
                                            onblur="Displayfare();" MaxLength="2" Columns="2" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" EnableViewState="False">0</asp:TextBox>
                                        </td>
                                    <td id="divAWFAmt" runat="server"  align="right">
                                        <asp:Label ID="lblAWFFareAdults" runat="server" Text="0"></asp:Label>
                                        
                                    </td>
                                    <td id="divCalcAWF" runat="server"  align="right">
                                       <b> <asp:Label ID="lblCalcAWF" runat="server" Text="0"></asp:Label></b>
                                    </td>
                                </tr>     
                                
                          <tr  id="trCWF" runat="server">
                                    <td>
                                        Child With South Veg Food</td>
                                    <td id="CWFACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblCWFfare" runat="server" Text="0"></asp:Label></td>
                                    <td id="CWFNonACFAre" runat="server" align="right">
                                        <asp:Label ID="lblCWFNACfare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoCWFNoOfChilds" runat="server" CssClass="inp" onkeypress="return chkNumeric(event);"
                                            onblur="Displayfare();" MaxLength="2" Columns="2" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" EnableViewState="False">0</asp:TextBox>
                                        </td>
                                    <td id="divCWFAmt" runat="server"  align="right">
                                        <asp:Label ID="lblCWFfareChild" runat="server" Text="0"></asp:Label>
                                        
                                    </td>
                                    <td id="divCalcCWF" runat="server"  align="right">
                                       <b> <asp:Label ID="lblCWFCalcChild" runat="server" Text="0"></asp:Label></b></td>
                                </tr>     
                               
                          <tr id="tra2f" runat="server">
                                    <td>
                                        Adult on Twin Sharing</td>
                                    <td id="divA2ACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblA2ACfare" runat="server" Text="0"></asp:Label></td>
                                    <td id="divA2NACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblA2NACfare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfAdultsTwin" runat="server" CssClass="inp" onkeypress="return chkNumeric(event);"
                                            onblur="validtwin();" MaxLength="2" Columns="2" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" EnableViewState="False">0</asp:TextBox>
                                        </td>
                                    <td  id="divAdultAmttwin" runat="server"  align="right">
                                        <asp:Label ID="lblFareAdultsTwin" runat="server" Text="0">  </asp:Label>
                                        
                                    </td>
                                    <td id="divCalcAdultTwin" runat="server"  align="right">
                                        <b><asp:Label ID="lblCalcAdultsTwin" runat="server" Text="0"></asp:Label></b>
                                    </td>
                                </tr>    
                               
                          <tr id="tra3f" runat="server">
                                    <td>
                                        Adult on Triple Sharing</td>
                                    <td id="divA3ACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblA3ACfare" runat="server" Text="0"></asp:Label></td>
                                    <td id="divA3NACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblA3NACfare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfAdultsTriple" runat="server" CssClass="inp" onkeypress="return chkNumeric(event);"
                                            onblur="validtriple();" MaxLength="2" Columns="2" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" EnableViewState="False">0</asp:TextBox>
                                        </td>
                                    <td id="divAdultAmttriple" runat="server"  align="right">
                                        <asp:Label ID="lblFareAdultsTriple" runat="server" Text="0"></asp:Label>
                                        
                                    </td>
                                    <td id="divCalcAdultTriple" runat="server"  align="right">
                                        <b><asp:Label ID="lblCalcAdultsTriple" runat="server" Text="0"></asp:Label></b></td>
                                </tr>
                           
                          <tr id="trcbsb" runat="server">
                                    <td>
                                        Child (2-5yrs) without seat &amp; Bed</td>
                                    <td id="divCBACSBFAre" runat="server"  align="right">
                                        <asp:Label ID="lblCBACSBfare" runat="server" Text="0"></asp:Label></td>
                                    <td id="divCBNACSBFAre" runat="server"  align="right">
                                        <asp:Label ID="lblCBNACSBfare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfChildBedSB" runat="server" CssClass="inp" onkeypress="return chkNumeric(event);"
                                            onblur="Displayfare();" MaxLength="2" Columns="2" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" EnableViewState="False">0</asp:TextBox>
                                        </td>
                                    <td id="divChildBedSBAmt" runat="server"   align="right">
                                        <asp:Label ID="lblFareChildBedSB" runat="server" Text="0"> </asp:Label>
                                        
                                    </td>
                                    <td id="divCalcChildBedSB" runat="server"  align="right">
                                        <b><asp:Label ID="lblCalcChildBedSB" runat="server" Text="0"></asp:Label></b>
                                    </td>
                                </tr>
                           <tr id="trcbf" runat="server">
                                    <td>
                                        Child(5-11)Without Bed</td>
                                    <td id="divCBACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblCBACfare" runat="server" Text="0"></asp:Label></td>
                                    <td id="divCBNACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblCBNACfare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfChildBed" runat="server" CssClass="inp" onkeypress="return chkNumeric(event);"
                                            onblur="Displayfare();" MaxLength="2" Columns="2" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" EnableViewState="False">0</asp:TextBox>
                                        </td>
                                    <td id="divChildBedAmt" runat="server"   align="right">
                                        <asp:Label ID="lblFareChildBed" runat="server" Text="0"> </asp:Label>
                                        
                                    </td>
                                    <td id="divCalcChildBed" runat="server"  align="right">
                                        <b><asp:Label ID="lblCalcChildBed" runat="server" Text="0"></asp:Label></b>
                                    </td>
                                </tr> 
                           <tr  id="tradf" runat="server">
                                    <td>
                                        Child With Bed</td>
                                    <td id="div1dormitory" runat="server"  align="right">
                                        <asp:Label ID="lbldACfare" runat="server" Text="0"></asp:Label></td>
                                    <td id="div2dormitory" runat="server"  align="right">
                                        <asp:Label ID="lbldNACfare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoofdormitory" runat="server" CssClass="inp" onkeypress="return chkNumeric(event);"
                                            onblur="Displayfare();" MaxLength="2" Columns="2" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" EnableViewState="False">0</asp:TextBox>
                                        </td>
                                    <td id="div3dormitory" runat="server"  align="right">
                                        <asp:Label ID="lblFaredormitory" runat="server" Text="0">  </asp:Label>
                                        
                                    </td>
                                    <td  id="div4dormitory" runat="server"  align="right">
                                        <b><asp:Label ID="lblCalcdormitory" runat="server" Text="0"></asp:Label></b>
                                    </td>
                                </tr>  
                                <tr id="trcbinf" runat="server">
                                    <td>
                                        Infant (0-2 yrs)</td>
                                    <td id="divCBACInfFAre" runat="server"  align="right">
                                        <asp:Label ID="lblCBACinffare" runat="server" Text="0"></asp:Label></td>
                                    <td id="divCBNACInfFAre" runat="server"  align="right">
                                        <asp:Label ID="lblCBNACinffare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfInfBed" runat="server" CssClass="inp" onkeypress="return chkNumeric(event);"
                                            onblur="Displayfare();" MaxLength="2" Columns="2" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" EnableViewState="False">0</asp:TextBox>
                                        </td>
                                    <td id="divInfChildBedAmt" runat="server"   align="right">
                                        <asp:Label ID="lblFareInfChildBed" runat="server" Text="0"> </asp:Label>
                                        
                                    </td>
                                    <td id="divCalcInfChildBed" runat="server"  align="right">
                                        <b><asp:Label ID="lblCalcInfChildBed" runat="server" Text="0"></asp:Label></b>
                                    </td>
                                </tr>
                          
                                
                          <tr id="trsf" runat="server">
                                    <td>
                                        Single Adult In a Room</td>
                                    <td id="divSACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblSACfare" runat="server" Text="0"></asp:Label></td>
                                    <td id="divSNACFAre" runat="server"  align="right">
                                        <asp:Label ID="lblSNACfare" runat="server" Text="0"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfSingles" runat="server" CssClass="inp" onkeypress="return chkNumeric(event);"
                                            onblur="Displayfare();" MaxLength="2" Columns="2" onfocus="javascript: if(this.value == '0'){ this.value = ''; }" EnableViewState="False">0</asp:TextBox>
                                        </td>
                                    <td id="divSingleAmt" runat="server"  align="right">
                                        <asp:Label ID="lblFareSingles" runat="server" Text="0"></asp:Label>
                                        
                                    </td>
                                    <td id="divCalcSingle" runat="server" align="right">
                                        <b><asp:Label ID="lblCalcSingles" runat="server" Text="0"></asp:Label></b></td>
                                </tr>
                          
                          <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Lblchild" runat="server" Text="Note: A Child above 5 years will be charged the same as an adult fare allotting a separate seat."></asp:Label>
                            
                            <br />
                            <asp:Label ID="LblTCSText" runat="server" Font-Bold="true" Text="Have you filed ITR (Income Tax Return) for last 2 years?" Visible="false"></asp:Label>&nbsp;<input type="checkbox" id="ChkFilledTCS" checked="checked" runat="server" visible="false" onclick="Displayfare();" />
                            <br />
                            <asp:Label ID="Labeltax" runat="server" style="color:#f1572b"></asp:Label>
                            <%--<br />
                            <asp:Label ID="lblServiceCharge" runat="server"></asp:Label>--%>
                            <br />
                            <asp:Label ID="lblLTC" runat="server" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:CheckBox ID="ChkTCS" runat="server" Checked="true" Visible="false" />
                            <asp:Label ID="LblChkTcs" runat="server" AssociatedControlID="ChkTCS" Visible="false">
                            <i>I agree with the <a target="_blank" href="International-Terms-Conditions.aspx" style="color:Red;"> International Tours Terms & Conditions</a></i>
                            </asp:Label>

                            </td>
                                    <td  align="right">
                                       <b> Total:</b>
                                    </td>
                                    <td id="divTotal" runat="server"  align="right">
                                         <b><asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></b></td>
                                </tr>
                                
                         
                          
                        </table>

                        
                   </div>
                   
                   <div class="btnwrap">
                   <%--<asp:ImageButton ID="btncheckavail" ImageUrl="images/check_availability.png" runat="server"
                                OnClick="btncheckavail_Click" />--%>
                            <asp:Button ID="btncheckavail" runat="server" CssClass="commonbtn" 
                                Text="Choose Seats"  OnClick="btncheckavail_Click"></asp:Button>
                       &nbsp;&nbsp;
                            <%--<asp:ImageButton ID="btnReset" ImageUrl="images/reset.png" runat="server" OnClick="btnReset_Click" />--%>
                            <asp:Button ID="btnReset" runat="server" Text="Reset"  OnClick="btnReset_Click"
                                CssClass="commonbtn transparentbtn" />
                                
                   
                   </div>
                    
                </div>
                 <!-- end amount table -->
                 
                 
                 <!-- seat selection -->
                  <asp:Panel ID="Panel4" runat="server" DefaultButton="btnContinuee">
                        
                    
                 <div class="seatselectwrap" id="colorindication" runat="server">
                 	
                    <h3 class="title">Seat <span>Selection</span>
                    <ul class="seatlist">
                    <li class="booked">Booked</li>
                    <li class="selected">Selected</li>
                    <li class="avail">Available</li>
                    </ul>
                       
                        
                       <%-- <div class="selectiondiv" >
                          <div class="frontsection">
                	
                    <div class="seat-d"><img src="images/seat-d.png"></div>
                    <div class="seat-c"><img src="images/seat-c.png"></div>
                    <div class="bus-entry"><img src="images/bus-entry.jpg"></div>
                    
                </div> <div class="backsection">
                <div class="bus-midspace">&nbsp;</div>--%>
                                <%if (Chart != null)
                                  {%>
                                <%=Chart.ToString()%>
                                <%} %>
                            <%--</div> 
                            
                        </div>--%>
                        
                        <div class="btnwrap">
                            <%--<a href="#">Continue Booking</a> <a class="transparent" href="#">Reset</a>
                            <asp:ImageButton ID="btnContinuee" ImageUrl="images/continue_booking.png" runat="server"
                                    Width="135" Height="24" OnClientClick="return checkseats();" OnClick="btnContinuee_Click" />
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="btnRe" ImageUrl="images/reset.png" runat="server" OnClick="btnReset_Click" />--%>
                                  <asp:Button ID="btnContinuee" runat="server" CssClass="commonbtn" 
                                Text="Continue Booking" OnClientClick="return checkseats();" OnClick="btnContinuee_Click"></asp:Button>
                            &nbsp;&nbsp;
                            <%--<asp:ImageButton ID="btnRe" ImageUrl="images/reset.png" runat="server" OnClick="btnReset_Click" />--%>
                            <asp:Button ID="btnRe" runat="server" Text="Reset"  OnClick="btnReset_Click"
                                CssClass="commonbtn transparentbtn" />
                        </div>
                        
                    </h3>
                    
                 </div>
                     
                    </asp:Panel>
                 <!-- end seat selection -->
                
                </asp:Panel>
                <!-- booking ststus -->
                <asp:Panel ID="Pnl2Step" runat="server" Visible="false" DefaultButton="CheckSubmit">
                <div class="bookingstatus">
                	  <input type="hidden" id="type" value="" runat="server" />
                                <input type="hidden" id="tmpEnValue" runat="server" />
                                
                                
                               
                    <div class="bookedcontent">
                    	
                        <div class="row">
                        <div class="col-md-6"><p><span>Booking Date :</span>  <asp:Label ID="lblbookingdate" CssClass="txtcolor" style="color:#000;" runat="server"></asp:Label></p>
                        <%--<p><span>Tour Name :</span> <asp:Label ID="lblTourName1"  CssClass="txtcolor" runat="server"></asp:Label></p>--%>
                        </div>
                        <div class="col-md-6">
                        <p class="txtright"><span>Adults :</span> <asp:Label ID="lblNoofAdults" style="color:#000;"  CssClass="txtcolor" runat="server" ></asp:Label></p>
						<p class="txtright"><span>Children :</span>  <asp:Label ID="lblNoofchild" style="color:#000;" CssClass="txtcolor" runat="server"></asp:Label></p>
                        </div>
                        </div>
                        
                    </div><div class="tablewrap">
                    <asp:GridView ID="dgtourdt" runat="server" AutoGenerateColumns="False" DataKeyField="Rowid" DataKeyNames="Rowid"
                                    Width="100%" 
                                    GridLines="None" AllowPaging="false"
                                    PageSize="20"  ShowFooter="false" CssClass="table-bordered tablepadding5" 
                              onrowcancelingedit="dgtourdt_RowCancelingEdit" 
                              onrowcommand="dgtourdt_RowCommand" onrowcreated="dgtourdt_RowCreated" 
                              onrowdatabound="dgtourdt_RowDataBound" onrowediting="dgtourdt_RowEditing" 
                              onrowupdated="dgtourdt_RowUpdated" onrowupdating="dgtourdt_RowUpdating" 
                              onrowdeleting="dgtourdt_RowDeleting" >
                                   
                                    <Columns>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkdelete" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField  DataField="TourName" ReadOnly="True" HeaderText="Tour Name" ></asp:BoundField>
                                        <asp:TemplateField HeaderText="Journey Date" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbldoj" runat="server" DataTextFormatString="{0:d}" Text='<%#DataBinder.Eval(Container.DataItem,"doj") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ReturnDate" ReadOnly="True" HeaderText="Return Date"
                                            DataFormatString="{0:d}">
                                        </asp:BoundField>
                                        <asp:BoundField Visible="False" DataField="dob" HeaderText="Booking Date" DataFormatString="{0:d}">
                                        </asp:BoundField>
                                         <asp:TemplateField  HeaderText="Departure Time">
                                            <ItemStyle VerticalAlign="Middle" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbldeparttime" runat="server" Text='<%#GetWAMBusType(Convert.ToString(DataBinder.Eval(Container.DataItem,"departtime")),Convert.ToString("9")) %>'></asp:Label>
                                            
                                              <%--<%#Convert.ToString(Eval("departtime"))%>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:BoundField DataField="departtime" ReadOnly="True" HeaderText="Departure Time"
                                           ></asp:BoundField>--%>
                                        <%--<asp:BoundField DataField="BusEnvType" ReadOnly="True" HeaderText="Bus Type" ></asp:BoundField>--%>
                                        
                                        <asp:TemplateField   >
                                        <HeaderTemplate><%# GetWAMBusType("Bus Type","1")%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        <asp:Label ID="LblBT" runat="server" Text='<%# GetWAMBusType(Convert.ToString(DataBinder.Eval(Container.DataItem,"BusEnvType")),Convert.ToString("2")) %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="noofadults" HeaderText="No. of Adults" Visible="False">
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="MinimumPay" HeaderText="Pay Only" Visible="true" ReadOnly="True"
                                            ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px" DataFormatString="{0:n}">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="totalamount" ReadOnly="True" HeaderText="Total Amount"
                                            ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px" DataFormatString="{0:n}">
                                        </asp:BoundField>--%>
                                        <asp:TemplateField  HeaderText="Pay Only" >
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                              <i class="fa fa-rupee"></i><%#Convert.ToString(Eval("MinimumPay", "{0:0,0}"))+"/-" %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Total Amount">
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                             <i class="fa fa-rupee"></i><%#Convert.ToString(Eval("totalamount", "{0:0,0}")) + "/-"%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle VerticalAlign="Middle" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" ImageUrl="Assets/images/edit.png" runat="server" ToolTip="Edit Tour"
                                                    CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'/>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField>
                                            <ItemStyle VerticalAlign="Middle" />
                                            <ItemTemplate>
                                               
                                              <asp:ImageButton ID="ImageButton1" ImageUrl="Assets/images/cross.png" runat="server" ToolTip="Delete Tour"
                                                    CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                            <%--                         <td><a href="#"><i class="fa fa-pencil"></i></a></td>
                            <td><a href="#"><i class="fa fa-close"></i></a></td>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                    
                    	

                    </div>
                    
                    <div><p class="notepara"><span>Note:</span> For hassle free booking, please complete 
                        your transaction within 20 minutes <span style="text-align:right; margin-left:95px"><b>
                        Grand Total :  <%=GrandTotal%></b></span></p>
                                    
                                      </div>
                    <div class="promocode">
                            	
                                <div class="input-group">
  <span>Promo code</span>
  <asp:TextBox CssClass="form-control" placeholder="Promo code" ID="promocode" type="text" name="promocode"
                             runat="server" MaxLength="10" oncopy="return false" ondrag="return false" ondrop="return false"
                                                                            onpaste="return false" autocomplete="off"  style=" height:42px;"  />
<asp:Label ID="lblPromoMsg" style="color:#000;"  CssClass="txtcolor" runat="server" ></asp:Label>                                                                            
  <span class="input-group-btn">
    <asp:Button ID="btnPromo" style="margin-top: 18px" runat="server" CssClass="commonbtn" Text="Apply" OnClientClick="return PromoCodeCHK()" 
                                        onclick="btnPromo_Click"></asp:Button>      
  </span>
  
</div>
                            </div>
                    <div class="btnwrapouter">
                    <div class="btnwrap pull-left">
                   	 <div class="bookanother">
                   	 <span>EmailID / Mobile No*</span>
                    <asp:TextBox ID="emailid"  CssClass="form-control" style=" height:42px;" placeholder="EmailID / Mobile No"  runat="server" MaxLength="145"></asp:TextBox>
                    
                    </div>
                    
                        <div class="submitbtn"> <asp:Button ID="CheckSubmit" style="margin-top: 21px" runat="server" CssClass="commonbtn" Text="Continue Booking" OnClick="CheckSubmit_Click"></asp:Button>                             
                    
                                                    <%--<asp:ImageButton ID="CheckSubmit" runat="server" ImageUrl="Assets/images/continue_booking.png"
                                                    OnClick="CheckSubmit_Click" Style="float: left;" />--%>
                                                <a href="#" onclick="javascript:fnFb();" style="display: none;">
                                                    <img alt="fblogin" border="0" src="Assets/images/fblogin.jpg" loading="lazy"/></a> </div>
                    </div>
                    
                    <div class="formwrap pull-right posrel mrgntop15" >
                        <div class="bookanother" style="margin-top: 21px">
                        
                         <asp:DropDownList ID="ddlTour"  CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlTour_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        
                        <%--<select class="form-control">
                        	<option>Book Another Tour Package</option>
                        </select>--%>
                        </div>
                        <div class="submitbtn">
                        <%--<asp:ImageButton ID="btngo" runat="server" ImageUrl="Assets/images/go.png" OnClick="btngo_Click1"
                                            Style="vertical-align: middle;" />--%>
<asp:Button ID="btngo" runat="server" style="margin-top: 21px" CssClass="form-control gobutton" Text="GO" OnClick="btngo_Click1"></asp:Button>                                                                         
                        <%--<input type="submit" class="form-control" value="GO">--%></div></div></div><div class="clearfix"></div>
                    
                </div>
                <!-- end booking ststus -->
                
                <!-- customer details -->
                 <%if ((emailid.Text != "" && emailid.Text != "Email ID / Mobile"))
                   {%>
                <div class="customerdtl">
                	
                    <h3 class="title">Customer Detail</h3><p class="notepara"><span>Note:</span> * 
                    Person filling up this form must be of above 18 years of age and should have any 
                    identification proof. (Indicate Required Field)</p>
                    <p class="notepara" style="color:Red; background-color:Yellow; padding:5px 5px 5px 5px;"> <strong>
                        ** Please select &quot;State&quot; carefully. State will not change after booking of 
                        ticket.</strong></p>
                    <div class="customerform">
                    	<div class="formwrap">
                        	<div class="row mrgnbtminput">
                            	<div class="col-md-6">
                                <div class="input-group">
                                <span>Title</span>
                     <asp:DropDownList ID="ddlTitle" runat="server" class="form-control" Width="88px">
                                                <asp:ListItem Text="Title" Value="Title"></asp:ListItem>
                                                <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                                <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                                <asp:ListItem Text="Miss." Value="Miss."></asp:ListItem>
                                                <asp:ListItem Text="Dr." Value="Dr."></asp:ListItem>
                                                <asp:ListItem Text="Prof." Value="Prof."></asp:ListItem>
                                            </asp:DropDownList>
                                            <label style="position: absolute; top: 0; left: 95px">Full Name*</label>
                                            <span class="input-group-btn">
                                            
                                             <asp:TextBox ID="txtName" style="margin-top: 14px"  Width="250px" MaxLength="35" CssClass="form-control" type="text" name="txtName"  placeholder="Full Name*"
                                                                runat="server" onkeypress="return CheckOnlyCharacter(event);" oncopy="return false"
                                                                ondrag="return false" ondrop="return false" onpaste="return false" autocomplete="off"
                                                                />
                                            </span></div>
                               
                                </div>
                                <div class="col-md-6">
                                <span>Email ID*</span>
                                <asp:TextBox ID="txtMail" MaxLength="145" type="text" name="Text1" runat="server" placeholder="Email ID*"
                                                                CssClass="form-control"  />
                                </div>
                            </div>
                            
                            <div class="row mrgnbtminput">
                            	<div class="col-md-6">
                                <span>Address*</span>
                                <asp:TextBox ID="txtAddress" MaxLength="150" placeholder="Address*" type="text" name="txtAddress" runat="server"
                                                                onkeypress="return CheckOnlyCharacteraddress(event);" oncopy="return false" ondrag="return false"
                                                                ondrop="return false" onpaste="return false" autocomplete="off" CssClass="form-control"
                                                                 />
                                <span class="suggest">Please avoid any special character.</span>
                                </div>
                                <div class="col-md-6">
                                            <span>Nationality*</span>  
                                            <asp:DropDownList runat="server" ID="ddlNationality" class="form-control">
                            </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mrgnbtminput">
                            	<div class="col-md-6">
                            	
                            	<span>Country</span>
                                 <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" 
                                        AutoPostBack="True" onselectedindexchanged="ddlCountry_SelectedIndexChanged" >
                                                            </asp:DropDownList>                            	
                               <%--AutoPostBack="True" onselectedindexchanged="ddlState_SelectedIndexChanged"--%>
                                </div>
                                <div class="col-md-6">
                                
                                <span>State**</span>
                                <div id="divState" runat="server">
                               <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" onchange="return clearCitylist();"></asp:DropDownList>                                
                               </div>
                               <asp:TextBox ID="TxtForeignState" runat="server" CssClass="form-control" Style="display: none"></asp:TextBox>
                                </div>
                            </div>
                             <div class="row">
                            	<div class="col-md-6">
                            	
                            	<span>City/District*</span>
                                 <%--<asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" >
                                                            </asp:DropDownList>--%>
                                                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" autocomplete="off" onkeyup="SetContextKey()"></asp:TextBox>
                                         <asp:HiddenField ID="hdnCity" runat="server" Value='' />
                                        <asp:HiddenField ID="hdnCityId" runat="server" Value='' />
                                        <asp:HiddenField ID="hdnStateIdBasedOnCity" runat="server" Value='' />
                                        <asp:Button ID="btnSetStateByCity" runat="server" style="display:none;" OnClick="btnSetStateByCity_Click" />
                                        <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="txtCity"
                                            ServicePath="" ServiceMethod="GetCity" MinimumPrefixLength="1" EnableCaching="false"
                                            CompletionListCssClass="completionList" CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="divwidth"
                                            OnClientPopulating="ShowProcessImage" OnClientPopulated="HideProcessImage" FirstRowSelected="false"
                                            OnClientItemSelected="OnClientSelectedCity" UseContextKey="True" /> 
                                            <asp:TextBox ID="txtForeignCity" runat="server" CssClass="form-control" Style="display: none"></asp:TextBox>                           	
                                
                                </div>
                                <div class="col-md-6">
                                
                                <span>Phone Number*</span>
                                 <asp:TextBox title="Put Country code" ID="txtPhoneCountryCode"  placeholder="Code*" onkeypress="return chkNumeric(event);"
                                                                MaxLength="3" size="2" type="text" name="txtPhoneCountryCode" runat="server"
                                                                CssClass="form-control" Style="width: 50px;" Visible="false" />
                                                              
                                                            <asp:TextBox ID="txtPhone" MaxLength="15" onkeypress="return chkNumeric(event);"  placeholder="Phone Number*"
                                                                size="15" type="text" name="txtPhone" runat="server" CssClass="form-control" />
                               <%-- <span class="suggest">Country Code - Phone No *</span>--%>
                                
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-md-6">
                            	<span>Whether registered under GST :</span>
                                                             
                                </div>
                                <div class="col-md-6">
                                 <asp:RadioButton ID="rdbIsGSTApplicableYes" GroupName="GST" OnCheckedChanged ="OnCheckChanged_rdbIsGSTApplicableYes" OnClick="return GSTHideUnhide('yes');"
                                runat="server" Text="Yes" />
                            <asp:RadioButton ID="rdbIsGSTApplicableNo" GroupName="GST" OnCheckedChanged ="OnCheckChanged_rdbIsGSTApplicableNo" OnClick="return GSTHideUnhide('no');"
                                Checked="true" runat="server" Text="No" />
                                </div>
                            </div>
                            <div class="row" style="display:none;" runat="server" id="divGSTDetails">
                            	<div class="col-md-6">
                            	<span>GSTIN Of Customer*</span>
                                 <asp:TextBox title="Customer GSTIN" ID="txtCustomerGSTIN"  placeholder="GSTIN Of Customer*"
                                                                type="text" name="txtCustomerGSTIN" runat="server"
                                                                CssClass="form-control"/></div>
                                <div class="col-md-6">
                                <span>Name of GST Holder*</span>
                                <asp:TextBox ID="txtGstHolderName" placeholder="Name of GST Holder*"
                                                                type="text" name="txtGstHolderName" runat="server"
                                                                CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-md-6">
                            	<span>Mobile No.*</span>
                                <asp:TextBox ID="txtMobile" MaxLength="10" placeholder="Mobile No.*"
                                                                type="text" name="txtMobile" onkeypress="return chkNumeric(event);" runat="server"
                                                                CssClass="form-control" />                               
                                </div>
                                <div class="col-md-6">
                                 <span>Emergency Contact No.*</span>
                                <asp:TextBox ID="txtAlternateMobileNo" MaxLength="15" placeholder="Emergency Contact No.*" size="10" type="text" name="txtAlternateMobileNo" onkeypress="return chkNumeric(event);"
                                                                runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            
                             <div class="row">
                            	<div class="col-md-6">
                            	<span>Aadhar No</span>
                                <asp:TextBox ID="txtAadharNo" MaxLength="12" placeholder="Aadhar No."
                                                                type="text" name="txtAadharNo" onkeypress="return chkNumeric(event);" runat="server"
                                                                CssClass="form-control" />                               
                                </div>
                                <div class="col-md-6">
                                 <span>Image Aadhar Card.</span>
                                 <asp:FileUpload ID="fupAadhar" runat="server" />
                                </div>
                            </div>
                            
                        </div>
                    </div>
                    
                    
                </div>
                <!-- end customer details -->
                
                <!-- customer payment detail -->
                 	<div class="custpaydetail">
                	
                    <h3 class="title">Customer's <span>Payment Detail</span></h3>
                    
                    <div class="row displaytable">
                    	<div class="col-md-12 displaycol leftsection">
                        	
                            
                            
                            <div class="paymentoption">
                            	
                                <h4>Payment Option</h4>
                                
                                <ul class="payoptionlist" >
                                
                                
                                    <li><asp:RadioButton CssClass="radiobtnwrap" ID="rbtnInstamojo" runat="server" Text="" GroupName="rdoPayment"
                                                         onclick="CardShow('divSubOpt',this);changeBank(this.value,'');AtomCardShow('tblAtom',this);" />
                                                         
                                                         <span>Credit Card/Debit Card/Net Banking/UPI/Wallets- Powered 
                                        by <asp:Image ID="Image5" runat="server" ImageUrl="~/Assets/images/instamojo-logo.png" Height="35px" ></asp:Image> </span>
                                                         
                                                         </li> 
                                                         
                                      <li><asp:RadioButton CssClass="radiobtnwrap" ID="rbtnPayu" runat="server" Text="" GroupName="rdoPayment"
                                                         onclick="CardShow('divSubOpt',this);changeBank(this.value,'');AtomCardShow('tblAtom',this);" />                                                         
                                                          <span>Credit Card/Debit Card/Net Banking/UPI/EMI/Wallets- 
                                          Powered by<asp:Image ID="Image6" runat="server" ImageUrl="~/Assets/images/payu.jpg" Height="35px" ></asp:Image> </span>
                                                         </li>    
                                
                                
                                
                                	<li style="display:none">
                                	
                                	<asp:RadioButton ID="rbtnAtom" CssClass="radiobtnwrap" runat="server" GroupName="rdoPayment"
                                               onclick="CardShow('divSubOpt',this);changeBank(this.value,'');AtomCardShow('tblAtom',this);" />
                                            <!-- Icon and text change section -->
                                            <span> Credit / Debit Card / Net Banking / EMI Options- Powered by <asp:Image ID="imgPaymentLogoAtom" runat="server" ImageUrl="~/Assets/images/atompayment.png" Height="35px" ></asp:Image> </span>
                                             <!-- End -->
                                    	
                                         <div class="sublistwrap ">
                                       		<table width="100%" border="0" style="display: none; " id="tblAtom" class="Atom">
                                                <tr>
                                                    <td >
                                        		 <table width="100%" border="0" >
                                                <tr>
                                                    <td >
                                                      
                                                            <asp:RadioButton ID="rdoAtomF" CssClass="radiobtnwrap" runat="server" Text="Full Payment" GroupName="rdoAtom"
                                                                 onclick="changeBank(this.value,'');AtomddlShow(this);SelectAtomMainPayment();" />
                                                    </td>
                                                    <td >
                                                            <asp:RadioButton ID="rdoAtom3" CssClass="radiobtnwrap" runat="server" Text="3 Month EMI" GroupName="rdoAtom"
                                                                 onclick="changeBank(this.value,'');AtomddlShow(this);SelectAtomMainPayment();" />
                                                        
                                                    </td>
                                                    <td >
                                                            <asp:RadioButton ID="rdoAtom6" CssClass="radiobtnwrap" runat="server" Text="6 Month EMI" GroupName="rdoAtom"
                                                                 onclick="changeBank(this.value,'');AtomddlShow(this);SelectAtomMainPayment();" />
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td >
                                                            <asp:RadioButton ID="rdoAtom9" CssClass="radiobtnwrap" runat="server" Text="9 Month EMI" GroupName="rdoAtom"
                                                                 onclick="changeBank(this.value,'');AtomddlShow(this);SelectAtomMainPayment();" />
                                                       
                                                    </td>
                                                    <td >
                                                            <asp:RadioButton ID="rdoAtom12" CssClass="radiobtnwrap" runat="server" Text="12 Month EMI" GroupName="rdoAtom"
                                                                 onclick="changeBank(this.value,'');AtomddlShow(this);SelectAtomMainPayment();" />
                                                        
                                                    </td>
                                                    <td style="
                                                        display: none;">
                                                        
                                                            <asp:RadioButton ID="rdoAtom18" CssClass="radiobtnwrap" runat="server" Text="18 Month EMI" GroupName="rdoAtom"
                                                                 onclick="changeBank(this.value,'');AtomddlShow(this);SelectAtomMainPayment();" />
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="display: none;">
                                                        
                                                            <asp:RadioButton ID="rdoAtom24" CssClass="radiobtnwrap" runat="server" Text="24 Month EMI" GroupName="rdoAtom"
                                                                 onclick="changeBank(this.value,'');AtomddlShow(this);SelectAtomMainPayment();" />
                                                        
                                                    </td>
                                                    <td colspan="4" style="border-bottom: 0px solid #FFFFFF !important; border-right: 0px solid #FFFFFF !important;">
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        		
                                              <div class="formwrap" Style="display: none;" id ="divAtomEMIBank">
                                              
                                              	
                                                <asp:DropDownList runat="server" class="form-control width250" ID="ddlAtomEMIBank"  Style="display: none;">
                                                            <asp:ListItem Selected="True" Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="CITI BANK" Value="CITI"></asp:ListItem>
                                                            <asp:ListItem Text="HDFC BANK" Value="HDFC"></asp:ListItem>
                                                            <asp:ListItem Text="KOTAK BANK" Value="KOTAK"></asp:ListItem>
                                                            <asp:ListItem Text="STANDARD CHARTERED BANK" Value="SCB"></asp:ListItem>
                                                        </asp:DropDownList>
                                              </div>  
                                        
                                        </td></tr></table>
                                            
										</div>	
                                        
                                    </li>
                                    
                                                
                                                         
                                                         
                                                         
                                    
                                    <li style="display:none;"> <asp:RadioButton ID="rdoNetBanking" CssClass="radiobtnwrap" runat="server" GroupName="rdoPayment"
                                                         onclick="CardShow('divSubOpt',this);changeBank(this.value,'');AtomCardShow('tblAtom',this);" />
                                                   <asp:Label
                                                        ID="lblPayment" runat="server" Text=""></asp:Label>
                                                        
                                                         <!-- Icon and text change section -->
                                            <span>Credit / Debit Card / Net Banking- Powered by <asp:Image ID="Image1" runat="server" ImageUrl="~/Assets/images/techprocesspayment.png" Height="40px" ></asp:Image> </span>
                                             <!-- End -->
                                                      
                                                        
                                                        
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
                                    <li> <asp:RadioButton ID="rdoDC" CssClass="radiobtnwrap" runat="server"  GroupName="rdoPayment"
                                                       onclick="CardShow('divSubOpt',this);changeBank(this.value,'');AtomCardShow('tblAtom',this);" />
                                                        
                                                         <!-- Icon and text change section -->
                                            <span> Debit Card- Powered by <asp:Image ID="Image2" runat="server" ImageUrl="~/Assets/images/hdfcpayment.png" Height="35px" ></asp:Image> </span>
                                             <!-- End -->
                                                       
                                                       
                                                        </li>
                                    
                                    <li><asp:RadioButton ID="rdoCCMs" CssClass="radiobtnwrap" runat="server" GroupName="rdoPayment"
                                                         onclick="CardShow('divSubOpt',this);changeBank(this.value,'');AtomCardShow('tblAtom',this);" />
                                                          <!-- Icon and text change section -->
                                            <span> Credit Card- Powered by <asp:Image ID="Image3" runat="server" ImageUrl="~/Assets/images/hdfcpayment.png" Height="35px" ></asp:Image> </span>
                                             <!-- End -->
                                    	
                                        <div class="sublistwrap" id="divSubOpt" style="display: none;">
                                        
                                        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="hdfc">
                                                <tr>
                                                    <td >
                                                            <asp:RadioButton ID="rdoCC" CssClass="radiobtnwrap" runat="server" Text="Full Payment" GroupName="rdoPayment1"
                                                                 onclick="changeBank(this.value,'');SelectHdfcMainPayment();" />
                                                    </td>
                                                    <td >
                                                            <asp:RadioButton ID="rbtnEMI3Month" CssClass="radiobtnwrap" runat="server" Text="3 Month EMI" GroupName="rdoPayment1"
                                                                 onclick="changeBank(this.value,'');SelectHdfcMainPayment();ShowPoup();" />
                                                       
                                                    </td>
                                                    <td >
                                                            <asp:RadioButton ID="rbtnEMI6Month" CssClass="radiobtnwrap" runat="server" Text="6 Month EMI" GroupName="rdoPayment1"
                                                                 onclick="changeBank(this.value,'');SelectHdfcMainPayment();ShowPoup();" />
                                                        <asp:Label ID="Label1" runat="server" Text="Info" class="orange" onmouseover="$find('PopExCC').showPopup();"
                                                            onmouseout="$find('PopExCC').hidePopup();" Style="cursor: pointer  !important;"></asp:Label><cc1:PopupControlExtender
                                                                ID="PopupControlExtender1" runat="server" BehaviorID="PopExCC" TargetControlID="Label1"
                                                                PopupControlID="Panel2" Position="Bottom">
                                                            </cc1:PopupControlExtender>
                                                        <asp:Panel ID="Panel2" runat="server" class="PopUp" BackColor="White" BorderWidth="1"
                                                            BorderColor="Red" Style="display: none; padding: 20px; z-index: 999;" Width="550px">
                                                            <div class="hPP" style="padding-top: 0px;" align="center">
                                                                <span class="orange24">EMI Details</span>
                                                                <div class="tPD top0" style="border: 0px; text-align: justify;">
                                                                    <ol>
                                                                        <%--<li>User would be charged a processing fee of 3% of the total amount
                                                                            <br />
                                                                            which he is paying towards the tour, by the bank. </li>--%>
                                                                        <li>The eligibility for EMI on your credit card is at the discretion of your<br />
                                                                            bank. Please check with your bank if unable to transact using EMI option.</li></ol>
                                                                </div>
                                                                <%----%>
                                                            </div>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                               
                                                </table>  
                                                 <p class="notepara">
                                                        ('GST applicable additionally on Interest amount' would suffice)</p>      
                                               <div class="tablewrap">
                                                            <table width="100%" cellspacing="0" cellpadding="0" border="0"  class="table-bordered rwd-table">
                                                                <tr>
                                                                    <th>
                                                                        Tenure
                                                                    </th>
                                                                    <th>
                                                                        Txn
                                                                        <br />
                                                                        Amount
                                                                    </th>
                                                                    <th>
                                                                        Merchant<br />
                                                                        Payback
                                                                    </th>
                                                                    <th>
                                                                        Loan
                                                                        <br />
                                                                        Amount
                                                                    </th>
                                                                    <th>
                                                                        EMI Finance
                                                                        <br />
                                                                        Charges (p.a.)
                                                                    </th>
                                                                    <th>
                                                                        EMI
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td data-th="Tenure">
                                                                        <asp:Label ID="Label8" runat="server" CssClass="txtcolor" Text="3 Month"></asp:Label>
                                                                    </td>
                                                                    <td data-th="Txn Amount">
                                                                        <asp:Label ID="lbl3EMIAMT" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td data-th="Merchant Payback">
                                                                    <td data-th="Category">
                                                                        <asp:Label ID="lbl3MarchPay" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td>
                                                                    <td data-th="Loan Amount"> 
                                                                        <asp:Label ID="lbl3LoanAmt" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td>
                                                                    <td data-th="EMI Finance Charges (p.a.)">
                                                                        <asp:Label ID="lbl3FinaAmt" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td>
                                                                    <td data-th="EMI">
                                                                        <asp:Label ID="lbl3EMIToAMT" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td data-th="Tenure">
                                                                        <asp:Label ID="Label9" runat="server" CssClass="txtcolor" Text="6 Month"></asp:Label>
                                                                        <%--<br /><span class="orange" style="margin-left: 13px;">(Processing Fee<br />3% Extra)</span>--%>
                                                                    </td>
                                                                    <td data-th="Txn Amount">
                                                                        <asp:Label ID="lblEMIToAmt" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td>
                                                                    <td data-th="Merchant Payback">
                                                                        <asp:Label ID="lbl6MarchPay" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td>
                                                                    <td data-th="Loan Amount">
                                                                        <asp:Label ID="lbl6LoanAmt" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td>
                                                                    <td data-th="EMI Finance Charges (p.a.)">
                                                                        <asp:Label ID="lbl6FinaAmt" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td>
                                                                    <td data-th="EMI">
                                                                        <asp:Label ID="lbl6EMIToAMT" runat="server" CssClass="txtcolor" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                          
                                            </table>
                                            
                                        

                                        
										</div>	
                                        </div>
                                    </li>
                                    
                                    <li ><asp:RadioButton ID="rdoamex" CssClass="radiobtnwrap" runat="server"  GroupName="rdoPayment" 
                                                         onclick="CardShow('divSubOpt',this);changeBank(this.value,'');AtomCardShow('tblAtom',this);" /> 
                                                          <!-- Icon and text change section -->
                                            <span>Amex Credit Card- Powered by <asp:Image ID="Image4" runat="server" ImageUrl="~/Assets/images/amexpayment.png" Height="35px" ></asp:Image> </span>
                                             <!-- End -->
                                              </li>           
                                                         
                                       
                                    <li ><asp:RadioButton ID="rdoRazorPay" CssClass="radiobtnwrap" runat="server"  GroupName="rdoPayment" 
                                                         onclick="CardShow('divSubOpt',this);changeBank(this.value,'');AtomCardShow('tblAtom',this);" /> 
                                                          <!-- Icon and text change section -->
                                            <span>Razorpay- Powered by <asp:Image ID="Image7" runat="server" ImageUrl="~/Assets/images/amexpayment.png" Height="35px" ></asp:Image> </span>
                                             <!-- End -->
                                              </li>       
                                                         
                                                                                    
                                </ul>
                                
                                
                                
                                
                                <ul class="chkboxlist">
                                <li>
                                
                                <asp:CheckBox ID="chkTrue" runat="server" class="inp"
                                                                                Text="" />
                                    I here by agree to the <a href="Terms-Conditions.aspx" target="_blank"><b>terms 
                                    &amp; conditions.</b></a>
                                                                                 
                                                                                 </li><li>
                                                                                 
                                                                                 <asp:CheckBox runat="server" ID="chkPromotions" /> I would like to be kept 
                                                                                 informed of special promotions and offers by Southern Travels through SMS, Email 
                                                                                 or phone.</li>
                                </ul>
                                
                                <div class="btnwrap">
                               <%-- <asp:ImageButton ID="Submit1" runat="server" ImageUrl="Assets/images/submit.png" CssClass="floatright"
                                                                            OnClick="btnOK_ServerClick" />--%>
                                	<asp:Button ID="Submit1" runat="server" CssClass="commonbtn" Text="Submit & Pay Now" OnClick="btnOK_ServerClick"></asp:Button>
                                	<%--<a href="#">Submit &amp; Pay Now</a>--%>
                                </div>
                                
                            </div>
                            
                            
                        </div>
                    </div>   
                       
                       <div class="row displaytable">
                       
                        <div class="col-md-12 displaycol rightsection">
                        	
                            <div class="weaccept">
                            	<h3>We Accept</h3>
                               
                               <p><img src="Assets/images/weaccept1.jpg" loading="lazy" alt="weaccept1"/> <img src="Assets/images/weaccept2.jpg" loading="lazy" alt="weaccept2"/> <img src="Assets/images/weaccept3.jpg" loading="lazy" alt="weaccept3"/> <img src="Assets/images/weaccept4.jpg" loading="lazy" alt="weaccept4"/> <img src="Assets/images/weaccept5.jpg" loading="lazy" alt="weaccept5"/> <img src="Assets/images/weaccept6.jpg" loading="lazy" alt="weaccept6"/> <img src="Assets/images/weaccept7.jpg" loading="lazy" alt="weaccept7"/> <img src="Assets/images/weaccept8.jpg" loading="lazy" alt="weaccept8"/> <img src="Assets/images/weaccept9.jpg" loading="lazy" alt="weaccept9"/></p>
                             
                                
                            </div>
                            
                        </div>
                       
                    </div>
                    
                    
                </div>
                
                
                  <%} %></asp:Panel>
                 </div>
                     <%--<div class="tab-pane" id="tab_inclexcl">Inclusions/Exclusions</div> --%>  
                       <div class="tab-pane  hidbookingnmobile" id="tab_tourinfo"> 
          	<h2 class="title showonmobile">Tour Info</h2>
          	<uc4:UCTourInfo ID="UCTourInfo1" runat="server" />
           
          </div>
          <div class="tab-pane  hidbookingnmobile" id="tab_tourPlaces"> 
          <h2 class="title showonmobile">Places Covered</h2>
          	<uc1:UCCityWisePlaceDisplay ID="UCCityWisePlaceDisplay1" runat="server" />
          	
           
          </div>
          
          <div class="tab-pane  hidbookingnmobile" id="tab_similar"> 
          <h2 class="title showonmobile">Similar Packages</h2>
          	<uc3:ucMatchingTour ID="ucMatchingTour1" runat="server" />
          	</div>
                        	
            <%--<div class="tab-pane" id="tab_terms">Terms</div>--%>
          
          
          
          <div class="tab-pane  hidbookingnmobile" id="tab_gallery">
           <h2 class="title showonmobile">Tour Gallery</h2>
          <uc5:UCTourGallery ID="UCTourGallery1" runat="server" /></div>
          
          <%--<div class="tab-pane" id="tab_testimonial">Testimonial</div>--%>
           </div></div></div>
           </section>
           
           
    <!-- Main Content End -->
    <!-- Footer Start -->
    <UCFooter:UCFooterEndUser ID="UCFooterEndUser1" runat="server" />
    <!-- Footer Start -->
    <asp:Panel ID="Panel3" runat="server" class="PopUp" BackColor="White" BorderWidth="1"
        BorderColor="Red" Style="display: none; padding: 20px;" Width="951px">
        <%--<div style="float: left;">
                                    <h1 class="orange24">
                                        Payment</h1>
                                </div>--%>
        <div style="float: right; margin-right: -30px; margin-top: -30px;">
            <asp:ImageButton runat="server" ID="lnkClose" ImageUrl="Assets/images/facebox/closelabel.png" OnClientClick="ClosePoup()" /></div>
        <%-- <asp:Panel ID="Panel3" runat="server" class="PopUp" BackColor="Silver" BorderWidth="1"
                            BorderColor="black" Style="display: none;" Width="925">
                            <div align="right" style="padding-right: 10px;">
                                <asp:LinkButton ID="lnkClose" runat="server" Font-Size="12pt" OnClick="lnkClose_Click">Close</asp:LinkButton>--%>
        <div class="hPP">
            <div class="tPD top0">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td height="30">
                            <input id="Radio1" type="radio" onclick="changeBank(this.value,'Allahabad Bank');"
                                name="rbPayOpt" value="280" />
                            <img src="Assets/images/allahabadbank.jpg" alt="Allahabad Bank" border="0" style="vertical-align: top"  loading="lazy"/>
                            Allahabad Bank
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle;">
                                <input id="Radio2" type="radio" onclick="changeBank(this.value,'AXIS Bank');" name="rbPayOpt"
                                    value="50" />
                                <img src="Assets/images/axis_bank.gif" alt="AXIS Bank" border="0" style="vertical-align: top" loading="lazy"/>
                                AXIS Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb19" type="radio" onclick="changeBank(this.value,'Bank of Bahrain and Kuwait');"
                                    name="rbPayOpt" value="340" />
                                <img src="Assets/images/Bank-of-Bahrain-and-Kuwait.jpg" alt="Bank of Bahrain and Kuwait" loading="lazy"
                                    border="0" style="vertical-align: top" />
                                Bank of Bahrain and Kuwait</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle;">
                                <input id="Radio3" type="radio" onclick="changeBank(this.value,'Bank of Baroda');"
                                    name="rbPayOpt" value="310" />
                                <img src="Assets/images/bob.jpg" alt="Bank of Baroda" border="0" style="vertical-align: middle"  loading="lazy"/>
                                Bank of Baroda</div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio4" type="radio" onclick="changeBank(this.value,'Bank of India');"
                                    name="rbPayOpt" value="240" />
                                <img src="Assets/images/bank_ofindia.gif" alt="Bank of India" border="0" style="vertical-align: top"  loading="lazy"/>
                                Bank of India
                            </div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio11" type="radio" onclick="changeBank(this.value,'Bank of Maharashtra');"
                                    name="rbPayOpt" value="750" />
                                <img src="Assets/images/Bank-of-Maharashtra.jpg" alt="Bank of Maharashtra" width="70px"
                                    height="24px" border="0" style="vertical-align: top"  loading="lazy"/>
                                Bank of Maharashtra
                            </div>
                        </td>
                        <%--<td>
                        <div align="left" style="vertical-align: middle">
                            <input id="Radio5" type="radio" onclick="changeBank(this.value,'Bank Of Rajesthan');" name="rbPayOpt"
                                value="170" />
                            <img src="Assets/images/bank_of_rajasthan.gif" alt=" Bank Of Rajesthan" border="0" style="vertical-align: middle" />
                            Bank Of Rajasthan
                        </div>
                    </td>
                    <td>
                        <div align="left" style="vertical-align: middle">
                            <input id="Radio6" type="radio" onclick="changeBank(this.value,'Corporation Bank');" name="rbPayOpt"
                                value="120" />
                            <img src="Assets/images/corp_bank.gif" alt="Corporation Bank" border="0" style="vertical-align: middle" />
                            Corporation Bank</div>
                    </td>--%>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank"  loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <%----%>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio5" type="radio" onclick="changeBank(this.value,'Beam Cash Card');"
                                    name="rbPayOpt" value="320" />
                                <img src="Assets/images/beam-cash-card.jpg" alt="Beam Cash Card" border="0" style="vertical-align: middle"  loading="lazy"/>
                                Beam Cash Card
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio6" type="radio" onclick="changeBank(this.value,'Central Bank of India');"
                                    name="rbPayOpt" value="740" />
                                <img src="Assets/images/Central-Bank-Of-India.jpg" alt="Central Bank of India" border="0"
                                    style="vertical-align: middle" loading="lazy" />
                                Central Bank of India
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb24" type="radio" onclick="changeBank(this.value,'Citi Bank');" name="rbPayOpt"
                                    value="230" />
                                <img src="Assets/images/Citi-Bank.jpg" alt="Citi Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                Citi Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio12" type="radio" onclick="changeBank(this.value,'City Union Bank');"
                                    name="rbPayOpt" value="440" />
                                <img src="Assets/images/City_Union_Bank.jpg" alt="City Union Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                City Union Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio25" type="radio" onclick="changeBank(this.value,'Canara Bank');"
                                    name="rbPayOpt" value="930" />
                                <img src="Assets/images/Canarabank_Logo.gif" alt="Canara Bank" border="0" style="vertical-align: middle"
                                    height="24" width="70" loading="lazy"/>
                                Canara Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio5" type="radio" onclick="changeBank(this.value,'Catholic Syrian Bank');"
                                    name="rbPayOpt" value="1130" />
                                <img src="Assets/images/csb.jpg" alt="Catholic Syrian Bank" border="0" style="vertical-align: middle" loading="lazy"
                                    height="24" width="70" />
                                Catholic Syrian Bank</div>
                        </td>
                        <%-- <td>
                                <div align="left" style="vertical-align: middle">
                                    <input id="Radio5" type="radio" onclick="changeBank(this.value,'DCB Bank');" name="rbPayOpt"
                                        value="540" />
                                    <img src="Assets/images/DCBlogo.jpg" alt="DCB Bank" border="0" style="vertical-align: middle"
                                        height="34" width="70" />
                                    DCB Bank</div>
                            </td>--%>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb17" type="radio" onclick="changeBank(this.value,'Deutsche Bank');" name="rbPayOpt"
                                    value="330" />
                                <img src="Assets/images/Deutsche-Bank.jpg" alt="Deutsche Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                Deutsche Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio13" type="radio" onclick="changeBank(this.value,'Development Credit Bank');"
                                    name="rbPayOpt" value="540" />
                                <img src="Assets/images/Development_Credit_Bank.jpg" alt="Development Credit Bank" border="0"
                                    style="vertical-align: middle" loading="lazy"/>
                                Development Credit Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb18" type="radio" onclick="changeBank(this.value,'Dhanlaxmi Bank');"
                                    name="rbPayOpt" value="370" />
                                <img src="Assets/images/Dhanlaxmi-Bank.jpg" alt="Dhanlaxmi Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                Dhanlaxmi Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio7" type="radio" onclick="changeBank(this.value,'Federal Bank');"
                                    name="rbPayOpt" value="270" />
                                <img src="Assets/images/fbllogo.jpg" alt="Federal Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                Federal Bank
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio8" type="radio" onclick="changeBank(this.value,'Hdfc Net Banking');"
                                    name="rbPayOpt" value="300" />
                                <img src="Assets/images/hdfcbank.jpg" alt="Hdfc Net Banking" border="0" style="vertical-align: middle" loading="lazy"/>
                                Hdfc Net Banking</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio14" type="radio" onclick="changeBank(this.value,'I-Cash Card');"
                                    name="rbPayOpt" value="460" checked="CHECKED" />
                                <img src="Assets/images/ICashCard.jpg" alt="I-Cash Card" border="0" style="vertical-align: middle" loading="lazy"/>
                                I-Cash Card</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio9" type="radio" onclick="changeBank(this.value,'ICICI Bank');" name="rbPayOpt"
                                    value="10" checked="CHECKED" />
                                <img src="Assets/images/icici_bank.gif" alt="ICICI Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                ICICI Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb25" type="radio" onclick="changeBank(this.value,'IDBI Bank');" name="rbPayOpt"
                                    value="520" />
                                <img src="Assets/images/IDBI-Bank.jpg" alt="IDBI Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                IDBI Bank
                            </div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio15" type="radio" onclick="changeBank(this.value,'Indian Bank');"
                                    name="rbPayOpt" value="490" />
                                <img src="Assets/images/Indian_Bank.jpg" alt="Indian Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                Indian Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio16" type="radio" onclick="changeBank(this.value,'Indian Overseas Bank');"
                                    name="rbPayOpt" value="420" />
                                <img src="Assets/images/Indian-Overseas-Bank.jpg" alt="Indian Overseas Bank" border="0"
                                    style="vertical-align: middle" loading="lazy"/>
                                Indian Overseas Bank</div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio17" type="radio" onclick="changeBank(this.value,'ING Vysya Bank');"
                                    name="rbPayOpt" value="830" />
                                <img src="Assets/images/ING-Vysya.jpg" alt="ING Vysya Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                ING Vysya Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio10" type="radio" onclick="changeBank(this.value,'J&amp;K Bank');"
                                    name="rbPayOpt" value="350" />
                                <img src="Assets/images/J-and-K-Bank.jpg" alt="J&amp;K Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                J&amp;K Bank</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy"/></div>
                        </td>
                    </tr>
                    <%--<td height="30">
                        <div align="left" style="vertical-align: middle">
                            <input id="Radio10" type="radio" onclick="changeBank(this.value,'Itz Cash Card');" name="rbPayOpt"
                                value="250" />
                            <img src="Assets/images/itz-cash.jpg" alt="Itz Cash Card" border="0" style="vertical-align: middle" />
                            Itz Cash Card</div>
                    </td>--%>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio24" type="radio" onclick="changeBank(this.value,'Kotak Mahindra bank');"
                                    name="rbPayOpt" value="910" />
                                <img src="Assets/images/Kotak_Logo.gif" alt="Kotak Mahindra bank" border="0" style="vertical-align: middle"
                                    height="24" width="70" loading="lazy"/>
                                Kotak Mahindra bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb20" type="radio" onclick="changeBank(this.value,'Karnataka Bank');"
                                    name="rbPayOpt" value="140" />
                                <img src="Assets/images/Karnataka-Bank.jpg" alt="Karnataka Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                Karnataka Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio18" type="radio" onclick="changeBank(this.value,'Karur Vysya Bank');"
                                    name="rbPayOpt" value="760" />
                                <img src="Assets/images/Karur_Vysya_Bank.jpg" alt="Karur Vysya Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                Karur Vysya Bank</div>
                        </td>
                        <%--<td>
                        <div align="left" style="vertical-align: middle">
                            <input id="rb13" type="radio" onclick="changeBank(this.value,'Oxicash');" name="rbPayOpt" value="220" />
                            <img src="Assets/images/oxi-cash.jpg" alt="Oxicash" border="0" style="vertical-align: middle" />
                            Oxicash</div>
                    </td>--%>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt=""  loading="lazy"/></div>
                        </td>
                    </tr>
                    <%--<td>
                        <div align="left" style="vertical-align: middle">
                            <input id="rb22" type="radio" onclick="changeBank(this.value,'Indian Overseas Bank');" name="rbPayOpt" value="420" />
                            <img src="Assets/images/Indian-Overseas-Bank.jpg" alt="Indian Overseas Bank" border="0" style="vertical-align: middle" />
                            Indian Overseas Bank</div>
                    </td>--%>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb12" type="radio" onclick="changeBank(this.value,'Oriental Bank Of Commerce');"
                                    name="rbPayOpt" value="160" />
                                <img src="Assets/images/orintal_bank.gif" alt="Oriental Bank Of Commerce" border="0" style="vertical-align: middle" loading="lazy"/>Oriental 
                                Bank Of Commerce</div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="rb14" type="radio" onclick="changeBank(this.value,'Punjab National Bank');"
                                    name="rbPayOpt" value="1220" />
                                <img src="Assets/images/PNB.JPG" alt="Punjab National Bank" border="0" style="vertical-align: middle" loading="lazy"
                                    height="24" width="70" />
                                Punjab National Bank
                            </div>
                        </td>
                        <td height="30">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio28" type="radio" onclick="changeBank(this.value,'South Indian Bank');"
                                    name="rbPayOpt" value="180" />
                                <img src="Assets/images/south_indian_bank.gif" alt="South Indian Bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                South Indian Bank
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb21" type="radio" onclick="changeBank(this.value,'Standard Chartered Bank');"
                                    name="rbPayOpt" value="450" />
                                <img src="Assets/images/Standard-Chartered-Bank.jpg" alt="Standard Chartered Bank" border="0"
                                    style="vertical-align: middle" loading="lazy"/>
                                Standard Chartered Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio19" type="radio" onclick="changeBank(this.value,'State Bank of Hyderabad');"
                                    name="rbPayOpt" value="560" />
                                <img src="Assets/images/State_Bank_of_Hyderabad.jpg" alt="State Bank of Hyderabad" border="0"
                                    style="vertical-align: middle" loading="lazy"/>
                                State Bank of Hyderabad
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb26" type="radio" onclick="changeBank(this.value,'State Bank of India');"
                                    name="rbPayOpt" value="530" />
                                <img src="Assets/images/sbi_logo_main.gif" alt="State Bank of India" border="0" style="vertical-align: middle" loading="lazy"/>
                                State Bank of India
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio26" type="radio" onclick="changeBank(this.value,'State Bank Of Bikaner and Jaipur');"
                                    name="rbPayOpt" value="950" />
                                <img src="Assets/images/State Bank of Bikaner.jpg" alt="State Bank Of Bikaner and Jaipur" loading="lazy"
                                    border="0" style="vertical-align: middle" width="70" width="24" />
                                State Bank Of Bikaner and Jaipur
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio27" type="radio" onclick="changeBank(this.value,'State Bank of Patiala');"
                                    name="rbPayOpt" value="880" />
                                <img src="Assets/images/State Bank of patiala.jpg" alt="State Bank of Patiala" border="0"
                                    style="vertical-align: middle" width="70" width="24" loading="lazy"/>
                                State Bank of Patiala
                            </div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio20" type="radio" onclick="changeBank(this.value,'State Bank of Mysore');"
                                    name="rbPayOpt" value="550" />
                                <img src="Assets/images/State_Bank_of_Mysore.jpg" alt="State Bank of Mysore" border="0"
                                    style="vertical-align: middle" loading="lazy"/>
                                State Bank of Mysore
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio22" type="radio" onclick="changeBank(this.value,'State Bank of Travencore');"
                                    name="rbPayOpt" value="680" />
                                <img src="Assets/images/State-Bank-of-Travencore.png" alt="State Bank of Travencore" width="70px"
                                    height="24px" border="0" style="vertical-align: middle" loading="lazy"/>
                                State Bank of Travencore</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio21" type="radio" onclick="changeBank(this.value,'Tamilnad Mercantile Bank');"
                                    name="rbPayOpt" value="620" />
                                <img src="Assets/images/Tamilnad_Mercantile_Bank.jpg" alt="Tamilnad Mercantile Bank" border="0"
                                    style="vertical-align: middle" loading="lazy"/>
                                Tamilnad Mercantile Bank</div>
                        </td>
                        <%--<td>
                        <div align="left" style="vertical-align: middle">
                            <input id="rb16" type="radio" onclick="changeBank(this.value);" name="rbPayOpt" value="130" />
                            <img src="Assets/images/yes_bank1.gif" alt="Yes bank" border="0" style="vertical-align: middle" />
                            Yes Bank</div>
                    </td>--%>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb23" type="radio" onclick="changeBank(this.value,'Union Bank of India');"
                                    name="rbPayOpt" value="190" />
                                <img src="Assets/images/Union-Bank-of-India.jpg" alt="Union Bank of India" border="0" style="vertical-align: middle" loading="lazy"/>
                                Union Bank of India</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div>
                                <img src="Assets/images/blank.gif" height="4" alt="blank" loading="lazy"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="rb15" type="radio" onclick="changeBank(this.value,'United Bank of India');"
                                    name="rbPayOpt" value="570" />
                                <img src="Assets/images/United-Bank-of-India.jpg" alt="United Bank of India" border="0"
                                    style="vertical-align: middle" loading="lazy"/>
                                United Bank of India</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio23" type="radio" onclick="changeBank(this.value,'Vijaya bank');"
                                    name="rbPayOpt" value="200" />
                                <img src="Assets/images/vijayabank.gif" alt="Vijaya bank" border="0" style="vertical-align: middle" loading="lazy"/>
                                Vijaya Bank</div>
                        </td>
                        <td>
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio30" type="radio" onclick="changeBank(this.value,'Visa Master Maestro Credit Card Gateway');"
                                    name="rbPayOpt" value="820" />
                                <img src="Assets/images/sbi_logo_main.gif" alt="Visa Master Maestro Credit Card Gateway" loading="lazy"
                                    border="0" style="vertical-align: middle" />
                                Visa Master Maestro Credit Card Gateway</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div align="left" style="vertical-align: middle">
                                <input id="Radio29" type="radio" onclick="changeBank(this.value,'Visa Master Maestro Debit Card Gateway');"
                                    name="rbPayOpt" value="1180" />
                                <img src="Assets/images/sbi_logo_main.gif" alt="Visa Master Maestro Debit Card Gateway" loading="lazy"
                                    border="0" style="vertical-align: middle" />
                                Visa Master Maestro Debit Card Gateway</div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <%--<cc1:ModalPopupExtender ID="mdlPopupFixed" runat="server" TargetControlID="rdoNetBanking"
            PopupControlID="Panel3" BackgdCssClass="modalBackground" CancelControlID="lnkClose"
            BehaviorID="mdlPopupFixed" />
        <%----%>
    <asp:Panel ID="Panel5" runat="server" class="PopUp" BackColor="White" BorderWidth="1"
        BorderColor="Red" Style="display: none; padding: 20px;" Width="300px">
        <%--<div style="float: right; margin-right: -30px; margin-top: -30px;">
                <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="facebox/closelabel.png"
                     /></div>--%>
        <div class="hPP">
            <div class="tPD top0" style="border: 0px;">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td height="15" align="center" style="font-size: 14px;">
                            <spna>EMI option is only valid for</spna>
                            <spna><b>HDFC credit card</b></spna>
                            <spna>customers.</spna>
                        </td>
                    </tr>
                    <tr>
                        <td height="15">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="15" align="center">
                            <asp:Button ID="btnAgree" runat="server" Text="I Agree" OnClientClick="javascript:return HideAlertAgree();" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnDisagreed" runat="server" Text="I Disagree" OnClientClick="javascript:return HideAlertDisAgree();" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <div id="lightboxOverlay-new"></div>
        <div id="videoModel-new">
    <div class="modelBody"> 
	  <div class="rightText">
<p>For hassle free booking, please complete your transaction within 20 minutes.</p>
<span class="close_N">OK</span>
	  </div>
    </div>
</div>

        <div id="videoModel-second">
  <div class="modelBody"> 
  <div class="rightText" >
<p style="font-size:1.3rem;"><strong>NOTE :</strong><br />
Helicopter tickets are issued by IRCTC through their online portal https://heliyatra.irctc.co.in/. The Capacity of each helicopter is only 5-6 seats and only 9 companies (one helicopter for each) are authorized to operate. Demand is very huge for Heli tickets but supply is limited. We make all the efforts to make the reservation of Helicopter tickets online on your behalf. However, because of the huge gap between demand and supply, sometimes we may not be able to reserve the Helicopter Tickets. In such cases, neither Southern Travels Pvt. Ltd nor its associates, take any responsibility for providing Helicopter Tickets and in such a situation, we would be refunding an amount of Rs. 5200/- towards the cost of the Helicopter Charges.<br />
In case of non-availability, pilgrims have an option of visiting the Shrine by walk/ pony/ doli at their cost for which our local representative will assist them. It is also clarified that in such circumstances, you will cooperate with the management and shall not raise any demands and or not file any complaint to the Consumer Court or any other courts for any compensation or damages.<br />
<br />
<strong>NOC :</strong><br />
I hereby certify that I have understood the booking process of ‘Helicopter Tickets’ for Kedarnath (in Chardham and Do-Dham Tours) and agree upon the same. I further certify that I will not file any complaints for seeking any relief in any Courts of Law.


</p>
<span class="close_N">Agree & Continue</span>
  </div>
  </div>
</div>

    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
    <cc1:ModalPopupExtender ID="mdlPopupFixed1" runat="server" TargetControlID="LinkButton1"
        PopupControlID="Panel5" BackgroundCssClass="modalBackground" CancelControlID="btnDisagreed"
        BehaviorID="mdlPopupFixed1" />
    <!-- body content end -->
    <!-- footer start -->
    <%--<uc:Footer runat="server" ID="ucFooter" />--%>
    <!-- footer end -->

<script type="text/javascript">
function MesgPopup_1(){
$('#videoModel-new').fadeIn(500);  

$(document).on('click','#videoModel-new .close_N', function(e){ 
  $("#videoModel-new").fadeOut(200);
  //$('#videoModel-second').fadeIn(500);
        //$('#lightboxOverlay-new').fadeOut(500);
    });
}
function MesgPopup(){       
        $('#videoModel-new').fadeIn(500);      
       $('#lightboxOverlay-new').fadeIn(300);  
    
$(document).on('click','#videoModel-new .close_N', function(e){ 
  $("#videoModel-new").fadeOut(200);
  $('#videoModel-second').fadeIn(500);
        //$('#lightboxOverlay-new').fadeOut(500);
    });

    $(document).on('click','#videoModel-second .close_N', function(e){ 
  $("#videoModel-second").fadeOut(200);
        $('#lightboxOverlay-new').fadeOut(500);
    });
      
}
</script>
    <script language="javascript" type="text/javascript">
        function ClosePoup() {
            document.getElementById('lblPayment').style.display = 'block';
            if (document.getElementById('hdBankName').value == '') {
                document.getElementById('lblPayment').innerHTML = "<span class=\"orange\">Selected Bank:</span> ICICI Bank";
            }
            else {
                document.getElementById('lblPayment').innerHTML = "<span class=\"orange\">Selected Bank:</span> " + document.getElementById('hdBankName').value;
            }
            //alert(document.getElementById('lblPayment').innerHTML);
            document.getElementById('rdoNetBanking').checked = true;
            document.getElementById('rdoCCMs').checked = false;
            document.getElementById('rdoamex').checked = false;
            //$find('mdlPopupFixed').hide();
            //return false;
        }
        function ShowPoup() {
            $find('mdlPopupFixed1').show();
            //return false;
        }
        function HideAlertAgree() {
            $find('mdlPopupFixed1').hide();
            return false;
        }
        function HideAlertDisAgree() {
            $find('mdlPopupFixed1').hide();
            document.getElementById('rdoCC').checked = true;
            document.getElementById('rbtnEMI3Month').checked = false;
            document.getElementById('rbtnEMI6Month').checked = false;
            return false;
        } 
    </script>

    <script language="javascript" type="text/javascript">
        function CalculateFinalAmount() {


            var TktAmt = document.getElementById('<%= hdAmount.ClientID%>').value;

            var STax = document.getElementById('<%= hdStax.ClientID %>').value;

            document.getElementById('<%= lbl3EMIAMT.ClientID %>').innerHTML = Math.round(TktAmt);
            document.getElementById('<%= lblEMIToAmt.ClientID %>').innerHTML = Math.round(TktAmt);


            var TotAmt = parseFloat(TktAmt) + Math.round(((parseFloat(TktAmt) * parseFloat(STax)) / parseFloat(100.00)));


            var lMPaybackPer = 0.85;
            var lMPaybackchrg3 = ((TktAmt * parseFloat(lMPaybackPer)) / 100.00)
            var lMPaybackchrg6 = 0.0;
            document.getElementById('<%= lbl3MarchPay.ClientID%>').innerHTML = (lMPaybackchrg3).toFixed(2);
            document.getElementById('<%= lbl6MarchPay.ClientID%>').innerHTML = (lMPaybackchrg6).toFixed(2);

            var lProcessing3 = parseFloat(0);
            var lProcessing6 = parseFloat(0);
            var lPFess3 = parseFloat((TktAmt * lProcessing3) / 100.00);
            var lPFess6 = parseFloat((TktAmt * lProcessing6) / 100.00);


            var P3 = parseFloat(TktAmt) + parseFloat(lPFess3) - parseFloat(lMPaybackchrg3);
            var P6 = parseFloat(TktAmt) + parseFloat(lPFess6) - parseFloat(lMPaybackchrg6);

            document.getElementById('<%= lbl3LoanAmt.ClientID%>').innerHTML = (P3).toFixed(2);
            document.getElementById('<%= lbl6LoanAmt.ClientID%>').innerHTML = (P6).toFixed(2);

            var R = 0.01166; var N3 = 3; var N6 = 6;

            document.getElementById('<%= lbl3FinaAmt.ClientID%>').innerHTML = '14%';
            document.getElementById('<%= lbl6FinaAmt.ClientID%>').innerHTML = '14%';

            var pvOne = 1;

            var C3 = (parseFloat(pvOne) / parseFloat(Math.pow((parseFloat(pvOne) + R), N3)));
            var B3 = parseFloat(pvOne) - C3;
            var RR3 = R / B3;
            document.getElementById('<%= lbl3EMIToAMT.ClientID%>').innerHTML = (P3 * RR3).toFixed(2);

            var C6 = (parseFloat(pvOne) / parseFloat(Math.pow((parseFloat(pvOne) + R), N6)));
            var B6 = parseFloat(pvOne) - C6;
            var RR6 = R / B6;
            document.getElementById('<%= lbl6EMIToAMT.ClientID%>').innerHTML = (P6 * RR6).toFixed(2);


        }
        function AtomddlShow(obj) {

            if (document.getElementById("rdoAtomF").checked) {
                document.getElementById('ddlAtomEMIBank').style.display = 'none';
                document.getElementById('divAtomEMIBank').style.display = 'none';
            }
            else {
                document.getElementById('ddlAtomEMIBank').style.display = 'block';
                document.getElementById('divAtomEMIBank').style.display = 'block';
            }
        }
    </script>

    <script language="javascript" type="text/javascript">
        CalculateFinalAmount();</script>

    <asp:Button ID="btnFaceBook_BookFixed" runat="server" Text="Button" OnClick="btnFaceBook_BookFixed_Click" />
    </form>

    <script src="Assets/js/jquery-scrolltofixed.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {

            initialize();
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

    <script type="text/javascript">
        window.onload = function() {
            var scrollY = parseInt('<%=Request.Form["scrollY"] %>');
            if (!isNaN(scrollY)) {
                window.scrollTo(0, scrollY);
            }
        };
        window.onscroll = function() {
            var scrollY = document.body.scrollTop;
            if (scrollY == 0) {
                if (window.pageYOffset) {
                    scrollY = window.pageYOffset;
                }
                else {
                    scrollY = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
                }
            }
            if (scrollY > 0) {
                var input = document.getElementById("scrollY");
                if (input == null) {
                    input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("id", "scrollY");
                    input.setAttribute("name", "scrollY");
                    document.forms[0].appendChild(input);
                }
                input.value = scrollY;
            }
        };
    </script>

    <script>
        $(function() {
            $('#tab_dateprice input[type=text]').each(function() {
                titleText = $(this).attr('placeholder');
                $(this).attr('title', '');
                $(this).attr('data-toggle', 'tooltip').tooltip({

                    placement: "right",
                    trigger: "focus"


                });


            });
        })
    </script>

    <script type="text/javascript">
        AtomCardShow('tblAtom', 'rdoCCMs');
        CardShow('divSubOpt', '');
    
    </script>

<asp:Literal ID="LitMesg" runat="server"></asp:Literal>
</body>
</html>
