using RoboTupiniquim.Dominio;
using RoboTupiniquim.Dominio.Comandos;

namespace RoboTupiniquim.Aplicacao;

public sealed class AplicacaoConsole
{
    private readonly IEntradaSaida entradaSaida;
    private readonly LeitorPosicao leitorPosicao = new();
    private readonly LeitorComandos leitorComandos = new();

    public AplicacaoConsole(IEntradaSaida entradaSaida)
    {
        ArgumentNullException.ThrowIfNull(entradaSaida);

        this.entradaSaida = entradaSaida;
    }

    public bool Executar()
    {
        var posicaoInicial = LerPosicaoInicial();

        if (posicaoInicial is null)
        {
            return false;
        }

        var comandos = LerComandos();

        if (comandos is null)
        {
            return false;
        }

        var robo = new Robo(posicaoInicial.Coordenada, posicaoInicial.Direcao);
        robo.ExecutarSequencia(comandos);

        entradaSaida.EscreverLinha($"Posição alcançada: {robo}");

        return true;
    }

    private PosicaoInicial? LerPosicaoInicial()
    {
        while (true)
        {
            entradaSaida.Escrever("Digite a posição inicial: ");

            var linha = entradaSaida.LerLinha();

            if (linha is null)
            {
                entradaSaida.EscreverLinha("Entrada encerrada. Nenhuma posição foi informada.");
                return null;
            }

            var resultado = leitorPosicao.Ler(linha);

            if (resultado.Sucesso)
            {
                return resultado.Valor;
            }

            entradaSaida.EscreverLinha($"Posição inválida. {resultado.Erro}");
        }
    }

    private IReadOnlyList<IComando>? LerComandos()
    {
        while (true)
        {
            entradaSaida.Escrever("Digite a sequência de comandos: ");

            var linha = entradaSaida.LerLinha();

            if (linha is null)
            {
                entradaSaida.EscreverLinha("Entrada encerrada. Nenhum comando foi informado.");
                return null;
            }

            var resultado = leitorComandos.Ler(linha);

            if (resultado.Sucesso)
            {
                return resultado.Valor;
            }

            entradaSaida.EscreverLinha($"Sequência inválida. {resultado.Erro}");
        }
    }
}
