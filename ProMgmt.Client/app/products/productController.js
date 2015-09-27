(function () {
    "user strict";
    angular
        .module('productManagement')
        .controller('productController', ['productResource',productController]);

    function productController(productResource) {
        var vm = this;
        vm.title = 'sss';
        vm.products = [];

        productResource.query(function (data) {
            vm.products = data;
        });
       
    };
})();