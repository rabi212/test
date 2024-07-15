$(document).ready(function () {
    blink();
    $('.customdatetime').datepicker({
        dateFormat: 'dd/mm/yy',
        autoclose: true,
        changeMonth: true,
        changeYear: true,
        yearRange: "-20:+2"
    });

    $('.CustomTimeX').timepicker({
        showSecond: true,
        showMillisec: true,
        timeFormat: 'hh:mm:TT',
        autoclose: true,
    });

    $('body').on('keydown', 'input, select, password', function (e) {
        var self = $(this)
            , form = self.parents('form:eq(0)')
            , focusable
            , next
            ;
        if (e.keyCode === 13) {
            focusable = form.find('input,a,select,button').filter(':visible');
            next = focusable.eq(focusable.index(this) + 1);
            if (next.length) {
                next.focus();
            }
            return false;
        }
        else if (e.keyCode === 27) {
            focusable = form.find('input,a,select,button').filter(':visible');
            next = focusable.eq(focusable.index(this) - 1);
            if (next.length) {
                next.focus();
            }
            return false;
        }
    });
    function blink() {
        $('.blink_me').fadeOut(500).fadeIn(500, blink);
    }
    $('input:text').focus(function () {
        $(this).css({ 'background': 'cornsilk' }); // mediumseagreen
        $(this).css({ 'color': 'black' });
       /* $(this).css({ 'border': '1px solid red' });*/
        $(this).select();
    });
    $('input:text').blur(function () {
        $(this).css({ 'background': 'white' });
        $(this).css({ 'color': 'black' });        
    });

    $('.selectedItems').focus(function () {
        $(this).css({ 'background': 'cornsilk' }); // mediumseagreen
        $(this).css({ 'color': 'black' });
        $(this).select();
    });
    $('.selectedItems').blur(function () {
        $(this).css({ 'background': 'white' });
        $(this).css({ 'color': 'black' });
    });
});


function Open_Dropdownlist(uqiqueid) {
    
}
function confirmDelete(uniqueId, IsDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId
    if (IsDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    }
    else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}
function LoadFile(input) {
    if (input.files && input.files[0]) {
        var filerdr = new FileReader();
        filerdr.onload = function (e) {
            $('#user_img').attr('src', e.target.result);
        }
        filerdr.readAsDataURL(input.files[0]);
    }
}
function LoadImage(input, previewimage) {
    if (input.files && input.files[0]) {
        var filerdr = new FileReader();
        filerdr.onload = function (e) {
            $(previewimage).attr('src', e.target.result);
        }
        filerdr.readAsDataURL(input.files[0]);
    }
}
function OnScrollDiv(Scrollablediv) {
    document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
    document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
}
function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
    var tbl = document.getElementById(gridId);
    if (tbl) {
        var DivHR = document.getElementById('DivHeaderRow');
        var DivMC = document.getElementById('DivMainContent');
        var DivFR = document.getElementById('DivFooterRow');

        //*** Set divheaderRow Properties ****
        DivHR.style.height = headerHeight + 'px';
        DivHR.style.width = (parseInt(width) - 16) + 'px';
        DivHR.style.position = 'relative';
        DivHR.style.top = '0px';
        DivHR.style.zIndex = '10';
        DivHR.style.verticalAlign = 'top';

        //*** Set divMainContent Properties ****
        DivMC.style.width = width + 'px';
        DivMC.style.height = height + 'px';
        DivMC.style.position = 'relative';
        DivMC.style.top = -headerHeight + 'px';
        DivMC.style.zIndex = '1';

        //*** Set divFooterRow Properties ****
        DivFR.style.width = (parseInt(width) - 16) + 'px';
        DivFR.style.position = 'relative';
        DivFR.style.top = -headerHeight + 'px';
        DivFR.style.verticalAlign = 'top';
        DivFR.style.paddingtop = '2px';

        if (isFooter) {
            var tblfr = tbl.cloneNode(true);
            tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
            var tblBody = document.createElement('tbody');
            tblfr.style.width = '100%';
            tblfr.cellSpacing = "0";
            //*****In the case of Footer Row *******
            tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
            tblfr.appendChild(tblBody);
            DivFR.appendChild(tblfr);
        }
        //****
        DivHR.appendChild(tbl.cloneNode(true));
    }
}

