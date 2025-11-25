using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace job_portal.Models
{
    public class LoginInsert
    {
        [Required(ErrorMessage ="Enter Email")]
        public string email { set; get; }
        [Required(ErrorMessage ="Enter Password")]
        public string password { set; get; }
        public string logintype { set; get; }
        public string loginmsg { set; get; }
    }
}