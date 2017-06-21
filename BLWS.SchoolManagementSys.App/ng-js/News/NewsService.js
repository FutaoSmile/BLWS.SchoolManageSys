(function (app) {
    var NewsService = function ($http, News_newsApiUrl) {
        //获取所有新闻
        var getAll = function () {
            return $http.get(News_newsApiUrl + "getNews_news");
        };
        //通过News_newsID查询一个新闻
        var getByNews_newsID = function (News_newsID) {
            return $http.get(News_newsApiUrl + "getNews_news/" + News_newsID);
        };
        //更新新闻信息
        var update = function (News_news) {
            return $http.post(News_newsApiUrl + "PutNews_news/" + News_news.NewsID, News_news);
        };
        //创建新闻
        var create = function (News_news) {
            return $http.post(News_newsApiUrl + "AddNews_news", News_news);
        };
        //删除新闻
        var destroy = function (News_news) {
            return $http.post(News_newsApiUrl + "DeleteNews_news/" + News_news.News_newsID);
        };
        return {
            getAll: getAll,
            getByNewsID: getByNews_newsID,
            update: update,
            createOne: create,
            delete: destroy
        };
    };
    app.factory("NewsService", NewsService);
}(angular.module("News")));