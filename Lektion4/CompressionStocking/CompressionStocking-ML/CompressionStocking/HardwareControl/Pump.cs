using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking.HardwareControl
{
    public class Pump
    {
        public void StartForward()
        {
            Console.WriteLine("Pump started running forwards");
        }

        public void StartBackward()
        {
            Console.WriteLine("Pump started running backwards");
        }

        public void Stop()
        {
            Console.WriteLine("Pump stopped");
        }
    }
}
