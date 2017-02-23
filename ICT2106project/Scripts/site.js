$(document).ready(function () {
    $('.right').click(function () {
        var position = $('.scrollContainer').position();
        var r = position.left - $(document.getElementById("scroller")).width() + 35;
        $('.scrollContainer').animate({
            'left': '' + r + 'px'
        });
    });

    $('.left').click(function () {
        var position = $('.scrollContainer').position();
        var l = position.left + $(document.getElementById("scroller")).width() - 35;
        if (l <= 0) {
            $('.scrollContainer').animate({
                'left': '' + l + 'px'
            });
        }
    });
});

//Getting the number of the divs with class contentContainer inside the div container
var length = $('div .scrollContainer').children('div .contentContainer').length;
//Setting the % width depending on the number of the child divs
$(".scrollContainer").width(length * 100 + '%');