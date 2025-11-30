using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_portal.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace job_portal.Controllers
{
    public class userprofileController : Controller
    {
        jobportal_mvcEntities dbobj = new jobportal_mvcEntities();
        // GET: userprofile
        public ActionResult usrprofile_pageload()
        {
            JobSearch js = new JobSearch();
            var data = dbobj.sp_alljobdisplay().ToList();
            ViewBag.jobpostings = data;

            foreach (var item in data)
            {
                js.selectjob.Add(new jobList
                {
                    Job_id = item.job_id,
                    Company_id = item.company_id,
                    Job_Tittle = item.job_title,
                    Job_description = item.job_description,
                    Job_Experience = item.experience_in_years.ToString(),
                    Job_Skills = item.job_skills,
                    Job_Salary = item.Job_salary,
                    Job_enddate = item.end_date,
                    Job_Location = item.job_location,
                    jobtype_name = item.job_type
                });
            }

            return View(js);
        }

        public ActionResult searchjob_click(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Experience))
            {
                qry += "and experience_in_years like '%" + clsobj.insertse.Job_Experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Skills))
            {
                qry += " and job_skills like '%" + clsobj.insertse.Job_Skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Location))
            {
                qry += "and job_location like '%" + clsobj.insertse.Job_Location + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Tittle))
            {
                qry += "and job_title like '%" + clsobj.insertse.Job_Tittle + "%'";
            }
            return View("usrprofile_pageload", getdata(clsobj, qry));
        }

        private JobSearch getdata(JobSearch clsobj, string qry)
        {
            using (var con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["importdataconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while (dr.Read())
                {
                    var jobcls = new jobList();
                    jobcls.Job_id = Convert.ToInt32(dr["job_id"].ToString());
                    jobcls.Company_id = Convert.ToInt32(dr["company_id"].ToString());
                    jobcls.Job_Tittle = dr["job_title"].ToString();
                    jobcls.Job_description = dr["job_description"].ToString();
                    jobcls.jobtype_name = dr["job_type"].ToString();
                    jobcls.Job_Experience = dr["experience_in_years"].ToString();
                    jobcls.Job_Skills = dr["job_skills"].ToString();
                    jobcls.Job_Salary =dr["Job_salary"].ToString();
                    jobcls.Job_enddate = Convert.ToDateTime(dr["end_date"].ToString());
                    jobcls.Job_Location = dr["job_location"].ToString();
                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }

    }
}