var rowno = 0; var projects = []; var projects1 = []; var totalBilubin = 0; var totalBilubinD = 0; var totalBUN = 0;
var STRTotal = 0; var SCHTotal = 0; var HDLTotal = 0; var LDLTotal = 0; var ProtTotal = 0; var Testplz = 0; var Contplz = 0;
var ALBTotal = 0; var GLBTotal = 0; var HBTotal = 0; var RBCTotal = 0; var PCVBTotal = 0; var MATotal = 0; var UCTotal = 0;
var APTTATotal = 0; var APTTBTotal = 0; var CD8ATotal = 0; var CD8BTotal = 0; var EstAverage = 0;
$(document).ready(function () {
	$('#ALLTestCode').hide();	
	//HeadChangeColHideShow();
	//$('.DocumentContainerDetails').summernote({
	//	height: screen.height - 420
	//});		
	DisplayInvestigationFile();
	if ($('#RptDate').val().trim() == "") {
		$('#RptDate').val(CurrentDateTime());
    }
	$("#TestListId").focus();	

	$.widget("custom.tablecompleteG", $.ui.autocomplete, {
		_create: function () {
			this._super();
			this.widget().menu("option", "items", "> li:not(.ui-autocomplete-header)");
		},
		_renderMenu(ul, items) {
			var self = this;
			ul.addClass("helpwidthTestGroup");
			let header = {
				id: "Id",
				value: "Result",
				isheader: true
			};
			self._renderItemData(ul, header);
			$.each(items, function (index, item) {
				self._renderItemData(ul, item);
			});
		},
		_renderItemData(ul, item) {
			return this._renderItem(ul, item).data("ui-autocomplete-item", item);
		},
		_renderItem(ul, item) {
			var $li = $("<li class='ui-menu-item' role='presentation'></li>");
			if (item.isheader)
				$li = $("<li class='ui-autocomplete-header' role='presentation'  style='font-weight:bold !important;background-color:#94974a;color:white;'></li>");
			var $content = "<div class='row ui-menu-item-wrapper'>" + "<div class='col-sm-1' hidden>" + item.id + "</div>" + "<div class='col-sm-11'>" + item.value + "</div>" + "</div>";
			$li.html($content);
			return $li.appendTo(ul);
		}
	});
	
});

