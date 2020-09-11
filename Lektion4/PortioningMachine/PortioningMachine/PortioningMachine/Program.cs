using System;
using PortioningMachine.ItemProviders;
using PortioningMachine.SystemComponents;

namespace PortioningMachine
{
    class Program
    {

        private static readonly PortioningMachine _portioningMachine = new PortioningMachine();
        private static readonly ItemProvider _itemProvider = new ItemProvider(new GaussianDistribution(100, 10));

        static void Main(string[] args)
        {
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


