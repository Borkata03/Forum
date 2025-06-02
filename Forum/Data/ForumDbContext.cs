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

            modelBuilder.Entity<Category>().HasData(
       new Category { Id = 1, Name = "Chat" },
       new Category { Id = 2, Name = "Car" },
       new Category { Id = 3, Name = "Fitness" },
       new Category { Id = 4, Name = "Technology" },
       new Category { Id = 5, Name = "Gaming" },
       new Category { Id = 6, Name = "Movies & TV" },
       new Category { Id = 7, Name = "Music" },
       new Category { Id = 8, Name = "Books" },
       new Category { Id = 9, Name = "Travel" },
       new Category { Id = 10, Name = "Food & Cooking" },
       new Category { Id = 11, Name = "Education" },
       new Category { Id = 12, Name = "Programming" },
       new Category { Id = 13, Name = "Science" },
       new Category { Id = 14, Name = "Art & Design" },
       new Category { Id = 15, Name = "Photography" },
       new Category { Id = 16, Name = "Health & Wellness" },
       new Category { Id = 17, Name = "Business & Finance" },
       new Category { Id = 18, Name = "Relationships" },
       new Category { Id = 19, Name = "Parenting" },
       new Category { Id = 20, Name = "Pets & Animals" });


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
