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

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<ADMIN1> ADMINs1 { get; set; }
        public virtual DbSet<ARTICLE> ARTICLEs { get; set; }
        public virtual DbSet<CLASS> CLASSes { get; set; }
        public virtual DbSet<CLASS_STUDENT> CLASS_STUDENT { get; set; }
        public virtual DbSet<COURSE> COURSEs { get; set; }
        public virtual DbSet<DETAIL_ORDERS> DETAIL_ORDERS { get; set; }
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

            modelBuilder.Entity<ADMIN1>()
                .Property(e => e.IDAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN1>()
                .HasMany(e => e.ARTICLEs)
                .WithRequired(e => e.ADMIN)
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
                .HasMany(e => e.CLASSes)
                .WithRequired(e => e.COURSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE>()
                .HasMany(e => e.RIGISTRATION_COURSE)
                .WithRequired(e => e.COURSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DETAIL_ORDERS>()
                .Property(e => e.IDOrders)
                .IsUnicode(false);

            modelBuilder.Entity<DETAIL_ORDERS>()
                .Property(e => e.IDRobot)
                .IsUnicode(false);

            modelBuilder.Entity<DETAIL_ORDERS>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.IDOrders)
                .IsUnicode(false);

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
                .Property(e => e.NameParent)
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
