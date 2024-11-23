using System;
using System.Collections.Generic;
using System.Linq;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class CountingSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public T[] SortMethod(T[] arr)
        {
            if (arr.Length == 0) return arr;

            // Para inteiros ou tipos numéricos
            if (typeof(T) == typeof(int))
            {
                return (T[])(object)SortIntArray((int[])(object)arr);  // Casting de volta para int[]
            }

            // Para double ou tipos numéricos
            if (typeof(T) == typeof(double))
            {
                return (T[])(object)SortDoubleArray((double[])(object)arr);  // Casting de volta para double[]
            }

            // Para strings, ou tipos lexicograficamente ordenáveis
            if (typeof(T) == typeof(string))
            {
                return (T[])(object)SortStringArray((string[])(object)arr);  // Casting de volta para string[]
            }

            // Caso o tipo não seja suportado
            throw new InvalidOperationException("Tipo não suportado para CountingSort.");
        }

        // Método para ordenar inteiros
        private int[] SortIntArray(int[] arr)
        {
            int min = arr.Min();
            int max = arr.Max();
            int[] count = new int[max - min + 1];
            int[] sortedArray = new int[arr.Length];

            // Contar a ocorrência de cada número
            foreach (int num in arr)
            {
                count[num - min]++;
            }

            // Construir o array ordenado
            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    sortedArray[index++] = i + min;
                    count[i]--;
                }
            }

            return sortedArray;
        }

        // Método para ordenar doubles
        private double[] SortDoubleArray(double[] arr)
        {
            double min = arr.Min();
            double max = arr.Max();
            int bucketCount = 1000;  // Ajuste de precisão (número de buckets)
            int[] count = new int[bucketCount];
            double[] sortedArray = new double[arr.Length];

            // Normalizar os números para inteiros (multiplicando por 1000)
            foreach (double num in arr)
            {
                // Calcular o índice de forma segura
                int index = (int)((num - min) * bucketCount); 

                // Garantir que o índice não ultrapasse os limites
                index = Math.Min(Math.Max(index, 0), bucketCount - 1); 

                count[index]++;
            }

            // Construir o array ordenado
            int indexArr = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    sortedArray[indexArr++] = min + (i / (double)bucketCount);
                    count[i]--;
                }
            }

            return sortedArray;
        }

        // Método para ordenar strings
        private string[] SortStringArray(string[] arr)
        {
            var count = new Dictionary<string, int>();
            foreach (string str in arr)
            {
                if (count.ContainsKey(str))
                {
                    count[str]++;
                }
                else
                {
                    count[str] = 1;
                }
            }

            // Gerar o array ordenado
            List<string> sortedList = count.OrderBy(x => x.Key).SelectMany(x => Enumerable.Repeat(x.Key, x.Value)).ToList();

            return sortedList.ToArray();
        }
    }
}
