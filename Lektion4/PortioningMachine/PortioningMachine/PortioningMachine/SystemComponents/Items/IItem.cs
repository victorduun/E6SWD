using PortioningMachine.SystemComponents.Interfaces;

namespace PortioningMachine.SystemComponents
{
    public interface IItem
    {

        uint Id { get; set; }
        double ActualWeight { get; set; } // True weight
        double AssignedWeight { get; set; } //Assigned by weight
        int AssignedBinNumber { get; set; }

    }
}