using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using ExOrdenacao.src.pt;




class Program
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


    static void Main(string[] args)
    {
        Random random = new Random();
        Stopwatch sw = Stopwatch.StartNew();

        //int[] array;
        //int[] tamanho = [256, 512, 1024, 2048];
        //int tamanhoB = 2560;



        //array = new int[random.Next(1, 5) * 256];
        /*
        SortTests(sw, array = new int[256000], random);
        SortTests(sw, array = new int[512000], random);
        SortTests(sw, array = new int[1024000], random);
        SortTests(sw, array = new int[2048000], random);
        SortTests(sw, array = new int[4076000], random);
        */
        /*
        SortTests(sw, array = new int[tamanhoB], random);
        SortTests(sw, array = new int[tamanhoB*2], random);
        SortTests(sw, array = new int[tamanhoB*4], random);
        SortTests(sw, array = new int[tamanhoB*8], random);
        SortTests(sw, array = new int[tamanhoB*16], random);
        */

        /*imprimir(array);

        TimeSpan ts = sw.Elapsed;

        string formated = String.Format("{0:00}:{1:00}:{2:00}.{3:0000}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10.0);

        Console.WriteLine("TEMPO TOTAL: " + formated);*/

        /*
                Console.WriteLine("QuickSortTempo:     [{0}]", string.Join("    ", QuickSortTempo.ToArray()));
                Console.WriteLine("SelectionSortTempo: [{0}]", string.Join("    ", SelectionSortTempo.ToArray()));
                Console.WriteLine("InsertionSortTempo: [{0}]", string.Join("    ", InsertionSortTempo.ToArray()));
                Console.WriteLine("MergeSortTempo:     [{0}]", string.Join("    ", MergeSortTempo.ToArray()));
                Console.WriteLine("BubbleSortTempo:    [{0}]", string.Join("    ", BubbleSortTempo.ToArray()));
                Console.WriteLine("RadixSortTempo:     [{0}]", string.Join("    ", RadixSortTempo.ToArray()));
                Console.WriteLine("HeapSortTempo:      [{0}]", string.Join("    ", HeapSortTempo.ToArray()));
                Console.WriteLine("BucketSortTempo:    [{0}]", string.Join("    ", BucketSortTempo.ToArray()));
                Console.WriteLine("CountingSortTempo:  [{0}]", string.Join("    ", CountingSortTempo.ToArray()));
        */
        ExOrdenacaoTabela ordenacaoTabela = new();
        ExOrdenacaoTabela.tabela();

    }

    static void SortTests(Stopwatch sw, int[] array, Random random)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(0, 1000);
        }
        int[] arr_return;
        Console.WriteLine(array.Length);

        sw.Start();
        arr_return = QuickSort(array);
        sw.Stop();
        QuickSortTempo.Add(imprimirTempo(sw, "QuickSort", array.Length));
        //imprimir(arr_return);

        sw.Start();
        arr_return = SelectionSort(array);
        sw.Stop();
        SelectionSortTempo.Add(imprimirTempo(sw, "SelectionSort", array.Length));
        //imprimir(arr_return);


        sw.Start();
        arr_return = InsertionSort(array);
        sw.Stop();
        InsertionSortTempo.Add(imprimirTempo(sw, "InsertionSort", array.Length));
        //imprimir(arr_return);

        sw.Start();
        arr_return = MergeSort(array);
        sw.Stop();
        MergeSortTempo.Add(imprimirTempo(sw, "MergeSort", array.Length));
        //imprimir(arr_return);

        sw.Start();
        arr_return = BubbleSort(array);
        sw.Stop();
        BubbleSortTempo.Add(imprimirTempo(sw, "BubbleSort", array.Length));
        //imprimir(arr_return);

        // Testa o RadixSort
        sw.Start();
        arr_return = RadixSort(array);
        sw.Stop();
        RadixSortTempo.Add(imprimirTempo(sw, "RadixSort", array.Length));

        // Testa o HeapSort
        sw.Start();
        arr_return = HeapSort(array);
        sw.Stop();
        HeapSortTempo.Add(imprimirTempo(sw, "HeapSort", array.Length));

        // Testa o BucketSort
        sw.Start();
        arr_return = BucketSort(array);
        sw.Stop();
        BucketSortTempo.Add(imprimirTempo(sw, "BucketSort", array.Length));

        // Testa o CountingSort
        sw.Start();
        arr_return = CountingSort(array);
        sw.Stop();
        CountingSortTempo.Add(imprimirTempo(sw, "CountingSort", array.Length));


    }

    static double imprimirTempo(Stopwatch sw, String sort, int size)
    {
        TimeSpan ts = sw.Elapsed;

        string formated = String.Format("{0:00}:{1:00}:{2:00}.{3:0000}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10.0);

        //Console.WriteLine("TEMPO TOTAL: " + formated);
        //Console.WriteLine("Sort: " + sort);
        //Console.WriteLine("Size: " + size);
        //Console.WriteLine();
        sw.Reset();
        return ts.Milliseconds * 10;
    }

    static void imprimir(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
            Console.Write(array[i].ToString() + "|");
        Console.WriteLine("");
    }
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
                    // Intercambiar sortedArray[j] y sortedArray[j + 1]
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

            // Mover elementos que son mayores que key a una posición adelante
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
            {
                result[k++] = left[i++];
            }
            else
            {
                result[k++] = right[j++];
            }
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
                // Intercambiar arr[i] y arr[j]
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        // Intercambiar arr[i + 1] y arr[high] (o pivot)
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

    public static int[] HeapSort(int[] arr)
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

    public static int[] CountingSort(int[] arr)
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