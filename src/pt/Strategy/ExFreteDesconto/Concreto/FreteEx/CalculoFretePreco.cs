using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto.FreteEx;

namespace ExOrdenacao.src.pt.Strategy.Concreto.FreteEx
{
    public class CalculoFretePreco: ICalculaFrete
{
    public decimal CalcularFrete(Pedido pedido)
    {
        // Exemplo: frete é 5% do valor total
        return pedido.PrecoTotal * 0.05m;
    }
}
}