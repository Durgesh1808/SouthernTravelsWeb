//===================================================================================================================================================
//======================= Validation Check in control==================================================================
 function check() 
 {
              
    var flag=false;
    
    if(document.getElementById("ddlPickupPlace"))
    {
        if (document.getElementById("ddlPickupPlace").selectedIndex==0)
        {
            alert("Please select Pickup Place.");
            document.getElementById("ddlPickupPlace").focus();
            return false;
        }
    }	                
    if (document.getElementById("ddlJDate").selectedIndex==0)
    {
        alert("Please select a date.");
        document.getElementById("ddlJDate").focus();
        return false;
    }	
    if(document.getElementById('gvFareDetails_ctl01_rbtnAcFare'))
    {        			
        if (document.getElementById('gvFareDetails_ctl01_rbtnAcFare').checked==true) 
        {
            flag=true;
        }
    }
    else  if(document.getElementById('gvFareDetails_ctl01_rbtnNAcFare'))
    {
        if (document.getElementById('gvFareDetails_ctl01_rbtnNAcFare').checked==true) 
        {
            flag=true;
        }  			
    }
                            
    if(flag==false)
    {
        alert("Please choose any AC/Non-AC first.");
        return false;
    }
                     	
    var grid = document.getElementById('gvFareDetails');
    if(grid!=null) 
    {
                    
         var Inputs = grid.getElementsByTagName("input"); 
         var ctr=2;
         flag=false;
         for(i = 0; i < Inputs.length; i++) 
         {
            if(Inputs[i].type == 'text' ) 
            {
               if(Inputs[i].id == 'gvFareDetails_ctl0'+ctr+'_txtPerson') 
               {
                   ctr=ctr+1;
                                 
                   if(Inputs[i].value=="" ||Inputs[i].value=="0")
                   {
                       flag=false;
                   }
                   else
                   {
                       flag=true;
                        break;
                   }
               }
             }        
                                        
        }
                            
        if(flag==false)
        {
           alert("Please enter No. of Persons. "); 
           return false;
        }
                           
     }
                
                
}
            
function isNumberKey(evt)
{
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
        return true;
}
   
function DDLSelect(obj)
{
   
    var strValue = obj.value.split('_')
    
     document.getElementById('lblDepartureTime').innerHTML=strValue[0];
}
                    
//======================= Seat table Decoration script==================================================================
                               
                    
var currentOptedSeats = 0;
function alterValue(chkBoxObject)
{           
  if(chkBoxObject.checked)   
  {        
    //alert(document.getElementById('currentOptedSeats').value); 
    //alert(document.getElementById('toPax').value);
     if(parseInt(document.getElementById('currentOptedSeats').value) >= parseInt(document.getElementById('toPax').value))
     {
        alert('You have selected more than '+ parseInt(document.getElementById('toPax').value) +' seat(s)');
             
        chkBoxObject.checked =false;
        return;
     }
                                           
     addValues(chkBoxObject.value);            
  }
  else            
     removeValues(chkBoxObject.value);
}

function addValues(chkValue)
{
  document.getElementById('currentOptedSeats').value=parseInt(document.getElementById('currentOptedSeats').value)+1;
  //currentOptedSeats = currentOptedSeats  + 1;
  var optedStr = document.getElementById('optedSeatNos').value;
  optedStr = optedStr.replace(",,",",");
  document.getElementById('optedSeatNos').value = optedStr + ',' + chkValue;           
                          
}

function removeValues(chkValue)
{
    document.getElementById('currentOptedSeats').value=parseInt(document.getElementById('currentOptedSeats').value)-1;
  // currentOptedSeats = currentOptedSeats  - 1;
   var optedStr = document.getElementById('optedSeatNos').value;
   optedStr = optedStr.replace(chkValue,"");
   optedStr = optedStr.replace(",,",",");                                
   document.getElementById('optedSeatNos').value = optedStr;
}

function checkseats()
{       
   var chek = true;            
   if(parseInt(document.getElementById('currentOptedSeats').value)!= parseInt(document.getElementById('toPax').value))
   {
      //You should select 6 seats 
      alert('You should select '+document.getElementById('toPax').value+' seats.');  
     // alert('Please Select The Correct Number Of seats');                   
      chek = false;
   }
   if(chek)
   {
      document.getElementById('btnContinuee').style.display='none';	     		          
   }
   return chek;
}
                      
function resetColor(tdObj)
{
   var idNo='';
   var cc='';
   if(tdObj.length==5)
   {   
     idNo = tdObj.id.substring(3,5);
     cc=tdObj.id.substring(2,3); 
   }
   else
   {
     idNo = tdObj.id.substring(3,6);
     cc=tdObj.id.substring(2,3);
   }
                        
   if(document.getElementById(cc+'chk'+idNo).checked==true)
   {
      tdObj.bgColor = 'red';
   }
   else
   {
      tdObj.bgColor = '#fff0ca';         
   }
                        
}             
//======================= Calculation  fare in control==================================================================

