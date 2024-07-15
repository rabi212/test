var rowno = 0; var projects = []; var projects1 = []; var doctorlist = []; var clientlist = []; var testmodearrary = [];
$(document).ready(function () {
	$("#CompId").focus();
	$('#btnAdd').bind('keypress keydown', function (e) {		
		$(this).select();
		if (e.which == 27) {
			//alert('The column is read-only and is not editable');
			$('#DiscountType').focus();
		}
	});
	if ($('#Id').val() == null || $('#Id').val() == 0) {		
		$('#PatientDetailsMasterViewModels_0__TestGId').val($('#modeno').val());
		$('#PatientDetailsMasterViewModels_0__Mode').val($('#modetype').val());
		var currentTime = updateClock();
		$('#STime').val(currentTime);
		$('#RTime').val(currentTime);
		$('#SDate').val(CurrentDate());
		$('#RDate').val(CurrentDate());
	}

	if ($('#Id').val() > 0) {
		$('#TotalAmtXX').html($('#TotalAmt').val());
		$('#BalAmtXX').html($('#BalAmt').val());
		$('#RefNoXX').html($('#RefNo').val());
	}
	
	var availableTags = [
		"Counter",
		"Doctor"
	];
	$("#DiscountType").autocomplete({
		position: { my: "top bottom", at: "left top" },
		source: availableTags
	});
	//projects.length = 0;
	//$.ajax({
	//	url: "/Master/FindTestRecord",
	//	method: "GET",
	//	data: { cmpid: $('#CompId').val() },
	//	success: function (result) {
	//		//result = JSON.parse(result);
	//		if (result.length > 0) {
	//			$.each(result, function (key, item) {
	//				projects.push({
	//					id: item.id,
	//					value: item.testCode,
	//					rate: item.rate
	//				});
	//			});
	//		}
	//	},
	//	error: function (errormessage) {
	//		console.error(errormessage.responseText);
	//	}
	//});

	$.widget("custom.tablecomplete", $.ui.autocomplete, {
		_create: function () {
			this._super();
			this.widget().menu("option", "items", "> li:not(.ui-autocomplete-header)");
		},
		_renderMenu(ul, items) {
			var self = this;
			ul.addClass("helpwidthTestMaster");
			let header = {
				id: "Id",
				value: "Test's  Name",
				rate: "Rate",
				pprate: "PP Rate",
				ccrate: "CC Rate",
				testgid: "Test Group Id",
				testmode: "Test Mode",
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
			var $content = "<div class='row ui-menu-item-wrapper small'>" + "<div class='col-sm-1' hidden>" + item.id + "</div>" + "<div class='col-sm-9'>" + item.value + "</div>" + "<div class='col-sm-2 text-sm-right'>" + item.rate + "</div>" + "<div class='col-sm-1' hidden>" + item.pprate + "</div>" + "<div class='col-sm-1' hidden>" + item.ccrate + "</div>" + "<div class='col-sm-1' hidden>" + item.testgid + "</div>" + "<div class='col-sm-1' hidden>" + item.testmode + "</div>" + "</div>";
			$li.html($content);
			return $li.appendTo(ul);
		}
	});

	// projects1.length = 0;
	$.ajax({
		url: "/Master/FindTestGoupRecord",
		method: "GET",
		data: { cmpid: $('#CompId').val() },
		success: function (result) {
			//result = JSON.parse(result);
			if (result.length > 0) {
				$.each(result, function (key, item) {
					projects1.push({
						id: item.id,
						value: item.shortName
					});
					testmodearrary.push({
						Id: item.id,
						Name:item.shortName
					});
				});
			}
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});

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
				value: "Mode",
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
			var $content = "<div class='row ui-menu-item-wrapper small'>" + "<div class='col-sm-1' hidden>" + item.id + "</div>" + "<div class='col-sm-1'>" + item.value + "</div>" + "</div>";
			$li.html($content);
			return $li.appendTo(ul);
		}
	});

	$.widget("custom.tablecompleteDoct", $.ui.autocomplete, {
		_create: function () {
			this._super();
			this.widget().menu("option", "items", "> li:not(.ui-autocomplete-header)");
		},
		_renderMenu(ul, items) {
			var self = this;
			ul.addClass("helpwidthDoctorPatientFile");
			let header = {
				id: "Id",
				value: "Name",
				code: "Code",
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
			var $content = "<div class='row ui-menu-item-wrapper small'>" + "<div class='col-sm-1' hidden>" + item.id + "</div>" + "<div class='col-sm-12'>" + item.value + "</div>" +  "<div class='col-sm-1' hidden>" + item.code + "</div>" + "</div>";
			$li.html($content);
			return $li.appendTo(ul);
		}
	});
	// create the autocomplete	
	//$('#OpenItemMasterDetailViewModels_' + $('#RowId').val() + '__OpnItemName').tablecomplete({	
	//$('.OpenItemDetailRecord').tablecomplete({
	//	//position: { my: "left bottom", at: "right bottom"},
	//	minLength: 1,
	//	source: projects,
	//	select: function (event, ui) {
	//		$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestId').val(ui.item.id);
	//		$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__OpnItemName').val(ui.item.value);
	//		$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Rate').val(ui.item.rate);
	//		return false;
	//	}
	//}); 	
	GetHeadLedCodeSrNo();

	$.widget("custom.tablecompleteClient", $.ui.autocomplete, {
		_create: function () {
			this._super();
			this.widget().menu("option", "items", "> li:not(.ui-autocomplete-header)");
		},
		_renderMenu(ul, items) {
			var self = this;
			ul.addClass("helpwidthDoctorPatientFile");
			let header = {
				id: "Id",
				value: "Name",
				panel: "Panel",
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
			var $content = "<div class='row ui-menu-item-wrapper small'>" + "<div class='col-sm-1' hidden>" + item.id + "</div>" + "<div class='col-sm-12'>" + item.value + "</div>" + "<div class='col-sm-1' hidden>" + item.panel + "</div>" + "</div>";
			$li.html($content);
			return $li.appendTo(ul);
		}
	});
	// Button Enable disable
	var buttonx = $('#Buttonx');
	$(buttonx).prop('disabled', true);

	$('.click').click(function () {
		if ($(buttonx).prop('disabled')) $(buttonx).prop('disabled', false);
		else $(buttonx).prop('disabled', true);
	});

	// Pop up Model Record
	var PlaceHolderElement = $('#PlaceHolderHere');
	$('button[data-toggle="ajax-model"]').click(function (event) {

		var url = $(this).data('url');
		var decodeUrl = decodeURIComponent(url);
		$.get(decodeUrl).done(function (data) {
			PlaceHolderElement.html(data);
			PlaceHolderElement.find('.modal').modal('show');
		});
	});

	PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
		var form = $(this).parents('.modal').find('form');
		var actionUrl = form.attr('action');
		
		var url = "/Master/" + actionUrl;
		var sendData = form.serialize();	
		$.post(url, sendData).done(function (event) {
			DoctorFilterByAccount();
			PlaceHolderElement.find('.modal').modal('hide');
		});
	});

});
function down(what) {
	$(what).show();
}
function ClientFilterByAccount() {
	//GetTestModebyValue();
	clientlist.length = 0;
	$.ajax({
		url: "/Master/FindClientRecord",
		method: "GET",
		data: { cmpid: $('#CompId').val() },
		success: function (result) {
			//result = JSON.parse(result);
			if (result.length > 0) {
				$.each(result, function (key, item) {
					clientlist.push({
						id: item.id,
						value: item.name,
						panel: item.regPanel
					});
				});
			}
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function ClientSearchRecord() {
	$(".ClientDetailRecord").tablecompleteClient({
		//position: { my: "top bottom", at: "right top", collision: "fit none" },
		position: { my: "left top", at: "right bottom", collision: "fit none" }, // flip,fit,flipfit,none
		minLength: 0,
		source: clientlist,
		select: function (event, ui) {
			$('#ClientName').val(ui.item.value);
			$('#ClientCode').val(ui.item.id);
			$('#TempPanel').val(ui.item.panel);
			return false;
		}
	});
}
function DoctorFilterByAccount() {
	//GetTestModebyValue();
	doctorlist.length = 0;
	$.ajax({
		url: "/Master/FindDoctorByLedgerRecord",
		method: "GET",
		data: { cmpid: $('#CompId').val()},
		success: function (result) {
			//result = JSON.parse(result);
			if (result.length > 0) {
				$.each(result, function (key, item) {
					doctorlist.push({
						id: item.id,
						value: item.name + ' ' + item.eduction,
						code: item.code
					});
				});
			}
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function DoctorByAccountSearchRecord() {
	$(".DoctorDetailRecord").tablecompleteDoct({
		//position: { my: "top bottom", at: "right top", collision: "fit none" },
		position: { my: "left top", at: "right bottom", collision: "fit none" }, // flip,fit,flipfit,none
		minLength: 0,
		source: doctorlist,
		select: function (event, ui) {			
			$('#DrName').val(ui.item.value);
			$('#DoctorAcCode').val(ui.item.id);
			$('#DoctorAcCodeX').val(ui.item.code);
			return false;
		}
	});
}
function TestFilterMode() {
	//GetTestModebyValue();
	projects.length = 0;
	$.ajax({
		url: "/Master/FindTestRecord",
		method: "GET",
		data: { cmpid: $('#CompId').val()},
		success: function (result) {
			//result = JSON.parse(result);
			if (result.length > 0) {
				$.each(result, function (key, item) {
					projects.push({
						id: item.id,
						value: item.testCode,
						rate: item.rate,
						pprate: item.ppRate,
						ccrate: item.ccRate,
						testgid: item.testGroupId,
						testmode: item.testGroupMasterViewModel.shortName
					});
				});
			}
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function TestSearchRecord() {
	$('.OpenItemDetailRecord').tablecomplete({
		minLength: 1,
		source: projects,
		select: function (event, ui) {
			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestId').val(ui.item.id);
			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestMasterViewModels_TestCode').val(ui.item.value);
		
			if ($('#TempPanel').val().trim() == "0") {
				$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Rate').val(ui.item.rate);				
			}
			else if ($('#TempPanel').val().trim() == "1") {
				$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Rate').val(ui.item.pprate);				
			} else if ($('#TempPanel').val().trim() == "2") {
				$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Rate').val(ui.item.ccrate);				
			}

			//$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Rate').val(ui.item.rate);
			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__StanderRate').val(ui.item.rate);

			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestGId').val(ui.item.testgid);
			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Mode').val(ui.item.testmode);

			return false;
		}
	});
}
function TestModeSearchRecord() {
	$(".ModeDetailRecord").tablecompleteG({
		position: { my: "top bottom", at: "right top" },
		minLength: 0,
		source: projects1,
		select: function (event, ui) {
			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestGId').val(ui.item.id);
			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Mode').val(ui.item.value);
			$('#modeno').val(ui.item.id);
			$('#modetype').val(ui.item.value);
			return false;
		}
	});
}
function GetTestModebyValue() {
	$.ajax({
		url: "/Master/FindTestGroupByShortName/",
		method: "GET",
		data: { shortname: $('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Mode').val() },
		success: function (Data) {			
			$('#modeno').val(Data.id);
			$('#modetype').val(Data.shortName);
			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestGId').val(Data.id);
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});		
}

function GetChangeTypebyValue() {
	if ($('#Id').val() == 0) {
		$('#PatientDetailsMasterViewModels_' + '0' + '__Mode').val($('#Type').val());
		$('#modetype').val($('#Type').val());
		//GetChangeModebyValue();
	}
}
function GetChangeModebyValue() {
	if ($('#Id').val() == 0) {
		$.ajax({
			url: "/Master/FindTestGroupByShortName/",
			method: "GET",
			data: { cmpid: $('#CompId').val(), shortname: $('#PatientDetailsMasterViewModels_' + '0' + '__Mode').val() },
			success: function (Data) {
				$('#modeno').val(Data.id);
				//$('#modetype').val(Data.shortName);
				$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestGId').val(Data.id);
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
	}
}
function GetPatientOldNew() {
	if ($('#MobileNo').val().trim() != "" && $('#MobileNo').val() != "0000000000") {
		if ($('#Id').val() == 0) {
			$.ajax({
				url: "/Master/GetSearchPatientFile/",
				method: "GET",
				data: { mobileno: $('#MobileNo').val() },
				success: function (Data) {
					$("input[name=Sex][value=" + Data.sex + "]").prop('checked', true);
					$('#TitleName').val(Data.titleName);
					$('#Name').val(Data.name);
					$('#Age').val(Data.age);
					$('#AgeType').val(Data.ageType);
					$('#Address').val(Data.address);
					$('#EmailAddress').val(Data.emailAddress);
				},
				error: function (errormessage) {
					console.error(errormessage.responseText);
				}
			});
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
function GetTotalIPCorrect() {
	if ($('#DoctorAcCodeX').val().trim() != "") {
		GetTotalIPAmt();
	}
	else {
		$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__IPPer1').val(0);
		$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__IPAmt1').val(0);
		GrandTotalAmount();
    }
}
function GetTotalIPAmt() {	
		var objemp = {
			doctorid: $('#DoctorAcCodeX').val(),
			cmdid: $('#CompId').val(),
			testGroupid: $('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestGId').val()
		}
		$.ajax({
			url: "/Master/GetDoctorIP/",
			method: "GET",
			data: objemp,
			success: function (result) {			
					var Amt1 = $('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Rate').val();
					var Amt2 = result != null ? parseFloat(result.ipPer1 * Amt1 * 0.01).toFixed(2) : 0;
					var Amt3 = result != null ? parseFloat(result.ipAmt1).toFixed(2) : 0;
					$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__IPPer1').val(Amt2);
					$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__IPAmt1').val(Amt3);
				GrandTotalAmount();
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
		//GrandTotalAmount();
}
$("#btnAdd").on('click', function () {
	$.ajax({
		async: true,
		data: $('#form').serialize(),
		type: "POST",
		url: '/Master/AddOrderItem',
		success: function (partialView) {
			console.log("partialView: " + partialView);
			$('#orderItemContinaer').html(partialView);
			$('.OpenItemDetailRecord').focus();
			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__TestGId').val($('#modeno').val());
			$('#PatientDetailsMasterViewModels_' + $('#RowId').val() + '__Mode').val($('#modetype').val());
		}
	});
});
function GrandTotalAmount() {
	var table = document.getElementById('orderItemContinaer');
	var rowscount = table.rows.length;
	var TotalPcs = 0; var TotalPurAmt = 0; var TotalIPPer = 0; var TotalIPAmt = 0;
	for (var i = 0; i < rowscount; i++) {
		TotalPcs = parseFloat(TotalPcs) + ($('#PatientDetailsMasterViewModels_' + i + '__Rate').val().trim() == "" || isNaN($('#PatientDetailsMasterViewModels_' + i + '__Rate').val()) == true ? 0 : parseFloat($('#PatientDetailsMasterViewModels_' + i + '__Rate').val()));
		TotalIPPer = $('#PatientDetailsMasterViewModels_' + i + '__IPPer1').val().trim() == "" || isNaN($('#PatientDetailsMasterViewModels_' + i + '__IPPer1').val()) == true ? 0 : $('#PatientDetailsMasterViewModels_' + i + '__IPPer1').val();
		TotalIPAmt = $('#PatientDetailsMasterViewModels_' + i + '__IPAmt1').val().trim() == "" || isNaN($('#PatientDetailsMasterViewModels_' + i + '__IPAmt1').val()) == true ? 0 : $('#PatientDetailsMasterViewModels_' + i + '__IPAmt1').val();
		TotalPurAmt = parseInt(TotalPurAmt) + parseInt(TotalIPPer) + parseInt(TotalIPAmt);
	}
	$("#TotalAmt").val(parseFloat(TotalPcs).toFixed(2));
	$("#TotalIPAmt").val(TotalPurAmt);
	$("#TotalAmtXX").html(parseFloat(TotalPcs).toFixed(2));
	GrandTotalPaid();
}
function AutoGenderSelect() {
	if ($('#TitleName').val().trim() == "Mr." || $('#TitleName').val().trim() == "Ms." || $('#TitleName').val().trim() == "Dr." ) {
		$('#Sex').val(0)
	} else if ($('#TitleName').val().trim() == "Dr(Mrs)" || $('#TitleName').val().trim() == "Miss" || $('#TitleName').val().trim() == "Mrs." || $('#TitleName').val().trim() == "Smt") {
		$('#Sex').val(1)
	}
}
function GrandTotalPaid() {
	var TotalAmt = 0; var DiscPer = 0; var DiscAmt = 0; var cAmt = 0; var dAmt = 0;
	TotalAmt = $('#TotalAmt').val().trim() == "" || isNaN($('#TotalAmt').val()) == true ? 0 : $("#TotalAmt").val();
	DiscPer = $('#DiscPer').val().trim() == "" || isNaN($('#DiscPer').val()) == true ? 0 : $("#DiscPer").val();
	cAmt = $('#CollectionCharge').val().trim() == "" || isNaN($('#CollectionCharge').val()) == true ? 0 : $("#CollectionCharge").val();
	dAmt = $('#DeliveryCharge').val().trim() == "" || isNaN($('#DeliveryCharge').val()) == true ? 0 : $("#DeliveryCharge").val();
	if (DiscPer > 0) {
		DiscAmt = TotalAmt * DiscPer * 0.01
		$("#DiscAmt").val(parseFloat(DiscAmt).toFixed(2));
	}
	else {
		DiscAmt = $('#DiscAmt').val().trim() == "" || isNaN($('#DiscAmt').val()) == true ? 0 : $("#DiscAmt").val();
	}
	var paidAmt = parseFloat(TotalAmt) - parseFloat(DiscAmt) + parseFloat(dAmt) + parseFloat(cAmt);
	$("#PaidAmt").val(parseFloat(paidAmt).toFixed(2));
	PaidBal();
}
function PaidBal() {
	var TotalAmt = 0; var discAmt = 0; var paidAmt = 0; var balAmt = 0; var cAmt = 0; var dAmt = 0;
	TotalAmt = $('#TotalAmt').val().trim() == "" || isNaN($('#TotalAmt').val()) == true ? 0 : $("#TotalAmt").val();
	discAmt = $('#DiscAmt').val().trim() == "" || isNaN($('#DiscAmt').val()) == true ? 0 : $("#DiscAmt").val();

	cAmt = $('#CollectionCharge').val().trim() == "" || isNaN($('#CollectionCharge').val()) == true ? 0 : $("#CollectionCharge").val();
	dAmt = $('#DeliveryCharge').val().trim() == "" || isNaN($('#DeliveryCharge').val()) == true ? 0 : $("#DeliveryCharge").val();
	

	paidAmt = $('#PaidAmt').val().trim() == "" || isNaN($('#PaidAmt').val()) == true ? 0 : $("#PaidAmt").val();

	balAmt = parseFloat(TotalAmt) + parseFloat(cAmt) + parseFloat(dAmt) - parseFloat(paidAmt) - parseFloat(discAmt) ;
	$("#BalAmt").val(parseFloat(balAmt).toFixed(2));
	$("#BalAmtXX").html(parseFloat(balAmt).toFixed(2));
}
function GetPatientVoucherNoCompanyWise() {
	if ($('#Id').val() == 0) {
		$.ajax({
			url: "/Master/NewPatientVoucherNo/",
			method: "GET",
			data: { cmpid: $('#CompId').val() },
			success: function (Data) {
				$('#VNo').val(Data);
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
	}
}
function GetPatientRefSrNo() {
	if ($('#Id').val() == 0) {
		$.ajax({
			url: "/Master/PatientCurrentDtRefNo/",
			method: "GET",
			data: { cmpid: $('#CompId').val(), type: $('#Type').val(), dt1: $('#SDate').val() },
			success: function (Data) {
				$('#RefNo').val(Data);
				$('#RefNoXX').html(Data);
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
	}
}
function GetHeadLedCodeSrNo() {
	if ($('#DoctorAcCode').val() > 0) {
		$.ajax({
			url: "/Master/FindDoctorAcCode/",
			method: "GET",
			data: { doctid: $('#DoctorAcCode').val() },
			success: function (Data) {
				$('#DoctorAcCodeX').val(Data);
			},
			error: function (errormessage) {
				console.error(errormessage.responseText);
			}
		});
	}
}
function GetHeadCodeSrNo() {
	$.ajax({
		url: "/Master/FindLedgerCode/",
		method: "GET",
		data: { doctid: $('#DoctorAcCodeX').val() },
		success: function (Data) {
			$('#DoctorAcCode').val(Data);
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}
function TotalDiscountDetails() {
	var rowcount = $('#TotalRow').val(); var Amt1 = 0;
	for (var i = 0; i < rowcount; i++) {
		Amt1 = parseFloat(Amt1) + (isNaN($('#PatientDiscountMasterViewModels_' + i + '__DiscAmt1').val()) == true ? 0 : parseFloat($('#PatientDiscountMasterViewModels_' + i + '__DiscAmt1').val()));
	}
	$("#DiscAmt").val(parseFloat(Amt1).toFixed(2));	
	GrandTotalPaid();
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
			data: $('#form').serialize(),
			url: "/Master/DeleteOrderItem",
			type: "Post",
		})
			.done(function (partialViewResult) {
				$("#orderItemContinaer").html(partialViewResult);
				if ($('#Id').val() > 0) {
					location.reload();
				}
			});
	}
	//GrandTotalAmount();
}
function GetSearchPatientDateWiseDetails() {
	var empobj = {
		cmpid: $('#CenterId').val(),
		patienttype :$('#Type').val(),
		fromdate: $('#FromDate').val(),
		uptodate: $('#UptoDate').val()
	}
	$.ajax({
		url: "/Master/PatientDateWiseRecord/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			var html = ''; var sextype = ''; var tempNo = 1; var paidclass = "";
			if (result.length > 0) {
				$.each(result, function (key, item) {
					sextype = item.sex == 0 ? "Male" : item.sex == 1 ? "Female" : "None";
					paidclass = item.reportCancel == true ? "reportCancelColor" : item.balAmt == 0 ? "fullpaidColor" : item.balAmt > 0 && item.paidAmt > 0 ? "partialpaidColor" : "fullyunpaidColor";
					html += '<tr class="small '+ paidclass +'">';
					html += '<td hidden>' + item.id + '</td>';
					html += '<td>' + tempNo + '</td>';
					html += '<td>' + item.type + '</td>';
					html += '<td>' + item.sDate + '</td>';
					html += '<td>' + item.refNo + '</td>';
					html += '<td>' + item.name + ' ' + item.age + ' ' + item.ageType + '/' + sextype + '</td>';
					html += '<td>' + item.ledgerMasterViewModel.partyName + '</td>';
					html += '<td class="actionListButtonWidthAgent">' +
						'<a href="Registration-File?id=' + item.id + '"' + '<span><i class="far fa-edit mr-3 fa-1x icon-color-green"></i></span></a>' +
						'</td >';
					html += '</tr>';
					tempNo++;
				});
			}
			else {
				html += '<tr>';
				html += '<td colspan="6"> ' + '<h3 class="text-danger text-center">No Record found......</h3>' + '</td>';
				html += '</tr>';
			}
			$('.orderItemtodaylistContainer').html(html);
			// '<a href="AddressBook-Delete-File?id=' + item.ledgerMasterId + '"' +  '<span><i class="fas fa-times fa-2x icon-color-red"></i></span></a>' +
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function GetSearchPatientTodayWiseDetails() {
	var empobj = {
		cmpid: $('#CompId').val(),
		patienttype: $('#Type').val()
	}
	$.ajax({
		url: "/Master/PatientTodayDateWiseRecord/",
		method: "GET",
		dataType: "json",
		data: empobj,
		contentType: "application/json",
		success: function (result) {
			var html = ''; var sextype = ''; var tempNo = 1; var paidclass = "";
			if (result.length > 0) {
				$.each(result, function (key, item) {
					sextype = item.sex == 0 ? "Male" : item.sex == 1 ? "Female" : "None";
					paidclass = item.balAmt == 0 ? "fullpaidColor" : item.balAmt > 0 && item.paidAmt > 0 ? "partialpaidColor" : "fullyunpaidColor";
					html += '<tr class="small ' + paidclass + '">';
					html += '<td hidden>' + item.id + '</td>';
					html += '<td>' + tempNo + '</td>';
					html += '<td>' + item.type + '</td>';
					html += '<td>' + item.sDate + '</td>';
					html += '<td>' + item.refNo + '</td>';
					html += '<td>' + item.name + ' ' + item.age + ' ' + item.ageType + '/' + sextype + '</td>';
					html += '<td>' + item.ledgerMasterViewModel.partyName + '</td>';
					html += '<td class="actionListButtonWidthAgent">' +
						'<a href="Registration-File?id=' + item.id + '"' + '<span><i class="far fa-edit mr-3 fa-1x icon-color-green"></i></span></a>' +
						'</td >';
					html += '</tr>';
					tempNo++;
				});
			}
			else {
				html += '<tr>';
				html += '<td colspan="6"> ' + '<h3 class="text-danger text-center">No Record found......</h3>' + '</td>';
				html += '</tr>';
			}
			$('.orderItemtodaylistContainer').html(html);
			// '<a href="AddressBook-Delete-File?id=' + item.ledgerMasterId + '"' +  '<span><i class="fas fa-times fa-2x icon-color-red"></i></span></a>' +
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
	return false;
}
function ModelShwoHid() {
	$('#messageId').val(' ');
	if ($('#Id').val() == 0) {
		$('#ModelIdReg').modal('show');
	}
	else if ($('#Id').val() != 0) {
		$('#ModelIdReg').modal('show');
		if ($('#messageId').val() =="Record Update Successfully..") {
			$('#ModelIdReg').modal('hide');
        }
    }
}