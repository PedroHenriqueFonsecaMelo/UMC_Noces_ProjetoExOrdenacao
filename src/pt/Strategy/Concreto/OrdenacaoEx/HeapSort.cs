using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class HeapSort : ISortAlgorithm
    {
        public int[] SortMethod(int[] arr)
        {
            int n = arr.Length;
            int[] sortedArray = (int[])arr.Clone();

            // Construir o heap
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(sortedArray, n, i);
            }

            // Extrair elementos do heap
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = sortedArray[0];
                sortedArray[0] = sortedArray[i];
                sortedArray[i] = temp;

                Heapify(sortedArray, i, 0);
            }

            return sortedArray;
        }

        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }
    }
}