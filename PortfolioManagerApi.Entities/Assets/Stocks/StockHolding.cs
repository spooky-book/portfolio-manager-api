using PortfolioManagerApi.Entities.Assets;

namespace PortfolioManagerApi.Entities.Assets.Stocks
{
    public class StockHolding : HoldableAsset
    {
        //public Stock Stock { get; set; }

        public string Symbol { get; set; }
        public double TotalQuantity { get; set; }
        public ICollection<StockTransaction> Transactions { get; set; } = new List<StockTransaction>();

        public void AddTransaction(StockTransaction stockTransaction)
        {
            Transactions.Add(stockTransaction);
            TotalQuantity += stockTransaction.Quantity;
        }
    }
}
