(function (app) {
    var DepartmentService = function ($http, DepartmentApiUrl) {
        //获取所有
        var getAll = function () {
            return $http.get(DepartmentApiUrl + "getDepartment");
        };
        //通过DepID查询一个学院
        var getByDepID = function (DepID) {
            return $http.get(DepartmentApiUrl + "getDepartment/" + DepID);
        };
        //更新学院信息
        var update = function (Department) {
            return $http.post(DepartmentApiUrl + "UpdateDepartment/" + Department.DepID, Department);
        };
        //创建学院
        var create = function (Department) {
            return $http.post(DepartmentApiUrl + "AddDepartment", Department);
        };
        //删除学院
        var destroy = function (Department) {
            return $http.post(DepartmentApiUrl + "DeleteDepartment/" + Department.DepID);
        };
        return {
            getAll: getAll,
            getByDepID: getByDepID,
            update: update,
            createOne: create,
            delete: destroy
        };
    };
    app.factory("DepartmentService", DepartmentService);
}(angular.module("Department")));