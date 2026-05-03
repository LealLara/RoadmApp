using Microsoft.EntityFrameworkCore;
using RoadmApp.Domain.Entities;

namespace RoadmApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<ContactEntity> Contacts => Set<ContactEntity>();
        public DbSet<LogEntity> Logs => Set<LogEntity>();
        public DbSet<AccessEntity> Accesses => Set<AccessEntity>();
        public DbSet<LogTypeEntity> LogTypes => Set<LogTypeEntity>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}