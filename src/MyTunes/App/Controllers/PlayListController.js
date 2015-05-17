"use strict";
myTunes.controller('playListController', ['$scope', 'playListService', '$log','notificationService'
    , function ($scope,playListService,$log,notificationService) {
        $scope.titulo = "Mis Canciones";
        $scope.canciones = [];
        playListService.traerLista().then(function (data) {
            //una respuesta exitosa (200)
            $scope.canciones = data;
            if ($scope.canciones.length > 0)
                notificationService.success("El usuario tiene listas");
            else
                notificationService.info("El usuario no tiene listas");
        }, function (errorMsg) {
            notificationService.error(errorMsg);
        });
    }]);
