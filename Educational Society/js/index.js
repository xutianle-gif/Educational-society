$(document).ready(function (e) {
    $('.arthd').hide()
    $('#art_hd1').show();
    $('#hd1').click(function () {
        $('.arthd').hide();
        $('#art_hd2').fadeIn(300);
    })
    $('#hd2').click(function () {
        $('.arthd').hide();
        $('#art_hd3').fadeIn(300);
    })
})