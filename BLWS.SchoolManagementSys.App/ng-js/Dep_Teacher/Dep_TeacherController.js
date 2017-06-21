(function (app) {
    var Dep_TeacherController = function ($scope, $http, $routeParams, Dep_TeacherService) {
        $scope.create = function () {
            //生成Guid
            var guid = "";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            $scope.CreateTacher = {
                teacher: {
                    UserID: guid,
                    UserName: "",
                    Password: "",
                    NamePinYin: "",
                    Tel: "",
                    Email: "",
                    CreateTime: new Date()
                }
            };
            angular.element("#create").modal('show');
        };
        //保存新教师
        $scope.save = function () {
           
            Dep_TeacherService.createOne($scope.CreateTacher.teacher, angular.element("#CurrentDepID").text()).then(function () {
                var conf = layer.confirm('添加成功', {
                    btn: ['关闭'] //可以无限个按钮
             , btn1: function () {
                 window.location.reload();
             }
                });
            })
        }
       
    };
    app.controller("Dep_TeacherController", Dep_TeacherController);
}(angular.module("Dep_Teacher")))