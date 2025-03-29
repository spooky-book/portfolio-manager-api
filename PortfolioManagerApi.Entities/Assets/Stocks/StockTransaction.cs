namespace PortfolioManagerApi.Entities.Assets.Stocks
{
    public class StockTransaction : Transaction
    {
        public double TotalAcquisitionPrice { get; set; }
        public DateTimeOffset AcquisitionDateTime { get; set; }
        public double AcquisitionUnitPrice { get; set; }
        public double AcquisitionBrokerageFee { get; set; }
        public int Quantity { get; set; }

        public bool IsDisposed { get; set; }
        public DateTimeOffset DisposalDateTime { get; set; }
        public double DisposalPrice { get; set; }
    }
}
