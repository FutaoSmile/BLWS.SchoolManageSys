(function (app) {
    var FlowService = function ($http, FlowApiUrl) {
        //获取所有用户
        var getAll = function () {
            return $http.get(FlowApiUrl + "getApprovalFlow_FlowType");
        };
        //通过ApprovalFlow_FlowTypeID查询一个用户
        var getByFlowID = function (ApprovalFlow_FlowTypeID) {
            return $http.get(FlowApiUrl + "getApprovalFlow_FlowType/" + ApprovalFlow_FlowTypeID);
        };
        //更新用户信息
        var update = function (ApprovalFlow_FlowType) {
            return $http.post(FlowApiUrl + "UpdateApprovalFlow_FlowType/" + ApprovalFlow_FlowType.FlowTypeID, ApprovalFlow_FlowType);
        };
        //创建用户
        var create = function (ApprovalFlow_FlowType) {
            return $http.post(FlowApiUrl + "AddApprovalFlow_FlowType", ApprovalFlow_FlowType);
        };
        //删除用户
        var destroy = function (ApprovalFlow_FlowType) {
            return $http.post(FlowApiUrl + "DeleteApprovalFlow_FlowType/" + ApprovalFlow_FlowType.ApprovalFlow_FlowTypeID);
        };
        return {
            getAll: getAll,
            getByFlowID: getByFlowID,
            update: update,
            createOne: create,
            delete: destroy
        };
    };
    app.factory("FlowService", FlowService);
}(angular.module("Flow")));