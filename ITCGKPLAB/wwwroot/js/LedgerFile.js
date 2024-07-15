var rowno = 0; var projects = []; var projects1 = [];
$(document).ready(function () {
	$("#CompId").focus();
	// account Help File
	// projects1.length = 0;	

	$.widget("custom.tablecompleteG", $.ui.autocomplete, {
		_create: function () {
			this._super();
			this.widget().menu("option", "items", "> li:not(.ui-autocomplete-header)");
		},
		_renderMenu(ul, items) {
			var self = this;
			ul.addClass("helpwidthLedgerFile");
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
		position: { my: "left top", at: "right bottom", collision: "fit none" }, // flip,fit,flipfit,none
		minLength: 1,
		source: projects1,
		select: function (event, ui) {			
			$('#AcId').val(ui.item.id);
			$('#CustomerName').val(ui.item.value);
			return false;
		}
	});
}
function IdZero() {	
	if ($('#CustomerName').val() == null || $('#CustomerName').val().trim() == "") {
		$('#AcId').val('0');
    }
}