namespace Kiosk.Entities.Concrete;

public class Asansor
    : AVMElement
{
    public Asansor(Koordinat koordinat, KatPlani bulunduguKat, string rengi)
        : base(koordinat, bulunduguKat, rengi)
    {
    }

    public Asansor(Koordinat koordinat, string rengi)
        : base(koordinat, rengi)
    {
    }
}
