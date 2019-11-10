using Microsoft.EntityFrameworkCore;

using Auth.Core.Entities;

namespace Auth.Infrastructure.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.Entity<User>()
                .Property(u => u.CreatedOn)
                .HasDefaultValueSql("NOW()");

            builder.Entity<User>()
                .Property(u => u.UpdatedOn)
                .HasDefaultValueSql("NOW()");
        }
        
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
    }
}