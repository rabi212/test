$(document).ready(function () {
    $('#CompId').focus();   
    //$('#OpnAc').chosen();
})
function GetNewSrNo() {
    if ($('#LedgerMasterId').val() == 0 || $('#LedgerMasterId').val().trim() == null) {
        $.ajax({
            url: "/Financial/GetAddressSrNo/",
            method: "GET",
            dataType: "json",
            data: { cmpid: $('#CompId').val() },
            contentType: "application/json",
            success: function (result) {
                //result = JSON.parse(result);            
                $('#LedCode').val(result);
            },
            error: function (errormessage) {
                console.error(errormessage.responseText);
            }
        });
        GetStateRecord();
    }
    return false;
}
function GetStateRecord() {
    $.ajax({
        url: "/Financial/GetStateFile/",
        method: "GET",
        dataType: "json",
        data: { cmpid: $('#CompId').val() },
        contentType: "application/json",
        success: function (result) {
            $('#LedStateId').val(result.stateId);
        },
        error: function (errormessage) {
            console.error(errormessage.responseText);
        }
    });
    return false;
}
function AccoutGroupDrCr() {
    $.ajax({
        url: "/Financial/GetGroupExpIncomeFile/",
        method: "GET",
        dataType: "json",
        data: { id: $('#AcGroupId').val() },
        contentType: "application/json",
        success: function (result) {
            if (result.nature == "1" || result.nature == "3") {
                $('#OpnAc').val(1);
            }
            else {
                $('#OpnAc').val(2);
            }
        },
        error: function (errormessage) {
            console.error(errormessage.responseText);
        }
    });
    return false;
}
function GetAccountNameMobileNo() {
    var empobj = {
        CompId1: $('#CompId1').val(),
        NameX: $('#NameX').val(),
        MobileX: $('#MobileX').val(),
        CityX: $('#CityX').val()
    }
    $.ajax({
        url: "/Financial/GetSearchAddressFile/",
        method: "GET",
        dataType: "json",
        data: empobj,
        contentType: "application/json",
        success: function (result) {
            var html = '';
            if (result.length > 0) {
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td hidden>' + item.ledgerMasterId + '</td>';
                    html += '<td>' + item.ledCode + '</td>';
                    html += '<td>' + item.partyName + '</td>';
                    html += '<td>' + item.address1 + '</td>';
                    html += '<td>' + item.city + '</td>';
                    html += '<td>' + item.mobileNo1 + '</td>';
                    html += '<td class="actionListButtonWidthAgent">' +
                        '<a href="AddressBook-File?id=' + item.ledgerMasterId + '"' + '<span><i class="far fa-edit mr-3 fa-1x icon-color-green"></i></span></a>' +
                        '</td >';
                    html += '</tr>';
                });
            }
            else {
                html += '<tr>';
                html += '<td colspan="7"> ' + '<h3 class="text-danger text-center">No Record found......</h3>' + '</td>';
                html += '</tr>';
            }
            $('.tbodyAddress').html(html);
            // '<a href="AddressBook-Delete-File?id=' + item.ledgerMasterId + '"' +  '<span><i class="fas fa-times fa-2x icon-color-red"></i></span></a>' +
        },
        error: function (errormessage) {
            console.error(errormessage.responseText);
        }
    });
    return false;
}