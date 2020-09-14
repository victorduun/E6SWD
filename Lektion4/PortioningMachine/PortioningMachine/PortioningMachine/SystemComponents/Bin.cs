using PortioningMachine.ItemHandlers;
using PortioningMachine.SystemComponents.Interfaces;
using System;
using System.Collections.Generic;

namespace PortioningMachine.SystemComponents
{
    public class Bin : IBin, IItemConveyer
    {

        public Bin(IItemConveyer nextConveyer )
        {
            NextConveyer = nextConveyer;
            ItemArrived += OnItemArrived;
            ItemsInBin = new List<IItem>();
        }

        public IItemConveyer NextConveyer { get; set; }

        private List<IItem> ItemsInBin { get; set; }

        public event ItemArrivedHandler ItemArrived;

        public void PutItemInConveyer(IItem item)
        {
            ItemArrived?.Invoke(this, item);
        }

        private void OnItemArrived(object o, IItem item)
        {
            PutItemIntoBin(item);
        }

        public void PutItemIntoBin(IItem item)
        {
            ItemsInBin.Add(item);
        }

        public void Empty()
        {
            ItemsInBin = null;
        }

        public double CurrentWeight
        {
            get
            {
                double weightSum = 0;
                foreach (IItem item in ItemsInBin)
                    weightSum += item.Weight;
                return weightSum;
            }
        }

        public double TargetWeight { get; set; } = 1000; //gram
    }
}