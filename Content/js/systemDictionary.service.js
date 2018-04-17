(function () {
    "use strict";

    angular
        .module("ToDoList")
        .factory("systemDictionaryService", systemDictionaryService);

    systemDictionaryService.$inject = ["$http", "$q"];

    function systemDictionaryService($http, $q) {
        var service = {
            loadUserLists: _getLists
            , createListType: _createListType
        };

        return service;

        ////////////

        function _getLists() {
            var settings = {
                method: "GET"
                , url: "/api/systemdictionary"
            };
            return $http(settings)
                .then(null, _getListError);
        }

        function _getListError(error) {
            return $q.reject(error.data.message);
        }

        function _createListType(item) {
            var settings = {
                method: "POST"
                , url: "/api/systemdictionary/"
                , data: item
            };
            return $http(settings)
                .then(null, _postItemError)
        }

        function _postItemError(error) {
            return $q.reject(error);
        }

        function _deleteSoftTask(ids) {
            var settings = {
                method: "POST"
                , url: "/api/lists/soft"
                , data: ids
            };
            return $http(settings)
                .then(null, _deleteSoftTaskError);
        }

        function _deleteSoftTaskError(error) {
            return $q.reject(error);
        }

        function _putTask(updatedItem) {
            var settings = {
                method: "PUT"
                , url: "/api/lists/" + updatedItem.id
                , data: updatedItem
            };
            return $http(settings)
                .then(null, _putTaskError);
        }

        function _putTaskError(error) {
            return $q.reject(error.data.message);
        }

        function _deleteHardTask(ids) {
            var settings = {
                method: "POST"
                , url: "/api/lists/hard"
                , data: ids
            };
            return $http(settings)
                .then(null, _deleteHardTaskError);
        }

        function _deleteHardTaskError(error) {
            $q.reject(error);
        }
    }
})();