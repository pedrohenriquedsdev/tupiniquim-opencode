using RoboTupiniquim.Aplicacao;

namespace RoboTupiniquim.Tests;

public class AplicacaoConsoleTests
{
    [Fact]
    public void Executar_ComEntradaValida_DeveExibirAPosicaoFinal()
    {
        var entradaSaida = new EntradaSaidaFake("1 2 N", "EMEMEMEMM");
        var aplicacao = new AplicacaoConsole(entradaSaida);

        var sucesso = aplicacao.Executar();

        Assert.True(sucesso);
        Assert.Equal("Posição alcançada: 1 3 N", entradaSaida.Saida[^1]);
    }

    [Fact]
    public void Executar_ComPosicaoInvalida_DeveSolicitarNovamente()
    {
        var entradaSaida = new EntradaSaidaFake("1 2", "1 2 N", "M");
        var aplicacao = new AplicacaoConsole(entradaSaida);

        var sucesso = aplicacao.Executar();

        Assert.True(sucesso);
        Assert.Contains(entradaSaida.Saida, mensagem => mensagem.StartsWith("Posição inválida."));
        Assert.Equal("Posição alcançada: 1 3 N", entradaSaida.Saida[^1]);
    }

    [Fact]
    public void Executar_ComSequenciaInvalida_DeveSolicitarNovamente()
    {
        var entradaSaida = new EntradaSaidaFake("1 2 N", "MX", "M");
        var aplicacao = new AplicacaoConsole(entradaSaida);

        var sucesso = aplicacao.Executar();

        Assert.True(sucesso);
        Assert.Contains(entradaSaida.Saida, mensagem => mensagem.StartsWith("Sequência inválida."));
        Assert.Equal("Posição alcançada: 1 3 N", entradaSaida.Saida[^1]);
    }

    [Fact]
    public void Executar_SemEntrada_DeveRetornarFalso()
    {
        var aplicacao = new AplicacaoConsole(new EntradaSaidaFake());

        var sucesso = aplicacao.Executar();

        Assert.False(sucesso);
    }

    private sealed class EntradaSaidaFake : IEntradaSaida
    {
        private readonly Queue<string?> entradas;

        public EntradaSaidaFake(params string?[] entradas)
        {
            this.entradas = new Queue<string?>(entradas);
        }

        public List<string> Saida { get; } = [];

        public void Escrever(string mensagem)
        {
            Saida.Add(mensagem);
        }

        public void EscreverLinha(string mensagem)
        {
            Saida.Add(mensagem);
        }

        public string? LerLinha()
        {
            return entradas.Count > 0 ? entradas.Dequeue() : null;
        }
    }
}
