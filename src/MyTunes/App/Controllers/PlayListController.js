"use strict";
myTunes.controller('playListController', ['$scope', 'playListService', '$log'
    , function ($scope,playListService,$log) {
        $scope.titulo = "Mis Canciones";
        $scope.canciones = [];
        playListService.traerLista().Then(function (response) {
            $scope.canciones = response;
        }, function (error) {
            $log.warn(error);
        });

    }]);
