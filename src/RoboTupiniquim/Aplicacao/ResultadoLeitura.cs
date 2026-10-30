namespace RoboTupiniquim.Aplicacao;

public sealed class ResultadoLeitura<T> where T : class
{
    private ResultadoLeitura(T? valor, string? erro)
    {
        Valor = valor;
        Erro = erro;
    }

    public bool Sucesso
    {
        get
        {
            return Erro is null;
        }
    }

    public T? Valor { get; }

    public string? Erro { get; }

    public static ResultadoLeitura<T> Ok(T valor)
    {
        return new ResultadoLeitura<T>(valor, null);
    }

    public static ResultadoLeitura<T> Falha(string erro)
    {
        return new ResultadoLeitura<T>(null, erro);
    }
}
