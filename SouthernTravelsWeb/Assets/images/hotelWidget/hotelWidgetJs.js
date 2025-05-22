
$(document).ready(function () {

    ////**********************************JS for Hotel**************************************************************************////

    $('#HotelDomestic , #HotelIntl').click(function () {
        if (this.id == "HotelDomestic") {
            $('#HotelDomestic').prop("checked", true);
            $('#HotelIntl').prop("checked", false);
            $('#autocomplete2_Hotel').show();
            $('#selectDiv_Hotel').hide();
        }
        if (this.id == "HotelIntl") {
            $('#HotelDomestic').prop("checked", false);
            $('#HotelIntl').prop("checked", true);
            $('#selectDiv_Hotel').show();
            $('#autocomplete2_Hotel').hide();
        }
    });

    $("[id^=SelectList]").click(function () {
        var id = this.id;
        var w = screen.width / 2;
        var h = screen.height / 2;
        LeftPosition = (screen.width) ? ((screen.width - w) / 2 + 200) : 0;
        TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
        settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=yes,resizable=no';
        var remote = window.open("", 'cities', settings);
        remote.focus();
        if (this.id == "SelectListDomestic") {
            remote.location.href = 'http://flights.southerntravelsindia.com/hotelcityList.htm';
        }
        else {
            remote.location.href = 'http://flights.southerntravelsindia.com/HotelCountry.aspx';
        }
        window.addEventListener('message', function (e) {
            var message = e.data;
            if (message.indexOf("|") >= 0) {
                message = message.split("|");
                $('#destCity :selected').text(message[1] + "," + message[2]);
                $('#destCity :selected').val(e.data);

            }
            else {
                $('#city').val(message);
            }
        });
        if (remote.opener == null)
            remote.opener = window;
        remote.opener.name = "opener";
    });

    $('#NoOfRooms').change(function () {
        var count = eval($('#NoOfRooms').val());
        var prevCount = eval($('#PrevNoOfRooms').val());
        if (count > prevCount) {
            for (var i = (prevCount + 1); i <= count; i++) {
                $('#room-' + i).show();
                $('#adtRoom-' + i).val('1');
                $('#chdRoom-' + i).val('0');
                $('#PrevChildCount-' + i).val('0');
            }
        }
        else if (count < prevCount) {
            for (var i = prevCount; i > count; i--) {
                $('#room-' + i).hide();
                $('#adtRoom-' + i).val('1');
                $('#chdRoom-' + i).val('0');
                $('#PrevChildCount-' + i).val('0');
                $('#ChildBlock-' + i).hide();
                $('#ChildBlock-' + i + '-ChildAge-1').val('-1');
                $('#ChildBlock-' + i + '-ChildAge-2').val('-1');
            }
        }
        $('#PrevNoOfRooms').val(count);
    });

    $("[id^=chdRoom]").change(function () {
        var childId = this.id;
        var number = childId.substring((eval(childId.indexOf("-")) + 1), eval(childId.length));
        var childCount = eval($('#chdRoom-' + number).val());
        var PrevChildCount = eval($('#PrevChildCount-' + number).val());
        if (eval($('#chdRoom-1').val()) > 0 || eval($('#chdRoom-2').val()) > 0 || eval($('#chdRoom-3').val()) > 0 || eval($('#chdRoom-4').val()) > 0) {
            $('#childDetails').show();
        }
        else {
            $('#childDetails').hide();
            $('#hotel_deals1').show();
        }
        if (childCount > PrevChildCount) {
            $('#ChildBlock-' + number).show();
            for (var i = (PrevChildCount + 1); i <= childCount; i++) {
                $('#ChildBlock-' + number + '-Child-' + i).show();
                $('#ChildBlock-' + number + '-ChildAge-' + i).val('-1');
            }
        }
        else if (childCount < PrevChildCount) {
            if (childCount == 0) {
                $('#ChildBlock-' + number).hide();
                $('#ChildBlock-' + number + '-ChildAge-1').val('-1');
                $('#ChildBlock-' + number + '-ChildAge-2').val('-1');
                $('#ChildBlock-' + number + '-Child-1').hide();
                $('#ChildBlock-' + number + '-Child-2').hide();
            }
            else {
                for (var i = PrevChildCount; i > childCount; i--) {
                    if (i != 0) {
                        $('#ChildBlock-' + number + '-Child-' + i).hide();
                        $('#ChildBlock-' + number + '-ChildAge-' + i).val('-1');
                    }
                }
            }
        }
        $('#PrevChildCount-' + number).val(childCount);
    });

    $('#hotelSearch').click(function () {
        var loading = "<div   class=\"searching_container\">";
        loading += "<div  class=\"inner_container\">";
        loading += "<div  id=\"logoDisplay\"  class=\"searching_logo\">";
        loading += "<img src=\"<%=preference.Logo%>\"  alt=\"Logo\" />";
        loading += "</div> ";
        loading += " <div id =\"loading-img\" class=\"searching_logo\"></div> ";
        loading += "</div></div>";
        if (HotelValidations()) {
            var locationString;
            var logoimage;
            var loaderimage;
            if ($('#isDomesticHotel').val() == "true") {
                locationString = "<h1>We are searching for best hotels in  " + $('#city').val() + "</h1>";
            }
            else {
                var w = $('#destCity :selected').index();
                var selected_text = $('#destCity :selected').text();
                locationString = "<h1>We are searching for best hotels in  " + selected_text + "</h1>";
            }
            logoimage = $('#Logo').html();
            loaderimage = $('#load-img').html();
            locationString += "<p><span><b>Check-In</b> : " + $('#checkInDate').val() + "</span><span style=\"border: none;\"><b>Check-Out</b> :" + $('#checkOutDate').val();
            locationString += "</span></p><h2>Please wait. Do not close this window...</h2>";
            logoimage = $('#Logo').html();
            loaderimage = $('#load-img').html();
            $('#form1').attr("action", "http://flights.southerntravelsindia.com/HotelSearchResult.aspx");
            $('#form1').submit();
            $('body').html("");
            $('body').append($('<div/>', {
                id: 'holdy',
                style: 'float:left;width:100%;text-align:center;',
                html: loading
            }));
            $('#logoDisplay').html(logoimage + locationString);
            $('#loading-img').html(loaderimage);
            $('#form1').hide();

        }
    });

    $('#destCity').change(function (e) {
        $('#city').val($.trim($('#destCity option:selected').html()));

    });
    var totalnights = 1;
    $('#night_stay').keyup(function (e) {
        totalnights = parseInt(this.value);
        if ($('#checkInDate').val() != "" || $('#checkInDate').val() != "DD/MM/YYYY") {
            var minDates = $.datepicker.parseDate('dd/mm/yy', $('#checkInDate').val());
            minDates.setDate(minDates.getDate() + totalnights);
            $("#checkOutDate").datepicker("setDate", minDates);
        }
    });


    ////**********************Calender related js***********************************************//
    var min = '0';
    $("#checkInDate").datepicker({ minDate: min, maxDate: '+1Y', selectedDate: '0', dateFormat: 'dd/mm/yy', numberOfMonths: 1, closeText: '',
        onSelect: function () {
        },
        onClose: function (selectedDate) {
            $("#checkInDate").datepicker("setDate", selectedDate);
            var minDate = $(this).datepicker('getDate');
            if ($('#night_stay').val() == 0) {
                minDate.setDate(minDate.getDate() + 1);
            }
            else {
                minDate.setDate(minDate.getDate() + (eval($('#night_stay').val())));
            }
            $("#checkOutDate").datepicker("option", "minDate", minDate);
            $("#checkOutDate").datepicker("setDate", minDate);
            $('#checkOutDate').focus();
        }
    });

    $("#checkOutDate").datepicker({
        minDate: min,
        maxDate: '+1Y',
        dateFormat: 'dd/mm/yy',
        numberOfMonths: 1,
        closeText: '',
        showAnim: 'slideDown',
        onClose: function (selectedDate) {
            $('#night_stay').val(($("#checkOutDate").datepicker("getDate") - $("#checkInDate").datepicker("getDate")) / 1000 / 60 / 60 / 24); // days
            var minDate = $(this).datepicker('getDate');
            minDate.setDate(minDate.getDate() - eval($('#night_stay').val()));
            $("#checkInDate").datepicker("option", "minDate", minDate);
            $("#checkInDate").datepicker("setDate", minDate);
        }
    });
    
    $("#ui-datepicker-div").hide();



    ////**********************Js of Ajax hit**********************************//
    var arrowkey = 0;
    var autoFocus = false;
    var resultDESnew = 0;
    var resultKey = 0;
    var resultCount = 0;
    var originCount = 0;
    var destCount = 0;
    var multiStopOrigin_1Count = 0;
    var multiStopOrigin_2Count = 0;
    var multiStopOrigin_3Count = 0;
    var multiStopDest_1Count = 0;
    var multiStopDest_2Count = 0;
    var multiStopDest_3Count = 0;
    var cityCount = 0;
    var busSourceCount = 0;
    var clickId;
    var totalAutoComplete = 0;
    $('#city').keydown(function (e) {
        clickId = this.id;
        $(this).autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "HotelCityList.aspx",
                    data: "Type=HotelSearchDomestic&searchKey=" + request.term,
                    success: function (data) {
                        resultKey = 0;
                        var list = data.split("/");
                        if (clickId == "city") {
                            resultDESnew = cityCount;
                            if (cityCount == 0) {
                                resultDESnew = resultCount + totalAutoComplete + 1;
                                cityCount = resultDESnew;
                                totalAutoComplete = totalAutoComplete + 1;
                            }
                        }
                        resultCount = resultCount + list.length;
                        response(list);
                    },
                    error: function () { alert(arguments[2]); }
                });
            },
            minLength: 3,
            focus: function (event, ui) {
                $('#errMessHotel').hide();
                resultKey = 1;
                $(this).val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $('#errMessHotel').hide();
                $(this).val(ui.item.label);
                autoFocus = true;
                resultKey = 1;
                if (autoFocus) {
                    $('#checkInDate').focus();
                }
                return false;
            },
            change: function (event, ui) {
                $('#errMessHotel').hide();
                if (clickId == "city") {
                    resultDESnew = cityCount;
                    if (cityCount == 0) {
                        resultDESnew = resultCount + totalAutoComplete + 1;
                        cityCount = resultDESnew;
                        totalAutoComplete = totalAutoComplete + 1;
                    }
                }
                if ($('#ui-id-' + resultDESnew + ' li:first')) {
                    if (arrowkey == 0 && resultKey == 0) {
                        if ($('#ui-id-' + resultDESnew + ' li:first').text() == "") {
                            $(this).val("Enter domestic city");
                        }
                        else {
                            $(this).val($('#ui-id-' + resultDESnew + ' li:first').text());
                        }
                        autoFocus = true;
                    }
                    else {
                        if (ui.item != null && ui.item.label != null) {
                            $(this).val(ui.item.label);
                            autoFocus = true;
                        }
                    }
                    if (autoFocus) {
                        $('#checkInDate').focus();
                    }
                    return false;
                }
            }
        });

    });
});

