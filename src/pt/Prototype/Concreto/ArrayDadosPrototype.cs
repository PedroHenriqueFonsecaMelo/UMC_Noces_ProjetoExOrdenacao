using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExOrdenacao.src.pt.Prototype.Concreto
{
    public class ArrayDadosPrototype<T> : IPrototype<T> where T : IComparable<T>
{
    private T[] _dados {get; set;};

    public ArrayDadosPrototype(T[] dados)
    {
        _dados = dados;
    }

    public ArrayDadosPrototype()
    {

    }

    public IPrototype<T> Clonar()
    {
        // Retorna uma cópia do objeto atual
        return new ArrayDadosPrototype<T>((T[])_dados.Clone());
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