using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_portal.Models;

namespace job_portal.Controllers
{
    public class jobappicationController : Controller
    {
        jobportal_mvcEntities dbobj = new jobportal_mvcEntities();
        // GET: jobappication
        public ActionResult application_pageload()
        {
            return View();
        }
    }
}