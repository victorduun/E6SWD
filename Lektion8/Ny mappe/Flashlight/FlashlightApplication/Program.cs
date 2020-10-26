using System;
using System.Threading;

namespace FlashlightApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var lamp = new Flashlight.ConsoleLamp();
            var flashlight = new Flashlight.Flashlight(lamp);
            while (true)
            {
                Thread.Sleep(100);
                flashlight.PowerPressed();
            }
        }
    }
}
