using System;
using System.Collections.Generic;
using ControlePenal.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ControlePenal.Context
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CriminalCodeContext> Criminalcodes { get; set; } = null!;
        public virtual DbSet<StatusContext> Statuses { get; set; } = null!;
        public virtual DbSet<UserContext> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<CriminalCodeContext>(entity =>
            {
                entity.HasKey(e => e.IdCriminalCode)
                    .HasName("PRIMARY");

                entity.ToTable("criminalcode");

                entity.HasIndex(e => e.StatusId, "CriminalCode_fk0");

                entity.HasIndex(e => e.CreateUserId, "CriminalCode_fk1");

                entity.HasIndex(e => e.UpdateUserId, "CriminalCode_fk2");

                entity.Property(e => e.IdCriminalCode)
                    .HasColumnType("int(11)")
                    .HasColumnName("Id_CriminalCode");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CreateUserID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Penalty).HasPrecision(10);

                entity.Property(e => e.PrisonTime).HasColumnType("int(11)");

                entity.Property(e => e.StatusId)
                    .HasColumnType("int(11)")
                    .HasColumnName("StatusID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("UpdateUserID");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.CriminalcodeCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CriminalCode_fk1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Criminalcodes)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CriminalCode_fk0");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.CriminalcodeUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CriminalCode_fk2");
            });

            modelBuilder.Entity<StatusContext>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PRIMARY");

                entity.ToTable("status");

                entity.Property(e => e.IdStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("Id_Status");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<UserContext>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("Id_User");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
