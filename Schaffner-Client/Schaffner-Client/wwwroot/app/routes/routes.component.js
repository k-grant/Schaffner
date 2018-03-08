(function () {
    'use strict';

    angular.module('schaffner').component("routes",
        {
            controllerAs: "vm",
            controller: function () {

                var vm = this;
                
            },
            templateUrl: function (IISProjectFolderRoot) {
                return IISProjectFolderRoot + "app/routes/routes.component.html";
            }
        });
})();