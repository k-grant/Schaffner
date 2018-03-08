(function () {
    'use strict';

    angular.module('schaffner').component("stopsList",
        {
            controllerAs: "vm",
            controller: function ($interval, stopsDataService) {

                var vm = this;               

                vm.stop1info = {hide:true}
                vm.stop2info = {hide:true}

                vm.stopInfos = [vm.stop1info, vm.stop2info];

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
                    stopsDataService.getStopPredition(1).then(function (response) {
                        var prevHide = vm.stop1info.hide;
                        vm.stop1info = response;
                        vm.stop1info.id = 1;
                        vm.stop1info.hide = prevHide;

                        vm.stopInfos = [vm.stop1info, vm.stop2info];
                    },
                        (err) => {
                            console.log("rejected with", err);
                        });

                    stopsDataService.getStopPredition(2).then(function (response) {
                        var prevHide = vm.stop2info.hide;
                        vm.stop2info = response;
                        vm.stop2info.id = 2;
                        vm.stop2info.hide = prevHide;

                        vm.stopInfos = [vm.stop1info, vm.stop2info];
                    },
                        (err) => {
                            console.log("rejected with", err);
                        });
                }
            },
            templateUrl: "app/stops/stops-list.component.html"
        });
})();