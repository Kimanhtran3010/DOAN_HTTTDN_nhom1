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

        public virtual DbSet<ACCOUNT> ACCOUNT { get; set; }
        public virtual DbSet<ADMIN> ADMIN { get; set; }
        public virtual DbSet<ADMINs> ADMINs { get; set; }
        public virtual DbSet<ARTICLE> ARTICLE { get; set; }
        public virtual DbSet<CLASS> CLASS { get; set; }
        public virtual DbSet<CLASS_STUDENT> CLASS_STUDENT { get; set; }
        public virtual DbSet<COURSE> COURSE { get; set; }
        public virtual DbSet<DETAIL_ORDERS> DETAIL_ORDERS { get; set; }
        public virtual DbSet<ORDERS> ORDERS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<PROMOTION> PROMOTION { get; set; }
        public virtual DbSet<RIGISTRATION_COURSE> RIGISTRATION_COURSE { get; set; }
        public virtual DbSet<STUDENT> STUDENT { get; set; }
        public virtual DbSet<TEACHER> TEACHER { get; set; }
        public virtual DbSet<TEACHING_CLASS> TEACHING_CLASS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.IDTeacher)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasOptional(e => e.TEACHER)
                .WithRequired(e => e.ACCOUNT);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.IDAmin)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ADMINs>()
                .Property(e => e.IDAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<ADMINs>()
                .HasMany(e => e.ARTICLE)
                .WithRequired(e => e.ADMINs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ARTICLE>()
                .Property(e => e.IDArticler)
                .IsUnicode(false);

            modelBuilder.Entity<ARTICLE>()
                .Property(e => e.IDAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<CLASS>()
                .Property(e => e.IDClass)
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

            modelBuilder.Entity<CLASS_STUDENT>()
                .Property(e => e.IDClass)
                .IsUnicode(false);

            modelBuilder.Entity<CLASS_STUDENT>()
                .Property(e => e.IDStudent)
                .IsUnicode(false);

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
                .HasMany(e => e.CLASS)
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

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.IDPromotion)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.PriceTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ORDERS>()
                .HasMany(e => e.DETAIL_ORDERS)
                .WithRequired(e => e.ORDERS)
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
                .Property(e => e.IDStudent)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .HasMany(e => e.CLASS_STUDENT)
                .WithRequired(e => e.STUDENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEACHER>()
                .Property(e => e.IDTeacher)
                .IsUnicode(false);

            modelBuilder.Entity<TEACHER>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<TEACHER>()
                .HasMany(e => e.TEACHING_CLASS)
                .WithRequired(e => e.TEACHER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEACHING_CLASS>()
                .Property(e => e.IDClass)
                .IsUnicode(false);

            modelBuilder.Entity<TEACHING_CLASS>()
                .Property(e => e.IDTeacher)
                .IsUnicode(false);
        }
    }
}
