$(document).ready(function (e) {
    var time = 60;
    $("#reg3").css("background-color", "#1b83da")
    $("#reg3").css("box-shadow", "0 0 10px 0 #999")
    $("#reg3").css("text-shadow", "3px 3px 20px #ffac66")
    $("#reg3").parent().find("span").css("color", "#1b83da")
    $("#reg3").parent().find("span").css("font-weight", "bold")

    if ($(".yz_span").html() == "ok") {
        
        getrandom();
    }

        function getrandom() {
            if (time == 0) {
                time = 60;
                $(".getyzm").show();
                $(".yztime").hide();
                return;
            }
            else {
                $(".yztime").show();
                $(".getyzm").hide();
                time--;
                $('.yztime').html("请" + time + "秒后重试");
                setTimeout(function () {
                    getrandom();
                }, 1000)
            }

        
    }})