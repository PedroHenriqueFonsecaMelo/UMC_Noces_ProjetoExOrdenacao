using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy;
using ExOrdenacao.src.pt.Strategy.Concreto;
using ExOrdenacao.src.pt.Strategy.Contexto;
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
        static Random random = new Random();

        static Context context = new Context();

        public ExOrdenacaoTabela() { }

        public static void tabela()
        {
            Random random = new Random();
            Stopwatch sw = Stopwatch.StartNew();

            int[] tamanho = { 50000, 100000, 200000, 400000, 800000 };


            // Testa para diferentes tamanhos de arrays
            foreach (int size in tamanho)
            {
                SortTests(new int[size]);
            }

            // Exibe os resultados em formato tabular
            PrintTable();
        }

        static void SortTests(int[] array)
        {
            // Preenche o array com números aleatórios
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            Console.Clear();
            Console.WriteLine($"Testando array de tamanho: {array.Length}");

            // Algoritmos de ordenação

            context.Strategy = new QuickSort();
            double quickSortAvg = context.RunAlgorithmMultipleTimes(array);
            QuickSortTempo.Add(quickSortAvg);

            context.Strategy = new SelectionSort();
            double selectionSortAvg = context.RunAlgorithmMultipleTimes(array);
            SelectionSortTempo.Add(selectionSortAvg);

            context.Strategy = new InsertionSort();
            double insertionSortAvg = context.RunAlgorithmMultipleTimes(array);
            InsertionSortTempo.Add(insertionSortAvg);

            context.Strategy = new MergeSort();
            double mergeSortAvg = context.RunAlgorithmMultipleTimes(array);
            MergeSortTempo.Add(mergeSortAvg);

            context.Strategy = new BubbleSort();
            double bubbleSortAvg = context.RunAlgorithmMultipleTimes(array);
            BubbleSortTempo.Add(bubbleSortAvg);

            context.Strategy = new RadixSort();
            double RadixSortAvg = context.RunAlgorithmMultipleTimes(array);
            RadixSortTempo.Add(RadixSortAvg);

            context.Strategy = new CountingSort();
            double CountingSortAvg = context.RunAlgorithmMultipleTimes(array);
            CountingSortTempo.Add(CountingSortAvg);

            context.Strategy = new BucketSort();
            double BucketSortAvg = context.RunAlgorithmMultipleTimes(array);
            BucketSortTempo.Add(BucketSortAvg);

            context.Strategy = new HeapSort();
            double HeapSortAvg = context.RunAlgorithmMultipleTimes(array);
            HeapSortTempo.Add(HeapSortAvg);
        }

        static void PrintTable()
        {
            // Títulos da tabela (algoritmos)
            string[] algoritmos = { "QuickSort", "SelectionSort", "InsertionSort", "MergeSort", "BubbleSort",
            "RadixSort", "CountingSort", "BucketSort", "HeapSort" };

            // Cabeçalho da tabela
            Table table = new Table()
                 .AddColumn("Algoritmo")
                 .AddColumn("50000")
                 .AddColumn("100000")
                 .AddColumn("200000")
                 .AddColumn("400000")
                 .AddColumn("800000");

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
                    case "CountingSort":
                        tempos = CountingSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "BucketSort":
                        tempos = BucketSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
                        break;
                    case "HeapSort":
                        tempos = HeapSortTempo.Cast<double>().Select(t => t.ToString("F4").Replace('.', ',')).ToArray();
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
    }
}