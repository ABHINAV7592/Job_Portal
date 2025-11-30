using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace job_portal.Models
{
    public class AddApplication
    {
        public string jobtitle { set; get; }
        public string companyname { set; get; }
        public string description { set; get; }
        public string location { set; get; }
        public string jobsalary { set; get; }
        public DateTime date { set; get; }
        public string resume { set; get; }
        public string applicationmsg { set; get; }
    }
}