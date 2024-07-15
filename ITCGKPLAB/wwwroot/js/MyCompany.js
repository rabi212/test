$(document).ready(function () {
    $('#CompName').focus();
    $('.custom-file-input').on("change", function () {
        var filename = $(this).val().split("\\").pop();
        $(this).next('.custom-file-label').html(filename);
    });
    // GetNewSrNo();
})
function GetNewSrNo() {
    var empObj2 = {
        stateid: $('#StateId').val(),
        distid: $('#DistId').val(),
    };
    if ($('#Id').val() == 0 || $('#Id').val().trim() == null) {
        $.ajax({
            url: "/Administration/GetBranchSrNo/",
            method: "GET",
            dataType: "json",
            data: empObj2,
            contentType: "application/json",
            success: function (result) {
                //result = JSON.parse(result);            
                $('#TransCode').val(result);
            },
            error: function (errormessage) {
                console.error(errormessage.responseText);
            }
        });
    }
    return false;
}
function GetDistrictList() {
    var empObj2 = {
        id: $('#StateId').val()
    };
    $.ajax({
        url: "/Administration/GetAllDistrictList/",
        method: "GET",
        data: empObj2,
        dataType: "json",
        contentType: "application/json",
        success: function (result) {
            //result = JSON.parse(result);
            $('#DistId').empty();
            $.each(result, function (i, item) {
                // replace 'item.Value' and 'item.Text' from corresponding list properties into model class
                $('#DistId').append('<option value="' + item.value + '"> ' + item.text + ' </option>');
            });
        },
        error: function (errormessage) {
            console.error(errormessage.responseText);
        }
    });
    return false;
}