"use strict";

var myTunes = angular.module('myTunes', ['ui.router', 'LocalStorageModule']);
// servicios router, http provider

toastr.options.positionClass = "toast-bottom-right";


myTunes.config([
    '$stateProvider', '$urlRouterProvider', '$httpProvider', 
function ($stateProvider, $urlRouterProvider, $httpProvider) {

    /////////////////////////////
    // Redirects and Otherwise //
    /////////////////////////////

    // Use $urlRouterProvider to configure any redirects (when) and invalid urls (otherwise).
    $urlRouterProvider
        .when('/h?', '/home')
        .otherwise('/');

    // The `when` method says if the url is ever the 1st param, then redirect to the 2nd param
    // Here we are just setting up some convenience urls.
    //.when('/home', '/home')
    //.when('/user/:id', '/contacts/:id')

    // If the url is ever invalid, e.g. '/asdf', then redirect to '/' aka the home state
    //.otherwise('/');


    //////////////////////////
    // State Configurations //
    //////////////////////////

    // Use $stateProvider to configure your states.
    $stateProvider
        //////////
        // login //
        //////////
        .state("login", {

            // Use a url of "/" to set a states as the "index".
            url: "/",
            templateUrl: '/Views/login.html'
        })
        .state("home", {
            url: "/home",
            templateUrl: '/Views/home.html'
        });

    $httpProvider.interceptors.push('oAuthInterceptor');
}
]);

//myTunes.config(function ($routeProvider, $httpProvider) {
//    $routeProvider.when('/home',
//    {
//        templateUrl: 'Index.html',
//        controller: 'HomeController'
//    });

//    $routeProvider.when('/login',
//    {
//        templateUrl: 'Login.html',
//        controller: 'LoginController'
//    });
//    //Ejemplo playlist
//    $routeProvider.when('/PlayList',
//    {
//        templateUrl: 'Views/PlayList.html',
//        controller: 'playListController'
//    });

//    $routeProvider.otherwise({
//        redirectTo: '/home'
//    });

//});

myTunes.run([
    '$rootScope', '$state', '$stateParams', 'authStorage', function ($rootScope, $state, $stateParams, authStorage) {

        $rootScope.getInitialUrl = function () {
            return $rootScope.initialUrl;
        };
        $rootScope.setInitialUrl = function (url) {
            $rootScope.initialUrl = url;
        };

        $rootScope.currentUser = null;
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

        $rootScope.appName = 'MyTunes';
        //$rootScope.$on('$stateChangeStart',
        //    function (event, toState, toParams, fromState, fromParams) {
        //        if (!authStorage.isAuthenticated()) { //no esta autenticado
        //            event.preventDefault();
        //            $state.go('login');

        //        } else {
        //            event.preventDefault();
        //            var authData = authStorage.getToken();
        //            $rootScope.currentUser = authData.userName;
        //            $state.go('home');
        //        }
        //    });
    }
]);