using RoboTupiniquim.Dominio;

namespace RoboTupiniquim.Aplicacao;

public sealed class LeitorPosicao
{
    private const string FormatoEsperado = "Informe a posição no formato \"X Y Direção\" (ex.: 1 2 N).";

    public ResultadoLeitura<PosicaoInicial> Ler(string? entrada)
    {
        if (string.IsNullOrWhiteSpace(entrada))
        {
            return ResultadoLeitura<PosicaoInicial>.Falha(FormatoEsperado);
        }

        var partes = entrada.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

        if (partes.Length != 3)
        {
            return ResultadoLeitura<PosicaoInicial>.Falha(FormatoEsperado);
        }

        if (!int.TryParse(partes[0], out var x) || !int.TryParse(partes[1], out var y))
        {
            return ResultadoLeitura<PosicaoInicial>.Falha("As coordenadas X e Y devem ser números inteiros.");
        }

        if (partes[2].Length != 1 || !Direcao.TentarObterPorLetra(partes[2][0], out var direcao))
        {
            return ResultadoLeitura<PosicaoInicial>.Falha("Orientação inválida. Use N, S, L ou O.");
        }

        return ResultadoLeitura<PosicaoInicial>.Ok(new PosicaoInicial(new Posicao(x, y), direcao!));
    }
}
