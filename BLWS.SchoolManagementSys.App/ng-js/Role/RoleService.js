(function (app) {
    var RoleService = function ($http, RoleApiUrl) {
        //获取所有角色
        var getAll = function () {
            return $http.get(RoleApiUrl + "getRole");
        };
        //通过RoleID查询一个角色
        var getByRoleID = function (RoleID) {
            return $http.get(RoleApiUrl + "getRole/" + RoleID);
        };
        //更新角色信息
        var update = function (Role) {
            return $http.post(RoleApiUrl + "PutRole/" + Role.RoleID, Role);
        };
        //创建角色
        var create = function (Role) {
            return $http.post(RoleApiUrl + "PostRole", Role);
        };
        //删除角色
        var destroy = function (Role) {
            return $http.post(RoleApiUrl + "DeleteRole/" + Role.RoleID);
        };
        //通过用户ID获取角色信息
        var ID_Menu = function (RoleID) {
            return $http.get(RoleApiUrl + "GetRoleMenu/" + RoleID);
        }
        var getMenus = function (RoleID) {
            return $http.get(RoleApiUrl + "getMenusByRole?roleID="+RoleID);
        }
        return {
            getAll: getAll,
            getByRoleID: getByRoleID,
            update: update,
            createOne: create,
            delete: destroy,
            getByMenuID: ID_Menu,
            getMenus:getMenus
        };
    };
    app.factory("RoleService", RoleService);
}(angular.module("Role")));