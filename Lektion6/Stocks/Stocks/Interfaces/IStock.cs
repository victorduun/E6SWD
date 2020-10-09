using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks.Interfaces
{
    public interface IStock
    {
        string Name { get; }
        string Symbol { get; }
    }
}
