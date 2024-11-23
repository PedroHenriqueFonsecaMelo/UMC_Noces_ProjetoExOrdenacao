using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Prototype.Interface;
using ExOrdenacao.src.pt.Strategy.Contexto;

namespace ExOrdenacao.src.pt.Bridge
{
    public class BridgeContext<T> where T : IComparable<T>
    {
        private ISortAlgorithm<T>? _sortAlgorithm { get; set; }
        private IPrototype<T>? _dataPrototype { get; set; }
        private static Random random = new Random();
        private static Stopwatch sw = Stopwatch.StartNew();

        // Construtor da abstração (Strategy + Prototype)
        public BridgeContext(ISortAlgorithm<T> sortAlgorithm, IPrototype<T> dataPrototype)
        {
            _sortAlgorithm = sortAlgorithm;
            _dataPrototype = dataPrototype;
        }

        public BridgeContext()
        {
        }

        // Definir o algoritmo de ordenação
        public void SetSortAlgorithm(ISortAlgorithm<T> sortAlgorithm)
        {
            _sortAlgorithm = sortAlgorithm;
        }

        // Definir o protótipo de dados
        public void SetDataPrototype(IPrototype<T> dataPrototype)
        {
            _dataPrototype = dataPrototype;
        }

        public ISortAlgorithm<T> GetSortAlgorithm(ISortAlgorithm<T> sortAlgorithm)
        {
            if (_sortAlgorithm == null || _dataPrototype == null)
            {
                throw new InvalidOperationException("Sort algorithm or data prototype not set.");
            }

            return _sortAlgorithm;
        }

        // Definir o protótipo de dados
        public IPrototype<T> GetDataPrototype()
        {
            if (_sortAlgorithm == null || _dataPrototype == null)
            {
                throw new InvalidOperationException("Sort algorithm or data prototype not set.");
            }

            return _dataPrototype;
        }

        public double RunAlgorithmMultipleTimes()
        {
            double totalTime = 0;
            if (_sortAlgorithm == null || _dataPrototype == null)
            {
                throw new InvalidOperationException("Sort algorithm or data prototype not set.");
            }

            T[] array = _dataPrototype.GetArray();

            // Executa o algoritmo 3 vezes
            for (int i = 0; i < 3; i++)
            {
                sw.Restart();
                if (_sortAlgorithm != null)
                {
                    _sortAlgorithm.SortMethod(array);  // Executa o algoritmo

                    sw.Stop();

                    totalTime += sw.Elapsed.TotalMilliseconds;

                    // Exibe progresso e tempo restante
                    ShowProgress(i + 1, 3, totalTime, array.Length, _sortAlgorithm.GetType().Name);
                }
            }

            // Calcula a média
            return totalTime / 3;
        }

        static void ShowProgress(int currentIteration, int totalIterations, double timeElapsed, int Length, string algorithmName)
        {
            // Remove números e caracteres indesejados no final do nome da classe
            string cleanAlgorithmName = System.Text.RegularExpressions.Regex.Replace(algorithmName, @"\d+", "");

            // Remove os acentos do nome do algoritmo
            string nameWithoutAccents = RemoveAccents(cleanAlgorithmName);

            // Remover qualquer caractere extra como backtick (`) ou outros caracteres especiais
            string finalAlgorithmName = nameWithoutAccents.Replace("`", "").Trim();

            double percentComplete = (double)currentIteration / totalIterations * 100;
            double timePerIteration = timeElapsed / currentIteration;
            double estimatedTotalTime = timePerIteration * totalIterations;
            double timeRemaining = estimatedTotalTime - timeElapsed;

            Console.Clear(); // Limpa a tela a cada atualização para mostrar apenas o progresso atual
            Console.WriteLine($"Testando array de tamanho: {Length}");
            Console.WriteLine($"\nIniciando {finalAlgorithmName}... Execução {currentIteration} de 3");
            Console.WriteLine($"Progresso: {percentComplete:F2}%");
            Console.WriteLine($"Tempo decorrido: {FormatTime(timeElapsed)}");
            Console.WriteLine($"Tempo estimado restante: {FormatTime(timeRemaining)}");
        }

        static string RemoveAccents(string input)
        {
            // Normaliza o texto para decompor os caracteres acentuados em seus componentes
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            // Concatena apenas os caracteres não acentuados
            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Retorna a string sem os acentos
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        static string FormatTime(double timeInMilliseconds)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(timeInMilliseconds);
            return string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        }

    }
}