$(document).ready(function () {
	$("#VNo").focus();
	if ($('#Id').val() == null || $('#Id').val() == 0) {
		$('#VDate').val(CurrentDate());
	}
	if ($('#Id').val() > 0) {
		GetAgentFilePayBill();
	}
	// 0731K00002
});
function GrandTotalPurMRPAmtCount() {
	var totalAmt = isNaN($('#TotalAmt').val()) == true || $('#TotalAmt').val().trim() == "" ? 0 : $('#TotalAmt').val();
	var epfAmt = isNaN($('#DiscAmt').val()) == true || $('#DiscAmt').val().trim() == "" ? 0 : $('#DiscAmt').val();		
	var TotalNetAmt = parseFloat(totalAmt) - parseFloat(epfAmt);
	$('#PaidAmt').val(parseFloat(TotalNetAmt).toFixed(2));
}

function GetAgentFilePayBill() {
	$('#EmpNameX').text(''); $('#EmpAddressX').text(''); $('#EmpMobileNoX').text('');
	$('#PatId').val('0');
	$.ajax({
		url: "/Master/GetPatientDetailsFile/",
		method: "GET",
		data: { vouchNo: $('#VNo').val()},
		success: function (result) {
			$('#PatId').val(result.id);
			$('#EmpNameX').text(result.name + ' ' + result.age + ' ' + result.ageType + ' / ' + (result.sex == 0 ? 'Male' : result.sex == 1 ? 'Female' : 'None'));
			$('#EmpAddressX').text(result.address);
			$('#EmpMobileNoX').text(result.mobileNo);
			if ($('#Id').val() == 0) {
				$('#TotalAmt').val(result.balAmt);
			}
		},
		error: function (errormessage) {
			console.error(errormessage.responseText);
		}		
	});	
}