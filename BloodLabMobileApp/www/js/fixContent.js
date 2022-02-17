var nashApi = 'http://adminhamza-001-site1.dtempurl.com';
//var nashApi = 'http://localhost:49988/';
var tokenValue = "cbfaf390-7fe7-4e24-9510-97c2b8f81926";

function showLoader() {
  document.getElementById("overlay").style.display = "block";
}

function hideLoader() {
  document.getElementById("overlay").style.display = "none";
}

function setLocalStorage(c_name, value) {
  localStorage.setItem(c_name, value);
}

function getLocalStorage(name) {
  var data = localStorage.getItem(name);
  return JSON.parse(data);
}

function mainFooter() {
  var mainFooterContent = '';
  mainFooterContent += '<div  class="container-flex row" style="background-color: white;height: 65px; position: fixed;bottom: 0;text-align: center;width: 100%;z-index:10001">';
  mainFooterContent += '<div onclick="goToLandingPage()" class="col-2" id="footerBackgroundHome" style="padding-top: 15px;height: 100%;margin-right: 5px;">';
  mainFooterContent += '<a> <img class="footer" style="width: 60%;" src="img/001-Home.svg" alt="">';
  mainFooterContent += '<p style="font-size: 12px;color: gray;">Home</p>';
  mainFooterContent += '</a>';
  mainFooterContent += '</div>';

  mainFooterContent += '<div onclick="goToLabResultPage()" class="col-2" id="footerBackgroundOrder" style="padding-top: 15px;height: 100%;margin-right: 5px;">';
  mainFooterContent += '<a><img class="footer" style="width: 60%;" src="img/002-Order.svg" alt="">';
  mainFooterContent += '<p style="font-size: 12px;color: gray;">Reports</p>';
  mainFooterContent += '</a>';
  mainFooterContent += '</div>';

  mainFooterContent += '<div class="col-3" id="footerBackgroundAdd" onclick="goToBookAppointmentPage()" style="padding-top: 15px;height: 100%;margin-right: 5px;">';
  mainFooterContent += '<a><img class="footer" style="width: 70% !important;" src="img/circle.png" alt="">';
  // mainFooterContent += '<p style="font-size: 12px;color: gray;">Order</p>';
  mainFooterContent += '</a>';
  mainFooterContent += '</div>';

  mainFooterContent += '<div onclick="goToProfilePage()" class="col-2" id="footerBackgroundProfile" style="padding-top: 15px;height: 100%;margin-right: 5px;">';
  mainFooterContent += '<a><img class="footer" style="width: 60%;" src="img/003-Profile.svg" alt="">';
  mainFooterContent += '<p style="font-size: 12px;color: gray;">Profile</p>';
  mainFooterContent += '</a>';
  mainFooterContent += '</div>';

  mainFooterContent += '<div onclick="goToNeedHelpPage()" class="col-2" id="footerBackgroundHelp" style="height: 100%;padding-top: 15px;padding-left: 0px !important;padding-right: 0px !important;margin-right: 5px;">';
  mainFooterContent += '<a><img class="footer" style="width: 60%;padding: 0px 8px;" src="img/004-Need Help.svg" alt="">';
  mainFooterContent += '<p style="font-size: 11px;color: gray;">Need Help</p>';
  mainFooterContent += '</a>';
  mainFooterContent += '</div>';
  mainFooterContent += '</div>';

  document.getElementById('mainFooterDiv').innerHTML = mainFooterContent;

}