$(document).ready(function () {
	$('#Name').focus();
})
function AutoZeroSet() {
	var rowcount = $('#TotalRow').val();
	for (var i = 0; i < rowcount; i++) {
		var Amt1 = $('#DoctorDetailsMasterViewModels_' + i + '__IPPer1').val();
		var Amt2 = $('#DoctorDetailsMasterViewModels_' + i + '__IPAmt1').val();
		if (Amt1 > 0 && Amt2 > 0) {
			$('#DoctorDetailsMasterViewModels_' + i + '__IPAmt1').val('0.00');
		}
	}
}
function GetSearchDoctorDetails() {
	var empobj = {
		CompId1: $('#CompId1').val(),
		NameX: $('#NameX').val(),
		MobileX: $('#MobileX').val(),
		CityX: $('#CityX').val()
	}
	$.ajax({
		url: "/Master/GetSearchDoctorFile/",
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
					html += '<td hidden>' + item.code + '</td>';
					html += '<td>' + item.name + '</td>';
					html += '<td>' + item.eduction + '</td>';
					html += '<td>' + item.address1 + '</td>';
					html += '<td>' + item.mobileNo + '</td>';
					html += '<td class="actionListButtonWidthAgent">' +
						'<a href="Doctor-File?id=' + item.id + '"' + '<span><i class="far fa-edit mr-3 fa-1x icon-color-green"></i></span></a>' +
						'</td >';
					html += '</tr>';
				});
			}
			else {
				html += '<tr>';
				html += '<td colspan="6"> ' + '<h3 class="text-danger text-center">No Record found......</h3>' + '</td>';
				html += '</tr>';
			}
			$('.tbodyDoctor').html(html);
			// '<a href="AddressBook-Delete-File?id=' + item.ledgerMasterId + '"' +  '<span><i class="fas fa-times fa-2x icon-color-red"></i></span></a>' +
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}