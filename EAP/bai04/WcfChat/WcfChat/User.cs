namespace WcfChat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            tblChats = new HashSet<Chat>();
        }

        [Key]
        [StringLength(200)]        
        [Required(ErrorMessage = "You must enter name !!!")]
        public string UserName { get; set; }

        [StringLength(10, ErrorMessage="At least 10 chars")]
        [Required]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chat> tblChats { get; set; }
    }
}
