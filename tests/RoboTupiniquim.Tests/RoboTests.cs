using RoboTupiniquim.Aplicacao;
using RoboTupiniquim.Dominio;

namespace RoboTupiniquim.Tests;

public class RoboTests
{
    [Fact]
    public void ExemploDoSpec_DeveTerminarNaPosicaoUmTresNorte()
    {
        var robo = new Robo(new Posicao(1, 2), Direcao.Norte);
        var comandos = new LeitorComandos().Ler("EMEMEMEMM").Valor!;

        robo.ExecutarSequencia(comandos);

        Assert.Equal("1 3 N", robo.ToString());
    }

    [Theory]
    [InlineData('N', 1, 3)]
    [InlineData('L', 2, 2)]
    [InlineData('S', 1, 1)]
    [InlineData('O', 0, 2)]
    public void Mover_DeveAvancarUmaPosicaoNaDirecaoAtual(char letra, int xEsperado, int yEsperado)
    {
        var robo = new Robo(new Posicao(1, 2), Direcao.PorLetra(letra));

        robo.Mover();

        Assert.Equal(xEsperado, robo.Posicao.X);
        Assert.Equal(yEsperado, robo.Posicao.Y);
        Assert.Equal(letra, robo.Direcao.Letra);
    }

    [Theory]
    [InlineData('E', 'O')]
    [InlineData('D', 'L')]
    public void Virar_NaoDeveAlterarAPosicao(char comando, char letraEsperada)
    {
        var robo = new Robo(new Posicao(1, 2), Direcao.Norte);
        var comandos = new LeitorComandos().Ler(comando.ToString()).Valor!;

        robo.ExecutarSequencia(comandos);

        Assert.Equal(1, robo.Posicao.X);
        Assert.Equal(2, robo.Posicao.Y);
        Assert.Equal(letraEsperada, robo.Direcao.Letra);
    }

    [Fact]
    public void Mover_ComMovimentoLivre_DevePermitirCoordenadasNegativas()
    {
        var robo = new Robo(new Posicao(0, 0), Direcao.Sul);

        robo.Mover();

        Assert.Equal("0 -1 S", robo.ToString());
    }

    [Fact]
    public void ExecutarSequencia_Vazia_DeveManterAPosicaoInicial()
    {
        var robo = new Robo(new Posicao(1, 2), Direcao.Norte);

        robo.ExecutarSequencia([]);

        Assert.Equal("1 2 N", robo.ToString());
    }

    [Fact]
    public void Mover_DeveRetornarNovaPosicaoSemAlterarAAnterior()
    {
        var robo = new Robo(new Posicao(1, 2), Direcao.Norte);

        robo.Mover();

        Assert.NotEqual(new Posicao(1, 2), robo.Posicao);
    }

    [Fact]
    public void ToString_DeveSeguirFormatoDeSaida()
    {
        var robo = new Robo(new Posicao(-3, 4), Direcao.Oeste);

        Assert.Equal("-3 4 O", robo.ToString());
    }
}
