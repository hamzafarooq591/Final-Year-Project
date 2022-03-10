function checkRandomNumber(){
    showLoader();
    var randomNumberGenerated = localStorage.getItem("RandomNumberGenerated");
    var inputVerification1 = document.getElementById("txtInput1VerificationPage").value;
    var inputVerification2 = document.getElementById("txtInput2VerificationPage").value;
    var inputVerification3 = document.getElementById("txtInput3VerificationPage").value;
    var inputVerification4 = document.getElementById("txtInput4VerificationPage").value;
    var inputVerification5 = document.getElementById("txtInput5VerificationPage").value;
    var inputRandomNumberGenerated = inputVerification1 + inputVerification2 + inputVerification3 + inputVerification4 + inputVerification5;

    if(randomNumberGenerated == inputRandomNumberGenerated){
        debugger;
        authenticate(inputRandomNumberGenerated);
        return true;
    }
    else{
        hideLoader();
        document.getElementById('invalidIdVerification').style.display = 'Block';
        document.getElementById('invalidIdVerification').style.color = 'red';
        document.getElementById('invalidIdVerification').innerHTML = 'Number does not match';
        return false;
    }
}

function authenticate(inputRandomNumberGenerated){
    showLoader();
    debugger;
    var nashApi = "http://adminhamza-001-site1.dtempurl.com";
    var inputFullNameSignUp = document.getElementById("txtFullNameSignUp").value;
    var inputAddressSignUp = document.getElementById("txtAddressSignUp").value;
    var inputNumberSignUp = document.getElementById("txtPhoneNumberSignUp").value;
    var inputPasswordSignUp = document.getElementById("txtPasswordSignUp").value;
    var inputConfirmPasswordSignUp = document.getElementById("txtConfirmPasswordSignUp").value;
    var inputEmailSignUp = document.getElementById("txtEmailSignUp").value;
    var formData = {
        patientId: 0,
        fullName: inputFullNameSignUp,
        address: inputAddressSignUp,
        phoneNumber: inputNumberSignUp,
        country: "Pakistan",
        city: "Karachi",
        province: "Sindh",
        email: inputEmailSignUp,
        password: inputPasswordSignUp,
        isVerified: true,
        isActive: true,
        verificationCode: inputRandomNumberGenerated,
        createdBy: "string",
        dateCreated: "string",
        dateModified: "string",
        lastModified: "string"
    };
    $.ajax({
        url: ' '+ nashApi + '/api/Patient' ,
        type: 'POST',
        dataType: 'json',
        data: formData,
        success: function (data) {
            debugger;
            goToLandingPage();
            hideLoader();

        },
        error: function (request, message, error) {
            debugger
            console.log(error);
            hideLoader();
        }
    });
}
