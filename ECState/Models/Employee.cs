using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECState.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int empid { get; set; }
        public string empname { get; set; }
        public string empfathername { get; set; }
        public string empsalary { get; set; }
        public int country_id { get; set; }
        public int state_id { get; set; }
        public int city_id { get; set; }
        public string email { get; set; }
       


    }
}