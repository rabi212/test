var rowno = 0; var projects = []; var projects1 = []; var projectsbat = [];
$(document).ready(function () {
	$("#CompId").focus();

	$('#TotalAmtX').text($('#TotalAmt').val());
	$('#DiscAmtX').text($('#DiscAmt').val());
	$('#IGSTTotalAmtX').text($('#IGSTTotalAmt').val());
	$('#SGSTTotalAmtX').text($('#SGSTTotalAmt').val());
	$('#CGSTTotalAmtX').text($('#CGSTTotalAmt').val());
	$('#NetAmtX').text($('#NetAmt').val());
	if ($('#STId').val() == null || $('#STId').val() == 0) {
		//GrandTotalAmtCount();
		$('#STDate').val(CurrentDate());
	}
	$('#STVNoX').text($('#STVNo').val());
	$('#STDateX').text($('#STDate').val());
	
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
	//$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__OpnItemName').tablecomplete({	
	$('.OpenItemDetailRecord').tablecomplete({
		//position: { my: "left bottom", at: "right bottom"},
		minLength: 1,
		source: projects,
		select: function (event, ui) {
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__STItemName').val(ui.item.value);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__UnitCase').val(ui.item.unitcase);
			// $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__CessPer').val(ui.item.cessrate);
			return false;
		}
	});

	// account Help File
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

	// Item Balance Help
	$.widget("custom.tablecompleteB", $.ui.autocomplete, {
		_create: function () {
			this._super();
			this.widget().menu("option", "items", "> li:not(.ui-autocomplete-header)");
		},
		_renderMenu(ul, items) {
			var self = this;
			ul.addClass("helpwidthBatchNoFile");
			let header = {
				id: "Exp.Date",
				value: "Batch No",
				mrp: "MRP",
				purrate: "Pur Rate",
				netpurrate: "Net PRate",
				salerate: "Sale Rate",
				netsalerate: "Net SRate",
				gstper: "GST %",
				cessper: "Cess %",
				onfreecase: "+Case",
				balqty: "Bal. Qty",
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
			var $content = "<div class='row ui-menu-item-wrapper small'>" + "<div class='col-sm-1'>" + item.id + "</div>" + "<div class='col-sm-2'>" + item.value + "</div>" + "<div class='col-sm-1 text-right'>" + item.mrp + "</div>" + "<div class='col-sm-1' text-right>" + item.purrate + "</div>" + "<div class='col-sm-1 text-right'>" + item.netpurrate + "</div>" + "<div class='col-sm-1 text-right'>" + item.salerate + "</div>" + "<div class='col-sm-1 text-right'>" + item.netsalerate + "</div>" + "<div class='col-sm-1 text-right'>" + item.gstper + "</div>" + "<div class='col-sm-1 text-right'>" + item.cessper + "</div>" + "<div class='col-sm-1 text-right'>" + item.onfreecase + "</div>" + "<div class='col-sm-1 text-right'>" + item.balqty + "</div>" + "</div>";
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
function FilterItemBatchNo() {
	projectsbat.length = 0;
	$.ajax({
		url: "/Financial/GetItemBalanceRecordHelp",
		method: "GET",
		data: { itemid: $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(), cmpid: $("#CompId").val()},
		success: function (result) {
			//result = JSON.parse(result);
			if (result.length > 0) {
				$.each(result, function (key, item) {
					projectsbat.push({
						id: item.expDate,
						value: item.batchNo,
						mrp: parseFloat(item.mrp).toFixed(2),
						purrate: parseFloat(item.purRate).toFixed(2),
						netpurrate: parseFloat(item.netPurRate).toFixed(2),
						salerate: parseFloat(item.saleRate).toFixed(2),
						netsalerate: parseFloat(item.netSaleRate).toFixed(2),
						gstper: parseFloat(item.gstPer).toFixed(2),
						cessper: parseFloat(item.cessPer).toFixed(2),
						onfreecase: parseFloat(item.onFreeCase).toFixed(2),
						balqty: parseFloat(item.balQty).toFixed(2)
					});
				});
			}
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function BatchSearchRecord() {
	$('.BatchDetailRecord').tablecompleteB({
		position: { my: "left top", at: "right bottom", collision: "fit none" }, // flip,fit,flipfit,none
		minLength: 1,
		source: projectsbat,
		select: function (event, ui) {
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__ExpDate').val(ui.item.id);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__BatchNo').val(ui.item.value);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__OnFreeCase').val(ui.item.onfreecase);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurRate').val(ui.item.purrate);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__NetPurRate').val(ui.item.netpurrate);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstper);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__MRP').val(ui.item.mrp);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__SaleRate').val(ui.item.salerate);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__NetSaleRate').val(ui.item.netsalerate);
			return false;
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
			$('#CustLedStateId').val(ui.item.custstateid);
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
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__STItemName').val(ui.item.value);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
			$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__UnitCase').val(ui.item.unitcase);
			// $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__CessPer').val(ui.item.cessrate);
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
	var opnCase = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__CasePcs').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__CasePcs').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__CasePcs').val();
	var freeunit = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__FreePcs').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__FreePcs').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__FreePcs').val();
	var caseunit = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__UnitCase').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__UnitCase').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__UnitCase').val();
	
	var totalpcs = parseFloat((parseFloat(opnCase) * parseFloat(caseunit))).toFixed(2);
	var nettotalpcs = parseFloat( parseFloat(totalpcs) + parseFloat(freeunit) ).toFixed(2) ;
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val(nettotalpcs);
}
function TotalPurchaseAmt() {
	var opnCase = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__CasePcs').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__CasePcs').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__CasePcs').val();
	var caserate = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurRate').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurRate').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurRate').val();

	var totalamt = parseFloat((parseFloat(opnCase) * parseFloat(caserate))).toFixed(2);
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurAmt').val(totalamt);
}
function TotalDiscountAmt() {
	//var discper2 = isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer2').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer2').val();
	//var discper3 = isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer3').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer3').val();
	var discAmt1 = 0; var discAmt2 = 0; var discAmt3 = 0;
	var puramt = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurAmt').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurAmt').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurAmt').val();
	var discper1 = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val();
	if (discper1 > 0) {
		discAmt1 = parseFloat(parseFloat(puramt) * parseFloat(discper1) * 0.01).toFixed(2);
	}
	else {
		discAmt1 = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val();
	}
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val(discAmt1);

	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val(0);
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val(0);
	//var puramt2 = parseFloat(parseFloat(puramt) - parseFloat(discAmt1)).toFixed(2);
	//if (discper2 > 0) {
	//	discAmt2 = parseFloat(parseFloat(puramt2) * parseFloat(discper2) * 0.01).toFixed(2);
	//}
	//else {
	//	discAmt2 = isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val();
	//}
	// $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val(discAmt2);
	//var puramt2 = parseFloat(parseFloat(puramt2) - parseFloat(discAmt2)).toFixed(2);
	//if (discper3 > 0) {
	//	discAmt3 = parseFloat(parseFloat(puramt2) * parseFloat(discper3) * 0.01).toFixed(2);
	//}
	//else {
	//	discAmt3 = isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val();
	//}
	// $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val(discAmt3);

	var totaldiscamt = parseFloat((parseFloat(discAmt1) + parseFloat(discAmt2) + parseFloat(discAmt3))).toFixed(2);
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__TotalDiscAmt').val(totaldiscamt);
}
function NetPurchaseAmount() {
	//var discper2 = isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer2').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer2').val();
	//var discper3 = isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer3').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer3').val();
	var discAmt1 = 0; var discAmt2 = 0; var discAmt3 = 0;
	var puramt = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurAmt').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurAmt').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__PurAmt').val();
	var discper1 = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val();
	if (discper1 > 0) {
		discAmt1 = parseFloat(parseFloat(puramt) * parseFloat(discper1) * 0.01).toFixed(2);
	}
	else {
		discAmt1 = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val();
	}

	//var puramt2 = parseFloat(parseFloat(puramt) - parseFloat(discAmt1)).toFixed(2);
	//if (discper2 > 0) {
	//	discAmt2 = parseFloat(parseFloat(puramt2) * parseFloat(discper2) * 0.01).toFixed(2);
	//}
	//else {
	//	discAmt2 = isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val();
	//}
	//var puramt2 = parseFloat(parseFloat(puramt2) - parseFloat(discAmt2)).toFixed(2);
	//if (discper3 > 0) {
	//	discAmt3 = parseFloat(parseFloat(puramt2) * parseFloat(discper3) * 0.01).toFixed(2);
	//}
	//else {
	//	discAmt3 = isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val();
	//}

	var gstrate = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__GSTPer').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__GSTPer').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__GSTPer').val();
	var totaldiscamt = parseFloat((parseFloat(discAmt1) + parseFloat(discAmt2) + parseFloat(discAmt3))).toFixed(2);
	var netpuramt = parseFloat(parseFloat(puramt) - parseFloat(totaldiscamt)).toFixed(2);
	var gstamt = parseFloat(parseFloat(netpuramt) * parseFloat(gstrate) * 0.01).toFixed(2);
	var cgstamt = parseFloat(gstamt / 2).toFixed(2);
	var igstamt = 0;
	if ($('#CustLedStateId').val() == $('#CompanyStateId').val()) {
		igstamt = 0;
	}
	else if (($('#LedStateId').val() == $('#CompanyStateId').val()) ) {
		igstamt = gstamt; cgstamt = 0;
    }
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__CGSTAmt').val(cgstamt);
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__SGSTAmt').val(cgstamt);
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__IGSTAmt').val(igstamt);

	var totalnetpuramt = parseFloat(parseFloat(netpuramt) + parseFloat(gstamt)).toFixed(2);
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__NetPurAmt').val(totalnetpuramt);

	var caseunit = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__UnitCase').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__UnitCase').val()) == true ? 1 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__UnitCase').val();
	var mrp = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__MRP').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__MRP').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__MRP').val();
	var totalpcs = $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val().trim() == "" || isNaN($('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val()) == true ? 0 : $('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val();
	var totalcase = totalpcs / caseunit	
	
	var mrpamt = parseFloat(mrp * totalcase).toFixed(2);
	$('#PurchaseRDetailViewModels_' + $('#RowId').val() + '__MRPAmt').val(mrpamt);
}
function GrandTotalAmtCount() {
	var table = document.getElementById('orderItemContinaer');
	var rowscount = table.rows.length;
	var Totaldisc = 0; var TotalPurAmt = 0; var TotalCGSTAmt = 0; var TotalSGSTAmt = 0; var TotalIGSTAmt = 0;
	var TotalCess = 0;
	for (var i = 0; i < rowscount; i++) {
		TotalPurAmt = parseFloat(TotalPurAmt) + parseFloat($('#PurchaseRDetailViewModels_' + i + '__PurAmt').val());
		Totaldisc = parseFloat(Totaldisc) + parseFloat($('#PurchaseRDetailViewModels_' + i + '__TotalDiscAmt').val());
		TotalCGSTAmt = parseFloat(TotalCGSTAmt) + parseFloat($('#PurchaseRDetailViewModels_' + i + '__CGSTAmt').val());
		TotalSGSTAmt = parseFloat(TotalSGSTAmt) + parseFloat($('#PurchaseRDetailViewModels_' + i + '__SGSTAmt').val());
		TotalIGSTAmt = parseFloat(TotalIGSTAmt) + parseFloat($('#PurchaseRDetailViewModels_' + i + '__IGSTAmt').val());
	}
	$('#TotalAmt').val(parseFloat(TotalPurAmt).toFixed(2));
	$('#DiscAmt').val(parseFloat(Totaldisc).toFixed(2));
	$('#IGSTTotalAmt').val(parseFloat(TotalIGSTAmt).toFixed(2));
	$('#SGSTTotalAmt').val(parseFloat(TotalSGSTAmt).toFixed(2));
	$('#CGSTTotalAmt').val(parseFloat(TotalCGSTAmt).toFixed(2));

	$('#TotalAmtX').text($('#TotalAmt').val());
	$('#DiscAmtX').text($('#DiscAmt').val());
	$('#IGSTTotalAmtX').text($('#IGSTTotalAmt').val());
	$('#SGSTTotalAmtX').text($('#SGSTTotalAmt').val());
	$('#CGSTTotalAmtX').text($('#CGSTTotalAmt').val());
	FinalTotalPurchaseAmt();
}
function FinalTotalPurchaseAmt() {
	var TotalAmt = $('#TotalAmt').val().trim() == "" || isNaN($('#TotalAmt').val()) == true ? 0 : $('#TotalAmt').val();
	var DiscAmt = $('#DiscAmt').val().trim() == "" || isNaN($('#DiscAmt').val()) == true ? 0 : $('#DiscAmt').val();
	var IGST = $('#IGSTTotalAmt').val().trim() == "" || isNaN($('#IGSTTotalAmt').val()) == true ? 0 : $('#IGSTTotalAmt').val();
	var SGST = $('#SGSTTotalAmt').val().trim() == "" || isNaN($('#SGSTTotalAmt').val()) == true ? 0 : $('#SGSTTotalAmt').val();
	var CGST = $('#CGSTTotalAmt').val().trim() == "" || isNaN($('#CGSTTotalAmt').val()) == true ? 0 : $('#CGSTTotalAmt').val();
	var CessAmt = $('#CessTotalAmt').val().trim() == "" || isNaN($('#CessTotalAmt').val()) == true ? 0 : $('#CessTotalAmt').val();
	var Other1 = $('#OtherAmt1').val().trim() == "" || isNaN($('#OtherAmt1').val()) == true ? 0 : $('#OtherAmt1').val();
	var Other2 = $('#OtherAmt2').val().trim() == "" || isNaN($('#OtherAmt2').val()) == true ? 0 : $('#OtherAmt2').val();

	var netamt = parseFloat(parseFloat(TotalAmt) - parseFloat(DiscAmt) + parseFloat(IGST) + parseFloat(SGST) + parseFloat(CGST) + parseFloat(CessAmt) + parseFloat(Other1) + parseFloat(Other2)).toFixed(2);
	$('#NetAmt').val(parseFloat(netamt).toFixed(2));
	$('#NetAmtX').text($('#NetAmt').val());
}
function GetPurVoucherSrNo() {
	if ($('#STId').val() == null || $('#STId').val() == 0) {
		$.ajax({
			url: "/Transaction/GetDebitNoteFileSrNo/",
			method: "GET",
			data: { cmpId: $('#CompId').val() },
			success: function (Data) {
				$('#STVNo').val(Data);
				$('#STVNoX').text(Data);
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
	}
}
function GetCompanyStateId() {	
		$.ajax({
			url: "/Administration/GetBranchDetails/",
			method: "GET",
			data: { cmpId: $('#CompId').val() },
			success: function (Data) {
				$('#CompanyStateId').val(Data.stateId)
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
}
$("#btnAdd").on('click', function () {
	$.ajax({
		async: true,
		data: $('#debitnoteform').serialize(),
		type: "POST",
		url: '/Transaction/AddOrderDebiteNoteFileItem',
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
			data: $('#debitnoteform').serialize(),
			url: "/Transaction/DeleteOrderDebitNoteFileItem",
			type: "Post",
		})
			.done(function (partialViewResult) {
				$("#orderItemContinaer").html(partialViewResult);
				if ($('#STId').val() > 0) {
					location.reload(true);
				}
			});
	}
}