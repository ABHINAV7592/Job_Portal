using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace job_portal.Models
{
    public class genclass
    {
        public int gid { set; get; }
        public string gname { set; get; }
    }
    public class qualificationcheckbox
    {
        public string qualvalue { set; get; }
        public string qualtext { set; get; }
        public bool qualischecked { set; get; }
    }
    public class skillcheckbox
    {
        public string skillvalue { set; get; }
        public string skilltext { set; get; }
        public bool skillischecked { set; get; }
    }
    public class Userinsert
    {
        [Required(ErrorMessage ="Enter Name")]
        public string name { set; get; }
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Enter Valid Phone")]
        [Required(ErrorMessage ="Enter Phone")]
        public string phone { set; get; }
        public int gid { set; get; }
        public string gname { set; get; }
        [Required(ErrorMessage ="Enter Age")]
        [Range(18,50,ErrorMessage ="Enter Valid Age")]
        public int age { set; get; }
        [Required(ErrorMessage ="Enter Address")]
        public string address { set; get; }
        public List<qualificationcheckbox> myqualification { set; get; }
        public string[] selectedqual { set; get; }
        public string qualf { set; get; }
        [Required(ErrorMessage ="Enter Experience In Years")]
        public int experience { set; get; }
        public List<skillcheckbox> myskills { set; get; }
        public string[] selectedskill { set; get; }
        public string skll { set; get; }
        [EmailAddress(ErrorMessage ="Enter Valid Mail Address")]
        [Required(ErrorMessage = "Enter Email")]
        public string email { set; get; }
        [Required(ErrorMessage = "Enter Password")]
        public string password { set; get; }
        [Compare("password",ErrorMessage ="Password Should Match")]
        public string confirmpassword { set; get; }
        public string usrmsg { set; get; }

    }
}