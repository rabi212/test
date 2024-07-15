var mini = true;
$(document).ready(function () {
    $('.sub-menu ul').hide();
    $(".sub-menu a").click(function () {
        $(this).parent(".sub-menu").children("ul").slideToggle("100");
        $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");

        var findId = $(this).parent(".sub-menu").children("ul").attr('id');
        $('.sub-menu ul').each(function () {
            var findallid = $(this).attr('id'); // This is your rel id
            if (findId != findallid) {
                $('#' + findallid).hide();
            }
        });
    });

});

function toggleSidebar() {
    console.clear();
    if (screen.width > 576) {
        if (mini) {
            console.log("opening sidebar");
            document.getElementById("mySidebar").style.width = "270px";
            document.getElementById("main1").style.marginLeft = "270px";
            this.mini = false;
        } else {
            console.log("closing sidebar");
            document.getElementById("mySidebar").style.width = "40px"; //45
            document.getElementById("main1").style.marginLeft = "30px";  //30
            this.mini = true;
        }
    }
}