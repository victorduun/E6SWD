
using PortioningMachine.SystemComponents.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PortioningMachine.SystemComponents.Algorithms
{

    public class FirstBinAlgorithm : IAssignmentAlgorithm
    {
        public int Next(List<IBin> bins)
        {
            return bins.First().BinNumber;
        }
    }
}