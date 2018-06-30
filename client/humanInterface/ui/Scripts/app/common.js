function showDialog(dialogMessage) {
    $('#commonDialogMessageContent').html(dialogMessage);
    $('#commonDialog').modal('show');
}
var baseURL;
$(document).ready(function () {
    baseURL = $('#baseURL').attr('href');
});

var applyTitleAutosuggest = function (targetControlSelector) {
    var autoSuggestUrl = baseURL + 'Titles/titleAutoSuggestData';    
    var ajaxRequest = $.ajax({
        type: "GET",
        cache: true,
        url: autoSuggestUrl
    });
    ajaxRequest.done(function (data) {
        if (data != undefined && data != '') {
            var dataArray = data.split(','); // controller returns string, splitting it into an array for autoSuggest            
            $(targetControlSelector).autocomplete({
                source: dataArray
            });
        }
    });

    ajaxRequest.fail(function (jqXHR, status, errorThrown) {        
        showDialog(errorThrown);
    });
};

//var initiateRating = function (targetControlSelector, ratedCallback) {
//    $(targetControlSelector).rateit();

//    var tooltipValues = ['Ok', 'Good', 'Great', 'Excellent', 'Absolutely Amazing']; // these are possible values TODO:Should this be dynamic some how
//    $(targetControlSelector).bind('over', function (event, value) { $(this).attr('title', tooltipValues[value - 1]); });

//    if (ratedCallback != undefined) {
//        $(targetControlSelector).bind('rated', function (event, value) {
//            ratedCallback(value);
//        });
//    }
//};

