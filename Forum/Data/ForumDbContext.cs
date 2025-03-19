using Forum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class ForumDbContext : IdentityDbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasOne(s => s.Thread)
                .WithMany(t => t.Posts)
                .HasForeignKey(s => s.ThreadId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Infrastructure.Data.Models.Thread>()
              .HasOne(s => s.Category)
              .WithMany(t => t.Threads)
              .HasForeignKey(s => s.CategoryId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
              .HasOne(s => s.Post)
              .WithMany(t => t.Comments)
              .HasForeignKey(s => s.PostId)
              .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Infrastructure.Data.Models.Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
