(function () {
    'use strict';

    angular
        .module('app', ['ngCookies', 'ui.router'])
        .config(config)
        .run(run);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('home', {
                url: '/home',
                controller: 'HomeController',
                templateUrl: 'WebAppJS/home/home.view.html',
                controllerAs: 'vm'
            })

            .state('login', {
                url: '/login',
                controller: 'LoginController',
                templateUrl: 'WebAppJS/login/login.view.html',
                controllerAs: 'vm'
            })

            .state('register', {
                url: '/register',
                controller: 'RegisterController',
                templateUrl: 'WebAppJS/register/register.view.html',
                controllerAs: 'vm'
            })

           // .otherwise({ redirectTo: '/login' });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];
    function run($rootScope, $location, $cookieStore, $http) {
        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in and trying to access a restricted page
            var restrictedPage = $.inArray($location.path(), ['/login', '/register']) === -1;
            var loggedIn = $rootScope.globals.currentUser;
            if (restrictedPage && !loggedIn) {
                $location.path('/login');
            }
        });
    }

})();