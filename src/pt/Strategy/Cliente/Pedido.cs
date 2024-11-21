using ExOrdenacao.src.pt.Strategy.Contexto.DescontoEx;
using ExOrdenacao.src.pt.Strategy.Contexto.FreteEx;

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

    // Construtor para criar um Pedido com preço e peso
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

    // Exibe o resumo do pedido
    public void Summary()
    {
        // Limpa o valor anterior da propriedade Info
        _info = $"Preço final com desconto e frete: {PrecoComDescontoEfrete()}";
        Console.WriteLine(_info);
    }

    // Método para aplicar o cálculo de frete (passando a estratégia de frete diretamente)
    public void AplicarFrete(ICalculaFrete calculoFrete)
    {
        Frete = calculoFrete.CalcularFrete(this);
    }

    // Método para aplicar o cálculo de desconto (passando a estratégia de desconto diretamente)
    public void AplicarDesconto(ICalculaDesconto calculoDesconto)
    {
        Desconto = calculoDesconto.CalcularDesconto(this);
    }
}