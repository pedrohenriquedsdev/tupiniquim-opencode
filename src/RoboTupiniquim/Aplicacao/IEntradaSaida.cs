namespace RoboTupiniquim.Aplicacao;

public interface IEntradaSaida
{
    void Escrever(string mensagem);

    void EscreverLinha(string mensagem);

    string? LerLinha();
}
