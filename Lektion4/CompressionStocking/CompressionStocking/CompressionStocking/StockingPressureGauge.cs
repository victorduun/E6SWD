using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompressionStocking
{
    public class StockingPressureGauge
    {
        private readonly IStocking _stocking;


        public StockingPressureGauge(IStocking stocking)
        {
            _stocking = stocking;
            MeasureStockingPressure();
        }
        private void MeasureStockingPressure()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    if (_stocking.Pressure >= 4000)
                    {
                        AboveSufficientCompressionPressureEvent?.Invoke(this, EventArgs.Empty);
                    }
                    else if (_stocking.Pressure <= 1100)
                    {
                        BelowSufficientDecompressionPressureEvent?.Invoke(this, EventArgs.Empty);
                    }
                    Console.WriteLine("Stocking pressure: {0}", _stocking.Pressure);
                }
            });
        }

        public event EventHandler AboveSufficientCompressionPressureEvent;
        public event EventHandler BelowSufficientDecompressionPressureEvent;
    }



}
