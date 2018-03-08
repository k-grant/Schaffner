(function () {
    'use strict';

    angular.module('schaffner').component("stopInfo",
        {
            bindings: {
                stopInfo: "<"
            },
            controllerAs: "vm",
            controller: function () {
                var vm = this;

                vm.$onInit = function () {

                    vm.busNumber = vm.stopInfo[0].route.id.toString(6);

                };

            },
            templateUrl: "app/stops/stop-info.component.html"
        });
})();