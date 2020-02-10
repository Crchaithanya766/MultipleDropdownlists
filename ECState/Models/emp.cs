using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace ECState.Models
{
    public class emp
    {
      
        public int empid { get; set; }
        public string empname { get; set; }
        public string empfathername { get; set; }
        public string empsalary { get; set; }
        public int country_id { get; set; }
        public int state_id { get; set; }
        public int city_id { get; set; }
        public string country_name { get; set; }
        public string state_name { get; set; }
        public string city_name { get; set; }
        public string email { get; set; }
      

    }
}