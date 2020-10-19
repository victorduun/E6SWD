using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SuperSorter
{
    public class SorterTester
    {
        private ISorter _sorter;
        private List<int> _array;

        private Stopwatch _stopwatch;

        public void SetStrategy(ISorter sorterStrategy)
        {
            _sorter = sorterStrategy;
        }

        public void SetArray(List<int> array)
        {
            _array = array;
        }

        public void TestMethod()
        {
            //Start timer
            _stopwatch = Stopwatch.StartNew();
            
            var arrayCopy = _array.ToList();
            _sorter.Sort(arrayCopy);
            
            Console.WriteLine(_stopwatch.ElapsedMilliseconds);
        }



    }
}
