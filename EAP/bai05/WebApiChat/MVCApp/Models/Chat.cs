using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp.Models
{
    public class Chat
    {
        public string Content { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        public DateTime? SentTime { get; set; }
    }
}
