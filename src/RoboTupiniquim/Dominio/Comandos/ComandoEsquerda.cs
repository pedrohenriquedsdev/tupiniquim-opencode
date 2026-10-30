namespace RoboTupiniquim.Dominio.Comandos;

public sealed class ComandoEsquerda : IComando
{
    public void Executar(Robo robo)
    {
        ArgumentNullException.ThrowIfNull(robo);

        robo.VirarParaEsquerda();
    }
}
