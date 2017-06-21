(function (app) {
    var GradeService = function ($http, GradeApiUrl) {
        //获取所有
        var getAll = function () {
            return $http.get(GradeApiUrl + "getClasses");
        };
        //通过DepID查询一个学院
        var getByClassID = function (ClassID) {
            return $http.get(GradeApiUrl + "getClasses/" + ClassID);
        };
        //更新学院信息
        var update = function (Class) {
            return $http.post(GradeApiUrl + "UpdateClasses/" + Class.ClassID, Class);
        };
        //创建学院
        var create = function (Class) {
            return $http.post(GradeApiUrl + "AddClasses", Class);
        };
        //删除学院
        var destroy = function (Class) {
            return $http.post(GradeApiUrl + "DeleteClasses/" + Class.ClassID);
        };
        return {
            getAll: getAll,
            getByClassID: getByClassID,
            update: update,
            createOne: create,
            delete: destroy
        };
    };
    app.factory("GradeService", GradeService);
}(angular.module("Grade")));