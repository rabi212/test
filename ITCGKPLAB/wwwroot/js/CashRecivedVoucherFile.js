var rowno = 0; var projects = [];
$(document).ready(function () {

	$("#CompId").focus();
	$('#DrAmtX').text("Debit Amt :- " + parseFloat($('#DrAmt').val()).toFixed(2));
	$('#CrAmtX').text("Credit Amt :- " + parseFloat($('#CrAmt').val()).toFixed(2));

	TotalDebitCreditVisible();
	if ($('#VId').val() == null || $('#VId').val() == 0) {
		GetCashReciptVoucherSrNo();
		$('#VDate').val(CurrentDate());
	}
	TotalPurMRPAmtCount();
	$('#VVNoX').text($('#VVNo').val())
	
	FilterAccount();

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
				value: "A/c  Name",
				shortname: "Address",
				balance: "Balance",
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
			var $content = "<div class='row ui-menu-item-wrapper small'>" + "<div class='col-sm-1' hidden>" + item.id + "</div>" + "<div class='col-sm-5'>" + item.value + "</div>" + "<div class='col-sm-5'>" + item.shortname + "</div>" + "<div class='col-sm-2 text-right'>" + item.balance + "</div>";
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
			$('#VoucherDetailViewModels_' + $('#RowId').val() + '__AcCode1').val(ui.item.id);
			$('#VoucherDetailViewModels_' + $('#RowId').val() + '__VoucherPartyName').val(ui.item.value);
			return false;
		}
	});

});
function FilterAccount() {
	projects.length = 0;
	$.ajax({
		url: "/Financial/FindAccountRecord",
		method: "GET",
		data: { CompId: $('#CompId').val() },
		success: function (result) {
			//result = JSON.parse(result);
			if (result.length > 0) {
				$.each(result, function (key, item) {
					projects.push({
						id: item.ledgerMasterId,
						value: item.partyName,
						shortname: item.address1,
						balance: (item.closeAc == 1 ? parseFloat(item.closeAmt).toFixed(2) + " Dr" : parseFloat(item.closeAmt).toFixed(2) + " Cr")
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
	$('.OpenItemDetailRecord').tablecomplete({
		//position: { my: "left bottom", at: "right bottom"},
		minLength: 1,
		source: projects,
		select: function (event, ui) {
			$('#VoucherDetailViewModels_' + $('#RowId').val() + '__AcCode1').val(ui.item.id);
			$('#VoucherDetailViewModels_' + $('#RowId').val() + '__VoucherPartyName').val(ui.item.value);
			return false;
		}
	});
}
function GetRemarkAutomation() {
	if ($('#VId').val() == null || $('#VId').val() == 0) {
		$('#Remark').text('');
		// Find String To numberic Values
		var element_id = $('#VoucherDetailViewModels_' + $('#RowId').val() + '__RefNo').val().trim();
		//var number = element_id.match(/\d+/);
		// end
		if (element_id.length >= 10) {
			GetPatientRecordNew();
		}
		else if (element_id.length < 10) {
			GetAgentFilePayBill();
		}
	}
}
function GetPatientRecordNew() {
	$.ajax({
		url: "/Master/GetPatientByVoucherNo/",
		method: "GET",
		data: { patientNo: $('#VoucherDetailViewModels_' + $('#RowId').val() + '__RefNo').val() },
		success: function (Data) {
			var agetype = Data.ageType == 0 ? "Year" : (Data.ageType == 1 ? "Month" : "Days");
			var gender = Data.sex == 0 ? "Male" : (Data.sex == 1 ? "Female" : "None");
			$('#Remark').val(Data.titleName + " " + Data.name + " " + Data.age + " " + agetype + " / " + gender + " ");
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function GetAgentFilePayBill() {
	$.ajax({
		url: "/PayBill/GetAgentDetailsFile/",
		method: "GET",
		data: { id: parseInt($('#VoucherDetailViewModels_' + $('#RowId').val() + '__RefNo').val()) },
		success: function (result) {
			$('#Remark').text(result.name + ' ' + result.address1 + ' ' + result.mobileNo);
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function DebitCreditVisible() {
	if ($('#VoucherDetailViewModels_' + $('#RowId').val() + '__AccountMode').val().trim() == 1) {
		$('#VoucherDetailViewModels_' + $('#RowId').val() + '__Dr_Amt').show();
		$('#VoucherDetailViewModels_' + $('#RowId').val() + '__Cr_Amt').hide();
	}
	else {
		$('#VoucherDetailViewModels_' + $('#RowId').val() + '__Cr_Amt').show();
		$('#VoucherDetailViewModels_' + $('#RowId').val() + '__Dr_Amt').hide();
    }
}
function TotalDebitCreditVisible() {
	var table = document.getElementById('orderItemContinaer');
	var rowscount = table.rows.length;
	for (var i = 0; i < rowscount; i++) {
		if ($('#VoucherDetailViewModels_' + i + '__AccountMode').val().trim() == 1) {
			$('#VoucherDetailViewModels_' + i + '__Dr_Amt').show();
			$('#VoucherDetailViewModels_' + i + '__Cr_Amt').hide();
		}
		else {
			$('#VoucherDetailViewModels_' + i + '__Cr_Amt').show();
			$('#VoucherDetailViewModels_' + i + '__Dr_Amt').hide();
		}
	}
}
function FindRowIndex(element) {
	$("#RowId").val(0);
	var rowJavascript = element.parentNode.parentNode;
	var id = (rowJavascript.rowIndex - 1)
	$("#RowId").val(id);
	rowno = id;
}
function TotalPurMRPAmtCount() {
	var table = document.getElementById('orderItemContinaer');
	var rowscount = table.rows.length;
	var TotalDr = 0; var TotalCr = 0;
	for (var i = 0; i < rowscount; i++) {
		if ($('#VoucherDetailViewModels_' + i + '__AccountMode').val().trim() == 1) {
			TotalDr = parseFloat(TotalDr) + (isNaN($('#VoucherDetailViewModels_' + i + '__Dr_Amt').val()) != true || $('#VoucherDetailViewModels_' + i + '__Dr_Amt').val().trim() !="" ? parseFloat($('#VoucherDetailViewModels_' + i + '__Dr_Amt').val()) : 0);
		}
		else {
			TotalCr = parseFloat(TotalCr) + (isNaN($('#VoucherDetailViewModels_' + i + '__Cr_Amt').val()) != true || $('#VoucherDetailViewModels_' + i + '__Cr_Amt').val().trim() != "" ? parseFloat($('#VoucherDetailViewModels_' + i + '__Cr_Amt').val()) : 0);
        }
	}
	$('#DrAmtX').text("Debit Amt :- " + parseFloat(TotalDr).toFixed(2));
	$('#CrAmtX').text("Credit Amt :- " + parseFloat(TotalCr).toFixed(2));
	$('#DrAmt').val(TotalDr); $('#CrAmt').val(TotalCr);
}
function GetCashReciptVoucherSrNo() {
	$.ajax({
		url: "/Transaction/GetOpenVoucherSrNo/",
		method: "GET",
		data: { cmpId: $('#CompId').val(), vtype: $('#VType').val() },
		success: function (Data) {
			if ($('#VId').val() == 0 || $('#VId').val() == null) {
				$('#VVNo').val(Data);
				$('#VVNoX').text(Data)
			}
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
$("#btnAdd").on('click', function () {
	if ($('#DrAmt').val() != $('#CrAmt').val()) {
		$.ajax({
			async: true,
			data: $('#form').serialize(),
			type: "POST",
			url: '/Transaction/AddVoucherItemDetails',
			success: function (partialView) {
				console.log("partialView: " + partialView);
				$('#orderItemContinaer').html(partialView);
				$('.AcountModeRecord').focus();
				TotalDebitCreditVisible();				
			}
		});
	}
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
			url: "/Transaction/DeleteVoucherItemDetails",
			type: "Post",
		})
			.done(function (partialViewResult) {
				$("#orderItemContinaer").html(partialViewResult);
				TotalDebitCreditVisible(); TotalPurMRPAmtCount();
			});
	}	
}