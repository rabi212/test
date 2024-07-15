var rowno = 0; var projects = []; var projects1 = []; var projectsbat = [];
$(document).ready(function () {
	$("#CompId").focus();
	if ($('#SRId').val() == null || $('#SRId').val() == 0) {
		$('#SDate').val(CurrentDate());
	}

	$('#TotalAmtX').text($('#TotalAmt').val());
	$('#DiscAmtX').text($('#DiscAmt').val());
	$('#TaxAmtX').text($('#TaxAmt').val());
	$('#NetAmtX').text($('#NetAmt').val());

	$('#SRVNoX').text($('#SRVNo').val());
	$('#SDateX').text($('#SDate').val());
	
	// Item File
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
	//$('#SaleRDetailViewModels_' + $('#RowId').val() + '__OpnItemName').tablecomplete({	
	$('.OpenItemDetailRecord').tablecomplete({
		//position: { my: "left bottom", at: "right bottom"},
		minLength: 1,
		source: projects,
		select: function (event, ui) {
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__SRItemName').val(ui.item.value);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__UnitCase').val(ui.item.unitcase);
			// $('#SaleRDetailViewModels_' + $('#RowId').val() + '__CessPer').val(ui.item.cessrate);
			return false;
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
function FilterItemBatchNo() {
	projectsbat.length = 0;
	$.ajax({
		url: "/Financial/GetItemBalanceRecordHelp",
		method: "GET",
		data: { itemid: $('#SaleRDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(), cmpid: $("#CompId").val()},
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
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__ExpDate').val(ui.item.id);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__BatchNo').val(ui.item.value);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__PurRate').val(ui.item.purrate);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__NetPurRate').val(ui.item.netpurrate);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstper);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__MRP').val(ui.item.mrp);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__SaleRate').val(ui.item.salerate);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__CustSaleRate').val(ui.item.salerate);
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
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__ItemCode').val(ui.item.id);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__SRItemName').val(ui.item.value);
			$('#SaleRDetailViewModels_' + $('#RowId').val() + '__GSTPer').val(ui.item.gstpercentage);
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

function TotalSaleAmt() {
	var opnCase = isNaN($('#SaleRDetailViewModels_' + $('#RowId').val() + '__Qty').val()) == true || $('#SaleRDetailViewModels_' + $('#RowId').val() + '__Qty').val().trim() == "" ? 0 : $('#SaleRDetailViewModels_' + $('#RowId').val() + '__Qty').val();
	var caserate = isNaN($('#SaleRDetailViewModels_' + $('#RowId').val() + '__CustSaleRate').val()) == true || $('#SaleRDetailViewModels_' + $('#RowId').val() + '__CustSaleRate').val().trim() == "" ? 1 : $('#SaleRDetailViewModels_' + $('#RowId').val() + '__CustSaleRate').val();

	var totalamt = parseFloat((parseFloat(opnCase) * parseFloat(caserate))).toFixed(2);
	$('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalAmt').val(totalamt);
}
function TotalDiscountAmt() {	
	var discAmt1 = 0;
	var puramt = isNaN($('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalAmt').val()) == true || $('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalAmt').val().trim() == "" ? 0 : $('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalAmt').val();
	var discper1 = isNaN($('#SaleRDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val()) == true || $('#SaleRDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val().trim() == ""  ? 0 : $('#SaleRDetailViewModels_' + $('#RowId').val() + '__DiscPer1').val();
	if (parseFloat(discper1).toFixed(2) > 0) {
		discAmt1 = parseFloat(parseFloat(puramt) * parseFloat(discper1) * 0.01).toFixed(2);
	}
	else {
		discAmt1 = isNaN($('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalDiscAmt').val()) == true || $('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalDiscAmt').val().trim() == "" ? 0 : $('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalDiscAmt').val();
	}
	$('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalDiscAmt').val(discAmt1);
}
function NetSaleAmount() {	
	var discAmt1 = 0; var discAmt2 = 0; var discAmt3 = 0;
	discAmt1 = isNaN($('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalDiscAmt').val()) == true || $('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalDiscAmt').val().trim() == "" ? 0 : $('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalDiscAmt').val();
	var Saleamt = isNaN($('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalAmt').val()) == true  || $('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalAmt').val().trim() == "" ?  0 : $('#SaleRDetailViewModels_' + $('#RowId').val() + '__TotalAmt').val();
	
	var netsaleamt = parseFloat(parseFloat(Saleamt) - parseFloat(discAmt1)).toFixed(2);	
	
	$('#SaleRDetailViewModels_' + $('#RowId').val() + '__NetTotalAmt').val(netsaleamt);
}
function GrandTotalAmtCount() {
	var table = document.getElementById('orderItemContinaer');
	var rowscount = table.rows.length;
	var Totaldisc = 0; var TotalSaleAmt = 0; var TotalNetAmt = 0; var TotalTaxAmt = 0; var gstrate = 0; var netamt = 0;
	var totalgstamt = 0;
	var TotalCess = 0;
	for (var i = 0; i < rowscount; i++) {
		gstrate = 0; netamt = 0; totalgstamt = 0;
		TotalSaleAmt = parseFloat(TotalSaleAmt) + parseFloat($('#SaleRDetailViewModels_' + i + '__TotalAmt').val());
		Totaldisc = parseFloat(Totaldisc) + parseFloat($('#SaleRDetailViewModels_' + i + '__TotalDiscAmt').val());
		TotalNetAmt = parseFloat(TotalNetAmt) + parseFloat($('#SaleRDetailViewModels_' + i + '__NetTotalAmt').val());
		netamt = parseFloat($('#SaleRDetailViewModels_' + i + '__NetTotalAmt').val());
		gstrate = parseFloat($('#SaleRDetailViewModels_' + i + '__GSTPer').val());
		gstrate = parseFloat(parseFloat(1) + parseFloat(gstrate * 0.01)).toFixed(2);
        if (gstrate > 0) {
			totalgstamt = parseFloat(netamt / gstrate).toFixed(2);
		}
		gstrate = 0;
		gstrate = parseFloat(parseFloat(netamt) - parseFloat(totalgstamt)).toFixed(2);
		TotalTaxAmt = parseFloat(TotalTaxAmt) + parseFloat(gstrate);
	}
	$('#TotalAmt').val(parseFloat(TotalSaleAmt).toFixed(2));
	$('#DiscAmt').val(parseFloat(Totaldisc).toFixed(2));
	$('#TaxAmt').val(parseFloat(TotalTaxAmt).toFixed(2));
	$('#NetAmt').val(parseFloat(TotalNetAmt).toFixed(2));

	$('#TotalAmtX').text($('#TotalAmt').val());
	$('#DiscAmtX').text($('#DiscAmt').val());
	$('#TaxAmtX').text($('#TaxAmt').val());
	$('#NetAmtX').text($('#NetAmt').val());			
}
function GetPatientOldNew() {
	if ($('#SSId').val() == null || $('#SSId').val() == 0) {
		$('#CustName').val(''); $('#CustAddress1').val('');
		$('#DrName').val('');
		$.ajax({
			url: "/OPDIPD/GetPatientOPDNo/",
			method: "GET",
			data: { patientNo: $('#PatientNo').val() },
			success: function (Data) {
				var agetype = parseInt(Data.ageType) == 0 ? "Year" : ( parseInt(Data.ageType) == 1 ? "Month" : "Days");
				var gender = parseInt(Data.sex) == 0 ? "Male" : ( parseInt(Data.sex) == 1 ? "Female" : "None");
				$('#CustName').val(Data.titleName + " " + Data.name + " " + Data.age + " " + agetype + " / " + gender);
				$('#CustAddress1').val(Data.address);
				$('#DrName').val(Data.drName);
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
	}
}
function GetPurVoucherSrNo() {
	if ($('#SRId').val() == null || $('#SRId').val() == 0) {
		$.ajax({
			url: "/Transaction/GetCreditNoteFileSrNo/",
			method: "GET",
			data: { cmpId: $('#CompId').val() },
			success: function (Data) {
				$('#SRVNo').val(Data);
				$('#SRVNoX').text(Data);
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
		data: $('#creditnoteform').serialize(),
		type: "POST",
		url: '/Transaction/AddOrderCreditNoteFileItem',
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
			data: $('#creditnoteform').serialize(),
			url: "/Transaction/DeleteOrderCreditNoteFileItem",
			type: "Post",
		})
			.done(function (partialViewResult) {
				$("#orderItemContinaer").html(partialViewResult);
				if ($('#SRId').val() > 0) {
					location.reload(true);
				}
			});
	}
}