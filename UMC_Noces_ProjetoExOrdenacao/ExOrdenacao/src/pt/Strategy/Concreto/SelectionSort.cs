using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class SelectionSort : ISortAlgorithm
{
    public int[] Sort(int[] arr)
    {
        int n = arr.Length;
        int[] sortedArray = (int[])arr.Clone();
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (sortedArray[j] < sortedArray[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = sortedArray[i];
            sortedArray[i] = sortedArray[minIndex];
            sortedArray[minIndex] = temp;
        }
        return sortedArray;
    }
}

}