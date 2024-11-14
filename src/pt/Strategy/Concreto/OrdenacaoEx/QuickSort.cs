using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class QuickSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public T[] SortMethod(T[] arr)
        {
            if (arr.Length <= 1) return (T[])arr.Clone();
            return QuickSortAlgorithm((T[])arr.Clone(), 0, arr.Length - 1);
        }

        private T[] QuickSortAlgorithm(T[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSortAlgorithm(arr, low, pi - 1);
                QuickSortAlgorithm(arr, pi + 1, high);
            }
            return arr;
        }

        private int Partition(T[] arr, int low, int high)
        {
            T pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j].CompareTo(pivot) < 0)
                {
                    i++;
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            T temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }
    }

}