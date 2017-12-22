courseApp.controller("courseController", function courseController($scope, $http, $timeout) {
    $scope.Author = "Umais Siddiqui";
    $scope.UserName = "";
    $scope.test = function () { alert("Testing"); };
    var promise = $timeout(function () {
$scope.UserName = $('#UserName').val();
    }, 1000)



    $scope.AddCourses = function () {


        var data1 = {
            CourseName: $scope.CourseName,
            CourseDuration: $scope.CourseDuration,
            CourseStartDate: $scope.CourseStartDate
        };

      
        var resource = location.protocol + "//" + location.host + "/api/Search/AddCourse";
        alert("" + resource);
        $http.post(resource, data1).success(function (data, status) {
            if (data == "true") {
                $scope.isSuccess = true;
             //   $scope.successMessage = "The customer has been removed from Direct mail.";
                //$scope.onPropertySearch();
            }
        })
    }

   

});