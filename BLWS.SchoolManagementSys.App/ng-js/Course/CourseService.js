(function (app) {
    var CourseService = function ($http, CourseApiUrl) {
        //获取所有课程
        var getAll = function (id) {
            return $http.get(CourseApiUrl + "GetCourseByDepManagerID/"+id);
        };
        //获取教师列表
        var getAllTeacher = function (id) {
            return $http.get(CourseApiUrl + "GetTeacherByDepManagerID/" + id);
        }
        //通过UserID查询一个课程
        var getByCourseID = function (CourseID) {
            return $http.get(CourseApiUrl + "getCourse/" + CourseID);
        };
        //更新课程信息
        var update = function (Course) {
            return $http.post(CourseApiUrl + "PutCourse/" + Course.CourseID, Course);
        };
        //创建课程
        var create = function (Course) {
            return $http.post(CourseApiUrl + "PostCourse", Course);
        };
        //删除课程
        var destroy = function (Course) {
            return $http.post(CourseApiUrl + "DeleteCourse/" + Course.CourseID);
        };
        //通过课程ID获取学院信息
        var ID_Course = function (CourseID) {
            return $http.get(CourseApiUrl + "GetCourseDepartment/" + CourseID);
        };
        var GetDepByManager = function (id) {
            return $http.get("http://localhost:57424/api/Departments/GetDepByManager/" + id)
        };
        //通过教师id获取教师信息
        var GetTeacherByTeacherID = function (id) {
            return $http.get("http://localhost:57424/api/users/getuser/" + id)
        };
        return {
            getAll: getAll,
            getByCourseID: getByCourseID,
            update: update,
            createOne: create,
            delete: destroy,
            getCourseByID: ID_Course,
            getAllTeacher: getAllTeacher,
            GetDepByManager: GetDepByManager,
            GetTeacherByTeacherID: GetTeacherByTeacherID
        };
    };
    app.factory("CourseService", CourseService);
}(angular.module("Course")));