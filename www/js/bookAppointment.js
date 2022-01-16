function fillTestList() {
    showLoader();
    $.ajax({
        url: ' ' + nashApi + '/api/Test',
        type: 'GET',
        datatype: 'json',
        headers: { 'token': tokenValue },
        success: function (data) {
            var value = data.data;
            fillTestListContent(value);
            hideLoader();
        },
        error: function (request, message, error) {
            hideLoader();
            console.log(error);
        }
    });
}

function fillTestListContent(valueList) {
    var testContent = '';
    $.each(valueList, function (index, value) {
        testContent += '<div id="testBookAppointment' + value.testId + '" class="row" style="border-bottom:1px solid #80808047;padding:7px">';
        testContent += '<div class="col-1" style="font-weight: bold;"><input onchange="addTestForPrice(' + value.testId + ')" type="checkbox" id="' + value.testId + '"></div>';
        testContent += '<div class="col-7 AppointmentString" style="font-weight: bold;">' + value.title + '</div>';
        testContent += '<div class="col-4 AppointmentValue">' + value.price + '</div>';
        testContent += '</div>';
    });
    document.getElementById('testOfferBookAppointment').innerHTML = testContent;
}

function fillOfferList() {
    showLoader();
    $.ajax({
        url: ' ' + nashApi + '/api/Offer',
        type: 'GET',
        datatype: 'json',
        headers: { 'token': tokenValue },
        success: function (data) {
            var value = data.data;
            fillOfferListContent(value)
            hideLoader();
        },
        error: function (request, message, error) {
            hideLoader();
            console.log(error);
        }
    });
}

function fillOfferListContent(valueList) {
    var offerContent = '';
    $.each(valueList, function (index, value) {
        offerContent += '<div class="row" style="border-bottom: 1px solid #80808047;padding-bottom: 25px;padding-top: 20px;">';
        offerContent += '<div class="col-8" style="font-weight: bolder;">' + value.title + '</div>';
        offerContent += '<div class="col-4"><button style="width: 100%;height: 100%;background: #b4c8db;border: lightgray;border-radius: 5px;font-size: 11px;">Book Appointment</button></div>';
        offerContent += ' <div class="row" style="width: 100%;">';
        offerContent += '<div class="col-2" style="padding-right: 0px;text-decoration: line-through;font-size: 15px;">' + value.oldPrice + '</div>';
        offerContent += '<div class="col-2" style="padding-right: 0px;color: #090986;font-weight: bold;font-size: 15px;">';
        offerContent += '' + value.newPrice + '</div>';
        offerContent += '</div>';
        offerContent += '</div>';
    });
    document.getElementById('discountOfferBookAppointment').innerHTML = offerContent;
}

function addTestForPrice(divValues) {
    var a = divValues.toString();
    var testSummaryDiv = document.getElementById('testSummary');
    var inputValue = document.getElementById(a);
    var divName = "testBookAppointment" + divValues;
    var rowIdTestSummary = "rowIdTestSummary" + divValues;
    var mainDiv = document.getElementById(divName);
    var valueTitle = mainDiv.childNodes[1].innerText;
    var valuePrice = mainDiv.lastElementChild.innerText;
    var addRow = '';
    debugger
    if (inputValue.checked == true) {
        if (testSummaryDiv.childElementCount == 0) {
            addRow += '<div id="' + rowIdTestSummary + '" class="row" style="border-bottom:1px solid #80808047">';
            addRow += '<div class="col-8" style="font-weight: bold;">' + valueTitle + '</div>';
            addRow += '<div class="col-4">' + valuePrice + '</div>';
            document.getElementById('testSummary').innerHTML = addRow;
            grandTotalCalculation(valuePrice);
        }
        else {
            addRow += '<div id="' + rowIdTestSummary + '"  class="row" style="border-bottom:1px solid #80808047">';
            addRow += '<div class="col-8" style="font-weight: bold;">' + valueTitle + '</div>';
            addRow += '<div class="col-4">' + valuePrice + '</div>';
            $('#testSummary').append(addRow);
            grandTotalCalculation(valuePrice);
        }
    }
    else {
        $("#" + rowIdTestSummary).remove();
        grandTotalCalculation(valuePrice);
    }
}

function grandTotalCalculation(price) {
    var amount = document.getElementById('testSummary');
    var rowcounter = amount.childElementCount;
    var updatedAmount = 0;
    for (var i = 0; i < rowcounter; i++) {
        var testPrice = amount.children[i].lastChild.innerText;
        testPrice = parseInt(testPrice, 10);
        if (i == 0) {
            var zero = 0;
            updatedAmount = testPrice + zero;
        }
        else {
            updatedAmount = updatedAmount + testPrice;
        }
    }
    document.getElementById('grandTotalAmount').innerHTML = "Grand Total Rs: " + updatedAmount;
}

function getTodayDate() {
    var date = new Date();
    var dateRow = '';
    for (var a = 1; a < 16; a++) {
        date.setDate(date.getDate() + 1);
        var day = date.getDay();
        var daylist = ["Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat"];
        var dayName = daylist[day];
        var dd = String(date.getDate()).padStart(2, '0');

        var mm = String(date.getMonth()); //January is 0!
        var monthlist = ["Jan", "Feb", "Mar", "Apr ", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec"];
        var monthName = monthlist[mm];
        var today = dayName + "," + dd + " " + monthName;
        console.log(today);
        dateRow += '<div style="margin-right: 10px;">';
        dateRow += '<button style="width: 100%;background: lightgray;border: lightgray;height: 30px;border-radius: 5px;font-size: 11px;">';
        dateRow += '' + today + '</button>';
        dateRow += '</div>';
        document.getElementById('fillDateRow').innerHTML = dateRow;
    }
}
