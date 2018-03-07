/// <reference path="../typings/angularjs/angular.d.ts" />
/// <reference path="../typings/angularjs/angular-resource.d.ts" />
/// <reference path="../typings/angularjs/angular-route.d.ts" />
var Schaffner;
(function (Schaffner) {
    "use strict";
    function routes($routeProvider) {
        $routeProvider.otherwise({ redirectTo: "/" });
    }
    function location($locationProvider) {
        $locationProvider.html5Mode(true);
    }
    angular
        .module("schaffner", ["ngRoute", "ngResource"])
        .config(routes)
        .config(location);
})(Schaffner || (Schaffner = {}));
//# sourceMappingURL=app.js.map