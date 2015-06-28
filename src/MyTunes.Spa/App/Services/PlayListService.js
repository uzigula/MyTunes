"use strict";
myTunes.factory('playListService', function ($http, $q) {
    var url = "http://localhost:52762/api/Playlist";
    return {
        traerLista: function () {
            var defered = $q.defer(); // una promesa
            // una llamada ajax Get
            $http.get(url).success(function (data) {
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
        },

        traeCanciones: function (id) {
            var defered = $q.defer();
            //$http.get(url + '/Canciones/' + id, { params: { playListId: id } })
            $http.get(url + '/Canciones/'+id, { params: { playListId: id } })
                .success(function (data) {
                    defered.resolve(data);
                })
                .error(function (msg, error) {
                    defered.reject;
                });
            return defered.promise;

        }

    }
}
);