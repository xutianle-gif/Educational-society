$(document).ready(function (e) {
    yzresult = true;
    $(".reg").hide();
    $("#getreg1").show();
    $("#reg1").css("background-color", "#1b83da")
    $("#reg1").css("box-shadow", "0 0 10px 0 #999")
    $("#reg1").css("text-shadow", "3px 3px 20px #ffac66")
    $("#reg1").parent().find("span").css("color", "#1b83da")
    $("#reg1").parent().find("span").css("font-weight", "bold")
    $(".getreg").click(function () {
        yz()
        if (yzresult == false) {
            Dialog.error("error", "请检查必填信息格式是否正确或是否漏填！");
        }
        else
        {
            yztrue();
            $(".reg").hide();
            id = "#get" + this.id;
            $(id).fadeIn(300);
            $(".get span").css("color", "#999")
            $(".get span").css("font-weight", "none")
            $(this).parent().find("span").css("color", "#1b83da")
            $(this).parent().find("span").css("font-weight", "bold")
            $(".getreg").css("background-color", "#999")
            $(".getreg").css("box-shadow", "")
            $(".getreg").css("text-shadow", "")
            $(this).css("background-color", "#1b83da")
            $(this).css("box-shadow", "0 0 10px 0 #999")
            $(this).css("text-shadow", "3px 3px 20px #ffac66")
        }
    })

    //..

    $()

    //..

    function yz() {
        
        if ($("#getreg1").is(":visible")) {
            yzresult = true;
            var str = document.getElementById("pic_name").value
            if (str == "") {
                yzresult = false
                $("#pic_name").parent().parent().find(".reg4").css("color", "red")
                $("#pic_name").parent().parent().find(".reg4").css("background-color", "rgba(255, 215, 215, 0.3)")
                $("#pic_name").parent().parent().find(".reg4").css("border", "1px solid #f1bdbd")
            }
            str = document.getElementById("txt_address").value
            if (str == "") {
                yzresult = false
                $("#txt_address").parent().parent().find(".reg4").css("color", "red")
                $("#txt_address").parent().parent().find(".reg4").css("background-color", "rgba(255, 215, 215, 0.3)")
                $("#txt_address").parent().parent().find(".reg4").css("border", "1px solid #f1bdbd")
            }
            var myreg = /^[1-9][0-9]{5}$/
            str = document.getElementById("txt_mail").value
            if (!myreg.test(str)) {
                yzresult = false
                $("#txt_mail").parent().parent().find(".reg4").css("color", "red")
                $("#txt_mail").parent().parent().find(".reg4").css("background-color", "rgba(255, 215, 215, 0.3)")
                $("#txt_mail").parent().parent().find(".reg4").css("border", "1px solid #f1bdbd")
            }
            str = document.getElementById("txt_time").value
            if (str == "") {
                yzresult = false
                $("#txt_time").parent().parent().find(".reg4").css("color", "red")
                $("#txt_time").parent().parent().find(".reg4").css("background-color", "rgba(255, 215, 215, 0.3)")
                $("#txt_time").parent().parent().find(".reg4").css("border", "1px solid #f1bdbd")
            }
        }
        if ($("#getreg2").is(":visible")) {
            yzresult = true;
            var str = document.getElementById("txt_tname").value
            if (str == "") {
                yzresult = false
                $("#txt_tname").parent().parent().find(".reg4").css("color", "red")
                $("#txt_tname").parent().parent().find(".reg4").css("background-color", "rgba(255, 215, 215, 0.3)")
                $("#txt_tname").parent().parent().find(".reg4").css("border", "1px solid #f1bdbd")
            }
            str = document.getElementById("txt_address").value
            if (str == "") {
                yzresult = false
                $("#txt_address").parent().parent().find(".reg4").css("color", "red")
                $("#txt_address").parent().parent().find(".reg4").css("background-color", "rgba(255, 215, 215, 0.3)")
                $("#txt_address").parent().parent().find(".reg4").css("border", "1px solid #f1bdbd")
            }
            var myreg = /^[1][3,4,5,7,8][0-9]{9}$/
            str = document.getElementById("txt_tel").value
            if (!myreg.test(str)) {
                yzresult = false
                $("#txt_tel").parent().parent().find(".reg4").css("color", "red")
                $("#txt_tel").parent().parent().find(".reg4").css("background-color", "rgba(255, 215, 215, 0.3)")
                $("#txt_tel").parent().parent().find(".reg4").css("border", "1px solid #f1bdbd")
            }
        }
        if ($("#getreg3").is(":visible")) {
            yzresult = true;
            var str = document.getElementById("txt_name").value
            if (str == "") {
                yzresult = false
                $("#txt_name").parent().parent().find(".reg4").css("color", "red")
                $("#txt_name").parent().parent().find(".reg4").css("background-color", "rgba(255, 215, 215, 0.3)")
                $("#txt_name").parent().parent().find(".reg4").css("border", "1px solid #f1bdbd")
            }
            str = document.getElementById("txt_password").value
            if (str == "") {
                yzresult = false
                $("#txt_password").parent().parent().find(".reg4").css("color", "red")
                $("#txt_password").parent().parent().find(".reg4").css("background-color", "rgba(255, 215, 215, 0.3)")
                $("#txt_password").parent().parent().find(".reg4").css("border", "1px solid #f1bdbd")
            }
        }
        
    }

    

    function yztrue() {
        $(".reg4").css("color", "#000")
        $(".reg4").css("background-color", "rgba(215, 243, 255, 0.3")
        $(".reg4").css("border", "1px solid #bde2f1")
    }




    

})