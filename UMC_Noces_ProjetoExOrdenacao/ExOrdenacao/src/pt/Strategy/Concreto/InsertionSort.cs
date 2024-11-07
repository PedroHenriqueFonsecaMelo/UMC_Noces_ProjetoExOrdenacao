using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
   public class InsertionSort : ISortAlgorithm
{
    public int[] Sort(int[] arr)
    {
        int n = arr.Length;
        int[] sortedArray = (int[])arr.Clone();
        for (int i = 1; i < n; i++)
        {
            int key = sortedArray[i];
            int j = i - 1;
            while (j >= 0 && sortedArray[j] > key)
            {
                sortedArray[j + 1] = sortedArray[j];
                j--;
            }
            sortedArray[j + 1] = key;
        }
        return sortedArray;
    }
}

}