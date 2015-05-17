"use strict";
myTunes.factory('playListService', function ($http, $q) {
    var url = "http://localhost:51342/PlayList/Lista";
    return {
        traerLista: function () {
            var defered = $q.defer();
            $http.get(url).then(function (response) {
                defered.resolve(response);
            }).error(function (error) {
                defered.reject(error);
            });
            return defered;
        }
    }
}
);