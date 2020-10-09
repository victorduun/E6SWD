using Stocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Stocks
{
    public class Stock : IStock
    {
        public Stock(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public string Name { get; private set; }
        public string Symbol { get; private set; }
    }
}