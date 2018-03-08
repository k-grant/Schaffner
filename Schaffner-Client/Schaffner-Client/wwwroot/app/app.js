
(function (Schaffner) {
    "use strict";

    function location($locationProvider) {
        $locationProvider.html5Mode(true);
    }

    var appModule = angular
        .module("schaffner", ["ngResource", "ui.router","ng-horizontal-timeline"])
        .config(location);

    appModule.constant("SchaffnerRestAPIBaseURL", "http://localhost/Schaffner/api/");
    appModule.constant("IISProjectFolderRoot", "/Schaffner-UI/");

    appModule.config(function ($stateProvider) {

        var states =
            [{
                name: "stops",
                url: "",
                template: "<stops-view></stops-view>"
            },
            {
                name: "stops2",
                url: "/",
                template: "<stops-view></stops-view>"
            },
            {
                name: "routes",
                url: "",
                template: "<routes></routes>"
            },
            {
                name: "serviceOutages",
                url: "",
                template: "<service-outages></service-outages>"
            },
            {
                name: "map",
                url: "",
                template: "<map></map>"
            }
        ];

        states.forEach(function (state) {
            $stateProvider.state(state);
        });

    });
})();
