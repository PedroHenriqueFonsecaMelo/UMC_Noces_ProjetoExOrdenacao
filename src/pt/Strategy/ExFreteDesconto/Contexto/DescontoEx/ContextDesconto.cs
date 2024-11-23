using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Concreto.DescontoEx;
using ExOrdenacao.src.pt.Strategy.Concreto.FreteEx;
using ExOrdenacao.src.pt.Strategy.Contexto.DescontoEx;

namespace UMC_Noces_ProjetoExOrdenacao.src.pt.Strategy.Contexto.DescontoEx
{
    public class ContextDesconto
    {
        private ICalculaDesconto _calculoDesconto;

        public ContextDesconto(ICalculaDesconto calculoDesconto)
        {
            _calculoDesconto = calculoDesconto;
        }

        public ContextDesconto()
        {
            _calculoDesconto = new DescontoPascoa();
        }

        public void SetCalculaDesconto(ICalculaDesconto calculoDesconto)
        {
            _calculoDesconto = calculoDesconto;
        }

        // Este método agora define o desconto diretamente no pedido
        public void AplicarDesconto(Pedido pedido)
        {
            pedido.Desconto = _calculoDesconto.CalcularDesconto(pedido);
            ExibirDescontoInfo(pedido);
        }

        public string ObterModalidadeDesconto()
        {
            return Regex.Replace(_calculoDesconto.GetType().Name.Replace("Desconto", ""),
            "(?<!^)([A-Z])", " $1");  // Default
        }

        // Método para exibir o tipo de desconto diretamente
        public void ExibirDesconto(Pedido pedido)
        {
            string modalidadeDesconto = ObterModalidadeDesconto();
            Console.WriteLine($"Desconto: {modalidadeDesconto} - Valor: {pedido.Desconto}");
        }
        public void ExibirDescontoInfo(Pedido pedido)
        {
            string modalidadeDesconto = ObterModalidadeDesconto();
            pedido.Info = $"Desconto: {modalidadeDesconto} - Valor: {pedido.Desconto} \n";
        }
    }
}