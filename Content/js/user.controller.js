(function () {
    "use strict";

    angular
        .module("ToDoList")
        .controller("userController", userController);

    userController.$inject = [];

    function userController() {
        var uc = this;
        uc.$onInit = _init;
        uc.data = {};
        uc.btnLogin = _login;

        /////////////

        function _init() {
            console.log('user controller registered');
        }

        function _login() {
            // send auth token use user service
            console.log(uc.data.password, uc.data.email);
        }
    }
})();