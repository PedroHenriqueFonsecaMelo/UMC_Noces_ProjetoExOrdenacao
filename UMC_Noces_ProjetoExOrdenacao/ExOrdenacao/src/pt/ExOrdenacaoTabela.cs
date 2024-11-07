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

        public ExOrdenacaoTabela() { }

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
            double quickSortAvg = RunAlgorithmMultipleTimes(sw, array, new QuickSort());
            QuickSortTempo.Add(quickSortAvg);

            double selectionSortAvg = RunAlgorithmMultipleTimes(sw, array, new SelectionSort());
            SelectionSortTempo.Add(selectionSortAvg);

            double insertionSortAvg = RunAlgorithmMultipleTimes(sw, array, new InsertionSort());
            InsertionSortTempo.Add(insertionSortAvg);

            double mergeSortAvg = RunAlgorithmMultipleTimes(sw, array, new MergeSort());
            MergeSortTempo.Add(mergeSortAvg);

            double bubbleSortAvg = RunAlgorithmMultipleTimes(sw, array, new BubbleSort());
            BubbleSortTempo.Add(bubbleSortAvg);
        }

        static double RunAlgorithmMultipleTimes(Stopwatch sw, int[] array, ISortAlgorithm algorithm)
        {
            double totalTime = 0;

            // Executa o algoritmo 3 vezes
            for (int i = 0; i < 3; i++)
            {
                sw.Start();
                algorithm.Sort(array);  // Executa o algoritmo
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
            string[] algoritmos = { "QuickSort", "SelectionSort", "InsertionSort", "MergeSort", "BubbleSort" };

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