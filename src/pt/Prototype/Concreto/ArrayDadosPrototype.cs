using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Prototype.Interface;

namespace ExOrdenacao.src.pt.Prototype.Concreto
{
    public class ArrayDadosPrototype<T> : IPrototype<T> where T : IComparable<T>
    {
        private T[] _dados;

        public ArrayDadosPrototype(T[] dados)
        {
            _dados = dados;
        }

        // Método Clonar que lida com tipos específicos de arrays (int[], double[], string[])
        public IPrototype<T> Clonar()
        {
            // Verifica o tipo real do array e faz a clonagem corretamente
            if (_dados is int[]) // Se o array for do tipo int[]
            {
                int[] clonedArray = (int[])_dados.Clone();
                return (IPrototype<T>)new ArrayDadosPrototype<int>(clonedArray); // Converte explicitamente para IPrototype<T>
            }
            else if (_dados is double[]) // Se o array for do tipo double[]
            {
                double[] clonedArray = (double[])_dados.Clone();
                return (IPrototype<T>)new ArrayDadosPrototype<double>(clonedArray); // Converte explicitamente para IPrototype<T>
            }
            else if (_dados is string[]) // Se o array for do tipo string[]
            {
                string[] clonedArray = (string[])_dados.Clone();
                return (IPrototype<T>)new ArrayDadosPrototype<string>(clonedArray); // Converte explicitamente para IPrototype<T>
            }
            else
            {
                throw new InvalidOperationException("Tipo de array não suportado.");
            }
        }

        public T[] GetArray()
        {
            return _dados;
        }

        public void CompararValores(int i, int j)
        {
            if (_dados[i].CompareTo(_dados[j]) > 0)
            {
                TrocarValores(i, j); // Se o valor em i for maior que em j, troca
            }
        }

        public void TrocarValores(int i, int j)
        {
            T temp = _dados[i];
            _dados[i] = _dados[j];
            _dados[j] = temp;
        }

        public int GetTamanho()
        {
            return _dados.Length;
        }

        public void Imprimir()
        {
            Console.WriteLine(string.Join(", ", _dados));
        }
    }
}