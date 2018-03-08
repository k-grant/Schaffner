(function () {
    'use strict';

    angular
        .module('schaffner')
        .factory('stopsDataService', stopsDataService);

    stopsDataService.$inject = ['$resource','$location'];

    function stopsDataService($resource, $location) {
        var port = ':' + $location.port();
        var baseURL = location.origin + '/Schaffner/api/stops/:stopId';
        var stopAPI = $resource(baseURL.replace(port,''), { stopId: '@id' });

        function getStopPredition(stopId) {
           return stopAPI.query({ stopId: stopId }).$promise;
        }

        return {
            getStopPredition: getStopPredition
        };
    }
})();