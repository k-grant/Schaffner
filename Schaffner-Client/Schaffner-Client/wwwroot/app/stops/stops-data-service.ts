/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-resource.d.ts" />
/// <reference path="../models/route.ts" />
/// <reference path="../models/arrivalprediction.ts" />

module Schaffner {

    export class StopsDataService {

        static $inject = ["$resource", "$location"];
        private port: string = ':' + this.$location.port();
        private baseURL: string = (location.origin + '/Schaffner/api/stops/:stopId').replace(this.port, '');
        private stopAPI = this.$resource(this.baseURL, { stopId: '@id' });

        constructor(private $resource: ng.resource.IResourceService, private $location: ng.ILocationService) {
        }

        public getStopPredition(stopId: number) {

            var promise = this.QueryStopsResource(stopId);
            
            return promise;
        }

        private QueryStopsResource(stopId: number) {
            return (this.stopAPI.query({ stopId: stopId }).$promise);
        }
    }

    function routes($routeProvider: ng.route.IRouteProvider) {
    }

    angular
        .module("schaffner")
        .service("stopsDataService", StopsDataService)
        .config(routes);
}