using RoboTupiniquim.Dominio.Comandos;

namespace RoboTupiniquim.Dominio;

public class Robo
{
    public Robo(Posicao posicao, Direcao direcao)
    {
        Posicao = posicao;
        Direcao = direcao;
    }

    public Posicao Posicao { get; private set; }

    public Direcao Direcao { get; private set; }

    public void VirarParaEsquerda()
    {
        Direcao = Direcao.Esquerda;
    }

    public void VirarParaDireita()
    {
        Direcao = Direcao.Direita;
    }

    public void Mover()
    {
        Posicao = Posicao.Mover(Direcao.DeltaX, Direcao.DeltaY);
    }

    public void Executar(IComando comando)
    {
        ArgumentNullException.ThrowIfNull(comando);

        comando.Executar(this);
    }

    public void ExecutarSequencia(IEnumerable<IComando> comandos)
    {
        ArgumentNullException.ThrowIfNull(comandos);

        foreach (var comando in comandos)
        {
            Executar(comando);
        }
    }

    public override string ToString()
    {
        return $"{Posicao.X} {Posicao.Y} {Direcao.Letra}";
    }
}
