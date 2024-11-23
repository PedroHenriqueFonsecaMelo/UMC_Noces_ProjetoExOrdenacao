using System;
using System.Collections.Generic;
using System.Linq;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class MergeSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public T[] SortMethod(T[] arr)
        {
            if (arr.Length <= 1) return (T[])arr.Clone();
            int mid = arr.Length / 2;
            T[] left = SortMethod(arr[..mid]);
            T[] right = SortMethod(arr[mid..]);
            return Merge(left, right);
        }

        private T[] Merge(T[] left, T[] right)
        {
            T[] result = new T[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                // Usamos CompareTo para comparação de qualquer tipo T que implemente IComparable<T>
                if (left[i].CompareTo(right[j]) <= 0)
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }

            // Adiciona os elementos restantes
            while (i < left.Length) result[k++] = left[i++];
            while (j < right.Length) result[k++] = right[j++];

            return result;
        }
    }
}
