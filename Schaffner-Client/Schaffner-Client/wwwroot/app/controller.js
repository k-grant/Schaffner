(function () {
    'use strict';

    angular
        .module('schaffner')
        .controller('begin', controller);

    controller.$inject = ['$interval', 'stopsDataService'];

    function controller($interval, stopsDataService) {

        var vm = this;
        vm.title = 'controller';
        var time = new Date(), secondsRemaining = (60 - time.getSeconds()) * 1000;

        setTimeout(function () {
            activate();
            $interval(function () { activate(); }, 60001);
        }, secondsRemaining);

        vm.stop1info = {}
        vm.stop2info = {}

        activate();

        function activate() {
            stopsDataService.getStopPredition(1).then(function (response) {
                    vm.stop1info = response;
            },
            (err) => {
                console.log("rejected with", err);
            });
            
            stopsDataService.getStopPredition(2).then(function (response) {
                    vm.stop2info = response;
            },
                (err) => {
                    console.log("rejected with", err);
                });
        }
    }
})();
