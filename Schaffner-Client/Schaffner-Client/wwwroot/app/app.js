
(function (Schaffner) {
    "use strict";

    function location($locationProvider) {
        $locationProvider.html5Mode(true);
    }

    var appModule = angular
        .module("schaffner", ["ngResource", "ui.router","ng-horizontal-timeline"])
        .config(location);

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

    appModule.value('componentBorders', false);

    appModule.run(function (componentBorders) {
        if (componentBorders) {
            if (appModule._invokeQueue) {
                appModule._invokeQueue.forEach(function (item) {
                    if (item[1] == 'component') {
                        var componentName = item[2][0];
                        var componentProperties = item[2][1];
                        if (componentProperties.templateUrl) {
                            var templateUrl = componentProperties.templateUrl;
                            delete componentProperties.templateUrl;
                            componentProperties.template = '<div class="component-borders"><b>' + componentName + '</b><div ng-include="\'' + templateUrl + '\'"></div></div>';
                        }
                        else {
                            var template = '<div class="component-borders">' + componentName + '<div>' + componentProperties.template + '</div></div>';
                            componentProperties.template = template;
                        }
                    }
                });
            }
        }
    });
})();
