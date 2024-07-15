$(document).ready(function () {
	$('#TestCode').focus();
	HeadChangeColHideShow();
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
		fontSizes: ['8', '9', '10', '11', '12', '14', '16', '18', '20', '22', '24', '26', '28', '30', '32', '34', '36'],
		height: screen.height - 500
	});
});
function FindRowIndex(element) {
	$("#RowId").val(0);
	var rowJavascript = element.parentNode.parentNode;
	var id = (rowJavascript.rowIndex - 1)
	$("#RowId").val(id);
	rowno = id;
}
function GrandRange() {
	var fromrange = $('#TestSubMasterViewModels_' + $('#RowId').val() + '__FromRange').val();
	var uptorange = $('#TestSubMasterViewModels_' + $('#RowId').val() + '__UptoRange').val();
	var rangesymble = $('#TestSubMasterViewModels_' + $('#RowId').val() + '__RangeSymble').val();
	$('#TestSubMasterViewModels_' + $('#RowId').val() + '__RangeDetails').val(fromrange + rangesymble + uptorange);
}
function HeadChangeColHideShow() {
	var doctype = $('#documentType').val();
	if (doctype == "Reading") {
		$('#TestSubMasterWidth').show();
		$('#DocumentContainer').hide();
	}
	else {
		$('#TestSubMasterWidth').hide();
		$('#DocumentContainer').show();
	}
}
function HeadChangeCol() {
	var doctype = $('#documentType').val();
	var html = '';
	if (doctype == "Reading") {
		$('#btnAdd').show();
		html += '<tr>';
		html += '<th style="width:1%;" class="text-center">##</th>';
		html += '<th style="width:3%">SrNo.</th>';
		html += '<th style="width:23%;">Test Details</th>';
		html += '<th style="width:5%;">Col 1</th>';
		html += '<th style="width:5%;">Col 2</th>';
		html += '<th style="width:5%;">Col 3</th>';
		html += '<th style="width:5%;">Col 4</th>';
		html += '<th style="width:3%;">T/F</th>';
		html += '<th style="width:3%;">Lock</th>';
		html += '<th style="width:3%;">Sex</th>';
		html += '<th style="width:5%;">Unit</th>';
		html += '<th style="width:4%;">Min</th>';
		html += '<th style="width:2%;">**</th>';
		html += '<th style="width:4%;">Max</th>';
		html += '<th style="width:8%;">Range</th>';
		html += '<th style="width:2%;">Age1</th>';
		html += '<th style="width:2%;">Age2</th>';
		html += '<th style="width:5%;">Result</th>';
		html += '<th style="width:4%;">Min</th>';
		html += '<th style="width:4%;">Max</th>';
		html += '</tr>';
	}
	else {
		$('#btnAdd').hide();
		html += '<tr>';
		html += '<th style="width:1%;" class="text-center">##</th>';
		html += '<th style="width:2%">SrNo.</th>';
		html += '<th style="width:62%;">Test Details</th>';
		html += '<th style="width:35%;">#</th>';
		html += '</tr>';
	}
	$('#tthead').html(html);
	RowChangeCol();
}
function RowChangeCol() {
	var doctype = $('#documentType').val();
	var html = '';
	if (doctype == "Reading") {
		//html += '<tr>';
		//html += '<td class="text-center">'
		//		'<a href="#" id="Delbutton" type="button" onclick="deleteRow(this)" class="mt-1"><i class="fas fa-times fa-1x icon-color-red"></i></a>'		
		//		'</td>';
		//html += '<td><input asp-for="TempNo" class="form-control form-control-sm"/></td>';
		//html += '<td><textarea asp-for="TestDetails" class="form-control form-control-sm small ModeDetailRecordX" rows="4" onfocus="FindRowIndex(this);"></textarea ></td>';
		//html += '<td><input asp-for="ColFirst" class="form-control form-control-sm " onfocus="FindRowIndex(this);" /></td>';
		//html += '<td><input asp-for="ColSecond" class="form-control form-control-sm"/></td>';
		//html += '<td><input asp-for="ColThird" class="form-control form-control-sm" /></td>';
		//html += '<td><input asp-for="ColFourth" class="form-control form-control-sm text-sm-right" onfocus="FindRowIndex(this)" /></td>';
		//html += '<td><select asp-for="VisualTrueFalse" class="form-control form-control-sm"><option value="0">F</option><option value="1">T</option></select></td>';
		//html += '<td><select asp-for="TestLocked" class="form-control form-control-sm"><option value="0">N</option><option value="1">Y</option></select></td>';
		//html += '<td><select asp-for="Gender" class="form-control form-control-sm"><option value="A">A</option><option value="M">M</option><option value="F">F</option></select></td>';
		//html += '<td><input asp-for="Units" class="form-control form-control-sm text-sm-right" onfocus="FindRowIndex(this)"/></td>';
		//html += '<td><input asp-for="FromRange" class="form-control form-control-sm text-sm-right" onfocus="FindRowIndex(this)" /></td>';
		//html += '<td><input asp-for="RangeSymble" class="form-control form-control-sm text-sm-right" onfocus="FindRowIndex(this)" /></td>';
		//html += '<td><input asp-for="UptoRange" class="form-control form-control-sm text-sm-right" onblur="GrandRange();" /></td>';
		//html += '<td><input asp-for="RangeDetails" class="form-control form-control-sm text-sm-right" /></td>';
		//html += '<td><input asp-for="FromAge" class="form-control form-control-sm text-sm-right" onkeypress="return isNumber(event)" /></td>';
		//html += '<td><input asp-for="UptoAge" class="form-control form-control-sm text-sm-right" onkeypress="return isNumber(event)"/></td>';
		//html += '<td><input asp-for="DefaultResult" class="form-control form-control-sm text-sm-right" /></td>';
		//html += '<td><input asp-for="MiniRange" class="form-control form-control-sm text-sm-right" onkeypress="return isNumber(event)" /></td>';
		//html += '<td><input asp-for="MaxRange" class="form-control form-control-sm text-sm-right" onkeypress="return isNumber(event)" /></td>';
		//html += '</tr>';
		$.ajax({
			async: true,
			data: $('#testform').serialize(),
			type: "POST",
			url: '/Master/AddTestSubItem',
			success: function (partialView) {
				console.log("partialView: " + partialView);
				$('#orderItemContinaer').html(partialView);
				$('.ModeDetailRecordX').focus();
			}
		});
	}
	else {
		html += '<tr>';
		html += '<td class="text-center">'
		'<a href="#" id="Delbutton" type="button" onclick="deleteRow(this)" class="mt-1"><i class="fas fa-times fa-1x icon-color-red"></i></a>'
		'</td>';
		html += '<td><input asp-for="TempNo" class="form-control form-control-sm" value="1"/></td>';
		html += '<td><textarea asp-for="TestDetails" class="form-control form-control-sm small ModeDetailRecordX" rows="15" onfocus="FindRowIndex(this);"></textarea ></td>';
		html += '<td></td>';
		html += '</tr>';
		$('#orderItemContinaer').html(html); $('.ModeDetailRecordX').focus();
	}
}

