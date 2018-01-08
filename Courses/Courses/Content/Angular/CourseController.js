courseApp.controller("courseController", function courseController($scope, $window, $http, $filter, $timeout, $log, $uibModal) {
    $scope.Author = "Umais Siddiqui";
    $scope.UserName = "";
    $scope.test = function () { alert("Testing"); };
    var promise = $timeout(function () {
$scope.UserName = $('#UserName').val();
    }, 1000)
    
    $scope.open = function (size, videoSource) {
        $log.info("open", videoSource);
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModal.html',
            controller: 'ModalInstanceCtrl',
            backdrop: true,
            size: size,
            resolve: {
                videoSource: function () {
                    return videoSource;
                }
            }
        });

        modalInstance.result.then(function (result) {
            //
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.videoClick = function ($event, videoSource) {

      //  alert(videoSource);
        var config = {
            headers: {
                'Authorization': 'Bearer M9-AXilUwLAAAAAAAAAAE5oPgmq8_7-AqcHjs9K7a9UixgirDSrxt4RzeRmHEzPD',
                'Content-Type': 'application/json'
            }
        }
        var data2 = {
            "path": videoSource


                    }

                    var resource2 = "https://api.dropboxapi.com/2/files/get_temporary_link";
                    $http.post(resource2, data2, config).success(function (data, status) {

                      

                        $log.info("videoClick", data.link)
                        $scope.open('lg', data.link);

                      //  alert($scope.GetModuleContentDropboxApi.metadata.name + "  " + $scope.GetModuleContentDropboxApi.link)

                     //   $window.location.href = 'https://api.dropboxapi.com/2/files/get_temporary_link';

                    });

               

       
    }


    $scope.fileClick = function ($event, fileSource) {

      
        var config = {
            headers: {
                'Authorization': 'Bearer M9-AXilUwLAAAAAAAAAAE5oPgmq8_7-AqcHjs9K7a9UixgirDSrxt4RzeRmHEzPD',
                'Content-Type': 'application/json'
            }
        }
        var data2 = {
            "path": fileSource,
            "short_url": false


        }

        var resource2 = "https://api.dropboxapi.com/2/sharing/create_shared_link";
        $http.post(resource2, data2, config).success(function (data, status) {

           

         //   alert(data.url);

            //  alert($scope.GetModuleContentDropboxApi.metadata.name + "  " + $scope.GetModuleContentDropboxApi.link)

            

            $window.open(
                data.url,
                '_blank' // <- This is what makes it open in a new window.
            );



        });




    }

    $scope.AddCourses = function () {


        var data1 = {
            CourseName: $scope.CourseName,
            CourseDuration: $scope.CourseDuration,
            CourseStartDate: $scope.CourseStartDate
        };

        if ($scope.CourseName != null && $scope.CourseDuration != null && $scope.CourseStartDate != null) {

            var resource = location.protocol + "//" + location.host + "/api/Search/AddCourse";
            $http.post(resource, data1).success(function (data, status) {
             
                if (data = "true") {
                    $scope.isError = false;
                    $scope.isSuccess = true;
                    $scope.successMessage = "Course Successfully Added...";
                    $scope.CourseName = '';
                    $scope.CourseDuration = '';
                    $scope.CourseStartDate = '';
                    $scope.getCourses();
                 //   $scope.AddCourseDirectory("/Courses/"+data1.CourseName);
                    //$scope.onPropertySearch();
                }
            });
        } else {

            $scope.isError = true;
            $scope.errormessage = "All Fields Are Required..";
        }
    }

   
    $scope.AddCourseDirectory = function (foldername) {

        var config = {
            headers: {
                'Authorization': 'Bearer M9-AXilUwLAAAAAAAAAAE5oPgmq8_7-AqcHjs9K7a9UixgirDSrxt4RzeRmHEzPD',
                'Content-Type': 'application/json'
            }
        }
        var data2 = {
            "title": "CreateFolder",
            "destination":  foldername,
            "open": true


        }

        var resource2 = "https://api.dropboxapi.com/2/file_requests/create";
        $http.post(resource2, data2, config).success(function (data, status) {

            if (data = "true") {

                $scope.isError = false;
                $scope.isSuccess = true;
                $scope.successMessage = "Successfully Directory Created in Dropbox ...";
               
            }

        });
    }

    $scope.AddModules = function () {


        var data1 = {
            ModuleName: $scope.ModuleName,
           
        };
       
        if ($scope.ModuleName != null) {
            var resource = location.protocol + "//" + location.host + "/api/Search/AddModules";
            $http.post(resource, data1).success(function (data, status) {
                if (data = "true") {
                    $scope.isError = false;
                    $scope.isSuccess = true;
                    $scope.successMessage = "Modules Successfully Added...";
                    $scope.ModuleName = '';
                    $scope.getModules();
                    //$scope.onPropertySearch();
                }
            });
        } else {
            $scope.isError = true;
            $scope.errormessage = "All Fields Are Required..";
        }

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

        var CourseName = '';
        var path = '';
        var ModuleName = '';

        var data1 = {
            CourseId: C_id,
            ModuleId: M_id,
            DirectoryPath: path
        }

        


           angular.forEach($scope.getAllCourses, function (value, key) {

               if (value.CourseID == C_id) {

                   CourseName =  value.CourseName;
            }
        });

         
           var ss = data1.ModuleId.split(",");
           for (var i in ss) {

               angular.forEach($scope.getAllModules, function (value, key) {

                   if (value.ModuleId == ss[i]) {


                       path += CourseName + "/Modules/" + value.ModuleName + ",";
                       ModuleName += value.ModuleName + ",";
                    //   $scope.AddCourseDirectory(path);

                   }
               });


           } 
     
         //  alert(path);

      
           var data = {
               CourseId: C_id,
               ModuleId: M_id,
               DirectoryPath: path,
               ModuleName: ModuleName,
           }
     

       // alert(C_id + " " + M_id);
        var resource = location.protocol + "//" + location.host + "/api/Search/AddCourseModules";
        $http.post(resource, data).success(function (data, status) {
            if (data = "true") {
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
            if (data = "true") {
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




    //$scope.getUsersRole = function () {
    //    var resource = location.protocol + "//" + location.host + "/api/Search/CheckUser";
    //    var user = $('#UserName').val();
      
    //    var data = {
    //        UserName: user
    //    };
        

    //    $http.post(resource, data).success(function (data, status) {
    //        if (data.Role == 1) {
    //            $scope.isAdmin = true;
    //        }


            
    //    })
    //        .error(function (data, status) {
    //            // this isn't happening:
    //        })



    //}

  //  $scope.getUsersRole();







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


        $scope.GetModuleContentDropboxApi = [];

        $scope.ShowContentModules = function (CourseName, Modulename,id) {

           

            var config = {
                headers: {
                    'Authorization': 'Bearer M9-AXilUwLAAAAAAAAAAE5oPgmq8_7-AqcHjs9K7a9UixgirDSrxt4RzeRmHEzPD',
                    'Content-Type': 'application/json'
                }
            }
            //angular.forEach($scope.GetAllSingleUserCourseModules, function (value, key) {



            var path = "/Courses/" + CourseName + "/Modules/" + Modulename + "/";

            var data1 = {
                "path": path


            }
            var resource1 = "https://api.dropboxapi.com/2/files/list_folder";
            $http.post(resource1, data1, config).success(function (data, status) {


                $scope.GetModuleContentDropboxApi = data.entries;

                var count = 0 ;
                angular.forEach($scope.GetAllSingleUserCourseModules, function (value, key) {
                    count = count + 1
                 //   alert();

                   

                   

                    if (value.ModuleName == Modulename) {

                        $("#"+id).css("display", "block");
                    } else {


                        $("#abc" + count).css("display", "none");
                    }

                });

                //angular.forEach(data.entries, function (value, key) {

                //  //  alert(value.name)

                //    var path2 = "/Courses/" + CourseName + "/Modules/" + Modulename + "/" + value.name ;

                //    var data2 = {
                //        "path": path2


                //    }

                //    var resource2 = "https://api.dropboxapi.com/2/files/get_temporary_link";
                //    $http.post(resource2, data2, config).success(function (data, status) {

                //        $scope.GetModuleContentDropboxApi = data;

                //        alert($scope.GetModuleContentDropboxApi.metadata.name + "  " + $scope.GetModuleContentDropboxApi.link)

                //     //   $window.location.href = 'https://api.dropboxapi.com/2/files/get_temporary_link';

                //    });

                //    });
            });
            //});


        }


        $scope.getAllExams = [];

        $scope.getExams = function () {
            var resource = location.protocol + "//" + location.host + "/api/Search/GetExams";

            $http.get(resource).success(function (data, status) {
                $scope.getAllExams = data;

            })
                .error(function (data, status) {
                    // this isn't happening:
                })



        }

        $scope.getExams();



        $scope.AddExam = function () {
            //   // alert("sdf");
            var videoSource = "";
                //$scope.propertyDetail = {};
                //$scope.propertyDetail.Id = id;
                //getClientYearSetup1();
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                    templateUrl: 'addExam.html',
                    
                    controller: 'addExamModalInstanceCtrl',
                    windowClass: 'app-modal-window',
                    size: '',
                    resolve: {
                        courses: function () {
                            return $scope.getAllCourses;
                        }
                    }
                });

                //modalInstance.result.then(function () {
                //    //$log.info(updatePropertyItemResponse);
                //    //if (updatePropertyItemResponse.hasOwnProperty('isError') && updatePropertyItemResponse.isError === true) {
                //    //    //showSucessMessageBox(saveCatalogResponse.message, "failure");
                //    //}
                //    //else {
                //    //    $scope.updatePropertyItem.Id = updatePropertyItemResponse.updatePropertyItem.Id;
                //    //    //showSucessMessageBox(saveCatalogResponse.message, "success");
                //    //}

                //}, function (response) {
                //    if (response == 'saved') {
                //        alert("dgf");
                //        $scope.getExams();
                //    }
                //});
           


            modalInstance.result.then(
                function handleResolve(response) {
                    $scope.getExams();
                },
                function handleReject(error) {
                   // alert("Alert rejected!");
                }
            );


            //$log.info("open", videoSource);
            //var modalInstance = $uibModal.open({
            //    animation: $scope.animationsEnabled,
            //    templateUrl: 'addExam.html',
            //    controller: 'addExamModalInstanceCtrl',
            //    backdrop: true,
            //    size: 'lg',
            //    resolve: {
            //        videoSource: function () {
            //            return videoSource;
            //        }
            //    }
            //});

            //modalInstance.result.then(function (result) {
            //    //
            //}, function () {
            //    $log.info('Modal dismissed at: ' + new Date());
            //    });


        }
});


courseApp.controller('addExamModalInstanceCtrl', function ($scope, $http, $uibModalInstance, courses) {
    $scope.modalTitle = "Add Exam";

  //  alert(courses[0].CourseName);
    $scope.getAllCourses = courses;




    $scope.InsertExam = function () {

        var C_id = $("#selectedCourses").val();
        var data1 = {
            ExamName: $scope.ExamName,
            CourseID: C_id
            
        };

        //if ($scope.CourseName != null && $scope.CourseDuration != null && $scope.CourseStartDate != null) {

        var resource = location.protocol + "//" + location.host + "/api/Search/InsertExam";
            $http.post(resource, data1).success(function (data, status) {

                if (data = "true") {
                 
                    $scope.isError = false;
                    $scope.isSuccess = true;
                    $scope.successMessage = "Exam Successfully Added...";
                    $scope.ExamName = '';
                    $uibModalInstance.close('saved');
                   
                }
        });

        //} else {

        //    $scope.isError = true;
        //    $scope.errormessage = "All Fields Are Required..";
        //}
    }

   

    $scope.ok = function () {
        $uibModalInstance.close('ok');
    };

  
    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };


});

courseApp.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, videoSource, $log) {
    $log.info("ModalInstanceCtrl", videoSource);

    $scope.id = Math.floor((Math.random() * 100) + 1);
    $scope.videoSource = videoSource;

    $scope.ok = function () {
        $uibModalInstance.close('ok');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});

courseApp.controller('videocontroller', function ($scope) {


    $scope.videoSources = [

        'http://www.sample-videos.com/video/mp4/720/big_buck_bunny_720p_1mb.mp4'
    ];

});


courseApp.filter("trustUrl", ['$sce', function ($sce) {
    return function (recordingUrl) {
        return $sce.trustAsResourceUrl(recordingUrl);
    };
}]);

