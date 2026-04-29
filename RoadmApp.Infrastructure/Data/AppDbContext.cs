using Microsoft.EntityFrameworkCore;
using RoadmApp.Domain.Entities;

namespace RoadmApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<LogEntity> Logs => Set<LogEntity>();
        public DbSet<LogTypeEntity> LogTypes => Set<LogTypeEntity>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}