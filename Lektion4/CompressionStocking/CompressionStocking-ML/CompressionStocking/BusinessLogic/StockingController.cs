using CompressionStocking.UserInterface;
using System;

namespace CompressionStocking.BusinessLogic
{
    public class StockingController : ICompressionStocking, IPressureChangedListener
    {
        private ICompressionCtrl compressionController;
        private ICompressionProgressListener compressionProgressListener;
        private IPressureSensor myPressureSensor;
        private bool isCompressed;
        private bool isRelaxed;
        private uint thePressureWhenCompressed;
        private uint thePressureWhenRelaxed;

        public StockingController(ICompressionCtrl compressionCtrl, 
                                  IPressureSensor pressureSensor,
                                  UInt32 pressureWhenCompressed,
                                  UInt32 pressureWhenRelaxed)
        {
            compressionController = compressionCtrl;
            myPressureSensor = pressureSensor;
            isRelaxed = true;
            isCompressed = false;
            thePressureWhenCompressed = pressureWhenCompressed;
            thePressureWhenRelaxed = pressureWhenRelaxed;
            pressureSensor.SetPressureChangedListener(this);
            Console.WriteLine("Stocking is initially relaxed.");
        }

        public void SetCompressionProgressListener(ICompressionProgressListener listener)
        {
            compressionProgressListener = listener;
        }

        public void CompressionComplete()
        {
            Console.WriteLine("Compression complete");
            isCompressed = true;
            if (compressionProgressListener != null)
            {
                compressionProgressListener.CompressionComplete();
            }
        }

        public void DecompressionComplete()
        {
            Console.WriteLine("Decompression complete");
            isRelaxed = true;
            if (compressionProgressListener != null)
            {
                compressionProgressListener.DecompressionComplete();
            }
        }

        public void StartCompression()
        {
            if (isRelaxed)
            {
                Console.WriteLine("Starting compression");
                isCompressed = false;
                isRelaxed = false;
                if (compressionProgressListener != null)
                {
                    compressionProgressListener.CompressionStarted();
                }
                compressionController.Compress();
            }
            else
            {
                Console.WriteLine("Can't start compression when stocking is not relaxed");
            }
        }

        public void StartDecompression()
        {
            if (isCompressed)
            {
                Console.WriteLine("Staring decompression");
                isCompressed = false;
                isRelaxed = false;
                if (compressionProgressListener != null)
                {
                    compressionProgressListener.DecompressionStarted();
                }
                compressionController.Decompress();
            }
            else
            {
                Console.WriteLine("Can't start decompression when stocking is not compressed");
            }
        }

        public void PressureChanged()
        {
            UInt32 pressure = myPressureSensor.GetPressure();
            Console.WriteLine("Pressure changed to {0}", pressure);
            if (pressure >= thePressureWhenCompressed)
            {
                compressionController.Stop();
                CompressionComplete();
            }
            else if (pressure <= thePressureWhenRelaxed)
            {
                compressionController.Stop();
                DecompressionComplete();
            }
        }
    }
}
