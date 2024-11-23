using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExOrdenacao.src.pt.Strategy.Concreto.FreteEx;
using ExOrdenacao.src.pt.Strategy.Contexto.FreteEx;

namespace UMC_Noces_ProjetoExOrdenacao.src.pt.Strategy.Contexto.FreteEx
{
    public class ContextFrete
    {
         private ICalculaFrete _calculoFrete;

        public ContextFrete(ICalculaFrete calculoFrete)
        {
            _calculoFrete = calculoFrete;
        }

        public ContextFrete()
        {
            _calculoFrete = new CalculoFretePeso();  // A estratégia padrão pode ser 'CalculoFretePeso'
        }

        public void SetCalculaFrete(ICalculaFrete calculoFrete)
        {
            _calculoFrete = calculoFrete;
        }

        // Este método agora define o frete diretamente no pedido
        public void AplicarFrete(Pedido pedido)
        {
            pedido.Frete = _calculoFrete.CalcularFrete(pedido);
            ExibirFreteInfo(pedido);
        }

        public string ObterModalidadeFrete()
        {
            
            return _calculoFrete.GetType().Name.Replace("CalculoFrete","");  // Default
        }

        // Método para exibir o tipo de frete diretamente
        public void ExibirFrete(Pedido pedido)
        {
            string modalidadeFrete = ObterModalidadeFrete();
            Console.WriteLine($"Frete: {modalidadeFrete} - Valor: {pedido.Frete}");
        }

        public void ExibirFreteInfo(Pedido pedido)
        {
            string modalidadeFrete = ObterModalidadeFrete();
            pedido.Info = $"Frete: {modalidadeFrete} - Valor: {pedido.Frete} \n";
        }
    }
}