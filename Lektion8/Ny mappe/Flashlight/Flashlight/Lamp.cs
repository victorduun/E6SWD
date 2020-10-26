using System;
using System.Collections.Generic;
using System.Text;

namespace Flashlight
{
    public class ConsoleLamp : ILamp
    {
        public void TurnOn()
        {
            Console.WriteLine("Lamp turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Lamp turned off");
        }
    }
}
