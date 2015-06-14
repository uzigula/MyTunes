"use strict";

var myTunes = angular.module('myTunes', ['ngRoute','LocalStorageModule']);
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

});

myTunes.run(function ($rootScope, $window, authStorage) {

    $rootScope.getInitialUrl = function () {
        return $rootScope.initialUrl;
    };
    $rootScope.setInitialUrl = function (url) {
        $rootScope.initialUrl = url;
    };

    $rootScope.currentUser = null;
    $rootScope.appName = 'MyTunes';
    $rootScope.setInitialUrl("/home");

    $rootScope.$on("$routeChangeStart", function (event, next, current) {
        if (!authStorage.isAuthenticated()) { //no esta autenticado
            event.preventDefault();
            $window.location.href = "login.html";
        } else {
            var authData = authStorage.getToken();
            $rootScope.currentUser = authData.userName;
        }
    });
    
});