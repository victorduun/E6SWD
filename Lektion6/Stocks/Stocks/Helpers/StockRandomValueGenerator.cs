using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks.Helpers
{
    public static class StockRandomValueGenerator
    {
        public static double Next()
        {
            var rand = new Random();
            double minimum = 1;
            double maximum = 5000;
            double randomDouble = rand.NextDouble() * (maximum - minimum) + minimum;
            return randomDouble;
        }
        public static double Next5PctDifference(double startingValue)
        {
            var rand = new Random();
            double fivePctDiff = (startingValue / 100) * 5;
            double minimum = startingValue - fivePctDiff;
            double maximum = startingValue + fivePctDiff;
            
            double returnVal = rand.NextDouble() * (maximum - minimum) + minimum;
            return returnVal;
        }
    }
}
