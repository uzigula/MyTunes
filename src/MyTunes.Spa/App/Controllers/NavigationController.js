"use strict";
myTunes.controller('navigationController',
    ['$scope', 'authenticacionService',
    function ($scope, authenticacionService) {
    $scope.logoff = function () {
        authenticacionService.logOut();
        $scope.$state.go('login');

    }
}]);
