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
        public string DirectoryPath { get; set; }

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



    public class Exams
    {
        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public string ExamName { get; set; }
        public string CourseName { get; set; }
        public DateTime Created { get; set; }

        public Exams()
        {


        }
        public Exams(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("ExamId") && dbReader["ExamId"] != DBNull.Value) ExamId = (int)dbReader["ExamId"];
            if (dbReader.HasColumn("CourseId") && dbReader["CourseId"] != DBNull.Value) CourseId = (int)dbReader["CourseId"];
            if (dbReader.HasColumn("ExamName") && dbReader["ExamName"] != DBNull.Value) ExamName = (string)dbReader["ExamName"];
            if (dbReader.HasColumn("CourseName") && dbReader["CourseName"] != DBNull.Value) CourseName = (string)dbReader["CourseName"];
            if (dbReader.HasColumn("Created") && dbReader["Created"] != DBNull.Value) Created = (DateTime)dbReader["Created"];

        }

    }


    public class Questions
    {
        public int QuesId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerType { get; set; }
        public string AnswerText { get; set; }
        public int ExamId { get; set; }
        public int OPID1 { get; set; }
        public int OPID2 { get; set; }
        public int OPID3 { get; set; }
        public int OPID4 { get; set; }

        public Questions()
        {


        }
        public Questions(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("QuesId") && dbReader["QuesId"] != DBNull.Value) QuesId = (int)dbReader["QuesId"];
            if (dbReader.HasColumn("Question") && dbReader["Question"] != DBNull.Value) QuestionText = (string)dbReader["Question"];
            if (dbReader.HasColumn("AnswerType") && dbReader["AnswerType"] != DBNull.Value) AnswerType = (string)dbReader["AnswerType"];
            if (dbReader.HasColumn("AnswerText") && dbReader["AnswerText"] != DBNull.Value) AnswerText = (string)dbReader["AnswerText"];
            if (dbReader.HasColumn("ExamId") && dbReader["ExamId"] != DBNull.Value) ExamId = (int)dbReader["ExamId"];
           

        }

    }


    public class Answers
    {
        public int AnswerID { get; set; }
        public int QuesId { get; set; }
        public string AnswerText { get; set; }
        public bool CorrectAnswer { get; set; }
        public int ExamId { get; set; }

        public Answers(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("AnswerID") && dbReader["AnswerID"] != DBNull.Value) AnswerID = (int)dbReader["AnswerID"];
            if (dbReader.HasColumn("QuestionId") && dbReader["QuestionId"] != DBNull.Value) QuesId = (int)dbReader["QuestionId"];
            if (dbReader.HasColumn("AnswerText") && dbReader["AnswerText"] != DBNull.Value) AnswerText = (string)dbReader["AnswerText"];
            if (dbReader.HasColumn("CorrectAnswer") && dbReader["CorrectAnswer"] != DBNull.Value) CorrectAnswer = (bool)dbReader["CorrectAnswer"];
            if (dbReader.HasColumn("ExamId") && dbReader["ExamId"] != DBNull.Value) ExamId = (int)dbReader["ExamId"];

        }

    }



    public class Questions1
    {
        public int QuesId { get; set; }
        public int ExamId { get; set; }
        public string Question{ get; set; }
        public string AnswerType { get; set; }


        public Questions1(IDataReader dbReader)
        {
            if (dbReader == null) return;
            if (dbReader.HasColumn("QuestionId") && dbReader["QuestionId"] != DBNull.Value) QuesId = (int)dbReader["QuestionId"];
            if (dbReader.HasColumn("ExamId") && dbReader["ExamId"] != DBNull.Value) ExamId = (int)dbReader["ExamId"];
            if (dbReader.HasColumn("Question") && dbReader["Question"] != DBNull.Value) Question = (string)dbReader["Question"];
            if (dbReader.HasColumn("AnswerType") && dbReader["AnswerType"] != DBNull.Value) AnswerType = (string)dbReader["AnswerType"];


        }

    }


    public class QuestionsAndAnswers
    {


        public List<Questions1> Questions { get; set; }
        public List<Answers> Answers { get; set; }

        public QuestionsAndAnswers()
        {


        }

        public QuestionsAndAnswers(IDataReader dbReader)
        {
            if (dbReader == null) return;
            Questions = new List<Questions1>();
            Answers = new List<Answers>();

        }
       
    }

    public class QuestionPaginations
    {

        
        public int CourseId { get; set; }
        public int Next { get; set; }
        public int Previous { get; set; }



    }



}
