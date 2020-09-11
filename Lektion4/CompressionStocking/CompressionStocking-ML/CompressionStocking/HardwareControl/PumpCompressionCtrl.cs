using System;
using CompressionStocking.BusinessLogic;

namespace CompressionStocking.HardwareControl
{
    public class PumpCompressionCtrl : ICompressionCtrl
    {
        private Pump myPump;

        public PumpCompressionCtrl(Pump pump)
        {
            myPump = pump;
        }

        public void Compress()
        {
            myPump.StartForward();
        }

        public void Decompress()
        {
            myPump.StartBackward();
        }

        public void Stop()
        {
            myPump.Stop();
        }
    }
}
