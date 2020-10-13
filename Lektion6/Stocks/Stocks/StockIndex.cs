using Stocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stocks
{

    public class StockIndex : IStockIndex
    {
        //Stock, price
        private Dictionary<IStock, double> _stockIndex = new Dictionary<IStock, double>();
        public StockIndex(IEnumerable<IStock> validStocks)
        {
            foreach (var stock in validStocks)
            {
                _stockIndex.Add(stock, Helpers.StockRandomValueGenerator.Next());
            }
        }

        public void ChangeStockPrice(IStock stock, double newPrice)
        {
            var stockKvp = _stockIndex.Where(s => s.Key.Name == stock.Name)
                .Select(s => s)
                .FirstOrDefault();

            var eventMessage = new StockPriceChangedEventMessage()
            {
                NewPrice = newPrice,
                OldPrice = stockKvp.Value,
                Stock = stock,
            };

            _stockIndex[stockKvp.Key] = newPrice;

            StockPriceChangedEvent?.Invoke(this, eventMessage);
        }

        public IEnumerable<IStock> GetAllStockTypes()
        {
            return _stockIndex.Keys;
        }

        public double GetStockPrice(IStock stock)
        {
            var stockKvp = _stockIndex.Where(s => s.Key.Name == stock.Name)
                .Select(s => s)
                .FirstOrDefault();
            return stockKvp.Value;
        }


        public event EventHandler<StockPriceChangedEventMessage> StockPriceChangedEvent;
    }
}
