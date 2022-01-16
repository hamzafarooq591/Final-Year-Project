var nash = "207.180.231.215:994";

function sideBar(){
    checkifUserIsLogin();
    var sideBarContent = "";
    sideBarContent += '<div class="logo">';
    sideBarContent += '<a href="dashboard.html" class="">';
    sideBarContent += '<img src="assets/img/logo1.jpg">';
    sideBarContent += '</a>';
    sideBarContent += '</div>';
    sideBarContent += '<div class="sidebar-wrapper" id="sidebar-wrapper" style="overflow-x: hidden;">';
    sideBarContent += '<ul class="nav">';
    sideBarContent += '<li class="active ">';
    sideBarContent += '<div id="accordion">';

    sideBarContent += '<div class="card" style="border-radius: 0;margin-bottom: 0px;box-shadow: none;border:none">';
    sideBarContent += '<div class="card-header" id="headingTwo">';
    sideBarContent += '<h5 class="mb-0">';
    sideBarContent += '<button onclick="goToDashboard()" style="width:100%; text-align:left" class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">';
    sideBarContent += 'Dashboard';
    sideBarContent += '</button>';
    sideBarContent += '</h5>';
    sideBarContent += '</div>';
    sideBarContent += '<div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">';
    sideBarContent += '<div class="card-body">';
    sideBarContent += '</div>';
    sideBarContent += '</div>';
    sideBarContent += '</div>';


    sideBarContent += '<div class="card" style="border-radius: 0;margin-bottom: 0px;box-shadow: none;border:none">';
    sideBarContent += '<div class="card-header" id="headingOne">';
    sideBarContent += '<h5 class="mb-0">';
    sideBarContent += '<button class="btn btn-link" style="width:100%; text-align:left" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">';
    sideBarContent += 'Inventory Management';
    sideBarContent += '</button>';
    sideBarContent += '</h5>';
    sideBarContent += '</div>';
    sideBarContent += '<div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordion">';
    sideBarContent += '<div class="card-body">';
    sideBarContent += '<a href="./userManagement.html">';
    sideBarContent += '<i class="now-ui-icons users_single-02"></i>';
    sideBarContent += '<p>User Management</p>';
    sideBarContent += '</a>';
    sideBarContent += '<a href="./Result.html">';
    sideBarContent += '<i class="now-ui-icons ui-1_simple-add"></i>';
    sideBarContent += '<p>Test Results</p>';
    sideBarContent += '</a>';
    // sideBarContent += '<a href="./sellItem.html">';
    // sideBarContent += '<i class="now-ui-icons shopping_box"></i>';
    // sideBarContent += '<p>Test Upload</p>';
    // sideBarContent += '</a>';
    sideBarContent += '<a href="./appointmentlist.html">';
    sideBarContent += '<i class="now-ui-icons ui-1_calendar-60"></i>';
    sideBarContent += '<p>Appointment List</p>';
    sideBarContent += '</a>';
    sideBarContent += '<a href="./testupload.html">';
    sideBarContent += '<i class="now-ui-icons files_single-copy-04"></i>';
    sideBarContent += '<p>Test Upload</p>';
    sideBarContent += '</a>';
    sideBarContent += '<a href="./offers.html">';
    sideBarContent += '<i class="now-ui-icons ui-2_time-alarm"></i>';
    sideBarContent += '<p>Offers</p>';
    sideBarContent += '</a>';
    sideBarContent += '<a href="./appointmentSlot.html">';
    sideBarContent += '<i class="now-ui-icons ui-2_time-alarm"></i>';
    sideBarContent += '<p>Appointment Slot</p>';
    sideBarContent += '</a>';
    // sideBarContent += '<a href="./addContact.html">';
    // sideBarContent += '<i class="now-ui-icons users_single-02"></i>';
    // sideBarContent += '<p>Add Contact</p>';
    // sideBarContent += '</a>';
    // sideBarContent += '<a href="./contactList.html">';
    // sideBarContent += '<i class="now-ui-icons business_badge"></i>';
    // sideBarContent += '<p>Contact List</p>';
    // sideBarContent += '</a>';
    // sideBarContent += '<a href="./profitAndLoss.html">';
    // sideBarContent += '<i class="now-ui-icons business_chart-bar-32"></i>';
    // sideBarContent += '<p>Profit and Loss</p>';
    // sideBarContent += '</a>';
    sideBarContent += '<a href="./companySettings.html">';
    sideBarContent += '<i class="now-ui-icons ui-1_settings-gear-63"></i>';
    sideBarContent += '<p>Settings</p>';
    sideBarContent += '</a>';
    sideBarContent += '</div>';
    sideBarContent += '</div>';
    sideBarContent += '</div>';
    sideBarContent += '</ul>';
    sideBarContent += '</div>';
    document.getElementById('sideBar').innerHTML = sideBarContent;
}

$( document ).ready(function() {
    sideBar();
});           
    

function getLocalStorage(name) {
    var data = localStorage.getItem(name);
    return JSON.parse(data);
}

function setLocalStorage(c_name, value) {
    localStorage.setItem(c_name, value);
}

var sessionKeyifExist = localStorage.getItem("Session");
function checkifUserIsLogin(){
    debugger;
    if(sessionKeyifExist == null){
        debugger;
       // window.open("index.html",'_self');
		return true;
    }
    else{
        debugger;
        return true;
    }
}

function goToDashboard(){
    window.open('dashboard.html','_self');
}
          
        
      