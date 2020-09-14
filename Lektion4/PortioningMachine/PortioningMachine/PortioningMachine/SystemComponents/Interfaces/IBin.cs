using System;
using System.Collections.Generic;
using System.Text;

namespace PortioningMachine.SystemComponents.Interfaces
{
    public interface IBin
    {
        void Empty();
        void PutItemIntoBin(IItem item);
        double CurrentWeight { get; }
        double TargetWeight { get; set; }
        int BinNumber { get; }

    }
}
