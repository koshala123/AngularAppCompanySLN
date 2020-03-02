var app = angular.module("UserApp", []);

app.controller("UserController", function ($scope, $http) {
    $scope.btntext = "Save";

    $scope.savedata = function () {
        $scope.btntext = "Please Wait";
        $http({
            method: 'POST',
            url: '/UserInfo/CreateRecord',
            data: $scope.userInformation
        }).then(function successCallback(response) {
            $scope.btntext = "Save";
            $scope.userInformation = null;
            alert(response.data);
        }, function errorCallback() {
            alert('Failed');
        });
    };

    $http.get("/UserInfo/GetData").then(function (response) {

        $scope.record = response.data;

    }, function (error) {
        alert("failed");
    });

    $scope.loadrecord = function (Id) {

        $http.get("/UserInfo/GetDataById?Id=" + Id).then(function (response) {

            $scope.registration = response.data;
        }, function (error) {
            alert("Failed");
        });
    };

    $scope.deleterecord = function (Id) {

        $http.get("/UserInfo/Delete_record?Id=" + Id).then(function (response) {

            alert(response.data);

            $http.get("/UserInfo/GetData").then(function (response) {

                $scope.record = response.data;
            }, function (error) {
                alert("failed");
            });

        }, function (error) {
            alert("Failed");
        });
    };

    $scope.updatedata = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/UserInfo/Update_recordReal',
            data: $scope.registration
        }).then(function successCallback(response) {

            $scope.btntext = "Update";
            $scope.registration = null;
            alert(response.data);
        }, function errorCallback() {
            alert('Failed');
        });
    };
});