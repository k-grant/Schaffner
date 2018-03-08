(function () {
    'use strict';

    angular
        .module('schaffner')
        .factory('stopsDataService', stopsDataService);

    stopsDataService.$inject = ['$resource','$location'];

    function stopsDataService($resource, $location) {
        var port = ':' + $location.port();
        var baseURL = location.origin + '/Schaffner/api/stops/:stopId';
        var baseURL2 = location.origin + '/Schaffner/api/stops/';
        var stopAPI = $resource(baseURL.replace(port, ''), { stopId: '@id' });

        function getStopPredictions(stopId) {
            var stopAPI = $resource(baseURL.replace(port, ''), { stopId: '@id' });
           return stopAPI.query({ stopId: stopId }).$promise;
        }

        function getAllStopPredictions() {
            var stopAPI = $resource(baseURL2.replace(port, ''));
            return stopAPI.query().$promise;
        }

        return {
            getStopPredictions: getStopPredictions,
            getAllStopPredictions: getAllStopPredictions
        };
    }
})();