function checkForm() {
    showLoader();
    var nashApi = "http://localhost:49988/";
    var inputNumber = document.getElementById("txtPhoneNumberSignIn").value;
    var inputPassword = document.getElementById("txtPasswordSignIn").value;

    if (inputNumber == "" || inputPassword == "") {
        hideLoader();
        document.getElementById('invalidID').style.display = 'Block';
        document.getElementById('invalidID').style.color = 'red';
        document.getElementById('invalidID').innerHTML = 'Please Enter the required information';

    }
    else {
        $.ajax({
            url:nashApi + '/api/Patient/Authenticate?PatientPhoneNumber='+inputNumber+'&Password='+ inputPassword,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                debugger
                hideLoader();
                if (data==null) document.getElementById('invalidID').innerHTML = "Invalid Number or Password";
                var value = data.data;
                var patientID = value.patientId;
                setLocalStorage("PatientID", patientID);
                goToLandingPage();
                hideLoader();
            },
            error: function (request, message, error) {
                console.log(error);
                hideLoader();
                document.getElementById('invalidID').style.display = 'Block';
                document.getElementById('invalidID').style.color = 'red';
                document.getElementById('invalidID').innerHTML = "Invalid Number or Password";
            }
        });

    }
}
