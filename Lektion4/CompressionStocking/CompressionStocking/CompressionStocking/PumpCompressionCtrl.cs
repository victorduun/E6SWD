using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompressionStocking
{
    public class PumpCompressionCtrl : ICompressionCtrl
    {
        private readonly IStocking _stocking;

        public PumpCompressionCtrl(IStocking stocking)
        {
            _stocking = stocking;
            var stockingPressureGauge = new StockingPressureGauge(stocking);

            stockingPressureGauge.AboveSufficientCompressionPressureEvent += OnAboveSufficientCompressionPressureEvent;
            stockingPressureGauge.BelowSufficientDecompressionPressureEvent += OnBelowSufficientDecompressionPressureEvent;
        }

        private void OnAboveSufficientCompressionPressureEvent(object sender, EventArgs e)
        {
            IsCompressed = true;
        }

        private void OnBelowSufficientDecompressionPressureEvent(object sender, EventArgs e)
        {
            IsCompressed = false;
        }

        private bool IsPumpActive { get; set; } = false;
        private bool IsCompressed { get; set; } = false;

        public event EventHandler DecompressionFinishedEvent;
        public event EventHandler CompressionFinishedEvent;
        public event EventHandler CompressionStartedEvent;
        public event EventHandler DecompressionStartedEvent;

        public void Compress()
        {
            if (IsPumpActive) return;
            if (!IsCompressed)
            {

                Console.WriteLine("Pump compression initiated");
                CompressionStartedEvent?.Invoke(this, EventArgs.Empty);
                IsPumpActive = true;
                Task.Factory.StartNew(() =>
                    {
                        while (!IsCompressed)
                        {
                            _stocking.Pressure += 1;
                            Thread.Sleep(1);
                        }
                        Console.WriteLine("Pump compression complete");
                        IsPumpActive = false;
                        CompressionFinishedEvent?.Invoke(this, EventArgs.Empty);
                    });
            }
            else
            {
                Console.WriteLine("Cannot compress the stocking any further.");
            }
        }

        public void Decompress()
        {
            if (IsPumpActive) return;
            if (IsCompressed)
            {
                Console.WriteLine("Pump decompression initiated");
                DecompressionStartedEvent?.Invoke(this, EventArgs.Empty);
                IsPumpActive = true;
                Task.Factory.StartNew(() =>
                {
                    while (IsCompressed)
                    {
                        _stocking.Pressure -= 1;
                        Thread.Sleep(1);
                    }
                    Console.WriteLine("Pump decompression complete");
                    IsPumpActive = false;
                    DecompressionFinishedEvent?.Invoke(this, EventArgs.Empty);
                });
            }
            else
            {
                Console.WriteLine("The stocking is already relaxed.");
            }
        }
    }
}
