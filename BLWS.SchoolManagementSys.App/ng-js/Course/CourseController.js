(function (app) {
    var CourseController = function ($scope, $http, $routeParams, CourseService) {
        //学院教师列表
        CourseService.getAllTeacher(angular.element("#CutrrentUser").text()).then(function (result) {
            $scope.TeacherList = result.data;
        })
        //当前学院
        CourseService.GetDepByManager(angular.element("#CutrrentUser").text()).then(function (result) {
            $scope.CurrentDep = result.data;
        })
        //详情
        $scope.Details = function (data) {
            CourseService.getByCourseID(data).then(function (result) {
                $scope.ResultDetails = result.data;
            });
            angular.element("#details").modal({
                show: true
            })

        };

        //获取所有课程信息
        CourseService.getAll(angular.element("#CutrrentUser").text()).then(function (result) { $scope.AllCourses = result.data; });


        //删除
        $scope.Delete_btn = function (data) {
            CourseService.getByCourseID(data).then(function (result) {
                $scope.deleteCourse = result.data;
                angular.element("#delete").modal({
                    show: true
                })
            })
        };
        //确认删除
        $scope.delete_btn = function () {
            CourseService.delete($scope.deleteCourse).then(function () {
                var conf = layer.confirm('删除成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };

        //新增角色初始化一个课程对象
        $scope.create = function () {
            //生成Guid
            var guid = "";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            $scope.createCourse = {
                Course: {
                    CourseID: guid,
                    CourseName: "",
                    Credit: "",
                    Description: "",
                    DepID: "",
                    DepName: "",
                    TeacherID: "",
                    TeacherName: ""
                }
            };
            angular.element("#create").modal('show');
        };
        //新增保存
        $scope.save = function () {
            $scope.createCourse.Course.DepID = $scope.CurrentDep.DepID;
            $scope.createCourse.Course.DepName = $scope.CurrentDep.DepName;
            $scope.createCourse.Course.TeacherName = $scope.ResultTeacher.UserName;
            $scope.createCourse.Course.TeacherID = $scope.ResultTeacher.UserID;
            CourseService.createOne($scope.createCourse.Course).then(function () {
                var conf = layer.confirm('添加成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };
        //修改
        //data为课程的编号ID
        $scope.Edit = function (data) {
            //通过课程ID获取课程对象
            CourseService.getByCourseID(data).then(function (result) {
                $scope.editCourse = result.data;
                //下拉列表默认值设定
                //先通过课程里面的教师ID获取教师对象
                CourseService.GetTeacherByTeacherID(result.data.TeacherID).then(function (result) {
                    //$scope.TeacherList为所有教师的列表
                    for (i = 0; i < $scope.TeacherList.length; i++) {
                        //如果当前课程教师的ID与当前遍历到的教师的ID相等的话就把当前遍历到的这个教师的对象给到 ng-model="editCourse.TeacherName"
                        if (result.data.UserID == $scope.TeacherList[i].UserID) {
                            $scope.Teacher = $scope.TeacherList[i];
                        }
                    }
                });
                angular.element("#edit").modal({
                    show: true
                })
            })
        }
        //修改保存
        $scope.editSave = function () {
            $scope.editCourse.TeacherID = $scope.Teacher.UserID;
            $scope.editCourse.TeacherName = $scope.Teacher.UserName;
            CourseService.update($scope.editCourse).then(function () {
                var conf = layer.confirm('修改成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };
        //获取所有学院信息
        $http.get("http://localhost:57424/api/Departments/getDepartment").then(function (result) { $scope.DepartmentsList = result.data; });
        //获取所有教师信息
        //$http.get("http://localhost:57424/api/users/getteacher").then(function (result) { $scope.TeacherList = result.data; });

    };
    app.controller("CourseController", CourseController);
}(angular.module("Course")));