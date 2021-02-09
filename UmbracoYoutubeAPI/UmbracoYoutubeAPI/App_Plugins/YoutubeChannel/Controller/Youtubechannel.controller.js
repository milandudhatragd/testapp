angular.module("umbraco")
    .controller("Youtubechannel.controller",
        function ($scope, $http) {
            var url = "/umbraco/api/YoutubeAPI/GetVideoListFromYoutube";
            $scope.defaultYoutubeUrl = "https://www.youtube.com/watch?v=";
            if (!$scope.model.value.list) {
                $scope.model.value = {
                    list: []
                };
            }
            $scope.GetVideoListFromYoutube = function () {
                $http.get(url)
                    .then(function (response) {
                        if (response.data.StatusCode === 200) {
                            $scope.model.value.list = response.data.Data;
                        }
                    });
            };
    });