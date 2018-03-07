/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-resource.d.ts" />
/// <reference path="../models/route.ts" />
/// <reference path="../models/arrivalprediction.ts" />
var Schaffner;
(function (Schaffner) {
    var StopsDataService = /** @class */ (function () {
        function StopsDataService($resource, $location) {
            this.$resource = $resource;
            this.$location = $location;
            this.port = ':' + this.$location.port();
            this.baseURL = (location.origin + '/Schaffner/api/stops/:stopId').replace(this.port, '');
            this.stopAPI = this.$resource(this.baseURL, { stopId: '@id' });
        }
        StopsDataService.prototype.getStopPredition = function (stopId) {
            var promise = this.QueryStopsResource(stopId);
            return promise;
        };
        StopsDataService.prototype.QueryStopsResource = function (stopId) {
            return (this.stopAPI.query({ stopId: stopId }).$promise);
        };
        StopsDataService.$inject = ["$resource", "$location"];
        return StopsDataService;
    }());
    Schaffner.StopsDataService = StopsDataService;
    function routes($routeProvider) {
    }
    angular
        .module("schaffner")
        .service("stopsDataService", StopsDataService)
        .config(routes);
})(Schaffner || (Schaffner = {}));
//# sourceMappingURL=stops-data-service.js.map