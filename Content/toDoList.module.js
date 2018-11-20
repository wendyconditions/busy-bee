(function () {
    angular
        .module("ToDoList", ['ui.router', 'ngAnimate', 'ngTouch', 'ui.bootstrap']);
        
})();


angular.module("ToDoList").config(["$locationProvider", function ($locationProvider) {
    $locationProvider.hashPrefix(''); // by default '!'
   // $locationProvider.html5Mode(true);
}]);