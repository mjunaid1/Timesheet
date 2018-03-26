using Courses.Entities.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Entities
{
        public class CompanyModel
        {
            public long CompanyId { get; set; }
            public string CompanyName { get; set; }


            public CompanyModel(IDataReader dbReader)
            {
                if (dbReader == null) return;
                if (dbReader.HasColumn("CompanyId") && dbReader["CompanyId"] != DBNull.Value) CompanyId = (long)dbReader["CompanyId"];
                if (dbReader.HasColumn("CompanyName") && dbReader["CompanyName"] != DBNull.Value) CompanyName = (string)dbReader["CompanyName"];


            }
        }

        public class Employees
        {
            public string Id { get; set; }
            public string Username { get; set; }
            public int Role { get; set; }




            public Employees(IDataReader dbReader)
            {
                if (dbReader == null) return;
                if (dbReader.HasColumn("UserName") && dbReader["UserName"] != DBNull.Value) Username = (string)dbReader["UserName"];
                if (dbReader.HasColumn("Id") && dbReader["Id"] != DBNull.Value) Id = (string)dbReader["Id"];
                if (dbReader.HasColumn("role") && dbReader["role"] != DBNull.Value) Role = (int)dbReader["role"];

            }

            public Employees()
            {


            }
        }

        public class CompanyEmployees
        {
            public string EmployeeId { get; set; }
            public long CompanyId { get; set; }

            public string CompanyName { get; set; }
            public string UserName { get; set; } 



        public CompanyEmployees(IDataReader dbReader)
            {
                if (dbReader == null) return;
                if (dbReader.HasColumn("EmployeeId") && dbReader["EmployeeId"] != DBNull.Value) EmployeeId = (string)dbReader["EmployeeId"];
                if (dbReader.HasColumn("CompanyId") && dbReader["CompanyId"] != DBNull.Value) CompanyId = (long)dbReader["CompanyId"];
                if (dbReader.HasColumn("CompanyName") && dbReader["CompanyName"] != DBNull.Value) CompanyName = (string)dbReader["CompanyName"];
                if (dbReader.HasColumn("UserName") && dbReader["UserName"] != DBNull.Value) UserName = (string)dbReader["UserName"];


             }


        }

        public class ProjectModel
        {
         
            public long ProjectId { get; set; }
            public string ProjectName { get; set; }
            public long CompanyId { get; set; }
            public string CompanyName { get; set; }
            public DateTime Created { get; set; }


        public ProjectModel(IDataReader dbReader)
            {
                if (dbReader == null) return;
                if (dbReader.HasColumn("ProjectId") && dbReader["ProjectId"] != DBNull.Value) ProjectId = (long)dbReader["ProjectId"];
                if (dbReader.HasColumn("ProjectName") && dbReader["ProjectName"] != DBNull.Value) ProjectName = (string)dbReader["ProjectName"];
                if (dbReader.HasColumn("CompanyId") && dbReader["CompanyId"] != DBNull.Value) CompanyId = (long)dbReader["CompanyId"];
                if (dbReader.HasColumn("Created") && dbReader["Created"] != DBNull.Value) Created = (DateTime)dbReader["Created"];
                if (dbReader.HasColumn("CompanyName") && dbReader["CompanyName"] != DBNull.Value) CompanyName = (string)dbReader["CompanyName"];



        }


        }

}
