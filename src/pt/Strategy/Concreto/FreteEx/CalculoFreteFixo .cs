using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto.FreteEx;

namespace ExOrdenacao.src.pt.Strategy.Concreto.FreteEx
{
    public class CalculoFreteFixo : ICalculaFrete
    {
        public decimal CalcularFrete(Pedido pedido)
        {
            // Frete fixo, independente do peso ou preço
            return 50;
        }
    }
}