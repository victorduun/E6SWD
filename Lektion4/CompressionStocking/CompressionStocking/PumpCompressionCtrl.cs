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
                        Thread.Sleep(5000);
                        IsPumpActive = false;
                        IsCompressed = true;
                        Console.WriteLine("Pump compression complete");
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
                    Thread.Sleep(2000);
                    IsPumpActive = false;
                    IsCompressed = false;
                    Console.WriteLine("Pump decompression complete");
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
