using RoboTupiniquim.Dominio;

namespace RoboTupiniquim.Tests;

public class DirecaoTests
{
    [Theory]
    [InlineData('N', 'O')]
    [InlineData('O', 'S')]
    [InlineData('S', 'L')]
    [InlineData('L', 'N')]
    public void Esquerda_DeveGirarNoventaGraus(char letraAtual, char letraEsperada)
    {
        var direcao = Direcao.PorLetra(letraAtual);

        Assert.Equal(letraEsperada, direcao.Esquerda.Letra);
    }

    [Theory]
    [InlineData('N', 'L')]
    [InlineData('L', 'S')]
    [InlineData('S', 'O')]
    [InlineData('O', 'N')]
    public void Direita_DeveGirarNoventaGraus(char letraAtual, char letraEsperada)
    {
        var direcao = Direcao.PorLetra(letraAtual);

        Assert.Equal(letraEsperada, direcao.Direita.Letra);
    }

    [Theory]
    [InlineData('N', 0, 1)]
    [InlineData('L', 1, 0)]
    [InlineData('S', 0, -1)]
    [InlineData('O', -1, 0)]
    public void Deslocamento_DeveCorresponderAoEixo(char letra, int deltaXEsperado, int deltaYEsperado)
    {
        var direcao = Direcao.PorLetra(letra);

        Assert.Equal(deltaXEsperado, direcao.DeltaX);
        Assert.Equal(deltaYEsperado, direcao.DeltaY);
    }

    [Fact]
    public void QuatroGirosParaAEsquerda_DevemRetornarADirecaoOriginal()
    {
        var direcao = Direcao.Norte;

        var resultado = direcao.Esquerda.Esquerda.Esquerda.Esquerda;

        Assert.Same(direcao, resultado);
    }

    [Theory]
    [InlineData('n', "Norte")]
    [InlineData('s', "Sul")]
    [InlineData('l', "Leste")]
    [InlineData('o', "Oeste")]
    public void PorLetra_DeveAceitarMinusculas(char letra, string nomeEsperado)
    {
        var direcao = Direcao.PorLetra(letra);

        Assert.Equal(nomeEsperado, direcao.Nome);
    }

    [Fact]
    public void TentarObterPorLetra_ComLetraInvalida_DeveRetornarFalso()
    {
        var encontrou = Direcao.TentarObterPorLetra('X', out var direcao);

        Assert.False(encontrou);
        Assert.Null(direcao);
    }

    [Fact]
    public void PorLetra_ComLetraInvalida_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Direcao.PorLetra('X'));
    }
}
