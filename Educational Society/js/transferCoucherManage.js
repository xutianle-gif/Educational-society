$(document).ready(function (e) {
    $("#content2").hide();
    //$(".tb_user").hover(function () {
    //    var value = $(this).children().find(".span").text();
    //    if (value == "已缴费") {
    //        $(this).children().find(".div2").show()
    //        $(this).children().find(".div3").hide()
    //    }
    //    else {
    //        $(this).children().find(".div1").show()
    //        $(this).children().find(".div3").hide()
    //    }
    //})

    //function getvalue()
    //{
    //    var tableID = document.getElementById("tb_user");
    //    var str = "";
    //    for (var i = 1; i <=tableID.rows.length; i++)
    //    {
    //        str = tableID.rows[1].cells[2].innerHTML;
    //        str = tableID.rows[i].cells[4].innerHTML
    //        if (str== "已缴费")
    //        {
    //            $(this).children().find(".div2").show()
    //            $(this).children().find(".div3").hide()
    //        }
    //        else
    //        {
    //            $(this).children().find(".div1").show()
    //            $(this).children().find(".div3").hide()
    //        }
    //    }
    //}
    
    //$(".upload").click(function () {
    //    $("#content2").fadeIn(400);
    //    var value = this.id;
    //    $(".test").attr('value', value)
    //})

    $("#btn_back").click(function () {
        $("#content2").hide();
    })

    $(".getpic").click(function () {
        var value = this.id
        $(".mask").show();
        $("#bigg").show();
        $("#bigg").attr('src', value);
    })
    $(".mask").click(function () {
        $(".mask").hide();
        $(".bigimg").hide();
        $(".bigimg").attr('src', "");
        $(".bigimg").attr('display', 'hidden')
    })

})