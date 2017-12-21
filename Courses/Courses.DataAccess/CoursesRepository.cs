using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.DataAccess
{
    public class CoursesRepository
    {
        protected string CoursesConnectionString { get; set; }
        public CoursesRepository()
        {
            CoursesConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public CoursesRepository(string connection)
        {
            CoursesConnectionString = connection;
        }

        public bool InsertStudent()
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "insert into [Courses] (CourseName, CourseDuration , CourseStartDate) values ('xyz','1 month','2018-01-01')";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
    }
}
