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

            $scope.GetModuleContentDropboxApi = "";

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

            var data44 = {
                "path": "id:y0FGkpiUfvAAAAAAAAAB6Q",
                "format": "png",
                "size": "w64h64",
                "mode": "strict"


            }
            var resource44 = "https://content.dropboxapi.com/2/files/get_thumbnail";
                    $http.post(resource44, data44, config).success(function (data, status) {


        });

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



        $scope.getAllExamsPerCourse = [];

        $scope.getExamsPerCourse = function () {

            var CourseId = $('#coursid').val();
       //     alert(CourseId);
            if (CourseId != undefined) {
                var resource = location.protocol + "//" + location.host + "/api/Search/getExamsPerCourse";

                $http.post(resource, CourseId).success(function (data, status) {
                    $scope.getAllExamsPerCourse = data;

                })
                    .error(function (data, status) {
                        // this isn't happening:
                    })


            } else {
      //          alert("fs");
            }
        }

        $scope.getExamsPerCourse();



        $scope.getAllViewsResults = [];

        $scope.GetViewsResults = function () {
            var resource = location.protocol + "//" + location.host + "/api/Search/ViewsResults";

            $http.get(resource).success(function (data, status) {
                $scope.getAllViewsResults = data;

            })
                .error(function (data, status) {
                    // this isn't happening:
                })



        }

        $scope.GetViewsResults();


        $scope.AddExam = function () {
                       
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

          

            modalInstance.result.then(
                function handleResolve(response) {
                    $scope.getExams();
                },
                function handleReject(error) {
                   // alert("Alert rejected!");
                }
            );

        }

        $scope.AddQues = function (Examid, examName) {
            
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'addQues.html',

                controller: 'addQuesModalInstanceCtrl',
                windowClass: 'app-modal-window',
                size: 'lg',
                resolve: {
                    ExamId: function () {
                        return Examid;
                    },
                    ExamName: function () {
                        return examName;
                    }
                }
            });



            modalInstance.result.then(
                function handleResolve(response) {
                  //  $scope.getExams();
                },
                function handleReject(error) {
                    // alert("Alert rejected!");
                }
            );

        }


        $scope.ViewQues = function (Examid,ExamName) {

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'viewQues.html',

                controller: 'viewQuesModalInstanceCtrl',
                windowClass: 'app-modal-window',
                size: 'lg',
                resolve: {
                    ExamId: function () {
                        return Examid;
                    },
                    ExamName: function () {
                        return ExamName;
                    }
                   
                }
            });



            modalInstance.result.then(
                function handleResolve(response) {
                    //  $scope.getExams();
                },
                function handleReject(error) {
                    // alert("Alert rejected!");
                }
            );

        }

        $scope.StartExam = function (Examid) {

            var CourseId = $('#coursid').val();
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'StartExam.html',

                controller: 'StartExamModalInstanceCtrl',
                windowClass: 'app-modal-window',
                size: 'lg',
                resolve: {
                    ExamId: function () {
                        return Examid;
                    },
                    Username: function () {
                        return $scope.UserName;
                    }

                }
            });



            modalInstance.result.then(
                function handleResolve(response) {
                    //  $scope.getExams();
                },
                function handleReject(error) {
                    // alert("Alert rejected!");
                }
            );

        }

});


