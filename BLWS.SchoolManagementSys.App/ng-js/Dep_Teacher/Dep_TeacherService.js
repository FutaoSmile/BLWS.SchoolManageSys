(function (app) {
    var Dep_TeacherService = function ($http, Dep_TeacherApiUrl) {
        //获取所有用户
        var getAll = function () {
            return $http.get(Dep_TeacherApiUrl + "getDep_Teacher");
        };
        //通过Dep_TeacherID查询一个用户
        var getByFlowID = function (Dep_TeacherID) {
            return $http.get(Dep_TeacherApiUrl + "getDep_Teacher/" + Dep_TeacherID);
        };
        //更新用户信息
        var update = function (Dep_Teacher) {
            return $http.post(Dep_TeacherApiUrl + "UpdateDep_Teacher/" + Dep_Teacher.FlowTypeID, Dep_Teacher);
        };
        //创建用户
        var create = function (User,id) {
            return $http.post(Dep_TeacherApiUrl + "PostDep_Teacher/" + id,User);
        };
        //删除用户
        var destroy = function (Dep_Teacher) {
            return $http.post(Dep_TeacherApiUrl + "DeleteDep_Teacher/" + Dep_Teacher.Dep_TeacherID);
        };
        return {
            getAll: getAll,
            getByFlowID: getByFlowID,
            update: update,
            createOne: create,
            delete: destroy
        };
    };
    app.factory("Dep_TeacherService", Dep_TeacherService);
}(angular.module("Dep_Teacher")));