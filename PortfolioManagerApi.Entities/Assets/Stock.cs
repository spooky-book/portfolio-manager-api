namespace PortfolioManagerApi.Entities.Assets
{
    public class Stock
    {
        public string Name { get; set; }
        public string Ticker { get; set; }

        public string CurrentPrice { get; set; }

        public Dictionary<DateTime, double> PriceHistory { get; set; }
    }
}
