namespace doan_htttdn.FF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QL_SCN : DbContext
    {
        public QL_SCN()
            : base("name=QL_SCN")
        {
        }

        public virtual DbSet<Admin_Article> Admin_Article { get; set; }
        public virtual DbSet<Article1> Article1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
