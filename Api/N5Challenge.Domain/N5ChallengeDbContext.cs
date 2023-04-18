using Microsoft.EntityFrameworkCore;
using N5Challenge.Domain.Configuration;
using N5Challenge.Domain.Entities;

namespace N5Challenge.Domain
{
    public class N5ChallengeDbContext: DbContext
    {
        public N5ChallengeDbContext(DbContextOptions<N5ChallengeDbContext> options) : base(options) { }

        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        }
    }
}