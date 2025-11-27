using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_portal.Models;

namespace job_portal.Controllers
{
    public class jobpostingController : Controller
    {
        jobportal_mvcEntities dbobj = new jobportal_mvcEntities();
        // GET: jobposting
        public ActionResult jobpost_pageload()
        {
            JobPost user = new JobPost();
            user.jobqualification = getqualificationdata();
            user.jobskill = getskillsdata();
            return View(user);
            
        }
        public List<postjobqualcheckbox> getqualificationdata()
        {
            List<postjobqualcheckbox> qual = new List<postjobqualcheckbox>()
            {
                new postjobqualcheckbox{qualvalue="SSLC",qualtext="SSLC",qualischecked=true},
                new postjobqualcheckbox{qualvalue="+2",qualtext="+2",qualischecked=false},
                new postjobqualcheckbox{qualvalue="Diploma",qualtext="Diploma",qualischecked=false},
                new postjobqualcheckbox{qualvalue="Degree",qualtext="Degree",qualischecked=false},
                new postjobqualcheckbox{qualvalue="B.Tech",qualtext="B.Tech",qualischecked=false},
                new postjobqualcheckbox{qualvalue="PostGraduate",qualtext="PostGraduate",qualischecked=false}
            };
            return qual;
        }
        public List<postjobskillcheckbox> getskillsdata()
        {
            List<postjobskillcheckbox> skill = new List<postjobskillcheckbox>()
            {
                new postjobskillcheckbox{skillvalue="C#",skilltext="C#",skillischecked=true},
                new postjobskillcheckbox{skillvalue="ASP.NET",skilltext="ASP.NET",skillischecked=false},
                new postjobskillcheckbox{skillvalue="MVC",skilltext="MVC",skillischecked=false},
                new postjobskillcheckbox{skillvalue="Java",skilltext="Java",skillischecked=false},
                new postjobskillcheckbox{skillvalue="SQL",skilltext="SQL",skillischecked=false},
                new postjobskillcheckbox{skillvalue="FrontEnd",skilltext="FrontEnd",skillischecked=false},
                new postjobskillcheckbox{skillvalue="BackEnd",skilltext="BackEnd",skillischecked=false},
                new postjobskillcheckbox{skillvalue="FullStack",skilltext="FullStack",skillischecked=false},
                new postjobskillcheckbox{skillvalue="UI/UX",skilltext="UI/UX",skillischecked=false}
            };
            return skill;
        }
        public ActionResult jobpostinsert_click(JobPost clsobj,FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var quid = string.Join(" or ", clsobj.selectedjobqual);
                clsobj.qualification = quid;
                clsobj.jobqualification = getqualificationdata();

                var suid = string.Join(",", clsobj.selectedjobskill);
                clsobj.skills = suid;
                clsobj.jobskill = getskillsdata();

                int uid = Convert.ToInt32(Session["uid"]);
                dbobj.sp_insertjobpost(uid,clsobj.jobtitle, clsobj.location, clsobj.experience, clsobj.skills, clsobj.qualification, clsobj.passoutyear, "Active", clsobj.jobstartdate, clsobj.jobenddate, clsobj.jobdescription, clsobj.jobtype);
                clsobj.jobmsg = "Successfully Posted";
                return View("jobpost_pageload", clsobj);
            }
            else
            {
                clsobj.jobqualification = getqualificationdata();
                clsobj.jobskill = getskillsdata();
                return View("jobpost_pageload", clsobj);
            }
        }
    }
}