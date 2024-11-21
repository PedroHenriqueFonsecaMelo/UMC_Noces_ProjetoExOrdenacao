using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Contexto.DescontoEx;
using ExOrdenacao.src.pt.Strategy.Contexto.FreteEx;

namespace ExOrdenacao.src.pt.Strategy.Concreto.FreteEx
{
    public class Pedido
    {
        public decimal PrecoTotal { get; set; }
        public decimal PesoTotal { get; set; }
        public decimal Desconto { get; private set; }
        public decimal Frete { get; private set; }

        private ICalculaFrete? _calculoFrete;
        private ICalculaDesconto? _calculoDesconto;

        public Pedido(decimal precoTotal, decimal pesoTotal)
        {
            PrecoTotal = precoTotal;
            PesoTotal = pesoTotal;
        }

        // Define a estratégia de cálculo de frete
        public void SetCalculaFrete(ICalculaFrete calculo)
        {
            _calculoFrete = calculo;
        }

        // Define a estratégia de cálculo de desconto
        public void SetCalculaDesconto(ICalculaDesconto calculo)
        {
            _calculoDesconto = calculo;
        }

        // Aplica o desconto no pedido
        public void AplicarDesconto()
        {
            if (_calculoDesconto == null)
            {
                throw new InvalidOperationException("Estratégia de desconto não definida.");
            }
            Desconto = _calculoDesconto.CalcularDesconto(this);
        }

        // Calcula o frete do pedido
        public void CalcularFrete()
        {
            if (_calculoFrete == null)
            {
                throw new InvalidOperationException("Estratégia de cálculo de frete não definida.");
            }
            Frete = _calculoFrete.CalcularFrete(this);
        }

        // Mostra o preço final após desconto e frete
        public decimal PrecoComDescontoEfrete()
        {
            return PrecoTotal - Desconto + Frete;
        }
    }
}