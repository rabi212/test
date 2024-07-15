//Load Data in Table when documents is ready  
$(document).ready(function () {

    $('#Ledger_Name').focus();

    $("#Under_Name").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Financial/AccountGroupGetSearchValue",
                type: "Post",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.under_Name, value: item.under_Name };
                    }));
                }
            });
        }
        //messages: {
        //    noResults: "", results: ""
        //}
    });

    //.data("ui-autocomplete")._renderItem = function (ul, item) {
    //    var expression = new RegExp(this.term, "gi");
    //    var result = expression.exec(item.label);
    //    var answer;
    //    if (result.index == 0) {
    //        var first = item.label.charAt(0);
    //        var remaining = item.label.slice(1, item.label.length);
    //        var first1 = first..replace(expression, "<span style='font-weight:bold;color:red'" > + this.term.toUpperCase() + "</span>");
    //        var remaining1 = remaining..replace(expression, "<span style='font-weight:bold;color:red'" > + this.term.toLowerCase() + "</span>");
    //        answer = first1 + remaining1;
    //    }
    //    else
    //       answer = item.label.replace(expression, "<span style='font-weight:bold;color:red'" > + this.term.toLowerCase() + "</span>");
    //    return $("<li></li>")
    //        .append("<a>" + answer + "</a>")
    //        .appendTo(ul);
    //};

});