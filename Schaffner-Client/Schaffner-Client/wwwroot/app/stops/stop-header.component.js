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

                vm.events = [
                    { text: '' },
                    { text: '' },
                    { text: '' }
                ];

                vm.index = 1;

                vm.logClickEvent = function () {
                };

                vm.$onInit = function () {
                    var min = 2147483647;
                    vm.stopInfo.forEach(function (prediction) {
                        var currMin = Math.min.apply(null, prediction.minutes);
                        if (currMin < min) min = currMin;
                    });
                    vm.nextStopTime = min;
                }
            },
            templateUrl: "app/stops/stop-header.component.html"
        });
})();