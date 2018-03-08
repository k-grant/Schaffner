(function () {
    'use strict';

    angular.module('schaffner').component("stopsList",
        {
            controllerAs: "vm",
            controller: function ($interval, stopsDataService) {

                var vm = this;               

                vm.stopInfos = [];

                vm.$onInit = function () {

                    activate();

                    var time = new Date(), secondsRemaining = (60 - time.getSeconds()) * 1000;
                    setTimeout(function () {
                        activate();
                        $interval(function () { activate(); }, 60001);
                    }, secondsRemaining);
                }

                vm.hideInfo = function (stopInfo) {
                    stopInfo.hide = !stopInfo.hide;
                }

                function activate() {
                    stopsDataService.getAllStopPredictions().then(function (response) {
                        vm.stopInfos = response;
                    },
                        (err) => {
                            console.log("rejected with", err);
                        });
                }
            },
            templateUrl: "app/stops/stops-list.component.html"
        });
})();