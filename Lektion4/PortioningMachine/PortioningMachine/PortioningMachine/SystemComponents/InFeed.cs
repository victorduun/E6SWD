using System;
using System.Collections.Generic;
using System.Text;

namespace PortioningMachine.ItemProviders
{
    public class InFeed : IItemProvider
    {
        public event ItemArrivedHandler ItemArrived;
        public void Go()
        {
            throw new NotImplementedException();
        }
    }
}
