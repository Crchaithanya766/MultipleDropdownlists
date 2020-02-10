using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECState.Models
{
    [Table("State")]
    public class State
    {

      
        [Key]
        public int state_id { get; set; }
        public string state_name { get; set; }
        
        public int country_id { get; set; }
    }
}