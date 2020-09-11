using CompressionStocking.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking.HardwareControl
{
    public class VibratingDevice : OnOffDevice
    {
        public void TurnOff()
        {
            Console.WriteLine("Vibrating device stopped");
        }

        public void TurnOn()
        {
            Console.WriteLine("Vibrating device started");
        }
    }
}
