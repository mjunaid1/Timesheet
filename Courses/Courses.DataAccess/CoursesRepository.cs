using Courses.Entities;
using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dropbox.Api.Files;
using System.Threading.Tasks;

namespace Courses.DataAccess
{
    public class CoursesRepository
    {
        static string DirectoryName = "";
        static string ModuleDirectoryName = "";
        static string ModuleName = "";
        static string CourseName = "";
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

                    DirectoryName = Model.CourseName;
                    var task = Task.Run((Func<Task>)CoursesRepository.Run);
                    task.Wait();

                //    Task.Run(Run);
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
                String[] words1 = Model.DirectoryPath.Split(',');
                String[] words2 = Model.ModuleName.Split(',');

                foreach (var a in words)
                {



                    string qry = "insert into [CourseModules] ([CourseId] ,[ModuleId] )values (" + Model.CourseId + ", " + a + ")";
                    using (var cmd = new SqlCommand(qry, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();


                    }


                }

                var count = 0;
                foreach (var a in words1)
                {
                    ModuleDirectoryName = a;

                    String[] words11 = a.Split('/');
                    foreach (var ab in words11)
                    {
                        count++;

                        if (count == 1)
                        {
                            CourseName = ab;

                        }

                        if (count == 3)
                        {
                            ModuleName = ab;

                            var task = Task.Run((Func<Task>)CoursesRepository.Run1);
                            task.Wait();

                      //      Task.Run(Run1);

                            count = 0;
                        }
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
                string qry = " select m.ModuleId , m.ModuleName, c.courseName from UserCourses uc ,CourseModules cm, courses c , modules m , AspNetUsers a where c.CourseId = uc.CourseId and a.Id = uc.StudentId and  cm.CourseId = c.CourseId and cm.ModuleId = m.ModuleId and a.Email = '"+Username+"' and c.CourseId =  "+CourseId + " group by m.ModuleId , m.ModuleName, c.courseName";
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


        
        public List<Exams> GetExams()
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                string qry = "select CourseExam.ExamId , Exam.ExamName , Courses.CourseName, Exam.Created from CourseExam , Courses , Exam where CourseExam.CourseId = Courses.CourseId and CourseExam.ExamId = Exam.ExamId";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<Exams> data = new List<Exams>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new Exams(myReader);
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





        public bool InsertExam(Exams Model)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                Exams data = new Exams();
                conn.Open();
                string qry = "insert into [Exam] (ExamName,Created) values  ('" + Model.ExamName+"','"+Model.Created+"')";
                
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                   
                    cmd.ExecuteNonQuery();

                    string qry2 = "select max(ExamId)as ExamId from [Exam] where ExamName = '" + Model.ExamName + "'";

                    using (var cmd2 = new SqlCommand(qry2, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        var myReader = cmd2.ExecuteReader();

                        myReader.Read();
                       
                           
                            data.ExamId = (int)myReader["ExamId"];

                        myReader.Close();

                            string qry3 = "insert into [CourseExam]  (ExamId,CourseId) values (" + data.ExamId + ", " + Model.CourseId + ")";

                            using (var cmd3 = new SqlCommand(qry3, conn))
                            {
                                cmd.CommandType = CommandType.Text;

                                cmd3.ExecuteNonQuery();

                            }


                        

                        

                    }


                    }



                return true;


            }
        }


        
        public bool InsertQues(Questions Model)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                Questions data = new Questions();
                var ansCount = 0;
                var option = "";
                var answer = "";
                string s = Model.AnswerText;
                String[] words = s.Split('‡');


                string qry = "INSERT INTO [ExamQuestions] ([ExamId] ,[Question], [AnswerType]) VALUES  (" + Model.ExamId + ",'" + Model.QuestionText + "','"+ Model.AnswerType + "')";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();


                    string qry2 = "select max(QuestionId)as QuestionId from [ExamQuestions] where Question = '" + Model.QuestionText + "'";

                    using (var cmd2 = new SqlCommand(qry2, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        var myReader = cmd2.ExecuteReader();

                        myReader.Read();


                        data.QuesId = (int)myReader["QuestionId"];

                        myReader.Close();


                        foreach (var a in words)
                        {

                            var abc = a;



                            String[] words1 = abc.Split('‰');
                            foreach (var a1 in words1)
                            {
                                ansCount++;
                                if (ansCount == 1)
                                    option = a1;
                                if (ansCount == 2)
                                {
                                    answer = a1;


                                    if (option != "")
                                    {



                                        var x = option;
                                        var y = answer;


                                        string qry3 = "insert into [ExamAnswers]  ([QuestionId],[AnswerText],CorrectAnswer,Examid) values (" + data.QuesId + ", '" + x + "','"+y+"',"+ Model.ExamId + ")";

                                        using (var cmd3 = new SqlCommand(qry3, conn))
                                        {
                                            cmd.CommandType = CommandType.Text;

                                            cmd3.ExecuteNonQuery();

                                        }





                                    }

                                    ansCount = 0;
                                }


                            }




                        }

                        






                    }






                }



                



                    return true;
            }
        }



