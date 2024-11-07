using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class RadixSort
    {
        public static int[] SortMethod(int[] arr)
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

    private static void CountingSortByDigit(int[] arr, int exp)
    {
        int n = arr.Length;
        int[] output = new int[n];
        int[] count = new int[10];

        // Contar ocorrências
        for (int i = 0; i < n; i++)
        {
            count[(arr[i] / exp) % 10]++;
        }

        // Atualizar a posição dos elementos no array de saída
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Construir o array de saída
        for (int i = n - 1; i >= 0; i--)
        {
            output[count[(arr[i] / exp) % 10] - 1] = arr[i];
            count[(arr[i] / exp) % 10]--;
        }

        // Copiar o array de saída para o array original
        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }
    }
}