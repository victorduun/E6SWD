using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortioningMachine.SystemComponents.Interfaces
{
    public interface IAssignmentAlgorithm
    {
        public int Next(List<IBin> bins, IItem nextItem);
    }

   
}
