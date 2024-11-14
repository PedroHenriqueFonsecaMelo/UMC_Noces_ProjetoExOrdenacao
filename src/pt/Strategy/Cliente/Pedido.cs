using System.Dynamic;
using ExOrdenacao.src.pt.Strategy.Concreto.DescontoEx;
using ExOrdenacao.src.pt.Strategy.Contexto.DescontoEx;
using ExOrdenacao.src.pt.Strategy.Contexto.FreteEx;
using UMC_Noces_ProjetoExOrdenacao.src.pt.Strategy.Contexto.DescontoEx;
using UMC_Noces_ProjetoExOrdenacao.src.pt.Strategy.Contexto.FreteEx;

namespace ExOrdenacao.src.pt.Strategy.Concreto.FreteEx
{
    public class Pedido
    {
        public decimal PrecoTotal { get; set; }
        public decimal PesoTotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal Frete { get; set; }
        private string _info = string.Empty;

        public string Info
        {
            get { return _info; }
            set { _info += value; }  // Adiciona o novo valor à string existente
        }

        public Pedido(decimal precoTotal, decimal pesoTotal)
        {
            PrecoTotal = precoTotal;
            PesoTotal = pesoTotal;
        }

        // Calcula o preço final após o desconto e frete
        public decimal PrecoComDescontoEfrete()
        {
            return PrecoTotal - Desconto + Frete;
        }

        public void Summary(){
            Info = $"Preço final com desconto e frete: {PrecoComDescontoEfrete()}";
            Console.WriteLine(Info);
           
        }

    }
}
