using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto;

public class BubbleSort<T> : ISortAlgorithm<T> where T : IComparable<T>
{

    public T[] SortMethod(T[] arr)
    {
        int n = arr.Length;
        T[] sortedArray = (T[])arr.Clone(); // Clona o array para preservar o original.

        // Realiza o algoritmo BubbleSort
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                // Compara os elementos adjacentes
                if (sortedArray[j].CompareTo(sortedArray[j + 1]) > 0)
                {
                    // Troca os elementos se estiverem fora de ordem
                    T temp = sortedArray[j];
                    sortedArray[j] = sortedArray[j + 1];
                    sortedArray[j + 1] = temp;
                }
            }
        }

        return sortedArray;
    }
}
