using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UpmessageMVCNETCore.Model
{
    public partial class HatunWillanaContext : DbContext
    {
        public HatunWillanaContext()
        {
        }

        public HatunWillanaContext(DbContextOptions<HatunWillanaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Discussion> Discussions { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostTemp> PostTemps { get; set; }
        public virtual DbSet<SavedPost> SavedPosts { get; set; }
        public virtual DbSet<SavedPost1> SavedPosts1 { get; set; }
        public virtual DbSet<User> Users { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ACER-SMALL;Database=HatunWillana;Trusted_Connection=True;");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Discussion");

                entity.Property(e => e.DiscussionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DiscussionID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.PostId).HasColumnName("PostID");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.Body).HasMaxLength(1500);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DiscussionId).HasColumnName("DiscussionID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<PostTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PostTemp");

                entity.Property(e => e.Body).HasMaxLength(1500);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DiscussionId).HasColumnName("DiscussionID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.PostId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PostID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SavedPost>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SavedPost");

                entity.Property(e => e.DateSaved).HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SavedPost1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SavedPosts");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
