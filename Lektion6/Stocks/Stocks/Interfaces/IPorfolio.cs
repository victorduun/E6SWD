﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks.Interfaces
{
    public class StockInformationDto
    {
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
        public int NumberOfStocks { get; set; }
        public int StockValue { get; set; }
    }


    public interface IPorfolio
    {
        void AddStock(IStock stock);
        IEnumerable<StockInformationDto> GetPortfolioStockInformations();
        double GetPortfolioValue();
    }
}