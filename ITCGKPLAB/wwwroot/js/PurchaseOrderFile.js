var rowno = 0; var projects = []; var projects1 = [];
$(document).ready(function () {
	$("#CompId").focus();
	if ($('#SOId').val() == null || $('#SOId').val() == 0) {
		$('#ODate').val(CurrentDate());
	}
	GrandTotalAmtCount();
	$('#STVNoX').text($('#SOVNo').val());
	$('#STDateX').text($('#ODate').val());
	
	// Item File
	$("#CompId").blur(function () {
		projects.length = 0;
		$.ajax({
			url: "/Financial/FindItemRecord",
			method: "GET",
			//data: { CompId: $('#CompId').val() },
			success: function (result) {
				//result = JSON.parse(result);
				if (result.length > 0) {
					$.each(result, function (key, item) {
						projects.push({
							id: item.itemId,
							value: item.itemName,							
							hsncode: item.ihsnCode,
							gstpercentage: item.gstPer,
							unitcase: item.unitCase,
							cessrate : item.cessPer
						});
					});
				}
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
		FilterAccount();
	});

	$.widget("custom.tablecomplete", $.ui.autocomplete, {
		_create: function () {
			this._super();
			this.widget().menu("option", "items", "> li:not(.ui-autocomplete-header)");
		},
		_renderMenu(ul, items) {
			var self = this;
			ul.addClass("helpwidthItemOpenStock");
			let header = {
				id: "Id",
				value: "Item's  Name",				
				hsncode: "HSN Code",
				gstpercentage: "GST %",
				unitcase: "1 Case",
				cessrate :"Cess Rate",
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
				$li = $("<li class='ui-autocomplete-header small' role='presentation'  style='font-weight:bold !important; font-size:18px;background-color:#94974a;color:white;'></li>");
			var $content = "<div class='row ui-menu-item-wrapper small'>" + "<div class='col-sm-1' hidden>" + item.id + "</div>" + "<div class='col-sm-6'>" + item.value + "</div>" + "<div class='col-sm-2'>" + item.hsncode + "</div>" + "<div class='col-sm-2' style='text-align: right;'>" + item.gstpercentage + "</div>" + "<div class='col-sm-2' style='text-align: right;'>" + item.unitcase + "</div>" +  "<div class='col-sm-2' style='text-align: right;' hidden>" + item.cessrate + "</div>" + "</div>";
			$li.html($content);
			return $li.appendTo(ul);
		}
	});
	// create the autocomplete	
	//$('#PurchaseOrderDetailViewModels_' + $('#RowId').val() + '__OpnItemName').tablecomplete({	
	$('.OpenItemDetailRecord').tablecomplete({
		//position: { my: "left bottom", at: "right bottom"},
		minLength: 1,
		source: projects,
		select: function (event, ui) {
			$('#PurchaseOrderDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#PurchaseOrderDetailViewModels_' + $('#RowId').val() + '__SSItemName').val(ui.item.value);
			$('#PurchaseOrderDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
			return false;
		}
	});

	// account Help File
	// projects1.length = 0;
	//FilterAccount();

	$.widget("custom.tablecompleteG", $.ui.autocomplete, {
		_create: function () {
			this._super();
			this.widget().menu("option", "items", "> li:not(.ui-autocomplete-header)");
		},
		_renderMenu(ul, items) {
			var self = this;
			ul.addClass("helpwidthAccountFile");
			let header = {
				id: "Id",
				value: "A/c Name",
				address: "Address",
				mobileno: "Mobile No.",
				balance: "Bal. Amt.",
				custstateid: "State Id",
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
			var $content = "<div class='row ui-menu-item-wrapper small'>" + "<div class='col-sm-1' hidden>" + item.id + "</div>" + "<div class='col-sm-4'>" + item.value + "</div>" + "<div class='col-sm-4'>" + item.address + "</div>" + "<div class='col-sm-2'>" + item.mobileno + "</div>" + "<div class='col-sm-2 text-right'>" + item.balance + "</div>" + "<div class='col-sm-1 text-right' hidden>" + item.custstateid + "</div>" + "</div>";
			$li.html($content);
			return $li.appendTo(ul);
		}
	});
});
function FilterAccount() {
	projects1.length = 0;
	$.ajax({
		url: "/Financial/FindAccountRecord",
		method: "GET",
		data: { CompId: $('#CompId').val() },
		success: function (result) {
			//result = JSON.parse(result);
			if (result.length > 0) {
				$.each(result, function (key, item) {
					projects1.push({
						id: item.ledgerMasterId,
						value: item.partyName,
						address: item.address1,
						mobileno: item.mobileNo1,
						balance: (item.closeAc == 1 ? parseFloat(item.closeAmt).toFixed(2) + " Dr" : parseFloat(item.closeAmt).toFixed(2) + " Cr"),
						custstateid: item.ledStateId
					});
				});
			}
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function AccountSearchRecord() {
	$(".AccountDetailRecord").tablecompleteG({
		//position: { my: "top bottom", at: "right top" },
		minLength: 1,
		source: projects1,
		select: function (event, ui) {			
			$('#AcCode').val(ui.item.id);
			$('#CustName').val(ui.item.value);
			$('#CustAddress1').val(ui.item.address);
			return false;
		}
	});
}
function ItemSearchRecord() {
	$('.OpenItemDetailRecord').tablecomplete({
		//position: { my: "left bottom" , at: "right bottom" },
		minLength: 1,
		source: projects,
		select: function (event, ui) {
			$('#PurchaseOrderDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#PurchaseOrderDetailViewModels_' + $('#RowId').val() + '__SSItemName').val(ui.item.value);
			$('#PurchaseOrderDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
			return false;
		}
	});
}
function FindRowIndex(element) {
	$("#RowId").val(0);
	var rowJavascript = element.parentNode.parentNode;
	var id = (rowJavascript.rowIndex - 1)
	$("#RowId").val(id);
	rowno = id;
}

function GrandTotalAmtCount() {
	var table = document.getElementById('orderItemContinaer');
	var rowscount = table.rows.length;	
	var TotalCase = 0;
	for (var i = 0; i < rowscount; i++) {
		TotalCase = parseFloat(TotalCase) + parseFloat($('#PurchaseOrderDetailViewModels_' + i + '__CasePcs').val());
	}	

	$('#TotalAmtX').text("Total Qty " + TotalCase);
}
function GetPurVoucherSrNo() {
	if ($('#SOId').val() == null || $('#SOId').val() == 0) {
		$.ajax({
			url: "/Transaction/GetOrderFileSrNo/",
			method: "GET",
			data: { cmpId: $('#CompId').val() },
			success: function (Data) {
				$('#SOVNo').val(Data);
				$('#STVNoX').text(Data);
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
	}
}
$("#btnAdd").on('click', function () {
	$.ajax({
		async: true,
		data: $('#purchaseOrderform').serialize(),
		type: "POST",
		url: '/Transaction/AddOrderFileItem',
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
			data: $('#purchaseOrderform').serialize(),
			url: "/Transaction/DeleteOrderFileItem",
			type: "Post",
		})
			.done(function (partialViewResult) {
				$("#orderItemContinaer").html(partialViewResult);
				if ($('#SOId').val() > 0) {
					location.reload(true);
				}
			});
	}
}
