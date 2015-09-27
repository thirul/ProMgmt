(function () {
    "user strict";
    angular
        .module('productManagement')
        .controller('productController', productController);

    function productController() {
        var vm = this;
        vm.title = 'sss';
        vm.products = [
            {
                name: 'product 1',
                code: 'c1',
                price: 12.45,
                date:null
            },
            {
                name: 'product 2',
                code: 'p2',
                price: 12.45,
                date: null
            },
            {
                name: 'prdouct 3',
                code: 'p5',
                price: 12.45,
                date: null
            },
        ];
    };
})();