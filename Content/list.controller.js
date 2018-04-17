(function () {
    "use strict";

    angular
        .module("ToDoList")
        .controller("listController", listController);

    listController.$inject = ["listService", "$uibModal", "$scope", "systemDictionaryService"];

    function listController(listService, $uibModal, $scope, systemDictionaryService) {
        var vm = this;
        vm.$onInit = _init;
        vm.data = {};
        vm.name = "Wendy"; // Hard coding until I generate users
        vm.btnAdd = _btnAdd;
        vm.btnComplete = _btnComplete;
        vm.btnUpdate = _btnUpdate;
        vm.btnDelete = _btnDelete;
        vm.createNewList = _createNewList;
        vm.expandList = _expandList;

        /////////////

        function _expandList(list) {
            list.toggle = !list.toggle;
        }

        function _createNewList() {
            $uibModal.open({
                templateUrl: 'html/newListModal.html',
                size: 'md',
                controller: createListController,
                scope: $scope
            });

            createListController.$inject = ['$scope', '$uibModalInstance'];

            function createListController($scope, $uibModalInstance) {
                $scope.newlist = {};
                $scope.btnCreate = function () {
                    console.log($scope.newlist);
                    systemDictionaryService.createListType($scope.newlist).then(_loadSuccess);
                    $uibModalInstance.close();
                }

                $scope.btnCancel = function () {
                    $uibModalInstance.close();
                }

                function _loadSuccess(response) {
                    console.log(response);
                    //set item to ListTypeID of toddolist model
                }
            }
        }

        function _init() {
            // get lists - maybe just get users categories and the lists
            systemDictionaryService.loadUserLists().then(_loadUsersLists);
            listService.loadList().then(_loadSuccess);
        }

        function _loadUsersLists(r) {
            vm.lists = r.data.items;

            console.log(vm.lists);
        }

        function _loadSuccess(response) {
            console.log(response);
        }

        function _btnAdd(data) {
            if (vm.data.id) {
                listService.updateTask(data).then(_taskSuccess, null);
            } else {
                listService.createItem(vm.data).then(_taskSuccess, null);
            }
        }

        function _taskSuccess() {
            _init();
            vm.data = {};
        }

        function _btnComplete(data) {
            var completedItems = { ids: [] };

            for (var i = 0; i < data.length; i++) {
                if (data[i].isComplete) {
                    completedItems.ids.push(data[i].id);  
                }
            }
            listService.completedTask(completedItems).then(_completedSuccess, _completedError);
        }

        function _completedSuccess() {
            _init();
        }

        function _completedError() {
            // Currently in progress
            console.log("need to handle this error");
        }

        function _btnUpdate(item) {
            vm.data = {
                toDoItem: item.toDoItem
                , priority: item.priority
                , id: item.id
            };
            return vm.data;
        }

        function _btnDelete(data) {
            var deleteItems = { ids: [] };

            for (var i = 0; i < data.length; i++) {
                if (data[i].isDelete) {
                    deleteItems.ids.push(data[i].id);
                }
            }
            listService.deleteTask(deleteItems).then(_deleteSuccess, null);
        }

        function _deleteSuccess() {
            _init();
        }
    }
})();