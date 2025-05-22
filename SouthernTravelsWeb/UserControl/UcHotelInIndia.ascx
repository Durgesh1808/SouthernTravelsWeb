<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHotelInIndia.ascx.cs" Inherits="SouthernTravelsWeb.UserControl.UcHotelInIndia" %>
<link href="css/demos.css" rel="stylesheet" type="text/css" />
<link type="text/css" href="css/smoothness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
<%--<script src="css/Js/jquery-1.3.2.min.js" type="text/javascript"></script>--%>

<script src="css/Js/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>

<style type="text/css">
    .DatePickerImage
    {
        position: relative;
        padding-left: 5px;
    }
</style>

<script type="text/javascript">
//function pageLoad(sender, args) { 
var prm = Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(pageLoaded);
function pageLoaded(sender, args){        
        $(function()
        {
            var checkInDate = $('#<%=txtCheckIn.ClientID  %>');
            var checkOutDate = $('#<%=txtCheckOut.ClientID  %>');
            var dt ='';
		    $( "#<%=txtCheckIn.ClientID  %>" ).datepicker({
		    
		        numberOfMonths: 1,
			    showOn: "button",autoSize: true,
			    buttonImage: "images/date.gif",
			    buttonImageOnly: true,
			    minDate: new Date(),
			    closeText: 'Close',
			    dateFormat: 'dd/mm/yy',buttonText: 'Choose a Date',
			    onSelect: function(date) {
			    
			    dt = checkInDate.datepicker('getDate');
			    var Tow = dt;
                Tow.setDate(dt.getDate() + 1);//get yesterday's date
                //alert(Tow);
                $('#<%=txtCheckOut.ClientID  %>').datepicker('option', 'defaultDate',new Date(dt));
			    $( "#<%=txtCheckOut.ClientID  %>" ).datepicker( "option", "minDate", new Date(dt) );
			    $('img.ui-datepicker-trigger').css({'cursor' : 'pointer', "vertical-align" : 'top'});
			    $('img.ui-datepicker-trigger').addClass('DatePickerImage');     
			    },
			   onClose:  function clearEndDate(date, inst) {
			   
			    if(dt=='')
			    {
                    checkOutDate.val('');
			    }
			    else
			    {
			        var today = new Date(dt);
                    var dd = today.getDate();
                    var mm = today.getMonth()+1;//January is 0!
                    var yyyy = today.getFullYear();
                    if(dd<10){dd='0'+dd}
                    if(mm<10){mm='0'+mm}
                    
			   checkOutDate.val(dd+'/'+mm+'/'+yyyy);}}
		       
 	           			
		    });

	
		        $( "#<%=txtCheckOut.ClientID  %>" ).datepicker({
    		                numberOfMonths: 1,
			            //  maxDate:"+4Y",
			                buttonImage: "images/date.gif",
			                buttonImageOnly: true,
			                minDate: new Date(),dateFormat: 'dd/mm/yy', buttonText: 'Choose a Date',
    			            showOn: 'button',autoSize: true,
			                closeText: 'Close', onSelect: function() {}
			              
          }); 	   
           	$('img.ui-datepicker-trigger').css({'cursor' : 'pointer', "vertical-align" : 'top'});
           	$('img.ui-datepicker-trigger').addClass('DatePickerImage');
		});
	}
	 
	
	
</script>

