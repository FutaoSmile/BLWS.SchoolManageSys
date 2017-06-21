(function () {
    var app = angular.module("News", ["ngRoute"]);

    app.constant("News_newsApiUrl", "http://localhost:57424/api/News_news/");
    app.filter('trustHtml', function ($sce) {
        return function (input) {
            return $sce.trustAsHtml(input);
        }})
}());