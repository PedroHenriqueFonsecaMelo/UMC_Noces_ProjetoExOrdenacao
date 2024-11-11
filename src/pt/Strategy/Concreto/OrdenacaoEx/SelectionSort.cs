using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class SelectionSort : ISortAlgorithm
{
    public int[] SortMethod(int[] arr)
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