/// <reference path="../typings/angularjs/angular.d.ts" />
/// <reference path="../typings/angularjs/angular-resource.d.ts" />
/// <reference path="../typings/angularjs/angular-route.d.ts" />

module Schaffner {
    "use strict";

    function routes($routeProvider: ng.route.IRouteProvider) {

        $routeProvider.otherwise({ redirectTo: "/" });
    }

    function location($locationProvider: ng.ILocationProvider) {
        $locationProvider.html5Mode(true);
    }

    angular
        .module("schaffner", ["ngRoute","ngResource"])
        .config(routes)
        .config(location);
}