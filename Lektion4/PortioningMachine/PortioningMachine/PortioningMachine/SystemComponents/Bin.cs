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
            ItemArrived?.Invoke(this, item);
        }

        public double Giveaway
        {
            get
            {
                if (TargetWeight == 0)
                    return 0;
                return ((CurrentWeight / TargetWeight) * 100) - 100;
            }
        }

        public void Empty()
        {
            BinStat binStat = new BinStat
            {
                BinNumber = BinNumber,
                TargetWeight = TargetWeight,
                Weight = CurrentWeight,
                Giveaway = Giveaway
            };

            _container.DumpItems(ItemsInBin);
            ItemsInBin = new List<IItem>();
            BinEmptied?.Invoke(this, binStat);
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

        public event ItemArrivedHandler ItemArrived;
        public event BinEmptiedHandler BinEmptied;
    }
}