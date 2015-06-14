'use strict';
myTunes.factory('authStorage',
    ['localStorageService', function (localStorageService) {
        var tokenKey = 'authorizationData';
        var authStorageInstance = {};

        var _getToken = function () {
            return localStorageService.get(tokenKey);
        };

        var _saveToken = function (token) {
            localStorageService.set(tokenKey, token);
        };

        var _deleteToken = function () {
            localStorageService.remove(tokenKey);
        }

        authStorageInstance.isAuthenticated = function () {
            var token = _getToken();
            return (token != null);
        }

        authStorageInstance.getToken = _getToken;
        authStorageInstance.saveToken = _saveToken;
        authStorageInstance.deleteToken = _deleteToken;

        return authStorageInstance;
    }]);