using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebmailServer.Models
{
    public partial class webmailContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserEmail> UserEmail { get; set; }

        public webmailContext(DbContextOptions<webmailContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Email_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserEmail>(entity =>
            {
                entity.Property(e => e.IsRead).HasDefaultValueSql("0");

                entity.Property(e => e.IsStarred).HasDefaultValueSql("0");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.UserEmail)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserEmail_Category");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.UserEmail)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserEmail_Email");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEmail)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserEmail_User");
            });
        }
    }
}