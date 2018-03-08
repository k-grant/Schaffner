(function () {
    'use strict';

    angular.module('schaffner').component("mainNavigator",
        {
            controllerAs: "vm",
            controller: function () {

                var vm = this;
                
            },
            templateUrl: function (IISProjectFolderRoot) {
                return IISProjectFolderRoot + "app/main-nav-bar/main-navigator.component.html";
            }
        });
})();