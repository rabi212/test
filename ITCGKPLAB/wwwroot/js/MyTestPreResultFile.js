$(document).ready(function () {
	$('#TestIdX').focus();
});
function GetSubTestRecord() {
	var empObj2 = {
		testid: $('#TestIdX').val()
	};
	$.ajax({
		url: "/Master/TestsubList/",
		method: "GET",
		data: empObj2,
		dataType: "json",
		contentType: "application/json",
		success: function (result) {
			//result = JSON.parse(result);
			$('#TestDetailName').empty();
			$.each(result, function (i, item) {
				// replace 'item.Value' and 'item.Text' from corresponding list properties into model class
				$('#TestDetailName').append('<option value="' + item.testDetails + '"> ' + item.testDetails + ' </option>');
			});
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function GetResultIdRecord() {
	$('#Id').val('0');
	var empObj2 = {
		testid: $('#TestIdX').val(),
		testDetailName: $('#TestDetailName').val()
	};
	$.ajax({
		url: "/Master/TestPreResultFindId/",
		method: "GET",
		data: empObj2,
		dataType: "json",
		contentType: "application/json",
		success: function (result) {
			$('#Id').val(result);
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function FindRowIndex(element) {
	$("#RowId").val(0);
	var rowJavascript = element.parentNode.parentNode;
	var id = (rowJavascript.rowIndex - 1)
	$("#RowId").val(id);
	rowno = id;
}
function AddAllPatientValue() {
	$('#orderItemContinaer').empty();
	$.ajax({
		async: true,
		data: $('#testpreresultform').serialize(),
		type: "Post",
		url: '/Master/AddTestPreResultALLFileItem',
		success: function (partialView) {
			console.clear;
			console.log("partialView: " + partialView);
			$('#orderItemContinaer').html(partialView);
			$('.OpenItemDetailRecord').focus();
		}
	});
}

$("#btnAdd").on('click', function () {
	$.ajax({
		async: true,
		data: $('#testpreresultform').serialize(),
		type: "Post",
		url: '/Master/AddOrderTestResultFileItem',
		success: function (partialView) {
			console.log("partialView: " + partialView);
			$('#orderItemContinaer').html(partialView);
			$('.OpenItemDetailRecord').focus();
		}
	});
});
function deleteRow(element) {
	$("#RowId").val(0);
	var rowJavascript = element.parentNode.parentNode;
	var id = (rowJavascript.rowIndex);// (rowJavascript.rowIndex - 1)
	$("#RowId").val(id);
	var message = confirm('Are you sure you want to delete record Sr No. : ' + id);
	//var rowjQuery = $(element).closest("tr");
	//alert("JavaScript Row Index : " + (rowJavascript.rowIndex - 1) + "\njQuery Row Index : " + (rowjQuery[0].rowIndex - 1));
	if (message) {
		$.ajax({
			async: true,
			data: $('#testpreresultform').serialize(),
			url: "/Master/DeleteOrderTestResultFileItem",
			type: "Post",
		})
			.done(function (partialViewResult) {
				$("#orderItemContinaer").html(partialViewResult);
			});
	}
}