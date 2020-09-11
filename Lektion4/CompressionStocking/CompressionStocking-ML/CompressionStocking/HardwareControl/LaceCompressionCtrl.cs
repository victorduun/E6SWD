using CompressionStocking.BusinessLogic;
using System;

namespace CompressionStocking.HardwareControl
{
    public class LaceCompressionCtrl : ICompressionCtrl
    {
        private Lace myLace;
        System.Timers.Timer compressionTimer = new System.Timers.Timer();
        System.Timers.Timer decompressionTimer = new System.Timers.Timer();
        const UInt32 TIMEOUT_IN_MILLIS = 100;

        public LaceCompressionCtrl(Lace lace)
        {
            myLace = lace;
            compressionTimer.Interval = TIMEOUT_IN_MILLIS;
            compressionTimer.AutoReset = false;
            compressionTimer.Elapsed += CompressionTimer_Elapsed_EventHandler;

            decompressionTimer.Interval = TIMEOUT_IN_MILLIS;
            decompressionTimer.AutoReset = false;
            decompressionTimer.Elapsed += DecompressionTimer_Elapsed_EventHandler;
        }

        private void CompressionTimer_Elapsed_EventHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            myLace.Tighten();
            var clicks = myLace.GetClicks();
            compressionTimer.Start();
        }

        private void DecompressionTimer_Elapsed_EventHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            myLace.Loosen();
            var clicks = myLace.GetClicks();
            if (0 == clicks)
            {
                // can't loosen more.
            }
            else
            {
                decompressionTimer.Start();
            }
        }

        public void Compress()
        {
            compressionTimer.Start();
        }

        public void Decompress()
        {
            decompressionTimer.Start();
        }

        public void Stop()
        {
            compressionTimer.Stop();
            decompressionTimer.Stop();
        }
    }
}
