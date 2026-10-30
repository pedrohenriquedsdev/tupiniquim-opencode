namespace RoboTupiniquim.Dominio.Comandos;

public sealed class ComandoDireita : IComando
{
    public void Executar(Robo robo)
    {
        ArgumentNullException.ThrowIfNull(robo);

        robo.VirarParaDireita();
    }
}
