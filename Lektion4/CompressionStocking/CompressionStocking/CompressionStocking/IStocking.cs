using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking
{
    public interface IStocking
    {
        int Pressure { get; set; }
    }
    public class Stocking :IStocking
    {
        public int Pressure { get; set; } = 1013;
    }
}
