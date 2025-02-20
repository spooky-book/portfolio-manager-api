using Microsoft.EntityFrameworkCore;
using portfolio_manager_api.Models;
using PortfolioManagerApi.Entities;
using PortfolioManagerApi.Entities.Assets;
using PortfolioManagerApi.Repository;

namespace portfolio_manager_api.Services
{
    public interface IPortfolioContextService
    {
        Task<List<Portfolio>> GetAllPortfolios();
        Task<Portfolio> CreatePortfolio(string name, string description = "");
        void AddAssetToPortolio(string portfolioId, HoldableAsset asset);
        void AddStockToPortfolio(string portfolioId, StockHolding stockHolding);
    }

    public class PortfolioContextService : IPortfolioContextService
    {
        private readonly PortfolioContext _portfolioContext;

        public PortfolioContextService(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public void AddAssetToPortolio(string portfolioId, HoldableAsset asset)
        {
            throw new NotImplementedException();
        }

        public void AddStockToPortfolio(string portfolioId, StockHolding stockHolding)
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
            return await _portfolioContext.Portfolios.ToListAsync();
        }
    }
}
