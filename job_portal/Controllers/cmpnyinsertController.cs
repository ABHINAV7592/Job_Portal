using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_portal.Models;
using System.IO;

namespace job_portal.Controllers
{
    public class cmpnyinsertController : Controller
    {
        jobportal_mvcEntities dbobj = new jobportal_mvcEntities();
        // GET: cmpnyinsert
        public ActionResult companyinsert_pageload()
        {
            return View();
        }
        public ActionResult cmpnyinsert_click(CompanyInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_regidcount().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                var ecount = dbobj.sp_emailcount(clsobj.email).FirstOrDefault();
                int getecount = Convert.ToInt32(ecount);
                if (getecount == 0)
                {
                    dbobj.sp_insertcmpny(regid, clsobj.companyname, clsobj.description, clsobj.phone, clsobj.address, clsobj.location);
                    dbobj.sp_logininsert(regid, clsobj.email, clsobj.password, "Admin");
                    clsobj.adminmsg = "Successfully Inserted";
                    return View("companyinsert_pageload", clsobj);
                }
                else
                {
                    clsobj.adminmsg = "Email Already Exist";
                }
            }
            return View("companyinsert_pageload", clsobj);
        }
    }
}