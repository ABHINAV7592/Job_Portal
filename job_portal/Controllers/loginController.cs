using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_portal.Models;

namespace job_portal.Controllers
{
    public class loginController : Controller
    {
        jobportal_mvcEntities dbobj = new jobportal_mvcEntities();
        // GET: login
        public ActionResult login_pageload()
        {
            return View();
        }
        public ActionResult login_click(LoginInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var id = dbobj.sp_countregid(clsobj.email, clsobj.password).FirstOrDefault();
                if (id == 1)
                {
                    var uid = dbobj.sp_regidselect(clsobj.email, clsobj.password).FirstOrDefault();
                    {
                        Session["uid"] = uid;
                        var type = dbobj.sp_logintype(clsobj.email, clsobj.password).FirstOrDefault();
                        {
                            if (type == "Admin")
                            {
                                return RedirectToAction("userhome");
                            }
                            else if (type == "User")
                            {
                                return RedirectToAction("adminhome");
                            }
                            else
                            {
                                return View("login_pageload", clsobj);
                                clsobj.loginmsg = "Invalid Login";
                            }
                        }
                    }
                }
            }
            return View("login_pageload", clsobj);
        }
    }
}