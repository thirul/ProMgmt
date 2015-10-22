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
            productResource.get({ id: 1 },
                function (data) {
                    vm.product = data;
                },
                function(response)
                {
                   
                    vm.message = response.statusText + "\r\n";
                    // handle the exceptions like internal server errors 
                    if(response.data.exceptionMessage)
                    {
                        vm.message += response.data.exceptionMessage;
                    }
                    // handle the validation errors 
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
                vm.product.$update({ id: vm.product.id },
                    function (data) {
                    vm.message = 'update completed'
                    },
                    function (response)
                    {
                   
                        vm.message = response.statusText + "\r\n";
                        // handle the exceptions like internal server errors 
                        if(response.data.exceptionMessage)
                        {
                            vm.message += response.data.exceptionMessage;
                        }

                        // handle the validation errors 
                        if (response.data.modelState)
                        {
                            for(var key in response.data.modelState)
                            {
                                vm.message += response.data.modelState[key] + "\r\n";
                            }
                        }
                    });

            }
            else // create new 
            {
                vm.product.$save(function (data) {
                    vm.message = 'new completed';
                },
                 function (response) {

                     vm.message = response.statusText + "\r\n";
                     // handle the exceptions like internal server errors 
                     if (response.data.exceptionMessage) {
                         vm.message += response.data.exceptionMessage;
                     }
                     // handle the validation errors 
                     // handle the validation errors 
                     if (respose.data.modelState) {
                         for (var key in response.data.modelState) {
                             vm.message += response.data.modelState[key] + "\r\n";
                         }
                     }
                 });
            }

        };

        vm.cancel = function () {

        };

    };
})();