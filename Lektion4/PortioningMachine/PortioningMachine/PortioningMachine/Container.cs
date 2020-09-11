namespace PortioningMachine.ItemProviders
{
    public class Container : IItemProvider
    {
        public Container()
        {

        }

        public event ItemArrivedHandler ItemArrived;

        public void Go()
        {
            throw new System.NotImplementedException();
        }
    }
}