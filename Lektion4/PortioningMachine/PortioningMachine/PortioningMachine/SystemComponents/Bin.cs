using PortioningMachine.ItemHandlers;
using PortioningMachine.SystemComponents.Interfaces;
using System;
using System.Collections.Generic;

namespace PortioningMachine.SystemComponents
{
    public class Bin : IBin
    {
        private readonly Container _container;

        public Bin(Container container, int binNumber )
        {
            _container = container;
            BinNumber = binNumber;
            ItemsInBin = new List<IItem>();
        }

        private List<IItem> ItemsInBin { get; set; }

        public void PutItemIntoBin(IItem item)
        {
            ItemsInBin.Add(item);
        }

        public void Empty()
        {
            _container.DumpItems(ItemsInBin);
        }

        public double CurrentWeight
        {
            get
            {
                double weightSum = 0;
                foreach (IItem item in ItemsInBin)
                    weightSum += item.ActualWeight;
                return weightSum;
            }
        }

        public double TargetWeight { get; set; } = 1000; //gram
        public int BinNumber { get; private set; }
    }
}