using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_portal.Models;
using System.IO;

namespace job_portal.Controllers
{
    public class jobapplicationController : Controller
    {
        jobportal_mvcEntities dbobj = new jobportal_mvcEntities();
        // GET: jobappication
        public ActionResult application_pageload(int cid,int jid)
        {
            TempData["cid"] = cid;
            Session["jid"] = jid;
            TempData["jid"] = jid;
            Session["cid"] = cid;
            
            var getdata = dbobj.sp_selectonejob(Convert.ToInt32(TempData["cid"]), Convert.ToInt32(TempData["jid"])).FirstOrDefault();
            return View(new AddApplication
            { 
                jobtitle=getdata.job_title,
                companyname=getdata.company_name,
                description=getdata.job_description,
                location=getdata.job_location,
                jobsalary=getdata.Job_salary
            });
        }
            
        
        public ActionResult application_click(AddApplication clsobj,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/resume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\resume", fname);
                    clsobj.resume = fullpath;

                    clsobj.date = DateTime.Now;

                    int count = Convert.ToInt32(dbobj.sp_applicationcount(Convert.ToInt32(Session["uid"]), Convert.ToInt32(TempData["jid"])).FirstOrDefault());
                    if (count == 0)
                    {
                        dbobj.sp_applicationinsert(Convert.ToInt32(Session["uid"]), Convert.ToInt32(Session["jid"]), clsobj.date, clsobj.resume, "Applied");
                        clsobj.applicationmsg = "Applied Successfully";
                        return View("application_pageload", clsobj);
                    }
                    else
                    {
                        clsobj.applicationmsg = "Already Applied";
                        return View("application_pageload", clsobj);
                    }
                }
            }
            return View("application_pageload", clsobj);
        }
    }
}