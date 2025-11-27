using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_portal.Models;

namespace job_portal.Controllers
{
    public class userprofileController : Controller
    {
        jobportal_mvcEntities dbobj = new jobportal_mvcEntities();
        // GET: userprofile
        public ActionResult usrprofile_pageload()
        {
            var data = dbobj.sp_displayalljobs().ToList();
            ViewBag.jobpostings = data;
            return View();
        }
        
    }
}