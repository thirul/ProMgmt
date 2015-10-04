(function () {
    "user strict";
    angular
        .module('productManagement')
        .controller('productEditCtrl', ['productResource', productEditCtrl]);

    function productEditCtrl(productResource) {
        var vm = this;        
        vm.product = {};
        vm.message = '';
        vm.title = '';

        // init
        get();
        
        function get() {
            productResource.get({ id: 1 }, function (data) {
                vm.product = data;
            });
        };

        if(vm.product && vm.product.id)
        {
            vm.title = 'Edit ' + vm.product.name;
        }
        else {
            vm.title = 'New Product'
        }

        vm.submit = function () {

            // put - update
            if (vm.product.id) {
                vm.product.$update({ id: vm.product.id }, function (data) {
                    vm.message = 'update completed'
                });
            }
            else // create new 
            {
                vm.product.$save(function (data) {
                    vm.message = 'new completed';
                });
            }

        };

        vm.cancel = function () {

        };

    };
})();