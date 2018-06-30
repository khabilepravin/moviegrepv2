$(document).ready(function () {
    $('.row').each(function (i, elem) {
        $(this).fadeIn("slow").delay(1000 * 3);
    });

    //GetTitlePercent();

});

function GetTitlePercent() {
    var startTime = '@Model[0].StartTime';
    var getPercentageUrl = '@Url.Action("GetTitlePercent", "Titles", new { id = Model[0].TitleId, currentTime=Model[0].StartTime.TotalSeconds })';
    $.ajax({
        type: "GET",
        url: getPercentageUrl
    }).done(function (data) {
        if (data != undefined && data != '') {
            data += '%';
            $('#progressBar').css('width', data);
            $('#progressTime').html(startTime);
        }
    });
}