<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTourCostIncludeExcIude.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcTourCostIncludeExcIude" %>

<div id="divCostInclude" runat="server">
    <div class="row rowgap">
        <div class="col-md-12">
            <h3 class="title">
                <span>Inclusions</span></h3>
                
                    <asp:Literal ID="ltrConstInclue" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h3 class="title">
                <span>Exclusions</span></h3>                
                    <asp:Literal ID="LtrCostExlude" runat="server"></asp:Literal>
        </div>
    </div>
</div>
