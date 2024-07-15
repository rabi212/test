var rowno = 0; var projects = [];
$(document).ready(function () {
	$("#CompId").focus();
	if ($('#Id').val() == null || $('#Id').val() == 0) {
		$('#VDate').val(CurrentDate());
		TotalDaysCount();
	}	
	$('#TotalPayX').text($('#TotalPay').val());
	$('#TotalDedPayX').text($('#TotalDedPay').val());
	$('#NetPayX').text($('#NetPay').val());
	$('#EmpIdX').text(parseInt($('#EmpId').val()));
	if ($('#Id').val() > 0) {
		GetAgentFilePayBill();
	}
	// 0731K00002
});
function TotalNewBasic() {
	var newDate = $('#VDate').val().split('/');
	var CurrentmonthDays = monthDayCount(newDate[1], newDate[2]);
	var newbasic = isNaN($('#BasicPay').val()) == true || $('#BasicPay').val().trim() == "" ? 0 : $('#BasicPay').val();
	var newday = isNaN($('#AttendDays').val()) == true || $('#AttendDays').val().trim() == "" ? 0 : $('#AttendDays').val();
	
	var toalpayable = parseFloat( newday * ( newbasic /CurrentmonthDays )).toFixed(0);
	$('#NewBasicPay').val(toalpayable);
	//$('#TotalPayX').text(parseFloat(toalpayable).toFixed(2));
}
function TotalPaymentAmount() {
	var newbasic = isNaN($('#NewBasicPay').val()) == true || $('#NewBasicPay').val().trim() == "" ? 0 : $('#NewBasicPay').val();
	var newda = isNaN($('#DA').val()) == true || $('#DA').val().trim() == "" ? 0 : $('#DA').val();
	var newta = isNaN($('#TA').val()) == true || $('#TA').val().trim() == "" ? 0 : $('#TA').val();
	var newhra = isNaN($('#HRA').val()) == true || $('#HRA').val().trim() == "" ? 0 : $('#HRA').val();
	var newcca = isNaN($('#CCA').val()) == true || $('#CCA').val().trim() == "" ? 0 : $('#CCA').val();
	var newip = isNaN($('#IPAmt').val()) == true || $('#IPAmt').val().trim() == "" ? 0 : $('#IPAmt').val();
	var newbonuse = isNaN($('#BonusAmt').val()) == true || $('#BonusAmt').val().trim() == "" ? 0 : $('#BonusAmt').val();
	var toalpayable = parseFloat(newbasic) + parseFloat(newda) + parseFloat(newta) + parseFloat(newhra) + parseFloat(newcca) + parseFloat(newip) + parseFloat(newbonuse);
	$('#TotalPay').val(toalpayable);
	$('#TotalPayX').text(parseFloat(toalpayable).toFixed(2));
	GrandTotalPurMRPAmtCount();
}
function GrandTotalPurMRPAmtCount() {
	var totalAmt = isNaN($('#TotalPay').val()) == true || $('#TotalPay').val().trim() == "" ? 0 : $('#TotalPay').val();
	var epfAmt = isNaN($('#EFP').val()) == true || $('#EFP').val().trim() == "" ? 0 : $('#EFP').val();
	var advAmt = isNaN($('#AdvAmt').val()) == true || $('#AdvAmt').val().trim() == "" ? 0 : $('#AdvAmt').val();
	var licAmt = isNaN($('#LIC').val()) == true || $('#LIC').val().trim() == "" ? 0 : $('#LIC').val();
	var TotaldeductAmt = parseFloat(epfAmt) + parseFloat(advAmt) + parseFloat(licAmt);
	var TotalNetAmt = parseFloat(totalAmt) - parseFloat(epfAmt) - parseFloat(advAmt) - parseFloat(licAmt);
	$('#TotalDedPay').val(parseFloat(TotaldeductAmt).toFixed(2));
	$('#TotalDedPayX').text(parseFloat(TotaldeductAmt).toFixed(2));

	$('#NetPay').val(parseFloat(TotalNetAmt).toFixed(2));
	$('#NetPayX').text(parseFloat(TotalNetAmt).toFixed(2));
}
function TotalDaysCount() {	
	var newDate = $('#VDate').val().split('/');		
	$('#AttendDays').val(monthDayCount(newDate[1], newDate[2]));
}
function GetAgentFilePayBill() {
	$('#EmpNameX').text(''); $('#EmpAddressX').text(''); $('#EmpMobileNoX').text('');
	$('#EmpBankNameX').text(''); $('#EmpAcNoX').text(''); $('#EmpIFSCNoX').text('');
	$.ajax({
		url: "/PayBill/GetAgentDetailsFile/",
		method: "GET",
		data: { id: parseInt($('#EmpId').val())},
		success: function (result) {
			$('#EmpNameX').text(result.name);
			$('#EmpAddressX').text(result.address1);
			$('#EmpMobileNoX').text(result.mobileNo);
			$('#EmpBankNameX').text(result.bankName);
			$('#EmpAcNoX').text(result.bankAcNo);
			$('#EmpIFSCNoX').text(result.ifsc);
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}		
	});	
}
function GetAgentFileLastPayBill() {
	$('#BasicPay').val('0.00');	$('#NewBasicPay').val('0.00');
	$('#DA').val('0.00');$('#TA').val('0.00');$('#HRA').val('0.00');
	$('#CCA').val('0.00');$('#IPAmt').val('0.00');$('#BonusAmt').val('0.00');
	$('#TotalPay').val('0.00');	$('#EFP').val('0.00');$('#AdvAmt').val('0.00');
	$('#LIC').val('0.00');$('#TotalDedPay').val('0.00');$('#NetPay').val('0.00');
	$.ajax({
		url: "/PayBill/GetAgentDetailsBasicAmtFile/",
		method: "GET",
		data: { id: $('#EmpId').val().trim(), uptoDate: $('#VDate').val().trim() },
		success: function (result) {
			$('#BasicPay').val(result.basicPay);
			$('#NewBasicPay').val(result.newBasicPay);
			$('#DA').val(result.da);
			$('#TA').val(result.ta);
			$('#HRA').val(result.hra);
			$('#CCA').val(result.cca);
			$('#IPAmt').val(result.ipAmt);
			$('#BonusAmt').val(result.bonusAmt);
			$('#TotalPay').val(result.totalPay);
			$('#EFP').val(result.efp);
			$('#AdvAmt').val(result.advAmt);
			$('#LIC').val(result.lic);
			$('#TotalDedPay').val(result.totalDedPay);
			$('#NetPay').val(result.netPay);
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}
	});
}