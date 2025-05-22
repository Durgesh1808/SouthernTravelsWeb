<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHotelInSouthern.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcHotelInSouthern" %>

   
<style type="text/css">
   
</style>
<!-- SweetAlert2 CSS & JS -->
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

<script type="text/javascript">


        $(function() {
            var checkInDate = $('#<%=txtCheckInDel.ClientID  %>');
            var checkOutDate = $('#<%=txtCheckOutDel.ClientID  %>');
            var dt = '';
            $("#<%=txtCheckInDel.ClientID  %>").datepicker({

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
                    $('#<%=txtCheckOutDel.ClientID  %>').datepicker('option', 'defaultDate', new Date(dt));
                    $("#<%=txtCheckOutDel.ClientID  %>").datepicker("option", "minDate", new Date(dt));
                    
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


            $("#<%=txtCheckOutDel.ClientID  %>").datepicker({
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

<script type="text/javascript">
    function isDate(dateStr, msg) {

        var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        var matchArray = dateStr.match(datePat); // is the format ok?

        if (matchArray == null) {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Please select ' + msg + ' date.',
                confirmButtonColor: '#f2572b'
            });
            return false;
        }

        day = matchArray[1]; // p@rse date into variables
        month = matchArray[3];
        year = matchArray[5];

        if (month < 1 || month > 12) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Month must be between 1 and 12 in dd/mm/yyyy format.',
                confirmButtonColor: '#f2572b'
            });
            return false;
        }

        if (day < 1 || day > 31) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Day must be between 1 and 31 in dd/mm/yyyy format.',
                 confirmButtonColor: '#f2572b'
            });
            return false;
        }

    }



    function getValidationInDel() {

        if (document.getElementById('bookHit')) {
            document.getElementById('bookHit').value = 'false';
        }
        var value = true;


        value = isDate(document.getElementById("<%=txtCheckInDel.ClientID %>").value, "Check In");
        if (value == false) {

            document.getElementById("<%=txtCheckInDel.ClientID %>").focus();
            //alert('Enter valid Date of Check-In');
            return false;
        }
        value = isDate(document.getElementById("<%=txtCheckOutDel.ClientID %>").value, "Check Out");
        if (value == false) {

            document.getElementById("<%=txtCheckOutDel.ClientID %>").focus();
            //alert('Enter valid Date of Check-Out');
            return false;
        }

        var CheckInDate = document.getElementById('<%=txtCheckInDel.ClientID %>').value;
        var CheckOutDate = document.getElementById('<%=txtCheckOutDel.ClientID %>').value;


        var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        var matchArrayChkIn = CheckInDate.match(datePat); // is the format ok?
        var matchArrayChkOut = CheckOutDate.match(datePat); // is the format ok?



        CheckInDay = matchArrayChkIn[1];
        CheckInMonth = matchArrayChkIn[3];
        CheckInYear = matchArrayChkIn[5];

        CheckOutDay = matchArrayChkOut[1];
        CheckOutMonth = matchArrayChkOut[3];
        CheckOutYear = matchArrayChkOut[5];

        var enddate = new Date(CheckOutYear, CheckOutMonth - 1, CheckOutDay);
        var startdate = new Date(CheckInYear, CheckInMonth - 1, CheckInDay);

        var difference = Date.UTC(enddate.getYear(), enddate.getMonth(), enddate.getDate(), 0, 0, 0) - Date.UTC(startdate.getYear(), startdate.getMonth(), startdate.getDate(), 0, 0, 0);
        var diff = difference / 1000 / 60 / 60 / 24;

        var today = new Date();
        var todate = today.getDate();
        var tomonth = today.getMonth();
        var toyear = today.getFullYear();
        var presentday = new Date(toyear, tomonth, todate);

      if (startdate < presentday) {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Check-in date should be later than today\'s date.',
                 confirmButtonColor: '#f2572b'
            }).then(() => {
                document.getElementById("<%=txtCheckInDel.ClientID %>").focus();
            });
            return false;
        }
        else if (enddate < presentday) {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Check-out date should be later than today\'s date.',
                 confirmButtonColor: '#f2572b'
            }).then(() => {
                document.getElementById("<%=txtCheckOutDel.ClientID %>").focus();
            });
            return false;
        }

       else if (CheckOutYear < CheckInYear) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Check Out date should be more than Check In date',
                     confirmButtonColor: '#f2572b'
                }).then(() => {
                    document.getElementById("<%=txtCheckOutDel.ClientID %>").focus();
                });
                return false;
            }

        else if ((CheckOutYear == CheckInYear) && (CheckOutMonth < CheckInMonth)) {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Check Out date should be more than Check In date',
                 confirmButtonColor: '#f2572b'
            }).then(() => {
                document.getElementById("<%=txtCheckOutDel.ClientID %>").focus();
            });
            return false;
        }


        else if ((CheckOutYear == CheckInYear) && (CheckOutMonth == CheckInMonth) && (CheckOutDay < CheckInDay)) {
            alert('Check Out date should be more than Check In date');
            document.getElementById("<%=txtCheckOutDel.ClientID %>").focus();
            return false;
        }
        else if (diff > 30) {
            alert("Sorry You Cannot Do  Booking For More Than 30 Days");
            document.getElementById("<%=txtCheckOutDel.ClientID %>").focus();
            return false;
        }
      if (document.getElementById("<%=ddlRoomDel.ClientID %>").value == "-1") {
            Swal.fire({
                icon: 'warning',
                text: 'Please select rooms.',
                 confirmButtonColor: '#f2572b'
            }).then(() => {
                document.getElementById("<%=ddlRoomDel.ClientID %>").focus();
            });
            chek = false;
            return false;
        }

      if (document.getElementById("<%=ddlAdultDel.ClientID %>").value == "-1") {
                Swal.fire({
                    icon: 'warning',
                    text: 'Please select Adults.',
                     confirmButtonColor: '#f2572b'
                }).then(() => {
                    document.getElementById("<%=ddlAdultDel.ClientID %>").focus();
                });
                chek = false;
                return false;
            }

    }
