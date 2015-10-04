(function () {
    "user strict";
    angular
        .module('productManagement')
        .controller('productListCtrl', ['productResource', productListCtrl]);

    function productListCtrl(productResource) {
        var vm = this;
        vm.title = 'sss';
        vm.searchCode = '';
        vm.products = [];

        // init
        get();
      

        vm.search = function () {
           
            get();
        };

        function get() {
            productResource.query({search: vm.searchCode }, function (data) {
                vm.products = data;
            });
        };
       
    };
})();