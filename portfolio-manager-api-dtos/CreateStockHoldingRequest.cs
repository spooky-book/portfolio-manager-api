using System.ComponentModel.DataAnnotations;

namespace portfolio_manager_api_dtos
{
    public class CreateStockHoldingRequest
    {
        [Required]
        public string Ticker { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTimeOffset AcquisitionDateTime { get; set; }

        [Required]
        public double AcquisitionPrice { get; set; }

        public bool IsDisposed { get; set; }
        public DateTimeOffset DisposalDateTime { get; set; }
        public double DisposalPrice { get; set; }
    }
}
