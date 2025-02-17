using PortfolioManagerApi.Proxy;

namespace portfolio_manager_api.Services
{
    public interface IPortfolioService
    {
        void Test();
    }

    public class PortfolioService : IPortfolioService
    {
        private readonly IStockDataProxy _stockDataProxy;

        public PortfolioService(IStockDataProxy stockDataProxy)
        {
            _stockDataProxy = stockDataProxy;    
        }

        public void Test()
        {
            var test = _stockDataProxy.GetStockPriceHistory("asx", "ivv");
            Console.WriteLine(test);
        }
    }
}
