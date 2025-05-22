<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTourGallery.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcTourGallery" %>
<link href="Assets/css/ekko-lightbox.css" rel="stylesheet">
<style>
.packagebox {
        
        width: 229px;
        height:225px;
        border: 1px solid transparent;
        text-indent: -75%;
        overflow: hidden;
        text-align: center;
    }
   .packagebox .intlbox, .packagebox .intlbox .imgsection img{ border: none}
   
    .gallerybox img{ height: inherit!important; width: inherit!important; display: inline-block!important; max-width: inherit!important }
    .modal{ z-index: 99999}
   
     .packagebox2 {
        
        border: 1px solid transparent;
        
    }
     .packagebox2 img{
        
        width: 100%!important
        
    }
    .intlbox{margin-bottom: 15px;}
</style>
<asp:HiddenField ID="hdCount" runat="server" Value="0" />
<div class="row rowgap noterow" id="divMsg" runat="server" visib0le="false">
    <div class="col-md-12 text-center noterow">
        <p>
            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
           </p>
    </div>
</div>
<div class="row">
    <asp:Repeater ID="rptGallery" runat="server" 
        onitemdatabound="rptGallery_ItemDataBound">
        <ItemTemplate>
            <div class="col-md-6 gallerybox">
                <div class="packagebox2 posrel" >
                <div class="intlbox">
                   <a href='EntityImage/<%#Eval("ImagePath") %>' data-toggle="lightbox" data-gallery="multiimages" data-title="">
                        <div class="imgsection">
                            <img src='EntityImage/<%#Eval("ImagePath") %>' class="img-responsive" style="" >
                            <%--style="width: 229px; height: 239px"--%>
                        </div>
                     <%-- <%# Eval("ImageDescription").ToString().Replace("&nbsp;", "").Trim() == "" ? "" : "<div class=textsection><p>" + Eval("ImageDescription").ToString() + " </p></div>"%>--%>
                         
                       <%-- <%if(Eval("ImageDescription") ==""){ %>
                        <div class="textsection">
                         <p>
                               <%#Eval("ImageDescription") %>
                             </p>
                        </div>
                        <%} %>--%>
                    </a></div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

<script src="Assets/js/ekko-lightbox.js"></script>

<script type="text/javascript">
    $(document).ready(function($) {

        // delegate calls to data-toggle="lightbox"
       
        $(document).delegate('*[data-toggle="lightbox"]:not([data-gallery="navigateTo"])', 'click', function(event) {

            event.preventDefault();
            return $(this).ekkoLightbox({
                onShown: function() {
                    if (window.console) {
                        return console.log('Checking our the events huh?');
                    }
                },
                onNavigate: function(direction, itemIndex) {
                    if (window.console) {
                        return console.log('Navigating ' + direction + '. Current item: ' + itemIndex);
                    }
                }
            });
        });

        //Programatically call
        $('#open-image').click(function(e) {
            e.preventDefault();
            $(this).ekkoLightbox();

        });
        $('#open-youtube').click(function(e) {
            e.preventDefault();
            $(this).ekkoLightbox();
        });

        // navigateTo
        $(document).delegate('*[data-gallery="navigateTo"]', 'click', function(event) {
            event.preventDefault();

            var lb;
            return $(this).ekkoLightbox({
                onShown: function() {

                    lb = this;

                    $(lb.modal_content).on('click', '.modal-footer a', function(e) {

                        e.preventDefault();
                        lb.navigateTo(2);

                    });

                }
            });
        });
    });
    $(function() {
    
        //$('.presscoverage .col-md-4:nth-child(3n)').after('<div class="clearfix"></div>');

});
$(window).resize(function() {
    adjustModalMaxHeightAndPosition();
});
function adjustModalMaxHeightAndPosition() {
    $('.ekko-lightbox.modal').each(function() {
        var winHeight = $(window).height();

        $(this).find('.modal-dialog').css({
            'margin': 'auto',
            'margin-top': function() {
                var modalHeight = $(this).outerHeight(),
          marginHeight = modalHeight >= winHeight ? 'auto' : ((winHeight - modalHeight) / 2);
                return marginHeight;
            }
        });
    });
}
</script>

