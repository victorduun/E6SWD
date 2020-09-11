using System;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemHandlers
{

    public interface IItemConveyer
    {
        event ItemArrivedHandler ItemArrived;

        public IItemConveyer NextConveyer { get; set; }

        public void PutItemInConveyer(IItem item);

    }
}
