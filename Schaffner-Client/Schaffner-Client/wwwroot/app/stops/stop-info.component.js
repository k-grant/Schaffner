(function () {
    'use strict';

    angular.module('schaffner').component("stopInfo",
        {
            bindings: {
                stopInfo: "<"
            },
            controllerAs: "vm",
            controller: function () {


            },
            templateUrl: "app/stops/stop-info.component.html"
        });
})();