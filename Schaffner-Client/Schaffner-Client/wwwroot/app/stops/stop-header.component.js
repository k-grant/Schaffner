(function () {
    'use strict';

    angular.module('schaffner').component("stopHeader",
        {
            bindings: {
                stopInfo: "<"
            },
            controllerAs: "vm",
            controller: function () {
                var vm = this;
                vm.hideInfo = function (stopInfo) {
                    stopInfo.hide = !stopInfo.hide;
                }
            },
            templateUrl: "app/stops/stop-header.component.html"
        });
})();