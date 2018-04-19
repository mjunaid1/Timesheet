using Courses.DataAccess;
using Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Courses.Controllers
{
    public class TimesheetController : ApiController
    {
        [HttpPost]
        public Employees CheckUser([FromBody]Employees s)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.CheckUser(s);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public bool AddCompany([FromBody]CompanyModel Model)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var Result = _searchRepository.AddCompany(Model);
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet]
        public List<CompanyModel> GetCompany()
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.GetCompany();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public List<Employees> GetEmployees()
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.GetEmployees();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public bool AddCompanyEmployees([FromBody]CompanyEmployees Model)
        {
            try
            {


                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var Result = _searchRepository.AddCompanyEmployees(Model);
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public List<CompanyEmployees> GetCompanyEmployees()
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.GetCompanyEmployees();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        public bool AddProject([FromBody]ProjectModel Model)
        {
            try
            {


                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var Result = _searchRepository.AddProject(Model);
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet] 
        public List<ProjectModel> GetProjects()
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.GetProjects();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        [HttpPost]
        public List<CompanyModel> getCompanyPerEmp(Employees Model)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.getCompanyPerEmp(Model.Username);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost] 
        public List<ProjectModel> GetProjectsPerCompany(CompanyModel Model)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.GetProjectsPerCompany(Model.CompanyId);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public bool AddTimePeriods([FromBody]TimesheetModel Model)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var Result = _searchRepository.AddTimePeriods(Model);
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public List<TimesheetModel> GetTimePeriods(TimesheetModel Model)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.GetTimePeriods(Model.UserName);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
      [HttpPost]
        public List<TimesheetModel> GetTimePeriodsPerId(TimesheetModel Model)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.GetTimePeriodsPerId(Model.UserName,Model.TimePeriodId);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost] 
        public bool addWorkingHours([FromBody]WorkingHours Model)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var Result = _searchRepository.addWorkingHours(Model);
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        [HttpPost]
        public List<WorkingHours> GetTimeSheetDetails(WorkingHours Model)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.GetTimeSheetDetails(Model.TimePeriodId);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost] 
        public bool SubmitTimeSheet([FromBody]TimesheetModel Model)
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var Result = _searchRepository.SubmitTimeSheet(Model);
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public List<TimesheetModel> GetSubmittedTimeSheets()
        {
            try
            {
                TimesheetRepositrory _searchRepository = new TimesheetRepositrory();
                var result = _searchRepository.GetSubmittedTimeSheets();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
