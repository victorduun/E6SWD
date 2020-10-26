using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking
{
    public class LaceStockingFactory : IStockingFactory
    {
        public ICompressionCtrl CreateCompressionMechanism()
        {
            return new LaceCompressionCtrl();
        }
    }
}
