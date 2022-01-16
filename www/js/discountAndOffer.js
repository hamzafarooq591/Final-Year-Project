function fillDiscountAndOfferList(){
    showLoader();
        $.ajax({
            url: ' '+ nashApi + '/api/Offer',
            type: 'GET',
            datatype: 'json',
            headers: { 'token': tokenValue },
            success: function (data) {
                debugger
                var value = data.data;
                fillDiscountAndOfferListContent(value)
                hideLoader();
            },
            error: function (request, message, error) {
                hideLoader();
                console.log(error);
            }
        });
}

function fillDiscountAndOfferListContent(valueList) {
    var offerContent = '';
    showLoader();
    $.each(valueList, function (index, value) {
        offerContent += '<div class="row" style="border-bottom: 1px solid #80808047;padding-bottom: 25px;padding-top: 20px;">'; 
        offerContent += '<div class="col-8" style="font-weight: bolder;">'+value.title+'</div>'; 
        offerContent += '<div class="col-4"><button style="width: 100%;height: 100%;background: #b4c8db;border: lightgray;border-radius: 5px;font-size: 11px;">Book Appointment</button></div>'; 
        offerContent += ' <div class="row" style="width: 100%;">'; 
        offerContent += '<div class="col-2" style="padding-right: 0px;text-decoration: line-through;font-size: 15px;">'+ value.oldPrice +'</div>'; 
        offerContent += '<div class="col-2" style="padding-right: 0px;color: #090986;font-weight: bold;font-size: 15px;">'; 
        offerContent += ''+ value.newPrice +'</div>';
        offerContent += '</div>';
        offerContent += '</div>';
    });
    hideLoader();
    document.getElementById('discountAndOfferList').innerHTML = offerContent;
  }