namespace doan_htttdn.Areas.USER.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Web1 : DbContext
    {
        public Web1()
            : base("name=Web11")
        {
        }

        public virtual DbSet<Admin_Article> Admin_Article { get; set; }
        public virtual DbSet<Article1> Article1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
