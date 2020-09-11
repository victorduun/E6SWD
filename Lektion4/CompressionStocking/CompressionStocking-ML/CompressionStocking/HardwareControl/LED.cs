using CompressionStocking.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking.HardwareControl
{
    public class LED : OnOffDevice
    {
        private string myColor;

        public LED(string color)
        {
            myColor = color;
        }

        public void TurnOff()
        {
            Console.WriteLine("{0} LED turned off", myColor);
        }

        public void TurnOn()
        {
            Console.WriteLine("{0} LED turned on", myColor);
        }
    }
}