courseApp.controller('StartExamModalInstanceCtrl', function ($scope, $http, $uibModal, $uibModalInstance, ExamId, Username) {
    $scope.modalTitle = "Exam Questions";
    var totalQuestions = 0;
    var next = 0;
    var previous = 0;
    $scope.ViewAllQuestionAndAnswers = [];
    $scope.Correct = [];
    
    $scope.previous_show = false;
    $scope.submitbtn = false;
    $scope.next_show = true;
    $scope.Isresults = false;
    var count = 0;
    //$scope.AnswerID = true;
    //$scope.CorrectAnswer = false;

    //$scope.junv = false;

    //$scope.jun = function (event,ab) {
    //    alert(ab);

    //    if ($scope.junv == event.target.value) $scope.junv = false


    //    $scope.junv = ab;
    //}


    $scope.jun = function (position, entities, qid) {

     //   alert(position);
        angular.forEach(entities, function (subscription, index) {
            
            if (qid == subscription.QuesId && position != subscription.AnswerID) {
            //if (position != index) {
          //      alert(subscription.CorrectAnswer);
               
                subscription.CorrectAnswer = false;
             //   $('#y' + qid).val(false);
                //}
            }
        });
    }


    $scope.submit = function () {

        var Correct1 = []
        var Iscorrect = 0;
        var IsWrong = 0;



       

       

        var resource = location.protocol + "//" + location.host + "/api/Search/ViewQuestionAndAnswers";
        $http.post(resource, ExamId).success(function (data, status) {




            if (data == null) {
                $scope.isError = true;
                $scope.errormessage = "No Questions Found...";
            } else {
                $scope.isError = false;
  
                $scope.Correct1 = data;

                

              

                angular.forEach($scope.Correct1.Questions, function (value, key) {
                    var u_op1 = false;
                    var u_op2 = false;
                    var u_op3 = false;
                    var u_op4 = false;

                    var _op1 = false;
                    var _op2 = false;
                    var _op3 = false;
                    var _op4 = false;
                    var Qid = value.QuesId;
                  
                 //   alert(Qid);
                    var count = 0;
                    for (var i in $scope.Correct1.Answers) {
                       
                        if (Qid == $scope.Correct1.Answers[i].QuesId && Qid == $scope.ViewAllQuestionAndAnswers.Answers[i].QuesId){

                        count++;

                            var r = $scope.Correct1.Answers[i].CorrectAnswer;
                            var r1 = $scope.ViewAllQuestionAndAnswers.Answers[i].CorrectAnswer;

                       //     alert(Qid + ":  Api " + $scope.Correct1.Answers[i].CorrectAnswer + " User:" + $scope.ViewAllQuestionAndAnswers.Answers[i].CorrectAnswer);
                        //    alert($scope.Correct1.Answers[i].CorrectAnswer);
                         //   alert($scope.ViewAllQuestionAndAnswers.Answers[i].CorrectAnswer);

                            if (count == 1){
                                u_op1 = $scope.ViewAllQuestionAndAnswers.Answers[i].CorrectAnswer;
                                _op1 = $scope.Correct1.Answers[i].CorrectAnswer;
                              //  alert(Qid + " c1")
                              
                            }

                            if (count == 2) {
                                u_op2 = $scope.ViewAllQuestionAndAnswers.Answers[i].CorrectAnswer;
                                _op2 = $scope.Correct1.Answers[i].CorrectAnswer;
                            //    alert(Qid + " c2")
                            }
                            if (count == 3) {
                                u_op3 = $scope.ViewAllQuestionAndAnswers.Answers[i].CorrectAnswer;
                                _op3 = $scope.Correct1.Answers[i].CorrectAnswer;
                             //   alert(Qid + " c3")
                            }
                            if (count == 4) {
                                u_op4 = $scope.ViewAllQuestionAndAnswers.Answers[i].CorrectAnswer;
                                _op4 = $scope.Correct1.Answers[i].CorrectAnswer;
                             //   alert(Qid + " c4")
                            }

                            


                            //if (r == r1) {

                            //    alert(QuesId + " Right Answer");
                            //} else {

                            //    alert(QuesId + " Wrong Answer");
                            //}

                        }

                       



                        //if (u_op1 == _op1 && u_op2 == _op2 && u_op3 == _op3 && u_op4 == _op4) {

                        //    alert(Qid + " Right Answer");
                        //} else {

                        //    alert(Qid + " Wrong Answer");
                        //}


                     //   total += count;


                    }

                    if (u_op1 == _op1 && u_op2 == _op2 && u_op3 == _op3 && u_op4 == _op4) {

                        Iscorrect++;
                //        alert(Qid + " Right Answer");
                    //    alert(Qid + ":\n1 API:" + _op1 + "::User:" + u_op1 + "\n" + "2 API:" + _op2 + "::User:" + u_op2 + "\n" + "3 API:" + _op3 + "::User:" + u_op3 + "\n" + "4 API:" + _op4 + "::User:" + u_op4 + "\n");
                        



                    } else {

                        IsWrong++;
                 //       alert(Qid + " Wrong Answer");

                  //      alert(Qid + ":\n1 API:" + _op1 + "::User:" + u_op1 + "\n" + "2 API:" + _op2 + "::User:" + u_op2 + "\n" + "3 API:" + _op3 + "::User:" + u_op3 + "\n" + "4 API:" + _op4 + "::User:" + u_op4 + "\n");
                     
                    }
                  

                  

                });

                var result = Iscorrect / totalQuestions * 100;

            //    alert("Wrong is: " + IsWrong + " and Right is: " + Iscorrect + ", Total:" + totalQuestions + " % is " + result + "%");


                var data1 = {
                    Username: Username,
                    ExamId: ExamId,
                    TotalWrongAnswers: IsWrong,
                    TotalCorrectAnswers: Iscorrect,
                    Result: result+"%"

                }


     //   $scope.ViewQuestionAndAnswers = function () {

            var resource = location.protocol + "//" + location.host + "/api/Search/InsertResult";
            $http.post(resource, data1).success(function (data, status) {


                if (data = "true") {

                 //   alert("true");

                    $scope.show = false;
                    $scope.submitbtn = false;
                    $scope.next_show = false;
                    $scope.previous_show = false;
                 
                    $scope.TotalQues = totalQuestions;
                    $scope.WrongAns = IsWrong;
                    $scope.CorrectAns = Iscorrect;
                    $scope.per = result;

                    $scope.Isresults = true;
                   
                }


            });


    //    }





                }




           


        });


       

        //angular.forEach($scope.ViewAllQuestionAndAnswers.Answers, function (value, key) {


        //    alert(value.CorrectAnswer);

        //});

        //var jun = $scope.ViewAllQuestionAndAnswers.Answers[0].CorrectAnswer;
        //alert(jun);

        //alert(jun);

        //alert($('#Q1128').val());

        //if ($('#abc1128').attr('checked')) {
        //    alert("fs");
        //}
       

        //$('#abc1128').change(function () {
        //    if ($(this).attr('checked')) {
        //        alert($(this).val('TRUE'));
        //    } else {
        //        alert($(this).val('FALSE'));
        //    }
        //});
    }

  
    $scope.next = function () {
       
        next++;
      
        $scope.show = 'index' + next;
      //  alert(totalQuestions);
        if (next != 1) {
            $scope.previous_show = true;
            $scope.submitbtn = false;








        }
        if (totalQuestions == next) {
            $scope.next_show = false;
            $scope.submitbtn = true;
        }
        //$scope.previous_show = true;
        //previous++;
        
        //var data = {
        //    CourseId: CourseId,
        //    Next: next,
        //    Previous: previous
        //}


        //$scope.ViewQuestionAndAnswers = function () {

        //    var resource = location.protocol + "//" + location.host + "/api/Search/ViewExamQuestion";
        //    $http.post(resource, data).success(function (data, status) {

        //        if (data == null) {
        //            $scope.isError = true;
        //            $scope.errormessage = "No Questions Found...";
        //        } else {
        //            $scope.isError = false;
        //            $scope.ViewQuestionAndAnswers = data;
        //        } 


        //    });


        //}
        //$scope.ViewQuestionAndAnswers();


        angular.forEach($scope.ViewAllQuestionAndAnswers.Questions, function (value, key) {

        //    alert(value.Question);


        });


    }

    $scope.next();



    $scope.previous = function () {

        next--;
        $scope.show = 'index' + next;

        if (next == 1)
            $scope.previous_show = false;

        $scope.next_show = true;
        $scope.submitbtn = false;
        //var data = {
        //    CourseId: CourseId,
        //    Next: next,
        //    Previous: previous
        //}


        //$scope.ViewQuestionAndAnswers = function () {

        //    var resource = location.protocol + "//" + location.host + "/api/Search/ViewExamQuestion";
        //    $http.post(resource, data).success(function (data, status) {

        //        if (data == null) {
        //            $scope.isError = true;
        //            $scope.errormessage = "No Questions Found...";
        //        } else {
        //            $scope.isError = false;
        //            $scope.ViewQuestionAndAnswers = data;
        //        }


        //    });


        //}
        //$scope.ViewQuestionAndAnswers();

    }


  

  
    $scope.ViewQuestionAndAnswers = function () {

      

        var resource = location.protocol + "//" + location.host + "/api/Search/ViewQuestionAndAnswers";
        $http.post(resource, ExamId).success(function (data, status) {




            if (data == null) {
                $scope.isError = true;
                $scope.errormessage = "No Questions Found...";
            } else {
                $scope.isError = false;
                $scope.Correct = data;
                $scope.ViewAllQuestionAndAnswers = data;
               
                totalQuestions = $scope.ViewAllQuestionAndAnswers.Questions.length;
           //     alert($scope.ViewAllQuestionAndAnswers.Questions.length);

                //$scope.ViewAllQuestionAndAnswers.Answers[0].CorrectAnswer = false;


                for (var i in $scope.ViewAllQuestionAndAnswers.Answers) {

                    $scope.ViewAllQuestionAndAnswers.Answers[i].CorrectAnswer = false;

                    //angular.forEach($scope.getAllModules, function (value, key) {

                    //    if (value.ModuleId == ss[i]) {


                    //        path += CourseName + "/Modules/" + value.ModuleName + ",";
                    //        ModuleName += value.ModuleName + ",";
                    //        //   $scope.AddCourseDirectory(path);

                    //    }
                    //});


                }


                //angular.forEach(data.Answers, function (value, key) {


                //    $scope.ViewAllQuestionAndAnswers.Answers.CorrectAnswer = false;

                //});
               

            }

            //var data1 = {

            //    Questions: { Question: [] },
            //    Answers: { Answer: []}
            //}

            //angular.forEach(data.Questions, function (value, key) {

            //    var QId = value.QuesId;

            // //   alert(value.Question);


            //    data1.Question = value.Question;
            //    angular.forEach(data.Answers, function (value1, key) {


            //        if (value1.QuesId == QId) {


            //            data1.Answers = value1.AnswerText;

            //           // alert(value1.AnswerText + "" + value1.CorrectAnswer);


            //        }






            //    });


            // //   alert(data1.Question + " Ans:" + data1.Answers);


            //});



        });


    }


    $scope.ViewQuestionAndAnswers();

  

 
   

    $scope.ok = function () {
        $uibModalInstance.close('ok');
    };


    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

});