</script>

<div class="formwrap">
    <div class="row">
        <div class="col-md-12">
            <h4>
                When</h4>
        </div>
    </div>
    <div class="row mrgnbtminput">
        <div class="col-md-6">
            <div class="input-group" style="width:100% !important" >
                <asp:TextBox ID="txtCheckInDel" runat="server" ValidationGroup="Validation"   class="form-control"
                    placeholder="Check-in-date*" ></asp:TextBox>
               
                <%--<asp:RequiredFieldValidator ID="ReqCheckInDel" runat="server" ControlToValidate="txtCheckInDel"
                    ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="Validation"
                    Display="Dynamic"></asp:RequiredFieldValidator>--%>
            </div>
        </div>
        <div class="col-md-6">
            <div class="input-group " style="width:100% !important">
                <asp:TextBox ID="txtCheckOutDel" runat="server" ValidationGroup="Validation" class="form-control"
                    placeholder="Check-out-date*"></asp:TextBox>
               
                <%--<asp:RequiredFieldValidator ID="ReqCheckOutDel" runat="server" ControlToValidate="txtCheckOutDel"
                    ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="Validation"
                    Display="Dynamic"></asp:RequiredFieldValidator>--%>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h4>
                How many People</h4>
        </div>
    </div>
    <div class="row">
    <div class="col-md-3">
        <asp:DropDownList ID="ddlRoomDel" runat="server" CssClass="form-control">
            <asp:ListItem Value="-1" Selected="True">Rooms*</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col-md-4">
        <asp:DropDownList ID="ddlAdultDel" runat="server" CssClass="form-control">
            <asp:ListItem Value="-1" Selected="True">Adult (10+ yrs)</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col-md-5">
        <asp:DropDownList ID="ddlChildDel" runat="server" CssClass="form-control" onchange="Child1AgeSele(this);">
            <asp:ListItem Value="-1" Selected="True">Children (6-10 yrs)</asp:ListItem>
        </asp:DropDownList>
    </div>
</div>

    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnSearch" runat="server" Text="Book Now" alt="Book Now" ValidationGroup="Validation"
                OnClientClick="return getValidationInDel();" CausesValidation="true" OnClick="btnSearch_Click"
                class="btn pull-right" />
        </div>
    </div>
</div>
