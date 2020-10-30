using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TurfManager.Models
{
    public partial class GDDContext : DbContext
    {
        //public GDDContext()
        //{
        //}

        public GDDContext(DbContextOptions<GDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Summary> Summary { get; set; }
        public virtual DbSet<Temperatures> Temperatures { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=gddxrw.database.windows.net;Database=GDD;User ID=gddtracker;Password=Gddapp123;Encrypt=True;TrustServerCertificate=False");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Summary>(entity =>
            {
                entity.Property(e => e.SummaryId).HasColumnName("SummaryID");

                entity.Property(e => e.SummaryDateGenerated).HasColumnType("datetime");

                entity.Property(e => e.SummaryDateString)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.SummaryDateWst)
                    .HasColumnName("SummaryDateWST")
                    .HasColumnType("datetime");

                entity.Property(e => e.SummaryGddtotal)
                    .HasColumnName("SummaryGDDTotal")
                    .HasColumnType("decimal(2, 0)");

                entity.Property(e => e.SummaryMaxTemp).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.SummaryMinTemp).HasColumnType("decimal(2, 0)");
            });

            modelBuilder.Entity<Temperatures>(entity =>
            {
                entity.HasKey(e => e.ReadingKey)
                    .HasName("PK_Temps");

                entity.Property(e => e.ReadingDateString)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.ReadingDateTimeWst)
                    .HasColumnName("ReadingDateTimeWST")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReadingValue).HasColumnType("decimal(2, 0)");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CBE44B499");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
