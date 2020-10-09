using System;
using System.Collections.Generic;
using System.Text;
using Stocks.Interfaces;

namespace Stocks
{
    public class PortfolioDisplay : IPortfolioDisplay
    {
        private readonly IPortfolio _portfolio;
        public PortfolioDisplay(IPortfolio portfolio)
        {
            _portfolio = portfolio;
            _portfolio.PortfolioPricesUpdated += OnPortfolioPricesUpdated;
        }

        private void OnPortfolioPricesUpdated(object? sender, EventArgs e)
        {
            DisplayPortfolio();
        }

        private void printer()
        {
            Console.WriteLine("Symbol \t Name \t Number of stocks \t Price per stock \t Total stock value");
            foreach (var s in _portfolio.GetPortfolioStockInformations()) //insert dummy portfolio
            {
                Console.WriteLine("{2} \t \t \t \t \t \t \t {2} \t {2} \t {2} ", s.StockSymbol, s.StockName, s.NumberOfStocks, s.StockValue);
            }
        }


        public void DisplayPortfolio()
        {
            printer();
        }
    }
}
