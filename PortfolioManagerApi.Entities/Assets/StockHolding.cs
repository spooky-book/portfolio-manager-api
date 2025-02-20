using PortfolioManagerApi.Entities.Assets;

namespace portfolio_manager_api.Models
{
    public class StockHolding : HoldableAsset
    {
        public Stock Stock { get; set; }

        public DateTime PurchaseTime { get; set; }
        public double PurchasePrice { get; set; }

        public DateTime SellTime { get; set; }
        public double SellPrice { get; set; }
    }
}
