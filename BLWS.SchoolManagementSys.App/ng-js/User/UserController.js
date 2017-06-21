(function (app) {
    var UserController = function ($scope,$http,$routeParams, UserService) {
        //获取当前用户信息
        UserService.getByUserID($.cookie('userID')).then(function (result) {
            $scope.UserInfo = result.data;
        });

        $scope.Details = function (data) {
            UserService.getByUserID(data).then(function (result) {
                $scope.ResultDetails = result.data;
            });
            angular.element("#details").modal({
                show:true
            })
            
        };

        //获取所有用户
        UserService.getAll().then(function (result) { $scope.AllUsers = result.data; });

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
            $scope.createUser = {   
                User: {
                    UserID: guid,
                    UserName: "",
                    Password: "",
                    NamePinYin: "",
                    Tel: "",
                    Email: "",
                    Birthday: "",
                    Sex: "",
                    CreateTime: new Date(),
                    UpdateTime: new Date()
                }

            };
            angular.element("#create").modal({
                show:true
            })

        };
        //新增保存
        $scope.save = function () {
            UserService.createOne($scope.createUser.User).then(function () {
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
            UserService.getByUserID(data).then(function (result) {
                $scope.editUser = result.data;
                angular.element("#edit").modal({
                    show:true
                })
            })
        }
        //修改保存
        $scope.editsave = function () {
            UserService.update($scope.editUser).then(function () {
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
            UserService.getByUserID(data).then(function (result) {
                $scope.deleteUser = result.data;
                angular.element("#delete").modal({
                    show: true
                })
            })
        };
        //确认删除
        $scope.delete_btn = function () {
            UserService.delete($scope.deleteUser).then(function () {
                var conf = layer.confirm('删除成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };
        //获取用户的角色
        $scope.UserRole = function (data) {
            $scope.CurrentUser = data;
            UserService.getRoleByID(data).then(function (result) {
                $scope.ResultRole = result.data;
                angular.element("#RoleInfo").modal({
                    show:true
                })
            }).catch(function onError(response) {
                $scope.ResultRole = "无角色信息";
                angular.element("#RoleInfo").modal({
                    show: true
                })
            })
        };
        //获取所有角色信息
        $http.get("http://localhost:57424/api/roles/getrole").then(function (result) { $scope.RoleList = result.data; });
        //编辑用户角色信息
        $scope.EditRole = function () {
            angular.element("#RoleInfo").modal('hide');
            angular.element("#EditRole").modal('show');
        };
        //确定修改用户信息
        $scope.EditConfirm = function () {
            angular.element("#EditRole").modal('hide');
            $http.get("http://localhost:57424/api/User_Role/EditUserRole?UserID=" + $scope.CurrentUser + "&RoleID=" + $scope.ResultRole.RoleID).then(function () {
                layer.msg("修改成功");
            }).catch(function (xhr) {
                layer.msg(xhr.status+"，修改失败");
            })
        }
    };
    app.controller("UserController", UserController);
}(angular.module("User")))