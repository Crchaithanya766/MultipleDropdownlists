using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECState.Models
{
    public class Registration
    {
        [Key]
        public int RegID { get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
        public string EmailId { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string MobilNo { get; set; }

        public string PineCode { get; set; }
        public string Address { get; set; }
        public string VCode { get; set; }




    }
}