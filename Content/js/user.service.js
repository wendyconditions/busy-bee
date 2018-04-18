(function () {
    "use strict";

    angular
        .module("ToDoList")
        .factory("userService", userService);

    userService.$inject = ["$http", "$q"];

    function userService($http, $q) {
        var service = {
            authenticateUser: _authUser
        };

        return service;

        ////////////

        function _authUser() {
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

        
    }
})();