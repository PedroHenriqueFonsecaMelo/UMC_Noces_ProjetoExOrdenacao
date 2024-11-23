using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Concreto.FreteEx;
using ExOrdenacao.src.pt.Strategy.Contexto.DescontoEx;

namespace ExOrdenacao.src.pt.Strategy.Concreto.DescontoEx
{
    public class DescontoDiaDasMaes : ICalculaDesconto
{
    public decimal CalcularDesconto(Pedido pedido)
    {
        return pedido.PrecoTotal * 0.25m; // 25% de desconto
    }
}
}