namespace PortfolioManagerApi.Entities.Assets
{
    public abstract class HoldableAsset
    {
        public Guid Id { get; set; }

        // Foreign Key
        public Guid PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; } = null;

        // a print function
    }
}
