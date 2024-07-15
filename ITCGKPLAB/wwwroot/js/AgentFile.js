$(document).ready(function () {
    $('#Name').focus();
    GetNewSrNo();
})
function GetNewSrNo() {
    if ($('#Id').val() == 0 || $('#Id').val().trim() == null) {
        $.ajax({
            url: "/Master/GetAgentSrNo/",
            method: "GET",
            dataType: "json",
            contentType: "application/json",
            success: function (result) {
                //result = JSON.parse(result);            
                $('#Code').val(result);
            },
            error: function (errormessage) {
                console.error(errormessage.responseText);
            }
        });
    }
    return false;
}
function GetSearchAgentDetails() {
    var empobj = {
        CompId1: $('#CompId1').val(),
        NameX: $('#NameX').val(),
        MobileX: $('#MobileX').val(),
        CityX: $('#CityX').val()
    }
    $.ajax({
        url: "/Master/GetSearchAgentFile/",
        method: "GET",
        dataType: "json",
        data: empobj,
        contentType: "application/json",
        success: function (result) {
            var html = '';
            if (result.length > 0) {
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td hidden>' + item.id + '</td>';
                    html += '<td>' + item.code + '</td>';
                    html += '<td>' + item.name + '</td>';
                    html += '<td>' + item.address1 + '</td>';
                    html += '<td>' + item.mobileNo + '</td>';
                    html += '<td class="text-sm-right" style="max-width:8%;">' + parseFloat(item.ipAmt1).toFixed(2) + '</td>';
                    html += '<td class="actionListButtonWidthAgent">' +
                        '<a href="Executive-File?id=' + item.id + '"' + '<span><i class="far fa-edit mr-3 fa-1x icon-color-green"></i></span></a>' + '<span><i class="fas fa-times fa-2x icon-color-red"></i></span></a>' +
                        '</td >';
                    html += '</tr>';
                });
            }
            else {
                html += '<tr>';
                html += '<td colspan="6"> ' + '<h3 class="text-danger text-center">No Record found......</h3>' + '</td>';
                html += '</tr>';
            }
            $('.tbodyAgent').html(html);
            // '<a href="AddressBook-Delete-File?id=' + item.ledgerMasterId + '"' +  '<span><i class="fas fa-times fa-2x icon-color-red"></i></span></a>' +
        },
        error: function (errormessage) {
            console.error(errormessage.responseText);
        }
    });
    return false;
}