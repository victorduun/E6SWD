using System;
using System.Collections.Generic;

namespace Stocks.Interfaces
{
    public class StockPriceChangedEventMessage
    {
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public IStock Stock { get; set; }
    }
    public interface IStockIndex
    {
        void ChangeStockPrice(IStock stock, double newPrice);
        IEnumerable<IStock> GetAllStockTypes();
        double GetStockPrice(IStock stock);

        event EventHandler<StockPriceChangedEventMessage> StockPriceChangedEvent;
    }
}
