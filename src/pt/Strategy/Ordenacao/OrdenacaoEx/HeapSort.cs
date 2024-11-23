using System;
using System.Collections.Generic;
using System.Linq;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class HeapSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public T[] SortMethod(T[] arr)
        {
            int n = arr.Length;
            T[] sortedArray = (T[])arr.Clone(); // Faz uma cópia do array original

            // Construir o heap
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(sortedArray, n, i);
            }

            // Extrair elementos do heap
            for (int i = n - 1; i >= 0; i--)
            {
                T temp = sortedArray[0];
                sortedArray[0] = sortedArray[i];
                sortedArray[i] = temp;

                Heapify(sortedArray, i, 0);
            }

            return sortedArray;
        }

        private static void Heapify(T[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // Comparar os elementos para garantir a propriedade de heap
            if (left < n && arr[left].CompareTo(arr[largest]) > 0)
            {
                largest = left;
            }

            if (right < n && arr[right].CompareTo(arr[largest]) > 0)
            {
                largest = right;
            }

            // Se o maior não for o nó atual, trocar e aplicar heapify recursivamente
            if (largest != i)
            {
                T swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }
    }
}
