namespace Kiosk.Entities.Concrete;

public class Koordinat
{
    public enum XStrings : int
    {
        A = 1,
        B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
    }

    public int X { get; set; }
    public int Y { get; set; }

    public Koordinat(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Koordinat(XStrings x, int y)
    {
        X = (int)x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{((XStrings)X).ToString()}{Y}";
    }
}
