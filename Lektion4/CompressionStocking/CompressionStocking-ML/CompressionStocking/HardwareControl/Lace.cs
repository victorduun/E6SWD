using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking.HardwareControl
{
    public class Lace
    {
        private Int32 clicks = 0;

        public void Tighten()
        {
            clicks++;
            System.Console.WriteLine("Tightening lace. Now at {0} clicks.", clicks);
        }

        public void Loosen()
        {
            clicks--;
            System.Console.WriteLine("Loosening lace. Now at {0} clicks.", clicks);
        }

        public Int32 GetClicks()
        {
            return clicks;
        }
    }
}