function OnScrollDiv2(Scrollablediv2) {
    document.getElementById('DivHeaderRow2').scrollLeft = Scrollablediv2.scrollLeft;
    document.getElementById('DivFooterRow2').scrollLeft = Scrollablediv2.scrollLeft;
}
function MakeStaticHeader2(gridId, height, width, headerHeight, isFooter) {
    var tbl = document.getElementById(gridId);
    if (tbl) {
        var DivHR = document.getElementById('DivHeaderRow2');
        var DivMC = document.getElementById('DivMainContent2');
        var DivFR = document.getElementById('DivFooterRow2');

        //*** Set divheaderRow Properties ****
        DivHR.style.height = headerHeight + 'px';
        DivHR.style.width = parseInt(parseInt(width) - 16) + 'px';
        DivHR.style.position = 'relative';
        DivHR.style.top = '0px';
        DivHR.style.zIndex = '10';
        DivHR.style.verticalAlign = 'top';

        //*** Set divMainContent Properties ****
        DivMC.style.width = width + 'px';
        DivMC.style.height = height + 'px';
        DivMC.style.position = 'relative';
        DivMC.style.top = -headerHeight + 'px';
        DivMC.style.zIndex = '1';

        //*** Set divFooterRow Properties ****
        DivFR.style.width = parseInt(parseInt(width) - 16) + 'px';
        DivFR.style.position = 'relative';
        DivFR.style.top = -headerHeight + 'px';
        DivFR.style.verticalAlign = 'top';
        DivFR.style.paddingtop = '2px';

        if (isFooter) {
            var tblfr = tbl.cloneNode(true);
            tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
            var tblBody = document.createElement('tbody');
            tblfr.style.width = '100%';
            tblfr.cellSpacing = "0";
            //*****In the case of Footer Row *******
            tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
            tblfr.appendChild(tblBody);
            DivFR.appendChild(tblfr);
        }
        //****
        DivHR.appendChild(tbl.cloneNode(true));
    }
}
function MakeStaticHeaderWithPercentage2(gridId, height, width, headerHeight, isFooter) {
    var tbl = document.getElementById(gridId);
    if (tbl) {
        var DivHR = document.getElementById('DivHeaderRow');
        var DivMC = document.getElementById('DivMainContent');
        var DivFR = document.getElementById('DivFooterRow');

        //*** Set divheaderRow Properties ****
        DivHR.style.height = headerHeight + 'px';
        DivHR.style.width = (parseInt(width) - 3) + '%'; //(parseInt(width) - 16) + 'px';
        DivHR.style.position = 'relative';
        DivHR.style.top = '0px';
        DivHR.style.zIndex = '10';
        DivHR.style.verticalAlign = 'top';

        //*** Set divMainContent Properties ****
        DivMC.style.width = (parseInt(width)) + '%'; // width + 'px'
        DivMC.style.height = height + 'px';
        DivMC.style.position = 'relative';
        DivMC.style.top = -headerHeight + 'px';
        DivMC.style.zIndex = '1';

        ////*** Set divFooterRow Properties ****
        DivFR.style.width = (parseInt(width) - 1.3) + '%'; // (parseInt(width) - 16) + 'px'
        DivFR.style.position = 'relative';
        DivFR.style.top = -headerHeight + 'px';
        DivFR.style.verticalAlign = 'top';
        DivFR.style.paddingtop = '2px';

        if (isFooter) {
            var tblfr = tbl.cloneNode(true);
            tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
            var tblBody = document.createElement('tbody');
            tblfr.style.width = '100%';
            tblfr.cellSpacing = "0";
            //*****In the case of Footer Row *******
            tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
            tblfr.appendChild(tblBody);
            DivFR.appendChild(tblfr);
        }
        //****
        DivHR.appendChild(tbl.cloneNode(true));
    }
}
function OnlyNumber(evt) {
    evt = evt ? evt : window.event;
    var charCode = evt.which ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}
