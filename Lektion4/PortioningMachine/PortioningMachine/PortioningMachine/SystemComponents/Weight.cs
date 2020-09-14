using System.Threading;
using System.Threading.Tasks;
using PortioningMachine.SystemComponents.Interfaces;
using PortioningMachine.SystemComponents;
using PortioningMachine.ItemHandlers;

namespace PortioningMachine.SystemComponents
{
    public class Weight : IItemConveyer
    {
        public Weight(IItemConveyer nextConveyer)
        {
            NextConveyer = nextConveyer;
            ItemArrived += OnItemArrived;
        }

        private void OnItemArrived(object o, IItem item)
        {
            Task.Run(() =>
            {
                Thread.Sleep(10);
                WeighItem(item); 
                NextConveyer.PutItemInConveyer(item);
            });
        }

        private void WeighItem(IItem item)
        {
            item.AssignedWeight = item.ActualWeight;
            ItemWeighed?.Invoke(this, item);
        }

        public event ItemArrivedHandler ItemArrived;
        public event ItemWeighedHandler ItemWeighed;
        public IItemConveyer NextConveyer { get; set; }
        public void PutItemInConveyer(IItem item)
        {
            ItemArrived?.Invoke(this, item);
        }
    }
}