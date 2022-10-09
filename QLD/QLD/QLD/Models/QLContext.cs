using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLD.Models
{
    public partial class QLContext : DbContext
    {
        public QLContext()
        {
        }

        public QLContext(DbContextOptions<QLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<Hocsinh> Hocsinhs { get; set; }
        public virtual DbSet<Lophoc> Lophocs { get; set; }
        public virtual DbSet<Monhoc> Monhocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=HTT; database=QL ;uid=sa;pwd=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Diem>(entity =>
            {
                entity.ToTable("Diem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.Class)
                    .HasConstraintName("FK_Diem_Lophoc");

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.Student)
                    .HasConstraintName("FK_Diem_Hocsinh");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.Subject)
                    .HasConstraintName("FK_Diem_Monhoc");

                entity.HasOne(d => d.TeacherNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.Teacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_Account");
            });

            modelBuilder.Entity<Hocsinh>(entity =>
            {
                entity.ToTable("Hocsinh");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mssv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MSSV");
            });

            modelBuilder.Entity<Lophoc>(entity =>
            {
                entity.ToTable("Lophoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.ToTable("Monhoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
