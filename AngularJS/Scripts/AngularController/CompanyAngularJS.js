var app = angular.module("CompanyApp", []);

app.controller("CompanyController", function ($scope, $http) {
    $scope.btntext = "Save";

    //populating the list
    $http({
        method: 'GET',
        url: '/UserInfo/GetData'
    }).then(function (result) {
        $scope.user = result.data;
    });

    //populating status
    $http({
        method: 'GET',
        url: '/Company/GetStatus'
    }).then(function (Somethings) {
        $scope.somedata = Somethings.data
    });


    $scope.savedata = function () {
        $scope.btntext = "Please Wait";
        $http({
            method: 'POST',
            url: '/Company/CreateRecord',
            data: $scope.company
        }).then(function successCallback(response) {
            $scope.btntext = "Save";
            $scope.company = null;
            alert(response.data);
        }, function errorCallback() {
            alert('Failed');
        });
    };


    $http.get("/Company/GetData").then(function (response) {

        $scope.record = response.data;
    }, function (error) {
        alert("failed");
    });

    $scope.deleterecord = function (Id) {

        $http.get("/Company/DeleteData?Id=" + Id).then(function (response) {

            alert(response.data);

            $http.get("/Company/GetData").then(function (response) {

                $scope.record = response.data;
            }, function (error) {
                alert("failed");
            });

        }, function (error) {
            alert("Failed");
        });
    };

    $scope.loadrecord = function (Id)
    {

        $http.get("/Company/GetDataById?Id=" + Id).then(function (response) {

            $scope.company = response.data;
            // for assigning the date
            $scope.company.RequestDate = new Date($scope.company.RequestDate);
            $scope.company.Status = response.data.Status;

        }, function (error) {
            alert("Failed");
        });
    };

    $scope.updatedata = function () {
        $scope.btntext = "Please Wait..";
        
        $http({
            method: 'POST',
            url: '/Company/UpdateData',
            data: $scope.company            
        }).then(function successCallback(response) {

            $scope.btntext = "Update";
            $scope.company = null;
            alert(response.data);
        }, function errorCallback() {
            alert('Failed');
        });
    };

});