using RoboTupiniquim.Aplicacao;
using RoboTupiniquim.Dominio;

namespace RoboTupiniquim.Tests;

public class LeitorPosicaoTests
{
    [Fact]
    public void Ler_ComEntradaValida_DeveRetornarPosicaoEDirecao()
    {
        var resultado = new LeitorPosicao().Ler("1 2 N");

        Assert.True(resultado.Sucesso);
        Assert.NotNull(resultado.Valor);
        Assert.Equal(new Posicao(1, 2), resultado.Valor.Coordenada);
        Assert.Same(Direcao.Norte, resultado.Valor.Direcao);
    }

    [Theory]
    [InlineData("  1   2   N  ")]
    [InlineData("1\t2\tN")]
    [InlineData("-3 4 o")]
    public void Ler_ComEspacosExtrasOuMinusculas_DeveSerAceito(string entrada)
    {
        var resultado = new LeitorPosicao().Ler(entrada);

        Assert.True(resultado.Sucesso);
        Assert.NotNull(resultado.Valor);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("1 2")]
    [InlineData("1 2 N 3")]
    [InlineData("a 2 N")]
    [InlineData("1 b N")]
    [InlineData("1 2 X")]
    [InlineData("1 2 NO")]
    public void Ler_ComEntradaInvalida_DeveRetornarFalha(string? entrada)
    {
        var resultado = new LeitorPosicao().Ler(entrada);

        Assert.False(resultado.Sucesso);
        Assert.Null(resultado.Valor);
        Assert.False(string.IsNullOrWhiteSpace(resultado.Erro));
    }
}
