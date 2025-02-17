using PortfolioManagerApi.Proxy.ApiDtos;
using System.Diagnostics;
using System.Net.Http.Json;

namespace PortfolioManagerApi.Proxy
{
    public interface IStockDataProxy
    {
        Task<StockDataTickerHistoryResponse> GetStockPriceHistory(string securityExchange, string ticker);
    }

    public class StockDataProxy : IStockDataProxy
    {
        private readonly HttpClient _httpClient;

        public StockDataProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<StockDataTickerHistoryResponse> GetStockPriceHistory(string securityExchange, string ticker)
        {
            StockDataTickerHistoryResponse? response;
            try
            {
                Debug.WriteLine($"{nameof(GetStockPriceHistory)}: Starting http call to retrieve stock prices from stock price api. securityExchange {securityExchange}, ticker {ticker}");
                // need to add message handler that logs non 200 statuses
                response = await _httpClient.GetFromJsonAsync<StockDataTickerHistoryResponse>($"/ticker/{securityExchange}/{ticker}/history");
            }
            catch (Exception e)
            {
                // log exception
                Debug.WriteLine($"{nameof(GetStockPriceHistory)}: Exception occurred:" + e);
                throw;
            }

            if (response?.HistoricalData is null)
            {
                Debug.WriteLine($"{nameof(GetStockPriceHistory)}: Response from stock price api was null or empty");
                // make better exception 
                throw new Exception();
            }

            Debug.WriteLine($"{nameof(GetStockPriceHistory)}: Successfully retrieved stock prices from the stock price api. securityExchange {securityExchange}, ticker {ticker}");
            return response;
        }
    }
}
