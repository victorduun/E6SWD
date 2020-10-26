using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking
{
    public interface IStockingFactory
    {
        ICompressionCtrl CreateCompressionMechanism();
    }
}
