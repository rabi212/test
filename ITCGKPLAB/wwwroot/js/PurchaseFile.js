var rowno = 0; var projects = []; var projects1 = [];
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
			data: { CompId: $('#CompId').val() },
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
	//$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__OpnItemName').tablecomplete({	
	$('.OpenItemDetailRecord').tablecomplete({
		//position: { my: "left bottom", at: "right bottom"},
		minLength: 1,
		source: projects,
		select: function (event, ui) {
			$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__STItemName').val(ui.item.value);
			$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
			$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__UnitCase').val(ui.item.unitcase);
			// $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CessPer').val(ui.item.cessrate);
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
			$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__STItemName').val(ui.item.value);
			$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
			$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__UnitCase').val(ui.item.unitcase);
			// $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CessPer').val(ui.item.cessrate);
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
	var opnCase = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CasePcs').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CasePcs').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CasePcs').val();
	var freeunit = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__FreePcs').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__FreePcs').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__FreePcs').val();
	var caseunit = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__UnitCase').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__UnitCase').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__UnitCase').val();
	
	var totalpcs = parseFloat((parseFloat(opnCase) * parseFloat(caseunit))).toFixed(2);
	var nettotalpcs = parseFloat( parseFloat(totalpcs) + parseFloat(freeunit) ).toFixed(2) ;
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val(nettotalpcs);
}
function TotalPurchaseAmt() {
	var opnCase = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CasePcs').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CasePcs').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CasePcs').val();
	var caserate = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurRate').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurRate').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurRate').val();

	var totalamt = parseFloat((parseFloat(opnCase) * parseFloat(caserate))).toFixed(2);
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurAmt').val(totalamt);
}
function TotalDiscountAmt() {
	//var discper2 = isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer2').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer2').val();
	//var discper3 = isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer3').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer3').val();
	var discAmt1 = 0; var discAmt2 = 0; var discAmt3 = 0;
	var puramt = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurAmt').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurAmt').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurAmt').val();
	var discper1 = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val();
	if (discper1 > 0) {
		discAmt1 = parseFloat(parseFloat(puramt) * parseFloat(discper1) * 0.01).toFixed(2);
	}
	else {
		discAmt1 = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val();
	}
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val(discAmt1);

	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val(0);
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val(0);
	//var puramt2 = parseFloat(parseFloat(puramt) - parseFloat(discAmt1)).toFixed(2);
	//if (discper2 > 0) {
	//	discAmt2 = parseFloat(parseFloat(puramt2) * parseFloat(discper2) * 0.01).toFixed(2);
	//}
	//else {
	//	discAmt2 = isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val();
	//}
	// $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val(discAmt2);
	//var puramt2 = parseFloat(parseFloat(puramt2) - parseFloat(discAmt2)).toFixed(2);
	//if (discper3 > 0) {
	//	discAmt3 = parseFloat(parseFloat(puramt2) * parseFloat(discper3) * 0.01).toFixed(2);
	//}
	//else {
	//	discAmt3 = isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val();
	//}
	// $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val(discAmt3);

	var totaldiscamt = parseFloat((parseFloat(discAmt1) + parseFloat(discAmt2) + parseFloat(discAmt3))).toFixed(2);
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__TotalDiscAmt').val(totaldiscamt);
}
function NetPurchaseAmount() {
	//var discper2 = isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer2').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer2').val();
	//var discper3 = isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer3').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer3').val();
	var discAmt1 = 0; var discAmt2 = 0; var discAmt3 = 0;
	var puramt = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurAmt').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurAmt').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurAmt').val();
	var discper1 = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val();
	if (discper1 > 0) {
		discAmt1 = parseFloat(parseFloat(puramt) * parseFloat(discper1) * 0.01).toFixed(2);
	}
	else {
		discAmt1 = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt1').val();
	}

	//var puramt2 = parseFloat(parseFloat(puramt) - parseFloat(discAmt1)).toFixed(2);
	//if (discper2 > 0) {
	//	discAmt2 = parseFloat(parseFloat(puramt2) * parseFloat(discper2) * 0.01).toFixed(2);
	//}
	//else {
	//	discAmt2 = isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt2').val();
	//}
	//var puramt2 = parseFloat(parseFloat(puramt2) - parseFloat(discAmt2)).toFixed(2);
	//if (discper3 > 0) {
	//	discAmt3 = parseFloat(parseFloat(puramt2) * parseFloat(discper3) * 0.01).toFixed(2);
	//}
	//else {
	//	discAmt3 = isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscAmt3').val();
	//}

	var gstrate = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__GSTPer').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__GSTPer').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__GSTPer').val();
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
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CGSTAmt').val(cgstamt);
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__SGSTAmt').val(cgstamt);
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__IGSTAmt').val(igstamt);

	var totalnetpuramt = parseFloat(parseFloat(netpuramt) + parseFloat(gstamt)).toFixed(2);
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__NetPurAmt').val(totalnetpuramt);

	var totalcase = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CasePcs').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CasePcs').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__CasePcs').val();
	var netpurrate = parseFloat(parseFloat(totalnetpuramt) / parseFloat(totalcase)).toFixed(2);
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__NetPurRate').val(netpurrate);

	var caseunit = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__UnitCase').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__UnitCase').val()) == true ? 1 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__UnitCase').val();
	var mrp = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__MRP').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__MRP').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__MRP').val();

	var salerate = parseFloat(mrp / caseunit).toFixed(2);
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__SaleRate').val(salerate);

	var totalpcs = $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val().trim() == "" || isNaN($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val()) == true ? 0 : $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__TotalPcs').val();
	var totalcase = totalpcs / caseunit	
	
	var mrpamt = parseFloat(mrp * totalcase).toFixed(2);
	$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__MRPAmt').val(mrpamt);
}
function GrandTotalAmtCount() {
	var table = document.getElementById('orderItemContinaer');
	var rowscount = table.rows.length;
	var Totaldisc = 0; var TotalPurAmt = 0; var TotalCGSTAmt = 0; var TotalSGSTAmt = 0; var TotalIGSTAmt = 0;
	var TotalCess = 0;
	for (var i = 0; i < rowscount; i++) {
		TotalPurAmt = parseFloat(TotalPurAmt) + parseFloat($('#PurchaseDetailViewModels_' + i + '__PurAmt').val());
		Totaldisc = parseFloat(Totaldisc) + parseFloat($('#PurchaseDetailViewModels_' + i + '__TotalDiscAmt').val());
		TotalCGSTAmt = parseFloat(TotalCGSTAmt) + parseFloat($('#PurchaseDetailViewModels_' + i + '__CGSTAmt').val());
		TotalSGSTAmt = parseFloat(TotalSGSTAmt) + parseFloat($('#PurchaseDetailViewModels_' + i + '__SGSTAmt').val());
		TotalIGSTAmt = parseFloat(TotalIGSTAmt) + parseFloat($('#PurchaseDetailViewModels_' + i + '__IGSTAmt').val());
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
function GetLastItemPurchase() {
	if ($('#PurchaseDetailViewModels_' + $('#RowId').val() + '__RecordType').val() !="Old" ) {
		$.ajax({
			url: "/Transaction/GetPurchaseFileLastItem/",
			method: "GET",
			data: { itemId: $('#PurchaseDetailViewModels_' + $('#RowId').val() + '__ItemCode').val() },
			success: function (Data) {
				$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__OnFreeCase').val(Data.onFreeCase);
				$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__PurRate').val(Data.purRate);
				$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val(Data.discPer1);
				$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__MRP').val(Data.mrp);
				$('#PurchaseDetailViewModels_' + $('#RowId').val() + '__SaleRate').val(Data.saleRate);
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
	}
}
function GetPurVoucherSrNo() {
	if ($('#STId').val() == null || $('#STId').val() == 0) {
		$.ajax({
			url: "/Transaction/GetPurchaseFileSrNo/",
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
		data: $('#purchaserecordform').serialize(),
		type: "POST",
		url: '/Transaction/AddOrderPurchaseFileItem',
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
			data: $('#purchaserecordform').serialize(),
			url: "/Transaction/DeleteOrderPurchaseFileItem",
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