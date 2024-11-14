using System;
using System.Collections.Generic;
using System.Linq;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class InsertionSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public T[] SortMethod(T[] arr)
        {
            int n = arr.Length;
            T[] sortedArray = (T[])arr.Clone();

            for (int i = 1; i < n; i++)
            {
                T key = sortedArray[i];
                int j = i - 1;

                // Compara os elementos usando o método CompareTo
                while (j >= 0 && sortedArray[j].CompareTo(key) > 0)
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
