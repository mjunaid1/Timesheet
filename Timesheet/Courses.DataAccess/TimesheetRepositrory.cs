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
                conn.Open();
                string qry = "insert into [Timesheet_tbl] (TimePeriods,UserName,Hours,duration,status,Created) values ('" + Model.TimePeriods + "','" + Model.UserName + "',0,0,'Not Submitted','" + System.DateTime.Now + "')";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

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
                string qry = "insert into [TimesheetDetails_tbl] (TimePeriodId,ProjectId,Hours,Date,Created) values (" + Model.TimePeriodId + "," + Model.ProjectId + ",'" + Model.Hours + "','" + Model.Date + "','" + System.DateTime.Now + "')";
                using (var cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

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
    }
}
