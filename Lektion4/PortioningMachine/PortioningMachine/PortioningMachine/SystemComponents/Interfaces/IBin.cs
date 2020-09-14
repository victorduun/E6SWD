using System;
using System.Collections.Generic;
using System.Text;
using PortioningMachine.ItemHandlers;

namespace PortioningMachine.SystemComponents.Interfaces
{

    public class BinStat
    {
        public int BinNumber { get; set; }
        public double Weight { get; set; }
        public double TargetWeight { get; set; }
        public double Giveaway { get; set; }
    }
    public delegate void BinEmptiedHandler(object o, BinStat binStat);


    public interface IBin
    {
        void Empty();
        public double Score { get; set; }
        void PutItemIntoBin(IItem item);
        double Giveaway { get; }
        double CurrentWeight { get; }
        double TargetWeight { get; set; }
        int BinNumber { get; }

        event ItemArrivedHandler ItemArrived;
        event BinEmptiedHandler BinEmptied;

    }
}
