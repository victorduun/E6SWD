using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PortioningMachine.ItemHandlers;
using PortioningMachine.SystemComponents;
using PortioningMachine.SystemComponents.Interfaces;

namespace PortioningMachine
{
    public class PortioningMachine
    {
        private readonly ILog _log;

        private readonly ControlUnit _controlUnit;
        private readonly InFeed _inFeed;
        private readonly Weight _weight;
        private readonly Portioner _portioner;
        private readonly List<IBin> _bins = new List<IBin>();
        private readonly Container _container;

        public PortioningMachine(Container container, ILog log, int nBins)
        {
            _container = container;
            _log = log;

            for (int i = 0; i < nBins; i++)
                _bins.Add(new Bin(container, i));
            
            _portioner = new Portioner();
            _weight = new Weight(_portioner);
            _inFeed = new InFeed(_weight);


            _controlUnit = new ControlUnit(_weight,_portioner,_bins);

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
