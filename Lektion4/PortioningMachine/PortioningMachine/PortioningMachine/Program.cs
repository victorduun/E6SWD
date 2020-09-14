using System;
using PortioningMachine.ItemHandlers;
using PortioningMachine.SystemComponents;
using PortioningMachine.SystemComponents.Interfaces;

namespace PortioningMachine
{
    class Program
    {

        private static PortioningMachine _portioningMachine;
        private static readonly ItemProvider _itemProvider = new ItemProvider(new GaussianDistribution(100, 10));

        static void Main(string[] args)
        {
            Container container = new Container();
            ILog log = new Log();
            _portioningMachine = new PortioningMachine(container, log, 10);

            _itemProvider.ItemArrived += FeedPortioningMachine;
            _itemProvider.Go();

            while (true)
            {
            }
        }

        private static void FeedPortioningMachine(object o, IItem item)
        {
            _portioningMachine.Feed(item);
        }
    }
}


