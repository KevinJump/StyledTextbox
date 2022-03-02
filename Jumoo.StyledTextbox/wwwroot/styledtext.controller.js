(function () {
    'use strict';

    function styledTextController($scope) {

        var vm = this;

        vm.config = $scope.model.config;
        vm.model = $scope.model;
        vm.limit = $scope.model.config.maxChars;
        vm.hideLabel = (vm.config.hideLabel === 1);

        vm.limitMsg = getLocalstring('limit', 'you have reached the limit of {{limit}} charaters');
        vm.adviseMsg = getLocalstring('advice', 'you have gone over the advised lenght by {{over}} characters');
        vm.remaining = getLocalstring('remaining', '{{remain}} characters left');

        // public methods 
        vm.getMessageClass = getMessageClass;
        vm.checkCharLimit = checkCharLimit;

        // when we start - check existing
        vm.checkCharLimit();

        // implimentation

        function getLocalstring(name, defaultValue) {
            var value = Umbraco.Sys.ServerVariables.styledText.strings[name];
            if (value != undefined) return value;
            return defaultValue ;
        }

        function getMessageClass() {
            if (vm.limit > 0 && vm.model.value !== undefined) {

                if (vm.model.value.length >= vm.limit) {
                    return 'color-red';
                }
                return 'muted';
            }
        }


        function checkCharLimit() {
            if (vm.limit > 0 && vm.model.value !== undefined) {

                if (vm.model.value.length > vm.limit) {
                    if (vm.config.enforceLimit) {
                        vm.model.value = vm.model.value.substr(0, vm.limit);
                        vm.info = vm.limitMsg.replace('{{limit}}', vm.limit);
                    }
                    else {
                        vm.info = vm.adviseMsg.replace('{{over}}', vm.model.value.length - vm.limit);
                    }
                }
                else {
                    vm.info = vm.remaining.replace('{{remain}}', vm.limit - vm.model.value.length);
                }
            }
        }
    }

    angular.module('umbraco')
        .controller('jumoo.styledTextController', styledTextController);

})();