courseApp.controller('viewQuesModalInstanceCtrl', function ($scope, $http, $uibModal, $uibModalInstance, ExamId, ExamName) {
    $scope.modalTitle = "View Questions (" + ExamName + ")";

   



    $scope.ViewAllQuestionAndAnswers = [];
    $scope.ViewQuestionAndAnswers = function () {

    
       
        
        var resource = location.protocol + "//" + location.host + "/api/Search/ViewQuestionAndAnswers";
        $http.post(resource, ExamId).success(function (data, status) {


           

            if (data == null) {
                $scope.isError = true;
                $scope.errormessage = "No Questions Found...";
            } else {
                $scope.isError = false;
                $scope.ViewQuestionAndAnswers = data;
            }

            //var data1 = {

            //    Questions: { Question: [] },
            //    Answers: { Answer: []}
            //}

            //angular.forEach(data.Questions, function (value, key) {
              
            //    var QId = value.QuesId;

            // //   alert(value.Question);

               
            //    data1.Question = value.Question;
            //    angular.forEach(data.Answers, function (value1, key) {

                
            //        if (value1.QuesId == QId) {


            //            data1.Answers = value1.AnswerText;

            //           // alert(value1.AnswerText + "" + value1.CorrectAnswer);


            //        }


                  



            //    });


            // //   alert(data1.Question + " Ans:" + data1.Answers);
              

            //});

          
            
        });

      
    }


    $scope.ViewQuestionAndAnswers();

    $scope.deleteQues = function (QuesId) {

     //   alert(ExamId);
        
            if (window.confirm("Are you sure to Delete Question ?")) {
                var resource = location.protocol + "//" + location.host + "/api/Search/deleteQues";
                $http.post(resource, QuesId).success(function (data, status) {
                   
                    if (data = "true") {
                     //   alert("fghf");


                        var resource = location.protocol + "//" + location.host + "/api/Search/ViewQuestionAndAnswers";
                        $http.post(resource, ExamId).success(function (data, status) {




                            if (data == null) {
                                $scope.isError = true;
                                $scope.errormessage = "No Questions Found...";
                                $scope.ViewQuestionAndAnswers = data;
                            } else {
                                $scope.isError = false;
                                $scope.ViewQuestionAndAnswers = data;
                            }
                        });
                       
                      //  $scope.successMessage = "The customer has been removed from Direct mail.";
                     //   $scope.onPropertySearch();
                    }
                })
            }
        
    }



    $scope.EditQues = function (QuesId) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'editQues.html',

            controller: 'editQuesModalInstanceCtrl',
            windowClass: 'app-modal-window',
            size: 'lg',
            resolve: {
                QuesId: function () {
                    return QuesId;
                },
                ViewAllQuestionAndAnswersObj: function () {
                    return $scope.ViewQuestionAndAnswers;
                }

            }
        });



        modalInstance.result.then(
            function handleResolve(response) {
             //   $scope.ViewQuestionAndAnswers;
                //  $scope.getExams();

                var resource = location.protocol + "//" + location.host + "/api/Search/ViewQuestionAndAnswers";
                $http.post(resource, ExamId).success(function (data, status) {




                    if (data == null) {
                        $scope.isError = true;
                        $scope.errormessage = "No Questions Found...";
                    } else {
                        $scope.isError = false;
                        $scope.ViewQuestionAndAnswers = data;
                    }
                });
            },
            function handleReject(error) {
                // alert("Alert rejected!");
            }
        );

    }





    $scope.ok = function () {
        $uibModalInstance.close('ok');
    };


    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

});


