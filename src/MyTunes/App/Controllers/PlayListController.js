"use strict";
myTunes.controller('playListController', ['$scope', 'playListService', '$log', 'notificationService', 'gravatarUrlBuilder','$timeout'
    , function ($scope, playListService, $log, notificationService, gravatarUrlBuilder,$timeout) {
        $scope.titulo = "Mis Listas";
        $scope.lista = [];
        $scope.listaCanciones = [];

        $scope.mostrarCanciones = function (id) {
            buscaCanciones(id);
        };


        var buscaCanciones = function (playListId) {
            playListService.traeCanciones(playListId).then(function (data) {
                $scope.listaCanciones = data;
                if ($scope.listaCanciones.length > 0)
                    notificationService.success("La lista tiene canciones");
                else
                    notificationService.info("La lista no tiene canciones");
            }, function (errorMsg) {
                notificationService.error(errorMsg);
            });
        };

        playListService.traerLista().then(function (data) {
            //una respuesta exitosa (200)
            $scope.lista = data;
            if ($scope.lista.length > 0) {
                notificationService.success("El usuario tiene listas");
                buscaCanciones($scope.lista[0].Id);
            }
            else
                notificationService.info("El usuario no tiene listas");
        }, function (errorMsg) {
            notificationService.error(errorMsg);
        });

        $timeout(function () {
            $scope.gravatarUrl = gravatarUrlBuilder.gravatarUrl('uzigula@gmail.com');
        }, 1000);

    }]);
