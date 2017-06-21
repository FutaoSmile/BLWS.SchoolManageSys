(function () {
    var app = angular.module("Score", ["ngRoute"]);

    app.constant("ScoreApiUrl", "http://localhost:57424/api/Scores/");
}());