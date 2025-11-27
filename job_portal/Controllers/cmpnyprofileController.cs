using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_portal.Models;

namespace job_portal.Controllers
{
    public class cmpnyprofileController : Controller
    {
        jobportal_mvcEntities dbobj = new jobportal_mvcEntities();
        // GET: cmpnyprofile
        public ActionResult cmpnyprofile_pageload()
        {
            return View();
        }
        public ActionResult cmpnyprofile_click()
        {
            return View();
        }
    }
}