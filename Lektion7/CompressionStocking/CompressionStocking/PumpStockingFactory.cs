using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking
{
    public class PumpStockingFactory : IStockingFactory
    {
        public ICompressionCtrl CreateCompressionMechanism()
        {
            return new PumpCompressionCtrl(new Stocking());
        }
    }
}
