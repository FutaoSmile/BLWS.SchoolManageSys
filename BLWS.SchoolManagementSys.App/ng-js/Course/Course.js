(function () {
    var app = angular.module("Course", ["ngRoute"]);
    //var config = function ($routeProvider) {
    //    $routeProvider
    //        .when("/Role", { templateUrl: "/Views/sysManage/RoleManage.cshtml" })
    //        .otherwise({
    //            redirectTo: "/Role"
    //        });
    //};
    //app.config(config);
    app.constant("CourseApiUrl", "http://localhost:57424/api/Courses/");
}());