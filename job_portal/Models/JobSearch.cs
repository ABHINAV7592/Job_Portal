using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace job_portal.Models
{
    public class JobSearch
    {
        
            public JobSearch()
            {
                selectjob = new List<jobList>();
                insertse = new jobList();
            }

            public jobList insertse { set; get; }

            public List<jobList> selectjob { set; get; }
     }

        public class jobList
        {

            public int Job_id { get; set; }

            public int Company_id { get; set; }
            public string Job_Tittle { get; set; }

            public string Job_description { get; set; }

            public string Job_Experience { get; set; }

            public string Job_Skills { get; set; }

            public string Job_Salary { get; set; }

            public System.DateTime Job_enddate { get; set; }

            public string Job_Location { get; set; }

            public string Job_Status { get; set; }

            public int jobype_Id { get; set; }

            public string jobtype_name { get; set; }
        }
    }
