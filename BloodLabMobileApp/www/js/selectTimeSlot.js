// function getTodayDate() {
//     var date = new Date();
//     var dateRow = '';
//     for (var a = 1; a < 16; a++) {
//         date.setDate(date.getDate() + 1);
//         var day = date.getDay();
//         var daylist = ["Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat"];
//         var dayName = daylist[day];
//         var dd = String(date.getDate()).padStart(2, '0');

//         var mm = String(date.getMonth()); //January is 0!
//         var monthlist = ["Jan", "Feb", "Mar", "Apr ", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec"];
//         var monthName = monthlist[mm];
//         var today = dayName + "," + dd + " " + monthName;
//         console.log(today);
//         dateRow += '<div style="margin-right: 10px;">';
//         dateRow += '<button style="width: 100%;background: lightgray;border: lightgray;height: 30px;border-radius: 5px;font-size: 11px;">';
//         dateRow += '' + today + '</button>';
//         dateRow += '</div>';
//         document.getElementById('fillDateRow').innerHTML = dateRow;
//     }
// }


