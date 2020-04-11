namespace WebApiChat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChat")]
    public partial class Chat
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        public DateTime? SentTime { get; set; }

        public virtual User tblUser { get; set; }
    }
}
