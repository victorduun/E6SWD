using System.Buffers.Text;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemProviders
{
    public class Weight : IItemProvider
    {
        public Weight()
        {

        }

        public event ItemArrivedHandler ItemArrived;
        public void Go()
        {
            throw new System.NotImplementedException();
        }
    }
}