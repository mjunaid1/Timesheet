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


        public Modules(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("ModuleId") && dbReader["ModuleId"] != DBNull.Value) ModuleId = (int)dbReader["ModuleId"];
            if (dbReader.HasColumn("ModuleName") && dbReader["ModuleName"] != DBNull.Value) ModuleName = (string)dbReader["ModuleName"];
           

        }

    }

    public class CourseModules
    {
        public int CourseId { get; set; }
        public string ModuleId { get; set; }



    }

    public class Students
    {
       
        public string Username { get; set; }

        public Students(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("UserName") && dbReader["UserName"] != DBNull.Value) Username = (string)dbReader["UserName"];


        }

    }
}
