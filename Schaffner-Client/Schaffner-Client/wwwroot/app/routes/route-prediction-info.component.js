(function () {
    'use strict';

    angular.module('schaffner').component("routePredictionInfo",
        {
            bindings: {
                predictionInfo : "<"
            },
            controllerAs: "vm",
            controller: function () {

                var vm = this;
                
            },
            templateUrl: "app/routes/route-prediction-info.component.html"
        });
})();