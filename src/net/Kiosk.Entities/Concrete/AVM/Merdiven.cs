namespace Kiosk.Entities.Concrete;

public class Merdiven
    : AVMElement
{
    public Merdiven(Koordinat koordinat, KatPlani bulunduguKat, string rengi)
        : base(koordinat, bulunduguKat, rengi)
    {
    }

    public Merdiven(Koordinat koordinat, string rengi)
        : base(koordinat, rengi)
    {
    }
}
