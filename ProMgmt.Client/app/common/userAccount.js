(function () {
    "use strict";

    angular
        .module('common-services')
        .factory("userAccount",
                ["$resource",
                "appSettings",
                userAccount]);

    function userAccount($resource, appSettings) {




        return {
            registration: $resource(appSettings.serverPath + "/api/Account/Register", null,
                                  {
                                      'registerUser': { method: 'POST' }
                                  }),

            // see http://stackoverflow.com/questions/29246908/c-sharp-unsupported-grant-type-when-calling-web-api

            login: $resource(appSettings.serverPath + "/token", null,
             {
                 // web api 2 token request will only allow 'application/x-www-form-urlencoded' and encodeURIComponent
                 // for example see hardcode value.
                 // grant_type=password&username=a@a.com&password=aBc_123
                 'loginUser': {
                     method: 'POST',
                     headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                     transformRequest: function(data, headers){
                         var str = [];
                         for (var d in data)
                             str.push(encodeURIComponent(d) + "=" + encodeURIComponent(data[d]));
                         
                         return str.join("&");                         
                     }
                     
                 }
             })


        };

    };

})();