using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECState.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int country_id { get; set; }
        public string country_name { get; set; }

        
    }
}