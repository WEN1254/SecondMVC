using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScendMvc.Models
{
    public partial class ScendMVCContext : DbContext
    {
        public ScendMVCContext()
        {
        }

        public ScendMVCContext(DbContextOptions<ScendMVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<Proposal> Proposal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=scendmvc.database.windows.net;Initial Catalog=ScendMVC;Persist Security Info=True;User ID=ScendMVC;Password=Aa12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.Property(e => e.FavoriteId)
                    .HasColumnName("Favorite_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProjectId).HasColumnName("Project_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.Property(e => e.FeedbackId).HasColumnName("feedbackID");

                entity.Property(e => e.DeliveryTime)
                    .HasColumnName("delivery_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.FeedbackAmount)
                    .HasColumnName("feedback_amount")
                    .HasColumnType("money");

                entity.Property(e => e.FeedbackCover)
                    .HasColumnName("feedback_cover")
                    .HasMaxLength(50);

                entity.Property(e => e.FeedbackLimit)
                    .HasColumnName("feedback_limit")
                    .HasMaxLength(50);

                entity.Property(e => e.FeedbackSummary).HasColumnName("feedback_summary");

                entity.Property(e => e.FeedbackType)
                    .HasColumnName("feedback_type")
                    .HasMaxLength(50);

                entity.Property(e => e.ProposalId).HasColumnName("Proposal_ID");
            });

            modelBuilder.Entity<Proposal>(entity =>
            {
                entity.Property(e => e.ProposalId)
                    .HasColumnName("Proposal_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.CurrentAmount).HasColumnName("Current_Amount");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.FanPage)
                    .HasColumnName("fan_page")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Identity)
                    .HasColumnName("identity")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ImgTeam)
                    .HasColumnName("img_team")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Principal)
                    .HasColumnName("principal")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ProjectCover)
                    .HasColumnName("project_cover")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Resume)
                    .HasColumnName("resume")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Target).HasColumnName("target");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.TimeEnd)
                    .HasColumnName("time_end")
                    .HasColumnType("datetime");

                entity.Property(e => e.TimeStart)
                    .HasColumnName("time_start")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Web)
                    .HasColumnName("web")
                    .HasMaxLength(60)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
