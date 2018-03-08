(function () {
    'use strict';

    angular.module('schaffner').component("noFussBus",
        {
            controllerAs: "vm",
            controller: function () {

                var vm = this;
               
            },
            templateUrl: function (IISProjectFolderRoot) {
                return IISProjectFolderRoot + "app/no-fuss-bus.component.html";
            }
        });
})();