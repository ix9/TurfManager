using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TurfManager.Models
{
    public partial class GDDContext : DbContext
    {
     
        public GDDContext(DbContextOptions<GDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Summary> Summary { get; set; }
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Temperatures> Temperatures { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<ActionSummary> ActionSummary { get; set; }


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

            modelBuilder.Entity<ActionSummary>(entity =>
            {
                entity.ToView(nameof(ActionSummary));
                entity.HasNoKey();
                entity.Property(e => e.ActionID).HasColumnName("ActionID");
                entity.Property(e => e.ActionName).HasColumnName("ActionName");
                entity.Property(e => e.ActionIcon).HasColumnName("ActionIcon");
                entity.Property(e => e.ActionLastDate).HasColumnName("ActionLastDate");
                entity.Property(e => e.ActionDaysAgo).HasColumnName("ActionDaysAgo");

            });

            modelBuilder.Entity<Action>(entity =>
            {
                entity.HasKey(e => e.ActionID)
                  .HasName("PK_Action");
                //entity.Property(e => e.ActionID).HasColumnName("ActionID");
                entity.Property(e => e.ActionName).HasColumnName("ActionName");
                entity.Property(e => e.ActionIcon).HasColumnName("ActionIcon");

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
