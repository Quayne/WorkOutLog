$(document).ready(function () {
    loginTime();
});

var mid = "am";

function myDate() {
    var date;
    var d = new Date();
    var today = d.getDate();
    var month = d.getMonth() + 1;
    var year = d.getFullYear();    
    date = today +"/"+ month +"/" +year;    
    return date;
}


//Need logical changes
//Current state: 12:00pm is 12:00
function myTime() {
    var time;
    var d = new Date();
    var hour = d.getHours();
    var minute = d.getMinutes();
    var second = d.getSeconds();
    hour = (hour + 24 ) % 24; 
    
    if(hour == 0){
        hour = 12;
    }
    else if(hour > 12){
        hour = hour % 12;
        mid="pm";
    }  
    time = hour +":"+ minute +":" + second;   
    return time;
}

function myDateTime(){
    var thisTime = myDate() + " " + myTime();
}

function loginTime() {
    document.getElementById("myTime").innerHTML = "Current Time: " + myTime() + mid;
}
