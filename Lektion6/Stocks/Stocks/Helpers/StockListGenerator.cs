using Stocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks.Helpers
{
    public static class StockListGenerator
    {
        public static IEnumerable<IStock> GetStockList()
        {
            var stockList = new List<IStock>
            {
                new Stock("Tesla", "TSLA"),
                new Stock("American Airlines Group, Inc.", "AAL"),
                new Stock("Apple Inc.", "AAPL"),
                new Stock("FuelCell Energy. Inc.", "FCEL"),
                new Stock("Advanced Micro Devices, Inc.", "AMD"),
                new Stock("NVIDIA Corporation", "NVDA"),
                new Stock("Amazon.com, Inc.", "AMZN"),
                new Stock("Taiwan Liposome Company, Ltd.", "TLC"),
                new Stock("Cytokinetics, Incorporated", "CYTK"),
                new Stock("Alphatec Holdings, Inc.", "ATEC"),
                new Stock("SCYNEXIS, Inc.", "SCYX"),
            };
            return stockList;
        }
    }
}
