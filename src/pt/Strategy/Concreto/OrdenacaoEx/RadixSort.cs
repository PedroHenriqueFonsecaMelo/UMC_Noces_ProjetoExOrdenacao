using System;
using System.Collections.Generic;
using System.Linq;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class RadixSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public T[] SortMethod(T[] arr)
        {
            // Verifica se o tipo é um número (int, double, etc.)
            if (typeof(T) == typeof(int))
            {
                return (T[])(object)SortIntArray((int[])(object)arr); // Cast para int[] e chama a versão tradicional
            }
            else if (typeof(T) == typeof(double))
            {
                return (T[])(object)SortDoubleArray((double[])(object)arr); // Cast para double[] e chama a versão de double
            }
            else if (typeof(T) == typeof(string))
            {
                return (T[])(object)SortStringArray((string[])(object)arr); // Cast para string[] e chama a versão de string
            }

            throw new InvalidOperationException("Tipo não suportado.");
        }

        // Método para ordenar arrays de int
        private int[] SortIntArray(int[] arr)
        {
            int max = arr.Max();
            int exp = 1;
            int[] sortedArray = (int[])arr.Clone();

            while (max / exp > 0)
            {
                CountingSortByDigit(sortedArray, exp);
                exp *= 10;
            }

            return sortedArray;
        }

        // Método para ordenar arrays de double
        private double[] SortDoubleArray(double[] arr)
        {
            // Para RadixSort funcionar com double, podemos trabalhar com valores absolutos e uma precisão fixa.
            double max = arr.Max();
            int exp = 1;
            double[] sortedArray = (double[])arr.Clone();

            while (max / exp > 0)
            {
                CountingSortByDigit(sortedArray, exp);
                exp *= 10;
            }

            return sortedArray;
        }

        // Método para ordenar arrays de string
        private string[] SortStringArray(string[] arr)
        {
            int maxLength = arr.Max(s => s.Length);
            string[] sortedArray = (string[])arr.Clone();

            // Ordena por cada dígito/posição
            for (int i = maxLength - 1; i >= 0; i--)
            {
                sortedArray = CountingSortByStringDigit(sortedArray, i);
            }

            return sortedArray;
        }

        // Contagem de dígitos (para int e double)
        private static void CountingSortByDigit(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }

        // Contagem de dígitos (para double)
        private static void CountingSortByDigit(double[] arr, int exp)
        {
            int n = arr.Length;
            double[] output = new double[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
            {
                count[(int)(arr[i] / exp) % 10]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(int)(arr[i] / exp) % 10] - 1] = arr[i];
                count[(int)(arr[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }

        // Contagem de dígitos (para string)
        private static string[] CountingSortByStringDigit(string[] arr, int index)
        {
            int n = arr.Length;
            string[] output = new string[n];
            int[] count = new int[256]; // Suporte para todos os caracteres ASCII

            for (int i = 0; i < n; i++)
            {
                char charAtIndex = index < arr[i].Length ? arr[i][index] : '\0';
                count[charAtIndex]++;
            }

            for (int i = 1; i < 256; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                char charAtIndex = index < arr[i].Length ? arr[i][index] : '\0';
                output[count[charAtIndex] - 1] = arr[i];
                count[charAtIndex]--;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }

            return arr;
        }
    }
}
