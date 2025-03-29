using Microsoft.EntityFrameworkCore;
using PortfolioManagerApi.Entities;
using PortfolioManagerApi.Entities.Assets;
using PortfolioManagerApi.Entities.Assets.Stocks;
using PortfolioManagerApi.Repository;

namespace portfolio_manager_api.Services
{
    public interface IPortfolioContextService
    {
        Task<List<Portfolio>> GetAllPortfolios();
        Task<Portfolio> CreatePortfolio(string name, string description = "");
        Task<HoldableAsset> AddAssetToPortolio(string portfolioId, HoldableAsset asset);
        void AddStockTransactionToPortfolio(string portfolioId, StockHolding stockHolding);
        Task<Portfolio> GetSinglePortfolio(string portfolioId);
        Task SavePortfolioContext();
    }

    public class PortfolioContextService : IPortfolioContextService
    {
        private readonly PortfolioContext _portfolioContext;

        public PortfolioContextService(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public async Task<HoldableAsset> AddAssetToPortolio(string portfolioId, HoldableAsset asset)
        {
            var guid = new Guid(portfolioId);
            Portfolio portfolio;
            try
            {
                portfolio = await _portfolioContext.Portfolios.Include(x => x.Assets).FirstAsync(x => x.Id.Equals(guid));
            }
            catch (Exception e)
            {
                // log
                throw;
            }

            portfolio.Assets.Add(asset);

            await _portfolioContext.SaveChangesAsync();

            return asset;
        }

        public void AddStockTransactionToPortfolio(string portfolioId, StockHolding stockHolding)
        {
            throw new NotImplementedException();
        }

        public async Task<Portfolio> CreatePortfolio(string name, string description = "")
        {
            var portfolio = new Portfolio(name, description);

            _portfolioContext.Portfolios.Add(portfolio);

            await _portfolioContext.SaveChangesAsync();

            return portfolio;
        }

        public async Task<List<Portfolio>> GetAllPortfolios()
        {
            return await _portfolioContext.Portfolios
                .Include(x => x.Assets)
                .ToListAsync();
        }

        public async Task<Portfolio> GetSinglePortfolio(string portfolioId)
        {
            return await _portfolioContext.Portfolios
                .Include(x => x.Assets)
                .FirstAsync(x => x.Id.Equals(new Guid(portfolioId)));
        }

        public async Task SavePortfolioContext()
        {
            await _portfolioContext.SaveChangesAsync();
        }
    }
}
