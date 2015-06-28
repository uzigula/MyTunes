'use strict';
myTunes.factory('authenticacionService',
    ['$http', '$q', 'authStorage', 
    function ($http, $q, authStorage) {
        var urlbase = "http://localhost:52762";
        var authService = {};

        authService.logOut = function () {
            authStorage.deleteToken();
        };

        authService.login = function (loginModel) {
            var data = "grant_type=password&username=" + loginModel.userName + "&password=" + loginModel.password;
            var defered = $q.defer();
            var miHeader = {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            };
            $http.post(urlbase + "/token", data, miHeader)
                .success(function (response) {
                    var token = {
                        token: response.access_token,
                        tokenType: response.token_type,
                        userName: loginModel.userName
                    }
                    authStorage.saveToken(token);
                    defered.resolve(response);
                }).error(function (err, status) {
                    authStorage.deleteToken();
                defered.reject(err);
                });
            return defered.promise;
        };
        return authService;
    }
]);