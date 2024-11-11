using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto.FreteEx;

namespace ExOrdenacao.src.pt.Strategy.Concreto.FreteEx
{
    public class CalculoFretePeso : ICalculaFrete
{
    public decimal CalcularFrete(Pedido pedido)
    {
        // Exemplo: frete é 10 por quilo
        return pedido.PesoTotal * 10;
    }
}
}