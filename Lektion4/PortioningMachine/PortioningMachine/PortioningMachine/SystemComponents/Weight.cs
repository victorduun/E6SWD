﻿using System.Threading;
using System.Threading.Tasks;
using PortioningMachine.SystemComponents.Interfaces;
using PortioningMachine.SystemComponents;
using PortioningMachine.ItemHandlers;

namespace PortioningMachine.SystemComponents
{
    public class Weight : IWeight, IItemConveyer
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