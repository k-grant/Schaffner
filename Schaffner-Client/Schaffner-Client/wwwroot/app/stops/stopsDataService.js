(function () {
    'use strict';

    angular
        .module('schaffner')
        .factory('stopsDataService', stopsDataService);

    stopsDataService.$inject = ['$resource','SchaffnerRestAPIBaseURL'];

    function stopsDataService($resource, SchaffnerRestAPIBaseURL) {

        var baseURL = SchaffnerRestAPIBaseURL + '/stops/';
        var baseURL2 = baseURL + ':stopId';

        function getStopPredictions(stopId) {
            var stopAPI = $resource(baseURL2, { stopId: '@id' });
           return stopAPI.query({ stopId: stopId }).$promise;
        }

        function getAllStopPredictions() {
            var stopAPI = $resource(baseURL);
            return stopAPI.query().$promise;
        }

        return {
            getStopPredictions: getStopPredictions,
            getAllStopPredictions: getAllStopPredictions
        };
    }
})();