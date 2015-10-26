(function () {

    'user strict';

    angular
           .module('common-services')
           .factory('productResource', ['$resource','appSettings','currentUser', productResource]);

    function productResource($resource,appSettings,currentUser)
    {
            // default resource 
        //return $resource(appSettings.serverPath + 'api/product/:id');      

        // custom resource
        return $resource(appSettings.serverPath + 'api/product/:id' ,null,
            {
                'get': { headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token } },
                'save': { headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token } },
                'update': {
                    method: 'PUT',
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                }
            });
        
    };


})();