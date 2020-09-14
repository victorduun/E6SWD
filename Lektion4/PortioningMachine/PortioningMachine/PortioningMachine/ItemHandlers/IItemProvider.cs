
using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemHandlers
{

    public interface IItemProvider
    {
        event ItemArrivedHandler ItemArrived;
        void Go();
    }
}