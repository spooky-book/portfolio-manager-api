using portfolio_manager_api_dtos;
using PortfolioManagerApi.Entities;
using PortfolioManagerApi.Entities.Assets.Stocks;
using PortfolioManagerApi.Proxy;

namespace portfolio_manager_api.Services
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetAllPortfolios();
        Task<Guid> CreatePortfolio(string name, string description);
        Task<Guid> CreateStockTransaction(string portfolioId, CreateStockTransactionRequest request);
        Task<StockHolding> GetStockHolding(string portfolioId, string stockTicker);
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

        // THE NEXT THING TO DO SHOULD BE TO IMPLEMENT A GET FUNCTIONALITY FOR A SPEICIFC STOCK HOLDING IN A PORTFOLIO
        // SHOULD RETURN ALL THE AGGREGATED DETAILS OF THAT STOCK HOLDING

        // tHE NEXT THING THAT SHOULD BE DONE IS INTEGRATE THE PRICING OF THE STOCKS INTO THIS, SO CONNECTING WITH THE OTHER API 

        public async Task<Guid> CreateStockTransaction(string portfolioId, CreateStockTransactionRequest request)
        {
            var portfolio = await _portfolioContextService.GetSinglePortfolio(portfolioId);
            var stockHolding = portfolio.Assets.OfType<StockHolding>().FirstOrDefault(x => x.Symbol.Equals(request.Ticker, StringComparison.OrdinalIgnoreCase));
            if (stockHolding is null)
            {
                stockHolding = new StockHolding
                {
                    Symbol = request.Ticker
                };

                portfolio.Assets.Add(stockHolding);
            }

            var transaction = new StockTransaction
            {
                AcquisitionBrokerageFee = request.AcquisitionBrokerageFee,
                AcquisitionDateTime = request.AcquisitionDateTime,
                AcquisitionUnitPrice = request.AcquisitionUnitPrice,
                TotalAcquisitionPrice = request.AcquisitionUnitPrice * request.AcquiredQuantity + request.AcquisitionBrokerageFee,
                DisposalDateTime = request.DisposalDateTime,
                DisposalPrice = request.DisposalPrice,
                IsDisposed = request.IsDisposed,
            };

            stockHolding.AddTransaction(transaction);

            await _portfolioContextService.SavePortfolioContext();

            return transaction.Id;
        }

        public async Task<List<Portfolio>> GetAllPortfolios()
        {
            return await _portfolioContextService.GetAllPortfolios();
        }

        public async Task<StockHolding> GetStockHolding(string portfolioId, string stockTicker)
        {
            var portfolio = await _portfolioContextService.GetSinglePortfolio(portfolioId) ?? throw new Exception();

            var stockHolding = portfolio.Assets.OfType<StockHolding>().FirstOrDefault(x => x.Symbol.Equals(stockTicker, StringComparison.OrdinalIgnoreCase)) ?? throw new Exception();

            return stockHolding;
        }
    }
}
