
(function () {
    "user strict";
    var app = angular.module('productManagement',
                            ['common-services', 'ui.router']);


    app.config(function ($stateProvider, $urlRouterProvider) {
        //
        // For any unmatched url, redirect to home
        $urlRouterProvider.otherwise("/home");
        
        // Now set up the states
        $stateProvider
           .state('home', {
                    url: "/",
                    templateUrl: "index.html"
                })
          .state('state1', {
              url: "/state1",
              templateUrl: "app/state/state1.html"
          })
          
          .state('state2', {
              url: "/state2",
              templateUrl: "app/state/state2.html"
          })
      
    });
})();