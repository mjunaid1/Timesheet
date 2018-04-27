timesheetApp.controller("timesheetController", function timesheetController($scope, $window, $http, $filter, $timeout, $log, $uibModal) {
    $scope.Author = "Umais Siddiqui";
    $scope.UserName = "";
    $scope.role = [];
    $scope.test = function () { alert("Testing"); };
    var promise = $timeout(function () {
        $scope.UserName = $('#UserName').val();
        $scope.role = $('#role').val();

        if ($scope.role == 1) {
          
            $scope.getCompany();
            $scope.getEmployees();
            $scope.getCompanyEmployees();
            $scope.getProjects();
            $scope.GetSubmittedTimeSheets();
            if ($('#paramid').val() != undefined) {
                $scope.getTimePeriodsPerId();
                $scope.GetTimeSheetDetails();
            }
         
        } else if ($scope.role == 2) {
            $scope.getTimePeriods();
            if ($('#paramid').val() != undefined) {
                $scope.getTimePeriodsPerId();
                $scope.GetTimeSheetDetails();
            }
        } 



    })


    

    $scope.getUsersRole = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/CheckUser";
        var user = $('#UserName').val();

        var data = {
            UserName: user
        };


        $http.post(resource, data).success(function (data, status) {
            if (data.Role == 1) {
                $scope.isStudent = false;
                $scope.isTeacher = false;
                $scope.isAdmin = true;


            } else if (data.Role == 2) {
                $scope.isAdmin = false;
                $scope.isTeacher = false;
                $scope.isStudent = true;



            } else if (data.Role == 3) {
                $scope.isStudent = false;
                $scope.isAdmin = false;
                $scope.isTeacher = true;


            }

            $scope.role = data.Role;

        })
            .error(function (data, status) {
                // this isn't happening:
            })



    }

    $scope.getUsersRole();


    $scope.AddCompany = function () {


        var data1 = {
            CompanyName: $scope.CompanyName,

        };
      

        if ($scope.CompanyName && $scope.CompanyName != undefined) {
            var resource = location.protocol + "//" + location.host + "/api/Search/AddCompany";
            $http.post(resource, data1).success(function (data, status) {
                if (data = "true") {
                    $scope.isError = false;
                    $scope.isSuccess = true;
                    $scope.successMessage = "Company Successfully Added...";
                    $scope.CompanyName = "";
                    $scope.getCompany();
                   
                }
            });
        } else {
            $scope.isError = true;
            $scope.isSuccess = false;
            $scope.errormessage = "All Fields Are Required..";
        }

    }


    $scope.Obj_getCompany = [];

    $scope.getCompany = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/getCompany";

        $http.get(resource).success(function (data, status) {
            $scope.Obj_getCompany = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }

    $scope.Obj_getEmployees = [];

    $scope.getEmployees = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/getEmployees";

        $http.get(resource).success(function (data, status) {
            $scope.Obj_getEmployees = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }
   
    $scope.AddCompanyEmployees = function () {

       var CompanyID = $("#selectedCompany").val();
       var CheckEmp_id = $("#selectedEmployees").val();


         //  $('#selectedCompany option:selected').text("? undefined:undefined ?")
         //  $('#selectedCompany option:eq(2)').attr('selected', true);

       if (CompanyID != "? undefined:undefined ?" && CheckEmp_id != null ){
           var Emp_id = $("#selectedEmployees").val().toString();
        
        var data1 = {
            CompanyId: CompanyID,
            EmployeeId: Emp_id

        };


        var resource = location.protocol + "//" + location.host + "/api/Search/AddCompanyEmployees";
            $http.post(resource, data1).success(function (data, status) {
                if (data = "true") {

                    $scope.isError = false;
                    $scope.isSuccess = true;
                    $scope.successMessage = "Records Successfully Added...";
                    $scope.getCompanyEmployees();

                }
            });


       } else {
          
            $scope.isError = true;
            $scope.isSuccess = false;
            $scope.errormessage = "All Fields Are Required..";

       }

    }


    
    $scope.Obj_getCompanyEmployees = [];

    $scope.getCompanyEmployees = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetCompanyEmployees";

        $http.get(resource).success(function (data, status) {
            $scope.Obj_getCompanyEmployees = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }


    
    $scope.AddProject = function () {

        var CompanyID = $("#selectedCompany").val();

        var data1 = {
            ProjectName: $scope.ProjectName,
            CompanyId: CompanyID

        };


        if ($scope.ProjectName && $scope.ProjectName != undefined && CompanyID != "? undefined:undefined ?") {
            var resource = location.protocol + "//" + location.host + "/api/Search/AddProject";
            $http.post(resource, data1).success(function (data, status) {
                if (data = "true") {
                    $scope.isError = false;
                    $scope.isSuccess = true;
                    $scope.successMessage = "Project Successfully Added...";
                    $scope.ProjectName = "";
                    $scope.getProjects();

                }
            });
        } else {
            $scope.isError = true;
            $scope.isSuccess = false;
            $scope.errormessage = "All Fields Are Required..";
        }

    }



    $scope.Obj_getProjects = [];

    $scope.getProjects = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetProjects";

        $http.get(resource).success(function (data, status) {
            $scope.Obj_getProjects = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }





    $scope.addTimeRows = function () {


        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'addTimeRows.html',

            controller: 'addTimeRowsModalInstanceCtrl',
            windowClass: 'app-modal-window',
            size: '',
            resolve: {
                Username: function() {
                    return $scope.UserName;

                },
                GetDatePeriod: function () {
                    return $scope.datesdata;

                }, TimePeriodId: function () {
                    return $('#paramid').val();

                }
            }
        });



        modalInstance.result.then(
            function handleResolve(response) {
                $scope.GetTimeSheetDetails();
                $scope.getTimePeriodsPerId();
            },
            function handleReject(error) {

               
            }
        );




    }

    $scope.addTimePriods = function () {


        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'addTimePriods.html',

            controller: 'addTimePriodsModalInstanceCtrl',
            windowClass: 'app-modal-window',
            size: '',
            resolve: {
                Username: function () {
                    return $scope.UserName;

                }
            }
        });



        modalInstance.result.then(
            function handleResolve(response) {
                $scope.getTimePeriods();
            },
            function handleReject(error) {


            }
        );




    }


    $scope.Obj_getTimePeriods = [];
 
    $scope.getTimePeriods = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetTimePeriods";
        var data = {
            UserName: $scope.UserName
        }
        $http.post(resource, data).success(function (data, status) {
            $scope.Obj_getTimePeriods = data;
          
      

        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }


    $scope.Obj_getTimePeriodsPerId = [];

    $scope.getTimePeriodsPerId  = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetTimePeriodsPerId";
        if ($scope.role == 1) {
       //     alert($('#User').val() + "  "+ $('#paramid').val())
            var data = {
                UserName: $('#User').val(),
                TimePeriodId: $('#paramid').val()
            }

        } else {
            var data = {
                UserName: $scope.UserName,
                TimePeriodId: $('#paramid').val()
            }

        }
       
        $http.post(resource, data).success(function (data, status) {
            $scope.Obj_getTimePeriodsPerId = data;

         
            var ss = data[0].TimePeriods.split("-");

         //   alert(ss);
            //for (var i in ss) {

           
            //    alert(ss[i]);

            //} 

            var s = ss[0];
            var s2 = ss[1];

        //    alert(s + "  " +s2);

            var start = new Date(s);
            var end = new Date(s2);
            var newend = end.setDate(end.getDate() + 1);
            var end = new Date(newend);
            var count = 0;
            var datedata = [];


            while (start < end) {
                //  alert(new Date(start).getTime() / 1000); // unix timestamp format
              // ISO Date format 
         //       alert("loop: " + start); 

              

                var newDate = start.setDate(start.getDate() + 1);
                start = new Date(newDate);

                datedata[count] = new Date(start - 1);
                count = count + 1;
            }

            $scope.datesdata = datedata;


            var days1 = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
            var ShortDays = [];

            angular.forEach($scope.datesdata, function (value1, key) {
                var d = new Date(value1);
                var dayName = days1[d.getDay()];
                ShortDays[key] = dayName;

               // alert("d");

            });

            $scope.Short = ShortDays;


         //   alert("object: "+datedata)
        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }


    $scope.Obj_getTimeSheetDetails = [];

    $scope.GetTimeSheetDetails = function () {

     

        var resource = location.protocol + "//" + location.host + "/api/Search/GetTimeSheetDetails";
        var data = {
            TimePeriodId: $('#paramid').val()
        }
        $http.post(resource, data).success(function (data, status) {
            $scope.Obj_getTimeSheetDetails = data;


            //var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

          

           

            //    angular.forEach(data, function (value, key) {
            //        alert("1")
            //        angular.forEach($scope.datesdata, function (value1, key) {

            //            var d = new Date(value1);
            //            var dayName = days[d.getDay()];
            //          //  alert(dayName)

            //        if (dayName == "Mon")
            //        {
            //            alert("Mon:" + value.Mon)
            //        }


            //        if (dayName == "Tue") {
            //            alert("Tue:" + value.Tue)
            //        }


            //        if (dayName == "Wed") {

            //            alert("Wed:" + value.Wed)
            //        }
            //        if (dayName == "Thu") {
            //            alert("Thu:" + value.Thu)

            //        }
            //        if (dayName == "Fri") {
            //            alert("Fri:" + value.Fri)
            //        }
            //        if (dayName == "Sat") {
            //            alert("Sat:" + value.Sat)
            //        }
            //        if (dayName == "Sun") {
            //            alert("Sun:" + value.Sun)
            //        }


            //    });


            //});
     

            //   alert("object: "+datedata)
        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }
  //  alert($('#paramid').val());


  //  alert($scope.Obj_getTimePeriodsPerId[0].TimePeriods)


    $scope.SubmitTimeSheet = function () {
        var des = $("#shortDescription1d").val();

       // alert(des);

        var resource = location.protocol + "//" + location.host + "/api/Search/SubmitTimeSheet";
        var data = {
            Description: des,
            TimePeriodId: $('#paramid').val()
        }
        $http.post(resource, data).success(function (data, status) {
            if (data = "true") {
                $scope.getTimePeriodsPerId();

            }
        });

    }

    
    $scope.Obj_GetSubmittedTimeSheets = [];

    $scope.GetSubmittedTimeSheets = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/GetSubmittedTimeSheets";
      
        $http.get(resource).success(function (data, status) {
            $scope.Obj_GetSubmittedTimeSheets = data;



        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }

    $scope.SaveAdminTimeSheet = function () {

        var TimePeriodId = 0;
        var ProjectId = 0;
        var Mon = "00:00:00";
        var Tue = "00:00:00";
        var Wed = "00:00:00";
        var Thu = "00:00:00";
        var Fri = "00:00:00";
        var Sat = "00:00:00";
        var Sun = "00:00:00";


        //angular.forEach($scope.datesdata, function (value1, key) {
        //    alert(value1)
        //});
        var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

        angular.forEach($scope.Obj_getTimeSheetDetails, function (value, key) {
          //  alert(value.CompanyName)
            TimePeriodId = value.TimePeriodId;
            ProjectId = value.ProjectId
                    angular.forEach($scope.datesdata, function (value1, key1) {

                      //  alert(value1)

                        var d = new Date(value1);
                        var dayName = days[d.getDay()];
                     //   alert(dayName)

                      

                    if (dayName == "Mon")
                    {
                        //alert("Mon:" + value.Mon)
                    //    alert($("#Mon" + key + key1).val());
                        Mon = $("#Mon" + key + key1).val();
                    }


                    if (dayName == "Tue") {
                       // alert("Tue:" + value.Tue)
                     //   alert($("#Tue" + key + key1).val());
                        Tue = $("#Tue" + key + key1).val();
                    }


                    if (dayName == "Wed") {

                       // alert("Wed:" + value.Wed)
                      //  alert($("#Wed" + key + key1).val());
                        Wed = $("#Wed" + key + key1).val();
                    }
                    if (dayName == "Thu") {
                      //  alert("Thu:" + value.Thu)
                    //    alert($("#Thu" + key + key1).val());
                        Thu = $("#Thu" + key + key1).val();

                    }
                    if (dayName == "Fri") {
                      //  alert("Fri:" + value.Fri)
                    //    alert($("#Fri" + key + key1).val());
                        Fri = $("#Fri" + key + key1).val(); 
                    }
                    if (dayName == "Sat") {
                      //  alert("Sat:" + value.Sat)
                    //    alert($("#Sat" + key + key1).val());
                        Sat = $("#Sat" + key + key1).val();
                    }
                    if (dayName == "Sun") {
                       // alert("Sun:" + value.Sun)
                    //    alert($("#Sun" + key + key1).val());
                        Sun = $("#Sun" + key + key1).val();
                    }


                });

                    var data = {
                        TimePeriodId: TimePeriodId,
                        Mon: Mon,
                        Tue: Tue,
                        Wed: Wed,
                        Thu: Thu,
                        Fri: Fri,
                        Sat: Sat,
                        Sun: Sun,
                        ProjectId: ProjectId

                    }

                    var resource = location.protocol + "//" + location.host + "/api/Search/SaveAdminTimeSheet";
                    $http.post(resource, data).success(function (data, status) {
                        if (data = "true") {
                            $scope.isError = false;
                            $scope.isSuccess = true;
                            $scope.successMessage = "Successfully Updated...";
                            $scope.getTimePeriodsPerId();
                        }
                    });

                //    alert(TimePeriodId +": Mon="+Mon+" Tue="+Tue+" Wed="+Wed+" Thu="+Thu+" Fri="+Fri+" Sat="+Sat+" Sun="+Sun);

            });

       // $scope.GetTimeSheetDetails();
       // alert("Mon:"+Mon+" Tue:"+Tue+" Wed:"+Wed);

      
    
    }

    $scope.deleteTimePeriods = function (TimePeriodId) {

        var data = {
            TimePeriodId: TimePeriodId

        }

        if (window.confirm("Are you sure to Delete Time Periods ?")) {
            var resource = location.protocol + "//" + location.host + "/api/Search/DeleteTimePeriods";
            $http.post(resource, data).success(function (data, status) {
                if (data = "true") {

                    $scope.getTimePeriods();
                }
            });
        }
    }

});


timesheetApp.controller('addTimePriodsModalInstanceCtrl', function ($scope, $http, $filter , $uibModal, $uibModalInstance, Username) {
    $scope.modalTitle = "Add Time Periods";

    $scope.AddTimePeriods = function () {
        var startdate = $filter('date')($scope.startdate, 'MM/dd/yyyy');
        var enddate = $filter('date')($scope.enddate, 'MM/dd/yyyy');

        var date_diff_indays = function (date1, date2) {
            dt1 = new Date(date1);
            dt2 = new Date(date2);
            return Math.floor((Date.UTC(dt2.getFullYear(), dt2.getMonth(), dt2.getDate()) - Date.UTC(dt1.getFullYear(), dt1.getMonth(), dt1.getDate())) / (1000 * 60 * 60 * 24));
        }
      


        if ((startdate != undefined || startdate != null) && (enddate != undefined || enddate != null)) {

            if (date_diff_indays(startdate, enddate) <= 6) {


                console.log(date_diff_indays(startdate, enddate));


                var data = {
                    TimePeriods: startdate + "-" + enddate,
                    UserName: Username
                }


            var resource = location.protocol + "//" + location.host + "/api/Search/AddTimePeriods";
            $http.post(resource, data).success(function (data, status) {
                if (data = "true") {
                    $uibModalInstance.close('ok');

                }
            });





            } else {
                $scope.isError = true;
                $scope.isSuccess = false;
                $scope.errormessage = "Time Periods Should be in 7 Days...";
            }

         

        

           
           


          


        } else {

            $scope.isError = true;
            $scope.isSuccess = false;
            $scope.errormessage = "All Fields Are Required..";
        }

    }

    $scope.ok = function () {
        $uibModalInstance.close('ok');
    };


    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

});


timesheetApp.controller('addTimeRowsModalInstanceCtrl', function ($scope, $filter, $http, $uibModal, $uibModalInstance, Username, GetDatePeriod, TimePeriodId) {
    $scope.modalTitle = "Add Time Rows";
   
    $scope.datesdata = GetDatePeriod;
    var data = {

        Username: Username
    }

    $scope.Obj_getCompany = [];

    $scope.getCompanyPerEmp = function () {
        var resource = location.protocol + "//" + location.host + "/api/Search/getCompanyPerEmp";

        $http.post(resource,data).success(function (data, status) {
            $scope.Obj_getCompany = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }

    $scope.changeCompany = function () {


      //  alert($scope.selectedCompany);
        var data = {

            CompanyId: $scope.selectedCompany
        }

        var resource = location.protocol + "//" + location.host + "/api/Search/GetProjectsPerCompany";

        $http.post(resource, data).success(function (data, status) {
            $scope.Obj_getProjects = data;

        })
            .error(function (data, status) {
                // this isn't happening:
            })


    }

    $scope.getCompanyPerEmp();


    $scope.addWorkingHours = function () {

        var CompanyID = $("#selectedCompany").val();
        var ProjectID = $("#selectedProject").val(); 
        var CurrentDate = $("#selectedCurrentDate").val();
        var Hours = $scope.hours;

        if (CompanyID != "? undefined:undefined ?" && ProjectID != "? undefined:undefined ?" && CurrentDate != "? undefined:undefined ?" && Hours != undefined && Hours != "") {

          //  alert(CompanyID + ": " + ProjectID + ": " + CurrentDate + ": " + Hours);


            var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
            var d = new Date(CurrentDate);
            var dayName = days[d.getDay()];
       
            var startdate = new Date(CurrentDate).getDay();
            
           // var startdate = $filter('date')(CurrentDate, 'EEE');
          //  alert(dayName);

            var data = {

                TimePeriodId: TimePeriodId,
                ProjectId: ProjectID,
                Date: CurrentDate,
                Hours: Hours + ":00",
                Day: dayName

            }

            var resource = location.protocol + "//" + location.host + "/api/Search/addWorkingHours";

            $http.post(resource, data).success(function (data, status) {
                if (data = "true") {
                    $scope.isError = false;
                    $scope.isSuccess = true;
                    $scope.successMessage = "Successfully Added...";
                    $uibModalInstance.close('ok');
                }

            })
                .error(function (data, status) {
                    // this isn't happening:
                })



        } else {

            $scope.isError = true;
            $scope.isSuccess = false;
            $scope.errormessage = "Required All Fields...";
        }

      
    }


    $scope.ok = function () {
        $uibModalInstance.close('ok');
    };


    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

});