        public QuestionsAndAnswers ViewQuestionAndAnswers(int ExamId)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("ExamQuestionAndAnswers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Examid", SqlDbType.BigInt).Value = ExamId;
                    QuestionsAndAnswers data = null;
                  
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                data = new QuestionsAndAnswers(myReader);
                            }
                            myReader.NextResult();
                            while (myReader.Read())
                            {


                                data.Questions.Add(new Questions1(myReader));
                              

                            }

                            myReader.NextResult();
                            while (myReader.Read())
                            {
                                data.Answers.Add(new Answers(myReader));
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

        public bool deleteQues(int Qid)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();

                



                string qry = "delete [ExamAnswers] where QuestionId = "+ Qid;
             

                using (var cmd = new SqlCommand(qry, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                    string qry2 = "delete [ExamQuestions] where QuestionId = " + Qid;
                    using (var cmd2 = new SqlCommand(qry2, conn))
                    {
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                    }


                    }





                return true;
            }
        }


        
        public bool EditQues(Questions Model)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();
                Questions data = new Questions();
                var ansCount = 0;
                var option = "";
                var answer = "";
                var answerid = "";
                string s = Model.AnswerText;
                String[] words = s.Split('‡');


                string qry = "update [ExamQuestions] set Question = '"+Model.QuestionText+"' , AnswerType = '"+Model.AnswerType+"' where QuestionId = "+ Model.QuesId;
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                        foreach (var a in words)
                        {

                            var abc = a;



                            String[] words1 = abc.Split('‰');
                            foreach (var a1 in words1)
                            {
                           //   ansCount++;
                            //if (ansCount == 1)
                            //    option = a1;
                            //if (ansCount == 2)
                            //{
                            //    answer = a1;

                            var xyz = a1;

                            //if(ansCount == 1)
                            //{
                            //    option = a1;
                              
                            //}
                                

                            String[] words2 = xyz.Split('œ');

                            foreach (var a2 in words2)
                            {
                                ansCount++;

                                var jun = a2;
                                if (ansCount == 1)
                                {
                                    option = jun;

                                }
                                if (ansCount == 2)
                                {
                                    answer = jun;

                                }
                                if (ansCount == 3)
                                {
                                    answerid = jun;



                                    if (option != "" && answerid != "-1" )
                                    {

                                        // up 
                                        string qry1 = "update [ExamAnswers] set QuestionId = "+Model.QuesId+" , AnswerText = '"+ option + "' , CorrectAnswer = '"+ answer + "' , ExamId = "+Model.ExamId+" where [AnswerID] =  " + answerid;
                                        using (var cmd1 = new SqlCommand(qry1, conn))
                                        {
                                            cmd1.CommandType = CommandType.Text;
                                            cmd1.ExecuteNonQuery();
                                        }

                                    }
                                    else if ((option == "" && answerid == "-1") || (option == "" && answerid != "-1"))
                                    {
                                        // up 

                                        string qry1 = "delete [ExamAnswers] where [AnswerID] = " + answerid;
                                        using (var cmd1 = new SqlCommand(qry1, conn))
                                        {
                                            cmd1.CommandType = CommandType.Text;
                                            cmd1.ExecuteNonQuery();
                                        }

                                        //   return true;

                                    }
                                    else
                                    {
                                        // In 


                                        string qry1 = "insert into [ExamAnswers]  ([QuestionId],[AnswerText],CorrectAnswer,Examid) values (" + Model.QuesId + ", '" + option + "','" + answer + "'," + Model.ExamId + ")";
                                        using (var cmd1 = new SqlCommand(qry1, conn))
                                        {
                                            cmd1.CommandType = CommandType.Text;
                                            cmd1.ExecuteNonQuery();
                                        }

                                    }






                                    ansCount = 0;
                                }



                            }


                                //if (option != "")
                                //{



                                //    var x = option;
                                //    var y = answer;


                                //    string qry3 = "insert into [ExamAnswers]  ([QuestionId],[AnswerText],CorrectAnswer,Examid) values (" + data.QuesId + ", '" + x + "','" + y + "'," + Model.ExamId + ")";

                                //    using (var cmd3 = new SqlCommand(qry3, conn))
                                //    {
                                //        cmd.CommandType = CommandType.Text;

                                //        cmd3.ExecuteNonQuery();

                                //    }


                                //}

                                //ansCount = 0;
                                //}


                            }




                        }








          






                }







                return true;
            }
        }

        public QuestionsAndAnswers ViewExamQuestion(QuestionPaginations Model)
        {
            using (var conn = new SqlConnection(CoursesConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("ExamQuestions_single", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CourseId", SqlDbType.BigInt).Value = Model.CourseId;
                    cmd.Parameters.Add("@previous", SqlDbType.BigInt).Value = Model.Previous;
                    cmd.Parameters.Add("@next", SqlDbType.BigInt).Value = Model.Next;

                    QuestionsAndAnswers data = null;

                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                data = new QuestionsAndAnswers(myReader);
                            }
                            myReader.NextResult();
                            while (myReader.Read())
                            {


                                data.Questions.Add(new Questions1(myReader));


                            }

                            myReader.NextResult();
                            while (myReader.Read())
                            {
                                data.Answers.Add(new Answers(myReader));
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


        static async Task Run()
        {
            using (var dbx = new DropboxClient("M9-AXilUwLAAAAAAAAAAE5oPgmq8_7-AqcHjs9K7a9UixgirDSrxt4RzeRmHEzPD"))
            {

                var full = await dbx.Users.GetCurrentAccountAsync();

                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);


                //    await Upload(dbx, @"/MyApp/test", "test.txt", "Testing!");

                //  await p.UploadDoc();

                //using (var abc1 = await dbx.Files.DownloadAsync(@"/Courses/xyz/Modules/Lesson 2/bbc.txt"))
                //{
                //    //foreach (var a in abc1.Entries)
                //    //{
                //    Console.WriteLine(await abc1.GetContentAsStringAsync() + "  ");
                //}
                //}
                var list = await dbx.Files.ListFolderAsync(@"/Courses/");

                //await Upload(dbx, @"/MyApp/test", "test.txt", "Testing!");
                //Console.ReadLine();

                var a1 = list.Entries.Where(i => i.Name == CoursesRepository.DirectoryName).Count();
                if (a1 == 1)
                {


                    //  await dbx.Files.CreateFolderAsync(@"/Courses" + "/" + data.CourseName + "/" + "Modules/" + data1.ModuleName);

                }
                else
                {
                    await dbx.Files.CreateFolderAsync("/Courses/" + CoursesRepository.DirectoryName+"/Modules");
                }

            }
        }



        static async Task Run1()
        {
            using (var dbx = new DropboxClient("M9-AXilUwLAAAAAAAAAAE5oPgmq8_7-AqcHjs9K7a9UixgirDSrxt4RzeRmHEzPD"))
            {

        //        var full = await dbx.Users.GetCurrentAccountAsync();

      //          Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);


                //    await Upload(dbx, @"/MyApp/test", "test.txt", "Testing!");

                //  await p.UploadDoc();

                //using (var abc1 = await dbx.Files.DownloadAsync(@"/Courses/xyz/Modules/Lesson 2/bbc.txt"))
                //{
                //    //foreach (var a in abc1.Entries)
                //    //{
                //    Console.WriteLine(await abc1.GetContentAsStringAsync() + "  ");
                //}
                //}
              

                //await Upload(dbx, @"/MyApp/test", "test.txt", "Testing!");
                //Console.ReadLine();
                if (CoursesRepository.ModuleDirectoryName != "") {

                    var list = await dbx.Files.ListFolderAsync(@"/Courses/" + CoursesRepository.CourseName + "/Modules/");
                    var a1 = list.Entries.Where(i => i.Name == CoursesRepository.ModuleName).Count();

                if (a1 != 1)
                {
                    //  CoursesRepository.ModuleName = "";
                    //       CoursesRepository.CourseName = "";
                    await dbx.Files.CreateFolderAsync("/Courses/" + CoursesRepository.ModuleDirectoryName);
                    CoursesRepository.ModuleDirectoryName = "";
                    //     CoursesRepository.ModuleDirectoryName = "";
                    //  await dbx.Files.CreateFolderAsync(@"/Courses" + "/" + data.CourseName + "/" + "Modules/" + data1.ModuleName);

                }

                }
            }
        }

    }
}
