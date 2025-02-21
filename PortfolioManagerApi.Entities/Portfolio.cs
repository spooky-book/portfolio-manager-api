using PortfolioManagerApi.Entities.Assets;

namespace PortfolioManagerApi.Entities
{
    public class Portfolio
    {
        public Portfolio(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<HoldableAsset> Assets { get; set; } = new List<HoldableAsset>();
    }
}
