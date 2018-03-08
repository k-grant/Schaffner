(function () {
    'use strict';

    angular.module('schaffner').component("map",
        {
            controllerAs: "vm",
            controller: function () {

                var vm = this;
                
            },
            templateUrl: function (IISProjectFolderRoot) {
                return IISProjectFolderRoot + "app/map/map.component.html";
            }
        });
})();