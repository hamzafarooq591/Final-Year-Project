var nashApi = "http://adminhamza-001-site1.dtempurl.com";
//var nashApi = "http://localhost:49988";
function sideBar(){
    // checkifUserIsLogin();
    var sideBarContent = '';
    sideBarContent += '<a href="dashboard.html">';
    sideBarContent += '<img src="dist/img/logo1.jpg" alt="logo1 Logo" class="brand-image elevation-3" style="opacity: .8;width:100%;height:100%">';
    // sideBarContent += '<span class="brand-text font-weight-light">NOOR</span>';
    sideBarContent += '</a>';
    sideBarContent += '<div  class="sidebar">';
    sideBarContent += '<nav class="mt-2">';
    sideBarContent += ' <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">';
    sideBarContent += ' <li class="nav-item has-treeview menu-open">';
    sideBarContent += ' <a href="#" class="nav-link active">';
    sideBarContent += ' <i class="nav-icon fas fa-tachometer-alt"></i>';
    sideBarContent += '  <p>';
    sideBarContent += ' Dashboard';
    sideBarContent += '<i class="right fas fa-angle-left"></i>';
    sideBarContent += '  </p>';
    sideBarContent += ' </a>';
    sideBarContent += '  <ul class="nav nav-treeview">';
    sideBarContent += ' <li class="nav-item">';
    sideBarContent += ' <a href="./dashboard.html" class="nav-link active">';
    sideBarContent += ' <i class=" nav-icon  fas fa-tachometer-alt"></i>';
    sideBarContent += '<p>Dashboard</p>';
    sideBarContent += '</a>';
    sideBarContent += ' </li>';
    sideBarContent += '</ul>';
    sideBarContent += '  </li>';
    sideBarContent += ' <li class="nav-item has-treeview">';
    sideBarContent += ' <a href="#" class="nav-link">';
    sideBarContent += ' <i class="fas fa-user-injured mr-2"></i>';
    sideBarContent += ' <p>';
    sideBarContent += ' Patients';
    sideBarContent += '  <i class="fas fa-angle-left right"></i>';
    sideBarContent += ' <span class="badge badge-info right"></span>';
    sideBarContent += ' </p>';
    sideBarContent += ' </a>';
    sideBarContent += '  <ul class="nav nav-treeview">';
    // sideBarContent += '<li class="nav-item">';
    // sideBarContent += '<a href="userManagement.html" class="nav-link">';
    // sideBarContent += ' <i class="far fa-circle nav-icon"></i>';
    // sideBarContent += ' <p>Patient</p>';
    // sideBarContent += ' </a>'; 
    // sideBarContent += ' </li>';
    sideBarContent += '<li class="nav-item">';
    sideBarContent += '<a href="testResult.html" class="nav-link">';
    sideBarContent += ' <i class="fas fa-poll-h mr-2"></i>';
    sideBarContent += ' <p>Test Result</p>';
    sideBarContent += ' </a>';
    sideBarContent += '  </li>';
    // sideBarContent += '<li class="nav-item">';
    // sideBarContent += ' <a href="testupload.html" class="nav-link">';
    // sideBarContent += ' <i class="far fa-circle nav-icon"></i>';
    // sideBarContent += ' <p>Test Update</p>';
    // sideBarContent += ' </a>';
    // sideBarContent += ' </li>';
    sideBarContent += ' <li class="nav-item">';
    sideBarContent += ' <a href="appointmentlist.html" class="nav-link">';
    sideBarContent += '  <i class="fas fa-calendar-check mr-2"></i>';
    sideBarContent += ' <p>Appointment List</p>';
    sideBarContent += '</a>';
    sideBarContent += '</li>';
    // sideBarContent += '<li class="nav-item">';
    // sideBarContent += ' <a href="offers.html" class="nav-link">';
    // sideBarContent += '<i class="far fa-circle nav-icon"></i>';
    // sideBarContent += ' <p>Offers</p>';
    // sideBarContent += '  </a>';
    // sideBarContent += '</li>';
    sideBarContent += '</ul>';
    sideBarContent += ' </li>';
    sideBarContent += '<li class="nav-item has-treeview">';
    sideBarContent += ' <a href="#" class="nav-link">';
    sideBarContent += '  <i class="fas fa-tasks mr-2"></i>';
    sideBarContent += '<p>';
    sideBarContent += ' Management';
    sideBarContent += '<i class="right fas fa-angle-left"></i>';
    sideBarContent += ' </p>';
    sideBarContent += '</a>';
    sideBarContent += '  <ul class="nav nav-treeview">';
     sideBarContent += '<li class="nav-item">';
    sideBarContent += '<a href="Patients.html" class="nav-link">';
    sideBarContent += ' <i class="fas fa-user-injured mr-2"></i>';
    sideBarContent += ' <p>Patients</p>';
    sideBarContent += ' </a>'; 
    sideBarContent += ' </li>';
    sideBarContent += '<li class="nav-item">';
    sideBarContent += '<a href="appointmentSlot.html" class="nav-link">';
    sideBarContent += ' <i class="fas fa-calendar-check mr-2"></i>';
    sideBarContent += ' <p>Appointment Slot</p>';
    sideBarContent += ' </a>'; 
    sideBarContent += ' </li>';
     sideBarContent += '<li class="nav-item">';
    sideBarContent += ' <a href="Labtest.html" class="nav-link">';
    sideBarContent += ' <i class="fas fa-vials mr-2"></i>';
    sideBarContent += ' <p>Lab Test</p>';
    sideBarContent += ' </a>';
    sideBarContent += ' </li>';
    sideBarContent += '<li class="nav-item">';
    sideBarContent += ' <a href="offers.html" class="nav-link">';
    sideBarContent += '<i class="fas fa-percentage  mr-2"></i>';
    sideBarContent += ' <p>Offers</p>';
    sideBarContent += '  </a>';
    sideBarContent += '</li>';
    // sideBarContent += '  <li class="nav-item">';
    // sideBarContent += ' <a href="companysetting.html" class="nav-link">';
    // sideBarContent += '  <i class="far fa-circle nav-icon"></i>';
    // sideBarContent += '  <p>Comapny Settings</p>';
    // sideBarContent += ' </a>';
    // sideBarContent += ' </li>';
    // sideBarContent += '<li class="nav-item">';
    // sideBarContent += ' <a href="smssetting.html" class="nav-link">';
    // sideBarContent += '  <i class="far fa-circle nav-icon"></i>';
    // sideBarContent += '<p>SMS Settings</p>';
    // sideBarContent += ' </a>';
    // sideBarContent += ' </li>';
    sideBarContent += ' </ul>';
    sideBarContent += '</li>';

    sideBarContent += '<li class="nav-item has-treeview">';
    sideBarContent += ' <a href="#" class="nav-link">';
    sideBarContent += '  <i class="fas fa-cogs mr-2"></i>';
    sideBarContent += '<p>';
    sideBarContent += ' Settings';
    sideBarContent += '<i class="right fas fa-angle-left"></i>';
    sideBarContent += ' </p>';
    sideBarContent += '</a>';
    sideBarContent += '  <ul class="nav nav-treeview">';
    sideBarContent += '  <li class="nav-item">';
    sideBarContent += ' <a href="companysetting.html" class="nav-link">';
    sideBarContent += '  <i class="fas fa-building mr-2"></i>';
    sideBarContent += '  <p>Comapny Settings</p>';
    sideBarContent += ' </a>';
    sideBarContent += ' </li>';
    sideBarContent += '<li class="nav-item">';
    sideBarContent += ' <a href="smssetting.html" class="nav-link">';
    sideBarContent += '  <i class="fas fa-sms mr-2"></i>';
    sideBarContent += '<p>SMS Settings</p>';
    sideBarContent += ' </a>';
    sideBarContent += ' </li>';
    sideBarContent += ' </ul>';
    sideBarContent += '</li>';

    sideBarContent += '</ul>';
    sideBarContent += '</nav>';
    sideBarContent += '</div>';
    document.getElementById('sideBarContent').innerHTML = sideBarContent;
}

$(document).ready(function(){
    sideBar();
});


function getLocalStorage(name) {
    var data = localStorage.getItem(name);
    return JSON.parse(data);
}

function setLocalStorage(c_name, value) {
    localStorage.setItem(c_name, value);
}

var sessionKeyifExist = localStorage.getItem("SessionKeyFromLogin");
function checkifUserIsLogin(){
    if(sessionKeyifExist == null){
        window.open("index.html",'_self');
        return false;
    }
    else{
        return true;
    }
}

function overlayOn() {
    document.getElementById("overlay").style.display = "block";
  }
  
  function overlayOff() {
    document.getElementById("overlay").style.display = "none";
  }
  function logout() {
    localStorage.clear();
    window.open('index.html','_self');
  }