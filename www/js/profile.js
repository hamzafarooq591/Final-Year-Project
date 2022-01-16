function fillProfileList(){
    showLoader();
    var patientId = localStorage.getItem("PatientID");
    patientId = parseInt(patientId);
        $.ajax({
            url: ' '+ nashApi + '/api/Patient/'+patientId,
            type: 'GET',
            datatype: 'json',
            headers: { 'token': tokenValue },
            success: function (data) {
                debugger
                var value = data.data;
                var inputFullName ='';
                inputFullName += '<span style="font-size: 15px;">Name</span>';
                inputFullName += '<input type="text" disabled id="profileFullName"';
                inputFullName += 'style="width: 100%;padding: 8px;background: lightgray;border: 2px solid darkgrey;border-radius: 5px;"';
                inputFullName += 'placeholder="'+value.fullName+'"></input>';  
                document.getElementById('profileFullName').innerHTML = inputFullName;

                var inputphoneNumber ='';
                inputphoneNumber += '<span style="font-size: 15px;">Phone Number</span>';
                inputphoneNumber += '<input type="text" disabled id="profileFullName"';
                inputphoneNumber += 'style="width: 100%;padding: 8px;background: lightgray;border: 2px solid darkgrey;border-radius: 5px;"';
                inputphoneNumber += 'placeholder="'+value.phoneNumber+'"></input>';  
                document.getElementById('profilePhoneNumber').innerHTML = inputphoneNumber;

                // document.getElementById('profileFullName').innerHTML = value.fullName;
                // document.getElementById('profilePhoneNumber').innerHTML = value.phoneNumber;
                // document.getElementById('profileRelationship').innerHTML = "none";
                hideLoader();
            },
            error: function (request, message, error) {
                hideLoader();
                console.log(error);
            }
    });
}