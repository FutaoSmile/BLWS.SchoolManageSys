(function (app) {
    var UserService = function ($http, UserApiUrl) {
        //获取所有用户
        var getAll = function () {
            return $http.get(UserApiUrl + "getUser");
        };
        //通过UserID查询一个用户
        var getByUserID = function (UserID) {
            return $http.get(UserApiUrl + "getUser/" + UserID);
        };
        //更新用户信息
        var update = function (User) {
            return $http.post(UserApiUrl + "UpdateUser/" + User.UserID, User);
        };
        //创建用户
        var create = function (User) {
            return $http.post(UserApiUrl + "AddUser", User);
        };
        //删除用户
        var destroy = function (User) {
            return $http.post(UserApiUrl + "DeleteUser/" + User.UserID);
        };
        //通过用户ID获取角色信息
        var ID_Role = function (UserID) {
            return $http.get(UserApiUrl + "GetUserRole/" + UserID);
        }
        return {
            getAll: getAll,
            getByUserID: getByUserID,
            update: update,
            createOne: create,
            delete: destroy,
            getRoleByID:ID_Role
        };
    };
    app.factory("UserService", UserService);
}(angular.module("User")));