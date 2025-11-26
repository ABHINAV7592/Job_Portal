using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace job_portal.Controllers
{
    public class userprofileController : Controller
    {
        // GET: userprofile
        public ActionResult usrprofile_pageload()
        {
            return View();
        }
        
    }
}