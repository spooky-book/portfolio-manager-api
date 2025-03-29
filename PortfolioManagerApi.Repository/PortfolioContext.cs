using Microsoft.EntityFrameworkCore;
using PortfolioManagerApi.Entities;
using PortfolioManagerApi.Entities.Assets;
using PortfolioManagerApi.Entities.Assets.Stocks;

namespace PortfolioManagerApi.Repository
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<HoldableAsset> Assets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

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
            modelBuilder.Entity<Portfolio>()
                .ToTable("Portfolios");

            modelBuilder.Entity<HoldableAsset>()
                .ToTable("Assets")
                .HasOne(a => a.Portfolio)
                .WithMany(a => a.Assets)
                .HasForeignKey(a => a.PortfolioId);
            modelBuilder.Entity<HoldableAsset>()
                .HasDiscriminator<string>("AssetType")
                .HasValue<StockHolding>("Stock");

            modelBuilder.Entity<Transaction>()
                .ToTable("Transactions");
            modelBuilder.Entity<Transaction>()
                .HasDiscriminator<string>("TransactionType")
                .HasValue<StockTransaction>("Stock");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}", b => b.MigrationsAssembly("PortfolioManagerApi"));
    }
}
