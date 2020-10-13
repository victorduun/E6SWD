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
            Console.WriteLine("|{0,10}|{1,50}|{2,16}|{3,16}|{4,18}|", "Symbol", "Name", "Number of stocks", "Price per stock", "Total stock value");

            foreach (var s in _portfolio.GetPortfolioStockInformations()) //insert dummy portfolio
            {
                Console.WriteLine("|{0,10}|{1,50}|{2,16}|{3,16:N1}|{4,18:N1}|", s.StockSymbol, s.StockName, s.NumberOfStocks, s.StockValue, s.StockValue * s.NumberOfStocks);
            }

            Console.WriteLine("Total portfolio value: {0:N1}", _portfolio.GetPortfolioValue());
        }


        public void DisplayPortfolio()
        {
            printer();
        }
    }
}
