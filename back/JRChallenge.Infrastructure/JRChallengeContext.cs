using JRChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JRChallenge.Infrastructure
{
    public class JRChallengeContext : DbContext
    {
        public JRChallengeContext(DbContextOptions<JRChallengeContext> options) : base(options) { }
        public DbSet<Permissions> Permissions { get; set; }

        public DbSet<PermissionTypes> Type { get; set; }
    }
}