function isNumber(evt, element) {

    var charCode = evt.which ? evt.which : event.keyCode;

    if (
        (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
        (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
        (charCode < 48 || charCode > 57))
        return false;

    return true;
}
function monthDiff(d1, d2) {
    var months;
    months = (d2.getFullYear() - d1.getFullYear()) * 12;
    months -= d1.getMonth();
    months += d2.getMonth();
    return months <= 0 ? 0 : months;
}
function monthDayCount(month, year) {
    // Here January is 1 based
    //Day 0 is the last day in the previous month
    return new Date(year, month, 0).getDate();
    // Here January is 0 based
    // return new Date(year, month+1, 0).getDate();    
}
function monthDayCount1(month, year) {
    var n = 0;
    // Here January is 1 based
    //Day 0 is the last day in the previous month
    //var months = [4 = 'April', 5 = 'May', 6 = 'June', 7 = 'July', 8 = 'August', 9 = 'September', 10 = 'October', 11 = 'November', 12 = 'December', 1 = 'January', 2 = 'February', 3 = 'March'];       
    var months = [{ prop1: 'January' }, { prop1: 'February' }, { prop1: 'March' }, { prop1: 'April' }, { prop1: 'May' }, { prop1: 'June' },
    { prop1: 'July' }, { prop1: 'August' }, { prop1: 'September' }, { prop1: 'October' }, { prop1: 'November' }, { prop1: 'December' }];
    n = months.findIndex(x => x.prop1 == month) + 1;
    return new Date(year, n, 0).getDate();
    // Here January is 0 based
    // return new Date(year, month+1, 0).getDate();    
}
function cal() {
    d1 = new Date($("#datepicker1").val());
    d2 = new Date($("#datepicker2").val());
    alert("The difference between two dates is: " + monthDiff(d1, d2));
}
// Only Date Format YYYY-MM-DD
function dateDiff(date) {
    date = date.split('-');
    var today = new Date();
    var year = today.getFullYear();
    var month = today.getMonth() + 1;
    var day = today.getDate();
    var yy = parseInt(date[0]);
    var mm = parseInt(date[1]);
    var dd = parseInt(date[2]);
    var years, months, days;
    // months
    months = month - mm;
    if (day < dd) {
        months = months - 1;
    }
    // years
    years = year - yy;
    if (month * 100 + day < mm * 100 + dd) {
        years = years - 1;
        months = months + 12;
    }
    // days
    days = Math.floor((today.getTime() - (new Date(yy + years, mm + months - 1, dd)).getTime()) / (24 * 60 * 60 * 1000));
    //
    return { years: years, months: months, days: days };
}

function ConvertDateFormating(dt) {
    var dt2 = "";
    var ary = dt;
    var ary1 = [];
    ary1 = ary.split(" ");
    var months = {
        jan: '01', feb: '02', mar: '03', apr: '04', may: '05', jun: '06',
        jul: '07', aug: '08', sep: '09', oct: '10', nov: '11', dec: '12'
    };
    if (ary1[1] != '') {
        dt2 = ary1[1] + "/" + months[ary1[0].toLowerCase()] + "/" + ary1[2];
    }
    else {
        dt2 = "0" + ary1[1] + "/" + months[ary1[0].toLowerCase()] + "/" + ary1[2];
    }
    return dt2;
}
// date 2017-01-29
function ConvertDateFormatingyear(dt) {
    var dt2 = "";
    var ary = dt;
    var ary1 = [];
    ary1 = ary.split("/");
    dt2 = ary1[2] + "-" + ary1[1] + "-" + ary1[0];
    return dt2;
}
// date 2017,01,29
function ConvertDateFormatingyearDate(dt) {
    var dt2 = "";
    var ary = dt;
    var ary1 = [];
    ary1 = ary.split("/");
    dt2 = ary1[2] + "," + ary1[1] + "," + ary1[0];
    return dt2;
}

// date 2017-01-29
function daysInMonth(year, month) {
    return new Date(year, month + 1, 0).getDate();
}

function addMonths(date, months) {
    var target_month = date.getMonth() + months;
    var year = date.getFullYear() + parseInt(target_month / 12);
    var month = target_month % 12;
    var day = date.getDate();
    var last_day = daysInMonth(year, month);
    if (day > last_day) {
        day = last_day;
    }
    var new_date = new Date(year, month, day);
    return new_date;
}
function getLstDayOfMonFnc(date) {
    return new Date(date.getFullYear(), date.getMonth(), 0).getDate()
}
function ConvertTwoDecimal(el) {
    var v = parseFloat(el.value);
    el.value = (isNaN(v)) ? '0.00' : v.toFixed(2);
}
function ConvertThreeDecimal(el) {
    var v = parseFloat(el.value);
    el.value = (isNaN(v)) ? '0.000' : v.toFixed(3);
}
function GetCompanyAllUser() {
    $.ajax({
        url: "/Account/GetAllUserToCompany/",
        method: "GET",
        data: { cmpId: $('#CompId').val() },
        success: function (result) {
            //result = JSON.parse(result);
            $('#UserId').empty();
            if ($('#CompId').val() == 0) {
                $('#UserId').append('<option value=0">ALL</option>');
            }
            $.each(result, function (i, item) {
                // replace 'item.Value' and 'item.Text' from corresponding list properties into model class
                $('#UserId').append('<option value="' + item.value + '"> ' + item.text + ' </option>');               
            });
        },
        error: function (errormessage) {
            console.error(errormessage.responseText);
        }
    });
}
function updateClock() {

    var currentTime = new Date();
    
    var currentHours = currentTime.getHours();
    var currentMinutes = currentTime.getMinutes();
    var currentSeconds = currentTime.getSeconds();
    var currentDay = currentTime.getDay();
    var currentMonth = currentTime.getMonth();

    // Pad the minutes and seconds with leading zeros, if required
    currentMinutes = (currentMinutes < 10 ? "0" : "") + currentMinutes;
    currentSeconds = (currentSeconds < 10 ? "0" : "") + currentSeconds;

    // Choose either "AM" or "PM" as appropriate
    var timeOfDay = (currentHours < 12) ? "AM" : "PM";

    // Convert the hours component to 12-hour format if needed
    currentHours = (currentHours > 12) ? currentHours - 12 : currentHours;

    // Convert an hours component of "0" to "12"
    currentHours = (currentHours == 0) ? 12 : currentHours;

    // Compose the string for display
    //var currentTimeString = currentHours + ":" + currentMinutes + ":" + currentSeconds + " " + timeOfDay;
    var currentTimeString = (currentHours < 10 ? "0" + currentHours : currentHours) + ":" + currentMinutes + " " + timeOfDay;

    return currentTimeString;
}
function CurrentDate() {
    var x = new Date()
    var month = (x.getMonth() + 1).toString();
    month = month.length == 1 ? 0 + month : month;

    var dt = x.getDate().toString();
    dt = dt.length == 1 ? 0 + dt : dt;

    //var x1 = month + "/" + dt + "/" + x.getFullYear();
    var x1 = dt + "/" + month + "/" + x.getFullYear();
    return x1;
}
function CurrentDateTime() {
    var x = new Date()
    var ampm = x.getHours() >= 12 ? ' PM' : ' AM';
    hours = x.getHours() % 12;
    hours = hours ? hours : 12;
    hours = hours.toString().length == 1 ? 0 + hours.toString() : hours;

    var minutes = x.getMinutes().toString()
    minutes = minutes.length == 1 ? 0 + minutes : minutes;

    var seconds = x.getSeconds().toString()
    seconds = seconds.length == 1 ? 0 + seconds : seconds;

    var month = (x.getMonth() + 1).toString();
    month = month.length == 1 ? 0 + month : month;

    var dt = x.getDate().toString();
    dt = dt.length == 1 ? 0 + dt : dt;

    //var x1 = month + "/" + dt + "/" + x.getFullYear();
    var x1 = dt + "/" + month + "/" + x.getFullYear();
    x1 = x1 + " " + hours + ":" + minutes + " " + ampm;
    return x1;
}
function toChangeUpperCase(str) {
    return str.replace(/(?:^|\s)\w/g, function (match) {
        return match.toUpperCase();
    });
}
$("#btn-confirm").on("click", function () {
    $("#mi-modal").modal('show');
    setTimeout(function () {
        $('#modal-btn-si').focus();
    }, 500);
});

$("#modal-btn-si").on("click", function () {
    $('#submit').click();    
    $("#mi-modal").modal('hide');
});
$("#modal-btn-no").on("click", function () {
    $("#mi-modal").modal('hide');
});