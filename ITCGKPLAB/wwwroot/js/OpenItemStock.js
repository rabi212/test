var rowno = 0; var projects = [];
$(document).ready(function () {
	$("#CompId").focus();
	if ($('#OpnId').val() == null || $('#OpnId').val() == 0) {
		GetOpenItemVoucherSrNo();
		TotalPurMRPAmtCount();
		$('#OpnDate').val(CurrentDate());
	}
	$("#CompId").blur(function () {
		projects.length = 0;
		$.ajax({
			url: "/Financial/FindItemRecord",
			method: "GET",
			//data: { cmpid: $('#CompId').val() },
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
	//$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__OpnItemName').tablecomplete({	
	$('.OpenItemDetailRecord').tablecomplete({
		//position: { my: "left bottom", at: "right bottom"},
		minLength: 1,
		source: projects,
		select: function (event, ui) {
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__ItemName').val(ui.item.value);
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__UnitCase').val(ui.item.unitcase);
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__CessPer').val(ui.item.cessrate);
			return false;
		}
	});
});
function ItemSearchRecord() {
	$('.OpenItemDetailRecord').tablecomplete({
		//position: { my: "left bottom" , at: "right bottom" },
		minLength: 1,
		source: projects,
		select: function (event, ui) {
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__ItemName').val(ui.item.value);
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__UnitCase').val(ui.item.unitcase);
			$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__CessPer').val(ui.item.cessrate);
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
function OpenTotalPcs() {
	
	var opnCase = isNaN($('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__CasePcs').val()) == true || $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__CasePcs').val().trim() == "" ? 0 : $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__CasePcs').val();
	var freeunit = isNaN($('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__FreePcs').val()) == true || $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__FreePcs').val().trim() == "" ? 0 : $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__FreePcs').val();
	var caseunit = isNaN($('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__UnitCase').val()) == true || $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__UnitCase').val().trim() == "" ? 1 : $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__UnitCase').val();
	
	var totalpcs = parseFloat((parseFloat(opnCase) * parseFloat(caseunit))).toFixed(2);
	var nettotalpcs = parseFloat( parseFloat(totalpcs) + parseFloat(freeunit) ).toFixed(2) ;
	$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val(nettotalpcs);
}
function OpenItemPurMRPAmount() {
	var totalpcs = isNaN($('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val()) == true || $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val().trim() == "" ? 0 : $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val();
	var purrate = isNaN($('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__PurRate').val()) == true || $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__PurRate').val().trim() == "" ? 0 : $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__PurRate').val();
	var mrp = isNaN($('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__MRP').val()) == true || $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__MRP').val().trim() == "" ? 0 : $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__MRP').val();
	var caseunit = isNaN($('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__UnitCase').val()) == true || $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__UnitCase').val().trim() == "" ? 1 : $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__UnitCase').val();
	var gstrate = isNaN($('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__GSTPer').val()) == true || $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__GSTPer').val().trim() == ""  ? 0 : $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__GSTPer').val();
	var totalcase = totalpcs / caseunit
	var puramt = parseFloat(totalcase * purrate).toFixed(2);
	var cessrate = isNaN($('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__CessPer').val()) == true || $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__CessPer').val().trim() == "" ? 0 : $('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__CessPer').val();
	var cessamt = parseFloat(puramt * (cessrate * 0.01)).toFixed(2);

	$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__CessAmt').val(cessamt);
	$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__PurAmt').val(puramt);
	var salerate = parseFloat(mrp / caseunit).toFixed(2);
	$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__SaleRate').val(salerate);
	var mrpamt = parseFloat(mrp * totalcase).toFixed(2);
	$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__MRPAmt').val(mrpamt);
	var gstamt = parseFloat(puramt * gstrate * 0.01).toFixed(2);
	
	var netpuramt = parseFloat( parseFloat(puramt) + parseFloat(cessamt) + parseFloat(gstamt)).toFixed(2);
	var netpurrate = parseFloat(netpuramt / totalcase).toFixed(2);
	$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__NetPurAmt').val(netpuramt);
	$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__NetPurRate').val(netpurrate);
}
function TotalPurMRPAmtCount() {
	var table = document.getElementById('orderItemContinaer');
	var rowscount = table.rows.length;
	var TotalPcs = 0; var TotalPurAmt = 0; var TotalMRPAmt = 0;
	for (var i = 0; i < rowscount; i++) {
		TotalPcs = parseFloat(TotalPcs) + parseFloat($('#OpenItemMasterDetailViewModels_' + i + '__TotalPcs').val());
		TotalPurAmt = parseFloat(TotalPurAmt) + parseFloat($('#OpenItemMasterDetailViewModels_' + i + '__NetPurAmt').val());
		TotalMRPAmt = parseFloat(TotalMRPAmt) + parseFloat($('#OpenItemMasterDetailViewModels_' + i + '__MRPAmt').val());
	}
	$('#GrandPcs').text("Total Pcs: " + parseInt(TotalPcs));
	$('#GrandMRPAmt').text("MRP Value : " + parseFloat(TotalMRPAmt).toFixed(2));
	$('#GrandPurAmt').text("Pur Amt : " + parseFloat(TotalPurAmt).toFixed(2));
	//alert(TotalPcs + ' ' + TotalPurAmt + ' ' + TotalMRPAmt);
}
function GetOpenItemVoucherSrNo() {
	if ($('#OpnId').val() == null || $('#OpnId').val() == 0) {
		$.ajax({
			url: "/Financial/GetOpenItemSrNo/",
			method: "GET",
			data: { cmpId: $('#CompId').val() },
			success: function (Data) {
				$('#OpnVNo').val(Data);
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
		data: $('#form').serialize(),
		type: "POST",
		url: '/Financial/AddOrderItem',
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
			data: $('#form').serialize(),
			url: "/Financial/DeleteOrderItem",
			type: "Post",
		})
			.done(function (partialViewResult) {
				$("#orderItemContinaer").html(partialViewResult);
				if ($('#OpnId').val() > 0) {
					location.reload(true);
				}
			});
	}
}