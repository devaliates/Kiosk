namespace Kiosk.Entities.Concrete;

public class KioskElement
    : AVMElement
{
    public string Name { get; private set; }

    public KioskElement(Koordinat koordinat, string name, KatPlani bulunduguKat, string rengi)
        : base(koordinat, bulunduguKat, rengi)
        => this.Name = name;

    public KioskElement(Koordinat koordinat, string name, string rengi)
        : base(koordinat, rengi)
        => this.Name = name;
}
