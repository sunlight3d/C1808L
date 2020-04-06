namespace bai04
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ChatDb : DbContext
    {
        public ChatDb()
            : base("name=ChatDB")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Chat> tblChats { get; set; }
        public virtual DbSet<User> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.tblChats)
                .WithRequired(e => e.tblUser)
                .WillCascadeOnDelete(false);
        }
    }
}