courseApp.controller('editQuesModalInstanceCtrl', function ($scope, $http, $uibModalInstance, QuesId, ViewAllQuestionAndAnswersObj) {
    $scope.modalTitle = "Update Question";

    $scope.ans1 = false;
    $scope.ans2 = false;
    $scope.ans3 = false;
    $scope.ans4 = false;

    $scope.ans1Option = "";
    $scope.ans2Option = "";
    $scope.ans3Option = "";
    $scope.ans4Option = "";
    $scope.question = "";
   
    var answerCount = 0;
    var opid1 = -1;
    var opid2 = -1;
    var opid3 = -1;
    var opid4 = -1;
    var ExamId = 0;




    angular.forEach(ViewAllQuestionAndAnswersObj.Questions, function (value, key) {
        

        if (value.QuesId == QuesId) {

        //    alert(value.Question);

            $scope.question = value.Question;
            ExamId = value.ExamId;
           
            $scope.answerType = value.AnswerType;

            angular.forEach(ViewAllQuestionAndAnswersObj.Answers, function (value1, key) {
               

                if (value1.QuesId == QuesId) {
                    answerCount++;
                  //  $scope.ans+answerCount+Option == value1.AnswerText;
                 //   $scope.ans+answerCount == value1.CorrectAnswer;

                  //  alert(answerCount + " "+value1.AnswerText);

                    if (answerCount == 1) {
                        $scope.ans1Option = value1.AnswerText;
                        $scope.ans1 = value1.CorrectAnswer;
                        opid1 = value1.AnswerID;

                        if ($scope.ans1 == true)
                            $scope.option1style = { 'border-color': 'green' };
                        else
                            $scope.option1style = { 'border-color': 'red' };

                    }
                       
                    if (answerCount == 2) {
                        $scope.ans2Option = value1.AnswerText;
                        $scope.ans2 = value1.CorrectAnswer;
                        opid2 = value1.AnswerID;

                        if ($scope.ans2 == true)
                            $scope.option2style = { 'border-color': 'green' };
                        else
                            $scope.option2style = { 'border-color': 'red' };

                    }

                    if (answerCount == 3) {
                        $scope.ans3Option = value1.AnswerText;
                        $scope.ans3 = value1.CorrectAnswer;
                        opid3 = value1.AnswerID;

                        if ($scope.ans3 == true)
                            $scope.option3style = { 'border-color': 'green' };
                        else
                            $scope.option3style = { 'border-color': 'red' };
                        

                    }
                    if (answerCount == 4) {
                        $scope.ans4Option = value1.AnswerText;
                        $scope.ans4 = value1.CorrectAnswer;
                        opid4 = value1.AnswerID;

                        if ($scope.ans4 == true)
                            $scope.option4style = { 'border-color': 'green' };
                        else
                            $scope.option4style = { 'border-color': 'red' };

                    }

                  
                        

                ///         alert(value1.AnswerText + " " + value1.CorrectAnswer);


                    }

                });


        }


             //   var QId = value.QuesId;

             ////   alert(value.Question);


             //   data1.Question = value.Question;
             //   angular.forEach(data.Answers, function (value1, key) {


             //       if (value1.QuesId == QId) {


             //           data1.Answers = value1.AnswerText;

             //           // alert(value1.AnswerText + "" + value1.CorrectAnswer);


             //       }

             //   });


             ////   alert(data1.Question + " Ans:" + data1.Answers);


            });







    $scope.OnCheck = function () {

        if ($scope.ans1 == true)
            $scope.option1style = { 'border-color': 'green' };
        else
            $scope.option1style = { 'border-color': 'red' };


        if ($scope.ans2 == true)
            $scope.option2style = { 'border-color': 'green' };
        else
            $scope.option2style = { 'border-color': 'red' };


        if ($scope.ans3 == true)
            $scope.option3style = { 'border-color': 'green' };
        else
            $scope.option3style = { 'border-color': 'red' };

        if ($scope.ans4 == true)
            $scope.option4style = { 'border-color': 'green' };
        else
            $scope.option4style = { 'border-color': 'red' };
    }


    $scope.EditQues = function () {

        var answerType = $("#answerType").val();


        //  alert($scope.answerType + "");

        var op1_ans1 = $scope.ans1Option + "‰" + $scope.ans1 + "œ" + opid1;
        var op2_ans2 = $scope.ans2Option + "‰" + $scope.ans2 + "œ" + opid2;
        var op3_ans3 = $scope.ans3Option + "‰" + $scope.ans3 + "œ" + opid3;
        var op4_ans4 = $scope.ans4Option + "‰" + $scope.ans4 + "œ" + opid4;




        var data1 = {
            QuestionText: $scope.question,
            AnswerType: $scope.answerType,
            AnswerText: op1_ans1 + "‡" + op2_ans2 + "‡" + op3_ans3 + "‡" + op4_ans4,
            QuesId: QuesId,
            ExamId: ExamId
        };


        if ($scope.question != "" && $scope.answerType != undefined && ($scope.ans1Option != "" || $scope.ans2Option != "" || $scope.ans3Option != "" || $scope.ans4Option != "")) {

         //   alert("true" + opid1 + " " + opid2 + " " + opid3 + " " + opid4);


          
            var resource = location.protocol + "//" + location.host + "/api/Search/EditQues";
            $http.post(resource, data1).success(function (data, status) {

                if (data = "true") {

                    $scope.isError = false;
                    $scope.isSuccess = true;
                    $scope.successMessage = "Questions Successfully Updated...";
                  
                    
                    $uibModalInstance.close('saved');

                  
                }
            });

        } else {
            $scope.isSuccess = false;
            $scope.isError = true;
            $scope.errormessage = "All Fields Are Required And Atleast 1 Option Required..";
        }
    }



    $scope.ok = function () {
        $uibModalInstance.close('ok');
    };


    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };


});


