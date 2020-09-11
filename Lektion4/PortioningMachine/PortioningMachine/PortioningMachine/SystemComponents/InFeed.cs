using PortioningMachine.ItemHandlers;
using PortioningMachine.SystemComponents.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortioningMachine.SystemComponents
{
    public class InFeed : IInFeed, IItemConveyer
    {

        public InFeed(IItemConveyer nextConveyer)
        {
            NextConveyer = nextConveyer;
            ItemArrived += OnItemReceivedEvent;
        }

        private void OnItemReceivedEvent(object sender, IItem item)
        {
            Task.Run(() =>
            {
                Thread.Sleep(10);
                NextConveyer.PutItemInConveyer(item);
            });
        }

        public IItemConveyer NextConveyer { get; set; }
        public void PutItemInConveyer(IItem item)
        {
            ItemArrived?.Invoke(this, item);
        }


        public event ItemArrivedHandler ItemArrived;

      
    }
}
