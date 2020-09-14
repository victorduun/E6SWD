using PortioningMachine.SystemComponents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortioningMachine.ItemHandlers;

namespace PortioningMachine.SystemComponents
{
    public class ControlUnit
    {

        public ControlUnit(Weight weight, Portioner portioner, List<IBin> bins)
        {
            Weight = weight;
            Portioner = portioner;
            BinsToMonitor = bins;
            Weight.ItemWeighed += OnItemWeighedEvent;
            Portioner.ItemArrived += OnItemArrivedPortionerEvent;
        }

        private void OnItemWeighedEvent(object o, IItem item)
        {
            //TODO: Assign a proper binnumber
            item.AssignedBinNumber = BinsToMonitor.First().BinNumber;
        }

        private void OnItemArrivedPortionerEvent(object o, IItem item)
        {
            Portioner portioner = (o as Portioner);
            portioner?.Eject(item, BinsToMonitor?.FirstOrDefault(b=> b.BinNumber == item.AssignedBinNumber));
            Console.WriteLine("Item ejected into bin");
        }

        public List<IBin> BinsToMonitor { get; set; }

        public Weight Weight { get; set; }
        public Portioner Portioner { get; set; }




    }
}
