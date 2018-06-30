$(document).ready(function () {
    var titleId = $('#titleIdForPostProcess').val();
    parseTitle(titleId);
});

function parseTitle(titleId) {
    $('#progressIndicator').css('display', 'block');
    var parseTitleUrl = baseURL + 'titles/ParseTitle';
    var params = { "titleId": titleId };

    $.ajax({
        type: "GET",
        url: parseTitleUrl,
        data: params,
        cache:false
    }).done(function () {
        $('#progressIndicator').css('display', 'none');
        indexTitle(titleId);
    });
}

function indexTitle(titleId) {
    $('#progressIndicator').html('Indexing...')
    $('#progressIndicator').css('display', 'block');
    var indexTitleUrl = baseURL + 'titles/indextitle';
    var params = { "titleId": titleId };

    $.ajax({
        type: "GET",
        url: indexTitleUrl,
        data: params,
        cache: false
    }).done(function () {
        $('#progressIndicator').css('display', 'none');
        $('#message').html('Done');
    });
}