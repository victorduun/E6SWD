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
        private readonly IAssignmentAlgorithm _assignmentAlgorithm;

        public ControlUnit(Weight weight, Portioner portioner, List<IBin> bins, IAssignmentAlgorithm assignmentAlgorithm)
        {
            Weight = weight;
            Portioner = portioner;
            Bins = bins;
            _assignmentAlgorithm = assignmentAlgorithm;


            Weight.ItemWeighed += OnItemWeighedEvent;
            Portioner.ItemArrived += OnItemArrivedPortionerEvent;

            foreach (IBin bin in Bins)
            {
                bin.ItemArrived += CheckBinWeight;
            }
        }



        private void CheckBinWeight(object o, IItem item)
        {
            IBin bin = (o as IBin);
            if (bin.CurrentWeight >= bin.TargetWeight)
            {
                bin.Empty();
                Console.WriteLine("Bin emptied");
            }

        }


        private void OnItemWeighedEvent(object o, IItem item)
        {
            //TODO: Assign a proper binnumber
            item.AssignedBinNumber = _assignmentAlgorithm.Next(Bins, item);
        }

        private void OnItemArrivedPortionerEvent(object o, IItem item)
        {
            Portioner portioner = (o as Portioner);
            portioner?.Eject(item, Bins?.FirstOrDefault(b=> b.BinNumber == item.AssignedBinNumber));
        }

        public List<IBin> Bins { get; set; }

        public Weight Weight { get; set; }
        public Portioner Portioner { get; set; }




    }
}
