var randomNumberGenerated = Math.floor(10000 + Math.random() * 90000);
//setLocalStorage("RandomNumberGenerated", randomNumberGenerated);

function saveForm() {
   // showLoader();
    var inputFullNameSignUp = document.getElementById("txtFullNameSignUp").value;
    var inputAddressSignUp = document.getElementById("txtAddressSignUp").value;
    var inputNumberSignUp = document.getElementById("txtPhoneNumberSignUp").value;
    var inputPasswordSignUp = document.getElementById("txtPasswordSignUp").value;
    var inputConfirmPasswordSignUp = document.getElementById("txtConfirmPasswordSignUp").value;
    var inputEmailSignUp = document.getElementById("txtEmailSignUp").value;
    // var randomNumberGenerated = Math.floor(10000 + Math.random() * 90000)
    if (inputFullNameSignUp == "" || inputAddressSignUp == "" || inputNumberSignUp == "" || inputPasswordSignUp == ""
        || inputConfirmPasswordSignUp == "" || inputEmailSignUp == "") {
        hideLoader();
        document.getElementById('invalidIdSignUp').style.display = 'Block';
        document.getElementById('invalidIdSignUp').style.color = 'red';
        document.getElementById('invalidIdSignUp').innerHTML = 'Please Enter the required information';
    }

    else if(inputPasswordSignUp != inputConfirmPasswordSignUp){
        hideLoader();
        document.getElementById('invalidIdSignUp').style.display = 'Block';
        document.getElementById('invalidIdSignUp').style.color = 'red';
        document.getElementById('invalidIdSignUp').innerHTML = 'Password does not match';
    }
    else if(inputNumberSignUp.length <= 10 || inputNumberSignUp.length >= 12){
        hideLoader();
        document.getElementById('invalidIdSignUp').style.display = 'Block';
        document.getElementById('invalidIdSignUp').style.color = 'red';
        document.getElementById('invalidIdSignUp').innerHTML = 'Phone Number Incorrect';
    }

    else{
        var SmsBody = randomNumberGenerated + "is your OTP for Authentication"; 
        var nashApi = "http://localhost:49988";  
        var tokenValue = "cbfaf390-7fe7-4e24-9510-97c2b8f81926";
        $.ajax({
        url: ' '+ nashApi + '/api/Sms/SendSms?ToNumber='+inputNumberSignUp+'&smsText='+ SmsBody ,
        // http://nash.pk:8991/api/Sms/SendSms?ToNumber=03452244259&smsText=otp
        type: 'POST',
        dataType: 'json',
        headers: { 'token': tokenValue },
        // data: data,
        success: function (data) {
            debugger
            goToVerificationNumberPage();
            hideLoader();

        },
        error: function (request, message, error) {
            debugger;
            console.log(error);
            hideLoader();
        }
    });
        
    }
}
