using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class BucketSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public T[] SortMethod(T[] arr)
        {
            if (arr.Length <= 1)
                return arr; // Se o array já tiver um ou nenhum elemento, não precisa ordenar.

            // Encontrar o máximo e o mínimo dos elementos
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Array não pode ser nulo ou vazio.");
                
            T max = arr.Max();
            T min = arr.Min();

            // Número de baldes
            int bucketCount = arr.Length;

            // Criar os baldes (List<T>[])
            List<T>[] buckets = new List<T>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i] = new List<T>();
            }

            // Distribuir os elementos para os baldes
            foreach (T num in arr)
            {
                int bucketIndex = GetBucketIndex(num, min, max, bucketCount);
                buckets[bucketIndex].Add(num);
            }

            // Ordenar os baldes e combinar os resultados
            T[] sortedArray = new T[arr.Length];
            int index = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort(); // Ordenar os baldes usando o método de ordenação da List<T>
                foreach (var num in bucket)
                {
                    sortedArray[index++] = num;
                }
            }

            return sortedArray;
        }

        /// <summary>
        /// Calcula o índice do balde com base no valor do elemento.
        /// </summary>
        private int GetBucketIndex(T value, T min, T max, int bucketCount)
        {
            // Para tipos numéricos (double, int), fazemos uma normalização
            if (typeof(T) == typeof(double) || typeof(T) == typeof(int))
            {
                dynamic val = value;
                dynamic minVal = min;
                dynamic maxVal = max;
                return (int)((val - minVal) * (bucketCount - 1) / (maxVal - minVal));
            }

            // Para tipos como string, podemos usar a comparação lexicográfica
            if (typeof(T) == typeof(string))
            {
                string? val = value as string;
                string? minVal = min as string;
                string? maxVal = max as string;
                return (int)(val.CompareTo(minVal) * (bucketCount - 1) / maxVal.CompareTo(minVal));
            }

            // Para outros tipos que não são numéricos ou string, podemos lançar uma exceção.
            throw new InvalidOperationException("Tipo não suportado para BucketSort.");
        }
    }
}