function markout(textBox, txt) {
    if ($('#' + textBox.id).val() == "") {
        $('#' + textBox.id).val(txt);
    }
}
function markin(textBox, txt) {
    if ($('#' + textBox.id).val() == txt) {
        $('#' + textBox.id).val("");
    }
}

//***********************************Hotel Validation********************************//
function HotelValidations() {
    if ($('#city').val().indexOf("India") != -1) {
        $('#isDomesticHotel').val("true");
        if ($('#city').val() == null || $('#city').val().trim().length == 0) {
            $('#errMessHotel').show();
            $('#errMessHotel').html("Please Select Destination City");
            return false;
        }
        else if ($('#city').val() != null && $('#city').val() == 'Type Or Select From List') {
            $('#errMessHotel').show();
            $('#errMessHotel').html("Please Select Destination City");
            return false;
        }
        $('#destinationCity').val($('#city').val());
    }
    else {
        $('#isDomesticHotel').val("false");
        if ($('#city').val() == null || $('#city').val().trim().length == 0) {
            $('#errMessHotel').show();
            $('#errMessHotel').html("Please Select Destination City");
            return false;
        }
        else if ($('#city').val() != null && $('#city').val() == 'Type Or Select From List') {
            $('#errMessHotel').show();
            $('#errMessHotel').html("Please Select Destination City");
            return false;
        }
        if ($('#destCity :selected').val() == 'Type Or Select From List') {
            $('#destinationCity').val($('#city').val());
        }
        else {
            $('#destinationCity').val($('#destCity :selected').val());
            $('#destCitySelected').val("true");
        }

    }



    if ($('#checkInDate').val().trim() == 'DD/MM/YYYY' || $('#checkInDate').val() == "") {
        $('#errMessHotel').show();
        $('#errMessHotel').html("Please enter correct checkIn date");
        return false;
    }
    if ($('#checkOutDate').val().trim() == 'DD/MM/YYYY' || $('#checkOutDate').val() == "") {
        $('#errMessHotel').show();
        $('#errMessHotel').html("Please enter correct checkOut date");
        return false;
    }
    var rooms = $('#NoOfRooms').val();
    for (var k = 1; k <= parseInt(rooms); k++) {
        if ($("#chdRoom-" + k).val() != 0) {
            for (var m = 1; m <= parseInt($("#chdRoom-" + k).val()); m++) {
                if (parseInt($("#ChildBlock-" + k + "-ChildAge-" + m).val()) == -1) {
                    $('#errMessHotel').show();
                    $('#errMessHotel').html("Please Enter age of Child No. " + m + " of room No. " + k + ".!!");
                    return false;
                }
            }
        }
    } //end for

    if ($('#Nationality').val() == 'Select') {
        $('#errMessHotel').show();
        $('#errMessHotel').html("Please select nationality");
        return false;
    }
    return true;
}
