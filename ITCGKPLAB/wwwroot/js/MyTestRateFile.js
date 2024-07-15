$(document).ready(function () {
	$('#Id').focus();
});

function AddAllPatientValue() {
	$('#orderItemContinaer').empty();
	$.ajax({
		async: true,
		data: $('#testrateform').serialize(),
		type: "Post",
		url: '/Master/AddOrderTestRateFileItem',
		success: function (partialView) {
			console.clear;
			console.log("partialView: " + partialView);
			$('#orderItemContinaer').html(partialView);
			$('.OpenItemDetailRecord').focus();
		}
	});
}
function GetTotalPageNoCounter() {	
		$.ajax({
			url: "/Master/TotalPageCountTestRate/",
			method: "GET",
			data: { testgroupId: $('#Id').val() , cmpid: $('#CompId').val() },
			success: function (Data) {
				$('#TotalPageNo').val(Data);
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
	
}