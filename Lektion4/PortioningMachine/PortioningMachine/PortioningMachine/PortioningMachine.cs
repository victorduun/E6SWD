using System;
using System.Collections.Generic;
using System.Text;
using PortioningMachine.ItemProviders;
using PortioningMachine.SystemComponents;

namespace PortioningMachine
{
    public class PortioningMachine
    {
        private InFeed _inFeed { get; set; }

        public PortioningMachine()
        {
            _inFeed = new InFeed();

        }


        public void Feed(IItem item)
        {
            _inFeed.Go();


        }

    }
}
