using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BubbleSort : ISortAlgorithm
{
    public int[] Sort(int[] arr)
    {
        int n = arr.Length;
        int[] sortedArray = (int[])arr.Clone();
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (sortedArray[j] > sortedArray[j + 1])
                {
                    int temp = sortedArray[j];
                    sortedArray[j] = sortedArray[j + 1];
                    sortedArray[j + 1] = temp;
                }
            }
        }
        return sortedArray;
    }
}
