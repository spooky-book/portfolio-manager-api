namespace portfolio_manager_api.Models
{
    public class Portfolio
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<HoldableAsset> Assets { get; set; }
    }
}
