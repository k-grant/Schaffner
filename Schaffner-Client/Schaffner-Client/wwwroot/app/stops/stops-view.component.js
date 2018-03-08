(function () {
    'use strict';

    angular.module('schaffner').component("stopsView",
        {
            controllerAs: "vm",
            controller: function () {

                var vm = this;
                
            },
            templateUrl: function (IISProjectFolderRoot) {
                return IISProjectFolderRoot + "app/stops/stops-view.component.html";
            }
        });
})();