(function (app) {
    var FlowController = function ($scope,$http, $routeParams, FlowService) {

        FlowService.getAll().then(function (result) { $scope.AllFlow = result.data })

        //新增流程
        $scope.create = function () {
            //生成Guid
            var guid = "";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            $scope.createFlow = {
                Flow: {
                    FlowTypeID: guid,
                    FlowTypeName: "",
                    FlowTypePriority: 0
                }

            };
            angular.element("#create").modal({
                show: true
            })
        };
        //新增保存
        $scope.save = function () {
            FlowService.createOne($scope.createFlow.Flow).then(function () {
                var conf = layer.confirm('添加成功', {
                    btn: ['关闭'] //可以无限个按钮
              , btn1: function () {
                  window.location.reload();
              }
                });
            })
        };
        //修改
        $scope.Edit = function (id) {
            FlowService.getByFlowID(id).then(function (result) {
                $scope.editFlow = result.data;
              
            });
            angular.element("#edit").modal('show');
        }
        //修改保存
        $scope.editSave = function () {
            FlowService.update($scope.editFlow).then(function () {
                var conf = layer.confirm('添加成功', {
                    btn: ['关闭'] //可以无限个按钮
                           , btn1: function () {
                               window.location.reload();
                           }
                });
            })
        }
        //详情
        $scope.Details = function (id) {
            $scope.CurrentFlowID = id;
            //获取该流程的所有节点
            $http.get("http://localhost:57424/api/ApprovalFlow_FlowSet/GetApprovalFlow_FlowSetByFlowID/" + $scope.CurrentFlowID).then(function (result) {
                $scope.All = result.data;
            })
            angular.element("#details").modal('show');

        }
        //新增节点
        $scope.NewItem = function () {
            //生成Guid
            var guid = "";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            };
            $scope.AllItem = $http.get("http://localhost:57424/api/ApprovalFlow_FlowSet/GetApprovalFlow_FlowSetByFlowID/" + $scope.CurrentFlowID).then(function (result) {
                $scope.ItemList = result.data;
            })
            $scope.FlowSet = {
                Item: {
                    StepID: guid,
                    FlowTypeID: $scope.CurrentFlowID,
                    StepName: "",
                    StepNum: 1,
                    //默认第一个节点ID都为0
                    PreviousStepID: "00000000-0000-0000-0000-000000000000"
                }
            };
            angular.element("#newitem").modal('show');
        };
        //保存新增的节点
        $scope.NewItemSave = function () {
            $scope.FlowSet.PreviousStepID = $scope.Item.StepID;
            $http.post("http://localhost:57424/api/ApprovalFlow_FlowSet/PostApprovalFlow_FlowSet", $scope.FlowSet.Item).then(function () {
                alert("chenggong");
            })
        }
    };
    app.controller("FlowController", FlowController);
}(angular.module("Flow")))