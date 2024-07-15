$(document).ready(function () {
	
})

function FullPaid() {
	$('#PaymentType').val("F");
}
function PartialPaid() {
	$('#PaymentType').val("P");
}
function FullyUnpaid() {
	$('#PaymentType').val("U");
}
function Allpaid() {
	$('#PaymentType').val("A");
}
function ReportCancelpaid() {
	$('#PaymentType').val("C");
}
function checkValues(chid) {	
	if ($('input[name="Item_Status_' + chid + '"]').is(':checked')) {
		// checked
		//alert("Check");
		//$("#StatusValue").is(":checked");
		UpdateRegistrationPatientRecord(chid,"True")
	} else {
		// unchecked
		//alert("UnCheck");
		//$("#StatusValue").is(":unchecked");
		UpdateRegistrationPatientRecord(chid, "False")
	}
}
function UpdateRegistrationPatientRecord(ID, statusvalue) {
	$.ajax({
		url: "/Master/UpdatePatientByCancel/",
		method: "GET",
		data: { id: ID, statusvalue: statusvalue },
		success: function (result) {
			//GetSearchPatientDetails();
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function GetSearchPatientDetails() {
	var totalamt = 0; var discamt = 0; var paidamt = 0; var balamt = 0;
	var empobj = {
		CompId1: $('#CompId1').val(),
		userid: $('#userid').val(),
		NameX: $('#NameX').val(),
		MobileX: $('#MobileX').val(),
		FromDt1: $('#FromDt1').val(),
		UptoDt1: $('#UptoDt1').val()
	}
	$.ajax({
		url: "/Master/PatientSearchDateWiseRecord/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			var html = '';
			if (result.length > 0) {
				$.each(result, function (key, item) {
					totalamt = totalamt + item.totalAmt;
					discamt = discamt + item.discAmt;
					paidamt = paidamt + item.paidAmt;
					balamt = balamt + item.balAmt
					html += '<tr class="small">';
					html += '<td hidden>' + item.id + '</td>';
					html += '<td style="width:5%;">' + item.sDate + '</td>';
					html += '<td style="width:5%;">' + item.refNo + '</td>';
					html += '<td>' + item.titleName + " " + item.name + '</td>';
					html += '<td style="width:8%;">' + (parseInt(item.age)) + "  " + item.ageType + " " + (item.sex == 0 ? "Male" : "Female") + '</td>';
					html += '<td style="width:20%;">' + item.ledgerMasterViewModel.partyName + item.ledgerMasterViewModel.address3 + '</td>';
					html += '<td style="width:8%;">' + item.mobileNo + '</td>';
					html += '<td style="width:7%;" class="text-right">' + parseFloat(item.totalAmt).toFixed(2) + '</td>';
					html += '<td style="width:7%;" class="text-right">' + parseFloat(item.discAmt).toFixed(2) + '</td>';
					html += '<td style="width:7%;" class="text-right">' + parseFloat(item.paidAmt).toFixed(2) + '</td>';
					html += '<td style="width:7%;" class="text-right">' + parseFloat(item.balAmt).toFixed(2) + '</td>';
					html += '<td class="actionListButtonWidthAgent">' +
						'<a href="Registration-File?id=' + item.id + '"' + '<span><i class="far fa-edit mr-3 fa-1x icon-color-green"></i></span></a>' +
						'<a href="Registration-Delete-File?id=' + item.id + '"' + '<span><i class="far fa-edit mr-3 fas fa-times fa-1x icon-color-red"></i></span></a>'
						'</td >';
					html += '</tr>';
				});
			}
			else {
				html += '<tr>';
				html += '<td colspan="12"> ' + '<h3 class="text-danger text-center">No Record found......</h3>' + '</td>';
				html += '</tr>';
			}
			$('.tbodyPatientRecord').html(html);
			$('#TotalAmtPatient').html("Total Amt. " + parseFloat(totalamt).toFixed(2));
			$('#DiscAmtPatient').html("Disc Amt. " + parseFloat(discamt).toFixed(2));
			$('#PaidAmtPaient').html("Paid Amt. " + parseFloat(paidamt).toFixed(2));
			$('#BalAmtPatient').html("Bal. Amt. " + parseFloat(balamt).toFixed(2));
			// '<a href="AddressBook-Delete-File?id=' + item.ledgerMasterId + '"' +  '<span><i class="fas fa-times fa-2x icon-color-red"></i></span></a>' +
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}