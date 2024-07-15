$(document).ready(function () {

})

function checkValues(chid) {	
	if ($('input[name="Item_Status_' + chid + '"]').is(':checked')) {
		// checked
		//alert("Check");
		//$("#StatusValue").is(":checked");
		UpdateRegistrationPatientRecord(chid, true)
	} else {
		// unchecked
		//alert("UnCheck");
		//$("#StatusValue").is(":unchecked");
		UpdateRegistrationPatientRecord(chid, false)
	}
}
function UpdateRegistrationPatientRecord(ID, statusvalue) {
	$.ajax({
		url: "/Master/UpdatePatientAuditFile/",
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
function checkValuesALL() {
	if ($('input[name="ZeroBal"]').is(':checked')) {		
		UpdateALLRegistrationPatientRecord();
	} else {
		UpdateALLRegistrationPatientRecord();
	}
}
function UpdateALLRegistrationPatientRecord() {
	$.ajax({
		async: true,
		data: $('#AuditSearchFileRecord').serialize(),
		type: "POST",
		url: '/Master/ALLUpdatePatientAuditFile',
		success: function (partialView) {
			//console.log("partialView: " + partialView);
			//$('#orderItemContinaer').html(partialView);
			//$('.OpenItemDetailRecord').focus();
		}
	});
}
function DeleteALLRegistrationPatientRecord() {
	var message = confirm('Are you sure you want to delete record: ');	
	if (message) {
		$.ajax({
			async: true,
			data: $('#AuditSearchFileRecord').serialize(),
			url: '/Master/ALLDeletePatientAuditFile',
			type: "Post",
		})
			//.done(function (partialViewResult) {
			//	$("#orderItemContinaer").html(partialViewResult);
			//});
	}
}