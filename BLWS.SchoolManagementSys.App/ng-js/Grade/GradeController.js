﻿(function (app) {
    var GradeController = function ($scope, $routeParams, GradeService) {
        //获取当前用户信息
        GradeService.getByClassID($.cookie('classID')).then(function (result) {
            $scope.ClassInfo = result.data;
        });

        $scope.Details = function (data) {
            GradeService.getByClassID(data).then(function (result) {
                $scope.ResultDetails = result.data;
            });
            angular.element("#details").modal({
                show: true
            })

        };

        //获取所有用户
        GradeService.getAll().then(function (result) { $scope.AllClasses = result.data; });
      
        //新增学校初始化一个用户对象
        $scope.create = function () {
            //生成Guid
            var guid = "";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            $scope.createClass = {
                Class: {
                    ClassID: guid,
                    ClassName: "",
                    DepID: ""
                }

            };
            angular.element("#create").modal({
                show: true
            })

        };
        //新增保存
        $scope.save = function () {
            GradeService.createOne($scope.createClass.Class).then(function () {
                var conf = layer.confirm('添加成功', {
                    btn: ['关闭'] //可以无限个按钮
                    , btn1: function () {
                        window.location.reload();
                    }
                });

            });
        };
        //编辑

        $scope.Edit = function (data) {
            GradeService.getByClassID(data).then(function (result) {
                $scope.editClass = result.data;
                angular.element("#edit").modal({
                    show: true
                })

            })
        }
        $scope.editsave = function () {
            GradeService.update($scope.editClass).then(function () {
                var conf = layer.confirm('修改成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };

        //删除
        $scope.Delete_btn = function (data) {
            GradeService.getByClassID(data).then(function (result) {
                $scope.deleteClass = result.data;
                angular.element("#delete").modal({
                    show: true
                })
            })
        };
        //确认删除
        $scope.delete_btn = function () {
            angular.element("#delete").modal('hide');
            GradeService.delete($scope.deleteClass).then(function () {
                var conf = layer.confirm('删除成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            }).catch(function (xhr) {
                layer.msg(xhr.status + ",删除失败");
            });
        };

    };

    app.controller("GradeController", GradeController);
}(angular.module("Grade")));