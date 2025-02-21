using portfolio_manager_api.Models;
using portfolio_manager_api_dtos;
using PortfolioManagerApi.Entities;
using PortfolioManagerApi.Proxy;

namespace portfolio_manager_api.Services
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetAllPortfolios();
        Task<Guid> CreatePortfolio(string name, string description);
        Task<Guid> CreateStock(string portfolioId, CreateStockHoldingRequest request);
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

        public async Task<Guid> CreateStock(string portfolioId, CreateStockHoldingRequest request)
        {
            var stock = new StockHolding
            {
                Symbol = request.Ticker,
                Quantity = request.Quantity,
                AcquisitionDateTime = request.AcquisitionDateTime,
                AcquisitionPrice = request.AcquisitionPrice,
                IsDisposed = request.IsDisposed,
                DisposalDateTime = request.DisposalDateTime,
                DisposalPrice = request.DisposalPrice
            };

            var createdStock = await _portfolioContextService.AddAssetToPortolio(portfolioId, stock);

            return createdStock.Id;
        }

        public async Task<List<Portfolio>> GetAllPortfolios()
        {
            return await _portfolioContextService.GetAllPortfolios();
        }
    }
}
