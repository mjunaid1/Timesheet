﻿using Courses.Entities;
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
   public class TimesheetRepositrory
    {
        protected string TimesheetConnectionString { get; set; }
        public TimesheetRepositrory()
        {
            TimesheetConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public TimesheetRepositrory(string connection)
        {
            TimesheetConnectionString = connection;
        }


        public Employees CheckUser(Employees s)
        {
            Employees data = null;
            using (var conn = new SqlConnection(TimesheetConnectionString))
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
                                data = new Employees(myReader);

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

        public bool UpdateRole(string role, string email)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "  update [AspNetUsers] set role = " + role + " where Email =  '" + email + "'";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }


        public bool AddCompany(CompanyModel Model)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "insert into [Company_Tbl] (CompanyName,Created,CreatedBy) values ('" + Model.CompanyName + "','"+System.DateTime.Now+"',1)";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }

                return true;
            }
        }


        public List<CompanyModel> GetCompany()
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "select * from [Company_Tbl]";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<CompanyModel> data = new List<CompanyModel>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new CompanyModel(myReader);
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


        public List<Employees> GetEmployees()
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "select * from [AspNetUsers] where role = " + 2 ;
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<Employees> data = new List<Employees>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new Employees(myReader);
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

        public bool AddCompanyEmployees(CompanyEmployees Model)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();

                string s = Model.EmployeeId.ToString();
                String[] words = s.Split(',');
          

                foreach (var a in words)
                {



                    string qry = "insert into [CompanyEmployees] ([CompanyId] ,[EmployeeId] )values (" + Model.CompanyId + ", '" + a + "')";
                    using (var cmd = new SqlCommand(qry, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();


                    }


                }


                return true;
            }
        }

        public List<CompanyEmployees> GetCompanyEmployees()
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = " select CompanyId, (select CompanyName from  Company_Tbl where Company_Tbl.CompanyId = [CompanyEmployees].CompanyId) as 'CompanyName',EmployeeId ,"+
                               "(select UserName from AspNetUsers where AspNetUsers.id = [CompanyEmployees].EmployeeId) as 'UserName'" +
                              "from[CompanyEmployees] group by CompanyId,EmployeeId";

                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<CompanyEmployees> data = new List<CompanyEmployees>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new CompanyEmployees(myReader);
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


        public bool AddProject(ProjectModel Model)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "insert into [Project_Tbl] (CompanyId,ProjectName,Created,CreatedBy) values ('" + Model.CompanyId + "','" + Model.ProjectName + "','"+System.DateTime.Now+"',1)";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }

                return true;
            }
        }

        public List<ProjectModel> GetProjects()
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "select * , (select CompanyName  from Company_Tbl where Company_Tbl.CompanyId = Project_Tbl.CompanyId ) as 'CompanyName' from  Project_Tbl";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<ProjectModel> data = new List<ProjectModel>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new ProjectModel(myReader);
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


        public List<CompanyModel> getCompanyPerEmp(string Username)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = " select ce.[CompanyId], (select [CompanyName] from  [Company_Tbl] where [Company_Tbl].CompanyId = ce.CompanyId) as 'CompanyName'  from [CompanyEmployees] ce inner join [AspNetUsers] a on  a.Id = ce.EmployeeId where  a.UserName = '"+Username+"'";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<CompanyModel> data = new List<CompanyModel>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new CompanyModel(myReader);
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


        
        public List<ProjectModel> GetProjectsPerCompany(long CompanyId)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "  select * from Project_Tbl where CompanyId = " + CompanyId;
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<ProjectModel> data = new List<ProjectModel>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new ProjectModel(myReader);
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

        public bool AddTimePeriods(TimesheetModel Model)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
             
                TimesheetModel data = new TimesheetModel();
                conn.Open();
                string qry = "insert into [Timesheet_tbl] (TimePeriods,UserName,Hours,duration,status,Created) values ('" + Model.TimePeriods + "','" + Model.UserName + "',0,0,'Not Submitted','" + System.DateTime.Now + "')";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();


                    string qry2 = "select max(TimePeriodId) as TimePeriodId from Timesheet_tbl where TimePeriods = '"+ Model.TimePeriods + "' and UserName = '"+ Model.UserName + "'";

                    using (var cmd2 = new SqlCommand(qry2, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        var myReader = cmd2.ExecuteReader();

                        myReader.Read();


                        data.TimePeriodId = (long)myReader["TimePeriodId"];

                        myReader.Close();

                        var timeUtc = DateTime.UtcNow;
                        TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                        DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);

                        string qry3 = "INSERT INTO [dbo].[Timesheet_TBL_info] ([TimePeriodId],[CreatedPeriodDateTime]) VALUES ("+ data.TimePeriodId + ",'"+ easternTime + "')";

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


        public List<TimesheetModel> GetTimePeriods(string Username)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "select * from [Timesheet_tbl] where UserName = '" + Username + "'";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<TimesheetModel> data = new List<TimesheetModel>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new TimesheetModel(myReader);
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

        
        public List<TimesheetModel> GetTimePeriodsPerId(string Username , long id)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "select * from [Timesheet_tbl] where UserName = '" + Username + "' and TimePeriodId = " + id;
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<TimesheetModel> data = new List<TimesheetModel>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new TimesheetModel(myReader);
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


        //public bool addWorkingHours(WorkingHours Model)
        //{
        //    using (var conn = new SqlConnection(TimesheetConnectionString))
        //    {
        //        conn.Open();
        //        string qry = "insert into [TimesheetDetails_tbl] (TimePeriodId,ProjectId,Hours,Date,Created) values (" + Model.TimePeriodId + "," + Model.ProjectId + ",'"+Model.Hours+"','"+Model.Date+"','" + System.DateTime.Now + "')";
        //        using (var cmd = new SqlCommand(qry, conn))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.ExecuteNonQuery();

        //        }

        //        return true;
        //    }
        //}

        public bool addWorkingHours(WorkingHours Model)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
               // string qry = "insert into [TimesheetDetails_tbl] (TimePeriodId,ProjectId,Hours,Date,Created) values (" + Model.TimePeriodId + "," + Model.ProjectId + ",'" + Model.Hours + "','" + Model.Date + "','" + System.DateTime.Now + "')";
                using (var cmd = new SqlCommand("[AddWorkingHours]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProjectId", SqlDbType.BigInt).Value = Model.ProjectId;
                    cmd.Parameters.Add("@TimePeriodId", SqlDbType.BigInt).Value = Model.TimePeriodId;
                    cmd.Parameters.Add("@Hours", SqlDbType.NVarChar).Value = Model.Hours;
                    cmd.Parameters.Add("@Day", SqlDbType.NVarChar).Value = Model.Day;


                    cmd.ExecuteNonQuery();

                    var timeUtc = DateTime.UtcNow;
                    TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);

                    string qry3 = "insert into [TimesheetDetails_info] (HoursDateTime,TimePeriodId,Day) values ('" + easternTime + "'," + Model.TimePeriodId + ", '"+ Model.Day + "')";

                    using (var cmd3 = new SqlCommand(qry3, conn))
                    {
                        cmd3.CommandType = CommandType.Text;

                        cmd3.ExecuteNonQuery();
                    }


                }

                return true;
            }
        }



        public List<WorkingHours> GetTimeSheetDetails(long TimePeriodId)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "  select * from TimesheetDetails_tbl inner join Project_Tbl on Project_Tbl.ProjectId = TimesheetDetails_tbl.ProjectId inner join Company_Tbl on Company_Tbl.CompanyId = Project_Tbl.CompanyId where TimesheetDetails_tbl.TimePeriodId = " + TimePeriodId + "";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<WorkingHours> data = new List<WorkingHours>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new WorkingHours(myReader);
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

        
        public bool SubmitTimeSheet(TimesheetModel Model)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "update [Timesheet_tbl] set Description = '"+Model.Description+"' , SubmitedDate = '"+ System.DateTime.Now + "' , status = 'Submitted' where TimePeriodId  = " + Model.TimePeriodId;
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    var timeUtc = DateTime.UtcNow;
                    TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);

                    string qry3 = "update [Timesheet_TBL_info] set SubmittedDateTime = '"+easternTime+"' where TimePeriodId =  "+Model.TimePeriodId;

                    using (var cmd3 = new SqlCommand(qry3, conn))
                    {
                        cmd3.CommandType = CommandType.Text;

                        cmd3.ExecuteNonQuery();
                    }

                }

                return true;
            }
        }

        
        public List<TimesheetModel> GetSubmittedTimeSheets()
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "select * from [Timesheet_tbl] where status = 'Submitted'";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<TimesheetModel> data = new List<TimesheetModel>();
                    //var myReader = cmd.ExecuteReader();
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                var get = new TimesheetModel(myReader);
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

        //public bool SaveAdminTimeSheet(WorkingHours Model)
        //{
        //    using (var conn = new SqlConnection(TimesheetConnectionString))
        //    {
        //        conn.Open();
        //        string qry = "update [TimesheetDetails_tbl] set Mon = '"+ Model.Mon + "' , Tue = '"+Model.Tue+"' , Wed = '"+ Model.Wed + "' , Thu = '"+Model.Thu+"' , Fri = '"+ Model.Fri+ "', Sat = '"+ Model.Sat + "' , Sun = '"+Model.Sun+"' where ProjectId = "+Model.ProjectId+" and TimePeriodId =  "+ Model.TimePeriodId;
        //        using (var cmd = new SqlCommand(qry, conn))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.ExecuteNonQuery();

        //        }

        //        return true;
        //    }
        //}

        public bool SaveAdminTimeSheet(WorkingHours Model)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("[AdminUpdateHours]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProjectId", SqlDbType.BigInt).Value = Model.ProjectId;
                    cmd.Parameters.Add("@TimePeriodId", SqlDbType.BigInt).Value = Model.TimePeriodId;
                    cmd.Parameters.Add("@Mon", SqlDbType.Time).Value = Model.Mon;
                    cmd.Parameters.Add("@Tue", SqlDbType.Time).Value = Model.Tue;
                    cmd.Parameters.Add("@Wed", SqlDbType.Time).Value = Model.Wed;
                    cmd.Parameters.Add("@Thu", SqlDbType.Time).Value = Model.Thu;
                    cmd.Parameters.Add("@Fri", SqlDbType.Time).Value = Model.Fri;
                    cmd.Parameters.Add("@Sat", SqlDbType.Time).Value = Model.Sat;
                    cmd.Parameters.Add("@Sun", SqlDbType.Time).Value = Model.Sun;


                    cmd.ExecuteNonQuery();

                }

                return true;
            }
        }

        
        public bool DeleteTimePeriods(WorkingHours Model)
        {
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("[DeleteTimeSheet]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TimePeriodId", SqlDbType.BigInt).Value = Model.TimePeriodId;
                


                    cmd.ExecuteNonQuery();

                }

                return true;
            }
        }
        public bool UpdateLogin_info(string email)
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
            using (var conn = new SqlConnection(TimesheetConnectionString))
            {
                conn.Open();
                string qry = "INSERT INTO [dbo].[Login_info]([Username],[DateTime]) VALUES ( '"+ email + "','"+ easternTime + "')";
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
