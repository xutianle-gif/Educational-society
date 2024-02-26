$(document).ready(function (e) {
    $("#content2").hide();
    $(".btn_th").click(function () {
        $("#content2").fadeIn(400);
        var value = this.id;
        $(".test").attr('value', value)
        value = $("#getyear").text();
        $("#lb_year").html(value)
        value = $("#getname").text();
        $("#lb_name").html(value)
    })

    $("#btn_back").click(function () {
        $("#content2").hide();
    })

    $(".tb_user img").hover(function () {
        var value = $(this)[0].src;
        $("#bigg").attr('src', value);
        $("#bigg").fadeIn(400);
    }, function () {
        $("#bigg").attr('src', "");
        $("#bigg").hide();
    })
})