function checkFare(obj) 
{

  var flag=false;
  var grid = document.getElementById('gvFareDetails');
  if(grid!=null) 
  {
     var Inputs = grid.getElementsByTagName("input"); 
     var ctr=2;
     var Total=0;
     var str=obj.id;
     var arr= str.split("_");
     var stri=arr[0]+'_'+arr[1];
    //=============== Find Control Inside in grid==================================
     for(i = 0; i < Inputs.length; i++) 
     {
        var arr1= Inputs[i].id.split("_");
        var stri1Name=arr1[0]+'_'+arr1[1];
        var tot='gvFareDetails_ctl0';
        if(Inputs[i].type == 'text' ) 
        {
              if(Inputs[i].id == obj.id) 
              {
                    if(Inputs[i].value!="")
                    {
                          //====== Check Multiples (Twin) Fare Type ===========
                                                       
                          if(document.getElementById(stri+'_hdCategoryID').value=="2")
                          {
                            if(Inputs[i].value>=0)
                            {
                              if ((Inputs[i].value % 2)!=0)
                              {
                                alert("Please enter multiples of 2 only.");
                                Inputs[i].value=0;
                                Inputs[i].focus();
                              }
                            }
                           }
                                                        
                          //====== Check Multiples (Triple) Fare Type ===========
                                                       
                          if(document.getElementById(stri+'_hdCategoryID').value=="3")
                          {
                            if(Inputs[i].value>=0)
                            {
                              if ((Inputs[i].value % 3)!=0)
                              {
                                 alert("Please enter multiples of 3 only.");
                                 Inputs[i].value=0;
                                 Inputs[i].focus();
                              }
                             }
                          }
                                                      
                         //====== Calculat Fare  ===========
                         
                         if(document.getElementById('gvFareDetails_ctl01_rbtnAcFare'))
                         {                      
                             if(document.getElementById('gvFareDetails_ctl01_rbtnAcFare').checked==true)
                             {
                                if(obj.value !='0' && obj.value !='')
                                {
                                   document.getElementById(stri+'_lblAmt').innerHTML=parseFloat(obj.value)*parseFloat(document.getElementById(stri+'_lblACFare').innerHTML) ;
                                   document.getElementById(stri+'_lblFarePer').innerHTML=parseFloat(document.getElementById(stri+'_lblACFare').innerHTML) ;
                                                                   
                                   document.getElementById(stri+'_hdAmt').value= document.getElementById(stri+'_lblAmt').innerHTML;
                                   document.getElementById(stri+'_hdFarePer').value= document.getElementById(stri+'_lblFarePer').innerHTML;
                               }
                             }
                         }
                         else if(document.getElementById('gvFareDetails_ctl01_rbtnNAcFare'))
                         {
                             if(document.getElementById('gvFareDetails_ctl01_rbtnNAcFare').checked==true)
                             {
                                 if(obj.value!='0' && obj.value !='')
                                {
                                   document.getElementById(stri+'_lblAmt').innerHTML=parseFloat(obj.value)*parseFloat(document.getElementById(stri+'_lblNACFare').innerHTML) ;
                                   document.getElementById(stri+'_lblFarePer').innerHTML=parseFloat(document.getElementById(stri+'_lblNACFare').innerHTML) ;
                                                                   
                                   document.getElementById(stri+'_hdAmt').value= document.getElementById(stri+'_lblAmt').innerHTML;
                                   document.getElementById(stri+'_hdFarePer').value= document.getElementById(stri+'_lblFarePer').innerHTML;
                               }
                             }
                         }
                         else
                         {
                           alert("Please choose any AC/Non-AC first.");
                           Inputs[i].value=0;
                           flag=true;
                         }
                    }
                    else
                    {
                       document.getElementById(stri+'_lblAmt').innerHTML='0.00' ;
                       document.getElementById(stri+'_lblFarePer').innerHTML='0.00' ;
                    }
               }
               var a=document.getElementById(stri1Name+'_lblAmt').innerHTML;
               Total=parseFloat(Total)+parseFloat(a);
               ctr=ctr+1;
         }        
                            
                           
         if(flag==true)
         {
            return;
         }
         else
         {   
            if(document.getElementById(tot+ctr+'_lblTotal'))
            {
               document.getElementById(tot+ctr+'_lblTotal').innerHTML=Total;
               document.getElementById(tot+ctr+'_hdTotal').value= document.getElementById(tot+ctr+'_lblTotal').innerHTML;
            }
         }    
      }
                       
   }
}

//===================================================================================================================================================