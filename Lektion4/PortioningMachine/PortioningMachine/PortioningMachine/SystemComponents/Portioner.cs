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
    public class Portioner : IPortioner, IItemConveyer
    {
        private readonly IEnumerable<IItemConveyer> _bins;

        public Portioner(IEnumerable<IItemConveyer> bins)
        {
            _bins = bins;
            ItemArrived += OnItemArrived;
        }


        private void OnItemArrived(object o, IItem item)
        {
            Task.Run(() =>
            {
                NextConveyer = _bins.First();



                Thread.Sleep(10);
                NextConveyer.PutItemInConveyer(item);
            });
        }

        public event ItemArrivedHandler ItemArrived;
        public IItemConveyer NextConveyer { get; set; }
        public void PutItemInConveyer(IItem item)
        {
            ItemArrived?.Invoke(this, item);
        }
    }
}
