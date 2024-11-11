using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class BucketSort : ISortAlgorithm
    {
        public int[] SortMethod(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;

            int max = arr.Max();
            int min = arr.Min();
            int bucketCount = (max - min) / arr.Length + 1;

            List<int>[] buckets = new List<int>[bucketCount];

            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i] = new List<int>();
            }

            // Coloca os elementos nos baldes
            foreach (int num in arr)
            {
                int bucketIndex = (num - min) / arr.Length;
                buckets[bucketIndex].Add(num);
            }

            // Ordena os baldes e coloca no array original
            int[] sortedArray = new int[arr.Length];
            int index = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort();
                foreach (var num in bucket)
                {
                    sortedArray[index++] = num;
                }
            }

            return sortedArray;
        }
    }
}