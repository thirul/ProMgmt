(function () {

    'user strict';

    angular
           .module('common-services')
           .factory('productResource', ['$resource','appSettings', productResource]);

    function productResource($resource,appSettings)
    {
            // default resource 
        //return $resource(appSettings.serverPath + 'api/product/:id');      

        // custom resource
        return $resource(appSettings.serverPath + 'api/product/:id' ,null,
            {
                'update': {method:'PUT'}
            });
        
    };


})();