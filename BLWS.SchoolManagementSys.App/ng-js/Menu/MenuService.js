(function (app) {
    var MenuService = function ($http, MenuApiUrl) {
        //获取所有用户
        var getAll = function () {
            return $http.get(MenuApiUrl + "getMenu");
        };
        //通过MenuID查询一个用户
        var getByMenuID = function (MenuID) {
            return $http.get(MenuApiUrl + "getMenu/" + MenuID);
        };
        //更新用户信息
        var update = function (Menu) {
            return $http.post(MenuApiUrl + "UpdateMenu/" + Menu.MenuID, Menu);
        };
        //创建用户
        var create = function (Menu) {
            return $http.post(MenuApiUrl + "AddMenu", Menu);
        };
        //删除用户
        var destroy = function (Menu) {
            return $http.post(MenuApiUrl + "DeleteMenu/" + Menu.MenuID);
        };
        return {
            getAll: getAll,
            getByMenuID: getByMenuID,
            update: update,
            createOne: create,
            delete: destroy
        };
    };
    app.factory("MenuService", MenuService);
}(angular.module("Menu")));