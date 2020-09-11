using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CompressionStocking
{
    public class LaceCompressionCtrl : ICompressionCtrl
    {

        private bool IsLaceCtrlActive { get; set; } = false;
        private bool IsCompressed { get; set; } = false;

        public event EventHandler DecompressionFinishedEvent;
        public event EventHandler CompressionFinishedEvent;
        public event EventHandler CompressionStartedEvent;
        public event EventHandler DecompressionStartedEvent;

        private const int ClicksToTighten = 40;

        public void Compress()
        {
            if (IsLaceCtrlActive) return;
            if (!IsCompressed)
            {

                Console.WriteLine("Lace compression initiated");
                CompressionStartedEvent?.Invoke(this, EventArgs.Empty);
                IsLaceCtrlActive = true;
                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < ClicksToTighten; i++)
                    {
                        Console.WriteLine("Click " + (i + 1));
                        Thread.Sleep(100);
                    }
                    IsLaceCtrlActive = false;
                    IsCompressed = true;
                    Console.WriteLine("Lace compression complete");
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
            if (IsLaceCtrlActive) return;
            if (IsCompressed)
            {
                Console.WriteLine("Lace decompression initiated");
                DecompressionStartedEvent?.Invoke(this, EventArgs.Empty);
                IsLaceCtrlActive = true;
                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < ClicksToTighten; i++)
                    {
                        Console.WriteLine("Click " + (i + 1));
                        Thread.Sleep(100);
                    }
                    IsLaceCtrlActive = false;
                    IsCompressed = false;
                    Console.WriteLine("Lace decompression complete");
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
