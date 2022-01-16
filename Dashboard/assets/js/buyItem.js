var currentPage = 1;
var rowSize = 10;
var rowCounter = 0;
var itemStockQuantity = [];
var itemBasePrice = [];
var imgConnectionStatus = "on"

$(document).ready(function () {
    fillContactList();
    fillItemList();
    getDate();
});
function itemQuantityChange() {
    debugger;
    var ddlItem1 = document.getElementById('ddlItem1');
    document.getElementById('itemQuantity').value = itemStockQuantity[ddlItem1.selectedIndex];
    document.getElementById('purchasePrice').value = itemBasePrice[ddlItem1.selectedIndex];
    itemTotal();
}

function itemTotal() {
    var a = document.getElementById('purchasePrice').value * document.getElementById('itemQuantity').value;
    document.getElementById('itemTotal').value = a;
}

function fillItemList() {
    $.ajax({
        url: 'http://207.180.231.215:994/api/Item?Size=' + rowSize + "&page=" + currentPage,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var value = data.data;
            fillItemListContent(value);
        }
    });
}

function fillItemListContent(valueList){
    var ddlItem1 = document.getElementById('ddlItem1');
    ddlItem1.options.length = 0;
    
    $.each(valueList, function (index, value) {
        itemStockQuantity[index] = value.quantity;
        itemBasePrice[index] = value.purchasePrice;
        var opt = document.createElement("option");
        opt.value = value.itemId;
        opt.innerHTML = value.itemName /*+ '&emsp;&emsp;&emsp;' + value.quantity*/;
        ddlItem1.append(opt);
    });
}
 
function addRow() {
    if (document.getElementById('ddlItem1').value != 0 && document.getElementById('itemQuantity').value != ""
        && document.getElementById('purchasePrice').value != 0)
    {
        var table = document.getElementById("ItemPurchaseDetailTableBody");
        var row = table.insertRow(0);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1)
        var cell3 = row.insertCell(2)
        var cell4 = row.insertCell(3);
        var cell5 = row.insertCell(4);
        $(cell5).addClass('cell-display-prop');
        var ddvalue = document.getElementById('ddlItem1');

        cell1.innerHTML = ddvalue.options[ddvalue.selectedIndex].text;
        cell1.innerHTML += '<input type="hidden" id="hdnItemId" value="' + ddvalue.value + '" />';
        cell2.innerHTML = document.getElementById('itemQuantity').value;
        cell3.innerHTML = document.getElementById('purchasePrice').value;
        cell4.innerHTML = document.getElementById('itemTotal').value;
// <<<<<<< Updated upstream
        cell5.innerHTML = '<td><button class="btn" onclick="deleteRow(this.parentNode.parentNode.rowIndex)"><i class="fa fa-trash"></i></button></td>';  
        var row2 = table.insertRow(1);
        $(row2).addClass('row-display-prop');
        var cell_empty_1 = row2.insertCell(0);
        var cell_btn_1 = row2.insertCell(1);
        var cell_btn_2 = row2.insertCell(2);
        var cell_empty_2 = row2.insertCell(3);
        cell_empty_1.innerHTML = '';
        cell_btn_1.innerHTML = '<td><button class="del-btn table-btn" onclick="deleteRowSellItem(this.parentNode.parentNode.rowIndex)"><i class="fa fa-trash font-face"></i></button></td>';
        cell_btn_2.innerHTML = '<td><button class="print-btn table-btn" onclick=""><i class="fa fa-print font-face" aria-hidden="true"></i></button></td>';
        cell_empty_2.innerHTML = '';
        
        rowCounter++;
        //alert(ddvalue.value);
        var pototal = document.getElementById('purchaseOrderTotalid').value;
        var itemtotal = document.getElementById('itemTotal').value;
        document.getElementById('purchaseOrderTotalid').value = parseInt(pototal) + parseInt(itemtotal);
        document.getElementById('itemQuantity').value = 0;
        document.getElementById('purchasePrice').value = 0;
        document.getElementById('itemTotal').value = 0;
        document.getElementById('ddlItem1').selectedIndex = 0;
    }
    else {
        alert('Please Fill all values for Adding an Item');
    }
}

function deleteRow(i) {
    rowCounter--;
    i = i - 2;
    var a = i++;
    var pototal = document.getElementById('purchaseOrderTotalid').value;
    var table = document.getElementById("ItemPurchaseDetailTableBody");
    //var itemtotal = table.rows[i].cells[i + 3].innerHTML;
    //document.getElementById('purchaseOrderTotalid').value = parseInt(pototal) - parseInt(itemtotal);
    document.getElementById("ItemPurchaseDetailTableBody").deleteRow(i);
    document.getElementById("ItemPurchaseDetailTableBody").deleteRow(a);

}

function fillContactList() {
    $.ajax({
        url: 'http://207.180.231.215:994/api/Contact?Size=' + rowSize + "&page=" + currentPage,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var value = data.data;
            fillContactContent(value);
        }
    });
}

function fillContactContent(valueContact){
    document.getElementById("ddlContact").options.length = 0;
    var ddlContact = document.getElementById('ddlContact');
    $.each(valueContact, function (index, value) {
        var opt = document.createElement("option");
        opt.value = value.contactId;
        opt.innerHTML = value.contactName;
        ddlContact.append(opt);
    });
}