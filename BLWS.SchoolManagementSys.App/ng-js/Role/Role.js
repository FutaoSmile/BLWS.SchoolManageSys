(function () {
    var app = angular.module("Role", ["ngRoute"]);
    //var config = function ($routeProvider) {
    //    $routeProvider
    //        .when("/Role", { templateUrl: "/Views/sysManage/RoleManage.cshtml" })
    //        .otherwise({
    //            redirectTo: "/Role"
    //        });
    //};
    //app.config(config);
    app.constant("RoleApiUrl", "http://localhost:57424/api/Roles/");
}());