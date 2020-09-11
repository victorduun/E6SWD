using PortioningMachine.SystemComponents;
using System;

namespace PortioningMachine.ItemHandlers
{
    public class Container : IItemConveyer
    {
        public Container()
        {
            ItemArrived += OnItemArrived;
        }

        private void OnItemArrived(object o, IItem item)
        {
            throw new NotImplementedException();
        }

        IItemConveyer IItemConveyer.NextConveyer { get; set; } = null;

        public event ItemArrivedHandler ItemArrived;

        public void PutItemInConveyer(IItem item)
        {
            ItemArrived?.Invoke(this, item);
        }
    }
}