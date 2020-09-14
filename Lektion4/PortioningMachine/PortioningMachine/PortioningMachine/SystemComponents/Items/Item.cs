using System;
using System.Collections.Generic;
using System.Text;

namespace PortioningMachine.SystemComponents
{
    public class Item : IItem
    {
        public uint Id { get; set; }
        public double ActualWeight { get; set; }
        public double AssignedWeight { get; set; }
        public int AssignedBinNumber { get; set; }
    }

}
