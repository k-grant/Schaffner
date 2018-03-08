(function () {
    'use strict';

    angular.module('schaffner').component("serviceOutages",
        {
            controllerAs: "vm",
            controller: function () {

                var vm = this;
                
            },
            templateUrl: function (IISProjectFolderRoot) {
                return IISProjectFolderRoot + "app/service-outages/service-outages.component.html";
            }
        });
})();