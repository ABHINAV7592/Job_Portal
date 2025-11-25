using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace job_portal.Models
{
    public class CompanyInsert
    {
        [Required(ErrorMessage ="Enter Name")]
        public string companyname { set; get; }
        [Required(ErrorMessage ="Enter Description")]
        public string description { set; get; }
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Enter Valid Phone")]
        [Required(ErrorMessage ="Enter Phone Number")]
        public string phone { set; get; }
        [Required(ErrorMessage ="Enter Address")]
        public string address { set; get; }
        [Required(ErrorMessage ="Enter Location")]
        public string location { set; get; }
        [EmailAddress(ErrorMessage = "Enter Valid Mail Address")]
        [Required(ErrorMessage = "Enter Email")]
        public string email { set; get; }
        [Required(ErrorMessage ="Enter Password")]
        public string password { set; get; }
        [Compare("password",ErrorMessage ="Password Should Match")]
        [Required(ErrorMessage ="Please Confirm Your Password")]
        public string confirmpassword { set; get; }
        public string adminmsg { set; get; }
    }
}