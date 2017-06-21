(function (app) {
    var ScoreService = function ($http, ScoreApiUrl) {
        //获取所有用户
        var getAll = function () {
            return $http.get(ScoreApiUrl + "getScore");
        };
        //通过MenuID查询一个用户
        var getByScoreID = function (ScoreID) {
            return $http.get(ScoreApiUrl + "getScore/" + ScoreID);
        };
        //更新用户信息
        var update = function (Score) {
            return $http.post(ScoreApiUrl + "PutScore/" + Score.ScoreID, Score);
        };
        //创建用户
        var create = function (Score) {
            return $http.post(ScoreApiUrl + "PostScore", Score);
        };
        //删除用户
        var destroy = function (Score) {
            return $http.post(ScoreApiUrl + "DeleteScore/" + Score.ScoreID);
        };
        return {
            getAll: getAll,
            getByScoreID: getByScoreID,
            update: update,
            createOne: create,
            delete: destroy
        };
    };
    app.factory("ScoreService", ScoreService);
}(angular.module("Score")));