courseApp.controller('addQuesModalInstanceCtrl', function ($scope, $http, $uibModalInstance, ExamId, ExamName) {
    $scope.modalTitle = "Add Question (" + ExamName + ")"  ;

    
   // $scope.getAllCourses = courses;
    $scope.ans1 = false;
    $scope.ans2 = false;
    $scope.ans3 = false;
    $scope.ans4 = false;

    $scope.ans1Option = "";
    $scope.ans2Option = "";
    $scope.ans3Option = "";
    $scope.ans4Option = "";
    $scope.question = "";


    $scope.OnCheck = function () {

        if ($scope.ans1 == true) 
            $scope.option1style = { 'border-color': 'green' };
        else
            $scope.option1style = { 'border-color': 'red' };


        if ($scope.ans2 == true)
            $scope.option2style = { 'border-color': 'green' };
        else
            $scope.option2style = { 'border-color': 'red' };


        if ($scope.ans3 == true)
            $scope.option3style = { 'border-color': 'green' };
        else
            $scope.option3style = { 'border-color': 'red' };

        if ($scope.ans4 == true)
            $scope.option4style = { 'border-color': 'green' };
        else
            $scope.option4style = { 'border-color': 'red' };
    }
  

    $scope.InsertQues = function () {

        var answerType = $("#answerType").val();

       
      //  alert($scope.answerType + "");

        var op1_ans1 = $scope.ans1Option + "‰" + $scope.ans1;
        var op2_ans2 = $scope.ans2Option + "‰" + $scope.ans2;
        var op3_ans3 = $scope.ans3Option + "‰" + $scope.ans3;
        var op4_ans4 = $scope.ans4Option + "‰" + $scope.ans4;

        


        var data1 = {
            QuestionText: $scope.question,
            AnswerType: $scope.answerType,
            AnswerText: op1_ans1 + "‡" + op2_ans2 + "‡" + op3_ans3 + "‡" + op4_ans4,
            ExamId: ExamId
        };

       
        //alert($scope.answerType);

        //if ($scope.answerType != undefined) {
        //    alert("sadf");
        //} else {
        //    alert("dsadfff");
        //}

         if ($scope.question != "" && $scope.answerType != undefined && ($scope.ans1Option != "" || $scope.ans2Option != "" || $scope.ans3Option != "" || $scope.ans4Option != "")) {

        var resource = location.protocol + "//" + location.host + "/api/Search/InsertQues";
        $http.post(resource, data1).success(function (data, status) {

            if (data = "true") {

                $scope.isError = false;
                $scope.isSuccess = true;
                $scope.successMessage = "Questions Successfully Added...";
                $scope.question = "";
                $scope.answerType = undefined;
                $scope.ans1Option = "";
                $scope.ans2Option = "";
                $scope.ans3Option = "";
                $scope.ans4Option = "";
              //$scope.ExamName = '';
              //$uibModalInstance.close('saved');

            }
        });

        } else {
            $scope.isSuccess = false;
            $scope.isError = true;
            $scope.errormessage = "All Fields Are Required And Atleast 1 Option Required..";
        }
    }



    $scope.ok = function () {
        $uibModalInstance.close('ok');
    };


    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };


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

