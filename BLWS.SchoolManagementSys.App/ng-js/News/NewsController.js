/// <reference path="../../Views/User/news.cshtml" />
/// <reference path="../../Views/User/news.cshtml" />
(function (app) {
    var NewsController = function ($scope, $routeParams, NewsService) {
        //获取所有新闻
        NewsService.getAll().then(function (result) {
            $scope.All_News = result.data;
            //将原本很长的时间表达式截断成只显示年月日
            for (i = 0; i < $scope.All_News.length; i++) {
                $scope.All_News[i].UploadTime = $scope.All_News[i].UploadTime.substring(0, 10);
            }

        });
        //编辑新闻
        $scope.Edit_News = function (news) {
            angular.element("#show_News").hide();
            angular.element("#details").hide();
            angular.element("#editor").show();
            $scope.CurrentNews = news;
            editor.txt.html($scope.CurrentNews.Content)
        }
        //返回展示页面
        $scope.Back = function () {
            angular.element("#editor").hide();
            angular.element("#details").hide();
            angular.element("#show_News").show();
        }
        //保存新闻
        $scope.Save_News = function () {
            $scope.CurrentNews.Content = editor.txt.html();
            NewsService.update($scope.CurrentNews).then(function (result) { layer.msg("保存成功！"); })
        };
        //新建新闻
        $scope.New_News = function () {
            //生成Guid
            var guid = "";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            $scope.CurrentNews = null;
            $scope.CurrentNews = {
                Title: "",
                NewsID: guid,
                Content: "",
                UploadTime: new Date(),
                UploadBy: angular.element("#UserName").text(),
                VisitCount: 0
            };
            angular.element("#show_News").hide();
            angular.element("#details").hide();
            angular.element("#editor").show();
        };
        //查看新闻详情
        $scope.Details = function (news) {
            $scope.Detailsnews = news;
            angular.element("#show_News").hide();
            angular.element("#editor").hide();
            angular.element("#details").show();
        };

        
        
        $scope.Haha = function (news) {
            $scope.detailsNews = news;
            angular.element("#index").hide();
            angular.element("#newsPage").show();
        };
        $scope.BackToIndex = function () {
            angular.element("#newsPage").hide();
            angular.element("#index").show();
        };
        
    };
    app.controller("NewsController", NewsController);
}(angular.module("News")))