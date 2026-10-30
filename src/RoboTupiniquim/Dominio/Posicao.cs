namespace RoboTupiniquim.Dominio;

public readonly record struct Posicao(int X, int Y)
{
    public Posicao Mover(int deltaX, int deltaY)
    {
        return new Posicao(X + deltaX, Y + deltaY);
    }
}
