function checkForm() {
    debugger;
    var nashApi = "nash.pk:8991";
    //----- authenticate call
    var inputNumber = document.getElementById("txtInputNumber").value;
    var inputPassword = document.getElementById("txtInputPassword").value;

    if (inputNumber == "" || inputPassword == "") {
        document.getElementById('invalidID').style.display = 'Block';
        document.getElementById('invalidID').style.color = 'red';
        document.getElementById('invalidID').innerHTML = 'Please Enter the required information';

    }
    else {
        var formData = {
            username: inputNumber,
            password: inputPassword
        };
        $.ajax({
            url: 'http://' + nashApi + '/api/NashUser/NashUserSession' ,
            type: 'POST',
            dataType: 'json',
            data: formData,
            success: function (data) {
                debugger;
                var value = data.data;
                CompanyId = value.companyId;
                SessionKey = value.sessionKey;
                setLocalStorage("CompanyIdFromLogin", CompanyId);
                setLocalStorage("SessionKeyFromLogin", SessionKey);
                goToDashboard();
            },
            error: function (request, message, error) {
                debugger;
                console.log(error);
                document.getElementById('invalidID').style.display = 'Block';
                document.getElementById('invalidID').style.color = 'red';
                document.getElementById('invalidID').innerHTML = "Invalid Number or Password";
            }
        });

    }
}

function goToDashboard(){
    window.open('dashboard.html',"_self");
}

function setLocalStorage(c_name, value) {
    localStorage.setItem(c_name, value);
}