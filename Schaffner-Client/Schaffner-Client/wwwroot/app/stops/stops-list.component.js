(function () {
    'use strict';

    angular.module('schaffner').component("stopsList",
        {
            controllerAs: "vm",
            controller: function ($interval, stopsDataService) {

                var vm = this;               

                vm.stopInfos = [];
                vm.hideInfos = [];

                vm.$onInit = function () {

                    activate();

                    var time = new Date(), secondsRemaining = (60 - time.getSeconds()) * 1000;
                    setTimeout(function () {
                        activate();
                        $interval(function () { activate(); }, 60001);
                    }, secondsRemaining);
                }

                vm.hideInfo = function (stopInfo) {
                    var valueNow = vm.hideInfos[stopInfo.stop.id - 1];
                    vm.hideInfos[stopInfo.stop.id - 1] = !valueNow;
                }

                function activate() {
                    stopsDataService.getAllStopPredictions().then(function (response) {
                        vm.stopInfos = response;

                        if (vm.hideInfos.length == 0) {
                            vm.hideInfos = new Array(vm.stopInfos.length);
                            for (var i = 0; i < vm.hideInfos.length; i++) {
                                vm.hideInfos[i] = true;
                            }
                        }
                    },
                        (err) => {
                            console.log("rejected with", err);
                        });
                }
            },
            templateUrl: function (IISProjectFolderRoot) {
                return IISProjectFolderRoot + "app/stops/stops-list.component.html";
            }
        });
})();