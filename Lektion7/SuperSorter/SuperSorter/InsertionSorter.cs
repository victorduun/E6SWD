using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSorter
{
    public class InsertionSorter :ISorter
    {
        public void Sort(List<int> list)
        {
            int  i, j, val, flag;

            for (i = 1; i < list.Count; i++)
            {
                val = list[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val < list[j])
                    {
                        list[j + 1] = list[j];
                        j--;
                        list[j + 1] = val;
                    }
                    else flag = 1;
                }
            }
        }
    }
}
