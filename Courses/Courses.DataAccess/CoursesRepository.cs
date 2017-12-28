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

                string s = Model.ModuleId.ToString();
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


        public bool AddUserCourses(UserCourses Model)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();

                string s = Model.CourseId.ToString();
                String[] words = s.Split(',');

                foreach (var a in words)
                {



                    string qry = "INSERT INTO UserCourses (StudentId ,CourseId) VALUES  ('" + Model.StudentId + "', " + a + ")";
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

        public Students CheckUser(Students s)
        {
            Students data = null;
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "select * from [AspNetUsers] where Email = '" + s.Username + "'";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                  
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                data = new Students(myReader);
                                
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


        //public List<CourseModules> GetCourseModules()
        //{
        //    using (var conn = new SqlConnection(CoursesConnectionString))
        //    {
        //        conn.Open();
        //        string qry = "select * from [Courses]";
        //        using (var cmd = new SqlCommand(qry, conn))
        //        {
        //            cmd.CommandType = CommandType.Text;

        //            List<CourseModules> data = new List<CourseModules>();
        //            var data1 = new List<CourseModules>();
        //            List<CoursesModel> c = new List<CoursesModel>();
        //            List<Modules> m = new List<Modules>();

        //            //var myReader = cmd.ExecuteReader();
        //            using (var myReader = cmd.ExecuteReader())
        //            {
        //                try
        //                {
        //                    while (myReader.Read())
        //                    {
        //                        var get = new CoursesModel(myReader);


        //                       string  data3 = GetCourseModules1(get.CourseID);

        //                        Console.WriteLine(data3);
        //                            // data.Add(get);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    // LOG ERROR
        //                    throw ex;
        //                }
        //            }
        //            return data;
        //        }
        //    }
        //}

        public List<CourseModules> GetCourseModules()
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "select CourseModules.CourseId, CourseModules.ModuleId, Courses.CourseName, Modules.ModuleName from [CourseModules] left join Courses on Courses.CourseId = CourseModules.CourseId left join Modules on Modules.ModuleId = CourseModules.ModuleId order by CourseModules.CourseId";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    // CourseModules cc = new CourseModules();
                    List<CourseModules> data = new List<CourseModules>();

                    var id = 0;
                    var name = "";


                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new CourseModules(myReader);

                                //if (get.CourseId == id)
                                //{

                                //    //        get.CourseId = 0; get.CourseName = ""; get.ModuleId = 0; 
                                //    name = get.ModuleName += "," + name;

                                //    data.Add(get);
                                //}
                                //else
                                //{

                                //    name = get.ModuleName;
                                //    data.Add(get);
                                //}

                                //  string data3 = GetCourseModules1(get.CourseID);
                                //cc.CourseId = (int)myReader["CourseId"];
                                //cc.ModuleId = (int)myReader["ModuleId"];
                                //cc.CourseName = (string)myReader["CourseName"];
                                //cc.ModuleName = (string)myReader["ModuleName"];
                                data.Add(get);

                                id = get.CourseId;


                                //      Console.WriteLine(data3);
                                // data.Add(get);
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



        public List<UserCourses> GetUserCourses()
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "select UserCourses.CourseId, UserCourses.StudentId, Courses.CourseName, AspNetUsers.Email from UserCourses left join Courses on Courses.CourseId = UserCourses.CourseId left join AspNetUsers on AspNetUsers.id = UserCourses.StudentId order by UserCourses.CourseId";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    // CourseModules cc = new CourseModules();
                    List<UserCourses> data = new List<UserCourses>();

                 
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new UserCourses(myReader);

                               
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




        public  string GetCourseModules1(int c )
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                string data = null;
                conn.Open();
                string qry = "select  Modules.ModuleId, Modules.ModuleName  from CourseModules left join  Modules on CourseModules.ModuleId = Modules.ModuleId where CourseModules.CourseId = " + c;
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                  
                    List<CoursesModel> c1 = new List<CoursesModel>();
                    List<Modules> m = new List<Modules>();

                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new Modules(myReader);
                                data += get.ModuleName + ",";


                                // data.Add(get);
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



        public List<CoursesModel> GetCourses_Single_User(string Username)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "select Courses.CourseId, Courses.CourseName from UserCourses left join AspNetUsers on AspNetUsers.Id = UserCourses.StudentId left join Courses on Courses.CourseId = UserCourses.CourseId where AspNetUsers.Email = '" + Username + "'";
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



        public List<Modules> GetCourseModules_Single_User(string Username, int CourseId)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = " select m.ModuleId , m.ModuleName from UserCourses uc ,CourseModules cm, courses c , modules m , AspNetUsers a where c.CourseId = uc.CourseId and a.Id = uc.StudentId and  cm.CourseId = c.CourseId and cm.ModuleId = m.ModuleId and a.Email = '"+Username+"' and c.CourseId =  "+CourseId;
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

    }
}
