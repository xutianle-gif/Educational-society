$(document).ready(function (e) {
    $("#content2").hide();
    $("#btn_new").click(function () {
        $("#content2").fadeIn(400);
    })

    $("#btn_back").click(function () {
        $("#content2").hide();
    })
})