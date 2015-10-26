(function(){
"use strict";

angular
    .module("productManagement")
    .controller("mainCtrl", ["userAccount","currentUser", mainCtrl]);

function mainCtrl(userAccount, currentUser) {
        var vm = this;

        vm.isLoggedIn = false;
        vm.message = '';
        vm.userData = {
            userName: '',
            email: '',
            password: '',
            confirmPassword: ''
        };

        vm.isLoggedIn = function () {
            return currentUser.getProfile().isLoggedIn;
        };
        
        vm.registerUser = function () {
            vm.userData.confirmPassword = vm.userData.password;
            userAccount.registration.registerUser(vm.userData,
                // success call 
                function (data) {
                    vm.confirmPassword = '';
                    vm.message = '...registered successfuly';
                    vm.login();
                },

                // error handling
                 function (response) {

                     vm.message = response.statusText + "\r\n";
                     // handle the exceptions like internal server errors 
                     if (response.data.exceptionMessage) {
                         vm.message += response.data.exceptionMessage;
                     }

                     // handle the validation errors 
                     if (response.data.modelState) {
                         for (var key in response.data.modelState) {
                             vm.message += response.data.modelState[key] + "\r\n";
                         }
                     }
                 });
        };

        vm.login = function () {
            vm.userData.grantType = "password";
            vm.userData.userName = vm.userData.email;
            userAccount.login.loginUser({userName:vm.userData.userName,password:vm.userData.password,grant_type:'password'},
                function (data) {
                    
                    vm.message = '';
                    vm.password = '';

                    // store token
                    currentUser.setProfile(vm.userData.userName, data.access_token);
                },
                // error handling
                 function (response) {

                     vm.message = response.statusText + "\r\n";
                     // handle the exceptions like internal server errors 
                     if (response.data.exceptionMessage) {
                         vm.message += response.data.exceptionMessage;
                     }

                     // handle the validation errors 
                     if (response.data.modelState) {
                         for (var key in response.data.modelState) {
                             vm.message += response.data.modelState[key] + "\r\n";
                         }
                     }
                 });
        };
    };


})();