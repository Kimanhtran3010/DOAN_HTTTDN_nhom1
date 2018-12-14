namespace doan_htttdn.FF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QL_SCN : DbContext
    {
        public QL_SCN()
            : base("name=QL_SCN1")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<Admin_Article> Admin_Article { get; set; }
        public virtual DbSet<ARTICLE> ARTICLEs { get; set; }
        public virtual DbSet<CLASS> CLASSes { get; set; }
        public virtual DbSet<CLASS_STUDENT> CLASS_STUDENT { get; set; }
        public virtual DbSet<COURSE> COURSEs { get; set; }
        public virtual DbSet<DETAIL_ORDERS> DETAIL_ORDERS { get; set; }
        public virtual DbSet<Menu_Article> Menu_Article { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<PROMOTION> PROMOTIONs { get; set; }
        public virtual DbSet<RIGISTRATION_COURSE> RIGISTRATION_COURSE { get; set; }
        public virtual DbSet<STUDENT> STUDENTs { get; set; }
        public virtual DbSet<TEACHER> TEACHERs { get; set; }
        public virtual DbSet<TEACHING_CLASS> TEACHING_CLASS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Admin_Article>()
                .Property(e => e.IDAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<Admin_Article>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Admin_Article>()
                .HasMany(e => e.ARTICLEs)
                .WithRequired(e => e.Admin_Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ARTICLE>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<ARTICLE>()
                .Property(e => e.IDAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<CLASS>()
                .Property(e => e.IDCourse)
                .IsUnicode(false);

            modelBuilder.Entity<CLASS>()
                .HasMany(e => e.CLASS_STUDENT)
                .WithRequired(e => e.CLASS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLASS>()
                .HasMany(e => e.TEACHING_CLASS)
                .WithRequired(e => e.CLASS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE>()
                .Property(e => e.IDCourse)
                .IsUnicode(false);

            modelBuilder.Entity<COURSE>()
                .Property(e => e.Fee)
                .HasPrecision(19, 4);

            modelBuilder.Entity<COURSE>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<COURSE>()
                .HasMany(e => e.CLASSes)
                .WithRequired(e => e.COURSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE>()
                .HasMany(e => e.RIGISTRATION_COURSE)
                .WithRequired(e => e.COURSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DETAIL_ORDERS>()
                .Property(e => e.IDRobot)
                .IsUnicode(false);

            modelBuilder.Entity<DETAIL_ORDERS>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Menu_Article>()
                .HasMany(e => e.ARTICLEs)
                .WithRequired(e => e.Menu_Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.IDPromotion)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.PriceTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.DETAIL_ORDERS)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.IDRobot)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.DETAIL_ORDERS)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROMOTION>()
                .Property(e => e.IDPromotion)
                .IsUnicode(false);

            modelBuilder.Entity<PROMOTION>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.PROMOTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIGISTRATION_COURSE>()
                .Property(e => e.IDRegist)
                .IsUnicode(false);

            modelBuilder.Entity<RIGISTRATION_COURSE>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<RIGISTRATION_COURSE>()
                .Property(e => e.IDCourse)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .HasMany(e => e.CLASS_STUDENT)
                .WithRequired(e => e.STUDENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEACHER>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<TEACHER>()
                .HasOptional(e => e.ACCOUNT)
                .WithRequired(e => e.TEACHER);

            modelBuilder.Entity<TEACHER>()
                .HasMany(e => e.TEACHING_CLASS)
                .WithRequired(e => e.TEACHER)
                .WillCascadeOnDelete(false);
        }
    }
}
