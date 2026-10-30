namespace RoboTupiniquim.Dominio.Comandos;

public sealed class ComandoMover : IComando
{
    public void Executar(Robo robo)
    {
        ArgumentNullException.ThrowIfNull(robo);

        robo.Mover();
    }
}
