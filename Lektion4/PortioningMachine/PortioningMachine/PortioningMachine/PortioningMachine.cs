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
        private readonly InFeed _inFeed;
        private readonly Weight _weight;
        private readonly Portioner _portioner;
        private readonly IEnumerable<Bin> _bins = new List<Bin>();
        private readonly Container _container;

        public PortioningMachine(Container container)
        {
            _container = container;
            
            for(int i = 0 ; i< 10;i++)
                _bins.ToList().Add(new Bin(container));
            _portioner = new Portioner(_bins.Select(b=>b as IItemConveyer));
            _weight = new Weight(_portioner);
            _inFeed = new InFeed(_weight);
            
        }


        public void Feed(IItem item)
        {
            (_inFeed as IItemConveyer)?.PutItemInConveyer(item);
        }

    }
}
