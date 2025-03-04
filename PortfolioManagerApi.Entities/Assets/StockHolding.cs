﻿using PortfolioManagerApi.Entities.Assets;

namespace portfolio_manager_api.Models
{
    public class StockHolding : HoldableAsset
    {
        //public Stock Stock { get; set; }

        public DateTimeOffset AcquisitionDateTime { get; set; }
        public double AcquisitionPrice { get; set; }

        public bool IsDisposed { get; set; }
        public DateTimeOffset DisposalDateTime { get; set; }
        public double DisposalPrice { get; set; }
    }
}
