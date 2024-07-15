var rowno = 0; var projects = []; var projects1 = [];
$(document).ready(function () {
	
});
function FindRowIndex(element) {
	$("#RowId").val(0);
	var rowJavascript = element.parentNode.parentNode;
	var id = (rowJavascript.rowIndex - 1)
	$("#RowId").val(id);
	rowno = id;
}
function AddNewReportRow(element) {
	$('#RptId').val(element);
	$.ajax({
		async: true,		
		data: $('#purchaserecordform').serialize(),
		type: "POST",
		url: '/Master/AddOrderSerialNoFileItem',
		success: function (partialView) {
			console.log("partialView: " + partialView);
			$('#orderItemContinaer').html(partialView);
			$('#btnAdd_' + element).hide();
			//$('.OpenItemDetailRecord').focus();			
		}
	});

}
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
			data: $('#purchaserecordform').serialize(),
			url: "/Master/DeleteOrderSerialNoFileItem",
			type: "Post",
		})
			.done(function (partialViewResult) {
				$("#orderItemContinaer").html(partialViewResult);				
			});
	}
}