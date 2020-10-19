using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SuperSorter.Helpers
{
    public enum ArrayReturnMode
    {
        CompletelyRandom,
        NearlySorted,
        ReverseOrder,
        FewUnique,
    }

    public static class ListExtensions
    {
        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            T value1 = list[index1];
            T value2 = list[index2];
            list[index1] = value2;
            list[index2] = value1;

        }
    }

    public class ArrayGenerator
    {
        private List<int> _array;
        private readonly int _size;
        private readonly int _max;
        private readonly int _seed;

        public ArrayGenerator(int size, int max, int seed)
        { 
            _size = size;
            _max = max; 
            _seed = seed;
            RefreshArray();
        }

        public void RefreshArray()
        {
            Random rand = new Random(_seed);
            List<int> newArray = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                newArray.Add(rand.Next(_max));
            }

            _array = newArray;

        }

        public List<int> GetArray(ArrayReturnMode returnMode)
        {
            switch (returnMode)
            {
                case ArrayReturnMode.CompletelyRandom:
                    return GetCompletelyRandomArray();
                case ArrayReturnMode.NearlySorted:
                    return GetNearlySortedArray();
                case ArrayReturnMode.ReverseOrder:
                    return GetReversedRandomArray();
                case ArrayReturnMode.FewUnique:
                    return GetFewUniqueRandomArray();
                default:
                    throw new ArgumentOutOfRangeException(nameof(returnMode), returnMode, null);
            }
        }
        
        private List<int> GetCompletelyRandomArray()
        {
            //Return copy
            return _array.ToList();
        }

        private List<int> GetNearlySortedArray()
        {
            var arrayCopy = _array.ToList();
            arrayCopy.Sort();

            Random rand = new Random(_seed);
            int noOfSwaps = 10;
            for (int i = 0; i < noOfSwaps; i++)
            {
                int index1 = rand.Next(_size);
                int index2 = rand.Next(_size);
                arrayCopy.Swap(index1, index2);
            }

            return arrayCopy;
        }

        private List<int> GetReversedRandomArray()
        {
            var arrayCopy = _array.ToList();
            arrayCopy.Reverse();
            return arrayCopy;
        }

        private List<int> GetFewUniqueRandomArray()
        {
            Random rand = new Random(_seed);
            List<int> newArray = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                newArray.Add(rand.Next(3));
            }

            return newArray;
        }
    }
}

