
using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemHandlers
{
    public delegate void ItemArrivedHandler(object o, IItem item);

    public interface IItemProvider
    {
        event ItemArrivedHandler ItemArrived;
        void Go();
    }
}