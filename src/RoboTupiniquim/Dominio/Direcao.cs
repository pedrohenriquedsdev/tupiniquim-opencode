namespace RoboTupiniquim.Dominio;

public sealed class Direcao
{
    public static readonly Direcao Norte = new("Norte", 'N', 0, 1);
    public static readonly Direcao Leste = new("Leste", 'L', 1, 0);
    public static readonly Direcao Sul = new("Sul", 'S', 0, -1);
    public static readonly Direcao Oeste = new("Oeste", 'O', -1, 0);

    private static readonly Direcao[] Ordem = [Norte, Leste, Sul, Oeste];

    private int indice;

    static Direcao()
    {
        for (var i = 0; i < Ordem.Length; i++)
        {
            Ordem[i].indice = i;
        }
    }

    private Direcao(string nome, char letra, int deltaX, int deltaY)
    {
        Nome = nome;
        Letra = letra;
        DeltaX = deltaX;
        DeltaY = deltaY;
    }

    public string Nome { get; }

    public char Letra { get; }

    public int DeltaX { get; }

    public int DeltaY { get; }

    public Direcao Esquerda
    {
        get
        {
            return Ordem[(indice + Ordem.Length - 1) % Ordem.Length];
        }
    }

    public Direcao Direita
    {
        get
        {
            return Ordem[(indice + 1) % Ordem.Length];
        }
    }

    public static bool TentarObterPorLetra(char letra, out Direcao? direcao)
    {
        var letraNormalizada = char.ToUpperInvariant(letra);

        foreach (var candidata in Ordem)
        {
            if (candidata.Letra == letraNormalizada)
            {
                direcao = candidata;
                return true;
            }
        }

        direcao = null;
        return false;
    }

    public static Direcao PorLetra(char letra)
    {
        if (!TentarObterPorLetra(letra, out var direcao))
        {
            throw new ArgumentOutOfRangeException(nameof(letra), letra, "Direção inválida. Use N, S, L ou O.");
        }

        return direcao!;
    }

    public override string ToString()
    {
        return Nome;
    }
}
