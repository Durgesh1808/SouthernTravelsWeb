<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcFlightSearch.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcFlightSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript">
$(document).ready(function(){
 
        $(".slidingDiv1").hide();
        $(".show_hide1").show();
 
    $('.show_hide1').click(function(){
    $(".slidingDiv1").slideToggle();
    });
 
});
</script>
<div class="row btm10">
    <iframe src="/HtmlPages/southerntravels.htm" style="min-height:330px; min-width:283px; max-width:594px; border-style:none;" scrolling="no"  title="Southern Travel Hotels list"></iframe>
</div>
