using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Strategy.Concreto
{
    public class BogoSort : ISortAlgorithm
    {
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        // To check if array is sorted or not 
        public static bool isSorted(int[] a, int n)
        {
            int i = 0;
            while (i < n - 1)
            {
                if (a[i] > a[i + 1])
                    return false;
                i++;
            }
            return true;
        }

        // To generate permutation of the array 
        public static void shuffle(int[] a, int n)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                Swap(ref a[i], ref a[rnd.Next(0, n)]);
        }

        // Sorts array a[0..n-1] using Bogo sort 
        public int[] SortMethod(int[] a)
        {
            // if array is not sorted then shuffle 
            // the array again 
            int n = a.Length;
            while (!isSorted(a, n))
                shuffle(a, n);
                
            return a;
        }
    }
}