using Microsoft.EntityFrameworkCore;
using PortfolioManagerApi.Entities;

namespace PortfolioManagerApi.Repository
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Portfolio> Portfolios { get; set; }

        public string DbPath;

        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var localFolderPath = Environment.GetFolderPath(folder);
            var DbDirectoryPath = Path.Combine(localFolderPath, "portfolio-manager", "databases");
            DbPath = Path.Combine(DbDirectoryPath, "portfolio.db");

            if (!Directory.Exists(DbDirectoryPath))
            {
                Directory.CreateDirectory(DbDirectoryPath);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>().ToTable("Portfolio");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}", b => b.MigrationsAssembly("PortfolioManagerApi"));
    }
}
