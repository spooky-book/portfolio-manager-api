using PortfolioManagerApi.Entities;
using PortfolioManagerApi.Proxy;

namespace portfolio_manager_api.Services
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetAllPortfolios();
        Task<Guid> CreatePortfolio(string name, string description);
    }

    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioContextService _portfolioContextService;
        private readonly IStockDataProxy _stockDataProxy;

        public PortfolioService(IPortfolioContextService portfolioContextService, IStockDataProxy stockDataProxy)
        {
            _portfolioContextService = portfolioContextService;
            _stockDataProxy = stockDataProxy;    
        }

        public async Task<Guid> CreatePortfolio(string name, string description)
        {
            var portfolio = await _portfolioContextService.CreatePortfolio(name, description);

            return portfolio.Id;
        }

        public async Task<List<Portfolio>> GetAllPortfolios()
        {
            return await _portfolioContextService.GetAllPortfolios();
        }
    }
}
