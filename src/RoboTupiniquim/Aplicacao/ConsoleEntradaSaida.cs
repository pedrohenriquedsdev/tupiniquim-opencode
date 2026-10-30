namespace RoboTupiniquim.Aplicacao;

public sealed class ConsoleEntradaSaida : IEntradaSaida
{
    public void Escrever(string mensagem)
    {
        Console.Write(mensagem);
    }

    public void EscreverLinha(string mensagem)
    {
        Console.WriteLine(mensagem);
    }

    public string? LerLinha()
    {
        return Console.ReadLine();
    }
}
