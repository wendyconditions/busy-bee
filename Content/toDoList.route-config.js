(function () {
    "use strict";

    var app = angular.module('ToDoList');

    app.config(_configureStates);

    _configureStates.$inject = ['$stateProvider', '$urlRouterProvider'];

    function _configureStates($stateProvider, $urlRouterProvider) {

        // For any unmatched url, redirect to /tasks
        $urlRouterProvider.otherwise("/login");

        // Registering states
        $stateProvider
            .state({
                name: 'login',
                component: 'login',
                url: '/login'
            })
            .state({
                name: 'home',
                component: 'home',
                url: '/home'
            })
    }

    // Definining state components and directing to templates
    app.component('login', {
        templateUrl: '/Content/html/login.html'
        , controller: 'userController as uc'
    });

    app.component('home', {
        templateUrl: '/Content/html/home.html'
        , controller: 'listController as vm'
    });
})();
