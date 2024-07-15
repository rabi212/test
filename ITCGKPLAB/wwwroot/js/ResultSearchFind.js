$(document).ready(function () {

})
function ResultNotDone() {
	$('#PaymentType').val("RND");
}
function ResultDone() {
	$('#PaymentType').val("RD");
}
function ResultApproved() {
	$('#PaymentType').val("AP");
}
function ResultIssue() {
	$('#PaymentType').val("IS");
}
function ResultHold() {
	$('#PaymentType').val("HO");
}
function ResultRecipt() {
	$('#PaymentType').val("RE");
}
function ResultDispatch() {
	$('#PaymentType').val("DI");
}
function ResultALL() {
	$('#PaymentType').val("ALL");
}
function ALLApproved() {
	$('#PaymentType').val("Approved");
}
$("#btnApproved").on('click', function () {
	$.ajax({
		async: true,
		data: $('#SearchResultform').serialize(),
		type: "POST",
		url: '/Master/ALLApprovedFileItem',
		success: function (partialView) {
			//console.log("partialView: " + partialView);
			//$('#orderItemContinaer').html(partialView);
			//$('.OpenItemDetailRecord').focus();
		}
	});
});

function checkValues(chid) {	
	if ($('input[name="Item_Status_' + chid + '"]').is(':checked')) {
		// checked
		//alert("Check");
		//$("#StatusValue").is(":checked");
		UpdateRegistrationPatientRecord(chid, "True")
	} else {
		// unchecked
		//alert("UnCheck");
		//$("#StatusValue").is(":unchecked");
		UpdateRegistrationPatientRecord(chid, "False")
	}
}
function UpdateRegistrationPatientRecord(ID, statusvalue) {
	$.ajax({
		url: "/Master/UpdatePatientApproved/",
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
function checkValuesIssue(chid) {
	if ($('input[name="Item_StatusI_' + chid + '"]').is(':checked')) {
		// checked
		//alert("Check");
		//$("#StatusValue").is(":checked");
		UpdateRegistrationPatientRecordIssue(chid, "True")
	} else {
		// unchecked
		//alert("UnCheck");
		//$("#StatusValue").is(":unchecked");
		UpdateRegistrationPatientRecordIssue(chid, "False")
	}
}
function UpdateRegistrationPatientRecordIssue(ID, statusvalue) {
	$.ajax({
		url: "/Master/UpdatePatientIssue/",
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
function checkValuesHold(chid) {
	if ($('input[name="Item_StatusH_' + chid + '"]').is(':checked')) {
		// checked
		//alert("Check");
		//$("#StatusValue").is(":checked");
		UpdateRegistrationPatientRecordHold(chid, "True")
	} else {
		// unchecked
		//alert("UnCheck");
		//$("#StatusValue").is(":unchecked");
		UpdateRegistrationPatientRecordHold(chid, "False")
	}
}
function UpdateRegistrationPatientRecordHold(ID, statusvalue) {
	$.ajax({
		url: "/Master/UpdatePatientHold/",
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
function checkValuesRecipt(chid) {
	if ($('input[name="Item_StatusR_' + chid + '"]').is(':checked')) {
		// checked
		//alert("Check");
		//$("#StatusValue").is(":checked");
		UpdateRegistrationPatientRecordRecipt(chid, "True")
	} else {
		// unchecked
		//alert("UnCheck");
		//$("#StatusValue").is(":unchecked");
		UpdateRegistrationPatientRecordRecipt(chid, "False")
	}
}
function UpdateRegistrationPatientRecordRecipt(ID, statusvalue) {
	$.ajax({
		url: "/Master/UpdatePatientRecipt/",
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
function checkValuesDispatch(chid) {
	if ($('input[name="Item_StatusD_' + chid + '"]').is(':checked')) {
		// checked
		//alert("Check");
		//$("#StatusValue").is(":checked");
		UpdateRegistrationPatientRecordDispatch(chid, "True")
	} else {
		// unchecked
		//alert("UnCheck");
		//$("#StatusValue").is(":unchecked");
		UpdateRegistrationPatientRecordDispatch(chid, "False")
	}
}
function UpdateRegistrationPatientRecordDispatch(ID, statusvalue) {
	$.ajax({
		url: "/Master/UpdatePatientDispatch/",
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