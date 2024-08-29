using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace gym.Models
{
    public partial class gymContext : DbContext
    {
        public gymContext()
        {
        }

        public gymContext(DbContextOptions<gymContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<Membership> Memberships { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Sınıflar> Sınıflars { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-UE43HMH;initial Catalog=gym;trusted_connection=yes ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Bookings__ClassI__2F10007B");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Bookings__Member__2E1BDC42");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Membershi__Membe__2B3F6F97");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Payments__Member__31EC6D26");
            });

            modelBuilder.Entity<Sınıflar>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK__Sınıflar__CB1927A0A97BBFA0");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Sınıflars)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK__Sınıflars__Train__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
