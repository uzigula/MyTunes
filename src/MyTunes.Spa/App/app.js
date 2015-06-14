"use strict";

var myTunes = angular.module('myTunes', ['ngRoute']);
// servicios router, http provider

toastr.options.positionClass = "toast-bottom-right";

myTunes.config(function ($routeProvider, $httpProvider) {
    $routeProvider.when('/home',
    {
        templateUrl: 'Index.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/landing',
    {
        templateUrl: 'Login.html',
        controller: 'LoginController'
    });
    //Ejemplo playlist
    $routeProvider.when('/PlayList',
    {
        templateUrl: 'Views/PlayList.html',
        controller: 'playListController'
    });

    // $httpProvider.interceptors.push('AuthInterceptor');
});

myTunes.run(function ($rootScope, $window) {

    $rootScope.getInitialUrl = function () {
        return $rootScope.initialUrl;
    };
    $rootScope.setInitialUrl = function (url) {
        $rootScope.initialUrl = url;
    };

    $rootScope.currentUser = null;
    $rootScope.appName = 'MyTunes';
    $rootScope.setInitialUrl("/landing");
    //if ($rootScope.currentUser === null) {
    //    $rootScope.setInitialUrl("/login");
    //    $window.location.href = "login.html";
    //} else {
    //    $rootScope.setInitialUrl("/landing");
    //    $window.location.href = "index.html";
    //}
});