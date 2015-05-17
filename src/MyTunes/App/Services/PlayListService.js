﻿"use strict";
myTunes.factory('playListService', function ($http, $q) {
    var url = "http://localhost:51342/PlayList";
    return {
        traerLista: function () {
            var defered = $q.defer(); // una promesa
            // una llamada ajax Get
            $http.get(url+'/Lista').success(function (data) {
                defered.resolve(data);
            }).error(function (msg, error) {
                defered.reject(msg);
            });
            return defered.promise;
        },
        crearLista: function () {
            var defered = $q.defer(); // una promesa
            // una llamada ajax Get
            $http.get(url+'/Crear').success(function (data) {
                defered.resolve(data);
            }).error(function (msg, error) {
                defered.reject(msg);
            });
            return defered.promise;
        }

    }
}
);