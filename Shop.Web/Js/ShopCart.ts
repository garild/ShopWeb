
/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-resource.d.ts" />


angular.module("MyBooks", ['ui.bootstrap', 'ngSanitize'])
.controller("CartController", function ($scope, $http) {
    $scope.SelectedEdtion = -1;

    $http.get("Editions/GetEdition").then(function (fillFulled) {
        if (fillFulled !== null) {
            console.log(fillFulled);
            $scope.EditionsList = fillFulled;
        }
    }, function (errorHandler) {
            console.log(errorHandler)
        })
});