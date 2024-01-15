var multiSearch = angular.module("multiSearch", []);

multiSearch.controller('myCtrl', function ($scope, $http, $timeout) {
  $scope.response = [];

  $scope.apiResponse = function () {
    $http.post(`https://localhost:7261/MultiSearch?search=${$scope.searchText}`)
      .then(function (response) {
        $scope.response = response.data;
      }, function (error) {
        console.error('Error:', error);
        $scope.response = 'Error occurred';
      });
  };

  $scope.initialAPICall = function () {
    $scope.searchText = '';
    $scope.apiResponse();
  };

  $scope.search = function () {
    $timeout.cancel($scope.searchTimeout);

    $scope.searchTimeout = $timeout(function () {
      $scope.apiResponse();
    }, 500);
  };


  $scope.initialAPICall();
})

