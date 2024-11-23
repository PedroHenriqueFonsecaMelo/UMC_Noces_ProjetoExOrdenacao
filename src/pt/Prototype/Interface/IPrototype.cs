using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExOrdenacao.src.pt.Prototype.Interface
{
    public interface IPrototype<T>
    {
    IPrototype<T> Clonar(); // Método para clonagem
    void CompararValores(int i, int j); // Método para comparação
    void TrocarValores(int i, int j); // Método para troca de elementos
    int GetTamanho(); // Método para obter o tamanho do array
    void Imprimir(); // Método para imprimir os elementos do array
    }
}