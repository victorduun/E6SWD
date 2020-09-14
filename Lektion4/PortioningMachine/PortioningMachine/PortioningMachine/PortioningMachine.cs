using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PortioningMachine.ItemHandlers;
using PortioningMachine.SystemComponents;
using PortioningMachine.SystemComponents.Interfaces;
using Container = PortioningMachine.ItemHandlers.Container;

namespace PortioningMachine
{
    public class PortioningMachine
    {
        private readonly ILog _log;

        private readonly InFeed _inFeed;
        private readonly Weight _weight;
        private readonly Portioner _portioner;
        private readonly List<Bin> _bins = new List<Bin>();
        private readonly Container _container;

        public PortioningMachine(Container container, ILog log, int nBins)
        {
            _container = container;
            _log = log;

            for (int i = 0; i < nBins; i++)
                _bins.Add(new Bin(container));

            _portioner = new Portioner(_bins.Select(b => b as IItemConveyer));
            _weight = new Weight(_portioner);
            _inFeed = new InFeed(_weight);

            _inFeed.ItemArrived += new ItemArrivedHandler(delegate(object o, IItem i)
            {
                _log.LogMessage(i + " Arrived at infeed");
            });


            _inFeed.ItemArrived += AssignItemToBin;
        }

        private void AssignItemToBin(object o, IItem item)
        {
            //Tell control unit to put item with id=id into some bin
            //ControlUnit.AssignItemToBin(IItem item, IBin bin)
        }

        public void Feed(IItem item)
        {
            (_inFeed as IItemConveyer)?.PutItemInConveyer(item);
        }

    }
}
