using System;
using System.Linq;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class SelectionSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public T[] SortMethod(T[] arr)
        {
            int n = arr.Length;
            T[] sortedArray = (T[])arr.Clone();
            
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (sortedArray[j].CompareTo(sortedArray[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                
                // Troca os elementos
                T temp = sortedArray[i];
                sortedArray[i] = sortedArray[minIndex];
                sortedArray[minIndex] = temp;
            }
            return sortedArray;
        }
    }
}
