using RoboTupiniquim.Dominio.Comandos;

namespace RoboTupiniquim.Aplicacao;

public sealed class LeitorComandos
{
    public ResultadoLeitura<IReadOnlyList<IComando>> Ler(string? entrada)
    {
        var comandos = new List<IComando>();

        if (string.IsNullOrWhiteSpace(entrada))
        {
            return ResultadoLeitura<IReadOnlyList<IComando>>.Ok(comandos);
        }

        foreach (var caractere in entrada)
        {
            if (char.IsWhiteSpace(caractere))
            {
                continue;
            }

            var comando = CriarComando(caractere);

            if (comando is null)
            {
                return ResultadoLeitura<IReadOnlyList<IComando>>.Falha(
                    $"Comando inválido: \"{caractere}\". Use apenas E, D ou M.");
            }

            comandos.Add(comando);
        }

        return ResultadoLeitura<IReadOnlyList<IComando>>.Ok(comandos);
    }

    private static IComando? CriarComando(char caractere)
    {
        return char.ToUpperInvariant(caractere) switch
        {
            'E' => new ComandoEsquerda(),
            'D' => new ComandoDireita(),
            'M' => new ComandoMover(),
            _ => null,
        };
    }
}
