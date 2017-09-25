(function () {
    "use strict";

    angular
        .module("ToDoList")
        .controller("listController", listController);

    function listController() {
        var vm = this;
        vm.name = "Wendy";
    }

})();