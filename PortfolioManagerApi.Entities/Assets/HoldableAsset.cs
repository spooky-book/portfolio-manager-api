namespace PortfolioManagerApi.Entities.Assets
{
    public abstract class HoldableAsset
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public double AveragePrice { get; set; }

        // Foreign Key
        public Guid PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; } = null;
    }
}
