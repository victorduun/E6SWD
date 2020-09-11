using PortioningMachine.ItemHandlers;
using PortioningMachine.SystemComponents.Interfaces;
using System;

namespace PortioningMachine.SystemComponents
{
    public class Bin : IBin, IItemConveyer
    {

        public Bin(IItemConveyer nextConveyer )
        {
            NextConveyer = nextConveyer;
            ItemArrived += OnItemArrived;
        }

        public IItemConveyer NextConveyer { get; set; }

        public event ItemArrivedHandler ItemArrived;

        public void PutItemInConveyer(IItem item)
        {
            ItemArrived?.Invoke(this, item);
        }

        private void OnItemArrived(object o, IItem item)
        {
            throw new NotImplementedException();
        }

    }
}