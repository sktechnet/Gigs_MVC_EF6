using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }




        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                    .HasRequired(x=>x.Gig)
                    .WithMany()
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Following>()
                .HasKey(x => new {x.FollowerId, x.FolloweeId})
                .Property(x => x.FolloweeId).HasMaxLength(128);

            modelBuilder.Entity<Following>()
                .Property(x => x.FollowerId).HasMaxLength(128);

            modelBuilder.Entity<ApplicationUser>()
                    .HasMany(x=>x.Followee)
                    .WithRequired(x=>x.Follower)
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>()
                    .HasMany(x=>x.Follower)
                    .WithRequired(x=>x.Followee)
                    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}