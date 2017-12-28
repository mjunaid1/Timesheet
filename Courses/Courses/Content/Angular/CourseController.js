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

        if ($scope.CourseName != null && $scope.CourseDuration != null && $scope.CourseStartDate != null) {

            var resource = location.protocol + "//" + location.host + "/api/Search/AddCourse";
            $http.post(resource, data1).success(function (data, status) {
                if (data === "true") {
                    $scope.isError = false;
                    $scope.isSuccess = true;
                    $scope.successMessage = "Course Successfully Added...";
                    $scope.CourseName = '';
                    $scope.CourseDuration = '';
                    $scope.CourseStartDate = '';
                    $scope.getCourses();
                    //$scope.onPropertySearch();
                }
            });
        } else {

            $scope.isError = true;
            $scope.errormessage = "All Fields Are Required..";
        }
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
                $scope.getModules();
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

       // alert(C_id + " " + M_id);
        var resource = location.protocol + "//" + location.host + "/api/Search/AddCourseModules";
        $http.post(resource, data1).success(function (data, status) {
            if (data === "true") {
                $scope.isSuccess = true;
                $scope.successMessage = "Successfully Assigned Modules...";
                $scope.getCourseModules();
                //$scope.onPropertySearch();
            }
        });

     

    }


    $scope.InsertUserCourses = function () {

        var S_id = $("#selectedStudents").val();
        var C_id = $("#selectedCourses").val().toString();

        var data1 = {
            StudentId: S_id,
            CourseId: C_id
        }

     //  alert(S_id + " dgjk'" + C_id);
        var resource = location.protocol + "//" + location.host + "/api/Search/AddUserCourses";
        $http.post(resource, data1).success(function (data, status) {
            if (data === "true") {
                $scope.isSuccess = true;
                $scope.successMessage = "Successfully Assigned Course...";
                $scope.getUserCourses();

                //$scope.onPropertySearch();
            }
        });

        

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




    $scope.getUsersRole = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/CheckUser";
        var user = $('#UserName').val();
      
        var data = {
            UserName: user
        };
        

        $http.post(resource, data).success(function (data, status) {
            if (data.Role == 1) {
                $scope.isAdmin = true;
            }


            
        })
            .error(function (data, status) {
                // this isn't happening:
            })



    }

    $scope.getUsersRole();







    $scope.getAllCourseModules = [];

    $scope.getCourseModules = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetCourseModules";

        $http.get(resource).success(function (data, status) {
            $scope.getAllCourseModules = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })



    }

    $scope.getCourseModules();



    $scope.getAllUserCourses = [];

    $scope.getUserCourses = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetUserCourses";

        $http.get(resource).success(function (data, status) {
            $scope.getAllUserCourses = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })



    }

    $scope.getUserCourses();



    $scope.GetAllSingleUserCourses = [];

        $scope.GetSingleUserCourses = function () {

            var Email = $('#UserName').val();
        var data = {
            Email: Email
            
        }

      //  alert(S_id + " dgjk'" + C_id);
            var resource = location.protocol + "//" + location.host + "/api/Search/GetCourses_Single_User";
            $http.post(resource, data).success(function (data, status) {
          
              
                $scope.GetAllSingleUserCourses = data;
          
        });

        

    }

        $scope.GetSingleUserCourses();


        $scope.GetAllSingleUserCourseModules = [];

        $scope.GetSingleUserCourseModules = function () {

            var Email = $('#UserName').val();
            var C_id = $('#coursid').val();
            var data = {
                Username: Email,
                CourseId: C_id

            }

            //  alert(S_id + " dgjk'" + C_id);
            var resource = location.protocol + "//" + location.host + "/api/Search/GetCourseModules_Single_User";
            $http.post(resource, data).success(function (data, status) {


                $scope.GetAllSingleUserCourseModules = data;

            });



        }

        $scope.GetSingleUserCourseModules();





});