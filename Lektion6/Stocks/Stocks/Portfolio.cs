using Microsoft.VisualBasic;
using Stocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stocks
{
    public class Portfolio :IPortfolio
    {
        public event EventHandler PortfolioPricesUpdated;

        private readonly List<IStock> _stocks = new List<IStock>();

        private readonly IStockIndex _stockIndex;
        public Portfolio(IStockIndex stockIndex)
        {
            _stockIndex = stockIndex;
            _stockIndex.StockPriceChangedEvent += OnStockPriceChangedEvent;
        }

        private void OnStockPriceChangedEvent(object? sender, StockPriceChangedEventMessage e)
        {
            var pfSi = GetPortfolioStockInformations();
            if (_stocks.Contains(e.Stock))
                PortfolioPricesUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void AddStock(IStock stock)
        {
            _stocks.Add(stock);
        }

        public IEnumerable<StockInformationDto> GetPortfolioStockInformations()
        {
            var siDto = _stocks.GroupBy(s => s.Symbol)
                .Select(s => s.First())
                .Select(ds=>
                    new StockInformationDto
                    {
                        NumberOfStocks = _stocks.Count(s => s.Symbol == ds.Symbol),
                        StockName = ds.Name,
                        StockSymbol = ds.Symbol,
                        StockValue = _stockIndex.GetStockPrice(ds),
                    });
            return siDto;
        }

        public double GetPortfolioValue()
        {
            return _stocks.Sum(s => _stockIndex.GetStockPrice(s));
        }

    }
}
