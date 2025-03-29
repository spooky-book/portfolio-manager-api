using System.ComponentModel.DataAnnotations;

namespace portfolio_manager_api_dtos
{
    public class CreateStockTransactionRequest
    {
        [Required]
        public string Ticker { get; set; }

        [Required]
        public int AcquiredQuantity { get; set; }

        [Required]
        public DateTimeOffset AcquisitionDateTime { get; set; }

        [Required]
        public double AcquisitionUnitPrice { get; set; }
        
        [Required]
        public double AcquisitionBrokerageFee { get; set; }

        public bool IsDisposed { get; set; }
        public DateTimeOffset DisposalDateTime { get; set; }
        public double DisposalPrice { get; set; }
    }
}
