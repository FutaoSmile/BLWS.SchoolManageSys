(function (app) {
    var RoleController = function ($scope, $http, $routeParams, RoleService) {
        //获取当前角色信息
        RoleService.getByRoleID($.cookie('RoleID')).then(function (result) {
            $scope.RoleInfo = result.data;
        });

        $scope.Details = function (data) {
            RoleService.getByRoleID(data).then(function (result) {
                $scope.ResultDetails = result.data;
            });
            angular.element("#details").modal({
                show: true
            })

        };

        //获取所有角色
        RoleService.getAll().then(function (result) { $scope.AllRoles = result.data; });


        //删除
        $scope.Delete_btn = function (data) {
            RoleService.getByRoleID(data).then(function (result) {
                $scope.deleteRole = result.data;
                angular.element("#delete").modal({
                    show: true
                })
            })
        };
        //确认删除
        $scope.delete_btn = function () {
            RoleService.delete($scope.deleteRole).then(function () {
                var conf = layer.confirm('删除成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };
        //新增角色初始化一个角色对象
        $scope.create = function () {
            //生成Guid
            var guid = "";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            $scope.createRole = {
                Role: {
                    RoleID: guid,
                    RoleName: ""
                }

            };
            angular.element("#create").modal({
                show: true
            })

        };
        //新增保存
        $scope.save = function () {
            RoleService.createOne($scope.createRole.Role).then(function () {
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
            RoleService.getByRoleID(data).then(function (result) {
                $scope.editRole = result.data;
                angular.element("#edit").modal({
                    show: true
                })
            })
        }
        //修改保存
        $scope.editSave = function () {
            RoleService.update($scope.editRole).then(function () {
                var conf = layer.confirm('修改成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };
        //获取该角色拥有的菜单
        $scope.RoleMenu = function (data) {
            $scope.CurrentRole = data;
            RoleService.getMenus(data).then(function (result) {
                $scope.ResultMenu = result.data;
                angular.element("#MenuInfo").modal({
                    show: true
                })
            }).catch(function onError(response) {
                $scope.ResultMenu = "无菜单信息";
                angular.element("#MenuInfo").modal({
                    show: true
                })
            })
        };
        //获取所有菜单信息
        $http.get("http://localhost:57424/api/menus/getmenu").then(function (result) { $scope.MenuList = result.data; });
        //添加角色菜单信息
        $scope.EditMenu = function () {
            angular.element("#MenuInfo").modal('hide');
            angular.element("#EditMenu").modal('show');
        };
        //确定添加角色信息
        $scope.EditConfirm = function () {
            angular.element("#EditMenu").modal('hide');
            $http.get("http://localhost:57424/api/Role_Menu/EditRoleMenu?RoleID=" + $scope.CurrentRole + "&MenuID=" + $scope.ResultMenu.MenuID).then(function () {
                layer.msg("添加成功");
            }).catch(function (xhr) {
                layer.msg("添加失败，请勿重复添加");
            })
        }
        //删除菜单
        $scope.DeleteMenu = function (menu) {
            $scope.CurrentMenuID=menu.MenuID;
            angular.element("#MenuInfo").modal('hide');
            angular.element("#DeleteMenu").modal('show');
        };
        //确认删除菜单
        $scope.delete = function () {
            angular.element("#DeleteMenu").modal('hide');
            $http.get("http://localhost:57424/api/Role_Menu/DeleteRoleMenu?RoleID=" + $scope.CurrentRole + "&MenuID=" + $scope.CurrentMenuID).then(function () {
                var conf = layer.confirm('删除成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };
    };
    app.controller("RoleController", RoleController);
}(angular.module("Role")));