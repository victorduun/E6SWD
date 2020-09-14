using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PortioningMachine.SystemComponents.Interfaces;
using PortioningMachine.SystemComponents;
using PortioningMachine.ItemHandlers;

namespace PortioningMachine.SystemComponents
{
    public class Portioner : IItemConveyer
    {

        public void Eject(IItem item, IBin bin)
        {
            bin.PutItemIntoBin(item);
        }


        public event ItemArrivedHandler ItemArrived; 
        public IItemConveyer NextConveyer { get; set; } = null; // Bins are not conveyers. Instead the items must be ejected into these
        public void PutItemInConveyer(IItem item)
        {
            ItemArrived?.Invoke(this, item);
        }

    }
}
