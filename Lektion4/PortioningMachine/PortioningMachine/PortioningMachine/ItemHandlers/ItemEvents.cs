using System;
using System.Collections.Generic;
using System.Text;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemHandlers
{
    public delegate void ItemArrivedHandler(object o, IItem item);
    public delegate void ItemWeighedHandler(object o, IItem item);
}