function UpdateDoctorAppproved() {		
	var empobj = {
		id: $('#PatientId').val(),
		rptdate: $('#RptDate').val() //$('#RowId').val()
	}
	$.ajax({
		url: "/Master/ApprovedByDoctor/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			//alert("Approved successfully........");								
			window.location = 'Search-Patient-Result?Search=Yes'
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function GetAllDocumentGroupTestFileX() {
	SearchFileTrueFalse();
	$('#ALLTestCode').empty();
	var empobj = {
		CompId: $('#CompId').val(),
		testgidX: $('#TestListId').val() //$('#RowId').val()
	}
	$.ajax({
		url: "/Master/GetTestDocMasterFile/",
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
function SearchFileTrueFalse() {	
	var empobj = {
		patid: $('#PatientId').val(),
		testgidX: $('#TestListId').val()
	}
	$.ajax({
		url: "/Master/GetPatientDocTrueFalse/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			if (parseInt(result) > 0) {
				$('#ALLTestCode').show();
			}
			else {
				$('#ALLTestCode').hide();
            }
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
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
function footerPrintValue() {
	var footerval = 'flexRadioDefault1';
	var xx;
	//alert(idValue, "False");	
	if ($('#' + footerval).attr('checked')) {
		$('#' + footerval).attr('checked', false);	
		xx = false;
		//alert("False");
	} else {
		$('#' + footerval).attr('checked', 'checked');		
		xx = true;
		//alert("True");
	}	
	$.ajax({
		url: "/Master/UpdatePageSetupFile",
		method: "Post",
		data: { compid: $('#CompId').val(),truefalse: xx },
		success: function (result) {
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function FindIndexNo(idValue,IdNo) {	
	var chk = ('detailtestList_' + IdNo + '__isSelected');
	var xx;	
	//alert(idValue, "False");	
		if ($('#' + chk).attr('checked')) {
			$('#' + chk).attr('checked', false);
			//alert("False" + idValue);
			xx = true;
		} else {
			$('#' + chk).attr('checked', 'checked');
			//alert("True" + idValue );
			xx = false;
		}
	
	$.ajax({		
		url: "/Master/UpdateTestPrintOption",
		method: "Post",
		data: { patid: $('#PatientId').val(), testid: idValue, truefalse: xx},
		success: function (result) {				
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	//alert(idValue, xx);
}
function TestCodeDisplay() {
	$('#MessageId').text($('#PatientInvestigationViewModels_' + $('#RowId').val() + '__TestMasterViewModels_TestCode').val());	
}
function HeadChangeColHideShow() {
	$('#TestSubMasterWidth').hide();
	$('#DocumentContainer').hide();
	$.ajax({
		url: "/Master/FindTestMasterDoc",
		method: "GET",
		//data: { testid: $('#TestListId').val()},
		data: { testid: $('#PatientInvestigationViewModels_' + "0" + '__TestIdX').val()},
		success: function (result) {	
			result.documentType == "Reading" ? $('#TestSubMasterWidth').show() : $('#DocumentContainer').show();
			$('#DocType').val(result.documentType);
			$('#ModelId').modal('hide');
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
		
}
function TestFilterResult() {
	projects.empty;
	projects.length = 0;
	$.ajax({
		url: "/Master/FindTestRsult",
		method: "GET",
		//data: { testid: $('#TestListId').val(), testDetailName: $('#PatientInvestigationViewModels_' + $('#RowId').val() + '__TestDetailsF').val().trim() },
		data: { testid: $('#PatientInvestigationViewModels_' + $('#RowId').val() + '__TestIdX').val(), testDetailName: $('#PatientInvestigationViewModels_' + $('#RowId').val() + '__TestDetailsF').val().trim() },
		success: function (result) {
			//result = JSON.parse(result);
			if (result.length > 0) {
				$.each(result, function (key, item) {
					projects.push({
						id: item.id,
						value: item.patientValue
					});
				});
			}
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function ValidReadOnly() {
	var valuetype;	
		valuetype = $('#PatientInvestigationViewModels_' + $('#RowId').val() + '__TestLocked').val();
		if (valuetype === "L" || valuetype === "M" || valuetype === "Y") {
			$('#PatientInvestigationViewModels_' + $('#RowId').val() + '__PatResult').prop('readonly', true);
			$('#PatientInvestigationViewModels_' + $('#RowId').val() + '__PatResult').addClass('input-disabled');
		}
		else {
			$('#PatientInvestigationViewModels_' + $('#RowId').val() + '__PatResult').prop('readonly', false);
		}
}
function TestResultSearchRecord() {
	$(".ModeResultRecord").tablecompleteG({
		position: { my: "left top", at: "right top"  },
		minLength: 0,
		source: projects,
		select: function (event, ui) {			
			$('#PatientInvestigationViewModels_' + $('#RowId').val() + '__PatResult').val(ui.item.value);			
			return false;
		}
	});
}
function FindRowIndex(element) {
	$("#RowId").val(0);
	var rowJavascript = element.parentNode.parentNode;
	var id = (rowJavascript.rowIndex - 1);
	$("#RowId").val(id);	
	//TestFilterResult();	
}

function DisplayInvestigationFile() {	
	$('#orderItemContinaer').empty();
	$('#TestDocumentain').empty();
	$('.DocumentContainerDetails').summernote('destroy');
	$('#ModelId').modal('show');
	$.ajax({
		async: true,
		data: $('#form').serialize(),
		type: "POST",
		url: '/Master/AddPatientResultItem',
		success: function (partialView) {			
			console.clear;
			console.log("partialView: " + partialView);							
			$('#orderItemContinaer').html(partialView);
			$('.ModeResultRecord').focus();		
			$('#TestDocumentain').val($('#PatientInvestigationViewModels_0__TestDetails').val());
			WordFormationg();
			//$('.DocumentContainerDetails').summernote({
			//		height: screen.height - 420
			//});
			DLCountValided();
			HeadChangeColHideShow();           
			//$('#ModelId').modal('hide');
			//alert($('#PatientInvestigationViewModels_0__TestDetails').val());
			//$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestGId').val($('#modeno').val());
			//$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Mode').val($('#modetype').val());
		}
	});	
}
function DLCountValided() {
	var table = document.getElementById('orderItemContinaer');
	var rowscount = table.rows.length;
	var TotalPcs = false;
	for (var i = 0; i < rowscount; i++) {
		if ($('#PatientInvestigationViewModels_' + i + '__TestDetailsF').val().trim() == "BASOPHILS" ) {
			TotalPcs = true;
		}
	}
	$("#DLCCount").attr('checked', TotalPcs);	
}
function DLCountFormating() {
	if ($('input[name=DLCCount]').is(':checked')) {
		var table = document.getElementById('orderItemContinaer');
		var rowscount = table.rows.length;
		var TotalPcs = 0;
		for (var i = 0; i < rowscount; i++) {
			if ($('#PatientInvestigationViewModels_' + i + '__TestDetailsF').val().trim() == "BASOPHILS"||
				$('#PatientInvestigationViewModels_' + i + '__TestDetailsF').val().trim() == "EOSINOPHILS" ||
				$('#PatientInvestigationViewModels_' + i + '__TestDetailsF').val().trim() == "MONOCYTES" ||
				$('#PatientInvestigationViewModels_' + i + '__TestDetailsF').val().trim() == "LYMPHOCYTES" ||
				$('#PatientInvestigationViewModels_' + i + '__TestDetailsF').val().trim() == "POLYMORPHS" ||
				$('#PatientInvestigationViewModels_' + i + '__TestDetailsF').val().trim() == "NEUTROPHILS") {
				var inputVal = $('#PatientInvestigationViewModels_' + i + '__PatResult').val().trim() == "" || isNaN($('#PatientInvestigationViewModels_' + i + '__PatResult').val()) == true ? 0 : $('#PatientInvestigationViewModels_' + i + '__PatResult').val();
				TotalPcs = parseInt(TotalPcs) + parseInt(inputVal);
			}
		}
		$("#DLCMessageId").html("Total DLC Count Values : " + TotalPcs);
		//if (TotalPcs != 100) {
		//	$("#submit").attr('disabled', true);
		//}
		//else {
		//	$("#submit").attr('disabled', false);
  //      }
	}
}
function TestPlzValue() {
	var testformuladec = 0;
	//EstAverage
	if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "GLYCOSYLATED HAEMOGLOBIN ( HBA1C )") {
		EstAverage = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();		
	}
	if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "ESTIMATED AVERAGE GLUCOSE" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "ESTIMATED AVERRAGE GLUCOSE") {
		testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());		
		if (parseFloat(EstAverage) > 0) {
			var estval = parseFloat(EstAverage) * parseFloat(28.6) - parseFloat(46.7);
			$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(estval).toFixed(testformuladec));
		}
	}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "CONTROL PLASMA") {
			Contplz = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "TEST PLASMA") {
			Testplz = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}	
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "INR VALUE") {
			testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
			if (parseFloat(Contplz) > 0) {
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(Testplz / Contplz).toFixed(testformuladec));
			}
		}

		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "CONTROL VALUE") {
			APTTATotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "PATIENT VALUE") {
			APTTBTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "RATIO") {
			testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
			if (parseFloat(APTTATotal) > 0) {
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(APTTBTotal / APTTATotal).toFixed(testformuladec));
			}
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "CD 4 LYMPHOCYTE ABSOLUTE" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "ABSOLUTE CD4+(T-HELPER)") {
			CD8ATotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "CD 8 LYMPHOCYTE ABSOLUTE" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "ABSOLUTE CD8+(T-SUPPRESSOR CELLS)") {
			CD8BTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "CD 4 / CD 8 RATIO" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "RATIO CD4/CD8") {
			testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
			if (parseFloat(CD8BTotal) > 0) {
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(CD8ATotal / CD8BTotal).toFixed(testformuladec));
			}
		}

		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "URINE ALBUMIN" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "URINE MICRO ALBUMIN" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "URINE FOR MICROALBUMIN") {
			MATotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "URINE CREATININE" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "URINE MICRO CREATININE") {
			UCTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}

		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "URINE ALBUMIN/CREATININE RATIO ( ACR )" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "URINE ALBUMIN / CREATININE RATIO ( ACR )" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "URINE MICRO ALBUMIN / CREATININE RATIO ( ACR )" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "URINE MICRO ALBUMIN/CREATININE RATIO ( ACR )" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "ACR" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "A.C.R. )" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MICROALBUMIN / CREATININE RATIO" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MICROALBUMIN/CREATININE RATIO") {
			testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
			if (parseFloat(UCTotal) > 0) {
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(MATotal / UCTotal).toFixed(testformuladec));
			}
		}	
}

function SBilibunCount() {
	var testformuladec =0;
	
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "SERUM BILIRUBIN ( TOTAL )" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S. BILIRUBIN ( TOTAL )" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S.BILIRUBIN ( TOTAL )") {
			totalBilubin = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "DIRECT") {
			totalBilubinD = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "INDIRECT") {
			testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
			$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(parseFloat(totalBilubin) - parseFloat(totalBilubinD)).toFixed(testformuladec));
		}
	
}
function SBUNCount() {
	var testformuladec = 0;
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S. UREA" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S.UREA" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "UREA" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "SERUM UREA") {
			totalBUN = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "B.U.N." || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "BUN" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "SERUM BUN") {
			if (parseFloat(totalBUN) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(totalBUN * 0.467).toFixed(testformuladec));
			}
		}

	var testformula = $('#TestFormulaApply').val();
	if (testformula == "Apply") {
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HEMOGLOBIN" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HAEMOGLOBIN" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HB" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HB%" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HB %" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "H.B.%" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "H.B. %") {
			HBTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "RBCS COUNT" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "R.B.C.S COUNT" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "R.B.CS COUNT") {
			RBCTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HAEMATOCRIT OR PACKED CELL VOLUME (PCV)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HEAMATOCRIT OR PACKED CELL VOLUME (PCV)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HEMATOCRIT OR PACKED CELL VOLUME (PCV)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HEMATOCRIT / PACKED CELL VOLUME (PCV)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "PACKED CELL VOLUME (PCV)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "PCV") {
			PCVBTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}

		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MEAN CORPUSCULAR VOLUME (MCV)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MCV" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "M.C.V.") {
			if (parseFloat(RBCTotal) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(PCVBTotal * 10 / RBCTotal).toFixed(testformuladec));
			}
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MEAN CORPUSCULAR HEMOGLOBIN (MCH)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MEAN CORPUSCULAR HEMOGLOBIN" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MCH" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "M.C.H." || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MEAN CORPUSCULAR HAEMOGLOBIN (MCH)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MEAN CORPUSCULAR HAEMOGLOBIN") {
			if (parseFloat(RBCTotal) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(HBTotal * 10 / RBCTotal).toFixed(testformuladec));
			}
		}

		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MEAN CORPUSCULAR HEAM. CONC. (MCHC)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MEAN CORPUSCULAR HAEM. CONC. (MCHC)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MEAN CORPUSCULAR HEMOGLOBIN CONC. (MCHC)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MEAN CORPUSCULAR HAEMOGLOBIN CONC. (MCHC)" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "MCHC" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "M.C.H.C.") {
			if (parseFloat(PCVBTotal) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(HBTotal * 100 / PCVBTotal).toFixed(testformuladec));
			}
		}
	}
}
function SCholesterolCount() {
	var testformuladec = 0;
	
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S.CHOLESTEROL ( TOTAL )" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S. CHOLESTEROL ( TOTAL )" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "SERUM CHOLESTEROL ( TOTAL )") {
			SCHTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S.TRIGLYCERIDE" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S. TRIGLYCERIDE" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "SERUM TRIGLYCERIDE") {
			STRTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "HDL CHOLESTEROL") {
			HDLTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "LDL CHOLESTEROL") {
			LDLTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "TOTAL PROTEIN") {
			ProtTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "ALBUMIN") {
			ALBTotal = $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val();
		}

		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "VLDL CHOLESTEROL") {
			if (parseFloat(STRTotal) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(STRTotal * 0.2).toFixed(testformuladec));
			}
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "LDL CHOLESTEROL") {
			if (parseFloat(SCHTotal) > 0 && parseFloat(HDLTotal) > 0 && parseFloat(STRTotal) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(parseFloat(SCHTotal) - (parseFloat(HDLTotal) + parseFloat(STRTotal * 0.2))).toFixed(testformuladec));
			}
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S.CHOLESTEROL ( TOTAL )/HDL CHOLESTEROL" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "S. CHOLESTEROL ( TOTAL )/HDL CHOLESTEROL" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "SERUM CHOLESTEROL ( TOTAL )/HDL CHOLESTEROL") {
			if (parseFloat(SCHTotal) > 0 && parseFloat(HDLTotal) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(parseFloat(SCHTotal) / parseFloat(HDLTotal)).toFixed(testformuladec));
			}
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "LDL CHOLESTEROL/HDL CHOLESTEROL" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "LDL/HDL" || $('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "LDL / HDL") {
			if (parseFloat(LDLTotal) > 0 && parseFloat(HDLTotal) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(parseFloat(LDLTotal) / parseFloat(HDLTotal)).toFixed(testformuladec));
			}
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "GLOBULIN") {
			GLBTotal = parseFloat(ProtTotal) - parseFloat(ALBTotal);
			if (parseFloat(GLBTotal) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(GLBTotal).toFixed(testformuladec));
			}
		}
		if ($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TestDetailsF').val().trim() == "ALBUMIN/GLOBULIN RATIO") {
			if (parseFloat(GLBTotal) > 1 && parseFloat(ALBTotal) > 0) {
				testformuladec = parseInt($('#PatientInvestigationViewModels_' + $("#RowId").val() + '__TempDigitPlace').val());
				$('#PatientInvestigationViewModels_' + $("#RowId").val() + '__PatResult').val(parseFloat(ALBTotal / GLBTotal).toFixed(testformuladec));
			}
		}
}
function myfunction() {	
	/*
	 ElseIf Trim(B.TextMatrix(B.Row, 1)) = "VLDL Cholesterol" Then
              Combo9.Text = Format(Val(STRTotal) / 5, "##############.00")
        ElseIf Trim(B.TextMatrix(B.Row, 1)) = "LDL Cholesterol" Then
              Combo9.Text = Format((Val(SCHTotal) - (Val(HDLTotal) + (Val(STRTotal) / 5))), "##############.00")
       ElseIf Trim(B.TextMatrix(B.Row, 1)) = "S.Cholesterol ( Total )/HDL Cholesterol" Then
            Combo9.Text = Format(Val(SCHTotal) / Val(HDLTotal), "##############.00")
       ElseIf Trim(B.TextMatrix(B.Row, 1)) = "LDL Cholesterol/HDL Cholesterol" Then
            Combo9.Text = Format(Val(LDLTotal) / Val(HDLTotal), "##############.00")
       ElseIf Trim(B.TextMatrix(B.Row, 1)) = "Globulin" Then
              Combo9.Text = Format(Val(ProtTotal) - Val(ALBTotal), "##############.00")
              GLBTotal = Combo9.Text
          If Val(GLBTotal) < 0 Then
             Combo9.Text = ""
          End If

       ElseIf Trim(B.TextMatrix(B.Row, 1)) = "Albumin/Globulin ratio" Then
          If Val(GLBTotal) > 1 Then
              Combo9.Text = Format(Val(ALBTotal) / Val(GLBTotal), "##############.00") & " : 1"
           Else
              Combo9.Text = "" '"00"
           End If
	 */
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
		height: screen.height - 420
	});
}