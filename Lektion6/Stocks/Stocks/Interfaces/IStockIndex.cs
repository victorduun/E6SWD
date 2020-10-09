using System;

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
        void ChangeStockPrice();
        void GetAllStockTypes();
        double GetStockPrice(IStock stock);

        event EventHandler<StockPriceChangedEventMessage> StockPriceChangedEvent;
    }
}
