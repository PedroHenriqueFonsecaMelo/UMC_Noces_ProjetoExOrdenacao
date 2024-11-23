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

        static Context<int> context = new();
        static Context<double> contextDouble = new Context<double>();
        static Context<string> contextString = new Context<string>();

        public ExOrdenacaoTabela() { }

        public static void tabela()
        {
            Random random = new Random();
            Stopwatch sw = Stopwatch.StartNew();

            int[] tamanho = { 500, 1000, 2000, 4000, 8000 };


            // Testa para diferentes tamanhos de arrays
            foreach (int size in tamanho)
            {
                // Testes para int
                SortTests(new int[size], "int");

                // Testes para double
                SortTests(new double[size], "double");

                // Testes para string (gerando palavras com 5 caracteres)
                SortTests(GenerateRandomStrings(size, 5), "string");
            }

            // Exibe os resultados em formato tabular
            PrintTable();
        }

        static void SortTests<T>(T[] array, string type) where T : IComparable<T>
        {
            // Preenche o array com números aleatórios
            if (type == "int")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = (T)(object)random.Next(0, 1000); // Gera números inteiros aleatórios
                }
            }
            else if (type == "double")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = (T)(object)(random.NextDouble() * 1000); // Gera números de ponto flutuante aleatórios
                }
            }
            else if (type == "string")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = (T)(object)GenerateRandomString(5); // Gera strings aleatórias com 5 caracteres
                }
            }

            Console.Clear();
            Console.WriteLine($"Testando array de tamanho: {array.Length}");

            // Algoritmos de ordenação

            IPrototype<T> arrayPrototype = new ArrayDadosPrototype<T>(array);
            

            if (type == "int")
            {
                RunSortTests(context, arrayPrototype.Clonar());
            }
            else if (type == "double")
            {
                RunSortTests(contextDouble, arrayPrototype.Clonar());
            }
            else if (type == "string")
            {
                RunSortTests(contextString, arrayPrototype.Clonar());
            }
        }

        public static void RunSortTests<T>(Context<T> context, T[] array) where T : IComparable<T>
        {

            Console.Clear();
            Console.WriteLine($"Testando array de tamanho: {array.Length}");

            // Algoritmos de ordenação
            context.Strategy = new QuickSort<T>();
            double quickSortAvg = context.RunAlgorithmMultipleTimes(array);
            QuickSortTempo.Add(quickSortAvg);

            context.Strategy = new SelectionSort<T>();
            double selectionSortAvg = context.RunAlgorithmMultipleTimes(array);
            SelectionSortTempo.Add(selectionSortAvg);

            context.Strategy = new InsertionSort<T>();
            double insertionSortAvg = context.RunAlgorithmMultipleTimes(array);
            InsertionSortTempo.Add(insertionSortAvg);

            context.Strategy = new MergeSort<T>();
            double mergeSortAvg = context.RunAlgorithmMultipleTimes(array);
            MergeSortTempo.Add(mergeSortAvg);

            context.Strategy = new BubbleSort<T>();
            double bubbleSortAvg = context.RunAlgorithmMultipleTimes(array);
            BubbleSortTempo.Add(bubbleSortAvg);

            context.Strategy = new RadixSort<T>();
            double radixSortAvg = context.RunAlgorithmMultipleTimes(array);
            RadixSortTempo.Add(radixSortAvg);

            context.Strategy = new CountingSort<T>();
            double countingSortAvg = context.RunAlgorithmMultipleTimes(array);
            CountingSortTempo.Add(countingSortAvg);

            context.Strategy = new BucketSort<T>();
            double bucketSortAvg = context.RunAlgorithmMultipleTimes(array);
            BucketSortTempo.Add(bucketSortAvg);

            context.Strategy = new HeapSort<T>();
            double heapSortAvg = context.RunAlgorithmMultipleTimes(array);
            HeapSortTempo.Add(heapSortAvg);
        }

        // Método para gerar strings aleatórias
        static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Range(0, length).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }

        // Método para gerar um array de strings aleatórias
        static string[] GenerateRandomStrings(int size, int length)
        {
            string[] array = new string[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = GenerateRandomString(length);
            }
            return array;
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