using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace ExOrdenacao.src.pt
{
    public class ExOrdenacaoTabela
    {
        static ArrayList QuickSortTempo = new();
        static ArrayList SelectionSortTempo = new();
        static ArrayList InsertionSortTempo = new();
        static ArrayList MergeSortTempo = new();
        static ArrayList BubbleSortTempo = new();
        static ArrayList RadixSortTempo = new();
        static ArrayList HeapSortTempo = new();
        static ArrayList BucketSortTempo = new();
        static ArrayList CountingSortTempo = new();

        public ExOrdenacaoTabela()
        {
        }

        public static void tabela()
        {
            Random random = new Random();
            Stopwatch sw = Stopwatch.StartNew();

            int[] tamanho = { 5000, 10000, 20000, 40000, 80000 };

            // Testa para diferentes tamanhos de arrays
            foreach (int size in tamanho)
            {
                SortTests(sw, new int[size], random);
            }

            // Exibe os resultados em formato tabular
            PrintTable();
        }

        static void SortTests(Stopwatch sw, int[] array, Random random)
        {
            // Preenche o array com números aleatórios
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            Console.WriteLine($"Testando array de tamanho: {array.Length}");

            // Algoritmos de ordenação
            double quickSortAvg = RunAlgorithmMultipleTimes(sw, array, QuickSort);
            QuickSortTempo.Add(quickSortAvg);

            double selectionSortAvg = RunAlgorithmMultipleTimes(sw, array, SelectionSort);
            SelectionSortTempo.Add(selectionSortAvg);

            double insertionSortAvg = RunAlgorithmMultipleTimes(sw, array, InsertionSort);
            InsertionSortTempo.Add(insertionSortAvg);

            double mergeSortAvg = RunAlgorithmMultipleTimes(sw, array, MergeSort);
            MergeSortTempo.Add(mergeSortAvg);

            double bubbleSortAvg = RunAlgorithmMultipleTimes(sw, array, BubbleSort);
            BubbleSortTempo.Add(bubbleSortAvg);

            double radixSortAvg = RunAlgorithmMultipleTimes(sw, array, RadixSort);
            RadixSortTempo.Add(radixSortAvg);

            double heapSortAvg = RunAlgorithmMultipleTimes(sw, array, HeapSort);
            HeapSortTempo.Add(heapSortAvg);

            double bucketSortAvg = RunAlgorithmMultipleTimes(sw, array, BucketSort);
            BucketSortTempo.Add(bucketSortAvg);

            double countingSortAvg = RunAlgorithmMultipleTimes(sw, array, CountingSort);
            CountingSortTempo.Add(countingSortAvg);
        }
        static double imprimirTempo(Stopwatch sw, string sort, int size)
        {
            TimeSpan ts = sw.Elapsed;
            string formated = String.Format("{0:00}:{1:00}:{2:00},{3:0000}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10.0);
            sw.Reset();
            return ts.TotalMilliseconds;  // Retorna o tempo total em milissegundos
        }

        static double RunAlgorithmMultipleTimes(Stopwatch sw, int[] array, Func<int[], int[]> algorithm)
        {
            double totalTime = 0;

            // Executa o algoritmo 3 vezes
            for (int i = 0; i < 3; i++)
            {
                sw.Start();
                algorithm(array);  // Executa o algoritmo
                sw.Stop();

                totalTime += sw.Elapsed.TotalMilliseconds;
                sw.Reset();
            }

            // Calcula a média
            return totalTime / 3;
        }
        static void PrintTable()
        {
            // Títulos da tabela (algoritmos)
            string[] algoritmos = { "QuickSort", "SelectionSort", "InsertionSort", "MergeSort",
                            "BubbleSort", "RadixSort", "HeapSort", "BucketSort", "CountingSort" };

            // Cabeçalho da tabela
            Table table = new Table()
                 .AddColumn("Algoritmo")
                 .AddColumn("50000").NoBorder()
                 .AddColumn("100000").NoBorder()
                 .AddColumn("200000").NoBorder()
                 .AddColumn("400000").NoBorder()
                 .AddColumn("800000").NoBorder();

            // Para cada algoritmo, imprime o nome e os tempos de execução médios
            foreach (var algoritmo in algoritmos)
            {
                string[] tempos;

                switch (algoritmo)
                {
                    case "QuickSort":
                        tempos = QuickSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "SelectionSort":
                        tempos = SelectionSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "InsertionSort":
                        tempos = InsertionSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "MergeSort":
                        tempos = MergeSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "BubbleSort":
                        tempos = BubbleSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "RadixSort":
                        tempos = RadixSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "HeapSort":
                        tempos = HeapSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "BucketSort":
                        tempos = BucketSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "CountingSort":
                        tempos = CountingSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    default:
                        throw new ArgumentException("Algoritmo desconhecido");
                }

                // Adiciona as linhas à tabela
                table.AddRow(algoritmo, tempos[0], tempos[1], tempos[2], tempos[3], tempos[4]);
                
            }

            // Exibe a tabela no console
            AnsiConsole.Write(table);
        }


        // Algoritmos de ordenação
        public static int[] BubbleSort(int[] arr)
        {
            int n = arr.Length;
            int[] sortedArray = (int[])arr.Clone();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sortedArray[j] > sortedArray[j + 1])
                    {
                        int temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }
            return sortedArray;
        }

        public static int[] SelectionSort(int[] arr)
        {
            int n = arr.Length;
            int[] sortedArray = (int[])arr.Clone();
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (sortedArray[j] < sortedArray[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = sortedArray[i];
                sortedArray[i] = sortedArray[minIndex];
                sortedArray[minIndex] = temp;
            }
            return sortedArray;
        }

        public static int[] InsertionSort(int[] arr)
        {
            int n = arr.Length;
            int[] sortedArray = (int[])arr.Clone();
            for (int i = 1; i < n; i++)
            {
                int key = sortedArray[i];
                int j = i - 1;
                while (j >= 0 && sortedArray[j] > key)
                {
                    sortedArray[j + 1] = sortedArray[j];
                    j--;
                }
                sortedArray[j + 1] = key;
            }
            return sortedArray;
        }

        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return (int[])arr.Clone();
            int mid = arr.Length / 2;
            int[] left = MergeSort(arr[..mid]);
            int[] right = MergeSort(arr[mid..]);
            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }
            while (i < left.Length) result[k++] = left[i++];
            while (j < right.Length) result[k++] = right[j++];
            return result;
        }

        public static int[] QuickSort(int[] arr)
        {
            if (arr.Length <= 1) return (int[])arr.Clone();
            return QuickSort((int[])arr.Clone(), 0, arr.Length - 1);
        }

        private static int[] QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
            return arr;
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }

        public static int[] RadixSort(int[] arr)
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

        public static int[] HeapSort(int[] arr)
        {
            int n = arr.Length;
            int[] sortedArray = (int[])arr.Clone();
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(sortedArray, n, i);
            }
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

        public static int[] BucketSort(int[] arr)
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
            foreach (int num in arr)
            {
                int bucketIndex = (num - min) / arr.Length;
                buckets[bucketIndex].Add(num);
            }
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

        public static int[] CountingSort(int[] arr)
        {
            if (arr.Length == 0) return arr;
            int min = arr.Min();
            int max = arr.Max();
            int[] count = new int[max - min + 1];
            int[] sortedArray = new int[arr.Length];
            foreach (int num in arr)
            {
                count[num - min]++;
            }
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