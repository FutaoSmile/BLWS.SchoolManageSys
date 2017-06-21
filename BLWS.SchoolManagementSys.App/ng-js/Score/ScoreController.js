(function (app) {
    var ScoreController = function ($scope,$http, $routeParams, ScoreService) {
        //获取当前成绩信息
        ScoreService.getByScoreID($.cookie('scoreID')).then(function (result) {
            $scope.ScoreInfo = result.data;
        });
        $scope.Details = function (data) {
            ScoreService.getByScoreID(data).then(function (result) {
                $scope.ResultDetails = result.data;
            });
            angular.element("#details").modal({
                show: true
            })
        }
        //获取所有成绩信息
        ScoreService.getAll().then(function (result) { $scope.AllScores = result.data; });

        //获取该用户的信息
        $http.get("http://localhost:57424/api/users/getuser/" + angular.element("#id").text()).then(function (result) { $scope.user = result.data; });
        //获取所有课程信息
        $http.get("http://localhost:57424/api/Courses/getcourse").then(function (result) { $scope.CourseList = result.data; });
        //新增学生初始化一个用户对象
        $scope.create = function (ID) {
            //生成Guid
            var guid = "";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            $scope.createScore = {
                Score: {
                    ScoreID: guid,
                    StudentID:'',
                    CourseID: '',
                    TeacherID: '',
                    StudentName: '',
                    CourseName: '',
                    TeacherName:''                  
                }

            };
            //获取所有课程信息 
            $http.get("http://localhost:57424/api/Courses/getcourse/"+ID).then(function(result){$scope.Choose=result.data;});
            angular.element("#create").modal({
                show: true
            })

        };
        //新增保存
        $scope.save = function () {
            //$scope.createScore.Score.CourseName = $scope.CourseList.CourseName;
            $scope.kass.StudentID = angular.element("#id").text();
            $scope.kass.StudentName = $scope.user.UserName;
            ScoreService.createOne($scope.kass).then(function () {
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
            ScoreService.getByScoreID(data).then(function (result) {
                $scope.editScore = result.data;
                angular.element("#edit").modal({
                    show: true
                })

            })
        }
        $scope.editsave = function () {
            ScoreService.update($scope.editScore).then(function () {
                var conf = layer.confirm('修改成功', {
                    btn: ['关闭'] //可以无限个按钮
                , btn1: function () {
                    window.location.reload();
                }
                });

            });
        };
    }
    app.controller("ScoreController", ScoreController);
}(angular.module("Score")))