using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaaPinden.Models;

namespace PaaPinden.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Yarn> Yarn { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Follow> Follow { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Identity roller for admin og almindelig bruger
            var admin = new IdentityRole
            {
                Id = "d5e8b2a1-9c74-4e0b-8d36-5c2a1f7e9b40",
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "e6c19d42-5a70-4b83-9e21-7d04a6f8c351" 
            };

            var user = new IdentityRole
            {
                Id = "a4f7c2d9-8b51-4e6a-9c30-2d7e5f1b8a64",
                Name = "user",
                NormalizedName = "USER",
                ConcurrencyStamp = "b3e58a91-6d42-4c70-8f25-9a1d7e6c304b"
            };

            modelBuilder.Entity<IdentityRole>().HasData(admin, user);

            modelBuilder.Entity<Like>() // sørger for at en bruger kun kan like den samme post én gang
                .HasIndex(l => new { l.ApplicationUserID, l.PostID })
                .IsUnique()
                .HasFilter("PostID IS NOT NULL");

            modelBuilder.Entity<Like>() // sørger for at en bruger kun kan like den samme recipe én gang
                .HasIndex(l => new { l.ApplicationUserID, l.RecipeID })
                .IsUnique()
                .HasFilter("RecipeID IS NOT NULL");

            modelBuilder.Entity<Follow>() // sørger for at en bruger kun kan følge den samme bruger én gang
                .HasIndex(f => new { f.FollowerID, f.FollowingID })
                .IsUnique();

            modelBuilder.Entity<Like>() // sørger for at et like tilhører et post eller en recipe
                .ToTable(t => t.HasCheckConstraint(
                    "CK_Like_PostOrRecipe",
                    "(PostID IS NOT NULL AND RecipeID IS NULL) OR " + "(PostID IS NULL AND RecipeID IS NOT NULL)"
                    ));

            modelBuilder.Entity<Comment>() // sørger for at en kommentar tilhører et post eller en recipe
                .ToTable(t => t.HasCheckConstraint(
                    "CK_Comment_PostOrRecipe",
                    "(PostID IS NOT NULL AND RecipeID IS NULL) OR " + "(PostID IS NULL AND RecipeID IS NOT NULL)"
                    ));
            
            modelBuilder.Entity<Follow>() // sørger for at en bruger ikke kan følge sig selv
                .ToTable(t => t.HasCheckConstraint(
                    "CK_Follow_NotSelf", "FollowerID <> FollowingID"
                    ));


            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post) 
                .HasForeignKey(c => c.PostID)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Post>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.ApplicationUserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Recipe>()
               .HasMany(r => r.Comments) 
               .WithOne(c => c.Recipe) 
               .HasForeignKey(c => c.RecipeID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.ApplicationUser)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.ApplicationUserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes) 
                .HasForeignKey(l => l.PostID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Recipe) 
                .WithMany(r => r.Likes) 
                .HasForeignKey(l => l.RecipeID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.ApplicationUser)
                .WithMany(u => u.Likes) 
                .HasForeignKey(l => l.ApplicationUserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ApplicationUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.ApplicationUserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower) 
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.FollowerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Following)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowingID)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
