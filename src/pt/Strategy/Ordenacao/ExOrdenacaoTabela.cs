using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Bridge;
using ExOrdenacao.src.pt.Prototype.Concreto;
using ExOrdenacao.src.pt.Prototype.Interface;
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

        static BridgeContext<int> contextInt = new();
        static BridgeContext<double> contextDouble = new();
        static BridgeContext<string> contextString = new();

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
                ArrayDadosPrototype<int> clonedPrototype = (ArrayDadosPrototype<int>)arrayPrototype.Clonar();
                contextInt.SetDataPrototype(clonedPrototype);

                RunSortTests(contextInt);
            }
            else if (type == "double")
            {
                ArrayDadosPrototype<double> clonedPrototype = (ArrayDadosPrototype<double>)arrayPrototype.Clonar();
                contextDouble.SetDataPrototype(clonedPrototype);

                RunSortTests(contextDouble);
                
            }
            else if (type == "string")
            {
                ArrayDadosPrototype<string> clonedPrototype = (ArrayDadosPrototype<string>)arrayPrototype.Clonar();
                 contextString.SetDataPrototype(clonedPrototype);

                RunSortTests(contextString);
            }
        }

        public static void RunSortTests<T>(BridgeContext<T> context) where T : IComparable<T>
        {

            Console.Clear();
            Console.WriteLine($"Testando array de tamanho: {context.GetDataPrototype().GetArray().Length}");

            // Algoritmos de ordenação
            context.SetSortAlgorithm(new QuickSort<T>());
            double quickSortAvg = context.RunAlgorithmMultipleTimes();
            QuickSortTempo.Add(quickSortAvg);

            context.SetSortAlgorithm(new SelectionSort<T>());
            double selectionSortAvg = context.RunAlgorithmMultipleTimes();
            SelectionSortTempo.Add(selectionSortAvg);

            context.SetSortAlgorithm(new InsertionSort<T>());
            double insertionSortAvg = context.RunAlgorithmMultipleTimes();
            InsertionSortTempo.Add(insertionSortAvg);

            context.SetSortAlgorithm(new MergeSort<T>());
            double mergeSortAvg = context.RunAlgorithmMultipleTimes();
            MergeSortTempo.Add(mergeSortAvg);

            context.SetSortAlgorithm(new BubbleSort<T>());
            double bubbleSortAvg = context.RunAlgorithmMultipleTimes();
            BubbleSortTempo.Add(bubbleSortAvg);

            context.SetSortAlgorithm(new RadixSort<T>());
            double radixSortAvg = context.RunAlgorithmMultipleTimes();
            RadixSortTempo.Add(radixSortAvg);

            context.SetSortAlgorithm(new CountingSort<T>());
            double countingSortAvg = context.RunAlgorithmMultipleTimes();
            CountingSortTempo.Add(countingSortAvg);

            context.SetSortAlgorithm(new BucketSort<T>());
            double bucketSortAvg = context.RunAlgorithmMultipleTimes();
            BucketSortTempo.Add(bucketSortAvg);

            context.SetSortAlgorithm(new HeapSort<T>());
            double heapSortAvg = context.RunAlgorithmMultipleTimes();
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