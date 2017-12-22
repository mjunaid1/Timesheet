using Courses.Entities;
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

        public bool UpdateRole(string role, string email)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "  update [AspNetUsers] set role = "+role+" where Email =  '"+email+"'";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }



        public bool AddCourse(CoursesModel Model)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "insert into [Courses] (CourseName, CourseDuration , CourseStartDate) values ('"+ Model.CourseName+ "','"+ Model.CourseDuration + "','"+ Model.CourseStartDate + "')";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    
                }

                return true;
            }
        }

        public bool AddModules(Modules Model)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "insert into [Modules] (ModuleName) values ('" + Model.ModuleName +  "')";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }

                return true;
            }
        }

       
        public List<CoursesModel> GetCourses()
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "select * from [Courses]";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<CoursesModel> data = new List<CoursesModel>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new CoursesModel(myReader);
                                data.Add(get);
                            }
                        }
                        catch (Exception ex)
                        {
                            // LOG ERROR
                            throw ex;
                        }
                    }
                    return data;
                }
            }
        }

        public List<Modules> GetModules()
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "select * from [Modules]";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<Modules> data = new List<Modules>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new Modules(myReader);
                                data.Add(get);
                            }
                        }
                        catch (Exception ex)
                        {
                            // LOG ERROR
                            throw ex;
                        }
                    }
                    return data;
                }
            }
        }


        public bool AddCourseModules(CourseModules Model)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();

                string s = Model.ModuleId;
                String[] words = s.Split(',');

                foreach (var a in words)
                {

                  

                    string qry = "insert into [CourseModules] ([CourseId] ,[ModuleId] )values (" + Model.CourseId + ", " +  a + ")";
                    using (var cmd = new SqlCommand(qry, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                    }


                }

               

                return true;
            }
        }


        public List<Students> GetStudents()
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "select * from [AspNetUsers] where role = 2";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<Students> data = new List<Students>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new Students(myReader);
                                data.Add(get);
                            }
                        }
                        catch (Exception ex)
                        {
                            // LOG ERROR
                            throw ex;
                        }
                    }
                    return data;
                }
            }
        }

    }
}
