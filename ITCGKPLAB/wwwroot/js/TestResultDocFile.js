$(document).ready(function () {	
	//$('.DocumentContainerDetails').summernote({
	//	height: screen.height - 380
	//});		
	DisplayInvestigationFile();	
	$('#RptDate').val(CurrentDateTime());
	$("#TestListId").focus();
});
function DisplayInvestigationFile() {		
	$('#TestDocumentain').val(''); $('#RowId').val(0);
	$('.DocumentContainerDetails').summernote('destroy');
	var empobj = {
		ptid: $('#PatientId').val(),
		testid: $('#TestListId').val()
	}
	$.ajax({
		url: "/Master/AddPatientResultDocItem/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			$('#TestDocumentain').val(result.testdetails);
			$('#RowId').val(result.testMasterViewModels.testGroupId);
			WordFormationg(); GetAllDocumentGroupTestFile();
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function GetAllDocumentGroupTestFile() {
	$('#ALLTestCode').empty();
	var empobj = {
		cmpid: $('#CompId').val(),
		testgid: $('#TestListId').val() //$('#RowId').val()
	}
	$.ajax({
		url: "/Master/AddListDocumentTest/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			//result = JSON.parse(result);			
			$.each(result, function (i, item) {
				// replace 'item.Value' and 'item.Text' from corresponding list properties into model class
				$('#ALLTestCode').append('<option value="' + item.id + '"> ' + item.testCode + ' </option>');
			});
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function GetAllDocumentGroupCountTrueFalse() {
	var empobj = {
		cmpid: $('#CompId').val(),
		testgid: $('#TestListId').val() //$('#RowId').val()
	}
	$.ajax({
		url: "/Master/AddListDocumentTestCount/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {			
			//result = JSON.parse(result);			
			$('#CountGroupRecord').val(result);
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function CustomInvestigationCurrentFile() {
	if ($('#CountGroupRecord').val() < 2) {
		CustomInvestigationFile();
	}
	else {
		CustomInvestigationFileX();
    }
}
function CustomInvestigationFile() {
	$('.DocumentContainerDetails').summernote('destroy');
	var empobj = {
		testid: $('#ALLTestCode').val()
	}
	$.ajax({
		url: "/Master/AddResultNewDocMaster/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			$('#TestDocumentain').val(result.documentFile);
			WordFormationg();
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function CustomInvestigationFileX() {	
	$('.DocumentContainerDetails').summernote('destroy');
	var empobj = {		
		testid: $('#ALLTestCode').val()
	}
	$.ajax({
		url: "/Master/AddPatientResultNewDocItem/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			$('#TestDocumentain').val(result.testDetails);			
			WordFormationg();
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function WordFormationg() {
	$('.DocumentContainerDetails').summernote({
		toolbar: [
			['style', ['style']],
			['font', ['bold', 'italic', 'underline', 'strikethrough', 'superscript', 'subscript', 'clear']],
			['fontsize', ['fontsize']],
			['fontname', ['fontname']],
			['color', ['color']],
			['para', ['ul', 'ol', 'paragraph']],
			['table', ['table']],
			['insert', ['link', 'picture', 'video']],
			['view', ['fullscreen', 'codeview', 'help']],
		],
		fontNames: ['Arial', 'Arial Black', 'Comic Sans MS', 'Courier New', 'Helvetica', 'Impact', 'Tahoma', 'Times New Roman', 'Verdana', 'Roboto', 'Yu Gothic'],
		fontSizes: ['8', '9', '10', '11', '12', '14', '16', '18', '20', '22', '24', '26', '28', '30', '32', '34', '36'],
		height: screen.height - 410		
	});
}
