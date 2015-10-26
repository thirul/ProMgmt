(function () {
    "use strict";

    angular
           .module("common-services")
            .factory("currentUser", [currentUser]);

    function currentUser() {

        var profile = {
            isLoggedIn: false,
            userName: '',
            token:''
        };

        var getProfile = function () {
            return profile;
        };

        var setProfile = function(userName,token)
        {
            profile.userName = userName;
            profile.token = token;
            profile.isLoggedIn = true;
        }

        return {
            getProfile: getProfile,
            setProfile: setProfile
        }
    };

})();