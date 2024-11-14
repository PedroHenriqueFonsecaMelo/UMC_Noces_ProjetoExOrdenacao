using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Concreto.FreteEx;

namespace ExOrdenacao.src.pt.Strategy.Contexto.FreteEx
{
    public interface ICalculaFrete
    {
          decimal CalcularFrete(Pedido pedido);
    }
}