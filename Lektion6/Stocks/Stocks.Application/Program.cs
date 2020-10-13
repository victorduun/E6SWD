using Stocks.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stocks.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IStock> validStocks = Helpers.StockListGenerator.GetStockList();
            IStockIndex stockIndex = new StockIndex(validStocks);
            IPortfolio portfolio = new Portfolio(stockIndex);
            IPortfolioDisplay portfolioDisplay = new PortfolioDisplay(portfolio);

            for (int i = 0; i < 10; i++)
                portfolio.AddStock(validStocks.FirstOrDefault(s => s.Symbol == "TSLA"));

            for (int i = 0; i < 15; i++)
                portfolio.AddStock(validStocks.FirstOrDefault(s => s.Symbol == "AAL"));

            for (int i = 0; i < 30; i++)
                portfolio.AddStock(validStocks.FirstOrDefault(s => s.Symbol == "AMD"));

            portfolio.AddStock(validStocks.First());
            portfolio.AddStock(validStocks.First());
            portfolio.AddStock(validStocks.First());
            portfolio.AddStock(validStocks.First());

            portfolioDisplay.DisplayPortfolio();



        }
    }
}
