$(document).ready(function () {

    $("#search").keyup(function (e) {
        if (e.keyCode == 13) {
            BuildSearchParamAndSearch();
        }
    });

    $('#titleName').keyup(function (e) {
        if (e.keyCode == 13) {
            BuildSearchParamAndSearch();
        }
    })

    $('#searchButton').on('click', function () {
        BuildSearchParamAndSearch();
    })

    $('#nextRandomQuote').on('click', function () {
        $('#randomQuoteText').animate({ opacity: "0.0" }, function () {
            NextRandomQuote();
        });
    });

    NextRandomQuote();
    //applyTitleAutosuggest('#titleName');
});

function BuildSearchParamAndSearch() {
    var searchString = $('#search').val();
    var titleName = $('#titleName').val();
    if (searchString != '') {
        var param = { 'searchCriteria': searchString, 'titleName': titleName };
        Search(param);
    }
}

function NextRandomQuote() {
    var randomTextUrl = baseURL + 'Quotes/RandomText';  //'@Url.Action("RandomText", "Quotes")';
    var randomTextRequest = $.ajax({
        type: "GET",
        url: randomTextUrl,
        cache: false
    });
    
    randomTextRequest.done(function (data) {
        if (data != undefined && data != '') {
            $('#randomQuoteText').html(data);
            $('#randomQuoteText').animate({ opacity: "100.0" });
            //initiateRating('#randomQuoteRate', function (value) {
            //    var ratingControl = $('#randomQuoteRate');
            //    RateIt(value, ratingControl);
            //});
        }
    });

    randomTextRequest.fail(function (jqXHR, status, errorThrown) {
        showDialog(errorThrown);
    });
}

function Search(params) {
    $('#searchInProgress').css('display', 'block');
    var searchUrl = baseURL + 'Quotes/Search'; //'@Url.Action("Search", "Quotes")';
    var searchRequest = $.ajax({
        type: "GET",
        url: searchUrl,
        data: params
    });

    searchRequest.done(function (data) {
        if (data != undefined && data != '') {
            $('#searchResult').html(data);
            //initiateRating(".rateit");
        }
        $('#searchInProgress').css('display', 'none');
    });

    searchRequest.fail(function (jqXHR, status, errorThrown) {
        showDialog(errorThrown);
    });
}

function RateIt(value, ratingControl) {
    var textId = $(ratingControl).attr('data-textid');
    var ratingId = $(ratingControl).attr('data-ratingid');

    var params = { 'rating': value, 'textId': textId, 'ratingId': ratingId }
    var rateQuoteURL = baseURL + 'titles/RateText'; //'@Url.Action("RateText", "titles")';
    $.ajax({
        type: "POST",
        url: rateQuoteURL,
        data: params
    }).done(function (data) {
        if (data != undefined && data != '') {
            $(ratingControl).attr('data-ratingid', data);
        }
    });
}