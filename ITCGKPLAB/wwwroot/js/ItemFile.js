$(document).ready(function () {
    $('#ItemName').focus();
})
function GetHSNCode() {
    if ($('#ItemId').val() == 0 || $('#ItemId').val().trim() == null) {
        $.ajax({
            url: "/Financial/GetProductHSNCode/",
            method: "GET",
            dataType: "json",
            data: { id: $('#ItGPCode').val() },
            contentType: "application/json",
            success: function (result) {
                //result = JSON.parse(result);            
                $('#IHSNCode').val(result.ihsnCode);
                $('#GSTPer').val(result.igstPer);
                $('#CessPer').val(result.cessPer);
            },
            error: function (errormessage) {
                console.error(errormessage.responseText);
            }
        });
    }
    return false;
}
function SearchItemFile() {
    var empobj = {
        ItemGroupId: $('#ItemGroupId').val(),
        ProdCodeX: $('#ProdCodeX').val(),
        NameX: $('#NameX').val(),
        ProdCompCordX: $('#ProdCompCordX').val(),
        HSNCodeX: $('#HSNCodeX').val()
    }
    $.ajax({
        url: "/Financial/ItemDetailSearchRecord/",
        method: "GET",
        dataType: "json",
        data: empobj,
        contentType: "application/json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td hidden>' + item.itemId + '</td>';
                html += '<td class="wdp-5">' + item.itemCode + '</td>';
                html += '<td class="wdp-10">' + item.ihsnCode + '</td>';
                html += '<td>' + item.itemName + '</td>';
                html += '<td class="wdp-10">' + item.itemGroupViewModel.itemGroupName + '</td>';
                html += '<td class="wdp-20">' + item.productCompanyViewModel.prodName + '</td>';
                html += '<td class="text-md-right wdp-5">' + item.gstPer + '</td>';
                html += '<td class="text-md-right wdp-5">' + item.unitCase + '</td>';
                html += '<td class="actionListButtonWidthAgent">' +
                    '<a href="Item-File?id=' + item.itemId + '"' + '<span><i class="far fa-edit mr-3 fa-1x icon-color-green"></i></span></a>' +
                    '</td >';
                html += '</tr>';
            });
            $('.tbodyItem').html(html);
            // '<a href="AddressBook-Delete-File?id=' + item.ledgerMasterId + '"' +  '<span><i class="fas fa-times fa-2x icon-color-red"></i></span></a>' +
        },
        error: function (errormessage) {
            console.error(errormessage.responseText);
        }
    });
    return false;
}