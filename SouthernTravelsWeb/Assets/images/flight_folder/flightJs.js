
$(document).ready(function () {

    //*******************Calendar Fare*****************************************************//
    $('#CalendarWidget').click(function () {
        if (CalendarWidgetValidate()) {
            if ($('#DepartureMonth').val() < 10) {
                $('#fdepDate').val("01/0" + $('#DepartureMonth').val() + "/" + $('#DepartureYear').val());
            }
            else {
                $('#fdepDate').val("01/" + $('#DepartureMonth').val() + "/" + $('#DepartureYear').val());
            }
            $('#form1').attr("action", "http://flights.southerntravelsindia.com/CalendarFareSearch.aspx");
            $('#form1').submit();
        }
    });

    ////*******************JS for Flight*******************************************////

    $('#oneWay , #roundTrip , #multiStop , #calFare').click(function (e) {
        e.preventDefault();
        $('#calFareBtn_box').hide();
        $('#fSearchbtn_box').show();
        $('#errMess').hide();
        var id = this.id;
        if (id == 'roundTrip') {
            $('#multiStopDiv ,#calFareBtn_box, #calFareDatesDiv').hide();
            $('#onewayReturnDiv ,#retDate ,#onewayreturnform ,#fSearchbtn_box, #onewayReturnDatesDiv').show();
            $('#round_Trip').addClass('selected');
            $('#cal_Fare , #multi_Stop , #one_Way').removeClass('selected');
            $('#searchType').val("1");
            if ($('#DepDate').val() != "DD/MM/YYYY" && $('#DepDate').val() != "") {
                min = $('#DepDate').val();
                $("#ReturnDate").val(min);
                $("#ReturnDate").datepicker("option", "minDate", min);
            }
        }
        else if (id == 'multiStop') {
            $('#onewayReturnDiv ,#calFareBtn_box').hide();
            $('#multiStopDiv ,#onewayreturnform ,#fSearchbtn_box').show();
            $('#multi_Stop').addClass('selected');
            $('#round_Trip , #cal_Fare , #one_Way').removeClass('selected');
            $('#searchType').val("2");
        }
        else if (id == 'calFare') {
            $('#multiStopDiv ,#onewayReturnDatesDiv ,#fSearchbtn_box ,#onewayreturnform').hide();
            $('#onewayReturnDiv ,#calFareBtn_box, #calFareDatesDiv').show();
            $('#cal_Fare').addClass('selected');
            $('#round_Trip , #multi_Stop , #one_Way').removeClass('selected');
            $('#searchType').val("3");
        }
        else {
            $('#multiStopDiv ,#retDate ,#calFareBtn_box, #calFareDatesDiv').hide();
            $('#onewayReturnDiv, #fSearchbtn_box ,#onewayreturnform, #onewayReturnDatesDiv').show();
            $('#one_Way').addClass('selected');
            $('#round_Trip , #multi_Stop , #cal_Fare').removeClass('selected');
            $('#searchType').val("0");
        }
    });

    $('#addMoreMultiStop').click(function () {
        if (multiStopValidation()) {
            var i = parseInt($('#flightSegmentCounter').val()) + 1;
            $('#MultiStopSegment_' + i).show();
            $('#multiStopOrigin_' + i).val($('#multiStopDest_' + $('#flightSegmentCounter').val()).val());
            min = $('#multiStopDepDate_' + $('#flightSegmentCounter').val()).val();
            $("#multiStopDepDate_" + i).val(min);
            $("#multiStopDepDate_" + i).datepicker("option", "minDate", min);
            $('#flightSegmentCounter').val(i);
            if (parseInt($('#flightSegmentCounter').val()) == 3) {
                $('#multi-add').hide();
            }
        }

    });

    $('#removeMultiStop_2 , #removeMultiStop_3').click(function () {
        if (parseInt($('#flightSegmentCounter').val()) == 2) {
            $('#MultiStopSegment_2').hide();
            $('#flightSegmentCounter').val(parseInt($('#flightSegmentCounter').val()) - 1);
        }
        if (parseInt($('#flightSegmentCounter').val()) == 3) {
            $('#MultiStopSegment_3').hide();
            $('#flightSegmentCounter').val(parseInt($('#flightSegmentCounter').val()) - 1);
            $('#multi-add').show();
        }
    });

    $('#flightSearch , #originalSearch').click(function () {
        if (this.id == "flightSearch") {
            $('#fdepDate').val($('#DepDate').val());
            if ($('#searchType').val() == "2") {
                if (multiStopValidation()) {
                    $('#form1').attr("action", "http://flights.southerntravelsindia.com/SearchResults.aspx");
                    $('#form1').submit();
                }
            }
            else {
                if (validate()) {
                    if ($('#IsSpecialReturnAllowed').val() == "True" && $('#origin').val().indexOf('India') > 0 && $('#dest').val().indexOf('India') > 0 && ($('#searchType').val() == "0" || $('#promotionalPlanType').val() == "Normal")) {
                        $('#GrayBox').show();
                        $('#SplSrchBox').show();
                    }
                    else {
                        $('#form1').attr("action", "http://flights.southerntravelsindia.com/SearchResults.aspx");
                        $('#form1').submit();
                    }
                }
            }
        }
        else {
            $('#form1').attr("action", "http://flights.southerntravelsindia.com/SearchResults.aspx");
            $('#form1').submit();
        }
    });

    $('#specialReturnFares').click(function () {
        if ($('#searchType').val() == "0") {
            $('#promotionalPlanType').val("LCCSpecialReturn");
            $('#GrayBox ,#SplSrchBox').hide();
            $('#round_Trip').addClass('selected');
            $('#cal_Fare , #multi_Stop , #one_Way').removeClass('selected');
            $('#searchType').val("1");
            $('#retDate').show();
            $('#DepDate ,#ReturnDate').val("DD/MM/YYYY");
        }
        else {
            $('#promotionalPlanType').val("LCCSpecialReturn");
            if (validate()) {
                if ($('#IsSpecialReturnAllowed').val() == "True" && $('#origin').val().indexOf('India') > 0 && $('#dest').val().indexOf('India') > 0 && ($('#searchType').val() == "0" || $('#promotionalPlanType').val() == "Normal")) {
                    $('#GrayBox').show();
                    $('#SplSrchBox').show();
                }
                else {
                    $('#form1').attr("action", "http://flights.southerntravelsindia.com/SearchResults.aspx");
                    $('#form1').submit();
                }
            }
        }
    });

    ////**********************Calender related js***********************************************//
    var min = '0';
    $("#DepDate").datepicker({ minDate: min, maxDate: '+1Y',
        selectedDate: '0',
        dateFormat: 'dd/mm/yy',
        numberOfMonths: 1,
        closeText: '',
        onSelect: function () {
        },
        onClose: function (selectedDate) {
            $("#ReturnDate").datepicker("option", "minDate", selectedDate);
        }
    });

    $("#ReturnDate").datepicker({
        dateFormat: 'dd/mm/yy',
        numberOfMonths: 2,
        closeText: '',
        onClose: function (selectedDate) {
        }
    });
    $("#multiStopDepDate_1 ,#multiStopDepDate_2 ,#multiStopDepDate_3").datepicker({ minDate: min, maxDate: '+1Y', selectedDate: '0', dateFormat: 'dd/mm/yy', numberOfMonths: 2, showAnim: 'slideDown' });
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
    var clickId;
    var totalAutoComplete = 0;
    $('#origin , #dest ,#multiStopOrigin_1 , #multiStopOrigin_2 , #multiStopOrigin_3 ,#multiStopDest_1 , #multiStopDest_2 , #multiStopDest_3').keydown(function (e) {
        clickId = this.id;
        $(this).autocomplete(
            {
                source: function (request, response) {
                    $.ajax({
					    type: "POST",
                        url: "CityList.aspx",
                        data: "Type=FlightSearch&searchKey=" + request.term +"&requestFrom=FlightSearch",
                        success: function (data) {
                            resultKey = 0;
                            var list = data.split("/");
                            if (clickId == "origin") {
                                resultDESnew = originCount;
                                if (originCount == 0) {
                                    resultDESnew = resultCount + totalAutoComplete + 1;
                                    originCount = resultDESnew;
                                    totalAutoComplete = totalAutoComplete + 1;
                                }
                            }
                            if (clickId == "dest") {
                                resultDESnew = destCount;
                                if (destCount == 0) {
                                    resultDESnew = resultCount + totalAutoComplete + 1;
                                    destCount = resultDESnew;
                                    totalAutoComplete = totalAutoComplete + 1;
                                }
                            }
                            if (clickId == "multiStopOrigin_1") {
                                resultDESnew = multiStopOrigin_1Count;
                                if (multiStopOrigin_1Count == 0) {
                                    resultDESnew = resultCount + totalAutoComplete + 1;
                                    multiStopOrigin_1Count = resultDESnew;
                                    totalAutoComplete = totalAutoComplete + 1;
                                }
                            }
                            if (clickId == "multiStopOrigin_2") {
                                resultDESnew = multiStopOrigin_2Count;
                                if (multiStopOrigin_2Count == 0) {
                                    resultDESnew = resultCount + totalAutoComplete + 1;
                                    multiStopOrigin_2Count = resultDESnew;
                                    totalAutoComplete = totalAutoComplete + 1;
                                }
                            }
                            if (clickId == "multiStopOrigin_3") {
                                resultDESnew = multiStopOrigin_3Count;
                                if (multiStopOrigin_3Count == 0) {
                                    resultDESnew = resultCount + totalAutoComplete + 1;
                                    multiStopOrigin_3Count = resultDESnew;
                                    totalAutoComplete = totalAutoComplete + 1;
                                }
                            }
                            if (clickId == "multiStopDest_1") {
                                resultDESnew = multiStopDest_1Count;
                                if (multiStopDest_1Count == 0) {
                                    resultDESnew = resultCount + totalAutoComplete + 1;
                                    multiStopDest_1Count = resultDESnew;
                                    totalAutoComplete = totalAutoComplete + 1;
                                }
                            }
                            if (clickId == "multiStopDest_2") {
                                resultDESnew = multiStopDest_2Count;
                                if (multiStopDest_2Count == 0) {
                                    resultDESnew = resultCount + totalAutoComplete + 1;
                                    multiStopDest_2Count = resultDESnew;
                                    totalAutoComplete = totalAutoComplete + 1;
                                }
                            }
                            if (clickId == "multiStopDest_3") {
                                resultDESnew = multiStopDest_3Count;
                                if (multiStopDest_3Count == 0) {
                                    resultDESnew = resultCount + totalAutoComplete + 1;
                                    multiStopDest_3Count = resultDESnew;
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
                    resultKey = 1;
                    $(this).val(ui.item.label);
                    return false;
                },
                select: function (event, ui) {
                    $('#errMess').hide();
                    $(this).val(ui.item.label);
                    autoFocus = true;
                    resultKey = 1;
                    if (autoFocus) {
                        if (this.id == "dest") {
                            $('#DepDate').focus();
                        }
                        else if (this.id == "origin") {
                            $('#dest').focus();
                        }
                    }
                    return false;
                },
                change: function (event, ui) {
                    $('#errMess').hide();
                    if (clickId == "origin") {
                        resultDESnew = originCount;
                        if (originCount == 0) {
                            resultDESnew = resultCount + totalAutoComplete + 1;
                            originCount = resultDESnew;
                            totalAutoComplete = totalAutoComplete + 1;
                        }
                    }
                    if (clickId == "dest") {
                        resultDESnew = destCount;
                        if (destCount == 0) {
                            resultDESnew = resultCount + totalAutoComplete + 1;
                            destCount = resultDESnew;
                            totalAutoComplete = totalAutoComplete + 1;
                        }
                    }
                    if (clickId == "multiStopOrigin_1") {
                        resultDESnew = multiStopOrigin_1Count;
                        if (multiStopOrigin_1Count == 0) {
                            resultDESnew = resultCount + totalAutoComplete + 1;
                            multiStopOrigin_1Count = resultDESnew;
                            totalAutoComplete = totalAutoComplete + 1;
                        }
                    }
                    if (clickId == "multiStopOrigin_2") {
                        resultDESnew = multiStopOrigin_2Count;
                        if (multiStopOrigin_2Count == 0) {
                            resultDESnew = resultCount + totalAutoComplete + 1;
                            multiStopOrigin_2Count = resultDESnew;
                            totalAutoComplete = totalAutoComplete + 1;
                        }
                    }
                    if (clickId == "multiStopOrigin_3") {
                        resultDESnew = multiStopOrigin_3Count;
                        if (multiStopOrigin_3Count == 0) {
                            resultDESnew = resultCount + totalAutoComplete + 1;
                            multiStopOrigin_3Count = resultDESnew;
                            totalAutoComplete = totalAutoComplete + 1;
                        }
                    }
                    if (clickId == "multiStopDest_1") {
                        resultDESnew = multiStopDest_1Count;
                        if (multiStopDest_1Count == 0) {
                            resultDESnew = resultCount + totalAutoComplete + 1;
                            multiStopDest_1Count = resultDESnew;
                            totalAutoComplete = totalAutoComplete + 1;
                        }
                    }
                    if (clickId == "multiStopDest_2") {
                        resultDESnew = multiStopDest_2Count;
                        if (multiStopDest_2Count == 0) {
                            resultDESnew = resultCount + totalAutoComplete + 1;
                            multiStopDest_2Count = resultDESnew;
                            totalAutoComplete = totalAutoComplete + 1;
                        }
                    }
                    if (clickId == "multiStopDest_3") {
                        resultDESnew = multiStopDest_3Count;
                        if (multiStopDest_3Count == 0) {
                            resultDESnew = resultCount + totalAutoComplete + 1;
                            multiStopDest_3Count = resultDESnew;
                            totalAutoComplete = totalAutoComplete + 1;
                        }
                    }
                    if ($('#ui-id-' + resultDESnew + ' li:first')) {
                        if (arrowkey == 0 && resultKey == 0) {
                            if ($('#ui-id-' + resultDESnew + ' li:first').text() == "") {
                                $(this).val("Enter any city/airport");
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
                            if (this.id == "dest") {
                                $('#DepDate').focus();
                            }
                            else if (this.id == "origin") {
                                $('#dest').focus();
                            }
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

//***********************************Flight Validation********************************//

function validate() {
    if ($('#origin').val().trim() == "" || $('#origin').val() == 'Enter any city/airport' || $('#origin').val().trim() == 'No city found') {
        $('#errMess').show();
        $('#errorMessage').html("Please enter origin");
        return false;
    }
    if ($('#dest').val().trim() == "" || $('#dest').val() == 'Enter any city/airport' || $('#dest').val().trim() == 'No city found') {
        $('#errMess').show();
        $('#errorMessage').html("Please enter destination");
        return false;
    }
    if ($('#origin').val() == $('#dest').val()) {
        $('#errMess').show();
        $('#errorMessage').html("Origin and destination should be different");
        return false;
    }
    if (isNaN($('#dest').val()) == false) {
        $('#errMess').show();
        $('#errorMessage').html("Destination should not be numeric or blank");
        return false;
    }
    $('#showInternational').val("true");
    if (isNaN($('#dest').val()) == false) {
        $('errMess').show();
        $('errorMessage').html("Destination should not be numeric or blank");
        return false;
    }
    if (eval($('#adultCount').val()) < eval($('#infantCount').val())) {
        $('errMess').show();
        $('#errorMessage').html("Infant count should not be greater than adult count");
        return false;
    }
    if ($('#DepDate').val().trim() == 'DD/MM/YYYY' || $('#DepDate').val() == "") {
        $('#errMess').show();
        $('#errorMessage').html("Please enter correct departure date");
        return false;
    }
    if ($('#searchType').val() == "1")
    {
        if ($('#ReturnDate').val().trim() == 'DD/MM/YYYY' || $('#ReturnDate').val() == "") {
            $('#errMess').show();
            $('#errorMessage').html("Please enter correct return date");
            return false;
        }
    }
    if ($('#searchType').val() == "0") {

        $('#promotionalPlanType').val("Normal");
    }
    return true;
}

function multiStopValidation() {
    $('#errMess').hide();
    for (var i = 1; i <= $('#flightSegmentCounter').val(); i++) {
        if ($('#multiStopOrigin_' + i).val().trim() == "" || $('#multiStopDest_' + i).val().trim() == "") {
            $('#errMess').show();
            $('#errorMessage').html("Please fill both origin and destination for flight " + i);
            return false;
        }
        if ($('#multiStopOrigin_' + i).val() == 'Enter any city/airport' || $('#multiStopOrigin_' + i).val().trim() == 'No city found') {
            $('#errMess').show();
            $('#errorMessage').html("Please fill correct origin for flight " + i);
            return false;
        }
        if ($('#multiStopDest_' + i).val() == 'Enter any city/airport' || $('#multiStopDest_' + i).val().trim() == 'No city found') {
            $('#errMess').show();
            $('#errorMessage').html("Please fill correct destination for flight " + i);
            return false;
        }
        if ($('#multiStopOrigin_' + i).val() == $('#multiStopDest_' + i).val()) {
            $('#errMess').show();
            $('#errorMessage').html("Origin and destination should be different for flight " + i);
            return false;
        }
        if (isNaN($('#multiStopOrigin_' + i).val()) == false) {
            $('#errMess').show();
            $('#errorMessage').html("Origin should not be numeric or blank for flight " + i);
            return false;
        }
        if (isNaN($('#multiStopDest_' + i).val()) == false) {
            $('#errMess').show();
            $('#errorMessage').html("Destination should not be numeric or blank for flight " + i);
            return false;
        }
        if ($('#multiStopDepDate_' + i).val() == 'DD/MM/YYYY') {
            $('#errMess').show();
            $('#errorMessage').html("Please fill departure date for flight " + i);
            return false;
        }
    }
    if (parseInt($('#flightSegmentCounter').val()) == 2) {
        if ($('#multiStopDest_1').val() != $('#multiStopOrigin_2').val()) {
            $('#errMess').show();
            $('#errorMessage').html("Destination for flight 1 and origin for flight 2 must be same");
            return false;
        }
        if ($('#multiStopDest_2').val() == $('#multiStopOrigin_1').val()) {
            $('#errMess').show();
            $('#errorMessage').html("Destination for flight 2 and origin for flight 1 not be same");
            return false;
        }
    }
    if (parseInt($('#flightSegmentCounter').val()) == 3) {
        if ($('#multiStopDest_2').val() != $('#multiStopOrigin_3').val()) {
            $('#errMess').show();
            $('#errorMessage').html("Destination for flight 2 and origin for flight 3 must be same");
            return false;
        }
        if ($('#multiStopDest_3').val() == $('#multiStopOrigin_2').val()) {
            $('#errMess').show();
            $('#errorMessage').html("Destination for flight 3 and origin for flight 2 not be same");
            return false;
        }
    }
    return true;
}

function CalendarWidgetValidate() {
    if ($('#origin').val().trim() == "" || $('#dest').val().trim() == "") {
        $('#errMess').show();
        $('#errorMessage').html("Please fill both origin and destination");
        return false;
    }
    if ($('#origin').val().trim() == 'No city found') {
        $('#errMess').show();
        $('#errorMessage').html("Please fill correct origin");
        return false;
    }
    if ($('#dest').val().trim() == 'No city found') {
        $('#errMess').show();
        $('#errorMessage').html("Please fill correct destination");
        return false;
    }
    if ($('#origin').val() == $('#dest').val()) {
        $('#errMess').show();
        $('#errorMessage').html("origin and destination should be different");
        return false;
    }
    if (isNaN($('#dest').val()) == false) {
        $('#errMess').show();
        $('#errorMessage').html("Destination should not be numeric or blank");
        return false;
    }
    if (isNaN($('#origin').val()) == false) {
        $('#errMess').show();
        $('#errorMessage').html("Destination should not be numeric or blank");
        return false;
    }
    if (parseInt($('#DepartureMonth').val()) < parseInt(new Date().getMonth()) && parseInt($('#DepartureYear').val()) == parseInt(new Date().getFullYear())) {
        $('#errMess').show();
        $('#errorMessage').html("Please select a future date");
        return false;
    }

    return true;
}