using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Concreto.FreteEx;

namespace ExOrdenacao.src.pt.Strategy.Contexto.DescontoEx
{
    public interface ICalculaDesconto
    {
        decimal CalcularDesconto(Pedido pedido);
    }
}