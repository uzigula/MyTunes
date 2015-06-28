'use strict';
myTunes.controller('loginController',
    ['$scope', 'authenticacionService',
        function ($scope, authenticacionService) {
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
                        $scope.$state.go('home');
                    }, function (err) {
                        alert(err.error.description);
                    });
            };
}]);