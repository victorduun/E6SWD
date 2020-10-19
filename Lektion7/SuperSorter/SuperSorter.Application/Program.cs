using System;
using SuperSorter.Helpers;

namespace SuperSorter.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            SorterTester tester = new SorterTester();


            ISorter sorter = new InsertionSorter();
            tester.SetStrategy(sorter);

            ArrayGenerator generator = new Helpers.ArrayGenerator(10000, 50, 100000);

            var array = generator.GetArray(ArrayReturnMode.CompletelyRandom);


            tester.SetArray(array);

            tester.TestMethod();



        }
    }
}
