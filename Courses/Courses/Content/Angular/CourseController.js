courseApp.controller("courseController", function courseController($scope, $http, $filter, $timeout) {
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
        $http.post(resource, data1).success(function (data, status) {
            if (data === "true") {
                $scope.isSuccess = true;
                $scope.successMessage = "Course Successfully Added...";
                $scope.CourseName = '';
                $scope.CourseDuration = '';
                $scope.CourseStartDate = '';
                //$scope.onPropertySearch();
            }
        });
    }

   


    $scope.AddModules = function () {


        var data1 = {
            ModuleName: $scope.ModuleName,
           
        };
       

        var resource = location.protocol + "//" + location.host + "/api/Search/AddModules";
        $http.post(resource, data1).success(function (data, status) {
            if (data === "true") {
                $scope.isSuccess = true;
                $scope.successMessage = "Modules Successfully Added...";
                $scope.ModuleName = '';
              
                //$scope.onPropertySearch();
            }
        });
    }


    //$scope.getCourses = function () {


    //    var data1 = {
    //        ModuleName: $scope.ModuleName,

    //    };


    //    var resource = location.protocol + "//" + location.host + "/api/Search/AddModules";
    //    $http.post(resource, data1).success(function (data, status) {
    //        if (data === "true") {
    //            $scope.isSuccess = true;
    //            $scope.successMessage = "Modules Successfully Added...";
    //            $scope.ModuleName = '';

    //            //$scope.onPropertySearch();
    //        }
    //    });
    //}

    $scope.getAllCourses = [];

    $scope.getCourses = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetCourses";

        $http.get(resource).success(function (data, status) {
            $scope.getAllCourses = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })



    }

    $scope.getCourses();




    $scope.getAllModules = [];

    $scope.getModules = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetModules";

        $http.get(resource).success(function (data, status) {
            $scope.getAllModules = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })



    }

    $scope.getModules();




    $scope.InsertCourseModule = function () {

        var C_id = $("#selectedCourses").val();
        var M_id = $("#selectedModules").val().toString();

        var data1 = {
            CourseId: C_id,
            ModuleId: M_id
        }

      //  alert(C_id + " " + M_id);
        var resource = location.protocol + "//" + location.host + "/api/Search/AddCourseModules";
        $http.post(resource, data1).success(function (data, status) {
            if (data === "true") {
                $scope.isSuccess = true;
                $scope.successMessage = "Successfully Assigned Modules...";
                $scope.ModuleName = '';

                //$scope.onPropertySearch();
            }
        });

      //  $scope.selectedCourses = 0;

      //  document.getElementById("#myform").reset();

    //    $("#selectedCourses").rest();

    }






    $scope.getAllStudents = [];

    $scope.getStudents = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetStudents";

        $http.get(resource).success(function (data, status) {
            $scope.getAllStudents = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })



    }

    $scope.getStudents();









});