$("#btnAdd").on('click', function () {
	$.ajax({
		async: true,
		data: $('#testform').serialize(),
		type: "POST",
		url: '/Master/AddTestSubItem',
		success: function (partialView) {
			console.log("partialView: " + partialView);
			$('#orderItemContinaer').html(partialView);
			$('.ModeDetailRecordX').focus();
		}
	});
});
$("#btnAddSale").on('click', function () {
	$.ajax({
		async: true,
		data: $('#testform').serialize(),
		type: "POST",
		url: '/Master/AddTestDetailsAddrows',
		success: function (partialView) {
			console.log("partialView: " + partialView);
			$('#orderItemContinaer').html(partialView);

		}
	});
});
$("#btnTestAdd").on('click', function () {
	$.ajax({
		async: true,
		data: $('#testform').serialize(),
		type: "POST",
		url: '/Master/AddTestSelectedItem',
		success: function (partialView) {
			console.log("partialView: " + partialView);
			$('#orderItemContinaer').html(partialView);

		}
	});
});

$("#btnBetweenTestAdd").on('click', function () {
	$.ajax({
		async: true,
		data: $('#testform').serialize(),
		type: "POST",
		url: '/Master/AddTestBetweenInsertRow',
		success: function (result) {
			if ($('#Id').val() > 0) {
				location.reload(true);
			}
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
			data: $('#testform').serialize(),
			type: "Post",
			url: "/Master/DeleteTestSubItem"
				
			
		})		
			.done(function (partialViewResult) {
				$("#orderItemContinaer").html(partialViewResult);
				if ($('#Id').val() > 0) {
					location.reload(true);
				}
			});
      
	}
}
function GetSearchTestDetails() {
	var empobj = {
		CompId: $('#CompId').val(),
		TestGroupIdx: $('#TestGroupIdx').val(),
		NameX: $('#NameX').val()
	}
	$.ajax({
		url: "/Master/GetSearchTestFile/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			var html = '';
			if (result.length > 0) {
				$.each(result, function (key, item) {
					html += '<tr >';
					html += '<td hidden>' + item.id + '</td>';
					html += '<td>' + item.testCode + '</td>';
					html += '<td class="text-sm-right" style="max-width:8%;">' + parseFloat(item.rate).toFixed(2) + '</td>';
					html += '<td class="actionListButtonWidthAgent">' +
						'<a href="Test-File?id=' + item.id + '"' + '<span><i class="far fa-edit mr-3 fa-1x icon-color-green"></i></span></a>' +
						'</td >';
					html += '</tr>';
				});
			}
			else {
				html += '<tr>';
				html += '<td colspan="4"> ' + '<h3 class="text-danger text-center">No Record found......</h3>' + '</td>';
				html += '</tr>';
			}
			$('.tbodyTest').html(html);
			// '<a href="AddressBook-Delete-File?id=' + item.ledgerMasterId + '"' +  '<span><i class="fas fa-times fa-2x icon-color-red"></i></span></a>' +
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}