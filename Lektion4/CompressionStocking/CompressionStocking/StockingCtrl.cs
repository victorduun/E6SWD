using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking
{
    public interface IBtnHandler
    {
        void StartBtnPushed();
        void StopBtnPushed();
    }



    public class StockingCtrl : IBtnHandler, IStocking
    {
        private readonly ICompressionCtrl _compressionCtrl;


        public StockingCtrl(ICompressionCtrl compressionCtrl)
        {
            _compressionCtrl = compressionCtrl;


            _compressionCtrl.CompressionFinishedEvent += OnCompressionFinishedEvent;
            _compressionCtrl.CompressionStartedEvent += OnCompressionStartedEvent;
            _compressionCtrl.DecompressionFinishedEvent += OnDecompressionFinishedEvent;
            _compressionCtrl.DecompressionStartedEvent += OnDecompressionStartedEvent;
        }

        private void OnDecompressionStartedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Red LED turned on. Vibration Started.");
        }

        private void OnDecompressionFinishedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Red LED turned off. Vibration Stopped.");
        }

        private void OnCompressionStartedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Green LED turned on. Vibration Started.");
        }

        private void OnCompressionFinishedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Green LED turned off. Vibration Stopped.");
        }

        // From IBtnHandler
        public void StartBtnPushed()
        {
            _compressionCtrl.Compress();
        }

        public void StopBtnPushed()
        {
            _compressionCtrl.Decompress();
        }

        public int Pressure { get; set; } = 1013;
    }
}
