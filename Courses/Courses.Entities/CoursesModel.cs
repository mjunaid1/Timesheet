using Courses.Entities.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Entities
{
    public class CoursesModel
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDuration { get; set; }
        public DateTime CourseStartDate { get; set; }


        public CoursesModel(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("CourseID") && dbReader["CourseID"] != DBNull.Value) CourseID = (int)dbReader["CourseID"];
            if (dbReader.HasColumn("CourseName") && dbReader["CourseName"] != DBNull.Value) CourseName = (string)dbReader["CourseName"];
            if (dbReader.HasColumn("CourseDuration") && dbReader["CourseDuration"] != DBNull.Value) CourseDuration = (string)dbReader["CourseDuration"];
            if (dbReader.HasColumn("CourseStartDate") && dbReader["CourseStartDate"] != DBNull.Value) CourseStartDate = (DateTime)dbReader["CourseStartDate"];

        }
    }

    public class Modules
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }

        public string CourseName { get; set; }

        public Modules(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("ModuleId") && dbReader["ModuleId"] != DBNull.Value) ModuleId = (int)dbReader["ModuleId"];
            if (dbReader.HasColumn("ModuleName") && dbReader["ModuleName"] != DBNull.Value) ModuleName = (string)dbReader["ModuleName"];
            if (dbReader.HasColumn("CourseName") && dbReader["CourseName"] != DBNull.Value) CourseName = (string)dbReader["CourseName"];

        }

    }

    public class CourseModules
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ModuleId { get; set; }
        public string ModuleName { get; set; }

        public int GetModuleId { get; set; }
        public string Username { get; set; }

        public CourseModules(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("CourseId") && dbReader["CourseId"] != DBNull.Value) CourseId = (int)dbReader["CourseId"];
            if (dbReader.HasColumn("CourseName") && dbReader["CourseName"] != DBNull.Value) CourseName = (string)dbReader["CourseName"];
            if (dbReader.HasColumn("ModuleId") && dbReader["ModuleId"] != DBNull.Value) GetModuleId = (int)dbReader["ModuleId"];
            if (dbReader.HasColumn("ModuleName") && dbReader["ModuleName"] != DBNull.Value) ModuleName = (string)dbReader["ModuleName"];


        }

    }


    public class UserCourses
    {
        public string StudentId { get; set; }
        public string Username { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }

        public int GetCourseId { get; set; }

        public UserCourses(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("StudentId") && dbReader["StudentId"] != DBNull.Value) StudentId = (string)dbReader["StudentId"];
            if (dbReader.HasColumn("Email") && dbReader["Email"] != DBNull.Value) Username = (string)dbReader["Email"];
            if (dbReader.HasColumn("CourseId") && dbReader["CourseId"] != DBNull.Value) GetCourseId = (int)dbReader["CourseId"];
            if (dbReader.HasColumn("CourseName") && dbReader["CourseName"] != DBNull.Value) CourseName = (string)dbReader["CourseName"];


        }

    }

    public class Students
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }

        public Students()
        {
         

        }


        public Students(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("UserName") && dbReader["UserName"] != DBNull.Value) Username = (string)dbReader["UserName"];
            if (dbReader.HasColumn("Id") && dbReader["Id"] != DBNull.Value) Id = (string)dbReader["Id"];
            if (dbReader.HasColumn("role") && dbReader["role"] != DBNull.Value) Role = (int)dbReader["role"];

        }

    }
}
