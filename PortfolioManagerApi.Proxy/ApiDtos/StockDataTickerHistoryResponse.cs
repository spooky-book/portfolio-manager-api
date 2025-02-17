namespace PortfolioManagerApi.Proxy.ApiDtos
{
    public class StockDataTickerHistoryResponse
    {
        public List<HistoricalData> HistoricalData { get; set; }
    }

    public class HistoricalData
    {
        public double ClosingPrice { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
