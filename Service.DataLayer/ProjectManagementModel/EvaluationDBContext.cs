using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Service.DataLayer.ProjectManagementModel
{
    public partial class EvaluationDBContext : DbContext
    {
        //public EvaluationDBContext()
        //{
        //}

        public EvaluationDBContext(DbContextOptions<EvaluationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<ProjectPhaseLevelEvalTbl> ProjectPhaseLevelEvalTbls { get; set; }
        public virtual DbSet<ProjectPhaseLevelTbl> ProjectPhaseLevelTbls { get; set; }
        public virtual DbSet<ProjectPhaseTbl> ProjectPhaseTbls { get; set; }
        public virtual DbSet<ProjectTbl> ProjectTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MUSSAB\\SQLEXPRESS;Database=ProjectManagementDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ProjectPhaseLevelEvalTbl>(entity =>
            {
                entity.HasKey(e => e.ProjectPhaseLevelEvalId);

                entity.ToTable("ProjectPhaseLevelEvalTbl");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProjectPhaseLevel)
                    .WithMany(p => p.ProjectPhaseLevelEvalTbls)
                    .HasForeignKey(d => d.ProjectPhaseLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectPhaseLevelEvalTbl_ProjectPhaseLevelTbl");
            });

            modelBuilder.Entity<ProjectPhaseLevelTbl>(entity =>
            {
                entity.HasKey(e => e.ProjectPhaseLevelId);

                entity.ToTable("ProjectPhaseLevelTbl");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectPhaseLevelEndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectPhaseLevelNameArabic).HasMaxLength(200);

                entity.Property(e => e.ProjectPhaseLevelNameEnglish).HasMaxLength(200);

                entity.Property(e => e.ProjectPhaseLevelStartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProjectPhase)
                    .WithMany(p => p.ProjectPhaseLevelTbls)
                    .HasForeignKey(d => d.ProjectPhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectPhaseLevelTbl_ProjectPhaseTbl");
            });

            modelBuilder.Entity<ProjectPhaseTbl>(entity =>
            {
                entity.HasKey(e => e.ProjectPhaseId);

                entity.ToTable("ProjectPhaseTbl");

                entity.Property(e => e.ProjectPhaseCreatedBy).HasMaxLength(200);

                entity.Property(e => e.ProjectPhaseCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectPhaseEndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectPhaseNameArabic).HasMaxLength(500);

                entity.Property(e => e.ProjectPhaseNameEnglish).HasMaxLength(500);

                entity.Property(e => e.ProjectPhaseStartDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectPhaseUpdatedBy).HasMaxLength(200);

                entity.Property(e => e.ProjectPhaseUpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectPhaseTbls)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectPhaseTbl_ProjectTbl");
            });

            modelBuilder.Entity<ProjectTbl>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("ProjectTbl");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectNameArabic).HasMaxLength(500);

                entity.Property(e => e.ProjectNameEnglish).HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
