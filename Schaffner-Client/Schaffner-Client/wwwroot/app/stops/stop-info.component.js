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
                };

                vm.getBackGroundColor = function (prediction) {
                    if (prediction.route.id == 1)
                        return'route1BackGroundColor';
                    else
                    if (prediction.route.id == 2)
                        return 'route2BackGroundColor';
                    else
                    if (prediction.route.id == 3)
                        return 'route3BackGroundColor';
                    else return'defaultBackGroundColor';
                }

                

            },
            templateUrl: "app/stops/stop-info.component.html"
        });
})();