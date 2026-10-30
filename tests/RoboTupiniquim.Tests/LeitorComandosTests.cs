using RoboTupiniquim.Aplicacao;
using RoboTupiniquim.Dominio.Comandos;

namespace RoboTupiniquim.Tests;

public class LeitorComandosTests
{
    [Fact]
    public void Ler_ComSequenciaDoSpec_DeveCriarTodosOsComandosNaOrdem()
    {
        var resultado = new LeitorComandos().Ler("EMEMEMEMM");

        Assert.True(resultado.Sucesso);
        Assert.NotNull(resultado.Valor);
        Assert.Equal(9, resultado.Valor.Count);
        Assert.IsType<ComandoEsquerda>(resultado.Valor[0]);
        Assert.IsType<ComandoMover>(resultado.Valor[1]);
    }

    [Fact]
    public void Ler_ComMinusculas_DeveCriarComandos()
    {
        var resultado = new LeitorComandos().Ler("edm");

        Assert.True(resultado.Sucesso);
        Assert.NotNull(resultado.Valor);
        Assert.Equal(3, resultado.Valor.Count);
        Assert.IsType<ComandoEsquerda>(resultado.Valor[0]);
        Assert.IsType<ComandoDireita>(resultado.Valor[1]);
        Assert.IsType<ComandoMover>(resultado.Valor[2]);
    }

    [Fact]
    public void Ler_ComEspacosInternos_DeveIgnoraLos()
    {
        var resultado = new LeitorComandos().Ler(" E M D ");

        Assert.True(resultado.Sucesso);
        Assert.NotNull(resultado.Valor);
        Assert.Equal(3, resultado.Valor.Count);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Ler_ComSequenciaVazia_DeveRetornarListaVazia(string entrada)
    {
        var resultado = new LeitorComandos().Ler(entrada);

        Assert.True(resultado.Sucesso);
        Assert.NotNull(resultado.Valor);
        Assert.Empty(resultado.Valor);
    }

    [Theory]
    [InlineData("EXM")]
    [InlineData("M1")]
    [InlineData("MOV")]
    public void Ler_ComCaractereInvalido_DeveRetornarFalha(string entrada)
    {
        var resultado = new LeitorComandos().Ler(entrada);

        Assert.False(resultado.Sucesso);
        Assert.Null(resultado.Valor);
        Assert.Contains("Comando inválido", resultado.Erro);
    }

    [Fact]
    public void Ler_ComEntradaNula_DeveRetornarListaVazia()
    {
        var resultado = new LeitorComandos().Ler(null);

        Assert.True(resultado.Sucesso);
        Assert.NotNull(resultado.Valor);
        Assert.Empty(resultado.Valor);
    }
}
