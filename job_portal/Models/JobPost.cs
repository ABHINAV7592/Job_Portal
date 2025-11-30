using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace job_portal.Models
{
    public class postjobskillcheckbox
    {
        public string skillvalue { set; get; }
        public string skilltext { set; get; }
        public bool skillischecked { set; get; }
    }
    public class postjobqualcheckbox
    {
        public string qualvalue { set; get; }
        public string qualtext { set; get; }
        public bool qualischecked { set; get; }
    }
    public class JobPost
    {
        [Required(ErrorMessage ="Enter Job Title")]
        public string jobtitle { set; get; }
        [Required(ErrorMessage ="Enter Job Location")]
        public string location { set; get; }
        [Required(ErrorMessage = "Enter Experience In Years")]
        public int experience { set; get; }
        public List<postjobskillcheckbox> jobskill { set; get; }
        public string[] selectedjobskill { set; get; }
        public string skills { set; get; }
        public List<postjobqualcheckbox> jobqualification { set; get; }
        public string[] selectedjobqual { set; get; }
        public string qualification { set; get; }
        [Required(ErrorMessage ="Enter Passout Year")]
        public int passoutyear { set; get; }
        
        [Required(ErrorMessage ="Enter Start Date")]
        public DateTime jobstartdate { set; get; }
        [Required(ErrorMessage = "Enter End Date")]
        public DateTime jobenddate { set; get; }
        [Required(ErrorMessage = "Enter Job Description")]
        public string jobdescription { set; get; }
        [Required(ErrorMessage = "Enter Job Type")]
        public string jobtype { set; get; }
        [Required(ErrorMessage ="Enter Salary")]
        public string jobsalary { set; get; }
        public string jobmsg { set; get; }
    }
}