(function () {
    var app = angular.module("User", ["ngRoute"]);
    //var config = function ($routeProvider) {
    //    $routeProvider
    //        .when("/MyInfo", { templateUrl: "/Views/User/MyInfo.cshtml" })
    //        .otherwise({
    //            redirectTo: "/MyInfo"
    //        });
    //};
    //app.config(config);
    app.constant("UserApiUrl", "http://localhost:57424/api/Users/");
}());