<script language="javascript" type="text/javascript">
      function getValidation() {
      
      if(document.getElementById('bookHit'))
      {
         document.getElementById('bookHit').value = 'false';
      }
       var value=true; 
       
          
            if(document.getElementById("<%=ddlCity.ClientID %>").value=='0'|| document.getElementById("<%=ddlCity.ClientID %>").value=='')
             {
               
                    document.getElementById("<%=ddlCity.ClientID %>").focus();
		            alert('Please select City.');
		            return false;
                 
             }
          
          value=isDate(document.getElementById("<%=txtCheckIn.ClientID %>").value,"Check In");
          if(value==false)
	      {
		     
		      document.getElementById("<%=txtCheckIn.ClientID %>").focus();
		       //alert('Enter valid Date of Check-In');
		      return false;
	      }
	      value=isDate(document.getElementById("<%=txtCheckOut.ClientID %>").value,"Check Out");
	      if(value==false)
	      {
		     
		      document.getElementById("<%=txtCheckOut.ClientID %>").focus();
		       //alert('Enter valid Date of Check-Out');
		      return false;
	      }
	      
	        var	CheckInDate  = document.getElementById('<%=txtCheckIn.ClientID %>').value;
	        var CheckOutDate = document.getElementById('<%=txtCheckOut.ClientID %>').value;


            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
		    var matchArrayChkIn = CheckInDate.match(datePat); // is the format ok?
    	    var matchArrayChkOut = CheckOutDate.match(datePat); // is the format ok?
    	    
            

	        CheckInDay   = matchArrayChkIn[1];
	        CheckInMonth = matchArrayChkIn[3];
	        CheckInYear  = matchArrayChkIn[5];

	        CheckOutDay   = matchArrayChkOut[1];
	        CheckOutMonth = matchArrayChkOut[3];
	        CheckOutYear  = matchArrayChkOut[5];
          
            var enddate=new Date(CheckOutYear,CheckOutMonth-1,CheckOutDay);
            var startdate=new Date(CheckInYear,CheckInMonth-1,CheckInDay);

            var difference = Date.UTC(enddate.getYear(),enddate.getMonth(),enddate.getDate(),0,0,0)- Date.UTC(startdate.getYear(),startdate.getMonth(),startdate.getDate(),0,0,0);
            var diff=difference/1000/60/60/24;

            var today=new Date();
            var todate=today.getDate();
            var tomonth=today.getMonth();
            var toyear=today.getFullYear();
            var presentday=new Date(toyear,tomonth,todate);
            
            if(startdate<presentday)
  	        {
     		    alert("Check-in date should be higher than todays date");
     		    document.getElementById("<%=txtCheckIn.ClientID %>").focus();
     		    return false;
  	        }
  	        else if(enddate<presentday)
  	        {
     		    alert("Check-out date should be higher than todays date");
     		    document.getElementById("<%=txtCheckOut.ClientID %>").focus();
     		    return false;
  	        }
	      else  if (CheckOutYear<CheckInYear)
	        {
		        alert('Check Out date should be more than Check In date');
		        document.getElementById("<%=txtCheckOut.ClientID %>").focus();
		        return false;
	        }
	        else if((CheckOutYear==CheckInYear)&&(CheckOutMonth<CheckInMonth))
	        {
		        alert('Check Out date should be more than Check In date');
		        document.getElementById("<%=txtCheckOut.ClientID %>").focus();
		        return false;
	        }
	       
	        else if((CheckOutYear==CheckInYear)&&(CheckOutMonth==CheckInMonth)&&(CheckOutDay<CheckInDay))
	        {
		        alert('Check Out date should be more than Check In date');
		        document.getElementById("<%=txtCheckOut.ClientID %>").focus();
		        return false;
	        }
	        else if(diff>30)
  	        {
      		    alert("Sorry You Cannot Do  Booking For More Than 30 Days");
      		    document.getElementById("<%=txtCheckOut.ClientID %>").focus();
      		    return false;
  	        }
            
  	        
  	        // Child age select validation
  	        
  	        if(document.getElementById("<%=ddlChild1.ClientID %>").value=='1')
             {
                if(document.getElementById("<%=ddlChild1Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild1Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
            else  if(document.getElementById("<%=ddlChild1.ClientID %>").value=='2')
             {
                if(document.getElementById("<%=ddlChild1Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild1Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild1Age2.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild1Age2.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
             else  if(document.getElementById("<%=ddlChild1.ClientID %>").value=='3')
             {
                if(document.getElementById("<%=ddlChild1Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild1Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild1Age2.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild1Age2.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild1Age3.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild1Age3.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
             
            if(document.getElementById("<%=ddlChild2.ClientID %>").value=='1')
             {
                if(document.getElementById("<%=ddlChild2Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild2Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
            else  if(document.getElementById("<%=ddlChild2.ClientID %>").value=='2')
             {
                if(document.getElementById("<%=ddlChild2Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild2Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild2Age2.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild2Age2.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
             else  if(document.getElementById("<%=ddlChild2.ClientID %>").value=='3')
             {
                if(document.getElementById("<%=ddlChild2Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild2Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild2Age2.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild2Age2.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild2Age3.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild2Age3.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
             if(document.getElementById("<%=ddlChild3.ClientID %>").value=='1')
             {
                if(document.getElementById("<%=ddlChild3Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild3Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
            else  if(document.getElementById("<%=ddlChild3.ClientID %>").value=='2')
             {
                if(document.getElementById("<%=ddlChild3Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild3Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild3Age2.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild3Age2.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
             else  if(document.getElementById("<%=ddlChild3.ClientID %>").value=='3')
             {
                if(document.getElementById("<%=ddlChild3Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild3Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild3Age2.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild3Age2.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild3Age3.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild3Age3.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
            if(document.getElementById("<%=ddlChild4.ClientID %>").value=='1')
             {
                if(document.getElementById("<%=ddlChild4Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild4Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
            else  if(document.getElementById("<%=ddlChild4.ClientID %>").value=='2')
             {
                if(document.getElementById("<%=ddlChild4Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild4Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild4Age2.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild4Age2.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
             else  if(document.getElementById("<%=ddlChild4.ClientID %>").value=='3')
             {
                if(document.getElementById("<%=ddlChild4Age1.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild4Age1.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild4Age2.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild4Age2.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
                if(document.getElementById("<%=ddlChild4Age3.ClientID %>").value=='-1')
                 {
                    document.getElementById("<%=ddlChild4Age3.ClientID %>").focus();
		            alert('Please select child age');
		            return false;
                 }
             }
      }
      
         
        

       
       function Child1AgeSele(obj) {  
       
        
         if(obj.value=='1')
         {
        
             document.getElementById('<%=ddlChild1Age1.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild1Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild1Age3.ClientID %>').style.display="none";
             document.getElementById('<%=lblCRoom1.ClientID %>').style.display="block";
             
             document.getElementById("<%=ddlChild1Age1.ClientID %>").value='-1';  
          
            
             
         }
        else if(obj.value=='2')
         {
             document.getElementById('<%=lblCRoom1.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild1Age1.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild1Age2.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild1Age3.ClientID %>').style.display="none";
           
             document.getElementById("<%=ddlChild1Age2.ClientID %>").value='-1';
          
            
         }
         else if(obj.value=='3')
         {
             document.getElementById('<%=lblCRoom1.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild1Age1.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild1Age2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild1Age3.ClientID %>').style.display="block";
             
             document.getElementById("<%=ddlChild1Age3.ClientID %>").value='-1';
             
         }
         else
         {
             document.getElementById("<%=ddlChild1Age1.ClientID %>").value='-1'; 
             document.getElementById("<%=ddlChild1Age2.ClientID %>").value='-1';
             document.getElementById("<%=ddlChild1Age3.ClientID %>").value='-1';
             document.getElementById('<%=lblCRoom1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild1Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild1Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild1Age3.ClientID %>').style.display="none";
         }
         //chklblAgeShow();
       } 
       
      function Child2AgeSele(obj) {  
        
         if(obj.value=='1')
         {
            document.getElementById("<%=ddlChild2Age1.ClientID %>").value='-1'; 
            
             
             document.getElementById('<%=ddlChild2Age1.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild2Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild2Age3.ClientID %>').style.display="none";
             document.getElementById('<%=lblCRoom2.ClientID %>').style.display="block";
             
         }
        else if(obj.value=='2')
         {
           
             document.getElementById("<%=ddlChild2Age2.ClientID %>").value='-1';
             
            document.getElementById('<%=ddlChild2Age1.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild2Age2.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild2Age3.ClientID %>').style.display="none";
            document.getElementById('<%=lblCRoom2.ClientID %>').style.display="block";
         }
         else if(obj.value=='3')
         {
            
             document.getElementById("<%=ddlChild2Age3.ClientID %>").value='-1';
             document.getElementById('<%=ddlChild2Age1.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild2Age2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild2Age3.ClientID %>').style.display="block";
            document.getElementById('<%=lblCRoom2.ClientID %>').style.display="block";
             
         }
         else
         {
            document.getElementById("<%=ddlChild2Age1.ClientID %>").value='-1'; 
             document.getElementById("<%=ddlChild2Age2.ClientID %>").value='-1';
             document.getElementById("<%=ddlChild2Age3.ClientID %>").value='-1';
             document.getElementById('<%=ddlChild2Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild2Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild2Age3.ClientID %>').style.display="none";
             document.getElementById('<%=lblCRoom2.ClientID %>').style.display="none";
         }
         //chklblAgeShow();
       }
      function Child3AgeSele(obj) {  
        
         if(obj.value=='1')
         {
                document.getElementById('<%=lblCRoom3.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild3Age1.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild3Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3Age3.ClientID %>').style.display="none";
              document.getElementById("<%=ddlChild3Age1.ClientID %>").value='-1'; 
             
         }
        else if(obj.value=='2')
         {
            document.getElementById('<%=lblCRoom3.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild3Age1.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild3Age2.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild3Age3.ClientID %>').style.display="none";
            
             document.getElementById("<%=ddlChild3Age2.ClientID %>").value='-1';
         }
         else if(obj.value=='3')
         {
            document.getElementById('<%=lblCRoom3.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild3Age1.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild3Age2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild3Age3.ClientID %>').style.display="block";
          
             document.getElementById("<%=ddlChild3Age3.ClientID %>").value='-1';
             
         }
         else
         {
            document.getElementById("<%=ddlChild3Age1.ClientID %>").value='-1'; 
             document.getElementById("<%=ddlChild3Age2.ClientID %>").value='-1';
             document.getElementById("<%=ddlChild3Age3.ClientID %>").value='-1';
            document.getElementById('<%=lblCRoom3.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3Age3.ClientID %>').style.display="none";
         }
         //chklblAgeShow();
       }
       function Child4AgeSele(obj) {  
        
         if(obj.value=='1')
         {
            document.getElementById('<%=lblCRoom4.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild4Age1.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild4Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age3.ClientID %>').style.display="none";
             document.getElementById("<%=ddlChild4Age1.ClientID %>").value='-1'; 
             
         }
        else if(obj.value=='2')
         {
            document.getElementById('<%=lblCRoom4.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild4Age1.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild4Age2.ClientID %>').style.display="block";
            document.getElementById('<%=ddlChild4Age3.ClientID %>').style.display="none";
            
             document.getElementById("<%=ddlChild4Age2.ClientID %>").value='-1';
         }
         else if(obj.value=='3')
         {
             document.getElementById('<%=ddlChild4Age1.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild4Age2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild4Age3.ClientID %>').style.display="block";
            document.getElementById('<%=lblCRoom4.ClientID %>').style.display="block";
            
             document.getElementById("<%=ddlChild4Age3.ClientID %>").value='-1';
         }
         else
         {
            document.getElementById("<%=ddlChild4Age1.ClientID %>").value='-1'; 
             document.getElementById("<%=ddlChild4Age2.ClientID %>").value='-1';
             document.getElementById("<%=ddlChild4Age3.ClientID %>").value='-1';
         
            document.getElementById('<%=lblCRoom4.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age3.ClientID %>').style.display="none";
         }
         //chklblAgeShow();
       }
       
    
       
       
    function isDate(dateStr,msg)
    {
	
		    var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
		    var matchArray = dateStr.match(datePat); // is the format ok?
    	
	        if (matchArray == null  )
	        {
        		alert("Please select "+msg+" date.");
		        return false;
	        }
        	 day = matchArray[1]; // p@rse date into variables
	        month = matchArray[3];
	        year = matchArray[5];
	       
        	
	        if (month < 1 || month > 12) 
	        { // check month range
		        alert("Month must be between 1 and 12 in dd/mm/yyyy formate.");
		        return false;
	        }
        	
	        if (day < 1 || day > 31) 
	        {
		        alert("Day must be between 1 and 31 in dd/mm/yyyy formate.");
		        return false;
	        }
			}

	        function getredioCity(obj) {
       
           radioButtons = obj;
           var opt= radioButtons.getElementsByTagName('input');
           var index;
           
           
            for (var x = 0; x < opt.length; x ++) {

            
            var rbRef = opt[x];
            
             if (rbRef.checked)
             {
          // alert(rbRef.value);
                  if (rbRef.value=='Other City') {
                 
                      document.getElementById("<%=ddlCity.ClientID %>").value='0';
                      document.getElementById("<%= ddlCity.ClientID %>").disabled =false ;
                      
                  }
                  else{
                        document.getElementById("<%=ddlCity.ClientID %>").value='0';
                         document.getElementById('<%= ddlCity.ClientID %>').disabled = true;
                  }
                  index = x;
                  break;
              }
            }
			}
        
	 function MultiRoomSele() {  
        
        //alert(document.getElementById("<%=ddlRoom.ClientID %>").value);
         if(document.getElementById("<%=ddlRoom.ClientID %>").value=='2')
         {
              
             document.getElementById("<%=ddlAdult3.ClientID %>").value='1'; 
              document.getElementById("<%=ddlChild3.ClientID %>").value='0'; 
              
             document.getElementById('<%=lblRoom1.ClientID %>').style.display="block";
             
             
             document.getElementById('<%=lblRoom2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlAdult2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild2.ClientID %>').style.display="block";
             
             document.getElementById('<%=lblRoom3.ClientID %>').style.display="none";
             document.getElementById('<%=ddlAdult3.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3.ClientID %>').style.display="none";   
             
             document.getElementById('<%=lblRoom4.ClientID %>').style.display="none";
             document.getElementById('<%=ddlAdult4.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4.ClientID %>').style.display="none"; 
             
             document.getElementById('<%=ddlChild3Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3Age3.ClientID %>').style.display="none";
              
             document.getElementById('<%=ddlChild4Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age3.ClientID %>').style.display="none"; 
             
              document.getElementById('<%=lblCRoom3.ClientID %>').style.display="none";
              document.getElementById('<%=lblCRoom4.ClientID %>').style.display="none"; 
             
         }
         else if(document.getElementById("<%=ddlRoom.ClientID %>").value=='3')
         {
           
             document.getElementById('<%=lblRoom1.ClientID %>').style.display="block";
             document.getElementById("<%=ddlAdult4.ClientID %>").value='1'; 
              document.getElementById("<%=ddlChild4.ClientID %>").value='0'; 
               
             document.getElementById('<%=lblRoom2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlAdult2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild2.ClientID %>').style.display="block";
             
             document.getElementById('<%=lblRoom3.ClientID %>').style.display="block";
             document.getElementById('<%=ddlAdult3.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild3.ClientID %>').style.display="block";   
             
             document.getElementById('<%=lblRoom4.ClientID %>').style.display="none";
             document.getElementById('<%=ddlAdult4.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4.ClientID %>').style.display="none";  
             
             document.getElementById('<%=ddlChild4Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age3.ClientID %>').style.display="none";
             
              document.getElementById('<%=lblCRoom4.ClientID %>').style.display="none";
                          
         }
         else if(document.getElementById("<%=ddlRoom.ClientID %>").value=='4')
         {
            
             document.getElementById('<%=lblRoom1.ClientID %>').style.display="block";
            
              document.getElementById("<%=ddlAdult4.ClientID %>").value='1'; 
              document.getElementById("<%=ddlChild4.ClientID %>").value='0'; 
              
             document.getElementById('<%=lblRoom2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlAdult2.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild2.ClientID %>').style.display="block";   
             
             document.getElementById('<%=lblRoom3.ClientID %>').style.display="block";
             document.getElementById('<%=ddlAdult3.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild3.ClientID %>').style.display="block";    
             
             document.getElementById('<%=lblRoom4.ClientID %>').style.display="block";
             document.getElementById('<%=ddlAdult4.ClientID %>').style.display="block";
             document.getElementById('<%=ddlChild4.ClientID %>').style.display="block";
                                          
         }
         else
         {
           document.getElementById("<%=ddlChild1Age1.ClientID %>").value='-1';  
           document.getElementById("<%=ddlChild1Age2.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild1Age3.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild2Age1.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild2Age2.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild2Age3.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild3Age1.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild3Age2.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild3Age3.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild4Age1.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild3Age2.ClientID %>").value='-1';
           document.getElementById("<%=ddlChild4Age3.ClientID %>").value='-1';
             
             document.getElementById('<%=lblRoom1.ClientID %>').style.display="none";
            
           // alert(document.getElementById('ddlAdult1').value);
             document.getElementById('<%=ddlAdult1.ClientID %>').value="1";
             document.getElementById('<%=ddlAdult2.ClientID %>').value="1";
             document.getElementById('<%=ddlAdult3.ClientID %>').value="1";
             document.getElementById('<%=ddlAdult4.ClientID %>').value="1";
             
             document.getElementById('<%=ddlChild1.ClientID %>').value="0";
             document.getElementById('<%=ddlChild2.ClientID %>').value="0";
             document.getElementById('<%=ddlChild3.ClientID %>').value="0";
             document.getElementById('<%=ddlChild4.ClientID %>').value="0";
             
             document.getElementById('<%=lblRoom2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlAdult2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild2.ClientID %>').style.display="none";
             
             document.getElementById('<%=lblRoom3.ClientID %>').style.display="none";
             document.getElementById('<%=ddlAdult3.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3.ClientID %>').style.display="none"; 
             
             document.getElementById('<%=lblRoom4.ClientID %>').style.display="none";
             document.getElementById('<%=ddlAdult4.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4.ClientID %>').style.display="none";
             
             document.getElementById('<%=ddlChild1Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild1Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild1Age3.ClientID %>').style.display="none";
              
             document.getElementById('<%=ddlChild2Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild2Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild2Age3.ClientID %>').style.display="none";
              
             document.getElementById('<%=ddlChild3Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild3Age3.ClientID %>').style.display="none";
              
             document.getElementById('<%=ddlChild4Age1.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age2.ClientID %>').style.display="none";
             document.getElementById('<%=ddlChild4Age3.ClientID %>').style.display="none";
            
            document.getElementById('<%=lblCRoom1.ClientID %>').style.display="none";
             document.getElementById('<%=lblCRoom2.ClientID %>').style.display="none";
             document.getElementById('<%=lblCRoom3.ClientID %>').style.display="none";
             document.getElementById('<%=lblCRoom4.ClientID %>').style.display="none"; 
                          
         }
         //chklblAgeShow();
       }  
    
        /*function chklblAgeShow() {  
           
            if(document.getElementById('ddlChild1').value!="0" || document.getElementById('ddlChild2').value!="0" || document.getElementById('ddlChild3').value!="0" || document.getElementById('ddlChild4').value!="0")
            {
                   
                 document.getElementById('lblChildAge1').style.display="block";
            }
            else
            {
                document.getElementById('lblChildAge1').style.display="none";
            }
        
        }*/
</script>

<div class="row btm25">
    <div class="left_ico">
        <img src="images/ico_flag.gif" width="23" height="26" alt="&gt;" loading="lazy" /></div>
    <div class="rhtForm">
        <div class="head">
            Where</div>
        <div class="field">
            <asp:DropDownList ID="ddlCity" runat="server" class="sel" ValidationGroup="Validation">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCity"
                ErrorMessage="Required Field." InitialValue="0" SetFocusOnError="True" ValidationGroup="Validation"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>
</div>
<div class="row btm25">
    <div class="left_ico">
        <img src="images/ico_watch.gif" width="21" height="21" alt="&gt;" loading="lazy" /></div>
    <div class="rhtForm">
        <div class="head bdrBtm1">
            When</div>
        <div class="row">
            <div class="floatleft right25">
                <div class="subHead">
                    Check-in Date<span class="orange">*</span></div>
                <div class="field">
                    <span class="date">
                    
                <asp:TextBox ID="txtCheckIn" runat="server" Width="70px"  ValidationGroup="Validation"  class="inpt"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="ReqCheckIn" runat="server" ControlToValidate="txtCheckIn"
                    ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="Validation"
                    Display="Dynamic"></asp:RequiredFieldValidator>
                      <asp:Label ID="lblErr" runat="server" Text="" ForeColor="Red"></asp:Label></span>
                </div>
            </div>
            <div class="floatleft">
                <div class="subHead">
                    Check-out Date<span class="orange">*</span></div>
                <div class="field">
                    <span class="date">
                     
                    <asp:TextBox ID="txtCheckOut" runat="server" Width="70px" CssClass="inpt" ValidationGroup="Validation"></asp:TextBox>
                
                    <asp:Label ID="lblErr1" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <asp:RequiredFieldValidator ID="ReqCheckOut" runat="server" ControlToValidate="txtCheckOut"
                        ErrorMessage="Required Field." SetFocusOnError="True" ValidationGroup="Validation"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                        
                             
                              </span>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row btm25">
    <div class="left_ico">
        <img src="images/ico_people.gif" width="20" height="21" alt="&gt;" loading="lazy"/></div>
    <div class="rhtForm">
        <div class="head bdrBtm1">
            How many People</div>
        <div class="row">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td align="left" valign="middle" width="102"><div class="subHead"> Rooms</div></td>
          <td align="left" valign="middle" width="75"><div class="subHead"> Adult</div></td>
          <td align="left" valign="middle"><div class="subHead"> Child <span class="gray">[0-11]</span> </div></td>
        </tr>
        <tr>
          <td align="left" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><asp:DropDownList ID="ddlRoom" runat="server" onchange="MultiRoomSele(this);" class="sel"
                                        Width="50px">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                  </asp:DropDownList></td>
                <td align="right" valign="middle"><asp:Label ID="lblRoom1" runat="server" Text="Room1" class="gray" Style="display:none;" CssClass="tR"></asp:Label></td>
              </tr>
            </table></td>
          <td align="left" valign="middle" ><asp:DropDownList ID="ddlAdult1" runat="server" class="sel" Width="50px">
              <asp:ListItem Selected="True">1</asp:ListItem>
              <asp:ListItem>2</asp:ListItem>
              <asp:ListItem>3</asp:ListItem>
              <asp:ListItem>4</asp:ListItem>
            </asp:DropDownList></td>
          <td align="left" valign="middle"><table border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><span class="formtext">
                  <asp:DropDownList ID="ddlChild1" runat="server" onchange="Child1AgeSele(this);"  class="sel" Width="50px">
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                  </asp:DropDownList>
                  </span></td>
              </tr>
            </table></td>
        </tr>
        <tr id="trHdrR2">
          <td align="left" valign="middle" colspan="3" class="top5"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="102" align="right" valign="middle"><asp:Label ID="lblRoom2" runat="server" Text="Room2 " class="gray" Style="display:none;" CssClass="tR"></asp:Label></td>
                <td width="75" align="left" valign="top"><asp:DropDownList ID="ddlAdult2" runat="server" Style="display: none;"  class="sel" Width="50px">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                  </asp:DropDownList></td>
                <td align="left" valign="top"><asp:DropDownList ID="ddlChild2" runat="server" onchange="Child2AgeSele(this);" Style="display: none;"  class="sel" Width="50px">
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                  </asp:DropDownList></td>
              </tr>
            </table></td>
        </tr>
        <tr id="trHdrR3">
          <td align="left" valign="middle" colspan="3" class="top5"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="102" align="right" valign="middle"><asp:Label ID="lblRoom3" runat="server" Text="Room3 " class="gray" Style="display: none;" CssClass="tR"></asp:Label></td>
                <td width="75" align="left" valign="top"><asp:DropDownList ID="ddlAdult3" runat="server" Style="display: none;"  class="sel" Width="50px">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                  </asp:DropDownList></td>
                <td align="left" valign="top"><asp:DropDownList ID="ddlChild3" runat="server" onchange="Child3AgeSele(this);" Style="display: none;"  class="sel" Width="50px">
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                  </asp:DropDownList></td>
              </tr>
            </table></td>
        </tr>
        <tr id="trHdrR4">
          <td align="left" valign="middle" colspan="3" class="top5"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="102" align="right" valign="middle"><asp:Label ID="lblRoom4" runat="server" Text="Room4 " class="gray" Style="display: none;" CssClass="tR"></asp:Label></td>
                <td width="75" align="left" valign="top"><asp:DropDownList ID="ddlAdult4" runat="server" Style="display: none;"  class="sel" Width="50px">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                  </asp:DropDownList></td>
                <td align="left" valign="top"><asp:DropDownList ID="ddlChild4" runat="server" onchange="Child4AgeSele(this);" Style="display: none;"   class="sel" Width="50px">
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                  </asp:DropDownList></td>
              </tr>
            </table></td>
        </tr>
        <tr id="trHdrR4">
          <td align="left" valign="middle" colspan="3" class="btm10"><asp:Label ID="lblCRoom1" runat="server" Text="Room1 Child Age" Style="display: none;"
                            ></asp:Label>
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td width="102" align="left" valign="top"><asp:DropDownList ID="ddlChild1Age1" runat="server" Width="50px" Style="display: none;"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
                <td width="75" align="left" valign="top"><asp:DropDownList ID="ddlChild1Age2" runat="server" Width="50px" Style="display: none;"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
                <td align="left" valign="top"><asp:DropDownList ID="ddlChild1Age3" runat="server" Width="50px" Style="display: none;"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
              </tr>
            </table></td>
        </tr>
        <tr id="trHdrR4">
          <td align="left" valign="middle" colspan="3" class="btm10"><asp:Label ID="lblCRoom2" runat="server" Text="Room2 Child Age" Style="display: none;"
                            ></asp:Label>
            <table width="100%"  cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td width="102" align="left" valign="top"><asp:DropDownList ID="ddlChild2Age1" runat="server" Width="50px" Style="display: none;"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
                <td width="75" align="left" valign="top"><asp:DropDownList ID="ddlChild2Age2" runat="server" Width="50px" Style="display: none;"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
                <td align="left" valign="top"><asp:DropDownList ID="ddlChild2Age3" runat="server" Width="50px" Style="display: none;"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
              </tr>
            </table></td>
        </tr>
        <tr id="trHdrR4">
          <td align="left" valign="middle" colspan="3" class="btm10"><asp:Label ID="lblCRoom3" runat="server" Text="Room3 Child Age" Style="display: none;"
                            ></asp:Label>
            <table width="100%"  cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td width="102" align="left" valign="top"><asp:DropDownList ID="ddlChild3Age1" runat="server" Style="display: none;" Width="50px"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
                <td width="75" align="left" valign="top"><asp:DropDownList ID="ddlChild3Age2" runat="server" Width="50px" Style="display: none;"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
                <td align="left" valign="top"><asp:DropDownList ID="ddlChild3Age3" Style="display: none;" runat="server" Width="50px"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
              </tr>
            </table></td>
        </tr>
        <tr id="trHdrR4">
          <td align="left" valign="middle" colspan="3"><asp:Label ID="lblCRoom4" runat="server" Text="Room4 Child Age" Style="display: none;"
                            ></asp:Label>
            <table width="100%"  cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td width="102" align="left" valign="top"><asp:DropDownList ID="ddlChild4Age1" Style="display: none;" runat="server" Width="50px"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
                <td width="75" align="left" valign="top"><asp:DropDownList ID="ddlChild4Age2" Style="display: none;" runat="server" Width="50px"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
                <td align="left" valign="top"><asp:DropDownList ID="ddlChild4Age3" Style="display: none;" runat="server" Width="50px"
                                        class="sel">
                    <asp:ListItem Selected="True" Value="-1">?</asp:ListItem>
                    <asp:ListItem Value="0">&lt;1</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                  </asp:DropDownList></td>
              </tr>
            </table></td>
        </tr>
      </table>
        </div>
    </div>
</div>
<div class="row">
    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btn_bookNow.gif"
        alt="Book Now" class="floatright" ValidationGroup="Validation" OnClientClick="return getValidation();"
        CausesValidation="true" OnClick="btnSearch_Click" />
</div>
