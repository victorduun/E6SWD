using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSorter
{
    public class BubbleSorter : ISorter
    {

        public void Sort(List<int> list)
        {
            int temp;
            for (int j = 0; j <= list.Count - 2; j++)
            {
                for (int i = 0; i <= list.Count - 2; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        temp = list[i + 1];
                        list[i + 1] = list[i];
                        list[i] = temp;
                    }
                }
            }
        }
    }

}
    
