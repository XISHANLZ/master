using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LZ.Model.Models;

namespace LZ.Model.EntityContext
{
    public partial class EntityContext : DbContext
    {
        public EntityContext()
        {
        }

        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<LoginLog> LoginLog { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRoleRelation> UserRoleRelation { get; set; }
        public virtual DbSet<Wage> Wage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.;database=LZ;uid=sa;pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.ToTable("Login_Info");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.ToTable("Login_Log");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LoginTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("登录时间");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UserRoleRelation>(entity =>
            {
                entity.ToTable("User_Role_Relation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Wage>(entity =>
            {
                entity.HasKey(e => e.UpdateTime);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AccumulationFundCompany)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("公积金-公司部分");

                entity.Property(e => e.AccumulationFundPrivate)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("公积金-私人部分");

                entity.Property(e => e.Achievements)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("绩效工资");

                entity.Property(e => e.ActualPayment)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("实际发放给员工工资");

                entity.Property(e => e.AgeWage)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("年龄工资");

                entity.Property(e => e.Base).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmploymentInjuryInsurance1)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("工伤保险-公司部分");

                entity.Property(e => e.EmploymentInjuryInsurancePrivate)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("工伤保险");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.EndowmentInsuranceCompany)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("养老保险-公司部分");

                entity.Property(e => e.EndowmentInsurancePrivate)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("养老保险");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MaternityInsuranceCompany)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("生育保险-公司部分");

                entity.Property(e => e.MaternityInsurancePrivate)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("生育保险");

                entity.Property(e => e.MedicalInsuranceCompany)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("医疗保险-公司部分");

                entity.Property(e => e.MedicalInsurancePrivate)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("医疗保险");

                entity.Property(e => e.Month).HasColumnType("datetime");

                entity.Property(e => e.Other).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.ToTalCompany)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("公司总缴");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalReduction)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("总共减少（五险一金私人部分相加）");

                entity.Property(e => e.UnemploymentInsurance1)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("失业保险-公司部分");

                entity.Property(e => e.UnemploymentInsurancePrivate)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("失业保险");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
