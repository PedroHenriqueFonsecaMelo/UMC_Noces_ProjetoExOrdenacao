using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class CountingSort: ISortAlgorithm
    {
        public int[] SortMethod(int[] arr)
        {
            if (arr.Length == 0) return arr;

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
    }
}