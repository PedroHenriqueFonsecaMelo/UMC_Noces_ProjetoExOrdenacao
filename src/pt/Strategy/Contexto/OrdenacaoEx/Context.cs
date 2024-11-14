using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Concreto;

namespace ExOrdenacao.src.pt.Strategy.Contexto
{
    public class Context<T> where T : IComparable<T>
    {
        private static Random random = new Random();
        private static Stopwatch sw = Stopwatch.StartNew();

        public ISortAlgorithm<T> Strategy { get; set; }

        public double RunAlgorithmMultipleTimes(T[] array)
        {
            double totalTime = 0;

            // Executa o algoritmo 3 vezes
            for (int i = 0; i < 3; i++)
            {
                sw.Restart();
                Strategy.SortMethod(array);  // Executa o algoritmo
                sw.Stop();

                totalTime += sw.Elapsed.TotalMilliseconds;

                // Exibe progresso e tempo restante
                ShowProgress(i + 1, 3, totalTime, array.Length, Strategy.GetType().Name);
            }

            // Calcula a média
            return totalTime / 3;
        }

        static void ShowProgress(int currentIteration, int totalIterations, double timeElapsed, int Length, String algorithmName)
        {
            double percentComplete = (double)currentIteration / totalIterations * 100;
            double timePerIteration = timeElapsed / currentIteration;
            double estimatedTotalTime = timePerIteration * totalIterations;
            double timeRemaining = estimatedTotalTime - timeElapsed;

            Console.Clear(); // Limpa a tela a cada atualização para mostrar apenas o progresso atual
            Console.WriteLine($"Testando array de tamanho: {Length}");
            Console.WriteLine($"\nIniciando {algorithmName}... Execução {currentIteration} de 3");
            Console.WriteLine($"Progresso: {percentComplete:F2}%");
            Console.WriteLine($"Tempo decorrido: {FormatTime(timeElapsed)}");
            Console.WriteLine($"Tempo estimado restante: {FormatTime(timeRemaining)}");
        }

        static string FormatTime(double timeInMilliseconds)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(timeInMilliseconds);
            return string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        }

    }
}
