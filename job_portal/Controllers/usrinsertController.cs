using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_portal.Models;
using System.IO;

namespace job_portal.Controllers
{
    public class usrinsertController : Controller
    {
        jobportal_mvcEntities dbobj = new jobportal_mvcEntities();
        // GET: userinsert
        public ActionResult usrinsertpage_load()
        {
            List<genclass> genlist = new List<genclass>
            {
                new genclass{gid=1,gname="Male"},
                new genclass{gid=2,gname="Female"},
                new genclass{gid=3,gname="Others"}
            };
            ViewBag.selgender = new SelectList(genlist, "gid", "gname");

            Userinsert user = new Userinsert();
            user.myqualification = getqualificationdata();
            user.myskills = getskillsdata();
            return View(user);
        }
        public List<qualificationcheckbox> getqualificationdata()
        {
            List<qualificationcheckbox> qual = new List<qualificationcheckbox>()
            {
                new qualificationcheckbox{qualvalue="SSLC",qualtext="SSLC",qualischecked=true},
                new qualificationcheckbox{qualvalue="+2",qualtext="+2",qualischecked=false},
                new qualificationcheckbox{qualvalue="Diploma",qualtext="Diploma",qualischecked=false},
                new qualificationcheckbox{qualvalue="Degree",qualtext="Degree",qualischecked=false}
            };
            return qual;
        }
        public List<skillcheckbox> getskillsdata()
        {
            List<skillcheckbox> skill = new List<skillcheckbox>()
            {
                new skillcheckbox{skillvalue="C#",skilltext="C#",skillischecked=true},
                new skillcheckbox{skillvalue="ASP.NET",skilltext="ASP.NET",skillischecked=false},
                new skillcheckbox{skillvalue="MVC",skilltext="MVC",skillischecked=false},
                new skillcheckbox{skillvalue="Java",skilltext="Java",skillischecked=false},
                new skillcheckbox{skillvalue="SQL",skilltext="SQL",skillischecked=false},
                new skillcheckbox{skillvalue="FrontEnd",skilltext="FrontEnd",skillischecked=false},
                new skillcheckbox{skillvalue="BackEnd",skilltext="BackEnd",skillischecked=false},
                new skillcheckbox{skillvalue="FullStack",skilltext="FullStack",skillischecked=false},
                new skillcheckbox{skillvalue="UI/UX",skilltext="UI/UX",skillischecked=false}
            };
            return skill;
        }
        public ActionResult insert_click(Userinsert clsobj,FormCollection form)
        {
            if (ModelState.IsValid)
            {
                List<genclass> genlist = new List<genclass>
              {
                new genclass{gid=1,gname="Male"},
                new genclass{gid=2,gname="Female"},
                new genclass{gid=3,gname="Others"}
              };
                ViewBag.selgender = new SelectList(genlist, "gid", "gname");

                int selectedid = Convert.ToInt32(form["ddlgender"]);
                genclass selecteditem = genlist.FirstOrDefault(c => c.gid == selectedid);
                clsobj.gid = selecteditem.gid;
                clsobj.gname = selecteditem.gname;

                var quid = string.Join(",", clsobj.selectedqual);
                clsobj.qualf = quid;
                clsobj.myqualification = getqualificationdata();

                var suid = string.Join(",", clsobj.selectedskill);
                clsobj.skll = suid;
                clsobj.myskills = getskillsdata();

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
                var ecount=dbobj.sp_emailcount(clsobj.email).FirstOrDefault();
                int getecount = Convert.ToInt32(ecount);
                if (getecount == 0)
                {
                    dbobj.sp_insertusr(regid, clsobj.name, clsobj.phone, clsobj.gname, clsobj.age, clsobj.address, clsobj.qualf, clsobj.experience, clsobj.skll, "Active");
                    dbobj.sp_logininsert(regid, clsobj.email, clsobj.password, "User");
                    clsobj.usrmsg = "Successfully Inserted";
                    return View("usrinsertpage_load", clsobj);
                }
                else
                {
                    clsobj.usrmsg = "Email Already Exist";
                    return View("usrinsertpage_load", clsobj);
                }
                
            }
            else
            {
                List<genclass> genlist = new List<genclass>
              {
                new genclass{gid=1,gname="Male"},
                new genclass{gid=2,gname="Female"},
                new genclass{gid=3,gname="Others"}
              };
                ViewBag.selgender = new SelectList(genlist, "gid", "gname");
                clsobj.myqualification = getqualificationdata();
                clsobj.myskills = getskillsdata();
                return View("usrinsertpage_load", clsobj);
            }
        }
        }
    }
