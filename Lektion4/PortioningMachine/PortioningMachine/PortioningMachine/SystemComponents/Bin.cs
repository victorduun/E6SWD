using PortioningMachine.ItemProviders;
using PortioningMachine.SystemComponents.Interfaces;

namespace PortioningMachine.SystemComponents
{
    public class Bin : IBin, IItemConveyer
    {

        public Bin()
        {

        }

        public event ItemArrivedHandler ItemArrived;
  
        public void ReceiveItem(IItem item)
        {
            throw new System.NotImplementedException();
        }

        public void ConveyItem(IItemConveyer itemConveyer)
        {
            throw new System.NotImplementedException();
        }

    }
}