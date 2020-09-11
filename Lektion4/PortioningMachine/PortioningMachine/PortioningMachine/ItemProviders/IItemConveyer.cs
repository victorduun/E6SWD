using System;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemProviders
{
    public interface IItemConveyer
    {
        public void ReceiveItem(IItem item);

        public void ConveyItem(IItemConveyer itemConveyer);
    }
}
