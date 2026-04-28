using Microsoft.EntityFrameworkCore;
using RoadmApp.Domain.Entities;

namespace RoadmApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Log> Logs => Set<Log>();
        public DbSet<LogType> LogTypes => Set<LogType>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}