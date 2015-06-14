'use strict';
myTunes.controller('loginController',
    ['$scope', '$window', 'authenticacionService',
        function ($scope, $window, authenticacionService) {
            $scope.userName = "";
            $scope.password = "";

            $scope.login = function () {
                var userModel = {
                    userName: $scope.userName,
                    password: $scope.password
                };
                authenticacionService.login(userModel).then(
                    function (response) {
                        $scope.currentUser = userModel.userName;
                        $window.location.href = '/';
                    }, function (err) {
                        alert(err.error.description);
                    });
            };
}]);