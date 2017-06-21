(function (app) {
    var DepartmentController = function ($scope,$http, $routeParams, DepartmentService) {
        //获取当前学院信息
        DepartmentService.getByDepID($.cookie('DepID')).then(function (result) {
            $scope.DepartmentInfo = result.data;
        });

        $scope.Details = function (data) {
            DepartmentService.getByDepID(data).then(function (result) {
                $scope.ResultDetails = result.data;
            });
            angular.element("#details").modal({
                show: true
            })

        };

        //获取所有学院
        DepartmentService.getAll().then(function (result) { $scope.AllDepartments = result.data; });
        //获取所有院长
        $http.get("http://localhost:57424/api/Departments/All_Dep_Manager").then(function (result) {
            $scope.All_Dep_Manager = result.data;
        })


        //新增学校初始化一个学院对象
        $scope.create = function () {
            //生成Guid
            var guid = "";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            $scope.createDepartment = {
                Department: {
                    DepID: guid,
                    DepName: "",
                    Dep_ManagerID: "",
                    Dep_Manage_Name:""
                }

            };
            angular.element("#create").modal({
                show: true
            })

        };
        //新增保存
        $scope.save = function () {
            $scope.createDepartment.Department.Dep_ManagerID = $scope.Manager.UserID;
            $scope.createDepartment.Department.Dep_Manage_Name = $scope.Manager.UserName;
            DepartmentService.createOne($scope.createDepartment.Department).then(function () {
                var conf = layer.confirm('添加成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };
        //修改

        $scope.Edit = function (data) {
            DepartmentService.getByDepID(data).then(function (result) {
                $scope.editDepartment = result.data;
                angular.element("#edit").modal({
                    show: true
                })

            })
        }
        $scope.editsave = function () {
            $scope.editDepartment.Dep_ManagerID = $scope.Current_Manager.UserID;
            $scope.editDepartment.Dep_Manage_Name = $scope.Current_Manager.UserName;
            DepartmentService.update($scope.editDepartment).then(function () {
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
            DepartmentService.getByDepID(data).then(function (result) {
                $scope.deleteDepartment = result.data;
                angular.element("#delete").modal({
                    show: true
                })
            })
        };
        //确认删除
        $scope.delete_btn = function () {
            angular.element("#delete").modal('hide');
            DepartmentService.delete($scope.deleteDepartment).then(function () {
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

    app.controller("DepartmentController", DepartmentController);
}(angular.module("Department")))

