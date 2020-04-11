using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp.Models
{
    public class User
    {        
        [StringLength(200)]
        [Required]
        public string UserName { get; set; }
        [StringLength(200)]
        [MinLength(2)]
        [Required]
        public string Password { get; set; }

    }
}
